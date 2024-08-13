Public Class frmNewSim8

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        ExceptionLogger.LogInfo("frmNewSim8 -> btnMainMenu_Click ")
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

End Class