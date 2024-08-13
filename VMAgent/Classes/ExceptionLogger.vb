Imports System.IO
Imports System.Xml
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Security

Public Class ExceptionLogger

    Private Shared Function Init(today As Date) As String
        ' Get the directory where the log files will be stored
        Dim logDirectory = Path.Combine(Application.StartupPath, "Logs")

        ' Create the log directory if it doesn't exist
        If Not Directory.Exists(logDirectory) Then
            Directory.CreateDirectory(logDirectory)
        End If

        ' Set the log file name using the current date
        Dim logFileName = Path.Combine(logDirectory, $"log_{today.ToString("yyyy-MM-dd")}.txt")
        Return logFileName
    End Function

    Public Shared Async Sub LogException(ByVal ex As Exception)
        Dim logFileName = Init(DateTime.Now)
        Await Task.Run(Sub()
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

    Public Shared Async Sub LogInfo(ByVal msg As String)
        msg = RemoveAllUnneededCharsForAPILogs(msg)
        Dim logFileName = Init(DateTime.Now)
        Await Task.Run(Sub()
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

    Friend Shared Function GetLogByDay(today As Date, Optional isRecyclersLog As Boolean = False) As String
        Dim logFileName As String

        If isRecyclersLog Then
            logFileName = Path.Combine(Application.StartupPath, "Logs", $"recyclers_log_{today.ToString("yyyy-MM-dd")}.txt")
        Else
            logFileName = Init(today)
        End If

        Dim returnedLogs As String = ""
        Try
            ' Read the log file
            Using reader As StreamReader = New StreamReader(logFileName)
                returnedLogs = reader.ReadToEnd()
                returnedLogs = SanitizeLogText(returnedLogs)
            End Using
        Catch ioEx As IOException
            ' Handle any IO exceptions (e.g., if unable to read the log file)
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
            If XmlConvert.IsXmlChar(ch) And ch <> "&" Then
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

    Friend Shared Function RemoveAllUnneededCharsForAPILogs(Input As String) As String
        ' Remove words longer than 200 characters
        Dim longWordPattern As String = "\b\w{201,}\b"
        Input = Regex.Replace(Input, longWordPattern, " ")

        ' Remove all invalid XML characters
        Dim xmlInvalidCharsPattern As String = "[^\u0009\u000A\u000D\u0020-\uD7FF\uE000-\uFFFD]"
        Input = Regex.Replace(Input, xmlInvalidCharsPattern, " ")

        ' Remove all characters except letters, digits, spaces, new lines, colons, asterisks, and question marks
        Dim allowedCharsPattern As String = "[^a-zA-Z0-9\s\n:*?.]"
        Input = Regex.Replace(Input, allowedCharsPattern, " ")

        ' Match valid time formats (e.g., HH:mm, HH:mm:ss)
        Dim timePattern As String = "\b((0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9](?::[0-5][0-9])?)\b"
        Dim validTimeMatches As MatchCollection = Regex.Matches(Input, timePattern)

        ' Create a set to store unique valid times
        Dim validTimes As New HashSet(Of String)
        For Each match As Match In validTimeMatches
            validTimes.Add(match.Value)
        Next

        ' Rebuild the string with valid characters and unique valid times
        Dim result As New StringBuilder()
        Dim lastIndex As Integer = 0

        For Each match As Match In validTimeMatches
            ' Append characters from the last index to the current match index
            result.Append(Input.Substring(lastIndex, match.Index - lastIndex))

            ' Append the valid time if it's unique
            If validTimes.Contains(match.Value) Then
                result.Append(match.Value)
                validTimes.Remove(match.Value)
            End If

            ' Update the last index to the end of the current match
            lastIndex = match.Index + match.Length
        Next

        ' Append any remaining characters after the last match
        If lastIndex < Input.Length Then
            result.Append(Input.Substring(lastIndex))
        End If
        Dim finalString As String = SecurityElement.Escape(result.ToString().Trim())
        Return finalString
    End Function
End Class
