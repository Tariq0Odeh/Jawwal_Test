
Imports System.Drawing
Imports System.Drawing.Text
Public Class frmNewSim8

    Private privateFonts As New PrivateFontCollection()
    Private isPostOrMix
    Public Sub New(Optional isPostOrMix As Boolean = False)
        InitializeComponent()
    End Sub
    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        ExceptionLogger.LogInfo("frmNewSim8 -> btnMainMenu_Click ")
        Me.Owner.Close()
        Me.Owner.Dispose()
    End Sub

    Private Sub frmNewSim8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSuccessOnPostOrMix.Visible = isPostOrMix
        LoadCustomFonts()
        If privateFonts.Families.Length > 0 Then
            lblSuccessOnPostOrMix.Font = New Font(privateFonts.Families(0), 12) ' Example font size
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
End Class