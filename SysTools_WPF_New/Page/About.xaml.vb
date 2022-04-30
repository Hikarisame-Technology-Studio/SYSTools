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
        AutoUpdater.Start()
    End Sub
End Class
