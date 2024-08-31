<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSIMSwap1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap1))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.lblTermsAndConditions = New System.Windows.Forms.Label()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlPassport = New System.Windows.Forms.Panel()
        Me.picPassportUploadedSuccessfully = New System.Windows.Forms.PictureBox()
        Me.btnUploadPassport = New System.Windows.Forms.PictureBox()
        Me.picVideoUploadedSuccessfully = New System.Windows.Forms.PictureBox()
        Me.picDocumentUploadedSuccessfully = New System.Windows.Forms.PictureBox()
        Me.btnAgreeStatus = New System.Windows.Forms.PictureBox()
        Me.btnUploadVideo = New System.Windows.Forms.PictureBox()
        Me.btnUploadDocument = New System.Windows.Forms.PictureBox()
        Me.rbPassport = New System.Windows.Forms.PictureBox()
        Me.rbNationalID = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ILImages = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlWA.SuspendLayout()
        Me.pnlPassport.SuspendLayout()
        CType(Me.picPassportUploadedSuccessfully, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUploadPassport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVideoUploadedSuccessfully, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDocumentUploadedSuccessfully, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAgreeStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUploadVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUploadDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbPassport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbNationalID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblTermsAndConditions)
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.pnlPassport)
        Me.pnlWA.Controls.Add(Me.picVideoUploadedSuccessfully)
        Me.pnlWA.Controls.Add(Me.picDocumentUploadedSuccessfully)
        Me.pnlWA.Controls.Add(Me.btnAgreeStatus)
        Me.pnlWA.Controls.Add(Me.btnUploadVideo)
        Me.pnlWA.Controls.Add(Me.btnUploadDocument)
        Me.pnlWA.Controls.Add(Me.rbPassport)
        Me.pnlWA.Controls.Add(Me.rbNationalID)
        Me.pnlWA.Controls.Add(Me.Label4)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.Label1)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 1
        '
        'lblTermsAndConditions
        '
        Me.lblTermsAndConditions.BackColor = System.Drawing.Color.Transparent
        Me.lblTermsAndConditions.Location = New System.Drawing.Point(699, 686)
        Me.lblTermsAndConditions.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTermsAndConditions.Name = "lblTermsAndConditions"
        Me.lblTermsAndConditions.Size = New System.Drawing.Size(248, 50)
        Me.lblTermsAndConditions.TabIndex = 42
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 193)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 41
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlPassport
        '
        Me.pnlPassport.BackgroundImage = CType(resources.GetObject("pnlPassport.BackgroundImage"), System.Drawing.Image)
        Me.pnlPassport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPassport.Controls.Add(Me.picPassportUploadedSuccessfully)
        Me.pnlPassport.Controls.Add(Me.btnUploadPassport)
        Me.pnlPassport.Location = New System.Drawing.Point(85, 252)
        Me.pnlPassport.Name = "pnlPassport"
        Me.pnlPassport.Size = New System.Drawing.Size(559, 386)
        Me.pnlPassport.TabIndex = 38
        Me.pnlPassport.Visible = False
        '
        'picPassportUploadedSuccessfully
        '
        Me.picPassportUploadedSuccessfully.Image = CType(resources.GetObject("picPassportUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picPassportUploadedSuccessfully.Location = New System.Drawing.Point(30, 104)
        Me.picPassportUploadedSuccessfully.Name = "picPassportUploadedSuccessfully"
        Me.picPassportUploadedSuccessfully.Size = New System.Drawing.Size(499, 246)
        Me.picPassportUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPassportUploadedSuccessfully.TabIndex = 40
        Me.picPassportUploadedSuccessfully.TabStop = False
        Me.picPassportUploadedSuccessfully.Visible = False
        '
        'btnUploadPassport
        '
        Me.btnUploadPassport.Image = CType(resources.GetObject("btnUploadPassport.Image"), System.Drawing.Image)
        Me.btnUploadPassport.Location = New System.Drawing.Point(88, 220)
        Me.btnUploadPassport.Name = "btnUploadPassport"
        Me.btnUploadPassport.Size = New System.Drawing.Size(42, 42)
        Me.btnUploadPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadPassport.TabIndex = 36
        Me.btnUploadPassport.TabStop = False
        '
        'picVideoUploadedSuccessfully
        '
        Me.picVideoUploadedSuccessfully.Image = CType(resources.GetObject("picVideoUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picVideoUploadedSuccessfully.Location = New System.Drawing.Point(113, 509)
        Me.picVideoUploadedSuccessfully.Name = "picVideoUploadedSuccessfully"
        Me.picVideoUploadedSuccessfully.Size = New System.Drawing.Size(499, 101)
        Me.picVideoUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVideoUploadedSuccessfully.TabIndex = 40
        Me.picVideoUploadedSuccessfully.TabStop = False
        Me.picVideoUploadedSuccessfully.Visible = False
        '
        'picDocumentUploadedSuccessfully
        '
        Me.picDocumentUploadedSuccessfully.Image = CType(resources.GetObject("picDocumentUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picDocumentUploadedSuccessfully.Location = New System.Drawing.Point(113, 318)
        Me.picDocumentUploadedSuccessfully.Name = "picDocumentUploadedSuccessfully"
        Me.picDocumentUploadedSuccessfully.Size = New System.Drawing.Size(499, 101)
        Me.picDocumentUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDocumentUploadedSuccessfully.TabIndex = 39
        Me.picDocumentUploadedSuccessfully.TabStop = False
        Me.picDocumentUploadedSuccessfully.Visible = False
        '
        'btnAgreeStatus
        '
        Me.btnAgreeStatus.Image = CType(resources.GetObject("btnAgreeStatus.Image"), System.Drawing.Image)
        Me.btnAgreeStatus.Location = New System.Drawing.Point(1122, 676)
        Me.btnAgreeStatus.Name = "btnAgreeStatus"
        Me.btnAgreeStatus.Size = New System.Drawing.Size(60, 60)
        Me.btnAgreeStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAgreeStatus.TabIndex = 37
        Me.btnAgreeStatus.TabStop = False
        '
        'btnUploadVideo
        '
        Me.btnUploadVideo.Image = CType(resources.GetObject("btnUploadVideo.Image"), System.Drawing.Image)
        Me.btnUploadVideo.Location = New System.Drawing.Point(172, 541)
        Me.btnUploadVideo.Name = "btnUploadVideo"
        Me.btnUploadVideo.Size = New System.Drawing.Size(42, 42)
        Me.btnUploadVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadVideo.TabIndex = 36
        Me.btnUploadVideo.TabStop = False
        '
        'btnUploadDocument
        '
        Me.btnUploadDocument.Image = CType(resources.GetObject("btnUploadDocument.Image"), System.Drawing.Image)
        Me.btnUploadDocument.Location = New System.Drawing.Point(172, 350)
        Me.btnUploadDocument.Name = "btnUploadDocument"
        Me.btnUploadDocument.Size = New System.Drawing.Size(42, 42)
        Me.btnUploadDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadDocument.TabIndex = 35
        Me.btnUploadDocument.TabStop = False
        '
        'rbPassport
        '
        Me.rbPassport.Image = CType(resources.GetObject("rbPassport.Image"), System.Drawing.Image)
        Me.rbPassport.Location = New System.Drawing.Point(1082, 489)
        Me.rbPassport.Name = "rbPassport"
        Me.rbPassport.Size = New System.Drawing.Size(60, 60)
        Me.rbPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rbPassport.TabIndex = 34
        Me.rbPassport.TabStop = False
        '
        'rbNationalID
        '
        Me.rbNationalID.Image = CType(resources.GetObject("rbNationalID.Image"), System.Drawing.Image)
        Me.rbNationalID.Location = New System.Drawing.Point(1082, 387)
        Me.rbNationalID.Name = "rbNationalID"
        Me.rbNationalID.Size = New System.Drawing.Size(60, 60)
        Me.rbNationalID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rbNationalID.TabIndex = 33
        Me.rbNationalID.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(220, 530)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(370, 61)
        Me.Label4.TabIndex = 32
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(97, 855)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(534, 78)
        Me.btnBack.TabIndex = 31
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(649, 855)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(534, 78)
        Me.btnOK.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(220, 338)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 61)
        Me.Label1.TabIndex = 0
        '
        'ILImages
        '
        Me.ILImages.ImageStream = CType(resources.GetObject("ILImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILImages.TransparentColor = System.Drawing.Color.Transparent
        Me.ILImages.Images.SetKeyName(0, "Selected.png")
        Me.ILImages.Images.SetKeyName(1, "Unselected.png")
        Me.ILImages.Images.SetKeyName(2, "Accept.png")
        Me.ILImages.Images.SetKeyName(3, "Reject.png")
        '
        'frmSIMSwap1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1026)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSIMSwap1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlPassport.ResumeLayout(False)
        CType(Me.picPassportUploadedSuccessfully, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUploadPassport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVideoUploadedSuccessfully, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDocumentUploadedSuccessfully, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAgreeStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUploadVideo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUploadDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbPassport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbNationalID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBack As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rbNationalID As PictureBox
    Friend WithEvents rbPassport As PictureBox
    Friend WithEvents ILImages As ImageList
    Friend WithEvents btnUploadVideo As PictureBox
    Friend WithEvents btnUploadDocument As PictureBox
    Friend WithEvents btnAgreeStatus As PictureBox
    Friend WithEvents pnlPassport As Panel
    Friend WithEvents btnUploadPassport As PictureBox
    Friend WithEvents picVideoUploadedSuccessfully As PictureBox
    Friend WithEvents picDocumentUploadedSuccessfully As PictureBox
    Friend WithEvents picPassportUploadedSuccessfully As PictureBox
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents lblTermsAndConditions As Label
End Class
