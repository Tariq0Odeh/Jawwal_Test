Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Diagnostics
Imports System.Reflection

Public Class frmMain

    Public TerminalLastStatus As String = ""
    Dim objMenu As Form
    Dim objConfigParams As New ConfigParams
    Dim TimeToTransferToOutBoxDaily As TimeSpan
    Dim isTranferedToday = False
    Dim PW As PleaseWaitUntilFinish

    Public Sub New()
        Try
            ' Subscribe to the Application.ThreadException event
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            AddHandler Application.ThreadExit, AddressOf Application_ThreadException
            ' Subscribe to the AppDomain.CurrentDomain.UnhandledException event
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

            InitializeComponent()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub

    Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        ' Handle the exception
        'MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Optionally, log the exception
        ExceptionLogger.LogException(e.Exception)

    End Sub

    Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        ' Handle the exception
        ' Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
        ' MessageBox.Show($"An unhandled exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Optionally, log the exception
        ExceptionLogger.LogException(e.ExceptionObject)
    End Sub


    Private Function ReadCurrentVersion() As String
        Dim returnValue = ""
        Try
            returnValue = System.IO.File.ReadAllText(objConfigParams.DeploymentToolPath & "\" & objConfigParams.DeploymentToolnewVersionFileName).Trim()
        Catch ex As Exception
            returnValue = ""
        End Try
        Return returnValue

    End Function
    Private Sub CopyDirectory(sourceDir As String, targetDir As String)
        ' Copy all files
        For Each filePath In Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories)
            Dim relativePath = filePath.Substring(sourceDir.Length + 1)
            Dim targetFilePath = Path.Combine(targetDir, relativePath)

            Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath))
            File.Copy(filePath, targetFilePath, True)
        Next
    End Sub

    Private Sub KillApplication(appName As String)
        For Each process As Process In Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appName))
            process.Kill()
            process.WaitForExit()
        Next
    End Sub

    Private Sub StartApplication(appPath As String)
        ExceptionLogger.LogInfo("StartApplication -> appPath")
        Dim processInfo As New ProcessStartInfo()

        processInfo.FileName = Path.Combine(objConfigParams.DeploymentToolPath, appPath)
        processInfo.WorkingDirectory = objConfigParams.DeploymentToolPath ' Set the working directory

        Process.Start(processInfo)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim version As Version = assembly.GetName().Version
        ' Check if another instance with the same process name is running
        Dim currentProcess As Process = Process.GetCurrentProcess()
        Dim processes() As Process = Process.GetProcessesByName(currentProcess.ProcessName)
        ' If more than one process with the same name is found (including the current instance), exit
        If processes.Length > 1 Then
            ExceptionLogger.LogInfo("Another instance of the application (VMAgent.exe) is already running.")
            Application.Exit()
        End If
        ExceptionLogger.LogInfo("frmMain -> frmMain_Load With App Version = " & version.ToString())
        Try
            objConfigParams = ConfigParams.GetConfigParams()
            ' Kill the application if needed



            ' Set the global config for the current build version
            GlobalConfig.CurrentBuildVersion = ReadCurrentVersion()

            ' Initialize the CoinCashRecycler
            objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)
            RecyclersOpened = objCoinCashRecycler.InitCoinCashRecyclers()
            ExceptionLogger.LogInfo("Recyclers Status is " & RecyclersOpened.ToString())

            ' Initialize the CardDispenser
            objCardDispnser = New CardDispenser
            CardDispnserOpened = objCardDispnser.Init("COM" & objConfigParams.CardDispenserCOMPortNumber, "9600", "00")

            ' Try to parse the time string with the specific format
            Try
                Dim parrsedDatetime As DateTime = DateTime.Parse(objConfigParams.TimeToTransferToOutBoxDaily)
                ' Extract the time part as a TimeSpan
                TimeToTransferToOutBoxDaily = New TimeSpan(parrsedDatetime.Hour, parrsedDatetime.Minute, 0)

                ' Display the TimeSpan
                'ExceptionLogger.LogInfo("TimeSpan: " & TimeToTransferToOutBoxDaily.ToString())
                'MessageBox.Show("TimeSpan: " & TimeToTransferToOutBoxDaily.ToString())
            Catch ex As Exception
                ExceptionLogger.LogInfo("#ERROR: Could not convert TimeToTransferToOutBoxDaily in app config to dotnet TimeSpan")
                'MessageBox.Show("Could not convert TimeToTransferToOutBoxDaily:" & objConfigParams.TimeToTransferToOutBoxDaily & " in app config to dotnet TimeSpan")
                TimeToTransferToOutBoxDaily = New TimeSpan(3, 30, 0)
            End Try

            ' Set the timer intervals and enable them
            tmrMain.Interval = (Val(objConfigParams.RefreshInterval) * 1000)
            tmrMain.Enabled = True
            tmrTimeout.Enabled = True


            Try
                If objConfigParams.AllowDeploymentTool = "Y" Then
                    ExceptionLogger.LogInfo("***Start Copying and running the Deployment Tool")
                    ' Copy contents from DeploymentTool directory to the specified path
                    Dim deploymentToolSourcePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DeploymentTool")
                    Dim deploymentToolDestinationPath As String = objConfigParams.DeploymentToolPath


                    'Try to kill app_monitor_service.exe

                    Try

                        KillApplication("app_monitor_service.exe")

                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                    End Try
                    'Try to kill DeploymentToolName

                    Try

                        KillApplication(objConfigParams.DeploymentToolName)
                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                    End Try
                    Threading.Thread.Sleep(2000)

                    If Directory.Exists(deploymentToolDestinationPath) Then
                        Dim files() As String = Directory.GetFiles(deploymentToolDestinationPath)

                        ' Delete each file
                        For Each file As String In files
                            IO.File.Delete(file)
                        Next

                        ' Optionally, delete subdirectories and their contents
                        Dim subDirectories() As String = Directory.GetDirectories(deploymentToolDestinationPath)
                        For Each subDirectory As String In subDirectories
                            Directory.Delete(subDirectory, True)
                        Next
                    End If


                    Threading.Thread.Sleep(500)

                    ' Ensure the destination directory exists
                    If Not Directory.Exists(deploymentToolDestinationPath) Then
                        Directory.CreateDirectory(deploymentToolDestinationPath)
                        Threading.Thread.Sleep(500)
                    End If



                    'Copy all files from the source directory to the target path
                    CopyDirectory(deploymentToolSourcePath, deploymentToolDestinationPath)

                    Threading.Thread.Sleep(3000)

                    ' Start the new executable
                    Try
                        StartApplication(objConfigParams.DeploymentToolName)
                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                    End Try

                End If

            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub
    Public tmrMain_TickTerminalStatus = ""
    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        Try
            tmrMain.Enabled = False

            Dim objTerminal As New Terminal
            objTerminal = APIs.GetTerminalDetails()

            If (objTerminal.TerminalStatus.ToUpper = "ONLINE" And TerminalLastStatus = "") Then
                ExceptionLogger.LogInfo("Terminal Status : ONLINE , Last Status was  " & TerminalLastStatus)
                If Not CurrentServiceForm Is Nothing Then
                    CurrentServiceForm.Close()
                    CurrentServiceForm.Dispose()
                    CurrentServiceForm = Nothing
                End If

                If Not objTimeExtension Is Nothing Then
                    objTimeExtension.Close()
                    objTimeExtension.Dispose()
                    objTimeExtension = Nothing
                End If

                If Not objMenu Is Nothing Then
                    objMenu.Close()
                    objMenu.Dispose()
                    objMenu = Nothing
                End If

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    If objMenu Is Nothing Then
                        If objConfigParams.ISEKYCEnabled = "Y" Then
                            objMenu = New frmMenuEKYC
                        Else
                            objMenu = New frmMenu
                        End If

                        objMenu.Owner = Me
                        objMenu.Show()
                    End If
                Else
                    ExceptionLogger.LogInfo(" #1 Last Status was '' and RecyclersOpened is " & RecyclersOpened.ToString())
                    'objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)
                    RecyclersOpened = objCoinCashRecycler.InitCoinCashRecyclers()
                    ExceptionLogger.LogInfo(" Restarting Recyclers machines and RecyclersOpened is " & RecyclersOpened.ToString())
                End If

                TerminalLastStatus = objTerminal.TerminalStatus.ToUpper
            ElseIf objTerminal.TerminalStatus.ToUpper = "ONLINE" And TerminalLastStatus = "OFFLINE" Then
                ExceptionLogger.LogInfo("Terminal Status : ONLINE , Last Status was OFFLINE ")
                If Not CurrentServiceForm Is Nothing Then
                    CurrentServiceForm.Close()
                    CurrentServiceForm.Dispose()
                    CurrentServiceForm = Nothing
                End If

                If Not objTimeExtension Is Nothing Then
                    objTimeExtension.Close()
                    objTimeExtension.Dispose()
                    objTimeExtension = Nothing
                End If

                If Not objMenu Is Nothing Then
                    objMenu.Close()
                    objMenu.Dispose()
                    objMenu = Nothing
                End If
                ExceptionLogger.LogInfo(" Trying to Reconnection Recyclers")
                RecyclersOpened = objCoinCashRecycler.InitCoinCashRecyclers()
                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    ExceptionLogger.LogInfo("Recyclers Reconnected Succcesfully")
                    If objConfigParams.ISEKYCEnabled = "Y" Then
                        objMenu = New frmMenuEKYC
                    Else
                        objMenu = New frmMenu
                    End If
                    objMenu.Owner = Me
                    objMenu.Show()
                Else
                    ExceptionLogger.LogInfo(" #2 Last Status was '' and RecyclersOpened is " & RecyclersOpened.ToString())
                    'objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)
                    RecyclersOpened = objCoinCashRecycler.InitCoinCashRecyclers()
                    ExceptionLogger.LogInfo(" Restarting Recyclers machines and RecyclersOpened is " & RecyclersOpened.ToString())
                End If

                TerminalLastStatus = objTerminal.TerminalStatus.ToUpper
            ElseIf objTerminal.TerminalStatus.ToUpper = "OFFLINE" And TerminalLastStatus = "" Then
                ExceptionLogger.LogInfo("Terminal Status : OFFLINE , Last Status was '' ")
                If Not CurrentServiceForm Is Nothing Then
                    CurrentServiceForm.Close()
                    CurrentServiceForm.Dispose()
                    CurrentServiceForm = Nothing
                End If

                If Not objTimeExtension Is Nothing Then
                    objTimeExtension.Close()
                    objTimeExtension.Dispose()
                    objTimeExtension = Nothing
                End If

                If Not objMenu Is Nothing Then
                    objMenu.Close()
                    objMenu.Dispose()
                    objMenu = Nothing
                End If

                TerminalLastStatus = objTerminal.TerminalStatus.ToUpper
            ElseIf objTerminal.TerminalStatus.ToUpper = "OFFLINE" And TerminalLastStatus = "OFFLINE" Then
                ExceptionLogger.LogInfo("Terminal Status : OFFLINE , Last Status was OFFLINE ")
                If Not CurrentServiceForm Is Nothing Then
                    CurrentServiceForm.Close()
                    CurrentServiceForm.Dispose()
                    CurrentServiceForm = Nothing
                End If

                If Not objTimeExtension Is Nothing Then
                    objTimeExtension.Close()
                    objTimeExtension.Dispose()
                    objTimeExtension = Nothing
                End If

                If Not objMenu Is Nothing Then
                    objMenu.Close()
                    objMenu.Dispose()
                    objMenu = Nothing
                End If

                TerminalLastStatus = objTerminal.TerminalStatus.ToUpper
            ElseIf objTerminal.TerminalStatus.ToUpper = "OFFLINE" And TerminalLastStatus = "ONLINE" Then
                ExceptionLogger.LogInfo("Terminal Status : OFFLINE , Last Status was ONLINE ")
                If Not CurrentServiceForm Is Nothing Then
                    CurrentServiceForm.Close()
                    CurrentServiceForm.Dispose()
                    CurrentServiceForm = Nothing
                End If

                If Not objTimeExtension Is Nothing Then
                    objTimeExtension.Close()
                    objTimeExtension.Dispose()
                    objTimeExtension = Nothing
                End If

                If Not objMenu Is Nothing Then
                    objMenu.Close()
                    objMenu.Dispose()
                    objMenu = Nothing
                End If

                TerminalLastStatus = objTerminal.TerminalStatus.ToUpper
            Else
                ExceptionLogger.LogInfo(" *** Terminal Status : " & objTerminal.TerminalStatus.ToUpper & ", TerminalLastStatus =  " & TerminalLastStatus)
                ExceptionLogger.LogInfo(" #3  and RecyclersOpened is " & RecyclersOpened.ToString())
                'objCoinCashRecycler = New VinderSDK.CoinCashRecycler(If(objConfigParams.CashRecyclerEnabled = "Y", True, False), If(objConfigParams.CoinRecyclerEnabled = "Y", True, False), objConfigParams.CoinRecyclerCOMPortNumber)
                If RecyclersOpened <> VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    RecyclersOpened = objCoinCashRecycler.InitCoinCashRecyclers()
                    ExceptionLogger.LogInfo(" #3 again Restarting Recyclers machines and RecyclersOpened is " & RecyclersOpened.ToString())
                End If

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline And (objMenu Is Nothing) Then
                    If objConfigParams.ISEKYCEnabled = "Y" Then
                        objMenu = New frmMenuEKYC
                    Else
                        objMenu = New frmMenu
                    End If

                    objMenu.Owner = Me
                    objMenu.Show()
                End If
            End If

            Dim currentTime As TimeSpan = DateTime.Now.TimeOfDay
            ' Define the start time (3:30 AM) as TimeSpan
            Dim startTime As TimeSpan = TimeToTransferToOutBoxDaily
            ' Define the end time (3:32 AM) as TimeSpan
            Dim endTime As TimeSpan = New TimeSpan(TimeToTransferToOutBoxDaily.Hours, TimeToTransferToOutBoxDaily.Minutes + 2, 0)

            ' Check if the current time is between the start time and end time
            If currentTime >= startTime AndAlso currentTime <= endTime And Not isTranferedToday Then
                'The current time is between startTime " & startTime.ToString() & " and endTime " & endTime.ToString() 
                objConfigParams = ConfigParams.GetConfigParams()
                Try
                    isTranferedToday = True
                    ExceptionLogger.LogInfo(" *** Beginning Transferring to cash outbox")
                    Globals.ShowPleaseWait(Me)
                    If objMenu IsNot Nothing Then objMenu.Hide()
                    objCoinCashRecycler.EmptyCash()
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try
                If objMenu IsNot Nothing Then
                    objMenu.Show()
                    objMenu.Visible = True
                End If
                Globals.HidePleaseWait(Me)
            End If

            If isTranferedToday And currentTime >= endTime Then
                'isTranferedToday And currentTime >= endTime so isTranferedToday = False"
                isTranferedToday = False
            End If

            tmrMain.Enabled = True
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub


#Region " Screen Timeout"

    Private Sub tmrTimeout_Tick(sender As Object, e As EventArgs) Handles tmrTimeout.Tick
        Try


            tmrTimeout.Enabled = False

            If Not CurrentServiceForm Is Nothing Then

                If GetAsyncKeyState(1) <> 0 Then
                    TimeOutCounter = 0
                Else

                    If TimeOutCounter >= (Val(objConfigParams.ScreenTimeout) / 2) And objTimeExtension Is Nothing Then
                        objTimeExtension = New frmTimeExtension
                        objTimeExtension.Show()
                    End If

                    If TimeOutCounter >= Val(objConfigParams.ScreenTimeout) Then

                        If Not objTimeExtension Is Nothing Then
                            objTimeExtension.Close()
                            objTimeExtension.Dispose()
                            objTimeExtension = Nothing
                        End If

                        If Not CurrentServiceForm Is Nothing Then
                            CurrentServiceForm.Close()
                            CurrentServiceForm.Dispose()
                            CurrentServiceForm = Nothing
                        End If

                        TimeOutCounter = 0
                    Else
                        TimeOutCounter += 1
                    End If
                End If

            Else
                TimeOutCounter = 0
            End If

            tmrTimeout.Enabled = True
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

#End Region



End Class
