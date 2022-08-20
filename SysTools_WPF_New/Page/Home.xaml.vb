Imports System.Management
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Windows.Threading

Class Home
    Shared ReadOnly client As HttpClient = New HttpClient()
    Dim UPTime As DateTime = DateTime.Now.AddMilliseconds(-(Environment.TickCount))

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        '开机时间获取
        OpenTime.Text = UPTime

        '欢迎头部文本
        Dim UserName = Environment.UserName
        Home_SP_Tip.ToolTip = "您好 :" + Chr(32) + UserName


        '一言卡片获取
        Try
            Dim MyReader As HttpResponseMessage = Await client.GetAsync("https://v1.hitokoto.cn/?c=b&c=a&encode=text")
            MyReader.EnsureSuccessStatusCode()
            Dim MyWebCode As String = Await MyReader.Content.ReadAsStringAsync()
            Hitokoto.Text = MyWebCode
        Catch err As Exception
            Hitokoto.Text = "！- 网络或网站出现问题 - ！"
        End Try

        If Hitokoto.Text = "！- 网络或网站出现问题 - ！" Then
            IPv4.Text = "!"
            IPv6.Text = "!"
        End If

        '获取Windows系统版本与版本号
        Dim OpSystem As New ManagementObjectSearcher("SELECT * FROM win32_OperatingSystem")
        Dim OpS As ManagementObjectCollection = OpSystem.Get()
        For Each OpSys As ManagementObject In OpS
            Windows_Name.Text = OpSys.GetPropertyValue("Caption").ToString()
            Windows_Version.Text = OpSys.GetPropertyValue("Version").ToString()
        Next

        '计时器
        Dim Timer As New DispatcherTimer()
        AddHandler Timer.Tick, AddressOf Timer_Tick
        Timer.Interval = New TimeSpan(0, 0, 1)
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        '启动时间获取并更新
        Dim Nows As TimeSpan = Now - UPTime
        Dim RunTime_ As String = Nows.Days & " 天 " & Nows.Hours & " 时 " & Nows.Minutes & " 分 " & Nows.Seconds & " 秒 "
        RunTime.Text = RunTime_
        CommandManager.InvalidateRequerySuggested()
    End Sub

    '左键获取IP地址
    Private Sub IPv4_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles IPv4.MouseLeftButtonDown
        IPv4_Info()
    End Sub
    Private Sub IPv6_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles IPv6.MouseLeftButtonDown
        IPv6_Info()
    End Sub
    '显示IP后右键隐藏
    Private Sub IPv4_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles IPv4.MouseRightButtonDown
        IPv4.Text = "***.***.***.***"
    End Sub

    Private Sub IPv6_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles IPv6.MouseRightButtonDown
        IPv6.Text = "****:****:****:****:****:****:****:****"
    End Sub
    '获取IP地址
    Private Async Sub IPv4_Info()
        Try
            Me.IPv4.Text = "Now Loading..."
            Dim IPv4Test As HttpResponseMessage = Await client.GetAsync("https://myip.ipip.net/")
            IPv4Test.EnsureSuccessStatusCode()
            Dim IPv4 As String = Await IPv4Test.Content.ReadAsStringAsync()
            Me.IPv4.Text = Regex.Replace(IPv4, "[\r\n]", "")
        Catch IPv4Error As Exception
            IPv4.Text = "当前网络可能没有IPV4地址或获取失败"
        End Try
    End Sub

    Private Async Sub IPv6_Info()
        Try
            Me.IPv6.Text = "Now Loading..."
            Dim IPv6Test As HttpResponseMessage = Await client.GetAsync("https://speed.neu6.edu.cn/getIP.php")
            IPv6Test.EnsureSuccessStatusCode()
            Dim IPv6 As String = Await IPv6Test.Content.ReadAsStringAsync()
            Me.IPv6.Text = "当前IPv6地址 : " + IPv6
        Catch IPv6Error As Exception
            IPv6.Text = "当前网络可能没有IPV6地址或获取失败"
        End Try
    End Sub


End Class
