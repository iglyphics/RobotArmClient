Imports System.Math
Imports System.Drawing.Drawing2D
'Imports System.Net.Sockets
Imports System.IO.Ports
Imports RobotArmParts



Public Class Form1
    Private MyImage As Bitmap
    Private MyGraphic As Graphics
    Private Mypen As Pen
    Private DelPen As Pen
    Private WithEvents Timer1 As Windows.Forms.Timer
    Private _Shoulder As Bar
    Private _Arm As Arm
    Private _Pid As Pid = New Pid()
    Public Delegate Sub UpdateMsg(ByVal Msg As String)
    Private Msg As String = ""
    Public Event RobotMessage(ByVal Msg As String)

    Private _Power As Single = 0

    'Dim tcpClient As New System.Net.Sockets.TcpClient()
    'Dim serverStream As NetworkStream
   

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Mypen = New Pen(Color.Black, 1)
        DelPen = New Pen(Color.White, 1)
        Timer1 = New Windows.Forms.Timer
        MyImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        MyGraphic = Graphics.FromImage(MyImage)

        _Shoulder = New Bar(PictureBox1, 8, 200)
        _Shoulder.Anchor = New PointF(PictureBox1.Width / 2, PictureBox1.Height / 2)
        'AddHandler _Shoulder.PositionChanged, AddressOf OnPositionChanged_Shoulder

        _Arm = New Arm(PictureBox1, New PointF(PictureBox1.Width / 2, PictureBox1.Height / 2))
        _Arm.AngleOffset = 90
        _Arm.Add(_Shoulder)

        Timer1.Interval = 15
        Timer1.Start()

        _Pid.SetPos = 45
    End Sub


    Private Sub Timer1_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MyGraphic.Clear(Color.White)

        _Arm.Draw(MyGraphic)

        PictureBox1.Image = MyImage
    End Sub

    Private Sub PowerTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerTimer.Tick
        Dim G As Single = 0
        'G = _Power / 100 * Math.Cos(_Shoulder.Angle)
        _Shoulder.AdjustAngle(_Power / 100 - G)
    End Sub

    Private Sub SetPower(ByVal Val As Single)
        If Val < -255 Then
            Val = -255
        ElseIf Val > 255 Then
            Val = 255
        End If
        _Power = Val
    End Sub

    Private Sub PidTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PidTimer.Tick
        Dim Weight As Single
        Weight = Math.Cos(_Shoulder.Angle * 0.0174533) * 10
        _Power = _Pid.Update(_Shoulder.Angle) ' - Weight
        '_Power = _Power - (_Power * Math.Cos(_Shoulder.Angle * 0.0174533))
        lblArmAngle.Text = _Shoulder.Angle
    End Sub

    Private Sub tbarAngle_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarAngle.ValueChanged
        _Pid.SetPos = tbarAngle.Value
        lblAngle.Text = tbarAngle.Value
    End Sub

    Private Sub tbarKp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarKp.ValueChanged
        Dim Val As Single
        Val = tbarKp.Value / 10
        lblKp.Text = Val
        _Pid.Kp = Val
    End Sub

    Private Sub tbarKi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarKi.ValueChanged
        Dim Val As Single
        Val = tbarKi.Value / 10
        lblKi.Text = Val
        _Pid.Ki = Val
    End Sub

    Private Sub tbarKd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarKd.ValueChanged
        Dim Val As Single
        Val = tbarKd.Value / 10
        lblKd.Text = Val
        _Pid.Kd = Val
    End Sub

   

  

    Public Sub ShowMsg(ByVal Msg As String)
        RaiseEvent RobotMessage(Msg)
    End Sub
End Class
