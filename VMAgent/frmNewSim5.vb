Public Class frmNewSim5

    Public Msisdn As String = ""
    Public Price As String = ""
    Public IDNumber As String = ""
    Public FullName As String = ""
    Public DateOfBirth As String = ""
    Public PlaceOfBirth As String = ""
    Public AddressRegion As String = ""
    Public AddressCity As String = ""
    Public Gender As String = ""
    Public DocType As String = ""
    Public reservationID As String = ""
    Public resourceID As String = ""
    Public IsESIM As Boolean = False
    Public MsisdnType As String = ""
    Public PackageCode As String = ""
    Public DocumentFileData() As Byte

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim5))
        ExceptionLogger.LogInfo("frmNewSim5_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmNewSim5
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmNewSim5_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmNewSim5_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmNewSim5_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmNewSim5 -> frmNewSim5_Load ")
        kbKeyboard.txtBox = txtEmailAddress

        AddHandler kbKeyboard.EnterButtonClicked, AddressOf ExecuteOK

    End Sub

    Private Sub txtEmailAddress_Click(sender As Object, e As EventArgs) Handles txtEmailAddress.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> txtEmailAddress_Click ")
        kbKeyboard.txtBox = txtEmailAddress

    End Sub

    Private Sub txtContactNumber_Click(sender As Object, e As EventArgs) Handles txtContactNumber.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> txtContactNumber_Click ")
        kbKeyboard.txtBox = txtContactNumber

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnOK_Click ")
        ExecuteOK()

    End Sub

    Private Sub ExecuteOK()

        lblErrorDescription.Text = ""

        If ValidationRules.VR001(txtEmailAddress.Text) = True And ValidationRules.VR014(txtContactNumber.Text) = True Then

            Dim obj As New frmNewSim6
            obj.Msisdn = Msisdn
            obj.Price = Price
            obj.IDNumber = IDNumber
            obj.FullName = FullName
            obj.DateOfBirth = DateOfBirth
            obj.PlaceOfBirth = PlaceOfBirth
            obj.AddressRegion = AddressRegion
            obj.AddressCity = AddressCity
            obj.Gender = Gender
            obj.DocType = DocType
            obj.reservationID = reservationID
            obj.resourceID = resourceID
            obj.IsESIM = IsESIM
            obj.MsisdnType = MsisdnType
            obj.PackageCode = PackageCode
            obj.EmailAddress = txtEmailAddress.Text
            obj.ContactNumber = txtContactNumber.Text
            obj.DocumentFileData = DocumentFileData
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()
        Else

            If txtEmailAddress.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال البريد الالكتروني"
            ElseIf ValidationRules.VR001(txtEmailAddress.Text) = False Then
                lblErrorDescription.Text = "البريد الالكتروني المدخل غير صحيح"
            ElseIf txtContactNumber.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال رقم للتواصل"
            ElseIf ValidationRules.VR014(txtContactNumber.Text) = False Then
                lblErrorDescription.Text = "الرقم المدخل للتواصل غير صحيح"
            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim5 -> btnBack_Click ")
        Me.Close()
    End Sub

End Class