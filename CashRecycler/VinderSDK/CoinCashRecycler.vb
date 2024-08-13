Imports Mei
Imports Mei.Bnr
Imports System.Threading

Public Class CoinCashRecycler
    Implements IDisposable

    Public Event OnCoinCashDeposit(ByVal Amount As Decimal)

    Public bnr As Bnr = New Bnr()
    Private cyCR6 As CsCYCR6
    Private cr6IsPoll As Boolean = False

    Private DepositInCoinThread As Threading.Thread
    Private DepositInCashThread As Threading.Thread
    Public StopAcceptingCoinCash As Boolean = False
    Private IsAcceptingMode As Boolean = False
    Public TotalInputAmount As Decimal = 0
    Private isOpenCashMachine As Boolean
    Private isOpenCoinMachine As Boolean
    Private coinComNum As Integer



    Public ev As AutoResetEvent = New AutoResetEvent(False)
    Private BnrResetTimeOutInMS As Integer = 60000
    Private BnrDefaultOperationTimeOutInMS As Integer = 10000
    Private BnrDefaultCashInOperationTimeOutInMS As Integer = 60000
    Private amountDue As Integer = 2000
    Private overdue As Integer = 0
    Private OCresult As BnrXfsErrorCode
    Private cashOrder As XfsCashOrder
    Public isCashMachineAvailable = False
    Public isCoinMachineAvailable = False

    Public Sub New(ByVal isOpenCashMachine As Boolean, ByVal isOpenCoinMachine As Boolean, ByVal coinComNum As Integer)
        Me.isOpenCashMachine = isOpenCashMachine
        Me.isOpenCoinMachine = isOpenCoinMachine
        Me.coinComNum = coinComNum
    End Sub
    Public Enum RecylcersStatusAfterInit
        BothOnline
        CashOnlyOffline
        CoinOnlyOffline
        BothOffline
    End Enum

    Dim lockInitCoinCashRecyclers = New Object()

    Public Function InitCoinCashRecyclers() As RecylcersStatusAfterInit
        SyncLock lockInitCoinCashRecyclers

            Dim returnValue As RecylcersStatusAfterInit = RecylcersStatusAfterInit.BothOffline

            isCashMachineAvailable = False
            If isOpenCashMachine Then
                isCashMachineAvailable = AttempOpenCashMachine()
            Else
                isCashMachineAvailable = True
            End If

            isCoinMachineAvailable = False
            If isOpenCoinMachine Then
                isCoinMachineAvailable = AttempOpenCoinMachine(coinComNum)
            Else
                isCoinMachineAvailable = True
            End If

            If isCashMachineAvailable And isCoinMachineAvailable Then
                returnValue = RecylcersStatusAfterInit.BothOnline
            ElseIf isCashMachineAvailable And Not isCoinMachineAvailable Then
                returnValue = RecylcersStatusAfterInit.CoinOnlyOffline
            ElseIf Not isCashMachineAvailable And isCoinMachineAvailable Then
                returnValue = RecylcersStatusAfterInit.CashOnlyOffline
            Else
                returnValue = RecylcersStatusAfterInit.BothOffline
            End If

            Return returnValue
        End SyncLock
    End Function

    Dim lockAttempOpenCashMachine = New Object()
    Private Function AttempOpenCashMachine() As Boolean

        SyncLock lockAttempOpenCashMachine


            Dim isOpened As Boolean = False

            Try

                Try
                    bnr.Open()
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try

                Try
                    Dim returnedValue = bnr.Reset()
                    Thread.Sleep(20000)
                    If returnedValue <= 0 Then
                        Try
                            bnr.Cancel()
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)
                        End Try
                        Try
                            bnr.Close()
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)
                        End Try
                        Try
                            bnr.Dispose()
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)
                        End Try
                        Try
                            bnr.Open()
                        Catch ex As Exception

                            ExceptionLogger.LogException(ex)
                        End Try
                        Try

                            bnr.Reset()
                        Catch ex As Exception

                            ExceptionLogger.LogException(ex)
                        End Try
                    End If

                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try

                Dim bnrStatus As Mei.Bnr.Status = bnr.Status
                If bnrStatus.DeviceStatus = DeviceStatus.OnLine Then
                    isOpened = True

                Else
                    Threading.Thread.Sleep(5000)
                    Try
                        bnr.Reset()
                        If bnrStatus.DeviceStatus = DeviceStatus.OnLine Then
                            isOpened = True
                        Else
                            isCashMachineAvailable = False
                        End If
                    Catch ex As Exception
                        ExceptionLogger.LogException(ex)
                    End Try
                End If

            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
            ExceptionLogger.LogInfo("AttempOpenCashMachine->isOpened=" & isOpened)
            Return isOpened
        End SyncLock
    End Function

    Dim lockAttempOpenCoinMachine = New Object()
    Private Sub AttempOpenCoinMachine()
        SyncLock lockAttempOpenCoinMachine
            Try
                AttempOpenCoinMachine(coinComNum)
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
        End SyncLock
    End Sub
    Dim AttempOpenCoinMachineLock As New Object()
    Private Function AttempOpenCoinMachine(ByVal coinComNum As Integer) As Boolean
        SyncLock AttempOpenCoinMachineLock

            Dim isOpened As Boolean = False
            If cyCR6 Is Nothing Then
                cyCR6 = New CsCYCR6()
                cyCR6.setSerialPort(New IO.Ports.SerialPort())
                cyCR6.openPort(coinComNum, 115200)
            Else
                cyCR6.closePort()
                cyCR6.setSerialPort(New IO.Ports.SerialPort())
                cyCR6.openPort(coinComNum, 115200)
            End If

            Dim poll = cyCR6.pollCmd()
            If poll > 0 Then
                cr6IsPoll = True
                isOpened = True
            Else
                isOpened = False
            End If
            ExceptionLogger.LogInfo("AttempOpenCoinMachine->isOpened=" & isOpened)
            Return isOpened
        End SyncLock
    End Function

    Dim StartAcceptingCoinCashLock As New Object()
    Public Sub StartAcceptingCoinCash(ByVal isAcceptingFromCash As Boolean, ByVal isAcceptingFromCoin As Boolean)
        SyncLock StartAcceptingCoinCashLock


            ExceptionLogger.LogInfo("StartAcceptingCoinCash")
            TotalInputAmount = 0
            IsAcceptingMode = True
            StopAcceptingCoinCash = False

            If isAcceptingFromCash = True Then
                AddHandler Bnr.OperationCompletedEvent, AddressOf Bnr_OperationCompletedEvent
                DepositInCashThread = New Threading.Thread(AddressOf StartAcceptingCash)
                DepositInCashThread.Start()

            End If
            If isAcceptingFromCoin = True Then

                DepositInCoinThread = New Threading.Thread(AddressOf StartAcceptingCoin)
                DepositInCoinThread.Start()

            End If
        End SyncLock
    End Sub

    Private Sub StartAcceptingCash()
        Dim bnrStatus As Mei.Bnr.Status = bnr.Status
        If bnrStatus.DeviceStatus = DeviceStatus.OnLine Then



            'If CashInStarted > 0 Then
            Threading.Thread.Sleep(1000)
            MakeBnrOperational()
            AcceptAmount()
        Else
            isCashMachineAvailable = False
        End If
    End Sub

    Dim lockStartAcceptingCoin = New Object()
    Private Sub StartAcceptingCoin()
        SyncLock lockStartAcceptingCoin

            Dim poll As Integer = cyCR6.pollCmd()
            If poll >= 1 Then
                'cyCR6.clearBuf()
                cyCR6.modifyBalanceTosingle(1, 0)
                cyCR6.modifyBalanceTosingle(2, 0)
                cyCR6.modifyBalanceTosingle(3, 0)
                cyCR6.modifyBalanceTosingle(4, 0)
                cyCR6.modifyBalanceTosingle(5, 0)
                cyCR6.modifyBalanceTosingle(6, 0)

                Dim byte1 As Byte, byte2 As Byte
                Dim bytes = New Byte(7) {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}

                Dim requestRegister As Integer = cyCR6.requestRegisterCmd(byte1, byte2)
                If requestRegister <> 1 Then
                    Threading.Thread.Sleep(50)
                    requestRegister = cyCR6.requestRegisterCmd(byte1, byte2)
                End If

                If requestRegister = 1 Then
                    If Not ((byte1 And bytes(4)) > 0 Or (byte1 And bytes(5)) > 0) Then
                        AcceptingCoin()

                    Else
                        AttempOpenCoinMachine()
                        poll = cyCR6.pollCmd()
                        If poll >= 1 Then
                            'cyCR6.clearBuf()
                            cyCR6.modifyBalanceTosingle(1, 0)
                            cyCR6.modifyBalanceTosingle(2, 0)
                            cyCR6.modifyBalanceTosingle(3, 0)
                            cyCR6.modifyBalanceTosingle(4, 0)
                            cyCR6.modifyBalanceTosingle(5, 0)
                            cyCR6.modifyBalanceTosingle(6, 0)
                            Dim byte1_2 As Byte, byte2_2 As Byte

                            requestRegister = cyCR6.requestRegisterCmd(byte1_2, byte2_2)
                            If requestRegister <> 1 Then
                                Threading.Thread.Sleep(50)
                                requestRegister = cyCR6.requestRegisterCmd(byte1_2, byte2_2)
                            End If

                            If Not ((byte1 And bytes(4)) > 0 Or (byte1 And bytes(5)) > 0) Then
                                AcceptingCoin()
                            End If
                        End If
                    End If
                End If
            End If
        End SyncLock
    End Sub

    Dim lockAcceptingCoin = New Object()
    Public Function AcceptingCoin() As Decimal
        SyncLock lockAcceptingCoin
            Dim objCoin As Coin = New Coin()
            Threading.Thread.Sleep(50)
            Dim requestCoinInByType As Integer = cyCR6.requestCoinInByType()
            If requestCoinInByType <> 1 Then
                Threading.Thread.Sleep(50)
                requestCoinInByType = cyCR6.requestCoinInByType()
            End If
            If requestCoinInByType = 1 Then

                Dim num1 As Integer = 0, num2 As Integer = 0, num3 As Integer = 0, num4 As Integer = 0, num5 As Integer = 0, num6 As Integer = 0

                objCoin.Coin10 = 0
                objCoin.Coin5 = 0
                objCoin.Coin2 = 0
                objCoin.Coin1New = 0
                objCoin.Coin1old = 0
                objCoin.Coin05 = 0

                Dim modifyStatus As Integer = cyCR6.startAcceptCoin(&H3F, 0)

                Dim RetryCounter As Integer = 0

                While modifyStatus > 0 And RetryCounter < 80

                    If StopAcceptingCoinCash = True Then
                        If RetryCounter = 0 Then
                            cyCR6.startAcceptCoin(0, 0)
                        End If
                        RetryCounter += 1
                    End If

                    Threading.Thread.Sleep(50)
                    requestCoinInByType = cyCR6.requestCoinInByType()
                    If requestCoinInByType <> 1 Then
                        Threading.Thread.Sleep(50)
                        requestCoinInByType = cyCR6.requestCoinInByType()
                    End If

                    cyCR6.getCoinNumberTo6(num1, num2, num3, num4, num5, num6)

                    If objCoin.Coin10 <> num1 Or objCoin.Coin5 <> num2 Or objCoin.Coin2 <> num3 Or objCoin.Coin1New <> num4 Or objCoin.Coin1old <> num5 Or objCoin.Coin05 <> num6 Then
                        Dim Amount As Decimal = 0
                        Amount = ((num1 - objCoin.Coin10) * 10) + ((num2 - objCoin.Coin5) * 5) + ((num3 - objCoin.Coin2) * 2) + ((num4 - objCoin.Coin1New)) + ((num5 - objCoin.Coin1old)) + ((num6 - objCoin.Coin05) * 0.5)
                        TotalInputAmount += Amount
                        If StopAcceptingCoinCash = False Then
                            RaiseEvent OnCoinCashDeposit(Amount)
                        End If
                    End If

                    objCoin.Coin10 = num1
                    objCoin.Coin5 = num2
                    objCoin.Coin2 = num3
                    objCoin.Coin1New = num4
                    objCoin.Coin1old = num5
                    objCoin.Coin05 = num6

                End While

            End If
            ExceptionLogger.LogInfo("AcceptingCoin->TotalInputAmount=" & TotalInputAmount.ToString())
            Return TotalInputAmount
        End SyncLock
    End Function

    Public Function StopAcceptingMoney() As Decimal

        StopAcceptingCoinCash = True 'confirm
        Try
            ev.Set()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Try
            ev.Reset()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Try
            ev.Close()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        If Not IsNothing(DepositInCoinThread) Then
            DepositInCoinThread.Join()
        End If

        If Not IsNothing(DepositInCashThread) Then
            DepositInCashThread.Join()
        End If

        IsAcceptingMode = False


        ExceptionLogger.LogInfo("StopAcceptingMoney->TotalInputAmount = " & TotalInputAmount.ToString())
        Return TotalInputAmount

    End Function

    Dim LockReturnCashAndCoins = New Object()
    Public Function ReturnCashAndCoins(ByVal isDispensingFromCash As Boolean, ByVal isDispensingFromCoin As Boolean, ByVal totalAmount As Decimal) As Decimal
        SyncLock LockReturnCashAndCoins

            ExceptionLogger.LogInfo("ReturnCashAndCoins isDispensingFromCash=" & isDispensingFromCash & "  isDispensingFromCoin=" & isDispensingFromCoin & " totalAmount=" & totalAmount)
            Dim ReturnedAmount As Decimal = 0

            IsAcceptingMode = False

            If isDispensingFromCash And totalAmount >= 20 Then

                Dim TimeoutCounter As Integer = 0
                Dim TimeoutMax As Integer = 20

                Dim TempAmount As Decimal = totalAmount

                Dim AmountToReturnAsBulk As Integer = CalculateCashMoneyToReturn(TempAmount)
                TimeoutCounter = 0
                While bnr.TransactionStatus.CurrentTransaction <> TransactionType.None And TimeoutCounter < TimeoutMax
                    Threading.Thread.Sleep(500)
                    TimeoutCounter += 1
                End While

                Dim StatusCodeBulk As Integer = 0
                Try
                    Threading.Thread.Sleep(1500)
                    Try
                        bnr.Dispense(AmountToReturnAsBulk * 100, "ILS")
                    Catch ex As Exception
                        Threading.Thread.Sleep(4000)
                        ExceptionLogger.LogException(ex)
                        ExceptionLogger.LogInfo("Could not Dispense from cash AmountToReturnAsBulk = " & AmountToReturnAsBulk)
                    End Try

                    TimeoutCounter = 0
                    While bnr.TransactionStatus.CurrentTransaction <> TransactionType.Dispense And TimeoutCounter < TimeoutMax
                        Threading.Thread.Sleep(500)
                        TimeoutCounter += 1
                    End While
                    StatusCodeBulk = bnr.Present()
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                    bnr.CancelWaitingCashTaken()
                    StatusCodeBulk = 0
                End Try

                If StatusCodeBulk > 0 Then
                    ReturnedAmount += AmountToReturnAsBulk
                Else

                    While TempAmount >= 200

                        TimeoutCounter = 0
                        While bnr.TransactionStatus.CurrentTransaction <> TransactionType.None And TimeoutCounter < TimeoutMax
                            Threading.Thread.Sleep(500)
                            TimeoutCounter += 1
                        End While

                        Dim StatusCode As Integer = 0
                        Try
                            bnr.Dispense(20000, "ILS")
                            TimeoutCounter = 0
                            While bnr.TransactionStatus.CurrentTransaction <> TransactionType.Dispense And TimeoutCounter < TimeoutMax
                                Threading.Thread.Sleep(500)
                                TimeoutCounter += 1
                            End While
                            StatusCode = bnr.Present()
                        Catch ex As Exception
                            bnr.CancelWaitingCashTaken()
                            StatusCode = 0
                        End Try

                        If StatusCode > 0 Then
                            TempAmount = TempAmount - 200
                            ReturnedAmount += 200
                        Else
                            Exit While
                        End If

                    End While

                    While TempAmount >= 100

                        TimeoutCounter = 0
                        While bnr.TransactionStatus.CurrentTransaction <> TransactionType.None And TimeoutCounter < TimeoutMax
                            Threading.Thread.Sleep(500)
                            TimeoutCounter += 1
                        End While

                        Dim StatusCode As Integer = 0
                        Try
                            bnr.Dispense(10000, "ILS")
                            TimeoutCounter = 0
                            While bnr.TransactionStatus.CurrentTransaction <> TransactionType.Dispense And TimeoutCounter < TimeoutMax
                                Threading.Thread.Sleep(500)
                                TimeoutCounter += 1
                            End While
                            StatusCode = bnr.Present()
                        Catch ex As Exception
                            bnr.CancelWaitingCashTaken()
                            StatusCode = 0
                        End Try

                        If StatusCode > 0 Then
                            TempAmount = TempAmount - 100
                            ReturnedAmount += 100
                        Else
                            Exit While
                        End If

                    End While

                    While TempAmount >= 50

                        TimeoutCounter = 0
                        While bnr.TransactionStatus.CurrentTransaction <> TransactionType.None And TimeoutCounter < TimeoutMax
                            Threading.Thread.Sleep(500)
                            TimeoutCounter += 1
                        End While

                        Dim StatusCode As Integer = 0
                        Try
                            bnr.Dispense(5000, "ILS")
                            TimeoutCounter = 0
                            While bnr.TransactionStatus.CurrentTransaction <> TransactionType.Dispense And TimeoutCounter < TimeoutMax
                                Threading.Thread.Sleep(500)
                                TimeoutCounter += 1
                            End While
                            StatusCode = bnr.Present()
                        Catch ex As Exception
                            bnr.CancelWaitingCashTaken()
                            StatusCode = 0
                        End Try

                        If StatusCode > 0 Then
                            TempAmount = TempAmount - 50
                            ReturnedAmount += 50
                        Else
                            Exit While
                        End If

                    End While

                    While TempAmount >= 20

                        TimeoutCounter = 0
                        While bnr.TransactionStatus.CurrentTransaction <> TransactionType.None And TimeoutCounter < TimeoutMax
                            Threading.Thread.Sleep(500)
                            TimeoutCounter += 1
                        End While

                        Dim StatusCode As Integer = 0
                        Try
                            bnr.Dispense(2000, "ILS")
                            TimeoutCounter = 0
                            While bnr.TransactionStatus.CurrentTransaction <> TransactionType.Dispense And TimeoutCounter < TimeoutMax
                                Threading.Thread.Sleep(500)
                                TimeoutCounter += 1
                            End While
                            StatusCode = bnr.Present()
                        Catch ex As Exception
                            bnr.CancelWaitingCashTaken()
                            StatusCode = 0
                        End Try

                        If StatusCode > 0 Then
                            TempAmount = TempAmount - 20
                            ReturnedAmount += 20
                        Else
                            Exit While
                        End If

                    End While

                End If
            End If

            If isDispensingFromCoin Then
                If cyCR6 Is Nothing Then
                    AttempOpenCoinMachine()
                End If
                totalAmount = totalAmount - ReturnedAmount
                Dim NumberOfCoins As Integer = System.Math.Floor(totalAmount / 10)
                If NumberOfCoins > 0 Then

                    Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
                    cyCR6.BCRPayOutMoneyFor6(NumberOfCoins, 0, 0, 0, 0, 0, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)
                    If dispNum1 > 0 Then
                        totalAmount = totalAmount - (dispNum1 * 10)
                        ReturnedAmount += (dispNum1 * 10)
                    End If
                End If

                NumberOfCoins = System.Math.Floor(totalAmount / 5)
                If NumberOfCoins > 0 Then

                    Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
                    cyCR6.BCRPayOutMoneyFor6(0, NumberOfCoins, 0, 0, 0, 0, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)
                    If dispNum2 > 0 Then
                        totalAmount = totalAmount - (dispNum2 * 5)
                        ReturnedAmount += (dispNum2 * 5)
                    End If

                End If

                NumberOfCoins = System.Math.Floor(totalAmount / 2)

                If NumberOfCoins > 0 Then

                    Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
                    cyCR6.BCRPayOutMoneyFor6(0, 0, NumberOfCoins, 0, 0, 0, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)

                    If dispNum3 > 0 Then
                        totalAmount = totalAmount - (dispNum3 * 2)
                        ReturnedAmount += (dispNum3 * 2)
                    End If

                End If

                NumberOfCoins = System.Math.Floor(totalAmount)

                If NumberOfCoins > 0 Then

                    Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
                    cyCR6.BCRPayOutMoneyFor6(0, 0, 0, NumberOfCoins, 0, 0, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)

                    If dispNum4 > 0 Then
                        totalAmount = totalAmount - dispNum4
                        ReturnedAmount += dispNum4
                    End If

                End If

                NumberOfCoins = System.Math.Floor(totalAmount / 0.5)

                If NumberOfCoins > 0 Then

                    Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
                    cyCR6.BCRPayOutMoneyFor6(0, 0, 0, 0, NumberOfCoins, 0, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)

                    If dispNum6 > 0 Then
                        totalAmount = totalAmount - (dispNum6 * 0.5)
                        ReturnedAmount += (dispNum6 * 0.5)
                    End If

                End If


            End If
            ExceptionLogger.LogInfo("ReturnCashAndCoins_>ReturnedAmount" & ReturnedAmount)
            Return ReturnedAmount
        End SyncLock
    End Function


    Public Function EmptyCash() As Integer

        Try

            ExceptionLogger.LogInfo("EmptyCash")
            Dim ReturnedAmount = False
            Dim TimeoutCounter As Integer = 0
            Dim TimeoutMax As Integer = 20
            Dim TotalTransfering = 0
            Dim StatusCodeBulk As Integer = 0
            Try
                Threading.Thread.Sleep(500)
                While IsAcceptingMode
                    ExceptionLogger.LogInfo("IsAcceptingMode = True, wait 60 second")
                    Threading.Thread.Sleep(60000)
                End While
                ExceptionLogger.LogInfo("Beginning to empty RE3")
                TotalTransfering = bnr.Empty("RE3", False) 'LO1, RE6, RE5, RE4, RE3
                ExceptionLogger.LogInfo("EmptyCash RE3 is Comploted with value " & TotalTransfering)
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
                Throw ex
            End Try

            Try
                Threading.Thread.Sleep(500)
                ExceptionLogger.LogInfo("Beginning to EmptyCash RE4 ")
                Threading.Thread.Sleep(80000)
                ExceptionLogger.LogInfo(" EmptyCash RE4 ")
                TotalTransfering = bnr.Empty("RE4", False) 'LO1, RE6, RE5, RE4, RE3
                ExceptionLogger.LogInfo("EmptyCash RE4 is Comploted with value " & TotalTransfering)

            Catch ex As Exception
                ExceptionLogger.LogException(ex)
                Throw ex
            End Try
            Try
                Threading.Thread.Sleep(500)
                ExceptionLogger.LogInfo("Beginning to EmptyCash RE5 ")
                Threading.Thread.Sleep(80000)
                ExceptionLogger.LogInfo(" EmptyCash RE5 ")
                TotalTransfering = bnr.Empty("RE5", False) 'LO1, RE6, RE5, RE4, RE3
                ExceptionLogger.LogInfo("EmptyCash RE5 is Comploted with value " & TotalTransfering)
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
                Throw ex
            End Try
            Try
                Threading.Thread.Sleep(500)
                ExceptionLogger.LogInfo("Beginning to EmptyCash RE6 ")
                Threading.Thread.Sleep(80000)
                ExceptionLogger.LogInfo("EmptyCash RE6 ")
                TotalTransfering = bnr.Empty("RE6", False) 'LO1, RE6, RE5, RE4, RE3
                ExceptionLogger.LogInfo("EmptyCash RE6 is Comploted with value " & TotalTransfering)
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
                Throw ex
            End Try
            Try
                Threading.Thread.Sleep(500)
                ExceptionLogger.LogInfo("Begining to EmptyCash LO1 ")
                Threading.Thread.Sleep(80000)
                ExceptionLogger.LogInfo("EmptyCash LO1 ")
                TotalTransfering = bnr.Empty("LO1", False) 'LO1, RE6, RE5, RE4, RE3
                ExceptionLogger.LogInfo("EmptyCash LO1 is Comploted with value " & TotalTransfering)
            Catch ex As Exception
                ExceptionLogger.LogException(ex)
            End Try
            ExceptionLogger.LogInfo("EmptyCash All Boxes Completed ")

        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Return 0
    End Function

    Private Sub RestartBNRandRefresh()
        Try

            bnr.Reboot()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
        Try

            bnr.KillUsbAndReload()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub
    Public Sub CloseCoinCashRecyclers()

        Try
            bnr.Close()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Try
            cyCR6.closePort()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub


    Public Sub AcceptAmount()
        Dim EventTimedOut As Boolean = False
        ev = New AutoResetEvent(False)
        ev.Reset()
        OCresult = BnrXfsErrorCode.NotUsed
        Try
            bnr.CashInStart()
        Catch ex As Exception
            ExceptionLogger.LogInfo("AcceptAmount -> Failed to CashInStart first try")
            ExceptionLogger.LogException(ex)
            Thread.Sleep(8000)
            Try
                bnr.CashInStart()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("AcceptAmount -> Failed to CashInStart second try")
                ExceptionLogger.LogException(ex)
                ExceptionLogger.LogInfo("AcceptAmount -> after Failed to CashInStart second  stop connection")
                Thread.Sleep(8000)
                Try
                    bnr.CashInStart()
                    ExceptionLogger.LogInfo("AcceptAmount -> after succeded to Cash In third time")
                Catch ex3 As Exception
                    ExceptionLogger.LogInfo("AcceptAmount -> Failed to CashInStart third try, Please check bnr machine")
                    ExceptionLogger.LogException(ex3)
                End Try

            End Try

        End Try
        Try
            Try
                ev.WaitOne(BnrDefaultOperationTimeOutInMS)
            Catch ex As Exception
                ExceptionLogger.LogInfo("AcceptAmount -> failed to ev.WaitOne(BnrDefaultOperationTimeOutInMS)")

                If Not IsNothing(ev) Then
                    ExceptionLogger.LogInfo("AcceptAmount -> failed to ev.WaitOne(BnrDefaultOperationTimeOutInMS) and ev is Nothing ")
                End If

            End Try



            If OCresult = BnrXfsErrorCode.Success Then

                While Not StopAcceptingCoinCash

                    OCresult = BnrXfsErrorCode.NotUsed
                    Try
                        bnr.CashIn()
                    Catch ex As Exception
                        ExceptionLogger.LogInfo("AcceptAmount -> Failed to CashIn in while eit while")
                        ExceptionLogger.LogException(ex)
                        Exit While
                    End Try

                    If StopAcceptingCoinCash Or Not ev.WaitOne(BnrDefaultCashInOperationTimeOutInMS) Or OCresult <> BnrXfsErrorCode.Success Then

                        EventTimedOut = True
                        Dim isCanceledOrCashInEndSuccesfully = False
                        Try
                            Thread.Sleep(500)
                            bnr.Cancel()
                            ev.WaitOne(BnrDefaultOperationTimeOutInMS)
                            Thread.Sleep(500)
                            isCanceledOrCashInEndSuccesfully = True
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)

                        End Try
                        Try
                            Thread.Sleep(500)
                            bnr.CashInEnd()
                            isCanceledOrCashInEndSuccesfully = True
                        Catch ex2 As Exception
                            ExceptionLogger.LogException(ex2)
                        End Try
                        If isCanceledOrCashInEndSuccesfully Then
                            ExceptionLogger.LogInfo("isCanceledOrCashInEndSuccesfully = True")
                        Else
                            ExceptionLogger.LogInfo("isCanceledOrCashInEndSuccesfully = False")
                        End If
                        Thread.Sleep(2000)
                    Else

                        Dim addedCash = 0
                        Try


                            addedCash = cashOrder.Denomination.Amount / 100
                            If addedCash > 0 Then
                                TotalInputAmount += addedCash
                                If Not StopAcceptingCoinCash And OCresult = BnrXfsErrorCode.Success Then

                                    RaiseEvent OnCoinCashDeposit(addedCash)
                                    ExceptionLogger.LogInfo(" RaiseEvent OnCoinCashDeposit(" & addedCash & "),  cashOrder.Denomination.Amount= " & cashOrder.Denomination.Amount & " ,cashOrder.Denomination.Items.Length" & cashOrder.Denomination.Items.Length)
                                Else
                                    ExceptionLogger.LogInfo("should not RaiseEvent OnCoinCashDeposit(" & addedCash & "),  cashOrder.Denomination.Amount= " & cashOrder.Denomination.Amount & " ,cashOrder.Denomination.Items.Length" & cashOrder.Denomination.Items.Length)
                                    ExceptionLogger.LogInfo("ELSE not the while condetion")
                                End If
                            End If

                            Thread.Sleep(500)
                        Catch ex As Exception
                            ExceptionLogger.LogException(ex)
                        End Try
                    End If

                End While
                RemoveHandler Bnr.OperationCompletedEvent, AddressOf Bnr_OperationCompletedEvent

            End If
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

    Public Sub Bnr_OperationCompletedEvent(ByVal identificationId As Integer, ByVal operationId As OperationId, ByVal result As BnrXfsErrorCode, ByVal extendedResult As BnrXfsErrorCode, ByVal Data As Object)
        OCresult = result

        Select Case operationId
            Case OperationId.Reset
                ExceptionLogger.LogInfo("operationCompleteOccured on a reset ")
            Case OperationId.CashIn

                If result = BnrXfsErrorCode.Success And StopAcceptingCoinCash <> True Then
                    cashOrder = CType(Data, XfsCashOrder)
                    ExceptionLogger.LogInfo("result = BnrXfsErrorCode.Success=" & result = BnrXfsErrorCode.Success & " ,StopAcceptingCoinCash = " & StopAcceptingCoinCash)
                    ExceptionLogger.LogInfo("cashOrder = CType(Data, XfsCashOrder) cashOrder.Denomination.Amount= " & cashOrder.Denomination.Amount & " ,cashOrder.Denomination.Items.Length" & cashOrder.Denomination.Items.Length)
                    ExceptionLogger.LogInfo("identificationId = " & identificationId & " ," & " operationId = " & operationId.ToString() & " , result =" & result.ToString() & " , extendedResult = " & extendedResult.ToString())
                Else
                    ExceptionLogger.LogInfo("Shouldn't rise this event operationCompleteOccured on a cashIn.")
                End If

                ExceptionLogger.LogInfo("operationCompleteOccured on a cashIn ")
            Case OperationId.CashInStart
                ExceptionLogger.LogInfo("operationCompleteOccured on a cashInStart")
            Case OperationId.CashInEnd

                If result = BnrXfsErrorCode.Success Then
                    'cashOrder = CType(Data, XfsCashOrder)
                    ExceptionLogger.LogInfo("operationCompleteOccured on a cashInEnd,  ")
                Else
                    ExceptionLogger.LogInfo("Error during cashInEnd.")
                End If

            Case OperationId.Dispense

                If result = BnrXfsErrorCode.Success Then
                    'cashOrder = CType(Data, XfsCashOrder)
                    ExceptionLogger.LogInfo("operationCompleteOccured on a dispense  ")
                End If

            Case OperationId.Present
                If result = BnrXfsErrorCode.Success Then
                    'cashOrder = CType(Data, XfsCashOrder)
                    ExceptionLogger.LogInfo("operationCompleteOccured on a present  ")
                End If

            Case Else
                ExceptionLogger.LogInfo("Unexpected OperationCompleteOccured ")
        End Select
        Try
            ev.[Set]()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub


    Public Sub MakeBnrOperational()
        Dim bnrStatus As Mei.Bnr.Status = bnr.Status

        If bnrStatus.DeviceStatus <> DeviceStatus.OnLine Then
            ev.Reset()
            bnr.Reset()
            ev.WaitOne(BnrResetTimeOutInMS)
        End If
    End Sub

