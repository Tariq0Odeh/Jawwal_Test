Imports System.IO
Imports System.Reflection

Public Class frmSIMSwap12

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        ExceptionLogger.LogInfo(Me.Name & " -> " & MethodBase.GetCurrentMethod().Name)
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

    Private Sub frmSIMSwap12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadQRCode(Globals.QRCode)
    End Sub

    Public Sub LoadQRCode(qrCodeBase64 As String)
        Try
            ' Decode the Base64 string into a byte array
            Dim qrCodeBytes As Byte() = Convert.FromBase64String(qrCodeBase64)

            ' Convert the byte array into a MemoryStream
            Using ms As New MemoryStream(qrCodeBytes)
                ' Create an image from the stream
                Dim qrImage As Image = Image.FromStream(ms)

                ' Display the image in the PictureBox (QR_NewSim)
                QR_SimSwap.Image = qrImage
            End Using
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub
End Class