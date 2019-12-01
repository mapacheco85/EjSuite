<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PagoCliente.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.PagoCliente" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Src="../../Controls/ClienteControl1.ascx" TagName="ClienteControl" TagPrefix="clic" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 255px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plClienteid" runat="server" Suffix=":" Text="Cliente" HelpText="Elija un cliente" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                    <clic:ClienteControl ID="clicCliente" runat="server" />
                    <asp:HiddenField ID="hfClienteId" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 255px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plFacturaPago" runat="server" Suffix=":" Text="Factura" HelpText="Elija una factura" />
                </td>
                <td style="vertical-align: top;">
                    <asp:DropDownList ID="ddlFactura" runat="server" AutoPostBack="True">
                        <asp:ListItem>Elija una Factura</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ErrorMessage="Elija una factura!" ControlToValidate="ddlFactura" Display="None" 
                        Operator="NotEqual" SetFocusOnError="True" ValueToCompare="Elija una Factura"></asp:CompareValidator>
                    <asp:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="CompareValidator1">
                    </asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 255px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plSaldoPago" runat="server" Suffix=":" Text="Saldo" HelpText="Saldo actual de pago de la factura seleccionada" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblSaldoPago" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
