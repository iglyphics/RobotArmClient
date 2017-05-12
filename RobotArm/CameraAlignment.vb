Public Class CameraAlignment
    Private _Loaded As Boolean = False
    Public Property Loaded() As Boolean
        Get
            Return _Loaded
        End Get
        Set(ByVal value As Boolean)
            _Loaded = value
        End Set
    End Property

    Private Sub CameraAlignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Loaded = True
    End Sub
End Class