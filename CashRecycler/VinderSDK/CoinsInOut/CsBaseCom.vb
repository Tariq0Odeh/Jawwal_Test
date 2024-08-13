Imports System.IO.Ports
Imports System.Threading

Public Class CsBaseCom
    Public sp As SerialPort
    Public Const MAXBUFSIZE As Integer = 4096
    Public dataArray As Byte() = New Byte(4095) {}
    Public Length As Integer = 0
    Public DELAYMS As Integer
    Public Const MAXINBUFF As Integer = 2048
    Public inbuff As Byte() = New Byte(2047) {}
    'Define wait times
    Public COUNTTIME As Integer

    'Define retry times
    Private RETRYCOUNT As Integer = 1


    Private Shared _lock As Object = New Object()
    Public Sub init()
        DELAYMS = 50
        COUNTTIME = 3
    End Sub
    Public Sub New()
        init()
    End Sub
    Public Sub New(sptmp As SerialPort)
        sp = sptmp
        init()
    End Sub
    Public Sub setSerialPort(sptmp As SerialPort)
        sp = sptmp
    End Sub
    Public Function openPort(port As Integer, baud As Integer, databit As Integer, stopbit As Integer, parity As Integer) As Boolean
        sp.Close()
        Dim comname As String
        comname = String.Format("COM{0}", port)
        sp.PortName = comname
        sp.BaudRate = baud
        sp.DataBits = databit
        If stopbit = 0 Then
            sp.StopBits = StopBits.None
        ElseIf stopbit = 1 Then
            sp.StopBits = StopBits.One
        ElseIf stopbit = 2 Then
            sp.StopBits = StopBits.OnePointFive
        ElseIf stopbit = 3 Then
            sp.StopBits = StopBits.Two
        Else
            sp.StopBits = StopBits.One
        End If
        If parity = 0 Then
            sp.Parity = System.IO.Ports.Parity.None
        ElseIf parity = 1 Then
            sp.Parity = System.IO.Ports.Parity.Odd
        ElseIf parity = 2 Then
            sp.Parity = System.IO.Ports.Parity.Even
        Else
            sp.Parity = System.IO.Ports.Parity.None
        End If
        Try
            sp.Open()
        Catch __unusedException1__ As Exception
            Return False
        End Try
        Return sp.IsOpen
    End Function
    Public Function openPort(port As Integer, baud As Integer) As Boolean
        sp.Close()
        Dim comname As String
        comname = String.Format("COM{0}", port)
        sp.PortName = comname
        sp.BaudRate = baud
        sp.DataBits = 8
        sp.StopBits = StopBits.One
        sp.Parity = Parity.None
        Try
            sp.Open()
        Catch ex As Exception
            Return False
        End Try
        Return sp.IsOpen
    End Function
    Public Sub closePort()
        sp.Close()
    End Sub

    Public Sub clearBuf()
        Length = 0
    End Sub
    Public Sub addChar(value As Byte)
        If Length < MAXBUFSIZE Then
            dataArray(Length) = value
            Length += 1
        End If

    End Sub

    Public Sub addArray(array As Byte(), len As Integer)
        For i = 0 To len - 1
            addChar(array(i))
        Next
    End Sub
    Public Sub deleteChar()
        If Length <= 1 Then
            Length = 0
            Return
        End If
        'Shift left by one position
        For i = 0 To Length - 1 - 1
            dataArray(i) = dataArray(i + 1)
        Next
        Length = Length - 1
    End Sub

    Public Function CompareArray(src As Byte(), srcindex As Integer, dst As Byte(), dstindex As Integer, len As Integer) As Integer
        Dim ret = 1
        If len <= 0 Then Return 0
        For i = 0 To len - 1
            If src(i + srcindex) <> dst(i + dstindex) Then
                ret = 0
                Exit For
            End If
        Next
        Return ret
    End Function
    'Array alignment.
    Public Function PosArray(array As Byte(), len As Integer) As Integer
        Dim ret = -1
        For i = 0 To Length - len + 1 - 1
            If CompareArray(dataArray, i, array, 0, len) = 1 Then
                ret = i
                Exit For
            End If
        Next
        Return ret
    End Function
    '获取十六禁止字符串
    Public Function getHexString() As String
        Dim str = ""
        For i = 0 To Length - 1
            str = str & String.Format("{0:X2} ", dataArray(i))
        Next
        Return str
    End Function
    'Retrieve hexadecimal string
    Public Sub setParam(dms As Integer, dcount As Integer)
        DELAYMS = dms
        COUNTTIME = dcount
    End Sub
    'Set delay function
    Public Sub delay(ms As Integer)
        Thread.Sleep(ms)
    End Sub
    'Send array
    Public Function sendArray(array As Byte(), len As Integer) As Integer
        If sp.IsOpen Then
            Try
                sp.Write(array, 0, len)
                Return 1
            Catch ee As TimeoutException
                Return -3
            Catch ee As ArgumentNullException
                Return 0
            Catch ee As ArgumentOutOfRangeException
                Return 0
            Catch ee As ArgumentException
                Return 0
            Catch ee As InvalidOperationException
                Return -2
            End Try
        Else
            Return -2
        End If

    End Function
    ''' <summary>
    ''' Receive data array
    ''' </summary>
    ''' <paramname  array="array of bytes" ></paramname>
    ''' <paramname  len=""></paramname>
    ''' <returns></returns>
    Public Function recvArray(array As Byte(), ByRef len As Integer) As Integer
        Try
            If sp.IsOpen Then
                len = sp.BytesToRead
                If len < MAXINBUFF Then
                    sp.Read(array, 0, len)
                Else
                    sp.Read(array, 0, MAXINBUFF)
                End If

                Return 1
            Else
                len = 0
                Return -2
            End If
        Catch ee As TimeoutException
            Return -3
        Catch ee As ArgumentNullException
            Return 0
        Catch ee As ArgumentOutOfRangeException
            Return 0
        Catch ee As ArgumentException
            Return 0
        Catch ee As InvalidOperationException
            Return -2
        End Try
        ' Exception:
        '   T:System.ArgumentNullException:
        '     The passed buffer is null.
        '
        '   T:System.InvalidOperationException:
        '     The specified port is not open.
        '
        '   T:System.ArgumentOutOfRangeException:
        '     The offset or count parameters exceed the valid range of the passed buffer. 
        '     Offset or count is less than zero.
        '
        '   T:System.ArgumentException:
        '     Offset plus count is greater than the length of the buffer.
        '
        '   T:System.TimeoutException:
        '     There are no bytes available to read.
    End Function
    'Check if the serial port is open.
    Public Function isOpen() As Boolean
        Try
            Return sp.IsOpen
        Catch __unusedException1__ As Exception
            Return False
        End Try
    End Function


    Public Function sendCmd(sendbuf As Byte(), sendlen As Integer) As Integer
        SyncLock _lock
            Console.WriteLine("Thread Name:" & Thread.CurrentThread.ManagedThreadId.ToString())
            Dim len = 0
            Dim cnt = 0
            Dim ret = -11
            Dim readflag = False
            Dim isRun = True
            If isOpen() Then
                recvArray(inbuff, len)
                clearBuf()
                ret = sendArray(sendbuf, sendlen)
                If ret <> 1 Then
                    Dim c = 0
                    While True
                        Thread.Sleep(1000)
                        c += 1
                        ret = sendArray(sendbuf, sendlen)
                        If ret = 1 Then Exit While
                        If c > 3 Then Return ret
                        If ret <> 1 Then Continue While
                    End While
                End If
                While isRun
                    delay(DELAYMS)
                    cnt += 200
                    ret = recvArray(inbuff, len)
                    If len > 0 Then
                        readflag = True
                        cnt = 0
                        addArray(inbuff, len)
                        Exit While
                    End If
                    'Timeout
                    If cnt > 3 * 1000 Then
                        Return ret
                    End If

                    Thread.Sleep(200)
                End While
                If readflag Then
                    ret = 1
                End If
                If ret = -3 Then 'Communication Timeout.
                    If RETRYCOUNT = 1 Then
                        RETRYCOUNT += 1
                        isRun = False
                        sendCmd(sendbuf, sendlen)
                    End If
                    If RETRYCOUNT = 2 Then
                        RETRYCOUNT = 1
                    End If

                    ret = -3 'Communication Timeout.
                End If
                RETRYCOUNT = 1

                Return ret
            Else
                RETRYCOUNT = 1
                ret = -2
            End If

        End SyncLock
        Return -10
    End Function



End Class
