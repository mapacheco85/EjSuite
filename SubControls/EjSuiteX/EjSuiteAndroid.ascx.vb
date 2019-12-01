Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports System.IO
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports System.Security.Cryptography
Imports System.Net

Namespace EjSuite.Modules.EjSuite

    Public Class EjSuiteAndroid
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txtFechafinal.Text = ""
                txtFechainicial.Text = ""
            End If
        End Sub

        Protected Sub cmdSearchExtracto_Click(sender As Object, e As EventArgs) Handles cmdSearchExtracto.Click
            Dim ds As New DataSet()
            ds = SPs.BuscarFacturaReimpresion(txtFechainicial.Text, txtFechafinal.Text).GetDataSet()
            grdRepFactura.DataSource = ds.Tables(0).DefaultView
            grdRepFactura.DataKeyNames = New String() {"nCodFactura"}
            grdRepFactura.DataBind()
            ds = Nothing
        End Sub

        Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
            Dim btnDetails As LinkButton = CType(sender, LinkButton)
            Dim oFila As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
            Dim nCodFactura As Integer = CType(grdRepFactura.DataKeys(oFila.RowIndex).Value, Integer)
            ImprimirFactura(nCodFactura)

            lbtnPDF_ModalPopupExtender.Show()
        End Sub

        Public Sub ImprimirFactura(ByVal nCodFactura As Integer)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptFactura"
            rptReporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            rptReporte.ShowParameterPrompts = False
            rptReporte.ShowExportControls = True
            rptReporte.ShowPrintButton = True

            Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport
            ServerReport = rptReporte.ServerReport

            Dim Credentials As System.Net.ICredentials
            Credentials = System.Net.CredentialCache.DefaultCredentials

            Dim cred As New ReportServerCredentials(cUsuario, cClave, ".")
            rptReporte.ServerReport.ReportServerCredentials = cred
            ServerReport.ReportServerUrl = New Uri(cDireccion)
            ServerReport.ReportPath = sUbiNomReporte

            Dim prmCodFac As New Microsoft.Reporting.WebForms.ReportParameter()
            prmCodFac.Name = "nFactura"
            prmCodFac.Values.Add(nCodFactura)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmCodFac}
            ServerReport.SetParameters(parameters)
        End Sub

        Private Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.lbtnPDF_ModalPopupExtender.Hide()
        End Sub

        Protected Sub lbtnPDF_Click(sender As Object, e As EventArgs) Handles lbtnPDF.Click
            Me.lbtnPDF_ModalPopupExtender.Show()
        End Sub
    End Class
End Namespace