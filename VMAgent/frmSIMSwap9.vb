Imports System.Reflection

Public Class frmSIMSwap9

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public Amount As String = ""
    Public IsESIM As Boolean = False

    Private Sub frmSIMSwap9_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        kbKeyboard.txtBox = txtEmailAddress

        AddHandler kbKeyboard.EnterButtonClicked, AddressOf ExecuteOK

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ExecuteOK()

    End Sub

    Private Sub ExecuteOK()

        lblErrorDescription.Text = ""

        If ValidationRules.VR001(txtEmailAddress.Text) = True Then

            Dim obj As New frmSIMSwap10
            obj.MobileNumber = MobileNumber
            obj.IDNumber = IDNumber
            obj.Amount = Amount
            obj.IsESIM = IsESIM
            obj.EmailAddress = txtEmailAddress.Text
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()
        Else

            If txtEmailAddress.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال البريد الالكتروني"
            Else
                lblErrorDescription.Text = "البريد الالكتروني المدخل غير صحيح"
            End If

        End If

    End Sub

    Private Sub btnBack1_Click(sender As Object, e As EventArgs) Handles btnBack1.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

End Class