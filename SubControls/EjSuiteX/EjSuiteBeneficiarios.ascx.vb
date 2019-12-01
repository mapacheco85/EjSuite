Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteBeneficiarios
        Inherits EjSuiteModuleBase

        Private Sub CargarCliente()
            Dim ds As New DataSet
            ds = SPs.VerDatosBeneficiario(txtBuscarCliente.Text.Trim()).GetDataSet()
            grdCliente.DataSource = ds.Tables(0).DefaultView
            grdCliente.DataKeyNames() = New String() {"nCodBeneficiario"}
            grdCliente.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then
                lbtnExportarExcel.Visible = True
            End If
            lblMessageCliente.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            ds = Nothing
            panelbusCli.Visible = True
        End Sub

        Private Sub inicializar()
            txtCiNitCliente.Text = ""
            txtNombreCliente.Text = ""
            txtCiNitCliente1.Text = ""
            txtNombreCliente1.Text = ""
            txtBuscarCliente.Text = ""
            lblMessageCliente.Text = ""
            txtDirBeneficiario.Text = ""
            txtDirBeneficiario1.Text = ""
            BeneficiarioControlSearch1.TextValueCliente = "Elija el Cliente"
            BeneficiarioControlSearch1.ClienteId = "0"
            BeneficiarioControlSearch2.TextValueCliente = "Elija un Cliente"
            BeneficiarioControlSearch2.ClienteId = "0"

            lbtnExportarExcel.Visible = False
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarCliente.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarCliente.ClientID))
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoCliente.Visible = False
                pnlBusquedaCliente.Visible = False
                inicializar()
            End If
        End Sub

        'Protected Sub myBar_ButtonClicked(ByVal sender As Object, ByVal be As Infragistics.WebUI.UltraWebToolbar.ButtonEvent) Handles myBar.ButtonClicked
        '    Dim valor As String = be.Button().Text
        '    Select Case valor
        '    End Select
        'End Sub

        Protected Sub cmdInsertCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertCliente.Click
            If Page.IsValid Then
                Dim objNewBeneficiario As New Beneficiario()
                objNewBeneficiario.NCodBeneficiario = New [Select](Aggregate.Max("nCodBeneficiario")).From(Beneficiario.Schema).ExecuteScalar(Of Integer)() + 1
                objNewBeneficiario.NCodCliente = CLng(BeneficiarioControlSearch1.ClienteId)
                objNewBeneficiario.CNit = txtCiNitCliente.Text
                objNewBeneficiario.CNombre = txtNombreCliente.Text
                objNewBeneficiario.DFechaReg = Now
                objNewBeneficiario.CDireccion = txtDirBeneficiario.Text.Trim()
                objNewBeneficiario.NCodBeneficiario = New [Select](Aggregate.Max(Beneficiario.Columns.NCodBeneficiario)). _
                    From(Beneficiario.Schema).ExecuteScalar(Of Integer)() + 1
                objNewBeneficiario.Save()
                pnlBusquedaCliente.Visible = False
                pnlNuevoCliente.Visible = False
                inicializar()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            End If
        End Sub

        Protected Sub cmdCancelCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelCliente.Click
            txtCiNitCliente.Text = ""
            txtNombreCliente.Text = ""
            txtDirBeneficiario.Text = ""
            inicializar()
            BeneficiarioControlSearch1.TextValueCliente = "Elija el Cliente"
            BeneficiarioControlSearch1.ClienteId = "0"
            pnlBusquedaCliente.Visible = False
            pnlNuevoCliente.Visible = False
        End Sub

        Protected Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarCliente.Click
            CargarCliente()
        End Sub

        Protected Sub grdCliente_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCliente.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdCliente.PageIndex = indice
            CargarCliente()
        End Sub

        Protected Sub grdCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCliente.SelectedIndexChanged
            If grdCliente.SelectedIndex > -1 Then
                Dim indice As Integer = grdCliente.SelectedIndex
                Dim id As String = CType(grdCliente.DataKeys(indice).Value, String)
                ViewState("bid") = id
                Dim objBeneficiario As New Beneficiario(id)
                txtCiNitCliente1.Text = objBeneficiario.CNit
                txtNombreCliente1.Text = objBeneficiario.CNombre
                txtDirBeneficiario1.Text = objBeneficiario.CDireccion
                txtBuscarCliente.Text = ""
                If objBeneficiario.NCodCliente <> "0" Then
                    BeneficiarioControlSearch2.ClienteId = objBeneficiario.NCodCliente.ToString()
                    Dim objCliente As New Cliente(objBeneficiario.NCodCliente)
                    BeneficiarioControlSearch2.TextValueCliente = objCliente.CCliente.ToUpper()
                Else
                    BeneficiarioControlSearch2.TextValueCliente = "Elija un Cliente"
                    BeneficiarioControlSearch2.ClienteId = "0"
                End If

                panelbusCli.Visible = False
                panelviewCli.Visible = True
                lbtnExportarExcel.Visible = False
            End If
        End Sub

        Protected Sub cmdUpdateCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateCliente.Click
            If ViewState("bid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As String = CType(ViewState("bid"), String)
                Dim objBeneficiario As New Beneficiario(id)
                objBeneficiario.CNit = txtCiNitCliente1.Text
                objBeneficiario.CNombre = txtNombreCliente1.Text
                objBeneficiario.DFechaReg = Now
                objBeneficiario.NCodCliente = BeneficiarioControlSearch2.ClienteId
                objBeneficiario.CDireccion = txtDirBeneficiario1.Text.Trim()
                objBeneficiario.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaCliente.Visible = False
                pnlNuevoCliente.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdDeleteCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteCliente.Click
            Try
                If ViewState("cid") IsNot Nothing Then
                    Dim id As String = CType(ViewState("cid"), String)
                    Beneficiario.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaCliente.Visible = False
                    pnlNuevoCliente.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "Tiene dependencias este item!")
                pnlBusquedaCliente.Visible = False
                pnlNuevoCliente.Visible = False
            End Try
            inicializar()
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdCliente.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReporteBeneficiarios.xlsx", grdCliente)
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoCliente.Visible = True
            pnlBusquedaCliente.Visible = False
            grdCliente.DataSource = Nothing
            grdCliente.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoCliente.Visible = False
            pnlBusquedaCliente.Visible = True
            panelbusCli.Visible = True
            panelviewCli.Visible = False
            grdCliente.DataSource = Nothing
            grdCliente.DataBind()
        End Sub
    End Class
End Namespace
