Imports Mei.Bnr
Imports VinderSDK

Public Class Form1
    Dim bnr As New Bnr

    Dim coinCashRecy As CoinCashRecycler

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button2.Enabled = False
        Button3.Enabled = False



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim isCash = RadioButton1.Checked
        Dim isCoin = RadioButton2.Checked
        If RadioButton3.Checked Then
            isCash = True
            isCoin = True
        End If
        coinCashRecy = New CoinCashRecycler(isCash, isCoin, 2)
        MessageBox.Show("Opened Succesfuly ? = " + coinCashRecy.InitCoinCashRecyclers().ToString())
        Button1.Text = "Opened"
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim isCash = RadioButton1.Checked
        Dim isCoin = RadioButton2.Checked
        If RadioButton3.Checked Then
            isCash = True
            isCoin = True
        End If
        'MessageBox.Show("Open = " + coinCashRecy.StartAcceptingMoney(isCash, isCoin).TotalMoney().ToString())

        AddHandler coinCashRecy.OnCoinCashDeposit, AddressOf OnCoinCash

        coinCashRecy.StartAcceptingCoinCash(isCash, isCoin)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim isCash = RadioButton1.Checked
        Dim isCoin = RadioButton2.Checked
        If RadioButton3.Checked Then
            isCash = True
            isCoin = True
        End If
        Dim retunredMeny = coinCashRecy.ReturnCashAndCoins(isCash, isCoin, Decimal.Parse(txtReturned.Text))
        'MessageBox.Show("Open = " + retunredMeny.TotalMoney().ToString())
    End Sub

    Public Sub OnCoinCash(ByVal Amount As Decimal)

        Invoke(New OnCoinCashDepositDelegate(AddressOf OnCoinCashDeposit), Amount)

    End Sub



    Private Delegate Sub OnCoinCashDepositDelegate(ByVal Amount As Decimal)
    Private Sub OnCoinCashDeposit(ByVal Amount As Decimal)

        txtAddedMoney.Text = Val(txtAddedMoney.Text) + Amount

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Dim a As Decimal = coinCashRecy.StopAcceptingMoney()

        MsgBox(a)


    End Sub

    Private Sub btnMoveToCashOut_Click(sender As Object, e As EventArgs) Handles btnMoveToCashOut.Click
        Dim bnr As New CoinCashRecycler(True, False, 2)
        bnr.EmptyCash()


    End Sub
End Class
