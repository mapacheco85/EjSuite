Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteProductos
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarGrupoTerapeutico.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.cmdBuscarGrupoTerapeutico.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
            Me.txtBuscarProducto.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.btnBuscarProducto.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
        End Sub

        Private Sub CargarProducto()
            Dim q As New Query(Producto.Schema)
            q.AddWhere(Producto.Columns.BVigente, Comparison.Equals, True)
            If Trim(txtBuscarProducto.Text) <> "" Then
                q.AND(Producto.Columns.CNombreComercial, Comparison.Like, "%" & txtBuscarProducto.Text.Trim() & "%")
                q.OR(Producto.Columns.BVigente, Comparison.Equals, True)
                q.AND(Producto.Columns.CNombreGenerico, Comparison.Like, "%" & txtBuscarProducto.Text.Trim() & "%")
                q.OR(Producto.Columns.BVigente, Comparison.Equals, True)
                q.AND(Producto.Columns.CCodProducto, Comparison.Like, "%" & txtBuscarProducto.Text.Trim() & "%")
            End If
            Dim lst As New ProductoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdProducto.DataSource = lst
            grdProducto.DataKeyNames() = New String() {Producto.Columns.NCodProducto}
            grdProducto.DataBind()
            lblMessageProducto.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            panelbusProducto.Visible = True
        End Sub

        Private Sub CargarGrupoTerapeutico()
            Dim q As New Query(GrupoProducto.Schema)
            If Trim(txtBuscarGrupoTerapeutico.Text) <> "" Then
                q.AddWhere(GrupoProducto.Columns.CGrupoProducto, Comparison.Like, "%" & txtBuscarGrupoTerapeutico.Text.Trim() & "%")
            End If
            Dim lst As New GrupoProductoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdGrupoTerapeutico.DataSource = lst
            grdGrupoTerapeutico.DataKeyNames() = New String() {GrupoProducto.Columns.NCodGrupo}
            grdGrupoTerapeutico.DataBind()
            lblMessageGrupoTerapeutico.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            panelbusGrupoTerapeutico.Visible = True
        End Sub

        Private Sub inicializar()
            txtIdProducto.Text = ""
            ProveedorMarcaSearchControl1.TextValue = ""
            GrupoterapeuticoControlSearch1.TextValue = "Elija un código de grupo de ventas"
            txtNombreGenericoProducto.Text = ""
            txtNombreComercialProducto.Text = ""
            txtDetallesProducto.Text = ""
            txtCompuestoProducto.Text = ""
            txtPrecioCompraProducto.Text = ""
            txtStockMinimoProducto.Text = ""
            txtStockMaximoProducto.Text = ""

            txtBuscarProducto.Text = ""
            lblMessageProducto.Text = ""

            lblIdProducto1.Text = ""
            GrupoterapeuticoControlSearch2.TextValue = "Elija otro código de grupo de ventas"
            txtNombreGenericoProducto1.Text = ""
            txtNombreComercialProducto1.Text = ""
            txtDetallesProducto1.Text = ""
            txtCompuestoProducto1.Text = ""
            txtPrecioCompraProducto1.Text = ""
            txtStockMinimoProducto1.Text = ""
            txtStockMaximoProducto1.Text = ""

            txtCodigoGrupoTerapeutico.Text = ""
            txtGrupomedicoGrupoTerapeutico.Text = ""
            txtBuscarGrupoTerapeutico.Text = ""
            lblMessageGrupoTerapeutico.Text = ""

            lblCodigoGrupoTerapeutico1.Text = ""
            txtGrupomedicoGrupoTerapeutico1.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsertProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertProducto.Click
            If Page.IsValid Then
                Dim q As SqlQuery = New [Select]("cCodProducto"). _
                    From(Producto.Schema). _
                    Where(Producto.Columns.CNombreGenerico).IsEqualTo(txtNombreGenericoProducto.Text)
                Dim ds As DataSet
                ds = q.ExecuteDataSet
                If ds.Tables(0).Rows.Count > 0 Then
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡El producto ya  existe en el sistema!")
                Else
                    Dim objNewProducto As New Producto()
                    objNewProducto.NCodProducto = New [Select](Aggregate.Max("nCodProducto")).From(Producto.Schema).ExecuteScalar(Of Integer)() + 1
                    objNewProducto.CCodProducto = txtIdProducto.Text.Trim()
                    objNewProducto.NCodProveedor = CType(ProveedorMarcaSearchControl1.hfValue, Integer)
                    objNewProducto.NCodMarca = CType(ProveedorMarcaSearchControl1.MarcaId, Integer)
                    objNewProducto.NCodGrupo = Integer.Parse(GrupoterapeuticoControlSearch1.Grupocodigo)
                    objNewProducto.CNombreGenerico = txtNombreGenericoProducto.Text
                    objNewProducto.CNombreComercial = txtNombreComercialProducto.Text
                    objNewProducto.CDetalles = txtDetallesProducto.Text
                    objNewProducto.CCompuesto = txtCompuestoProducto.Text
                    objNewProducto.NPrecioCompra = CType(txtPrecioCompraProducto.Text, Decimal)
                    objNewProducto.CUnUna = ""
                    objNewProducto.CContiene = ""
                    objNewProducto.CTipoElementos = ""
                    objNewProducto.CMedidad = ""
                    objNewProducto.CUnidad = ""
                    objNewProducto.NMontoVentaEnvase = 0D
                    objNewProducto.NMontoVentaIndividual = 0D
                    objNewProducto.NPromocion = 0

                    If txtStockMinimoProducto.Text.Length > 0 Then
                        objNewProducto.NStockMinimo = CType(txtStockMinimoProducto.Text, Decimal)
                    End If
                    If txtStockMaximoProducto.Text.Length > 0 Then
                        objNewProducto.NStockMaximo = CType(txtStockMaximoProducto.Text, Decimal)
                    End If

                    objNewProducto.BVigente = True
                    objNewProducto.Save()

                    If objNewProducto.NCodGrupo IsNot Nothing Then
                        ViewState("grupocod") = objNewProducto.NCodGrupo
                    End If

                    pnlNuevoProducto.Visible = False
                    pnlBusquedaProductos.Visible = False
                    pnlNuevoGrupoTerapeutico.Visible = False
                    pnlBusquedaGrupoTerapeutico.Visible = False
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                End If
            End If
        End Sub

        Protected Sub cmdCancelProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelProducto.Click
            txtNombreGenericoProducto.Text = ""
            txtNombreComercialProducto.Text = ""
            txtDetallesProducto.Text = ""
            txtPrecioCompraProducto.Text = ""
            txtStockMinimoProducto.Text = ""
            txtStockMaximoProducto.Text = ""
            pnlNuevoProducto.Visible = False
            pnlBusquedaProductos.Visible = False
            pnlNuevoGrupoTerapeutico.Visible = False
            pnlBusquedaGrupoTerapeutico.Visible = False
        End Sub

        Protected Sub btnBuscarProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarProducto.Click
            CargarProducto()
        End Sub

        Protected Sub grdProducto_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdProducto.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdProducto.PageIndex = indice
            CargarProducto()
        End Sub

        Protected Sub grdProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdProducto.SelectedIndexChanged
            If grdProducto.SelectedIndex > -1 Then
                Dim indice As Integer = grdProducto.SelectedIndex
                Dim id As String = grdProducto.DataKeys(indice).Value.ToString()
                ViewState("pid") = id
                Dim objProducto As New Producto(id)

                lblIdProducto1.Text = objProducto.CCodProducto
                'ProveedorMarcaSearchControl2.TextValue = objProducto.Proveedor.Nomrazon
                Dim objProveedor As New Proveedor(objProducto.NCodProveedor)
                hfProveedorIdProducto1.Value = objProveedor.NCodProveedor.ToString()
                lblProveedorNomRazonProducto1.Text = "Proveedor: " & objProveedor.CNombre

                Dim objMarca As New Marca(objProducto.NCodMarca)
                hfMarcaIdProducto1.Value = objMarca.NCodMarca.ToString()
                lblMarcaEmpresaProducto1.Text = "Empresa: " & objMarca.CEmpresa

                Dim objGrupoProducto As New GrupoProducto(objProducto.NCodGrupo)
                hfGrupoCodigoProducto1.Value = objGrupoProducto.NCodGrupo
                lblGrupoMedicoProducto1.Text = objGrupoProducto.CGrupoProducto

                txtNombreGenericoProducto1.Text = objProducto.CNombreGenerico
                txtNombreComercialProducto1.Text = objProducto.CNombreComercial
                txtDetallesProducto1.Text = objProducto.CDetalles
                txtCompuestoProducto1.Text = objProducto.CCompuesto
                txtPrecioCompraProducto1.Text = String.Format("{0:F}", objProducto.NPrecioCompra)
                txtStockMinimoProducto1.Text = String.Format("{0}", CType(objProducto.NStockMinimo, Integer))
                txtStockMaximoProducto1.Text = String.Format("{0}", CType(objProducto.NStockMaximo, Integer))
                txtBuscarProducto.Text = ""

                If objProducto.NCodGrupo IsNot Nothing Then
                    ViewState("grupocod") = objProducto.NCodGrupo
                End If
                panelbusProducto.Visible = False
                panelviewProducto.Visible = True
            End If
        End Sub

        Protected Sub grdProducto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProducto.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As String = CType(grdProducto.DataKeys(indice).Value, String)
                    Dim objProducto As New Producto(cod)
                    Dim hypProducto As Label = CType(e.Row.Cells(4).Controls(0), Label)
                    hypProducto.Text = String.Format("{0:F}", objProducto.NPrecioCompra)
            End Select
        End Sub

        Protected Sub grdProducto_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProducto.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypProducto As New Label
                    hypProducto.CssClass = "CommandButton"
                    e.Row.Cells(4).Controls.Add(hypProducto)
            End Select
        End Sub

        Protected Sub cmdUpdateProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateProducto.Click
            If ViewState("pid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As String = CType(ViewState("pid"), String)
                Dim objProducto As New Producto(id)

                If ProveedorMarcaSearchControl2.ProveedorId.HasValue Then
                    objProducto.NCodProveedor = CType(ProveedorMarcaSearchControl2.ProveedorId, Decimal)
                Else
                    objProducto.NCodProveedor = CType(hfProveedorIdProducto1.Value, Decimal)
                End If

                If ProveedorMarcaSearchControl2.MarcaId.HasValue Then
                    objProducto.NCodMarca = CType(ProveedorMarcaSearchControl2.MarcaId, Decimal)
                Else
                    objProducto.NCodMarca = CType(hfMarcaIdProducto1.Value, Decimal)
                End If

                If ViewState("grupocod") IsNot Nothing Then
                    If hfGrupoCodigoProducto1.Value = ViewState("grupocod").ToString().Trim() Then
                        objProducto.NCodGrupo = hfGrupoCodigoProducto1.Value
                    Else
                        objProducto.NCodGrupo = GrupoterapeuticoControlSearch2.Grupocodigo
                    End If
                End If

                objProducto.CNombreGenerico = txtNombreGenericoProducto1.Text
                objProducto.CNombreComercial = txtNombreComercialProducto1.Text
                objProducto.CDetalles = txtDetallesProducto1.Text
                objProducto.CCompuesto = txtCompuestoProducto1.Text
                objProducto.NPrecioCompra = CType(txtPrecioCompraProducto1.Text, Decimal)
                If txtStockMinimoProducto.Text.Length > 0 Then
                    objProducto.NStockMinimo = CType(txtStockMinimoProducto1.Text, Decimal)
                End If
                If txtStockMaximoProducto.Text.Length > 0 Then
                    objProducto.NStockMaximo = CType(txtStockMaximoProducto1.Text, Decimal)
                End If

                objProducto.BVigente = True
                objProducto.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteProducto.Click
            If ViewState("pid") IsNot Nothing Then
                Dim id As String = CType(ViewState("pid"), String)
                Dim objProducto As New Producto(id)
                objProducto.BVigente = False

                objProducto.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
            End If
        End Sub

        Protected Sub cmdInsertGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertGrupoTerapeutico.Click
            If Page.IsValid Then
                Dim objNewGrupoTerapeutico As New GrupoProducto()
                objNewGrupoTerapeutico.NCodGrupo = Integer.Parse(txtCodigoGrupoTerapeutico.Text)
                objNewGrupoTerapeutico.CGrupoProducto = txtGrupomedicoGrupoTerapeutico.Text
                objNewGrupoTerapeutico.Save()
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            End If
        End Sub

        Protected Sub cmdCancelGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelGrupoTerapeutico.Click
            txtCodigoGrupoTerapeutico.Text = ""
            txtGrupomedicoGrupoTerapeutico.Text = ""
            pnlNuevoProducto.Visible = False
            pnlBusquedaProductos.Visible = False
            pnlNuevoGrupoTerapeutico.Visible = False
            pnlBusquedaGrupoTerapeutico.Visible = False
        End Sub

        Protected Sub cmdBuscarGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarGrupoTerapeutico.Click
            CargarGrupoTerapeutico()
        End Sub

        Protected Sub grdGrupoTerapeutico_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrupoTerapeutico.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdGrupoTerapeutico.PageIndex = indice
            CargarGrupoTerapeutico()
        End Sub

        Protected Sub grdGrupoTerapeutico_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdGrupoTerapeutico.SelectedIndexChanged
            If grdGrupoTerapeutico.SelectedIndex > -1 Then
                Dim indice As Integer = grdGrupoTerapeutico.SelectedIndex
                Dim id As String = CType(grdGrupoTerapeutico.DataKeys(indice).Value, String)
                ViewState("eid") = id
                Dim objGrupoTerapeutico As New GrupoProducto(id)
                lblCodigoGrupoTerapeutico1.Text = objGrupoTerapeutico.NCodGrupo
                txtGrupomedicoGrupoTerapeutico1.Text = objGrupoTerapeutico.CGrupoProducto
                txtBuscarGrupoTerapeutico.Text = ""
                panelbusGrupoTerapeutico.Visible = False
                panelviewGrupoTerapeutico.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateGrupoTerapeutico.Click
            If ViewState("eid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As String = CType(ViewState("eid"), String)
                Dim objGrupoTerapeutico As New GrupoProducto(id)
                objGrupoTerapeutico.CGrupoProducto = txtGrupomedicoGrupoTerapeutico1.Text
                objGrupoTerapeutico.Save()

                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteGrupoTerapeutico.Click
            Try
                If ViewState("eid") IsNot Nothing Then
                    Dim id As String = CType(ViewState("eid"), String)
                    GrupoProducto.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlNuevoProducto.Visible = False
                    pnlBusquedaProductos.Visible = False
                    pnlNuevoGrupoTerapeutico.Visible = False
                    pnlBusquedaGrupoTerapeutico.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlNuevoProducto.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlNuevoGrupoTerapeutico.Visible = False
                pnlBusquedaGrupoTerapeutico.Visible = False
            End Try
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoProducto.Visible = True
            pnlBusquedaProductos.Visible = False
            pnlNuevoGrupoTerapeutico.Visible = False
            pnlBusquedaGrupoTerapeutico.Visible = False
            grdGrupoTerapeutico.DataSource = Nothing
            grdGrupoTerapeutico.DataBind()
            grdProducto.DataSource = Nothing
            grdProducto.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoProducto.Visible = False
            pnlBusquedaProductos.Visible = True
            pnlNuevoGrupoTerapeutico.Visible = False
            pnlBusquedaGrupoTerapeutico.Visible = False
            panelbusProducto.Visible = True
            panelviewProducto.Visible = False
            grdGrupoTerapeutico.DataSource = Nothing
            grdGrupoTerapeutico.DataBind()
            grdProducto.DataSource = Nothing
            grdProducto.DataBind()
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlNuevoProducto.Visible = False
            pnlBusquedaProductos.Visible = False
            pnlNuevoGrupoTerapeutico.Visible = True
            pnlBusquedaGrupoTerapeutico.Visible = False
            grdGrupoTerapeutico.DataSource = Nothing
            grdGrupoTerapeutico.DataBind()
            grdProducto.DataSource = Nothing
            grdProducto.DataBind()
        End Sub

        Protected Sub lbtn4_Click(sender As Object, e As EventArgs) Handles lbtn4.Click
            inicializar()
            pnlNuevoProducto.Visible = False
            pnlBusquedaProductos.Visible = False
            pnlNuevoGrupoTerapeutico.Visible = False
            pnlBusquedaGrupoTerapeutico.Visible = True
            panelbusGrupoTerapeutico.Visible = True
            panelviewGrupoTerapeutico.Visible = False
            grdGrupoTerapeutico.DataSource = Nothing
            grdGrupoTerapeutico.DataBind()
            grdProducto.DataSource = Nothing
            grdProducto.DataBind()
        End Sub
    End Class
End Namespace
