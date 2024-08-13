Public Class ctlBrand

    Public MobileNumber As String = ""
    Public objBrand As New Brand
    Public TheOwnerForm As Form
    Public MyParent As frmDigitalGoods2

    Private Sub ctlBrand_Click(sender As Object, e As EventArgs) Handles Me.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods3()
        End If
    End Sub

    Private Sub picBrandLogo_Click(sender As Object, e As EventArgs) Handles picBrandLogo.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods3()
        End If
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click
        If MyParent.IgnoreAction = False Then
            OpenDigitalGoods3()
        End If
    End Sub

    Private Sub OpenDigitalGoods3()

        Dim obj As New frmDigitalGoods3
        obj.MobileNumber = MobileNumber
        obj.objBrand = objBrand
        obj.picBrandLogo.Image = picBrandLogo.Image
        obj.txtDescription.Text = objBrand.name & vbNewLine & objBrand.description & vbNewLine & vbNewLine & objBrand.redemptionProcedure
        obj.Owner = TheOwnerForm
        obj.ShowDialog()

    End Sub

End Class
