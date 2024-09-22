Imports Newtonsoft.Json.Linq

Public Class frmNewSim2

    Public Msisdn As String = ""
    Public Price As String = ""
    Public DocumentType As String = "palestine_id"    'NationalID/Passport
    Public DocumentUploaded As Boolean = False
    Public DocumentFileData() As Byte
    Public VideoUploaded As Boolean = False
    Public VideoFilePath As String = ""
    Public AgreeStatus As Boolean = False

    Private Sub frmNewSim2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmNewSim2 -> frmNewSim2_Load ")
    End Sub

    Private Sub rbNationalID_Click(sender As Object, e As EventArgs) Handles rbNationalID.Click
        ExceptionLogger.LogInfo("frmNewSim2 -> rbNationalID_Click ")
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
        ExceptionLogger.LogInfo("frmNewSim2 -> rbPassport_Click ")
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
        ExceptionLogger.LogInfo("frmNewSim2 -> btnUploadDocument_Click ")
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
    Dim objfrmVideoRecorder As frmVideoRecorder
    Private Sub btnUploadVideo_Click(sender As Object, e As EventArgs) Handles btnUploadVideo.Click
        ExceptionLogger.LogInfo("frmNewSim2 -> btnUploadVideo_Click ")
        objfrmVideoRecorder = New frmVideoRecorder
        objfrmVideoRecorder.Owner = Me.Owner
        objfrmVideoRecorder.ShowDialog()
        objfrmVideoRecorder.Close()
        If objfrmVideoRecorder.IsDone = True Then
            VideoUploaded = True
            VideoFilePath = objfrmVideoRecorder.VideoFilePath
            picVideoUploadedSuccessfully.Visible = True
        End If

    End Sub

    Private Sub btnUploadPassport_Click(sender As Object, e As EventArgs) Handles btnUploadPassport.Click
        ExceptionLogger.LogInfo("frmNewSim2 -> btnUploadPassport_Click ")
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
        ExceptionLogger.LogInfo("frmNewSim2 -> btnAgreeStatus_Click ")
        If AgreeStatus = True Then
            btnAgreeStatus.Image = ILImages.Images.Item(3)
            AgreeStatus = False
        Else
            btnAgreeStatus.Image = ILImages.Images.Item(2)
            AgreeStatus = True
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSim2 -> btnOK_Click ")
        lblErrorDescription.Text = ""

        If AgreeStatus = True And ((DocumentType = "palestine_id" And DocumentUploaded = True And VideoUploaded = True) Or (DocumentType = "Passport" And DocumentUploaded = True)) Then

            Globals.ShowPleaseWait(Me)

            Dim ExtractUserInfoResult As Boolean = False
            Dim ExtractedUserInfo As String = ""

            If DocumentType = "palestine_id" Then
                Dim FLVideo() As Byte = IO.File.ReadAllBytes(VideoFilePath)
                ExtractedUserInfo = APIs.ExtractUserInfo(Convert.ToBase64String(DocumentFileData), Convert.ToBase64String(FLVideo), "id", Msisdn, frmNewSim.SessionId)
                ExceptionLogger.LogInfo("frmNewSim2 -> btnOK_Click ExtractedUserInfo from id = " & ExtractedUserInfo & " Msisdn=" & Msisdn)
            ElseIf DocumentType = "Passport" Then
                ExtractedUserInfo = APIs.ExtractUserInfo(Convert.ToBase64String(DocumentFileData), "", "passport", Msisdn, frmNewSim.SessionId)
                ExceptionLogger.LogInfo("frmNewSim2 -> btnOK_Click ExtractedUserInfo from passport = " & ExtractedUserInfo)
            End If

            Dim IDNumber As String = ""
            Dim FullName As String = ""
            Dim DateOfBirth As String = ""
            Dim PlaceOfBirth As String = ""
            Dim AddressRegion As String = ""
            Dim Gender As String = ""
            Dim DocType As String = ""
            Dim reservationID As String = ""
            Dim resourceID As String = ""

            Dim jsonObj As JObject = JObject.Parse(ExtractedUserInfo)
            If jsonObj("code") = "0" And jsonObj("message") = "Valid" Then

                Dim jsonData As JObject = jsonObj("data")

                IDNumber = jsonData("iD_number").ToString()
                FullName = jsonData("name").ToString()
                DateOfBirth = jsonData("dateOfBirth").ToString()
                PlaceOfBirth = jsonData("placeOfBirth").ToString()
                AddressRegion = jsonData("region").ToString()
                Gender = jsonData("gender").ToString()
                DocType = jsonData("type").ToString()
                reservationID = jsonData("reservationID").ToString()
                resourceID = jsonData("resourceID").ToString()

                ExtractUserInfoResult = True

            End If

            If ExtractUserInfoResult = True Then

                Globals.HidePleaseWait(Me)

                Dim obj As New frmNewSim3
                obj.Msisdn = Msisdn
                obj.Price = Price
                obj.IDNumber = IDNumber
                obj.FullName = FullName
                obj.DateOfBirth = DateOfBirth
                obj.PlaceOfBirth = PlaceOfBirth
                obj.AddressRegion = AddressRegion
                obj.Gender = Gender
                obj.DocType = DocType
                obj.reservationID = reservationID
                obj.resourceID = resourceID
                obj.DocumentFileData = DocumentFileData
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
        ExceptionLogger.LogInfo("frmNewSim2 -> btnBack_Click ")
        Me.Close()
    End Sub

    Private Sub lblTermsAndConditions_Click(sender As Object, e As EventArgs) Handles lblTermsAndConditions.Click
        Dim obj As frmNewSimTermsAndConditions = New frmNewSimTermsAndConditions(Me)
        obj.Owner = Me.Owner
        obj.ShowDialog()
    End Sub
End Class