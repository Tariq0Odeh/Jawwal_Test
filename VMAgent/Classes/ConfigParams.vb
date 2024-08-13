Public Class ConfigParams

    Public RefreshInterval As String = ""
    Public ScreenTimeout As String = ""
    Public PlatformURL As String = ""
    Public PlatformAPIURL As String = ""
    Public CompanyId As String = ""
    Public UserId As String = ""
    Public UserPassword As String = ""
    Public TerminalId As String = ""
    Public CashRecyclerEnabled As String = ""
    Public CoinRecyclerEnabled As String = ""
    Public CoinRecyclerCOMPortNumber As String = ""
    Public CardDispenserCOMPortNumber As String = ""
    Public TimeToTransferToOutBoxDaily As String = ""
    Public DeploymentToolPath As String = ""
    Public DeploymentToolnewVersionFileName As String = ""
    Public DeploymentToolName As String = ""
    Public AllowDeploymentTool As String = ""
    Public ISEKYCEnabled As String = ""



    Public Shared Function GetConfigParams() As ConfigParams

        Dim objConfigParams As New ConfigParams

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

        Try
            objConfigParams.RefreshInterval = CType(configurationAppSettings.GetValue("RefreshInterval", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.RefreshInterval = "5000"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.ScreenTimeout = CType(configurationAppSettings.GetValue("ScreenTimeout", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.ScreenTimeout = "60000"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.PlatformURL = CType(configurationAppSettings.GetValue("PlatformURL", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.PlatformURL = "http://localhost:5050"
            ExceptionLogger.LogException(ex)
        End Try

        If objConfigParams.PlatformURL.EndsWith("/") = True Then
            objConfigParams.PlatformAPIURL = objConfigParams.PlatformURL & "api/TTTP/ProcessRequest"
        Else
            objConfigParams.PlatformURL = objConfigParams.PlatformURL & "/"
            objConfigParams.PlatformAPIURL = objConfigParams.PlatformURL & "api/TTTP/ProcessRequest"
        End If

        Try
            objConfigParams.CompanyId = CType(configurationAppSettings.GetValue("CompanyId", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CompanyId = ""
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.UserId = CType(configurationAppSettings.GetValue("UserId", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.UserId = ""
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.UserPassword = CType(configurationAppSettings.GetValue("UserPassword", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.UserPassword = ""
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.TerminalId = CType(configurationAppSettings.GetValue("TerminalId", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.TerminalId = ""
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.CashRecyclerEnabled = CType(configurationAppSettings.GetValue("CashRecyclerEnabled", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CashRecyclerEnabled = "N"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.CoinRecyclerEnabled = CType(configurationAppSettings.GetValue("CoinRecyclerEnabled", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CoinRecyclerEnabled = "N"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.CoinRecyclerCOMPortNumber = CType(configurationAppSettings.GetValue("CoinRecyclerCOMPortNumber", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CoinRecyclerCOMPortNumber = "2"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.CardDispenserCOMPortNumber = CType(configurationAppSettings.GetValue("CardDispenserCOMPortNumber", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.CardDispenserCOMPortNumber = "1"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.TimeToTransferToOutBoxDaily = CType(configurationAppSettings.GetValue("TimeToTransferToOutBoxDaily", GetType(System.String)), String)
            DateTime.Parse(CType(configurationAppSettings.GetValue("TimeToTransferToOutBoxDaily", GetType(System.String)), String)).ToString()

        Catch ex As Exception
            objConfigParams.TimeToTransferToOutBoxDaily = "3:30 am"
            ExceptionLogger.LogException(ex)
        End Try


        Try

            objConfigParams.DeploymentToolPath = CType(configurationAppSettings.GetValue("DeploymentToolPath", GetType(System.String)), String)


        Catch ex As Exception
            objConfigParams.DeploymentToolPath = "C:\DeploymentTool"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.DeploymentToolnewVersionFileName = CType(configurationAppSettings.GetValue("DeploymentToolnewVersionFileName", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.DeploymentToolnewVersionFileName = "newVersion.txt"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.DeploymentToolName = CType(configurationAppSettings.GetValue("DeploymentToolName", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.DeploymentToolName = "DeploymentTool.exe"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.AllowDeploymentTool = CType(configurationAppSettings.GetValue("AllowDeploymentTool", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.AllowDeploymentTool = "N"
            ExceptionLogger.LogException(ex)
        End Try

        Try
            objConfigParams.ISEKYCEnabled = CType(configurationAppSettings.GetValue("ISEKYCEnabled", GetType(System.String)), String)
        Catch ex As Exception
            objConfigParams.ISEKYCEnabled = "N"
            ExceptionLogger.LogException(ex)
        End Try
        Return objConfigParams

    End Function

End Class
