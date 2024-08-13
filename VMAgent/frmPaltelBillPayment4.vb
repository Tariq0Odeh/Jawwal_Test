Imports System.Reflection

Public Class frmPaltelBillPayment4

    Private Sub btnMainMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMainMenu.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

End Class