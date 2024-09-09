Imports System.ComponentModel
Imports System.Reflection

Public Class frmNewSim7

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
    'Public objCoinCashRecycler As VinderSDK.CoinCashRecycler

    Private Sub frmNewSim7_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmNewSim7 -> frmNewSim7_Load ")
        If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()
            'objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)

            AddHandler objCoinCashRecycler.OnCoinCashDeposit, AddressOf OnCoinCash
            objCoinCashRecycler.StartAcceptingCoinCash(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False))
        End If
        txtTotalAmount.Text = Price

    End Sub

    Private Sub frmNewSim7_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ExceptionLogger.LogInfo("frmNewSim7 -> frmNewSim7_Closing ")
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
            Try
                ExceptionLogger.LogInfo("frmNewSim7 -> btnOK_Click ")
                If Val(txtAmount.Text) >= Val(Price) Then
                    btnOK.Enabled = False
                    isConfirmedClicked = True
                    Globals.ShowPleaseWait(Me)

                    Dim CC As New CameraCapture
                    CurrentTransaction.CustomerPhoto2 = CC.CaptureAsBase64String()

                    If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                        Dim TotalInputAmount As Decimal = objCoinCashRecycler.StopAcceptingMoney()
                        txtAmount.Text = TotalInputAmount.ToString
                    End If

                    Dim SIMSerialNumber As String = ""

                    If IsESIM = False Then
                        Try
                            objCardDispnser.CaptureCard()
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)
                        End Try
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
                    CurrentTransaction.PaidAmount = Val(txtAmount.Text)
                    CurrentTransaction.ReturnedAmount = Val(txtAmount.Text) - Val(Price)
                    If (IsESIM = True Or (IsESIM = False And SIMSerialNumber <> "")) Then
                        Dim apiResponse = APIs.ConfirmNewSIM(Msisdn.Substring(1), IDNumber, SIMSerialNumber, FullName, DateOfBirth, Gender, AddressCity, IsESIM.ToString.ToLower, DocType, Convert.ToBase64String(DocumentFileData), MsisdnType, "Cash", PackageCode, EmailAddress, ContactNumber, reservationID, resourceID)
                        If apiResponse = APIs.APIReturnedValue.Success Then

                            If (IsESIM = False And Not (MsisdnType.ToLower().Contains("post") Or MsisdnType.ToLower().Contains("mix"))) Then
                                objCardDispnser.DispenseCard()
                            End If

                            ReturnCoinCash(Val(txtAmount.Text) - Val(Price))
                            TrxnAmount = Val(Price)
                            PaidAmount = Val(txtAmount.Text)
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
                            ReturnCoinCash(Val(txtAmount.Text))
                            TrxnAmount = Val(Price)
                            PaidAmount = Val(txtAmount.Text)
                            PrintFailedReceipt("Failed")
                            Globals.HidePleaseWait(Me)
                            btnOK.Enabled = True
                            txtAmount.Text = 0
                            isConfirmedClicked = False
                            Me.Owner.Close()
                            Me.Owner.Dispose()
                        Else

                            objCardDispnser.CaptureCard()
                            ReturnCoinCash(Val(txtAmount.Text) - Val(Price))
                            TrxnAmount = Val(Price)
                            PaidAmount = Val(txtAmount.Text)
                            PrintFailedReceipt("UnKnownStatus")
                            Globals.HidePleaseWait(Me)
                            btnOK.Enabled = True
                            txtAmount.Text = 0
                            isConfirmedClicked = False
                            Me.Owner.Close()
                            Me.Owner.Dispose()

                        End If
                    Else

                        Globals.HidePleaseWait(Me)

                    End If
                    btnOK.Enabled = True
                    txtAmount.Text = 0
                    isConfirmedClicked = False
                End If
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub

    Private btnCancelLock As New Object
    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        SyncLock btnCancelLock
            ExceptionLogger.LogInfo("frmNewSim7 -> btnCancel_Click ")
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

                    TrxnAmount = Val(Price)
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
            ExceptionLogger.LogInfo("frmNewSim7 -> btnBack_Click ")
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

                    TrxnAmount = Val(Price)
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


                If (IsESIM = True And Not (MsisdnType.ToLower().Contains("post") Or MsisdnType.ToLower().Contains("mix"))) Then
                    PrintReceiptDetails = APIs.GetReceiptDetails("NewESIMSuccess")
                Else
                    PrintReceiptDetails = APIs.GetReceiptDetails("NewSIMSuccess")
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

                CurrentTransaction.ServiceNumber = Msisdn
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
            CurrentTransaction.SaveTransactionDetails("Cash")
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

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[Time]", Date.Now.ToString("HH:mm")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm")).Replace("[ServiceName]", "انضم لعائلة جوال").Replace("[TerminalId]", objConfigParams.TerminalId).Replace("[TrxnAmount]", TrxnAmount).Replace("[PaidAmount]", PaidAmount).Replace("[ReturnedAmount]", ReturnedAmount).Replace("[TrxnStatus]", TrxnStatus).Replace("[TrxnReference]", CurrentTransaction.TransactionReference)

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

    Private ReturnedAmount As Decimal = 0
    Private Sub ReturnCoinCash(ByVal Amount As Decimal)

        ReturnedAmount = 0

        If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline And Amount >= 0.5 Then

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            ReturnedAmount = objCoinCashRecycler.ReturnCashAndCoins(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), Amount)

        End If

    End Sub

    Private isConfirmedClicked As Boolean


End Class