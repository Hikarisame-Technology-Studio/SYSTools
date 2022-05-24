Imports System.IO
Class TestTools
    Dim AppPath As String = Directory.GetCurrentDirectory()
    Dim DiskTools As String = "\Software Package\TestTools\"
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
    Private Sub Prime95_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Prime95.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "Prime95\Prime95.exe") Then
            Process.Start(AppPath + DiskTools + "Prime95\Prime95.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub IntelBurnTest_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles IntelBurnTest.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "IntelBurnTest\IntelBurnTest.exe") Then
            Try
                Process.Start(AppPath + DiskTools + "IntelBurnTest\IntelBurnTest.exe")
            Catch ex As Exception
            End Try
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub FurMark_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles FurMark.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "FurMark\FurMark.exe") Then
            Process.Start(AppPath + DiskTools + "FurMark\FurMark.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub MemTest_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles MemTest.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "MemTest\MemTest.exe") Then
            Process.Start(AppPath + DiskTools + "MemTest\MemTest.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

End Class
