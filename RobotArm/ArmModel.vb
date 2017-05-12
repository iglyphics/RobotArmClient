Public Class ArmModel

    Private _b As Single
    Private _h As Single
    Private _alpha As Single
    Private _beta As Single
    Private _mu As Single
    Private _gamma As Single
    Private _phi As Single
    Private _theta As Single
    Private _ArmSegmentLength As Single
    Private _UpperArmLength As Double
    Private _ForearmLength As Double
    Private _ArcRadius As Single
    Private _ShoulderDistance As Single
    'Dim ShoulderDistance As Single

    Public Sub New(ByVal ArmSegmentLength As Single, ByVal ArcRadius As Single, ByVal ShoulderDistance As Single)
        _ArmSegmentLength = ArmSegmentLength
        _ArcRadius = ArcRadius
        _ShoulderDistance = ShoulderDistance
    End Sub

    Public Sub New(ByVal UpperArmLength As Double, ByVal ForearmLength As Double, ByVal ArcRadius As Single, ByVal ShoulderDistance As Single)
        _ArmSegmentLength = ArmSegmentLength
        _UpperArmLength = UpperArmLength
        _ForearmLength = ForearmLength
        _ArcRadius = ArcRadius
        _ShoulderDistance = ShoulderDistance
    End Sub

    Public ReadOnly Property b() As Single
        Get
            Return _b
        End Get
    End Property

    Public ReadOnly Property h() As Single
        Get
            Return _h
        End Get
    End Property

    Public ReadOnly Property alpha() As Single
        Get
            Return _alpha
        End Get
    End Property
    Public ReadOnly Property beta() As Single
        Get
            Return _beta
        End Get
    End Property
    Public ReadOnly Property mu() As Single
        Get
            Return _mu
        End Get
    End Property
    Public ReadOnly Property gamma() As Single
        Get
            Return _gamma
        End Get
    End Property
    Public ReadOnly Property phi() As Single
        Get
            Return _phi
        End Get
    End Property
    Public ReadOnly Property theta() As Single
        Get
            Return _theta
        End Get
    End Property

    Public Property ArmSegmentLength() As Single
        Get
            Return _ArmSegmentLength
        End Get
        Set(ByVal value As Single)
            _ArmSegmentLength = value
        End Set
    End Property
    Public Property ArcRadius() As Single
        Get
            Return _ArcRadius
        End Get
        Set(ByVal value As Single)
            _ArcRadius = value
        End Set
    End Property
    Public Property ShoulderDistance() As Single
        Get
            Return _ShoulderDistance
        End Get
        Set(ByVal value As Single)
            _ShoulderDistance = value
        End Set
    End Property


    Public Sub Calculate(ByVal ArcAngle As Single)
        'Dim Radius As Single
        Dim Angle As Single
        Dim Rad180 As Double = 180 * 0.0174533

        'Radius = ArcRadius
        Angle = ArcAngle * 0.0174533
        'ShoulderDistance = ShoulderDistance

        '_b = Math.Sqrt(Radius ^ 2 + ShoulderDistance ^ 2 - 2 * Radius * ShoulderDistance * Math.Cos(Angle))
        '_h = Radius * Math.Sin(Angle)
        '_alpha = Math.Asin(h / b) / 0.0174533
        '_mu = Math.Acos((b / 2) / _ArmSegmentLength) / 0.0174533
        '_beta = ArcAngle

        ''alpha = Math.Acos((Radius ^ 2 - b ^ 2 - ShoulderDistance ^ 2) / (-2 * b * ShoulderDistance)) / 0.0174533
        '_phi = 180 - Math.Acos(1 - (b ^ 2) / (2 * _ArmSegmentLength ^ 2)) / 0.0174533
        '_mu = phi / 2
        ''phi = 180 - 2 * mu
        '_gamma = mu + (180 - alpha - beta)
        '_theta = 180 - mu - alpha

        Dim c As Double
        Dim D As Double = _ShoulderDistance
        Dim R As Double = _ArcRadius
        Dim Au As Double = _UpperArmLength
        Dim Af As Double = _ForearmLength
        Dim Alpha As Double = ArcAngle * 0.0174533
        Dim AlphaP As Double
        Dim Beta As Double
        Dim BetaP As Double
        Dim Gamma As Double
        Dim GammaP As Double

        c = Math.Sqrt(R ^ 2 + D ^ 2 - 2 * R * D * Math.Cos(Alpha))
        Beta = Math.Acos((D ^ 2 - c ^ 2 - R ^ 2) / (-2 * R * c))
        Gamma = Rad180 - Alpha - Beta

        GammaP = Math.Acos((Af ^ 2 - Au ^ 2 - c ^ 2) / (-2 * Au * c))
        AlphaP = Math.Acos((c ^ 2 - Au ^ 2 - Af ^ 2) / (-2 * Au * Af))
        BetaP = Rad180 - AlphaP - GammaP

        _theta = (Rad180 - Gamma - GammaP) / 0.0174533
        _gamma = 180 - (Rad180 - Beta - BetaP) / 0.0174533
        _phi = 180 - (Rad180 - GammaP - BetaP) / 0.0174533

        

    End Sub



End Class
