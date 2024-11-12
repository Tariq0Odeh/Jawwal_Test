Imports System.Reflection
Imports VinderSDK

Public Class frmSIMSwap1

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public DocumentType As String = "palestine_id"    'NationalID/Passport
    Public DocumentUploaded As Boolean = False
    Public DocumentFileData() As Byte
    Public VideoUploaded As Boolean = False
    Public VideoFilePath As String = ""
    Public AgreeStatus As Boolean = False

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap1))
        ExceptionLogger.LogInfo("frmSIMSwap1_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap1
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

        Me.pnlPassport.BackgroundImage = Global.VMAgent.My.Resources.Resources.pnlPassport_BackgroundImage
        Me.pnlPassport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

        Me.picPassportUploadedSuccessfully.Image = Global.VMAgent.My.Resources.Resources.picPassportUploadedSuccessfully
        Me.picPassportUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.btnUploadPassport.Image = Global.VMAgent.My.Resources.Resources.btnUpload
        Me.btnUploadPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.picVideoUploadedSuccessfully.Image = Global.VMAgent.My.Resources.Resources.picVideoUploadedSuccessfully
        Me.picVideoUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.picDocumentUploadedSuccessfully.Image = Global.VMAgent.My.Resources.Resources.picDocumentUploadedSuccessfully
        Me.picDocumentUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.btnAgreeStatus.Image = Global.VMAgent.My.Resources.Resources.btnAgreeStatus
        Me.btnAgreeStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.btnUploadVideo.Image = Global.VMAgent.My.Resources.Resources.btnUpload
        Me.btnUploadVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.btnUploadDocument.Image = Global.VMAgent.My.Resources.Resources.btnUpload
        Me.btnUploadDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.rbPassport.Image = Global.VMAgent.My.Resources.Resources.rbPassport
        Me.rbPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.rbNationalID.Image = Global.VMAgent.My.Resources.Resources.rbNationalID
        Me.rbNationalID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub frmSIMSwap1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap1_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap1_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub rbNationalID_Click(sender As Object, e As EventArgs) Handles rbNationalID.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        DocumentType = "palestine_id"
        rbNationalID.Image = ILImages.Images.Item(0)
        rbPassport.Image = ILImages.Images.Item(1)
        pnlPassport.Visible = False
        picDocumentUploadedSuccessfully.Visible = False
        picVideoUploadedSuccessfully.Visible = False
        DocumentUploaded = False
        VideoUploaded = False

    End Sub

    Private Sub rbPassport_Click(sender As Object, e As EventArgs) Handles rbPassport.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        DocumentType = "Passport"
        rbNationalID.Image = ILImages.Images.Item(1)
        rbPassport.Image = ILImages.Images.Item(0)
        pnlPassport.Visible = True
        pnlPassport.BringToFront()
        picPassportUploadedSuccessfully.Visible = False
        DocumentUploaded = False
        VideoUploaded = False

    End Sub

    Private Sub btnUploadDocument_Click(sender As Object, e As EventArgs) Handles btnUploadDocument.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmDocumentScanner
        obj.Owner = Me.Owner
        obj.DocumentType = DocumentType
        obj.ShowDialog()
        obj.Close()
        If obj.IsDone = True Then
            DocumentUploaded = True
            DocumentFileData = obj.DocumentFileData
            picDocumentUploadedSuccessfully.Visible = True
        End If

    End Sub
    Dim obj As frmVideoRecorder
    Private Sub btnUploadVideo_Click(sender As Object, e As EventArgs) Handles btnUploadVideo.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        obj = New frmVideoRecorder
        obj.Owner = Me.Owner
        obj.ShowDialog()
        ExceptionLogger.LogInfo("frmSimSwap1 => btnUploadVideo obj.IsDone = " & obj.IsDone)
        obj.Close()
        If obj.IsDone = True Then
            VideoUploaded = True
            ExceptionLogger.LogInfo("frmSimSwap1 => btnUploadVideo obj.VideoFilePath = " & obj.VideoFilePath)
            VideoFilePath = obj.VideoFilePath
            picVideoUploadedSuccessfully.Visible = True
        End If

    End Sub

    Private Sub btnUploadPassport_Click(sender As Object, e As EventArgs) Handles btnUploadPassport.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmDocumentScanner
        obj.Owner = Me.Owner
        obj.DocumentType = DocumentType
        obj.ShowDialog()
        obj.Close()
        If obj.IsDone = True Then
            DocumentUploaded = True
            DocumentFileData = obj.DocumentFileData
            picPassportUploadedSuccessfully.Visible = True
        End If

    End Sub

    Public Sub btnAgreeStatus_Click(sender As Object, e As EventArgs) Handles btnAgreeStatus.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        If AgreeStatus = True Then
            btnAgreeStatus.Image = ILImages.Images.Item(3)
            AgreeStatus = False
        Else
            btnAgreeStatus.Image = ILImages.Images.Item(2)
            AgreeStatus = True
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        lblErrorDescription.Text = ""

        If AgreeStatus = True And ((DocumentType = "palestine_id" And DocumentUploaded = True And VideoUploaded = True) Or (DocumentType = "Passport" And DocumentUploaded = True)) Then

            Globals.ShowPleaseWait(Me)

            Dim EkycCheckResult As Boolean = False

            If DocumentType = "palestine_id" Then
                Dim FLVideo() As Byte = IO.File.ReadAllBytes(VideoFilePath)
                EkycCheckResult = APIs.EkycCheck(Convert.ToBase64String(DocumentFileData), Convert.ToBase64String(FLVideo), "id", frmSIMSwap.SessionId)
            ElseIf DocumentType = "Passport" Then
                EkycCheckResult = APIs.EkycCheck(Convert.ToBase64String(DocumentFileData), "", "passport", frmSIMSwap.SessionId)
            End If

            If EkycCheckResult = True Then

                Globals.HidePleaseWait(Me)

                Dim obj As New frmSIMSwap2
                obj.MobileNumber = MobileNumber
                obj.IDNumber = IDNumber
                obj.Owner = Me.Owner
                obj.ShowDialog()
                obj.Close()
            Else

                If DocumentType = "palestine_id" Then

                    picDocumentUploadedSuccessfully.Visible = False
                    picVideoUploadedSuccessfully.Visible = False
                    DocumentUploaded = False
                    VideoUploaded = False

                    lblErrorDescription.Text = "الرجاء اعادة تحميل صورة الوثيقة والفيديو الشخصي"

                ElseIf DocumentType = "Passport" Then

                    picPassportUploadedSuccessfully.Visible = False
                    DocumentUploaded = False
                    VideoUploaded = False

                    lblErrorDescription.Text = "الرجاء اعادة تحميل صورة الوثيقة"

                End If

                Globals.HidePleaseWait(Me)

            End If

        Else

            If DocumentType = "palestine_id" Then

                If DocumentUploaded = False Then
                    lblErrorDescription.Text = "الرجاء تحميل صورة الوثيقة"
                ElseIf VideoUploaded = False Then
                    lblErrorDescription.Text = "الرجاء تحميل الفيدبو الشخصي"
                ElseIf AgreeStatus = False Then
                    lblErrorDescription.Text = "الرجاء الموافقة على الشروط والأحكام"
                End If

            ElseIf DocumentType = "Passport" Then

                If DocumentUploaded = False Then
                    lblErrorDescription.Text = "الرجاء تحميل صورة الوثيقة"
                ElseIf AgreeStatus = False Then
                    lblErrorDescription.Text = "الرجاء الموافقة على الشروط والأحكام"
                End If

            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

    Private Sub lblTermsAndConditions_Click(sender As Object, e As EventArgs) Handles lblTermsAndConditions.Click
        Dim obj As frmNewSimTermsAndConditions = New frmNewSimTermsAndConditions(Me)
        obj.Owner = Me.Owner
        obj.ShowDialog()
    End Sub
End Class