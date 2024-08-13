Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class Camera
    Public VideoSource As Integer 'The camera ID
    Private PreHandle As Int32 'The preview control handle (picturebox usually)
    Private Handle As Integer 'The create preview window handle
    Private lwndC As Integer
    Public Running As Boolean
    Public Recording As Boolean
    Public PreviewFrameRate As Integer
    Public OutputHeight As Integer
    Public OutputWidth As Integer
    Public CapParams As CAPTUREPARMS
    Public CapturePathAndFileName As String
    Public AlwaysOverwrite As Boolean

#Region "Api's and constants"
    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const SWP_NOMOVE As Short = &H2S
    Private Const SWP_NOZORDER As Short = &H4S
    Private Const SWP_NOSIZE As Short = 1
    Private Const HWND_BOTTOM As Short = 1
    Private Const WM_USER As Short = &H400S
    Private Const WM_CAP_START As Long = WM_USER
    Private Const WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2
    Private Const WM_CAP_SET_CALLBACK_STATUS = WM_CAP_START + 3
    Private Const WM_CAP_SET_CALLBACK_YIELD = WM_CAP_START + 4
    Private Const WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5
    Private Const WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6
    Private Const WM_CAP_FILE_SAVEAS As Integer = WM_CAP_START + 23
    Private Const WM_CAP_SET_SCALE As Integer = WM_CAP_START + 53
    Private Const WM_CAP_SINGLE_FRAME_OPEN As Integer = WM_CAP_START + 70
    Private Const WM_CAP_SINGLE_FRAME_CLOSE As Integer = WM_CAP_START + 71
    Private Const WM_CAP_SINGLE_FRAME As Integer = WM_CAP_START + 72
    Private Const WM_CAP_GRAB_FRAME As Integer = WM_CAP_START + 60
    Private Const WM_CAP_DLG_VIDEOSOURCE As Integer = WM_CAP_START + 42
    Private Const WM_CAP_SET_OVERLAY As Integer = WM_CAP_START + 51
    Private Const WM_CAP_SET_CALLBACK_CAPCONTROL As Integer = WM_CAP_START + 85
    Private Const WM_CAP_GRAB_FRAME_NOSTOP As Integer = WM_CAP_START + 61
    Private Const WM_CAP_FILE_SET_CAPTURE_FILE As Integer = WM_CAP_START + 20
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP_START + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP_START + 11
    Private Const WM_CAP_SET_VIDEOFORMAT As Integer = WM_CAP_START + 45
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_CAP_START + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP_START + 52
    Private Const WM_CAP_GET_FRAME As Long = WM_CAP_START + 60
    Private Const WM_CAP_EDIT_COPY As Long = WM_CAP_START + 30
    Private Const WM_CAP_STOP As Long = WM_CAP_START + 68
    Private Const WM_CAP_SEQUENCE As Long = WM_CAP_START + 62
    Private Const WM_CAP_SET_SEQUENCE_SETUP As Long = WM_CAP_START + 64
    Private Const WM_CAP_FILE_SET_CAPTURE_FILEA As Long = WM_CAP_START + 20
    Private Const WM_CAP_SAVEDIB As Integer = WM_CAP_START + 25
    Private Const WM_CAP_DLG_VIDEOCOMPRESSION As Integer = WM_CAP_START + 46
    Private Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP_START + 41
    Private Const WM_CAP_DLG_VIDEODISPLAY As Integer = WM_CAP_START + 43
    Private Const WM_CAP_GET_VIDEOFORMAT As Integer = WM_CAP_START + 44

