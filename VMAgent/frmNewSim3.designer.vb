<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSim3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim3))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.txtIdNumber = New System.Windows.Forms.Label()
        Me.cbCity = New System.Windows.Forms.ComboBox()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.cbRegion = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.kbKeyboard = New VMAgent.ctlKeyboard()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.dtpDateOfBirth)
        Me.pnlWA.Controls.Add(Me.kbKeyboard)
        Me.pnlWA.Controls.Add(Me.txtIdNumber)
        Me.pnlWA.Controls.Add(Me.cbCity)
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.cbRegion)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.txtFullName)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Location = New System.Drawing.Point(0, 11)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 15
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Tahoma", 27.75!)
        Me.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(856, 380)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dtpDateOfBirth.RightToLeftLayout = True
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(302, 52)
        Me.dtpDateOfBirth.TabIndex = 170
        '
        'txtIdNumber
        '
        Me.txtIdNumber.BackColor = System.Drawing.Color.Transparent
        Me.txtIdNumber.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtIdNumber.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtIdNumber.Location = New System.Drawing.Point(133, 279)
        Me.txtIdNumber.Name = "txtIdNumber"
        Me.txtIdNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIdNumber.Size = New System.Drawing.Size(467, 60)
        Me.txtIdNumber.TabIndex = 168
        Me.txtIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbCity
        '
        Me.cbCity.BackColor = System.Drawing.Color.White
        Me.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCity.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCity.FormattingEnabled = True
        Me.cbCity.Location = New System.Drawing.Point(129, 380)
        Me.cbCity.Name = "cbCity"
        Me.cbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbCity.Size = New System.Drawing.Size(296, 53)
        Me.cbCity.TabIndex = 167
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 242)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 166
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbRegion
        '
        Me.cbRegion.BackColor = System.Drawing.Color.White
        Me.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbRegion.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRegion.FormattingEnabled = True
        Me.cbRegion.Location = New System.Drawing.Point(493, 380)
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbRegion.Size = New System.Drawing.Size(294, 53)
        Me.cbRegion.TabIndex = 105
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(648, 478)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(533, 76)
        Me.btnOK.TabIndex = 28
        '
        'txtFullName
        '
        Me.txtFullName.AutoEllipsis = True
        Me.txtFullName.BackColor = System.Drawing.Color.Transparent
        Me.txtFullName.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtFullName.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtFullName.Location = New System.Drawing.Point(679, 279)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFullName.Size = New System.Drawing.Size(467, 60)
        Me.txtFullName.TabIndex = 16
        Me.txtFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(98, 478)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(533, 76)
        Me.btnBack.TabIndex = 15
        '
        'kbKeyboard
        '
        Me.kbKeyboard.BackColor = System.Drawing.Color.White
        Me.kbKeyboard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.kbKeyboard.Location = New System.Drawing.Point(0, 567)
        Me.kbKeyboard.Name = "kbKeyboard"
        Me.kbKeyboard.Size = New System.Drawing.Size(1280, 457)
        Me.kbKeyboard.TabIndex = 169
        '
        'frmNewSim3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmNewSim3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnOK As Label
    Friend WithEvents txtFullName As Label
    Friend WithEvents btnBack As Label
    Friend WithEvents cbRegion As ComboBox
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents cbCity As ComboBox
    Friend WithEvents txtIdNumber As Label
    Friend WithEvents kbKeyboard As ctlKeyboard
    Friend WithEvents dtpDateOfBirth As DateTimePicker
End Class
