Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports EjSuite.Modules.EjSuite.VentaControlSearch
Imports System.Transactions

Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.text.Image

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuitePedido
        Inherits EjSuiteModuleBase

        Private sumaproducto As Decimal

        Public Sub BuscarProducto()
            Dim q As New Query(VwProductoPedido.Schema)
            q.ORDER_BY(VwProductoPedido.Columns.Faltante, SortDirection.Descending)

            Dim lst As New VwProductoPedidoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                pnlPedido.Visible = False
                pnlregistroPedidos.Visible = False
                pnlBusquedaPed.Visible = False
                BuscarProducto()
            End If
        End Sub

        Protected Sub txtCantidad0_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
            If txtCantidad.Text = "" Then
                txtCantidad.Text = "0"
            End If

            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Private Sub calculaTotal()
            If CInt(txtCantidad.Text) > 0 And ProductoControlSearch1.ProductoId <> Nothing Then
                Dim IdProducto As String = ProductoControlSearch1.ProductoId
                Dim producto As Producto = producto.FetchByID(IdProducto)
                Dim precio As Double

                Dim precioSuelto As Double = CInt(txtCantidad.Text) * (producto.NPrecioCompra)
                precio = precioSuelto
                lblPrecioUnit.Text = String.Format("{0:F}", producto.NPrecioCompra) & " " & "Bs."
                lblTotal.Text = String.Format("{0:F}", precio) & " " & "Bs."

                cmdInsertA.Enabled = True
            Else
                lblTotal.Text = ""
                cmdInsertA.Enabled = False
            End If
        End Sub

        Protected Sub cmdInsertA_Click(sender As Object, e As EventArgs) Handles cmdInsertA.Click
            Try
                Dim ProdId As String = ProductoControlSearch1.ProductoId
                Dim Producto As Producto = Producto.FetchByID(ProdId)
                Try
                    Dim productoNom As String = Producto.CNombreGenerico
                    Dim cantidad As Integer
                    If txtCantidad.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim objbuscaProd As New VWBuscaProductoCompra(VWBuscaProductoCompra.Columns.NCodProducto, Producto.NCodProducto)
                    AdicionarProducto(ProdId, Producto, productoNom, cantidad, objbuscaProd)

                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. " & ex.Message & " Por favor intente de nuevo.")
                End Try
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Falla en la operacion del sistema. " & ex.Message & " Por favor intente de nuevo.")
            End Try
        End Sub

        Private Sub AdicionarProducto(ByVal ProdId As String, ByVal oProducto As Producto, _
                                      ByVal productoNom As String, ByVal cantidad As Integer, ByVal objbuscaProd As VWBuscaProductoCompra)
            If (cantidad <= objbuscaProd.NStockActualEnvase) And (objbuscaProd.NStockActualEnvase > 0) Then
                Dim precio As Double

                Dim precioSuelto As Double = oProducto.NPrecioCompra * cantidad
                precio = precioSuelto
                Dim tabla As DataTable = New DataTable("DetalleVentas")
                If (ViewState("gvCompra") Is Nothing) Then
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
                    fila("detalle") = oProducto.CNombreGenerico
                    fila("punitario") = String.Format("{0:F2}", oProducto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F2}", 0)
                    fila("total") = String.Format("{0:F2}", precio)
                    tabla.Rows.Add(fila)
                    ViewState("gvCompra") = tabla
                Else
                    Dim encontrado As Boolean = False
                    Dim faltante As Boolean = False
                    Dim aux As String = ""
                    Dim val1 As Integer = 0
                    Dim ntotal As Decimal = 0
                    Dim x As Integer = 0
                    For i As Integer = 0 To grdProductos.Rows.Count - 1
                        If (grdProductos.Rows(i).Cells(0).Text = ProdId) Then
                            aux = grdProductos.Rows(i).Cells(1).Text
                            If ((Integer.Parse(aux) + cantidad) <= objbuscaProd.NStockActualEnvase) And _
                                ((Integer.Parse(aux) + cantidad) > 0) Then
                                encontrado = True
                                val1 = Integer.Parse(aux) + cantidad
                                aux = grdProductos.Rows(i).Cells(3).Text
                                ntotal = Decimal.Parse(aux) * val1 * (1 - 0)
                                x = i
                                faltante = False
                            Else
                                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Producto no cargado!")
                                faltante = True
                            End If
                        End If
                    Next
                    tabla = CType(ViewState("gvCompra"), DataTable)
                    If (encontrado = False AndAlso faltante = False) Then
                        Dim fila As DataRow
                        fila = tabla.NewRow()
                        fila("id") = ProdId
                        fila("cantidad") = cantidad
                        fila("detalle") = oProducto.CNombreGenerico
                        fila("punitario") = String.Format("{0:F2}", oProducto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F2}", 0)
                        fila("total") = String.Format("{0:F2}", precio)
                        tabla.Rows.Add(fila)
                        ViewState("gvCompra") = tabla
                    ElseIf (encontrado = True AndAlso faltante = False) Then
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(4) = String.Format("{0:F2}", 0)
                        tabla.Rows(x).Item(5) = String.Format("{0:F2}", ntotal)
                        ViewState("gvCompra") = tabla
                    End If
                End If

                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To tabla.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next

                lbTotalCompra0.Text = String.Format("{0:F}", suma)
                ViewState("gvCompra") = tabla

                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()

                lblLiteralCompra0.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra0.Text))
                txtCantidad.Text = ""
                ProductoControlSearch1.TextValue = "Elija un producto"
                ProductoControlSearch1.ProductoId = 0
                lblPrecioUnit.Text = ""
                If (ProductoControlSearch1 IsNot Nothing) Then
                    ProductoControlSearch1 = Nothing
                End If
                pnlPedido.Visible = False
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), _
                "¡Observe los detalles del producto!")
            End If
        End Sub

        Protected Sub btnPedido_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPedido.Click
            If grdProductos.Rows.Count > 0 Then
                Dim oOrdenCompra As New OrdenCompra()
                oOrdenCompra.NCodPedido = New [Select](Aggregate.Max(OrdenCompra.Columns.NCodPedido)). _
                    From(OrdenCompra.Schema).ExecuteScalar(Of Integer)() + 1
                oOrdenCompra.CNumeroOC = ((New [Select](Aggregate.Max(OrdenCompra.Columns.CNumeroOC)). _
                    From(OrdenCompra.Schema).ExecuteScalar(Of Integer)()) + 1).ToString("D20")
                oOrdenCompra.DFechaEntrega = Date.MaxValue
                oOrdenCompra.NFacturaAsociada = 0
                oOrdenCompra.BEntregado = False
                oOrdenCompra.BNotaCredito = False
                oOrdenCompra.NCodSucursal = 1
                oOrdenCompra.BAnulado = False
                oOrdenCompra.DFechaSolicitud = Now
                oOrdenCompra.BNotaCredito = False
                oOrdenCompra.NCodCliente = 0
                oOrdenCompra.CFirmaCliente = "EJSUITE SISTEMA"
                oOrdenCompra.CEstadoEnvio = "P"
                oOrdenCompra.BEsPedido = True
                oOrdenCompra.BEsOC = True
                oOrdenCompra.NCodVendedor = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                oOrdenCompra.Save()

                Dim tabla As DataTable = New DataTable("DetalleVentas")
                tabla = CType(ViewState("gvCompra"), DataTable)
                For i As Integer = 0 To tabla.Rows.Count - 1

                    Dim oOrdenCompraDetalle As New OrdenCompraDetalle()
                    oOrdenCompraDetalle.NCodPedidoDetalle = New [Select](Aggregate.Max(OrdenCompraDetalle.Columns.NCodPedidoDetalle)). _
                         From(OrdenCompraDetalle.Schema).ExecuteScalar(Of Integer)() + 1
                    oOrdenCompraDetalle.NCodPedido = oOrdenCompra.NCodPedido
                    oOrdenCompraDetalle.NCodProducto = CType(tabla.Rows(i)("id"), String)
                    oOrdenCompraDetalle.NCantidad = CType(tabla.Rows(i)("cantidad"), Integer)
                    oOrdenCompraDetalle.NPrecioUnitario = CType(tabla.Rows(i)("punitario"), Decimal)
                    oOrdenCompraDetalle.NDescuento = 0D
                    oOrdenCompraDetalle.Save()
                Next
                cmdExportarPDF.Visible = True
                pnlPedido.Visible = True

                lblFecha.Text = "Fecha del Pedido: " & oOrdenCompra.DFechaSolicitud
                ViewState("gvCompra") = Nothing
                grdProductos.DataSource = Nothing
                grdProductos.DataBind()

                Dim qry As SqlQuery = New [Select]("nCodPedidoDetalle, nCodPedido, EJS_Producto.nCodProducto, cNombreGenerico, nCantidad, nPrecioUnitario, nCantidad * nPrecioUnitario AS nTotal"). _
                From(OrdenCompraDetalle.Schema). _
                InnerJoin(Producto.NCodProductoColumn, OrdenCompraDetalle.NCodProductoColumn). _
                Where(OrdenCompraDetalle.Columns.NCodPedido).IsEqualTo(oOrdenCompra.NCodPedido)
                Dim ds As New DataSet
                ds = qry.ExecuteDataSet

                grdPedido.DataSource = ds.Tables(0).DefaultView
                grdPedido.DataBind()

                GenerarPedido(oOrdenCompra.NCodPedido)

                EjSuite.Mensaje(Me.upPanel, Me.GetType(), _
                "¡Pedido Ingresado puede proceder a imprimirlo!")
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), _
                "¡No hay productos ingresados!")
            End If
        End Sub

        Public Sub GenerarPedido(ByVal nCodPedido As Integer)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptPedidos"
            rptReporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            rptReporte.ShowParameterPrompts = False
            rptReporte.ShowExportControls = True
            rptReporte.ShowPrintButton = True

            Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport
            ServerReport = rptReporte.ServerReport

            Dim Credentials As System.Net.ICredentials
            Credentials = System.Net.CredentialCache.DefaultCredentials

            'Dim rsCredentials As ReportServerCredentials
            'rsCredentials = ServerReport.ReportServerCredentials

            Dim cred As New ReportServerCredentials(cUsuario, cClave, ".")
            rptReporte.ServerReport.ReportServerCredentials = cred
            ServerReport.ReportServerUrl = New Uri(cDireccion)
            ServerReport.ReportPath = sUbiNomReporte

            Dim prmnCodPedido As New Microsoft.Reporting.WebForms.ReportParameter()
            prmnCodPedido.Name = "nCodPedido"
            prmnCodPedido.Values.Add(nCodPedido)
          
            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmnCodPedido}
            ServerReport.SetParameters(parameters)
        End Sub

        Protected Sub cmdExportarPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExportarPDF.Click
            Me.cmdExportarPDF_ModalPopupExtender.Show()
        End Sub

        Protected Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.cmdExportarPDF_ModalPopupExtender.Hide()
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusquedaPed.Visible = False
            pnlPedido.Visible = False
            pnlregistroPedidos.Visible = True
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            pnlBusquedaPed.Visible = True
            pnlPedido.Visible = False
            pnlregistroPedidos.Visible = False
        End Sub

        Protected Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
            Dim oConsulta As New Query(OrdenCompra.Schema)
            If txtFechaPedido.Text.Trim() <> "" Then
                oConsulta.AddWhere(OrdenCompra.Columns.DFechaSolicitud, CType(txtFechaPedido.Text.Trim(), Date))
            End If
            oConsulta.AddWhere(OrdenCompra.Columns.BEsOC, True)
            oConsulta.AddWhere(OrdenCompra.Columns.BEsPedido, True)
            oConsulta.AddWhere(OrdenCompra.Columns.BAnulado, False)

            Dim oData As New OrdenCompraCollection()
            oData.LoadAndCloseReader(oConsulta.ExecuteReader())

            grdPedidos.DataSource = oData
            grdPedidos.DataKeyNames = New String() {OrdenCompra.Columns.NCodPedido}
            grdPedidos.DataBind()
        End Sub

        Protected Sub grdPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPedidos.SelectedIndexChanged
            If grdPedidos.SelectedIndex > -1 Then
                Dim nIndice As Integer = grdPedidos.SelectedIndex
                Dim nCodPedido As Integer = CType(grdPedidos.DataKeys(nIndice).Value, Integer)
                cmdExportarPDF.Visible = True
                pnlBusquedaPed.Visible = False
                pnlPedido.Visible = True
                pnlregistroPedidos.Visible = False

                Dim oOrdenCompra As New OrdenCompra(nCodPedido)
                lblFecha.Text = "Fecha del Pedido: " & oOrdenCompra.DFechaSolicitud
                ViewState("gvCompra") = Nothing
                grdProductos.DataSource = Nothing
                grdProductos.DataBind()

                Dim qry As SqlQuery = New [Select]("nCodPedidoDetalle, nCodPedido, EJS_Producto.nCodProducto, cNombreGenerico, nCantidad, nPrecioUnitario, nCantidad * nPrecioUnitario AS nTotal"). _
                From(OrdenCompraDetalle.Schema). _
                InnerJoin(Producto.NCodProductoColumn, OrdenCompraDetalle.NCodProductoColumn). _
                Where(OrdenCompraDetalle.Columns.NCodPedido).IsEqualTo(oOrdenCompra.NCodPedido)
                Dim ds As New DataSet
                ds = qry.ExecuteDataSet

                grdPedido.DataSource = ds.Tables(0).DefaultView
                grdPedido.DataBind()

                GenerarPedido(nCodPedido)
            End If
        End Sub
    End Class
End Namespace
