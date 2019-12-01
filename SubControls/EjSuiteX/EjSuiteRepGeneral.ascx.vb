Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepGeneral
        Inherits EjSuiteModuleBase

        Private Sub CargarVentas()
            Dim rep As DataSet = SPs.SpEmpleadoProductoConsolidado(txtFechainicialVentasRepGeneral.Text, txtFechafinalVentasRepGeneral.Text).GetDataSet
            grdVentas.DataSource = rep.Tables(0).DefaultView
            'grdVentas.DataKeyNames() = New String() {"nCodProducto"}
            grdVentas.DataBind()
            lblMessageVentas.Text = "Se encontraron: " & rep.Tables(0).Rows.Count & " registro(s)"
            panelbusVentas.Visible = True
            rep = Nothing
        End Sub

        Private Sub CargarProductos()
            Dim envases As DataSet = SPs.SpClienteProductoConsolidado(txtFechainicialProductosRepGeneral.Text, txtFechafinalProductosRepGeneral.Text).GetDataSet
            grdProductos.DataSource = envases.Tables(0).DefaultView
            'grdProductos.DataKeyNames() = New String() {"nCodProducto"}
            grdProductos.DataBind()
            lblMessageProductos.Text = "Se encontraron: " & envases.Tables(0).Rows.Count & " registro(s)"
            pnlbusProductos.Visible = True
            envases = Nothing
        End Sub

        Private Sub CargarMeses()
            If ddlTotalMesesRepGeneral.Text = "Producto" Then
                Dim envases As DataSet = SPs.SpReporteProductosPorMeses(txtFechainicialMesesRepGeneral.Text, txtFechafinalMesesRepGeneral.Text).GetDataSet

                grdMesesProd.DataSource = envases.Tables(0).DefaultView
                grdMesesProd.DataKeyNames() = New String() {"nCodProducto"}
                grdMesesProd.DataBind()
                lblMessageMeses.Text = "Se encontraron: " & envases.Tables(0).Rows.Count & " registro(s)"
                pnlbusProductos.Visible = True
                envases = Nothing

            End If
            '====================================================================================================
            If ddlTotalMesesRepGeneral.Text = "Sucursal" Then
                Dim rep As DataSet = SPs.SpReporteSucursalPorMeses(txtFechainicialMesesRepGeneral.Text, txtFechafinalMesesRepGeneral.Text).GetDataSet
                grdMesesSuc.DataSource = rep.Tables(0).DefaultView
                grdMesesSuc.DataKeyNames() = New String() {"nCodSucursal"}
                grdMesesSuc.DataBind()
                lblMessageMeses.Text = "Se encontraron: " & rep.Tables(0).Rows.Count & " registro(s)"
                pnlbusMeses.Visible = True
                rep = Nothing
            End If
            '====================================================================================================
            If ddlTotalMesesRepGeneral.Text = "Empleado" Then
                Dim rep As DataSet = SPs.SpReporteEmpleadoPorMeses(txtFechainicialMesesRepGeneral.Text, txtFechafinalMesesRepGeneral.Text).GetDataSet
                grdMesesEmp.DataSource = rep.Tables(0).DefaultView
                grdMesesEmp.DataKeyNames() = New String() {"nombres"}
                grdMesesEmp.DataBind()
                lblMessageMeses.Text = "Se encontraron: " & rep.Tables(0).Rows.Count & " registro(s)"
                pnlbusMeses.Visible = True
                rep = Nothing
            End If
        End Sub

        Private Sub inicializar()
            txtFechainicialVentasRepGeneral.Text = ""
            txtFechafinalVentasRepGeneral.Text = ""
            lblMessageVentas.Text = ""

            txtFechainicialProductosRepGeneral.Text = ""
            txtFechafinalProductosRepGeneral.Text = ""
            lblMessageProductos.Text = ""

            txtFechainicialMesesRepGeneral.Text = ""
            txtFechafinalMesesRepGeneral.Text = ""
            lblMessageMeses.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlVentasRepGeneral.Visible = False
                pnlProductosRepGeneral.Visible = False
                pnlMesesRepGeneral.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdSearchVentas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchVentas.Click
            CargarVentas()
        End Sub

        Protected Sub cmdCancelVentas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelVentas.Click
            pnlVentasRepGeneral.Visible = False
            pnlProductosRepGeneral.Visible = False
            pnlMesesRepGeneral.Visible = False
        End Sub

        Protected Sub cmdSearchProductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchProductos.Click
            CargarProductos()
        End Sub

        Protected Sub cmdCancelProductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelProductos.Click
            pnlVentasRepGeneral.Visible = False
            pnlProductosRepGeneral.Visible = False
            pnlMesesRepGeneral.Visible = False
        End Sub

        Protected Sub grdProductos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdProductos.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdVentas.PageIndex = indice
            CargarProductos()
        End Sub

        Protected Sub cmdSearchMeses_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchMeses.Click
            grdMesesProd.DataSource = Nothing
            grdMesesProd.DataBind()
            grdMesesSuc.DataSource = Nothing
            grdMesesSuc.DataBind()
            grdMesesEmp.DataSource = Nothing
            grdMesesEmp.DataBind()
            CargarMeses()
        End Sub

        Protected Sub cmdCancelMeses_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelMeses.Click
            pnlVentasRepGeneral.Visible = False
            pnlProductosRepGeneral.Visible = False
            pnlMesesRepGeneral.Visible = False
        End Sub

        Protected Sub grdMesesProd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMesesProd.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdMesesProd.PageIndex = indice
            CargarMeses()
        End Sub

        Protected Sub grdMesesSuc_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMesesSuc.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdMesesSuc.PageIndex = indice
            CargarMeses()
        End Sub

        Protected Sub grdMesesSuc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMesesSuc.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim rep As DataSet = SPs.SpReporteSucursalPorMeses(txtFechainicialMesesRepGeneral.Text, txtFechafinalMesesRepGeneral.Text).GetDataSet
                    Dim indice As Integer = e.Row.RowIndex
                    Dim tabla As DataTable = New DataTable("ReporteVentas")
                    tabla = rep.Tables(0)
                    Dim dr As DataRow = tabla.Rows(indice)
                    Dim hypRepSucM As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypRepSucM.Text = String.Format("{0:F}", dr(3))
            End Select
        End Sub

        Protected Sub grdMesesSuc_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMesesSuc.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypRepSucM As New Label
                    hypRepSucM.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypRepSucM)
            End Select
        End Sub

        Protected Sub grdMesesEmp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMesesEmp.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdMesesEmp.PageIndex = indice
            CargarMeses()
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If (pnlVentasRepGeneral.Visible) And (grdVentas.Rows.Count > 0) Then
                GridViewExportUtil.Export("Reporte.xlsx", grdVentas)
            End If

            If (pnlProductosRepGeneral.Visible) And (grdProductos.Rows.Count > 0) Then
                GridViewExportUtil.Export("Reporte.xlsx", grdProductos)
            End If

            If pnlMesesRepGeneral.Visible Then
                If (ddlTotalMesesRepGeneral.Text = "Producto") And (grdMesesProd.Rows.Count > 0) Then
                    GridViewExportUtil.Export("Reporte.xlsx", grdMesesProd)
                End If
                If (ddlTotalMesesRepGeneral.Text = "Sucursal") And (grdMesesSuc.Rows.Count > 0) Then
                    GridViewExportUtil.Export("Reporte.xlsx", grdMesesSuc)
                End If
                If (ddlTotalMesesRepGeneral.Text = "Empleado") And (grdMesesEmp.Rows.Count > 0) Then
                    GridViewExportUtil.Export("Reporte.xlsx", grdMesesEmp)
                End If
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlVentasRepGeneral.Visible = True
            pnlProductosRepGeneral.Visible = False
            pnlMesesRepGeneral.Visible = False
            grdVentas.DataSource = Nothing
            grdVentas.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlVentasRepGeneral.Visible = False
            pnlProductosRepGeneral.Visible = True
            pnlMesesRepGeneral.Visible = False
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlVentasRepGeneral.Visible = False
            pnlProductosRepGeneral.Visible = False
            pnlMesesRepGeneral.Visible = True
            grdMesesProd.DataSource = Nothing
            grdMesesProd.DataBind()
            grdMesesSuc.DataSource = Nothing
            grdMesesSuc.DataBind()
            grdMesesEmp.DataSource = Nothing
            grdMesesEmp.DataBind()
        End Sub
    End Class
End Namespace
