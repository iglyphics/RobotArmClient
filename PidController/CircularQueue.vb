Imports System.Threading


Public Class CircularQueue(Of T)
    Private _Queue() As T
    Private _Head As Integer = 0
    Private _Tail As Integer = 0
    Private _Count As Integer = 0
    Private _Size As Integer = 0

    Public Sub New(ByVal Size As Integer)
        ReDim _Queue(Size - 1)
        _Size = Size
    End Sub
    Public ReadOnly Property IsFull() As Boolean
        Get
            Dim RetVal As Boolean = False
            If _Count = _Size Then
                RetVal = True
            End If
            Return RetVal
        End Get
    End Property

    Public ReadOnly Property IsEmpty() As Boolean
        Get
            Dim RetVal As Boolean = False
            If _Count = 0 Then
                RetVal = True
            End If
            Return RetVal
        End Get
    End Property

    Public Function Push(ByVal Obj As T) As Boolean
        Dim RetVal As Boolean = False
        SyncLock _Queue
            If IsFull Then
                Pop()
            End If
            If Not IsFull Then
                _Queue(_Tail) = Obj
                _Tail = NextPosition(_Tail)
                _Count += 1
                RetVal = True
            End If
        End SyncLock
        Return RetVal
    End Function
    Public Function Pop() As T
        Dim Obj As T = Nothing
        SyncLock _Queue
            If Not IsEmpty Then
                Obj = _Queue(_Head)
                _Queue(_Head) = Nothing
                _Head = NextPosition(_Head)
                _Count -= 1
            End If
        End SyncLock
        Return Obj
    End Function

    Private Function NextPosition(ByVal Pos As Integer) As Integer
        Pos += 1
        If Pos >= _Size Then
            Pos = 0
        End If
        Return Pos
    End Function

    Public Sub Clear()
        _Head = 0
        _Tail = 0
        _Count = 0
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _Count
        End Get
    End Property

    Public ReadOnly Property Size() As Integer
        Get
            Return _Size
        End Get
    End Property
End Class
