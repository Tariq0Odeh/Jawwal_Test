Imports System.Reflection

Public Class frmSIMSwap4

    Public MobileNumber As String = ""
    Public IDNumber As String = ""

    Private Sub frmSIMSwap4_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            Globals.ShowPleaseWait(Me)

            If APIs.SendEmailOTP(MobileNumber.Substring(1), txtEmailAddress.Text, frmSIMSwap.SessionId) = True Then

                Globals.HidePleaseWait(Me)

                Dim obj As New frmSIMSwap5
                obj.MobileNumber = MobileNumber
                obj.IDNumber = IDNumber
                obj.EmailAddress = txtEmailAddress.Text
                obj.Owner = Me.Owner
                obj.ShowDialog()
                obj.Close()
            Else

                lblErrorDescription.Text = "الرجاء التأكد من البريد الالكتروني المدخل"

                Globals.HidePleaseWait(Me)

            End If

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