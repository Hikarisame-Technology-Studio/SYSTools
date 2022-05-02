Imports AutoUpdaterDotNET

Class About
    Private Sub QQ_Click(sender As Object, e As RoutedEventArgs) Handles QQ.Click
        Process.Start("https://jq.qq.com/?_wv=1027&k=qTaIu5Fa")
    End Sub

    Private Sub Web_Click(sender As Object, e As RoutedEventArgs) Handles Web.Click
        Process.Start("https://tools.hksstudio.work")
    End Sub

    Private Sub Github_Click(sender As Object, e As RoutedEventArgs) Handles Github.Click
        Process.Start("https://github.com/Hikarisame-Technology-Studio/SYSTools")
    End Sub

    Private Sub Update_Click(sender As Object, e As RoutedEventArgs) Handles Update.Click
        AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36"
        AutoUpdater.UpdateFormSize = New System.Drawing.Size(800, 600)
        AutoUpdater.Start("https://systools.hksstudio.work/SYSTools_AutoUpdate.xml")
    End Sub

    Private Sub Tool_Update_Click(sender As Object, e As RoutedEventArgs) Handles Tool_Update.Click
        AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36"
        AutoUpdater.UpdateFormSize = New System.Drawing.Size(800, 600)
        AutoUpdater.Start("https://systools.hksstudio.work/SYSTools_Tools_AutoUpdate.xml")
    End Sub
End Class
