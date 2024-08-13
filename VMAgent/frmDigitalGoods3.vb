Imports Newtonsoft.Json.Linq

Public Class frmDigitalGoods3

    Public MobileNumber As String = ""
    Public objBrand As New Brand
    Public IgnoreAction As Boolean = False

    Private Sub frmDigitalGoods3_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExceptionLogger.LogInfo("frmDigitalGoods3 -> frmDigitalGoods3_Load ")
        Globals.ShowPleaseWait(Me)

        Dim Denominations As String = APIs.GetDenominations(MobileNumber.Substring(1), objBrand.code)

        Dim jsonObj As JObject = JObject.Parse(Denominations)
        If jsonObj("code") = "0" Then

            Dim ALDenominations As JArray = jsonObj("data")
            For I As Integer = 0 To ALDenominations.Count - 1

                Dim objDenomination As New Denomination

                Dim DenominationObj As New JObject
                DenominationObj = ALDenominations(I)

                objDenomination.code = DenominationObj("code").ToString()
                objDenomination.name = DenominationObj("name").ToString()
                objDenomination.description = DenominationObj("description").ToString()
                objDenomination.voucherValue = DenominationObj("voucherValue").ToString()
                objDenomination.imagePath = DenominationObj("imagePath").ToString()
                objDenomination.brandCode = DenominationObj("brandCode").ToString()
                objDenomination.priceCurrency = DenominationObj("priceCurrency").ToString()
                objDenomination.voucherCurrency = DenominationObj("voucherCurrency").ToString()
                objDenomination.endCustomerPriceWithVATLIS = DenominationObj("endCustomerPriceWithVATLIS").ToString()

                Dim obj As New ctlDenomination
                obj.Dock = DockStyle.Left
                obj.MobileNumber = MobileNumber
                obj.objBrand = objBrand
                obj.objDenomination = objDenomination
                Try
                    obj.picDenominationLogo.Load(objDenomination.imagePath)
                Catch ex As Exception
                    ExceptionLogger.LogException(ex)
                End Try
                obj.txtName.Text = objDenomination.name
                obj.txtendCustomerPriceWithVATLIS.Text = objDenomination.endCustomerPriceWithVATLIS
                obj.TheOwnerForm = Me.Owner
                obj.MyParent = Me
                pnlDenominations.Controls.Add(obj)

                AddHandler obj.MouseDown, AddressOf pnlDenominations_MouseDown
                AddHandler obj.MouseMove, AddressOf pnlDenominations_MouseMove
                AddHandler obj.MouseUp, AddressOf pnlDenominations_MouseUp

                AddHandler obj.picDenominationLogo.MouseDown, AddressOf pnlDenominations_MouseDown
                AddHandler obj.picDenominationLogo.MouseMove, AddressOf pnlDenominations_MouseMove
                AddHandler obj.picDenominationLogo.MouseUp, AddressOf pnlDenominations_MouseUp

                AddHandler obj.txtendCustomerPriceWithVATLIS.MouseDown, AddressOf pnlDenominations_MouseDown
                AddHandler obj.txtendCustomerPriceWithVATLIS.MouseMove, AddressOf pnlDenominations_MouseMove
                AddHandler obj.txtendCustomerPriceWithVATLIS.MouseUp, AddressOf pnlDenominations_MouseUp

                AddHandler obj.txtName.MouseDown, AddressOf pnlDenominations_MouseDown
                AddHandler obj.txtName.MouseMove, AddressOf pnlDenominations_MouseMove
                AddHandler obj.txtName.MouseUp, AddressOf pnlDenominations_MouseUp

            Next

            If pnlDenominations.HorizontalScroll.Visible = False Then
                For I As Integer = 0 To pnlDenominations.Controls.Count - 1
                    If pnlDenominations.Controls(I).GetType = GetType(ctlDenomination) Then
                        CType(pnlDenominations.Controls(I), ctlDenomination).Dock = DockStyle.Right
                    End If
                Next
            Else
                pnlDenominations.Height += SystemInformation.HorizontalScrollBarHeight
            End If

        End If

        AddHandler txtDescription.MouseDown, AddressOf pnlDescription_MouseDown
        AddHandler txtDescription.MouseMove, AddressOf pnlDescription_MouseMove
        AddHandler txtDescription.MouseUp, AddressOf pnlDescription_MouseUp

        If pnlDescription.VerticalScroll.Visible = True Then
            pnlDescription.Width += SystemInformation.VerticalScrollBarWidth
        End If

        Globals.HidePleaseWait(Me)

    End Sub

    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        ExceptionLogger.LogInfo("frmDigitalGoods3 -> btnBack_MouseDown ")
        Me.Close()
    End Sub

#Region "pnlDescription"

    Dim pnlDescriptionmouseDownPoint As Point
    Dim pnlDescriptionIsMouseDown As Boolean = False

    Private Sub pnlDescription_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlDescription.MouseDown
        pnlDescriptionIsMouseDown = True
        pnlDescriptionmouseDownPoint = Cursor.Position
    End Sub

    Private Sub pnlDescription_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlDescription.MouseMove
        If pnlDescriptionIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlDescriptionmouseDownPoint.X, Cursor.Position.Y - pnlDescriptionmouseDownPoint.Y)
            If ((pnlDescriptionmouseDownPoint.X <> Cursor.Position.X) Or (pnlDescriptionmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlDescription.AutoScrollPosition
                pnlDescription.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlDescriptionmouseDownPoint = Cursor.Position

            End If

        End If
    End Sub

    Private Sub pnlDescription_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlDescription.MouseUp
        pnlDescriptionIsMouseDown = False
    End Sub

#End Region

#Region "pnlDenominations"

    Dim pnlDenominationsmouseDownPoint As Point
    Dim pnlDenominationsIsMouseDown As Boolean = False

    Private Sub pnlDenominations_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlDenominations.MouseDown
        pnlDenominationsIsMouseDown = True
        pnlDenominationsmouseDownPoint = Cursor.Position
        IgnoreAction = False
    End Sub

    Private Sub pnlDenominations_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlDenominations.MouseMove
        If pnlDenominationsIsMouseDown = True Then

            Dim pointDifference As Point = New Point(Cursor.Position.X - pnlDenominationsmouseDownPoint.X, Cursor.Position.Y - pnlDenominationsmouseDownPoint.Y)
            If ((pnlDenominationsmouseDownPoint.X <> Cursor.Position.X) Or (pnlDenominationsmouseDownPoint.Y <> Cursor.Position.Y)) Then

                Dim currAutoS As Point = pnlDenominations.AutoScrollPosition
                pnlDenominations.AutoScrollPosition = New Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y)
                pnlDenominationsmouseDownPoint = Cursor.Position

                IgnoreAction = True

            End If

        End If
    End Sub

    Private Sub pnlDenominations_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlDenominations.MouseUp
        pnlDenominationsIsMouseDown = False
    End Sub

#End Region



End Class