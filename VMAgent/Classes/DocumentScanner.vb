Imports System.IO

Public Class DocumentScanner

    Private ReadOnly folderPath As String
    Private ReadOnly processName As String

    Public Sub New()
        folderPath = "C:\Program Files (x86)\Sinosecu\Sinosecu Passport Reader\Demo\picture"
        processName = "EPRDemo"
    End Sub

    Public Function CaptureImage() As String
        Dim DocumentImagePath As String = ""

        If ClearPictureFolder() = True Then

            KillRunningProcess()

            Dim objProcess As New Process()
            objProcess.StartInfo.FileName = "C:\Program Files (x86)\Sinosecu\Sinosecu Passport Reader\Demo\EPRDemo.exe"
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            objProcess.Start()

            DocumentImagePath = GetDocumentImagePath()

            KillRunningProcess()

        End If

        Return DocumentImagePath
    End Function

    Private Function ClearPictureFolder() As Boolean
        Dim Ret As Boolean = True

        Try
            Dim files As String() = Directory.GetFiles(folderPath)
            For Each file As String In files
                IO.File.Delete(file)
            Next
        Catch ex As Exception
            Ret = False
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret
    End Function

    Private Sub KillRunningProcess()

        Dim processes() As Process = Process.GetProcessesByName(processName)
        For Each proc As Process In processes
            proc.Kill()
        Next

    End Sub

    Private Function GetDocumentImagePath() As String
        Dim DocumentImagePath As String = ""

        For I As Integer = 0 To 300

            Dim imageFiles() As String = Directory.GetFiles(folderPath, "*.jpg")
            For F As Integer = 0 To imageFiles.Length - 1
                If imageFiles(F).Contains("_Head.jpg") = False And imageFiles(F).Contains("IR.jpg") = False Then

                    If HasReadAccess(imageFiles(F)) = True Then
                        DocumentImagePath = imageFiles(F)
                        Exit For
                    End If

                End If
            Next

            If DocumentImagePath <> "" Then
                Exit For
            Else
                Threading.Thread.Sleep(100)
            End If

        Next

        Return DocumentImagePath
    End Function

    Public Function HasReadAccess(filePath As String) As Boolean
        Dim Ret As Boolean = False
        Dim counter = 0
        While Ret = False And counter < 5
            Try
                Using reader As New StreamReader(filePath)
                    Ret = True
                End Using
            Catch ex As Exception
                counter = counter + 1
                ExceptionLogger.LogInfo("DocumentScanner -> HasReadAccess : Counter = " & counter)
                ExceptionLogger.LogException(ex)
                Threading.Thread.Sleep(500 * counter)
            End Try
        End While
        Return Ret
    End Function

End Class
