Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteProveedores
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarProveedor.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.btnBuscarProveedor.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
            Me.txtBuscarMarca.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.cmdBuscarMarca.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
        End Sub

        Private Sub CargarProveedor()
            Dim q As New Query(Proveedor.Schema)
            If Trim(txtBuscarProveedor.Text) <> "" Then
                q.AddWhere(Proveedor.Columns.CNombre, Comparison.Like, "%" & txtBuscarProveedor.Text.Trim() & "%")
            End If
            Dim lst As New ProveedorCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdProveedor.DataSource = lst
            grdProveedor.DataKeyNames() = New String() {Proveedor.Columns.NCodProveedor}
            grdProveedor.DataBind()
            lblMessageProveedor.Text = "Resultados: " & lst.Count.ToString() & " registro(s)"
            panelbusProv.Visible = True
        End Sub

        Private Sub CargarMarca()
            Dim q As New Query(Marca.Schema)
            If Trim(txtBuscarMarca.Text) <> "" Then
                q.AddWhere(Marca.Columns.CEmpresa, Comparison.Like, "%" & txtBuscarMarca.Text.Trim() & "%")
                'q.OR(Proveedor.Columns.Representante, Comparison.Like, "%" & txtBuscarProveedor.Text.Trim() & "%")
            End If
            Dim lst As New MarcaCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdMarca.DataSource = lst
            grdMarca.DataKeyNames() = New String() {Marca.Columns.NCodMarca}
            grdMarca.DataBind()
            lblMessageMarca.Text = "Resultados: " & lst.Count.ToString() & " registro(s)"
            panelbusMarc.Visible = True
        End Sub

        Private Sub inicializar()
            txtDireccion.Text = ""
            txtNomRazon.Text = ""
            txtRepresentante.Text = ""
            txtTelefono.Text = ""

            txtDireccion1.Text = ""
            txtNomRazon1.Text = ""
            txtRepresentante1.Text = ""
            txtTelefono1.Text = ""

            txtBuscarProveedor.Text = ""
            lblMessageProveedor.Text = ""

            txtEmpresaMarca.Text = ""
            txtDireccionMarca.Text = ""
            ProveedorControlSearch1.TextValue = "Elija proveedor"
            ProveedorControlSearch2.TextValue = "Cambie de proveedor"

            txtEmpresaMarca1.Text = ""
            txtDireccionMarca1.Text = ""

            txtBuscarMarca.Text = ""
            lblMessageMarca.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlNuevaMarca.Visible = False
                pnlBusquedaMarca.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsert.Click
            If Page.IsValid Then
                Dim objNewProveedor As New Proveedor()
                Dim nCodProveedor As Integer = New [Select](Aggregate.Max("nCodProveedor")).From(Proveedor.Schema).ExecuteScalar(Of Integer)()
                objNewProveedor.NCodProveedor = nCodProveedor + 1
                objNewProveedor.CNombre = txtNomRazon.Text
                objNewProveedor.CDireccion = txtDireccion.Text
                objNewProveedor.CRepresentante = txtRepresentante.Text
                objNewProveedor.CTelefono = txtTelefono.Text
                objNewProveedor.Save()
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlNuevaMarca.Visible = False
                pnlBusquedaMarca.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            txtDireccion.Text = ""
            txtNomRazon.Text = ""
            txtRepresentante.Text = ""
            txtTelefono.Text = ""
            pnlNuevoProveedor.Visible = False
            pnlBusquedaProveedor.Visible = False
            pnlNuevaMarca.Visible = False
            pnlBusquedaMarca.Visible = False
        End Sub

        Protected Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarProveedor.Click
            CargarProveedor()
        End Sub

        Protected Sub grdProveedor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdProveedor.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdProveedor.PageIndex = indice
            CargarProveedor()
        End Sub

        Protected Sub grdProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdProveedor.SelectedIndexChanged
            If grdProveedor.SelectedIndex > -1 Then
                Dim indice As Integer = grdProveedor.SelectedIndex
                Dim id As Integer = CType(grdProveedor.DataKeys(indice).Value, Integer)
                ViewState("pid") = id.ToString()
                Dim objProveedor As New Proveedor(id)
                txtDireccion1.Text = objProveedor.CDireccion
                txtNomRazon1.Text = objProveedor.CNombre
                txtRepresentante1.Text = objProveedor.CRepresentante
                txtTelefono1.Text = objProveedor.CTelefono
                txtBuscarProveedor.Text = ""
                panelbusProv.Visible = False
                panelviewProv.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateProveedor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateProveedor.Click
            If ViewState("pid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As Integer = CType(ViewState("pid"), Integer)
                Dim objProveedor As New Proveedor(id)
                objProveedor.CDireccion = txtDireccion1.Text
                objProveedor.CNombre = txtNomRazon1.Text
                objProveedor.CRepresentante = txtRepresentante1.Text
                objProveedor.CTelefono = txtTelefono1.Text
                objProveedor.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlBusquedaMarca.Visible = False
                pnlNuevaMarca.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteProveedor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteProveedor.Click
            Try
                If ViewState("pid") IsNot Nothing Then
                    Dim id As Integer = CType(ViewState("pid"), Integer)
                    Proveedor.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaProveedor.Visible = False
                    pnlNuevoProveedor.Visible = False
                    pnlBusquedaMarca.Visible = False
                    pnlNuevaMarca.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlBusquedaMarca.Visible = False
                pnlNuevaMarca.Visible = False
            End Try
        End Sub

        Protected Sub cmdInsertMarca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertMarca.Click
            If Page.IsValid AndAlso ProveedorControlSearch1.ProveedorId.HasValue Then
                Dim objNewMarca As New Marca()
                Dim nCodMarca As Integer = New [Select](Aggregate.Max("nCodMarca")).From(Marca.Schema).ExecuteScalar(Of Integer)()
                objNewMarca.NCodMarca = nCodMarca + 1
                objNewMarca.CEmpresa = txtEmpresaMarca.Text
                objNewMarca.CDireccion = txtDireccionMarca.Text()
                objNewMarca.NCodProveedor = ProveedorControlSearch1.ProveedorId

                objNewMarca.Save()
                pnlBusquedaMarca.Visible = False
                pnlNuevaMarca.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Debe seleccionar proveedor!")
            End If
        End Sub

        Protected Sub cmdCancelMarca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelMarca.Click
            txtDireccion.Text = ""
            txtEmpresaMarca.Text = ""
            txtDireccionMarca.Text = ""
            pnlNuevoProveedor.Visible = False
            pnlBusquedaProveedor.Visible = False
            pnlNuevaMarca.Visible = False
            pnlBusquedaMarca.Visible = False
        End Sub

        Protected Sub cmdBuscarMarca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarMarca.Click
            CargarMarca()
        End Sub

        Protected Sub grdMarca_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMarca.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdMarca.PageIndex = indice
            CargarMarca()
        End Sub

        Protected Sub grdMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdMarca.SelectedIndexChanged
            If grdMarca.SelectedIndex > -1 Then
                Dim indice As Integer = grdMarca.SelectedIndex
                Dim id As Integer = CType(grdMarca.DataKeys(indice).Value, Integer)
                ViewState("mid") = id.ToString()
                Dim objMarca As New Marca(id)
                txtEmpresaMarca1.Text = objMarca.CEmpresa
                txtDireccionMarca1.Text = objMarca.CDireccion
                Dim objProveedor As New Proveedor(objMarca.NCodProveedor)
                hfProveedorIdMarca1.Value = objMarca.NCodProveedor.ToString()
                lblProveedorNomRazonMarca1.Text = objProveedor.CNombre

                txtBuscarMarca.Text = ""
                panelbusMarc.Visible = False
                panelviewMarc.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateMarca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateMarca.Click
            If ViewState("mid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As Integer = CType(ViewState("mid"), Integer)
                Dim objMarca As New Marca(id)
                objMarca.CEmpresa = txtEmpresaMarca1.Text
                objMarca.CDireccion = txtDireccionMarca1.Text

                If ProveedorControlSearch2.ProveedorId.HasValue Then
                    objMarca.NCodProveedor = ProveedorControlSearch2.ProveedorId
                Else
                    objMarca.NCodProveedor = CType(hfProveedorIdMarca1.Value, Decimal)
                End If

                objMarca.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlBusquedaMarca.Visible = False
                pnlNuevaMarca.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteMarca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteMarca.Click
            Try
                If ViewState("mid") IsNot Nothing Then
                    Dim id As Integer = CType(ViewState("mid"), Integer)
                    Marca.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaProveedor.Visible = False
                    pnlNuevoProveedor.Visible = False
                    pnlBusquedaMarca.Visible = False
                    pnlNuevaMarca.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaProveedor.Visible = False
                pnlNuevoProveedor.Visible = False
                pnlBusquedaMarca.Visible = False
                pnlNuevaMarca.Visible = False
            End Try
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoProveedor.Visible = True
            pnlBusquedaProveedor.Visible = False
            pnlNuevaMarca.Visible = False
            pnlBusquedaMarca.Visible = False
            grdMarca.DataSource = Nothing
            grdMarca.DataBind()
            grdProveedor.DataSource = Nothing
            grdProveedor.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoProveedor.Visible = False
            pnlBusquedaProveedor.Visible = True
            pnlNuevaMarca.Visible = False
            pnlBusquedaMarca.Visible = False
            panelbusProv.Visible = True
            panelviewProv.Visible = False
            grdMarca.DataSource = Nothing
            grdMarca.DataBind()
            grdProveedor.DataSource = Nothing
            grdProveedor.DataBind()
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlNuevoProveedor.Visible = False
            pnlBusquedaProveedor.Visible = False
            pnlNuevaMarca.Visible = True
            pnlBusquedaMarca.Visible = False
            grdMarca.DataSource = Nothing
            grdMarca.DataBind()
            grdProveedor.DataSource = Nothing
            grdProveedor.DataBind()
        End Sub

        Protected Sub lbtn4_Click(sender As Object, e As EventArgs) Handles lbtn4.Click
            inicializar()
            pnlNuevoProveedor.Visible = False
            pnlBusquedaProveedor.Visible = False
            pnlNuevaMarca.Visible = False
            pnlBusquedaMarca.Visible = True
            panelbusMarc.Visible = True
            panelviewMarc.Visible = False
            grdMarca.DataSource = Nothing
            grdMarca.DataBind()
            grdProveedor.DataSource = Nothing
            grdProveedor.DataBind()
        End Sub
    End Class
End Namespace
