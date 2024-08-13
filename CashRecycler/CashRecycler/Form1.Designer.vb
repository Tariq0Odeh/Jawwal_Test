<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtAddedMoney = New System.Windows.Forms.TextBox()
        Me.txtReturned = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnMoveToCashOut = New System.Windows.Forms.Button()
        Me.txtCashIn = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Open"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(14, 112)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Accept Money"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(161, 231)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 29)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Returned"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtAddedMoney
        '
        Me.txtAddedMoney.Enabled = False
        Me.txtAddedMoney.Location = New System.Drawing.Point(161, 114)
        Me.txtAddedMoney.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddedMoney.Name = "txtAddedMoney"
        Me.txtAddedMoney.Size = New System.Drawing.Size(140, 26)
        Me.txtAddedMoney.TabIndex = 3
        Me.txtAddedMoney.Text = "0"
        '
        'txtReturned
        '
        Me.txtReturned.Location = New System.Drawing.Point(14, 231)
        Me.txtReturned.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtReturned.Name = "txtReturned"
        Me.txtReturned.Size = New System.Drawing.Size(84, 26)
        Me.txtReturned.TabIndex = 4
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(161, 15)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 24)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.Text = "Cash"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(258, 15)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(66, 24)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.Text = "Coin"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(339, 15)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(140, 24)
        Me.RadioButton3.TabIndex = 5
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Cash And Coin"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(360, 112)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(84, 29)
        Me.btnStop.TabIndex = 6
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnMoveToCashOut
        '
        Me.btnMoveToCashOut.Location = New System.Drawing.Point(12, 327)
        Me.btnMoveToCashOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMoveToCashOut.Name = "btnMoveToCashOut"
        Me.btnMoveToCashOut.Size = New System.Drawing.Size(290, 29)
        Me.btnMoveToCashOut.TabIndex = 2
        Me.btnMoveToCashOut.Text = "Move Cash To OutBox"
        Me.btnMoveToCashOut.UseVisualStyleBackColor = True
        '
        'txtCashIn
        '
        Me.txtCashIn.Enabled = False
        Me.txtCashIn.Location = New System.Drawing.Point(172, 155)
        Me.txtCashIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCashIn.Name = "txtCashIn"
        Me.txtCashIn.Size = New System.Drawing.Size(140, 26)
        Me.txtCashIn.TabIndex = 3
        Me.txtCashIn.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1231, 579)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.txtReturned)
        Me.Controls.Add(Me.txtCashIn)
        Me.Controls.Add(Me.txtAddedMoney)
        Me.Controls.Add(Me.btnMoveToCashOut)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents txtAddedMoney As TextBox
    Friend WithEvents txtReturned As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents btnStop As Button
    Friend WithEvents btnMoveToCashOut As Button
    Friend WithEvents txtCashIn As TextBox
End Class
