﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.lblTest = New System.Windows.Forms.Label()
        Me.bwtTest = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(37, 33)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(39, 13)
        Me.lblTest.TabIndex = 0
        Me.lblTest.Text = "Label1"
        '
        'bwtTest
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.lblTest)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents bwtTest As System.ComponentModel.BackgroundWorker

End Class
