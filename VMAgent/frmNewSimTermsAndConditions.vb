﻿Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.Drawing.Text

Public Class frmNewSimTermsAndConditions

    Public ListOfNumbers As String = ""
    Private privateFonts As New PrivateFontCollection()
    Private parentFrm As Form
    Public Sub New(parent As Form)
        Me.parentFrm = parent
        InitializeComponent()

    End Sub

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSimTermsAndConditions))
        ExceptionLogger.LogInfo("frmNewSimTermsAndConditions_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmNewSimTermsAndConditions
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    End Sub

    Private Sub frmNewSimTermsAndConditions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmNewSimTermsAndConditions_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmNewSimTermsAndConditions_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmNewSimTermsAndConditions -> frmNewSimTermsAndConditions_Load ")
        RichTextBox1.Dock = DockStyle.Fill
        RichTextBox1.RightToLeft = RightToLeft.Yes

        LoadCustomFonts()
        AlignTextRight()

        If privateFonts.Families.Length > 0 Then
            RichTextBox1.Font = New Font(privateFonts.Families(0), 12) ' Example font size
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSimTermsAndConditions -> btnOk_Click ")

        ' Cast the parent form to the expected type and then access its properties/methods
        Dim parentWithAgreeStatus = TryCast(parentFrm, Object)

        If parentWithAgreeStatus IsNot Nothing Then
            ' Use Reflection to access the properties and methods
            Dim agreeStatusProperty = parentWithAgreeStatus.GetType().GetField("AgreeStatus")
            Dim agreeStatusValue As Boolean = False
            If agreeStatusProperty IsNot Nothing Then
                agreeStatusValue = CBool(agreeStatusProperty.GetValue(parentWithAgreeStatus))
            End If

            If Not agreeStatusValue Then
                Dim agreeMethod = parentWithAgreeStatus.GetType().GetMethod("btnAgreeStatus_Click")
                If agreeMethod IsNot Nothing Then
                    agreeMethod.Invoke(parentWithAgreeStatus, New Object() {Nothing, Nothing})
                End If
            End If
        End If

        Me.Close()

        'If Not parentFrm.AgreeStatus Then
        '    parentFrm.btnAgreeStatus_Click(Nothing, Nothing)
        'End If
        Me.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSimTermsAndConditions -> btnBack_Click ")
        Me.Close()
    End Sub

    Private Sub AlignTextRight()
        ' Select all text in the RichTextBox and set its alignment to right
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
        RichTextBox1.DeselectAll()
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