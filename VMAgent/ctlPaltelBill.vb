Public Class ctlPaltelBill

    Public IsSelected As Boolean = False
    Public objPaltelInvoice As New PaltelInvoice
    Public MyParent As frmPaltelBillPayment1

    Private Sub btnSelectUnSelect_Click(sender As Object, e As EventArgs) Handles btnSelectUnSelect.Click

        If MyParent.IgnoreAction = False Then

            If IsSelected = False Then
                IsSelected = True
                Me.BackgroundImage = picSelected.Image
            Else
                IsSelected = False
                Me.BackgroundImage = picUnselected.Image
            End If

        End If

    End Sub

End Class
