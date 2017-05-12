Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Threading
'Imports System.Net.Sockets
Imports System.IO.Ports
Imports AForge
Imports AForge.Imaging
Imports AForge.Imaging.Filters
Imports AForge.Video
Imports AForge.Video.VFW
Imports AForge.Video.DirectShow
Imports AForge.Vision.Motion
Imports AForge.Math.Geometry


Public Class Form1
    Private First As Boolean
    Private Loop_1 As Long
    Private Loop_2 As Long
    Private Loop_3 As Long
    Private MyImage As Bitmap
    Private MyGraphic As Graphics
    Private VideoGraphic As Graphics
    Private Mypen As Pen
    Private DelPen As Pen
    Private WithEvents Timer1 As Windows.Forms.Timer
    Private _Shoulder As Bar
    Private _Elbow As Bar
    Private _Wrist As Bar
    Private _Arm As Arm
    Private _Initialized As Boolean = False
    Private _TurnTableOn As Boolean = False
    Private _UpperArmLength As Double = 31.6875
    Private _ForearmLength As Double = 31.5 '31.75
    Private _ArmSegmentLength = 31.625
    Private _ArcRadius As Single = 24
    'Private _BaseLength As Double = _UpperArmLength + _ArcRadius + 12

    Private _ShoulderDistance As Single = 33.9375
    Private _SerialPortAvailable As Boolean = True
    Private _WristGamma As Single
    Private _Model As ArmModel = Nothing
    Private _Running As Boolean = False
    Public Event SerialDataEvent(ByVal Val As String)
    Private _PictureTaken As Boolean = False
    Private _SerialData As String
    Private _Panic As Boolean = False
    Private _Messages As CircularQueue(Of String) = New CircularQueue(Of String)(50)
    Private _BaseDirectory As String
    Private _ImageFolder = "default"
    Private _TakePicture As Boolean = False
    Private _SnapShotName As String = ""
    Private _MovingMarker As Boolean = False
    Private _FindTable As Boolean = False



    'Dim tcpClient As New System.Net.Sockets.TcpClient()
    'Dim serverStream As NetworkStream
    Dim ComPort As SerialPort
    Private _SendingBytes As Boolean = False
    Private _DisplayBuffer As List(Of String)

    Private _ArmModel As ArmModel

    Private videoDevices As FilterInfoCollection

    Private Const atargetElbow As String = "E"
    Private Const atargetShoulder As String = "S"
    Private Const atargetWrist As String = "W"
    Private Const atargetAll As String = "*"
    Private Const atargetPushShutter As String = "B"
    Private Const atargetCamera As String = "C"
    Private Const atargetTurntable As String = "T"
    Private Const atargetArm As String = "A"


    Private Const acmdStop As String = "!"
    Private Const acmdSetAngle As String = "A"
    Private Const acmdInitialize As String = "I"
    Private Const acmdTakePicture As String = "T"
    Private Const acmdSeek As String = "S"
    Private Const acmdSetMaxPower As String = "P"
    Private Const acmdSetMaxSpeed As String = "S"

    Public Delegate Sub UpdateMsg(ByVal Msg As String)
    Private Msg As String = ""
    Private MsgCnt As Integer = 0
    Public Event RobotMessage(ByVal Msg As String)
    Private _AlignmentForm As CameraAlignment = Nothing
    Private _AlignmentBusy As Boolean = False
    Private _ShowingVideo As Boolean = False
    Private _TurnTableThread As Thread

    Public Delegate Sub MoveToStartDelegate()
    Public Delegate Sub SetArmDelegate(ByVal Angle As Single, ByVal ArcRadius As Single, ByVal Distance As Single)
    Public Delegate Sub RunTurntableDelegate(ByVal angle As Single)
    Public Delegate Sub PrintDelegate(ByVal Msg As String)

    Private Declare Function GetInputState Lib "user32" () As Integer


    Event PictureTaken()


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Mypen = New Pen(Color.Black, 1)
        DelPen = New Pen(Color.White, 1)
        Timer1 = New Windows.Forms.Timer
        MyImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        MyGraphic = Graphics.FromImage(MyImage)
        VideoGraphic = videoSourcePlayer.CreateGraphics()

        'Debugger.Launch()

        _Shoulder = New Bar(PictureBox1, 8, _UpperArmLength * 3)
        _Shoulder.Anchor = New PointF(PictureBox1.Width / 2, PictureBox1.Height * 0.75)
        AddHandler _Shoulder.PositionChanged, AddressOf OnPositionChanged_Shoulder

        _Elbow = New Bar(PictureBox1, 8, _ForearmLength * 3)
        AddHandler _Elbow.PositionChanged, AddressOf OnPositionChanged_Elbow

        _Wrist = New Bar(PictureBox1, 8, 50)
        '_Wrist.StartOffset = -90
        _Wrist.RotationDirection = RotationDirection.CW

        AddHandler _Wrist.PositionChanged, AddressOf OnPositionChanged_Wrist

        _Arm = New Arm(PictureBox1, New PointF(PictureBox1.Width / 2, PictureBox1.Height * 0.75))
        _Arm.AngleOffset = 90
        _Arm.Add(_Shoulder)
        _Arm.Add(_Elbow)
        _Arm.Add(_Wrist)



        Timer1.Interval = 15
        Timer1.Start()

        'ComPort = New SerialPort("COM7", 115200, Parity.None, 8, StopBits.One)
        'ComPort = New SerialPort("COM7", 115200)
        Try
            SerialPort1.Open()
        Catch ex As Exception
            _SerialPortAvailable = False
        End Try


        'tcpClient.Connect("192.168.1.177", 80)
        _Elbow.Angle = 175

        CreateModel()
        '_Model = New ArmModel(_ArmSegmentLength, _ArcRadius, _ShoulderDistance)
        '_Model.Calculate(0)
        _Wrist.StartOffset = -90 '+ 270 - _Model.gamma
        _WristGamma = _Model.gamma


        AddHandler SerialDataEvent, AddressOf SerialDataHandler

        InitDevicesCombo()

        AddHandler RobotMessage, AddressOf OnRobotMessage
        'SerialPort1.Open()

        jpElbow.Kp.Value = My.Settings.ElbowKp
        jpElbow.Ki.Value = My.Settings.ElbowKi
        jpElbow.Kd.Value = My.Settings.ElbowKd
        jpElbow.MaxPower.Value = My.Settings.ElbowMaxPower

        jpShoulder.Kp.Value = My.Settings.ShoulderKp
        jpShoulder.Ki.Value = My.Settings.ShoulderKi
        jpShoulder.Kd.Value = My.Settings.ShoulderKd
        jpShoulder.MaxPower.Value = My.Settings.ShoulderMaxPower

        jpWrist.AngleFactor.Value = My.Settings.WristAngleFactor
        jpWrist.AngleOffset.Value = My.Settings.WristAngleOffset

        AddHandler My.Application.Shutdown, AddressOf OnAppShutdown
        _BaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) & "\RobotCam"
        My.Computer.FileSystem.CreateDirectory(_BaseDirectory)
        PrepareImageFolder(_ImageFolder)
        tbarDistance.Value = 33.9375
        tbarRadius.Value = 24

        _TurnTableThread = New Thread(AddressOf Run)

    End Sub

    Private Sub OnAppShutdown()
        videoSourcePlayer.Stop()
        My.Settings.ElbowKp = jpElbow.Kp.Value
        My.Settings.ElbowKi = jpElbow.Ki.Value
        My.Settings.ElbowKd = jpElbow.Kd.Value
        My.Settings.ElbowMaxPower = jpElbow.MaxPower.Value

        My.Settings.ShoulderKp = jpShoulder.Kp.Value
        My.Settings.ShoulderKi = jpShoulder.Ki.Value
        My.Settings.ShoulderKd = jpShoulder.Kd.Value
        My.Settings.ShoulderMaxPower = jpShoulder.MaxPower.Value

        My.Settings.WristAngleFactor = jpWrist.AngleFactor.Value
        My.Settings.WristAngleOffset = jpWrist.AngleOffset.Value

        My.Settings.Save()

    End Sub

    Private Sub PrepareImageFolder(ByVal Name As String)
        Dim Folder As String = _BaseDirectory & "\" & Name
        If My.Computer.FileSystem.DirectoryExists(Folder) Then
            My.Computer.FileSystem.DeleteDirectory(Folder, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(Folder)

    End Sub

    Private Sub SaveImage(ByVal Image As Bitmap, ByVal Name As String)
        Dim Filename As String = String.Format("{0}\{1}\{2}.jpg", _BaseDirectory, _ImageFolder, Name)
        If Not Image Is Nothing Then
            Image.Save(Filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub
    Private Sub CreateModel()
        _Model = New ArmModel(_UpperArmLength, _ForearmLength, _ArcRadius, _ShoulderDistance)
        _Model.Calculate(0)
    End Sub

    Private Sub SerialDataHandler(ByVal Val As String)
        txtDisplay.Text += Val
        DoAppEvents()
    End Sub


    Private Sub Timer1_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not _ShowingVideo Then
            _ShowingVideo = True
            MyGraphic.Clear(Color.White)
            Dim P As New Pen(Color.DarkGray)

            MyGraphic.DrawArc(P, _
                              _Shoulder.Anchor.X + _ShoulderDistance * 3 - _ArcRadius * 3, _
                              _Shoulder.Anchor.Y - _ArcRadius * 3, _
                              _ArcRadius * 6, _ArcRadius * 6, 180, 90)
            MyGraphic.DrawLine(P, _Shoulder.Anchor.X - _ShoulderDistance * 3, _Shoulder.Anchor.Y, _Shoulder.Anchor.X + _ShoulderDistance * 3, _Shoulder.Anchor.Y)
            _Arm.Draw(MyGraphic)

            PictureBox1.Image = MyImage
            _ShowingVideo = False
        End If
    End Sub

    Private Sub OnPositionChanged_Shoulder(ByVal sender As Bar)
        Dim A As Integer = 180 - sender.Angle
        txtShoulder_.Text = A

        If A > 180 And A < 270 Then A = 180
        If A >= 270 Then A = 0

        If _Initialized Then
            SendCommand("S", "A", A)
        End If

    End Sub

    Private Sub OnPositionChanged_Elbow(ByVal sender As Bar)
        Dim A As Integer = 180 - sender.Angle
        txtElbow_.Text = A

        If A > 180 And A < 270 Then A = 180
        If A >= 270 Then A = 0

        If _Initialized Then
            SendCommand("E", "A", A)
        End If

    End Sub

    Private Sub OnPositionChanged_Wrist(ByVal sender As Bar)
        Dim A As Integer = sender.Angle ' * 67 / 90 + 10
        txtWrist_.Text = A

        'If A >= 180 Then A = 180


        If _Initialized Then
            SendCommand("W", "A", A)
        End If
    End Sub

    Private Sub SendBytes(ByVal Bytes() As Byte)
        If Not _SendingBytes Then
            _SendingBytes = True

            'Dim serverStream As NetworkStream = tcpClient.GetStream()

            'serverStream.Write(Bytes, 0, Bytes.Length)
            'serverStream.Flush()

            'ComPort.Open()
            If _SerialPortAvailable Then
                SerialPort1.Write(Bytes, 0, Bytes.Length)
            End If

            'ComPort.Close()
            _SendingBytes = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Bytes(3) As Byte

        'Bytes(0) = System.Text.Encoding.ASCII.GetBytes("*")(0)
        'Bytes(1) = 0
        'Bytes(2) = 0
        'Bytes(3) = 0
        _Panic = True
        _Running = False
        _Messages.Clear()
        SendCommand("*", "!", 0)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim Bytes(2) As Byte

        'Bytes(0) = System.Text.Encoding.ASCII.GetBytes("I")(0)
        'Bytes(1) = 0
        'Bytes(2) = 0

        'SendBytes(Bytes)
        Dim Result As DialogResult
        Result = MessageBox.Show("ReCalibrate?", "", MessageBoxButtons.YesNo)
        If Result = Windows.Forms.DialogResult.Yes Then

            SendCommand("*", "I", 0)
            MessageBox.Show("Calibrate the arm")
        End If
        _Initialized = True
    End Sub



    Private Sub SendCommand(ByVal Joint As String, ByVal Cmd As String, ByVal Value As String)
        'Dim Bytes(3) As Byte

        'Bytes(0) = System.Text.Encoding.ASCII.GetBytes(Joint)(0)
        'Bytes(1) = System.Text.Encoding.ASCII.GetBytes(Cmd)(0)
        'Bytes(2) = Value And 255
        'Bytes(3) = (Value And 255 * 256) >> 8

        'SendBytes(Bytes)
        'ComPort.Open()
        Dim Msg As String
        Msg = String.Format("{0},{1},{2}{3}", Joint, Cmd, Value, vbCr)
        _Messages.Push(Msg)


        'txtDisplay.Text += Msg
        'ComPort.Close()
    End Sub

    Private Sub btnSetWrist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Wrist.Angle = txtWrist_.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'SendCommand("B", "P", 0)
        SendCommand("C", "T", 5)
    End Sub

    Private Sub btnTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable.Click
        _TurnTableOn = Not _TurnTableOn

        If _TurnTableOn Then
            'SendCommand("T", "S", 128)
            btnTable.Text = "Stop Table"
            btnTable.BackColor = Color.Red
            btnTable.ForeColor = Color.White
            timerTurnTable.Enabled = True
        Else
            'SendCommand("T", "!", 128)
            timerTurnTable.Enabled = False
            btnTable.Text = "Start Table"
            btnTable.BackColor = Color.Green
            btnTable.ForeColor = Color.White
        End If



        'SendCommand("T", "S", 0)
    End Sub

    Private Sub SetArm(ByVal ArcAngle As Single, ByVal ArcRadius As Single, ByVal ShoulderDistance As Single)
        Dim Z As Single
        Dim Radius As Single
        Dim Angle As Single
        Dim ElbowAngle As Single
        Dim ShoulderAngle As Single
        Dim WristAngle As Single
        Dim TargetY As Single
        Dim TargetX As Single
        Dim RotationAngle As Single

        Dim b As Single
        Dim h As Single
        Dim alpha As Single
        Dim beta As Single
        Dim mu As Single
        Dim gamma As Single
        Dim phi As Single
        Dim theta As Single
        'Dim ShoulderDistance As Single




        Radius = ArcRadius
        Angle = ArcAngle * 0.0174533
        ShoulderDistance = _ShoulderDistance

        'b = Math.Sqrt(Radius ^ 2 + ShoulderDistance ^ 2 - 2 * Radius * ShoulderDistance * Math.Cos(Angle))
        'h = Radius * Math.Sin(Angle)
        'alpha = Math.Asin(h / b) / 0.0174533
        'mu = Math.Acos((b / 2) / _ArmSegmentLength) / 0.0174533
        'beta = ArcAngle

        ''alpha = Math.Acos((Radius ^ 2 - b ^ 2 - ShoulderDistance ^ 2) / (-2 * b * ShoulderDistance)) / 0.0174533
        ''phi = Math.Acos(1 - (b ^ 2) / (2 * _ArmSegmentLength ^ 2)) / 0.0174533
        'mu = (180 - phi) / 2
        'phi = 180 - 2 * mu
        'gamma = (mu + (180 - alpha - beta))
        'theta = 180 - mu - alpha

        If _Model Is Nothing Then
            CreateModel()
        End If

        _Model.Calculate(ArcAngle)


        'b = Math.Sqrt(Radius ^ 2 + ShoulderDistance ^ 2 - 2 * Radius * ShoulderDistance * Math.Cos(Angle))
        'h = Radius * Math.Sin(Angle)
        'alpha = Math.Asin(h / b) / 0.0174533
        'mu = Math.Acos((b / 2) / _ArmSegmentLength) / 0.0174533
        'beta = ArcAngle

        ''alpha = Math.Acos((Radius ^ 2 - b ^ 2 - ShoulderDistance ^ 2) / (-2 * b * ShoulderDistance)) / 0.0174533
        'phi = 180 - Math.Acos(1 - (b ^ 2) / (2 * _ArmSegmentLength ^ 2)) / 0.0174533
        'mu = phi / 2
        ''phi = 180 - 2 * mu
        'gamma = mu + (180 - alpha - beta)
        'theta = 180 - mu - alpha


        _Shoulder.Angle = _Model.theta
        _Elbow.Angle = _Model.phi

        _Wrist.Angle = _WristGamma - _Model.gamma

        Print(String.Format("Arc Angle: {0}", Angle))

    End Sub

    Private Sub tbarArcAngle_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarArcAngle.ValueChanged
        tbarArcAngle.Value = System.Math.Truncate((tbarArcAngle.Value + 5) / 10) * 10
        SetArm(tbarArcAngle.Value, _ArcRadius, _ShoulderDistance)
        txtArcAngle.Text = tbarArcAngle.Value
    End Sub

    Private Sub btnRunSequence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunSequence.Click
        If Not _Running Then
            If _TurnTableThread.ThreadState <> ThreadState.Running Then
                _TurnTableThread = New Thread(AddressOf Run)
                _TurnTableThread.Start()
            End If
        End If
    End Sub

    Private Sub Sleep(ByVal msecs As Integer)
       
        Dim StartTime As Date = Date.Now()
        Dim EndTime As Date = StartTime.AddMilliseconds(msecs)

        'Thread.Sleep(msecs)
        While Date.Now() < EndTime
            If Date.Now() >= StartTime.AddMilliseconds(10) Then
                DoAppEvents()
                StartTime = Date.Now()
            End If
        End While

    End Sub

    Private Sub MoveToStartPosition()
        Dim ArcAngle As Single = System.Math.Truncate((tbarArcAngle.Value + 5) / 10) * 10
        If ArcAngle <> 0 Then
            tbarArcAngle.Value = ArcAngle
        Else
            SetArm(0, _ArcRadius, _ShoulderDistance)
        End If
    End Sub

    Private Sub GotoStartPosition()
        Dim Angle As Integer

        _Wrist.Angle = 0
        If _Running Then
            For Angle = 0 To 20 Step 4
                If Not _Running Then Exit For
                _Elbow.Angle = 180 - Angle
                DoAppEvents()
                Sleep(250)
            Next

            For Angle = 0 To 95 Step 5
                If Not _Running Then Exit For
                _Shoulder.Angle = Angle
                DoAppEvents()
                Sleep(250)
            Next
        End If
    End Sub

    Private Sub TurnTableSeek()
        _SerialData = ""
        SendCommand("C", "S", 5)
        While Not _SerialData.StartsWith("ok") And False 'Not cbDryRun.Checked

            DoAppEvents()
        End While
        'Sleep(500)
    End Sub

    Private Sub PressShutter()
        SendCommand("B", "P", 0)
        Sleep(1500)
    End Sub

    Private Sub TakePicture()
        SendCommand("C", "T", 5)
        Sleep(1500)
    End Sub

    Private Sub SnapPicture(ByVal Name As String)
        'If Not cbDryRun.Checked Then
        Dim image As Bitmap = videoSourcePlayer.GetCurrentVideoFrame()
        SaveImage(image, Name)
        'End If
    End Sub

    Private Sub RunTurntable(ByVal ArcAngle As Integer)
        Dim i As Integer
        If videoSourcePlayer.IsAccessible Then
            videoSourcePlayer.Refresh()
        End If

        For i = 1 To 36
            If Not _Running Then Exit For
            Print(String.Format("Turntable Position: {0}", i))
            _SerialData = ""
            BumpTurntable()
            'Application.DoEvents()
            Sleep(500)
            SnapPicture(String.Format("Frame_{0,8:D8}_{1,8:D8}", ArcAngle, i))
            'Application.DoEvents()
            Sleep(500)

            'TakePicture()
            'TurnTableSeek()
            'While Not _SerialData.StartsWith("ok")
            '    Application.DoEvents()
            'End While

            'Sleep(1500)
            'PressShutter()
        Next
    End Sub

    Private Sub timerTurnTable_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerTurnTable.Tick
        SendCommand("T", "S", 0)
    End Sub

    Private Sub InitDevicesCombo()
        Try

            ' enumerate video devices
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)

            If videoDevices.Count = 0 Then
                Throw New ApplicationException()
            End If

            ' add all devices to combo
            For Each device As FilterInfo In videoDevices
                devicesCombo.Items.Add(device.Name)
            Next

        Catch ex As Exception

            devicesCombo.Items.Add("No local capture devices")
            devicesCombo.Enabled = False

        End Try
        devicesCombo.SelectedIndex = 0

    End Sub

    Private Sub devicesCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles devicesCombo.SelectedIndexChanged

        Try


            Dim device As String = videoDevices(devicesCombo.SelectedIndex).MonikerString
            Dim videoSource As VideoCaptureDevice = New VideoCaptureDevice(device)

            OpenVideoSource(videoSource)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenVideoSource(ByVal source As IVideoSource)
        ' set busy cursor
        Me.Cursor = Cursors.WaitCursor

        ' close previous video source
        CloseVideoSource()

        ' start new video source
        videoSourcePlayer.VideoSource = source
        videoSourcePlayer.Start()

        '// reset statistics
        'statIndex = statReady = 0;

        '// start timers
        'timer.Start( );
        'alarmTimer.Start( );

        'videoSource = source

        Me.Cursor = Cursors.Default
    End Sub
    ' Close current video source
    Private Sub CloseVideoSource()
        ' set busy cursor
        Me.Cursor = Cursors.WaitCursor

        ' stop current video source
        videoSourcePlayer.SignalToStop()

        ' wait 2 seconds until camera stops
        For i As Integer = 0 To 50 Step 1
            If Not videoSourcePlayer.IsRunning Then Exit For
            Sleep(100)
        Next

        If videoSourcePlayer.IsRunning Then videoSourcePlayer.Stop()



        videoSourcePlayer.BorderColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Form1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        'CloseVideoSource()

    End Sub

    Private Sub btnStartPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartPos.Click
        Dim ArcAngle As Single = System.Math.Truncate((tbarArcAngle.Value + 5) / 10) * 10
        If ArcAngle <> 0 Then
            tbarArcAngle.Value = ArcAngle
        Else
            SetArm(0, _ArcRadius, _ShoulderDistance)
        End If
    End Sub

    Private Sub btnDecArcAngle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecArcAngle.Click
        If tbarArcAngle.Value > tbarArcAngle.Minimum Then
            tbarArcAngle.Value -= tbarArcAngle.TickFrequency
        End If
    End Sub

    Private Sub btnIncArcAngle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncArcAngle.Click
        If tbarArcAngle.Value < tbarArcAngle.Maximum Then
            tbarArcAngle.Value += tbarArcAngle.TickFrequency
        End If
    End Sub

    Private Sub tbarRadius_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarRadius.ValueChanged
        lblRadius.Text = tbarRadius.Value
        _ArcRadius = tbarRadius.Value
        CreateModel()
        SetArm(tbarArcAngle.Value, _ArcRadius, _ShoulderDistance)
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarDistance.ValueChanged
        lblDistance.Text = tbarDistance.Value
        _ShoulderDistance = tbarDistance.Value
        CreateModel()
        SetArm(tbarArcAngle.Value, _ArcRadius, _ShoulderDistance)
    End Sub

    Private Sub Print(ByVal Msg As String)
        txtDisplay.Text &= Date.Now().ToString("yyyy-MM-dd HH:mm:ss") & " " & Msg & vbCrLf
        txtDisplay.SelectionStart = txtDisplay.Text.Length
        txtDisplay.ScrollToCaret()
        MsgCnt += 1
    End Sub
    Private Sub OnRobotMessage(ByVal Msg As String)
        Dim Params() As String
        txtDisplay.Text &= MsgCnt & " " & Msg & vbCrLf
        txtDisplay.SelectionStart = txtDisplay.Text.Length
        txtDisplay.ScrollToCaret()
        MsgCnt += 1
        _SerialData = Msg
        Params = Msg.Split(",")
        '  Name, Angle, MaxPower, Kp, Ki, Kd
        Select Case Params(0)
            Case "?"
                Select Case Params(1)
                    Case "S"
                        _Shoulder.Angle = 180 - Params(2)
                        jpShoulder.MaxPower.Value = Params(3)
                        jpShoulder.Kp.Value = Params(4)
                        jpShoulder.Ki.Value = Params(5)
                        jpShoulder.Kd.Value = Params(6)

                    Case "E"
                        _Elbow.Angle = 180 - Params(2)
                        jpElbow.MaxPower.Value = Params(3)
                        jpElbow.Kp.Value = Params(4)
                        jpElbow.Ki.Value = Params(5)
                        jpElbow.Kd.Value = Params(6)
                End Select

        End Select

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim Str As String
        Dim mi As UpdateMsg = AddressOf ShowMsg
        Dim StartPos As Integer = 0
        Dim EndPos As Integer = 0
        Dim i As Integer
        Str = SerialPort1.ReadExisting()
        Dim params(0) As Object

        For i = 0 To Str.Length - 1
            Select Case Str(i)
                Case "~"c
                    Msg = ""

                Case "!"c
                    params(0) = Msg
                    Me.Invoke(mi, params)
                    Msg = ""

                Case Else
                    Msg = Msg & Str(i)
            End Select
        Next
    End Sub

    Public Sub ShowMsg(ByVal Msg As String)
        RaiseEvent RobotMessage(Msg)
    End Sub

    Private Sub btnGetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStatus.Click
        SendCommand("S", "?", 0)
        Sleep(250)
        SendCommand("E", "?", 0)
        Sleep(250)
        SendCommand("T", "?", 0)

        _Initialized = True
    End Sub

    Private Sub Shoulder_KdChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpShoulder.KdChanged
        SendCommand("S", "Kd", Value)
    End Sub

    Private Sub Shoulder_KiChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpShoulder.KiChanged
        SendCommand("S", "Ki", Value)
    End Sub

    Private Sub Shoulder_KpChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpShoulder.KpChanged
        SendCommand("S", "Kp", Value)
    End Sub

    Private Sub Shoulder_MaxPowerChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Int32) Handles jpShoulder.MaxPowerChanged
        SendCommand("S", "P", Value)
    End Sub

    Private Sub Elbow_KdChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpElbow.KdChanged
        SendCommand("E", "Kd", Value)
    End Sub

    Private Sub Elbow_KiChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpElbow.KiChanged
        SendCommand("E", "Ki", Value)
    End Sub

    Private Sub Elbow_KpChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Single) Handles jpElbow.KpChanged
        SendCommand("E", "Kp", Value)
    End Sub

    Private Sub Elbow_MaxPowerChanged(ByVal Obj As RobotCam.JointPanel, ByVal Value As System.Int32) Handles jpElbow.MaxPowerChanged
        SendCommand("E", "P", Value)
    End Sub

    Private Sub timerMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerMessage.Tick
        Dim Msg As String

        If _Messages.Count > 0 Then
            Msg = _Messages.Pop()
            If _SerialPortAvailable Then
                SerialPort1.Write(Msg)
            End If
        End If
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        BumpTurntable()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Result As DialogResult
        Result = MessageBox.Show("ReCalibrate?", "", MessageBoxButtons.YesNo)
        If Result = Windows.Forms.DialogResult.Yes Then

            SendCommand("*", "I", 0)
            MessageBox.Show("Calibrate the arm")
        End If
        _Initialized = True
    End Sub

    Private Sub tsbtnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnStatus.Click
        SendCommand("S", "?", 0)
        Sleep(250)
        SendCommand("E", "?", 0)
        Sleep(250)
        SendCommand("W", "F", jpWrist.AngleFactor.Value)
        Sleep(250)
        SendCommand("W", "O", jpWrist.AngleOffset.Value)
        _Initialized = True
    End Sub


    Private Sub jpWrist_AngleFactorChanged(ByVal Obj As RobotCam.CtlWristSettings, ByVal Value As System.Single) Handles jpWrist.AngleFactorChanged
        SendCommand("W", "F", Value)
        Sleep(250)
        SendCommand("W", "A", _Wrist.Angle)
    End Sub

    Private Sub jpWrist_AngleOffsetChanged(ByVal Obj As RobotCam.CtlWristSettings, ByVal Value As System.Int32) Handles jpWrist.AngleOffsetChanged
        SendCommand("W", "O", Value)
        Sleep(250)
        SendCommand("W", "A", _Wrist.Angle)
    End Sub


    Private Sub btnCalibrateArm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateArm.Click
        Dim Result As DialogResult
        Result = MessageBox.Show("ReCalibrate Arm?", "", MessageBoxButtons.YesNo)
        If Result = Windows.Forms.DialogResult.Yes Then
            SendCommand("S", "I", 0)
            Sleep(250)
            SendCommand("E", "I", 0)
            MessageBox.Show("Calibrate the arm")
        End If
    End Sub

    Private Sub btnCalibrateTurntable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateTurntable.Click
        Dim Result As DialogResult
        Result = MessageBox.Show("ReCalibrate Turntable?", "", MessageBoxButtons.YesNo)
        If Result = Windows.Forms.DialogResult.Yes Then
            SendCommand("C", "I", 0)
            MessageBox.Show("Calibrate the turntable")
        End If
    End Sub

    Private Sub btnCalibrateBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateBoth.Click
        Dim Result As DialogResult
        Result = MessageBox.Show("ReCalibrate System?", "", MessageBoxButtons.YesNo)
        If Result = Windows.Forms.DialogResult.Yes Then
            SendCommand("*", "I", 0)
            MessageBox.Show("Calibrate the system")
            _Initialized = True
        End If
    End Sub

    Private Sub BumpTurntable()
        TurnTableSeek()
    End Sub


    Private Sub videoSourcePlayer_NewFrame(ByVal sender As System.Object, ByRef image As System.Drawing.Bitmap) Handles videoSourcePlayer.NewFrame

        'If _TakePicture Then
        '    _TakePicture = False
        '    SaveImage(image, _SnapShotName)
        '    'image.Save(_SnapShotName)
        '    _SnapShotName = ""

        'End If
        'If _FindTable Then
        '    'create filter
        '    Dim colorFilter As ColorFiltering = New ColorFiltering()
        '    ' configure the filter
        '    colorFilter.Red = New IntRange(0, 100)
        '    colorFilter.Green = New IntRange(0, 200)
        '    colorFilter.Blue = New IntRange(150, 255)
        '    ' apply the filter
        '    Dim objectImage As Bitmap = colorFilter.Apply(image)
        'End If
        'If Not _AlignmentForm Is Nothing Then
        '    If _AlignmentForm.Loaded Then
        '        If Not _AlignmentBusy Then
        '            'ProcessImage(image)
        '            _AlignmentForm.picViewport.Image = ProcessImage(image)
        '        End If
        '    End If
        'End If


    End Sub

    Private Sub Button4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        _MovingMarker = True
    End Sub

    Private Sub Button4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        _MovingMarker = False
    End Sub

    Private Dragging As Boolean = False
    Private mousex As Integer
    Private mousey As Integer

    Private Sub btnMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMove.MouseDown
        If e.Button = MouseButtons.Left Then
            Dragging = True
            mousex = -e.X
            mousey = -e.Y
            Dim clipleft As Integer = Me.PointToClient(MousePosition).X - btnMove.Location.X
            Dim cliptop As Integer = Me.PointToClient(MousePosition).Y - btnMove.Location.Y
            Dim clipwidth As Integer = Me.ClientSize.Width - (btnMove.Width - clipleft)
            Dim clipheight As Integer = Me.ClientSize.Height - (btnMove.Height - cliptop)
            Cursor.Clip = Me.RectangleToScreen(New Rectangle(clipleft, cliptop, clipwidth, clipheight))
            btnMove.Invalidate()
        End If
    End Sub

    Private Sub btnMove_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMove.MouseMove
        If Dragging Then
            'move control to new position
            Dim MPosition As New Point()
            MPosition = Me.PointToClient(MousePosition)
            MPosition.Offset(mousex, mousey)
            'ensure control cannot leave container
            btnMove.Location = MPosition
        End If
    End Sub

    Private Sub btnMove_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMove.MouseUp
        If Dragging Then
            'end the dragging
            Dragging = False
            Cursor.Clip = Nothing
            btnMove.Invalidate()
        End If
    End Sub

    Private Function ProcessImage(ByVal bitmap As Bitmap) As Bitmap

        ' lock image
        'Try
        _AlignmentBusy = True
        Dim Image As Bitmap = bitmap.Clone()
        Dim bitmapData As BitmapData = Image.LockBits( _
            New Rectangle(0, 0, Image.Width, Image.Height), _
            ImageLockMode.ReadWrite, Image.PixelFormat)

        ' step 1 - turn background to black
        Dim colorFilter As ColorFiltering = New ColorFiltering()

        colorFilter.Red = New IntRange(100, 255)
        colorFilter.Green = New IntRange(0, 25)
        colorFilter.Blue = New IntRange(20, 120)
        'colorFilter.FillOutsideRange = false;

        colorFilter.ApplyInPlace(bitmapData)

        '// step 2 - locating objects
        Dim blobCounter As BlobCounter = New BlobCounter()

        blobCounter.FilterBlobs = True
        blobCounter.MinHeight = 5
        blobCounter.MinWidth = 5

        blobCounter.ProcessImage(bitmapData)
        Dim blobs() As Blob = blobCounter.GetObjectsInformation()
        Image.UnlockBits(bitmapData)

        '// step 3 - check objects' type and highlight
        Dim shapeChecker As SimpleShapeChecker = New SimpleShapeChecker()

        Dim g As Graphics = Graphics.FromImage(Image)
        Dim yellowPen As Pen = New Pen(Color.Yellow, 20) ' // circles
        Dim redPen As Pen = New Pen(Color.Red, 2) '      // quadrilateral
        Dim brownPen As Pen = New Pen(Color.Brown, 2) ';   // quadrilateral with known sub-type
        Dim greenPen As Pen = New Pen(Color.Green, 2) ';   // known triangle
        Dim bluePen As Pen = New Pen(Color.Blue, 2)  ';     // triangle

        For i As Integer = 0 To blobs.Length - 1 Step 1
            Dim edgePoints As List(Of IntPoint) = blobCounter.GetBlobsEdgePoints(blobs(i))

            Dim center As DoublePoint
            Dim radius As Double

            '// is circle ?
            If shapeChecker.IsCircle(edgePoints, center, radius) Then
                'g.DrawEllipse(yellowPen, _
                '    CSng(center.X - radius), CSng(center.Y - radius), _
                '    CSng(radius * 2), CSng(radius * 2))
            Else
                Dim corners As List(Of IntPoint) = New List(Of IntPoint)

                '// is triangle or quadrilateral
                If (shapeChecker.IsConvexPolygon(edgePoints, corners)) Then
                    '// get sub-type
                    Dim subType As PolygonSubType = shapeChecker.CheckPolygonSubType(corners)

                    Dim pen As Pen

                    If subType = PolygonSubType.Unknown Then
                        pen = IIf(corners.Count = 4, redPen, bluePen)
                    Else
                        pen = IIf(corners.Count = 4, yellowPen, greenPen)

                        g.DrawPolygon(pen, ToPointsArray(corners))
                    End If
                End If
            End If
        Next

        yellowPen.Dispose()
        redPen.Dispose()
        greenPen.Dispose()
        bluePen.Dispose()
        brownPen.Dispose()
        g.Dispose()

        '// put new image to clipboard
        '_AlignmentForm.picViewport.Image = bitmap
        'Clipboard.SetDataObject(bitmap)
        '// and to picture box

        'UpdatePictureBoxPosition( );
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        _AlignmentBusy = False
        Return Image
    End Function

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        _AlignmentForm = New CameraAlignment()
        AddHandler _AlignmentForm.Disposed, AddressOf OnDisposeCameraAlignment
        _AlignmentForm.Show()

    End Sub

    Private Sub OnDisposeCameraAlignment(ByVal sender As Object, ByVal e As System.EventArgs)
        _AlignmentForm = Nothing
    End Sub

    Private Function ToPointsArray(ByVal points As List(Of IntPoint)) As Point()
        Dim PtArray() As Point
        ReDim PtArray(points.Count - 1)

        For i As Integer = 0 To points.Count - 1 Step 1
            PtArray(i) = New Point(points(i).X, points(i).Y)
        Next

        Return PtArray
    End Function

    Private Sub Run(ByVal Data As Object)
        Dim Angle As Integer
        Dim mts As MoveToStartDelegate = AddressOf MoveToStartPosition
        Dim sa As SetArmDelegate = AddressOf SetArm
        Dim rt As RunTurntableDelegate = AddressOf RunTurntable
        Dim pd As PrintDelegate = AddressOf Print
        Dim sa_params(2) As Object
        Dim rt_params(0) As Object
        Dim pd_params(0) As Object
        Dim StartTime As Date = Date.Now()

        If Not _Running Then
            _Running = True
            Me.Invoke(mts)


            For Angle = 0 To 90 Step 10
                If Not _Running Then Exit For

                sa_params(0) = Angle
                sa_params(1) = _ArcRadius
                sa_params(2) = _ShoulderDistance
                Me.Invoke(sa, sa_params)
                'SetArm(Angle, _ArcRadius, _ShoulderDistance)
                DoAppEvents()
                Sleep(5000)
                rt_params(0) = Angle
                Me.Invoke(rt, rt_params)
                'RunTurntable(Angle)
            Next
            pd_params(0) = String.Format("Elapsed Time: {0}", (Date.Now() - StartTime).ToString())
            Me.Invoke(pd, pd_params)
            _Running = False
            Me.Invoke(mts)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub DoAppEvents()
        'If GetInputState() <> 0 Then
        '    Application.DoEvents()
        'End If
    End Sub
End Class
