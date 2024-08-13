Public Class frmBundles3

    Public MobileNumber As String = ""

    Private Sub frmBundles3_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmBundles3 -> frmBundles3_Load")
    End Sub

    Private Sub btnRoamingT1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT1.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT1_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "1")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT2.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT2_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "2")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT3_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT3.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT3_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "3")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT4_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT4.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT4_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "4")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT5_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT5.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT5_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "5")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT6_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT6.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT6_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "6")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT7_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT7.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT7_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "8")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoamingT8_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT8.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT8_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "7")

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Roaming"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnBack_MouseDown")
        Me.Close()
    End Sub



End Class