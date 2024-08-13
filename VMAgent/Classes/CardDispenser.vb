Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class CardDispenser

#Region " APIs"

    <DllImport("CRT_driver.dll")>
    Public Shared Sub Select_Dev(iDev As Integer)
    End Sub

    <DllImport("CRT_driver.dll")>
    Public Shared Function R_Open(strPort As String, baudrate As Integer) As Integer
    End Function

    <DllImport("CRT_driver.dll")>
    Public Shared Function R_Close(comHandle As Integer) As Integer
    End Function

    <DllImport("CRT_driver.dll")>
    Public Shared Function R_ExeCommandB(ComHandle As Integer, TxData As Byte(), TxDataLen As Integer, RxData As Byte(), ByRef RxDataLen As Integer) As Integer
    End Function

    <DllImport("CRT_driver.dll")>
    Public Shared Function R_ExeCommandS(ComHandle As Integer, TxData As String, TxDataLen As Integer, RxData As Byte(), ByRef RxDataLen As Integer) As Integer
    End Function

#End Region

    Dim comHandle As Integer = 0
    Dim address = "00"
    Dim baudrate = "9600"

    Public Function Init(com As String, baudrate As String, address As String) As Boolean

        Select_Dev(13)

        Me.baudrate = baudrate
        Me.address = address
        comHandle = R_Open(com, Convert.ToInt32(baudrate))

        If comHandle > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ScanSimCardAndReturnBarCode() As String
        Dim BarCode As String = ""

        Dim rcvData = New Byte(127) {}
        Dim strAdrr = GetAddr(address)
        Dim RxDataLen As Integer = 3
        Dim cmdData As String = ""

        cmdData = strAdrr & "464340"
        RxDataLen = 0

        Dim iRet As Integer = 0
        Dim counter = 3
        While counter > 0 And iRet = 0


            iRet = R_ExeCommandS(comHandle, cmdData, cmdData.Length / 2, rcvData, RxDataLen)

            If iRet >= 0 Then

                Thread.Sleep(1000)

                rcvData = New Byte(127) {}
                cmdData = strAdrr & "4249"
                RxDataLen = 17

                iRet = R_ExeCommandS(comHandle, cmdData, cmdData.Length / 2, rcvData, RxDataLen)

                If iRet = 0 Then
                    Dim TempBarCode As String = Encoding.ASCII.GetString(rcvData)
                    For I As Integer = 0 To TempBarCode.Length - 1
                        If IsNumeric(TempBarCode.Substring(I, 1)) = True Then
                            BarCode &= TempBarCode.Substring(I, 1)
                        End If
                    Next
                End If
                counter = 0
            Else
                counter = counter - 1
                Threading.Thread.Sleep(500)
            End If
        End While
        Return BarCode
    End Function

    Public Function DispenseCard() As Boolean

        Dim rcvData = New Byte(127) {}
        Dim strAddr As String = GetAddr(address)
        Dim RxDataLen As Integer = 3
        Dim cmdData As String = ""

        cmdData = strAddr & "4443"
        RxDataLen = 0

        Dim iRet As Integer = R_ExeCommandS(comHandle, cmdData, cmdData.Length / 2, rcvData, RxDataLen)

        If iRet >= 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function CaptureCard() As Boolean

        Dim rcvData = New Byte(127) {}
        Dim strAddr As String = GetAddr(address)
        Dim RxDataLen As Integer = 3
        Dim cmdData As String = ""

        cmdData = strAddr & "4350"
        RxDataLen = 0

        Dim iRet As Integer = R_ExeCommandS(comHandle, cmdData, cmdData.Length / 2, rcvData, RxDataLen)

        If iRet >= 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function CheckStatus() As String
        Dim returnValue = ""

        Dim rcvData = New Byte(127) {}
        Dim strAddr As String = GetAddr(address)
        Dim RxDataLen As Integer = 3
        Dim cmdData As String = ""

        cmdData = strAddr & "5246"
        RxDataLen = 3

        Dim iRet As Integer = R_ExeCommandS(comHandle, cmdData, cmdData.Length / 2, rcvData, RxDataLen)

        If iRet >= 0 Then

            If GetBitValue(rcvData(0), 3) = 1 Then
                returnValue = "Issuing card" & vbLf
            End If
            If GetBitValue(rcvData(0), 2) = 1 Then
                returnValue = "Receiving card" & vbLf
            End If
            If GetBitValue(rcvData(0), 1) = 1 Then
                returnValue = "Card issuance error" & vbLf
            End If
            If GetBitValue(rcvData(0), 0) = 1 Then
                returnValue = "Card receiving error" & vbLf
            End If

            If GetBitValue(rcvData(1), 3) = 1 Then
                returnValue += ("No capture card" & vbLf)
            End If
            If GetBitValue(rcvData(1), 2) = 1 Then
                returnValue += ("Overlapping card" & vbLf)
            End If
            If GetBitValue(rcvData(1), 1) = 1 Then
                returnValue += ("Blocking card" & vbLf)
            End If
            If GetBitValue(rcvData(1), 0) = 1 Then
                returnValue += ("Card pre empty" & vbLf)
            End If

            If GetBitValue(rcvData(2), 3) = 1 Then
                returnValue += ("Card empty" & vbLf)
            End If
            If GetBitValue(rcvData(2), 2) = 1 Then
                returnValue += ("Disp-Sensor Status" & vbLf)
            End If
            If GetBitValue(rcvData(2), 1) = 1 Then
                returnValue += ("Light sensing 2 status" & vbLf)
            End If
            If GetBitValue(rcvData(2), 0) = 1 Then
                returnValue += ("Light sensing 1 status")
            End If
        End If

        Return returnValue
    End Function

    Public Sub ClosePort()

        If comHandle > 0 Then
            Dim Ret As Integer = R_Close(comHandle)
        End If

    End Sub

    Private Function GetAddr(Addr As String) As String
        Dim strAddr As String = Addr
        Dim bAddr = Encoding.ASCII.GetBytes(strAddr)
        strAddr = BitConverter.ToString(bAddr).Replace("-", "")
        Return strAddr
    End Function

    Private Function GetBitValue(b As Byte, bitIndex As Integer) As Integer
        If bitIndex < 0 OrElse bitIndex > 7 Then
        End If
        Return b >> bitIndex And 1
    End Function

End Class
