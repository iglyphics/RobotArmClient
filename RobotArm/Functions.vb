Imports System.Math

Module Functions
    Public Const PI = 3.14159265

    Public Enum Tri_Stat
        neg = -1
        Zero = 0
        pos = 1
    End Enum

    Public Structure Cords_Type
        Public X As Single
        Public Y As Single
    End Structure

    Public Structure Ship_Type
        Public Speed As Single
        Public Direction As Single
        Public Angle As Single
        Public Location As Cords_Type
        Public Cords() As Cords_Type
        Public Ang_Const() As Single
        Public Len_Const() As Single
    End Structure

    Public Structure Blocks_Type
        Public Speed As Single
        Public Cords() As Cords_Type
        Public Ang_Const() As Single
        Public Len_Const() As Single
        Public Size As Byte
        Public Location As Cords_Type
        Public First As Boolean
        Public Vis As Boolean
        Public Direction As Single
        Public Rotate As Single
        Public Angle As Single
    End Structure

    Public Structure Shot_Type
        Public Speed As Single
        Public Direction As Single
        Public Location As Cords_Type
        Public TTL As Single
        Public First As Boolean
    End Structure

    Public Ship As Ship_Type
    Public Asteroids(39) As Blocks_Type
    Public Def_Ast As Blocks_Type
    Public Shots(19) As Shot_Type
    Public Turn As Tri_Stat
    Public Accelerate As Boolean
    Public Warp As Boolean
    Public Shoot As Boolean
    Public Dead As Boolean
    Public Score As Decimal

    Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal Destination() As Cords_Type, ByVal Source() As Cords_Type, ByVal Length As Long)

    Private Loop_1 As Long
    Private Loop_2 As Long

    Public Sub Init_const()
        With Ship
            For Loop_1 = 0 To 2
                .Ang_Const(Loop_1) = Atan((.Cords(Loop_1 + 1).X - .Cords(0).X) / (.Cords(Loop_1 + 1).Y - .Cords(0).Y))
                .Len_Const(Loop_1) = (.Cords(0).Y - .Cords(Loop_1 + 1).Y) / Cos(.Ang_Const(Loop_1))
            Next Loop_1
        End With

        With Def_Ast
            For Loop_1 = 0 To 9
                .Ang_Const(Loop_1) = Atan((.Cords(Loop_1 + 1).X - .Cords(0).X) / (.Cords(Loop_1 + 1).Y - .Cords(0).Y))
                .Len_Const(Loop_1) = (.Cords(0).Y - .Cords(Loop_1 + 1).Y) / Cos(.Ang_Const(Loop_1))
            Next Loop_1
        End With
        Score = 0
    End Sub

    Public Sub Init_Ast()

        Asteroids(0) = Def_Ast
        Asteroids(1) = Def_Ast
        Asteroids(2) = Def_Ast
        Asteroids(3) = Def_Ast
        With Asteroids(0)
            .Direction = Rnd() * 360
            .Location.X = Rnd() * 80
            .Location.Y = Rnd() * 80
            .Angle = Rnd() * 360
            .Rotate = Rnd() * 2 - 1
        End With
        With Asteroids(1)
            .Direction = Rnd() * 360
            .Location.X = Rnd() * 80 + 560
            .Location.Y = Rnd() * 80
            .Angle = Rnd() * 360
            .Rotate = Rnd() * 2 - 1
        End With
        With Asteroids(2)
            .Direction = Rnd() * 360
            .Location.X = Rnd() * 80 + 560
            .Location.Y = Rnd() * 80 + 400
            .Angle = Rnd() * 360
            .Rotate = Rnd() * 2 - 1
        End With
        With Asteroids(3)
            .Direction = Rnd() * 360
            .Location.X = Rnd() * 80
            .Location.Y = Rnd() * 80 + 400
            .Angle = Rnd() * 360
            .Rotate = Rnd() * 2 - 1
        End With
    End Sub

    Public Sub Set_Default()
        With Ship
            ReDim .Cords(3)
            ReDim .Ang_Const(2)
            ReDim .Len_Const(2)
            .Speed = 0
            .Angle = 180
            .Direction = 0
            .Cords(0).X = 7
            .Cords(0).Y = 10
            .Cords(1).X = 7
            .Cords(1).Y = 0
            .Cords(2).X = 0
            .Cords(2).Y = 20
            .Cords(3).X = 14
            .Cords(3).Y = 20
            .Location.X = 320
            .Location.Y = 240
        End With
        With Def_Ast
            ReDim .Cords(10)
            ReDim .Ang_Const(9)
            ReDim .Len_Const(9)
            .Speed = 0.3
            .Size = 1
            .Cords(0).X = 50
            .Cords(0).Y = 50
            .Cords(1).X = 52
            .Cords(1).Y = 0
            .Cords(2).X = 73
            .Cords(2).Y = 9
            .Cords(3).X = 65
            .Cords(3).Y = 20
            .Cords(4).X = 95
            .Cords(4).Y = 45
            .Cords(5).X = 75
            .Cords(5).Y = 80
            .Cords(6).X = 50
            .Cords(6).Y = 100
            .Cords(7).X = 25
            .Cords(7).Y = 75
            .Cords(8).X = 0
            .Cords(8).Y = 70
            .Cords(9).X = 5
            .Cords(9).Y = 30
            .Cords(10).X = 25
            .Cords(10).Y = 10
            .Vis = True
            .First = True
            .Size = 1
        End With
    End Sub
End Module
