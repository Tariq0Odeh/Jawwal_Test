Public Class frmBundles2

    Public MobileNumber As String = ""

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles2))
        ExceptionLogger.LogInfo("frmBundles2_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmBundles2
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmBundles2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmBundles2_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmBundles2_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmBundles2 -> frmBundles2_Load")
    End Sub

    Private Sub btn3G_MouseDown(sender As Object, e As MouseEventArgs) Handles btn3G.MouseDown
        ExceptionLogger.LogInfo("frmBundles2 -> btn3G_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "3G", "", frmBundles.SessionId)

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "3G"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnMinutes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMinutes.MouseDown
        ExceptionLogger.LogInfo("frmBundles2 -> btnMinutes_MouseDown")
        Globals.ShowPleaseWait(Me)

        Dim RecommendedBundles As String = APIs.GetRecommendedBundles(MobileNumber.Substring(1), "Minutes", "", frmBundles.SessionId)

        Globals.HidePleaseWait(Me)

        Dim obj As New frmBundles4
        obj.MobileNumber = MobileNumber
        obj.BundleType = "Minutes"
        obj.RecommendedBundles = RecommendedBundles
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnRoaming_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRoaming.MouseDown
        ExceptionLogger.LogInfo("frmBundles2 -> btnRoaming_MouseDown")
        Dim obj As New frmBundles3
        obj.MobileNumber = MobileNumber
        obj.Owner = Me.Owner
        obj.ShowDialog()

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmBundles2 -> btnBack_MouseDown")
        Me.Close()
    End Sub



End Class