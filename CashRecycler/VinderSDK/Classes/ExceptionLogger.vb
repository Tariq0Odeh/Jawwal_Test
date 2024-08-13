Imports System.IO
Imports System.Xml
Imports System.Threading

Public Class ExceptionLogger

    Private Shared Function Init() As String
        ' Get the directory where the log files will be stored
        Dim logDirectory = "Logs"

        ' Create the log directory if it doesn't exist
        If Not Directory.Exists(logDirectory) Then
            Directory.CreateDirectory(logDirectory)
        End If

        ' Set the log file name using the current date
        Dim logFileName = Path.Combine(logDirectory, $"recyclers_log_{DateTime.Now.ToString("yyyy-MM-dd")}.txt")
        Return logFileName
    End Function

    Public Shared Sub LogException(ByVal ex As Exception)
        Dim logFileName = Init()
        ThreadPool.QueueUserWorkItem(Sub()
                                         Try
                                             ' Create or append to the log file
                                             Using writer As StreamWriter = New StreamWriter(logFileName, True)
                                                 ' Write the exception details to the log file
                                                 writer.WriteLine($"[{DateTime.Now.ToString()}] Exception: {ex.Message}")
                                                 writer.WriteLine($"StackTrace: {ex.StackTrace}")
                                             End Using
                                         Catch ioEx As IOException
                                             ' Handle any IO exceptions (e.g., if unable to write to the log file)
                                         End Try
                                     End Sub)
    End Sub

    Public Shared Sub LogInfo(ByVal msg As String)
        Dim logFileName = Init()
        ThreadPool.QueueUserWorkItem(Sub()
                                         Try
                                             ' Create or append to the log file
                                             Using writer As StreamWriter = New StreamWriter(logFileName, True)
                                                 ' Write the info message to the log file
                                                 writer.WriteLine($"[{DateTime.Now.ToString()}] Info: {msg}")
                                             End Using
                                         Catch ioEx As IOException
                                             ' Handle any IO exceptions (e.g., if unable to write to the log file)
                                         End Try
                                     End Sub)
    End Sub

    Friend Shared Function GetLogByDay(today As Date) As String
        Dim logFileName = Init()
        Dim returnedLogs = ""
        Try
            ' Create or append to the log file
            Using reader As StreamReader = New StreamReader(logFileName)
                ' Write the exception details to the log file
                returnedLogs = reader.ReadToEnd()
                returnedLogs = SanitizeLogText(returnedLogs)
            End Using
        Catch ioEx As IOException
            ' Handle any IO exceptions (e.g., if unable to write to the log file)
        End Try
        Return returnedLogs
    End Function

    Friend Shared Function SanitizeLogText(logText As String) As String
        ' Replace characters that are not allowed in XML with an empty string
        Dim sanitizedText As String = RemoveInvalidXmlChars(logText)
        Return sanitizedText
    End Function

    Friend Shared Function RemoveInvalidXmlChars(text As String) As String
        ' Create a new StringBuilder to store the sanitized text
        Dim sanitizedTextBuilder As New System.Text.StringBuilder()

        ' Loop through each character in the input text
        For Each ch As Char In text
            ' Check if the character is a valid XML character
            If IsValidXmlChar(ch) And ch <> "&" Then
                ' If it's a valid XML character, append it to the sanitized text
                sanitizedTextBuilder.Append(ch)
            Else
                ' If it's not a valid XML character, replace it with an empty string
                sanitizedTextBuilder.Append("")
            End If
        Next

        ' Return the sanitized text as a string
        Return sanitizedTextBuilder.ToString()
    End Function

    Private Shared Function IsValidXmlChar(ch As Char) As Boolean
        ' Valid XML character ranges according to XML specification
        Return (ch = ChrW(&H9)) OrElse
               (ch = ChrW(&HA)) OrElse
               (ch = ChrW(&HD)) OrElse
               (ch >= ChrW(&H20) AndAlso ch <= ChrW(&HD7FF)) OrElse
               (ch >= ChrW(&HE000) AndAlso ch <= ChrW(&HFFFD))
    End Function

End Class
