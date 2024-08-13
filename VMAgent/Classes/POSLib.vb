Imports CashierAgentDesktopDLL

Public Class POSLib

    Dim posObj As POS
    Dim baudRate As Integer = 9600
    Dim comPort As String = "COM7"

    Public Sub New(comPort As Integer, baudRate As Integer)

        posObj = New POS()
        posObj.baudRate = baudRate
        posObj.comPort = "COM" + comPort.ToString()

    End Sub

    ''' <summary>
    ''' Purchase
    ''' </summary>
    ''' <param name="TransIndexCode">Trans Index Code from your system</param>
    ''' <param name="TransAmount">Trans Amount in fils ex:100 = 0.1 jd</param>
    ''' <param name="CurrencyCode"> ex: 400 Means JOD </param>
    ''' <param name="EnableReceipt">Enable Receipt</param>
    ''' <param name="SkipConfirmProcedure">Skip Confirm Procedure</param>
    ''' <param name="Timeout">Timeout</param>
    ''' <returns></returns>
    Public Function Purchase(ByVal TransIndexCode As String, ByVal TransAmount As String, ByVal CurrencyCode As Integer, ByVal EnableReceipt As Integer, ByVal SkipConfirmProcedure As Integer, ByVal timeout As Integer) As String
        Dim ReturnedValue As String = ""

        ReturnedValue = posObj.Purchase(TransIndexCode, TransAmount, CurrencyCode, EnableReceipt, SkipConfirmProcedure, timeout)

        Return ReturnedValue
    End Function

    ''' <summary>
    ''' Refund
    ''' </summary>
    ''' <param name="TransIndexCode">Trans Index Code from your system</param>
    ''' <param name="TransID"> Transaction ID for the Transaction that will be refunded</param>
    ''' <param name="CurrencyCode"> ex: 400 Means JOD </param>
    ''' <param name="EnableReceipt">Enable Receipt</param>
    ''' <param name="SkipConfirmProcedure">Skip Confirm Procedure</param>
    ''' <param name="timeout">timeout</param>
    ''' <returns></returns>
    Public Function Refund(ByVal TransIndexCode As String, ByVal TransID As String, ByVal CurrencyCode As Integer, ByVal EnableReceipt As Integer, ByVal SkipConfirmProcedure As Integer, ByVal timeout As Integer) As String
        Dim ReturnedValue As String = ""

        ReturnedValue = posObj.Refund(TransIndexCode, TransID, CurrencyCode, EnableReceipt, SkipConfirmProcedure, timeout)

        Return ReturnedValue
    End Function

End Class
