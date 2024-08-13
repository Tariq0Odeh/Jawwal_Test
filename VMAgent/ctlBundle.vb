Public Class ctlBundle

    Public MobileNumber As String = ""
    Public BundleType As String = ""
    Public objBundle As New Bundle
    Public TheOwnerForm As Form
    Public MyParent As frmBundles4

    Private Sub btnDetailsAndSubscribe_Click(sender As Object, e As EventArgs) Handles btnDetailsAndSubscribe.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub ctlBundle_Click(sender As Object, e As EventArgs) Handles Me.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub pnl3G_Click(sender As Object, e As EventArgs) Handles pnl3G.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub pnl3GMins_Click(sender As Object, e As EventArgs) Handles pnl3GMins.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub pnlMins_Click(sender As Object, e As EventArgs) Handles pnlMins.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txt3GOnlySize_Click(sender As Object, e As EventArgs) Handles txt3GOnlySize.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txt3GSize_Click(sender As Object, e As EventArgs) Handles txt3GSize.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txt3GSize2_Click(sender As Object, e As EventArgs) Handles txt3GSize2.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtappPrice_Click(sender As Object, e As EventArgs) Handles txtappPrice.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtappType_Click(sender As Object, e As EventArgs) Handles txtappType.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtminutesSize_Click(sender As Object, e As EventArgs) Handles txtminutesSize.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtminutesSize2_Click(sender As Object, e As EventArgs) Handles txtminutesSize2.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtminutesSize3_Click(sender As Object, e As EventArgs) Handles txtminutesSize3.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtMinutesSizeZainJordan_Click(sender As Object, e As EventArgs) Handles txtMinutesSizeZainJordan.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub txtsmsSize_Click(sender As Object, e As EventArgs) Handles txtsmsSize.Click
        If MyParent.IgnoreAction = False Then
            OpenBundles5()
        End If
    End Sub

    Private Sub OpenBundles5()

        Dim obj As New frmBundles5
        obj.MobileNumber = MobileNumber
        obj.BundleType = BundleType
        obj.objBundle = objBundle
        obj.FillData()
        obj.Owner = TheOwnerForm
        obj.ShowDialog()

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

    End Sub

End Class
