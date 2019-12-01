Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteVentaPorVendedorProducto1
        Inherits EjSuiteModuleBase
        Private sumatoria As Decimal
        Private sumatoria1 As Decimal
        Private sumatoria2 As Decimal
        Private sumatoria22 As Decimal
        Private empleado As String
        Private Sub Cargar()
            Dim qry As SqlQuery = New [Select]().From(VwVentasPorVendedor.Schema)
            'ven = DropDownList1.SelectedValue
            If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
                qry.Where(VwVentasPorVendedor.Columns.DFechaEmision).IsGreaterThanOrEqualTo(txtFechainicialRepSucursal.Text)
                qry.And(VwVentasPorVendedor.Columns.DFechaEmision).IsLessThanOrEqualTo(txtFechafinalRepSucursal.Text)
            End If
            empleado = DropDownList1.SelectedValue
            If empleado = "JOSE LUIS ARRATIA" Then
                qry.And(VwVentasPorVendedor.Columns.NCodEmpleado).IsEqualTo(9)
            End If
            If empleado = "Mabel Aruni" Then
                qry.And(VwVentasPorVendedor.Columns.NCodEmpleado).IsEqualTo(16)
            End If
            If empleado = "Alexis Franco" Then
                qry.And(VwVentasPorVendedor.Columns.NCodEmpleado).IsEqualTo(10)
            End If
            If empleado = "cecilia pacheco" Then
                qry.And(VwVentasPorVendedor.Columns.NCodEmpleado).IsEqualTo(7)
            End If
            'qry.And(VwDeudasReporte.Columns.Vendedor).Like(ven)

            qry.OrderDesc(VwVentasPorVendedor.Columns.DFechaEmision)

            Dim lst As New VwVentasPorVendedorCollection()
            lst.LoadAndCloseReader(qry.ExecuteReader)

            grdRepSucursal.DataSource = lst
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = String.Format("Se encontraron: {0} registro(s)", lst.Count)
        End Sub
        Private Sub cargar2()
            Dim rep As DataSet = SPs.SpVentasPorVendedor(txtFechainicialRepSucursal.Text, txtFechafinalRepSucursal.Text).GetDataSet
            grdVendedor.DataSource = rep.Tables(0).DefaultView
            lblMessageRepSucursal1.Text = String.Format("Se encontraron: {0} registro(s)", rep.Tables(0).Rows.Count)
            grdVendedor.DataKeyNames() = New String() {"VENDEDOR"}
            grdVendedor.DataBind()
            rep = Nothing
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
                pnlBusqueda1.Visible = False
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            Cargar()
            cmdConsolidar.Visible = True
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechafinalRepSucursal.Text = ""
            txtFechainicialRepSucursal.Text = ""
        End Sub
        Private Sub grdRepSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(7).Text)
                    Me.sumatoria = Me.sumatoria + precio
                    Dim precio1 As Decimal = Convert.ToDecimal(e.Row.Cells(8).Text)
                    Me.sumatoria1 = Me.sumatoria1 + precio1
                Case DataControlRowType.Footer
                    e.Row.Cells(6).Text = "Totales:"
                    e.Row.Cells(7).Text = String.Format("{0:F}", sumatoria)
                    e.Row.Cells(8).Text = String.Format("{0:F}", sumatoria1)
            End Select
        End Sub
        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("VENDEDORCLIENTE.xlsx", grdRepSucursal)
            End If
        End Sub

        Protected Sub cmdConsolidar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdConsolidar.Click
            cargar2()
        End Sub

        Protected Sub lbtnExportarExcel1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel1.Click
            If grdVendedor.Rows.Count > 0 Then
                GridViewExportUtil.Export("VendedorClienteConsolidado.xlsx", grdVendedor)
            End If
        End Sub

        Private Sub grdVendedor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdVendedor.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdVendedor.PageIndex = indice
            cargar2()
        End Sub

        Private Sub grdVendedor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVendedor.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(1).Text)
                    Me.sumatoria2 = Me.sumatoria2 + precio
                    Dim precio1 As Decimal = Convert.ToDecimal(e.Row.Cells(2).Text)
                    Me.sumatoria22 = Me.sumatoria22 + precio1
                Case DataControlRowType.Footer
                    e.Row.Cells(0).Text = "Totales:"
                    e.Row.Cells(1).Text = String.Format("{0:F}", sumatoria2)
                    e.Row.Cells(2).Text = String.Format("{0:F}", sumatoria22)
            End Select
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
        End Sub
    End Class
End Namespace
