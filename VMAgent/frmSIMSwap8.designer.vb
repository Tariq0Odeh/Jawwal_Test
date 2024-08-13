<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSIMSwap8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap8))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnESIM = New System.Windows.Forms.Label()
        Me.btnNormalSIM = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.btnNormalSIM)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnESIM)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 1
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(184, 76)
        Me.btnBack.TabIndex = 38
        '
        'btnESIM
        '
        Me.btnESIM.BackColor = System.Drawing.Color.Transparent
        Me.btnESIM.Location = New System.Drawing.Point(648, 385)
        Me.btnESIM.Name = "btnESIM"
        Me.btnESIM.Size = New System.Drawing.Size(443, 236)
        Me.btnESIM.TabIndex = 37
        '
        'btnNormalSIM
        '
        Me.btnNormalSIM.BackColor = System.Drawing.Color.Transparent
        Me.btnNormalSIM.Location = New System.Drawing.Point(190, 385)
        Me.btnNormalSIM.Name = "btnNormalSIM"
        Me.btnNormalSIM.Size = New System.Drawing.Size(443, 236)
        Me.btnNormalSIM.TabIndex = 39
        '
        'frmSIMSwap8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSIMSwap8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnESIM As Label
    Friend WithEvents btnBack As Label
    Friend WithEvents btnNormalSIM As Label
End Class
