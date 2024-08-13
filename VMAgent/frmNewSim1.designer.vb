<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSim1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim1))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.pnlMsisdns = New System.Windows.Forms.Panel()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.pnlMsisdns)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 17
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(189, 816)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(441, 76)
        Me.btnBack.TabIndex = 16
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(649, 816)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(441, 76)
        Me.btnOK.TabIndex = 15
        '
        'pnlMsisdns
        '
        Me.pnlMsisdns.AutoScroll = True
        Me.pnlMsisdns.BackColor = System.Drawing.Color.Transparent
        Me.pnlMsisdns.Location = New System.Drawing.Point(181, 240)
        Me.pnlMsisdns.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlMsisdns.Name = "pnlMsisdns"
        Me.pnlMsisdns.Size = New System.Drawing.Size(905, 527)
        Me.pnlMsisdns.TabIndex = 14
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 209)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 167
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmNewSim1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmNewSim1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents pnlMsisdns As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents lblErrorDescription As Label
End Class
