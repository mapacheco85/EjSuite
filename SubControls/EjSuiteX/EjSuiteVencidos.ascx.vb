Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports SubSonic

Imports Microsoft.VisualBasic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteVencidos
        Inherits EjSuiteModuleBase

        Private Sub LotesVencidos()
            Dim ds As New DataSet
            ds = SPs.VerLotesVencidos().GetDataSet()
            grdVencidos.DataSource = ds.Tables(0).DefaultView
            lblResult.Text = "Se encontraron: " & ds.Tables(0).Rows.Count & " registro(s)"
            grdVencidos.DataKeyNames() = New String() {Lote.Columns.NCodLote}
            grdVencidos.DataBind()
            ds = Nothing
        End Sub

        Private Sub LotesNoVencidos()
            Dim ds As New DataSet
            ds = SPs.VerLotesNoVencidos.GetDataSet()
            grdNoVencidos.DataSource = ds.Tables(0).DefaultView
            lblResult.Text = "Se encontraron: " & ds.Tables(0).Rows.Count & " registro(s)"
            grdNoVencidos.DataKeyNames() = New String() {Lote.Columns.NCodLote}
            grdNoVencidos.DataBind()
            ds = Nothing
        End Sub

        Private Sub VencidosMeses()
            Dim rep As DataSet = SPs.SpVence3Meses().GetDataSet
            grdMeses.DataSource = rep.Tables(0).DefaultView
            lblResult.Text = "Se encontraron: " & rep.Tables(0).Rows.Count & " registro(s)"
            grdMeses.DataKeyNames() = New String() {Lote.Columns.NCodLote}
            grdMeses.DataBind()
            rep = Nothing
        End Sub

        Private Sub StockMinimo()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim qry As SqlQuery = New [Select]("nCodEmpleado, nCodUsuario, nCodEmpleadoSucursal, EJS_Sucursal.nCodSucursal, EJS_Almacen.nCodAlmacen, nCodJefeAlmacen"). _
                From(Empleado.Schema). _
                InnerJoin(EmpleadoSucursal.NCodEmpleadoColumn, Empleado.NCodEmpleadoColumn). _
                InnerJoin(Sucursal.NCodSucursalColumn, EmpleadoSucursal.NCodSucursalColumn). _
                InnerJoin(Almacen.NCodSucursalColumn, Sucursal.NCodSucursalColumn). _
                Where(Almacen.Columns.NCodJefeAlmacen).IsEqualTo(Usrid)
            Dim ds As New DataSet
            ds = qry.ExecuteDataSet
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Dim AlmacnId As Integer = CType(dr(4), Integer)
            If UserController.Instance.GetCurrentUserInfo().IsSuperUser Then
                AlmacnId = 1
            End If
            Dim rep As DataSet = SPs.SpVerificarStock(AlmacnId).GetDataSet
            grdStockMinimo.DataSource = rep.Tables(0).DefaultView
            lblResult.Text = "Se encontraron: " & rep.Tables(0).Rows.Count & " registro(s)"
            grdStockMinimo.DataKeyNames() = New String() {"nCodProducto"}
            grdStockMinimo.DataBind()
            ds = Nothing
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlVencidos.Visible = False
            End If
        End Sub

        Protected Sub grdVencidos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdVencidos.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdVencidos.PageIndex = indice
            LotesVencidos()
        End Sub

        Protected Sub grdNoVencidos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdNoVencidos.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdNoVencidos.PageIndex = indice
            LotesNoVencidos()
        End Sub

        Protected Sub grdMeses_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMeses.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdMeses.PageIndex = indice
            VencidosMeses()
        End Sub

        Protected Sub grdStockMinimo_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdStockMinimo.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdStockMinimo.PageIndex = indice
            StockMinimo()
        End Sub

        Protected Sub grdVencidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVencidos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdVencidos.DataKeys(indice).Value, Integer)
                    Dim objLote As New Lote(cod)
                    Dim hypLote As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypLote.Text = objLote.DFechaVencimiento.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdVencidos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVencidos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypLote As New Label
                    hypLote.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypLote)
            End Select
        End Sub

        Protected Sub grdNoVencidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdNoVencidos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdNoVencidos.DataKeys(indice).Value, Integer)
                    Dim objLote As New Lote(cod)
                    Dim hypLote1 As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypLote1.Text = objLote.DFechaIngreso.ToShortDateString()
                    Dim hypLote2 As Label = CType(e.Row.Cells(4).Controls(0), Label)
                    hypLote2.Text = objLote.DFechaVencimiento.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdNoVencidos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdNoVencidos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypLote1 As New Label
                    hypLote1.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypLote1)
                    Dim hypLote2 As New Label
                    hypLote2.CssClass = "CommandButton"
                    e.Row.Cells(4).Controls.Add(hypLote2)
            End Select
        End Sub

        Protected Sub grdMeses_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMeses.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdMeses.DataKeys(indice).Value, Integer)
                    Dim objLote As New Lote(cod)
                    Dim hypLote As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypLote.Text = objLote.DFechaVencimiento.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdMeses_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMeses.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypLote As New Label
                    hypLote.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypLote)
            End Select
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If (pnlVencidos.Visible) And (grdVencidos.Rows.Count > 0) Then
                GridViewExportUtil.Export("ReporteVencidos.xlsx", grdVencidos)
            End If
            If (pnlNoVencidos.Visible) And (grdNoVencidos.Rows.Count > 0) Then
                GridViewExportUtil.Export("ReporteNoVencidos.xlsx", grdNoVencidos)
            End If
            If (pnlVencidosMeses.Visible) And (grdMeses.Rows.Count > 0) Then
                GridViewExportUtil.Export("ReporteA3Meses.xlsx", grdMeses)
            End If
            If (pnlStockMinimo.Visible) And (grdStockMinimo.Rows.Count > 0) Then
                GridViewExportUtil.Export("ReporteStockMinimo.xlsx", grdStockMinimo)
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlVencidos.Visible = True
            pnlNoVencidos.Visible = False
            pnlVencidosMeses.Visible = False
            pnlStockMinimo.Visible = False
            lblResult.Text = ""
            LotesVencidos()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            pnlVencidos.Visible = False
            pnlNoVencidos.Visible = True
            pnlVencidosMeses.Visible = False
            pnlStockMinimo.Visible = False
            lblResult.Text = ""
            LotesNoVencidos()
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            pnlVencidos.Visible = False
            pnlNoVencidos.Visible = False
            pnlVencidosMeses.Visible = True
            pnlStockMinimo.Visible = False
            lblResult.Text = ""
            VencidosMeses()
        End Sub

        Protected Sub lbtn4_Click(sender As Object, e As EventArgs) Handles lbtn4.Click
            pnlVencidos.Visible = False
            pnlNoVencidos.Visible = False
            pnlVencidosMeses.Visible = False
            pnlStockMinimo.Visible = True
            lblResult.Text = ""
            StockMinimo()
        End Sub


    End Class
End Namespace
