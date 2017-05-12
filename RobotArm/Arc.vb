Public Class Arc
    Public Enum Direction
        Clockwise
        CounterClockwise
    End Enum
    Private _FromAngle As Single = 0
    Private _ToAngle As Single = 0
    Private _AdjustedFrom As Single = 0
    Private _AdjustedTo As Single = 0

    Private _Direction As Direction
    Private _Offset As Single = 0

    Public Sub New(ByVal FromAngle As Single, ByVal ToAngle As Single, ByVal Direction As Direction)
        _FromAngle = FromAngle
        _ToAngle = ToAngle
        _Direction = Direction

        If _Direction = Arc.Direction.Clockwise Then
            _AdjustedFrom = _FromAngle
            _AdjustedTo = _ToAngle
            _Offset = 0
            If _ToAngle < _FromAngle Then
                _AdjustedFrom = 0
                _AdjustedTo = 360 - _FromAngle
                _Offset = -_FromAngle
            End If
        Else
            _AdjustedFrom = _FromAngle
            _AdjustedTo = _ToAngle
            _Offset = 0
            If _ToAngle < _FromAngle Then
                _AdjustedFrom = 0
                _AdjustedTo = 360 - _FromAngle
                _Offset = -_FromAngle
            End If
        End If
    End Sub

    Public Function HitTest(ByVal Angle As Single)
        Dim ToAngle As Single = _ToAngle
    End Function
End Class
