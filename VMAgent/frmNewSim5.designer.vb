﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSim5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim5))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.Label()
        Me.kbKeyboard = New VMAgent.ctlKeyboard()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.txtContactNumber)
        Me.pnlWA.Controls.Add(Me.txtEmailAddress)
        Me.pnlWA.Controls.Add(Me.kbKeyboard)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 22
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(99, 459)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(533, 76)
        Me.btnBack.TabIndex = 30
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(647, 459)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(533, 76)
        Me.btnOK.TabIndex = 29
        '
        'txtContactNumber
        '
        Me.txtContactNumber.AutoEllipsis = True
        Me.txtContactNumber.BackColor = System.Drawing.Color.Transparent
        Me.txtContactNumber.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtContactNumber.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtContactNumber.Location = New System.Drawing.Point(132, 298)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtContactNumber.Size = New System.Drawing.Size(467, 60)
        Me.txtContactNumber.TabIndex = 18
        Me.txtContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.AutoEllipsis = True
        Me.txtEmailAddress.BackColor = System.Drawing.Color.Transparent
        Me.txtEmailAddress.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtEmailAddress.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtEmailAddress.Location = New System.Drawing.Point(683, 298)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEmailAddress.Size = New System.Drawing.Size(467, 60)
        Me.txtEmailAddress.TabIndex = 17
        Me.txtEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kbKeyboard
        '
        Me.kbKeyboard.BackColor = System.Drawing.Color.White
        Me.kbKeyboard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.kbKeyboard.Location = New System.Drawing.Point(0, 567)
        Me.kbKeyboard.Name = "kbKeyboard"
        Me.kbKeyboard.Size = New System.Drawing.Size(1280, 457)
        Me.kbKeyboard.TabIndex = 0
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(375, 221)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 172
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmNewSim5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmNewSim5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents kbKeyboard As ctlKeyboard
    Friend WithEvents txtContactNumber As Label
    Friend WithEvents txtEmailAddress As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents btnBack As Label
    Friend WithEvents lblErrorDescription As Label
End Class
