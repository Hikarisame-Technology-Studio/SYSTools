Imports System.IO

Class DetectionTools
    Dim AppPath As String = Directory.GetCurrentDirectory()
    Dim DiskTools As String = "\Software Package\DetectionTools\"
    Dim Dialog As New ProgramFailed()
    Private Function FileExist(ByVal Str_File As String) As Boolean
        '用于查找文件是否存在
        FileExist = File.Exists(Str_File)
    End Function
    Private Function DirExist(ByVal Str_Path As String) As Boolean
        '用于查找文件夹是否存在
        DirExist = Directory.Exists(Str_Path)
    End Function
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        If DirExist(AppPath + DiskTools) Then
        Else
            Directory.CreateDirectory(AppPath + DiskTools)
        End If
    End Sub
    Private Sub TextBlock_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs)
        If DirExist(AppPath + DiskTools) Then
            Process.Start("explorer.exe", AppPath + DiskTools)
        End If
    End Sub
    Private Sub Aida64_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Aida64.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "Aida64\Aida64.exe") Then
            Process.Start(AppPath + DiskTools + "Aida64\Aida64.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub CPU_Z_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles CPU_Z.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "CPUZ\CPUZ.exe") Then
            Process.Start(AppPath + DiskTools + "CPUZ\CPUZ.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub GPU_Z_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles GPU_Z.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "GPUZ\GPUZ.exe") Then
            Process.Start(AppPath + DiskTools + "GPUZ\GPUZ.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub HWinfo_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles HWinfo.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "HWinfo\HWinfo.exe") Then
            Process.Start(AppPath + DiskTools + "HWinfo\HWinfo.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub HWmonitor_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles HWmonitor.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "HWmonitor\HWmonitor.exe") Then
            Process.Start(AppPath + DiskTools + "HWmonitor\HWmonitor.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

End Class
