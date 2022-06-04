Imports System.IO

Class RepairingTools
    Dim AppPath As String = Directory.GetCurrentDirectory()
    Dim RepairingTools As String = "\Software Package\RepairingTools\"
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
        If DirExist(AppPath + RepairingTools) Then
        Else
            Directory.CreateDirectory(AppPath + RepairingTools)
        End If
    End Sub
    Private Sub TextBlock_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs)
        If DirExist(AppPath + RepairingTools) Then
            Process.Start("explorer.exe", AppPath + RepairingTools)
        End If
    End Sub
    Private Sub DirectX_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles DirectX.MouseDoubleClick
        If FileExist(AppPath + RepairingTools + "DirectX\DirectXinstall.exe") Then
            Try
                Process.Start(AppPath + RepairingTools + "DirectX\DirectXinstall.exe")
            Catch ex As Exception
            End Try
        Else
            Dialog.ShowAsync()
        End If
    End Sub

End Class
