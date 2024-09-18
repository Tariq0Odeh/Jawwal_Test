Imports Newtonsoft.Json.Linq

Public Class frmNewSim3

    Public Msisdn As String = ""
    Public Price As String = ""
    Public IDNumber As String = ""
    Public FullName As String = ""
    Public DateOfBirth As String = ""
    Public PlaceOfBirth As String = ""
    Public AddressRegion As String = ""
    Public Gender As String = ""
    Public DocType As String = ""
    Public reservationID As String = ""
    Public resourceID As String = ""
    Public DocumentFileData() As Byte

    Private Sub frmNewSim3_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmNewSim3 -> frmNewSim3_Load ")
        txtFullName.Text = FullName
        If txtFullName.Text <> "" Then
            txtFullName.BackColor = Color.White
        Else
            txtFullName.BackColor = Color.Transparent
        End If

        txtIdNumber.Text = IDNumber
        If txtIdNumber.Text <> "" Then
            txtIdNumber.BackColor = Color.White
        Else
            txtIdNumber.BackColor = Color.Transparent
        End If

        Try
            Dim DT As Date
            If Date.TryParseExact(DateOfBirth, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, DT) = True Then
                dtpDateOfBirth.Value = DT
            End If
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        Try
            cbRegion.SelectedValue = AddressRegion
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

        kbKeyboard.txtBox = txtFullName

        AddHandler kbKeyboard.EnterButtonClicked, AddressOf ExecuteOK

        Dim ALRegion As New List(Of LookupItem)

        Dim obj1 As New LookupItem
        obj1.ItemName = "اختر المنطقة"
        obj1.ItemValue = ""
        ALRegion.Add(obj1)

        obj1 = New LookupItem
        obj1.ItemName = "الضفة الغربية"
        obj1.ItemValue = "الضفة الغربية"
        ALRegion.Add(obj1)

        obj1 = New LookupItem
        obj1.ItemName = "غزه"
        obj1.ItemValue = "غزه"
        ALRegion.Add(obj1)

        cbRegion.DataSource = ALRegion
        cbRegion.DisplayMember = "ItemName"
        cbRegion.ValueMember = "ItemValue"
        cbRegion.SelectedIndex = 0

        '-------------------------------------------------------------

        Dim ALCity As New List(Of LookupItem)

        Dim obj2 As New LookupItem
        obj2.ItemName = "اختر المدينة"
        obj2.ItemValue = ""
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "نابلس"
        obj2.ItemValue = "نابلس"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "رام الله"
        obj2.ItemValue = "رام الله"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "بيت لحم"
        obj2.ItemValue = "بيت لحم"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "جنين"
        obj2.ItemValue = "جنين"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "خانيونس"
        obj2.ItemValue = "خانيونس"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "طولكرم"
        obj2.ItemValue = "طولكرم"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "قلقيليه"
        obj2.ItemValue = "قلقيليه"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "الخليل"
        obj2.ItemValue = "الخليل"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "اريحا"
        obj2.ItemValue = "اريحا"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "قطاع غزه"
        obj2.ItemValue = "قطاع غزه"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "جباليا"
        obj2.ItemValue = "جباليا"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "دير البلح"
        obj2.ItemValue = "دير البلح"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "رفح"
        obj2.ItemValue = "رفح"
        ALCity.Add(obj2)

        obj2 = New LookupItem
        obj2.ItemName = "القدس"
        obj2.ItemValue = "القدس"
        ALCity.Add(obj2)

        cbCity.DataSource = ALCity
        cbCity.DisplayMember = "ItemName"
        cbCity.ValueMember = "ItemValue"
        cbCity.SelectedIndex = 0

    End Sub

    Private Sub txtFullName_Click(sender As Object, e As EventArgs) Handles txtFullName.Click
        ExceptionLogger.LogInfo("frmNewSim3 -> txtFullName_Click ")
        kbKeyboard.txtBox = txtFullName
        kbKeyboard.SetKeyboardMode(False)
    End Sub

    Private Sub txtIdNumber_Click(sender As Object, e As EventArgs) Handles txtIdNumber.Click
        ExceptionLogger.LogInfo("frmNewSim3 -> txtIdNumber_Click ")
        kbKeyboard.txtBox = txtIdNumber
        kbKeyboard.SetKeyboardMode(True)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSim3 -> txtIdNumber_Click ")
        ExecuteOK()

    End Sub

    Private Sub ExecuteOK()

        lblErrorDescription.Text = ""

        If (Not cbRegion.SelectedItem Is Nothing AndAlso CType(cbRegion.SelectedItem, LookupItem).ItemValue <> "") And (Not cbCity.SelectedItem Is Nothing AndAlso CType(cbCity.SelectedItem, LookupItem).ItemValue <> "") And txtFullName.Text.Length > 0 And ValidationRules.VR030(txtIdNumber.Text) = True Then

            Globals.ShowPleaseWait(Me)

            Dim PaymentTypeWithPackages As String = APIs.GetPaymentTypeWithPackages(frmNewSim.SessionId)

            Globals.HidePleaseWait(Me)

            Dim obj As New frmNewSim4
            obj.Msisdn = Msisdn
            obj.Price = Price
            obj.IDNumber = txtIdNumber.Text
            obj.FullName = txtFullName.Text
            obj.DateOfBirth = dtpDateOfBirth.Value.ToString("dd/MM/yyyy")
            obj.PlaceOfBirth = PlaceOfBirth
            obj.AddressRegion = CType(cbRegion.SelectedItem, LookupItem).ItemValue
            obj.AddressCity = CType(cbCity.SelectedItem, LookupItem).ItemValue
            obj.Gender = Gender
            obj.DocType = DocType
            obj.reservationID = reservationID
            obj.resourceID = resourceID
            obj.PaymentTypeWithPackages = PaymentTypeWithPackages
            obj.DocumentFileData = DocumentFileData
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()

        Else

            If txtFullName.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال الاسم الرباعي"
            ElseIf txtIdNumber.Text = "" Then
                lblErrorDescription.Text = "الرجاء ادخال رقم الوثيقة"
            ElseIf ValidationRules.VR030(txtIdNumber.Text) = False Then
                lblErrorDescription.Text = "رقم الوثيقة المدخل غير صحيح"
            ElseIf (cbRegion.SelectedItem Is Nothing Or CType(cbRegion.SelectedItem, LookupItem).ItemValue = "") Then
                lblErrorDescription.Text = "الرجاء اختيار المنطقة"
            ElseIf (cbCity.SelectedItem Is Nothing Or CType(cbCity.SelectedItem, LookupItem).ItemValue = "") Then
                lblErrorDescription.Text = "الرجاء اختيار المدينة"
            End If

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim3 -> btnBack_Click ")
        Me.Close()
    End Sub



End Class