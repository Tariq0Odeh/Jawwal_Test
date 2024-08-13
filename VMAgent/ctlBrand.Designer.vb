<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlBrand
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlBrand))
        Me.txtName = New System.Windows.Forms.Label()
        Me.picBrandLogo = New System.Windows.Forms.PictureBox()
        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.AutoEllipsis = True
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.White
        Me.txtName.Location = New System.Drawing.Point(23, 174)
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtName.Size = New System.Drawing.Size(136, 81)
        Me.txtName.TabIndex = 25
        Me.txtName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picBrandLogo
        '
        Me.picBrandLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.picBrandLogo.Location = New System.Drawing.Point(60, 81)
        Me.picBrandLogo.Name = "picBrandLogo"
        Me.picBrandLogo.Size = New System.Drawing.Size(67, 67)
        Me.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBrandLogo.TabIndex = 26
        Me.picBrandLogo.TabStop = False
        '
        'ctlBrand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.picBrandLogo)
        Me.Controls.Add(Me.txtName)
        Me.Name = "ctlBrand"
        Me.Size = New System.Drawing.Size(187, 286)
        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtName As Label
    Friend WithEvents picBrandLogo As PictureBox
End Class
