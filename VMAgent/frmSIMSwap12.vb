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

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSIMSwap12))
        ExceptionLogger.LogInfo("frmSIMSwap12_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmSIMSwap12
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmSIMSwap12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmSIMSwap12_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmSIMSwap12_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

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