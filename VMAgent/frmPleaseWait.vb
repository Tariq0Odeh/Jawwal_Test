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

    Private Sub frmPleaseWait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ExceptionLogger.LogInfo("frmPleaseWait -> frmPleaseWait_Load : Trying to BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch")

            Me.pnlWA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Catch ex As Exception
            ExceptionLogger.LogException(ex)
        End Try

    End Sub
End Class