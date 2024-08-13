Imports System.Reflection

Public Class frmTimeExtension

    Private Sub frmTimeExtension_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        TimeOutCounter = 0
        objTimeExtension.Close()
        objTimeExtension.Dispose()
        objTimeExtension = Nothing

    End Sub

End Class
