Public Class ctlMsisdn

    Public Msisdn As String = ""
    Public Price As String = ""

    Public ParentPanel As New Panel
    Public IsSelected As Boolean = False

    Private Sub btnSelectUnSelect_Click(sender As Object, e As EventArgs) Handles btnSelectUnSelect.Click

        If IsSelected = False Then

            For I As Integer = 0 To ParentPanel.Controls.Count - 1
                If ParentPanel.Controls(I).GetType = GetType(ctlMsisdn) Then
                    CType(ParentPanel.Controls(I), ctlMsisdn).UnSelect()
                End If
            Next

            IsSelected = True
            Me.BackgroundImage = picSelected.Image
        Else
            IsSelected = False
            Me.BackgroundImage = picUnselected.Image
        End If

    End Sub

    Public Sub UnSelect()
        IsSelected = False
        Me.BackgroundImage = picUnselected.Image
    End Sub

End Class
