Public Class ConfigParams

    Public PlatformURL As String = "http://10.102.220.174"
    Public APPPlatformURL As String = "http://192.168.0.31/DataForm.aspx?VersionName=PublicURL&CompanyId=Vending&TerminalId=T00001"
    Public downloadHistoryFile As String = "download_history.txt"
    Public newVersionFile As String = "newVersion.txt"
    Public CompanyId As String = "BeyondKode"
    Public TerminalId As String = "T00001"
    Public appToKill As String = "VMAgent.exe"
    Public downloadLocation As String = "C:\DownloadedFiles\file.zip"
    Public extractionPath As String = "C:\VMAgent"
    Public backupPath As String = "C:\VMAgentBackup"
    Public RefreshInterval As Integer = 60000 ' 1 minute in milliseconds

    Public Shared Function GetConfigParams() As ConfigParams

        Dim objConfigParams As New ConfigParams

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

        Try
            objConfigParams.RefreshInterval = CType(configurationAppSettings.GetValue("RefreshInterval", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.RefreshInterval = "5000"

        End Try


        Try
            objConfigParams.TerminalId = CType(configurationAppSettings.GetValue("TerminalId", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.TerminalId = ""

        End Try
        Try
            objConfigParams.CompanyId = CType(configurationAppSettings.GetValue("CompanyId", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CompanyId = ""

        End Try
        Try
            objConfigParams.PlatformURL = CType(configurationAppSettings.GetValue("PlatformURL", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.PlatformURL = "http://localhost:5050"

        End Try



        If objConfigParams.PlatformURL.EndsWith("/") = True Then
            objConfigParams.APPPlatformURL = objConfigParams.PlatformURL & "/DataForm.aspx?VersionName=TerminalApps&CompanyId=" & objConfigParams.CompanyId & "&TerminalId=" & objConfigParams.TerminalId
        Else
            objConfigParams.PlatformURL = objConfigParams.PlatformURL & "/"
            objConfigParams.APPPlatformURL = objConfigParams.PlatformURL & "/DataForm.aspx?VersionName=TerminalApps&CompanyId=" & objConfigParams.CompanyId & "&TerminalId=" & objConfigParams.TerminalId
        End If


        Try
            objConfigParams.downloadHistoryFile = CType(configurationAppSettings.GetValue("downloadHistoryFile", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.downloadHistoryFile = "download_history.txt"

        End Try

        Try
            objConfigParams.newVersionFile = CType(configurationAppSettings.GetValue("newVersionFile", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.newVersionFile = "newVersion.txt"

        End Try

        Try
            objConfigParams.appToKill = CType(configurationAppSettings.GetValue("appToKill", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.appToKill = "VMAgent.exe"

        End Try


        Try
            objConfigParams.downloadLocation = CType(configurationAppSettings.GetValue("downloadLocation", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.downloadLocation = "C:\DownloadedFiles\file.zip"

        End Try

        Try
            objConfigParams.extractionPath = CType(configurationAppSettings.GetValue("extractionPath", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.extractionPath = "C:\YourApplicationPath"

        End Try
        Try
            objConfigParams.backupPath = CType(configurationAppSettings.GetValue("backupPath", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.backupPath = "C:\VMAgentBackup"

        End Try



        Return objConfigParams

    End Function

End Class
