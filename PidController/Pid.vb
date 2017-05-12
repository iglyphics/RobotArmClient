Public Class Pid
    Private _SetPos As Single
    Private _Kp As Single = 5
    Private _Ki As Single = 2
    Private _Kd As Single = 0.05
    Private _MinI As Single = -55
    Private _MaxI As Single = 55
    Private _SumI As Single = 0
    Private _LastPos As Single = 0


    Public Function Update(ByVal Pos As Single) As Single
        Dim Power As Single
        Dim E As Single
        Dim P As Single
        Dim I As Single
        Dim D As Single

        E = _SetPos - Pos
        P = E * Kp
        _SumI = _SumI + E
        If _SumI < _MinI Then
            _SumI = _MinI
        ElseIf _SumI > _MaxI Then
            _SumI = _MaxI
        End If
        I = _SumI * Ki
        D = (Pos - _LastPos) * Kd
        _LastPos = Pos

        Power = (P + I + D)

        If Power < 10 Then
            'Power = 0
        End If
        Return Power


    End Function



    Public Property SetPos() As Single
        Get
            Return _SetPos
        End Get
        Set(ByVal value As Single)
            _SetPos = value
        End Set
    End Property



    Public Property Kp() As Single
        Get
            Return _Kp
        End Get
        Set(ByVal value As Single)
            _Kp = value
        End Set
    End Property

    Public Property Ki() As Single
        Get
            Return _Ki
        End Get
        Set(ByVal value As Single)
            _Ki = value
        End Set
    End Property

    Public Property Kd() As Single
        Get
            Return _Kd
        End Get
        Set(ByVal value As Single)
            _Kd = value
        End Set
    End Property

    Public Property MinI() As Single
        Get
            Return _MinI
        End Get
        Set(ByVal value As Single)
            _MinI = value
        End Set
    End Property

    Public Property MaxI() As Single
        Get
            Return _MaxI
        End Get
        Set(ByVal value As Single)
            _MaxI = value
        End Set
    End Property
End Class
