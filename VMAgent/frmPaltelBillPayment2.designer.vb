<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaltelBillPayment2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaltelBillPayment2))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnCash = New System.Windows.Forms.Label()
        Me.btnReflect = New System.Windows.Forms.Label()
        Me.btnCreditCard = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.btnCash)
        Me.pnlWA.Controls.Add(Me.btnReflect)
        Me.pnlWA.Controls.Add(Me.btnCreditCard)
        Me.pnlWA.Controls.Add(Me.txtAmount)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 6
        '
        'btnCash
        '
        Me.btnCash.BackColor = System.Drawing.Color.Transparent
        Me.btnCash.Location = New System.Drawing.Point(831, 477)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(350, 200)
        Me.btnCash.TabIndex = 13
        '
        'btnReflect
        '
        Me.btnReflect.BackColor = System.Drawing.Color.Transparent
        Me.btnReflect.Location = New System.Drawing.Point(464, 477)
        Me.btnReflect.Name = "btnReflect"
        Me.btnReflect.Size = New System.Drawing.Size(350, 200)
        Me.btnReflect.TabIndex = 12
        '
        'btnCreditCard
        '
        Me.btnCreditCard.BackColor = System.Drawing.Color.Transparent
        Me.btnCreditCard.Location = New System.Drawing.Point(99, 477)
        Me.btnCreditCard.Name = "btnCreditCard"
        Me.btnCreditCard.Size = New System.Drawing.Size(350, 200)
        Me.btnCreditCard.TabIndex = 11
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.Transparent
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtAmount.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtAmount.Location = New System.Drawing.Point(482, 259)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(317, 60)
        Me.txtAmount.TabIndex = 10
        Me.txtAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 76)
        Me.btnBack.TabIndex = 9
        '
        'frmPaltelBillPayment2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmPaltelBillPayment2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents txtAmount As Label
    Friend WithEvents btnCash As Label
    Friend WithEvents btnReflect As Label
    Friend WithEvents btnCreditCard As Label
End Class
