Imports System.Reflection

Public Class frmSIMSwap2

    Public MobileNumber As String = ""
    Public IDNumber As String = ""

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap2))
        ExceptionLogger.LogInfo("frmSIMSwap2_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap2
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap2_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap2_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub btnPINCode_Click(sender As Object, e As EventArgs) Handles btnPINCode.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Globals.ShowPleaseWait(Me)

        If APIs.SendOTP(MobileNumber.Substring(1), "simswap", frmSIMSwap.SessionId) = True Then

            Globals.HidePleaseWait(Me)

            Dim obj As New frmSIMSwap3
            obj.MobileNumber = MobileNumber
            obj.IDNumber = IDNumber
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()
        Else

            Globals.HidePleaseWait(Me)

        End If

    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap4
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnSerialNumber_Click(sender As Object, e As EventArgs) Handles btnSerialNumber.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap6
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnQuestions_Click(sender As Object, e As EventArgs) Handles btnQuestions.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Globals.ShowPleaseWait(Me)

        Dim QuestionsList As String = APIs.GetQuestions(frmSIMSwap.SessionId)

        Globals.HidePleaseWait(Me)

        Dim obj As New frmSIMSwap7
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.QuestionsList = QuestionsList
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub



End Class