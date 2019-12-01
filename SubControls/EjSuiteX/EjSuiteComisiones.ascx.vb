Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteComisiones
        Inherits EjSuiteModuleBase

        Private sumatoria As Decimal
        Private sumacobro As Decimal

        Private Sub CargarVentasVendedor()
            Dim ds As DataSet = SPs.SpVentasEmpleado(VendedorControlSearch1.EmpleadoId, txtDesdeComision.Text, txtHastaComision.Text).GetDataSet
            Dim total As Decimal = 0

            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim dr As DataRow = ds.Tables(0).Rows(i)
                total = total + CDec(dr(5))
            Next

            lblComision.Text = String.Format("{0:f}", total * (CDec(txtComision.Text) / 100))
            grdVentasVendedor.DataSource = ds.Tables(0).DefaultView
            grdVentasVendedor.DataKeyNames() = New String() {"nCodEmpleado"}
            grdVentasVendedor.DataBind()
            lblMessage.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            panelViewVentasVendedor.Visible = True

            'Dim ds1 As DataSet = SPs.SpCobrosEmpleado(VendedorControlSearch1.EmpleadoId, txtDesdeComision.Text, txtHastaComision.Text).GetDataSet
            'grdCobros.DataSource = ds1.Tables(0).DefaultView
            'grdCobros.DataBind()
            'For i = 0 To ds1.Tables(0).Rows.Count - 1
            '    Dim dr As DataRow = ds1.Tables(0).Rows(i)
            '    total = total + CDec(dr(3))
            'Next
            'lblCobros.Text = String.Format("{0:f}", total * (0.015))

            'ds1 = Nothing
            ds = Nothing
        End Sub

        Private Sub inicializar()
            txtDesdeComision.Text = ""
            txtHastaComision.Text = ""
            txtComision.Text = ""
            lblMessage.Text = ""
            VendedorControlSearch1.TextValue = "Elija un vendedor"
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtComision.Attributes.Add("onkeypress", String.Format(" var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.cmdInsert.ClientID))
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlCalculoComisiones.Visible = True
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsert.Click
            CargarVentasVendedor()
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            pnlCalculoComisiones.Visible = False
        End Sub

        Protected Sub grdVentasVendedor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdVentasVendedor.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdVentasVendedor.PageIndex = indice
            CargarVentasVendedor()
        End Sub

        Protected Sub grdVentasVendedor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVentasVendedor.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    Me.sumatoria = Me.sumatoria + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(3).Text = "Totales"
                    e.Row.Cells(4).Text = String.Format("{0:F}", sumatoria)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub cmdExportarE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExportarE.Click
            If grdVentasVendedor.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteVendedor.xlsx", grdVentasVendedor)
            End If
        End Sub

        'Protected Sub cmdExportarE1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExportarE1.Click
        '    If grdCobros.Rows.Count > 0 Then
        '        GridViewExportUtil.Export("ReporteVendedorCobros.xlsx", grdCobros)
        '    End If
        'End Sub

        'Private Sub grdCobros_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCobros.RowDataBound
        '    Select Case e.Row.RowType
        '        Case DataControlRowType.DataRow
        '            Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(2).Text)
        '            Me.sumacobro = Me.sumacobro + precio
        '        Case DataControlRowType.Footer
        '            e.Row.Cells(1).Text = "Totales"
        '            e.Row.Cells(2).Text = String.Format("{0:F}", sumacobro)
        '        Case Else
        '            Exit Select
        '    End Select
        'End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlCalculoComisiones.Visible = True
            panelViewVentasVendedor.Visible = True
            grdVentasVendedor.DataSource = Nothing
            grdVentasVendedor.DataBind()
        End Sub
    End Class
End Namespace