#Region " Cash Recycler Methods"

    Dim OnCashInEventLock = New Object()
    Private Sub OnCashInEvent(ByVal cashInOrder As XfsCashOrder)


        SyncLock OnCashInEventLock


            Dim cashIn = 0
            If IsAcceptingMode = True Then
                ExceptionLogger.LogInfo("On Cash In Event = True")
                If cashInOrder.Denomination.Amount > 0 Then
                    cashIn = cashInOrder.Denomination.Amount / 100
                    ExceptionLogger.LogInfo("On Cash In cashIn = " & cashIn)
                    TotalInputAmount += cashIn
                    If StopAcceptingCoinCash = False Then
                        RaiseEvent OnCoinCashDeposit(cashIn)
                        ExceptionLogger.LogInfo("On Cash In RaiseEvent OnCoinCashDeposit : " & cashIn)

                    End If
                End If

                Try
                    bnr.CashIn()
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try

            Else
                ExceptionLogger.LogInfo("On Cash In Event : IsAccepting = False and TotalInputAmount is  " & TotalInputAmount)
            End If
        End SyncLock
    End Sub

    Function CalculateCashMoneyToReturn(ByVal value As Decimal) As Integer
        Dim result As Integer = 0

        While value >= 20
            If value >= 200 Then
                result += 200
                value -= 200
            ElseIf value >= 100 Then
                result += 100
                value -= 100
            ElseIf value >= 50 Then
                result += 50
                value -= 50
            ElseIf value >= 20 Then
                result += 20
                value -= 20
            End If
        End While

        Return result
    End Function

    Public Sub StopBNRConnection()
        Try
            bnr.Close()
            ExceptionLogger.LogInfo("Disposed bnr successfuly")
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            bnr.Close()
            ExceptionLogger.LogInfo("Disposed bnr successfuly")
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Try
            cyCR6.closePort()
            ExceptionLogger.LogInfo("Disposed ctCR6 successfuly")
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

#End Region

End Class
