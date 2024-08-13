<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlDenomination
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlDenomination))
        Me.picDenominationLogo = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.Label()
        Me.txtendCustomerPriceWithVATLIS = New System.Windows.Forms.Label()
        CType(Me.picDenominationLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDenominationLogo
        '
        Me.picDenominationLogo.BackColor = System.Drawing.Color.Transparent
        Me.picDenominationLogo.Location = New System.Drawing.Point(56, 56)
        Me.picDenominationLogo.Name = "picDenominationLogo"
        Me.picDenominationLogo.Size = New System.Drawing.Size(70, 70)
        Me.picDenominationLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDenominationLogo.TabIndex = 27
        Me.picDenominationLogo.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(16, 166)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(150, 65)
        Me.txtName.TabIndex = 28
        Me.txtName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtendCustomerPriceWithVATLIS
        '
        Me.txtendCustomerPriceWithVATLIS.BackColor = System.Drawing.Color.Transparent
        Me.txtendCustomerPriceWithVATLIS.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtendCustomerPriceWithVATLIS.ForeColor = System.Drawing.Color.Black
        Me.txtendCustomerPriceWithVATLIS.Location = New System.Drawing.Point(16, 132)
        Me.txtendCustomerPriceWithVATLIS.Name = "txtendCustomerPriceWithVATLIS"
        Me.txtendCustomerPriceWithVATLIS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtendCustomerPriceWithVATLIS.Size = New System.Drawing.Size(150, 26)
        Me.txtendCustomerPriceWithVATLIS.TabIndex = 29
        Me.txtendCustomerPriceWithVATLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctlDenomination
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtendCustomerPriceWithVATLIS)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.picDenominationLogo)
        Me.Name = "ctlDenomination"
        Me.Size = New System.Drawing.Size(183, 245)
        CType(Me.picDenominationLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picDenominationLogo As PictureBox
    Friend WithEvents txtName As Label
    Friend WithEvents txtendCustomerPriceWithVATLIS As Label
End Class
