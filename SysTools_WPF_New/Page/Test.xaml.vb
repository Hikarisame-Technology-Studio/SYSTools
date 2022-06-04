Imports System.Management
Imports System.Xml
Imports System.IO


Class Test
    Private Function Boo_FileExist(ByVal Str_File As String) As Boolean
        Boo_FileExist = System.IO.File.Exists(Str_File)
    End Function
    Private Sub TestView_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles TestView.Loaded
        Dim FileLoad As String = System.AppDomain.CurrentDomain.BaseDirectory()
        If Boo_FileExist(FileLoad & "Info.xml") Then
            Xml()
        Else
            TestView.Items.Add("请点击检测配置按钮以获取最新配置信息")
        End If

    End Sub

    Private Sub TestBotton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles TestBotton.Click

        Test()
        Xml()

    End Sub


    Private Sub Info_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Info.Click

        Dim TestQueryDialog As New TestQueryDialog()
        TestQueryDialog.ShowAsync()

    End Sub

    Private Sub Xml()

        TestView.Items.Clear()

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("Info.xml")
        Dim xn As XmlNode = xmlDoc.SelectSingleNode("//ComputerSystem")
        Dim xnl As XmlNodeList = xn.ChildNodes
        Dim xnf As XmlNode
        Dim root As XmlElement = xmlDoc.DocumentElement
        Dim elemList As XmlNodeList = root.GetElementsByTagName("Attribute")
        Dim i As Integer
        For i = 0 To elemList.Count - 1
            xnf = xnl.Item(i)
            Dim xe As XmlElement = CType(xnf, XmlElement)
            Dim xnf1 As XmlNodeList = xe.ChildNodes
            TestView.Items.Add(xnf.Attributes("xmlns"))
            For Each xnf In xnf1
                TestView.Items.Add(Chr(32) + Chr(32) + Chr(32) + Chr(32) + xnf.InnerText)
            Next xnf
        Next i
    End Sub

    Dim TestConfigDialog As New TestConfigDialog()
    Dim TestErrorDialog As New TestErrorDialog()

    Private Sub Test()
        '操作系统信息
        Dim OpSystem As New ManagementObjectSearcher("select * from win32_OperatingSystem")
        Dim OpS As ManagementObjectCollection = OpSystem.Get()
        '计算机信息
        Dim cmsystem As New ManagementObjectSearcher("select * from win32_computersystem")
        Dim cms As ManagementObjectCollection = cmsystem.Get()
        'CPU信息
        Dim Process As New ManagementObjectSearcher("select * from win32_Processor")
        Dim CPUPr As ManagementObjectCollection = Process.Get()
        '网卡信息
        Dim NetAdapter As New ManagementObjectSearcher("SELECT *FROM   Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\%'")
        Dim NetAdapterDevice As ManagementObjectCollection = NetAdapter.Get()
        '局域网IP有关
        Dim NETconfig As New ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
        Dim MNetconfig As ManagementObjectCollection = NETconfig.Get()
        '声卡信息
        Dim Sound As New ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice")
        Dim SoundDevice As ManagementObjectCollection = Sound.Get()
        '显卡信息
        Dim Video As New ManagementObjectSearcher("SELECT * FROM Win32_VideoController")
        Dim VideoDevice As ManagementObjectCollection = Video.Get()
        '屏幕分辨率
        Dim DeskTop As New ManagementObjectSearcher("select * from Win32_VideoController")
        Dim DeskTopCont As ManagementObjectCollection = DeskTop.Get()

        Dim XmlSettings As XmlWriterSettings = New XmlWriterSettings()
        XmlSettings.Indent = True
        Try
            Using Xml_Writer As XmlWriter = XmlWriter.Create("Info.xml", XmlSettings)
                Xml_Writer.WriteStartDocument()

                Xml_Writer.WriteStartElement("Info")
                Xml_Writer.WriteStartElement("ComputerSystem")

                Xml_Writer.WriteStartElement("Attribute", "计算机信息")
                For Each cmsys As ManagementObject In cms
                    Dim memory As Double = cmsys.GetPropertyValue("totalphysicalmemory") / 1024 / 1024 / 1024
                    memory = Int(memory)

                    Xml_Writer.WriteElementString("Properties", "工作组:" + Chr(32) + cmsys.GetPropertyValue("domain").ToString())
                    Xml_Writer.WriteElementString("Properties", "计算机名称:" + Chr(32) + cmsys.GetPropertyValue("__server").ToString())
                    Xml_Writer.WriteElementString("Properties", "计算机制造商:" + Chr(32) + cmsys.GetPropertyValue("manufacturer").ToString())
                    Xml_Writer.WriteElementString("Properties", "计算机内存:" + Chr(32) + (memory + 1).ToString() + "GB")
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "操作系统信息")
                For Each OpSys As ManagementObject In OpS

                    Xml_Writer.WriteElementString("Properties", "Windows版本:" + Chr(32) + OpSys.GetPropertyValue("Caption").ToString())
                    Xml_Writer.WriteElementString("Properties", "系统位数:" + Chr(32) + OpSys.GetPropertyValue("OSArchitecture").ToString() + "操作系统")
                    Xml_Writer.WriteElementString("Properties", "内核版本号:" + Chr(32) + OpSys.GetPropertyValue("Version").ToString())
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "CPU信息")
                For Each CPU As Object In CPUPr

                    Xml_Writer.WriteElementString("Properties", "CPU型号:" + Chr(32) + CPU.GetPropertyValue("Name").ToString() + Chr(32) + CPU.GetPropertyValue("NumberOfCores").ToString() + "核" + CPU.GetPropertyValue("NumberOfLogicalProcessors").ToString() + "线程")
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "显卡信息")
                For Each VideoDevice_Object As ManagementObject In VideoDevice

                    Xml_Writer.WriteElementString("Properties", VideoDevice_Object.GetPropertyValue("Name").ToString())
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "网卡信息")
                For Each NetAdapter_Object As ManagementObject In NetAdapterDevice
                    Xml_Writer.WriteElementString("Properties", NetAdapter_Object.GetPropertyValue("Name").ToString())
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "局域网IP")
                For Each MNF As ManagementObject In MNetconfig
                    If MNF("IPEnabled") Then

                        Xml_Writer.WriteElementString("Properties", "内网IP地址:" + Chr(32) + MNF.GetPropertyValue("IpAddress")(0).ToString())
                        Xml_Writer.WriteElementString("Properties", "MAC地址:" + Chr(32) + MNF.GetPropertyValue("MACAddress").ToString())

                        Exit For
                    End If
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "声卡信息")
                For Each SoundDevice_Object As ManagementObject In SoundDevice
                    Xml_Writer.WriteElementString("Properties", SoundDevice_Object.GetPropertyValue("Caption").ToString())
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteStartElement("Attribute", "分辨率与颜色深度(有空位表示双卡或扩展未使用)")
                For Each DeskTop_Info As ManagementObject In DeskTopCont
                    Xml_Writer.WriteElementString("Properties", DeskTop_Info.GetPropertyValue("VideoModeDescription"))
                Next
                Xml_Writer.WriteEndElement()


                Xml_Writer.WriteEndElement()
                Xml_Writer.WriteEndElement()
                Xml_Writer.WriteEndDocument()

            End Using

            TestConfigDialog.ShowAsync()

        Catch er As Exception

            TestErrorDialog.ShowAsync()

            Using Xml_Writer As XmlWriter = XmlWriter.Create("Info.xml", XmlSettings)
                Xml_Writer.WriteStartDocument()
                Xml_Writer.WriteStartElement("Info")
                Xml_Writer.WriteStartElement("ComputerSystem")
                Xml_Writer.WriteStartElement("Attribute", "配置提取失败 请重试或联系开发者")
                Xml_Writer.WriteEndElement()
                Xml_Writer.WriteEndElement()
                Xml_Writer.WriteEndElement()
                Xml_Writer.WriteEndDocument()
            End Using

        End Try
    End Sub

End Class
