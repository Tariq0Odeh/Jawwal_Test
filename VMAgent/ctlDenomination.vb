Public Class ctlDenomination

    Public MobileNumber As String = ""
    Public objBrand As New Brand
    Public objDenomination As New Denomination
    Public TheOwnerForm As Form
    Public MyParent As frmDigitalGoods3

    Private Sub ctlDenomination_Click(sender As Object, e As EventArgs) Handles Me.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods4()
        End If
    End Sub

    Private Sub picDenominationLogo_Click(sender As Object, e As EventArgs) Handles picDenominationLogo.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods4()
        End If
    End Sub

    Private Sub txtendCustomerPriceWithVATLIS_Click(sender As Object, e As EventArgs) Handles txtendCustomerPriceWithVATLIS.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods4()
        End If
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods4()
        End If
    End Sub

    Private Sub OpenDigitalGoods4()

        Dim obj As New frmDigitalGoods4
        obj.MobileNumber = MobileNumber
        obj.objBrand = objBrand
        obj.objDenomination = objDenomination
        obj.Owner = TheOwnerForm
        obj.ShowDialog()

    End Sub

End Class
