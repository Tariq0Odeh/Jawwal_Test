Public Class frmDigitalGoods1

    Public MobileNumber As String = ""
    Dim PINCode As String = ""

    Private Sub frmDigitalGoods1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmDigitalGoods1 -> frmDigitalGoods1_Load ")
        txtMobileNumber.Text = MobileNumber

    End Sub

    Private Sub btn0_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn0_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "0"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn1_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "1"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn2_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "2"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods -> btn3_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "3"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn4_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "4"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn5_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "5"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles btn6.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn6_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "6"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles btn7.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn7_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "7"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles btn8.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn8_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "8"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_MouseDown(sender As Object, e As MouseEventArgs) Handles btn9.MouseDown
        'ExceptionLogger.LogInfo("frmDigitalGoods1 -> btn9_MouseDown ")
        If txtPINCode.Text.Length < 4 Then
            txtPINCode.Text &= "X"
            PINCode &= "9"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods1 -> btnClear_MouseDown ")
        If txtPINCode.Text <> "" Then
            txtPINCode.Text = txtPINCode.Text.Substring(0, txtPINCode.Text.Length - 1)
            PINCode = PINCode.Substring(0, PINCode.Length - 1)
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If txtPINCode.Text <> "" Then
            txtPINCode.BackColor = Color.White
        Else
            txtPINCode.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods1 -> btnOK_MouseDown ")
        lblErrorDescription.Text = ""

        If txtPINCode.Text.Length = 4 Then

            Globals.ShowPleaseWait(Me)

            If APIs.VerifyOTP(MobileNumber.Substring(1), "digitalgoods", PINCode) = True Then

                Dim BrandsDetails As String = APIs.GetBrands(MobileNumber.Substring(1))

                Globals.HidePleaseWait(Me)

                Dim obj As New frmDigitalGoods2
                obj.MobileNumber = MobileNumber
                obj.BrandsDetails = BrandsDetails
                obj.Owner = Me.Owner
                obj.ShowDialog()

            Else

                lblErrorDescription.Text = "الرقم السري المدخل غير صحيح"

                Globals.HidePleaseWait(Me)

            End If

        Else

            If txtPINCode.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال الرقم السري"
            ElseIf txtPINCode.Text.Length < 4 Then
                lblErrorDescription.Text = "الرقم السري المدخل غير مكتمل"
            End If

        End If

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods1 -> btnBack_MouseDown ")
        Me.Close()
    End Sub

#Region "PleaseWait"


#End Region

End Class