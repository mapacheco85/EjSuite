Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users
'Imports System.Data.SqlClient

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteVentaCliente1
        Inherits EjSuiteModuleBase
        Private sumatoria As Decimal
        Private sumatoria1 As Decimal
        'Private MONTO As Decimal
        Private cliente As String

        Private Sub Cargar()
            Dim qry As SqlQuery = New [Select]().From(VwPago.Schema)
            'MONTO = 1000
            'cliente = DropDownList1.SelectedValue
            If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
                qry.Where(VwPago.Columns.DFechaPago).IsGreaterThanOrEqualTo(txtFechainicialRepSucursal.Text)
                qry.And(VwPago.Columns.DFechaPago).IsLessThanOrEqualTo(txtFechafinalRepSucursal.Text)
            End If

            'qry.And(VwDeudasReporte.Columns.Cliente).Like(cliente)
            qry.OrderAsc(VwPago.Columns.CCliente)

            Dim lst As New VwPagoCollection()
            lst.LoadAndCloseReader(qry.ExecuteReader)

            grdRepSucursal.DataSource = lst
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = String.Format("Se encontraron: {0} registro(s)", lst.Count)
        End Sub

        Private Sub cargar2()
            Dim rep As DataSet = SPs.SpPagoConsolidado(txtFechainicialRepSucursal.Text, txtFechafinalRepSucursal.Text).GetDataSet
            grdVendedor.DataSource = rep.Tables(0).DefaultView
            lblMessageRepSucursal1.Text = String.Format("Se encontraron: {0} registro(s)", rep.Tables(0).Rows.Count)
            grdVendedor.DataKeyNames() = New String() {"cliente"}
            grdVendedor.DataBind()
            rep = Nothing

            'Dim qry1 As SqlQuery = New [Select]().From(VwConsoPagos.Schema)

            'If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
            '    qry1.Where(VwConsoPagos.Columns.Fechapago).IsGreaterThanOrEqualTo(txtFechainicialRepSucursal.Text)
            '    qry1.And(VwConsoPagos.Columns.Fechapago).IsLessThanOrEqualTo(txtFechafinalRepSucursal.Text)
            'End If


            'qry1.OrderAsc(VwConsoPagos.Columns.Cliente)

            'Dim lst1 As New VwConsoPagosCollection()
            'lst1.LoadAndCloseReader(qry1.ExecuteReader)

            'grdVendedor.DataSource = lst1
            'grdVendedor.DataBind()
            'lblMessageRepSucursal1.Text = "Se encontraron: " & lst1.Count & " registro(s)"
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
                pnlBusqueda1.Visible = False
                'Dim qry1 As SqlQuery = New [Select]().From(VwSoloClientes.Schema)
                'qry1.OrderAsc(VwDeudasReporte.Columns.Cliente)
                'Dim lst1 As New VwSoloClientesCollection()
                'lst1.LoadAndCloseReader(qry1.ExecuteReader)
                'DropDownList1.DataSource = lst1
                'DropDownList1.DataBind()
            End If

        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            Cargar()
            'cargar2()
            Me.cmdConsolidar.Visible = True
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechafinalRepSucursal.Text = ""
            txtFechainicialRepSucursal.Text = ""

        End Sub
        Private Sub grdRepSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    Me.sumatoria = Me.sumatoria + precio
                Case DataControlRowType.Footer
                    e.Row.Cells(3).Text = "Total:"
                    e.Row.Cells(4).Text = String.Format("{0:F}", sumatoria)
            End Select
        End Sub
        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("PAGOPORCLIENTE.xlsx", grdRepSucursal)

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
                    Dim precio1 As Decimal = Convert.ToDecimal(e.Row.Cells(3).Text)
                    Me.sumatoria1 = Me.sumatoria1 + precio1
                Case DataControlRowType.Footer
                    e.Row.Cells(2).Text = "Total:"
                    e.Row.Cells(3).Text = String.Format("{0:F}", sumatoria1)
            End Select
        End Sub


        Protected Sub cmdConsolidar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdConsolidar.Click
            cargar2()
        End Sub

        Protected Sub lbtnExportarExcel1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel1.Click
            If grdVendedor.Rows.Count > 0 Then
                GridViewExportUtil.Export("PAGOPORCLIENTECONSOLIDADO.xlsx", grdVendedor)
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
        End Sub
    End Class
End Namespace
