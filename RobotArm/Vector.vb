Public Class Vector
    Private _Anchor As PointF
    Private _Angle As Single
    Private _Length As Single

    Public Sub New(ByVal Anchor As PointF, ByVal Angle As Single, ByVal Length As Single)
        _Anchor = Anchor
        _Angle = Angle
        _Length = Length
    End Sub

    Public ReadOnly Property EndPoint() As PointF
        Get
            Dim Pt As PointF = New PointF(0, 0)
            Dim Rads As Single = (_Angle + 90) * 0.0174533
            Pt.X = _Anchor.X + Math.Cos(Rads) * _Length
            Pt.Y = Math.Sin(Rads) * _Length + _Anchor.Y

            Return Pt
        End Get
    End Property

    Public Property Anchor() As PointF
        Get
            Return _Anchor
        End Get
        Set(ByVal value As PointF)
            _Anchor = value
        End Set
    End Property

    Public Property Angle() As Single
        Get
            Return _Angle
        End Get
        Set(ByVal value As Single)
            _Angle = value
        End Set
    End Property

    Public Property Length() As Single
        Get
            Return _Length
        End Get
        Set(ByVal value As Single)
            _Length = value
        End Set
    End Property
   
End Class
