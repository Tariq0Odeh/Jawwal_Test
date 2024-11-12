﻿Imports Newtonsoft.Json.Linq

Public Class frmJawwalBillPayment4

    Public MobileNumber As String = ""
    Public Amount As String = ""
    Public ALInvoicesToPay As New List(Of JawwalInvoice)

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJawwalBillPayment4))
        ExceptionLogger.LogInfo("frmJawwalBillPayment4_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmJawwalBillPayment4
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub
    Private Sub frmJawwalBillPayment4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmJawwalBillPayment4_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmJawwalBillPayment4_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmJawwalBillPayment4 -> frmJawwalBillPayment4_Load ")
        txtAmount.Text = Amount

    End Sub

    Private Sub btnCash_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCash.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment4 -> btnCash_MouseDown ")
        Dim obj As New frmJawwalBillPayment5
        obj.MobileNumber = MobileNumber
        obj.Amount = Amount
        obj.ALInvoicesToPay = ALInvoicesToPay
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnReflect_MouseDown(sender As Object, e As MouseEventArgs) Handles btnReflect.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment4 -> btnReflect_MouseDown ")
        DoPaymentUsingCard()

    End Sub

    Private Sub btnCreditCard_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCreditCard.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment4 -> btnCreditCard_MouseDown ")
        DoPaymentUsingCard()

    End Sub
    Private DoPaymentUsingCardLock As New Object
    Private Sub DoPaymentUsingCard()
        SyncLock DoPaymentUsingCardLock
            Try
                ExceptionLogger.LogInfo(Me.Name & " -> frmJawwalDoPaymentUsingCard")

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

                CurrentTransaction.ServiceNumber = MobileNumber
                CurrentTransaction.TransactionAmount = Val(Amount)
                CurrentTransaction.PaidAmount = 0
                CurrentTransaction.ReturnedAmount = 0

                Dim CardResponse As Boolean = False
                Dim TransactionReference As String = ""
                Dim TransIndexCode As String = Date.Now.ToString("yyyyMMddHHmmssfffff")

                Dim objPOSLib As New POSLib(7, 9600)
                Dim POSResponse As String = ""
                Try

                    ExceptionLogger.LogInfo("Trying to connect to POS with " & TransIndexCode & " and Amount " & Amount.ToString())
                    POSResponse = objPOSLib.Purchase(TransIndexCode, Val(Amount) * 100, "376", 0, 1, 60)
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try
                Dim posCardResponseCode = ""
                If POSResponse.Contains("{") = True And POSResponse.Contains("}") = True Then

                    POSResponse = POSResponse.Substring(POSResponse.IndexOf("{"))
                    POSResponse = POSResponse.Substring(0, POSResponse.IndexOf("}") + 1)

                    Dim jsonObj As JObject = JObject.Parse(POSResponse)
                    posCardResponseCode = jsonObj("RespCode")
                    If posCardResponseCode = "000" Or posCardResponseCode = "001" Or posCardResponseCode = "003" Then

                        CardResponse = True
                        TransactionReference = jsonObj("TransID")

                    End If

                End If

                If CardResponse = True Then
                    Try
                        Dim payments As String = ""

                        For I As Integer = 0 To ALInvoicesToPay.Count - 1
                            If Val(ALInvoicesToPay(I).partialAmount) <> Val(ALInvoicesToPay(I).amount) Then
                                payments &= ",{ ""invoice"": { ""invoiceNumber"": """ & ALInvoicesToPay(I).invoiceNumber & """, ""amount"": """ & ALInvoicesToPay(I).amount & """, ""cycle"": """ & ALInvoicesToPay(I).cycle & """, ""msisdn"": """ & ALInvoicesToPay(I).msisdn & """, ""dueDate"": """ & ALInvoicesToPay(I).dueDate & """, ""currency"": """ & ALInvoicesToPay(I).currency & """ }, ""partialAmount"": """ & ALInvoicesToPay(I).partialAmount & """ }"
                            Else
                                payments &= ",{ ""invoice"": { ""invoiceNumber"": """ & ALInvoicesToPay(I).invoiceNumber & """, ""amount"": """ & ALInvoicesToPay(I).amount & """, ""cycle"": """ & ALInvoicesToPay(I).cycle & """, ""msisdn"": """ & ALInvoicesToPay(I).msisdn & """, ""dueDate"": """ & ALInvoicesToPay(I).dueDate & """, ""currency"": """ & ALInvoicesToPay(I).currency & """ }, ""partialAmount"": """" }"
                            End If
                        Next

                        If payments <> "" Then
                            payments = payments.Substring(1)
                        End If


                        Dim apiReturnedValue = APIs.PayJawwalInvoices(MobileNumber.Substring(1), payments, TransactionReference, "Visa", frmJawwalBillPayment.SessionId)
                        If apiReturnedValue = APIs.APIReturnedValue.Success Then
                            CurrentTransaction.PaidAmount = Val(Amount)
                            TrxnAmount = Val(Amount)
                            PaidAmount = Val(Amount)
                            ReturnedAmount = 0
                            PrintSuccessReceipt()



                            Dim obj As New frmJawwalBillPayment6
                            obj.Owner = Me.Owner
                            obj.ShowDialog()

                        ElseIf apiReturnedValue = APIs.APIReturnedValue.Failed Then

                            objPOSLib.Refund(TransIndexCode, TransactionReference, "376", 0, 1, 60)

                            TrxnAmount = Val(Amount)
                            PaidAmount = Val(Amount)
                            ReturnedAmount = Val(Amount)
                            PrintFailedReceipt()



                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        Else
                            TrxnAmount = Val(Amount)
                            PaidAmount = 0
                            ReturnedAmount = 0
                            PrintUnkownStatusReceipt()
                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        End If
                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                        Globals.HidePleaseWait(Me)
                        Throw ex
                    End Try

                Else
                    TrxnAmount = Val(Amount)
                    PaidAmount = 0
                    ReturnedAmount = 0
                    PrintCancelledReceipt("UnKnownStatus")
                    Globals.HidePleaseWait(Me)
                    ExceptionLogger.LogInfo("frmJawwalBillPayment -> Failed to DoPaymentUsingCard, card response=" & posCardResponseCode)

                End If
                Globals.HidePleaseWait(Me)
            Catch ex As Exception
                TrxnAmount = Val(Amount)
                PaidAmount = 0
                ReturnedAmount = 0
                PrintCancelledReceipt("UnKnownStatus")
                Globals.HidePleaseWait(Me)
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmJawwalBillPayment4 -> btnBack_MouseDown ")
        Me.Close()
    End Sub

#Region "Print Receipt"

    Dim PrintReceiptDetails As String = ""
    Dim TrxnStatus As String = ""
    Dim TrxnAmount As Decimal = 0
    Dim PaidAmount As Decimal = 0
    Dim ReturnedAmount As Decimal = 0

    Private PrintSuccessReceiptLock As New Object

    Private Sub PrintUnkownStatusReceipt()
        SyncLock PrintSuccessReceiptLock
            Try

                PrintReceiptDetails = APIs.GetReceiptDetails("JawwalBillPaymentSuccess")
                TrxnStatus = "UnknownStatus"
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
                CurrentTransaction.ServiceNumber = MobileNumber
                CurrentTransaction.TransactionAmount = TrxnAmount
                CurrentTransaction.PaidAmount = PaidAmount
                CurrentTransaction.ReturnedAmount = ReturnedAmount
                CurrentTransaction.TransactionStatus = TrxnStatus
                CurrentTransaction.SaveTransactionDetails("Visa")
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub

    Private Sub PrintSuccessReceipt()
        SyncLock PrintSuccessReceiptLock
            Try


                PrintReceiptDetails = APIs.GetReceiptDetails("JawwalBillPaymentSuccess")
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

                CurrentTransaction.ServiceNumber = MobileNumber
                CurrentTransaction.TransactionAmount = TrxnAmount
                CurrentTransaction.PaidAmount = PaidAmount
                CurrentTransaction.ReturnedAmount = ReturnedAmount
                CurrentTransaction.TransactionStatus = TrxnStatus
                CurrentTransaction.SaveTransactionDetails("Visa")
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub

    Private Sub PrintFailedReceipt()
        Try
            PrintReceiptDetails = APIs.GetReceiptDetails("JawwalBillPaymentFailed")
            TrxnStatus = "Failed"

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

            CurrentTransaction.ServiceNumber = MobileNumber
            CurrentTransaction.TransactionAmount = TrxnAmount
            CurrentTransaction.PaidAmount = PaidAmount
            CurrentTransaction.ReturnedAmount = ReturnedAmount
            CurrentTransaction.TransactionStatus = TrxnStatus
            CurrentTransaction.SaveTransactionDetails("Visa")
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Private Sub PrintCancelledReceipt(Optional TrxnStatus As String = "Cancelled")
        Try

            PrintReceiptDetails = APIs.GetReceiptDetails("JawwalBillPaymentCancelled")
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

            CurrentTransaction.ServiceNumber = MobileNumber
            CurrentTransaction.TransactionAmount = TrxnAmount
            CurrentTransaction.PaidAmount = PaidAmount
            CurrentTransaction.ReturnedAmount = ReturnedAmount
            CurrentTransaction.TransactionStatus = TrxnStatus
            CurrentTransaction.SaveTransactionDetails("Visa")
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

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[Time]", Date.Now.ToString("HH:mm")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm")).Replace("[ServiceName]", "دفع فاتورة جوال").Replace("[TerminalId]", objConfigParams.TerminalId).Replace("[TrxnAmount]", TrxnAmount).Replace("[PaidAmount]", PaidAmount).Replace("[ReturnedAmount]", ReturnedAmount).Replace("[TrxnStatus]", TrxnStatus).Replace("[TrxnReference]", CurrentTransaction.TransactionReference)

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



End Class