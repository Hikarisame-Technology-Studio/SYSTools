Imports System.IO

Class DiskTools
    Dim AppPath As String = Directory.GetCurrentDirectory()
    Dim DiskTools As String = "\Software Package\DiskTools\"
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
    Private Sub AS_SSD_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles AS_SSD.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "AS SSD Benchmark\AS SSD Benchmark.exe") Then
            Process.Start(AppPath + DiskTools + "AS SSD Benchmark\AS SSD Benchmark.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub CrystalDiskInfo_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles CrystalDiskInfo.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe") Then
            Process.Start(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub CrystalDiskMark_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles CrystalDiskMark.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "CrystalDiskMark\CrystalDiskMark.exe") Then
            Process.Start(AppPath + DiskTools + "CrystalDiskMark\CrystalDiskMark.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub Disk_Benchmark_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Disk_Benchmark.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "DiskBenchmark\DiskBenchmark.exe") Then
            Process.Start(AppPath + DiskTools + "DiskBenchmark\DiskBenchmark.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub DiskGenius_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles DiskGenius.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "DiskGenius\DiskGenius.exe") Then
            Process.Start(AppPath + DiskTools + "DiskGenius\DiskGenius.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub HD_Tune_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles HD_Tune.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "HDTune\HDTune.exe") Then
            Process.Start(AppPath + DiskTools + "HDTune\HDTune.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub LLFTOOL_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles LLFTOOL.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "LLFTOOL\LLFTOOL.exe") Then
            Process.Start(AppPath + DiskTools + "LLFTOOL\LLFTOOL.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub PartAssist_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles PartAssist.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "PartAssist\PartAssist.exe") Then
            Process.Start(AppPath + DiskTools + "PartAssist\PartAssist.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub SSD_Z_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles SSD_Z.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "SSDZ\SSDZ.exe") Then
            Process.Start(AppPath + DiskTools + "SSDZ\SSDZ.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub

    Private Sub Victoria_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Victoria.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe") Then
            Process.Start(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub
    Private Sub H2TestW_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles H2TestW.MouseDoubleClick
        If FileExist(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe") Then
            Process.Start(AppPath + DiskTools + "CrystalDiskInfo\CrystalDiskInfo.exe")
        Else
            Dialog.ShowAsync()
        End If
    End Sub


End Class
