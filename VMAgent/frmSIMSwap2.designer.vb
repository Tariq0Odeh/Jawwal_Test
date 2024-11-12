<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSIMSwap2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap2))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnQuestions = New System.Windows.Forms.Label()
        Me.btnSerialNumber = New System.Windows.Forms.Label()
        Me.btnEmail = New System.Windows.Forms.Label()
        Me.btnPINCode = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnQuestions)
        Me.pnlWA.Controls.Add(Me.btnSerialNumber)
        Me.pnlWA.Controls.Add(Me.btnEmail)
        Me.pnlWA.Controls.Add(Me.btnPINCode)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 2
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 76)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(184, 76)
        Me.btnBack.TabIndex = 146
        '
        'btnQuestions
        '
        Me.btnQuestions.BackColor = System.Drawing.Color.Transparent
        Me.btnQuestions.Location = New System.Drawing.Point(98, 314)
        Me.btnQuestions.Name = "btnQuestions"
        Me.btnQuestions.Size = New System.Drawing.Size(260, 170)
        Me.btnQuestions.TabIndex = 145
        '
        'btnSerialNumber
        '
        Me.btnSerialNumber.BackColor = System.Drawing.Color.Transparent
        Me.btnSerialNumber.Location = New System.Drawing.Point(372, 314)
        Me.btnSerialNumber.Name = "btnSerialNumber"
        Me.btnSerialNumber.Size = New System.Drawing.Size(260, 170)
        Me.btnSerialNumber.TabIndex = 144
        '
        'btnEmail
        '
        Me.btnEmail.BackColor = System.Drawing.Color.Transparent
        Me.btnEmail.Location = New System.Drawing.Point(647, 314)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(260, 170)
        Me.btnEmail.TabIndex = 143
        '
        'btnPINCode
        '
        Me.btnPINCode.BackColor = System.Drawing.Color.Transparent
        Me.btnPINCode.Location = New System.Drawing.Point(922, 314)
        Me.btnPINCode.Name = "btnPINCode"
        Me.btnPINCode.Size = New System.Drawing.Size(260, 170)
        Me.btnPINCode.TabIndex = 0
        '
        'frmSIMSwap2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmSIMSwap2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents btnPINCode As Label
    Friend WithEvents btnQuestions As Label
    Friend WithEvents btnSerialNumber As Label
    Friend WithEvents btnEmail As Label
    Friend WithEvents btnBack As Label
End Class
