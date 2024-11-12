Imports Newtonsoft.Json.Linq

Public Class frmBundles4

    Public MobileNumber As String = ""
    Public BundleType As String = ""
    Public RecommendedBundles As String = ""
    Public IgnoreAction As Boolean = False

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBundles4))
        ExceptionLogger.LogInfo("frmBundles4_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmBundles4
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

        Me.picNoNoneRenewable.Image = Global.VMAgent.My.Resources.Resources.picNoNoneRenewable
        Me.picNoNoneRenewable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage

        Me.picNoRenewable.Image = Global.VMAgent.My.Resources.Resources.picNoRenewable
        Me.picNoRenewable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage


    End Sub

    Private Sub frmBundles4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmBundles4_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmBundles4_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load")
        If BundleType = "3G" Or BundleType = "Minutes" Then
            ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> 3G or Minutes")
            If RecommendedBundles.Contains("code") = True Then
                ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> 3G or Minutes - Code")
                Dim jsonObj As JObject = JObject.Parse(RecommendedBundles)
                If jsonObj("code") = "0" Then
                    ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> 3G or Minutes - Code = '0'")
                    Dim dataObj As JObject = jsonObj("data")

                    Dim ALrenewedBundles As JArray = dataObj("renewedBundles")
                    For I As Integer = 0 To ALrenewedBundles.Count - 1

                        Dim objBundle As New Bundle

                        Dim BundleObj As New JObject
                        BundleObj = ALrenewedBundles(I)
                        objBundle.productId = BundleObj("productId").ToString()
                        objBundle.productName = BundleObj("productName").ToString()
                        objBundle.productDescription = BundleObj("productDescription").ToString()
                        objBundle.appSize = BundleObj("appSize").ToString()
                        objBundle.appPrice = BundleObj("appPrice").ToString()
                        objBundle.appType = BundleObj("appType").ToString()
                        objBundle.minutesSize = BundleObj("minutesSize").ToString()
                        objBundle.smsSize = BundleObj("smsSize").ToString()
                        objBundle.productNameE = BundleObj("productNameE").ToString()
                        objBundle.descriptionE = BundleObj("descriptionE").ToString()

                        Dim obj As New ctlBundle
                        obj.Dock = DockStyle.Left
                        obj.MobileNumber = MobileNumber
                        obj.BundleType = BundleType
                        obj.objBundle = objBundle
                        obj.FillData()
                        obj.TheOwnerForm = Me.Owner
                        obj.MyParent = Me
                        pnlRenewed.Controls.Add(obj)

                        AddHandler obj.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.btnDetailsAndSubscribe.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.btnDetailsAndSubscribe.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.btnDetailsAndSubscribe.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnl3G.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnl3G.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnl3G.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnl3GMins.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnl3GMins.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnl3GMins.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnlMins.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnlMins.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnlMins.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GOnlySize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GOnlySize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GOnlySize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GSize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GSize2.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GSize2.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GSize2.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtappPrice.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtappPrice.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtappPrice.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtappType.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtappType.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtappType.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize2.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize2.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize2.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize3.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize3.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize3.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtMinutesSizeZainJordan.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtMinutesSizeZainJordan.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtMinutesSizeZainJordan.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtsmsSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtsmsSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtsmsSize.MouseUp, AddressOf pnlRenewed_MouseUp

                    Next

                    If ALrenewedBundles.Count > 0 Then
                        picNoRenewable.Visible = False
                    Else
                        picNoRenewable.Visible = True
                    End If

                    If pnlRenewed.HorizontalScroll.Visible = False Then
                        For I As Integer = 0 To pnlRenewed.Controls.Count - 1
                            If pnlRenewed.Controls(I).GetType = GetType(ctlBundle) Then
                                CType(pnlRenewed.Controls(I), ctlBundle).Dock = DockStyle.Right
                            End If
                        Next
                    Else
                        pnlRenewed.Height += SystemInformation.HorizontalScrollBarHeight
                    End If

                    Dim ALnonRenewedBundles As JArray = dataObj("nonRenewedBundles")
                    For I As Integer = 0 To ALnonRenewedBundles.Count - 1

                        Dim objBundle As New Bundle

                        Dim BundleObj As New JObject
                        BundleObj = ALnonRenewedBundles(I)
                        objBundle.productId = BundleObj("productId").ToString()
                        objBundle.productName = BundleObj("productName").ToString()
                        objBundle.productDescription = BundleObj("productDescription").ToString()
                        objBundle.appSize = BundleObj("appSize").ToString()
                        objBundle.appPrice = BundleObj("appPrice").ToString()
                        objBundle.appType = BundleObj("appType").ToString()
                        objBundle.minutesSize = BundleObj("minutesSize").ToString()
                        objBundle.smsSize = BundleObj("smsSize").ToString()
                        objBundle.productNameE = BundleObj("productNameE").ToString()
                        objBundle.descriptionE = BundleObj("descriptionE").ToString()

                        Dim obj As New ctlBundle
                        obj.Dock = DockStyle.Left
                        obj.MobileNumber = MobileNumber
                        obj.BundleType = BundleType
                        obj.objBundle = objBundle
                        obj.FillData()
                        obj.TheOwnerForm = Me.Owner
                        obj.MyParent = Me
                        pnlNonRenewed.Controls.Add(obj)

                        AddHandler obj.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.btnDetailsAndSubscribe.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.btnDetailsAndSubscribe.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.btnDetailsAndSubscribe.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.pnl3G.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.pnl3G.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.pnl3G.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.pnl3GMins.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.pnl3GMins.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.pnl3GMins.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.pnlMins.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.pnlMins.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.pnlMins.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txt3GOnlySize.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txt3GOnlySize.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txt3GOnlySize.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txt3GSize.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txt3GSize.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txt3GSize.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txt3GSize2.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txt3GSize2.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txt3GSize2.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtappPrice.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtappPrice.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtappPrice.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtappType.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtappType.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtappType.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtminutesSize.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtminutesSize.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtminutesSize.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtminutesSize2.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtminutesSize2.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtminutesSize2.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtminutesSize3.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtminutesSize3.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtminutesSize3.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtMinutesSizeZainJordan.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtMinutesSizeZainJordan.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtMinutesSizeZainJordan.MouseUp, AddressOf pnlNonRenewed_MouseUp

                        AddHandler obj.txtsmsSize.MouseDown, AddressOf pnlNonRenewed_MouseDown
                        AddHandler obj.txtsmsSize.MouseMove, AddressOf pnlNonRenewed_MouseMove
                        AddHandler obj.txtsmsSize.MouseUp, AddressOf pnlNonRenewed_MouseUp

                    Next

                    If ALnonRenewedBundles.Count > 0 Then
                        picNoNoneRenewable.Visible = False
                    Else
                        picNoNoneRenewable.Visible = True
                    End If

                    If pnlNonRenewed.HorizontalScroll.Visible = False Then
                        For I As Integer = 0 To pnlNonRenewed.Controls.Count - 1
                            If pnlNonRenewed.Controls(I).GetType = GetType(ctlBundle) Then
                                CType(pnlNonRenewed.Controls(I), ctlBundle).Dock = DockStyle.Right
                            End If
                        Next
                    Else
                        pnlNonRenewed.Height += SystemInformation.HorizontalScrollBarHeight
                    End If

                End If

            Else
                ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> 3G or Minutes But doesn't contain Code")

                picNoRenewable.Visible = True
                picNoNoneRenewable.Visible = True

            End If

        Else
            ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> NOT (3G or Minutes )")
            If RecommendedBundles.Contains("code") = True Then
                ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> NOT (3G or Minutes ) -> code")
                Dim jsonObj As JObject = JObject.Parse(RecommendedBundles)
                If jsonObj("code") = "0" Then

                    Dim ALBundles As JArray = jsonObj("data")
                    For I As Integer = 0 To ALBundles.Count - 1

                        Dim objBundle As New Bundle

                        Dim BundleObj As New JObject
                        BundleObj = ALBundles(I)
                        objBundle.productId = BundleObj("productId").ToString()
                        objBundle.productName = BundleObj("productName").ToString()
                        objBundle.productDescription = BundleObj("productDescription").ToString()
                        objBundle.appSize = BundleObj("appSize").ToString()
                        objBundle.appPrice = BundleObj("appPrice").ToString()
                        objBundle.appType = BundleObj("appType").ToString()
                        objBundle.minutesSize = BundleObj("minutesSize").ToString()
                        objBundle.smsSize = BundleObj("smsSize").ToString()
                        objBundle.productNameE = BundleObj("productNameE").ToString()
                        objBundle.descriptionE = BundleObj("descriptionE").ToString()

                        Dim obj As New ctlBundle
                        obj.Dock = DockStyle.Left
                        obj.MobileNumber = MobileNumber
                        obj.BundleType = BundleType
                        obj.objBundle = objBundle
                        obj.FillData()
                        obj.TheOwnerForm = Me.Owner
                        obj.MyParent = Me
                        pnlRenewed.Controls.Add(obj)

                        AddHandler obj.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.btnDetailsAndSubscribe.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.btnDetailsAndSubscribe.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.btnDetailsAndSubscribe.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnl3G.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnl3G.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnl3G.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnl3GMins.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnl3GMins.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnl3GMins.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.pnlMins.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.pnlMins.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.pnlMins.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GOnlySize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GOnlySize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GOnlySize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GSize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txt3GSize2.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txt3GSize2.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txt3GSize2.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtappPrice.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtappPrice.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtappPrice.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtappType.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtappType.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtappType.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize2.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize2.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize2.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtminutesSize3.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtminutesSize3.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtminutesSize3.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtMinutesSizeZainJordan.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtMinutesSizeZainJordan.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtMinutesSizeZainJordan.MouseUp, AddressOf pnlRenewed_MouseUp

                        AddHandler obj.txtsmsSize.MouseDown, AddressOf pnlRenewed_MouseDown
                        AddHandler obj.txtsmsSize.MouseMove, AddressOf pnlRenewed_MouseMove
                        AddHandler obj.txtsmsSize.MouseUp, AddressOf pnlRenewed_MouseUp

                    Next

                    If ALBundles.Count > 0 Then
                        picNoRenewable.Visible = False
                    Else
                        picNoRenewable.Visible = True
                    End If

                    If pnlRenewed.HorizontalScroll.Visible = False Then
                        For I As Integer = 0 To pnlRenewed.Controls.Count - 1
                            If pnlRenewed.Controls(I).GetType = GetType(ctlBundle) Then
                                CType(pnlRenewed.Controls(I), ctlBundle).Dock = DockStyle.Right
                            End If
                        Next
                    Else
                        pnlRenewed.Height += SystemInformation.HorizontalScrollBarHeight
                    End If

                End If

            Else
                ExceptionLogger.LogInfo("frmBundles4 -> frmBundles4_Load -> NOT (3G or Minutes ) -> dons't contian code")
                picNoRenewable.Visible = True
                picNoNoneRenewable.Visible = True

            End If

        End If

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmBundles4 -> btnBack_MouseDown")
        Me.Close()
    End Sub

#Region "pnlRenewed"

    Dim pnlRenewedmouseDownPoint As Point
    Dim pnlRenewedIsMouseDown As Boolean = False

    Private Sub pnlRenewed_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlRenewed.MouseDown
        pnlRenewedIsMouseDown = True
        pnlRenewedmouseDownPoint = Cursor.Position
        IgnoreAction = False
    End Sub

    Private Sub pnlRenewed_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlRenewed.MouseMove
        If pnlRenewedIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlRenewedmouseDownPoint.X, Cursor.Position.Y - pnlRenewedmouseDownPoint.Y)
            If ((pnlRenewedmouseDownPoint.X <> Cursor.Position.X) Or (pnlRenewedmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlRenewed.AutoScrollPosition
                pnlRenewed.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlRenewedmouseDownPoint = Cursor.Position

                IgnoreAction = True

            End If

        End If
    End Sub

    Private Sub pnlRenewed_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlRenewed.MouseUp
        pnlRenewedIsMouseDown = False
    End Sub

#End Region

#Region "pnlNonRenewed"

    Dim pnlNonRenewedmouseDownPoint As Point
    Dim pnlNonRenewedIsMouseDown As Boolean = False

    Private Sub pnlNonRenewed_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlNonRenewed.MouseDown
        pnlNonRenewedIsMouseDown = True
        pnlNonRenewedmouseDownPoint = Cursor.Position
        IgnoreAction = False
    End Sub

    Private Sub pnlNonRenewed_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlNonRenewed.MouseMove
        If pnlNonRenewedIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlNonRenewedmouseDownPoint.X, Cursor.Position.Y - pnlNonRenewedmouseDownPoint.Y)
            If ((pnlNonRenewedmouseDownPoint.X <> Cursor.Position.X) Or (pnlNonRenewedmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlNonRenewed.AutoScrollPosition
                pnlNonRenewed.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlNonRenewedmouseDownPoint = Cursor.Position

                IgnoreAction = True

            End If

        End If
    End Sub

    Private Sub pnlNonRenewed_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlNonRenewed.MouseUp
        pnlNonRenewedIsMouseDown = False
    End Sub

#End Region

End Class