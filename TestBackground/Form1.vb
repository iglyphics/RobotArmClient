Imports System.Threading
Public Class Form1
    Dim _Counter As Integer = 0
    Private Sub bwtTest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwtTest.DoWork
        Thread.Sleep(1000)
        Dim frm As Form1 = e.Argument
        frm.lblTest.Text = _Counter
        frm._Counter += 1
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bwtTest.RunWorkerAsync(Me)
    End Sub
End Class
