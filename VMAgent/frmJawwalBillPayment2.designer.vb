﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJawwalBillPayment2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJawwalBillPayment2))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.pnlBills = New FlickerFreePanel
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.txtTotalBills = New System.Windows.Forms.Label()
        Me.pnlBillsHolder = New System.Windows.Forms.Panel()
        Me.pnlWA.SuspendLayout()
        Me.pnlBillsHolder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.Controls.Add(Me.pnlBillsHolder)
        Me.pnlWA.Controls.Add(Me.lblErrorDescription)
        Me.pnlWA.Controls.Add(Me.btnBack)
        Me.pnlWA.Controls.Add(Me.btnOK)
        Me.pnlWA.Controls.Add(Me.txtTotalBills)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 4
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.Red
        Me.lblErrorDescription.Location = New System.Drawing.Point(371, 349)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblErrorDescription.Size = New System.Drawing.Size(531, 23)
        Me.lblErrorDescription.TabIndex = 16
        Me.lblErrorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlBills
        '
        Me.pnlBills.AutoScroll = True
        Me.pnlBills.BackColor = System.Drawing.Color.Transparent
        Me.pnlBills.Location = New System.Drawing.Point(0, 0)
        Me.pnlBills.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlBills.Name = "pnlBills"
        Me.pnlBills.Size = New System.Drawing.Size(1100, 410)
        Me.pnlBills.TabIndex = 13
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(98, 816)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(534, 76)
        Me.btnBack.TabIndex = 10
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(648, 816)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(535, 76)
        Me.btnOK.TabIndex = 9
        '
        'txtTotalBills
        '
        Me.txtTotalBills.BackColor = System.Drawing.Color.Transparent
        Me.txtTotalBills.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Bold)
        Me.txtTotalBills.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtTotalBills.Location = New System.Drawing.Point(455, 259)
        Me.txtTotalBills.Name = "txtTotalBills"
        Me.txtTotalBills.Size = New System.Drawing.Size(368, 60)
        Me.txtTotalBills.TabIndex = 0
        Me.txtTotalBills.Text = "0"
        Me.txtTotalBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBillsHolder
        '
        Me.pnlBillsHolder.BackColor = System.Drawing.Color.Transparent
        Me.pnlBillsHolder.Controls.Add(Me.pnlBills)
        Me.pnlBillsHolder.Location = New System.Drawing.Point(90, 390)
        Me.pnlBillsHolder.Name = "pnlBillsHolder"
        Me.pnlBillsHolder.Size = New System.Drawing.Size(1100, 410)
        Me.pnlBillsHolder.TabIndex = 17
        '
        'frmJawwalBillPayment2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlWA)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmJawwalBillPayment2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        Me.pnlBillsHolder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents txtTotalBills As Label
    Friend WithEvents btnBack As Label
    Friend WithEvents btnOK As Label
    Friend WithEvents pnlBills As FlickerFreePanel
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents pnlBillsHolder As Panel
End Class
