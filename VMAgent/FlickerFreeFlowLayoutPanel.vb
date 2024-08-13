Public Class FlickerFreeFlowLayoutPanel
    Inherits FlowLayoutPanel

    Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.EnableNotifyMessage, True)
    End Sub

    Protected Overrides Sub OnNotifyMessage(ByVal m As System.Windows.Forms.Message)
        If m.Msg <> &H14 Then
            MyBase.OnNotifyMessage(m)
        End If
    End Sub

End Class
