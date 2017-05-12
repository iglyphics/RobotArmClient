<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JointPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox = New System.Windows.Forms.GroupBox()
        Me.MaxI = New RobotCam.Slider()
        Me.MinI = New RobotCam.Slider()
        Me.MaxPower = New RobotCam.Slider()
        Me.Kd = New RobotCam.Slider()
        Me.Ki = New RobotCam.Slider()
        Me.Kp = New RobotCam.Slider()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.MaxI)
        Me.GroupBox.Controls.Add(Me.MinI)
        Me.GroupBox.Controls.Add(Me.MaxPower)
        Me.GroupBox.Controls.Add(Me.Kd)
        Me.GroupBox.Controls.Add(Me.Ki)
        Me.GroupBox.Controls.Add(Me.Kp)
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox.MinimumSize = New System.Drawing.Size(0, 477)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(555, 477)
        Me.GroupBox.TabIndex = 4
        Me.GroupBox.TabStop = False
        Me.GroupBox.Text = "GroupBox1"
        '
        'MaxI
        '
        Me.MaxI.Dock = System.Windows.Forms.DockStyle.Top
        Me.MaxI.Location = New System.Drawing.Point(3, 396)
        Me.MaxI.Maximum = 100.0!
        Me.MaxI.Minimum = 0.0!
        Me.MaxI.MinimumSize = New System.Drawing.Size(0, 76)
        Me.MaxI.Name = "MaxI"
        Me.MaxI.Size = New System.Drawing.Size(549, 76)
        Me.MaxI.Steps = 100
        Me.MaxI.TabIndex = 5
        Me.MaxI.Title = "MaxI"
        Me.MaxI.Value = 0.0!
        '
        'MinI
        '
        Me.MinI.Dock = System.Windows.Forms.DockStyle.Top
        Me.MinI.Location = New System.Drawing.Point(3, 320)
        Me.MinI.Maximum = 100.0!
        Me.MinI.Minimum = 0.0!
        Me.MinI.MinimumSize = New System.Drawing.Size(0, 76)
        Me.MinI.Name = "MinI"
        Me.MinI.Size = New System.Drawing.Size(549, 76)
        Me.MinI.Steps = 50
        Me.MinI.TabIndex = 4
        Me.MinI.Title = "MinI"
        Me.MinI.Value = 0.0!
        '
        'MaxPower
        '
        Me.MaxPower.Dock = System.Windows.Forms.DockStyle.Top
        Me.MaxPower.Location = New System.Drawing.Point(3, 244)
        Me.MaxPower.Maximum = 100.0!
        Me.MaxPower.Minimum = 0.0!
        Me.MaxPower.MinimumSize = New System.Drawing.Size(0, 76)
        Me.MaxPower.Name = "MaxPower"
        Me.MaxPower.Size = New System.Drawing.Size(549, 76)
        Me.MaxPower.Steps = 50
        Me.MaxPower.TabIndex = 0
        Me.MaxPower.Title = "Max Power"
        Me.MaxPower.Value = 0.0!
        '
        'Kd
        '
        Me.Kd.Dock = System.Windows.Forms.DockStyle.Top
        Me.Kd.Location = New System.Drawing.Point(3, 168)
        Me.Kd.Maximum = 2.5!
        Me.Kd.Minimum = 0.0!
        Me.Kd.MinimumSize = New System.Drawing.Size(0, 76)
        Me.Kd.Name = "Kd"
        Me.Kd.Size = New System.Drawing.Size(549, 76)
        Me.Kd.Steps = 50
        Me.Kd.TabIndex = 3
        Me.Kd.Title = "Kd"
        Me.Kd.Value = 0.0!
        '
        'Ki
        '
        Me.Ki.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ki.Location = New System.Drawing.Point(3, 92)
        Me.Ki.Maximum = 2.5!
        Me.Ki.Minimum = 0.0!
        Me.Ki.MinimumSize = New System.Drawing.Size(0, 76)
        Me.Ki.Name = "Ki"
        Me.Ki.Size = New System.Drawing.Size(549, 76)
        Me.Ki.Steps = 50
        Me.Ki.TabIndex = 2
        Me.Ki.Title = "Ki"
        Me.Ki.Value = 0.0!
        '
        'Kp
        '
        Me.Kp.Dock = System.Windows.Forms.DockStyle.Top
        Me.Kp.Location = New System.Drawing.Point(3, 16)
        Me.Kp.Maximum = 2.5!
        Me.Kp.Minimum = 0.0!
        Me.Kp.MinimumSize = New System.Drawing.Size(0, 76)
        Me.Kp.Name = "Kp"
        Me.Kp.Size = New System.Drawing.Size(549, 76)
        Me.Kp.Steps = 50
        Me.Kp.TabIndex = 1
        Me.Kp.Title = "Kp"
        Me.Kp.Value = 0.0!
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GroupBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(571, 379)
        Me.Panel1.TabIndex = 5
        '
        'JointPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "JointPanel"
        Me.Size = New System.Drawing.Size(571, 379)
        Me.GroupBox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MaxPower As RobotCam.Slider
    Friend WithEvents Kp As RobotCam.Slider
    Friend WithEvents Ki As RobotCam.Slider
    Friend WithEvents Kd As RobotCam.Slider
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MaxI As RobotCam.Slider
    Friend WithEvents MinI As RobotCam.Slider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
