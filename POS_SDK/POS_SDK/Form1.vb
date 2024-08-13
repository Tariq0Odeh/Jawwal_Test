Public Class txTransIndexCode

    Public pos_sdk As POS_LIP.POS_LIP



    Private Sub RadioPurchase_CheckedChanged(sender As Object, e As EventArgs) Handles RadioPurchase.CheckedChanged
        btnDoAction.Text = "Purchase"
        lblTransAmount.Text = "Trans Purchase"

    End Sub

    Private Sub RadioRefund_CheckedChanged(sender As Object, e As EventArgs) Handles RadioRefund.CheckedChanged
        btnDoAction.Text = "Refund"
        lblTransAmount.Text = "Trans ID"

    End Sub

    Private Sub btnDoAction_Click(sender As Object, e As EventArgs) Handles btnDoAction.Click
        If RadioPurchase.Checked = True Then
            ' Purchase
            Dim ret As String = pos_sdk.Purchase(txtTransIndexCode.Text, txtTransAmmount.Text, txtCurrencyCode.Text, txEnableReceipt.Text, txtSkipConfrimProcedure.Text, txtTimeout.Text)

            ret = ""
        End If
        If RadioRefund.Checked = True Then
            ' Refund
            Dim ret As String = pos_sdk.Refund(txtTransIndexCode.Text, txtTransAmmount.Text, txtCurrencyCode.Text, txEnableReceipt.Text, txtSkipConfrimProcedure.Text, txtTimeout.Text)

            ret = ""
        End If


    End Sub

    Private Sub txTransIndexCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pos_sdk = New POS_LIP.POS_LIP(7, 9600)


    End Sub
End Class
