Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepSucursal
        Inherits EjSuiteModuleBase

        Private sumascliente As Decimal

        Private Sub CargarRepSucursal()
            Dim envases As DataSet = SPs.SpReportePreferencias(txtFechainicialRepSucursal.Text, txtFechafinalRepSucursal.Text).GetDataSet
            grdRepSucursal.DataSource = envases.Tables(0).DefaultView
            grdRepSucursal.DataKeyNames = New String() {"nCodProducto"}
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = "Se encontraron: " & envases.Tables(0).Rows.Count & " registro(s)"
            panelbusRepS.Visible = True
            envases = Nothing
        End Sub

        Private Sub CargarRepConsolidado()
            Dim envases As DataSet = SPs.SpReporteConsolidado(txtFechainicialRepConsolidado.Text, txtFechafinalRepConsolidado.Text).GetDataSet
            grdConsolidados.DataSource = envases.Tables(0).DefaultView
            grdConsolidados.DataKeyNames = New String() {"nCodProducto"}
            grdConsolidados.DataBind()
            lblRes.Text = "Se encontraron: " & envases.Tables(0).Rows.Count & " registro(s)"
            panelbusRepC.Visible = True
            envases = Nothing
        End Sub

        Private Sub CargarRepProductos()
            Dim envases As DataSet = SPs.SpReporteGlobalProductos(txtFechainicialRepProducto.Text, txtFechafinalRepProducto.Text).GetDataSet
            grdProductos.DataSource = envases.Tables(0).DefaultView
            grdProductos.DataKeyNames = New String() {"nCodProducto"}
            grdProductos.DataBind()
            lblBusqueda.Text = "Se encontraron: " & envases.Tables(0).Rows.Count & " registro(s)"
            panelbusRepP.Visible = True
            envases = Nothing
        End Sub

        Private Sub inicializar()
            txtFechainicialRepSucursal.Text = ""
            txtFechafinalRepSucursal.Text = ""
            lblMessageRepSucursal.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusqueda1.Visible = False
                pnlBusqueda2.Visible = False
                pnlBusqueda3.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            CargarRepSucursal()
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            pnlBusqueda1.Visible = False
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReportePreferencias.xlsx", grdRepSucursal)
            End If
            If grdProductos.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteProductosGlobal.xlsx", grdProductos)
            End If
            If grdConsolidados.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteConsolidado.xlsx", grdConsolidados)
            End If
        End Sub

        Private Sub grdRepSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(5).Text)
                    Me.sumascliente = Me.sumascliente + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(4).Text = "Totales"
                    e.Row.Cells(5).Text = String.Format("{0:F}", sumascliente)
            End Select
        End Sub

        Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
            CargarRepConsolidado()
        End Sub

        Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            pnlBusqueda2.Visible = False
        End Sub

        Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar1.Click
            CargarRepProductos()
        End Sub

        Protected Sub btnCancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar1.Click
            pnlBusqueda3.Visible = False
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlBusqueda1.Visible = True
            pnlBusqueda2.Visible = False
            pnlBusqueda3.Visible = False
            panelbusRepS.Visible = True
            panelbusRepC.Visible = False
            panelbusRepP.Visible = False
            grdRepSucursal.DataSource = Nothing
            grdRepSucursal.DataBind()
            grdConsolidados.DataSource = Nothing
            grdConsolidados.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlBusqueda1.Visible = False
            pnlBusqueda2.Visible = True
            pnlBusqueda3.Visible = False
            panelbusRepS.Visible = False
            panelbusRepC.Visible = True
            panelbusRepP.Visible = False
            grdRepSucursal.DataSource = Nothing
            grdRepSucursal.DataBind()
            grdConsolidados.DataSource = Nothing
            grdConsolidados.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            lblRes.Text = ""
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlBusqueda1.Visible = False
            pnlBusqueda2.Visible = False
            pnlBusqueda3.Visible = True
            panelbusRepS.Visible = False
            panelbusRepC.Visible = False
            panelbusRepP.Visible = True
            grdRepSucursal.DataSource = Nothing
            grdRepSucursal.DataBind()
            grdConsolidados.DataSource = Nothing
            grdConsolidados.DataBind()
            grdProductos.DataSource = Nothing
            grdProductos.DataBind()
            lblBusqueda.Text = ""
        End Sub
    End Class
End Namespace
