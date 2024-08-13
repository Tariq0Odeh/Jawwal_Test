Imports System.Reflection

Public Class frmSIMSwap12

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

End Class