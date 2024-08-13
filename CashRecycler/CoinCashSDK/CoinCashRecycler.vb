
Imports System.Threading

Imports Microsoft.VisualBasic.Devices

Public Class ILSMoney
    Public PaperMoney As PaperMoney
    Public Coins As Coin
    Public Sub New()
        Me.Coins = New Coin()
        Me.PaperMoney = New PaperMoney()
    End Sub

    Public Function TotalMoney() As Decimal
        Dim totalReturn As Decimal = 0
        If Not Me.Coins Is Nothing Then
            totalReturn += Coins.Total()
        End If
        If Not Me.PaperMoney Is Nothing Then
            totalReturn += PaperMoney.Total()
        End If
        Return totalReturn
    End Function

End Class

Public Class CoinCashRecycler
    ''' <summary>
    ''' Init Both Coin and Cash Recycling Machines 
    ''' </summary>
    ''' <param name="isOpenCashMachine"></param>
    ''' <param name="cashComNum"></param>
    ''' <param name="isOpenCoinMachine"></param>
    ''' <param name="coinComNum"></param>
    ''' <returns></returns>
    Public Function InitCoinCashRecycler(isOpenCashMachine As Boolean, cashComNum As Integer, isOpenCoinMachine As Boolean, coinComNum As Integer) As Boolean
        Dim returnValue As Boolean = False

        Dim isCashMachineAvailable = False
        If isOpenCashMachine Then
            isCashMachineAvailable = Not AttempOpenCashMachine(cashComNum)
        Else
            isCashMachineAvailable = True ' no need to open
        End If

        Dim isCoinMachineAvailable = False
        If isOpenCoinMachine Then
            isCoinMachineAvailable = AttempOpenCoinMachine(coinComNum)
        Else
            isCoinMachineAvailable = True ' no need to open
        End If

        If isCashMachineAvailable And isCoinMachineAvailable Then
            returnValue = True
        End If

        Return returnValue
    End Function


    Public Function StartAcceptingMoney(isAcceptingFromCash As Boolean, isAcceptingFromCoin As Boolean) As ILSMoney
        Dim returnedMoney As New ILSMoney
        returnedMoney.Coins.Coin10 = 0
        returnedMoney.Coins.Coin05 = 0
        returnedMoney.Coins.Coin2 = 0
        returnedMoney.Coins.Coin1New = 0
        returnedMoney.Coins.Coin1old = 0
        returnedMoney.Coins.Coin05 = 0
        returnedMoney.PaperMoney.Cash200 = 0
        returnedMoney.PaperMoney.Cash100 = 0
        returnedMoney.PaperMoney.Cash50 = 0
        returnedMoney.PaperMoney.Cash20 = 0


        'Dim denomination As List(Of Integer) = New List(Of Integer)() From {
        '    0,' "ILS 10",
        '0,' "ILS 5",
        '0,' "ILS 2",
        '0,' "ILS 1 New",
        '0,' "ILS 1 Old",
        '0 ' "ILS 0.5"
        '}
        Dim thread As New Thread(New ThreadStart(Sub()
                                                     'result = bNRClientApplicationObj.AcceptAmount()
                                                     If isAcceptingFromCash Then
                                                         returnedMoney.PaperMoney = startDepositInCash()
                                                     End If

                                                     If isAcceptingFromCoin Then
                                                         returnedMoney.Coins = startDepositInCoin()
                                                     End If
                                                 End Sub))

        ' Start the thread
        thread.Start()

        ' Wait for the thread to complete
        thread.Join()



        Return returnedMoney
    End Function



    Public Shared Function TotalDemonition(demonition As ILSMoney) As Decimal

        Return (demonition.Coins.Coin10 * 10 + demonition.Coins.Coin5 * 5 + demonition.Coins.Coin2 * 2 + demonition.Coins.Coin1New + demonition.Coins.Coin1old + demonition.Coins.Coin05 * 0.5) + (demonition.PaperMoney.Cash200 * 200 + demonition.PaperMoney.Cash100 * 100 + demonition.PaperMoney.Cash50 * 50 + demonition.PaperMoney.Cash20 * 2)

    End Function

    ''' <summary>
    ''' Return Cash And Coins
    ''' </summary>
    ''' <param name="isDispensingFromCash"></param>
    ''' <param name="isDispensingFromCoin"></param>
    ''' <param name="totalDispens"></param>
    ''' <returns></returns>
    Public Function ReturnCashAndCoins(isDispensingFromCash As Boolean, isDispensingFromCoin As Boolean, totalDispens As Decimal) As ILSMoney

        Dim cashCoinCounter As ILSMoney = CalculateILSMoney(totalDispens, isDispensingFromCash, isDispensingFromCoin)
        Dim returnedMoney As New ILSMoney()

        If isDispensingFromCash Then
            ' not yet
            returnedMoney.PaperMoney = bNRClientApplicationObj.DispenseAmount(cashCoinCounter.PaperMoney)
        End If

        If isDispensingFromCoin Then
            Dim dispNum1 = 0, dispNum2 = 0, dispNum3 = 0, dispNum4 = 0, dispNum5 = 0, dispNum6 = 0
            returnedMoney.Coins = cyCR6.BCRPayOutMoneyFor6(cashCoinCounter.Coins.Coin10, cashCoinCounter.Coins.Coin5, cashCoinCounter.Coins.Coin2, cashCoinCounter.Coins.Coin1New, cashCoinCounter.Coins.Coin1old, cashCoinCounter.Coins.Coin05, dispNum1, dispNum2, dispNum3, dispNum4, dispNum5, dispNum6)

        End If

        Console.WriteLine(If(returnedMoney.TotalMoney() > 0, "Success", "Failed"))



        'End If



    End Function
#Region "Private Functions and Properities"

    Private cr6IsPoll As Boolean = False
    Private cyCR6 As CsCYCR6 = New CsCYCR6()
    Private bNRClientApplicationObj As BNRClientApplication = New BNRClientApplication()

    Friend Delegate Sub CoinDisplay(coin As Coin)
    Private coinDisplayField As CoinDisplay

    ''' <summary>
    ''' Attemp Open Coin Machine
    ''' </summary>
    ''' <param name="coinComNum"></param>
    ''' <returns></returns>
    Private Function AttempOpenCoinMachine(coinComNum As Integer) As Boolean
        Dim isOpened As Boolean = False

        cyCR6.setSerialPort(New System.IO.Ports.SerialPort())
        cyCR6.openPort(coinComNum, 115200)

        Dim poll As Integer = cyCR6.pollCmd()
        If poll > 0 Then
            cr6IsPoll = True
            isOpened = True
        Else
            isOpened = False
        End If
        Return isOpened
    End Function

    ''' <summary>
    ''' Attemp Open Cash Machine
    ''' </summary>
    ''' <param name="cashComNum"></param>
    ''' <returns></returns>
    Private Function AttempOpenCashMachine(cashComNum As Integer) As Boolean
        Return False
    End Function

    Private Function startDepositInCash() As PaperMoney
        Dim result As PaperMoney = New PaperMoney()
        Dim thread As New Thread(New ThreadStart(Sub()
                                                     result = bNRClientApplicationObj.AcceptAmount()

                                                 End Sub))

        ' Start the thread
        thread.Start()

        ' Wait for the thread to complete
        thread.Join()
        Return result
    End Function
    Private Function startDepositInCoin() As Coin
        Dim result As Coin = New Coin()
        Dim thread As New Thread(New ThreadStart(Sub()
                                                     Dim poll As Integer = cyCR6.pollCmd()

                                                     If poll < 1 Then Return

                                                     Dim depositError = False
                                                     Thread.Sleep(50)
                                                     Dim modifyStatus As Integer = cyCR6.startAcceptCoin(&H3F, 0)
                                                     Thread.Sleep(50)
                                                     If modifyStatus > 0 Then
                                                         Dim num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0, num6 = 0
                                                         Dim bytes = New Byte(7) {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}
                                                         Dim byte1 As Byte = 0, byte2 As Byte = 0

                                                         Dim timerOut = 0
                                                         Dim coin As Coin = New Coin()
                                                         While True

                                                             Dim requestRegister As Integer = cyCR6.requestRegisterCmd(byte1, byte2)
                                                             If requestRegister <> 1 Then
                                                                 Thread.Sleep(50)
                                                                 requestRegister = cyCR6.requestRegisterCmd(byte1, byte2)
                                                             End If

                                                             If requestRegister = 1 Then
                                                                 If (byte1 And bytes(4)) > 0 OrElse (byte1 And bytes(5)) > 0 Then
                                                                     Console.WriteLine(String.Format("An error has been detected and needs to be checked。b1：{0}  b2:{1}", byte1, byte2))
                                                                     depositError = True
                                                                     Exit While
                                                                 End If
                                                             Else
                                                                 Console.WriteLine("Communication error")
                                                                 Exit While
                                                             End If


                                                             Thread.Sleep(50)
                                                             Dim requestCoinInByType As Integer = cyCR6.requestCoinInByType()
                                                             If requestCoinInByType <> 1 Then
                                                                 Thread.Sleep(50)
                                                                 requestCoinInByType = cyCR6.requestCoinInByType()
                                                             End If
                                                             If requestCoinInByType <> 1 Then
                                                                 Console.WriteLine("Communication error")
                                                                 Exit While
                                                             End If
                                                             cyCR6.getCoinNumberTo6(num1, num2, num3, num4, num5, num6)

                                                             coin.Coin10 = num1
                                                             coin.Coin5 = num2
                                                             coin.Coin2 = num3
                                                             coin.Coin1New = num4
                                                             coin.Coin1old = num5
                                                             coin.Coin05 = num6

                                                             'If Not Me.IsHandleCreated OrElse Me.IsDisposed Then Exit While
                                                             'Me.Invoke(coinDisplayField, coin)
                                                             'depositCoinDisplay(coin)
                                                             result.Coin10 = coin.Coin10
                                                             result.Coin5 = coin.Coin5
                                                             result.Coin2 = coin.Coin2
                                                             result.Coin1old = coin.Coin1old
                                                             result.Coin1New = coin.Coin1New
                                                             result.Coin05 = coin.Coin05
                                                             Thread.Sleep(400)

                                                             If coin.Total() = result.Total() Then
                                                                 timerOut += 1
                                                                 If timerOut >= 10 * 2 Then
                                                                     cyCR6.startAcceptCoin(0, 0)
                                                                     Exit While
                                                                 End If
                                                             End If



                                                         End While
                                                         While True
                                                             Thread.Sleep(50)
                                                             Dim requestRegister As Integer = cyCR6.requestRegisterCmd(byte1, byte2)
                                                             If requestRegister = 1 Then
                                                                 If (byte1 And bytes(1)) = 0 Then
                                                                     Exit While
                                                                 End If

                                                             End If
                                                         End While
                                                         'After stopping, get a receive result
                                                         If cyCR6.requestCoinInByType() <> 1 Then
                                                             Thread.Sleep(50)
                                                             cyCR6.requestCoinInByType()
                                                         End If
                                                         cyCR6.getCoinNumberTo6(num1, num2, num3, num4, num5, num6)
                                                         coin.Coin10 = num1
                                                         coin.Coin5 = num2
                                                         coin.Coin2 = num3
                                                         coin.Coin1New = num4
                                                         coin.Coin1old = num5
                                                         coin.Coin05 = num6

                                                         result.Coin10 = coin.Coin10
                                                         result.Coin5 = coin.Coin5
                                                         result.Coin2 = coin.Coin2
                                                         result.Coin1old = coin.Coin1old
                                                         result.Coin1New = coin.Coin1New
                                                         result.Coin05 = coin.Coin05

                                                         'If Me.IsHandleCreated AndAlso Not Me.IsDisposed Then Me.Invoke(coinDisplayField, coin)

                                                         If depositError Then
                                                             'If Me.IsHandleCreated AndAlso Not Me.IsDisposed Then Me.Invoke(New Action(Sub()
                                                             '                                                                              Dim errForm As CoinsErrorForm = New CoinsErrorForm(cyCR6)
                                                             '                                                                              errForm.ShowDialog()
                                                             '                                                                              Return
                                                             '                                                                          End Sub))
                                                         End If
                                                     End If

                                                 End Sub))

        ' Start the thread
        thread.Start()

        ' Wait for the thread to complete
        thread.Join()
        Return result


    End Function


    ''' <summary>
    ''' This Function will retun the count number of each type of Paper Money and Coins as ILSMoney Type 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="isCashAvailable"></param>
    ''' <param name="isCoinAvailable"></param>
    ''' <returns></returns>
    Function CalculateILSMoney(value As Decimal, isCashAvailable As Boolean, isCoinAvailable As Boolean) As ILSMoney
        Dim result As New ILSMoney()

        If isCashAvailable Then
            Dim paperMoney As New PaperMoney()
            While value >= 20
                If value >= 200 Then
                    paperMoney.Cash200 += 1
                    value -= 200
                ElseIf value >= 100 Then
                    paperMoney.Cash100 += 1
                    value -= 100
                ElseIf value >= 50 Then
                    paperMoney.Cash50 += 1
                    value -= 50
                ElseIf value >= 20 Then
                    paperMoney.Cash20 += 1
                    value -= 20
                End If
            End While
            result.PaperMoney = paperMoney
        Else
            result.PaperMoney = New PaperMoney()
        End If

        If isCoinAvailable Then
            Dim coins As New Coin()
            While value > 0
                If value >= 10 Then
                    coins.Coin10 += 1
                    value -= 10
                ElseIf value >= 5 Then
                    coins.Coin5 += 1
                    value -= 5
                ElseIf value >= 2 Then
                    coins.Coin2 += 1
                    value -= 2
                ElseIf value >= 1 Then
                    coins.Coin1New += 1
                    value -= 1
                ElseIf value >= 0.5 Then
                    coins.Coin05 += 1
                    value -= 0.5
                End If
            End While
            result.Coins = coins
        Else
            result.Coins = New Coin()
        End If

        Return result
    End Function
#End Region




End Class
