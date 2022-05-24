Imports System.Net.Http

Class Home
    Shared ReadOnly client As HttpClient = New HttpClient()

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)

        '欢迎头部文本
        Dim UserName = Environment.UserName
        Home_SP_Tip.ToolTip = "您好 :" + Chr(32) + UserName


        '开机时间/启动时间获取
        Dim UPTime As DateTime = DateTime.Now.AddMilliseconds(-(Environment.TickCount))
        Dim Nows As TimeSpan = Now - UPTime
        Dim RunTime_ As String = Nows.Days & " 天 " & Nows.Hours & " 时 " & Nows.Minutes & " 分 " & Nows.Seconds & " 秒 "
        OpenTime.Text = UPTime
        RunTime.Text = RunTime_


        '一言卡片获取
        Try
            Dim MyReader As HttpResponseMessage = Await client.GetAsync("https://v1.hitokoto.cn/?c=b&c=a&encode=text")
            MyReader.EnsureSuccessStatusCode()
            Dim MyWebCode As String = Await MyReader.Content.ReadAsStringAsync()
            Hitokoto.Text = MyWebCode
        Catch err As HttpRequestException
            Hitokoto.Text = "！- 网络或网站出现问题 - ！"
        End Try


        If Hitokoto.Text = "！- 网络或网站出现问题 - ！" Then
            IPNull.Text = "！- 网络未连接 - ！"
            IPv4.Text = "!"
            IPv6.Text = "!"
        End If


    End Sub

    '公网IP获取
    Private Sub IPv4_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles IPv4.MouseDown
        IPv4_Info()
    End Sub

    Private Sub IPv6_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles IPv6.MouseDown
        IPv6_Info()
    End Sub

    Private Async Sub IPv4_Info()
        Try
            Dim IPv4Test As HttpResponseMessage = Await client.GetAsync("https://api-ipv4.ip.sb/ip")
            IPv4Test.EnsureSuccessStatusCode()
            Dim IPv4 As String = Await IPv4Test.Content.ReadAsStringAsync()
            Me.IPv4.Text = "当前IPv4地址 : " + IPv4
        Catch IPv4Error As HttpRequestException
            IPv4.Text = "!"
        End Try
    End Sub

    Private Async Sub IPv6_Info()
        Try
            Dim IPv6Test As HttpResponseMessage = Await client.GetAsync("https://speed.neu6.edu.cn/getIP.php")
            IPv6Test.EnsureSuccessStatusCode()
            Dim IPv6 As String = Await IPv6Test.Content.ReadAsStringAsync()
            Me.IPv6.Text = "当前IPv6地址 : " + IPv6
        Catch IPv6Error As HttpRequestException
            IPv6.Text = "!"
        End Try
    End Sub

End Class
