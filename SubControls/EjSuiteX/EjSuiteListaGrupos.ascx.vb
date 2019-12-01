Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite

    Public Class EjSuiteListaGrupos
        Inherits EjSuiteModuleBase

        Private Sub inicializar()
            pnlGrupos.Visible = False
            pnlListados.Visible = False
            fsGrupos.Visible = True
            fsGruposCrud.Visible = False
            fsListados.Visible = True
            fsListadosCrud.Visible = False
            txtNombreGrupo.Text = ""
            txtBuscarGrupo.Text = ""
            txtBuscarProducto.Text = ""
            txtNombreProducto.Text = ""

            CargarNoListados()

            Dim q As New Query(Grupo.Schema)
            Dim lst As New GrupoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            ddlGrupo.DataSource = lst
            ddlGrupo.DataTextField = Grupo.Columns.CTipoGrupo
            ddlGrupo.DataValueField = Grupo.Columns.NCodGrupo
            ddlGrupo.DataBind()
        End Sub

        Protected Sub CargarGrupos()
            Dim q As New Query(Grupo.Schema)
            If Trim(txtBuscarGrupo.Text) <> "" Then
                q.AddWhere(Grupo.Columns.CTipoGrupo, Comparison.Like, "%" & txtBuscarGrupo.Text.Trim() & "%")
            End If
            q.ORDER_BY(Grupo.Columns.CTipoGrupo)
            Dim lst As New GrupoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdGrupo.DataSource = lst
            grdGrupo.DataKeyNames() = New String() {Grupo.Columns.NCodGrupo}
            grdGrupo.DataBind()
            lblMessageGrupo.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            fsGrupos.Visible = True
        End Sub

        Protected Sub CargarNoListados()
            Dim q1 As SqlQuery = [Select].AllColumnsFrom(Of Producto)().Where("nCodProducto"). _
                                    NotIn(New [Select]("nCodProducto").From(Of ListadoProducto))
            q1.OrderAsc(Producto.Columns.CNombreComercial, Producto.Columns.NCodProducto)
            Dim ds As New DataSet
            ds = q1.ExecuteDataSet()
            grdSinListado.DataSource = ds.Tables(0).DefaultView
            grdSinListado.DataKeyNames() = New String() {Producto.Columns.NCodProducto}
            grdSinListado.DataBind()
        End Sub

        Protected Sub CargarListados()
            Dim q As SqlQuery = New [Select](ListadoProducto.Columns.NCodListado, Producto.Columns.NCodProducto, _
                                           Producto.Columns.CNombreComercial, Grupo.Columns.NCodGrupo, _
                                           Grupo.Columns.CTipoGrupo).From(ListadoProducto.Schema). _
                                           InnerJoin(Producto.NCodProductoColumn, ListadoProducto.NCodProductoColumn). _
                                           InnerJoin(Grupo.NCodGrupoColumn, ListadoProducto.NCodGrupoColumn). _
                                           Where(Producto.Columns.CNombreComercial). _
                                           Like("%" & txtBuscarProducto.Text & "%")
            q.OrderAsc(Producto.Columns.CNombreComercial, Grupo.Columns.CTipoGrupo)
            Dim ds As New DataSet
            ds = q.ExecuteDataSet()
            grdProductos.DataSource = ds.Tables(0).DefaultView
            grdProductos.DataKeyNames() = New String() {ListadoProducto.Columns.NCodListado}
            grdProductos.DataBind()
            lblMessageProductos.Text = "Se encontraron: " & ds.Tables(0).DefaultView.Count & " registro(s)"
            fsListados.Visible = True
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                inicializar()
            End If
        End Sub

        Protected Sub btnBuscarGrupo_Click(sender As Object, e As EventArgs) Handles btnBuscarGrupo.Click
            CargarGrupos()
        End Sub

        Protected Sub lbtnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles lbtnNuevoGrupo.Click
            fsGrupos.Visible = False
            fsGruposCrud.Visible = True
            cmdInsertUpdate.Text = "Insertar"
            cmdDeleteClear.Text = "Limpiar"
        End Sub

        Protected Sub grdGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGrupo.SelectedIndexChanged
            If grdGrupo.SelectedIndex > -1 Then
                Dim indice As Integer = grdGrupo.SelectedIndex
                Dim id As String = CType(grdGrupo.DataKeys(indice).Value, String)
                ViewState("gid") = id
                Dim objGrupo As New Grupo(id)
                txtNombreGrupo.Text = objGrupo.CTipoGrupo
                fsListados.Visible = False
                fsListadosCrud.Visible = True
                cmdInsertUpdate.Text = "Modificar"
                cmdDeleteClear.Text = "Eliminar"
            End If
        End Sub

        Protected Sub cmdInsertUpdate_Click(sender As Object, e As EventArgs) Handles cmdInsertUpdate.Click
            Select Case cmdInsertUpdate.Text
                Case "Insertar"
                    Dim objNewGrupo As New Grupo
                    objNewGrupo.CTipoGrupo = txtNombreGrupo.Text
                    objNewGrupo.Save()
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                Case "Modificar"
                    If ViewState("gid") IsNot Nothing Then
                        Dim objGrupo As New Grupo(ViewState("gid").ToString())
                        objGrupo.CTipoGrupo = txtNombreGrupo.Text
                        objGrupo.Save()
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado exitosamente!")
                    End If
            End Select
            inicializar()
        End Sub

        Protected Sub cmdDeleteClear_Click(sender As Object, e As EventArgs) Handles cmdDeleteClear.Click
            Select Case cmdDeleteClear.Text
                Case "Eliminar"
                    Try
                        If ViewState("gid") IsNot Nothing Then
                            Dim id As String = CType(ViewState("gid"), String)
                            Grupo.Delete(id)
                            EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                        End If
                    Catch ex As Exception
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                    End Try
                    inicializar()
                Case "Limpiar"
                    txtNombreGrupo.Text = ""
            End Select
        End Sub

        Protected Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
            txtNombreGrupo.Text = ""
            txtBuscarGrupo.Text = ""
            txtBuscarProducto.Text = ""
            txtNombreProducto.Text = ""
            fsGrupos.Visible = True
            fsGruposCrud.Visible = False
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlGrupos.Visible = True
            pnlListados.Visible = False
            fsGrupos.Visible = True
            fsGruposCrud.Visible = False
            fsListados.Visible = True
            fsListadosCrud.Visible = False
            grdGrupo.DataSource = Nothing
            grdGrupo.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            pnlGrupos.Visible = False
            pnlListados.Visible = True
            fsGrupos.Visible = True
            fsGruposCrud.Visible = False
            fsListados.Visible = True
            grdSinListado.Visible = False
            fsListadosCrud.Visible = False
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
        End Sub

        Protected Sub lbtnNuevoElemento_Click(sender As Object, e As EventArgs) Handles lbtnNuevoElemento.Click
            fsListados.Visible = False
            fsListadosCrud.Visible = True
            cmdInsertarModificarLista.Text = "Insertar"
            cmdEliminarLimpiarLista.Text = "Limpiar"
            grdSinListado.Visible = True
            txtNombreProducto.Text = ""
        End Sub

        Protected Sub grdProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdProductos.SelectedIndexChanged
            If grdProductos.SelectedIndex > -1 Then
                Dim indice As Integer = grdProductos.SelectedIndex
                Dim id As String = CType(grdProductos.DataKeys(indice).Value, String)
                ViewState("lid") = id
                Dim objListado As New ListadoProducto(id)
                Dim objProducto As New Producto(objListado.NCodProducto)
                txtNombreProducto.Text = objProducto.CNombreComercial
                ViewState("pid") = objListado.NCodProducto
                ddlGrupo.SelectedValue = objListado.NCodGrupo
                fsListados.Visible = False
                fsListadosCrud.Visible = True
                cmdInsertarModificarLista.Text = "Modificar"
                cmdEliminarLimpiarLista.Text = "Eliminar"
            End If
        End Sub

        Protected Sub cmdInsertarModificarLista_Click(sender As Object, e As EventArgs) Handles cmdInsertarModificarLista.Click
            Select Case cmdInsertarModificarLista.Text
                Case "Insertar"
                    For i = 0 To grdSinListado.Rows.Count - 1
                        Dim chkmod As CheckBox = CType(grdSinListado.Rows(i).FindControl("chkmod"), CheckBox)
                        If chkmod.Checked = True Then
                            Dim objNewLista As New ListadoProducto()
                            objNewLista.NCodProducto = grdSinListado.DataKeys(i).Value.ToString
                            objNewLista.NCodGrupo = ddlGrupo.SelectedValue
                            objNewLista.DFechaReg = Now()
                            objNewLista.BVigente = True
                            objNewLista.Save()
                        End If
                    Next
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                Case "Modificar"
                    If ViewState("lid") IsNot Nothing AndAlso ViewState("pid") IsNot Nothing Then
                        Dim objListado As New ListadoProducto(ViewState("lid").ToString())
                        objListado.NCodProducto = ViewState("pid").ToString
                        objListado.NCodGrupo = ddlGrupo.SelectedValue
                        objListado.DFechaReg = Now
                        objListado.BVigente = True
                        objListado.Save()
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado exitosamente!")
                    End If
            End Select
            inicializar()
        End Sub

        Protected Sub cmdEliminarLimpiarLista_Click(sender As Object, e As EventArgs) Handles cmdEliminarLimpiarLista.Click
            Select Case cmdEliminarLimpiarLista.Text
                Case "Eliminar"
                    Try
                        If ViewState("lid") IsNot Nothing Then
                            Dim id As String = CType(ViewState("lid"), String)
                            ListadoProducto.Delete(id)
                            EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                        End If
                    Catch ex As Exception
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                    End Try
                    inicializar()
                Case "Limpiar"
                    ddlGrupo.SelectedIndex = 0
            End Select
        End Sub

        Protected Sub cmdCancelarLista_Click(sender As Object, e As EventArgs) Handles cmdCancelarLista.Click
            fsListados.Visible = True
            fsListadosCrud.Visible = False
            txtNombreGrupo.Text = ""
            txtBuscarGrupo.Text = ""
            txtBuscarProducto.Text = ""
            txtNombreProducto.Text = ""
        End Sub

        Protected Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
            CargarListados()
        End Sub
    End Class
End Namespace