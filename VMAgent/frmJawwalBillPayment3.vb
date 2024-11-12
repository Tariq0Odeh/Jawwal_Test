Public Class frmJawwalBillPayment3

    Public IsDone As Boolean = False
    Public Amount As String = ""

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJawwalBillPayment3))
        ExceptionLogger.LogInfo("frmJawwalBillPayment3_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmJawwalBillPayment3
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub
    Private Sub frmJawwalBillPayment3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmJawwalBillPayment3_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmJawwalBillPayment3_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> frmJawwalBillPayment3_Load")

    End Sub

    Private Sub btn0_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn0_MouseDown")
        If txtAmount.Text <> "" And txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "0"
        End If

    End Sub

    Private Sub btn1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn1.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn1_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "1"
        End If

    End Sub

    Private Sub btn2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn2.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn2_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "2"
        End If

    End Sub

    Private Sub btn3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn3_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "3"
        End If

    End Sub

    Private Sub btn4_MouseDown(sender As Object, e As MouseEventArgs) Handles btn4.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn4_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "4"
        End If

    End Sub

    Private Sub btn5_MouseDown(sender As Object, e As MouseEventArgs) Handles btn5.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn5_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "5"
        End If

    End Sub

    Private Sub btn6_MouseDown(sender As Object, e As MouseEventArgs) Handles btn6.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn6_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "6"
        End If

    End Sub

    Private Sub btn7_MouseDown(sender As Object, e As MouseEventArgs) Handles btn7.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn7_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "7"
        End If

    End Sub

    Private Sub btn8_MouseDown(sender As Object, e As MouseEventArgs) Handles btn8.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn8_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "8"
        End If

    End Sub

    Private Sub btn9_MouseDown(sender As Object, e As MouseEventArgs) Handles btn9.MouseDown
        'ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btn9_MouseDown")
        If txtAmount.Text.Length < Amount.Length Then
            txtAmount.Text &= "9"
        End If

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btnClear_MouseDown")
        If txtAmount.Text <> "" Then
            txtAmount.Text = txtAmount.Text.Substring(0, txtAmount.Text.Length - 1)
        End If

    End Sub

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btnOK_MouseDown txtAmount.Text= " & txtAmount.Text)
        If txtAmount.Text.EndsWith(".") Then
            txtAmount.Text = txtAmount.Text.Substring(0, txtAmount.Text.Length - 1)
        End If

        lblErrorDescription.Text = ""

        If Amount <> "" And txtAmount.Text <> "" Then
            If Val(txtAmount.Text) <= Val(Amount) Then
                IsDone = True
                Me.Close()
            End If
        Else

            If txtAmount.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال قيمة الدفعة"
            End If

        End If

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment3 -> btnBack_MouseDown ")
        Me.Close()
    End Sub

End Class