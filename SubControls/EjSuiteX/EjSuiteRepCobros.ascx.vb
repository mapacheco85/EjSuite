Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports iTextSharp.text.pdf

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteRepCobros
        Inherits EjSuiteModuleBase

        Private Sub BuscarDeudas()
            
            Dim q As New Query(VwDeuda.Schema)
            q.AddWhere(VwDeuda.Columns.Deuda, Comparison.GreaterThan, 0)
            If txtFechainicialDeudas.Text <> "" Then
                q.AND(VwDeuda.Columns.Emitida, Comparison.GreaterOrEquals, EjSuite.ConvertToUsaFormat(txtFechainicialDeudas.Value.ToString()))
            End If
            If txtFechafinalDeudas.Text <> "" Then
                q.AND(VwDeuda.Columns.Emitida, Comparison.LessOrEquals, EjSuite.ConvertToUsaFormat(txtFechafinalDeudas.Value.ToString()))
            End If
            q.ORDER_BY(VwDeuda.Columns.NNumero)
            Dim lst As New VwDeudaCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdDeudas.DataSource = lst
            grdDeudas.DataKeyNames = New String() {VwDeuda.Columns.NCodFactura}
            grdDeudas.DataBind()
            lblMessageDeudas.Text = "Se encontraron " & lst.Count.ToString() & " registro(s)"
            If lst.Count > 0 Then
                cmdExportarE.Visible = True
            End If
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cmdExportarE.Visible = False
        End Sub

        Protected Sub cmdSearchDeudas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchDeudas.Click
            BuscarDeudas()
        End Sub

        Protected Sub cmdCancelDeudas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelDeudas.Click
            txtFechafinalDeudas.Text = ""
            txtFechainicialDeudas.Text = ""
        End Sub

        Protected Sub cmdExportarE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExportarE.Click
            If grdDeudas.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteDeudas.xlsx", grdDeudas)
            End If
        End Sub
    End Class
End Namespace