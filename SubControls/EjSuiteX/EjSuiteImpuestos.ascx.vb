Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteImpuestos
        Inherits EjSuiteModuleBase
       
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinalRepSucursal.Text = ""
                txtFechainicialRepSucursal.Text = ""
                pnlBusqueda1.Visible = False
            End If
        End Sub

        Private Sub cargareporte()
            Dim consulta As SqlQuery = New [Select]().From(VWDavinci.Schema)
            If txtFechainicialRepSucursal.Text <> "" AndAlso txtFechafinalRepSucursal.Text <> "" Then
                consulta.Where(VWDavinci.Columns.DFechaEmision). _
                    IsGreaterThanOrEqualTo(EjSuite.ConvertToUsaFormat(txtFechainicialRepSucursal.Value.ToString()))
                consulta.And(VWDavinci.Columns.DFechaEmision). _
                    IsLessThanOrEqualTo(EjSuite.ConvertToUsaFormat(txtFechafinalRepSucursal.Value.ToString()))
            End If
            consulta.OrderAsc(VWDavinci.Columns.NNumero, VWDavinci.Columns.DFechaEmision)
            Dim lista As New VWDavinciCollection()
            lista.LoadAndCloseReader(consulta.ExecuteReader)
            grdRepSucursal.DataSource = lista
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = String.Format("Se encontraron: {0} registro(s)", lista.Count)
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            cargareporte()
            Dim dInicio As Date = Date.Parse(txtFechainicialRepSucursal.Value.ToString())
            Dim dFinal As Date = Date.Parse(txtFechafinalRepSucursal.Value.ToString())
            VerDavinci(dInicio, dFinal)
        End Sub

        Protected Sub cmdCancelRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelRepSucursal.Click
            txtFechainicialRepSucursal.Text = ""
            txtFechafinalRepSucursal.Text = ""
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            Me.lbtnExportarExcel_ModalPopupExtender.Show()
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
        End Sub

        Private Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.lbtnExportarExcel_ModalPopupExtender.Hide()
        End Sub

        Public Sub VerDavinci(ByVal dFechaInicio As Date, ByVal dFechaFinal As Date)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptDaVinci"
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

            Dim prmdFechaInicial As New Microsoft.Reporting.WebForms.ReportParameter()
            prmdFechaInicial.Name = "dFechaInicial"
            prmdFechaInicial.Values.Add(dFechaInicio)

            Dim prmcdFechaFinal As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcdFechaFinal.Name = "dFechaFinal"
            prmcdFechaFinal.Values.Add(dFechaFinal)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmdFechaInicial, prmcdFechaFinal}
            ServerReport.SetParameters(parameters)
        End Sub
    End Class
End Namespace
