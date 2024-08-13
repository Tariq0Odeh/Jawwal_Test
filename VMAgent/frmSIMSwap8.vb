Imports System.Reflection

Public Class frmSIMSwap8

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public Amount As String = ""

    Private Sub frmSIMSwap8_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub btnNormalSIM_Click(sender As Object, e As EventArgs) Handles btnNormalSIM.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap10
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Amount = Amount
        obj.IsESIM = False
        obj.EmailAddress = ""
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnESIM_Click(sender As Object, e As EventArgs) Handles btnESIM.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap9
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Amount = Amount
        obj.IsESIM = True
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

End Class