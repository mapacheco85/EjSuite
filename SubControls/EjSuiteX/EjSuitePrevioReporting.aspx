<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EjSuitePrevioReporting.aspx.vb" Inherits=".EjSuitePrevioReporting" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Factura a Imprimir</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        &nbsp;<br />
        <asp:UpdatePanel ID="upPanel" runat="server">
            <ContentTemplate>
                &nbsp;<rsweb:ReportViewer ID="rpt1" runat="server" Width="100%" Height="100%"
                    ShowRefreshButton="false" ShowPrintButton="true" ZoomPercent="100"
                    AsyncRendering="false" SizeToReportContent="true" ZoomMode="FullPage">
                </rsweb:ReportViewer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

