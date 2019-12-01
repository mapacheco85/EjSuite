Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports iTextSharp.text.pdf
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteClienteMora
        Inherits EjSuiteModuleBase

        Private Sub ClientesMora()
            Dim nUsuarioId As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, nUsuarioId)
            Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
            Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
            '=====================================================================================================
            Dim ds As New DataSet
            ds = SPs.BuscarClientesMora(objSucursal.NCodSucursal, txtFechainicial.Text, txtFechafinal.Text).GetDataSet()
            grdClientesMora.DataSource = ds.Tables(0).DefaultView
            grdClientesMora.DataKeyNames = New String() {"nCodFactura"}
            grdClientesMora.DataBind()
            lblMessageClientesMora.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)
            ds = Nothing
            panelbusqueda.Visible = True
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack() Then
                pnlClientesMora.Visible = True
                panelbusqueda.Visible = True
                txtFechainicial.Text = ""
                txtFechafinal.Text = ""
                lblMessageClientesMora.Text = ""
            End If
        End Sub

        Protected Sub cmdSearchClientesMora_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchClientesMora.Click
            ClientesMora()
        End Sub

        Protected Sub cmdCancelClientesMora_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelClientesMora.Click
            pnlClientesMora.Visible = False
            txtFechainicial.Text = ""
            txtFechafinal.Text = ""
            lblMessageClientesMora.Text = ""
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdClientesMora.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteClientesEnMora.xlsx", grdClientesMora)
            End If
        End Sub

        Protected Sub grdClientesMora_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientesMora.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim nIndice As Integer = (e.Row.RowIndex) + 1 + (grdClientesMora.PageIndex * (grdClientesMora.PageSize))
                    Dim lblNumero As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    lblNumero.Text = nIndice.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdClientesMora_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientesMora.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblNumero As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(0).Controls.Add(lblNumero)
                Case Else
                    Exit Select
            End Select
        End Sub

    End Class
End Namespace
