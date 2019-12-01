<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ClienteVendedorControl.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ClienteVendedorControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ClienteControl1.ascx" TagName="ClienteControl" TagPrefix="uc321" %>
<%@ Register Src="../../Controls/VendedorControl.ascx" TagName="VendedorControl"
    TagPrefix="uc123" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <table style="border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 150px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plACuentaDe" runat="server" Suffix=":" 
                        Text="A cuenta de" HelpText="La cuenta del cliente" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="txt1" runat="server" Text="Elija un cliente"></asp:Label>&nbsp;
                    <uc321:ClienteControl ID="cliCliente" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="VendidoPor" runat="server" Suffix=":" Text="Vendedor" HelpText="Elija un vendedor" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="txt2" runat="server" Text="Elija un empleado"></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
