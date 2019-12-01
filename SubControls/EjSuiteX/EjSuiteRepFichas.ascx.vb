Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.text.Image

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepFichas
        Inherits EjSuiteModuleBase

        Private Sub CuentaCliente()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)

            Dim qryCliCuenta As New Query(VwCuentasCliente.Schema)
            qryCliCuenta.AddWhere(VwCuentasCliente.Columns.NCodSucursal, objSucursal.NCodSucursal)
            qryCliCuenta.AND(VwCuentasCliente.Columns.NCodCliente, CuentaCliente1.ClienteId)
            qryCliCuenta.BETWEEN_AND(VwCuentasCliente.Columns.DFechaEmision, txtFechainicial.Text, txtFechafinal.Text)
            qryCliCuenta.ORDER_BY(VwCuentasCliente.Columns.NCodCliente)
            Dim lst As New VwCuentasClienteCollection
            lst.LoadAndCloseReader(qryCliCuenta.ExecuteReader)
            grdFichaCuenta.DataSource = lst
            grdFichaCuenta.DataKeyNames = New String() {VwCuentasCliente.Columns.NCodFactura}
            grdFichaCuenta.DataBind()
            lblMessageCuentaCliente.Text = "Se encontraron " & lst.Count.ToString() & " registro(s)"
            panelbusqueda.Visible = True
            If lst.Count > 0 Then
                lbtnExportarExcel.Visible = True
                lbtnExportarPDF.Visible = True
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlClienteExtracto.Visible = True
                panelbusqueda.Visible = True
                CuentaCliente1.TextValue = "Elija un cliente"
                CuentaCliente1.ClienteId = Nothing
                txtFechainicial.Text = ""
                txtFechafinal.Text = ""
                lblResult.Text = ""
                lblMessageCuentaCliente.Text = ""
                lbtnExportarExcel.Visible = False
                lbtnExportarPDF.Visible = False
            End If
        End Sub

        Protected Sub cmdSearchCuentaCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchCuentaCliente.Click
            If CuentaCliente1.ClienteId IsNot Nothing Then
                CuentaCliente()
            End If
        End Sub

        Protected Sub cmdCancelCuentaCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelCuentaCliente.Click
            pnlClienteExtracto.Visible = False
            CuentaCliente1.TextValue = "Elija un cliente"
            CuentaCliente1.ClienteId = Nothing
            txtFechainicial.Text = ""
            txtFechafinal.Text = ""
            lblResult.Text = ""
            lblMessageCuentaCliente.Text = ""
        End Sub

        Protected Sub grdFichaCuenta_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFichaCuenta.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdFichaCuenta.DataKeys(indice).Value, Integer)
                    Dim objVwCuentasCliente As New VwCuentasCliente(VwCuentasCliente.Columns.NCodFactura, cod)
                    Dim hypFechaEmision As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypFechaEmision.Text = objVwCuentasCliente.DFechaEmision.Value.ToShortDateString()
                    Dim hypFechaVencimiento As Label = CType(e.Row.Cells(4).Controls(0), Label)
                    hypFechaVencimiento.Text = objVwCuentasCliente.DVencimiento.Value.ToShortDateString()
                    Dim hypVwCuentasCliente As Label = CType(e.Row.Cells(7).Controls(0), Label)
                    hypVwCuentasCliente.Text = String.Format("{0:F}", objVwCuentasCliente.Debe - objVwCuentasCliente.Haber)
            End Select
        End Sub

        Protected Sub grdFichaCuenta_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFichaCuenta.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypFechaEmision As New Label
                    hypFechaEmision.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypFechaEmision)
                    Dim hypFechaVencimiento As New Label
                    hypFechaVencimiento.CssClass = "CommandButton"
                    e.Row.Cells(4).Controls.Add(hypFechaVencimiento)
                    Dim hypVwCuentasCliente As New Label
                    hypVwCuentasCliente.CssClass = "CommandButton"
                    e.Row.Cells(7).Controls.Add(hypVwCuentasCliente)
            End Select
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdFichaCuenta.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteFichaCuenta.xlsx", grdFichaCuenta)
            End If
        End Sub

        Protected Sub lbtnExportarPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarPDF.Click
            Try
                Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 35, 35, 150, 20)

                document.PageSize.Rotate()
                document.AddCreationDate()
                document.AddAuthor("")
                document.AddCreator("")
                document.AddTitle("Pedido")
                document.AddSubject("Pedido en PDF")
                document.AddKeywords("pdf, PdfWriter; Documento; iTextSharp")
                Response.Cache.SetCacheability(HttpCacheability.Public)
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(360))
                Response.ContentType = "application/pdf"
                Response.AddHeader("Content-disposition", "attachment; filename=" & "Pedido.pdf")
                PdfWriter.GetInstance(document, Response.OutputStream)
                document.Open()
                Dim fontname As String = "msmincho.ttc"
                If Request("Fontname") <> "" Then fontname = Request("Fontname")
                Dim Font1 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
                Dim Font2 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
                Dim Font3 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)

                Font1.Size = 14
                Font2.Size = 12
                Font3.Size = 10

                'string chartLoc = string.Empty;
                'chartLoc = "reports/report1.png";
                'iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(chartLoc);
                'chartImg.SetAbsolutePosition(50, 500);

                Dim Loc As String = Nothing
                'Loc = "~/DesktopModules/EjSuite/Images/ejsuiteff.jpg"
                Loc = "C:\intra\intra\DesktopModules\EjSuite\Images\EjSuite-logo.jpg"
                Dim Img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Loc)
                Img.SetAbsolutePosition(20, 620)

                'Dim imagen As New PdfImage("~/DesktopModules/EjSuite/Images/ejsuiteff.jpg")
                'Dim imagen As New PdfImage()
                document.Add(Img)
                Dim tablaLogo As New PdfPTable(1)
                tablaLogo.WidthPercentage = 100
                Dim cellLogo As New PdfPCell(New iTextSharp.text.Paragraph("DYR DISTRIBUIDORES", Font2))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("De: EDSON JIMENEZ CANAZA", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CASA MATRIZ 0", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("AV. LAS AMERICAS ESQ OCOBAYA #2243", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("VILLA FATIMA", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("TELEFONO: 2262836", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CORREO: contactos@ejsuitebolivia.com", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("LA PAZ - BOLIVIA", Font3))
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
                cellLogo.Border = 0
                cellLogo.PaddingTop = 0
                cellLogo.PaddingBottom = 0
                cellLogo.PaddingLeft = 0
                tablaLogo.AddCell(cellLogo)
                document.Add(tablaLogo)

                Dim p As New iTextSharp.text.Paragraph("FICHA CUENTA", Font1)
                p.SetAlignment("center")
                document.Add(p)

                '----Fechas
                Dim p2 As New iTextSharp.text.Paragraph("CODIGO CLIENTE: " & CuentaCliente1.ClienteId, Font2)
                p2.SpacingBefore = 24
                'p2.IndentationLeft = 506
                document.Add(p2)
                p2 = New iTextSharp.text.Paragraph("CLIENTE: " & CuentaCliente1.TextValue, Font2)
                document.Add(p2)
                p2 = New iTextSharp.text.Paragraph("FECHA: " & Now.ToShortDateString, Font2)
                document.Add(p2)
                p2 = New iTextSharp.text.Paragraph(" ", Font2)
                document.Add(p2)
                p2 = New iTextSharp.text.Paragraph("DESDE: " & txtFechainicial.Text, Font2)
                document.Add(p2)
                p2 = New iTextSharp.text.Paragraph("HASTA: " & txtFechafinal.Text, Font2)
                document.Add(p2)

                '----Productos
                Dim tabla As New PdfPTable({60, 80, 80, 80, 80, 80})
                tabla.WidthPercentage = 100
                'tabla.TotalWidth = 557.14
                tabla.SpacingBefore = 20

                Dim cell As New PdfPCell(New iTextSharp.text.Paragraph("FACTURA No", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                'cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)
                cell = New PdfPCell(New iTextSharp.text.Paragraph("FECHA EMISION", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                'cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)
                cell = New PdfPCell(New iTextSharp.text.Paragraph("FECHA VENCIMIENTO", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)
                cell = New PdfPCell(New iTextSharp.text.Paragraph("DEBE", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)
                cell = New PdfPCell(New iTextSharp.text.Paragraph("HABER", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)
                cell = New PdfPCell(New iTextSharp.text.Paragraph("SALDO", Font2))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                tabla.AddCell(cell)

                For i = 0 To grdFichaCuenta.Rows.Count - 1
                    Dim cod As Integer = CInt(grdFichaCuenta.Rows(i).Cells(2).Text)
                    Dim objVwCuentasCliente As New VwCuentasCliente(VwCuentasCliente.Columns.NNumero, cod)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(grdFichaCuenta.Rows(i).Cells(2).Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(objVwCuentasCliente.DFechaEmision.ToString.Substring(0, 10), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(objVwCuentasCliente.DVencimiento.ToString.Substring(0, 10), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(grdFichaCuenta.Rows(i).Cells(5).Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(grdFichaCuenta.Rows(i).Cells(6).Text, Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                    cell = New PdfPCell(New iTextSharp.text.Paragraph(String.Format("{0:F}", objVwCuentasCliente.Debe - objVwCuentasCliente.Haber), Font2))
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT
                    cell.BorderWidthLeft = 0.5
                    cell.BorderWidthRight = 0.5
                    cell.BorderWidthBottom = 0.5
                    tabla.AddCell(cell)
                Next
                document.Add(tabla)

                '====================================================================================
                'Debajo la tabla
                'Dim tabla3 As New PdfPTable({480, 200})
                'tabla3.WidthPercentage = 100
                'tabla3.SpacingBefore = 5
                'cell = New PdfPCell(New iTextSharp.text.Paragraph("Son: " & lblLiteralCompra.Text, Font2))
                'cell.Indent = 10
                'cell.Border = 0
                'tabla3.AddCell(cell)
                'cell = New PdfPCell(New iTextSharp.text.Paragraph("TOTAL: Bs. " & lblTotalCompra.Text, Font2))
                'cell.Indent = 23
                'cell.Border = 0
                'tabla3.AddCell(cell)
                'document.Add(tabla3)
                document.Close()
                tabla = Nothing
            Catch exp As Exception
                Response.Clear()
                Response.ContentType = "text/plain"
                Response.Write(exp.StackTrace)
            End Try
            Response.Flush()
            Response.End()
            'pnlFactura.Visible = False

        End Sub
    End Class
End Namespace
