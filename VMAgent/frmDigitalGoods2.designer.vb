<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDigitalGoods2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalGoods2))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.pnlBrands = New FlickerFreeFlowLayoutPanel
        Me.btnBack = New System.Windows.Forms.Label()
        Me.pnlBrandsHolder = New System.Windows.Forms.Panel()
        Me.pnlWA.SuspendLayout()
        Me.pnlBrandsHolder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.pnlBrandsHolder)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 7
        '
        'pnlBrands
        '
        Me.pnlBrands.AutoScroll = True
        Me.pnlBrands.BackColor = System.Drawing.Color.Transparent
        Me.pnlBrands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlBrands.Location = New System.Drawing.Point(0, 0)
        Me.pnlBrands.Name = "pnlBrands"
        Me.pnlBrands.Size = New System.Drawing.Size(1200, 687)
        Me.pnlBrands.TabIndex = 11
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(1000, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(182, 76)
        Me.btnBack.TabIndex = 10
        '
        'pnlBrandsHolder
        '
        Me.pnlBrandsHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlBrandsHolder.Controls.Add(Me.pnlBrands)
        Me.pnlBrandsHolder.Location = New System.Drawing.Point(40, 231)
        Me.pnlBrandsHolder.Name = "pnlBrandsHolder"
        Me.pnlBrandsHolder.Size = New System.Drawing.Size(1200, 687)
        Me.pnlBrandsHolder.TabIndex = 12
        '
        'frmDigitalGoods2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmDigitalGoods2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlBrandsHolder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents pnlBrands As FlickerFreeFlowLayoutPanel
    Friend WithEvents pnlBrandsHolder As Panel
End Class
