Public Class CtlWristSettings
    Public Event AngleOffsetChanged(ByVal Obj As CtlWristSettings, ByVal Value As Integer)
    Public Event AngleFactorChanged(ByVal Obj As CtlWristSettings, ByVal Value As Single)

    Private Sub AngleFactor_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles AngleFactor.ValueChanged
        RaiseEvent AngleFactorChanged(Me, Value)
    End Sub

    Private Sub AngleOffset_ValueChanged(ByVal Obj As RobotCam.Slider, ByVal Value As System.Single) Handles AngleOffset.ValueChanged
        RaiseEvent AngleOffsetChanged(Me, Value)
    End Sub
End Class
