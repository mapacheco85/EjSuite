Imports System.Web
Imports System.Web.Services
Imports MessagingToolkit.QRCode
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient

Namespace EjSuite
    Public Class CodigoQR
        Implements System.Web.IHttpHandler

        Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim cCodigo As String = context.Request.QueryString.Get("codigo")
            context.Response.ContentType = "image/gif"
            If cCodigo.Length > 0 Then
                Dim oFactura As New Factura(Factura.Columns.NCodFactura, cCodigo)
                Dim qe As New MessagingToolkit.QRCode.Codec.QRCodeEncoder()
                qe.QRCodeForegroundColor = Color.Black
                qe.QRCodeBackgroundColor = Color.White
                qe.QRCodeErrorCorrect = Codec.QRCodeEncoder.ERROR_CORRECTION.M
                Dim bm As Bitmap = qe.Encode(oFactura.CValorQR, Encoding.UTF8)
                bm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)
            End If
        End Sub

        ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    End Class
End Namespace