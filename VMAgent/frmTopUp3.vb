Imports System.Reflection

Public Class frmTopUp3

    Private Sub btnMainMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMainMenu.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

End Class