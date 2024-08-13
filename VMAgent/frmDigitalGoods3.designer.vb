<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDigitalGoods3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalGoods3))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.pnlDenominationsHolder = New System.Windows.Forms.Panel()
        Me.pnlDescriptionHolder = New System.Windows.Forms.Panel()
        Me.picBrandLogo = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.pnlDescription = New FlickerFreePanel
        Me.txtDescription = New System.Windows.Forms.Label()
        Me.pnlDenominations = New VMAgent.FlickerFreePanel()
        Me.pnlWA.SuspendLayout()
        Me.pnlDenominationsHolder.SuspendLayout()
        Me.pnlDescriptionHolder.SuspendLayout()
        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.pnlDenominationsHolder)
        Me.pnlWA.Controls.Add(Me.pnlDescriptionHolder)
        Me.pnlWA.Controls.Add(Me.picBrandLogo)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 7
        '
        'pnlDenominationsHolder
        '
        Me.pnlDenominationsHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlDenominationsHolder.Controls.Add(Me.pnlDenominations)
        Me.pnlDenominationsHolder.Location = New System.Drawing.Point(120, 490)
        Me.pnlDenominationsHolder.Name = "pnlDenominationsHolder"
        Me.pnlDenominationsHolder.Size = New System.Drawing.Size(1062, 255)
        Me.pnlDenominationsHolder.TabIndex = 41
        '
        'pnlDescriptionHolder
        '
        Me.pnlDescriptionHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlDescriptionHolder.Controls.Add(Me.pnlDescription)
        Me.pnlDescriptionHolder.Location = New System.Drawing.Point(120, 194)
        Me.pnlDescriptionHolder.Name = "pnlDescriptionHolder"
        Me.pnlDescriptionHolder.Size = New System.Drawing.Size(814, 221)
        Me.pnlDescriptionHolder.TabIndex = 40
        '
        'picBrandLogo
        '
        Me.picBrandLogo.BackColor = System.Drawing.Color.Transparent
        Me.picBrandLogo.Location = New System.Drawing.Point(954, 194)
        Me.picBrandLogo.Name = "picBrandLogo"
        Me.picBrandLogo.Size = New System.Drawing.Size(228, 221)
        Me.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBrandLogo.TabIndex = 27
        Me.picBrandLogo.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(1000, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(182, 76)
        Me.btnBack.TabIndex = 10
        '
        'pnlDescription
        '
        Me.pnlDescription.AutoScroll = True
        Me.pnlDescription.BackColor = System.Drawing.Color.Transparent
        Me.pnlDescription.Controls.Add(Me.txtDescription)
        Me.pnlDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnlDescription.Name = "pnlDescription"
        Me.pnlDescription.Size = New System.Drawing.Size(814, 221)
        Me.pnlDescription.TabIndex = 41
        '
        'txtDescription
        '
        Me.txtDescription.AutoSize = True
        Me.txtDescription.BackColor = System.Drawing.Color.Transparent
        Me.txtDescription.Font = New System.Drawing.Font("Arial Narrow", 23.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(0, 0)
        Me.txtDescription.MaximumSize = New System.Drawing.Size(800, 0)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(0, 36)
        Me.txtDescription.TabIndex = 14
        '
        'pnlDenominations
        '
        Me.pnlDenominations.AutoScroll = True
        Me.pnlDenominations.BackColor = System.Drawing.Color.Transparent
        Me.pnlDenominations.Location = New System.Drawing.Point(0, 0)
        Me.pnlDenominations.Name = "pnlDenominations"
        Me.pnlDenominations.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlDenominations.Size = New System.Drawing.Size(1062, 255)
        Me.pnlDenominations.TabIndex = 37
        '
        'frmDigitalGoods3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmDigitalGoods3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlDenominationsHolder.ResumeLayout(False)
        Me.pnlDescriptionHolder.ResumeLayout(False)
        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDescription.ResumeLayout(False)
        Me.pnlDescription.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents picBrandLogo As PictureBox
    Friend WithEvents pnlDenominations As FlickerFreePanel
    Friend WithEvents pnlDescriptionHolder As Panel
    Friend WithEvents pnlDenominationsHolder As Panel
    Friend WithEvents pnlDescription As FlickerFreePanel
    Friend WithEvents txtDescription As Label
End Class
