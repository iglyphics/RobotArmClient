Imports System.ComponentModel

Public Class JointPanel
    Public Event MaxPowerChanged(ByVal Obj As JointPanel, ByVal Value As Integer)
    Public Event KpChanged(ByVal Obj As JointPanel, ByVal Value As Single)
    Public Event KiChanged(ByVal Obj As JointPanel, ByVal Value As Single)
    Public Event KdChanged(ByVal Obj As JointPanel, ByVal Value As Single)

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Title() As String
        Get
            Return GroupBox.Text
        End Get
        Set(ByVal value As String)
            GroupBox.Text = value
        End Set
    End Property


    Private Sub Kp_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles Kp.ValueChanged
        RaiseEvent KpChanged(Me, Value)
    End Sub


    Private Sub Ki_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles Ki.ValueChanged
        RaiseEvent KiChanged(Me, Value)
    End Sub


    Private Sub Kd_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles Kd.ValueChanged
        RaiseEvent KdChanged(Me, Value)
    End Sub


    Private Sub MaxPower_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles MaxPower.ValueChanged
        RaiseEvent MaxPowerChanged(Me, Value)
    End Sub

    Private Sub JointPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Kd.Steps = 100
    End Sub
End Class
