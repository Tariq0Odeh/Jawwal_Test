Public Class ctlJawwalBill

    Public IsSelected As Boolean = False
    Public objJawwalInvoice As New JawwalInvoice
    Public MyParent As frmJawwalBillPayment2

    Private Sub btnSelectUnSelect_Click(sender As Object, e As EventArgs) Handles btnSelectUnSelect.Click

        If MyParent.IgnoreAction = False Then

            If IsSelected = False Then

                Dim obj As New frmJawwalBillPayment3
                obj.Amount = txtAmount.Text
                obj.txtAmount.Text = txtAmount.Text
                obj.ShowDialog()

                If obj.IsDone = True Then
                    txtAmountToPay.Text = obj.txtAmount.Text
                    txtAmountToPay.ForeColor = Color.Black
                    objJawwalInvoice.partialAmount = obj.txtAmount.Text
                    IsSelected = True
                    Me.BackgroundImage = picSelected.Image
                End If

            Else
                txtAmountToPay.Text = "0"
                txtAmountToPay.ForeColor = Color.Silver
                objJawwalInvoice.partialAmount = ""
                IsSelected = False
                Me.BackgroundImage = picUnselected.Image
            End If

        End If

    End Sub

End Class
