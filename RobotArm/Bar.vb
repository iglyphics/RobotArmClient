Imports System.Drawing.Drawing2D
Imports System.Net.Sockets
Public Enum RotationDirection
    CW
    CCW
End Enum
Public Class Bar
    Private _Name As String = ""
    Private _Path As GraphicsPath
    Private _Width As Integer
    Private _Height As Integer
    Private _RotationPoint As PointF
    Private _Anchor As PointF
    Private _Angle As Single = 0
    Private _BaseBar As Bar = Nothing
    Private _ParentControl As Control
    Private _MouseDown As Boolean = False
    Private _EndPoint As PointF = New PointF(0, 0)
    Private _AngleOffset = 90
    Private _StartOffset = 0
    Private _RotationDirection = RotationDirection.CW
    Private _LastPosition As Single = 0
    Private _UpdateTimer As Timer = New Timer()
    'Private _Arc As 
   

    Public Event PositionChanged(ByVal sender As Bar)


    Public Sub New(ByVal Parent As Control, ByVal Width As Integer, ByVal Height As Integer)
        _Width = Width
        _Height = Height
        _Path = New GraphicsPath()
        _Path.AddRectangle(New Rectangle(Width, 3 * Width, Width, Height - 3 * Width))
        _Path.AddEllipse(0, 0, 3 * Width, 3 * Width)
        _Path.AddRectangle(New Rectangle(0, Height, 3 * Width, 3 * Width))
        _RotationPoint = New PointF(Width * 3 / 2, Width * 3 / 2)

        _Anchor = New PointF(Width / 2, 0)
        _ParentControl = Parent
        AddHandler _ParentControl.MouseDown, AddressOf OnMouseDown
        AddHandler _ParentControl.MouseMove, AddressOf OnMouseMove
        AddHandler _ParentControl.MouseUp, AddressOf OnMouseUp

        _UpdateTimer.Interval = 100
        AddHandler _UpdateTimer.Tick, AddressOf UpdatePosition
        _UpdateTimer.Start()

    End Sub

    Private Sub UpdatePosition()
        If _LastPosition <> Me._Angle Then
            _LastPosition = _Angle
            RaiseEvent PositionChanged(Me)
        End If
    End Sub

    Private Sub OnMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If HitTest(e.Location) Then
            _MouseDown = True
        End If
    End Sub

    Private Sub OnMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If _MouseDown Then
            Angle = Math.Atan2(_Anchor.X - e.X, e.Y - _Anchor.Y) / 0.0174533 - (_AngleOffset + _StartOffset)
        End If
    End Sub

    Private Sub OnMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        _MouseDown = False
    End Sub

    Public Function TransformedPath() As GraphicsPath
        Dim P As GraphicsPath = _Path.Clone()
        Dim Mr As Matrix = New Matrix()
        Dim Mt As Matrix = New Matrix()

        Mr.RotateAt(AdjustedAngle, New PointF(_RotationPoint.X, _RotationPoint.Y))
        P.Transform(Mr)

        Mt.Translate(_Anchor.X - _RotationPoint.X, _Anchor.Y - _RotationPoint.Y)
        P.Transform(Mt)


        Return P
    End Function
    Public Sub Draw(ByVal g As Graphics)
        Dim Path As GraphicsPath = TransformedPath()
        Dim MyPen As Pen = New Pen(Color.Black)

        g.FillPath(Brushes.Beige, Path)
        g.DrawPath(MyPen, Path)
        Dim Pt As PointF = FreeEnd
        g.DrawEllipse(Pens.Red, Pt.X - 5, Pt.Y - 5, 10, 10)
    End Sub

    Public Property Angle() As Single
        Get
            Return _Angle
        End Get
        Set(ByVal value As Single)

            value = value Mod 360
            If value < 0 Then
                value += 360
            End If
            If value >= 0 And value < 180 Then
                _Angle = value
                'RaiseEvent PositionChanged(Me)
            Else
                Dim x As Integer = 2344
            End If
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

    Public Property StartOffset() As Single
        Get
            Return _StartOffset
        End Get
        Set(ByVal value As Single)
            _StartOffset = value

        End Set
    End Property

    Public ReadOnly Property FreeEnd() As PointF
        Get
            Dim Pt As PointF = New PointF(0, 0)
            Dim Rads As Single = (AdjustedAngle + 90) * 0.0174533
            Pt.X = _Anchor.X + Math.Cos(Rads) * _Height
            Pt.Y = Math.Sin(Rads) * _Height + _Anchor.Y

            Return Pt
        End Get
    End Property

    Public Property BaseBar() As Bar
        Get
            Return _BaseBar
        End Get
        Set(ByVal value As Bar)
            _BaseBar = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public ReadOnly Property AdjustedAngle() As Single
        Get
            Dim AA As Single

            AA = _Angle + _AngleOffset + _StartOffset
            If _RotationDirection = RotationDirection.CCW Then
                'AA = 360 - AA
            End If
            Return AA
        End Get
    End Property

    Public Property RotationDirection() As RotationDirection
        Get
            Return _RotationDirection
        End Get
        Set(ByVal value As RotationDirection)
            _RotationDirection = value
        End Set
    End Property

    Public Function HitTest(ByVal Pt As PointF)
        Dim P As GraphicsPath = TransformedPath()

        Return P.IsVisible(Pt)
    End Function

End Class
