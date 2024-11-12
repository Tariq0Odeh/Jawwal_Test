
Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Public Class frmNewSim8

    Private privateFonts As New PrivateFontCollection()
    Private isPostOrMix As Boolean

    Public Sub New(Optional isPostOrMix As Boolean = False)
        InitializeComponent()
        Me.isPostOrMix = isPostOrMix
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        ExceptionLogger.LogInfo("frmNewSim8 -> btnMainMenu_Click ")
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim8))
        ExceptionLogger.LogInfo("frmNewSim8_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmNewSim8
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmNewSim8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmNewSim8_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmNewSim8_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        lblSuccessOnPostOrMix.Visible = isPostOrMix
        LoadCustomFonts()
        If privateFonts.Families.Length > 0 Then
            lblSuccessOnPostOrMix.Font = New Font(privateFonts.Families(0), 12) ' Example font size
        End If
        If Not isPostOrMix Then
            LoadQRCode(Globals.QRCode)
        End If
    End Sub

    Private Sub LoadCustomFonts()
        Try
            ' List the font files you want to load
            Dim fontFiles As String() = {
                "Resources\Fonts\Neo_Sans_Arabic_Regular.ttf",
                "Resources\Fonts\Neo_Sans_Medium.ttf",
                "Resources\Fonts\NeoSansArabic-Black.ttf",
                "Resources\Fonts\NeoSansArabic-Bold.ttf",
                "Resources\Fonts\NeoSansArabic-Light.ttf",
                "Resources\Fonts\NeoSansArabic-Medium.ttf",
                "Resources\Fonts\NeoSansArabic-Ultra.ttf",
                "Resources\Fonts\NeoSansArabic.ttf",
                "Resources\Fonts\NeoSansArabicBlack.ttf",
                "Resources\Fonts\NeoSansArabicBold.ttf",
                "Resources\Fonts\NeoSansArabicLight.ttf",
                "Resources\Fonts\NeoSansArabicMedium.ttf",
                "Resources\Fonts\NeoSansArabicUltra.ttf"}



            ' Load each font file
            For Each fontFile As String In fontFiles
                privateFonts.AddFontFile(fontFile)
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading custom font: " & ex.Message)
        End Try
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
                QR_NewSim.Image = qrImage
            End Using
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try
    End Sub

End Class