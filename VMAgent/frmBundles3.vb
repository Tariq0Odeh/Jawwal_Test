Public Class frmBundles3

    Public MobileNumber As String = ""

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles3))
        ExceptionLogger.LogInfo("frmBundles3_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmBundles3
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub


    Private Sub frmBundles3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmBundles3_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmBundles3_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmBundles3 -> frmBundles3_Load")
    End Sub

    Private Sub btnRoamingT1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoamingT1.MouseDown
        ExceptionLogger.LogInfo("frmBundles3 -> btnRoamingT1_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "1", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "2", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "3", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "4", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "5", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "6", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "8", frmBundles.SessionId)

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

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Roaming", "7", frmBundles.SessionId)

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