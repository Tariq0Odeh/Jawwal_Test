Imports Newtonsoft.Json.Linq

Public Class frmNewSim6

    Public Msisdn As String = ""
    Public Price As String = ""
    Public IDNumber As String = ""
    Public FullName As String = ""
    Public DateOfBirth As String = ""
    Public PlaceOfBirth As String = ""
    Public AddressRegion As String = ""
    Public AddressCity As String = ""
    Public Gender As String = ""
    Public DocType As String = ""
    Public reservationID As String = ""
    Public resourceID As String = ""
    Public IsESIM As Boolean = False
    Public MsisdnType As String = ""
    Public PackageCode As String = ""
    Public EmailAddress As String = ""
    Public ContactNumber As String = ""
    Public DocumentFileData() As Byte

    Private Sub frmNewSim6_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmNewSim5 -> frmNewSim6_Load ")
        txtAmount.Text = Price

    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnCash_Click ")
        Dim obj As New frmNewSim7
        obj.Msisdn = Msisdn
        obj.Price = Price
        obj.IDNumber = IDNumber
        obj.FullName = FullName
        obj.DateOfBirth = DateOfBirth
        obj.PlaceOfBirth = PlaceOfBirth
        obj.AddressRegion = AddressRegion
        obj.AddressCity = AddressCity
        obj.Gender = Gender
        obj.DocType = DocType
        obj.reservationID = reservationID
        obj.resourceID = resourceID
        obj.IsESIM = IsESIM
        obj.MsisdnType = MsisdnType
        obj.PackageCode = PackageCode
        obj.EmailAddress = EmailAddress
        obj.ContactNumber = ContactNumber
        obj.DocumentFileData = DocumentFileData
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()

    End Sub

    Private Sub btnReflect_Click(sender As Object, e As EventArgs) Handles btnReflect.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnReflect_Click ")
        DoPaymentUsingCard()

    End Sub

    Private Sub btnCreditCard_Click(sender As Object, e As EventArgs) Handles btnCreditCard.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnCreditCard_Click ")
        DoPaymentUsingCard()

    End Sub

    Private DoPaymentUsingCardLock As New Object
    Private Sub DoPaymentUsingCard()
        SyncLock DoPaymentUsingCardLock
            Globals.ShowPleaseWait(Me)

            Dim CC As New CameraCapture
            CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

            Dim CardResponse As Boolean = False
            Dim TransactionReference As String = ""
            Dim TransIndexCode As String = Date.Now.ToString("yyyyMMddHHmmssfffff")

            Dim objPOSLib As New POSLib(7, 9600)
            Dim POSResponse As String = objPOSLib.Purchase(TransIndexCode, Val(Price) * 100, "376", 0, 1, 60)
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

                CurrentTransaction.ServiceNumber = Msisdn
                CurrentTransaction.TransactionAmount = Val(Price)
                CurrentTransaction.PaidAmount = Val(Price)
                CurrentTransaction.ReturnedAmount = 0
                If (IsESIM = True Or (IsESIM = False And SIMSerialNumber <> "")) Then
                    Dim apiResponse = APIs.ConfirmNewSIM(Msisdn.Substring(1), IDNumber, SIMSerialNumber, FullName, DateOfBirth, Gender, AddressCity, IsESIM.ToString.ToLower, DocType, Convert.ToBase64String(DocumentFileData), MsisdnType, "Visa", PackageCode, EmailAddress, ContactNumber, reservationID, TransactionReference)
                    If apiResponse = APIs.APIReturnedValue.Success Then

                        If (IsESIM = False And (MsisdnType.ToLower().Contains("post") Or MsisdnType.ToLower().Contains("mix"))) Then
                            objCardDispnser.DispenseCard()
                        End If

                        TrxnAmount = Val(Price)
                            PaidAmount = Val(Price)
                            ReturnedAmount = 0
                            PrintSuccessReceipt()
                            Globals.HidePleaseWait(Me)

                            Dim obj As frmNewSim8
                            If MsisdnType.ToLower().Contains("post") Or MsisdnType.ToLower().Contains("mix") Then
                                obj = New frmNewSim8(True)
                            Else
                                obj = New frmNewSim8()
                            End If
                            obj.Owner = Me.Owner
                            obj.ShowDialog()
                            obj.Close()

                        ElseIf apiResponse = APIs.APIReturnedValue.Failed Then

                            objCardDispnser.CaptureCard()
                            objPOSLib.Refund(TransIndexCode, TransactionReference, "376", 0, 1, 60)
                            TrxnAmount = Val(Price)
                            PaidAmount = Val(Price)
                            ReturnedAmount = Val(Price)
                            PrintFailedReceipt("Failed")
                            Globals.HidePleaseWait(Me)
                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        Else

                            objCardDispnser.CaptureCard()
                        TrxnAmount = Val(Price)
                        PaidAmount = Val(Price)
                        ReturnedAmount = 0
                        PrintFailedReceipt("UnKnownStatus")
                        Globals.HidePleaseWait(Me)
                        Me.Owner.Close()
                        Me.Owner.Dispose()

                    End If
                End If
            Else
                ExceptionLogger.LogInfo("frmNewSim6->Failed to pay with Visa card POSResponse = " & POSResponse)
                Globals.HidePleaseWait(Me)

            End If
        End SyncLock
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnBack_Click ")
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


                PrintReceiptDetails = APIs.GetReceiptDetails("NewSIMSuccess")
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

                CurrentTransaction.ServiceNumber = Msisdn
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

            PrintReceiptDetails = APIs.GetReceiptDetails("NewSIMFailed")
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

            CurrentTransaction.ServiceNumber = Msisdn
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


            PrintReceiptDetails = APIs.GetReceiptDetails("NewSIMCancelled")
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

            CurrentTransaction.ServiceNumber = Msisdn
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

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[Time]", Date.Now.ToString("HH:mm")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm")).Replace("[ServiceName]", "انضم لعائلة جوال").Replace("[TerminalId]", objConfigParams.TerminalId).Replace("[TrxnAmount]", TrxnAmount).Replace("[PaidAmount]", PaidAmount).Replace("[ReturnedAmount]", ReturnedAmount).Replace("[TrxnStatus]", TrxnStatus).Replace("[TrxnReference]", CurrentTransaction.TransactionReference)

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