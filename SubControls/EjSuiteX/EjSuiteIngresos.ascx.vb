Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Services.Personalization
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.Transactions
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteIngresos
        Inherits EjSuiteModuleBase

        'Dim Mode As DisplayMode = DisplayMode.Normal
        Dim bImprimirAuto As Boolean = False
        Dim bCerrarAuto As Boolean = False

        Dim nEstadoRec As Integer
        Dim nTipoImp As Integer
        Dim ServerReportRec As Microsoft.Reporting.WebForms.ServerReport
        Dim cNumFactura As String = ""

        Public Enum nTipoProducto
            Clasico = 1
            Cuotas = 2
        End Enum

        Private Sub CargarLote()
            Dim q As SqlQuery = New [Select]("nCodLote, EJS_Producto.nCodProducto, cComprobanteRecibo, cNombreGenerico, cNombreComercial, nTotalEnvases, nTotalSueltos"). _
                From(Lote.Schema).InnerJoin(Producto.Schema). _
                Where(Producto.Columns.CNombreGenerico).Like(String.Format("%{0}%", txtBuscarLote.Text.Trim())). _
                Or(Producto.Columns.CNombreComercial).Like(String.Format("%{0}%", txtBuscarLote.Text.Trim())). _
                Or(Lote.Columns.CComprobanteRecibo).Like(String.Format("%{0}%", txtBuscarLote.Text.Trim()))

            Dim ds As New DataSet
            ds = q.ExecuteDataSet
            grdBusquedaLotes.DataSource = ds.Tables(0).DefaultView
            grdBusquedaLotes.DataKeyNames() = New String() {Lote.Columns.NCodLote}
            grdBusquedaLotes.DataBind()
            lblMessageLote.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            panelbusLote.Visible = True
            ds = Nothing
        End Sub

        Private Sub inicializar()
            ProductoControlSearch1.TextValue = "Elija un Producto"
            txtComprobanteLote.Text = ""
            txtFacturaLote.Text = ""
            ddlFormapagoLote.SelectedIndex = 0
            txtFechaingresoLote.Text = ""
            txtFechavctoLote.Text = ""
            txtTotalenvasesLote.Text = ""
            txtObservacionesLote.Text = "Lote: "

            txtBuscarLote.Text = ""
            lblMessageLote.Text = ""
            txtTotalenvasesLote1.Text = ""
            txtObservacionesLote1.Text = ""
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarLote.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarLote.ClientID))
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoLote.Visible = False
                pnlBusquedaLote.Visible = False
                lbtnPDF.Visible = False
                Page.EnableViewState = True
                inicializar()
            End If
        End Sub

        Protected Sub lbtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAdd.Click
            Try
                Dim id As String = ProductoControlSearch1.ProductoId
                Dim objProducto As New Producto(id)
                lbtnAdd.Enabled = True
                Try
                    Dim ProdId As String = ProductoControlSearch1.ProductoId
                    Dim comprob As String = txtComprobanteLote.Text
                    Dim factura As String = txtFacturaLote.Text
                    ViewState("cNumFactura") = txtFacturaLote.Text
                    
                    Dim formapago As String = ddlFormapagoLote.SelectedItem.ToString()
                    Dim feching As Date = CType(txtFechaingresoLote.Text, Date)
                    Dim fechvcto As Date
                    If txtFechavctoLote.Text = "" Then
                        fechvcto = Date.MaxValue
                    Else
                        fechvcto = CType(txtFechavctoLote.Text, Date)
                    End If
                    Dim precioant As Decimal = objProducto.NPrecioCompra
                    Dim precioact As Decimal = objProducto.NPrecioCompra
                    Dim estado As String = rbtEstadoLote.SelectedItem.ToString()
                    Dim totenvases As Integer = CType(txtTotalenvasesLote.Text, Integer)
                    Const totsueltos As Integer = 0
                    Dim observac As String
                    If txtObservacionesLote.Text <> "" Then
                        observac = txtObservacionesLote.Text
                    Else
                        observac = Nothing
                    End If
                    Dim tabla As DataTable = New DataTable("DetalleLotes")
                    'Usamos un ViewState para guardar los datos
                    If (ViewState("gvLote") Is Nothing) Then
                        ' Crea un DataTable.
                        Dim col1 As DataColumn = New DataColumn() With {.AllowDBNull = True, .Caption = "Id Prod.", .ColumnName = "nCodProducto", .DefaultValue = ""}
                        tabla.Columns.Add(col1)
                        Dim col2 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Comprobante", .ColumnName = "cComprobanteRecibo", .DefaultValue = ""}
                        tabla.Columns.Add(col2)
                        Dim col3 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Factura", .ColumnName = "cNumeroFactura", .DefaultValue = ""}
                        tabla.Columns.Add(col3)
                        Dim col4 As DataColumn = New DataColumn() With {.AllowDBNull = True, .Caption = "Tipo de Compra", .ColumnName = "cFormaPago", .DefaultValue = ""}
                        tabla.Columns.Add(col4)
                        Dim col5 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "F. Ingreso", .ColumnName = "dFechaIngreso", .DefaultValue = 0}
                        tabla.Columns.Add(col5)
                        Dim col6 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "F. Vcto.", .ColumnName = "dFechaVencimiento", .DefaultValue = 0}
                        tabla.Columns.Add(col6)
                        Dim col7 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Precio Anterior Envase", .ColumnName = "nPrecioAnteriorEnvase", .DefaultValue = 0}
                        tabla.Columns.Add(col7)
                        Dim col8 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Precio Actual Envase", .ColumnName = "nPrecioActualEnvase", .DefaultValue = 0}
                        tabla.Columns.Add(col8)
                        Dim col9 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Estado Lote", .ColumnName = "bEstadoLote", .DefaultValue = True}
                        tabla.Columns.Add(col9)
                        Dim col10 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Total Envases", .ColumnName = "nTotalEnvases", .DefaultValue = 0}
                        tabla.Columns.Add(col10)
                        Dim col11 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Total Sueltos", .ColumnName = "nTotalSueltos", .DefaultValue = 0}
                        tabla.Columns.Add(col11)
                        Dim col12 As DataColumn = New DataColumn() With {.AllowDBNull = True, .Caption = "Observaciones", .ColumnName = "cObservaciones", .DefaultValue = ""}
                        tabla.Columns.Add(col12)

                        'Dim PrimaryKeyColumns(1) As DataColumn
                        'PrimaryKeyColumns(0) = tabla.Columns("id")
                        'tabla.PrimaryKey = PrimaryKeyColumns

                        'Adicionar una fila
                        Dim fila As DataRow = tabla.NewRow()
                        fila("nCodProducto") = ProdId
                        fila("cComprobanteRecibo") = comprob
                        fila("cNumeroFactura") = factura
                        fila("cFormaPago") = formapago
                        fila("dFechaIngreso") = feching
                        fila("dFechaVencimiento") = fechvcto
                        fila("nPrecioAnteriorEnvase") = precioant
                        fila("nPrecioActualEnvase") = precioact
                        fila("bEstadoLote") = estado
                        fila("nTotalEnvases") = totenvases
                        fila("nTotalSueltos") = totsueltos
                        fila("cObservaciones") = observac
                        tabla.Rows.Add(fila)
                        ViewState("gvLote") = tabla
                    Else
                        Dim encontrado As Boolean = False
                        Const totenvases1 As Integer = 0
                        Const totsueltos1 As Integer = 0
                        Const x As Integer = 0
                        'Comprobamos si hay nuevos productos en la lista
                        'For i As Integer = 0 To grdLotes.Rows.Count - 1
                        '    If (grdLotes.Rows(i).Cells(0).Text = ProdId) Then
                        '        encontrado = True
                        '        aux = grdLotes.Rows(i).Cells(7).Text
                        '        totenvases1 = Integer.Parse(aux) + totenvases
                        '        aux = grdLotes.Rows(i).Cells(10).Text
                        '        totsueltos1 = Integer.Parse(aux) + totsueltos
                        '        x = i
                        '    End If
                        'Next
                        tabla = CType(ViewState("gvLote"), DataTable)
                        If (encontrado = False) Then
                            Dim fila As DataRow = tabla.NewRow()
                            fila("nCodProducto") = ProdId
                            fila("cComprobanteRecibo") = comprob
                            fila("cNumeroFactura") = factura
                            fila("cFormaPago") = formapago
                            fila("dFechaIngreso") = feching
                            fila("dFechaVencimiento") = fechvcto
                            fila("nPrecioAnteriorEnvase") = precioant
                            fila("nPrecioActualEnvase") = precioact
                            fila("bEstadoLote") = estado
                            fila("nTotalEnvases") = totenvases
                            fila("nTotalSueltos") = totsueltos
                            fila("cObservaciones") = observac
                            tabla.Rows.Add(fila)
                            ViewState("gvLote") = tabla
                        Else
                            tabla.Rows(x).Item(9) = totenvases1
                            tabla.Rows(x).Item(10) = totsueltos1
                            ViewState("gvLote") = tabla
                        End If
                    End If

                    grdLotes.DataSource = tabla.DefaultView
                    grdLotes.DataKeyNames() = New String() {"nCodProducto"}
                    grdLotes.DataBind()

                    inicializar()
                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Producto inexistente!")
                End Try
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Producto inexistente!")
                lbtnAdd.Enabled = False
            End Try
        End Sub

        Protected Sub lbtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnCancelar.Click
            'ProductoPrecioBase1.TextValue = ""
            'ProductoPrecioBase1.TextValuePrecio = ""
            txtComprobanteLote.Text = ""
            txtFacturaLote.Text = ""
            txtFechaingresoLote.Text = ""
            txtFechavctoLote.Text = ""
            'txtPrecioanteriorenvaseLote.Text = ""
            'txtPrecioactualenvaseLote.Text = ""
            txtTotalenvasesLote.Text = ""
            'txtTotalSueltosLote.Text = ""
            txtObservacionesLote.Text = ""

            pnlNuevoLote.Visible = False
            pnlBusquedaLote.Visible = False
            lbtnPDF.Visible = False
        End Sub

        Protected Sub lbtnIngresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnIngresar.Click
            If grdLotes.Rows.Count > 0 Then
                Using tx As New TransactionScope()
                    Dim dtLote As New DataTable()
                    dtLote = CType(ViewState("gvLote"), DataTable)

                    For index = 0 To dtLote.Rows.Count - 1
                        Dim objNewLote As New Lote
                        objNewLote.NCodLote = New [Select](Aggregate.Max(Lote.Columns.NCodLote)).From(Lote.Schema).ExecuteScalar(Of String)() + 1
                        objNewLote.NCodProducto = dtLote.Rows(index).Item(0).ToString
                        objNewLote.CComprobanteRecibo = dtLote.Rows(index).Item(1).ToString
                        objNewLote.CNumeroFactura = dtLote.Rows(index).Item(2).ToString
                        objNewLote.CFormaPago = dtLote.Rows(index).Item(3).ToString
                        objNewLote.DFechaIngreso = CType(dtLote.Rows(index).Item(4), Date)
                        objNewLote.DFechaVencimiento = CType(dtLote.Rows(index).Item(5), Date)
                        objNewLote.NPrecioAnteriorEnvase = CType(dtLote.Rows(index).Item(6), Decimal)
                        objNewLote.NPrecioActualEnvase = CType(dtLote.Rows(index).Item(7), Decimal)
                        objNewLote.CTipo = dtLote.Rows(index).Item(3).ToString

                        If objNewLote.CTipo = "Contado" Then
                            objNewLote.NCostoUnidad = Decimal.Parse(String.Format("{0:F}", objNewLote.NPrecioActualEnvase * 0.72999999999999998))
                        Else
                            objNewLote.NCostoUnidad = 0.0
                        End If

                        Dim estado As String = dtLote.Rows(index).Item(8).ToString
                        If estado = "Existente" Then
                            objNewLote.BEstadoLote = True
                        Else
                            objNewLote.BEstadoLote = False
                        End If
                        objNewLote.NTotalEnvases = CType(dtLote.Rows(index).Item(9), Integer)
                        objNewLote.NTotalSueltos = CType(dtLote.Rows(index).Item(10), Integer)
                        objNewLote.CObservaciones = dtLote.Rows(index).Item(11).ToString

                        objNewLote.Save()

                        'Para actualizar el precio en Producto:
                        'Dim objProducto As New Producto(objNewLote.Productoid)
                        'objProducto.Preciocompra = objNewLote.Precioactualenvase
                        'objProducto.Save(
                        'Verificar si el usuario esta registrado como jefe de almacen
                        Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                        Dim qry As SqlQuery = New [Select]("nCodEmpleado, nCodUsuario, nCodEmpleadoSucursal, EJS_Sucursal.nCodSucursal, nCodAlmacen, nCodJefeAlmacen"). _
                            From(Empleado.Schema). _
                            InnerJoin(EmpleadoSucursal.NCodEmpleadoColumn, Empleado.NCodEmpleadoColumn). _
                            InnerJoin(Sucursal.NCodSucursalColumn, EmpleadoSucursal.NCodSucursalColumn). _
                            InnerJoin(Almacen.NCodSucursalColumn, Sucursal.NCodSucursalColumn). _
                            Where(Empleado.Columns.NCodUsuario).IsEqualTo(Usrid)

                        Dim ds As New DataSet
                        ds = qry.ExecuteDataSet
                        Dim AlmacnId As Integer
                        If ds.Tables(0).Rows.Count > 0 Then
                            Dim dr As DataRow = ds.Tables(0).Rows(0)
                            AlmacnId = CType(dr(4), Integer)
                        Else
                            If UserController.Instance.GetCurrentUserInfo().IsSuperUser() Then
                                AlmacnId = 1
                            Else
                                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Usuario no asignado para realizar esta operacion!")
                            End If
                        End If
                        '=====================================================================================================
                        Dim LoteId As Integer = New [Select](Aggregate.Max("nCodLote")). _
                                From(Lote.Schema).ExecuteScalar(Of Integer)()
                        '=====================================================================================================
                        Dim q As New Query(KardexInventario.Schema)
                        q.AddWhere(KardexInventario.Columns.NCodProducto, objNewLote.NCodProducto)
                        q.AND(KardexInventario.Columns.NCodAlmacen, AlmacnId)
                        Dim lst As New KardexInventarioCollection()
                        lst.LoadAndCloseReader(q.ExecuteReader())
                        '=====================================================================================================
                        Dim objNewKardex As New KardexInventario
                        If lst.Count > 0 Then
                            Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                                From(KardexInventario.Schema). _
                                Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                                And(KardexInventario.NCodProductoColumn).IsEqualTo(objNewLote.NCodProducto). _
                                ExecuteScalar(Of Integer)()
                            Dim objAuxKardex As New KardexInventario(kardexId)
                            objNewKardex.NCodAlmacen = AlmacnId
                            objNewKardex.NCodLote = LoteId
                            objNewKardex.NCodProducto = objNewLote.NCodProducto
                            objNewKardex.DFechareg = objNewLote.DFechaIngreso
                            If objNewLote.BEstadoLote Then
                                objNewKardex.CObservacion = "Nota de Remisión/Factura"
                            Else
                                objNewKardex.CObservacion = "Factura de Venta"
                            End If

                            objNewKardex.NPrecioCompra = objNewLote.NCostoUnidad

                            Select Case objNewLote.CTipo
                                Case "Contado"
                                    objNewKardex.NEntrada = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = CType(objNewLote.NTotalSueltos, Integer)
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase + CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NStockAnteriorSuelto = objAuxKardex.NStockActualSuelto
                                    objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto + CType(objNewLote.NTotalSueltos, Integer)
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro
                                Case "Bonificado"
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockAnteriorSuelto = objAuxKardex.NStockActualSuelto
                                    objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto
                                    objNewKardex.NEntradaBonificacion = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion + CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro
                                Case "Reintegrado"
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase
                                    objNewKardex.NStockAnteriorSuelto = objAuxKardex.NStockActualSuelto
                                    objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockActualBonificacion = objAuxKardex.NStockActualBonificacion
                                    objNewKardex.NStockAnteriorReintegro = objAuxKardex.NStockActualReintegro
                                    objNewKardex.NStockActualReintegro = objAuxKardex.NStockActualReintegro + CType(objNewLote.NTotalEnvases, Integer)
                                Case Else
                                    Exit Select
                            End Select

                            objNewKardex.NCostoTotal = objNewLote.NPrecioActualEnvase * objNewLote.NTotalEnvases
                            If objNewLote.CObservaciones <> "" Then
                                objNewKardex.CGlosa = String.Format("Compra de Producto a {0}{1}", objNewLote.CTipo, objNewLote.CObservaciones)
                            End If
                            objNewKardex.NPrecioAlmacen = objNewLote.NCostoUnidad
                            objNewKardex.NPrecioVenta = objNewLote.NPrecioActualEnvase
                            objNewKardex.NCodKardex = New [Select](Aggregate.Max("nCodKardex")).From(KardexInventario.Schema). _
                                ExecuteScalar(Of Integer)() + 1
                            objNewKardex.Save()
                        Else
                            objNewKardex.NCodAlmacen = AlmacnId
                            objNewKardex.NCodLote = LoteId
                            objNewKardex.NCodProducto = objNewLote.NCodProducto
                            objNewKardex.DFechareg = objNewLote.DFechaIngreso

                            If objNewLote.BEstadoLote Then
                                objNewKardex.CObservacion = "Nota de Remisión/Factura"
                            Else
                                objNewKardex.CObservacion = "Factura de Venta"
                            End If
                            objNewKardex.NPrecioCompra = objNewLote.NPrecioActualEnvase

                            Select Case objNewLote.CTipo
                                Case "Contado"
                                    objNewKardex.NEntrada = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = CType(objNewLote.NTotalSueltos, Integer)
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = 0
                                    objNewKardex.NStockActualEnvase = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NStockAnteriorSuelto = 0
                                    objNewKardex.NStockActualSuelto = CType(objNewLote.NTotalSueltos, Integer)
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = 0
                                    objNewKardex.NStockActualBonificacion = 0
                                    objNewKardex.NStockAnteriorReintegro = 0
                                    objNewKardex.NStockActualReintegro = 0
                                Case "Bonificado"
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = 0
                                    objNewKardex.NStockActualEnvase = 0
                                    objNewKardex.NStockAnteriorSuelto = 0
                                    objNewKardex.NStockActualSuelto = 0
                                    objNewKardex.NEntradaBonificacion = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = 0
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = 0
                                    objNewKardex.NStockActualBonificacion = CType(objNewLote.NTotalEnvases, Integer)
                                    objNewKardex.NStockAnteriorReintegro = 0
                                    objNewKardex.NStockActualReintegro = 0
                                Case "Reintegro"
                                    objNewKardex.NEntrada = 0
                                    objNewKardex.NSalida = 0
                                    objNewKardex.NEntradaSueltos = 0
                                    objNewKardex.NSalidaSueltos = 0
                                    objNewKardex.NStockAnteriorEnvase = 0
                                    objNewKardex.NStockActualEnvase = 0
                                    objNewKardex.NStockAnteriorSuelto = 0
                                    objNewKardex.NStockActualSuelto = 0
                                    objNewKardex.NEntradaBonificacion = 0
                                    objNewKardex.NSalidaBonificacion = 0
                                    objNewKardex.NEntradaReintegro = CType(objNewLote.NTotalSueltos, Integer)
                                    objNewKardex.NSalidaReintegro = 0
                                    objNewKardex.NStockAnteriorBonificacion = 0
                                    objNewKardex.NStockActualBonificacion = 0
                                    objNewKardex.NStockAnteriorReintegro = 0
                                    objNewKardex.NStockActualReintegro = CType(objNewLote.NTotalSueltos, Integer)
                                Case Else
                                    Exit Select
                            End Select

                            objNewKardex.NCostoTotal = objNewLote.NPrecioActualEnvase * objNewLote.NTotalEnvases
                            If objNewLote.CObservaciones <> "" Then
                                objNewKardex.CGlosa = objNewLote.CObservaciones
                            End If
                            objNewKardex.NPrecioAlmacen = objNewLote.NCostoUnidad
                            objNewKardex.NPrecioVenta = objNewLote.NPrecioActualEnvase
                            objNewKardex.NCodKardex = New [Select](Aggregate.Max("nCodKardex")).From(KardexInventario.Schema). _
                                ExecuteScalar(Of Integer)() + 1
                            objNewKardex.Save()
                        End If
                    Next
                    pnlNuevoLote.Visible = False
                    pnlBusquedaLote.Visible = False
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Lote Completo registrado exitosamente!")
                    'ViewState("gvLote") = Nothing
                    lbtnPDF.Visible = True
                    tx.Complete()
                End Using
                'grdBusquedaLotes.DataSource = Nothing
                'grdBusquedaLotes.DataBind()
                'grdLotes.DataSource = Nothing
                'grdLotes.DataBind()
            End If
            cNumFactura = ViewState("cNumFactura").ToString()
            'EjSuite.Mensaje(Me.upPanel, Me.GetType(),"" & cNumFactura & "")
            GenerarIngresoAlmacen(cNumFactura)
            inicializar()
        End Sub

        Protected Sub grdLotes_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdLotes.RowDeleting
            Dim indice As Integer = e.RowIndex
            Dim tabla As DataTable = New DataTable("DetalleLotes")
            If (grdLotes.Rows.Count > 0 And ViewState("gvLote") IsNot Nothing) Then
                tabla = CType(ViewState("gvLote"), DataTable)
                tabla.Rows(indice).Delete()
                grdLotes.DataSource = tabla.DefaultView
                grdLotes.DataKeyNames() = New String() {"nCodProducto"}
                grdLotes.DataBind()
            End If
        End Sub

        Protected Sub grdLotes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdLotes.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim tabla As DataTable = New DataTable("DetalleLotes")
                    tabla = CType(ViewState("gvLote"), DataTable)
                    Dim dr As DataRow = tabla.Rows(indice)
                    Dim hypLote1 As Label = CType(e.Row.Cells(4).Controls(0), Label)
                    Dim fechaing As Date = CType(dr(4), Date)
                    hypLote1.Text = fechaing.ToShortDateString()
                    Dim hypLote2 As Label = CType(e.Row.Cells(5).Controls(0), Label)
                    Dim fechavct As Date = CType(dr(5), Date)
                    hypLote2.Text = fechavct.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdLotes_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdLotes.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypLote1 As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(4).Controls.Add(hypLote1)
                    Dim hypLote2 As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(5).Controls.Add(hypLote2)
            End Select
        End Sub

        Protected Sub btnBuscarLote_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarLote.Click
            CargarLote()
        End Sub

        Protected Sub grdBusquedaLotes_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdBusquedaLotes.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdBusquedaLotes.PageIndex = indice
            CargarLote()
        End Sub

        Protected Sub grdBusquedaLotes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBusquedaLotes.SelectedIndexChanged
            If grdBusquedaLotes.SelectedIndex > -1 Then
                Dim indice As Integer = grdBusquedaLotes.SelectedIndex
                Dim id As Integer = CType(grdBusquedaLotes.DataKeys(indice).Value, Integer)
                ViewState("lid") = id.ToString()
                Dim objLote As New Lote(id)
                Dim objProducto As New Producto(objLote.NCodProducto)
                hfProductoidLote1.Value = objProducto.NCodProducto.ToString()
                lblProductoidLote1.Text = String.Format("{0} - {1}", objProducto.NCodProducto, objProducto.CNombreGenerico)
                lblComprobanteLote1.Text = objLote.CComprobanteRecibo
                lblFacturaLote1.Text = objLote.CNumeroFactura
                ddlFormapagoLote1.Text = objLote.CTipo
                lblFechaingresoLote1.Text = objLote.DFechaIngreso.ToShortDateString()
                lblFechavctoLote1.Text = objLote.DFechaVencimiento.ToShortDateString()
                'lblPrecioanteriorenvaseLote1.Text = String.Format("{0:F}", objLote.Precioanteriorenvase)
                'lblPrecioactualenvaseLote1.Text = String.Format("{0:F}", objLote.Precioactualenvase)
                If objLote.BEstadoLote Then
                    lblEstadoLote1.Text = "Existente"
                Else
                    lblEstadoLote1.Text = "Vendido/Dado de baja"
                End If
                txtTotalenvasesLote1.Text = objLote.NTotalEnvases.ToString()
                ViewState("totenvasesant") = objLote.NTotalEnvases
                'txtTotalSueltosLote1.Text = objLote.Totalsueltos.ToString
                ViewState("totsueltosant") = objLote.NTotalSueltos
                txtObservacionesLote1.Text = objLote.CObservaciones

                txtBuscarLote.Text = ""
                panelbusLote.Visible = False
                panelviewLote.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateLote_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateLote.Click
            If ViewState("lid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As Integer = CType(ViewState("lid"), Integer)
                Dim objLote As New Lote(id)
                objLote.NCodProducto = CType(hfProductoidLote1.Value, String)
                objLote.CComprobanteRecibo = lblComprobanteLote1.Text
                objLote.CNumeroFactura = lblFacturaLote1.Text
                objLote.CTipo = ddlFormapagoLote1.Text
                objLote.DFechaIngreso = CType(lblFechaingresoLote1.Text, Date)
                objLote.DFechaVencimiento = CType(lblFechavctoLote1.Text, Date)
                'objLote.Precioanteriorenvase = CType(lblPrecioanteriorenvaseLote1.Text, Decimal)
                'objLote.Precioactualenvase = CType(lblPrecioactualenvaseLote1.Text, Decimal)
                If lblEstadoLote1.Text = "Existente" Then
                    objLote.BEstadoLote = True
                Else
                    objLote.BEstadoLote = False
                End If

                objLote.NTotalEnvases = CType(txtTotalenvasesLote1.Text, Decimal)
                'objLote.Totalsueltos = CType(txtTotalSueltosLote1.Text, Decimal)
                objLote.CObservaciones = txtObservacionesLote1.Text
                objLote.Save()
                '=====================================================================================================
                Dim totenvasesant As Integer = CType(ViewState("totenvasesant"), Integer)
                Dim totsueltosant As Integer = CType(ViewState("totsueltosant"), Integer)
                '=====================================================================================================
                Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                'Dim objEmpleado As New Empleado(Empleado.Columns.Userid, Usrid)
                Dim qry As SqlQuery = New [Select]("nCodEmpleado, nCodUsuario, nCodEmpleadoSucursal, EJS_Sucursal.nCodSucursal, nCodAlmacen, nCodJefeAlmacen"). _
                    From(Empleado.Schema). _
                    InnerJoin(EmpleadoSucursal.NCodEmpleadoColumn, Empleado.NCodEmpleadoColumn). _
                    InnerJoin(Sucursal.NCodSucursalColumn, EmpleadoSucursal.NCodSucursalColumn). _
                    InnerJoin(Almacen.NCodSucursalColumn, Sucursal.NCodSucursalColumn). _
                    Where(Empleado.Columns.NCodUsuario).IsEqualTo(Usrid)
                Dim ds As New DataSet
                ds = qry.ExecuteDataSet
                Dim AlmacnId As Integer
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = ds.Tables(0).Rows(0)
                    AlmacnId = CType(dr(4), Integer)
                Else
                    If UserController.Instance.GetCurrentUserInfo().IsSuperUser() Then
                        AlmacnId = 1
                    Else
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Usuario no asignado para realizar esta operacion!")
                    End If
                End If
                '=====================================================================================================
                Dim q As New Query(KardexInventario.Schema)
                q.AddWhere(KardexInventario.Columns.NCodProducto, objLote.NCodProducto)
                q.AND(KardexInventario.Columns.NCodAlmacen, AlmacnId)
                Dim lst As New KardexInventarioCollection()
                lst.LoadAndCloseReader(q.ExecuteReader())
                '=====================================================================================================
                Dim objNewKardex As New KardexInventario
                If lst.Count > 0 Then
                    Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(objLote.NCodProducto). _
                        ExecuteScalar(Of Integer)()
                    Dim objAuxKardex As New KardexInventario(kardexId)
                    objNewKardex.NCodAlmacen = AlmacnId
                    objNewKardex.NCodLote = CType(objLote.NCodLote, Integer)
                    objNewKardex.NCodProducto = objLote.NCodProducto
                    objNewKardex.DFechareg = objLote.DFechaIngreso
                    objNewKardex.CObservacion = String.Format("Compra de Producto a {0}. Ingreso modificado", objLote.CTipo)
                    objNewKardex.NPrecioCompra = objLote.NCostoUnidad

                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                    If CType(objLote.NTotalEnvases, Integer) > totenvasesant Then
                        objNewKardex.NEntrada = CType(objLote.NTotalEnvases, Integer) - totenvasesant
                        objNewKardex.NSalida = 0
                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase + objNewKardex.NEntrada
                    Else
                        objNewKardex.NEntrada = 0
                        objNewKardex.NSalida = totenvasesant - CType(objLote.NTotalEnvases, Integer)
                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - objNewKardex.NSalida
                    End If

                    objNewKardex.NStockAnteriorSuelto = objAuxKardex.NStockActualSuelto
                    If CType(objLote.NTotalSueltos, Integer) > totsueltosant Then
                        objNewKardex.NEntradaSueltos = CType(objLote.NTotalSueltos, Integer) - totsueltosant
                        objNewKardex.NSalidaSueltos = 0
                        objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto + objNewKardex.NEntradaSueltos
                    Else
                        objNewKardex.NEntradaSueltos = 0
                        objNewKardex.NSalidaSueltos = totsueltosant - CType(objLote.NTotalSueltos, Integer)
                        objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto - objNewKardex.NSalidaSueltos
                    End If
                    objNewKardex.NCostoTotal = objLote.NPrecioActualEnvase * objLote.NTotalEnvases
                    If objLote.CObservaciones <> "" Then
                        objNewKardex.CGlosa = objLote.CObservaciones
                    Else
                        objNewKardex.CGlosa = "Ingreso Modificado"
                    End If
                    objNewKardex.NPrecioAlmacen = 0
                    objNewKardex.NPrecioVenta = 0
                    objNewKardex.NCodKardex = New [Select](Aggregate.Max("nCodKardex")).From(KardexInventario.Schema). _
                                ExecuteScalar(Of Integer)() + 1
                    objNewKardex.Save()
                End If
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Ingreso ingresado exitosamente!")
                panelbusLote.Visible = False
                panelviewLote.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteLote_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteLote.Click
            txtTotalenvasesLote1.Text = ""
            txtObservacionesLote1.Text = ""
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoLote.Visible = True
            pnlBusquedaLote.Visible = False
            lbtnPDF.Visible = False
            grdLotes.DataSource = ""
            grdLotes.DataBind()
            grdBusquedaLotes.DataSource = Nothing
            grdBusquedaLotes.DataBind()
            ViewState("gvLote") = Nothing
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoLote.Visible = False
            pnlBusquedaLote.Visible = True
            lbtnPDF.Visible = False
            panelbusLote.Visible = True
            panelviewLote.Visible = False
            grdLotes.DataSource = ""
            grdLotes.DataBind()
            grdBusquedaLotes.DataSource = Nothing
            grdBusquedaLotes.DataBind()
            ViewState("gvLote") = Nothing
        End Sub

        Protected Sub lbtnPDF_Click(sender As Object, e As EventArgs) Handles lbtnPDF.Click
            Me.lbtnPDF_ModalPopupExtender.Show()
        End Sub


        Public Sub GenerarIngresoAlmacen(ByVal cNumFactura1 As String)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptLoteIngresado"
            bImprimirAuto = True
            bCerrarAuto = True
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

            Dim prmcDato As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcDato.Name = "cNumero"
            prmcDato.Values.Add(cNumFactura1)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmcDato}
            ServerReport.SetParameters(parameters)
        End Sub

        Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
            Me.lbtnPDF_ModalPopupExtender.Hide()
        End Sub
    End Class
End Namespace
