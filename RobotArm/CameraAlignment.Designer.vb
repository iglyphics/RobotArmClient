<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CameraAlignment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.picViewport = New System.Windows.Forms.PictureBox
        CType(Me.picViewport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picViewport
        '
        Me.picViewport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picViewport.Location = New System.Drawing.Point(12, 12)
        Me.picViewport.Name = "picViewport"
        Me.picViewport.Size = New System.Drawing.Size(640, 480)
        Me.picViewport.TabIndex = 0
        Me.picViewport.TabStop = False
        '
        'CameraAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 515)
        Me.Controls.Add(Me.picViewport)
        Me.Name = "CameraAlignment"
        Me.Text = "CameraAlignment"
        CType(Me.picViewport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picViewport As System.Windows.Forms.PictureBox
End Class
