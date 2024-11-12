Public Class frmPleaseWait

    Public Sub New()
        Try
            ' Subscribe to the Application.ThreadException event
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            ' Subscribe to the AppDomain.CurrentDomain.UnhandledException event
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

            InitializeComponent()
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub

    Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        ' Handle the exception
        ' MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Optionally, log the exception
        ExceptionLogger.LogException(e.Exception)

    End Sub

    Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        ' Handle the exception
        ' Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
        ' MessageBox.Show($"An unhandled exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Optionally, log the exception
        ExceptionLogger.LogException(e.ExceptionObject)
    End Sub

    Private Sub LoadPanelBackGround()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPleaseWait))
        ExceptionLogger.LogInfo("frmPleaseWait -> LoadPanelBackGround : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")
        Me.pnlWA.BackgroundImage = Global.VMAgent.My.Resources.Resources.frmPleaseWait
        Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

        Me.picWait.Image = Global.VMAgent.My.Resources.Resources.frmPleaseWaitGIF
        Me.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub frmPleaseWait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadPanelBackGround()
        Catch ex As Exception
            ExceptionLogger.LogInfo("Failed to load Image Background for pnlWA in frmPleaseWait_Load")
            ExceptionLogger.LogException(ex)
            ExceptionLogger.LogInfo("Try to load Again")
            Try
                Threading.Thread.Sleep(500)
                LoadPanelBackGround()
            Catch ex2 As Exception
                ExceptionLogger.LogInfo("Failed second time to load Image Background for pnlWA in frmPleaseWait_Load")
                ExceptionLogger.LogException(ex2)
                Me.Close()
            End Try
        End Try

        ExceptionLogger.LogInfo("frmPleaseWait -> frmPleaseWait_Load")
    End Sub
End Class