Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports System.Xml

Module PostBuildScript
    Sub Main()
        Try


            Dim sourceAppName As String = "VMAgent.exe"

            ' Define the source directory (your build folder)
            Dim sourceDirectoryRelease As String = "..\..\..\VMAgent\bin\Release"

            ' Define the target directory where the copies will be placed
            Dim targetDirectory As String = "..\..\..\VMAgent\bin"

            Dim deploymentToolDirectoryDebug As String = "..\..\..\DeploymentTool\bin\Debug"

            ' Copy all files from the source directory to the target path
            CopyDirectory(deploymentToolDirectoryDebug, sourceDirectoryRelease & "\DeploymentTool")

            ' Define the path to the compiled executable of the project you want to get the version from
            Dim assemblyPath As String = sourceDirectoryRelease & "\" & sourceAppName

            ' Get the assembly version
            Dim appVersion As String = GetAssemblyVersion(assemblyPath)

            ' Create a list of configurations for each copy
            Dim configs As New List(Of Tuple(Of String, String, String, String)) From {
                Tuple.Create("http://10.102.220.174", "T00001", "BeyondKode", "VMAgent_PLAZA_T00001_" & appVersion),
                Tuple.Create("http://10.102.220.174", "T00002", "BeyondKode", "VMAgent_Bardoni_T00002_" & appVersion),
                Tuple.Create("http://10.102.220.174", "T00003", "BeyondKode", "VMAgent_DownTown_T00003_" & appVersion),
                Tuple.Create("http://10.102.220.174", "T00004", "BeyondKode", "VMAgent_Jenin_T00004_" & appVersion),
                Tuple.Create("http://192.168.0.156", "T00001", "BeyondKode", "VMAgent_T00001_" & appVersion & "_Test")
            }

            ' Loop through each configuration and create the copies
            For Each config In configs
                Dim platformURL As String = config.Item1
                Dim terminalId As String = config.Item2
                Dim companyId As String = config.Item3
                Dim folderName As String = config.Item4

                ' Define the target path for this copy
                Dim targetPath As String = Path.Combine(targetDirectory, folderName)
                Directory.CreateDirectory(targetPath)

                ' Copy all files from the source directory to the target path
                CopyDirectory(sourceDirectoryRelease, targetPath)
                'CopyDirectory(sourceDirectoryDebug, targetPath)

                ' Update the app.config file in the target path
                UpdateAppConfig(Path.Combine(targetPath, "VMAgent.exe.config"), platformURL, terminalId, companyId)
                CreateTextFile(targetPath, "newVersion.txt", folderName)
                CreateTextFile(targetPath, "download_history.txt", folderName)
                CreateTextFile(Path.Combine(targetPath, "DeploymentTool"), "newVersion.txt", folderName)
                CreateTextFile(Path.Combine(targetPath, "DeploymentTool"), "download_history.txt", folderName)
                UpdateDeploymentToolAppConfig(Path.Combine(targetPath, "DeploymentTool", "DeploymentTool.exe.config"), platformURL, terminalId, companyId)

                If System.IO.Directory.Exists(targetPath & "\Logs") Then
                    Dim logFiles = System.IO.Directory.GetFiles(targetPath & "\Logs")
                    System.IO.Directory.GetFiles(targetPath)
                    For Each logFile In logFiles
                        Try
                            File.Delete(logFile)
                        Catch ex As Exception

                        End Try
                    Next
                End If

                If System.IO.File.Exists(Path.Combine(targetDirectory, folderName & ".zip")) Then
                    File.Delete(Path.Combine(targetDirectory, folderName & ".zip"))
                End If

                ' Create a zip file from the target path
                ZipFile.CreateFromDirectory(targetPath, Path.Combine(targetDirectory, folderName & ".zip"))

                ' Clean up the temporary folder
                Directory.Delete(targetPath, True)
            Next
        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)
            Console.WriteLine("Stack Trace: " & ex.StackTrace)
            Environment.Exit(1) ' Exit with a non-zero code to indicate failure
        End Try
    End Sub

    ''' <summary>
    ''' Creates a text file with the specified content, replacing the file if it already exists.
    ''' </summary>
    ''' <param name="filePath">The directory path where the file will be created.</param>
    ''' <param name="fileName">The name of the file to be created.</param>
    ''' <param name="content">The content to be written to the file.</param>
    Sub CreateTextFile(filePath As String, fileName As String, content As String)
        Try
            ' Ensure the directory exists
            If Not Directory.Exists(filePath) Then
                Directory.CreateDirectory(filePath)
            End If

            ' Combine the directory path and file name to get the full file path
            Dim fullFilePath As String = Path.Combine(filePath, fileName)

            ' Write the content to the file, replacing it if it already exists
            File.WriteAllText(fullFilePath, content)
            Console.WriteLine($"File '{fullFilePath}' created successfully.")
        Catch ex As Exception
            Console.WriteLine($"An error occurred: {ex.Message}")
            Throw ' Re-throw the exception to be handled by the main try-catch block
        End Try
    End Sub
    Private Function GetAssemblyVersion(assemblyPath As String) As String
        Try
            Dim assembly As Assembly = Assembly.LoadFrom(assemblyPath)
            Dim version As Version = assembly.GetName().Version

            Return version.ToString()
        Catch ex As Exception
            Console.WriteLine("Failed to get assembly version: " & ex.Message)
            Throw ' Re-throw the exception to be handled by the main try-catch block
        End Try
    End Function

    Private Sub CopyDirectory(sourceDir As String, targetDir As String)
        Try
            ' Copy all files
            For Each filePath In Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories)
                Dim relativePath = filePath.Substring(sourceDir.Length + 1)
                Dim targetFilePath = Path.Combine(targetDir, relativePath)

                Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath))
                File.Copy(filePath, targetFilePath, True)
            Next
        Catch ex As Exception
            Console.WriteLine("Failed to copy directory: " & ex.Message)
            Throw ' Re-throw the exception to be handled by the main try-catch block
        End Try
    End Sub

    Private Sub UpdateAppConfig(appConfigPath As String, platformURL As String, terminalId As String, companyId As String)
        Try

            Dim doc As New XmlDocument()
            doc.Load(appConfigPath)

            Dim nodes = doc.SelectNodes("//appSettings/add")

            For Each node As XmlNode In nodes
                If node.Attributes("key").Value = "PlatformURL" Then
                    node.Attributes("value").Value = platformURL
                ElseIf node.Attributes("key").Value = "TerminalId" Then
                    node.Attributes("value").Value = terminalId

                ElseIf node.Attributes("key").Value = "CompanyId" Then
                    node.Attributes("value").Value = companyId
                End If
            Next

            doc.Save(appConfigPath)
        Catch ex As Exception
            Console.WriteLine("Failed to update app.config: " & ex.Message)
            Throw ' Re-throw the exception to be handled by the main try-catch block
        End Try
    End Sub

    Private Sub UpdateDeploymentToolAppConfig(appConfigPath As String, platformURL As String, terminalId As String, companyId As String)
        Try

            Dim doc As New XmlDocument()
            doc.Load(appConfigPath)

            Dim nodes = doc.SelectNodes("//appSettings/add")

            For Each node As XmlNode In nodes
                If node.Attributes("key").Value = "PlatformURL" Then
                    node.Attributes("value").Value = platformURL
                ElseIf node.Attributes("key").Value = "TerminalId" Then
                    node.Attributes("value").Value = terminalId
                ElseIf node.Attributes("key").Value = "CompanyId" Then
                    node.Attributes("value").Value = companyId
                End If
            Next

            doc.Save(appConfigPath)
        Catch ex As Exception
            Console.WriteLine("Failed to update app.config: " & ex.Message)
            Throw ' Re-throw the exception to be handled by the main try-catch block
        End Try
    End Sub
End Module
