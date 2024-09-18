Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class frmSIMSwap10

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public Amount As String = ""
    Public IsESIM As Boolean = False
    Public EmailAddress As String = ""

    Private Sub frmSIMSwap10_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        txtAmount.Text = Amount

    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap11
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Amount = Amount
        obj.IsESIM = IsESIM
        obj.EmailAddress = EmailAddress
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnReflect_Click(sender As Object, e As EventArgs) Handles btnReflect.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        DoPaymentUsingCard()

    End Sub

    Private Sub btnCreditCard_Click(sender As Object, e As EventArgs) Handles btnCreditCard.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        DoPaymentUsingCard()

    End Sub
    Private DoPaymentUsingCardLock As New Object
    Private Sub DoPaymentUsingCard()
        SyncLock DoPaymentUsingCardLock
            ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
            Globals.ShowPleaseWait(Me)

            Dim CC As New CameraCapture
            CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

            Dim CardResponse As Boolean = False
            Dim TransactionReference As String = ""
            Dim TransIndexCode As String = Date.Now.ToString("yyyyMMddHHmmssfffff")

            Dim objPOSLib As New POSLib(7, 9600)
            Dim POSResponse As String = objPOSLib.Purchase(TransIndexCode, Val(Amount) * 100, "376", 0, 1, 60)
            If POSResponse.Contains("{") = True And POSResponse.Contains("}") = True Then

                POSResponse = POSResponse.Substring(POSResponse.IndexOf("{"))
                POSResponse = POSResponse.Substring(0, POSResponse.IndexOf("}") + 1)

                Dim jsonObj As JObject = JObject.Parse(POSResponse)
                If jsonObj("RespCode") = "000" Or jsonObj("RespCode") = "001" Or jsonObj("RespCode") = "003" Then

                    CardResponse = True
                    TransactionReference = jsonObj("TransID")

                End If

            End If

            If CardResponse = True Then

                Dim SIMSerialNumber As String = ""

                If IsESIM = False Then
                    SIMSerialNumber = objCardDispnser.ScanSimCardAndReturnBarCode()
                    If SIMSerialNumber = "" Then
                        objCardDispnser.CaptureCard()
                        SIMSerialNumber = objCardDispnser.ScanSimCardAndReturnBarCode()
                        If SIMSerialNumber = "" Then
                            objCardDispnser.CaptureCard()
                            SIMSerialNumber = objCardDispnser.ScanSimCardAndReturnBarCode()
                        End If
                    End If
                End If
                Try

                    CurrentTransaction.ServiceNumber = MobileNumber
                    CurrentTransaction.TransactionAmount = Val(Amount)
                    CurrentTransaction.PaidAmount = Val(Amount)
                    CurrentTransaction.ReturnedAmount = 0
                    If (IsESIM = True Or (IsESIM = False And SIMSerialNumber <> "")) Then



                        Dim apiResponseValue = APIs.ConfirmSimSwap(MobileNumber.Substring(1), EmailAddress, IsESIM.ToString.ToLower, SIMSerialNumber, TransactionReference, "Visa", frmSIMSwap.SessionId)
                        If apiResponseValue = APIs.APIReturnedValue.Success Then

                            If IsESIM = False Then
                                objCardDispnser.DispenseCard()
                            End If

                            TrxnAmount = Val(Amount)
                            PaidAmount = Val(Amount)
                            ReturnedAmount = 0
                            PrintSuccessReceipt()

                            Globals.HidePleaseWait(Me)

                            Dim obj As New frmSIMSwap12
                            obj.Owner = Me.Owner
                            obj.ShowDialog()
                            obj.Close()
                        ElseIf apiResponseValue = APIs.APIReturnedValue.Failed Then

                            objCardDispnser.CaptureCard()
                            objPOSLib.Refund(TransIndexCode, TransactionReference, "376", 0, 1, 60)
                            TrxnAmount = Val(Amount)
                            PaidAmount = Val(Amount)
                            ReturnedAmount = Val(Amount)
                            PrintFailedReceipt("Failed")
                            Globals.HidePleaseWait(Me)
                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        Else

                            objCardDispnser.CaptureCard()
                            TrxnAmount = Val(Amount)
                            PaidAmount = Val(Amount)
                            ReturnedAmount = 0
                            PrintFailedReceipt("UnKnownStatus")
                            Globals.HidePleaseWait(Me)
                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        End If
                    End If
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                    Globals.HidePleaseWait(Me)
                End Try
            Else

                Globals.HidePleaseWait(Me)
                ExceptionLogger.LogInfo("frmSimSwap10 -> failed to pay wth visa POSResponse =" & POSResponse)
            End If
        End SyncLock
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

#Region "Print Receipt"

    Dim PrintReceiptDetails As String = ""
    Dim TrxnStatus As String = ""
    Dim TrxnAmount As Decimal = 0
    Dim PaidAmount As Decimal = 0
    Dim ReturnedAmount As Decimal = 0

    Private PrintSuccessReceiptLock As New Object
    Private Sub PrintSuccessReceipt()
        SyncLock PrintSuccessReceiptLock
            Try
                If (IsESIM = True) Then
                    PrintReceiptDetails = APIs.GetReceiptDetails("ESIMSwapSuccess")
                Else
                    PrintReceiptDetails = APIs.GetReceiptDetails("SIMSwapSuccess")
                End If

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

    Private Sub PrintFailedReceipt(TrxnStatus As String)
        Try

            PrintReceiptDetails = APIs.GetReceiptDetails("SIMSwapFailed")
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

    Private Sub PrintCancelledReceipt()

        Try
            PrintReceiptDetails = APIs.GetReceiptDetails("SIMSwapCancelled")
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

            CurrentTransaction.ServiceNumber = MobileNumber
            CurrentTransaction.TransactionAmount = TrxnAmount
            CurrentTransaction.PaidAmount = PaidAmount
            CurrentTransaction.ReturnedAmount = ReturnedAmount
            CurrentTransaction.TransactionStatus = TrxnStatus
            CurrentTransaction.SaveTransactionDetails("Visa", True)
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

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[Time]", Date.Now.ToString("HH:mm")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm")).Replace("[ServiceName]", "تبديل الشريحة").Replace("[TerminalId]", objConfigParams.TerminalId).Replace("[TrxnAmount]", TrxnAmount).Replace("[PaidAmount]", PaidAmount).Replace("[ReturnedAmount]", ReturnedAmount).Replace("[TrxnStatus]", TrxnStatus).Replace("[TrxnReference]", CurrentTransaction.TransactionReference)

                            e.Graphics.DrawString(ContentData, ContentFont, DrawBrush, DisplayRectangle, SF)

                        ElseIf ContentType = "Image" Then

                            Dim PIC As New PictureBox

                            If ContentData.Contains("esim.png") Then
                                Dim base64Image As String = Globals.QRCode
                                Dim imageBytes() As Byte = Convert.FromBase64String(base64Image)

                                Using ms As New System.IO.MemoryStream(imageBytes)
                                    PIC.Image = Image.FromStream(ms)
                                End Using
                            Else
                                PIC.Load(objConfigParams.PlatformURL & ContentData)
                            End If

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