Imports System.Reflection
Imports AForge.Video.FFMPEG
Imports System.IO
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports AForge

Public Class frmVideoRecorder

    Dim MaxProgress As Integer = 6
    Dim Progress As Integer = 0
    Dim Cam As New Camera
    Public VideoFilePath As String = ""
    Public IsDone As Boolean = False

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideoRecorder))
        ExceptionLogger.LogInfo("frmVideoRecorder_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmVideoRecorder
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

        Me.pnlHint.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmVideoRecorderHint
        Me.pnlHint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmVideoRecorder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmVideoRecorder_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmVideoRecorder_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub tmrProgress_Tick(sender As Object, e As EventArgs) Handles tmrProgress.Tick
        tmrProgress.Enabled = False

        If Progress = 0 Then
            ' Initialize the recording when the timer starts
            videoWriter = New VideoFileWriter()
            videoWriter.Open(VideoFilePath, 640, 480, 25, VideoCodec.MPEG4)
            recording = True
        End If

        lblTimer.Text = "00:0" & Progress.ToString()

        If Progress = MaxProgress Then
            Globals.ShowPleaseWait(Me)
            recording = False
            videoSource.SignalToStop()
            videoSource.WaitForStop()
            videoWriter.Close()
            videoWriter = Nothing

            Dim newPath = ""
            ' Convert the AVI file to MP4
            If ConvertAVIToMP4(VideoFilePath) Then
                newPath = VideoFilePath.Replace(".avi", ".mp4")
            End If

            ' Delete the AVI file
            If System.IO.File.Exists(VideoFilePath) Then
                System.IO.File.Delete(VideoFilePath)
            End If
            VideoFilePath = newPath
            Globals.HidePleaseWait(Me)
            IsDone = True
            Me.Close()
        Else
            Progress += 1
            tmrProgress.Enabled = True
        End If
    End Sub



    Private Function ConvertAVIToMP4(ByVal AVIFilePath As String) As Boolean
        Dim result As Boolean = False

        Dim psi As New ProcessStartInfo
        psi.FileName = Application.StartupPath & "\avi2mp4.exe"
        psi.Arguments = """" & AVIFilePath & """"
        psi.Arguments &= " --bitrate 2000k"
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim process As Process = Process.Start(psi)
        process.WaitForExit()

        If process.ExitCode = 0 Then
            result = True
        End If

        Return result

    End Function
    Private videoSource As VideoCaptureDevice
    Private recording As Boolean = False
    Private videoWriter As VideoFileWriter
    Private Sub btnStartRecording_Click(sender As Object, e As EventArgs) Handles btnStartRecording.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        pnlHint.Visible = False
        Application.DoEvents()

        ' Start the camera
        Dim videoDevices As New FilterInfoCollection(FilterCategory.VideoInputDevice)
        ExceptionLogger.LogInfo("frmVideoRecorder = > btnStartRecording_Click videoDevices.Count=" & videoDevices.Count)
        If videoDevices.Count > 0 Then
            videoSource = New VideoCaptureDevice(videoDevices(0).MonikerString)
            AddHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource.Start()

            ' Prepare output video file path
            VideoFilePath = Path.Combine(Application.StartupPath, "Video", GetNewId() & ".avi")
            ExceptionLogger.LogInfo("frmVideoRecorder = > btnStartRecording_Click VideoFilePath=" & VideoFilePath)
            ' Initialize the video writer
            videoWriter = New VideoFileWriter()
            videoWriter.Open(VideoFilePath, 640, 480, 25, VideoCodec.MPEG4)

            recording = True
            tmrProgress.Enabled = True
            tmrProgress.Start()
        End If
    End Sub

    Private Sub VideoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        If recording Then
            ' Write the frame to the video file
            videoWriter.WriteVideoFrame(eventArgs.Frame.Clone())
            ' Display the video frame
            picVideo.Image = eventArgs.Frame.Clone()
        End If
    End Sub
    Private Sub StopRecording()
        If recording Then
            recording = False
            videoSource.SignalToStop()
            videoSource.WaitForStop()
            videoWriter.Close()
            videoWriter = Nothing
            tmrProgress.Stop()
            tmrProgress.Enabled = False
        End If
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        StopRecording()
        Me.Close()
    End Sub

    Public Shared Function GetNewId() As String

        Dim NewId As String
        NewId = Date.Now.ToString("yyMMddHHmmssffffff") & System.Guid.NewGuid.ToString("N").ToUpper

        Return NewId

    End Function

End Class