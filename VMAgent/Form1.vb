Imports System.Net
Imports Newtonsoft.Json.Linq
Imports VinderSDK

Public Class Form1

    Dim mouseDownPoint As Point
    Dim IsMouseDown As Boolean = False

    Private Sub pnlTouch_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTouch.MouseDown
        IsMouseDown = True
        mouseDownPoint = Cursor.Position
    End Sub

    Private Sub pnlTouch_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTouch.MouseMove
        If IsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y)
            If ((mouseDownPoint.X <> Cursor.Position.X) Or (mouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlTouch.AutoScrollPosition
                pnlTouch.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                mouseDownPoint = Cursor.Position

            End If

        End If
    End Sub

    Private Sub pnlTouch_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTouch.MouseUp
        IsMouseDown = False
    End Sub



















    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Dim objPOSLib As New POSLib(7, 9600)
        'Dim POSResponse As String = objPOSLib.Purchase(Date.Now.ToString("yyyyMMddHHmmssfffff"), "200", "376", 0, 1, 60)
        'If POSResponse.Contains("{") = True And POSResponse.Contains("}") = True Then
        '    POSResponse = POSResponse.Substring(POSResponse.IndexOf("{"))
        '    POSResponse = POSResponse.Substring(0, POSResponse.IndexOf("}") + 1)

        '    Dim jsonObj As JObject = JObject.Parse(POSResponse)
        '    If jsonObj("RespCode") = "000" Or jsonObj("RespCode") = "001" Or jsonObj("RespCode") = "003" Then

        '        Dim IsVISAPaid As Boolean = True
        '        Dim TransactionReference As String = jsonObj("TransID")


        '    End If

        'End If

        'Dim obj As New Transaction
        'obj.TransactionReference = "A123"
        'obj.SaveTransactionDetails()

        'Dim a As New CameraCapture
        'RichTextBox1.Text = a.CaptureAsBase64String()





        ' Dim FL() As Byte = IO.File.ReadAllBytes("C:\Temp\ImadID.png")


        ' RichTextBox1.Text = APIs.ConfirmNewSIM("599354598", "921568556", "123654789", "Imad Abu Hayyah", "24/02/1983", "M", "رام الله", "false", "id", Convert.ToBase64String(FL), "PRE", "Cash", "1236", "imad@tiresias.co.com", "0599354598", "321456", "")



        'Dim FL() As Byte = IO.File.ReadAllBytes("C:\Temp\ImadID.png")
        'Dim FL2() As Byte = IO.File.ReadAllBytes("D:\Vending Machine Project - Jawwal\VMAgent\VMAgent\bin\Debug\Vedio\24051322534882080337348536350F4BA7BC1BBD9DF76E6EC9.avi")
        'RichTextBox1.Text = APIs.ExtractUserInfo(Convert.ToBase64String(FL), Convert.ToBase64String(FL2), "id")


        'Dim jsonObj As JObject = JObject.Parse(RichTextBox1.Text)
        'If jsonObj("code") = "0" Then

        '    Dim ALQuestions As JArray = jsonObj("data")
        '    For I As Integer = 0 To ALQuestions.Count - 1

        '        Dim QuestionObj As New JObject
        '        QuestionObj = ALQuestions(I)

        '        If QuestionObj("id").ToString() = "3" Then
        '            If QuestionObj("answers").Type = JTokenType.Array Then
        '                Dim ALAnswers As JArray = QuestionObj("answers")
        '                For A As Integer = 0 To ALAnswers.Count - 1
        '                    Dim AnswerObj As New JObject
        '                    AnswerObj = ALAnswers(A)
        '                    Dim PkgType As String = AnswerObj("type").ToString()
        '                    'ToDO
        '                Next
        '            End If
        '        End If
        '        If QuestionObj("id").ToString() = "4" Then
        '            If QuestionObj("answers").Type = JTokenType.Array Then
        '                Dim ALAnswers As JArray = QuestionObj("answers")
        '                For A As Integer = 0 To ALAnswers.Count - 1
        '                    Dim AnswerObj As New JObject
        '                    AnswerObj = ALAnswers(A)
        '                    Dim Pkgname As String = AnswerObj("pkgname").ToString()
        '                    Dim Pkgofferid As String = AnswerObj("pkgofferid").ToString()
        '                    Dim PkgType As String = AnswerObj("type").ToString()
        '                    'ToDo
        '                Next
        '            End If
        '        End If

        '    Next

        'End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' CtlKeyboard1.txtBox = txtPhoneNumber

        AddHandler Label2.MouseDown, AddressOf pnlTouch_MouseDown
        AddHandler Label2.MouseMove, AddressOf pnlTouch_MouseMove
        AddHandler Label2.MouseUp, AddressOf pnlTouch_MouseUp

        AddHandler Label3.MouseDown, AddressOf pnlTouch_MouseDown
        AddHandler Label3.MouseMove, AddressOf pnlTouch_MouseMove
        AddHandler Label3.MouseUp, AddressOf pnlTouch_MouseUp

        pnlTouch.Width += SystemInformation.VerticalScrollBarWidth

    End Sub

    Private Sub AA()
        MsgBox("dd")
    End Sub

    Public Shared Function GetNewId() As String

        Dim NewId As String
        NewId = Date.Now.ToString("yyMMddHHmmssffffff") & System.Guid.NewGuid.ToString("N").ToUpper

        Return NewId

    End Function

#Region "Print Receipt"

    Dim PrintReceiptDetails As String = ""

    Private Sub PrintSuccessReceipt()
        Try



            PrintReceiptDetails = APIs.GetReceiptDetails("TopUpSuccess")

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
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Private Sub PrintFaildReceipt()
        Try



            PrintReceiptDetails = APIs.GetReceiptDetails("TopUpFaild")

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
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Private Sub PrintCancelledReceipt()

        Try


            PrintReceiptDetails = APIs.GetReceiptDetails("TopUpCancelled")

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

                            ContentData = ContentData.Replace("[Date]", Date.Now.ToString("dd/MM/yyyy")).Replace("[DateTime]", Date.Now.ToString("dd/MM/yyyy HH:mm"))

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

    Dim obj As PleaseWaitUntilFinish

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        obj = New PleaseWaitUntilFinish
        obj.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        obj.Close()
    End Sub

#End Region


    Public Function Execute(ByVal RequestResource As String, ByRef RequestDataFields As Object, ByRef objEnvironment As Object) As String
        Dim Ret As String = "True"

        If RequestDataFields.ContainsKey("TransactionReference") = True And RequestDataFields.ContainsKey("TransactionType") = True And RequestDataFields.ContainsKey("TerminalId") = True And RequestDataFields.ContainsKey("ServiceNumber") = True And RequestDataFields.ContainsKey("TransactionAmount") = True And RequestDataFields.ContainsKey("PaidAmount") = True And RequestDataFields.ContainsKey("ReturnedAmount") = True And RequestDataFields.ContainsKey("CustomerPhoto1") = True And RequestDataFields.ContainsKey("CustomerPhoto2") = True And RequestDataFields.ContainsKey("CustomerPhoto3") = True And RequestDataFields.ContainsKey("DocumentPhoto") = True And RequestDataFields.ContainsKey("CustomerVideo") = True And RequestDataFields.ContainsKey("MoreDetails1") = True And RequestDataFields.ContainsKey("MoreDetails2") = True And RequestDataFields.ContainsKey("MoreDetails3") = True And RequestDataFields.ContainsKey("MoreDetails4") = True And RequestDataFields.ContainsKey("MoreDetails5") = True And RequestDataFields.ContainsKey("TransactionDateTime") = True And RequestDataFields.ContainsKey("TransactionStatus") = True Then

            Dim objActionResult As Object = objEnvironment.CreateObject("ActionResult")
            Dim objTransaction As Object = objEnvironment.CreateObject("Transaction")
            objTransaction.TransactionReference = RequestDataFields("TransactionReference")
            objTransaction.TransactionType = RequestDataFields("TransactionType")
            objTransaction.TerminalId = RequestDataFields("TerminalId")
            objTransaction.ServiceNumber = RequestDataFields("ServiceNumber")
            objTransaction.TransactionAmount = RequestDataFields("TransactionAmount")
            objTransaction.PaidAmount = RequestDataFields("PaidAmount")
            objTransaction.ReturnedAmount = RequestDataFields("ReturnedAmount")
            objTransaction.CustomerPhoto1 = RequestDataFields("CustomerPhoto1")
            objTransaction.CustomerPhoto2 = RequestDataFields("CustomerPhoto2")
            objTransaction.CustomerPhoto3 = RequestDataFields("CustomerPhoto3")
            objTransaction.DocumentPhoto = RequestDataFields("DocumentPhoto")
            objTransaction.CustomerVideo = RequestDataFields("CustomerVideo")
            objTransaction.MoreDetails1 = RequestDataFields("MoreDetails1")
            objTransaction.MoreDetails2 = RequestDataFields("MoreDetails2")
            objTransaction.MoreDetails3 = RequestDataFields("MoreDetails3")
            objTransaction.MoreDetails4 = RequestDataFields("MoreDetails4")
            objTransaction.MoreDetails5 = RequestDataFields("MoreDetails5")
            objTransaction.TransactionDateTime = RequestDataFields("TransactionDateTime")
            objTransaction.TransactionStatus = RequestDataFields("TransactionStatus")
            objTransaction.Insert(objEnvironment)

        End If

        Return Ret
    End Function


End Class