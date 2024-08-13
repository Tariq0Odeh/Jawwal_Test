<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlMsisdn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlMsisdn))
        Me.picUnselected = New System.Windows.Forms.PictureBox()
        Me.picSelected = New System.Windows.Forms.PictureBox()
        Me.btnSelectUnSelect = New System.Windows.Forms.Label()
        Me.txtMsisdn = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.Label()
        CType(Me.picUnselected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picUnselected
        '
        Me.picUnselected.Image = CType(resources.GetObject("picUnselected.Image"), System.Drawing.Image)
        Me.picUnselected.Location = New System.Drawing.Point(3, 21)
        Me.picUnselected.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picUnselected.Name = "picUnselected"
        Me.picUnselected.Size = New System.Drawing.Size(18, 16)
        Me.picUnselected.TabIndex = 5
        Me.picUnselected.TabStop = False
        Me.picUnselected.Visible = False
        '
        'picSelected
        '
        Me.picSelected.Image = CType(resources.GetObject("picSelected.Image"), System.Drawing.Image)
        Me.picSelected.Location = New System.Drawing.Point(3, 2)
        Me.picSelected.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picSelected.Name = "picSelected"
        Me.picSelected.Size = New System.Drawing.Size(18, 14)
        Me.picSelected.TabIndex = 4
        Me.picSelected.TabStop = False
        Me.picSelected.Visible = False
        '
        'btnSelectUnSelect
        '
        Me.btnSelectUnSelect.BackColor = System.Drawing.Color.Transparent
        Me.btnSelectUnSelect.Location = New System.Drawing.Point(801, 50)
        Me.btnSelectUnSelect.Name = "btnSelectUnSelect"
        Me.btnSelectUnSelect.Size = New System.Drawing.Size(60, 60)
        Me.btnSelectUnSelect.TabIndex = 20
        '
        'txtMsisdn
        '
        Me.txtMsisdn.BackColor = System.Drawing.Color.Transparent
        Me.txtMsisdn.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMsisdn.ForeColor = System.Drawing.Color.Black
        Me.txtMsisdn.Location = New System.Drawing.Point(516, 50)
        Me.txtMsisdn.Name = "txtMsisdn"
        Me.txtMsisdn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMsisdn.Size = New System.Drawing.Size(274, 60)
        Me.txtMsisdn.TabIndex = 22
        Me.txtMsisdn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.Color.Transparent
        Me.txtPrice.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.ForeColor = System.Drawing.Color.Black
        Me.txtPrice.Location = New System.Drawing.Point(44, 50)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPrice.Size = New System.Drawing.Size(252, 60)
        Me.txtPrice.TabIndex = 23
        Me.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ctlMsisdn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtMsisdn)
        Me.Controls.Add(Me.btnSelectUnSelect)
        Me.Controls.Add(Me.picUnselected)
        Me.Controls.Add(Me.picSelected)
        Me.Name = "ctlMsisdn"
        Me.Size = New System.Drawing.Size(905, 159)
        CType(Me.picUnselected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picUnselected As PictureBox
    Friend WithEvents picSelected As PictureBox
    Friend WithEvents btnSelectUnSelect As Label
    Friend WithEvents txtMsisdn As Label
    Friend WithEvents txtPrice As Label
End Class