#Region "Callback message IDs"
    Private Const IDS_CAP_BEGIN As Integer = 300 '/* "Capture Start" */
    Private Const IDS_CAP_END As Integer = 301 '/* "Capture End" */
    Private Const IDS_CAP_INFO As Integer = 401 '/* "%s" */
    Private Const IDS_CAP_OUTOFMEM As Integer = 402 '/* "Out of memory" */
    Private Const IDS_CAP_FILEEXISTS As Integer = 403 '/* "File '%s' exists -- overwrite it?" */
    Private Const IDS_CAP_ERRORPALOPEN As Integer = 404 '/* "Error opening palette '%s'" */
    Private Const IDS_CAP_ERRORPALSAVE As Integer = 405 '/* "Error saving palette '%s'" */
    Private Const IDS_CAP_ERRORDIBSAVE As Integer = 406 '/* "Error saving frame '%s'" */
    Private Const IDS_CAP_DEFAVIEXT As Integer = 407 '/* "avi" */
    Private Const IDS_CAP_DEFPALEXT As Integer = 408 '/* "pal" */
    Private Const IDS_CAP_CANTOPEN As Integer = 409 '/* "Cannot open '%s'" */
    Private Const IDS_CAP_SEQ_MSGSTART As Integer = 410 '/* "Select OK to start capture\nof video sequence\nto %s." */
    Private Const IDS_CAP_SEQ_MSGSTOP As Integer = 411 '/* "Hit ESCAPE or click to end capture" */
    Private Const IDS_CAP_VIDEDITERR As Integer = 412 '/* "An error occurred while trying to run VidEdit." */
    Private Const IDS_CAP_READONLYFILE As Integer = 413 '/* "The file '%s' is a read-only file." */
    Private Const IDS_CAP_WRITEERROR As Integer = 414 '/* "Unable to write to file '%s'.\nDisk may be full." */
    Private Const IDS_CAP_NODISKSPACE As Integer = 415 '/* "There is no space to create a capture file on the specified device." */
    Private Const IDS_CAP_SETFILESIZE As Integer = 416 '/* "Set File Size" */
    Private Const IDS_CAP_SAVEASPERCENT As Integer = 417 '/* "SaveAs: %2ld%%  Hit Escape to abort." */
    Private Const IDS_CAP_DRIVER_ERROR As Integer = 418 '/* Driver specific error message */
    Private Const IDS_CAP_WAVE_OPEN_ERROR As Integer = 419 '/* "Error: Cannot open the wave input device.\nCheck sample size, frequency, and channels." */
    Private Const IDS_CAP_WAVE_ALLOC_ERROR As Integer = 420 '/* "Error: Out of memory for wave buffers." */
    Private Const IDS_CAP_WAVE_PREPARE_ERROR As Integer = 421 '/* "Error: Cannot prepare wave buffers." */
    Private Const IDS_CAP_WAVE_ADD_ERROR As Integer = 422 '/* "Error: Cannot add wave buffers." */
    Private Const IDS_CAP_WAVE_SIZE_ERROR As Integer = 423 '/* "Error: Bad wave size." */
    Private Const IDS_CAP_VIDEO_OPEN_ERROR As Integer = 424 '/* "Error: Cannot open the video input device." */
    Private Const IDS_CAP_VIDEO_ALLOC_ERROR As Integer = 425 '/* "Error: Out of memory for video buffers." */
    Private Const IDS_CAP_VIDEO_PREPARE_ERROR As Integer = 426 '/* "Error: Cannot prepare video buffers." */
    Private Const IDS_CAP_VIDEO_ADD_ERROR As Integer = 427 '/* "Error: Cannot add video buffers." */
    Private Const IDS_CAP_VIDEO_SIZE_ERROR As Integer = 428 '/* "Error: Bad video size." */
    Private Const IDS_CAP_FILE_OPEN_ERROR As Integer = 429 '/* "Error: Cannot open capture file." */
    Private Const IDS_CAP_FILE_WRITE_ERROR As Integer = 430 '/* "Error: Cannot write to capture file.  Disk may be full." */
    Private Const IDS_CAP_RECORDING_ERROR As Integer = 431 '/* "Error: Cannot write to capture file.  Data rate too high or disk full." */
    Private Const IDS_CAP_RECORDING_ERROR2 As Integer = 432 '/* "Error while recording" */
    Private Const IDS_CAP_AVI_INIT_ERROR As Integer = 433 '/* "Error: Unable to initialize for capture." */
    Private Const IDS_CAP_NO_FRAME_CAP_ERROR As Integer = 434 '/* "Warning: No frames captured.\nConfirm that vertical sync interrupts\nare configured and enabled." */
    Private Const IDS_CAP_NO_PALETTE_WARN As Integer = 435 '/* "Warning: Using default palette." */
    Private Const IDS_CAP_MCI_CONTROL_ERROR As Integer = 436 '/* "Error: Unable to access MCI device." */
    Private Const IDS_CAP_MCI_CANT_STEP_ERROR As Integer = 437 '/* "Error: Unable to step MCI device." */
    Private Const IDS_CAP_NO_AUDIO_CAP_ERROR As Integer = 438 '/* "Error: No audio data captured.\nCheck audio card settings." */
    Private Const IDS_CAP_AVI_DRAWDIB_ERROR As Integer = 439 '/* "Error: Unable to draw this data format." */
    Private Const IDS_CAP_COMPRESSOR_ERROR As Integer = 440 '/* "Error: Unable to initialize compressor." */
    Private Const IDS_CAP_AUDIO_DROP_ERROR As Integer = 441 '/* "Error: Audio data was lost during capture, reduce capture rate." */
    Private Const IDS_CAP_STAT_LIVE_MODE As Integer = 500 '/* "Live window" */
    Private Const IDS_CAP_STAT_OVERLAY_MODE As Integer = 501 '/* "Overlay window" */
    Private Const IDS_CAP_STAT_CAP_INIT As Integer = 502 '/* "Setting up for capture - Please wait" */
    Private Const IDS_CAP_STAT_CAP_FINI As Integer = 503 '/* "Finished capture, now writing frame %ld" */
    Private Const IDS_CAP_STAT_PALETTE_BUILD As Integer = 504 '/* "Building palette map" */
    Private Const IDS_CAP_STAT_OPTPAL_BUILD As Integer = 505 '/* "Computing optimal palette" */
    Private Const IDS_CAP_STAT_I_FRAMES As Integer = 506 '/* "%d frames" */
    Private Const IDS_CAP_STAT_L_FRAMES As Integer = 507 '/* "%ld frames" */
    Private Const IDS_CAP_STAT_CAP_L_FRAMES As Integer = 508 '/* "Captured %ld frames" */
    Private Const IDS_CAP_STAT_CAP_AUDIO As Integer = 509 '/* "Capturing audio" */
    Private Const IDS_CAP_STAT_VIDEOCURRENT As Integer = 510 '/* "Captured %ld frames (%ld dropped) %d.%03d sec." */
    Private Const IDS_CAP_STAT_VIDEOAUDIO As Integer = 511 '/* "Captured %d.%03d sec.  %ld frames (%ld dropped) (%d.%03d fps).  %ld audio bytes (%d,%03d sps)" */
    Private Const IDS_CAP_STAT_VIDEOONLY As Integer = 512 '/* "Captured %d.%03d sec.  %ld frames (%ld dropped) (%d.%03d fps)" */
    Private Const IDS_CAP_STAT_FRAMESDROPPED As Integer = 513 '/* "Dropped %ld of %ld frames (%d.%02d%%) during capture." */
