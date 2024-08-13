<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBundles6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles6))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.txtAmount = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnBalance = New System.Windows.Forms.Label()
        Me.btnCash = New System.Windows.Forms.Label()
        Me.btnReflect = New System.Windows.Forms.Label()
        Me.btnCreditCard = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.txtAmount)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnBalance)
        Me.pnlWA.Controls.Add(Me.btnCash)
        Me.pnlWA.Controls.Add(Me.btnReflect)
        Me.pnlWA.Controls.Add(Me.btnCreditCard)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 6
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.Transparent
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtAmount.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtAmount.Location = New System.Drawing.Point(482, 259)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(317, 60)
        Me.txtAmount.TabIndex = 11
        Me.txtAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 76)
        Me.btnBack.TabIndex = 5
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBalance
        '
        Me.btnBalance.BackColor = System.Drawing.Color.Transparent
        Me.btnBalance.Location = New System.Drawing.Point(923, 534)
        Me.btnBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnBalance.Name = "btnBalance"
        Me.btnBalance.Size = New System.Drawing.Size(259, 164)
        Me.btnBalance.TabIndex = 4
        Me.btnBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCash
        '
        Me.btnCash.BackColor = System.Drawing.Color.Transparent
        Me.btnCash.Location = New System.Drawing.Point(648, 534)
        Me.btnCash.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(259, 164)
        Me.btnCash.TabIndex = 3
        Me.btnCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReflect
        '
        Me.btnReflect.BackColor = System.Drawing.Color.Transparent
        Me.btnReflect.Location = New System.Drawing.Point(373, 534)
        Me.btnReflect.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnReflect.Name = "btnReflect"
        Me.btnReflect.Size = New System.Drawing.Size(259, 164)
        Me.btnReflect.TabIndex = 2
        Me.btnReflect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCreditCard
        '
        Me.btnCreditCard.BackColor = System.Drawing.Color.Transparent
        Me.btnCreditCard.Location = New System.Drawing.Point(98, 534)
        Me.btnCreditCard.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnCreditCard.Name = "btnCreditCard"
        Me.btnCreditCard.Size = New System.Drawing.Size(259, 164)
        Me.btnCreditCard.TabIndex = 1
        Me.btnCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmBundles6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmBundles6"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents btnBalance As Label
    Friend WithEvents btnCash As Label
    Friend WithEvents btnReflect As Label
    Friend WithEvents btnCreditCard As Label
    Friend WithEvents txtAmount As Label
End Class
