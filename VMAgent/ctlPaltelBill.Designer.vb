<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlPaltelBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlPaltelBill))
        Me.picUnselected = New System.Windows.Forms.PictureBox()
        Me.picSelected = New System.Windows.Forms.PictureBox()
        Me.btnSelectUnSelect = New System.Windows.Forms.Label()
        Me.txtBillDueDate = New System.Windows.Forms.Label()
        Me.txtBillDate = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.Label()
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
        Me.picUnselected.TabIndex = 3
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
        Me.picSelected.TabIndex = 2
        Me.picSelected.TabStop = False
        Me.picSelected.Visible = False
        '
        'btnSelectUnSelect
        '
        Me.btnSelectUnSelect.BackColor = System.Drawing.Color.Transparent
        Me.btnSelectUnSelect.Location = New System.Drawing.Point(804, 48)
        Me.btnSelectUnSelect.Name = "btnSelectUnSelect"
        Me.btnSelectUnSelect.Size = New System.Drawing.Size(60, 60)
        Me.btnSelectUnSelect.TabIndex = 19
        '
        'txtBillDueDate
        '
        Me.txtBillDueDate.BackColor = System.Drawing.Color.Transparent
        Me.txtBillDueDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDueDate.ForeColor = System.Drawing.Color.Gray
        Me.txtBillDueDate.Location = New System.Drawing.Point(508, 75)
        Me.txtBillDueDate.Name = "txtBillDueDate"
        Me.txtBillDueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBillDueDate.Size = New System.Drawing.Size(274, 32)
        Me.txtBillDueDate.TabIndex = 22
        Me.txtBillDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBillDate
        '
        Me.txtBillDate.BackColor = System.Drawing.Color.Transparent
        Me.txtBillDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDate.ForeColor = System.Drawing.Color.Black
        Me.txtBillDate.Location = New System.Drawing.Point(508, 42)
        Me.txtBillDate.Name = "txtBillDate"
        Me.txtBillDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBillDate.Size = New System.Drawing.Size(274, 32)
        Me.txtBillDate.TabIndex = 21
        Me.txtBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.Transparent
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtAmount.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtAmount.Location = New System.Drawing.Point(38, 48)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(154, 60)
        Me.txtAmount.TabIndex = 20
        Me.txtAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctlPaltelBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtBillDueDate)
        Me.Controls.Add(Me.txtBillDate)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.btnSelectUnSelect)
        Me.Controls.Add(Me.picUnselected)
        Me.Controls.Add(Me.picSelected)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ctlPaltelBill"
        Me.Size = New System.Drawing.Size(914, 156)
        CType(Me.picUnselected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picUnselected As PictureBox
    Friend WithEvents picSelected As PictureBox
    Friend WithEvents btnSelectUnSelect As Label
    Friend WithEvents txtBillDueDate As Label
    Friend WithEvents txtBillDate As Label
    Friend WithEvents txtAmount As Label
End Class
