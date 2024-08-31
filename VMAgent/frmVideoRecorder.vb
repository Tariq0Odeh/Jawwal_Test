Imports System.Reflection

Public Class frmVideoRecorder

    Dim MaxProgress As Integer = 6
    Dim Progress As Integer = 0
    Dim Cam As New Camera
    Public VideoFilePath As String = ""
    Public IsDone As Boolean = False

    Private Sub frmVideoRecorder_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub tmrProgress_Tick(sender As Object, e As EventArgs) Handles tmrProgress.Tick

        tmrProgress.Enabled = False

        If Progress = 0 Then
            Cam.CapturePathAndFileName = VideoFilePath
            Cam.StartRecording()
        End If

        lblTimer.Text = "00:0" & Progress.ToString

        If Progress = MaxProgress Then
            Globals.ShowPleaseWait(Me)
            Cam.StopRecording()
            Dim newPath = ""
            ' convert the avi file to mp4
            If ConvertAVIToMP4(VideoFilePath) = True Then
                newPath = VideoFilePath.Replace(".avi", ".mp4")
            End If

            ' delete the avi file
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

    Private Sub btnStartRecording_Click(sender As Object, e As EventArgs) Handles btnStartRecording.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        pnlHint.Visible = False
        Application.DoEvents()

        Cam.Start(picVideo.Handle.ToInt32)

        VideoFilePath = Application.StartupPath & "\Video\" & GetNewId() & ".avi"

        tmrProgress.Enabled = True

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

    Public Shared Function GetNewId() As String

        Dim NewId As String
        NewId = Date.Now.ToString("yyMMddHHmmssffffff") & System.Guid.NewGuid.ToString("N").ToUpper

        Return NewId

    End Function

End Class