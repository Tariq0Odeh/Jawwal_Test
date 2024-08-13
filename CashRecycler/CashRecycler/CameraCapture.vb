Public Class CameraCapture

    Private Declare Function capCreateCaptureWindow Lib "avicap32.dll" Alias "capCreateCaptureWindowA" (ByVal WindowName As String, ByVal Style As Integer, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Parent As Integer, ByVal ID As Integer) As Integer
    Private Declare Function DestroyWindow Lib "user32" (ByVal hWnd As Integer) As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Declare Function SendMessageAsString Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WS_CHILD As Integer = &H40000000
    Private Const WM_USER = &H400
    Private Const WM_CAP_START = WM_USER
    Private Const WM_CAP_FILE_SAVEDIB As Long = WM_CAP_START + 25

    Dim CamHwnd As Long

    Dim PIC As New PictureBox

    Sub New()
        CamHwnd = capCreateCaptureWindow("CamWnd", WS_CHILD, 0, 0, 320, 240, PIC.Handle.ToInt32, 0)
    End Sub

    Public Function Capture() As Image

        Dim CustomerPicture As Image = Nothing

        Try

            If SendMessage(CamHwnd, WM_CAP_DRIVER_CONNECT, 0, 0) Then
                SendMessage(CamHwnd, WM_CAP_EDIT_COPY, 0, 0)
                SendMessage(CamHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)

                Dim data As IDataObject

                data = Clipboard.GetDataObject()
                If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                    CustomerPicture = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
                    Clipboard.SetDataObject("N/A")
                Else
                    CustomerPicture = Nothing
                End If
            Else
                CustomerPicture = Nothing
            End If

        Catch ex As Exception
            CustomerPicture = Nothing
        End Try

        Return CustomerPicture

    End Function

End Class
