<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSIMSwap9
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap9))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.txtEmailAddress = New System.Windows.Forms.Label()
        Me.kbKeyboard = New VMAgent.ctlKeyboard()
        Me.btnBack1 = New System.Windows.Forms.Label()
        Me.btnBack2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.txtEmailAddress)
        Me.pnlWA.Controls.Add(Me.kbKeyboard)
        Me.pnlWA.Controls.Add(Me.btnBack1)
        Me.pnlWA.Controls.Add(Me.btnBack2)
        Me.pnlWA.Controls.Add(Me.btnOK)
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
        Me.txtEmailAddress.Location = New System.Drawing.Point(309, 324)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(664, 60)
        Me.txtEmailAddress.TabIndex = 141
        Me.txtEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kbKeyboard
        '
        Me.kbKeyboard.BackColor = System.Drawing.Color.White
        Me.kbKeyboard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.kbKeyboard.Location = New System.Drawing.Point(0, 567)
        Me.kbKeyboard.Name = "kbKeyboard"
        Me.kbKeyboard.Size = New System.Drawing.Size(1280, 457)
        Me.kbKeyboard.TabIndex = 140
        '
        'btnBack1
        '
        Me.btnBack1.BackColor = System.Drawing.Color.Transparent
        Me.btnBack1.Location = New System.Drawing.Point(999, 76)
        Me.btnBack1.Name = "btnBack1"
        Me.btnBack1.Size = New System.Drawing.Size(184, 76)
        Me.btnBack1.TabIndex = 138
        '
        'btnBack2
        '
        Me.btnBack2.BackColor = System.Drawing.Color.Transparent
        Me.btnBack2.Location = New System.Drawing.Point(99, 478)
        Me.btnBack2.Name = "btnBack2"
        Me.btnBack2.Size = New System.Drawing.Size(533, 77)
        Me.btnBack2.TabIndex = 102
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(648, 478)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(534, 76)
        Me.btnOK.TabIndex = 101
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
        Me.lblErrorDescription.TabIndex = 142
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmSIMSwap9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSIMSwap9"
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
