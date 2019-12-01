Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteTotalCompraCliente1
        Inherits EjSuiteModuleBase
        Private sumatoria As Decimal
        Private MONTO As Decimal
        Private Sub Cargar()

            Dim qry As SqlQuery = New [Select]().From(VwDeudasReporte.Schema)
            MONTO = 1000
            If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
                qry.Where(VwDeudasReporte.Columns.Emitida).IsGreaterThanOrEqualTo(txtFechainicialRepSucursal.Text)
                qry.And(VwDeudasReporte.Columns.Emitida).IsLessThanOrEqualTo(txtFechafinalRepSucursal.Text)
            End If
            qry.And(VwDeudasReporte.Columns.Deuda).IsEqualTo(0)
            qry.OrderAsc(VwDeudasReporte.Columns.CCliente)

            Dim lst As New VwDeudasReporteCollection()
            lst.LoadAndCloseReader(qry.ExecuteReader)

            grdRepSucursal.DataSource = lst
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = String.Format("Se encontraron: {0} registro(s)", lst.Count)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            Cargar()
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechafinalRepSucursal.Text = ""
            txtFechainicialRepSucursal.Text = ""
        End Sub
        Private Sub grdRepSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    'e.Row.Cells(0).CssClass = "locked"
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    Me.sumatoria = Me.sumatoria + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(3).Text = "Total unidades:"
                    e.Row.Cells(4).Text = String.Format("{0:F}", sumatoria)
                Case Else
                    Exit Select
            End Select
        End Sub
        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("CompraClienteTotal.xlsx", grdRepSucursal)
            End If
        End Sub

    End Class
End Namespace
