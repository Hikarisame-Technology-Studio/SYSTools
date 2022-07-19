Imports System.Net.Http
Imports AutoUpdaterDotNET
Imports System.IO

Class About
    Shared ReadOnly Client As New HttpClient()
    Private Sub QQ_Click(sender As Object, e As RoutedEventArgs) Handles QQ.Click
        Process.Start("https://jq.qq.com/?_wv=1027&k=qTaIu5Fa")
    End Sub

    Private Sub Web_Click(sender As Object, e As RoutedEventArgs) Handles Web.Click
        Process.Start("https://tools.hksstudio.work")
    End Sub

    Private Sub Github_Click(sender As Object, e As RoutedEventArgs) Handles Github.Click
        Process.Start("https://github.com/Hikarisame-Technology-Studio/SYSTools")
    End Sub

    Sub AutoUpdateVersion()
        AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36"
        AutoUpdater.UpdateFormSize = New System.Drawing.Size(800, 600)
        AutoUpdater.Start("https://systools.hksstudio.work/SYSTools_AutoUpdate.xml")
    End Sub
    '软件本体更新检测
    Private Async Sub Update_Click(sender As Object, e As RoutedEventArgs) Handles Update.Click
        Dim MyReader As HttpResponseMessage = Await Client.GetAsync("https://systools.hksstudio.work/SYSTools_Update_Version")
        MyReader.EnsureSuccessStatusCode()
        Dim MyWebCode As String = Await MyReader.Content.ReadAsStringAsync()
        If Application.ResourceAssembly.GetName().Version.ToString() >= MyWebCode Then
            Dim Dialog As New NoUpdate()
            Await Dialog.ShowAsync().ConfigureAwait(False)
        Else
            AutoUpdateVersion()
        End If
    End Sub
    '工具包更新检测
    Private Async Sub Tool_Update_Click(sender As Object, e As RoutedEventArgs) Handles Tool_Update.Click
        FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory() + "//" + "SysTools_WPF_Update(Tools).exe"))
        Dim ToolsFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Directory.GetCurrentDirectory() + "\SysTools_WPF_Update(Tools).exe")
        Dim MyReader As HttpResponseMessage = Await Client.GetAsync("https://systools.hksstudio.work/Tools_Update/Tools_Update_Version")
        MyReader.EnsureSuccessStatusCode()
        Dim MyWebCode As String = Await MyReader.Content.ReadAsStringAsync()
        If ToolsFileVersionInfo.FileVersion = MyWebCode Then
            Dim Dialog As New NoUpdate()
            Await Dialog.ShowAsync().ConfigureAwait(False)
        Else
            Process.Start("SysTools_WPF_Update(Tools).exe")
        End If
    End Sub

End Class
