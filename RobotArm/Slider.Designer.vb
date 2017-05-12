<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Slider
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblText = New System.Windows.Forms.Label()
        Me.timerUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TrackBar, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtValue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblText, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(378, 76)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TrackBar
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TrackBar, 2)
        Me.TrackBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TrackBar.Location = New System.Drawing.Point(3, 23)
        Me.TrackBar.Maximum = 999
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(372, 42)
        Me.TrackBar.TabIndex = 0
        '
        'txtValue
        '
        Me.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtValue.Location = New System.Drawing.Point(268, 3)
        Me.txtValue.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(100, 20)
        Me.txtValue.TabIndex = 1
        '
        'lblText
        '
        Me.lblText.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblText.AutoSize = True
        Me.lblText.Location = New System.Drawing.Point(10, 3)
        Me.lblText.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(39, 13)
        Me.lblText.TabIndex = 2
        Me.lblText.Text = "Label1"
        '
        'timerUpdate
        '
        Me.timerUpdate.Enabled = True
        Me.timerUpdate.Interval = 250
        '
        'Slider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(0, 76)
        Me.Name = "Slider"
        Me.Size = New System.Drawing.Size(378, 76)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents timerUpdate As System.Windows.Forms.Timer

End Class
