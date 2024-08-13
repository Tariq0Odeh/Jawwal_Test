Public Class frmBundles5

    Public MobileNumber As String = ""
    Public BundleType As String = ""
    Public objBundle As New Bundle

    Private Sub frmBundles5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExceptionLogger.LogInfo("frmMenu -> frmBundles5_Load ")
    End Sub

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        ExceptionLogger.LogInfo("frmMenu -> btnOK_MouseDown ")
        Dim obj As New frmBundles6
        obj.MobileNumber = MobileNumber
        obj.BundleType = BundleType
        obj.objBundle = objBundle
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmMenu -> btnBack_MouseDown ")
        Me.Close()
    End Sub

    Public Sub FillData()

        txtappType.Text = objBundle.appType
        txtappPrice.Text = objBundle.appPrice & " شيكل"
        txtminutesSize.Text = objBundle.minutesSize
        txtminutesSize2.Text = objBundle.minutesSize
        txtminutesSize3.Text = objBundle.minutesSize
        txtsmsSize.Text = objBundle.smsSize
        txt3GSize.Text = objBundle.appSize
        txt3GSize2.Text = objBundle.appSize
        txt3GOnlySize.Text = objBundle.appSize

        If objBundle.minutesSize <> "" AndAlso ValidationRules.VR021(objBundle.minutesSize) = True Then
            txtminutesSize.Text &= " دقيقة"
            txtminutesSize2.Text &= " دقيقة"
            txtminutesSize3.Text &= " دقيقة"
        End If

        If objBundle.appSize.Contains("GB") = True Then
            txt3GSize.Text &= " انترنت"
            txt3GSize2.Text &= " انترنت"
            txt3GOnlySize.Text &= " انترنت"
        End If

        If objBundle.appSize <> "" And objBundle.minutesSize = "" And objBundle.smsSize = "" Then
            pnl3G.Visible = True
            pnl3GMins.Visible = False
            pnlMins.Visible = False
        ElseIf objBundle.appSize <> "" And objBundle.minutesSize <> "" And objBundle.smsSize = "" Then
            pnl3G.Visible = False
            pnl3GMins.Visible = True
            pnlMins.Visible = False
        ElseIf objBundle.appSize = "" And objBundle.minutesSize <> "" And objBundle.smsSize = "" Then
            pnl3G.Visible = False
            pnl3GMins.Visible = False
            pnlMins.Visible = True
        Else
            pnl3G.Visible = False
            pnl3GMins.Visible = False
            pnlMins.Visible = False
        End If

        txtproductDescription.Text = objBundle.productDescription

    End Sub

End Class