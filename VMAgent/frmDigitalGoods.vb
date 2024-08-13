Public Class frmDigitalGoods

    Private Sub frmDigitalGoods_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmDigitalGoods -> frmDigitalGoods_Load ")

    End Sub

    Private Sub btn0_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn0_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "" Or txtMobileNumber.Text.StartsWith("05") = True) Then
            txtMobileNumber.Text &= "0"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        ' ExceptionLogger.LogInfo("frmDigitalGoods -> btn1_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "1"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn1_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "2"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn3_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "3"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn4_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "4"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn5_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "0" Or txtMobileNumber.Text.StartsWith("05") = True) Then
            txtMobileNumber.Text &= "5"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles btn6.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn6_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "6"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles btn7.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn7_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "7"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles btn8.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn8_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "8"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_MouseDown(sender As Object, e As MouseEventArgs) Handles btn9.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn9_MouseDown ")
        If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
            txtMobileNumber.Text &= "9"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods -> btnClear_MouseDown ")
        If txtMobileNumber.Text <> "" Then
            txtMobileNumber.Text = txtMobileNumber.Text.Substring(0, txtMobileNumber.Text.Length - 1)
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If txtMobileNumber.Text <> "" Then
            txtMobileNumber.BackColor = Color.White
        Else
            txtMobileNumber.BackColor = Color.Transparent
        End If

    End Sub

    Private btnOKCardLock As New Object
    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        SyncLock btnOKCardLock
            ExceptionLogger.LogInfo("frmDigitalGoods -> btnOK_MouseDown ")
            lblErrorDescription.Text = ""

            If txtMobileNumber.Text.Length = 10 Then

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto1 = CC.CaptureAsBase64String()

                If APIs.SendOTP(txtMobileNumber.Text.Substring(1), "digitalgoods") = True Then

                    Globals.HidePleaseWait(Me)

                    Dim obj As New frmDigitalGoods1
                    obj.MobileNumber = txtMobileNumber.Text
                    obj.Owner = Me
                    obj.ShowDialog()

                Else

                    lblErrorDescription.Text = "الرجاء التأكد من رقم الجوال المدخل"

                    Globals.HidePleaseWait(Me)

                End If

            Else

                If txtMobileNumber.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال رقم الجوال"
                ElseIf txtMobileNumber.Text.Length < 10 Then
                    lblErrorDescription.Text = "رقم الجوال المدخل غير مكتمل"
                End If

            End If
        End SyncLock
    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods -> btnBack_MouseDown ")
        Me.Close()
    End Sub



End Class