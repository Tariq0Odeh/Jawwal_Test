Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json.Linq

Public Class APIs
    Public Enum APIReturnedValue
        Success
        Failed
        Unkonwn
    End Enum
    Public Shared Function GetTerminalDetails() As Terminal

        Dim objTerminal As New Terminal

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>GetTerminalDetails</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            If Globals.IsVerbose Then
                Dim logByDay As String = ExceptionLogger.GetLogByDay(Date.Today)
                Dim recyclersLogByDay As String = ExceptionLogger.GetLogByDay(Date.Today, True)

                Dim yesterdaylogByDay As String = ExceptionLogger.GetLogByDay(Date.Today.AddDays(-1))
                Dim yesterdayrecyclersLogByDay As String = ExceptionLogger.GetLogByDay(Date.Today.AddDays(-1), True)

                Dim daybeforeyesterdaylogByDay As String = ExceptionLogger.GetLogByDay(Date.Today.AddDays(-2))
                Dim daybeforeyesterdayrecyclersLogByDay As String = ExceptionLogger.GetLogByDay(Date.Today.AddDays(-2), True)

                'To get a specafic date logs
                'Dim daylogByDay24072024 As String = ExceptionLogger.GetLogByDay(New Date(2024, 7, 24))
                'Dim daylogByDay24072024dayrecyclersLogByDay As String = ExceptionLogger.GetLogByDay(New Date(2024, 7, 24), True)

                Dim log =  " Today's Log                :" & vbNewLine & logByDay & vbNewLine & vbNewLine & "*-----------------Recycler Log-----------------*" & vbNewLine & vbNewLine & recyclersLogByDay & vbNewLine & vbNewLine
                log &= " *********************************************************END of day****************************************************************** "
                log &= " Yesterday's Log            :" & vbNewLine & yesterdaylogByDay & vbNewLine & vbNewLine & "*-----------------Recycler Log-----------------*" & vbNewLine & vbNewLine & yesterdayrecyclersLogByDay & vbNewLine
                log &= " *********************************************************END of day****************************************************************** "
                log &= " Day before Yesterday's Log :" & vbNewLine & daybeforeyesterdaylogByDay & vbNewLine & vbNewLine & "*-----------------Recycler Log-----------------*" & vbNewLine & vbNewLine & daybeforeyesterdayrecyclersLogByDay & vbNewLine
                'log &= " *********************************************************END of day****************************************************************** "
                'log &= " Day 24072024 Log :" & vbNewLine & daylogByDay24072024 & vbNewLine & vbNewLine & "*-----------------Recycler Log-----------------*" & vbNewLine & vbNewLine & daylogByDay24072024dayrecyclersLogByDay & vbNewLine
                EnquiryString &= "    <OpenAPIParam>" & vbNewLine
                EnquiryString &= "      <ParamName>VerboseLog</ParamName>" & vbNewLine
                EnquiryString &= "      <ParamValue>" & vbNewLine
                EnquiryString &= log
                EnquiryString &= "      </ParamValue>" & vbNewLine
                EnquiryString &= "    </OpenAPIParam>" & vbNewLine
                Globals.IsVerbose = False
            End If

            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Dim TerminalDetails As String = APIs.GetXMLItemValue(Response, "ResponseData")

            If TerminalDetails.Split(Chr(169)).Length = 3 Then             'objTerminal.TerminalId & Chr(169) & objTerminal.TerminalStatus & Chr(169) & objTerminal.LastCommand

                objTerminal.TerminalId = TerminalDetails.Split(Chr(169))(0)
                objTerminal.TerminalStatus = TerminalDetails.Split(Chr(169))(1)
                objTerminal.LastCommand = TerminalDetails.Split(Chr(169))(2)

                If objTerminal.LastCommand = "IsVerbose" Then
                    Globals.IsVerbose = True
                    objTerminal.LastCommand = ""
                ElseIf objTerminal.LastCommand.Contains("VMAgent") Then
                    'CurrentBuildVersion

                    If CurrentBuildVersion <> objTerminal.LastCommand Then
                        If objConfigParams.AllowDeploymentTool = "Y" Then


                            Globals.EnsureDirectoryExists(objConfigParams.DeploymentToolPath)

                            UpdateCurrentBuildVersion(objConfigParams.DeploymentToolPath & "\" & objConfigParams.DeploymentToolnewVersionFileName, objTerminal.LastCommand)
                            UpdateCurrentBuildVersion(objConfigParams.DeploymentToolnewVersionFileName, objTerminal.LastCommand)
                        End If
                    End If
                    objTerminal.LastCommand = ""
                End If

                If objTerminal.LastCommand <> "" Then
                    APIs.ProcessLastCommand(objTerminal.LastCommand)
                End If

            Else
                objTerminal.TerminalStatus = "OFFLINE"
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return objTerminal

    End Function

    Private Shared Sub UpdateCurrentBuildVersion(downloadHistoryFile As String, lastCommand As String)


        If Not File.Exists(downloadHistoryFile) Then
            ' Create the file and optionally write initial content
            Dim sw As StreamWriter = File.CreateText(downloadHistoryFile)
            sw.Close()
        End If
        System.IO.File.WriteAllText(downloadHistoryFile, lastCommand)
    End Sub

    Public Shared Sub ProcessLastCommand(ByVal LastCommand As String)

        Try

            If LastCommand.ToUpper() = "SCREENSHOT" Then

                Dim objConfigParams As New ConfigParams
                objConfigParams = ConfigParams.GetConfigParams()

                Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                Dim ScreenshotImage As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                Dim g As Graphics = Graphics.FromImage(ScreenshotImage)
                g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)

                Dim Screenshot As String = ""

                Using ms As New MemoryStream()
                    ScreenshotImage.Save(ms, Imaging.ImageFormat.Png)
                    Dim imageBytes As Byte() = ms.ToArray()
                    Screenshot = Convert.ToBase64String(imageBytes)
                End Using

                Dim ReponseString As String = ""
                ReponseString = "<OpenAPIRequest>" & vbNewLine
                ReponseString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
                ReponseString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
                ReponseString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
                ReponseString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
                ReponseString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
                ReponseString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
                ReponseString &= "  <RequestParam1>SetTerminalScreenshot</RequestParam1>" & vbNewLine
                ReponseString &= "  <RequestParams>" & vbNewLine
                ReponseString &= "    <OpenAPIParam>" & vbNewLine
                ReponseString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
                ReponseString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
                ReponseString &= "    </OpenAPIParam>" & vbNewLine
                ReponseString &= "    <OpenAPIParam>" & vbNewLine
                ReponseString &= "      <ParamName>Screenshot</ParamName>" & vbNewLine
                ReponseString &= "      <ParamValue>" & Screenshot & "</ParamValue>" & vbNewLine
                ReponseString &= "    </OpenAPIParam>" & vbNewLine
                ReponseString &= "  </RequestParams>" & vbNewLine
                ReponseString &= "</OpenAPIRequest>"

                Dim ResRSI As New RESTServiceInvoker
                ResRSI.InvokeService(objConfigParams.PlatformAPIURL, ReponseString, "application/xml")

            ElseIf LastCommand.ToUpper() = "RESTART" Then

                Dim objExitWin As New cWrapExitWindows
                objExitWin.ExitWindows(cWrapExitWindows.Action.Restart, True)

            ElseIf LastCommand.ToUpper() = "SHUTDOWN" Then

                Dim objExitWin As New cWrapExitWindows
                objExitWin.ExitWindows(cWrapExitWindows.Action.Shutdown, True)

            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub

    Public Shared Function CheckRefill(ByVal msisdn As String, ByVal amount As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteCheckRefill</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>amount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & amount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function RefillBalance(ByVal msisdn As String, ByVal amount As String, ByVal referenceNumber As String, ByVal paymentType As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteRefillBalance</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>amount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & amount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function SendOTP(ByVal msisdn As String, ByVal Service As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteSendOTP</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Service</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Service & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifyOTP(ByVal msisdn As String, ByVal Service As String, ByVal Pin As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifyOTP</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Service</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Service & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Pin</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Pin & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetInvoices(ByVal number As String, ByVal userType As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetInvoices</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>number</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & number & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>userType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & userType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function PayJawwalInvoices(ByVal msisdn As String, ByVal payments As String, ByVal referenceNumber As String, ByVal paymentType As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecutePayJawwalInvoices</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>payments</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & payments & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifyFixedLine(ByVal number As String, ByVal idNumber As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifyFixedLine</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>number</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & number & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>idNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & idNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function PayPaltelInvoices(ByVal msisdn As String, ByVal payments As String, ByVal referenceNumber As String, ByVal cardNumber As String, ByVal paymentType As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecutePayPaltelInvoices</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>payments</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & payments & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>cardNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & cardNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetRecommendedBundles(ByVal msisdn As String, ByVal type As String, ByVal countryCode As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetRecommendedBundles</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>type</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & type & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>countryCode</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & countryCode & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function SetBundles(ByVal msisdn As String, ByVal bundleId As String, ByVal paymentType As String, ByVal referenceNumber As String, ByVal type As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteSetBundles</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>bundleId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & bundleId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>type</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & type & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetBrands(ByVal msisdn As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetBrands</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetDenominations(ByVal msisdn As String, ByVal brandCode As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetDenominations</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>brandCode</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & brandCode & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function PurchaseDigitalGoods(ByVal msisdn As String, ByVal denominationCode As String, ByVal brandCode As String, ByVal referenceNumber As String, ByVal paymentType As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecutePurchaseDigitalGoods</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>denominationCode</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & denominationCode & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>brandCode</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & brandCode & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifyIdNumber(ByVal msisdn As String, ByVal idNumber As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifyIdNumber</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>idNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & idNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function EkycCheck(ByVal Image As String, ByVal Video As String, ByVal ekycType As String) As Boolean
        'ekycType: id/passport

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteEkycCheck</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Image</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Image & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Video</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Video & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ekycType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ekycType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifySerialNumber(ByVal msisdn As String, ByVal serialNumber As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifySerialNumber</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>serialNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & serialNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function SendEmailOTP(ByVal msisdn As String, ByVal email As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteSendEmailOTP</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>email</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & email & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifyEmailOTP(ByVal msisdn As String, ByVal otp As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifyEmailOTP</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>otp</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & otp & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetQuestions() As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetQuestions</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function VerifyAnswers(ByVal msisdn As String, ByVal answer1 As String, ByVal answer2 As String, ByVal answer3 As String, ByVal answer4 As String) As Boolean

        Dim Ret As Boolean = False

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteVerifyAnswers</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>answer1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & answer1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>answer2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & answer2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>answer3</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & answer3 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>answer4</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & answer4 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = True
            End If

        Catch ex As Exception
        End Try

        Return Ret

    End Function

    Public Shared Function GetSimSwapPrice(ByVal msisdn As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetSimSwapPrice</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If GetJSONItemValue(Response, "code") = "0" Then
                Ret = GetJSONItemValue(Response, "data")
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function ConfirmSimSwap(ByVal msisdn As String, ByVal email As String, ByVal isEsim As String, ByVal simNumber As String, ByVal referenceNumber As String, ByVal paymentType As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteConfirmSimSwap</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>email</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & email & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>isEsim</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & isEsim & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>simNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & simNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>referenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & referenceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>paymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & paymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function SearchForNumber(ByVal entry As String, ByVal pattern As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteSearchForNumber</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>entry</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & entry & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>pattern</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & pattern & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetPaymentTypeWithPackages() As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteGetPaymentTypeWithPackages</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function ExtractUserInfo(ByVal Image As String, ByVal Video As String, ByVal ekycType As String, ByVal msisdnToReserve As String) As String
        'ekycType: id/passport

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteExtractUserInfo</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Image</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Image & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Video</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Video & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ekycType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ekycType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdnToReserve</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdnToReserve & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function ConfirmNewSIM(ByVal msisdn As String, ByVal IdNumber As String, ByVal SimNumber As String, ByVal FullName As String, ByVal DateOfBirth As String, ByVal Gender As String, ByVal City As String, ByVal IsEsim As String, ByVal DocumentType As String, ByVal Document As String, ByVal MsisdnType As String, ByVal PaymentType As String, ByVal PackageCode As String, ByVal Email As String, ByVal ContactNumber As String, ByVal ReservationID As String, ByVal resourceID As String) As APIReturnedValue
        'paymentType: Balance/Visa/Cash/OnBill

        Dim Ret As APIReturnedValue = APIReturnedValue.Unkonwn

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>ExecuteConfirmNewSIM</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>msisdn</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & msisdn & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>IdNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & IdNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>SimNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & SimNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>FullName</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & FullName & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>DateOfBirth</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & DateOfBirth & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Gender</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Gender & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>City</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & City & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>IsEsim</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & IsEsim & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>DocumentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & DocumentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Document</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Document & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MsisdnType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MsisdnType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>PaymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & PaymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>PackageCode</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & PackageCode & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>Email</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & Email & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ContactNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ContactNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ReservationID</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ReservationID & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ReferenceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & "" & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CurrentTransaction.CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>resourceID</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & resourceID & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Response = APIs.GetXMLItemValue(Response, "ResponseData")

            If Response.ToUpper = "True".ToUpper Then
                Ret = APIReturnedValue.Success
            ElseIf Response.ToUpper = "False".ToUpper Then
                Ret = APIReturnedValue.Failed
            End If

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetReceiptDetails(ByVal ReceiptId As String) As String

        Dim Ret As String = ""

        Try

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>GetReceiptDetails</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & objConfigParams.TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ReceiptId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ReceiptId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")

            Ret = APIs.GetXMLItemValue(Response, "ResponseData")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Return Ret

    End Function

    Public Shared Function GetNewId() As String

        Dim NewId As String
        NewId = Date.Now.ToString("yyMMddHHmmssffffff") & System.Guid.NewGuid.ToString("N").ToUpper

        Return NewId

    End Function

    Public Shared Function GetXMLItemValue(ByVal XMLString As String, ByVal ItemName As String) As String

        Dim XMLItemValue As String = ""

        Try

            Dim RespXMLDoc As New XmlDocument
            RespXMLDoc.LoadXml(XMLString)
            If Not RespXMLDoc.GetElementsByTagName(ItemName)(0) Is Nothing Then
                XMLItemValue = RespXMLDoc.GetElementsByTagName(ItemName)(0).InnerText
            End If

        Catch ex As Exception
            XMLItemValue = ""
        End Try

        Return XMLItemValue

    End Function

    Public Shared Function GetJSONItemValue(ByVal JSONString As String, ByVal ItemName As String) As String

        Dim JSONItemValue As String = ""

        Try

            Dim jsonObj As JObject = JObject.Parse(JSONString)
            JSONItemValue = jsonObj(ItemName)

        Catch ex As Exception
            JSONItemValue = ""
            ExceptionLogger.LogException(ex)
        End Try

        Return JSONItemValue

    End Function

End Class
