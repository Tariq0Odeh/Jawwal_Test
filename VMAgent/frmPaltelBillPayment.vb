Imports System.Reflection

Public Class frmPaltelBillPayment

    Dim ActiveInputBox As String = "PHONE"                 'PHONE/IDNUMBER
    Public Shared SessionId As String = ""
    Private Sub frmPaltelBillPayment_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        SessionId = APIs.CreateSession(APIs.ServiceNames.billsPayment.ToString())
        ExceptionLogger.LogInfo("SessionId: " & SessionId)
    End Sub

    Private Sub txtPhoneNumber_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPhoneNumber.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "PHONE"

    End Sub

    Private Sub txtIDNumber_MouseDown(sender As Object, e As MouseEventArgs) Handles txtIDNumber.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        ActiveInputBox = "IDNUMBER"

    End Sub

    Private Sub btn0_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "0"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "0"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "1"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "1"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "2"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "2"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "3"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "3"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "4"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "4"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "5"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "5"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles btn6.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "6"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "6"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles btn7.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "7"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "7"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles btn8.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "8"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "8"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_MouseDown(sender As Object, e As MouseEventArgs) Handles btn9.MouseDown
        'ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text.Length < 10 Then
                txtPhoneNumber.Text &= "9"
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text.Length < 9 Then
                txtIDNumber.Text &= "9"
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If ActiveInputBox = "PHONE" Then

            If txtPhoneNumber.Text.Length = 3 Then
                txtPhoneNumber.Text = txtPhoneNumber.Text.Substring(0, txtPhoneNumber.Text.Length - 2)
            ElseIf txtPhoneNumber.Text <> "" Then
                txtPhoneNumber.Text = txtPhoneNumber.Text.Substring(0, txtPhoneNumber.Text.Length - 1)
            End If
        ElseIf ActiveInputBox = "IDNUMBER" Then
            If txtIDNumber.Text <> "" Then
                txtIDNumber.Text = txtIDNumber.Text.Substring(0, txtIDNumber.Text.Length - 1)
            End If
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If ActiveInputBox = "PHONE" Then
            If txtPhoneNumber.Text <> "" Then
                txtPhoneNumber.BackColor = Color.White
            Else
                txtPhoneNumber.BackColor = Color.Transparent
            End If
            If txtPhoneNumber.Text.Length = 2 Then
                txtPhoneNumber.Text &= "-"
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

            If txtPhoneNumber.Text.Length = 10 And txtIDNumber.Text.Length = 9 And ValidationRules.VR030(txtIDNumber.Text) = True Then

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto1 = CC.CaptureAsBase64String()

                Try


                    If APIs.VerifyFixedLine(txtPhoneNumber.Text.Replace("-", ""), txtIDNumber.Text, frmPaltelBillPayment.SessionId) = True Then

                        Dim InvoicesDetails As String = APIs.GetInvoices(txtPhoneNumber.Text.Replace("-", ""), "paltel", frmPaltelBillPayment.SessionId)

                        Globals.HidePleaseWait(Me)

                        Dim obj As New frmPaltelBillPayment1
                        obj.PhoneNumber = txtPhoneNumber.Text.Replace("-", "")
                        obj.IDNumber = txtIDNumber.Text
                        obj.InvoicesDetails = InvoicesDetails
                        obj.Owner = Me
                        obj.ShowDialog()

                    Else

                        lblErrorDescription.Text = "الرجاء التأكد من رقم الهاتف الأرضي المدخل ومن رقم الهوية"



                    End If
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try
                Globals.HidePleaseWait(Me)
            Else

                If txtPhoneNumber.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال رقم الهاتف الأرضي"
                ElseIf txtPhoneNumber.Text.Length < 10 Then
                    lblErrorDescription.Text = "رقم الهاتف الأرضي المدخل غير مكتمل"
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

    Private btnBacklLock As New Object
    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        SyncLock btnBacklLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            Me.Close()
        End SyncLock
    End Sub



End Class