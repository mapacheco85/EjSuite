Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports EjSuite.Modules.EjSuite.VentaControlSearch
Imports System.Transactions
'MR 14/01/2011
Namespace EjSuite.Modules.EjSuite
    Public Class CotizacionControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        Private Sub calculaTotal()
            If CInt(txtCantidad.Text) > 0 And VentaControlSearch1.ProductoId <> Nothing Then
                Dim prod As String = VentaControlSearch1.ProductoId
                Dim oProducto As Producto = Producto.FetchByID(prod)
                Dim precio As Decimal
                If ckbSuelto.Checked = True Then
                    Dim descuento As Decimal = CDec(oProducto.NPrecioCompra / CDec(oProducto.CContiene) * (oProducto.NMontoVentaIndividual / 100))
                    Dim precioSuelto As Decimal = CDec(oProducto.NPrecioCompra) / CDec(oProducto.CContiene)
                    precio = precioSuelto + descuento
                Else
                    Dim descuento1 As Decimal = CDec(oProducto.NPrecioCompra * CDec(oProducto.NMontoVentaEnvase / 100))
                    Dim precioEnvace As Decimal = CDec(oProducto.NPrecioCompra)
                    precio = precioEnvace + descuento1
                End If
                lblTotal.Text = String.Format("{0} Bs.", String.Format("{0:F}", precio * CInt(txtCantidad.Text)))
            Else
                lblTotal.Text = "0"
            End If
        End Sub

        Protected Sub grdProductos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdProductos.RowDeleting
            Dim indice As Integer = e.RowIndex
            Dim tabla As DataTable = New DataTable("Detalle")
            If (grdProductos.Rows.Count > 0 And ViewState("gvCompra") IsNot Nothing) Then
                tabla = gvCompra
                tabla.Rows(indice).Delete()
                grdProductos.DataSource = tabla.DefaultView
                grdProductos.DataKeyNames = New String() {"id"}
                grdProductos.DataBind()
                Dim parcial As Decimal = 0D
                Dim suma As Decimal = 0D
                For i As Integer = 0 To grdProductos.Rows.Count - 1
                    Dim x As String = tabla.Rows(i).Item(4).ToString()
                    parcial = Decimal.Parse(x)
                    suma = suma + parcial
                Next
                lbTotalCompra.Text = suma.ToString()
                gvCompra = tabla
            End If
            If CInt(lbTotalCompra.Text) = 0 Then
                pnlPedido.Visible = False
            End If
        End Sub

        Public Property gvCompra() As DataTable
            Get
                If Not ViewState("gvCompra") Is Nothing Then
                    Return CType(ViewState("gvCompra"), DataTable)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As DataTable)
                ViewState("gvCompra") = value
            End Set
        End Property

        Protected Sub ckbSuelto_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ckbSuelto.CheckedChanged
            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Protected Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCantidad.TextChanged
            If CInt(txtCantidad.Text) > 0 Then
                calculaTotal()
            End If
        End Sub

        Protected Sub cmdInsertar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertar.Click
            Try
                lblError0.Visible = True
                lblError0.Text = ""
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
                    'Try
                    If (oProducto.BSueltos = True And ckbSuelto.Checked = True) Or (oProducto.BSueltos = False And ckbSuelto.Checked = False) Or (oProducto.BSueltos = True And ckbSuelto.Checked = False) Then
                        If (cantidad <= objbuscaProd.NStockActualSuelto And ckbSuelto.Checked = True) Or (cantidad <= objbuscaProd.NStockActualEnvase And ckbSuelto.Checked = False) Or (cantidad > objbuscaProd.NStockActualSuelto And objbuscaProd.NStockActualEnvase > 0 And CDec(oProducto.CContiene) > cantidad And ckbSuelto.Checked = True) Then
                            Dim precio As Decimal
                            If ckbSuelto.Checked = True Then
                                Dim descuento As Decimal = CDec(oProducto.NPrecioCompra / CDec(oProducto.CContiene) * (oProducto.NMontoVentaIndividual / 100))
                                Dim precioSuelto As Decimal = CDec(oProducto.NPrecioCompra) / CDec(oProducto.CContiene)
                                precio = precioSuelto + descuento
                            Else
                                Dim descuento1 As Decimal = CDec(oProducto.NPrecioCompra * CDec(oProducto.NMontoVentaEnvase / 100))
                                Dim precioEnvace As Decimal = CDec(oProducto.NPrecioCompra)

                                precio = precioEnvace + descuento1
                            End If

                            Dim precioTotal As Double = Math.Round(precio * cantidad, 1)
                            Dim tabla As DataTable = New DataTable("DetalleVentas")
                            If (ViewState("gvCompra") Is Nothing) Then
                                Dim col1 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Id Producto", .ColumnName = "id", .DefaultValue = 0}
                                tabla.Columns.Add(col1)
                                Dim col2 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Producto", .ColumnName = "prod", .DefaultValue = ""}
                                tabla.Columns.Add(col2)
                                Dim col3 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Cantidad", .ColumnName = "cant", .DefaultValue = 0}
                                tabla.Columns.Add(col3)
                                Dim col4 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Precio Unit.", .ColumnName = "punit", .DefaultValue = 0}
                                tabla.Columns.Add(col4)
                                Dim col5 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Total", .ColumnName = "total", .DefaultValue = 0}
                                tabla.Columns.Add(col5)
                                Dim col6 As DataColumn = New DataColumn() With {.AllowDBNull = False, .Caption = "Suelto", .ColumnName = "suelto", .DefaultValue = False}
                                tabla.Columns.Add(col6)
                                Dim fila As DataRow = tabla.NewRow()
                                fila("id") = ProdId
                                fila("prod") = productoNom
                                fila("cant") = cantidad
                                fila("punit") = String.Format("{0:F}", precio)
                                fila("total") = String.Format("{0:F}", precioTotal)
                                fila("suelto") = ckbSuelto.Checked
                                tabla.Rows.Add(fila)
                                ViewState("gvCompra") = tabla
                            Else
                                Dim encontrado As Boolean = False
                                Dim aux As String = ""
                                Dim val As Integer = 0
                                Dim ntotal As Decimal = 0
                                Dim x As Integer = 0
                                For i As Integer = 0 To grdProductos.Rows.Count - 1
                                    If (grdProductos.Rows(i).Cells(0).Text = ProdId) Then
                                        encontrado = True
                                        aux = grdProductos.Rows(i).Cells(2).Text
                                        val = Integer.Parse(aux) + cantidad
                                        aux = grdProductos.Rows(i).Cells(3).Text
                                        ntotal = Decimal.Parse(aux) * val
                                        x = i
                                    End If
                                Next
                                tabla = CType(ViewState("gvCompra"), DataTable)
                                If (encontrado = False) Then
                                    Dim fila As DataRow = tabla.NewRow()
                                    fila("id") = ProdId
                                    fila("prod") = productoNom
                                    fila("cant") = cantidad
                                    fila("punit") = String.Format("{0:F}", precio)
                                    fila("total") = String.Format("{0:F}", precioTotal)
                                    fila("suelto") = ckbSuelto.Checked
                                    tabla.Rows.Add(fila)
                                    ViewState("gvCompra") = tabla
                                Else
                                    tabla.Rows(x).Item(2) = val
                                    tabla.Rows(x).Item(4) = ntotal
                                    ViewState("gvCompra") = tabla
                                End If
                            End If
                            grdProductos.DataSource = tabla.DefaultView
                            grdProductos.DataKeyNames = New String() {"id"}
                            grdProductos.DataBind()
                            Dim parcial As Decimal = 0D
                            Dim suma As Decimal = 0D
                            For i As Integer = 0 To grdProductos.Rows.Count - 1
                                Dim x As String = tabla.Rows(i).Item(4).ToString()
                                parcial = Decimal.Parse(x)
                                suma = suma + parcial
                            Next
                            lbTotalCompra.Text = String.Format("{0:F}", Math.Round(suma, 1))
                            Dim dsuma As Double = Double.Parse(suma.ToString())
                            lblError0.Visible = False
                            txtCantidad.Text = ""
                            lblTotal.Text = ""
                            If (VentaControlSearch1 IsNot Nothing) Then
                                VentaControlSearch1 = Nothing
                            End If
                            pnlPedido.Visible = True
                        Else
                            lblError0.Text = String.Format("Existen: {0} unidades y {1} Envases en Almacen. Cada envase con {2} unidades.", objbuscaProd.NStockActualSuelto, objbuscaProd.NStockActualEnvase, oProducto.CContiene)

                        End If
                    Else
                        lblError0.Text = String.Format("El producto: {0}  no esta a al venta por unidades. Existen {1} Envaces en Almacen. Cada envase con {2} unidades.", oProducto.CNombreComercial, objbuscaProd.NStockActualEnvase, oProducto.CContiene)
                    End If
                Catch ex As Exception
                    lblError0.Text = "Producto inexistente"
                    lblError0.ForeColor = Drawing.Color.Red
                    lblError0.Visible = True
                End Try
            Catch ex As Exception
                lblError0.Text = "Producto inexistente"
                lblError0.ForeColor = Drawing.Color.Red
                lblError0.Visible = True
            End Try

        End Sub
    End Class
End Namespace
