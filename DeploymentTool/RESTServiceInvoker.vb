Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Text
Imports System.Xml

Public Class RESTServiceInvoker

    Public Function InvokeService(ByVal PlatformURL As String, ByVal RequestData As String, ByVal ContentType As String) As String

        Dim RESTResponse As String = ""

        Try

            Dim RESTRequest As HttpWebRequest = Nothing

            RESTRequest = CType(WebRequest.Create(PlatformURL), HttpWebRequest)

            RESTRequest.Method = "POST"

            Dim RequestEncoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding

            RESTRequest.ContentType = ContentType
            RESTRequest.ContentLength = RequestEncoding.GetByteCount(RequestData)

            Using RS As Stream = RESTRequest.GetRequestStream
                Using SW As StreamWriter = New StreamWriter(RS, RequestEncoding)
                    SW.Write(RequestData)
                End Using
            End Using

            Using Serviceres As WebResponse = RESTRequest.GetResponse()

                Using rd As StreamReader = New StreamReader(Serviceres.GetResponseStream())
                    RESTResponse = rd.ReadToEnd()
                End Using

            End Using

        Catch ex As Exception
            RESTResponse = ex.Message

        End Try

        Return RESTResponse

    End Function

    Public Function ValidateCertificate(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslpolicyerror As System.Net.Security.SslPolicyErrors) As Boolean

        Return True

    End Function

End Class
