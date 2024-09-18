Imports Newtonsoft.Json.Linq

Public Class frmNewSim
    Public Shared SessionId As String = ""
    Private Sub frmNewSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmNewSim -> frmNewSim_Load ")
        Dim ALEntries As New List(Of MsisdnEntry)

        Dim obj1 As New MsisdnEntry
        obj1.EntryName = "اختر المقدمة"
        obj1.EntryValue = ""
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0592"
        obj1.EntryValue = "0592"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0593"
        obj1.EntryValue = "0593"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0594"
        obj1.EntryValue = "0594"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0595"
        obj1.EntryValue = "0595"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0597"
        obj1.EntryValue = "0597"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0598"
        obj1.EntryValue = "0598"
        ALEntries.Add(obj1)

        obj1 = New MsisdnEntry
        obj1.EntryName = "0599"
        obj1.EntryValue = "0599"
        ALEntries.Add(obj1)

        cbEntry.DataSource = ALEntries
        cbEntry.DisplayMember = "EntryName"
        cbEntry.ValueMember = "EntryValue"
        cbEntry.SelectedIndex = 0

        SessionId = APIs.CreateSession(APIs.ServiceNames.newsim.ToString())
        ExceptionLogger.LogInfo("SessionId: " & SessionId)
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn0_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "0"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn1_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "1"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn2_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "2"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn3_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "3"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn4_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "4"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn5_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "5"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn6_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "6"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn7_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "7"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn8_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "8"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        ExceptionLogger.LogInfo("frmNewSim -> btn9_Click ")
        If txtPattern.Text.Length < 6 Then
            txtPattern.Text &= "9"
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ExceptionLogger.LogInfo("frmNewSim -> btnClear_Click ")
        If txtPattern.Text <> "" Then
            txtPattern.Text = txtPattern.Text.Substring(0, txtPattern.Text.Length - 1)
        End If

        ChangeInputBoxBackColor()

    End Sub

    Private Sub ChangeInputBoxBackColor()

        If txtPattern.Text <> "" Then
            txtPattern.BackColor = Color.White
        Else
            txtPattern.BackColor = Color.Transparent
        End If

    End Sub

    Private btnOKCardLock As New Object
    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        SyncLock btnOKCardLock
            ExceptionLogger.LogInfo("frmNewSim -> btnOK_Click ")
            lblErrorDescription.Text = ""

            If (Not cbEntry.SelectedItem Is Nothing AndAlso CType(cbEntry.SelectedItem, MsisdnEntry).EntryValue <> "") And txtPattern.Text.Length > 0 Then

                Globals.ShowPleaseWait(Me)

                Dim CC As New CameraCapture
                CurrentTransaction.CustomerPhoto1 = CC.CaptureAsBase64String()

                Dim IsOK As Boolean = False
                Dim ListOfNumbers As String = APIs.SearchForNumber(CType(cbEntry.SelectedItem, MsisdnEntry).EntryValue, txtPattern.Text, frmNewSim.SessionId)

                Dim jsonObj As JObject = JObject.Parse(ListOfNumbers)
                If jsonObj("code") = "0" Then
                    Dim ALNumbers As JArray = jsonObj("data")
                    If ALNumbers.Count > 0 Then
                        IsOK = True
                    End If
                End If

                If IsOK = True Then

                    Globals.HidePleaseWait(Me)

                    Dim obj As New frmNewSim1
                    obj.ListOfNumbers = ListOfNumbers
                    obj.Owner = Me
                    obj.ShowDialog()

                Else

                    lblErrorDescription.Text = "الرقم المفضل غير متوفر، الرجاء ادخال خيارات أخرى"

                    Globals.HidePleaseWait(Me)

                End If

            Else

                If (cbEntry.SelectedItem Is Nothing Or CType(cbEntry.SelectedItem, MsisdnEntry).EntryValue = "") Then
                    lblErrorDescription.Text = "الرجاء اختيار المقدمة"
                ElseIf txtPattern.Text = "" Then
                    lblErrorDescription.Text = "الرجاء ادخال محتويات الرقم الذي تفضله"
                End If

            End If
        End SyncLock
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim -> btnBack_Click ")
        Me.Close()
    End Sub



End Class