<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocumentScanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentScanner))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnContinue = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.picDocument = New System.Windows.Forms.PictureBox()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        CType(Me.picDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.btnContinue)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.picDocument)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 0
        '
        'btnContinue
        '
        Me.btnContinue.BackColor = System.Drawing.Color.Transparent
        Me.btnContinue.Location = New System.Drawing.Point(649, 854)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(442, 76)
        Me.btnContinue.TabIndex = 12
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(189, 854)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(442, 76)
        Me.btnOK.TabIndex = 11
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 76)
        Me.btnBack.TabIndex = 10
        '
        'picDocument
        '
        Me.picDocument.BackColor = System.Drawing.Color.Silver
        Me.picDocument.Location = New System.Drawing.Point(314, 276)
        Me.picDocument.Name = "picDocument"
        Me.picDocument.Size = New System.Drawing.Size(649, 436)
        Me.picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDocument.TabIndex = 3
        Me.picDocument.TabStop = False
        Me.picDocument.Visible = False
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 197)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 16
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmDocumentScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmDocumentScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vending Machine"
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        CType(Me.picDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents picDocument As PictureBox
    Friend WithEvents btnBack As Label
    Friend WithEvents btnContinue As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents lblErrorDescription As Label
End Class
