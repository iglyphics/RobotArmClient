<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlWristSettings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AngleFactor = New RobotCam.Slider()
        Me.AngleOffset = New RobotCam.Slider()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AngleFactor)
        Me.GroupBox1.Controls.Add(Me.AngleOffset)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 384)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wrist"
        '
        'AngleFactor
        '
        Me.AngleFactor.Dock = System.Windows.Forms.DockStyle.Top
        Me.AngleFactor.Location = New System.Drawing.Point(3, 92)
        Me.AngleFactor.Maximum = 1.5!
        Me.AngleFactor.Minimum = 0.0!
        Me.AngleFactor.MinimumSize = New System.Drawing.Size(0, 76)
        Me.AngleFactor.Name = "AngleFactor"
        Me.AngleFactor.Size = New System.Drawing.Size(360, 76)
        Me.AngleFactor.Steps = 150
        Me.AngleFactor.TabIndex = 1
        Me.AngleFactor.Title = "Angle Factor"
        Me.AngleFactor.Value = 0.0!
        '
        'AngleOffset
        '
        Me.AngleOffset.Dock = System.Windows.Forms.DockStyle.Top
        Me.AngleOffset.Location = New System.Drawing.Point(3, 16)
        Me.AngleOffset.Maximum = 50.0!
        Me.AngleOffset.Minimum = -50.0!
        Me.AngleOffset.MinimumSize = New System.Drawing.Size(0, 76)
        Me.AngleOffset.Name = "AngleOffset"
        Me.AngleOffset.Size = New System.Drawing.Size(360, 76)
        Me.AngleOffset.Steps = 100
        Me.AngleOffset.TabIndex = 0
        Me.AngleOffset.Title = "Angle Offset"
        Me.AngleOffset.Value = 0.0000007450581!
        '
        'CtlWristSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CtlWristSettings"
        Me.Size = New System.Drawing.Size(366, 384)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AngleOffset As RobotCam.Slider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AngleFactor As RobotCam.Slider

End Class
