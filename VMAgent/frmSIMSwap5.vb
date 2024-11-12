Imports System.Reflection

Public Class frmSIMSwap5

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public EmailAddress As String = ""
    Dim PINCode As String = ""

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap5))
        ExceptionLogger.LogInfo("frmSIMSwap5_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap5
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap5_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap5_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap5_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        txtEmailAddress.Text = EmailAddress

    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "0"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "1"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "2"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "3"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "4"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "5"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "6"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "7"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "8"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtPINCode.Text.Length < 6 Then
            txtPINCode.Text &= "X"
            PINCode &= "9"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        lblErrorDescription.Text = ""

        If txtPINCode.Text.Length = 6 Then

            Globals.ShowPleaseWait(Me)

            If APIs.VerifyEmailOTP(MobileNumber.Substring(1), PINCode, frmSIMSwap.SessionId) = True Then

                Dim Amount As String = APIs.GetSimSwapPrice(MobileNumber.Substring(1), frmSIMSwap.SessionId)

                Globals.HidePleaseWait(Me)

                If Amount <> "" Then

                    Dim obj As New frmSIMSwap8
                    obj.MobileNumber = MobileNumber
                    obj.IDNumber = IDNumber
                    obj.Amount = Amount
                    obj.Owner = Me.Owner
                    obj.ShowDialog()
                    obj.Close()
                End If

            Else

                lblErrorDescription.Text = "الرمز السري المدخل غير صحيح"

                Globals.HidePleaseWait(Me)

            End If

        Else

            If txtPINCode.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال الرمز السري"
            ElseIf txtPINCode.Text.Length < 6 Then
                lblErrorDescription.Text = "الرمز السري المدخل غير مكتمل"
            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub



End Class