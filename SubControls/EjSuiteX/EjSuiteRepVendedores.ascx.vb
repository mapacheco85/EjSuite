Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepVendedores
        Inherits EjSuiteModuleBase

        Private Sub CargarVendedores()
            Dim ds As New DataSet
            ds = SPs.ListarVentasDiarias(txtFechainicialRepSucursal.Text, txtFechafinalRepSucursal.Text).GetDataSet()

            grdRepSucursal.DataSource = ds.Tables(0).DefaultView
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = "Se encontraron: " & ds.Tables(0).DefaultView.Count & " registro(s)"
            ds = Nothing
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
                pnlBusqueda1.Visible = False
                lbtnExportarExcel.Visible = False
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            CargarVendedores()
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechafinalRepSucursal.Text = ""
            txtFechainicialRepSucursal.Text = ""
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteVendedores.xlsx", grdRepSucursal)
            End If

        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
            lbtnExportarExcel.Visible = True
        End Sub
    End Class
End Namespace