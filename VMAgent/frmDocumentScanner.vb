Public Class frmDocumentScanner

    Public DocumentFileData() As Byte
    Public DocumentType As String
    Public IsDone As Boolean = False

    Private IsDocumentCaptured As Boolean = False

    Private Sub frmDocumentScanner_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmDocumentScanner -> frmDocumentScanner_Load")

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmDocumentScanner -> btnOK_Click")
        lblErrorDescription.Text = ""

        Globals.ShowPleaseWait(Me)

        Dim objDocumentScanner As New DocumentScanner

        Dim DocumentPath As String = objDocumentScanner.CaptureImage()

        If DocumentPath <> "" Then

            DocumentFileData = IO.File.ReadAllBytes(DocumentPath)

            Dim MS As New IO.MemoryStream
            MS.Write(DocumentFileData, 0, DocumentFileData.Length)
            picDocument.Image = Image.FromStream(MS)
            picDocument.Visible = True

            IsDocumentCaptured = True
        End If

        Globals.HidePleaseWait(Me)

    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        ExceptionLogger.LogInfo("frmDocumentScanner -> btnContinue_Click")
        lblErrorDescription.Text = ""

        If IsDocumentCaptured = True Then
            IsDone = True
            Me.Close()
        Else
            lblErrorDescription.Text = "الرجاء مسح صورة الوثيقة"
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmDocumentScanner -> btnBack_Click")
        Me.Close()
    End Sub



End Class