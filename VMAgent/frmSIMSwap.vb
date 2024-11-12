Imports System.Reflection

Public Class frmSIMSwap

    Dim ActiveInputBox As String = "MOBILE"                 'MOBILE/IDNUMBER
    Public Shared SessionId As String = ""

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap))
        ExceptionLogger.LogInfo("frmSIMSwap_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        SessionId = APIs.CreateSession(APIs.ServiceNames.simswap.ToString())
        ExceptionLogger.LogInfo("SessionId: " & SessionId)
    End Sub

    Private Sub txtMobileNumber_Click(sender As Object, e As EventArgs) Handles txtMobileNumber.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "MOBILE"

    End Sub

    Private Sub txtIDNumber_Click(sender As Object, e As EventArgs) Handles txtIDNumber.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "IDNUMBER"

    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "" Or txtMobileNumber.Text.StartsWith("05") = True) Then
                txtMobileNumber.Text &= "0"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "0"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "1"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "1"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "2"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "2"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "3"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "3"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "4"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "4"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And (txtMobileNumber.Text = "0" Or txtMobileNumber.Text.StartsWith("05") = True) Then
                txtMobileNumber.Text &= "5"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "5"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "6"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "6"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "7"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "7"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "8"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "8"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text.Length < 10 And txtMobileNumber.Text.StartsWith("05") = True Then
                txtMobileNumber.Text &= "9"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "9"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "MOBILE" Then
            If txtMobileNumber.Text <> "" Then
                txtMobileNumber.Text = txtMobileNumber.Text.Substring(0, txtMobileNumber.Text.Length - 1)
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text <> "" Then
                txtIDNumber.Text = txtIDNumber.Text.Substring(0, txtIDNumber.Text.Length - 1)
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
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text <> "" Then
                txtIDNumber.BackColor = Color.White
            Else
                txtIDNumber.BackColor = Color.Transparent
            End If
        End If

    End Sub

    Private btnOKCardLock As New Object
    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        SyncLock btnOKCardLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            lblErrorDescription.Text = ""

            If txtMobileNumber.Text.Length = 10 And txtIDNumber.Text.Length = 9 And ValidationRules.VR030(txtIDNumber.Text) = True Then

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto1 = CC.CaptureAsBase64String()

                If APIs.VerifyIdNumber(txtMobileNumber.Text.Substring(1), txtIDNumber.Text, frmSIMSwap.SessionId) = True Then

                    Globals.HidePleaseWait(Me)

                    Dim obj As New frmSIMSwap1
                    obj.MobileNumber = txtMobileNumber.Text
                    obj.IDNumber = txtIDNumber.Text
                    obj.Owner = Me
                    obj.ShowDialog()
                    obj.Close()
                Else

                    lblErrorDescription.Text = "الرجاء التأكد من رقم الجوال المدخل ومن رقم الهوية"

                    Globals.HidePleaseWait(Me)

                End If

            Else

                If txtMobileNumber.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال رقم الجوال"
                ElseIf txtMobileNumber.Text.Length < 10 Then
                    lblErrorDescription.Text = "رقم الجوال المدخل غير مكتمل"
                ElseIf txtIDNumber.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال رقم الهوية"
                ElseIf txtIDNumber.Text.Length < 9 Then
                    lblErrorDescription.Text = "رقم الهوية المدخل غير مكتمل"
                ElseIf ValidationRules.VR030(txtIDNumber.Text) = False Then
                    lblErrorDescription.Text = "رقم الهوية المدخل غير صحيح"
                End If

            End If
        End SyncLock
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub



End Class