Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports System.Net
Imports EjSuite.Modules.EjSuite

Public Class EjSuitePrevioReporting
    Inherits System.Web.UI.Page

    'Dim Mode As DisplayMode = DisplayMode.Normal
    Dim bImprimirAuto As Boolean = False
    Dim bCerrarAuto As Boolean = False

    Dim nEstadoRec As Integer
    Dim nTipoImp As Integer
    Dim ServerReportRec As Microsoft.Reporting.WebForms.ServerReport

    Public Enum nTipoProducto
        Clasico = 1
        Cuotas = 2
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim nCodFactura As String

            If Request.QueryString("nofac") IsNot Nothing Then
                nCodFactura = Request.QueryString("nofac").ToString()
            Else
                nCodFactura = "0"
            End If

            ImprimirFactura(CInt(nCodFactura))
        End If
    End Sub

    Public Sub ImprimirFactura(ByVal nCodFactura As Integer)
        Dim sUbiNomReporte As String
        bImprimirAuto = True
        bCerrarAuto = True
        sUbiNomReporte = "/mkdReports/rptInvoice"

        rpt1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
        rpt1.ShowParameterPrompts = False
        rpt1.ShowExportControls = False
        rpt1.ShowPrintButton = True

        Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport
        ServerReport = rpt1.ServerReport

        Dim Credentials As System.Net.ICredentials
        Credentials = System.Net.CredentialCache.DefaultCredentials

        Dim rsCredentials As ReportServerCredentials
        rsCredentials = ServerReport.ReportServerCredentials

        Dim cred As New ReportServerCredentials("Administrador", "clindamicina", ".")
        rpt1.ServerReport.ReportServerCredentials = cred

        'ServerReport.ReportServerUrl = New Uri(sNomServReportingService)
        ServerReport.ReportServerUrl = New Uri("http://inetEjSuite/ReportServer/")
        ServerReport.ReportPath = sUbiNomReporte


        Dim prmCodFac As New Microsoft.Reporting.WebForms.ReportParameter()
        prmCodFac.Name = "nFactura"
        prmCodFac.Values.Add(nCodFactura)

        Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmCodFac}
        ServerReport.SetParameters(parameters)

    End Sub

End Class