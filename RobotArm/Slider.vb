Imports System.ComponentModel

Public Class Slider
    Private _Factor As Single
    Private _Minimum As Single = 0
    Private _Maximum As Single = 100
    Private _Steps As Integer = 10
    Private _MouseDown As Boolean = False
    Private _LastValue As Single = 0
    Public Event ValueChanged(ByVal Obj As Slider, ByVal Value As Single)

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Steps() As Integer
        Get
            Return _Steps
        End Get
        Set(ByVal value As Integer)
            Dim TickFreq As Integer
            _Steps = value
            TickFreq = (TrackBar.Maximum - TrackBar.Minimum) / _Steps
            If TickFreq < 1 Then
                TickFreq = 1
            End If
            TrackBar.TickFrequency = TickFreq
        End Set
    End Property


    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Minimum() As Single
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Single)
            _Minimum = value
            GetFactor()
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Maximum() As Single
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Single)
            _Maximum = value
            GetFactor()
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Value As Single
        Get
            Return (TrackBar.Value - TrackBar.Minimum) * _Factor + _Minimum
        End Get
        Set(ByVal setvalue As Single)
            If setvalue < _Minimum Then
                setvalue = _Minimum
            ElseIf setvalue > _Maximum Then
                setvalue = _Maximum
            End If
            TrackBar.Value = (setvalue - _Minimum) / _Factor

        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Property Title() As String
        Get
            Return lblText.Text
        End Get
        Set(ByVal value As String)
            lblText.Text = value
        End Set
    End Property

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub GetFactor()
        _Factor = (_Maximum - _Minimum) / TrackBar.Maximum
    End Sub

    Private Sub TrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar.ValueChanged
        txtValue.Text = Value
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        Value = txtValue.Text
    End Sub

    Private Sub TrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar.MouseUp
        _MouseDown = False
        txtValue.Text = Value
        Value = txtValue.Text

    End Sub

    Private Sub TrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar.MouseDown
        _MouseDown = True
    End Sub

    Private Sub timerUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerUpdate.Tick
        If Value <> _LastValue Then
            _LastValue = Value
            'RaiseEvent ValueChanged(Me, _LastValue)
        End If
    End Sub
End Class
