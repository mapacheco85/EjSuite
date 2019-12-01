Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users
Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteReporteKardex
        Inherits EjSuiteModuleBase

        Private Sub ReporteKardex()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
            
            Dim qryKardex As New Query(VwReporteKardex.Schema)
            qryKardex.AddWhere(VwReporteKardex.Columns.NCodAlmacen, objAlmacen.NCodAlmacen)
            qryKardex.BETWEEN_AND(VwReporteKardex.Columns.DFechareg, txtFechainicial.Text, txtFechafinal.Text)
            qryKardex.ORDER_BY(VwReporteKardex.Columns.NCodProducto)
            Dim lst As New VwReporteKardexCollection
            lst.LoadAndCloseReader(qryKardex.ExecuteReader)
            grdReporteKardex.DataSource = lst
            grdReporteKardex.DataKeyNames = New String() {VwReporteKardex.Columns.NCodKardex}
            grdReporteKardex.DataBind()
            lblMessageReporteKardex.Text = "Se encontraron " & lst.Count.ToString() & " registro(s)"
            panelbusqueda.Visible = True
            If lst.Count > 0 Then
                lbtnExportarExcel.Visible = True
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlReporteKardex.Visible = True
                grdReporteKardex.DataSource = Nothing
                grdReporteKardex.DataBind()
                txtFechainicial.Text = ""
                txtFechafinal.Text = ""
                lblMessageReporteKardex.Text = ""
                lbtnExportarExcel.Visible = False
            End If
        End Sub

        Protected Sub cmdSearchReporteKardex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchReporteKardex.Click
            ReporteKardex()
        End Sub

        Protected Sub cmdCancelReporteKardex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelReporteKardex.Click
            pnlReporteKardex.Visible = False
        End Sub

        Protected Sub grdReporteKardex_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReporteKardex.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indicenro As Integer = (e.Row.RowIndex) + 1 + (grdReporteKardex.PageIndex * (grdReporteKardex.PageSize))
                    Dim lblNro As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    lblNro.Text = indicenro.ToString
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdReporteKardex.DataKeys(indice).Value, Integer)
                    Dim objReporteKardex As New VwReporteKardex(VwReporteKardex.Columns.NCodKardex, cod)
                    Dim hypReporteKardex As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypReporteKardex.Text = objReporteKardex.DFechareg.ToShortDateString()
            End Select
        End Sub

        Protected Sub grdReporteKardex_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReporteKardex.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblNro As New Label
                    lblNro.CssClass = "CommandButton"
                    e.Row.Cells(0).Controls.Add(lblNro)
                    Dim hypKardex As New Label
                    hypKardex.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypKardex)
            End Select
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdReporteKardex.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteFichaCuenta.xlsx", grdReporteKardex)
            End If
        End Sub

    End Class
End Namespace
