Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class frmSIMSwap7

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public QuestionsList As String = ""

    Private Sub frmSIMSwap7_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        kbKeyboard.txtBox = txtPUK
        kbKeyboard.SetKeyboardMode(True)

        AddHandler kbKeyboard.EnterButtonClicked, AddressOf ExecuteOK

        Dim ALPackageDetails1 As New List(Of PackageDetails)
        Dim ALPackageDetails2 As New List(Of PackageDetails)

        Dim obj1 As New PackageDetails
        obj1.PkgName = "اختر طبيعة الرقم"
        obj1.PkgType = ""
        ALPackageDetails1.Add(obj1)

        Dim obj2 As New PackageDetails
        obj2.PkgName = "اختر الباكج"
        obj2.PkgOfferId = ""
        ALPackageDetails2.Add(obj2)

        Dim jsonObj As JObject = JObject.Parse(QuestionsList)
        If jsonObj("code") = "0" Then

            Dim ALQuestions As JArray = jsonObj("data")
            For I As Integer = 0 To ALQuestions.Count - 1

                Dim QuestionObj As New JObject
                QuestionObj = ALQuestions(I)

                If QuestionObj("id").ToString() = "3" Then
                    If QuestionObj("answers").Type = JTokenType.Array Then
                        Dim ALAnswers As JArray = QuestionObj("answers")
                        For A As Integer = 0 To ALAnswers.Count - 1
                            Dim AnswerObj As New JObject
                            AnswerObj = ALAnswers(A)
                            Dim PkgType As String = AnswerObj("type").ToString()

                            obj1 = New PackageDetails
                            obj1.PkgName = PkgType
                            obj1.PkgType = PkgType
                            ALPackageDetails1.Add(obj1)

                        Next
                    End If
                End If
                If QuestionObj("id").ToString() = "4" Then
                    If QuestionObj("answers").Type = JTokenType.Array Then
                        Dim ALAnswers As JArray = QuestionObj("answers")
                        For A As Integer = 0 To ALAnswers.Count - 1
                            Dim AnswerObj As New JObject
                            AnswerObj = ALAnswers(A)
                            Dim Pkgname As String = AnswerObj("pkgname").ToString()
                            Dim Pkgofferid As String = AnswerObj("pkgofferid").ToString()
                            Dim PkgType As String = AnswerObj("type").ToString()

                            obj2 = New PackageDetails
                            obj2.PkgName = Pkgname
                            obj2.PkgOfferId = Pkgofferid
                            obj2.PkgType = PkgType
                            ALPackageDetails2.Add(obj2)

                        Next
                    End If
                End If

            Next

        End If

        cbPkgType.DataSource = ALPackageDetails1
        cbPkgType.DisplayMember = "PkgName"
        cbPkgType.ValueMember = "PkgType"
        cbPkgType.SelectedIndex = 0

        cbPkgName.DataSource = ALPackageDetails2
        cbPkgName.DisplayMember = "PkgName"
        cbPkgName.ValueMember = "PkgOfferId"
        cbPkgName.SelectedIndex = 0

    End Sub

    Private Sub txtPUK_Click(sender As Object, e As EventArgs) Handles txtPUK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        kbKeyboard.txtBox = txtPUK
    End Sub

    Private Sub txtLastInvoiceOrBalance_Click(sender As Object, e As EventArgs) Handles txtLastInvoiceOrBalance.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        kbKeyboard.txtBox = txtLastInvoiceOrBalance
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)

        ExecuteOK()

    End Sub

    Private Sub ExecuteOK()

        lblErrorDescription.Text = ""

        If (Not cbPkgType.SelectedItem Is Nothing AndAlso CType(cbPkgType.SelectedItem, PackageDetails).PkgType <> "") And (Not cbPkgName.SelectedItem Is Nothing AndAlso CType(cbPkgName.SelectedItem, PackageDetails).PkgOfferId <> "") And txtPUK.Text.Length > 0 And txtLastInvoiceOrBalance.Text.Length > 0 Then

            Globals.ShowPleaseWait(Me)

            If APIs.VerifyAnswers(MobileNumber.Substring(1), txtPUK.Text, txtLastInvoiceOrBalance.Text, CType(cbPkgType.SelectedItem, PackageDetails).PkgType, CType(cbPkgName.SelectedItem, PackageDetails).PkgOfferId) = True Then

                Dim Amount As String = APIs.GetSimSwapPrice(MobileNumber.Substring(1))

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

                lblErrorDescription.Text = "الرجاء التأكد من الإجابات المدخلة"

                Globals.HidePleaseWait(Me)

            End If

        Else

            lblErrorDescription.Text = "الرجاء الإجابة عن جميع الأسئلة"

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