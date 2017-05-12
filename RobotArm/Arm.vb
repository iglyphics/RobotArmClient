Public Class Arm
    Private _Bars As List(Of Bar) = New List(Of Bar)
    Private _Anchor As PointF = New Point(0, 0)
    Private _Parent As Control
    Private _AngleOffset As Single = 0

    Public Sub New(ByVal Parent As Control, ByVal Anchor As PointF)
        _Parent = Parent
        _Anchor = Anchor
    End Sub

    Public Sub Add(ByVal B As Bar)
        _Bars.Add(B)
    End Sub
    Public Sub Draw(ByVal g As Graphics)
        Dim Anchor As PointF = _Anchor
        Dim Offset As Single = _AngleOffset
        Dim B As Bar
        For Each B In _Bars
            B.AngleOffset = Offset
            B.Anchor = Anchor
            B.Draw(g)
            Anchor = B.FreeEnd
            Offset += B.Angle
        Next
    End Sub

    Public Property Bars() As List(Of Bar)
        Get
            Return _Bars
        End Get
        Set(ByVal value As List(Of Bar))
            _Bars = value
        End Set
    End Property

    Public Property Anchor() As PointF
        Get
            Return _Anchor
        End Get
        Set(ByVal value As PointF)
            _Anchor = value
        End Set
    End Property

    Public Property AngleOffset() As Single
        Get
            Return _AngleOffset
        End Get
        Set(ByVal value As Single)
            _AngleOffset = value
        End Set
    End Property
End Class
