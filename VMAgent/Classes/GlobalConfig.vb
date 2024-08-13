Module GlobalConfig

    Public Declare Auto Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Integer) As Short
    Public TimeOutCounter As Integer = 0
    Public objTimeExtension As frmTimeExtension = Nothing

    Public objCoinCashRecycler As VinderSDK.CoinCashRecycler
    Public RecyclersOpened As VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit = VinderSDK.CoinCashRecycler.RecylcersStatusAfterInit.BothOffline
    Public objCardDispnser As CardDispenser
    Public CardDispnserOpened As Boolean = False

    Public CurrentServiceForm As Form = Nothing
    Public CurrentBuildVersion As String = ""

    '------------------------------------------------------------------------------------------------

    Public CurrentTransaction As New Transaction

End Module
