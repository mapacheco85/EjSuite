Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteVentasPorZonas
        Inherits EjSuiteModuleBase
        Public Sub cargar()
            'Dim qry As SqlQuery = New [Select]().From(VWVentasPorZonas.Schema)

            'If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
            '    qry.Where(VWVentasPorZonas.Columns.Fechaemision).IsGreaterThanOrEqualTo(txtFechainicialRepSucursal.Text)
            '    qry.And(VWVentasPorZonas.Columns.Fechaemision).IsLessThanOrEqualTo(txtFechafinalRepSucursal.Text)
            'End If

            'qry.OrderAsc(VWVentasPorZonas.Columns.Nombres, VWVentasPorZonas.Columns.Fechaemision)

            'Dim lst As New VWVentasPorZonasCollection()
            'lst.LoadAndCloseReader(qry.ExecuteReader)

            'grdRepSucursal.DataSource = lst
            'grdRepSucursal.DataBind()
            'lblMessageRepSucursal.Text = "Se encontraron: " & lst.Count & " registro(s)"

        End Sub


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
                pnlBusqueda1.Visible = False
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            cargar()
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechafinalRepSucursal.Text = ""
            txtFechainicialRepSucursal.Text = ""
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporVentasPorZona.xlsx", grdRepSucursal)
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
        End Sub
    End Class
End Namespace
