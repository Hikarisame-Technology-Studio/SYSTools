Imports System.IO
Class PeripheralsTools
    Dim AppPath As String = Directory.GetCurrentDirectory()
    Dim PeripheralsTools As String = "\Software Package\PeripheralsTools\"
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
        If DirExist(AppPath + PeripheralsTools) Then
        Else
            Directory.CreateDirectory(AppPath + PeripheralsTools)
        End If
    End Sub
    Private Sub TextBlock_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs)
        If DirExist(AppPath + PeripheralsTools) Then
            Process.Start("explorer.exe", AppPath + PeripheralsTools)
        End If
    End Sub
    Private Sub HKBTest_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles HKBTest.MouseDoubleClick
        If FileExist(AppPath + PeripheralsTools + "HKBTest\HKBTest.exe") Then
            Process.Start(AppPath + PeripheralsTools + "HKBTest\HKBTest.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub MouseTest_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles MouseTest.MouseDoubleClick
        If FileExist(AppPath + PeripheralsTools + "MouseTest\MouseTest.exe") Then
            Process.Start(AppPath + PeripheralsTools + "MouseTest\MouseTest.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub MouseRate_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles MouseRate.MouseDoubleClick
        If FileExist(AppPath + PeripheralsTools + "MouseRate\MouseRate.exe") Then
            Process.Start(AppPath + PeripheralsTools + "MouseRate\MouseRate.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub


End Class
