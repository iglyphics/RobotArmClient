Imports System.Math
Imports System.Drawing.Drawing2D

Public Class FrmAsteroids
    Private First As Boolean
    Private Loop_1 As Long
    Private Loop_2 As Long
    Private Loop_3 As Long
    Private MyImage As Bitmap
    Private MyGraphic As Graphics
    Private Mypen As Pen
    Private DelPen As Pen
    Private WithEvents Timer1 As Windows.Forms.Timer
    Private _BarPath As Bar
    Private _RotateBar As Boolean = False
    Private _Arm As Arm

    Private Sub Asteroids_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case 39
                Turn = Tri_Stat.pos
            Case 37
                Turn = Tri_Stat.neg
            Case 38
                Accelerate = True
            Case 40
                Warp = True
            Case 32
                Shoot = True
        End Select
        '32 = Space
        '38 = up
        '40 = Down
        '39 = right
        '37 = left
    End Sub

    Private Sub Asteroids_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case 39, 37
                Turn = Tri_Stat.Zero
            Case 38
                Accelerate = False
        End Select

    End Sub

    Private Sub Asteroids_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Mypen = New Pen(Color.Black, 1)
        DelPen = New Pen(Color.White, 1)
        Timer1 = New Windows.Forms.Timer
        MyImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        MyGraphic = Graphics.FromImage(MyImage)

        First = True
        Set_Default()
        Timer1.Interval = 15
        Timer1.Enabled = True
        Dead = False
        Init_const()
        Init_Ast()
        _BarPath = New Bar(PictureBox1, 8, 200)
        _BarPath.Anchor = New PointF(200, 200)
        _Arm = New Arm(PictureBox1, New PointF(300, 300))
        '_Arm.ShoulderAngle = 45
        '_Arm.ElbowAngle = 45


    End Sub


    Private Sub Check_Input()
        Dim Tmp As Cords_Type
        Select Case Turn
            Case Tri_Stat.pos
                Ship.Angle = Ship.Angle + 1.5
                If Ship.Angle >= 360 Then Ship.Angle = Ship.Angle - 360
            Case Tri_Stat.neg
                Ship.Angle = Ship.Angle - 1.5
                If Ship.Angle < 0 Then Ship.Angle = Ship.Angle + 360
        End Select
        If Accelerate Then
            With Ship
                Tmp.X = .Speed * Sin(.Direction * PI / 180)
                Tmp.Y = .Speed * Cos(.Direction * PI / 180)
                Tmp.X = Tmp.X + (0.02 * Sin(.Angle * PI / 180))
                Tmp.Y = Tmp.Y + (0.02 * Cos(.Angle * PI / 180))
                If Tmp.Y = 0 Then
                    .Direction = (Atan(Tmp.Y / Tmp.X)) / PI * 180
                    .Speed = Tmp.X / (Cos(.Direction * PI / 180))
                Else
                    .Direction = (Atan(Tmp.X / Tmp.Y)) / PI * 180
                    .Speed = Tmp.Y / (Cos(.Direction * PI / 180))
                End If
                If .Speed > 2 Then .Speed = 2
                If .Speed < -2 Then .Speed = -2
            End With
        End If
        If Warp Then
            With Ship
                .Location.X = Rnd() * 640
                .Location.Y = Rnd() * 480
                .Angle = Rnd() * 360
                .Direction = Rnd() * 360
            End With
            Warp = False
        End If
        If Shoot Then
            For Loop_1 = 0 To 19
                If Shots(Loop_1).TTL = 0 Then
                    Shots(Loop_1).Direction = Ship.Angle
                    Shots(Loop_1).Location.X = Ship.Location.X
                    Shots(Loop_1).Location.Y = Ship.Location.Y
                    Shots(Loop_1).Speed = 3
                    Shots(Loop_1).TTL = 320
                    Shots(Loop_1).First = True
                    Exit For
                End If
            Next Loop_1
            Shoot = False
        End If
    End Sub

    Private Sub Do_Score()
        MyGraphic.DrawString("Score: " & Score, Me.Font, Brushes.Black, 1, 1)

    End Sub

    Private Sub Check_Space()
        Dim Diff As Cords_Type
        Dim Direction As Single
        Dim Distance As Single
        For Loop_1 = 0 To 39
            With Asteroids(Loop_1)
                If .Vis Then
                    Diff.X = .Location.X - 320
                    Diff.Y = .Location.Y - 240
                    If Diff.Y = 0 Then
                        Direction = (Atan(Diff.Y / Diff.X)) / PI * 180
                        Distance = Diff.X / (Cos(Direction * PI / 180))
                    Else
                        Direction = (Atan(Diff.X / Diff.Y)) / PI * 180
                        Distance = Diff.Y / (Cos(Direction * PI / 180))
                    End If
                    If Abs(Distance) < (50 / .Size) + 40 Then
                        Exit Sub
                    End If
                End If
            End With
        Next Loop_1
        Dead = False
        First = True
        With Ship
            .Speed = 0
            .Angle = 180
            .Direction = 0
            .Location.X = 320
            .Location.Y = 240
        End With
        Put_Ship()
        First = False

    End Sub
    Private Sub Check_Stage()
        For Loop_1 = 0 To 39
            With Asteroids(Loop_1)
                If .Vis Then
                    Exit Sub
                End If
            End With
        Next Loop_1
        Init_Ast()
        With Ship
            .Location.X = 320
            .Location.Y = 240
            .Speed = 0
        End With
    End Sub

    Private Sub Hit_Aster()
        Dim Diff As Cords_Type
        Dim Direction As Single
        Dim Distance As Single
        For Loop_1 = 0 To 39
            With Asteroids(Loop_1)
                If .Vis Then
                    For Loop_2 = 0 To 19
                        If Shots(Loop_2).TTL > 0 Then
                            Diff.X = .Location.X - Shots(Loop_2).Location.X
                            Diff.Y = .Location.Y - Shots(Loop_2).Location.Y
                            If Diff.Y = 0 Then
                                Direction = (Atan(Diff.Y / Diff.X)) / PI * 180
                                Distance = Diff.X / (Cos(Direction * PI / 180))
                            Else
                                Direction = (Atan(Diff.X / Diff.Y)) / PI * 180
                                Distance = Diff.Y / (Cos(Direction * PI / 180))
                            End If
                            If Abs(Distance) < 50 / .Size Then
                                Score = Score + 5 * .Size
                                MyGraphic.DrawRectangle(DelPen, Shots(Loop_2).Location.X - 1, Shots(Loop_2).Location.Y - 1, 2, 2)
                                Shots(Loop_2).TTL = 0
                                Shots(Loop_2).First = True
                                .Size = .Size * 2
                                If .Size <= 8 Then
                                    For Loop_3 = 0 To 39
                                        If Not (Asteroids(Loop_3).Vis) Then
                                            Asteroids(Loop_3) = Asteroids(Loop_1)
                                            Asteroids(Loop_1).Direction = Rnd() * 360
                                            Asteroids(Loop_1).Rotate = Rnd() * .Size - (.Size / 2)
                                            Asteroids(Loop_3).Direction = Asteroids(Loop_1).Direction + 180
                                            Asteroids(Loop_3).Rotate = Rnd() * .Size - (.Size / 2)
                                            Asteroids(Loop_3).Vis = True
                                            Asteroids(Loop_3).First = True
                                            Exit For
                                        End If
                                    Next Loop_3
                                End If
                            End If
                        End If
                    Next Loop_2
                    If Not Dead Then
                        Diff.X = .Location.X - Ship.Location.X
                        Diff.Y = .Location.Y - Ship.Location.Y
                        If Diff.Y = 0 Then
                            Direction = (Atan(Diff.Y / Diff.X)) / PI * 180
                            Distance = Diff.X / (Cos(Direction * PI / 180))
                        Else
                            Direction = (Atan(Diff.X / Diff.Y)) / PI * 180
                            Distance = Diff.Y / (Cos(Direction * PI / 180))
                        End If
                        If Abs(Distance) < (50 / .Size) + 6 Then
                            Dead = True
                        End If
                    End If
                End If
            End With
        Next Loop_1
    End Sub

    Private Sub Put_Aster()
        Dim Cord(9) As Cords_Type
        For Loop_1 = 0 To 39
            With Asteroids(Loop_1)
                If .Vis Then

                    .Location.X = .Location.X + .Speed * Sin(.Direction * PI / 180)
                    .Location.Y = .Location.Y - .Speed * Cos(.Direction * PI / 180)
                    .Angle = .Angle + .Rotate

                    If .Location.X >= 640 Then .Location.X = .Location.X - 640
                    If .Location.X < 0 Then .Location.X = .Location.X + 640
                    If .Location.Y >= 480 Then .Location.Y = .Location.Y - 480
                    If .Location.Y < 0 Then .Location.Y = .Location.Y + 480
                    If .Angle >= 360 Then .Angle = .Angle - 360
                    If .Angle < 0 Then .Angle = .Angle + 360

                    For Loop_2 = 0 To 9
                        Cord(Loop_2).X = .Location.X - (.Len_Const(Loop_2) * Sin(.Ang_Const(Loop_2) + .Angle * PI / 180)) / .Size
                        Cord(Loop_2).Y = .Location.Y + (.Len_Const(Loop_2) * Cos(.Ang_Const(Loop_2) + .Angle * PI / 180)) / .Size
                    Next Loop_2

                    If .Size > 8 Then
                        .Vis = False
                    Else
                        For Loop_2 = 0 To 8
                            MyGraphic.DrawLine(Mypen, Cord(Loop_2).X, Cord(Loop_2).Y, Cord(Loop_2 + 1).X, Cord(Loop_2 + 1).Y)
                        Next Loop_2
                        MyGraphic.DrawLine(Mypen, Cord(9).X, Cord(9).Y, Cord(0).X, Cord(0).Y)


                        .First = False
                    End If
                End If
            End With
        Next Loop_1
    End Sub

    Private Sub Put_Shots()
        'MyGraphic = Graphics.FromImage(MyImage)
        For Loop_1 = 0 To 19
            With Shots(Loop_1)
                If .TTL > 0 Then
                    .Location.X = .Location.X - .Speed * Sin(.Direction * PI / 180)
                    .Location.Y = .Location.Y + .Speed * Cos(.Direction * PI / 180)
                    If .Location.X >= 640 Then .Location.X = .Location.X - 640
                    If .Location.X < 0 Then .Location.X = .Location.X + 640
                    If .Location.Y >= 480 Then .Location.Y = .Location.Y - 480
                    If .Location.Y < 0 Then .Location.Y = .Location.Y + 480
                    MyGraphic.DrawRectangle(Mypen, .Location.X - 1, .Location.Y - 1, 2, 2)
                    .TTL = .TTL - .Speed

                    .First = False
                End If
                If .TTL <= 0 And Not .First Then
                    MyGraphic.DrawRectangle(DelPen, .Location.X - 1, .Location.Y - 1, 2, 2)
                    .TTL = 0
                    .First = True
                End If
            End With
        Next Loop_1
    End Sub

    Private Sub Put_Ship()
        Dim Cord(2) As Cords_Type
        With Ship
            .Location.X = .Location.X - .Speed * Sin(.Direction * PI / 180)
            .Location.Y = .Location.Y + .Speed * Cos(.Direction * PI / 180)

            If .Location.X >= 640 Then .Location.X = .Location.X - 640
            If .Location.X < 0 Then .Location.X = .Location.X + 640
            If .Location.Y >= 480 Then .Location.Y = .Location.Y - 480
            If .Location.Y < 0 Then .Location.Y = .Location.Y + 480

            For Loop_1 = 0 To 2
                Cord(Loop_1).X = .Location.X - (.Len_Const(Loop_1) * Sin(.Ang_Const(Loop_1) + .Angle * PI / 180))
                Cord(Loop_1).Y = .Location.Y + (.Len_Const(Loop_1) * Cos(.Ang_Const(Loop_1) + .Angle * PI / 180))
            Next Loop_1

        End With
        MyGraphic.DrawLine(Mypen, Cord(0).X, Cord(0).Y, Cord(1).X, Cord(1).Y)
        MyGraphic.DrawLine(Mypen, Cord(1).X, Cord(1).Y, Cord(2).X, Cord(2).Y)
        MyGraphic.DrawLine(Mypen, Cord(2).X, Cord(2).Y, Cord(0).X, Cord(0).Y)

    End Sub

    Private Sub Timer1_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MyGraphic.Clear(Color.White)

        If Not Dead Then
            Check_Input()
            Put_Ship()
        Else
            Check_Space()
        End If
        Put_Shots()
        Put_Aster()
        Hit_Aster()
        Check_Stage()
        Do_Score()

        _BarPath.Draw(MyGraphic)
        _Arm.Draw(MyGraphic)


        PictureBox1.Image = MyImage
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        With Ship
            .Angle = Math.Atan2(.Location.X - e.X, e.Y - .Location.Y) / 0.0174533
        End With
        'If _BarPath.HitTest(e.Location) Then
        '    _RotateBar = True
        'End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        With Ship
            .Angle = Math.Atan2(.Location.X - e.X, e.Y - .Location.Y) / 0.0174533
        End With
        'If _RotateBar Then
        '    _BarPath.Angle = Math.Atan2(_BarPath.Anchor.X - e.X, e.Y - _BarPath.Anchor.Y) / 0.0174533
        'End If
    End Sub

    Private Function GetDonutPath(ByVal rect As Rectangle, ByVal holeRadius As Integer) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddRectangle(rect)
        'path.AddEllipse(rect)
        Dim centerPoint As Point = New Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2)
        'Dim holeRect As Rectangle = New Rectangle(centerPoint.X - holeRadius, centerPoint.Y - holeRadius, holeRadius * 2, holeRadius * 2)
        'path.AddEllipse(holeRect)

        Dim format As StringFormat = New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        path.AddString("Hi", Me.Font.FontFamily, CInt(Me.Font.Style), Me.Font.Height, RectangleF.op_Implicit(rect), format)

        Return path
    End Function

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        '_RotateBar = False
    End Sub
End Class
