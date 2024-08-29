<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSim8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim8))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnMainMenu = New System.Windows.Forms.Label()
        Me.lblSuccessOnPostOrMix = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblSuccessOnPostOrMix)
        Me.pnlWA.Controls.Add(Me.btnMainMenu)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 7
        '
        'btnMainMenu
        '
        Me.btnMainMenu.BackColor = System.Drawing.Color.Transparent
        Me.btnMainMenu.Location = New System.Drawing.Point(373, 650)
        Me.btnMainMenu.Name = "btnMainMenu"
        Me.btnMainMenu.Size = New System.Drawing.Size(533, 76)
        Me.btnMainMenu.TabIndex = 0
        '
        'lblSuccessOnPostOrMix
        '
        Me.lblSuccessOnPostOrMix.AutoSize = True
        Me.lblSuccessOnPostOrMix.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSuccessOnPostOrMix.Font = New System.Drawing.Font("Showcard Gothic", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuccessOnPostOrMix.Location = New System.Drawing.Point(466, 768)
        Me.lblSuccessOnPostOrMix.Name = "lblSuccessOnPostOrMix"
        Me.lblSuccessOnPostOrMix.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSuccessOnPostOrMix.Size = New System.Drawing.Size(1061, 124)
        Me.lblSuccessOnPostOrMix.TabIndex = 1
        Me.lblSuccessOnPostOrMix.Text = "مشتركنا العزيز، تم تقديم طلب الحصول على فاتورة بنجاح" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " وسيتم التواصل معك خلال 48 " &
    "ساعة عمل. نتمنى لك يوماً سعيداً"
        Me.lblSuccessOnPostOrMix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmNewSim8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmNewSim8"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlWA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnMainMenu As Label
    Friend WithEvents lblSuccessOnPostOrMix As Label
End Class
