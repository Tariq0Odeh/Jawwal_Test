Imports Newtonsoft.Json.Linq

Public Class frmNewSim4

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
    Public PaymentTypeWithPackages As String = ""
    Public DocumentFileData() As Byte

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim4))
        ExceptionLogger.LogInfo("frmNewSim4_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmNewSim4
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmNewSim4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmNewSim4_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmNewSim4_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmNewSim4 -> frmNewSim4_Load ")
        Dim ALSIMType As New List(Of LookupItem)

        Dim obj1 As New LookupItem
        obj1.ItemName = "اختر نوع الشريحة"
        obj1.ItemValue = ""
        ALSIMType.Add(obj1)

        obj1 = New LookupItem
        obj1.ItemName = "SIM شريحة فيزيائية "
        obj1.ItemValue = "SIM"
        ALSIMType.Add(obj1)

        obj1 = New LookupItem
        obj1.ItemName = "eSIM شريحة الكترونية "
        obj1.ItemValue = "eSIM"
        ALSIMType.Add(obj1)

        cbSIMType.DataSource = ALSIMType
        cbSIMType.DisplayMember = "ItemName"
        cbSIMType.ValueMember = "ItemValue"
        cbSIMType.SelectedIndex = 0

        '------------------------------------------------

        Dim ALPaymentTypes As New List(Of LookupItem)

        Dim obj2 As New LookupItem
        obj2.ItemName = "اختر نوع الاشتراك"
        obj2.ItemValue = ""
        ALPaymentTypes.Add(obj2)

        Dim jsonObj As JObject = JObject.Parse(PaymentTypeWithPackages)
        If jsonObj("code") = "0" Then
            Dim ALTypes As JArray = jsonObj("data")
            For I As Integer = 0 To ALTypes.Count - 1

                Dim PaymentType As New JObject
                PaymentType = ALTypes(I)

                obj2 = New LookupItem
                obj2.ItemName = PaymentType("type").ToString()
                obj2.ItemValue = PaymentType("type").ToString()
                ALPaymentTypes.Add(obj2)

            Next
        End If

        cbMsisdnType.DataSource = ALPaymentTypes
        cbMsisdnType.DisplayMember = "ItemName"
        cbMsisdnType.ValueMember = "ItemValue"
        cbMsisdnType.SelectedIndex = 0

        '------------------------------------------------

        Dim ALPackages As New List(Of LookupItem)

        Dim obj3 As New LookupItem
        obj3.ItemName = "اختر برنامجك"
        obj3.ItemValue = ""
        ALPackages.Add(obj3)

        cbPackage.DataSource = ALPackages
        cbPackage.DisplayMember = "ItemName"
        cbPackage.ValueMember = "ItemValue"
        cbPackage.SelectedIndex = 0

    End Sub

    Private Sub MsisdnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMsisdnType.SelectedIndexChanged
        ExceptionLogger.LogInfo("frmNewSim4 -> MsisdnType_SelectedIndexChanged ")
        If (Not cbMsisdnType.SelectedItem Is Nothing AndAlso CType(cbMsisdnType.SelectedItem, LookupItem).ItemValue <> "") Then

            Dim ALPackages As New List(Of LookupItem)

            Dim obj3 As New LookupItem
            obj3.ItemName = "اختر برنامجك"
            obj3.ItemValue = ""
            ALPackages.Add(obj3)

            Dim jsonObj As JObject = JObject.Parse(PaymentTypeWithPackages)
            If jsonObj("code") = "0" Then
                Dim ALTypes As JArray = jsonObj("data")
                For I As Integer = 0 To ALTypes.Count - 1

                    Dim PaymentType As New JObject
                    PaymentType = ALTypes(I)

                    If PaymentType("type").ToString() = CType(cbMsisdnType.SelectedItem, LookupItem).ItemValue Then

                        Dim ALPkgs As JArray = PaymentType("packages")

                        For P As Integer = 0 To ALPkgs.Count - 1

                            Dim PkgData As JObject
                            PkgData = ALPkgs(P)

                            obj3 = New LookupItem
                            obj3.ItemName = PkgData("name").ToString()
                            obj3.ItemValue = PkgData("code").ToString()
                            ALPackages.Add(obj3)

                        Next

                    End If

                Next
            End If

            cbPackage.DataSource = ALPackages
            cbPackage.DisplayMember = "ItemName"
            cbPackage.ValueMember = "ItemValue"
            cbPackage.SelectedIndex = 0

            cbPackage.Enabled = True

        Else

            Dim ALPackages As New List(Of LookupItem)

            Dim obj3 As New LookupItem
            obj3.ItemName = "اختر برنامجك"
            obj3.ItemValue = ""
            ALPackages.Add(obj3)

            cbPackage.DataSource = ALPackages
            cbPackage.DisplayMember = "ItemName"
            cbPackage.ValueMember = "ItemValue"
            cbPackage.SelectedIndex = 0

            cbPackage.Enabled = False

        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSim4 -> btnOK_Click ")
        lblErrorDescription.Text = ""

        If (Not cbSIMType.SelectedItem Is Nothing AndAlso CType(cbSIMType.SelectedItem, LookupItem).ItemValue <> "") And (Not cbMsisdnType.SelectedItem Is Nothing AndAlso CType(cbMsisdnType.SelectedItem, LookupItem).ItemValue <> "") And (Not cbPackage.SelectedItem Is Nothing AndAlso CType(cbPackage.SelectedItem, LookupItem).ItemValue <> "") Then

            Dim obj As New frmNewSim5
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
            obj.IsESIM = If(CType(cbSIMType.SelectedItem, LookupItem).ItemValue = "eSIM", True, False)
            obj.MsisdnType = CType(cbMsisdnType.SelectedItem, LookupItem).ItemValue
            obj.PackageCode = CType(cbPackage.SelectedItem, LookupItem).ItemValue
            obj.DocumentFileData = DocumentFileData
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()
        Else

            If (cbSIMType.SelectedItem Is Nothing Or CType(cbSIMType.SelectedItem, LookupItem).ItemValue = "") Then
                lblErrorDescription.Text = "الرجاء اختيار نوع الشريحة"
            ElseIf (cbMsisdnType.SelectedItem Is Nothing Or CType(cbMsisdnType.SelectedItem, LookupItem).ItemValue = "") Then
                lblErrorDescription.Text = "الرجاء اختيار نوع الاشتراك"
            ElseIf (cbPackage.SelectedItem Is Nothing Or CType(cbPackage.SelectedItem, LookupItem).ItemValue = "") Then
                lblErrorDescription.Text = "الرجاء اختيار البرنامج"
            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim4 -> btnBack_Click ")
        Me.Close()
    End Sub

End Class