Imports Newtonsoft.Json.Linq

Public Class frmDigitalGoods2

    Public MobileNumber As String = ""
    Public BrandsDetails As String = ""
    Public IgnoreAction As Boolean = False

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalGoods2))
        ExceptionLogger.LogInfo("frmDigitalGoods2_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmDigitalGoods2
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmDigitalGoods2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmDigitalGoods2_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmDigitalGoods2_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmDigitalGoods2 -> frmDigitalGoods2_Load ")
        Globals.ShowPleaseWait(Me)

        Dim jsonObj As JObject = JObject.Parse(BrandsDetails)
        If jsonObj("code") = "0" Then

            Dim ALBrands As JArray = jsonObj("data")
            For I As Integer = 0 To ALBrands.Count - 1

                Dim objBrand As New Brand

                Dim BrandObj As New JObject
                BrandObj = ALBrands(I)

                objBrand.code = BrandObj("code").ToString()
                objBrand.name = BrandObj("name").ToString()
                objBrand.description = BrandObj("description").ToString()
                objBrand.imagePath = BrandObj("imagePath").ToString()
                objBrand.redemptionProcedure = BrandObj("redemptionProcedure").ToString()

                Dim obj As New ctlBrand
                obj.MobileNumber = MobileNumber
                obj.objBrand = objBrand
                Try
                    obj.picBrandLogo.Load(objBrand.imagePath)
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try
                obj.txtName.Text = objBrand.name
                obj.TheOwnerForm = Me.Owner
                obj.MyParent = Me
                pnlBrands.Controls.Add(obj)

                AddHandler obj.MouseDown, AddressOf pnlBrands_MouseDown
                AddHandler obj.MouseMove, AddressOf pnlBrands_MouseMove
                AddHandler obj.MouseUp, AddressOf pnlBrands_MouseUp

                AddHandler obj.picBrandLogo.MouseDown, AddressOf pnlBrands_MouseDown
                AddHandler obj.picBrandLogo.MouseMove, AddressOf pnlBrands_MouseMove
                AddHandler obj.picBrandLogo.MouseUp, AddressOf pnlBrands_MouseUp

                AddHandler obj.txtName.MouseDown, AddressOf pnlBrands_MouseDown
                AddHandler obj.txtName.MouseMove, AddressOf pnlBrands_MouseMove
                AddHandler obj.txtName.MouseUp, AddressOf pnlBrands_MouseUp

            Next

            If pnlBrands.VerticalScroll.Visible = True Then
                pnlBrands.Width += SystemInformation.VerticalScrollBarWidth
            End If

        End If

        Globals.HidePleaseWait(Me)

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods2 -> btnBack_MouseDown ")
        Me.Close()
    End Sub

#Region "pnlBrands"

    Dim pnlBrandsmouseDownPoint As Point
    Dim pnlBrandsIsMouseDown As Boolean = False

    Private Sub pnlBrands_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlBrands.MouseDown
        pnlBrandsIsMouseDown = True
        pnlBrandsmouseDownPoint = Cursor.Position
        IgnoreAction = False
    End Sub

    Private Sub pnlBrands_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlBrands.MouseMove
        If pnlBrandsIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlBrandsmouseDownPoint.X, Cursor.Position.Y - pnlBrandsmouseDownPoint.Y)
            If ((pnlBrandsmouseDownPoint.X <> Cursor.Position.X) Or (pnlBrandsmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlBrands.AutoScrollPosition
                pnlBrands.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlBrandsmouseDownPoint = Cursor.Position

                IgnoreAction = True

            End If

        End If
    End Sub

    Private Sub pnlBrands_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlBrands.MouseUp
        pnlBrandsIsMouseDown = False
    End Sub

#End Region



End Class