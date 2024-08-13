Imports System
Imports System.Globalization

Public Class ByteUtils
    Public Shared Function ToHexString(bytes As Byte(), len As Integer) As String
        Dim byteStr = String.Empty
        If bytes IsNot Nothing OrElse bytes.Length > 0 Then
            For i = 0 To len - 1
                byteStr += String.Format("{0:X2}", bytes(i))
            Next
        End If
        Return byteStr
    End Function


    Public Shared Function HexStringToByteArray(hexString As String) As Byte()
        If hexString.Length Mod 2 <> 0 Then
            Throw New ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString))
        End If
        Dim data = New Byte(hexString.Length / 2 - 1) {}
        For index = 0 To data.Length - 1
            Dim byteValue = hexString.Substring(index * 2, 2)
            data(index) = Byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
        Next
        Return data
    End Function

End Class

