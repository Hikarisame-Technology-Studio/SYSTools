Imports System.Net.Http
Imports System.Xml
Imports AutoUpdaterDotNET

Class MainWindow
    Shared ReadOnly client As HttpClient = New HttpClient()
    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Try
            Dim MyReader As HttpResponseMessage = Await client.GetAsync("https://systools.hksstudio.work/Tools_Update/Tools_Update_Version")
            MyReader.EnsureSuccessStatusCode()
            Dim MyWebCode As String = Await MyReader.Content.ReadAsStringAsync()
            Version.Text = "当前本地版本为: " + (Application.ResourceAssembly.GetName().Version.ToString())
            Cloud_Version.Text = "云端版本为: " + MyWebCode
            If Application.ResourceAssembly.GetName().Version.ToString() = MyWebCode Then
                Version_Verify.Text = "暂无更新"
            Else
                Version_Verify.Text = "有新版本 等待获取更新.."
                AutoUpdateVersion()
            End If
        Catch err As HttpRequestException
            Cloud_Version.Text = "！- 网络或云端出现问题 - ！"
        End Try
    End Sub

    Sub AutoUpdateVersion()
        AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36"
        AutoUpdater.UpdateFormSize = New System.Drawing.Size(800, 600)
        AutoUpdater.Start("https://systools.hksstudio.work/Tools_Update/Tools_AutoUpdate.xml")
        Version_Verify.Text = "已获取更新 若不小心关闭请关闭该窗口重新启动"
    End Sub

End Class
