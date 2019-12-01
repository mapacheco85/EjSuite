Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports EjSuite.Modules.EjSuite
Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteClientes
        Inherits EjSuiteModuleBase

        Public Enum nTipoProducto
            Clasico = 1
            Cuotas = 2
        End Enum

        Private Sub CargarCliente()
            Dim ds As New DataSet
            ds = SPs.BuscarClientesListado(txtBuscarCliente.Text.Trim()).GetDataSet()

            grdCliente.DataSource = ds.Tables(0).DefaultView
            grdCliente.DataKeyNames() = New String() {"nCodCliente"}
            grdCliente.DataBind()

            lblMessageCliente.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            panelbusCli.Visible = True
        End Sub

        Private Sub CodigoCliente()
            Dim codCliente As String = New [Select](Aggregate.Max("nCodCliente")). _
                From(Cliente.Schema).ExecuteScalar(Of String)()
            If codCliente <> 0 Then
                lblCodigoCliente.Text = CStr(CInt(codCliente) + 1)
            Else
                lblCodigoCliente.Text = "1000"
            End If

        End Sub

        Private Sub inicializar()
            lblCodigoCliente.Text = ""
            txtCiNitCliente.Text = ""
            txtNombreCliente.Text = ""
            txtDireccionCliente.Text = "S/D"
            txtTelefonoCliente.Text = "0"
            txtContacto.Text = ""
            txtReferencias.Text = ""
            txtTelefonoCliente.Text = ""
            txtTelefonoContacto.Text = ""
            
            txtCiNitCliente1.Text = ""
            txtNombreCliente1.Text = ""
            txtDireccionCliente1.Text = ""
            txtTelefonoCliente1.Text = ""
            txtContacto1.Text = ""
            txtReferencias1.Text = ""
            txtTelefonoCliente1.Text = ""
            txtTelefonoContacto1.Text = ""

            txtBuscarCliente.Text = ""
            lblMessageCliente.Text = ""
            chkVisible.Checked = True

            GenerarListadoClientes("")
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

        Protected Sub cmdInsertCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertCliente.Click
            If Page.IsValid Then
                Dim objNewCliente As New Cliente()
                objNewCliente.NCodCliente = CInt(lblCodigoCliente.Text)
                objNewCliente.CNit = txtCiNitCliente.Text.Trim()
                objNewCliente.CCliente = txtNombreCliente.Text.Trim()
                objNewCliente.CDireccion = txtDireccionCliente.Text.Trim()
                objNewCliente.CTelefono = txtTelefonoCliente.Text.Trim()
                objNewCliente.NCodUsuario = UserId
                objNewCliente.NCodZona = ZonaControlSearch1.ZonaId
                objNewCliente.CContacto = txtContacto.Text.Trim()
                objNewCliente.CReferencias = txtReferencias.Text.Trim()
                objNewCliente.CCelularContacto = txtCelular.Text.Trim()
                objNewCliente.CTelefono2 = txtCelular.Text.Trim()
                objNewCliente.BValido = chkVisible.Checked
                objNewCliente.NCodRegion = 1
                objNewCliente.NCodCliente = New [Select](Aggregate.Max(Cliente.Columns.NCodCliente)). _
                    From(Cliente.Schema).ExecuteScalar(Of Integer)() + 1
                objNewCliente.Save()

                Dim objNewBeneficiario As New Beneficiario()
                objNewBeneficiario.NCodCliente = objNewCliente.NCodCliente
                objNewBeneficiario.CNit = txtCiNitCliente.Text
                objNewBeneficiario.CNombre = txtNombreCliente.Text
                objNewBeneficiario.DFechaReg = Now
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
            inicializar()
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
                ViewState("cid") = id
                Dim objCliente As New Cliente(id)
                txtCiNitCliente1.Text = objCliente.CNit
                txtNombreCliente1.Text = objCliente.CCliente
                txtDireccionCliente1.Text = objCliente.CDireccion
                txtTelefonoCliente1.Text = objCliente.CTelefono
                txtContacto1.Text = objCliente.CContacto
                txtReferencias1.Text = objCliente.CReferencias
                txtCelular1.Text = objCliente.CCelularContacto
                txtTelefonoContacto1.Text = objCliente.CTelefono2
                chkVisible1.Checked = objCliente.BValido
                txtBuscarCliente.Text = ""

                If objCliente.NCodZona IsNot Nothing Then
                    ZonaControlSearch2.ZonaId = objCliente.NCodUsuario
                    Dim objZona As New Zona(objCliente.NCodUsuario)
                    ZonaControlSearch2.TextValue = objZona.CDescripcion
                Else
                    ZonaControlSearch2.ZonaId = 0
                    ZonaControlSearch2.TextValue = "Elija una Zona"
                End If

                panelbusCli.Visible = False
                panelviewCli.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateCliente.Click
            If ViewState("cid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As String = CType(ViewState("cid"), String)
                Dim objCliente As New Cliente(id)
                objCliente.CNit = txtCiNitCliente1.Text
                objCliente.CCliente = txtNombreCliente1.Text
                objCliente.CDireccion = txtDireccionCliente1.Text
                objCliente.CTelefono = txtTelefonoCliente1.Text
                objCliente.NCodUsuario = UserId
                objCliente.NCodZona = ZonaControlSearch2.ZonaId
                objCliente.CContacto = txtContacto1.Text
                objCliente.CReferencias = txtReferencias1.Text
                objCliente.CCelularContacto = txtCelular1.Text
                objCliente.CTelefono2 = txtCelular1.Text
                objCliente.BValido = chkVisible1.Checked
                objCliente.Save()
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
                    Cliente.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaCliente.Visible = False
                    pnlNuevoCliente.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaCliente.Visible = False
                pnlNuevoCliente.Visible = False
            End Try
            inicializar()
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            
            Me.lbtnExportarExcel_ModalPopupExtender.Show()
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            CodigoCliente()
            pnlNuevoCliente.Visible = True
            pnlBusquedaCliente.Visible = False
            chkVisible.Checked = True
            chkVisible1.Checked = True
            grdCliente.DataSource = Nothing
            grdCliente.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoCliente.Visible = False
            pnlBusquedaCliente.Visible = True
            panelbusCli.Visible = True
            panelviewCli.Visible = False
            chkVisible.Checked = True
            chkVisible1.Checked = True
            grdCliente.DataSource = Nothing
            grdCliente.DataBind()
        End Sub

        Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
            Me.lbtnExportarExcel_ModalPopupExtender.Hide()
        End Sub

        Public Sub GenerarListadoClientes(ByVal cDato As String)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptClientes"
            rptReporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            rptReporte.ShowParameterPrompts = False
            rptReporte.ShowExportControls = True
            rptReporte.ShowPrintButton = True

            Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport = rptReporte.ServerReport
            Dim Credentials As System.Net.ICredentials = System.Net.CredentialCache.DefaultCredentials

            Dim cred As New ReportServerCredentials(cUsuario, cClave, ".")
            rptReporte.ServerReport.ReportServerCredentials = cred
            ServerReport.ReportServerUrl = New Uri(cDireccion)
            ServerReport.ReportPath = sUbiNomReporte

            Dim prmcDato As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcDato.Name = "cDato"
            prmcDato.Values.Add(cDato)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmcDato}
            ServerReport.SetParameters(parameters)
        End Sub
    End Class
End Namespace
