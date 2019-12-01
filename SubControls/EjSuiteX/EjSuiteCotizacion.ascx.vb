Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports SubSonic
Imports EjSuite.Modules.EjSuite.CotizacionControlSearch
Imports EjSuite.Modules.EjSuite.SucursalControlSearch
Imports System.Transactions
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging


Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteCotizacion
        Inherits EjSuiteModuleBase

        Private Sub inicializar()
            lblNroCotizacion.Text = ""
            txtFechaEmision.Text = ""
            CuentaCliente1.TextValue = "Elija un cliente"
            CuentaCliente1.ClienteId = Nothing
            txtCantidad.Text = ""
            txtDescuento.Text = "0,00"
            lblTotal.Text = ""

            lblNroCotizacion1.Text = ""
            txtFechaEmision1.Text = ""
            CuentaCliente2.TextValue = "Elija un cliente"
            CuentaCliente2.ClienteId = Nothing
            txtCantidad1.Text = ""
            txtDescuento1.Text = ""
            lbltotal1.Text = """"

            lblMessageCotizacion.Text = ""
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            grdCotizacion.DataSource = Nothing
            grdCotizacion.DataBind()
            grdProductosCotizacion.DataSource = Nothing
            grdProductosCotizacion.DataBind()
            grdEjCotizacion.DataSource = Nothing
            grdEjCotizacion.DataBind()
            grdProductosEjCotizacion.DataSource = Nothing
            grdProductosEjCotizacion.DataBind()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlEncabezado.Visible = False
                pnlNuevaCotizacion.Visible = False
                pnlCotizacion.Visible = False
                pnlBusquedaCotizacion.Visible = False
                pnlEjecutarCotizacion.Visible = False
                For index As Decimal = 0 To 100
                    txtDescuento.Items.Add(String.Format("{0:F2}", index))
                Next
                Dim ds As New DataSet()
                ds = SPs.ObtenerListadoValor(101).GetDataSet()
                ddlPlazoCotizacion.DataSource = ds.Tables(0).DefaultView
                ddlPlazoCotizacion.DataTextField = "cValorCatalogo"
                ddlPlazoCotizacion.DataValueField = "cCodCatalogo"
                ddlPlazoCotizacion.DataBind()

                ddlPlazoCotizacion1.DataSource = ds.Tables(0).DefaultView
                ddlPlazoCotizacion1.DataTextField = "cValorCatalogo"
                ddlPlazoCotizacion1.DataValueField = "cCodCatalogo"
                ddlPlazoCotizacion1.DataBind()

                ds = SPs.ObtenerListadoValor(107).GetDataSet()
                rblTipoCotizacion.DataSource = ds.Tables(0).DefaultView
                rblTipoCotizacion.DataTextField = "cValorCatalogo"
                rblTipoCotizacion.DataValueField = "cCodCatalogo"
                rblTipoCotizacion.DataBind()

                rblTipoCotizacion1.DataSource = ds.Tables(0).DefaultView
                rblTipoCotizacion1.DataTextField = "cValorCatalogo"
                rblTipoCotizacion1.DataValueField = "cCodCatalogo"
                rblTipoCotizacion1.DataBind()


                Dim oSucursal As New Sucursal(1)
                Dim oEmpresa As Empresa = EjSuite.GetEmpresa()
                lblEmpresa.Text = oEmpresa.CRazonSocial.ToUpper()
                lblPropietario.Text = "DE: " & oEmpresa.CPropietario.ToUpper()
                lblSucursal.Text = "CASA MATRIZ - 0"
                lblDatos.Text = oEmpresa.CDireccion & "<br/>" & _
                        "TELEFONO: " & oEmpresa.CTelefonos & "<br/>" & _
                        "CORREO: " & oEmpresa.CCorreo & "<br/>LA PAZ - BOLIVIA"

                imgLogo.ImageUrl = String.Format("~/DesktopModules/EjSuite/SubControls/EjSuiteX/LogoImage.ashx?codEmpresa={0}", oEmpresa.NCodEmpresa)
            End If
        End Sub

        Private Sub calculaTotal()
            If CInt(txtCantidad.Text) > 0 And VentaControlSearch1.ProductoId <> Nothing Then
                Dim IdProducto As String = VentaControlSearch1.ProductoId
                Dim oProducto As Producto = Producto.FetchByID(IdProducto)
                VentaControlSearch1.ProductoId = IdProducto
                VentaControlSearch1.TextValue = oProducto.CNombreGenerico
                lblPrecioUnit.Text = String.Format("{0:F}", oProducto.NPrecioCompra)

                If txtDescuento.Text = "" Then
                    txtDescuento.Text = "0,00"
                End If

                Dim nDescuento As Decimal = CDec(txtDescuento.Text) / 100
                Dim precio As Decimal = CInt(txtCantidad.Text) * (oProducto.NPrecioCompra - oProducto.NPrecioCompra * nDescuento)
                lblTotal.Text = String.Format("{0:F} Bs.", precio)
                cmdInsertA.Enabled = True
            Else
                lblTotal.Text = ""
                cmdInsertA.Enabled = False
            End If
        End Sub

        Private Sub AdicionarProducto(ByVal ProdId As String, ByVal oProducto As Producto, ByVal cNombreCompleto As String, ByVal nCantidad As Integer, ByVal oProductoBuscado As VWBuscaProducto)
            If (nCantidad <= oProductoBuscado.NStockActualEnvase) And (oProductoBuscado.NStockActualEnvase > 0) Then
                Dim nPrecio As Decimal
                Dim nDescuento As Decimal
                If txtDescuento.Text <> "" Then
                    nDescuento = CDec(txtDescuento.Text)
                Else
                    nDescuento = 0
                End If
                nDescuento = CDec(nDescuento) / 100
                Dim precioSuelto As Decimal = ((oProducto.NPrecioCompra) - (nDescuento * oProducto.NPrecioCompra)) * nCantidad
                nPrecio = precioSuelto

                Dim tabla As DataTable = New DataTable("DetalleVentas")
                If (ViewState("gvCompra") Is Nothing) Then
                    Dim col1 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Id Producto", .ColumnName = "id", .DefaultValue = 0}
                    tabla.Columns.Add(col1)
                    Dim col3 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Cantidad", .ColumnName = "cantidad", .DefaultValue = 0}
                    tabla.Columns.Add(col3)
                    Dim col7 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Detalle", .ColumnName = "detalle", .DefaultValue = ""}
                    tabla.Columns.Add(col7)
                    Dim col4 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Precio Unit.", .ColumnName = "punitario", .DefaultValue = 0}
                    tabla.Columns.Add(col4)
                    Dim col8 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Descuento", .ColumnName = "descuento", .DefaultValue = 0}
                    tabla.Columns.Add(col8)
                    Dim col5 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Total", .ColumnName = "total", .DefaultValue = 0}
                    tabla.Columns.Add(col5)
                    Dim fila As DataRow = tabla.NewRow()
                    fila("id") = ProdId
                    fila("cantidad") = nCantidad
                    fila("detalle") = oProducto.CDetalles
                    fila("punitario") = String.Format("{0:F}", oProducto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F}", nDescuento)
                    fila("total") = String.Format("{0:F}", nPrecio)
                    tabla.Rows.Add(fila)
                    ViewState("gvCompra") = tabla
                Else
                    Dim encontrado As Boolean = False
                    Dim aux As String = ""
                    Dim val1 As Integer = 0
                    Dim ntotal As Decimal = 0
                    Dim x As Integer = 0
                    For i As Integer = 0 To grdProductos.Rows.Count - 1
                        If (grdProductos.Rows(i).Cells(0).Text = ProdId) Then
                            encontrado = True
                            aux = grdProductos.Rows(i).Cells(1).Text
                            val1 = Integer.Parse(aux) + nCantidad
                            aux = grdProductos.Rows(i).Cells(3).Text
                            ntotal = Decimal.Parse(aux) * val1
                            x = i
                        End If
                    Next
                    tabla = CType(ViewState("gvCompra"), DataTable)
                    If (encontrado = False) Then
                        Dim fila As DataRow = tabla.NewRow()
                        fila("id") = ProdId
                        fila("cantidad") = nCantidad
                        fila("detalle") = oProducto.CDetalles
                        fila("punitario") = String.Format("{0:F}", oProducto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F}", nDescuento)
                        fila("total") = String.Format("{0:F}", nPrecio)
                        tabla.Rows.Add(fila)
                        ViewState("gvCompra") = tabla
                    Else
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(5) = ntotal
                        ViewState("gvCompra") = tabla
                    End If
                End If
                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()

                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductos.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next

                lblTotalCotizacion.Text = String.Format("{0:F}", suma)
                txtCantidad.Text = ""
                lblTotal.Text = ""
                If (VentaControlSearch1 IsNot Nothing) Then
                    VentaControlSearch1 = Nothing
                End If
                pnlCotizacion.Visible = True
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Solo existen: {0} envases en almacén", oProductoBuscado.NStockActualEnvase))
            End If
        End Sub

        Protected Sub ddlPlazoCotizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlPlazoCotizacion.SelectedIndexChanged
            Dim fecha As Date = Now.Date
            If ddlPlazoCotizacion.SelectedIndex > -1 Then
                Dim nDias As Integer = CType(ddlPlazoCotizacion.SelectedValue, Integer)
                txtPlazoCotizacion.Text = fecha.AddDays(nDias)
            End If
        End Sub

        Protected Sub cmdInsertA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA.Click
            Try
                Dim ProdId As String = VentaControlSearch1.ProductoId
                Dim oProducto As Producto = Producto.FetchByID(ProdId)
                Try
                    Dim productoNom As String = oProducto.CNombreGenerico
                    Dim cantidad As Integer
                    If txtCantidad.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, oProducto.NCodProducto)
                    AdicionarProducto(ProdId, oProducto, productoNom, cantidad, objbuscaProd)

                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Falla en la operacion del sistema. Por favor intente de nuevo. {0}", ex.Message))
                End Try
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Falla en la operacion del sistema. Por favor intente de nuevo. {0}", ex.Message))
            End Try

        End Sub

        Protected Sub grdProductos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProductos.RowDeleting
            Dim indice As Integer = e.RowIndex
            Dim tabla As DataTable = New DataTable("Detalle")
            If (grdProductos.Rows.Count > 0 And ViewState("gvCompra") IsNot Nothing) Then
                tabla = CType(ViewState("gvCompra"), DataTable)
                tabla.Rows(indice).Delete()
                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductos.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next
                lblTotalCotizacion.Text = suma.ToString()
            End If
            If CInt(lblTotalCotizacion.Text) = 0 Then
                pnlCotizacion.Visible = False
            End If
        End Sub

        Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad.TextChanged
            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Protected Sub cmdCotizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCotizar.Click
            If grdProductos.Rows.Count > 0 Then
                '=====================================================================================
                Dim nCodUsuario As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, nCodUsuario)
                Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
                Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                'Nueva Proforma/Cotizacion
                Dim IdCotizacion As Integer = New [Select](Aggregate.Max("nCodCotizacion")). _
                        From(Cotizacion.Schema).ExecuteScalar(Of Integer)() + 1
                Dim objNewCotizacion As New Cotizacion()
                objNewCotizacion.NCodCotizacion = IdCotizacion
                objNewCotizacion.NCodSucursalId = objSucursal.NCodSucursal
                objNewCotizacion.NCodUsuario = objempleado.NCodUsuario
                objNewCotizacion.NNumeroCotizacion = New [Select](Aggregate.Max("nNumeroCotizacion")). _
                        From(Cotizacion.Schema).ExecuteScalar(Of Integer)() + 1
                objNewCotizacion.DFechaCotizacion = Date.Parse(txtFechaEmision.Text)
                objNewCotizacion.DFechaLimite = Date.Parse(txtPlazoCotizacion.Text)
                If rblTipoCotizacion.SelectedValue.ToString().Equals("1") Then
                    objNewCotizacion.BEjecutada = False
                    objNewCotizacion.BParcialmente = True
                ElseIf rblTipoCotizacion.SelectedValue.ToString().Equals("2") Then
                    objNewCotizacion.BEjecutada = False
                    objNewCotizacion.BParcialmente = False
                End If

                objNewCotizacion.CCodCliente = CuentaCliente1.ClienteId
                objNewCotizacion.CCliente = CuentaCliente1.TextValue
                objNewCotizacion.Save()

                For i As Integer = 0 To grdProductos.Rows.Count - 1
                    Dim idProducto As String = grdProductos.Rows(i).Cells(0).Text
                    Dim cantidad As Integer = Integer.Parse(grdProductos.Rows(i).Cells(2).Text)
                    Dim precioU As Decimal = Decimal.Parse(grdProductos.Rows(i).Cells(3).Text)
                    Dim descuento As Decimal = Decimal.Parse(grdProductos.Rows(i).Cells(4).Text)
                    Dim objNewProfDetalle As New CotizacionDetalle()
                    Dim IdDetCotizacion As Integer = New [Select](Aggregate.Max("nCodCotizacionDetalle")). _
                        From(CotizacionDetalle.Schema).ExecuteScalar(Of Integer)() + 1
                    objNewProfDetalle.NCodCotizacionDetalle = IdDetCotizacion
                    objNewProfDetalle.NCodProducto = idProducto
                    objNewProfDetalle.NCodCotizacion = IdCotizacion
                    objNewProfDetalle.NCantidad = cantidad
                    objNewProfDetalle.NPrecioUnitario = precioU
                    objNewProfDetalle.BUnidad = False
                    objNewProfDetalle.BCien = False
                    objNewProfDetalle.BDocena = False
                    objNewProfDetalle.BMil = False
                    objNewProfDetalle.NDescuento = descuento
                    objNewProfDetalle.Save()
                Next
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Cotizacion ingresada exitosamente!")
                pnlNuevaCotizacion.Visible = False
                pnlEncabezado.Visible = False
                pnlCotizacion.Visible = False
                pnlBusquedaCotizacion.Visible = False
                pnlEjecutarCotizacion.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub lbtnPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDF.Click
            'If grdProductos.Rows.Count > 0 Then
            '    Try
            '        Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 35, 35, 150, 20)
            '        document.PageSize.Rotate()
            '        document.AddCreationDate()
            '        document.AddAuthor("")
            '        document.AddCreator("")
            '        document.AddTitle("Pedido")
            '        document.AddSubject("Pedido en PDF")
            '        document.AddKeywords("pdf, PdfWriter; Documento; iTextSharp")
            '        Response.Cache.SetCacheability(HttpCacheability.Public)
            '        Response.Cache.SetExpires(DateTime.Now.AddSeconds(360))
            '        Response.ContentType = "application/pdf"
            '        Response.AddHeader("Content-disposition", "attachment; filename=" & "Cotizacion.pdf")
            '        PdfWriter.GetInstance(document, Response.OutputStream)
            '        document.Open()
            '        Dim fontname As String
            '        If Request("Fontname") <> "" Then
            '            fontname = Request("Fontname")
            '        Else
            '            fontname = "msmincho.ttc"
            '        End If
            '        Dim Font1 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font2 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font3 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)

            '        Font1.Size = 14
            '        Font2.Size = 12
            '        Font3.Size = 10

            '        Dim Loc As String = Nothing
            '        Loc = "C:\ejsuite\DesktopModules\EjSuite\Images\EjSuite-logo.jpg"
            '        Dim Img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Loc)
            '        Img.SetAbsolutePosition(20, 620)

            '        document.Add(Img)
            '        Dim tablaLogo As New PdfPTable(1) With {.WidthPercentage = 100}
            '        Dim cellLogo As New PdfPCell(New iTextSharp.text.Paragraph("D Y R DISTRIBUIDORES", Font2)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("De: EDSON JIMENEZ CANAZA", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CASA MATRIZ 0", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("AV. LAS AMERICAS ESQ OCOBAYA #2343", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("VILLA FATIMA", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("TELEFONO: 2264435", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CORREO: contactos@ejsuitebolivia.com", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("LA PAZ - BOLIVIA", Font3)) With {.HorizontalAlignment = Element.ALIGN_LEFT, .Border = 0, .PaddingTop = 0, .PaddingBottom = 0, .PaddingLeft = 0}
            '        tablaLogo.AddCell(cellLogo)
            '        document.Add(tablaLogo)

            '        Dim p As New iTextSharp.text.Paragraph("COTIZACION No " & lblNroCotizacion.Text, Font1)
            '        p.SetAlignment("center")
            '        document.Add(p)

            '        '----Fechas
            '        Dim p2 As New iTextSharp.text.Paragraph("CODIGO CLIENTE: " & CuentaCliente1.ClienteId, Font2)
            '        p2.SpacingBefore = 24
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("CLIENTE: " & CuentaCliente1.TextValue, Font2)
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("FECHA COTIZACION: " & txtFechaEmision.Text, Font2)
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("FECHA VALIDEZ: " & txtPlazoCotizacion.Text, Font2)
            '        document.Add(p2)

            '        '----Productos
            '        Dim tabla As New PdfPTable({50, 150, 60, 60, 60, 60})
            '        tabla.WidthPercentage = 100
            '        tabla.SpacingBefore = 20

            '        Dim cell As New PdfPCell(New iTextSharp.text.Paragraph("CODIGO", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("DETALLE", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("CANTIDAD", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthRight = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("PRECIO UNITARIO", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthRight = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("DESCUENTO", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthRight = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("PRECIO TOTAL", Font2)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .BorderWidthLeft = 0.5, .BorderWidthRight = 0.5, .BorderWidthTop = 0.5, .BorderWidthBottom = 0.5}
            '        tabla.AddCell(cell)

            '        For i = 0 To grdProductos.Rows.Count - 1
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(0).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(1).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(2).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(3).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(4).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductos.Rows(i).Cells(5).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthRight = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '        Next
            '        document.Add(tabla)

            '        '====================================================================================
            '        'Debajo la tabla
            '        Dim tabla3 As New PdfPTable({260, 200})
            '        tabla3.WidthPercentage = 100
            '        tabla3.SpacingBefore = 5
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph(" ", Font2))
            '        cell.Indent = 10
            '        cell.Border = 0
            '        tabla3.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("TOTAL COTIZACION: Bs. " & lblTotalCotizacion.Text, Font2))
            '        cell.Indent = 23
            '        cell.Border = 0
            '        tabla3.AddCell(cell)
            '        document.Add(tabla3)
            '        document.Close()
            '        tabla = Nothing
            '    Catch exp As Exception
            '        Response.Clear()
            '        Response.ContentType = "text/plain"
            '        Response.Write(exp.StackTrace)
            '    End Try
            '    Response.Flush()
            '    Response.End()
            'End If
        End Sub

        '===========================================================================================================
        'búsqueda y Modificacion de una Cotizacion

        Public Sub CargarCotizacion()
            Dim nCodUsuario As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
            Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, nCodUsuario)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '====================================================================================================
            Dim qryproforma As New Query(Cotizacion.Schema)
            qryproforma.AddWhere(Cotizacion.Columns.BEjecutada, False)
            qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
            If txtBuscarCotizacion.Text.Trim() <> "" Then
                qryproforma.AND(Cotizacion.Columns.CCliente, Comparison.Like, String.Format("%{0}%", txtBuscarCotizacion.Text.Trim()))
                qryproforma.OR(Cotizacion.Columns.BEjecutada, False)
                qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
                qryproforma.AND(Cotizacion.Columns.NNumeroCotizacion, txtBuscarCotizacion.Text.Trim())
                qryproforma.OR(Cotizacion.Columns.BEjecutada, False)
                qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
                qryproforma.AND(Cotizacion.Columns.DFechaCotizacion, txtBuscarCotizacion.Text.Trim())
            End If

            Dim lst As New CotizacionCollection
            lst.LoadAndCloseReader(qryproforma.ExecuteReader)
            grdCotizacion.DataSource = lst
            grdCotizacion.DataKeyNames() = New String() {Cotizacion.Columns.NCodCotizacion}
            grdCotizacion.DataBind()
            lblMessageCotizacion.Text = String.Format("Se encontraron: {0} registro(s)", lst.Count)
        End Sub

        Private Sub AdicionarProdCotizacion(ByVal ProdId As String, ByVal Producto As Producto, ByVal productoNom As String, ByVal cantidad As Integer, ByVal objbuscaProd As VWBuscaProducto, ByVal precio As Decimal, ByVal descuento As Decimal)
            If (cantidad <= objbuscaProd.NStockActualEnvase) And (objbuscaProd.NStockActualEnvase > 0) Then
                Dim tabla As DataTable = New DataTable("DetalleVentas1")
                If (ViewState("gvCotizacion") Is Nothing) Then
                    Dim col1 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Id Producto", .ColumnName = "id", .DefaultValue = 0}
                    tabla.Columns.Add(col1)
                    Dim col3 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Cantidad", .ColumnName = "cantidad", .DefaultValue = 0}
                    tabla.Columns.Add(col3)
                    Dim col7 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Detalle", .ColumnName = "detalle", .DefaultValue = ""}
                    tabla.Columns.Add(col7)
                    Dim col4 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Precio Unit.", .ColumnName = "punitario", .DefaultValue = 0}
                    tabla.Columns.Add(col4)
                    Dim col8 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Descuento", .ColumnName = "descuento", .DefaultValue = 0}
                    tabla.Columns.Add(col8)
                    Dim col5 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Total", .ColumnName = "total", .DefaultValue = 0}
                    tabla.Columns.Add(col5)
                    Dim fila As DataRow = tabla.NewRow()
                    fila("id") = ProdId
                    fila("cantidad") = cantidad
                    fila("detalle") = Producto.CDetalles
                    fila("punitario") = String.Format("{0:F}", Producto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F}", descuento)
                    fila("total") = String.Format("{0:F}", precio)
                    tabla.Rows.Add(fila)
                    ViewState("gvCotizacion") = tabla
                Else
                    Dim encontrado As Boolean = False
                    Dim aux As String = ""
                    Dim val1 As Integer = 0
                    Dim ntotal As Decimal = 0
                    Dim x As Integer = 0
                    For i As Integer = 0 To grdProductosCotizacion.Rows.Count - 1
                        If (grdProductosCotizacion.Rows(i).Cells(0).Text = ProdId) Then
                            encontrado = True
                            aux = grdProductosCotizacion.Rows(i).Cells(1).Text
                            val1 = Integer.Parse(aux) + cantidad
                            aux = grdProductosCotizacion.Rows(i).Cells(3).Text
                            ntotal = Decimal.Parse(aux) * val1
                            x = i
                        End If
                    Next
                    tabla = CType(ViewState("gvCotizacion"), DataTable)
                    If (encontrado = False) Then
                        Dim fila As DataRow = tabla.NewRow()
                        fila("id") = ProdId
                        fila("cantidad") = cantidad
                        fila("detalle") = Producto.CDetalles
                        fila("punitario") = String.Format("{0:F}", Producto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F}", descuento)
                        fila("total") = String.Format("{0:F}", precio)
                        tabla.Rows.Add(fila)
                        ViewState("gvCompra") = tabla
                    Else
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(5) = ntotal
                        ViewState("gvCotizacion") = tabla
                    End If
                End If
                grdProductosCotizacion.DataSource = tabla.DefaultView
                grdProductosCotizacion.DataKeyNames = New String() {"id"}
                grdProductosCotizacion.DataBind()
                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductosCotizacion.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next

                lblTotalCotizacion1.Text = String.Format("{0:F}", suma)
                txtCantidad1.Text = ""
                txtDescuento1.Text = ""
                lbltotal1.Text = ""
                If (VentaControlSearch2 IsNot Nothing) Then
                    VentaControlSearch2 = Nothing
                End If
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Solo existen: {0} envases en almacen", objbuscaProd.NStockActualEnvase))
            End If
        End Sub

        Protected Sub btnBuscarCotizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarCotizacion.Click
            CargarCotizacion()
        End Sub

        Protected Sub grdCotizacion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCotizacion.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdCotizacion.PageIndex = indice
            CargarCotizacion()
        End Sub

        Protected Sub grdCotizacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCotizacion.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdCotizacion.DataKeys(indice).Value, Integer)
                    Dim objCotizacion As New Cotizacion(cod)
                    Dim hypFechaEmision As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypFechaEmision.Text = objCotizacion.DFechaCotizacion.ToShortDateString()
                    Dim hypFechaVcto As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypFechaVcto.Text = objCotizacion.DFechaLimite.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdCotizacion_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCotizacion.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypFechaEmision As New Label
                    hypFechaEmision.CssClass = "CommandButton"
                    e.Row.Cells(2).Controls.Add(hypFechaEmision)
                    Dim hypFechaVcto As New Label
                    hypFechaVcto.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypFechaVcto)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdCotizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCotizacion.SelectedIndexChanged
            If grdCotizacion.SelectedIndex > -1 Then
                Dim indice As Integer = grdCotizacion.SelectedIndex
                Dim id As Integer = CType(grdCotizacion.DataKeys(indice).Value, Integer)
                ViewState("cotizacionid") = id
                Dim objCotizacion As New Cotizacion(id)
                lblNroCotizacion1.Text = objCotizacion.NNumeroCotizacion
                txtFechaEmision1.Text = objCotizacion.DFechaCotizacion.ToShortDateString()
                If objCotizacion.DFechaCotizacion.AddDays(15) = objCotizacion.DFechaLimite Then
                    ddlPlazoCotizacion1.SelectedValue = "0"
                End If
                If objCotizacion.DFechaCotizacion.AddDays(30) = objCotizacion.DFechaLimite Then
                    ddlPlazoCotizacion1.SelectedValue = "1"
                End If
                If objCotizacion.DFechaCotizacion.AddDays(60) = objCotizacion.DFechaLimite Then
                    ddlPlazoCotizacion1.SelectedValue = "2"
                End If
                txtPlazoCotizacion1.Text = objCotizacion.DFechaLimite.ToShortDateString()
                CuentaCliente2.TextValue = objCotizacion.CCliente
                CuentaCliente2.ClienteId = objCotizacion.CCodCliente
                Dim qry As SqlQuery = New [Select]().From(CotizacionDetalle.Schema). _
                    Where(CotizacionDetalle.Columns.NCodCotizacionDetalle).IsEqualTo(id)
                Dim ds As DataSet
                ds = qry.ExecuteDataSet
                Dim dr As DataRow
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    Dim ProdId As String = dr(2).ToString
                    Dim cantidad As Integer = CInt(dr(4))
                    Dim descuento As Decimal = CDec(dr(6))
                    Dim objProducto As New Producto(ProdId)
                    Dim productoNom As String = objProducto.CNombreGenerico
                    Dim precio As Decimal = ((objProducto.NPrecioCompra) - (descuento * objProducto.NPrecioCompra)) * cantidad
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, ProdId)
                    AdicionarProdCotizacion(ProdId, objProducto, productoNom, cantidad, objbuscaProd, precio, descuento)
                Next

                pnlEncabezado.Visible = True
                panelbusCotizacion.Visible = False
                panelviewCotizacion.Visible = True
            End If
        End Sub

        Protected Sub txtCantidad1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad1.TextChanged
            If CInt(txtCantidad1.Text.Trim()) > 0 And VentaControlSearch2.ProductoId <> Nothing Then
                Dim IdProducto As String = VentaControlSearch2.ProductoId
                Dim producto As New Producto(IdProducto)
                Dim precio As Decimal
                If txtDescuento1.Text = "" Then
                    txtDescuento1.Text = "0"
                End If
                Dim descuento As Decimal = CDec(txtDescuento1.Text) / 100
                precio = CInt(txtCantidad1.Text) * (producto.NPrecioCompra - producto.NPrecioCompra * descuento)
                lbltotal1.Text = String.Format("{0:F} Bs.", precio)
                cmdInsertA1.Enabled = True
            Else
                lbltotal1.Text = ""
                cmdInsertA1.Enabled = False
            End If
        End Sub

        Protected Sub cmdInsertA1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA1.Click
            Try
                Dim ProdId As String = VentaControlSearch2.ProductoId
                Dim oProducto As New Producto(ProdId)
                Try
                    Dim productoNom As String = oProducto.CNombreGenerico
                    Dim cantidad As Integer
                    If txtCantidad1.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad1.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim descuento As Decimal = 0
                    If txtDescuento1.Text.Trim() <> "" Then
                        descuento = CDec(txtDescuento1.Text)
                    End If
                    descuento = CDec(descuento) / 100
                    Dim precio As Decimal = ((oProducto.NPrecioCompra) - (descuento * oProducto.NPrecioCompra)) * cantidad
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, oProducto.NCodProducto)
                    AdicionarProdCotizacion(ProdId, oProducto, productoNom, cantidad, objbuscaProd, precio, descuento)

                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. Por favor intente de nuevo.")
                End Try
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. Por favor intente de nuevo.")
            End Try
        End Sub

        Protected Sub grdProductosCotizacion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProductosCotizacion.RowDeleting
            Dim indice As Integer = e.RowIndex
            Dim proformaId As Integer = CInt(ViewState("cotizacionid"))
            Dim productoId As String = grdProductosCotizacion.DataKeys(indice).Value.ToString
            Dim tabla As DataTable = New DataTable("DetalleCotizacion")
            If (grdProductosCotizacion.Rows.Count > 0 And ViewState("gvCotizacion") IsNot Nothing) Then
                tabla = CType(ViewState("gvCotizacion"), DataTable)
                tabla.Rows(indice).Delete()
                grdProductosCotizacion.DataSource = tabla.DefaultView
                grdProductosCotizacion.DataKeyNames = New String() {"id"}
                grdProductosCotizacion.DataBind()
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductosCotizacion.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next
                lblTotalCotizacion1.Text = suma.ToString()
                Dim profDetalleId As Integer = New [Select]("nCodCotizacion").From(CotizacionDetalle.Schema). _
                    Where(CotizacionDetalle.Columns.NCodCotizacion).IsEqualTo(proformaId). _
                    And(CotizacionDetalle.Columns.NCodProducto).IsEqualTo(productoId).ExecuteScalar(Of Integer)()
                If profDetalleId > 0 Then
                    CotizacionDetalle.Delete(profDetalleId)
                End If
            End If
            If CInt(lblTotalCotizacion1.Text) = 0 Then
                pnlCotizacion.Visible = False
            End If
        End Sub

        Protected Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            If ViewState("cotizacionid") IsNot Nothing AndAlso Page.IsValid Then
                Dim proformaId As Integer = CInt(ViewState("cotizacionid"))
                Dim objCotizacion As New Cotizacion(proformaId)
                'objCotizacion.Sucursalid = CInt(objSucursal.Sucursalid)
                'objCotizacion.Usuarioid = CInt(objempleado.Userid)
                'objCotizacion.Numero = CDec(lblNroCotizacion.Text)
                objCotizacion.DFechaCotizacion = CDate(txtFechaEmision1.Text)
                objCotizacion.DFechaLimite = CDate(txtPlazoCotizacion1.Text)
                'objCotizacion.Ejecutada = False
                objCotizacion.CCodCliente = CuentaCliente2.ClienteId
                objCotizacion.CCliente = CuentaCliente2.TextValue
                objCotizacion.Save()
                For i As Integer = 0 To grdProductosCotizacion.Rows.Count - 1
                    'Registro de todos los productos de la cotizacion en ProformaDetalle
                    Dim idProducto As String = grdProductosCotizacion.Rows(i).Cells(0).Text
                    Dim cantidad As Integer = Integer.Parse(grdProductosCotizacion.Rows(i).Cells(2).Text)
                    Dim precioU As Decimal = Decimal.Parse(grdProductosCotizacion.Rows(i).Cells(3).Text)
                    Dim descuento As Decimal = Decimal.Parse(grdProductosCotizacion.Rows(i).Cells(4).Text)
                    Dim profDetalleId As Integer = New [Select]("nCodCotizacion"). _
                        From(CotizacionDetalle.Schema). _
                        Where(CotizacionDetalle.Columns.NCodCotizacion).IsEqualTo(proformaId). _
                        And(CotizacionDetalle.Columns.NCodProducto).IsEqualTo(idProducto). _
                        ExecuteScalar(Of Integer)()

                    If profDetalleId > 0 Then
                        Dim objProfDetalle As New CotizacionDetalle(profDetalleId)
                        objProfDetalle.NCodProducto = CType(idProducto, String)
                        objProfDetalle.NCodCotizacion = proformaId
                        objProfDetalle.NCantidad = cantidad
                        objProfDetalle.NPrecioUnitario = precioU
                        objProfDetalle.BUnidad = False
                        objProfDetalle.NDescuento = descuento
                        objProfDetalle.Save()
                    Else
                        Dim objNewProfDetalle As New CotizacionDetalle()
                        objNewProfDetalle.NCodProducto = CType(idProducto, String)
                        objNewProfDetalle.NCodCotizacion = proformaId
                        objNewProfDetalle.NCantidad = cantidad
                        objNewProfDetalle.NPrecioUnitario = precioU
                        objNewProfDetalle.BUnidad = False
                        objNewProfDetalle.NDescuento = descuento
                        objNewProfDetalle.Save()
                    End If
                Next
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Cotización modificada exitosamente!")
                pnlNuevaCotizacion.Visible = False
                pnlEncabezado.Visible = False
                pnlCotizacion.Visible = False
                pnlBusquedaCotizacion.Visible = False
                pnlEjecutarCotizacion.Visible = False
            End If
        End Sub

        Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If ViewState("cotizacionid") IsNot Nothing Then
                    Dim id As Integer = CType(ViewState("cotizacionid"), Integer)
                    Dim qry As SqlQuery = New [Select]("nCodCotizacion").From(CotizacionDetalle.Schema).
                        Where(CotizacionDetalle.Columns.NCodCotizacionDetalle).IsEqualTo(id)
                    Dim ds As DataSet
                    ds = qry.ExecuteDataSet
                    Dim dr As DataRow
                    If ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            dr = ds.Tables(0).Rows(i)
                            CotizacionDetalle.Delete(CInt(dr(0)))
                        Next
                    End If

                    Cotizacion.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Cotizacion eliminado correctamente!")
                    pnlNuevaCotizacion.Visible = False
                    pnlEncabezado.Visible = False
                    pnlCotizacion.Visible = False
                    pnlBusquedaCotizacion.Visible = False
                    pnlEjecutarCotizacion.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlNuevaCotizacion.Visible = False
                pnlEncabezado.Visible = False
                pnlCotizacion.Visible = False
                pnlBusquedaCotizacion.Visible = False
                pnlEjecutarCotizacion.Visible = False
            End Try
        End Sub

        Protected Sub lbtnPDF1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDF1.Click
            'If grdProductosCotizacion.Rows.Count > 0 Then
            '    Try
            '        Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 35, 35, 150, 20)

            '        document.PageSize.Rotate()
            '        document.AddCreationDate()
            '        document.AddAuthor("")
            '        document.AddCreator("")
            '        document.AddTitle("Pedido")
            '        document.AddSubject("Pedido en PDF")
            '        document.AddKeywords("pdf, PdfWriter; Documento; iTextSharp")
            '        Response.Cache.SetCacheability(HttpCacheability.Public)
            '        Response.Cache.SetExpires(DateTime.Now.AddSeconds(360))
            '        Response.ContentType = "application/pdf"
            '        Response.AddHeader("Content-disposition", "attachment; filename=" & "Cotizacion.pdf")
            '        PdfWriter.GetInstance(document, Response.OutputStream)
            '        document.Open()
            '        Dim fontname As String = "msmincho.ttc"
            '        If Request("Fontname") <> "" Then fontname = Request("Fontname")
            '        Dim Font1 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font2 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font3 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)

            '        Font1.Size = 14
            '        Font2.Size = 12
            '        Font3.Size = 10

            '        Dim Loc As String = Nothing
            '        Loc = "C:\intra\DesktopModules\EjSuite\Images\EjSuite-logo.jpg"
            '        Dim Img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Loc)
            '        Img.SetAbsolutePosition(20, 620)

            '        document.Add(Img)
            '        Dim tablaLogo As New PdfPTable(1)
            '        tablaLogo.WidthPercentage = 100
            '        Dim cellLogo As New PdfPCell(New iTextSharp.text.Paragraph("D Y R DISTRIBUIDORES", Font2))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("De: EDSON JIMENEZ CANAZA", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CASA MATRIZ 0", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("AV. LAS AMERICAS ESQ OCOBAYA #2344", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("VILLA FATIMA", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("TELEFONO: 22690745", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("CORREO: contactos@ejsuitebolivia.com", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        cellLogo = New PdfPCell(New iTextSharp.text.Paragraph("LA PAZ - BOLIVIA", Font3))
            '        cellLogo.HorizontalAlignment = Element.ALIGN_LEFT
            '        cellLogo.Border = 0
            '        cellLogo.PaddingTop = 0
            '        cellLogo.PaddingBottom = 0
            '        cellLogo.PaddingLeft = 0
            '        tablaLogo.AddCell(cellLogo)
            '        document.Add(tablaLogo)

            '        Dim p As New iTextSharp.text.Paragraph("COTIZACION No " & lblNroCotizacion1.Text, Font1)
            '        p.SetAlignment("center")
            '        document.Add(p)

            '        '----Fechas
            '        Dim p2 As New iTextSharp.text.Paragraph("CODIGO CLIENTE: " & CuentaCliente2.ClienteId, Font2)
            '        p2.SpacingBefore = 24
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("CLIENTE: " & CuentaCliente2.TextValue, Font2)
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("FECHA COTIZACION: " & txtFechaEmision1.Text, Font2)
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph("FECHA VALIDEZ: " & txtPlazoCotizacion1.Text, Font2)
            '        document.Add(p2)

            '        '----Productos
            '        Dim tabla As New PdfPTable({50, 150, 60, 60, 60, 60})
            '        tabla.WidthPercentage = 100
            '        tabla.SpacingBefore = 20

            '        Dim cell As New PdfPCell(New iTextSharp.text.Paragraph("CODIGO", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("DETALLE", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("CANTIDAD", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthRight = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("PRECIO UNITARIO", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthRight = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("DESCUENTO", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthRight = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("PRECIO TOTAL", Font2))
            '        cell.HorizontalAlignment = Element.ALIGN_CENTER
            '        cell.BorderWidthLeft = 0.5
            '        cell.BorderWidthRight = 0.5
            '        cell.BorderWidthTop = 0.5
            '        cell.BorderWidthBottom = 0.5
            '        tabla.AddCell(cell)

            '        For i = 0 To grdProductosCotizacion.Rows.Count - 1
            '            'Dim cod As Integer = CInt(grdFichaCuenta.Rows(i).Cells(2).Text)
            '            'Dim objVwCuentasCliente As New VwCuentasCliente(VwCuentasCliente.Columns.Numero, cod)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(0).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(1).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(2).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_CENTER
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(3).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(4).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosCotizacion.Rows(i).Cells(5).Text, Font2))
            '            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            '            cell.BorderWidthLeft = 0.5
            '            cell.BorderWidthRight = 0.5
            '            cell.BorderWidthBottom = 0.5
            '            tabla.AddCell(cell)
            '        Next
            '        document.Add(tabla)

            '        '====================================================================================
            '        'Debajo la tabla
            '        Dim tabla3 As New PdfPTable({260, 200})
            '        tabla3.WidthPercentage = 100
            '        tabla3.SpacingBefore = 5
            '        'cell = New PdfPCell(New iTextSharp.text.Paragraph("Son: " & lblLiteralCompra.Text, Font2))
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph(" ", Font2))
            '        cell.Indent = 10
            '        cell.Border = 0
            '        tabla3.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("TOTAL COTIZACION: Bs. " & lblTotalCotizacion1.Text, Font2))
            '        cell.Indent = 23
            '        cell.Border = 0
            '        tabla3.AddCell(cell)
            '        document.Add(tabla3)
            '        document.Close()
            '        tabla = Nothing
            '    Catch exp As Exception
            '        Response.Clear()
            '        Response.ContentType = "text/plain"
            '        Response.Write(exp.StackTrace)
            '    End Try
            '    Response.Flush()
            '    Response.End()
            '    'pnlFactura.Visible = False
            'End If
        End Sub


        Public Sub CargarEjCotizacion()
            Dim nUsuarioId As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
            Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, nUsuarioId)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '====================================================================================================
            Dim qryproforma As New Query(Cotizacion.Schema)
            qryproforma.AddWhere(Cotizacion.Columns.BEjecutada, False)
            qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
            If txtBuscarCotizacion.Text.Trim() <> "" Then
                qryproforma.AND(Cotizacion.Columns.CCliente, Comparison.Like, "%" & txtBuscarEjCotizacion.Text.Trim() & "%")
                qryproforma.OR(Cotizacion.Columns.BEjecutada, False)
                qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
                qryproforma.AND(Cotizacion.Columns.NNumeroCotizacion, txtBuscarEjCotizacion.Text.Trim())
                qryproforma.OR(Cotizacion.Columns.BEjecutada, False)
                qryproforma.AND(Cotizacion.Columns.NCodSucursalId, objSucursal.NCodSucursal)
                qryproforma.AND(Cotizacion.Columns.DFechaCotizacion, txtBuscarEjCotizacion.Text.Trim())
            End If

            Dim lst As New CotizacionCollection
            lst.LoadAndCloseReader(qryproforma.ExecuteReader)
            grdEjCotizacion.DataSource = lst
            grdEjCotizacion.DataKeyNames() = New String() {Cotizacion.Columns.NCodCotizacion}
            grdEjCotizacion.DataBind()
            EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Se encontraron: {0} registro(s)", lst.Count))
        End Sub

        Private Sub GenerarCodigoControl(ByVal aut As Int64, ByVal fac As Int64, ByVal nit As Int64, ByVal fecha As Int64, ByVal dd As Double, ByVal monto As Int64, ByVal llave As String)
            Dim control As String = EjSuite.CargarCodigoControl(aut, fac, nit, fecha, dd, monto, llave, fecha)
            lblCodigoControl3.Text = control
        End Sub

        Private Sub AdicionarEjProdCotizacion(ByVal ProdId As String, ByVal Producto As Producto, ByVal productoNom As String, ByVal cantidad As Integer, ByVal objbuscaProd As VWBuscaProducto, ByVal precio As Decimal, ByVal descuento As Decimal)
            If (cantidad <= objbuscaProd.NStockActualEnvase) And (objbuscaProd.NStockActualEnvase > 0) Then
                Dim tabla As DataTable = New DataTable("DetalleVentas3")
                If (ViewState("gvEjecutarCotizacion") Is Nothing) Then
                    Dim col1 As DataColumn = New DataColumn()
                    col1.AllowDBNull = False
                    col1.Caption = "Id Producto"
                    col1.ColumnName = "id"
                    col1.DefaultValue = 0
                    tabla.Columns.Add(col1)
                    Dim col3 As DataColumn = New DataColumn()
                    col3.AllowDBNull = False
                    col3.Caption = "Cantidad"
                    col3.ColumnName = "cantidad"
                    col3.DefaultValue = 0
                    tabla.Columns.Add(col3)
                    Dim col7 As DataColumn = New DataColumn()
                    col7.AllowDBNull = False
                    col7.Caption = "Detalle"
                    col7.ColumnName = "detalle"
                    col7.DefaultValue = ""
                    tabla.Columns.Add(col7)
                    Dim col4 As DataColumn = New DataColumn()
                    col4.AllowDBNull = False
                    col4.Caption = "Precio Unit."
                    col4.ColumnName = "punitario"
                    col4.DefaultValue = 0
                    tabla.Columns.Add(col4)
                    Dim col8 As DataColumn = New DataColumn()
                    col8.AllowDBNull = False
                    col8.Caption = "Descuento"
                    col8.ColumnName = "descuento"
                    col8.DefaultValue = 0
                    tabla.Columns.Add(col8)
                    Dim col5 As DataColumn = New DataColumn()
                    col5.AllowDBNull = False
                    col5.Caption = "Total"
                    col5.ColumnName = "total"
                    col5.DefaultValue = 0
                    tabla.Columns.Add(col5)
                    Dim fila As DataRow
                    fila = tabla.NewRow()
                    fila("id") = ProdId
                    fila("cantidad") = cantidad
                    fila("detalle") = Producto.CDetalles
                    fila("punitario") = String.Format("{0:F}", Producto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F}", descuento)
                    fila("total") = String.Format("{0:F}", precio)
                    tabla.Rows.Add(fila)
                    ViewState("gvEjecutarCotizacion") = tabla
                Else
                    Dim encontrado As Boolean = False
                    Dim aux As String = ""
                    Dim val1 As Integer = 0
                    Dim ntotal As Decimal = 0
                    Dim x As Integer = 0
                    For i As Integer = 0 To grdProductosEjCotizacion.Rows.Count - 1
                        If (grdProductosEjCotizacion.Rows(i).Cells(0).Text = ProdId) Then
                            encontrado = True
                            aux = grdProductosEjCotizacion.Rows(i).Cells(1).Text
                            val1 = Integer.Parse(aux) + cantidad
                            aux = grdProductosEjCotizacion.Rows(i).Cells(3).Text
                            ntotal = Decimal.Parse(aux) * val1
                            x = i
                        End If
                    Next
                    tabla = CType(ViewState("gvEjecutarCotizacion"), DataTable)
                    If (encontrado = False) Then
                        Dim fila As DataRow
                        fila = tabla.NewRow()
                        fila("id") = ProdId
                        fila("cantidad") = cantidad
                        fila("detalle") = Producto.CDetalles
                        fila("punitario") = String.Format("{0:F}", Producto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F}", descuento)
                        fila("total") = String.Format("{0:F}", precio)
                        tabla.Rows.Add(fila)
                        ViewState("gvEjecutarCotizacion") = tabla
                    Else
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(5) = ntotal
                        ViewState("gvEjecutarCotizacion") = tabla
                    End If
                End If
                grdProductosEjCotizacion.DataSource = tabla.DefaultView
                grdProductosEjCotizacion.DataKeyNames = New String() {"id"}
                grdProductosEjCotizacion.DataBind()
                '=================================================================================
                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductosEjCotizacion.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next

                lbTotalCompra3.Text = String.Format("{0:F}", suma)
                lblLiteralCompra3.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra3.Text))
                '=================================================================================
                txtCantidad3.Text = ""
                txtDescuento3.Text = ""
                lbltotal3.Text = ""
                If (VentaControlSearch3 IsNot Nothing) Then
                    VentaControlSearch3 = Nothing
                End If
                'pnlCotizacion.Visible = True
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("Se existen: {0} unidades en almacen", objbuscaProd.NStockActualEnvase))
            End If
        End Sub

        Protected Sub cmdBuscarEjCotizacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarEjCotizacion.Click
            CargarEjCotizacion()
        End Sub

        Protected Sub grdEjCotizacion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEjCotizacion.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdCotizacion.PageIndex = indice
            CargarCotizacion()
        End Sub

        Protected Sub grdEjCotizacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEjCotizacion.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdEjCotizacion.DataKeys(indice).Value, Integer)
                    Dim objCotizacion As New Cotizacion(cod)
                    Dim hypFechaEmision As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypFechaEmision.Text = objCotizacion.DFechaCotizacion.ToShortDateString()
                    Dim hypFechaVcto As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypFechaVcto.Text = objCotizacion.DFechaLimite.ToShortDateString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdEjCotizacion_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEjCotizacion.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypFechaEmision As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(2).Controls.Add(hypFechaEmision)
                    Dim hypFechaVcto As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(3).Controls.Add(hypFechaVcto)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdEjCotizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdEjCotizacion.SelectedIndexChanged
            If grdEjCotizacion.SelectedIndex > -1 Then
                Dim indice As Integer = grdEjCotizacion.SelectedIndex
                Dim id As Integer = CType(grdEjCotizacion.DataKeys(indice).Value, Integer)
                ViewState("cotizacionEjId") = id
                Dim objCotizacion As New Cotizacion(id)
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, objCotizacion.CCodCliente)
                CuentaCliente3.TextValue = objCliente.CCliente
                CuentaCliente3.ClienteId = objCliente.NCodCliente
                ClienteControlSearch3.TextValue = objCliente.CCliente
                ClienteControlSearch3.ClienteId = objCliente.NCodCliente
                ClienteControlSearch3.Nit = objCliente.CNit
                ClienteControlSearch3.TextValueNit = objCliente.CNit
                ClienteControlSearch3.Nombre = objCliente.CCliente
                ClienteControlSearch3.TextValueNombre = objCliente.CCliente
                Dim qry As SqlQuery = New [Select]().From(CotizacionDetalle.Schema). _
                    Where(CotizacionDetalle.Columns.NCodCotizacion).IsEqualTo(id)
                Dim ds As DataSet = qry.ExecuteDataSet
                Dim dr As DataRow
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    Dim ProdId As String = dr(2).ToString
                    Dim cantidad As Integer = CInt(dr(4))
                    Dim descuento As Decimal = CDec(dr(6))
                    Dim objProducto As New Producto(ProdId)
                    Dim productoNom As String = objProducto.CNombreGenerico
                    Dim precio As Decimal = ((objProducto.NPrecioCompra) - (descuento * objProducto.NPrecioCompra)) * cantidad
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, ProdId)
                    AdicionarEjProdCotizacion(ProdId, objProducto, productoNom, cantidad, objbuscaProd, precio, descuento)
                Next
                pnlEncabezado.Visible = True
                pnlNuevaCotizacion.Visible = False
                pnlBusquedaCotizacion.Visible = False
                pnlCotizacion.Visible = False
                pnlEjecutarCotizacion.Visible = True
                panelbusEjCotizacion.Visible = False
                panelviewEjCotizacion.Visible = True
                panelFacturar.Visible = False
            End If
        End Sub

        Protected Sub txtCantidad3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad3.TextChanged
            If CInt(txtCantidad3.Text.Trim()) > 0 And VentaControlSearch3.ProductoId <> Nothing Then
                Dim IdProducto As String = VentaControlSearch3.ProductoId
                Dim oProducto As New Producto(IdProducto)
                Dim precio As Decimal
                If txtDescuento3.Text = "" Then
                    txtDescuento3.Text = "0"
                End If
                Dim descuento As Decimal = CDec(txtDescuento3.Text) / 100
                precio = CInt(txtCantidad3.Text) * (oProducto.NPrecioCompra - oProducto.NPrecioCompra * descuento)
                lbltotal3.Text = String.Format("{0} Bs.", String.Format("{0:F}", precio))
                cmdInsertA3.Enabled = True
            Else
                lbltotal3.Text = ""
                cmdInsertA3.Enabled = False
            End If
        End Sub

        Protected Sub cmdInsertA3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA3.Click
            Try
                Dim ProdId As String = VentaControlSearch3.ProductoId
                Dim oProducto As New Producto(ProdId)
                Try
                    Dim productoNom As String = oProducto.CNombreGenerico
                    Dim cantidad As Integer
                    If txtCantidad3.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad3.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim descuento As Decimal = 0
                    If txtDescuento3.Text.Trim() <> "" Then
                        descuento = CDec(txtDescuento3.Text)
                    End If
                    descuento = CDec(descuento) / 100
                    Dim precio As Decimal = ((oProducto.NPrecioCompra) - (descuento * oProducto.NPrecioCompra)) * cantidad
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, oProducto.NCodProducto)
                    AdicionarEjProdCotizacion(ProdId, oProducto, productoNom, cantidad, objbuscaProd, precio, descuento)

                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. Por favor intente de nuevo.")
                End Try
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. Por favor intente de nuevo.")
            End Try
        End Sub

        Protected Sub grdProductosEjCotizacion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProductosEjCotizacion.RowDeleting
            Dim indice As Integer = e.RowIndex
            Dim proformaId As Integer = CInt(ViewState("cotizacionEjId"))
            Dim productoId As String = grdProductosEjCotizacion.DataKeys(indice).Value.ToString
            Dim tabla As DataTable = New DataTable("DetalleCotizacion3")
            If (grdProductosEjCotizacion.Rows.Count > 0 And ViewState("gvEjecutarCotizacion") IsNot Nothing) Then
                tabla = CType(ViewState("gvEjecutarCotizacion"), DataTable)
                tabla.Rows(indice).Delete()
                grdProductosEjCotizacion.DataSource = tabla.DefaultView
                grdProductosEjCotizacion.DataKeyNames = New String() {"id"}
                grdProductosEjCotizacion.DataBind()
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductosEjCotizacion.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next
                lbTotalCompra3.Text = suma.ToString()
                '===========================================================================                
                Dim profDetalleId As Integer = New [Select]("nCodCotizacionDetalle").From(CotizacionDetalle.Schema). _
                    Where(CotizacionDetalle.Columns.NCodCotizacion).IsEqualTo(proformaId). _
                    And(CotizacionDetalle.Columns.NCodProducto).IsEqualTo(productoId).ExecuteScalar(Of Integer)()
                If profDetalleId > 0 Then
                    CotizacionDetalle.Delete(profDetalleId)
                End If
            End If
            If CInt(lbTotalCompra3.Text) = 0 Then
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡No hay registros de productos!")
            End If
        End Sub

        Protected Sub cmdFacturar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFacturar.Click
            If grdProductosEjCotizacion.Rows.Count > 0 Then
                Dim q As New Query(SniDatum.Schema)
                q.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                q.AddWhere(SniDatum.Columns.DFechaInicio, Comparison.LessOrEquals, Now())
                Dim lista As New SniDatumCollection
                lista.LoadAndCloseReader(q.ExecuteReader)

                If lista.Count > 0 Then
                    Dim idSni As Integer = New [Select](SniDatum.Columns.NCodSNI). _
                        From(SniDatum.Schema). _
                        Where(SniDatum.Columns.DFechaFinal).IsGreaterThanOrEqualTo(Now()). _
                        And(SniDatum.Columns.DFechaInicio).IsLessThanOrEqualTo(Now()).ExecuteScalar(Of Integer)()
                    Dim objDatoSni As New SniDatum(idSni)
                    Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                    Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, user)
                    Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
                    Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                    Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
                    Dim objRegion As New Region(Region.Columns.NCodRegion, objSucursal.NCodRegion)

                    'id de la ultima factura correspondiente al dato sni (fechas)
                    Dim IdFactura As Integer = New [Select](Aggregate.Max("nCodFactura")). _
                        From(Factura.Schema). _
                        Where(Factura.Columns.CLlaveDosificacion).IsEqualTo(objDatoSni.CLlave). _
                        And(Factura.Columns.CAutorizacion).IsEqualTo(objDatoSni.CAutorizacion). _
                        ExecuteScalar(Of Integer)()

                    Dim numeroFactura As Integer
                    If IdFactura <> 0 Then
                        Dim objFactura As New Factura(IdFactura)
                        numeroFactura = objFactura.NNumero + 1
                    Else
                        numeroFactura = 1
                    End If

                    'Nueva Factura
                    Dim objNewFactura As New Factura
                    objNewFactura.NNumero = CDec(numeroFactura)
                    objNewFactura.CNit = ClienteControlSearch3.Nit
                    objNewFactura.CAutorizacion = objDatoSni.CAutorizacion
                    objNewFactura.CCodigoFactura = lblCodigoControl3.Text
                    objNewFactura.CLlaveDosificacion = objDatoSni.CLlave
                    objNewFactura.DFechaLimite = objDatoSni.DFechaFinal.ToString()
                    objNewFactura.BPendiente = True
                    objNewFactura.BPagada = False
                    objNewFactura.NCodSucursal = CInt(objSucursal.NCodSucursal)
                    objNewFactura.NCodUsuario = CInt(objempleado.NCodUsuario)
                    objNewFactura.DFechaEmision = Now
                    objNewFactura.DVencimiento = Now
                    objNewFactura.BAnulado = False
                    objNewFactura.NCodCliente = CuentaCliente3.ClienteId
                    objNewFactura.NCodCuenta = New [Select](Aggregate.Max(Factura.Columns.NCodCuenta)). _
                        From(Factura.Schema).ExecuteScalar(Of Integer)() + 1
                    objNewFactura.NCodVendedor = VendedorControlSearch3.EmpleadoId
                    objNewFactura.NCodFactura = New [Select](Aggregate.Max(Factura.Columns.NCodFactura)). _
                        From(Factura.Schema).ExecuteScalar(Of Integer)() + 1
                    objNewFactura.Save()

                    For i As Integer = 0 To grdProductosEjCotizacion.Rows.Count - 1
                        'Registro de todos los productos de la factura en Detalle
                        Dim idProducto As String = grdProductosEjCotizacion.Rows(i).Cells(0).Text
                        Dim idFactur As String = objNewFactura.NNumero
                        Dim cantidad As Integer = Integer.Parse(grdProductosEjCotizacion.Rows(i).Cells(1).Text)
                        Dim precioU As Decimal = Decimal.Parse(grdProductosEjCotizacion.Rows(i).Cells(3).Text)
                        Dim descuento As Decimal = Decimal.Parse(grdProductosEjCotizacion.Rows(i).Cells(4).Text)
                        Dim objNewDetalle As Detalle = New Detalle()
                        objNewDetalle.NCodProducto = CType(idProducto, String)
                        objNewDetalle.NcodFactura = objNewFactura.NCodFactura
                        objNewDetalle.NCantidad = cantidad
                        objNewDetalle.NPrecioUnitario = precioU
                        objNewDetalle.BUnidad = False
                        objNewDetalle.NDescuento = descuento
                        objNewDetalle.Save()
                        'Registro de todos los productos de la factura en kardex
                        Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)
                        Dim kardexId As Integer = New [Select](Aggregate.Max("kardexid")). _
                                From(KardexInventario.Schema). _
                                Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                                And(KardexInventario.NCodProductoColumn).IsEqualTo(idProducto). _
                                ExecuteScalar(Of Integer)()
                        Dim objAuxKardex As New KardexInventario(kardexId)
                        Dim objNewKardex As New KardexInventario
                        objNewKardex.NCodAlmacen = AlmacnId
                        objNewKardex.NCodLote = objAuxKardex.NCodLote
                        objNewKardex.NCodProducto = idProducto
                        objNewKardex.DFechareg = Now()
                        objNewKardex.CObservacion = "Venta Factura No " & objNewFactura.NNumero
                        objNewKardex.NPrecioCompra = precioU
                        objNewKardex.NEntrada = 0
                        objNewKardex.NSalida = cantidad
                        objNewKardex.NEntradaSueltos = 0
                        objNewKardex.NSalidaSueltos = 0
                        objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - cantidad
                        objNewKardex.NStockAnteriorSuelto = 0
                        objNewKardex.NStockActualSuelto = 0
                        objNewKardex.NCostoTotal = CDec(lbTotalCompra3.Text)
                        objNewKardex.CGlosa = "Venta de Productos"
                        objNewKardex.NPrecioAlmacen = 0
                        objNewKardex.NPrecioVenta = 0
                        objNewKardex.Save()
                    Next
                    panelFacturar.Visible = True
                    ddlFechaVencimiento3.SelectedValue = "0"
                    txtFechaVencimiento3.Text = Now.Date
                    'Generacion del codigo de control
                    Try
                        Dim total As String = (lbTotalCompra3.Text)
                        Dim qry As New Query(SniDatum.Schema)
                        qry.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                        Dim lst As New SniDatumCollection
                        lst.LoadAndCloseReader(qry.ExecuteReader)
                        If lst.Count > 0 Then
                            For Each objsni As SniDatum In lst
                                Dim llave As String = objsni.CLlave
                                Dim aut As Int64 = Int64.Parse(objsni.CAutorizacion)
                                Dim fac As Int64 = objNewFactura.NNumero
                                Dim nit1 As Int64 = Int64.Parse(objNewFactura.CNit)
                                Dim fechaest As String = txtFechaEmision3.Text.Substring(6, 4) 'Now().Date.Year.ToString
                                fechaest &= txtFechaEmision3.Text.Substring(3, 2)
                                fechaest &= txtFechaEmision3.Text.Substring(0, 2)
                                Dim fecha As Int64 = Int64.Parse(fechaest.Trim)
                                Dim total1 As String = lbTotalCompra3.Text
                                total1 = total1.Replace(".", ",")
                                Dim dd As Double = CDbl(total1)
                                Dim entero As Integer = CInt(dd)
                                Dim fraccion As Integer = CInt((dd - entero) * 100)
                                Dim monto As Int64
                                If fraccion >= 50 Then
                                    monto = Int64.Parse(entero.ToString) + 1
                                Else
                                    monto = Int64.Parse(entero.ToString)
                                End If
                                GenerarCodigoControl(aut, fac, nit1, fecha, dd, monto, llave)
                            Next
                        End If
                    Catch ex As Exception
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "No hay conexion al sistema principal. Consulte con su proveedor.")
                    End Try
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡No hay registros de productos!")
                End If
                lbtnFinalizar.Visible = True
            End If
        End Sub

        Protected Sub lbtnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnFinalizar.Click
            Using tx As New TransactionScope()
                Const friendlyName As String = "EjSuite"
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=Pedfacturacion"

                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)

                Dim idSni As Integer = New [Select](SniDatum.Columns.NCodSNI). _
                            From(SniDatum.Schema). _
                            Where(SniDatum.Columns.DFechaFinal).IsGreaterThanOrEqualTo(Now()). _
                            And(SniDatum.Columns.DFechaInicio).IsLessThanOrEqualTo(Now()).ExecuteScalar(Of Integer)()
                Dim objDatoSni As New SniDatum(idSni)
                Dim IdFactura As Integer = New [Select](Aggregate.Max("nCodFactura")). _
                            From(Factura.Schema). _
                            Where(Factura.Columns.CLlaveDosificacion).IsEqualTo(objDatoSni.CLlave). _
                            And(Factura.Columns.CAutorizacion).IsEqualTo(objDatoSni.CAutorizacion). _
                            ExecuteScalar(Of Integer)()
                Dim objFactura As New Factura(IdFactura)
                objFactura.DFechaEmision = txtFechaEmision3.Text
                objFactura.DVencimiento = txtFechaVencimiento3.Text
                objFactura.CCodigoFactura = lblCodigoControl3.Text

                Dim NroCuenta As Integer = New [Select](Aggregate.Max("cuenta")). _
                            From(Factura.Schema). _
                            ExecuteScalar(Of Integer)()

                If NroCuenta <> 0 Then
                    objFactura.NCodCuenta = NroCuenta + 1
                Else
                    objFactura.NCodCuenta = 10000
                End If
                objFactura.Save()
                '==========================================================================================
                Dim proformaId As Integer = CInt(ViewState("cotizacionEjId"))
                Dim objCotizacion As New Cotizacion(proformaId) With {.BEjecutada = True}
                objCotizacion.Save()
                '==========================================================================================
                tx.Complete()
                lblRes.Text = String.Format("Venta almacenada, puede finalizar el Pedido <a href='{0}'>Haga click aqui </a>", urlDoc)
            End Using
        End Sub

        Protected Sub ddlFechaVencimiento3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFechaVencimiento3.SelectedIndexChanged
            Dim fecha As Date = Now.Date
            If ddlFechaVencimiento3.SelectedValue = "0" Then
                txtFechaVencimiento3.Text = fecha
            End If
            If ddlFechaVencimiento3.SelectedValue = "1" Then
                txtFechaVencimiento3.Text = fecha.AddDays(15)
            End If
            If ddlFechaVencimiento3.SelectedValue = "2" Then
                txtFechaVencimiento3.Text = fecha.AddDays(30)
            End If
            If ddlFechaVencimiento3.SelectedValue = "3" Then
                txtFechaVencimiento3.Text = fecha.AddDays(60)
            End If
        End Sub

        Protected Sub lbtnImprimirFactura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnImprimirFactura.Click
            'If grdProductosEjCotizacion.Rows.Count > 0 Then
            '    Try
            '        Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 35, 5, 41, 174)
            '        document.PageSize.Rotate()
            '        document.AddCreationDate()
            '        document.AddAuthor("")
            '        document.AddCreator("")
            '        document.AddTitle("Factura")
            '        document.AddSubject("Factura en PDF")
            '        document.AddKeywords("pdf, PdfWriter; Documento; iTextSharp")
            '        Response.Cache.SetCacheability(HttpCacheability.Public)
            '        Response.Cache.SetExpires(DateTime.Now.AddSeconds(360))
            '        Response.ContentType = "application/pdf"
            '        Response.AddHeader("Content-disposition", "attachment; filename=" & "Cotizacion.pdf")
            '        PdfWriter.GetInstance(document, Response.OutputStream)
            '        document.Open()
            '        Dim fontname As String = "msmincho.ttc"
            '        If Request("Fontname") <> "" Then fontname = Request("Fontname")
            '        Dim Font1 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font2 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Dim Font3 As New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, iTextSharp.text.Font.BOLD)
            '        Font1.Size = 12
            '        Font2.Size = 12
            '        Font3.Size = 10

            '        Const nitEjSuite As String = "640804019"

            '        Dim idSni As Integer = New [Select](SniDatum.Columns.NCodSNI). _
            '                From(SniDatum.Schema). _
            '                Where(SniDatum.Columns.DFechaFinal).IsGreaterThanOrEqualTo(Now()). _
            '                And(SniDatum.Columns.DFechaInicio).IsLessThanOrEqualTo(Now()).ExecuteScalar(Of Integer)()
            '        Dim objDatoSni As New SniDatum(idSni)

            '        Dim IdFactura As Integer = New [Select](Aggregate.Max("nCodFactura")). _
            '                From(Factura.Schema). _
            '                Where(Factura.Columns.CLlaveDosificacion).IsEqualTo(objDatoSni.CLlave). _
            '                And(Factura.Columns.CAutorizacion).IsEqualTo(objDatoSni.CAutorizacion). _
            '                ExecuteScalar(Of Integer)()
            '        Dim objFactura As New Factura(IdFactura)

            '        '----Nit, Factura, autorizacion
            '        Dim p As New iTextSharp.text.Paragraph("NIT " & nitEjSuite, Font2) With {.IndentationLeft = 410}
            '        document.Add(p)
            '        p = New iTextSharp.text.Paragraph("Factura No. " & objFactura.NNumero, Font2) With {.IndentationLeft = 410}
            '        document.Add(p)
            '        p = New iTextSharp.text.Paragraph("Autorización No. " & objDatoSni.CAutorizacion, Font2) With {.IndentationLeft = 410}
            '        document.Add(p)

            '        '----Fechas
            '        Dim p2 As New iTextSharp.text.Paragraph(txtFechaEmision3.Text, Font3) With {.SpacingBefore = 24, .IndentationLeft = 506}
            '        document.Add(p2)
            '        p2 = New iTextSharp.text.Paragraph(txtFechaVencimiento3.Text, Font3) With {.IndentationLeft = 506}
            '        document.Add(p2)

            '        '----Datos cliente
            '        Dim objCliente As New Cliente(Cliente.Columns.CNit, objFactura.CNit)
            '        p = New iTextSharp.text.Paragraph(String.Format("{0} | Dirección: {1}", objCliente.NCodCliente, objCliente.CDireccion), Font2) With {.SpacingBefore = 37, .IndentationLeft = 75}
            '        document.Add(p)

            '        Dim tabla1 As New PdfPTable({460, 122}) With {.WidthPercentage = 100, .SpacingBefore = 2}
            '        Dim cell As New PdfPCell(New iTextSharp.text.Paragraph(objCliente.CCliente, Font2)) With {.Indent = 50, .Border = 0}
            '        tabla1.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph(objCliente.CNit, Font2)) With {.Border = 0}
            '        tabla1.AddCell(cell)
            '        document.Add(tabla1)

            '        '----Productos
            '        Dim q As SqlQuery = New [Select](). _
            '            From(Detalle.Schema). _
            '            Where(Detalle.Columns.NcodFactura).IsEqualTo(IdFactura)
            '        Dim ds As DataSet = q.ExecuteDataSet
            '        Dim tabla As New PdfPTable({57.140000000000001, 57.140000000000001, 280.43000000000001, 57.140000000000001, 57.140000000000001, 65}) With {.WidthPercentage = 100, .SpacingBefore = 20}

            '        For i = 0 To ds.Tables(0).Rows.Count - 1
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(0).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(1).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(2).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(3).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(4).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '            cell = New PdfPCell(New iTextSharp.text.Paragraph(grdProductosEjCotizacion.Rows(i).Cells(5).Text, Font1))
            '            cell.Border = 0
            '            tabla.AddCell(cell)
            '        Next

            '        document.Add(tabla)
            '        For i = 1 To 15 - grdProductos.Rows.Count
            '            document.Add(New iTextSharp.text.Paragraph(" ", Font1))
            '        Next
            '        'Debajo la tabla
            '        Dim tabla3 As New PdfPTable({480, 200}) With {.WidthPercentage = 100, .SpacingBefore = 5}
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("Son: " & lblLiteralCompra3.Text, Font2)) With {.Indent = 10, .Border = 0}
            '        tabla3.AddCell(cell)
            '        cell = New PdfPCell(New iTextSharp.text.Paragraph("TOTAL: Bs. " & lbTotalCompra3.Text, Font2)) With {.Indent = 23, .Border = 0}
            '        tabla3.AddCell(cell)
            '        document.Add(tabla3)

            '        document.Add(New iTextSharp.text.Paragraph("Codigo de Control: " & lblCodigoControl3.Text, Font1))
            '        document.Add(New iTextSharp.text.Paragraph("Fecha Limite de Emision: " & objDatoSni.DFechaFinal.ToShortDateString(), Font1))

            '        document.Close()
            '        tabla = Nothing
            '    Catch exp As Exception
            '        Response.Clear()
            '        Response.ContentType = "text/plain"
            '        Response.Write(exp.StackTrace)
            '    End Try
            '    Response.Flush()
            '    Response.End()
            'End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlEncabezado.Visible = True
            pnlNuevaCotizacion.Visible = True
            pnlCotizacion.Visible = False
            pnlBusquedaCotizacion.Visible = False
            pnlEjecutarCotizacion.Visible = False
            Dim fecha As Date = Now.Date
            txtFechaEmision.Text = fecha.ToShortDateString()
            txtPlazoCotizacion.Text = fecha.AddDays(15).ToShortDateString()
            Dim IdCotizacion As Integer = New [Select](Aggregate.Max("nCodCotizacion")). _
                From(Cotizacion.Schema).ExecuteScalar(Of Integer)()
            Dim numeroCotizacion As Integer = New [Select](Aggregate.Max("nNumeroCotizacion")). _
                From(Cotizacion.Schema).ExecuteScalar(Of Integer)()
            If IdCotizacion <> 0 Then
                Dim objCotizacion As New Cotizacion(IdCotizacion)
                numeroCotizacion = objCotizacion.NNumeroCotizacion + 1
            End If
            lblNroCotizacion.Text = numeroCotizacion.ToString()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlEncabezado.Visible = False
            pnlNuevaCotizacion.Visible = False
            pnlCotizacion.Visible = False
            pnlBusquedaCotizacion.Visible = True
            panelbusCotizacion.Visible = True
            panelviewCotizacion.Visible = False
            pnlEjecutarCotizacion.Visible = False
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlEncabezado.Visible = False
            pnlNuevaCotizacion.Visible = False
            pnlCotizacion.Visible = False
            pnlBusquedaCotizacion.Visible = False
            pnlEjecutarCotizacion.Visible = True
            panelbusEjCotizacion.Visible = True
            panelviewEjCotizacion.Visible = False
            panelFacturar.Visible = False
        End Sub

        Protected Sub txtDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDescuento.SelectedIndexChanged
            If txtDescuento.SelectedIndex > -1 Then
                calculaTotal()
            End If
        End Sub
    End Class
End Namespace
