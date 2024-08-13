<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSIMSwap4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap4))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.txtEmailAddress = New System.Windows.Forms.Label()
        Me.kbKeyboard = New VMAgent.ctlKeyboard()
        Me.btnBack2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.btnBack1 = New System.Windows.Forms.Label()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.txtEmailAddress)
        Me.pnlWA.Controls.Add(Me.kbKeyboard)
        Me.pnlWA.Controls.Add(Me.btnBack2)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.btnBack1)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 1
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.BackColor = System.Drawing.Color.Transparent
        Me.txtEmailAddress.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtEmailAddress.Location = New System.Drawing.Point(304, 325)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(672, 60)
        Me.txtEmailAddress.TabIndex = 67
        Me.txtEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kbKeyboard
        '
        Me.kbKeyboard.BackColor = System.Drawing.Color.White
        Me.kbKeyboard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.kbKeyboard.Location = New System.Drawing.Point(0, 567)
        Me.kbKeyboard.Name = "kbKeyboard"
        Me.kbKeyboard.Size = New System.Drawing.Size(1280, 457)
        Me.kbKeyboard.TabIndex = 66
        '
        'btnBack2
        '
        Me.btnBack2.BackColor = System.Drawing.Color.Transparent
        Me.btnBack2.Location = New System.Drawing.Point(97, 478)
        Me.btnBack2.Name = "btnBack2"
        Me.btnBack2.Size = New System.Drawing.Size(535, 76)
        Me.btnBack2.TabIndex = 30
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(648, 478)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(535, 76)
        Me.btnOK.TabIndex = 29
        '
        'btnBack1
        '
        Me.btnBack1.BackColor = System.Drawing.Color.Transparent
        Me.btnBack1.Location = New System.Drawing.Point(999, 76)
        Me.btnBack1.Name = "btnBack1"
        Me.btnBack1.Size = New System.Drawing.Size(183, 76)
        Me.btnBack1.TabIndex = 28
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 283)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 68
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmSIMSwap4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSIMSwap4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack2 As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents btnBack1 As Label
    Friend WithEvents kbKeyboard As ctlKeyboard
    Friend WithEvents txtEmailAddress As Label
    Friend WithEvents lblErrorDescription As Label
End Class
