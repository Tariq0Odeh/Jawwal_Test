' 1 	10 	    LIS
' 2 	5 	    LIS
' 3 	2 	    LIS
' 4 	1 	    new LIS
' 5 	1 	    old LIS
' 6 	0.5 	LIS

Public Class Coin
    Public Property Coin10 As Integer
    Public Property Coin5 As Integer
    Public Property Coin2 As Integer
    Public Property Coin1New As Integer
    Public Property Coin1old As Integer
    Public Property Coin05 As Integer

    Public Function Total() As Decimal
        Return (Coin10 * 10 + Coin5 * 5 + Coin2 * 2 + Coin1New + Coin1old + Coin05 * 0.5)
    End Function
End Class
