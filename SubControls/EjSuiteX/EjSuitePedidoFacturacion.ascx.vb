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


Namespace EjSuite.Modules.EjSuite

    Public Class EjSuitePedidoFacturacion
        Inherits EjSuiteModuleBase

        Dim cCodigoQR As String
        Dim totalCompra As Decimal
        Dim importecredfiscal As Decimal
        Dim importedcto As Decimal

        Private Sub calculaTotal()
            If CInt(txtCantidad.Text) > 0 And VentaControlSearch1.ProductoId <> Nothing Then
                Dim IdProducto As String = VentaControlSearch1.ProductoId
                Dim producto As Producto = producto.FetchByID(IdProducto)
                Dim precio As Double

                If txtDescuento.Text = "" Then
                    txtDescuento.Text = "0,00"
                End If

                Dim descuento As Double = CDec(Replace(txtDescuento.Text, ".", ","))
                descuento = descuento / 100
                Dim precioSuelto As Double = CInt(txtCantidad.Text) * (producto.NPrecioCompra) * (1 - descuento)
                precio = precioSuelto
                lblPrecioUnit.Text = String.Format("{0:F} Bs.", producto.NPrecioCompra)
                lblTotal.Text = String.Format("{0:F} Bs.", precio)
                cmdInsertA.Enabled = True
            Else
                lblTotal.Text = ""
                cmdInsertA.Enabled = False
            End If
        End Sub

        Private Sub GenerarCodigoControl(ByVal aut As Int64, ByVal fac As Int64, ByVal nit As Int64, _
                                         ByVal fecha As Int64, ByVal dd As Double, ByVal monto As Int64, _
                                         ByVal llave As String, ByVal fechalimite As String)
           
            Dim control As String = EjSuite.CargarCodigoControl(aut, fac, nit, fecha, dd, monto, llave, fechalimite)
            lblCodigoControl.Text = control
            ObtenerMontosFactura()

            Dim data As String = EjSuite.ObtenerCodigoBaseQR("594839012", fac, aut, _
                                Now.ToShortDateString(), String.Format("{0:F2}", totalCompra), _
                                String.Format("{0:F2}", importecredfiscal.ToString().Replace(",", ".")), _
                                lblCodigoControl.Text, ClienteControlSearch1.Nit, "0", _
                                "0", "0", importedcto.ToString().Replace(",", "."))
            cCodigoQR = data
            imgQr.ImageUrl = "~/DesktopModules/EjSuite/SubControls/EjSuiteX/CodigoQR.ashx?codigo=" & data
            lblAdvertencia.Text = "ESTA FACTURA CONTRIBUYE AL DESARROLLO DEL PAÍS, EL USO ILÍCITO DE LA MISMA SERÁ SANCIONADO POR LEY"
            lblAdvertencia.Visible = True
            imgQr.Visible = True
        End Sub

        Private Sub ObtenerMontosFactura()
            Dim tabla As DataTable = New DataTable("DetalleVentas")
            tabla = CType(ViewState("gvCompra"), DataTable)

            'Suma Total de toda la compra
            Dim parcial As Decimal = 0D
            Dim suma As Decimal = 0D
            Dim dcto As Decimal = 0D
            For i As Integer = 0 To tabla.Rows.Count - 1
                Dim x As String = tabla.Rows(i).Item(5).ToString()
                parcial = Decimal.Parse(x)
                suma = suma + parcial
            Next

            lbTotalCompra.Text = String.Format("{0:F}", suma)
            tabla = CType(ViewState("gvCompra"), DataTable)
            suma = 0
            For i As Integer = 0 To tabla.Rows.Count - 1
                dcto = CDec(tabla.Rows(i).Item(4))
                tabla.Rows(i).Item(5) = String.Format("{0:F}", CDbl(tabla.Rows(i).Item(5)) * (1 - (dcto / 100)))
                suma = suma + (CDbl(tabla.Rows(i).Item(1)) * CDbl(tabla.Rows(i).Item(3)))
                ViewState("gvCompra") = tabla
            Next
            lbTotalCompra.Text = String.Format("{0:F}", suma)
            totalCompra = suma
            importecredfiscal = suma - (suma * (dcto / 100))
            importedcto = suma * (dcto / 100)
        End Sub

        Private Sub AdicionarProducto(ByVal ProdId As String, ByVal Producto As Producto, ByVal productoNom As String, _
                                         ByVal cantidad As Integer, ByVal objbuscaProd As VWBuscaProducto)
            If (cantidad <= objbuscaProd.NStockActualEnvase) And (objbuscaProd.NStockActualEnvase > 0) Then
                Dim precio As Double
                Dim descuento As Double
                If txtDescuento.Text <> "" Then
                    descuento = CDbl(Replace(txtDescuento.Text, ".", ","))
                Else
                    descuento = 0
                End If
                descuento = CDbl(descuento) / 100

                Dim precioSuelto As Double = Producto.NPrecioCompra * (1 - descuento) * cantidad
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
                    fila("detalle") = Producto.CDetalles
                    fila("punitario") = String.Format("{0:F2}", Producto.NPrecioCompra)
                    fila("descuento") = String.Format("{0:F2}", descuento * 100)
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
                                ntotal = Decimal.Parse(aux) * val1 * (1 - descuento)
                                x = i
                                faltante = False
                            Else
                                EjSuite.Mensaje(Me.upPanel, Me.GetType(), _
                                    String.Format("¡Solo existen: {0} envases en almacen!", objbuscaProd.NStockActualEnvase))
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
                        fila("detalle") = Producto.CDetalles
                        fila("punitario") = String.Format("{0:F2}", Producto.NPrecioCompra)
                        fila("descuento") = String.Format("{0:F2}", descuento * 100)
                        fila("total") = String.Format("{0:F2}", precio)
                        tabla.Rows.Add(fila)
                        ViewState("gvCompra") = tabla
                    ElseIf (encontrado = True AndAlso faltante = False) Then
                        tabla.Rows(x).Item(1) = val1
                        tabla.Rows(x).Item(4) = String.Format("{0:F2}", descuento * 100)
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

                lbTotalCompra.Text = String.Format("{0:F}", suma)
                ViewState("gvCompra") = tabla
                lbTotalCompra.Text = String.Format("{0:F}", suma)

                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()

                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))
                '=================================================================================
                lblError0.Visible = False
                txtCantidad.Text = ""
                txtDescuento.Text = "0,00"
                VentaControlSearch1.TextValue = "Elija un producto"
                VentaControlSearch1.ProductoId = 0
                lblTotal.Text = ""
                lblPrecioUnit.Text = ""
                If (VentaControlSearch1 IsNot Nothing) Then
                    VentaControlSearch1 = Nothing
                End If
                pnlPedido.Visible = True
                panelFacturar.Visible = False
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("¡Solo dispone de: {0} envases en almacen!", _
                 objbuscaProd.NStockActualEnvase))
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Not IsPostBack Then
                    ViewState("gvCompra") = Nothing
                    cmdInsertA.Enabled = False

                    For index As Decimal = 0 To 100
                        txtDescuento.Items.Add(String.Format("{0:F2}", index))
                    Next
                    txtFechaEmision.Text = Now
                    lblAdvertencia.Visible = False
                    imgQr.Visible = False
                    cmdFacturar.Enabled = True

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
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Protected Sub cmdInsertA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA.Click
            Try
                lblError0.Visible = True
                lblError0.Text = ""
                Dim ProdId As String = VentaControlSearch1.ProductoId
                Dim Producto As Producto = Producto.FetchByID(ProdId)
                Try
                    Dim productoNom As String = Producto.CNombreGenerico
                    Dim cantidad As Integer
                    If txtCantidad.Text <> "" Then
                        cantidad = Integer.Parse(txtCantidad.Text)
                    Else
                        cantidad = 0
                    End If
                    Dim objbuscaProd As New VWBuscaProducto(VWBuscaProducto.Columns.NCodProducto, Producto.NCodProducto)
                    AdicionarProducto(ProdId, Producto, productoNom, cantidad, objbuscaProd)

                Catch ex As Exception
                    lblError0.Text = "Falla en la operacion del sistema. " & ex.Message & " Por favor intente de nuevo."
                    lblError0.ForeColor = Drawing.Color.Red
                    lblError0.Visible = True
                End Try
            Catch ex As Exception
                lblError0.Text = "Falla en la operacion del sistema. " & ex.Message & " Por favor intente de nuevo."
                lblError0.ForeColor = Drawing.Color.Red
                lblError0.Visible = True
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
                lbTotalCompra.Text = suma.ToString()
                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))
            Else
                lbTotalCompra.Text = "0,00"
                lblLiteralCompra.Text = EjSuite.ObtenerLiteral(CDec(lbTotalCompra.Text))
            End If
            If CInt(lbTotalCompra.Text) = 0 Then
                pnlPedido.Visible = False
            End If
        End Sub

        Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad.TextChanged
            If txtCantidad.Text = "" Then
                txtCantidad.Text = "0"
            End If

            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Protected Sub cmdFacturacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFacturar.Click
            If grdProductos.Rows.Count > 0 AndAlso ClienteControlSearch1.ClienteId <> Nothing Then
                Using tx As New TransactionScope()
                    Dim q As New Query(SniDatum.Schema)
                    q.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                    q.AddWhere(SniDatum.Columns.DFechaInicio, Comparison.LessOrEquals, Now())
                    Dim lista As New SniDatumCollection
                    lista.LoadAndCloseReader(q.ExecuteReader)

                    If lista.Count > 0 Then
                        Dim idSni As Integer = New [Select](Aggregate.Max(SniDatum.Columns.NCodSNI)). _
                            From(SniDatum.Schema).ExecuteScalar(Of Integer)()
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
                            numeroFactura = objDatoSni.NNroFacturaInicial
                        End If

                        'Nueva Factura
                        Dim objEjSuite As New EjSuite
                        Dim objNewFactura As New Factura
                        objNewFactura.NCodFactura = New [Select](Aggregate.Max(Factura.Columns.NCodFactura)). _
                            From(Factura.Schema).ExecuteScalar(Of Integer)() + 1
                        objNewFactura.NNumero = CDec(numeroFactura)
                        objNewFactura.CNit = ClienteControlSearch1.Nit
                        objNewFactura.CNombreFactura = ClienteControlSearch1.Nombre
                        objNewFactura.CAutorizacion = objDatoSni.CAutorizacion
                        objNewFactura.CCodigoFactura = lblCodigoControl.Text
                        objNewFactura.CLlaveDosificacion = objDatoSni.CLlave
                        objNewFactura.DFechaLimite = Date.Parse(objDatoSni.DFechaFinal.ToShortDateString())
                        objNewFactura.BPendiente = False
                        objNewFactura.BPagada = True
                        objNewFactura.NCodSucursal = CInt(objSucursal.NCodSucursal)
                        objNewFactura.NCodUsuario = CInt(objempleado.NCodUsuario)
                        objNewFactura.DFechaEmision = Now
                        objNewFactura.DVencimiento = Now
                        objNewFactura.BAnulado = False
                        objNewFactura.NCodCliente = ClienteControlSearch1.ClienteId
                        objNewFactura.NCodVendedor = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
                        objNewFactura.Save()

                        For i As Integer = 0 To grdProductos.Rows.Count - 1
                            'Registro de todos los productos de la factura en Detalle
                            Dim idProducto As String = grdProductos.Rows(i).Cells(0).Text
                            Dim idFactur As String = objNewFactura.NNumero
                            Dim cantidad As Integer = Integer.Parse(grdProductos.Rows(i).Cells(2).Text)
                            Dim precioU As Decimal = Decimal.Parse(grdProductos.Rows(i).Cells(3).Text)
                            Dim descuento As Decimal = Decimal.Parse(grdProductos.Rows(i).Cells(4).Text)
                            Dim objNewDetalle As Detalle = New Detalle()
                            objNewDetalle.NCodDetalle = New [Select](Aggregate.Max(Detalle.Columns.NCodDetalle)). _
                                From(Detalle.Schema).ExecuteScalar(Of Integer)() + 1
                            objNewDetalle.NCodProducto = CType(idProducto, String)
                            objNewDetalle.NcodFactura = objNewFactura.NCodFactura
                            objNewDetalle.NCantidad = cantidad
                            objNewDetalle.NPrecioUnitario = precioU
                            objNewDetalle.BUnidad = False
                            objNewDetalle.NDescuento = descuento
                            objNewDetalle.Save()

                            'Registro de todos los productos de la factura en kardex
                            Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)
                            Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
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
                            objNewKardex.CObservacion = "Venta: Factura No " & objNewFactura.NNumero
                            objNewKardex.NPrecioCompra = precioU

                            Dim auxa As Integer = 0, auxb As Integer = 0, auxc As Integer = 0, auxd As Integer = 0
                            If objAuxKardex.NStockActualReintegro > 0 Then
                                If cantidad <= objAuxKardex.NStockActualReintegro Then
                                    objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro - cantidad
                                    objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockAnteriorSuelto = 0
                                    objNewKardex.NStockActualSuelto = 0
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = cantidad
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0
                                Else
                                    auxa = cantidad - objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro - auxa
                                    objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockAnteriorSuelto = 0
                                    objNewKardex.NStockActualSuelto = 0
                                    auxb = cantidad - auxa
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = auxa
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0

                                    If objAuxKardex.NStockActualBonificacion > 0 Then
                                        If auxb <= objAuxKardex.NStockActualBonificacion Then
                                            objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                            objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion - auxb
                                            objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockAnteriorSuelto = 0
                                            objNewKardex.NStockActualSuelto = 0
                                            objNewKardex.NEntrada = 0
                                            objNewKardex.NSalida = 0
                                            objNewKardex.NEntradaSueltos = 0
                                            objNewKardex.NSalidaSueltos = 0
                                            objNewKardex.NEntradaBonificacion = 0
                                            objNewKardex.NSalidaBonificacion = auxb
                                        Else
                                            auxc = auxb - objAuxKardex.NStockActualBonificacion
                                            objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                            objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion - auxc
                                            objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockAnteriorSuelto = 0
                                            objNewKardex.NStockActualSuelto = 0
                                            auxd = auxb - auxc
                                            objNewKardex.NEntrada = 0
                                            objNewKardex.NSalida = 0
                                            objNewKardex.NEntradaSueltos = 0
                                            objNewKardex.NSalidaSueltos = 0
                                            objNewKardex.NEntradaBonificacion = 0
                                            objNewKardex.NSalidaBonificacion = auxc
                                            If objAuxKardex.NStockActualEnvase > 0 Then
                                                If auxd <= objAuxKardex.NStockActualEnvase Then
                                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - auxd
                                                    objNewKardex.NStockAnteriorSuelto = 0
                                                    objNewKardex.NStockActualSuelto = 0
                                                    objNewKardex.NEntrada = 0
                                                    objNewKardex.NSalida = auxd
                                                    objNewKardex.NEntradaSueltos = 0
                                                    objNewKardex.NSalidaSueltos = 0
                                                End If
                                            End If
                                        End If
                                    Else
                                        If objAuxKardex.NStockActualEnvase > 0 Then
                                            If auxb <= objAuxKardex.NStockActualEnvase Then
                                                objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                                objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                                objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                                objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - auxb
                                                objNewKardex.NStockAnteriorSuelto = 0
                                                objNewKardex.NStockActualSuelto = 0
                                                objNewKardex.NEntrada = 0
                                                objNewKardex.NSalida = auxb
                                                objNewKardex.NEntradaSueltos = 0
                                                objNewKardex.NSalidaSueltos = 0
                                                objNewKardex.NEntradaBonificacion = 0
                                                objNewKardex.NSalidaBonificacion = 0
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                If objAuxKardex.NStockActualBonificacion > 0 Then
                                    If cantidad <= objAuxKardex.NStockActualBonificacion Then
                                        objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                        objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro
                                        objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                        objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion - cantidad
                                        objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                        objNewKardex.NStockAnteriorSuelto = 0
                                        objNewKardex.NStockActualSuelto = 0
                                        objNewKardex.NEntrada = 0
                                        objNewKardex.NSalida = 0
                                        objNewKardex.NEntradaSueltos = 0
                                        objNewKardex.NSalidaSueltos = 0
                                        objNewKardex.NEntradaReintegro = 0
                                        objNewKardex.NSalidaReintegro = 0
                                        objNewKardex.NEntradaBonificacion = 0
                                        objNewKardex.NSalidaBonificacion = cantidad
                                    Else
                                        auxa = cantidad - objAuxKardex.NStockActualBonificacion
                                        objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualBonificacion
                                        objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro
                                        objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                        objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion - auxa
                                        objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                        objNewKardex.NStockAnteriorSuelto = 0
                                        objNewKardex.NStockActualSuelto = 0
                                        auxb = cantidad - auxa
                                        objNewKardex.NEntrada = 0
                                        objNewKardex.NSalida = 0
                                        objNewKardex.NEntradaSueltos = 0
                                        objNewKardex.NSalidaSueltos = 0
                                        objNewKardex.NEntradaReintegro = 0
                                        objNewKardex.NSalidaReintegro = 0
                                        objNewKardex.NEntradaBonificacion = 0
                                        objNewKardex.NSalidaBonificacion = auxa
                                        If auxb <= objAuxKardex.NStockActualEnvase Then
                                            objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - auxb
                                            objNewKardex.NStockAnteriorSuelto = 0
                                            objNewKardex.NStockActualSuelto = 0
                                            objNewKardex.NEntrada = 0
                                            objNewKardex.NSalida = auxb
                                            objNewKardex.NEntradaSueltos = 0
                                            objNewKardex.NSalidaSueltos = 0
                                        End If

                                    End If
                                Else
                                    If objAuxKardex.NStockActualEnvase > 0 Then
                                        If cantidad <= objAuxKardex.NStockActualEnvase Then
                                            objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                            objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - cantidad
                                            objNewKardex.NStockAnteriorSuelto = 0
                                            objNewKardex.NStockActualSuelto = 0
                                            objNewKardex.NEntrada = 0
                                            objNewKardex.NSalida = cantidad
                                            objNewKardex.NEntradaSueltos = 0
                                            objNewKardex.NSalidaSueltos = 0
                                            objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                            objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro
                                            objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                            objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                            objNewKardex.NEntradaReintegro = 0
                                            objNewKardex.NSalidaReintegro = 0
                                            objNewKardex.NEntradaBonificacion = 0
                                            objNewKardex.NSalidaBonificacion = 0
                                        End If
                                    End If
                                End If
                            End If

                            objNewKardex.NPrecioVenta = CDec(lbTotalCompra.Text)
                            objNewKardex.CGlosa = "Venta de Productos"
                            objNewKardex.NPrecioAlmacen = 0
                            objNewKardex.NPrecioCompra = 0
                            objNewKardex.NCodKardex = New [Select](Aggregate.Max(KardexInventario.Columns.NCodKardex)). _
                                From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                            objNewKardex.Save()
                        Next
                        panelFacturar.Visible = True

                        'Generacion del codigo de control
                        Try
                            Dim total As String = (lbTotalCompra.Text)
                            Dim qry As New Query(SniDatum.Schema)
                            qry.AddWhere(SniDatum.Columns.DFechaFinal, Comparison.GreaterOrEquals, Now())
                            Dim lst As New SniDatumCollection
                            lst.LoadAndCloseReader(qry.ExecuteReader)
                            If lst.Count > 0 Then
                                For Each objsni As SniDatum In lst
                                    Dim llave As String = objsni.CLlave
                                    Dim aut As Int64 = Int64.Parse(objsni.CAutorizacion)
                                    Dim fac As Int64 = Int64.Parse(objNewFactura.NNumero)
                                    Dim nit1 As Int64 = Int64.Parse(objNewFactura.CNit)
                                    Dim fechaest As String = txtFechaEmision.Text.Substring(6, 4) 'Now().Date.Year.ToString
                                    fechaest &= txtFechaEmision.Text.Substring(3, 2)
                                    fechaest &= txtFechaEmision.Text.Substring(0, 2)
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
                                    GenerarCodigoControl(aut, fac, nit1, fecha, dd, monto, llave, objDatoSni.DFechaFinal)
                                Next
                            End If
                        Catch ex As Exception

                        End Try
                        Dim objFacturaAux As New Factura(objNewFactura.NCodFactura)
                        ViewState("FNumero") = objNewFactura.NNumero
                        Dim aux As String = txtFechaEmision.Text
                        aux = String.Format("{0}-{1}-{2}", aux.Substring(6, 4), aux.Substring(3, 2), aux.Substring(0, 2))
                        Dim aux1 As String = aux
                        objFacturaAux.DFechaEmision = aux
                        objFacturaAux.CCodigoFactura = lblCodigoControl.Text
                        objFacturaAux.CValorQR = cCodigoQR

                        Dim NroCuenta As Integer = New [Select](Aggregate.Max(Factura.Columns.NCodCuenta)). _
                                    From(Factura.Schema).ExecuteScalar(Of Integer)()

                        If NroCuenta <> 0 Then
                            objFacturaAux.NCodCuenta = NroCuenta + 1
                        Else
                            objFacturaAux.NCodCuenta = 10000
                        End If
                        objFacturaAux.Save()
                    Else
                        'Dim objsni As New Snidatum(idSni)
                        'objsni.Facturainicial = 0
                    End If
                    tx.Complete()
                End Using
                cmdFacturar.Enabled = False
                lbtnPDF.Visible = True

                Const friendlyName As String = "EjSuite"
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=Pedfacturacion"

                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                ImprimirFactura(CType(ViewState("FNumero").ToString(), Integer))
                lblRes.Text = "Venta almacenada, puede finalizar el Pedido <a href='" & urlDoc & "'>Haga click aqui </a>"
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Seleccione un cliente!")
            End If
        End Sub

        Protected Sub txtDescuento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDescuento.SelectedIndexChanged
            If txtDescuento.SelectedIndex > -1 Then
                calculaTotal()
            End If
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

        Protected Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.lbtnPDF_ModalPopupExtender.Hide()
        End Sub

        Protected Sub lbtnPDF_Click(sender As Object, e As EventArgs) Handles lbtnPDF.Click
            Me.lbtnPDF_ModalPopupExtender.Show()
        End Sub
    End Class
End Namespace