#End Region

    <DllImportAttribute("gdi32.dll")> Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As String) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal webcam1 As Integer, ByVal Msg As Integer, ByVal wParam As IntPtr, ByRef lParam As CAPTUREPARMS) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("avicap32.dll", EntryPoint:="capCreateCaptureWindow")> Public Shared Function capCreateCaptureWindow(ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hwndParent As Integer, ByVal nID As Integer) As Integer
    End Function
    Public Declare Ansi Function SetWindowPos Lib "user32.dll" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Public Declare Function DestroyWindow Lib "user32.dll" (ByVal hWnd As Integer) As Boolean
    Public Declare Function capGetDriverDescription Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean 'Not used with this class but kept here for future use 
    'Public Delegate Sub DelegateCallbackGetFrame(ByVal hwnd As System.IntPtr, ByRef videoHeader As VIDEOHDR) 'Not used with this class but kept here for future use
    'Public Delegate Sub DelegateCallbackGetStatus(ByVal hWnd As System.IntPtr, ByVal nID As Integer, ByVal lpsz As Integer) 'Not used with this class but kept here for future use
    '<DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal wMsg As UInteger, ByVal wParam As Integer, ByVal lParam As DelegateCallbackGetStatus) As Integer 'Not used with this class but kept here for future use
    'End Function
    '<DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal wMsg As UInteger, ByVal wParam As Integer, ByVal lParam As DelegateCallbackGetFrame) As Integer 'Not used with this class but kept here for future use
    'End Function
    '<DllImport("user32.dll", EntryPoint:="SendMessage")> Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal wMsg As UInteger, ByVal wParam As Integer, ByRef bitmapInfo As BITMAPINFO) As Integer 'Not used with this class but kept here for future use
    'End Function
