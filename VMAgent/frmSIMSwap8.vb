Imports System.Reflection

Public Class frmSIMSwap8

    Public MobileNumber As String = ""
    Public IDNumber As String = ""
    Public Amount As String = ""

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap8))
        ExceptionLogger.LogInfo("frmSIMSwap8_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap8
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap8_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap8_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap8_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
    End Sub

    Private Sub btnNormalSIM_Click(sender As Object, e As EventArgs) Handles btnNormalSIM.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap10
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Amount = Amount
        obj.IsESIM = False
        obj.EmailAddress = ""
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnESIM_Click(sender As Object, e As EventArgs) Handles btnESIM.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Dim obj As New frmSIMSwap9
        obj.MobileNumber = MobileNumber
        obj.IDNumber = IDNumber
        obj.Amount = Amount
        obj.IsESIM = True
        obj.Owner = Me.Owner
        obj.ShowDialog()
        obj.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Close()
    End Sub

End Class