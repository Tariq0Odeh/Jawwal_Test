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
        Me.lblTearmsAndConditions = New System.Windows.Forms.Label()
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
        Me.pnlWA.Controls.Add(Me.lblTearmsAndConditions)
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
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1920, 1575)
        Me.pnlWA.TabIndex = 1
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(562, 297)
        Me.lblErrorDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(796, 35)
        Me.lblErrorDescription.TabIndex = 41
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlPassport
        '
        Me.pnlPassport.BackgroundImage = CType(resources.GetObject("pnlPassport.BackgroundImage"), System.Drawing.Image)
        Me.pnlPassport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPassport.Controls.Add(Me.picPassportUploadedSuccessfully)
        Me.pnlPassport.Controls.Add(Me.btnUploadPassport)
        Me.pnlPassport.Location = New System.Drawing.Point(128, 388)
        Me.pnlPassport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlPassport.Name = "pnlPassport"
        Me.pnlPassport.Size = New System.Drawing.Size(838, 594)
        Me.pnlPassport.TabIndex = 38
        Me.pnlPassport.Visible = False
        '
        'picPassportUploadedSuccessfully
        '
        Me.picPassportUploadedSuccessfully.Image = CType(resources.GetObject("picPassportUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picPassportUploadedSuccessfully.Location = New System.Drawing.Point(45, 160)
        Me.picPassportUploadedSuccessfully.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picPassportUploadedSuccessfully.Name = "picPassportUploadedSuccessfully"
        Me.picPassportUploadedSuccessfully.Size = New System.Drawing.Size(748, 378)
        Me.picPassportUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPassportUploadedSuccessfully.TabIndex = 40
        Me.picPassportUploadedSuccessfully.TabStop = False
        Me.picPassportUploadedSuccessfully.Visible = False
        '
        'btnUploadPassport
        '
        Me.btnUploadPassport.Image = CType(resources.GetObject("btnUploadPassport.Image"), System.Drawing.Image)
        Me.btnUploadPassport.Location = New System.Drawing.Point(132, 338)
        Me.btnUploadPassport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUploadPassport.Name = "btnUploadPassport"
        Me.btnUploadPassport.Size = New System.Drawing.Size(63, 65)
        Me.btnUploadPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadPassport.TabIndex = 36
        Me.btnUploadPassport.TabStop = False
        '
        'picVideoUploadedSuccessfully
        '
        Me.picVideoUploadedSuccessfully.Image = CType(resources.GetObject("picVideoUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picVideoUploadedSuccessfully.Location = New System.Drawing.Point(170, 783)
        Me.picVideoUploadedSuccessfully.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picVideoUploadedSuccessfully.Name = "picVideoUploadedSuccessfully"
        Me.picVideoUploadedSuccessfully.Size = New System.Drawing.Size(748, 155)
        Me.picVideoUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVideoUploadedSuccessfully.TabIndex = 40
        Me.picVideoUploadedSuccessfully.TabStop = False
        Me.picVideoUploadedSuccessfully.Visible = False
        '
        'picDocumentUploadedSuccessfully
        '
        Me.picDocumentUploadedSuccessfully.Image = CType(resources.GetObject("picDocumentUploadedSuccessfully.Image"), System.Drawing.Image)
        Me.picDocumentUploadedSuccessfully.Location = New System.Drawing.Point(170, 489)
        Me.picDocumentUploadedSuccessfully.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picDocumentUploadedSuccessfully.Name = "picDocumentUploadedSuccessfully"
        Me.picDocumentUploadedSuccessfully.Size = New System.Drawing.Size(748, 155)
        Me.picDocumentUploadedSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDocumentUploadedSuccessfully.TabIndex = 39
        Me.picDocumentUploadedSuccessfully.TabStop = False
        Me.picDocumentUploadedSuccessfully.Visible = False
        '
        'btnAgreeStatus
        '
        Me.btnAgreeStatus.Image = CType(resources.GetObject("btnAgreeStatus.Image"), System.Drawing.Image)
        Me.btnAgreeStatus.Location = New System.Drawing.Point(1683, 1040)
        Me.btnAgreeStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAgreeStatus.Name = "btnAgreeStatus"
        Me.btnAgreeStatus.Size = New System.Drawing.Size(90, 92)
        Me.btnAgreeStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAgreeStatus.TabIndex = 37
        Me.btnAgreeStatus.TabStop = False
        '
        'btnUploadVideo
        '
        Me.btnUploadVideo.Image = CType(resources.GetObject("btnUploadVideo.Image"), System.Drawing.Image)
        Me.btnUploadVideo.Location = New System.Drawing.Point(258, 832)
        Me.btnUploadVideo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUploadVideo.Name = "btnUploadVideo"
        Me.btnUploadVideo.Size = New System.Drawing.Size(63, 65)
        Me.btnUploadVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadVideo.TabIndex = 36
        Me.btnUploadVideo.TabStop = False
        '
        'btnUploadDocument
        '
        Me.btnUploadDocument.Image = CType(resources.GetObject("btnUploadDocument.Image"), System.Drawing.Image)
        Me.btnUploadDocument.Location = New System.Drawing.Point(258, 538)
        Me.btnUploadDocument.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUploadDocument.Name = "btnUploadDocument"
        Me.btnUploadDocument.Size = New System.Drawing.Size(63, 65)
        Me.btnUploadDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnUploadDocument.TabIndex = 35
        Me.btnUploadDocument.TabStop = False
        '
        'rbPassport
        '
        Me.rbPassport.Image = CType(resources.GetObject("rbPassport.Image"), System.Drawing.Image)
        Me.rbPassport.Location = New System.Drawing.Point(1623, 752)
        Me.rbPassport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbPassport.Name = "rbPassport"
        Me.rbPassport.Size = New System.Drawing.Size(90, 92)
        Me.rbPassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rbPassport.TabIndex = 34
        Me.rbPassport.TabStop = False
        '
        'rbNationalID
        '
        Me.rbNationalID.Image = CType(resources.GetObject("rbNationalID.Image"), System.Drawing.Image)
        Me.rbNationalID.Location = New System.Drawing.Point(1623, 595)
        Me.rbNationalID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbNationalID.Name = "rbNationalID"
        Me.rbNationalID.Size = New System.Drawing.Size(90, 92)
        Me.rbNationalID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rbNationalID.TabIndex = 33
        Me.rbNationalID.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(330, 815)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(555, 94)
        Me.Label4.TabIndex = 32
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(146, 1315)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(801, 120)
        Me.btnBack.TabIndex = 31
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(974, 1315)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(801, 120)
        Me.btnOK.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(330, 520)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(555, 94)
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
        'lblTearmsAndConditions
        '
        Me.lblTearmsAndConditions.BackColor = System.Drawing.Color.Transparent
        Me.lblTearmsAndConditions.Location = New System.Drawing.Point(1049, 1055)
        Me.lblTearmsAndConditions.Name = "lblTearmsAndConditions"
        Me.lblTearmsAndConditions.Size = New System.Drawing.Size(372, 77)
        Me.lblTearmsAndConditions.TabIndex = 42
        '
        'frmSIMSwap1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1920, 1575)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
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
    Friend WithEvents lblTearmsAndConditions As Label
End Class
