Imports Mei.Bnr
Imports System.Threading

Friend Class BNRClientApplication
    Implements IDisposable

    Private Shared bnr As Bnr = New Bnr()
    Private Shared ev As AutoResetEvent = New AutoResetEvent(False)

    Private Shared BnrResetTimeOutInMS As Integer = 60000
    Private Shared BnrDefaultOperationTimeOutInMS As Integer = 10000
    Private Shared BnrDefaultCashInOperationTimeOutInMS As Integer = 60000
    Private Shared amountDue As Integer = 2000
    Private Shared insertedAmount As Integer = 0
    Private Shared overdue As Integer = 0

    Private Shared OCresult As BnrXfsErrorCode
    Private Shared cashOrder As XfsCashOrder


    Public Function AcceptAmount() As PaperMoney 'amount As Integer

        Dim retunredResult As New PaperMoney()
        Dim EventTimedOut = False
        ev.Reset()
        OCresult = BnrXfsErrorCode.NotUsed
        Try

            bnr.CashInStart()
        Catch ex As Exception
            bnr.CashInEnd()
            bnr.CashInStart()
        End Try
        ev.WaitOne(BnrDefaultOperationTimeOutInMS)
        If OCresult = BnrXfsErrorCode.Success Then
            While Not EventTimedOut 'amount > insertedAmount AndAlso
                System.Console.WriteLine("Please insert the bill(s).")
                ev.Reset()
                OCresult = BnrXfsErrorCode.NotUsed
                bnr.CashIn()
                If Not ev.WaitOne(BnrDefaultCashInOperationTimeOutInMS) OrElse OCresult = Not BnrXfsErrorCode.Success Then
                    EventTimedOut = True
                    bnr.Cancel()
                    ev.WaitOne(BnrDefaultOperationTimeOutInMS)
                    System.Console.WriteLine("Error during cashIn operation.")
                Else
                    If cashOrder.Denomination.Amount = 20000 Then
                        retunredResult.Cash200 += 1

                    ElseIf cashOrder.Denomination.Amount = 10000 Then
                        retunredResult.Cash100 += 1
                    ElseIf cashOrder.Denomination.Amount = 5000 Then
                        retunredResult.Cash50 += 1
                    ElseIf cashOrder.Denomination.Amount = 2000 Then
                        retunredResult.Cash20 += 1
                    End If
                    insertedAmount += cashOrder.Denomination.Amount
                End If 'if
            End While 'while
            If OCresult = BnrXfsErrorCode.Success Then
                ev.Reset()
                OCresult = BnrXfsErrorCode.NotUsed
                bnr.CashInEnd()
                ev.WaitOne(BnrDefaultOperationTimeOutInMS)
                System.Console.WriteLine("amount inserted :  " & cashOrder.Denomination.Amount.ToString())
            End If 'if
        End If 'if
        Return retunredResult

    End Function 'AcceptAmount

    Private Sub Bnr_OperationCompletedEvent(identificationId As Integer, operationId As OperationId, result As BnrXfsErrorCode, extendedResult As BnrXfsErrorCode, Data As Object)
        OCresult = result
        Select Case operationId
            Case OperationId.Reset
                System.Console.WriteLine("operationCompleteOccured on a reset ")

            Case OperationId.CashIn
                If result = BnrXfsErrorCode.Success Then
                    cashOrder = CType(Data, XfsCashOrder)
                End If 'if

                System.Console.WriteLine("operationCompleteOccured on a cashIn ")

            Case OperationId.CashInStart
                System.Console.WriteLine("operationCompleteOccured on a cashInStart")

            Case OperationId.CashInEnd
                If result = BnrXfsErrorCode.Success Then
                    cashOrder = CType(Data, XfsCashOrder)
                    System.Console.WriteLine("operationCompleteOccured on a cashInEnd ")
                Else
                    System.Console.WriteLine("Error during cashInEnd.")
                End If 'if

            Case OperationId.Dispense
                If result = BnrXfsErrorCode.Success Then
                    cashOrder = CType(Data, XfsCashOrder)
                    System.Console.WriteLine("operationCompleteOccured on a dispense ")
                End If 'if

            Case OperationId.Present
                If result = BnrXfsErrorCode.Success Then
                    cashOrder = CType(Data, XfsCashOrder)
                    System.Console.WriteLine("operationCompleteOccured on a present ")
                End If 'if

            Case Else
                System.Console.WriteLine("Unexpected OperationCompleteOccured ")
        End Select 'switch
        ev.Set()

        ' throw new Exception("The method or operation is not implemented.");
    End Sub 'Bnr_OperationCompletedEvent

    Public Function DispenseAmount(amount As PaperMoney) As PaperMoney
        Dim returnArray As New PaperMoney()
        Dim currencyCode = "ILS"
        ev.Reset()
        OCresult = BnrXfsErrorCode.NotUsed

        For i = 0 To amount.Cash200 - 1


            Dim dispenseValue = InnerDispense(20000, currencyCode)
            returnArray.Cash200 += dispenseValue / 100
        Next
        For i = 0 To amount.Cash100 - 1


            Dim dispenseValue = InnerDispense(10000, currencyCode)
            returnArray.Cash100 += dispenseValue / 100
        Next
        For i = 0 To amount.Cash50 - 1

            Dim dispenseValue = InnerDispense(5000, currencyCode)
            returnArray.Cash50 += dispenseValue / 100
        Next
        For i = 0 To amount.Cash20 - 1
            Dim dispenseValue = InnerDispense(2000, currencyCode)
            returnArray.Cash20 += dispenseValue / 100
        Next





        Return returnArray

    End Function 'DispenseAmount

    Private Function InnerDispense(AmountOfMoney As Integer, CurrencyCode As String)
        Dim returnedValue As Integer = 0
        bnr.Dispense(AmountOfMoney, CurrencyCode)
        If Not ev.WaitOne(BnrDefaultOperationTimeOutInMS) OrElse OCresult = Not BnrXfsErrorCode.Success Then
            System.Console.WriteLine("Error during Dispense.")
        Else
            ev.Reset()
            OCresult = BnrXfsErrorCode.NotUsed
            returnedValue = bnr.Present()
            If Not ev.WaitOne(BnrDefaultOperationTimeOutInMS) OrElse OCresult = Not BnrXfsErrorCode.Success Then
                System.Console.WriteLine("Error during present.")
                System.Console.WriteLine("Banknotes may not have been taken by the user.")
            End If 'if               
        End If 'if
        Return returnedValue
    End Function
    Public Sub New()

        AddHandler Bnr.OperationCompletedEvent, AddressOf Bnr_OperationCompletedEvent
        Try
            bnr.Open()
            MakeBnrOperational()
            System.Console.WriteLine("ok")
            'AcceptAmount(amountDue)
            'overdue = insertedAmount - amountDue
            'If overdue > 0 Then
            'DispenseAmount(overdue)
            'End If 'if

        Catch e As Mei.Bnr.BnrUsbException
            System.Console.WriteLine("USB error ...")
            System.Console.WriteLine(e.ToString())
        End Try 'try

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Cleanup code here
        ' Dispose of unmanaged resources, close files, etc.
        If bnr IsNot Nothing Then
            Try
                bnr.Close()
            Catch e As Mei.Bnr.BnrUsbException
                System.Console.WriteLine("BNR Already closed ...")
                System.Console.WriteLine(e.ToString())
            End Try 'try
        End If
    End Sub


    Private Shared Sub MakeBnrOperational()

        Dim bnrStatus As Mei.Bnr.Status = bnr.Status
        If Not (bnrStatus.DeviceStatus = DeviceStatus.OnLine) Then
            ev.Reset()
            bnr.Reset()
            ev.WaitOne(BnrResetTimeOutInMS)
        End If 'if

    End Sub 'MakeBnrOperational

End Class 'BNRClientApplication

