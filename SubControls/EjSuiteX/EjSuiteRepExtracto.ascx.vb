Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepExtracto
        Inherits EjSuiteModuleBase

        Private Sub RepExtracto()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '=====================================================================================================
            Dim qryCliCuenta As New Query(VwCuentasCliente.Schema)
            qryCliCuenta.AddWhere(VwCuentasCliente.Columns.NCodSucursal, objSucursal.NCodSucursal)
            qryCliCuenta.BETWEEN_AND(VwCuentasCliente.Columns.DFechaEmision, txtFechainicial.Text, txtFechafinal.Text)
            qryCliCuenta.ORDER_BY(VwCuentasCliente.Columns.NCodCliente)
            Dim lst As New VwCuentasClienteCollection()
            lst.LoadAndCloseReader(qryCliCuenta.ExecuteReader)
            grdRepExtracto.DataSource = lst
            grdRepExtracto.DataKeyNames = New String() {VwCuentasCliente.Columns.NCodFactura}
            grdRepExtracto.DataBind()
            lblMessageExtracto.Text = String.Format("Se encontraron {0} registro(s)", lst.Count)
            panelbusqueda.Visible = True
            If lst.Count > 0 Then
                lbtnExportarExcel.Visible = True
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlClienteExtracto.Visible = True
                panelbusqueda.Visible = True
                txtFechainicial.Text = ""
                txtFechafinal.Text = ""
                lbtnExportarExcel.Visible = False
                lblMessageExtracto.Text = ""
            End If
        End Sub

        Protected Sub cmdSearchExtracto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchExtracto.Click
            RepExtracto()
        End Sub

        Protected Sub cmdCancelExtracto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelExtracto.Click
            pnlClienteExtracto.Visible = False
            txtFechainicial.Text = ""
            txtFechafinal.Text = ""
            lblMessageExtracto.Text = ""
        End Sub

        Protected Sub grdRepExtracto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepExtracto.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdRepExtracto.DataKeys(indice).Value, Integer)
                    Dim objVwCuentasCliente As New VwCuentasCliente(VwCuentasCliente.Columns.NCodFactura, cod)
                    'Dim objVwPago As New VwPago(VwPago.Columns.Pagoid, cod)
                    Dim hypFechaEmision As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypFechaEmision.Text = objVwCuentasCliente.DFechaEmision.Value.ToShortDateString()
                    Dim hypFechaVencimiento As Label = CType(e.Row.Cells(4).Controls(0), Label)
                    hypFechaVencimiento.Text = objVwCuentasCliente.DVencimiento.Value.ToShortDateString()
                    'Dim fechaPago As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    'fechaPago.Text = objVwPago.Fechapago.ToString.Substring(0, 10)
                    Dim hypVwCuentasCliente As Label = CType(e.Row.Cells(7).Controls(0), Label)
                    hypVwCuentasCliente.Text = String.Format("{0:F}", objVwCuentasCliente.Debe - objVwCuentasCliente.Haber)
            End Select
        End Sub

        Protected Sub grdRepExtracto_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepExtracto.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypFechaEmision As New Label
                    hypFechaEmision.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypFechaEmision)
                    Dim hypFechaVencimiento As New Label
                    hypFechaVencimiento.CssClass = "CommandButton"
                    e.Row.Cells(4).Controls.Add(hypFechaVencimiento)
                    Dim hypVwCuentasCliente As New Label
                    hypVwCuentasCliente.CssClass = "CommandButton"
                    e.Row.Cells(7).Controls.Add(hypVwCuentasCliente)
            End Select
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepExtracto.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteFichaCuenta.xlsx", grdRepExtracto)
            End If
        End Sub
    End Class
End Namespace
