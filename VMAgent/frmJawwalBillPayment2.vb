Imports Newtonsoft.Json.Linq

Public Class frmJawwalBillPayment2

    Public MobileNumber As String = ""
    Public InvoicesDetails As String = ""
    Public IgnoreAction As Boolean = False

    Private Sub frmJawwalBillPayment2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmJawwalBillPayment2 -> frmJawwalBillPayment2_Load")
        Dim TotalBills As Decimal = 0

        If InvoicesDetails.Contains("code") = True Then

            Dim jsonObj As JObject = JObject.Parse(InvoicesDetails)
            If jsonObj("code") = "0" Then
                Dim ALInvoices As JArray = jsonObj("data")
                For I As Integer = 0 To ALInvoices.Count - 1

                    Dim Invoice As New JObject
                    Invoice = ALInvoices(I)

                    Dim obj As New ctlJawwalBill
                    obj.Dock = DockStyle.Top
                    obj.objJawwalInvoice.invoiceNumber = Invoice("invoiceNumber").ToString()
                    obj.objJawwalInvoice.amount = Invoice("amount").ToString()
                    obj.objJawwalInvoice.cycle = Invoice("cycle").ToString()
                    obj.objJawwalInvoice.msisdn = Invoice("msisdn").ToString()
                    obj.objJawwalInvoice.dueDate = Invoice("dueDate").ToString()
                    obj.objJawwalInvoice.currency = Invoice("currency").ToString()

                    obj.txtBillDate.Text = Invoice("cycle").ToString()
                    obj.txtBillDueDate.Text = Invoice("dueDate").ToString()
                    obj.txtAmount.Text = Invoice("amount").ToString()
                    obj.MyParent = Me
                    pnlBills.Controls.Add(obj)
                    obj.BringToFront()

                    AddHandler obj.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.MouseUp, AddressOf pnlBills_MouseUp

                    AddHandler obj.btnSelectUnSelect.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.btnSelectUnSelect.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.btnSelectUnSelect.MouseUp, AddressOf pnlBills_MouseUp

                    AddHandler obj.txtAmount.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.txtAmount.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.txtAmount.MouseUp, AddressOf pnlBills_MouseUp

                    AddHandler obj.txtAmountToPay.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.txtAmountToPay.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.txtAmountToPay.MouseUp, AddressOf pnlBills_MouseUp

                    AddHandler obj.txtBillDate.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.txtBillDate.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.txtBillDate.MouseUp, AddressOf pnlBills_MouseUp

                    AddHandler obj.txtBillDueDate.MouseDown, AddressOf pnlBills_MouseDown
                    AddHandler obj.txtBillDueDate.MouseMove, AddressOf pnlBills_MouseMove
                    AddHandler obj.txtBillDueDate.MouseUp, AddressOf pnlBills_MouseUp

                    TotalBills += Val(Invoice("amount").ToString())

                Next
            End If

        End If

        If pnlBills.VerticalScroll.Visible = True Then
            pnlBills.Width += SystemInformation.VerticalScrollBarWidth
        End If

        txtTotalBills.Text = TotalBills.ToString

    End Sub

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment2 -> btnOK_MouseDown")
        Dim HasBills As Boolean = False

        Dim TotalAmountToPay As Decimal = 0
        Dim ALInvoicesToPay As New List(Of JawwalInvoice)

        For I As Integer = 0 To pnlBills.Controls.Count - 1
            If pnlBills.Controls(I).GetType = GetType(ctlJawwalBill) Then
                HasBills = True
                If CType(pnlBills.Controls(I), ctlJawwalBill).IsSelected = True Then
                    TotalAmountToPay += Val(CType(pnlBills.Controls(I), ctlJawwalBill).txtAmountToPay.Text)
                    ALInvoicesToPay.Add(CType(pnlBills.Controls(I), ctlJawwalBill).objJawwalInvoice)
                End If
            End If
        Next

        lblErrorDescription.Text = ""

        If HasBills = True And TotalAmountToPay > 0 Then

            Dim obj As New frmJawwalBillPayment4
            obj.MobileNumber = MobileNumber
            obj.Amount = TotalAmountToPay.ToString()
            obj.ALInvoicesToPay = ALInvoicesToPay
            obj.Owner = Me.Owner
            obj.ShowDialog()

        Else

            If HasBills = True Then
                lblErrorDescription.Text = "الرجاء تحديد الفواتير التي ترغب بتسديدها"
            Else
                lblErrorDescription.Text = "لا يوجد فواتير مستحقة"
            End If

        End If

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment2 -> btnBack_MouseDown")
        Me.Close()
    End Sub

#Region "pnlBills"

    Dim pnlBillsmouseDownPoint As Point
    Dim pnlBillsIsMouseDown As Boolean = False

    Private Sub pnlBills_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlBills.MouseDown
        pnlBillsIsMouseDown = True
        pnlBillsmouseDownPoint = Cursor.Position
        IgnoreAction = False
    End Sub

    Private Sub pnlBills_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlBills.MouseMove
        If pnlBillsIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlBillsmouseDownPoint.X, Cursor.Position.Y - pnlBillsmouseDownPoint.Y)
            If ((pnlBillsmouseDownPoint.X <> Cursor.Position.X) Or (pnlBillsmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlBills.AutoScrollPosition
                pnlBills.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlBillsmouseDownPoint = Cursor.Position

                IgnoreAction = True

            End If

        End If
    End Sub

    Private Sub pnlBills_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlBills.MouseUp
        pnlBillsIsMouseDown = False
    End Sub

#End Region

End Class