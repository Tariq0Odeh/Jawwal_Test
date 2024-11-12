Imports Newtonsoft.Json.Linq

Public Class frmNewSim1

    Public ListOfNumbers As String = ""


    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSim1))
        ExceptionLogger.LogInfo("frmNewSim1_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmNewSim1
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmNewSim1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmNewSim1_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmNewSim1_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmNewSim1 -> frmNewSim1_Load ")
        Dim jsonObj As JObject = JObject.Parse(ListOfNumbers)
        If jsonObj("code") = "0" Then

            Dim ALNumbers As JArray = jsonObj("data")

            For I As Integer = 0 To ALNumbers.Count - 1

                Dim MsisdnObj As New JObject
                MsisdnObj = ALNumbers(I)

                If ValidationRules.VR021(MsisdnObj("price").ToString()) = True Then

                    Dim obj As New ctlMsisdn
                    obj.Dock = DockStyle.Top
                    obj.Msisdn = "0" & MsisdnObj("msisdn").ToString()
                    obj.Price = MsisdnObj("price").ToString()

                    obj.txtMsisdn.Text = "0" & MsisdnObj("msisdn").ToString()
                    obj.txtPrice.Text = MsisdnObj("price").ToString() & " شيكل"
                    obj.ParentPanel = pnlMsisdns
                    pnlMsisdns.Controls.Add(obj)
                    obj.BringToFront()

                End If

            Next

        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ExceptionLogger.LogInfo("frmNewSim1 -> btnOK_Click ")
        Dim Msisdn As String = ""
        Dim Price As String = ""

        For I As Integer = 0 To pnlMsisdns.Controls.Count - 1
            If pnlMsisdns.Controls(I).GetType = GetType(ctlMsisdn) Then
                If CType(pnlMsisdns.Controls(I), ctlMsisdn).IsSelected = True Then
                    Msisdn = CType(pnlMsisdns.Controls(I), ctlMsisdn).Msisdn
                    Price = CType(pnlMsisdns.Controls(I), ctlMsisdn).Price
                    Exit For
                End If
            End If
        Next

        lblErrorDescription.Text = ""

        If Msisdn <> "" And Price <> "" Then

            Dim obj As New frmNewSim2
            obj.Msisdn = Msisdn
            obj.Price = Price
            obj.Owner = Me.Owner
            obj.ShowDialog()
            obj.Close()

        Else

            lblErrorDescription.Text = "الرجاء اختيار أحد الأرقام من القائمة"

        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ExceptionLogger.LogInfo("frmNewSim1 -> btnBack_Click ")
        Me.Close()
    End Sub

End Class