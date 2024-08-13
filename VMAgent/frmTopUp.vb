Imports System.Reflection

Public Class frmTopUp

    Dim ActiveInputBox As String = "MOBILE"                 'MOBILE/AMOUNT

    Private Sub frmTopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub txtMobileNumber_MouseDown(sender As Object, e As MouseEventArgs) Handles txtMobileNumber.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "MOBILE"

    End Sub

    Private Sub txtAmount_MouseDown(sender As Object, e As MouseEventArgs) Handles txtAmount.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "AMOUNT"

    End Sub

    Private Sub btn0_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "" Or txtMobileNumber.Text.StartsWith("05") = True) Then
                txtMobileNumber.Text &= "0"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 And txtAmount.Text <> "" Then
                txtAmount.Text &= "0"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "1"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "1"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "2"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "2"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "3"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "3"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "4"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "4"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "0" Or txtMobileNumber.Text.StartsWith("05") = True) Then
                txtMobileNumber.Text &= "5"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "5"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles btn6.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "6"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "6"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles btn7.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "7"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "7"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles btn8.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "8"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "8"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_MouseDown(sender As Object, e As MouseEventArgs) Handles btn9.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "9"
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text.Length < 5 Then
                txtAmount.Text &= "9"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text <> "" Then
                txtMobileNumber.Text = txtMobileNumber.Text.Substring(0, txtMobileNumber.Text.Length - 1)
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text <> "" Then
                txtAmount.Text = txtAmount.Text.Substring(0, txtAmount.Text.Length - 1)
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text <> "" Then
                txtMobileNumber.BackColor = Color.White
            Else
                txtMobileNumber.BackColor = Color.Transparent
            End If
        ElseIf ActiveInputBox = "AMOUNT" Then
            If txtAmount.Text <> "" Then
                txtAmount.BackColor = Color.White
            Else
                txtAmount.BackColor = Color.Transparent
            End If
        End If

    End Sub

    Private btnOKCardLock As New Object
    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        SyncLock btnOKCardLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            lblErrorDescription.Text = ""

            If txtMobileNumber.Text.Length = 10 And txtAmount.Text <> "" Then

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto1 = CC.CaptureAsBase64String()

                If APIs.CheckRefill(txtMobileNumber.Text.Substring(1), txtAmount.Text) = True Then

                    Globals.HidePleaseWait(Me)

                    Dim obj As New frmTopUp1
                    obj.MobileNumber = txtMobileNumber.Text
                    obj.Amount = txtAmount.Text
                    obj.Owner = Me
                    obj.ShowDialog()

                Else

                    lblErrorDescription.Text = "الرجاء التأكد من رقم الجوال المدخل ومن قيمة الشحن"

                    Globals.HidePleaseWait(Me)

                End If

            Else

                If txtMobileNumber.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال رقم الجوال"
                ElseIf txtMobileNumber.Text.Length < 10 Then
                    lblErrorDescription.Text = "رقم الجوال المدخل غير مكتمل"
                ElseIf txtAmount.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال قيمة الشحن"
                End If

            End If
        End SyncLock
    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

End Class