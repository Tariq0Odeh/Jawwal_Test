Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim obj As New CameraCapture
        PictureBox1.Image = obj.Capture()

    End Sub
End Class