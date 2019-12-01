Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports iTextSharp.text.pdf

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepVentas
        Inherits EjSuiteModuleBase

        Private sumascliente As Decimal
        Private sumaproducto As Decimal
        Private sumagrupo As Decimal

        Public Sub BuscarCliente()
            Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, user)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '==========================================================================================
            Dim qryClientes As New Query(VwRepVentasCliente.Schema)
            qryClientes.AddWhere(VwRepVentasCliente.Columns.NCodSucursal, objSucursal.NCodSucursal)

            If txtFechainicialClientes.Text.Trim() <> "" Then
                qryClientes.AND(VwRepVentasCliente.Columns.DFechaEmision, Comparison.GreaterOrEquals, txtFechainicialClientes.Text)
            End If

            If txtFechafinalClientes.Text.Trim() <> "" Then
                qryClientes.AND(VwRepVentasCliente.Columns.DFechaEmision, Comparison.LessOrEquals, txtFechafinalClientes.Text)
            End If

            If CuentaCliente1.ClienteId <> Nothing Then
                qryClientes.AND(VwRepVentasCliente.Columns.NCodCliente, CuentaCliente1.ClienteId)
            End If

            'If txtFechainicialClientes.Text.Trim() <> "" And txtFechafinalClientes.Text.Trim() <> "" Then
            '    qryClientes.BETWEEN_AND(VwRepVentasCliente.Columns.Fechaemision, txtFechainicialClientes.Text, txtFechafinalClientes.Text)
            'End If

            qryClientes.ORDER_BY(VwRepVentasCliente.Columns.CCliente)

            Dim lst As New VwRepVentasClienteCollection
            lst.LoadAndCloseReader(qryClientes.ExecuteReader)
            grdClientes.DataSource = lst
            grdClientes.DataKeyNames() = New String() {VwRepVentasCliente.Columns.NCodCliente}
            grdClientes.DataBind()
            lblMessageCli.Text = "Se encontraron: " & lst.Count.ToString & " registro(s)"
            panelbusCli.Visible = True
            If lst.Count > 0 Then
                cmdExportarE.Visible = True
            End If
        End Sub

        Public Sub BuscarProducto()
            Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, user)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '==========================================================================================
            Dim qryProductos As New Query(VwRepVentasProducto.Schema)
            qryProductos.AddWhere(VwRepVentasProducto.Columns.NCodSucursal, objSucursal.NCodSucursal)

            If txtFechainicialProducto.Text.Trim() <> "" Then
                qryProductos.AND(VwRepVentasProducto.Columns.DFechaEmision, Comparison.GreaterOrEquals, txtFechainicialProducto.Text)
            End If

            If txtFechafinalProducto.Text.Trim() <> "" Then
                qryProductos.AND(VwRepVentasProducto.Columns.DFechaEmision, Comparison.LessOrEquals, txtFechaFinalProducto.Text)
            End If

            If ProductoControlSearch1.ProductoId <> Nothing Then
                qryProductos.AND(VwRepVentasProducto.Columns.NCodProducto, ProductoControlSearch1.ProductoId)
            End If
            qryProductos.ORDER_BY(VwRepVentasProducto.Columns.NCodProducto)

            Dim lst As New VwRepVentasProductoCollection
            lst.LoadAndCloseReader(qryProductos.ExecuteReader)
            grdProductos.DataSource = lst
            grdProductos.DataKeyNames() = New String() {VwRepVentasProducto.Columns.NCodProducto}
            grdProductos.DataBind()
            lblMessageProductos.Text = "Se encontraron: " & lst.Count.ToString & " registro(s)"
            panelbusPro.Visible = True
            If lst.Count > 0 Then
                cmdExportarE.Visible = True
            End If
        End Sub

        Public Sub BuscarGTerapeutico()
            Dim user As Integer = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, user)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '==========================================================================================
            Dim qryGTerapeutico As New Query(VwRepVentasGTerapeutico.Schema)
            qryGTerapeutico.AddWhere(VwRepVentasGTerapeutico.Columns.NCodSucursal, objSucursal.NCodSucursal)

            If txtFechainicialGrupoTerapeutico.Text.Trim() <> "" Then
                qryGTerapeutico.AND(VwRepVentasGTerapeutico.Columns.DFechaEmision, Comparison.GreaterOrEquals, txtFechainicialGrupoTerapeutico.Text)
            End If

            If txtFechafinalGrupoTerapeutico.Text.Trim() <> "" Then
                qryGTerapeutico.AND(VwRepVentasGTerapeutico.Columns.DFechaEmision, Comparison.LessOrEquals, txtFechafinalGrupoTerapeutico.Text)
            End If

            If GrupoterapeuticoControlSearch1.Grupocodigo <> Nothing Then
                qryGTerapeutico.AND(VwRepVentasGTerapeutico.Columns.NCodGrupo, GrupoterapeuticoControlSearch1.Grupocodigo)
            End If
            qryGTerapeutico.ORDER_BY(VwRepVentasGTerapeutico.Columns.NCodGrupo)

            Dim lst As New VwRepVentasGTerapeuticoCollection
            lst.LoadAndCloseReader(qryGTerapeutico.ExecuteReader)

            grdGruposTerapeuticos.DataSource = lst
            grdGruposTerapeuticos.DataKeyNames() = New String() {VwRepVentasGTerapeutico.Columns.NCodGrupo}
            grdGruposTerapeuticos.DataBind()
            lblMessageGrupoTerapeutico.Text = "Se encontraron: " & lst.Count.ToString & " registro(s)"
            panelbusGru.Visible = True
            If lst.Count > 0 Then
                cmdExportarE.Visible = True
            End If
        End Sub

        Public Sub inicializar()
            CuentaCliente1.TextValue = "Elija un cliente"
            txtFechainicialClientes.Text = ""
            txtFechafinalClientes.Text = ""

            ProductoControlSearch1.TextValue = "Elija un producto"
            txtFechainicialProducto.Text = ""
            txtFechainicialProducto.Enabled = True
            txtFechafinalProducto.Enabled = True
            txtFechafinalProducto.Text = ""

            GrupoterapeuticoControlSearch1.TextValue = "Elija un grupo terapeutico"
            txtFechainicialGrupoTerapeutico.Text = ""
            txtFechafinalGrupoTerapeutico.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaClientes.Visible = False
                pnlBusquedaProductos.Visible = False
                pnlBusquedaGruposTeraupeticos.Visible = False
                'inicializar()
            End If
        End Sub

        Protected Sub cmdExportarE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExportarE.Click
            If grdClientes.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteVentas-1.xlsx", grdClientes)
            End If
            If grdProductos.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteVentas-2.xlsx", grdProductos)
            End If
            If grdGruposTerapeuticos.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteVentas-3.xlsx", grdGruposTerapeuticos)
            End If
        End Sub

        Protected Sub cmdSearchProductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchProductos.Click
            BuscarProducto()
            inicializar()
        End Sub

        Protected Sub cmdSearchClientes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchClientes.Click
            BuscarCliente()
            inicializar()
        End Sub

        Protected Sub cmdSearchGrupoTerapeutico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchGrupoTerapeutico.Click
            BuscarGTerapeutico()
            inicializar()
        End Sub

        Protected Sub grdClientes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientes.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = (e.Row.RowIndex) + 1 + (grdClientes.PageIndex * (grdClientes.PageSize))
                    Dim lblNro As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    lblNro.Text = indice.ToString
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(6).Text)
                    Me.sumascliente = Me.sumascliente + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(5).Text = "Totales"
                    e.Row.Cells(6).Text = String.Format("{0:F}", sumascliente)
            End Select
        End Sub

        Protected Sub grdClientes_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientes.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblNro As New Label
                    lblNro.CssClass = "CommandButton"
                    e.Row.Cells(0).Controls.Add(lblNro)
            End Select
        End Sub

        Protected Sub grdProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = (e.Row.RowIndex) + 1 + (grdProductos.PageIndex * (grdProductos.PageSize))
                    Dim lblNro As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    lblNro.Text = indice.ToString
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    Me.sumaproducto = Me.sumaproducto + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(3).Text = "Totales"
                    e.Row.Cells(4).Text = String.Format("{0:F}", sumaproducto)
            End Select
        End Sub

        Protected Sub grdProductos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblNro As New Label
                    lblNro.CssClass = "CommandButton"
                    e.Row.Cells(0).Controls.Add(lblNro)
            End Select
        End Sub

        Protected Sub grdGruposTerapeuticos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGruposTerapeuticos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = (e.Row.RowIndex) + 1 + (grdGruposTerapeuticos.PageIndex * (grdGruposTerapeuticos.PageSize))
                    Dim lblNro As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    lblNro.Text = indice.ToString
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    Me.sumagrupo = Me.sumagrupo + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(3).Text = "Totales"
                    e.Row.Cells(4).Text = String.Format("{0:F}", sumagrupo)
            End Select
        End Sub

        Protected Sub grdGruposTerapeuticos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGruposTerapeuticos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblNro As New Label
                    lblNro.CssClass = "CommandButton"
                    e.Row.Cells(0).Controls.Add(lblNro)
            End Select
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlBusquedaClientes.Visible = True
            panelbusCli.Visible = True
            pnlBusquedaProductos.Visible = False
            panelbusPro.Visible = False
            pnlBusquedaGruposTeraupeticos.Visible = False
            panelbusGru.Visible = False
            grdClientes.DataSource = Nothing
            grdClientes.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            grdGruposTerapeuticos.DataSource = Nothing
            grdGruposTerapeuticos.DataBind()
            lblMessageCli.Text = ""
            cmdExportarE.Visible = False
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlBusquedaClientes.Visible = False
            panelbusCli.Visible = False
            pnlBusquedaProductos.Visible = True
            panelbusPro.Visible = True
            pnlBusquedaGruposTeraupeticos.Visible = False
            panelbusGru.Visible = False
            grdClientes.DataSource = Nothing
            grdClientes.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            grdGruposTerapeuticos.DataSource = Nothing
            grdGruposTerapeuticos.DataBind()
            lblMessageProductos.Text = ""
            cmdExportarE.Visible = False
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlBusquedaClientes.Visible = False
            panelbusCli.Visible = False
            pnlBusquedaProductos.Visible = False
            panelbusPro.Visible = False
            pnlBusquedaGruposTeraupeticos.Visible = True
            panelbusGru.Visible = True
            grdClientes.DataSource = Nothing
            grdClientes.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            grdGruposTerapeuticos.DataSource = Nothing
            grdGruposTerapeuticos.DataBind()
            lblMessageGrupoTerapeutico.Text = ""
            cmdExportarE.Visible = False
        End Sub
    End Class
End Namespace
