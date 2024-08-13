<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlJawwalBill
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlJawwalBill))
        Me.picSelected = New System.Windows.Forms.PictureBox()
        Me.picUnselected = New System.Windows.Forms.PictureBox()
        Me.txtAmountToPay = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.Label()
        Me.txtBillDate = New System.Windows.Forms.Label()
        Me.txtBillDueDate = New System.Windows.Forms.Label()
        Me.btnSelectUnSelect = New System.Windows.Forms.Label()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picUnselected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picSelected
        '
        Me.picSelected.Image = CType(resources.GetObject("picSelected.Image"), System.Drawing.Image)
        Me.picSelected.Location = New System.Drawing.Point(356, 15)
        Me.picSelected.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picSelected.Name = "picSelected"
        Me.picSelected.Size = New System.Drawing.Size(18, 14)
        Me.picSelected.TabIndex = 0
        Me.picSelected.TabStop = False
        Me.picSelected.Visible = False
        '
        'picUnselected
        '
        Me.picUnselected.Image = CType(resources.GetObject("picUnselected.Image"), System.Drawing.Image)
        Me.picUnselected.Location = New System.Drawing.Point(356, 34)
        Me.picUnselected.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picUnselected.Name = "picUnselected"
        Me.picUnselected.Size = New System.Drawing.Size(18, 16)
        Me.picUnselected.TabIndex = 1
        Me.picUnselected.TabStop = False
        Me.picUnselected.Visible = False
        '
        'txtAmountToPay
        '
        Me.txtAmountToPay.BackColor = System.Drawing.Color.Transparent
        Me.txtAmountToPay.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtAmountToPay.ForeColor = System.Drawing.Color.Silver
        Me.txtAmountToPay.Location = New System.Drawing.Point(102, 48)
        Me.txtAmountToPay.Name = "txtAmountToPay"
        Me.txtAmountToPay.Size = New System.Drawing.Size(154, 60)
        Me.txtAmountToPay.TabIndex = 14
        Me.txtAmountToPay.Text = "0"
        Me.txtAmountToPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.Transparent
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtAmount.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtAmount.Location = New System.Drawing.Point(401, 48)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(154, 60)
        Me.txtAmount.TabIndex = 15
        Me.txtAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBillDate
        '
        Me.txtBillDate.BackColor = System.Drawing.Color.Transparent
        Me.txtBillDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDate.ForeColor = System.Drawing.Color.Black
        Me.txtBillDate.Location = New System.Drawing.Point(696, 45)
        Me.txtBillDate.Name = "txtBillDate"
        Me.txtBillDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBillDate.Size = New System.Drawing.Size(274, 32)
        Me.txtBillDate.TabIndex = 16
        Me.txtBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBillDueDate
        '
        Me.txtBillDueDate.BackColor = System.Drawing.Color.Transparent
        Me.txtBillDueDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDueDate.ForeColor = System.Drawing.Color.Gray
        Me.txtBillDueDate.Location = New System.Drawing.Point(696, 78)
        Me.txtBillDueDate.Name = "txtBillDueDate"
        Me.txtBillDueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBillDueDate.Size = New System.Drawing.Size(274, 32)
        Me.txtBillDueDate.TabIndex = 17
        Me.txtBillDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSelectUnSelect
        '
        Me.btnSelectUnSelect.BackColor = System.Drawing.Color.Transparent
        Me.btnSelectUnSelect.Location = New System.Drawing.Point(984, 48)
        Me.btnSelectUnSelect.Name = "btnSelectUnSelect"
        Me.btnSelectUnSelect.Size = New System.Drawing.Size(60, 60)
        Me.btnSelectUnSelect.TabIndex = 18
        '
        'ctlJawwalBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnSelectUnSelect)
        Me.Controls.Add(Me.txtBillDueDate)
        Me.Controls.Add(Me.txtBillDate)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtAmountToPay)
        Me.Controls.Add(Me.picUnselected)
        Me.Controls.Add(Me.picSelected)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ctlJawwalBill"
        Me.Size = New System.Drawing.Size(1100, 156)
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picUnselected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picSelected As PictureBox
    Friend WithEvents picUnselected As PictureBox
    Friend WithEvents txtAmountToPay As Label
    Friend WithEvents txtAmount As Label
    Friend WithEvents txtBillDate As Label
    Friend WithEvents txtBillDueDate As Label
    Friend WithEvents btnSelectUnSelect As Label
End Class
