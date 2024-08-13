<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVideoRecorder
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideoRecorder))
        Me.pnlWA = New System.Windows.Forms.Panel()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.picVideo = New System.Windows.Forms.PictureBox()
        Me.tmrProgress = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHint = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Label()
        Me.btnStartRecording = New System.Windows.Forms.Label()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.pnlWA.SuspendLayout()
        CType(Me.picVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHint.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWA
        '
        Me.pnlWA.BackgroundImage = CType(resources.GetObject("pnlWA.BackgroundImage"), System.Drawing.Image)
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlWA.Controls.Add(Me.lblTimer)
        Me.pnlWA.Controls.Add(Me.lblNote)
        Me.pnlWA.Controls.Add(Me.picVideo)
        Me.pnlWA.Location = New System.Drawing.Point(0, 0)
        Me.pnlWA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlWA.Name = "pnlWA"
        Me.pnlWA.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlWA.TabIndex = 0
        '
        'lblNote
        '
        Me.lblNote.BackColor = System.Drawing.Color.Transparent
        Me.lblNote.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.Location = New System.Drawing.Point(240, 209)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNote.Size = New System.Drawing.Size(800, 66)
        Me.lblNote.TabIndex = 2
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picVideo
        '
        Me.picVideo.BackColor = System.Drawing.Color.Transparent
        Me.picVideo.Location = New System.Drawing.Point(339, 298)
        Me.picVideo.Name = "picVideo"
        Me.picVideo.Size = New System.Drawing.Size(592, 450)
        Me.picVideo.TabIndex = 0
        Me.picVideo.TabStop = False
        '
        'tmrProgress
        '
        Me.tmrProgress.Interval = 1000
        '
        'pnlHint
        '
        Me.pnlHint.BackgroundImage = CType(resources.GetObject("pnlHint.BackgroundImage"), System.Drawing.Image)
        Me.pnlHint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHint.Controls.Add(Me.btnStartRecording)
        Me.pnlHint.Controls.Add(Me.btnBack)
        Me.pnlHint.Location = New System.Drawing.Point(0, 0)
        Me.pnlHint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlHint.Name = "pnlHint"
        Me.pnlHint.Size = New System.Drawing.Size(1280, 1024)
        Me.pnlHint.TabIndex = 1
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Location = New System.Drawing.Point(999, 77)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(183, 75)
        Me.btnBack.TabIndex = 2
        '
        'btnStartRecording
        '
        Me.btnStartRecording.BackColor = System.Drawing.Color.Transparent
        Me.btnStartRecording.Location = New System.Drawing.Point(374, 856)
        Me.btnStartRecording.Name = "btnStartRecording"
        Me.btnStartRecording.Size = New System.Drawing.Size(533, 75)
        Me.btnStartRecording.TabIndex = 3
        '
        'lblTimer
        '
        Me.lblTimer.BackColor = System.Drawing.Color.Transparent
        Me.lblTimer.Font = New System.Drawing.Font("Arial", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.ForeColor = System.Drawing.Color.DimGray
        Me.lblTimer.Location = New System.Drawing.Point(618, 829)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(201, 55)
        Me.lblTimer.TabIndex = 3
        Me.lblTimer.Text = "00:00"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmVideoRecorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 1024)
        Me.Controls.Add(Me.pnlHint)
        Me.Controls.Add(Me.pnlWA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmVideoRecorder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.pnlWA.ResumeLayout(False)
        CType(Me.picVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlWA As Panel
    Friend WithEvents picVideo As PictureBox
    Friend WithEvents tmrProgress As Timer
    Friend WithEvents lblNote As Label
    Friend WithEvents pnlHint As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents btnStartRecording As Label
    Friend WithEvents lblTimer As Label
End Class