#End Region

#Region "Structures"
    <StructLayout(LayoutKind.Sequential)> Private Structure BITMAPINFOHEADER 'Not used with this class but kept here for future use
        Dim biSize As UInteger
        Dim biWidth As Integer
        Dim biHeight As Integer
        Dim biPlanes As UShort
        Dim biBitCount As UShort
        Dim biCompression As UInteger
        Dim biSizeImage As UInteger
        Dim biXPelsPerMeter As Integer
        Dim biYPelsPerMeter As Integer
        Dim biClrUsed As UInteger
        Dim biClrImportant As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential)> Private Structure BITMAPINFO 'Not used with this class but kept here for future use
        Dim bmiHeader As BITMAPINFOHEADER
        Dim bmiColors As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> Private Structure VIDEOHDR 'Not used with this class but kept here for future use
        Dim lpData As System.IntPtr ' Pointer to locked data buffer
        Dim dwBufferLength As UInteger ' Length of data buffer
        Dim dwBytesUsed As UInteger ' Bytes actually used
        Dim dwTimeCaptured As UInteger ' Milliseconds from start of stream
        Dim dwUser As UInteger ' For client's use
        Dim dwFlags As UInteger ' Assorted flags (see defines)
        <MarshalAs(UnmanagedType.SafeArray)> Dim dwReserved As Byte() ' Reserved for driver
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> Public Structure CAPTUREPARMS
        Public dwRequestMicroSecPerFrame As System.UInt32
        Public fMakeUserHitOKToCapture As System.Int32
        Public wPercentDropForError As System.UInt32
        Public fYield As System.Int32
        Public dwIndexSize As System.UInt32
        Public wChunkGranularity As System.UInt32
        Public fUsingDOSMemory As System.Int32
        Public wNumVideoRequested As System.UInt32
        Public fCaptureAudio As System.Int32
        Public wNumAudioRequested As System.UInt32
        Public vKeyAbort As System.UInt32
        Public fAbortLeftMouse As System.Int32
        Public fAbortRightMouse As System.Int32
        Public fLimitEnabled As System.Int32
        Public wTimeLimit As System.UInt32
        Public fMCIControl As System.Int32
        Public fStepMCIDevice As System.Int32
        Public dwMCIStartTime As System.UInt32
        Public dwMCIStopTime As System.UInt32
        Public fStepCaptureAt2x As System.Int32
        Public wStepCaptureAverageFrames As System.UInt32
        Public dwAudioBufferSize As System.UInt32
    End Structure
#End Region

