Imports OpenQA.Selenium.Edge
Imports System.IO
Imports System.IO.Compression
Imports System.Threading

Module Module1
    Dim objConfigParams As ConfigParams

    Sub Main()
        objConfigParams = ConfigParams.GetConfigParams()
        RestartAppMonitorService()

        While True
            Try
                ' Ensure required directories exist
                EnsureDirectoryExists(Path.GetDirectoryName(objConfigParams.downloadLocation))
                EnsureDirectoryExists(objConfigParams.extractionPath)
                EnsureDirectoryExists(objConfigParams.backupPath)

                CheckAndUpdateFile()

                Thread.Sleep(objConfigParams.RefreshInterval)
            Catch ex As Exception
                Console.WriteLine($"Error: {ex.Message}")
            End Try

        End While
    End Sub

    Private Sub EnsureDirectoryExists(directoryPath As String)
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If
    End Sub

    Private Sub CheckAndUpdateFile()
        Dim latestDownloadedFileName As String = ""
        Dim newFileName As String = ""
        Try

            latestDownloadedFileName = GetLatestDownloadedFileName()
            newFileName = GetNewVMAgentVersionName()

            If newFileName IsNot Nothing And newFileName <> "" And newFileName.Trim() <> latestDownloadedFileName.Trim() Then
                Try
                    Console.WriteLine("Try to Download newFileName = " & newFileName & " and APPPlatformURL = " & objConfigParams.APPPlatformURL & " and downloadLocation = " & objConfigParams.downloadLocation)
                    Dim DownloadedFileName = DownloadFileUsingSelenium(objConfigParams.APPPlatformURL, objConfigParams.downloadLocation)
                    Console.WriteLine("Try to kill Agent")
                    KillApplication(objConfigParams.appToKill)
                    Console.WriteLine("Try to backup agent")
                    BackupCurrentFiles(objConfigParams.extractionPath, objConfigParams.backupPath)
                    Console.WriteLine("Try to extract")
                    Thread.Sleep(2000)
                    ExtractZipFile(Path.Combine(objConfigParams.downloadLocation, DownloadedFileName), objConfigParams.extractionPath)
                    Console.WriteLine("Try to save download history")
                    SaveDownloadHistory(newFileName)
                    Console.WriteLine("Try to Start the agent Application")
                    StartApplication(objConfigParams.appToKill)
                Catch ex As Exception
                    Console.WriteLine($"Error: {ex.Message}")
                    ' Restore from backup if something goes wrong
                    RestoreBackup(objConfigParams.backupPath, objConfigParams.extractionPath)
                    StartApplication(objConfigParams.appToKill)
                End Try
            Else
                Console.WriteLine("No New Build OLD Version = " & latestDownloadedFileName & " and New version = " & newFileName)
            End If
        Catch ex As Exception
            Console.WriteLine("Failed To read versions = " & latestDownloadedFileName & " and New version = " & newFileName)
        End Try
        Thread.Sleep(5000)
    End Sub

    Private Function GetNewVMAgentVersionName() As String
        If System.IO.File.Exists(objConfigParams.newVersionFile) Then
            Return System.IO.File.ReadAllText(objConfigParams.newVersionFile).Trim()
        End If
        Return String.Empty
    End Function

    Private Function DownloadFileUsingSelenium(url As String, downloadDirectory As String) As String
        Directory.Delete(downloadDirectory, True)
        Directory.CreateDirectory(downloadDirectory)
        Dim options As New EdgeOptions()
        options.AddUserProfilePreference("download.default_directory", downloadDirectory)
        options.AddUserProfilePreference("download.prompt_for_download", False)
        options.AddUserProfilePreference("disable-popup-blocking", "true")

        Using driver As New EdgeDriver(options)
            driver.Navigate().GoToUrl(url)
            Thread.Sleep(100000) ' Wait for the download to complete. Adjust the time as needed.

            ' Assuming that the file is the most recent one in the download directory
            Dim downloadedFiles = Directory.GetFiles(downloadDirectory).OrderByDescending(Function(f) New FileInfo(f).LastWriteTime).ToArray()
            If downloadedFiles.Length > 0 Then
                Return Path.GetFileName(downloadedFiles(0))
            End If
        End Using
        Return Nothing
    End Function

    Private Function GetLatestDownloadedFileName() As String
        If System.IO.File.Exists(objConfigParams.downloadHistoryFile) Then
            Return System.IO.File.ReadAllText(objConfigParams.downloadHistoryFile).Trim()
        End If
        Return String.Empty
    End Function
    Private Sub KillApplication(appName As String)
        For Each process As Process In Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appName))
            process.Kill()
            process.WaitForExit()
        Next
    End Sub

    Private Sub BackupCurrentFiles(sourcePath As String, backupPath As String)
        EnsureDirectoryExists(backupPath)

        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)
        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
            System.IO.Path.Combine(backupPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the method to copy all the nested folders
                BackupCurrentFiles(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Private Sub ExtractZipFile(zipPath As String, extractPath As String)
        EnsureDirectoryExists(extractPath)

        ' Delete all files and folders inside extractionPath except 'logs' folder
        For Each item In Directory.GetFileSystemEntries(extractPath)
            If Not item.EndsWith("\Logs") Then
                If Directory.Exists(item) Then
                    Directory.Delete(item, True)
                Else
                    File.Delete(item)
                End If
            End If
        Next

        ZipFile.ExtractToDirectory(zipPath, extractPath)
    End Sub

    Private Sub StartApplication(appPath As String)
        Try
            Dim myProcess As ProcessStartInfo = New ProcessStartInfo()
            myProcess.FileName = Path.Combine(objConfigParams.extractionPath, appPath)
            myProcess.UseShellExecute = False
            myProcess.RedirectStandardOutput = True
            myProcess.RedirectStandardError = True
            myProcess.CreateNoWindow = True

            Process.Start(myProcess)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub StartMonitorTool(appPath As String)
        Try
            Console.WriteLine("StartApplication -> appPath")
            Dim processInfo As New ProcessStartInfo()

            processInfo.FileName = appPath
            processInfo.WorkingDirectory = "C:\DeploymentTool\" ' Set the working directory

            Process.Start(processInfo)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub SaveDownloadHistory(fileName As String)
        System.IO.File.WriteAllText(objConfigParams.downloadHistoryFile, fileName)
    End Sub

    Private Sub RestoreBackup(backupPath As String, targetPath As String)
        EnsureDirectoryExists(targetPath)
        If Directory.Exists(targetPath) Then
            Directory.Delete(targetPath, True)
        End If
        Directory.CreateDirectory(targetPath)
        For Each file As String In Directory.GetFiles(backupPath)
            System.IO.File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)), True)
        Next
    End Sub

    Private Sub RestartAppMonitorService()
        Dim servicePath As String = "C:\DeploymentTool\app_monitor_service.exe"

        ' Check if the service is running
        For Each proc As Process In Process.GetProcessesByName("app_monitor_service.exe")
            Try
                Console.WriteLine("Killing app_monitor_service.exe")
                proc.Kill()
                proc.WaitForExit()
                Console.WriteLine("Killed succesfuly")
            Catch ex As Exception
                Console.WriteLine($"Failed to kill process: {ex.Message}")
            End Try
        Next

        ' Start the service
        StartMonitorTool(servicePath)
    End Sub

End Module
