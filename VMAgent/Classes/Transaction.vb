Public Class Transaction

    Public Property TransactionReference As String = ""
    Public Property TransactionType As String = ""
    Public Property TerminalId As String = ""
    Public Property ServiceNumber As String = ""
    Public Property TransactionAmount As Decimal = 0.0
    Public Property PaidAmount As Decimal = 0.0
    Public Property ReturnedAmount As Decimal = 0.0
    Public Property CustomerPhoto1 As String = ""
    Public Property CustomerPhoto2 As String = ""
    Public Property CustomerPhoto3 As String = ""
    Public Property DocumentPhoto As String = ""
    Public Property CustomerVideo As String = ""
    Public Property MoreDetails1 As String = ""
    Public Property MoreDetails2 As String = ""
    Public Property MoreDetails3 As String = ""
    Public Property MoreDetails4 As String = ""
    Public Property MoreDetails5 As String = ""
    Public Property TransactionDateTime As String = ""
    Public Property TransactionStatus As String = ""

    Public Sub SaveTransactionDetails(PaymentType As String, Optional isCancelled As Boolean = False)

        Try
            Dim isUpdate = "Y"
            If isCancelled Then
                isUpdate = "N"
            End If

            Dim objConfigParams As New ConfigParams
            objConfigParams = ConfigParams.GetConfigParams()

            Dim LoggingString As String = ""
            Dim EnquiryString As String = ""
            EnquiryString = "<OpenAPIRequest>" & vbNewLine
            EnquiryString &= "  <CompanyId>" & objConfigParams.CompanyId & "</CompanyId>" & vbNewLine
            EnquiryString &= "  <UserId>" & objConfigParams.UserId & "</UserId>" & vbNewLine
            EnquiryString &= "  <UserPassword>" & objConfigParams.UserPassword & "</UserPassword>" & vbNewLine
            EnquiryString &= "  <RequestType>ExecuteAPIProxy</RequestType>" & vbNewLine
            EnquiryString &= "  <TransactionReference>" & APIs.GetNewId() & "</TransactionReference>" & vbNewLine
            EnquiryString &= "  <TransactionReferenceEncrypted>NO</TransactionReferenceEncrypted>" & vbNewLine
            EnquiryString &= "  <RequestParam1>SaveTransactionDetails</RequestParam1>" & vbNewLine
            EnquiryString &= "  <RequestParams>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionReference</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TransactionReference & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TransactionType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TerminalId</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TerminalId & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ServiceNumber</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ServiceNumber & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TransactionAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>PaidAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & PaidAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>ReturnedAmount</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & ReturnedAmount & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            LoggingString &= EnquiryString
            EnquiryString &= "      <ParamName>CustomerPhoto1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CustomerPhoto1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CustomerPhoto2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerPhoto3</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CustomerPhoto3 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>DocumentPhoto</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & DocumentPhoto & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>CustomerVideo</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & CustomerVideo & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MoreDetails1</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MoreDetails1 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MoreDetails2</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MoreDetails2 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MoreDetails3</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MoreDetails3 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MoreDetails4</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MoreDetails4 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>MoreDetails5</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & MoreDetails5 & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            LoggingString &= "      <ParamName>TransactionDateTime</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TransactionDateTime & "</ParamValue>" & vbNewLine
            LoggingString &= "      <ParamValue>" & TransactionDateTime & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>TransactionStatus</ParamName>" & vbNewLine
            LoggingString &= "      <ParamName>TransactionStatus</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & TransactionStatus & "</ParamValue>" & vbNewLine
            LoggingString &= "      <ParamValue>" & TransactionStatus & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>PaymentType</ParamName>" & vbNewLine
            LoggingString &= "      <ParamName>PaymentType</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & PaymentType & "</ParamValue>" & vbNewLine
            LoggingString &= "      <ParamValue>" & PaymentType & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "    <OpenAPIParam>" & vbNewLine
            EnquiryString &= "      <ParamName>IsUpdate</ParamName>" & vbNewLine
            LoggingString &= "      <ParamName>IsUpdate</ParamName>" & vbNewLine
            EnquiryString &= "      <ParamValue>" & isUpdate & "</ParamValue>" & vbNewLine
            LoggingString &= "      <ParamValue>" & isUpdate & "</ParamValue>" & vbNewLine
            EnquiryString &= "    </OpenAPIParam>" & vbNewLine
            EnquiryString &= "  </RequestParams>" & vbNewLine
            EnquiryString &= "</OpenAPIRequest>"

            ExceptionLogger.LogInfo("SaveTransactionDetails:")
            ExceptionLogger.LogInfo("----------------------Request:")
            ExceptionLogger.LogInfo(LoggingString)
            Dim RSI As New RESTServiceInvoker
            Dim Response As String = RSI.InvokeService(objConfigParams.PlatformAPIURL, EnquiryString, "application/xml")
            ExceptionLogger.LogInfo("Request----------------------:")
            ExceptionLogger.LogInfo(Response)
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub

End Class
