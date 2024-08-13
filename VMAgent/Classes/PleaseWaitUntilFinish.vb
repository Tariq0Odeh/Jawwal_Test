Public Class PleaseWaitUntilFinish
    Implements IDisposable

    Dim t As Threading.Thread = Nothing
    Dim b As frmPleaseWait = Nothing

    Public Sub New()
        t = New Threading.Thread(AddressOf _ShowBusy)
        t.SetApartmentState(Threading.ApartmentState.STA)
        t.Priority = Threading.ThreadPriority.Highest
        t.Name = "PleaseWaitThread"
    End Sub

    Private showLock As New Object
    Public Sub Show()
        SyncLock showLock
            t.Start()
        End SyncLock
    End Sub

    Private closeLock As New Object
    Public Sub Close()
        SyncLock closeLock
            If b Is Nothing Then Exit Sub
            b.Invoke(New MethodInvoker(AddressOf _Close))
            If t Is Nothing Then Exit Sub
            t.Join()
        End SyncLock
    End Sub

    Private Sub _Close()
        If b Is Nothing Then Exit Sub
        b.Hide()
        b.Close()
        b = Nothing
    End Sub

    Private Sub _ShowBusy()
        Try
            If b Is Nothing Then
                b = New frmPleaseWait
            End If
            b.ShowDialog()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
            Threading.Thread.Sleep(1000)
            Try
                b = New frmPleaseWait
                b.ShowDialog()
            Catch ex2 As Exception
                Threading.Thread.Sleep(1000)

            End Try
        End Try

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: eliminare stato gestito (oggetti gestiti).
                Close()
            End If

            ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del seguente Finalize().
            ' TODO: impostare campi di grandi dimensioni su null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: eseguire l'override di Finalize() solo se Dispose(ByVal disposing As Boolean) dispone del codice per liberare risorse non gestite.
    'Protected Overrides Sub Finalize()
    '    ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
