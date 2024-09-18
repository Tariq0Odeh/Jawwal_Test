Imports System.ComponentModel
Imports System.Reflection

Public Class frmPaltelBillPayment3

    Public PhoneNumber As String = ""
    Public IDNumber As String = ""
    Public Amount As String = ""
    Public ALInvoicesToPay As New List(Of PaltelInvoice)
    Private isConfirmedClicked As Boolean = False
    'Public objCoinCashRecycler As VinderSDK.CoinCashRecycler

    Private Sub frmPaltelBillPayment3_Load(sender As Object, e As EventArgs) Handles Me.Load

        If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()
            'objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)
            AddHandler objCoinCashRecycler.OnCoinCashDeposit, AddressOf OnCoinCash
            objCoinCashRecycler.StartAcceptingCoinCash(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False))
        End If

        txtTotalAmount.Text = Amount

    End Sub

    Private Sub frmPaltelBillPayment3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
            RemoveHandler objCoinCashRecycler.OnCoinCashDeposit, AddressOf OnCoinCash
        End If

    End Sub

    Private Sub OnCoinCash(ByVal Amount As Decimal)
        Try
            Invoke(New OnCoinCashDepositDelegate(AddressOf OnCoinCashDeposit), Amount)
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub

    Private Delegate Sub OnCoinCashDepositDelegate(ByVal Amount As Decimal)
    Private Sub OnCoinCashDeposit(ByVal Amount As Decimal)

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name & " Amount = " & Amount)
            txtAmount.Text = Val(txtAmount.Text) + Amount
            TimeOutCounter = 0



    End Sub

    Private btnOKCardLock As New Object
    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        SyncLock btnOKCardLock

            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            If Val(txtAmount.Text) >= Val(Amount) Then
                btnOK.Enabled = False
                isConfirmedClicked = True
                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    Dim TotalInputAmount As Decimal = objCoinCashRecycler.StopAcceptingMoney()
                    txtAmount.Text = TotalInputAmount.ToString
                End If

                Dim payments As String = ""

                For I As Integer = 0 To ALInvoicesToPay.Count - 1
                    payments &= ",{ ""invoice"": { ""invoiceNumber"": """ & ALInvoicesToPay(I).invoiceNumber & """, ""amount"": """ & ALInvoicesToPay(I).amount & """, ""cycle"": """ & ALInvoicesToPay(I).cycle & """, ""msisdn"": """ & ALInvoicesToPay(I).msisdn & """, ""dueDate"": """ & ALInvoicesToPay(I).dueDate & """, ""currency"": """ & ALInvoicesToPay(I).currency & """ } }"
                Next

                If payments <> "" Then
                    payments = payments.Substring(1)
                End If
                CurrentTransaction.ServiceNumber = PhoneNumber
                CurrentTransaction.TransactionAmount = Val(Amount)
                CurrentTransaction.PaidAmount = Val(txtAmount.Text)
                CurrentTransaction.ReturnedAmount = Val(txtAmount.Text) - Val(Amount)
                Dim apiResponeValue = APIs.PayPaltelInvoices(PhoneNumber, payments, "", "", "Cash", frmPaltelBillPayment.SessionId)
                If apiResponeValue = APIs.APIReturnedValue.Success Then

                    ReturnCoinCash(Val(txtAmount.Text) - Val(Amount))

                    TrxnAmount = Val(Amount)
                    PaidAmount = Val(txtAmount.Text)
                    PrintSuccessReceipt()

                    Globals.HidePleaseWait(Me)

                    Dim obj As New frmPaltelBillPayment4
                    obj.Owner = Me.Owner
                    obj.ShowDialog()

                ElseIf apiResponeValue = APIs.APIReturnedValue.Failed Then

                    ReturnCoinCash(Val(txtAmount.Text))
                    TrxnAmount = Val(Amount)
                    PaidAmount = Val(txtAmount.Text)
                    PrintFailedReceipt("Failed")
                    btnOK.Enabled = True
                    txtAmount.Text = 0
                    isConfirmedClicked = False
                    Globals.HidePleaseWait(Me)
                    Me.Owner.Close()
                    Me.Owner.Dispose()

                Else


                    ReturnCoinCash(Val(txtAmount.Text) - Val(Amount))
                    TrxnAmount = Val(Amount)
                    PaidAmount = Val(txtAmount.Text)
                    PrintFailedReceipt("UnknownStatus")
                    Globals.HidePleaseWait(Me)
                    btnOK.Enabled = True
                    txtAmount.Text = 0
                    isConfirmedClicked = False
                    Me.Owner.Close()
                    Me.Owner.Dispose()

                End If
                btnOK.Enabled = True
                txtAmount.Text = 0
                isConfirmedClicked = False
            End If
        End SyncLock
    End Sub

    Private btnCancelLock As New Object
    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        SyncLock btnCancelLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            If isConfirmedClicked = False Then
                btnOK.Enabled = False

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    Dim TotalInputAmount As Decimal = objCoinCashRecycler.StopAcceptingMoney()
                    txtAmount.Text = TotalInputAmount.ToString
                End If

                If Val(txtAmount.Text) > 0 Then

                    ReturnCoinCash(Val(txtAmount.Text))

                    TrxnAmount = Val(Amount)
                    PaidAmount = Val(txtAmount.Text)
                    PrintCancelledReceipt()

                End If

                Globals.HidePleaseWait(Me)

                Me.Owner.Close()
                Me.Owner.Dispose()
                btnOK.Enabled = True
            End If
        End SyncLock
    End Sub

    Private btnBacklLock As New Object
    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        SyncLock btnBacklLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            If isConfirmedClicked = False Then
                btnOK.Enabled = False

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    Dim TotalInputAmount As Decimal = objCoinCashRecycler.StopAcceptingMoney()
                    txtAmount.Text = TotalInputAmount.ToString
                End If

                If Val(txtAmount.Text) > 0 Then

                    ReturnCoinCash(Val(txtAmount.Text))

                    TrxnAmount = Val(Amount)
                    PaidAmount = Val(txtAmount.Text)
                    PrintCancelledReceipt()

                End If

                Globals.HidePleaseWait(Me)

                Me.Close()
                btnOK.Enabled = True
            End If
        End SyncLock
    End Sub

#Region "Print Receipt"

    Dim PrintReceiptDetails As String = ""
    Dim TrxnStatus As String = ""
    Dim TrxnAmount As Decimal = 0
    Dim PaidAmount As Decimal = 0

    Private PrintSuccessReceiptLock As New Object
    Private Sub PrintSuccessReceipt()
        SyncLock PrintSuccessReceiptLock
            Try


                PrintReceiptDetails = APIs.GetReceiptDetails("PaltelBillPaymentSuccess")
                TrxnStatus = "Success"

                Dim objReceiptDocument As New Printing.PrintDocument
                Dim PrintController As New System.Drawing.Printing.StandardPrintController
                objReceiptDocument.PrintController = PrintController
                objReceiptDocument.DefaultPageSettings.Margins.Left = 0
                objReceiptDocument.DefaultPageSettings.Margins.Right = 0
                objReceiptDocument.DefaultPageSettings.Margins.Top = 0
                objReceiptDocument.DefaultPageSettings.Margins.Bottom = 0

                Dim PaperWidth As Integer = (80 * 0.0393701 * 100)
                Dim PaperHeight As Integer = (80 * 0.0393701 * 100)
                Dim ALReceiptDetails() As String = PrintReceiptDetails.Split(Chr(174))
                If ALReceiptDetails.Length > 0 Then
                    Dim ReceiptDetails As String = ALReceiptDetails(0)
                    If ReceiptDetails.Split(Chr(169)).Length = 9 Then
                        PaperWidth = Val(ReceiptDetails.Split(Chr(169))(0)) * 0.0393701 * 100
                        PaperHeight = Val(ReceiptDetails.Split(Chr(169))(1)) * 0.0393701 * 100
                    End If
                End If
                objReceiptDocument.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", PaperWidth, PaperHeight)

                AddHandler objReceiptDocument.PrintPage, AddressOf OnPrintReceiptDocument
                objReceiptDocument.Print()

                '------------------------------------------------------------------------------------------------------------

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto3 = CC.CaptureAsBase64String()

                CurrentTransaction.ServiceNumber = PhoneNumber
                CurrentTransaction.TransactionAmount = TrxnAmount
                CurrentTransaction.PaidAmount = PaidAmount
                CurrentTransaction.ReturnedAmount = ReturnedAmount
                CurrentTransaction.TransactionStatus = TrxnStatus
                CurrentTransaction.SaveTransactionDetails("Cash")
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub

    Private Sub PrintFailedReceipt(TrxnStatus As String)
        Try

            PrintReceiptDetails = APIs.GetReceiptDetails("PaltelBillPaymentFailed")
            Me.TrxnStatus = TrxnStatus

            Dim objReceiptDocument As New Printing.PrintDocument
            Dim PrintController As New System.Drawing.Printing.StandardPrintController
            objReceiptDocument.PrintController = PrintController
            objReceiptDocument.DefaultPageSettings.Margins.Left = 0
            objReceiptDocument.DefaultPageSettings.Margins.Right = 0
            objReceiptDocument.DefaultPageSettings.Margins.Top = 0
            objReceiptDocument.DefaultPageSettings.Margins.Bottom = 0

            Dim PaperWidth As Integer = (80 * 0.0393701 * 100)
            Dim PaperHeight As Integer = (80 * 0.0393701 * 100)
            Dim ALReceiptDetails() As String = PrintReceiptDetails.Split(Chr(174))
            If ALReceiptDetails.Length > 0 Then
                Dim ReceiptDetails As String = ALReceiptDetails(0)
                If ReceiptDetails.Split(Chr(169)).Length = 9 Then
                    PaperWidth = Val(ReceiptDetails.Split(Chr(169))(0)) * 0.0393701 * 100
                    PaperHeight = Val(ReceiptDetails.Split(Chr(169))(1)) * 0.0393701 * 100
                End If
            End If
            objReceiptDocument.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", PaperWidth, PaperHeight)

            AddHandler objReceiptDocument.PrintPage, AddressOf OnPrintReceiptDocument
            objReceiptDocument.Print()

            '------------------------------------------------------------------------------------------------------------

            Dim CC As New CameraCapture
            CurrentTransaction.CustomerPhoto3 = CC.CaptureAsBase64String()

            CurrentTransaction.ServiceNumber = PhoneNumber
            CurrentTransaction.TransactionAmount = TrxnAmount
            CurrentTransaction.PaidAmount = PaidAmount
            CurrentTransaction.ReturnedAmount = ReturnedAmount
            CurrentTransaction.TransactionStatus = TrxnStatus
            CurrentTransaction.SaveTransactionDetails("Cash")
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Private Sub PrintCancelledReceipt()

        Try
            PrintReceiptDetails = APIs.GetReceiptDetails("PaltelBillPaymentCancelled")
            TrxnStatus = "Cancelled"

            Dim objReceiptDocument As New Printing.PrintDocument
            Dim PrintController As New System.Drawing.Printing.StandardPrintController
            objReceiptDocument.PrintController = PrintController
            objReceiptDocument.DefaultPageSettings.Margins.Left = 0
            objReceiptDocument.DefaultPageSettings.Margins.Right = 0
            objReceiptDocument.DefaultPageSettings.Margins.Top = 0
            objReceiptDocument.DefaultPageSettings.Margins.Bottom = 0

            Dim PaperWidth As Integer = (80 * 0.0393701 * 100)
            Dim PaperHeight As Integer = (80 * 0.0393701 * 100)
            Dim ALReceiptDetails() As String = PrintReceiptDetails.Split(Chr(174))
            If ALReceiptDetails.Length > 0 Then
                Dim ReceiptDetails As String = ALReceiptDetails(0)
                If ReceiptDetails.Split(Chr(169)).Length = 9 Then
                    PaperWidth = Val(ReceiptDetails.Split(Chr(169))(0)) * 0.0393701 * 100
                    PaperHeight = Val(ReceiptDetails.Split(Chr(169))(1)) * 0.0393701 * 100
                End If
            End If
            objReceiptDocument.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", PaperWidth, PaperHeight)

            AddHandler objReceiptDocument.PrintPage, AddressOf OnPrintReceiptDocument
            objReceiptDocument.Print()

            '------------------------------------------------------------------------------------------------------------

            Dim CC As New CameraCapture
            CurrentTransaction.CustomerPhoto3 = CC.CaptureAsBase64String()

            CurrentTransaction.ServiceNumber = PhoneNumber
            CurrentTransaction.TransactionAmount = TrxnAmount
            CurrentTransaction.PaidAmount = PaidAmount
            CurrentTransaction.ReturnedAmount = ReturnedAmount
            CurrentTransaction.TransactionStatus = TrxnStatus
            CurrentTransaction.SaveTransactionDetails("Cash", True)
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Private Sub OnPrintReceiptDocument(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Try
            e.Graphics.PageUnit = GraphicsUnit.Millimeter

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim ALReceiptDetails() As String = PrintReceiptDetails.Split(Chr(174))

            For I As Integer = 0 To ALReceiptDetails.Length - 1
                Dim ReceiptDetails As String = ALReceiptDetails(I)
                If ReceiptDetails.Split(Chr(169)).Length = 9 Then

                    Try

                        Dim ContentType As String = ReceiptDetails.Split(Chr(169))(2)
                        Dim ContentData As String = ReceiptDetails.Split(Chr(169))(3)
                        Dim ContentLocationX As Integer = Val(ReceiptDetails.Split(Chr(169))(4))
                        Dim ContentLocationY As Integer = Val(ReceiptDetails.Split(Chr(169))(5))
                        Dim ContentWidth As Integer = Val(ReceiptDetails.Split(Chr(169))(6))
                        Dim ContentHeight As Integer = Val(ReceiptDetails.Split(Chr(169))(7))
                        Dim ContentStyle As String = ReceiptDetails.Split(Chr(169))(8)

                        If ContentType = "Text" Then

                            Dim ContentFont As Font = Me.Font
                            Dim SF As New System.Drawing.StringFormat
                            Dim DrawBrush As New SolidBrush(Color.Black)
                            Dim DisplayRectangle As RectangleF = New RectangleF(New PointF(Math.Round((ContentLocationX)), Math.Round((ContentLocationY))), New SizeF(ContentWidth, ContentHeight))

                            Dim ContentStyleParts() As String = ContentStyle.Split("|")
                            For S As Integer = 0 To ContentStyleParts.Length - 1
                                If ContentStyleParts(S).Split("=").Length = 2 Then
                                    Dim StyleName As String = ContentStyleParts(S).Split("=")(0)
                                    Dim StyleValue As String = ContentStyleParts(S).Split("=")(1)
                                    If StyleName.ToUpper = "Font".ToUpper And StyleValue.Split(";").Length = 3 Then
                                        Try
                                            ContentFont = New Font(StyleValue.Split(";")(0), CType(StyleValue.Split(";")(1), Single), CType(StyleValue.Split(";")(2), FontStyle))
                                        Catch ex As Exception
                                            ContentFont = Me.Font
                                            ExceptionLogger.LogException(ex)
                                        End Try
                                    ElseIf StyleName.ToUpper = "Align".ToUpper Then
                                        If StyleValue = "L" Then
                                            SF.Alignment = StringAlignment.Near
                                        End If
                                        If StyleValue = "C" Then
                                            SF.Alignment = StringAlignment.Center
                                        End If
                                        If StyleValue = "R" Then
                                            SF.Alignment = StringAlignment.Far
                                        End If
                                    ElseIf StyleName.ToUpper = "RTL".ToUpper Then
                                        If StyleValue = "Y" Then
                                            SF.FormatFlags = StringFormatFlags.DirectionRightToLeft
                                        End If
                                    End If
                                End If
                            Next

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[Time]", Date.Now.ToString("HH:mm")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm")).Replace("[ServiceName]", "دفع فاتورة الخط الثابت").Replace("[TerminalId]", objConfigParams.TerminalId).Replace("[TrxnAmount]", TrxnAmount).Replace("[PaidAmount]", PaidAmount).Replace("[ReturnedAmount]", ReturnedAmount).Replace("[TrxnStatus]", TrxnStatus).Replace("[TrxnReference]", CurrentTransaction.TransactionReference)

                            e.Graphics.DrawString(ContentData, ContentFont, DrawBrush, DisplayRectangle, SF)

                        ElseIf ContentType = "Image" Then

                            Dim PIC As New PictureBox
                            PIC.Load(objConfigParams.PlatformURL & ContentData)

                            Dim DisplayRectangle As RectangleF = New RectangleF(New PointF(Math.Round((ContentLocationX)), Math.Round((ContentLocationY))), New SizeF(ContentWidth, ContentHeight))
                            e.Graphics.DrawImage(PIC.Image, DisplayRectangle)

                        End If

                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                    End Try

                End If
            Next
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

#End Region

    Private ReturnedAmount As Decimal = 0
    Private Sub ReturnCoinCash(ByVal Amount As Decimal)

        ReturnedAmount = 0

        If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline And Amount >= 0.5 Then

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            ReturnedAmount = objCoinCashRecycler.ReturnCashAndCoins(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), Amount)

        End If

    End Sub



End Class