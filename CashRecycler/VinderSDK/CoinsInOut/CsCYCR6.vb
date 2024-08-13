Public Class CsCYCR6
    Inherits CsBaseCom
    Public inChannel As Integer() = New Integer(15) {} 'Denomination of channel
    Public inArray As Integer() = New Integer(15) {} 'The number of channel receipts


    Private Sub clearInChannel()
        For i = 0 To 15
            inChannel(i) = 0
        Next
    End Sub

    Private Sub clearInCoin()
        For i = 0 To 15
            inArray(i) = 0
        Next
    End Sub
    ''' <summary>
    ''' Check that the array satisfies the checksum
    ''' </summary>
    ''' <paramname="array"></param>
    ''' <paramname="len"></param>
    ''' <returns></returns>
    Public Function arrayCheck2(array As Byte(), len As Integer) As Boolean
        If len < 1 Then Return False
        Dim ret As UInteger = 0
        For i = 0 To len - 1
            ret = ret + array(i)
        Next
        Dim sum As UInteger
        sum = ret Mod 256
        If sum = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Create an array of check codes
    ''' </summary>
    ''' <paramname="array"></param>
    ''' <paramname="len"></param>
    Public Sub makeCheck2(array As Byte(), len As Integer)
        Dim ret As UInteger = 0
        For i = 0 To len - 1 - 1
            ret = ret + array(i)
        Next
        Dim sum As Byte
        sum = CByte(ret Mod 256)
        array(len - 1) = CByte(256 - sum)
    End Sub
    'Reset 
    Public Function resetCmd() As Integer

        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H1
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 10 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function
    'samplePoll
    Public Function pollCmd() As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &HFE
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 10 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function
    ''' <summary></summary>

    ''' </summary>

    ''' <paramname="byte1">        /// 第一个字节：                                      
    '''  B0: Singulator running
    '''  B1: Escalator running
    '''  B2: Processing money in 询问知有硬币通过硬币识别器
    '''  B3: Processing money out 询问知有硬币在找出去
    '''  B4:  Coin in jam or fault 询问知有错误被探测到
    '''  B5: Coin out jam or fault 阻塞架空探测到
    '''  B6: Changer initialising
    '''  B7: Entry flap open</param>
    ''' <paramname="byte2">        /// 第二个字节： 
    '''  B0:  Continuous rejects[unsupported]
    '''  B1: Hopper configuration change
    '''  B2: Reject divert active
    '''  B3: Exit cup full
    '''  B4: Non-fatal fault detected
    '''  B5: {Reserved}
    '''  B6: {Reserved - Changer in test mode}
    ''' B7: {Reserved - Debug console output ready} </param>
    ''' <returns>-10 Thread safe, no processing, 1 succeeded, 0 incorrect response, other failures</returns>
    Public Function requestRegisterCmd(ByRef byte1 As Byte, ByRef byte2 As Byte) As Integer
        Dim result = -10
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &H1
        sendbuf(3) = &H7B
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then
                    If Length = 7 Then
                        byte1 = dataArray(4)
                        byte2 = dataArray(5)
                        result = 1
                    ElseIf Length = 12 Then
                        byte1 = dataArray(9)
                        byte2 = dataArray(10)
                        result = 1
                    Else

                        result = 0
                    End If
                End If
            Else
                Return ret
            End If
        Else
            result = -2
        End If
        If result = -10 Then
            Console.WriteLine("=======================Object is in use, calling this method is invalid=========")
        End If
        Return result
    End Function

    ''' <summary>
    ''' modifyStatus
    ''' </summary>
    ''' <paramname="byte1"></param>
    ''' <paramname="byte2"></param>
    ''' <returns>Status: -1 Communication timeout -2 Serial port not enabled -3 Communication timeout 0 Data error 1 Succeeded</returns>
    Public Function modifyStatus(byte1 As Byte, byte2 As Byte) As Integer
        Dim sendlen = 7
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &HE7
        sendbuf(4) = byte1
        sendbuf(5) = byte2
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)

            Dim HexString As String = ByteUtils.ToHexString(inbuff, Length)
            Dim index = HexString.IndexOf("FF00")
            HexString = HexString.Substring(index)
            Dim dataArrayTmp As Byte() = ByteUtils.HexStringToByteArray(HexString)
            Length = 0
            addArray(dataArrayTmp, dataArrayTmp.Length)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 OrElse Length = 12 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function

    Public Function requestStatus(ByRef byte1 As Byte, ByRef byte2 As Byte) As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &HE6
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 7 Then
                        byte1 = dataArray(4)
                        byte2 = dataArray(5)
                        Return 1
                    ElseIf Length = 12 Then
                        byte1 = dataArray(9)
                        byte2 = dataArray(10)
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function



    Public Function payMoneyOut(money As UInteger) As Integer
        Dim sendlen = 9
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H7D
        sendbuf(4) = CByte(money Mod 256)
        sendbuf(5) = CByte(money / 256 Mod 256)
        sendbuf(6) = CByte(money / 65536 Mod 256)
        sendbuf(7) = CByte(money / 65536 / 256 Mod 256)
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 14 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function

    Public Function verifyMoneyOut(ByRef money1 As UInteger, ByRef money2 As UInteger) As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H7C
        money1 = 0
        money2 = 0
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 14 Then
                        money1 = dataArray(5)
                        money1 = money1 + CUInt(dataArray(6) * 256)
                        money1 = money1 + CUInt(dataArray(7) * 65536)
                        money1 = money1 + CUInt(dataArray(8) * 65536 * 256)

                        money2 = dataArray(9)
                        money2 = money2 + CUInt(dataArray(10) * 256)
                        money2 = money2 + CUInt(dataArray(11) * 65536)
                        money2 = money2 + CUInt(dataArray(12) * 65536 * 256)
                        Return 1
                    ElseIf Length = 19 Then
                        money1 = dataArray(10)
                        money1 = money1 + CUInt(dataArray(11) * 256)
                        money1 = money1 + CUInt(dataArray(12) * 65536)
                        money1 = money1 + CUInt(dataArray(13) * 65536 * 256)

                        money2 = dataArray(14)
                        money2 = money2 + CUInt(dataArray(15) * 256)
                        money2 = money2 + CUInt(dataArray(16) * 65536)
                        money2 = money2 + CUInt(dataArray(17) * 65536 * 256)
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function

    ''' <summary>
    ''' Automatically empty the cash box
    ''' </summary>
    ''' <paramname="box"></param>
    ''' <paramname="num"></param>
    ''' <returns></returns>
    Public Function purgeHopper(box As Byte, num As Byte) As Integer
        Dim sendlen = 7
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H79
        sendbuf(4) = box
        sendbuf(5) = num
        makeCheck2(sendbuf, sendlen) '生成校验码
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen) '发送数据
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 12 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function


    ''' <summary>
    ''' Change for 3 bill boxes
    ''' </summary>
    ''' <paramname="num1"></param>
    ''' <paramname="num2"></param>
    ''' <paramname="num3"></param>
    ''' <paramname="outmoney"></param>
    ''' <paramname="coin10"></param>
    ''' <paramname="coin5"></param>
    ''' <paramname="coin1"></param>
    ''' <returns></returns>
    Public Function BCRPayOutMoney(num1 As Byte, num2 As Byte, num3 As Byte, ByRef outmoney As Integer, ByRef coin10 As Integer, ByRef coin5 As Integer, ByRef coin1 As Integer) As Integer
        outmoney = 0
        coin10 = 0
        coin5 = 0
        coin1 = 0
        If num1 + num2 + num3 <= 0 Then Return 1
        Dim ret As Integer
        delay(300)
        'ret = pollCmd();
        'if (ret != 1) return ret;
        delay(1000)


        Dim coin10temp = 0
        Dim coin5temp = 0
        Dim coin1temp = 0
        delay(200)
        requestBalanceNew(1, coin10temp)
        delay(200)
        requestBalanceNew(2, coin5temp)
        delay(200)
        requestBalanceNew(3, coin1temp)
        Dim outindex = New Byte(2) {}
        Dim outbyte = New Byte(2) {}
        outindex(0) = 1
        outindex(1) = 2
        outindex(2) = 3
        Dim myoutmoney = num1 * 500 + num2 * 10 + num3 * 10
        If num1 > 0 Then
            outbyte(0) = num1
            myoutmoney = myoutmoney + num1 * 500
        End If
        If num2 > 0 Then
            outbyte(1) = num2
            myoutmoney = myoutmoney + num2 * 100
        End If
        If num3 > 0 Then
            outbyte(2) = num3
            myoutmoney = myoutmoney + num3 * 10
        End If
        ret = payOut3(outindex(0), outbyte(0), outindex(1), outbyte(1), outindex(2), outbyte(2))
        delay(2000)
        Dim byte1 As Byte = 0
        Dim byte2 As Byte = 0
        Dim errorcount = 0
        Dim count = 0
        Dim othercount = 0


        Dim bytes = New Byte(7) {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}
        While True
            delay(2000)
            othercount += 1
            If othercount > 200 Then Exit While
            byte1 = 0
            byte2 = 0
            ret = requestRegisterCmd(byte1, byte2)
            If ret = 1 Then
                If (byte1 And bytes(3)) = 0 Then
                    count += 1
                    If count >= 3 Then
                        Exit While
                    End If
                End If
            Else
                delay(300)
                errorcount += 1
                If errorcount > 5 Then
                    Exit While
                End If


            End If

        End While
        Dim coinouttmp10 = 0
        Dim coinouttmp5 = 0
        Dim coinouttmp1 = 0
        delay(300)
        requestBalanceNew(1, coinouttmp10)
        delay(300)
        requestBalanceNew(2, coinouttmp5)
        delay(300)
        requestBalanceNew(3, coinouttmp1)

        coin10 = coin10temp - coinouttmp10
        coin5 = coin5temp - coinouttmp5
        coin1 = coin1temp - coinouttmp1

        Return 1



    End Function

    ''' <summary>
    ''' Change for 6 bill boxes
    ''' </summary>
    ''' <paramname="num1"></param>
    ''' <paramname="num2"></param>
    ''' <paramname="num3"></param>
    ''' <paramname="num4"></param>
    ''' <paramname="num5"></param>
    ''' <paramname="num6"></param>
    ''' <paramname="coin1"></param>
    ''' <paramname="coin2"></param>
    ''' <paramname="coin3"></param>
    ''' <paramname="coin4"></param>
    ''' <paramname="coin5"></param>
    ''' <paramname="coin6"></param>
    ''' <returns></returns>
    Public Function BCRPayOutMoneyFor6(num1 As Byte, num2 As Byte, num3 As Byte, num4 As Byte, num5 As Byte, num6 As Byte, ByRef coin1 As Integer, ByRef coin2 As Integer, ByRef coin3 As Integer, ByRef coin4 As Integer, ByRef coin5 As Integer, ByRef coin6 As Integer) As Coin
        coin1 = 0
        coin2 = 0
        coin3 = 0
        coin4 = 0
        coin5 = 0
        coin6 = 0
        If num1 + num2 + num3 + num4 + num5 + num6 <= 0 Then Return New Coin()
        Dim ret As Integer
        ''' Get the amount once before dispensing coins.
        Dim coin1temp = 0
        Dim coin2temp = 0
        Dim coin3temp = 0
        Dim coin4temp = 0
        Dim coin5temp = 0
        Dim coin6temp = 0
        ' Adding By Khaleel , Making balance Max by force
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        modifyBalanceTosingle(1, 700)
        modifyBalanceTosingle(2, 600)
        modifyBalanceTosingle(3, 750)
        modifyBalanceTosingle(4, 900)
        modifyBalanceTosingle(5, 900)
        modifyBalanceTosingle(6, 650)
        '''''end of khaleel changes''''''''''''''''''''''''
        delay(100)
        requestBalanceNew(1, coin1temp)
        delay(100)
        requestBalanceNew(2, coin2temp)
        delay(100)
        requestBalanceNew(3, coin3temp)
        delay(100)
        requestBalanceNew(4, coin4temp)
        delay(100)
        requestBalanceNew(5, coin5temp)
        delay(100)
        requestBalanceNew(6, coin6temp)



        Dim outindex = New Byte(5) {}
        Dim outbyte = New Byte(5) {}
        outindex(0) = 1
        outindex(1) = 2
        outindex(2) = 3
        outindex(3) = 4
        outindex(4) = 5
        outindex(5) = 6

        If num1 > 0 Then
            outbyte(0) = num1

        End If
        If num2 > 0 Then
            outbyte(1) = num2

        End If
        If num3 > 0 Then
            outbyte(2) = num3

        End If
        If num4 > 0 Then
            outbyte(3) = num4

        End If
        If num5 > 0 Then
            outbyte(4) = num5
        End If
        If num6 > 0 Then
            outbyte(5) = num6
        End If
        ret = payOut6(outindex(0), outbyte(0), outindex(1), outbyte(1), outindex(2), outbyte(2), outindex(3), outbyte(3), outindex(4), outbyte(4), outindex(5), outbyte(5))
        delay(2000)
        Dim byte1 As Byte = 0
        Dim byte2 As Byte = 0
        Dim errorcount = 0
        Dim count = 0
        Dim othercount = 0


        Dim bytes = New Byte(7) {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}
        While True
            delay(500)
            othercount += 1
            If othercount > 200 Then Exit While
            byte1 = 0
            byte2 = 0
            ret = requestRegisterCmd(byte1, byte2)
            If ret = 1 Then
                If (byte1 And bytes(3)) = 0 Then
                    count += 1
                    If count >= 3 Then
                        Exit While
                    End If
                End If
            Else
                delay(300)
                errorcount += 1
                If errorcount > 5 Then
                    Exit While
                End If
            End If

        End While
        Dim coinouttmp1 = 0
        Dim coinouttmp2 = 0
        Dim coinouttmp3 = 0
        Dim coinouttmp4 = 0
        Dim coinouttmp5 = 0
        Dim coinouttmp6 = 0

        delay(100)
        requestBalanceNew(1, coinouttmp1)
        delay(100)
        requestBalanceNew(2, coinouttmp2)
        delay(100)
        requestBalanceNew(3, coinouttmp3)
        delay(100)
        requestBalanceNew(4, coinouttmp4)
        delay(100)
        requestBalanceNew(5, coinouttmp5)
        delay(100)
        requestBalanceNew(6, coinouttmp6)

        Dim returnMoney As Coin = New Coin()

        coin1 = coin1temp - coinouttmp1
        coin2 = coin2temp - coinouttmp2
        coin3 = coin3temp - coinouttmp3
        coin4 = coin4temp - coinouttmp4
        coin5 = coin5temp - coinouttmp5
        coin6 = coin6temp - coinouttmp6
        returnMoney.Coin10 = coin1
        returnMoney.Coin05 = coin2
        returnMoney.Coin2 = coin3
        returnMoney.Coin1New = coin4
        returnMoney.Coin1old = coin5
        returnMoney.Coin05 = coin6

        Return returnMoney
    End Function
    Public Function BCRPayOutMoneyFor3(num1 As Byte, num2 As Byte, num3 As Byte, ByRef coin1 As Integer, ByRef coin2 As Integer, ByRef coin3 As Integer) As Integer
        coin1 = 0
        coin2 = 0
        coin3 = 0
        If num1 + num2 + num3 <= 0 Then Return 1
        Dim ret As Integer


        Dim coin1temp = 0
        Dim coin2temp = 0
        Dim coin3temp = 0
        delay(100)
        requestBalanceNew(1, coin1temp)
        delay(100)
        requestBalanceNew(2, coin2temp)
        delay(100)
        requestBalanceNew(3, coin3temp)



        Dim outindex = New Byte(5) {}
        Dim outbyte = New Byte(5) {}
        outindex(0) = 1
        outindex(1) = 2
        outindex(2) = 3
        outindex(3) = 4
        outindex(4) = 5
        outindex(5) = 6

        If num1 > 0 Then
            outbyte(0) = num1

        End If
        If num2 > 0 Then
            outbyte(1) = num2

        End If
        If num3 > 0 Then
            outbyte(2) = num3

        End If


        ret = payOut3(outindex(0), outbyte(0), outindex(1), outbyte(1), outindex(2), outbyte(2))
        delay(2000)
        Dim byte1 As Byte = 0
        Dim byte2 As Byte = 0
        Dim errorcount = 0
        Dim count = 0
        Dim othercount = 0


        Dim bytes = New Byte(7) {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}
        While True
            delay(500)
            othercount += 1
            If othercount > 200 Then Exit While
            byte1 = 0
            byte2 = 0
            ret = requestRegisterCmd(byte1, byte2)
            If ret = 1 Then
                If (byte1 And bytes(3)) = 0 Then
                    count += 1
                    If count >= 3 Then
                        Exit While
                    End If
                End If
            Else
                delay(300)
                errorcount += 1
                If errorcount > 5 Then
                    Exit While
                End If
            End If

        End While
        Dim coinouttmp1 = 0
        Dim coinouttmp2 = 0
        Dim coinouttmp3 = 0

        delay(100)
        requestBalanceNew(1, coinouttmp1)
        delay(100)
        requestBalanceNew(2, coinouttmp2)
        delay(100)
        requestBalanceNew(3, coinouttmp3)

        coin1 = coin1temp - coinouttmp1
        coin2 = coin2temp - coinouttmp2
        coin3 = coin3temp - coinouttmp3
        Return 1



    End Function


    Public Function payOut3(box1 As Byte, num1 As Byte, box2 As Byte, num2 As Byte, box3 As Byte, num3 As Byte) As Integer
        Dim sendlen = 11
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H55
        sendbuf(4) = box1
        sendbuf(5) = num1
        sendbuf(6) = box2
        sendbuf(7) = num2
        sendbuf(8) = box3
        sendbuf(9) = num3
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 16 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function
    Public Function payOut6(box1 As Byte, num1 As Byte, box2 As Byte, num2 As Byte, box3 As Byte, num3 As Byte, box4 As Byte, num4 As Byte, box5 As Byte, num5 As Byte, box6 As Byte, num6 As Byte) As Integer
        Dim sendlen = 17
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H55
        sendbuf(4) = box1
        sendbuf(5) = num1
        sendbuf(6) = box2
        sendbuf(7) = num2
        sendbuf(8) = box3
        sendbuf(9) = num3
        sendbuf(10) = box4
        sendbuf(11) = num4
        sendbuf(12) = box5
        sendbuf(13) = num5
        sendbuf(14) = box6
        sendbuf(15) = num6
        makeCheck2(sendbuf, sendlen) 'Generate a checksum.
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen) 'Send data.
            Console.WriteLine("发送payOut6命令：" & ByteUtils.ToHexString(sendbuf, sendlen).ToString())
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then
                    Console.WriteLine("rev：" & ByteUtils.ToHexString(dataArray, Length).ToString())
                    If Length = 5 Then
                        Return 1
                    ElseIf Length = 16 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function


    Public Function isHopperType(box As Byte, ByRef byte1 As Byte) As Integer
        Dim sendlen = 6
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H77
        sendbuf(4) = box
        byte1 = &H0
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 13 Then
                        byte1 = CByte((dataArray(6) - &H30) * 100 + (dataArray(7) - &H30) * 10 + dataArray(8) - &H30)
                        Return 1
                    ElseIf Length = 19 Then
                        byte1 = CByte((dataArray(12) - &H30) * 100 + (dataArray(13) - &H30) * 10 + dataArray(14) - &H30)
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function




    Public Function requestOptoState(ByRef byte1 As Byte, ByRef byte2 As Byte) As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &HEC
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 7 Then
                        byte1 = dataArray(4)
                        byte2 = dataArray(5)
                        Return 1
                    ElseIf Length = 12 Then
                        byte1 = dataArray(9)
                        byte2 = dataArray(10)
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function




    Public Function requestSoftwareRevision() As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &HF1
        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 17 Then
                        Return 1
                    ElseIf Length = 22 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function


    Public Sub getCoinNumber(ByRef coin10 As Integer, ByRef coin5 As Integer, ByRef coin1 As Integer)
        coin10 = 0
        coin5 = 0
        coin1 = 0
        For i = 0 To 15
            'Hardcode 1-3.
            If i = 0 OrElse i = 1 Then
                coin10 = coin10 + inArray(i)

            End If
            If i = 2 OrElse i = 3 OrElse i = 4 Then
                coin5 = coin5 + inArray(i)
            End If
            If i = 5 OrElse i = 6 OrElse i = 7 Then
                coin1 = coin1 + inArray(i)

            End If

        Next
    End Sub

    Public Sub getCoinNumberTo6(ByRef coin1 As Integer, ByRef coin2 As Integer, ByRef coin3 As Integer, ByRef coin4 As Integer, ByRef coin5 As Integer, ByRef coin6 As Integer)
        coin1 = 0
        coin2 = 0
        coin3 = 0
        coin4 = 0
        coin5 = 0
        coin6 = 0
        For i = 0 To 15
            If i = 0 Then
                coin1 = coin1 + inArray(i)
            End If
            If i = 1 Then
                coin2 = coin2 + inArray(i)
            End If
            If i = 2 Then
                coin3 = coin3 + inArray(i)
            End If
            If i = 3 Then
                coin4 = coin4 + inArray(i)
            End If
            If i = 4 Then
                coin5 = coin5 + inArray(i)
            End If
            If i = 5 Then
                coin6 = coin6 + inArray(i)
            End If

        Next
    End Sub

    ''' <summary>
    ''' requestCoinInByType
    ''' </summary>
    ''' <returns></returns>
    Public Function requestCoinInByType() As Integer
        clearInCoin()
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H52

        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then
                    '  Console.WriteLine("requestCoinInByType" + ByteUtils.ToHexString(dataArray, sendlen));
                    If Length = 42 Then
                        For i = 0 To 15
                            inArray(i) = dataArray(i * 2 + 9) + dataArray(i * 2 + 10) * 256
                        Next

                        Return 1
                    ElseIf Length = 37 Then
                        For i = 0 To 15
                            inArray(i) = dataArray(i * 2 + 4) + dataArray(i * 2 + 5) * 256
                        Next
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function
    Public Function startAcceptCoin(byte1 As Byte, byte2 As Byte) As Integer
        Dim ret As Integer
        clearInChannel()
        ret = modifyStatus(byte1, byte2)
        Return ret
    End Function
    Public Function stopAcceptCoin() As Integer
        Dim ret As Integer
        ret = modifyStatus(0, 0)
        Return ret
    End Function


    Public Function modifyBalanceTosingle(box As Byte, newbalance As Integer) As Integer
        Dim byte1, byte2 As Byte
        byte1 = CByte(newbalance Mod 256)
        byte2 = CByte(newbalance / 256 Mod 256)
        Dim sendlen = 8
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H78
        sendbuf(4) = box
        sendbuf(5) = byte1
        sendbuf(6) = byte2
        makeCheck2(sendbuf, sendlen) 'Generate checksum.
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen) 'Send data.
            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 13 Then
                        Return 1
                    ElseIf Length = 5 Then
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If

    End Function

    Private Function requestBalanceNew(box As Byte, ByRef balance As Integer) As Integer
        Dim errorcount = 0
        Dim ret As Integer
        ret = requestBalance(box, balance)
        While ret <> 1
            errorcount += 1
            If errorcount > 3 Then Return ret
            delay(200)
            ret = requestBalance(box, balance)
        End While
        Return 1

    End Function

    Public Function requestBalance(box As Byte, ByRef balance As Integer) As Integer
        balance = 0
        Dim sendlen = 6
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen - 5)
        sendbuf(2) = &HFF
        sendbuf(3) = &H77
        sendbuf(4) = box

        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)

            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then

                    If Length = 13 Then
                        balance = CInt(dataArray(10)) + CInt(dataArray(11)) * 256
                        Return 1
                    ElseIf Length = 19 Then
                        balance = CInt(dataArray(16)) + CInt(dataArray(17)) * 256
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If
    End Function


    ''' <summary>
    ''' ModifyHopperBalanceCmd
    ''' </summary>
    ''' <paramname="boxNo">box</param>
    ''' <paramname="count">number</param>
    ''' <returns>1：success</returns>
    Public Function ModifyHopperBalanceCmd(boxNo As Integer, count As UShort) As Integer
        Dim counts = BitConverter.GetBytes(count)

        Dim box As Byte = boxNo 'hopperNo

        Dim sendlen = 8
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = &H3
        sendbuf(2) = &H1
        sendbuf(3) = &H3C
        sendbuf(4) = box
        sendbuf(5) = counts(0)
        sendbuf(6) = counts(1)

        makeCheck2(sendbuf, sendlen)
        Dim ret = 0

        If isOpen() Then
            ret = sendCmd(sendbuf, sendlen)
            If ret > 0 Then
                If arrayCheck2(dataArray, Length) Then
                    If Length = 5 OrElse Length = 10 Then
                        ret = 1
                    End If
                End If
            End If
        End If
        Return ret
    End Function




    ''' <summary>
    ''' Header 062 : Request error manifest
    ''' </summary>
    ''' <paramname="byte1">Bit 0 – Coin in conveyor motor locked-rotor ( 1 = locked )
    ''' Bit 1 –Coin out conveyor motor locked-rotor( 1 = locked )
    ''' Bit 2 –Validation coil abnormal( 1 = abnormal )
    ''' Bit 3 – Turnplate motor locked-rotor( 1 = locked )
    ''' Bit 4 – {Reserved}
    ''' Bit 5 – {Reserved}
    ''' Bit 6 – {Reserved}
    ''' Bit 7 –Coin out slot jammed (1 = jammed)</param>
    ''' <paramname="byte2">
    ''' Bit 0 –{Reserved}
    ''' Bit 1 – Hopper 1 timeout(1 = timeout)
    ''' Bit 2 – Hopper 2 timeout(1 = timeout)
    ''' Bit 3 – Hopper 3 timeout(1 = timeout)
    ''' Bit 4 – Hopper 4 timeout(1 = timeout)
    ''' Bit 5 – Hopper 5 timeout(1 = timeout)
    ''' Bit 6 – Hopper 6 timeout(1 = timeout)
    ''' Bit 7 – {Reserved }</param>
    ''' <paramname="byte3">Bit 0 – Coin box full ( 1 = full ) 
    ''' Bit 1 – Hopper 1 full( 1 = full )
    ''' Bit 2 – Hopper 2 full( 1 = full )
    ''' Bit 3 – Hopper 3 full( 1 = full )
    ''' Bit 4 – Hopper 4 full( 1 = full )
    ''' Bit 5 – Hopper 5 full( 1 = full )
    ''' Bit 6 – Hopper 6 full( 1 = full )
    ''' Bit 7 –{Reserved}</param>
    ''' <paramname="byte4">Bit 0 –{Reserved}
    ''' Bit 1 – Hopper 1 empty( 1 = empty )
    ''' Bit 2 – Hopper 2 empty( 1 = empty )
    ''' Bit 3 – Hopper 3 empty( 1 = empty )
    ''' Bit 4 – Hopper 4 empty( 1 = empty )
    ''' Bit 5 – Hopper 5 empty( 1 = empty )
    ''' Bit 6 – Hopper 6 empty( 1 = empty )
    ''' Bit 7 –{Reserved}</param>
    ''' <returns></returns>
    Public Function RequestErrorManifestFor6(ByRef byte1 As Byte, ByRef byte2 As Byte, ByRef byte3 As Byte, ByRef byte4 As Byte) As Integer
        Dim sendlen = 5
        Dim sendbuf = New Byte(49) {}
        sendbuf(0) = &H37
        sendbuf(1) = CByte(sendlen)
        sendbuf(2) = &HFF
        sendbuf(3) = &H3E

        makeCheck2(sendbuf, sendlen)
        If isOpen() Then
            Dim ret As Integer = sendCmd(sendbuf, sendlen)

            If ret = 1 Then
                If arrayCheck2(dataArray, Length) Then
                    If Length = 9 Then
                        byte1 = dataArray(4)
                        byte2 = dataArray(5)
                        byte3 = dataArray(6)
                        byte4 = dataArray(7)
                        Return 1
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Else
                Return ret
            End If
        Else
            Return -2
        End If


    End Function


End Class