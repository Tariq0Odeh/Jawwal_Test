<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBundles2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles2))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btn3G = New System.Windows.Forms.Label()
        Me.btnMinutes = New System.Windows.Forms.Label()
        Me.btnRoaming = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btn3G)
        Me.pnlWA.Controls.Add(Me.btnMinutes)
        Me.pnlWA.Controls.Add(Me.btnRoaming)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 7
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 76)
        Me.btnBack.TabIndex = 3
        '
        'btn3G
        '
        Me.btn3G.BackColor = System.Drawing.Color.Transparent
        Me.btn3G.Location = New System.Drawing.Point(831, 436)
        Me.btn3G.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btn3G.Name = "btn3G"
        Me.btn3G.Size = New System.Drawing.Size(350, 235)
        Me.btn3G.TabIndex = 2
        '
        'btnMinutes
        '
        Me.btnMinutes.BackColor = System.Drawing.Color.Transparent
        Me.btnMinutes.Location = New System.Drawing.Point(465, 436)
        Me.btnMinutes.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnMinutes.Name = "btnMinutes"
        Me.btnMinutes.Size = New System.Drawing.Size(350, 235)
        Me.btnMinutes.TabIndex = 1
        '
        'btnRoaming
        '
        Me.btnRoaming.BackColor = System.Drawing.Color.Transparent
        Me.btnRoaming.Location = New System.Drawing.Point(98, 436)
        Me.btnRoaming.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnRoaming.Name = "btnRoaming"
        Me.btnRoaming.Size = New System.Drawing.Size(350, 235)
        Me.btnRoaming.TabIndex = 0
        '
        'frmBundles2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmBundles2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents btn3G As Label
    Friend WithEvents btnMinutes As Label
    Friend WithEvents btnRoaming As Label
End Class
