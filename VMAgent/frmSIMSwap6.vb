Imports System.Reflection

Public Class frmSIMSwap6

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Dim SerialNumber As String = ""

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap6))
        ExceptionLogger.LogInfo("frmSIMSwap6_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap6
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap6_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap6_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap6_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "0"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "1"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "2"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "3"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "4"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "5"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "6"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "7"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "8"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text.Length < 4 Then
            txtSerialNumber.Text &= "X"
            SerialNumber &= "9"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If txtSerialNumber.Text <> "" Then
            txtSerialNumber.Text = txtSerialNumber.Text.Substring(0, txtSerialNumber.Text.Length - 1)
            SerialNumber = SerialNumber.Substring(0, SerialNumber.Length - 1)
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If txtSerialNumber.Text <> "" Then
            txtSerialNumber.BackColor = Color.White
        Else
            txtSerialNumber.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        lblErrorDescription.Text = ""

        If txtSerialNumber.Text.Length = 4 Then

            Globals.ShowPleaseWait(Me)

            If APIs.VerifySerialNumber(MobileNumber.Substring(1), SerialNumber, frmSIMSwap.SessionId) = True Then

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

                lblErrorDescription.Text = "الرجاء التأكد من الرقم التسلسلي المدخل"

                Globals.HidePleaseWait(Me)

            End If

        Else

            If txtSerialNumber.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال الرقم التسلسلي"
            ElseIf txtSerialNumber.Text.Length < 6 Then
                lblErrorDescription.Text = "الرقم التسلسلي المدخل غير مكتمل"
            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub



End Class