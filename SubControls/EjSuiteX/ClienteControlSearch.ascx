<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ClienteControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ClienteControlSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ClienteControl.ascx" TagName="ClienteControl" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel2" runat="server">
    <ContentTemplate>
        <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 25%; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plClienteid" runat="server" Suffix=":" Text="Código Cliente"
                        HelpText="Elija el código del Cliente" />
                </td>
                <td style="width: 75%; vertical-align: top;">
                    <asp:Label ID="lblCliente" runat="server"></asp:Label>
                    <uc1:ClienteControl ID="cliCliente" runat="server" />
                    <asp:HiddenField ID="hfClienteId" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plBeneficiarioId" runat="server" Suffix=":" Text="Nombre Factura"
                        HelpText="Elija el Beneficiario de la Factura" />
                </td>
                <td style="width: 75%; vertical-align: top;">
                    <asp:DropDownList ID="ddlBeneficiario" runat="server" AutoPostBack="True" Width="350px">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="ddlBeneficiario" Display="None" 
                        ErrorMessage="Elija un beneficiario!" Operator="NotEqual" 
                        SetFocusOnError="True" ValueToCompare="Elija beneficiario"></asp:CompareValidator>
                    <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="CompareValidator1">
                    </cc1:ValidatorCalloutExtender>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: top;" colspan="2">
                    <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                        <tr>
                            <td style="width: 25%; vertical-align: top; text-align:left;" class="SubHead">
                                <dnn:label ID="plNombreCliente" runat="server" Suffix=":" Text="Se&ntilde;or(es)"
                                    HelpText="Datos del Cliente" />
                            </td>
                            <td style="width: 25%; vertical-align: top; text-align:left;" class="SubHead">
                                <asp:TextBox ID="lblNombreCliente" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 25%; vertical-align: top; text-align:left;" class="SubHead">
                                <dnn:label ID="plNitCiCliente" runat="server" Suffix=":" Text="NIT/CI" HelpText="NIT o CI del Cliente" />
                            </td>
                            <td style="width: 25%; vertical-align: top; text-align:left;" class="SubHead">
                                <asp:TextBox ID="lblNitCiCliente" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
