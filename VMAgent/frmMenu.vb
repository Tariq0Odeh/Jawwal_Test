Public Class frmMenu

    'Public objCoinCashRecycler As VinderSDK.CoinCashRecycler
    Dim objConfigParams As New ConfigParams

    Private Sub LoadPanelBackGround()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        ExceptionLogger.LogInfo("frmMenu_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.Home_Edit
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmMenu_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Dim counter = 1

            While (True)
                counter = counter + 1
                Try
                    Threading.Thread.Sleep(500)
                    LoadPanelBackGround()
                    Exit While
                Catch ex2 As Exception
                    ExceptionLogger.LogInfo("Failed " & counter & " times to load Image Background for pnlWA in frmMenu_Load")
                    ExceptionLogger.LogException(ex2)

                End Try
            End While

        End Try

        ExceptionLogger.LogInfo("frmMenu -> frmMenu_Load ")
        objConfigParams = ConfigParams.GetConfigParams()

    End Sub

    Private Sub btnTopUp_Click(sender As Object, e As EventArgs) Handles btnTopUp.Click
        ExceptionLogger.LogInfo("frmMenu -> btnTopUp_Click ")

        CurrentTransaction = New Transaction
        CurrentTransaction.TransactionReference = objConfigParams.TerminalId & Date.Now.ToString("yyMMddHHmmss")
        CurrentTransaction.TransactionType = "TopUp"
        CurrentTransaction.TerminalId = objConfigParams.TerminalId
        CurrentTransaction.TransactionDateTime = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        CurrentTransaction.TransactionStatus = "Inprogress"

        Dim obj As New frmTopUp
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub

    Private Sub btnJawwalBillPayment_Click(sender As Object, e As EventArgs) Handles btnJawwalBillPayment.Click
        ExceptionLogger.LogInfo("frmMenu -> btnJawwalBillPayment_Click ")

        CurrentTransaction = New Transaction
        CurrentTransaction.TransactionReference = objConfigParams.TerminalId & Date.Now.ToString("yyMMddHHmmss")
        CurrentTransaction.TransactionType = "JawwalBillPayment"
        CurrentTransaction.TerminalId = objConfigParams.TerminalId
        CurrentTransaction.TransactionDateTime = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        CurrentTransaction.TransactionStatus = "Inprogress"

        Dim obj As New frmJawwalBillPayment
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub

    Private Sub btnPaltelBillPayment_Click(sender As Object, e As EventArgs) Handles btnPaltelBillPayment.Click
        ExceptionLogger.LogInfo("frmMenu -> btnPaltelBillPayment_Click ")


        CurrentTransaction = New Transaction
        CurrentTransaction.TransactionReference = objConfigParams.TerminalId & Date.Now.ToString("yyMMddHHmmss")
        CurrentTransaction.TransactionType = "PaltelBillPayment"
        CurrentTransaction.TerminalId = objConfigParams.TerminalId
        CurrentTransaction.TransactionDateTime = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        CurrentTransaction.TransactionStatus = "Inprogress"

        Dim obj As New frmPaltelBillPayment
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub

    Private Sub btnBundles_Click(sender As Object, e As EventArgs) Handles btnBundles.Click
        ExceptionLogger.LogInfo("frmMenu -> btnBundles_Click ")


        CurrentTransaction = New Transaction
        CurrentTransaction.TransactionReference = objConfigParams.TerminalId & Date.Now.ToString("yyMMddHHmmss")
        CurrentTransaction.TransactionType = "Bundles"
        CurrentTransaction.TerminalId = objConfigParams.TerminalId
        CurrentTransaction.TransactionDateTime = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        CurrentTransaction.TransactionStatus = "Inprogress"

        Dim obj As New frmBundles
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub

    Private Sub btnDigitalGoods_Click(sender As Object, e As EventArgs) Handles btnDigitalGoods.Click
        ExceptionLogger.LogInfo("frmMenu -> btnDigitalGoods_Click ")


        CurrentTransaction = New Transaction
        CurrentTransaction.TransactionReference = objConfigParams.TerminalId & Date.Now.ToString("yyMMddHHmmss")
        CurrentTransaction.TransactionType = "DigitalGoods"
        CurrentTransaction.TerminalId = objConfigParams.TerminalId
        CurrentTransaction.TransactionDateTime = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        CurrentTransaction.TransactionStatus = "Inprogress"

        Dim obj As New frmDigitalGoods
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub



    Private Sub btnPLUS_Click(sender As Object, e As EventArgs) Handles btnPLUS.Click
        ExceptionLogger.LogInfo("frmMenu -> btnPLUS_Click")
        Dim obj As New frmPlus
        CurrentServiceForm = obj
        obj.ShowDialog()
        CurrentServiceForm = Nothing

    End Sub



#Region "Coin Back"

    Dim OfflinAmount As Decimal = 0
    Dim isRetunring = False
    Private messagesLock As New Object
    Private Sub btnCoinBack_Click(sender As Object, e As EventArgs) Handles btnCoinBack.Click
        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click trying to show waiting and return money")
        SyncLock messagesLock
            If isRetunring = False Then
                isRetunring = True

                ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click Show Please Wait")
                Globals.ShowPleaseWait(Me)

                OfflinAmount = 0

                If RecyclersOpened = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOnline Then
                    Try
                        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> AddHandler")
                        AddHandler objCoinCashRecycler.OnCoinCashDeposit, AddressOf OnCoinCash

                        objCoinCashRecycler.StartAcceptingCoinCash(False, True)

                        Threading.Thread.Sleep(30000)

                        Dim TotalInputAmount As Decimal = objCoinCashRecycler.StopAcceptingMoney()
                        OfflinAmount = TotalInputAmount.ToString

                        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> OfflinAmount > 0 ? " & (OfflinAmount > 0).ToString())
                        If OfflinAmount > 0 Then
                            ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> Begining Returning Money")
                            objCoinCashRecycler.ReturnCashAndCoins(False, True, OfflinAmount)
                            ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click ->  Returning Money Ended")
                        End If

                        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> RemoveHandler")
                        RemoveHandler objCoinCashRecycler.OnCoinCashDeposit, AddressOf OnCoinCash
                    Catch ex As Exception
                        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> Exception while trying to return money")
                        ExceptionLogger.LogException(ex)
                    End Try
                End If
                Try

                    ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click -> trying to hide please wait")

                    Globals.HidePleaseWait(Me)
                Catch ex As Exception
                    ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click Exception while hiding please wait")
                    ExceptionLogger.LogException(ex)
                End Try
                ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click ending show waiting and return money")
                    isRetunring = False
                End If
        End SyncLock
        ExceptionLogger.LogInfo("frmMenu -> btnCoinBack_Click End")
    End Sub

    Private Sub OnCoinCash(ByVal Amount As Decimal)
        OfflinAmount += Amount
    End Sub

#End Region

#Region "PleaseWait"

    Dim PW As PleaseWaitUntilFinish



    Private Sub frmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ExceptionLogger.LogInfo("***frmMenu is trying to close...")
        If (Me.Owner IsNot Nothing) Then

            Select Case CType(Me.Owner, frmMain).TerminalLastStatus
                Case "ONLINE"
                    ExceptionLogger.LogInfo("***frmMain is trying to close with status Online...")
                    e.Cancel = True
                Case "OFFLINE"
                    ExceptionLogger.LogInfo("***frmMain is trying to close with status Offline...")
                Case ""
                    ExceptionLogger.LogInfo("***frmMain is trying to close with status ''...")

            End Select


        End If

    End Sub

#End Region

End Class