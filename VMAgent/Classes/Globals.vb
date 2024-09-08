Imports System.IO

Public Class Globals
    Public Shared IsVerbose As Boolean = False
    Public Shared QRCode As String = ""

    Public Shared Sub EnsureDirectoryExists(directoryPath As String)
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If
    End Sub


    Private Shared PW As New PleaseWaitUntilFinish
    Public Shared Sub ShowPleaseWait(parent As Form)
        'PW.Parent = parent
        'parent.Enabled = False
        'Application.DoEvents()
        ExceptionLogger.LogInfo("Trying to show frmPleaseWait as Dialog")
        Try
            If PW Is Nothing Then
                PW = New PleaseWaitUntilFinish
            End If

            parent.Enabled = False
            Application.DoEvents()
            Threading.Thread.Sleep(500)
            PW.Show()
            Threading.Thread.Sleep(500)
            Application.DoEvents()

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        'Application.DoEvents()

    End Sub

    Public Shared Sub HidePleaseWait(parent As Form)

        'Application.DoEvents()
        'PW.Parent = Nothing
        ExceptionLogger.LogInfo("Trying to close frmPleaseWait")

        Try
            PW.Close()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Try
            PW.Dispose()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Try
            PW = Nothing
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        ExceptionLogger.LogInfo("frmPleaseWait closed Successfully")
        parent.Enabled = True

    End Sub
End Class
