Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteAjustePrecios
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarProductos.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarProducto.ClientID))
        End Sub

        Private Sub CargarProducto()
            Dim ds As New DataSet
            ds = SPs.VerPreciosXLinea(txtBuscarProductos.Text.Trim()).GetDataSet()
            grdAjuste.DataSource = ds.Tables(0).DefaultView
            grdAjuste.DataKeyNames() = New String() {"nCodProducto"}
            grdAjuste.DataBind()
            lblMessageProducto.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            panelbusProd.Visible = True
            ds = Nothing

            If grdAjuste.Rows.Count > 0 Then
                panelviewProd.Visible = True
            End If
        End Sub

        Private Sub inicializar()
            txtBuscarProductos.Text = ""
            lblMessageProducto.Text = ""

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaProducto.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub btnBuscarProducto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarProducto.Click
            grdAjuste.DataSource = Nothing
            grdAjuste.DataBind()
            CargarProducto()
        End Sub

        Protected Sub cmdUpdateProductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateProductos.Click
            If grdAjuste.Rows.Count > 0 Then
                For i = 0 To grdAjuste.Rows.Count - 1
                    Dim chkmod As CheckBox = CType(grdAjuste.Rows(i).FindControl("chkmod"), CheckBox)
                    Dim txtprecio As TextBox = CType(grdAjuste.Rows(i).FindControl("txtprecio"), TextBox)
                    If chkmod.Checked = True Then
                        Dim objProducto As New Producto(grdAjuste.DataKeys(i).Value) With {.NPrecioCompra = CType(txtprecio.Text, Decimal)}
                        objProducto.Save()
                    End If
                Next
            End If
            EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Ajuste realizado exitosamente!")
            pnlBusquedaProducto.Visible = False
        End Sub

        Protected Sub cmdLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLimpiar.Click
            inicializar()
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlBusquedaProducto.Visible = True
            panelbusProd.Visible = True
            panelviewProd.Visible = False
            grdAjuste.DataSource = Nothing
            grdAjuste.DataBind()
        End Sub
    End Class
End Namespace
