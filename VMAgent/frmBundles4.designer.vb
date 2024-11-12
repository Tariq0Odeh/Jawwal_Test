<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBundles4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles4))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.pnlNonRenewed = New FlickerFreePanel()
        Me.picNoNoneRenewable = New System.Windows.Forms.PictureBox()
        Me.pnlRenewed = New FlickerFreePanel
        Me.picNoRenewable = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.pnlRenewedHolder = New System.Windows.Forms.Panel()
        Me.pnlNonRenewedHolder = New System.Windows.Forms.Panel()
        Me.pnlWA.SuspendLayout()
        Me.pnlNonRenewed.SuspendLayout()
        CType(Me.picNoNoneRenewable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRenewed.SuspendLayout()
        CType(Me.picNoRenewable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRenewedHolder.SuspendLayout()
        Me.pnlNonRenewedHolder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.pnlNonRenewedHolder)
        Me.pnlWA.Controls.Add(Me.pnlRenewedHolder)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 9
        '
        'pnlNonRenewed
        '
        Me.pnlNonRenewed.AutoScroll = True
        Me.pnlNonRenewed.BackColor = System.Drawing.Color.Transparent
        Me.pnlNonRenewed.Controls.Add(Me.picNoNoneRenewable)
        Me.pnlNonRenewed.Location = New System.Drawing.Point(0, 0)
        Me.pnlNonRenewed.Name = "pnlNonRenewed"
        Me.pnlNonRenewed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlNonRenewed.Size = New System.Drawing.Size(1084, 346)
        Me.pnlNonRenewed.TabIndex = 13
        '
        'picNoNoneRenewable
        '
        Me.picNoNoneRenewable.Location = New System.Drawing.Point(352, 83)
        Me.picNoNoneRenewable.Name = "picNoNoneRenewable"
        Me.picNoNoneRenewable.Size = New System.Drawing.Size(379, 179)
        Me.picNoNoneRenewable.TabIndex = 1
        Me.picNoNoneRenewable.TabStop = False
        '
        'pnlRenewed
        '
        Me.pnlRenewed.AutoScroll = True
        Me.pnlRenewed.BackColor = System.Drawing.Color.Transparent
        Me.pnlRenewed.Controls.Add(Me.picNoRenewable)
        Me.pnlRenewed.Location = New System.Drawing.Point(0, 0)
        Me.pnlRenewed.Name = "pnlRenewed"
        Me.pnlRenewed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlRenewed.Size = New System.Drawing.Size(1084, 346)
        Me.pnlRenewed.TabIndex = 12
        '
        'picNoRenewable
        '
        Me.picNoRenewable.Location = New System.Drawing.Point(370, 79)
        Me.picNoRenewable.Name = "picNoRenewable"
        Me.picNoRenewable.Size = New System.Drawing.Size(344, 188)
        Me.picNoRenewable.TabIndex = 0
        Me.picNoRenewable.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 76)
        Me.btnBack.TabIndex = 11
        '
        'pnlRenewedHolder
        '
        Me.pnlRenewedHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlRenewedHolder.Controls.Add(Me.pnlRenewed)
        Me.pnlRenewedHolder.Location = New System.Drawing.Point(98, 235)
        Me.pnlRenewedHolder.Name = "pnlRenewedHolder"
        Me.pnlRenewedHolder.Size = New System.Drawing.Size(1084, 346)
        Me.pnlRenewedHolder.TabIndex = 14
        '
        'pnlNonRenewedHolder
        '
        Me.pnlNonRenewedHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlNonRenewedHolder.Controls.Add(Me.pnlNonRenewed)
        Me.pnlNonRenewedHolder.Location = New System.Drawing.Point(98, 647)
        Me.pnlNonRenewedHolder.Name = "pnlNonRenewedHolder"
        Me.pnlNonRenewedHolder.Size = New System.Drawing.Size(1084, 346)
        Me.pnlNonRenewedHolder.TabIndex = 15
        '
        'frmBundles4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmBundles4"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlNonRenewed.ResumeLayout(False)
        CType(Me.picNoNoneRenewable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRenewed.ResumeLayout(False)
        CType(Me.picNoRenewable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRenewedHolder.ResumeLayout(False)
        Me.pnlNonRenewedHolder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents pnlRenewed As FlickerFreePanel
    Friend WithEvents pnlNonRenewed As FlickerFreePanel
    Friend WithEvents picNoRenewable As PictureBox
    Friend WithEvents picNoNoneRenewable As PictureBox
    Friend WithEvents pnlRenewedHolder As Panel
    Friend WithEvents pnlNonRenewedHolder As Panel
End Class
