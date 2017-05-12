<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtShoulder_ = New System.Windows.Forms.TextBox
        Me.txtWrist_ = New System.Windows.Forms.TextBox
        Me.txtElbow_ = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.btnTable = New System.Windows.Forms.Button
        Me.tbarArcAngle = New System.Windows.Forms.TrackBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnRunSequence = New System.Windows.Forms.Button
        Me.timerTurnTable = New System.Windows.Forms.Timer(Me.components)
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.videoSourcePlayer = New AForge.Controls.VideoSourcePlayer
        Me.devicesCombo = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblDistance = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbarDistance = New System.Windows.Forms.TrackBar
        Me.lblRadius = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbarRadius = New System.Windows.Forms.TrackBar
        Me.btnIncArcAngle = New System.Windows.Forms.Button
        Me.btnDecArcAngle = New System.Windows.Forms.Button
        Me.cbDisableCom = New System.Windows.Forms.CheckBox
        Me.txtArcAngle = New System.Windows.Forms.Label
        Me.btnStartPos = New System.Windows.Forms.Button
        Me.cbEnableTurntable = New System.Windows.Forms.CheckBox
        Me.btnGetStatus = New System.Windows.Forms.Button
        Me.timerMessage = New System.Windows.Forms.Timer(Me.components)
        Me.btnTest = New System.Windows.Forms.Button
        Me.tabsSettings = New System.Windows.Forms.TabControl
        Me.tabShoulder = New System.Windows.Forms.TabPage
        Me.tabElbow = New System.Windows.Forms.TabPage
        Me.tabWrist = New System.Windows.Forms.TabPage
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.btnCalibrateArm = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCalibrateTurntable = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCalibrateBoth = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnStatus = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.btnMove = New System.Windows.Forms.Button
        Me.cbDryRun = New System.Windows.Forms.CheckBox
        Me.jpShoulder = New RobotCam.JointPanel
        Me.jpElbow = New RobotCam.JointPanel
        Me.jpWrist = New RobotCam.CtlWristSettings
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarArcAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tbarDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarRadius, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabsSettings.SuspendLayout()
        Me.tabShoulder.SuspendLayout()
        Me.tabElbow.SuspendLayout()
        Me.tabWrist.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(320, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(569, 396)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(327, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Shoulder:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(345, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Wrist:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(340, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Elbow:"
        '
        'txtShoulder_
        '
        Me.txtShoulder_.Location = New System.Drawing.Point(385, 37)
        Me.txtShoulder_.Name = "txtShoulder_"
        Me.txtShoulder_.Size = New System.Drawing.Size(72, 20)
        Me.txtShoulder_.TabIndex = 4
        '
        'txtWrist_
        '
        Me.txtWrist_.Location = New System.Drawing.Point(385, 89)
        Me.txtWrist_.Name = "txtWrist_"
        Me.txtWrist_.Size = New System.Drawing.Size(72, 20)
        Me.txtWrist_.TabIndex = 5
        '
        'txtElbow_
        '
        Me.txtElbow_.Location = New System.Drawing.Point(385, 63)
        Me.txtElbow_.Name = "txtElbow_"
        Me.txtElbow_.Size = New System.Drawing.Size(72, 20)
        Me.txtElbow_.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(895, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(322, 91)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "STOP"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(533, 683)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Calibrate"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.PortName = "COM9"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(533, 731)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 22)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Shutter"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnTable
        '
        Me.btnTable.Location = New System.Drawing.Point(669, 683)
        Me.btnTable.Name = "btnTable"
        Me.btnTable.Size = New System.Drawing.Size(75, 23)
        Me.btnTable.TabIndex = 20
        Me.btnTable.Text = "Test Table"
        Me.btnTable.UseVisualStyleBackColor = True
        '
        'tbarArcAngle
        '
        Me.tbarArcAngle.LargeChange = 10
        Me.tbarArcAngle.Location = New System.Drawing.Point(6, 97)
        Me.tbarArcAngle.Maximum = 90
        Me.tbarArcAngle.Name = "tbarArcAngle"
        Me.tbarArcAngle.Size = New System.Drawing.Size(308, 42)
        Me.tbarArcAngle.SmallChange = 10
        Me.tbarArcAngle.TabIndex = 21
        Me.tbarArcAngle.TickFrequency = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Arc Angle"
        '
        'btnRunSequence
        '
        Me.btnRunSequence.Location = New System.Drawing.Point(669, 730)
        Me.btnRunSequence.Name = "btnRunSequence"
        Me.btnRunSequence.Size = New System.Drawing.Size(75, 23)
        Me.btnRunSequence.TabIndex = 23
        Me.btnRunSequence.Text = "Run"
        Me.btnRunSequence.UseVisualStyleBackColor = True
        '
        'timerTurnTable
        '
        Me.timerTurnTable.Interval = 2000
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(320, 430)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(569, 247)
        Me.txtDisplay.TabIndex = 24
        '
        'videoSourcePlayer
        '
        Me.videoSourcePlayer.Location = New System.Drawing.Point(896, 125)
        Me.videoSourcePlayer.Name = "videoSourcePlayer"
        Me.videoSourcePlayer.Size = New System.Drawing.Size(322, 242)
        Me.videoSourcePlayer.TabIndex = 25
        Me.videoSourcePlayer.Text = "VideoSourcePlayer1"
        Me.videoSourcePlayer.VideoSource = Nothing
        '
        'devicesCombo
        '
        Me.devicesCombo.FormattingEnabled = True
        Me.devicesCombo.Location = New System.Drawing.Point(895, 373)
        Me.devicesCombo.Name = "devicesCombo"
        Me.devicesCombo.Size = New System.Drawing.Size(322, 21)
        Me.devicesCombo.TabIndex = 26
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDistance)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.tbarDistance)
        Me.GroupBox3.Controls.Add(Me.lblRadius)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbarRadius)
        Me.GroupBox3.Controls.Add(Me.btnIncArcAngle)
        Me.GroupBox3.Controls.Add(Me.btnDecArcAngle)
        Me.GroupBox3.Controls.Add(Me.cbDisableCom)
        Me.GroupBox3.Controls.Add(Me.txtArcAngle)
        Me.GroupBox3.Controls.Add(Me.btnStartPos)
        Me.GroupBox3.Controls.Add(Me.cbEnableTurntable)
        Me.GroupBox3.Controls.Add(Me.tbarArcAngle)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(896, 400)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(321, 277)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Run Opotions"
        '
        'lblDistance
        '
        Me.lblDistance.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDistance.Location = New System.Drawing.Point(263, 192)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(37, 13)
        Me.lblDistance.TabIndex = 36
        Me.lblDistance.Text = "000"
        Me.lblDistance.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Distance"
        '
        'tbarDistance
        '
        Me.tbarDistance.Location = New System.Drawing.Point(6, 208)
        Me.tbarDistance.Maximum = 60
        Me.tbarDistance.Minimum = 12
        Me.tbarDistance.Name = "tbarDistance"
        Me.tbarDistance.Size = New System.Drawing.Size(308, 42)
        Me.tbarDistance.TabIndex = 34
        Me.tbarDistance.Value = 12
        '
        'lblRadius
        '
        Me.lblRadius.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblRadius.Location = New System.Drawing.Point(263, 139)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(37, 13)
        Me.lblRadius.TabIndex = 33
        Me.lblRadius.Text = "000"
        Me.lblRadius.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Radius"
        '
        'tbarRadius
        '
        Me.tbarRadius.Location = New System.Drawing.Point(6, 155)
        Me.tbarRadius.Maximum = 36
        Me.tbarRadius.Minimum = 6
        Me.tbarRadius.Name = "tbarRadius"
        Me.tbarRadius.Size = New System.Drawing.Size(308, 42)
        Me.tbarRadius.TabIndex = 31
        Me.tbarRadius.UseWaitCursor = True
        Me.tbarRadius.Value = 6
        '
        'btnIncArcAngle
        '
        Me.btnIncArcAngle.AutoSize = True
        Me.btnIncArcAngle.Location = New System.Drawing.Point(171, 81)
        Me.btnIncArcAngle.Name = "btnIncArcAngle"
        Me.btnIncArcAngle.Size = New System.Drawing.Size(32, 23)
        Me.btnIncArcAngle.TabIndex = 30
        Me.btnIncArcAngle.Text = ">"
        Me.btnIncArcAngle.UseVisualStyleBackColor = True
        '
        'btnDecArcAngle
        '
        Me.btnDecArcAngle.AutoSize = True
        Me.btnDecArcAngle.Location = New System.Drawing.Point(120, 81)
        Me.btnDecArcAngle.Name = "btnDecArcAngle"
        Me.btnDecArcAngle.Size = New System.Drawing.Size(32, 23)
        Me.btnDecArcAngle.TabIndex = 29
        Me.btnDecArcAngle.Text = "<"
        Me.btnDecArcAngle.UseVisualStyleBackColor = True
        '
        'cbDisableCom
        '
        Me.cbDisableCom.AutoSize = True
        Me.cbDisableCom.Location = New System.Drawing.Point(227, 20)
        Me.cbDisableCom.Name = "cbDisableCom"
        Me.cbDisableCom.Size = New System.Drawing.Size(88, 17)
        Me.cbDisableCom.TabIndex = 28
        Me.cbDisableCom.Text = "Disable COM"
        Me.cbDisableCom.UseVisualStyleBackColor = True
        '
        'txtArcAngle
        '
        Me.txtArcAngle.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtArcAngle.Location = New System.Drawing.Point(263, 81)
        Me.txtArcAngle.Name = "txtArcAngle"
        Me.txtArcAngle.Size = New System.Drawing.Size(37, 13)
        Me.txtArcAngle.TabIndex = 23
        Me.txtArcAngle.Text = "000"
        Me.txtArcAngle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnStartPos
        '
        Me.btnStartPos.Location = New System.Drawing.Point(7, 49)
        Me.btnStartPos.Name = "btnStartPos"
        Me.btnStartPos.Size = New System.Drawing.Size(75, 23)
        Me.btnStartPos.TabIndex = 1
        Me.btnStartPos.Text = "Start"
        Me.btnStartPos.UseVisualStyleBackColor = True
        '
        'cbEnableTurntable
        '
        Me.cbEnableTurntable.AutoSize = True
        Me.cbEnableTurntable.Location = New System.Drawing.Point(7, 20)
        Me.cbEnableTurntable.Name = "cbEnableTurntable"
        Me.cbEnableTurntable.Size = New System.Drawing.Size(71, 17)
        Me.cbEnableTurntable.TabIndex = 0
        Me.cbEnableTurntable.Text = "Turntable"
        Me.cbEnableTurntable.UseVisualStyleBackColor = True
        '
        'btnGetStatus
        '
        Me.btnGetStatus.Location = New System.Drawing.Point(785, 683)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(75, 23)
        Me.btnGetStatus.TabIndex = 28
        Me.btnGetStatus.Text = "Get Status"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        '
        'timerMessage
        '
        Me.timerMessage.Enabled = True
        Me.timerMessage.Interval = 50
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(785, 732)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 31
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'tabsSettings
        '
        Me.tabsSettings.Controls.Add(Me.tabShoulder)
        Me.tabsSettings.Controls.Add(Me.tabElbow)
        Me.tabsSettings.Controls.Add(Me.tabWrist)
        Me.tabsSettings.Location = New System.Drawing.Point(9, 28)
        Me.tabsSettings.Name = "tabsSettings"
        Me.tabsSettings.SelectedIndex = 0
        Me.tabsSettings.Size = New System.Drawing.Size(305, 649)
        Me.tabsSettings.TabIndex = 32
        '
        'tabShoulder
        '
        Me.tabShoulder.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tabShoulder.Controls.Add(Me.jpShoulder)
        Me.tabShoulder.Location = New System.Drawing.Point(4, 22)
        Me.tabShoulder.Name = "tabShoulder"
        Me.tabShoulder.Padding = New System.Windows.Forms.Padding(3)
        Me.tabShoulder.Size = New System.Drawing.Size(297, 623)
        Me.tabShoulder.TabIndex = 0
        Me.tabShoulder.Text = "Shoulder"
        '
        'tabElbow
        '
        Me.tabElbow.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tabElbow.Controls.Add(Me.jpElbow)
        Me.tabElbow.Location = New System.Drawing.Point(4, 22)
        Me.tabElbow.Name = "tabElbow"
        Me.tabElbow.Padding = New System.Windows.Forms.Padding(3)
        Me.tabElbow.Size = New System.Drawing.Size(297, 623)
        Me.tabElbow.TabIndex = 1
        Me.tabElbow.Text = "Elbow"
        '
        'tabWrist
        '
        Me.tabWrist.Controls.Add(Me.jpWrist)
        Me.tabWrist.Location = New System.Drawing.Point(4, 22)
        Me.tabWrist.Name = "tabWrist"
        Me.tabWrist.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWrist.Size = New System.Drawing.Size(297, 623)
        Me.tabWrist.TabIndex = 2
        Me.tabWrist.Text = "Wrist"
        Me.tabWrist.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.ToolStripSeparator2, Me.tsbtnStatus, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1225, 25)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCalibrateArm, Me.btnCalibrateTurntable, Me.btnCalibrateBoth})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripSplitButton1.Text = "Calibrate"
        '
        'btnCalibrateArm
        '
        Me.btnCalibrateArm.Name = "btnCalibrateArm"
        Me.btnCalibrateArm.Size = New System.Drawing.Size(131, 22)
        Me.btnCalibrateArm.Text = "Arm"
        '
        'btnCalibrateTurntable
        '
        Me.btnCalibrateTurntable.Name = "btnCalibrateTurntable"
        Me.btnCalibrateTurntable.Size = New System.Drawing.Size(131, 22)
        Me.btnCalibrateTurntable.Text = "Turntable"
        '
        'btnCalibrateBoth
        '
        Me.btnCalibrateBoth.Name = "btnCalibrateBoth"
        Me.btnCalibrateBoth.Size = New System.Drawing.Size(131, 22)
        Me.btnCalibrateBoth.Text = "Both"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnStatus
        '
        Me.tsbtnStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnStatus.Image = CType(resources.GetObject("tsbtnStatus.Image"), System.Drawing.Image)
        Me.tsbtnStatus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnStatus.Name = "tsbtnStatus"
        Me.tsbtnStatus.Size = New System.Drawing.Size(34, 22)
        Me.tsbtnStatus.Text = "Sync"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButton1.Text = "Align Camera"
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(919, 239)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 10)
        Me.btnMove.TabIndex = 34
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'cbDryRun
        '
        Me.cbDryRun.AutoSize = True
        Me.cbDryRun.Location = New System.Drawing.Point(679, 759)
        Me.cbDryRun.Name = "cbDryRun"
        Me.cbDryRun.Size = New System.Drawing.Size(65, 17)
        Me.cbDryRun.TabIndex = 35
        Me.cbDryRun.Text = "Dry Run"
        Me.cbDryRun.UseVisualStyleBackColor = True
        '
        'jpShoulder
        '
        Me.jpShoulder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.jpShoulder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.jpShoulder.Location = New System.Drawing.Point(3, 3)
        Me.jpShoulder.Name = "jpShoulder"
        Me.jpShoulder.Size = New System.Drawing.Size(291, 617)
        Me.jpShoulder.TabIndex = 29
        Me.jpShoulder.Title = "Shoulder"
        '
        'jpElbow
        '
        Me.jpElbow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.jpElbow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.jpElbow.Location = New System.Drawing.Point(3, 3)
        Me.jpElbow.Name = "jpElbow"
        Me.jpElbow.Size = New System.Drawing.Size(291, 617)
        Me.jpElbow.TabIndex = 30
        Me.jpElbow.Title = "Elbow"
        '
        'jpWrist
        '
        Me.jpWrist.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.jpWrist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.jpWrist.Location = New System.Drawing.Point(3, 3)
        Me.jpWrist.Name = "jpWrist"
        Me.jpWrist.Size = New System.Drawing.Size(291, 617)
        Me.jpWrist.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 891)
        Me.Controls.Add(Me.cbDryRun)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.tabsSettings)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnGetStatus)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.devicesCombo)
        Me.Controls.Add(Me.videoSourcePlayer)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.btnRunSequence)
        Me.Controls.Add(Me.btnTable)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtElbow_)
        Me.Controls.Add(Me.txtWrist_)
        Me.Controls.Add(Me.txtShoulder_)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Robot Arm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarArcAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tbarDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarRadius, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabsSettings.ResumeLayout(False)
        Me.tabShoulder.ResumeLayout(False)
        Me.tabElbow.ResumeLayout(False)
        Me.tabWrist.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtShoulder_ As System.Windows.Forms.TextBox
    Friend WithEvents txtWrist_ As System.Windows.Forms.TextBox
    Friend WithEvents txtElbow_ As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnTable As System.Windows.Forms.Button
    Friend WithEvents tbarArcAngle As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRunSequence As System.Windows.Forms.Button
    Friend WithEvents timerTurnTable As System.Windows.Forms.Timer
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents videoSourcePlayer As AForge.Controls.VideoSourcePlayer
    Friend WithEvents devicesCombo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbEnableTurntable As System.Windows.Forms.CheckBox
    Friend WithEvents btnStartPos As System.Windows.Forms.Button
    Friend WithEvents txtArcAngle As System.Windows.Forms.Label
    Friend WithEvents cbDisableCom As System.Windows.Forms.CheckBox
    Friend WithEvents btnDecArcAngle As System.Windows.Forms.Button
    Friend WithEvents btnIncArcAngle As System.Windows.Forms.Button
    Friend WithEvents tbarRadius As System.Windows.Forms.TrackBar
    Friend WithEvents lblRadius As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbarDistance As System.Windows.Forms.TrackBar
    Friend WithEvents btnGetStatus As System.Windows.Forms.Button
    Friend WithEvents jpShoulder As RobotCam.JointPanel
    Friend WithEvents jpElbow As RobotCam.JointPanel
    Friend WithEvents timerMessage As System.Windows.Forms.Timer
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents tabsSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabShoulder As System.Windows.Forms.TabPage
    Friend WithEvents tabElbow As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnStatus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tabWrist As System.Windows.Forms.TabPage
    Friend WithEvents jpWrist As RobotCam.CtlWristSettings
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnCalibrateArm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCalibrateTurntable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCalibrateBoth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbDryRun As System.Windows.Forms.CheckBox

End Class