#Region "Routines"
    ''' <summary>
    ''' Creates a new instance of the camera class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        VideoSource = 0
        PreviewFrameRate = 30
        OutputHeight = 600
        OutputWidth = 800
        CapParams = New CAPTUREPARMS
        CapParams.dwRequestMicroSecPerFrame = 66667
        CapParams.fMakeUserHitOKToCapture = 0
        CapParams.wPercentDropForError = 10
        CapParams.fYield = 1
        CapParams.dwIndexSize = 324000
        CapParams.wChunkGranularity = 0
        CapParams.fUsingDOSMemory = 0
        CapParams.wNumVideoRequested = 10
        CapParams.fCaptureAudio = 1
        CapParams.wNumAudioRequested = 10
        CapParams.vKeyAbort = 0
        CapParams.fAbortLeftMouse = 0
        CapParams.fAbortRightMouse = 0
        CapParams.fLimitEnabled = 0
        CapParams.wTimeLimit = 30
        CapParams.fMCIControl = 0
        CapParams.fStepMCIDevice = 0
        CapParams.dwMCIStartTime = 0
        CapParams.dwMCIStopTime = 0
        CapParams.fStepCaptureAt2x = 0
        CapParams.wStepCaptureAverageFrames = 5
        CapParams.dwAudioBufferSize = 10
        CapturePathAndFileName = "C:\capture.avi"
        AlwaysOverwrite = False
        Handle = Nothing
    End Sub

    ''' <summary>
    ''' Resets the camera.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reset()
        If Running Then
            Close()
            Application.DoEvents()
            Handle = capCreateCaptureWindow(VideoSource.ToString, WS_VISIBLE Or WS_CHILD, 0, 0, 0, 0, PreHandle, 0)
            If SetCamera() = False Then
                'MessageBox.Show("Error Setting/Re-Setting Camera", "Errror Setting/Re-Setting Camera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Starts up the camera.
    ''' </summary>
    ''' <param name="PreviewHandle">The handle of the picturebox control to set the image on.</param>
    ''' <remarks></remarks>
    Public Sub Start(ByVal PreviewHandle As Int32)
        If Running = True Then
            'MessageBox.Show("Camera is already running", "Camera is already running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            PreHandle = PreviewHandle
            Handle = capCreateCaptureWindow(VideoSource.ToString, WS_VISIBLE Or WS_CHILD, 0, 0, 0, 0, PreviewHandle, 0)
            If SetCamera() = False Then
                ExceptionLogger.LogException(New Exception("Error setting up camera"))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Starts recording video.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartRecording()
        If Running Then
            If Recording Then
                'MessageBox.Show("Currently recording a video", "Already recording", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If OverwriteExistingFileIfExist() = True Then
                    SendMessage(Handle, WM_CAP_SET_SEQUENCE_SETUP, New IntPtr(Marshal.SizeOf(CapParams)), CapParams)
                    SendMessage(Handle, WM_CAP_FILE_SET_CAPTURE_FILEA, 0, CapturePathAndFileName)
                    SendMessage(Handle, WM_CAP_SEQUENCE, 0, 0)
                    Recording = True
                End If
            End If
        Else
            'MessageBox.Show("Preview video before recording", "Preview first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function OverwriteExistingFileIfExist() As Boolean
        If System.IO.File.Exists(CapturePathAndFileName) Then
            If AlwaysOverwrite = True Then
                System.IO.File.Delete(CapturePathAndFileName)
                Return True
            Else
                'If MessageBox.Show(CapturePathAndFileName + " already exists. Overwrite?", "File exists", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                '    System.IO.File.Delete(CapturePathAndFileName)
                Return True
                'Else
                '    Return False
                'End If
            End If

        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Stops recording video. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopRecording()
        If Recording Then
            SendMessage(Handle, WM_CAP_STOP, 0, 0)
            Recording = False
        Else
            'MessageBox.Show("Not currently recording video", "Not recording", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Sets the camera frame rate.
    ''' </summary>
    ''' <param name="FrameRate">The rate to set.</param>
    ''' <remarks></remarks>
    Public Sub SetPreviewFrameRate(ByVal FrameRate As Integer)
        PreviewFrameRate = FrameRate
        Reset()
    End Sub

    ''' <summary>
    ''' Sets the source index of the capture device to contect to.
    ''' </summary>
    ''' <param name="SourceIndex"> The index of the caputre source to connect to.</param>
    ''' <remarks></remarks>
    Public Sub SetVideoSource(ByVal SourceIndex As Integer)
        VideoSource = SourceIndex
        Reset()
    End Sub

    Private Function SetCamera() As Boolean
        If SendMessage(Handle, WM_CAP_DRIVER_CONNECT, VideoSource, 0) = 1 Then
            SendMessage(Handle, WM_CAP_SET_SCALE, 1, 0)
            SendMessage(Handle, WM_CAP_SET_PREVIEWRATE, CInt(Math.Round((1 / PreviewFrameRate) * 1000)), 0)
            SendMessage(Handle, WM_CAP_SET_PREVIEW, 1, 0)
            SendMessage(Handle, WM_CAP_SET_SEQUENCE_SETUP, New IntPtr(Marshal.SizeOf(CapParams)), CapParams)
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, OutputWidth, OutputHeight, SWP_NOMOVE Or SWP_NOZORDER)
            Running = True
            Return True
        Else
            Running = False
            Return False
        End If
    End Function

    ''' <summary>
    ''' Closes the camera.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Close() As Boolean
        If Recording Then
            SendMessage(Handle, WM_CAP_STOP, 0, 0)
            Recording = False
        End If
        If Running Then
            Close = CBool(SendMessage(Handle, WM_CAP_DRIVER_DISCONNECT, 0, 0))
            DestroyWindow(Handle)
            Running = False
        End If
        Handle = Nothing
        Return False
    End Function

    ''' <summary>
    ''' Shows the camera device settings.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Settings()
        If Handle <> Nothing Then
            SendMessage(Handle, WM_CAP_DRIVER_CONNECT, VideoSource, 0)
            SendMessage(Handle, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
        Else
            'MessageBox.Show("Start camera first", "Camera not started", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Shows compression settings.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Compression()
        If Handle <> Nothing Then
            SendMessage(Handle, WM_CAP_DRIVER_CONNECT, VideoSource, 0)
            SendMessage(Handle, WM_CAP_DLG_VIDEOCOMPRESSION, 0, 0)
        Else
            'MessageBox.Show("Start camera first", "Camera not started", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Copies the current camera frame from the picturebox and returns a bitmap.
    ''' </summary>
    ''' <param name="src">The picturebox where the camera is being previewed.</param>
    ''' <param name="rect">The size of the the camera output.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CopyFrame(ByVal src As PictureBox, ByVal rect As RectangleF) As Bitmap
        If Running Then
            Dim srcPic As Graphics = src.CreateGraphics
            Dim srcBmp As New Bitmap(src.Width, src.Height, srcPic)
            Dim srcMem As Graphics = Graphics.FromImage(srcBmp)
            Dim HDC1 As IntPtr = srcPic.GetHdc
            Dim HDC2 As IntPtr = srcMem.GetHdc
            BitBlt(HDC2, 0, 0, CInt(rect.Width), CInt(rect.Height), HDC1, CInt(rect.X), CInt(rect.Y), 13369376)
            CopyFrame = CType(srcBmp.Clone(), Bitmap)
            srcPic.ReleaseHdc(HDC1) ' Clean Up 
            srcMem.ReleaseHdc(HDC2)
            srcPic.Dispose()
            srcMem.Dispose()
            Return CopyFrame
        Else
            'MessageBox.Show("Start camera first", "Camera not started", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return Nothing
    End Function

#End Region

End Class
