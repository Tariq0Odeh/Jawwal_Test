Public Class frmDigitalGoods6

    Private Sub btnMainMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMainMenu.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods6 -> btnMainMenu_MouseDown")
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

End Class