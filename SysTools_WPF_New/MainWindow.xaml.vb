Imports System.IO
Imports System.Windows.Controls
Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        File.Delete("Info.xml")
        '程序启动数量限制
        Dim AppName As String = Process.GetCurrentProcess.ProcessName
        Dim ProcessTotal As Integer = Process.GetProcessesByName(AppName).Length
        If ProcessTotal > 1 Then
            MessageBox.Show("该程序有一个同名进程正在运行!", "程序冲突!", vbOKOnly)
            Me.Close()
        End If
        AppName = Nothing
        ProcessTotal = Nothing
        Title = "SysTools Ver" + (Application.ResourceAssembly.GetName().Version.ToString())
    End Sub

    Private Sub Home_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Home.MouseDown
        '主页
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/Home.xaml", UriKind.Absolute))
    End Sub

    Private Sub Fast_Detection_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Fast_Detection.MouseDown
        '系统配置快速检测 ( 基于 Windows Management Instrumentation )
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/Test.xaml", UriKind.Absolute))
    End Sub

    Private Sub Detection_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Detection_Tools.MouseDown
        '配置检测工具 ( 仅64位系统 )
        FrameContent.Navigate(New Uri("pack://application:,,,/ToolsPage/DetectionTools.xaml", UriKind.Absolute))
    End Sub
    Private Sub Test_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Test_Tools.MouseDown
        '硬件测试工具
        FrameContent.Navigate(New Uri("pack://application:,,,/ToolsPage/TestTools.xaml", UriKind.Absolute))
    End Sub

    Private Sub Disk_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Disk_Tools.MouseDown
        '硬盘工具
        FrameContent.Navigate(New Uri("pack://application:,,,/ToolsPage/DiskTools.xaml", UriKind.Absolute))
    End Sub

    Private Sub Peripherals_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Peripherals_Tools.MouseDown
        '外设工具
        FrameContent.Navigate(New Uri("pack://application:,,,/ToolsPage/PeripheralsTools.xaml", UriKind.Absolute))
    End Sub

    Private Sub Repairing_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Repairing_Tools.MouseDown
        '运行库安装工具
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/RepairingTools.xaml", UriKind.Absolute))
    End Sub
    Private Sub Adb_Tools_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Adb_Tools.MouseDown
        'Adb工具Box
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/AdbTools.xaml", UriKind.Absolute))
        Dim Dialog As New AdbDialog()
        Dialog.ShowAsync()
    End Sub
    Private Sub Windows_Activation_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Windows_Activation.MouseDown
        '系统激活工具
        FrameContent.Navigate(New Uri("pack://application:,,,/ToolsPage/Activation.xaml", UriKind.Absolute))
    End Sub

    Private Sub About_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles About.MouseDown
        '关于
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/About.xaml", UriKind.Absolute))
    End Sub

    Private Sub GithubRecommend_Page_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ChangeWindows_Page.MouseDown
        'Windows时间线
        FrameContent.Navigate(New Uri("pack://application:,,,/Page/ChangeWindows.xaml", UriKind.Absolute))
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        Dim AppPath As String = Directory.GetCurrentDirectory()
        Dim Bitmap As New BitmapImage()
        If FileExist(AppPath + "\Config\BackImage\1.jpg") Then
            Bitmap.BeginInit()
            Bitmap.UriSource = New Uri(AppPath + "\Config\BackImage\1.jpg")
            Bitmap.EndInit()
            BackImage.Source = Bitmap
        ElseIf FileExist(AppPath + "\Config\BackImage\1.png") Then
            Bitmap.BeginInit()
            Bitmap.UriSource = New Uri(AppPath + "\Config\BackImage\1.png")
            Bitmap.EndInit()
            BackImage.Source = Bitmap
        End If

    End Sub

    Private Function FileExist(ByVal Str_File As String) As Boolean
        FileExist = System.IO.File.Exists(Str_File)
    End Function

    Private Function DirExist(ByVal Str_Path As String) As Boolean
        DirExist = System.IO.Directory.Exists(Str_Path)
    End Function

    Private Sub About_PreviewMouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles About.PreviewMouseDoubleClick
        Dim BackNew As New BackImageNew()
        Dim Backold As New BackImageOld()
        Dim AppPath As String = Directory.GetCurrentDirectory()
        If DirExist(AppPath + "\Config\BackImage") Then
            If FileExist(AppPath + "\Config\BackImage\Null.txt") Then
                Backold.ShowAsync()
            Else
                BackText()
                Backold.ShowAsync()
            End If
        Else
            BackNew.ShowAsync()
            Directory.CreateDirectory(AppPath + "\Config\BackImage")
            BackText()
        End If
    End Sub
    Public Sub BackText()
        Dim AppPath As String = Directory.GetCurrentDirectory()
        File.Create(AppPath + "\Config\BackImage\Null.txt").Close()
        Dim sw As StreamWriter = New StreamWriter(AppPath + "\Config\BackImage\Null.txt")
        sw.WriteLine("恭喜你找到一个神奇的彩蛋")
        sw.WriteLine("找一张你喜欢的格式为(.Jpg/.Png)的图片")
        sw.WriteLine("重命名为1 保持原文件后戳 丢到这个文件夹里面")
        sw.WriteLine("不出意外应该会修改软件背景图片")
        sw.WriteLine("记得重启软件 我没加热更新(因为我不会 （；´д｀）ゞ)")
        sw.Close()
    End Sub

End Class
