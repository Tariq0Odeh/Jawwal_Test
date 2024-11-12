<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSim4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim4))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.cbPackage = New System.Windows.Forms.ComboBox()
        Me.cbMsisdnType = New System.Windows.Forms.ComboBox()
        Me.cbSIMType = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.cbPackage)
        Me.pnlWA.Controls.Add(Me.cbMsisdnType)
        Me.pnlWA.Controls.Add(Me.cbSIMType)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 22
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 260)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 171
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbPackage
        '
        Me.cbPackage.BackColor = System.Drawing.Color.White
        Me.cbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPackage.Enabled = False
        Me.cbPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPackage.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPackage.FormattingEnabled = True
        Me.cbPackage.Location = New System.Drawing.Point(311, 546)
        Me.cbPackage.Name = "cbPackage"
        Me.cbPackage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbPackage.Size = New System.Drawing.Size(654, 53)
        Me.cbPackage.TabIndex = 170
        '
        'cbMsisdnType
        '
        Me.cbMsisdnType.BackColor = System.Drawing.Color.White
        Me.cbMsisdnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMsisdnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMsisdnType.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMsisdnType.FormattingEnabled = True
        Me.cbMsisdnType.Location = New System.Drawing.Point(311, 450)
        Me.cbMsisdnType.Name = "cbMsisdnType"
        Me.cbMsisdnType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbMsisdnType.Size = New System.Drawing.Size(654, 53)
        Me.cbMsisdnType.TabIndex = 169
        '
        'cbSIMType
        '
        Me.cbSIMType.BackColor = System.Drawing.Color.White
        Me.cbSIMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSIMType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSIMType.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSIMType.FormattingEnabled = True
        Me.cbSIMType.Location = New System.Drawing.Point(311, 355)
        Me.cbSIMType.Name = "cbSIMType"
        Me.cbSIMType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbSIMType.Size = New System.Drawing.Size(654, 53)
        Me.cbSIMType.TabIndex = 168
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(648, 818)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(534, 76)
        Me.btnOK.TabIndex = 5
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(99, 818)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(534, 76)
        Me.btnBack.TabIndex = 4
        '
        'frmNewSim4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmNewSim4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents cbPackage As ComboBox
    Friend WithEvents cbMsisdnType As ComboBox
    Friend WithEvents cbSIMType As ComboBox
    Friend WithEvents lblErrorDescription As Label
End Class
