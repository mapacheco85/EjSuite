Imports System.Web
Imports System.Web.Services
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports EjSuite
Imports System.IO
Imports System.Drawing.Imaging

Public Class LogoImage
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.Clear()
        Dim cCodigo As String = context.Request.QueryString.Get("codEmpresa")
        context.Response.ContentType = "image/jpg"
        If cCodigo.Length > 0 Then
            Dim oEmpresa As New Empresa(Empresa.Columns.NCodEmpresa, cCodigo)
            Dim iImagen As Byte() = CType(oEmpresa.ILogo, Byte())
            Dim oMemoria As New MemoryStream(iImagen, False)
            Dim oImagen As Image = Image.FromStream(oMemoria)

            context.Response.ContentType = "image/jpeg"
            oImagen.Save(context.Response.OutputStream, ImageFormat.Jpeg)
        End If
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class