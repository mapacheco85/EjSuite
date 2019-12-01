Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports iTextSharp.text.pdf
Imports System.Transactions
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteAjusteVentas
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            If UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" OrElse UserController.Instance.GetCurrentUserInfo().IsSuperUser Then
                Me.txtBusquedaFactura.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarFactura.ClientID))
                Me.txtBusquedaAnulada.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscaAnulada.ClientID))
                pnlBusquedaFactura.Visible = False
                pnlAnuladas.Visible = False
                lbtn1.Visible = True
                lbtn2.Visible = True
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡No está autorizado, no insista!")
                lbtn1.Visible = False
                lbtn2.Visible = False
            End If
        End Sub

        Private Sub CargarAnulador()
            Dim qry As SqlQuery = New [Select]("nCodFactura, nNumero, cCliente, EJS_Factura.cNit, dFechaEmision"). _
                From(Cliente.Schema).InnerJoin(Factura.NCodClienteColumn, Cliente.NCodClienteColumn)

            If txtBusquedaAnulada.Text <> "" Then
                If IsNumeric(txtBusquedaAnulada.Text) Then
                    qry.Where(Factura.Columns.BAnulado).IsEqualTo(False). _
                                            And(Factura.Columns.NNumero).IsEqualTo(CDec(txtBusquedaAnulada.Text))
                Else
                    qry.Where(Factura.Columns.BAnulado).IsEqualTo(False). _
                        And(Cliente.Columns.CCliente).Like(String.Format("%{0}%", txtBusquedaAnulada.Text))
                End If
            End If

            Dim ds As New DataSet
            ds = qry.ExecuteDataSet()
            grdAnuladas.DataSource = ds.Tables(0).DefaultView
            grdAnuladas.DataKeyNames() = New String() {Factura.Columns.NCodFactura}
            grdAnuladas.DataBind()
            lblTotalAnuladas.Text = String.Format("Se encontraron:{0}Registro(s)", ds.Tables(0).Rows.Count)
            panelbusFact.Visible = True
        End Sub

        Private Sub CargarFactura()
            Dim qry As SqlQuery = New [Select]("nCodFactura, nNumero, cCliente, EJS_Factura.cNit, dFechaEmision"). _
                From(Cliente.Schema).InnerJoin(Factura.NCodClienteColumn, Cliente.NCodClienteColumn). _
                Where(Factura.BAnuladoColumn).IsEqualTo(False)
            If txtBusquedaFactura.Text <> "" Then
                If IsNumeric(txtBusquedaFactura.Text) Then
                    qry.And(Factura.Columns.BAnulado).IsEqualTo(False). _
                                            And(Factura.Columns.NNumero).IsEqualTo(txtBusquedaFactura.Text)
                Else
                    qry.And(Factura.Columns.BAnulado).IsEqualTo(False). _
                                            And(Cliente.Columns.CCliente).Like(String.Format("%{0}%", txtBusquedaFactura.Text))
                End If
            End If

            Dim ds As New DataSet
            ds = qry.ExecuteDataSet()
            grdFactura.DataSource = ds.Tables(0).DefaultView
            grdFactura.DataKeyNames() = New String() {Factura.Columns.NCodFactura}
            grdFactura.DataBind()
            lblMessageFactura.Text = String.Format("Se encontraron:{0}Registro(s)", ds.Tables(0).Rows.Count)
            panelbusFact.Visible = True
        End Sub

        Private Sub calculaTotal()
            If CInt(txtCantidad.Text) > 0 And VentaControlSearch1.ProductoId <> Nothing Then
                Dim IdProducto As String = VentaControlSearch1.ProductoId
                Dim producto As Producto = producto.FetchByID(IdProducto)
                Dim precio As Decimal

                If txtDescuento.Text = "" Then
                    txtDescuento.Text = "0"
                End If

                Dim descuento As Decimal = CDec(txtDescuento.Text) / 100
                Dim precioSuelto As Decimal = CInt(txtCantidad.Text) * (producto.NPrecioCompra - producto.NPrecioCompra * descuento)
                precio = precioSuelto
                lblPrecioUnit.Text = String.Format("{0} Bs.", String.Format("{0:F}", producto.NPrecioCompra))
                lblTotal.Text = String.Format("{0} Bs.", String.Format("{0:F}", precio))
                cmdInsertA.Enabled = True
            Else
                lblTotal.Text = ""
                cmdInsertA.Enabled = False
            End If
        End Sub

        Private Sub AdicionarProducto(ByVal ProdId As String, ByVal oProducto As Producto, ByVal productoNom As String, ByVal cantidad As Integer, ByVal objbuscaProd As VWBuscaProducto)
            If (cantidad <= objbuscaProd.NStockActualEnvase) And (objbuscaProd.NStockActualEnvase > 0) Then
                Dim precio As Decimal
                Dim descuento As Decimal
                If txtDescuento.Text <> "" Then
                    descuento = CDec(txtDescuento.Text)
                Else
                    descuento = 0
                End If
                descuento = CDec(descuento) / 100

                Dim precioSuelto As Decimal = ((oProducto.NPrecioCompra) - (descuento * oProducto.NPrecioCompra)) * cantidad
                precio = precioSuelto
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
                    fila("cantidad") = cantidad
                    fila("detalle") = oProducto.CDetalles
                    fila("punitario") = String.Format("{0:F}", oProducto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F}", descuento)
                    fila("total") = String.Format("{0:F}", precio)
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
                                ntotal = Decimal.Parse(aux) * val1
                                x = i
                                faltante = False
                            Else
                                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Solo existen: " & objbuscaProd.NStockActualEnvase & " envases en almacen!")
                                faltante = True
                            End If
                        End If
                    Next
                    tabla = CType(ViewState("gvCompra"), DataTable)
                    If (encontrado = False AndAlso faltante = False) Then
                        Dim fila As DataRow = tabla.NewRow()
                        fila("id") = ProdId
                        fila("cantidad") = cantidad
                        fila("detalle") = oProducto.CDetalles
                        fila("punitario") = String.Format("{0:F}", oProducto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F}", descuento)
                        fila("total") = String.Format("{0:F}", precio)
                        tabla.Rows.Add(fila)
                        ViewState("gvCompra") = tabla
                    ElseIf (encontrado = True AndAlso faltante = False) Then
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(5) = ntotal
                        ViewState("gvCompra") = tabla
                    End If
                End If
                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()
                '=================================================================================
                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductos.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(5).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next

                lbTotalCompra.Text = String.Format("{0:F}", suma)
                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))
                '=================================================================================
                lblError0.Visible = False
                txtCantidad.Text = ""
                txtDescuento.Text = ""
                VentaControlSearch1.TextValue = "Elija un producto"
                VentaControlSearch1.ProductoId = 0
                lblTotal.Text = ""
                lblPrecioUnit.Text = ""
                If (VentaControlSearch1 IsNot Nothing) Then
                    VentaControlSearch1 = Nothing
                End If
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("¡Solo existen: {0} envases en almacen!", objbuscaProd.NStockActualEnvase))
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaFactura.Visible = False
                panelbusFact.Visible = True
                panelviewFact.Visible = False
                panelTotal.Visible = False
                panelFacturar.Visible = False
                pnlAnuladas.Visible = False

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

        Protected Sub btnBuscarFactura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarFactura.Click
            CargarFactura()
        End Sub

        Protected Sub grdFactura_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFactura.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdFactura.PageIndex = indice
            CargarFactura()
        End Sub

        Protected Sub grdFactura_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdFactura.SelectedIndexChanged
            If grdFactura.SelectedIndex > -1 Then
                Dim indice As Integer = grdFactura.SelectedIndex
                Dim id As Integer = CType(grdFactura.DataKeys(indice).Value, Integer)
                ViewState("factid") = id.ToString()
                Dim objFactura As New Factura(id)
                Dim objVendedor As New Empleado(Empleado.Columns.NCodUsuario, objFactura.NCodVendedor)
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, objFactura.NCodCliente)
                Dim objBeneficiario As New Beneficiario(Beneficiario.Columns.CNit, objCliente.CNit)
                ClienteControlSearch1.TextValue = objCliente.NCodCliente
                ClienteControlSearch1.ClienteId = objCliente.NCodCliente
                ClienteControlSearch1.CargarBeneficiario(objCliente.NCodCliente)
                ClienteControlSearch1.DropDownValue = objBeneficiario.NCodBeneficiario
                ClienteControlSearch1.TextValueNombre = objBeneficiario.CNombre
                ClienteControlSearch1.Nombre = objBeneficiario.CNombre
                ClienteControlSearch1.TextValueNit = objBeneficiario.CNit
                ClienteControlSearch1.Nit = objBeneficiario.CNit
                lblFechaEmision.Text = objFactura.DFechaEmision.Value.ToShortDateString()
                lblCodigoControl.Text = objFactura.CCodigoFactura

                '===========================================================
                'búsqueda de productos pertenecientes a la factura
                Dim q As SqlQuery = New [Select]("nCodProducto, nCantidad, nPrecioUnitario, nDescuento, (nCantidad * nPrecioUnitario) - (nCantidad * nDescuento * nPrecioUnitario) Total"). _
                From(Detalle.Schema). _
                Where(Detalle.Columns.NcodFactura).IsEqualTo(objFactura.NCodFactura)
                Dim ds As DataSet
                ds = q.ExecuteDataSet
                grdProductos.DataSource = ds.Tables(0).DefaultView
                grdProductos.DataKeyNames() = New String() {"nCodProducto"}
                grdProductos.DataBind()

                '===========================================================
                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = New [Select](Aggregate.Sum("(nCantidad * nPrecioUnitario) - (nCantidad * nDescuento * nPrecioUnitario)")). _
                            From(Of Detalle).Where(Detalle.NcodFacturaColumn). _
                            IsEqualTo(ViewState("factid")).ExecuteScalar(Of Decimal)()

                lbTotalCompra.Text = String.Format("{0:F}", suma)

                Dim descuento As Decimal = New [Select](Aggregate.Sum("(nCantidad * nDescuento * nPrecioUnitario)")). _
                            From(Of Detalle).Where(Detalle.NcodFacturaColumn). _
                            IsEqualTo(ViewState("factid")).ExecuteScalar(Of Decimal)()

                lblTotalDescuento.Text = String.Format("{0:F}", descuento)
                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))

                '=============================================================
                lblError0.Visible = False
                txtCantidad.Text = ""
                txtDescuento.Text = ""
                lblTotal.Text = ""
                If (VentaControlSearch1 IsNot Nothing) Then
                    VentaControlSearch1 = Nothing
                End If
                panelbusFact.Visible = False
                panelviewFact.Visible = True
                panelTotal.Visible = True
                panelFacturar.Visible = False

                If objFactura.DFechaLimite.Year < Now.Date.Year Then
                    cmdFacturar.Visible = False
                    cmdInsertA.Visible = False
                    lbtnPDF.Visible = False
                Else
                    cmdFacturar.Visible = True
                    cmdInsertA.Visible = True
                    lbtnPDF.Visible = True
                End If

            End If
        End Sub

        Protected Sub cmdInsertA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA.Click
            Try
                lblError0.Visible = True
                lblError0.Text = ""
                Dim ProdId As String = VentaControlSearch1.ProductoId
                Dim oProducto As Producto = Producto.FetchByID(ProdId)
                Try
                    Dim productoNom As String = oProducto.CDetalles
                    Dim cantidad As Integer
                    If txtCantidad.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, oProducto.NCodProducto)
                    AdicionarProducto(ProdId, oProducto, productoNom, cantidad, objbuscaProd)

                    Dim parcial As Decimal = 0D
                    Dim suma As Decimal = New [Select](Aggregate.Sum("(CANTIDAD * PRECIOUNITARIO) - (CANTIDAD * DESCUENTO * PRECIOUNITARIO)")). _
                                From(Of Detalle).Where(Detalle.NcodFacturaColumn). _
                                IsEqualTo(ViewState("factid")).ExecuteScalar(Of Decimal)()

                    lbTotalCompra.Text = String.Format("{0:F}", suma)
                    lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))

                Catch ex As Exception
                    lblError0.Text = "Falla en la operacion del sistema. Por favor intente de nuevo."
                    lblError0.ForeColor = Drawing.Color.Red
                    lblError0.Visible = True
                End Try
            Catch ex As Exception
                lblError0.Text = "Falla en la operacion del sistema. Por favor intente de nuevo."
                lblError0.ForeColor = Drawing.Color.Red
                lblError0.Visible = True
            End Try

        End Sub

        Private Sub grdProductos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblDetalle As New Label
                    e.Row.Cells(1).Controls.Add(lblDetalle)
                    Dim lblPrecio As New Label
                    e.Row.Cells(3).Controls.Add(lblPrecio)
                    Dim lblTotal As New Label
                    e.Row.Cells(5).Controls.Add(lblTotal)
                Case Else
                    Exit Select
            End Select
        End Sub

        Private Sub grdProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim pid As String = grdProductos.DataKeys(indice).Value.ToString
                    Dim objDetalle As Detalle = New [Select]().From(Of Detalle).Where(Detalle.NCodProductoColumn). _
                        IsEqualTo(pid).And(Detalle.NcodFacturaColumn). _
                        IsEqualTo(ViewState("factid")).ExecuteSingle(Of Detalle)()
                    Dim lblDetalle As Label = CType(e.Row.Cells(1).Controls(0), Label)
                    Dim objProducto As New Producto(objDetalle.NCodProducto)
                    lblDetalle.Text = objProducto.CDetalles
                    Dim lblPrecio As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    lblPrecio.Text = String.Format("{0:F}", objDetalle.NPrecioUnitario)
                    Dim lblTotal As Label = CType(e.Row.Cells(5).Controls(0), Label)
                    Dim aux As String = New [Select]("(nCantidad * nPrecioUnitario) - (nCantidad * nDescuento * nPrecioUnitario)"). _
                        From(Of Detalle).Where(Detalle.NCodProductoColumn). _
                        IsEqualTo(pid).And(Detalle.NcodFacturaColumn). _
                        IsEqualTo(ViewState("factid")).ExecuteScalar().ToString
                    lblTotal.Text = String.Format("{0:F}", CDec(aux))
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdProductos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProductos.RowDeleting
            If Year(CDate(lblFechaEmision.Text)) >= Now.Date.Year Then
                Dim indice As Integer = e.RowIndex
                '=====================================================================================
                'Registro del producto modificado en kardex
                Dim objDetalle As Detalle = New [Select](). _
                        From(Of Detalle). _
                        Where(Detalle.NCodProductoColumn).IsEqualTo(grdProductos.DataKeys(indice).Value). _
                        And(Detalle.NcodFacturaColumn).IsEqualTo(ViewState("factid")). _
                        ExecuteSingle(Of Detalle)()

                Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, user)
                Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
                Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
                Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)

                Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                            From(KardexInventario.Schema). _
                            Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                            And(KardexInventario.NCodProductoColumn).IsEqualTo(grdProductos.DataKeys(indice).Value). _
                            ExecuteScalar(Of Integer)()
                Dim objAuxKardex As New KardexInventario(kardexId)

                If objDetalle IsNot Nothing Then
                    Dim objNewKardex As New KardexInventario
                    objNewKardex.NCodAlmacen = AlmacnId
                    objNewKardex.NCodLote = objAuxKardex.NCodLote
                    objNewKardex.NCodProducto = grdProductos.DataKeys(indice).Value
                    objNewKardex.DFechareg = Now()
                    objNewKardex.CObservacion = "Devolucion"
                    objNewKardex.NPrecioCompra = objDetalle.NPrecioUnitario
                    objNewKardex.NEntrada = CInt(objDetalle.NCantidad)
                    objNewKardex.NSalida = 0
                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase + CInt(objDetalle.NCantidad)
                    objNewKardex.NCostoTotal = (CInt(objDetalle.NCantidad) * objDetalle.NPrecioUnitario) - (objDetalle.NPrecioUnitario * objDetalle.NDescuento * objDetalle.NCantidad)
                    objNewKardex.CGlosa = "Devolucion de Productos/Cliente: " & ClienteControlSearch1.Nombre
                    objNewKardex.NEntradaSueltos = 0
                    objNewKardex.NSalidaSueltos = 0
                    objNewKardex.NStockAnteriorSuelto = 0
                    objNewKardex.NStockActualSuelto = 0
                    objNewKardex.NPrecioAlmacen = 0
                    objNewKardex.NPrecioVenta = 0
                    objNewKardex.NCodKardex = New [Select](Aggregate.Max(KardexInventario.Columns.NCodKardex)). _
                                From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                    objNewKardex.Save()
                End If

                '=====================================================================================
                Dim q As New Query(Detalle.Schema)
                q.BuildDeleteCommand()
                q.AddWhere(Detalle.Columns.NCodProducto, grdProductos.DataKeys(indice).Value)
                q.AddWhere(Detalle.Columns.NcodFactura, ViewState("factid"))
                q.Execute()

                Dim qr As SqlQuery = New [Select]("nCodProducto, nCantidad, nPrecioUnitario, nDescuento, (nCantidad * nPrecioUnitario) - (nCantidad * nDescuento * nPrecioUnitario) as Total"). _
                        From(Detalle.Schema). _
                        Where(Detalle.Columns.NcodFactura).IsEqualTo(ViewState("factid"))
                Dim lst As New DetalleCollection()
                lst.LoadAndCloseReader(qr.ExecuteReader())
                grdProductos.DataSource = lst

                grdProductos.DataKeyNames() = New String() {"nCodProducto"}
                grdProductos.DataBind()

                '=================================================================================
                'Suma Total de toda la compra
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = New [Select](Aggregate.Sum("(nCantidad * nPrecioUnitario) - (nCantidad * nDescuento * nPrecioUnitario)")). _
                            From(Of Detalle).Where(Detalle.NcodFacturaColumn). _
                            IsEqualTo(ViewState("factid")).ExecuteScalar(Of Decimal)()

                lbTotalCompra.Text = String.Format("{0:F}", suma)
                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))
            End If
        End Sub

        Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad.TextChanged
            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Protected Sub cmdFacturacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFacturar.Click
            If grdProductos.Rows.Count > 0 Then
                Dim q As New Query(Snidatum.Schema)
                q.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                q.AddWhere(SniDatum.Columns.DFechaInicio, Comparison.LessOrEquals, Now())
                Dim lista As New SnidatumCollection
                lista.LoadAndCloseReader(q.ExecuteReader)

                If lista.Count > 0 Then
                    Dim idSni As Integer = New [Select](Aggregate.Max(SniDatum.Columns.NCodSNI)). _
                            From(SniDatum.Schema).ExecuteScalar(Of Integer)()
                    Dim objDatoSni As New Snidatum(1)
                    '=====================================================================================
                    Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                    Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, user)
                    Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
                    Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                    Dim objRegion As New Region(Region.Columns.NCodRegion, objSucursal.NCodRegion)
                    '=====================================================================================
                    Dim IdFactura As Integer = CInt(ViewState("factid"))
                    'Modificacion Factura
                    Dim objFactura As New Factura(IdFactura)
                    objFactura.CNit = ClienteControlSearch1.TextValueNit
                    objFactura.CNombreFactura = ClienteControlSearch1.TextValueNombre

                    objFactura.NCodUsuario = CInt(objempleado.NCodUsuario)
                    objFactura.NCodCliente = ClienteControlSearch1.ClienteId
                    objFactura.Save()
                    '====================================================================================
                    '==================== Generacion del codigo de control ==============================
                    '====================================================================================
                    Try
                        Dim total As String = (lbTotalCompra.Text)
                        Dim qry As New Query(Snidatum.Schema)
                        qry.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                        Dim lst As New SnidatumCollection
                        lst.LoadAndCloseReader(qry.ExecuteReader)
                        If lst.Count > 0 Then
                            For Each objsni As Snidatum In lst
                                Dim llave As String = objsni.CLlave
                                Dim aut As Int64 = Int64.Parse(objsni.CAutorizacion)
                                Dim fac As Int64 = Int64.Parse(objFactura.NNumero)
                                Dim nit As Int64 = Int64.Parse(objFactura.CNit)
                                Dim fechaest As String = lblFechaEmision.Text.Substring(6, 4)
                                fechaest &= lblFechaEmision.Text.Substring(3, 2)
                                fechaest &= lblFechaEmision.Text.Substring(0, 2)
                                Dim fecha As Int64 = Int64.Parse(fechaest.Trim)
                                Dim total1 As String = lbTotalCompra.Text
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
                                Dim control As String = EjSuite.CargarCodigoControl(aut, fac, nit, fecha, dd, monto, llave, fecha)
                                lblCodigoControl.Text = control
                                panelFacturar.Visible = True
                                lbtnPDF.Visible = True
                            Next
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    Exit Sub
                End If

                Using tx As New TransactionScope()
                    Const friendlyName As String = "EjSuite"
                    Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                    Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                    Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                    Dim param(2) As String
                    param(0) = "mid=" & modID
                    param(1) = "EjSuiteSubControl=Ajusteventas"

                    Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                    Dim idSni As Integer = New [Select](SniDatum.Columns.NCodSNI). _
                                From(SniDatum.Schema). _
                                Where(SniDatum.Columns.DFechaFinal).IsGreaterThanOrEqualTo(Now()). _
                                And(SniDatum.Columns.DFechaInicio).IsLessThanOrEqualTo(Now()).ExecuteScalar(Of Integer)()
                    Dim objDatoSni As New SniDatum(idSni)
                    Dim IdFactura As Integer = CInt(ViewState("factid"))
                    Dim objFactura As New Factura(IdFactura)
                    Dim aux As String = lblFechaEmision.Text
                    objFactura.DVencimiento = Now
                    objFactura.CCodigoFactura = lblCodigoControl.Text

                    Dim data As String = EjSuite.ObtenerCodigoBaseQR("594839012", objFactura.NNumero.ToString(), _
                                objFactura.CAutorizacion, objFactura.DFechaEmision.Value.ToShortDateString(), _
                                String.Format("{0:F2}", CDec(lbTotalCompra.Text) + CDec(lblTotalDescuento.Text)), _
                                String.Format("{0:F2}", lbTotalCompra.Text.Replace(",", ".")), _
                                lblCodigoControl.Text, ClienteControlSearch1.Nit, "0", _
                                "0", "0", lblTotalDescuento.Text.Replace(",", "."))
                    objFactura.CValorQR = data
                    objFactura.Save()

                    'COMMIT TRANSACTION
                    tx.Complete()
                    lblRes.Text = String.Format("Datos modificados, puede finalizar esta accion <a href='{0}'>Haga click aqui </a>", urlDoc)
                End Using

                ImprimirFactura(CInt(ViewState("factid")))
            End If
        End Sub

        Protected Sub lbtnPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDF.Click
            Me.lbtnPDF_ModalPopupExtender.Show()
        End Sub

        Protected Sub btnBuscaAnulada_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscaAnulada.Click
            CargarAnulador()
        End Sub

        Protected Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
            If grdAnuladas.Rows.Count > 0 Then
                For i = 0 To grdAnuladas.Rows.Count - 1
                    Dim chkmod As CheckBox = CType(grdAnuladas.Rows(i).FindControl("chkmod"), CheckBox)
                    If chkmod.Checked = True Then
                        Dim objFactura As New Factura(grdAnuladas.DataKeys(i).Value)
                        objFactura.BAnulado = True
                        objFactura.Save()

                        Dim q As New Query(Detalle.Schema)
                        q.AddWhere(Detalle.Columns.NcodFactura, objFactura.NCodFactura)
                        Dim lst As New DetalleCollection
                        lst.LoadAndCloseReader(q.ExecuteReader())
                        For Each objDetalle As Detalle In lst
                            Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                            Dim objempleado As New Empleado(Empleado.Columns.NCodUsuario, user)
                            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objempleado.NCodEmpleado)
                            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                            Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
                            Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)

                            Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                                        From(KardexInventario.Schema). _
                                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                                        And(KardexInventario.NCodProductoColumn).IsEqualTo(objDetalle.NCodProducto). _
                                        ExecuteScalar(Of Integer)()
                            Dim objAuxKardex As New KardexInventario(kardexId)
                            Dim objNewKardex As New KardexInventario
                            objNewKardex.NCodAlmacen = AlmacnId
                            objNewKardex.NCodLote = objAuxKardex.NCodLote
                            objNewKardex.NCodProducto = objDetalle.NCodProducto
                            objNewKardex.DFechareg = Now()
                            objNewKardex.CObservacion = "Anulacion de factura"
                            objNewKardex.NPrecioCompra = objDetalle.NPrecioUnitario
                            objNewKardex.NEntrada = objDetalle.NCantidad
                            objNewKardex.NSalida = 0
                            objNewKardex.NEntradaSueltos = 0
                            objNewKardex.NSalidaSueltos = 0
                            objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                            objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase + objDetalle.NCantidad
                            objNewKardex.NStockAnteriorSuelto = 0
                            objNewKardex.NStockActualSuelto = 0
                            objNewKardex.NCostoTotal = (objDetalle.NCantidad * objDetalle.NPrecioUnitario)
                            objNewKardex.CGlosa = "Anulacion de Factura"
                            objNewKardex.NPrecioAlmacen = 0
                            objNewKardex.NPrecioVenta = 0
                            objNewKardex.NCodKardex = New [Select](Aggregate.Max(KardexInventario.Columns.NCodKardex)). _
                                From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                            objNewKardex.Save()
                        Next
                    End If
                Next
            End If
            EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Anulacion realizada exitosamente!")
            CargarAnulador()
        End Sub

        Protected Sub cmdLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLimpiar.Click
            pnlBusquedaFactura.Visible = False
            pnlAnuladas.Visible = True
            txtBusquedaAnulada.Text = ""
            txtBusquedaFactura.Text = ""
            grdAnuladas.DataSource = Nothing
            grdAnuladas.DataBind()
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusquedaFactura.Visible = True
            pnlAnuladas.Visible = False
            txtBusquedaAnulada.Text = ""
            txtBusquedaFactura.Text = ""
            grdFactura.DataSource = Nothing
            grdFactura.DataBind()
            panelbusFact.Visible = True
            panelviewFact.Visible = False
            panelTotal.Visible = False
            panelFacturar.Visible = False
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            pnlBusquedaFactura.Visible = False
            pnlAnuladas.Visible = True
            txtBusquedaAnulada.Text = ""
            txtBusquedaFactura.Text = ""
            grdAnuladas.DataSource = Nothing
            grdAnuladas.DataBind()
            panelbusFact.Visible = True
            panelviewFact.Visible = False
            panelTotal.Visible = False
            panelFacturar.Visible = False
        End Sub

        Public Sub ImprimirFactura(ByVal nCodFactura As Integer)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptFactura"
            rptReporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            rptReporte.ShowParameterPrompts = False
            rptReporte.ShowExportControls = True
            rptReporte.ShowPrintButton = True

            Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport
            ServerReport = rptReporte.ServerReport

            Dim Credentials As System.Net.ICredentials
            Credentials = System.Net.CredentialCache.DefaultCredentials

            Dim cred As New ReportServerCredentials(cUsuario, cClave, ".")
            rptReporte.ServerReport.ReportServerCredentials = cred
            ServerReport.ReportServerUrl = New Uri(cDireccion)
            ServerReport.ReportPath = sUbiNomReporte

            Dim prmCodFac As New Microsoft.Reporting.WebForms.ReportParameter()
            prmCodFac.Name = "nFactura"
            prmCodFac.Values.Add(nCodFactura)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmCodFac}
            ServerReport.SetParameters(parameters)
        End Sub

        Private Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.lbtnPDF_ModalPopupExtender.Hide()
        End Sub
    End Class
End Namespace