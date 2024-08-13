<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnCoinBack = New System.Windows.Forms.Label()
        Me.btnPLUS = New System.Windows.Forms.Label()
        Me.btnDigitalGoods = New System.Windows.Forms.Label()
        Me.btnBundles = New System.Windows.Forms.Label()
        Me.btnPaltelBillPayment = New System.Windows.Forms.Label()
        Me.btnJawwalBillPayment = New System.Windows.Forms.Label()
        Me.btnTopUp = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.Home_Edit
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.btnCoinBack)
        Me.pnlWA.Controls.Add(Me.btnPLUS)
        Me.pnlWA.Controls.Add(Me.btnDigitalGoods)
        Me.pnlWA.Controls.Add(Me.btnBundles)
        Me.pnlWA.Controls.Add(Me.btnPaltelBillPayment)
        Me.pnlWA.Controls.Add(Me.btnJawwalBillPayment)
        Me.pnlWA.Controls.Add(Me.btnTopUp)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 0
        '
        'btnCoinBack
        '
        Me.btnCoinBack.BackColor = System.Drawing.Color.Transparent
        Me.btnCoinBack.Location = New System.Drawing.Point(99, 824)
        Me.btnCoinBack.Name = "btnCoinBack"
        Me.btnCoinBack.Size = New System.Drawing.Size(304, 119)
        Me.btnCoinBack.TabIndex = 8
        '
        'btnPLUS
        '
        Me.btnPLUS.BackColor = System.Drawing.Color.Transparent
        Me.btnPLUS.Location = New System.Drawing.Point(644, 554)
        Me.btnPLUS.Name = "btnPLUS"
        Me.btnPLUS.Size = New System.Drawing.Size(535, 89)
        Me.btnPLUS.TabIndex = 7
        '
        'btnDigitalGoods
        '
        Me.btnDigitalGoods.BackColor = System.Drawing.Color.Transparent
        Me.btnDigitalGoods.Location = New System.Drawing.Point(644, 278)
        Me.btnDigitalGoods.Name = "btnDigitalGoods"
        Me.btnDigitalGoods.Size = New System.Drawing.Size(264, 270)
        Me.btnDigitalGoods.TabIndex = 4
        '
        'btnBundles
        '
        Me.btnBundles.BackColor = System.Drawing.Color.Transparent
        Me.btnBundles.Location = New System.Drawing.Point(917, 278)
        Me.btnBundles.Name = "btnBundles"
        Me.btnBundles.Size = New System.Drawing.Size(264, 270)
        Me.btnBundles.TabIndex = 3
        '
        'btnPaltelBillPayment
        '
        Me.btnPaltelBillPayment.BackColor = System.Drawing.Color.Transparent
        Me.btnPaltelBillPayment.Location = New System.Drawing.Point(99, 555)
        Me.btnPaltelBillPayment.Name = "btnPaltelBillPayment"
        Me.btnPaltelBillPayment.Size = New System.Drawing.Size(535, 89)
        Me.btnPaltelBillPayment.TabIndex = 2
        '
        'btnJawwalBillPayment
        '
        Me.btnJawwalBillPayment.BackColor = System.Drawing.Color.Transparent
        Me.btnJawwalBillPayment.Location = New System.Drawing.Point(99, 278)
        Me.btnJawwalBillPayment.Name = "btnJawwalBillPayment"
        Me.btnJawwalBillPayment.Size = New System.Drawing.Size(259, 270)
        Me.btnJawwalBillPayment.TabIndex = 1
        '
        'btnTopUp
        '
        Me.btnTopUp.BackColor = System.Drawing.Color.Transparent
        Me.btnTopUp.Location = New System.Drawing.Point(371, 278)
        Me.btnTopUp.Name = "btnTopUp"
        Me.btnTopUp.Size = New System.Drawing.Size(264, 270)
        Me.btnTopUp.TabIndex = 0
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmMenu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnTopUp As Label
    Friend WithEvents btnJawwalBillPayment As Label
    Friend WithEvents btnPaltelBillPayment As Label
    Friend WithEvents btnBundles As Label
    Friend WithEvents btnDigitalGoods As Label
    Friend WithEvents btnPLUS As Label
    Friend WithEvents btnCoinBack As Label
End Class
