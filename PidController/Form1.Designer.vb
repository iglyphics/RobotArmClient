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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PowerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PidTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tbarAngle = New System.Windows.Forms.TrackBar()
        Me.lblAngle = New System.Windows.Forms.Label()
        Me.lblArmAngle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbarKp = New System.Windows.Forms.TrackBar()
        Me.tbarKi = New System.Windows.Forms.TrackBar()
        Me.tbarKd = New System.Windows.Forms.TrackBar()
        Me.lblKd = New System.Windows.Forms.Label()
        Me.lblKi = New System.Windows.Forms.Label()
        Me.lblKp = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarKp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarKi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarKd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(229, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 450)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PowerTimer
        '
        Me.PowerTimer.Enabled = True
        Me.PowerTimer.Interval = 10
        '
        'PidTimer
        '
        Me.PidTimer.Enabled = True
        Me.PidTimer.Interval = 50
        '
        'tbarAngle
        '
        Me.tbarAngle.Location = New System.Drawing.Point(12, 31)
        Me.tbarAngle.Maximum = 179
        Me.tbarAngle.Name = "tbarAngle"
        Me.tbarAngle.Size = New System.Drawing.Size(196, 50)
        Me.tbarAngle.TabIndex = 1
        '
        'lblAngle
        '
        Me.lblAngle.AutoSize = True
        Me.lblAngle.Location = New System.Drawing.Point(22, 12)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New System.Drawing.Size(39, 13)
        Me.lblAngle.TabIndex = 2
        Me.lblAngle.Text = "Label1"
        '
        'lblArmAngle
        '
        Me.lblArmAngle.AutoSize = True
        Me.lblArmAngle.Location = New System.Drawing.Point(639, 11)
        Me.lblArmAngle.Name = "lblArmAngle"
        Me.lblArmAngle.Size = New System.Drawing.Size(39, 13)
        Me.lblArmAngle.TabIndex = 3
        Me.lblArmAngle.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Kp:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ki:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Kd:"
        '
        'tbarKp
        '
        Me.tbarKp.Location = New System.Drawing.Point(12, 109)
        Me.tbarKp.Maximum = 100
        Me.tbarKp.Name = "tbarKp"
        Me.tbarKp.Size = New System.Drawing.Size(196, 50)
        Me.tbarKp.TabIndex = 7
        '
        'tbarKi
        '
        Me.tbarKi.Location = New System.Drawing.Point(12, 189)
        Me.tbarKi.Maximum = 100
        Me.tbarKi.Name = "tbarKi"
        Me.tbarKi.Size = New System.Drawing.Size(196, 50)
        Me.tbarKi.TabIndex = 8
        '
        'tbarKd
        '
        Me.tbarKd.Location = New System.Drawing.Point(12, 296)
        Me.tbarKd.Maximum = 50
        Me.tbarKd.Name = "tbarKd"
        Me.tbarKd.Size = New System.Drawing.Size(196, 50)
        Me.tbarKd.TabIndex = 9
        '
        'lblKd
        '
        Me.lblKd.AutoSize = True
        Me.lblKd.Location = New System.Drawing.Point(168, 280)
        Me.lblKd.Name = "lblKd"
        Me.lblKd.Size = New System.Drawing.Size(39, 13)
        Me.lblKd.TabIndex = 10
        Me.lblKd.Text = "Label4"
        '
        'lblKi
        '
        Me.lblKi.AutoSize = True
        Me.lblKi.Location = New System.Drawing.Point(167, 172)
        Me.lblKi.Name = "lblKi"
        Me.lblKi.Size = New System.Drawing.Size(39, 13)
        Me.lblKi.TabIndex = 11
        Me.lblKi.Text = "Label4"
        '
        'lblKp
        '
        Me.lblKp.AutoSize = True
        Me.lblKp.Location = New System.Drawing.Point(167, 88)
        Me.lblKp.Name = "lblKp"
        Me.lblKp.Size = New System.Drawing.Size(39, 13)
        Me.lblKp.TabIndex = 12
        Me.lblKp.Text = "Label4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 514)
        Me.Controls.Add(Me.lblKp)
        Me.Controls.Add(Me.lblKi)
        Me.Controls.Add(Me.lblKd)
        Me.Controls.Add(Me.tbarKd)
        Me.Controls.Add(Me.tbarKi)
        Me.Controls.Add(Me.tbarKp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblArmAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.tbarAngle)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Asteroids Demo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarKp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarKi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarKd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PowerTimer As System.Windows.Forms.Timer
    Friend WithEvents PidTimer As System.Windows.Forms.Timer
    Friend WithEvents tbarAngle As System.Windows.Forms.TrackBar
    Friend WithEvents lblAngle As System.Windows.Forms.Label
    Friend WithEvents lblArmAngle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbarKp As System.Windows.Forms.TrackBar
    Friend WithEvents tbarKi As System.Windows.Forms.TrackBar
    Friend WithEvents tbarKd As System.Windows.Forms.TrackBar
    Friend WithEvents lblKd As System.Windows.Forms.Label
    Friend WithEvents lblKi As System.Windows.Forms.Label
    Friend WithEvents lblKp As System.Windows.Forms.Label

End Class
