<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProveedorMarcaSearchControl.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProveedorMarcaSearchControl" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProveedorControlSearch.ascx" TagName="ProveedorControlSearch" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/ProveedorControl.ascx" TagName="ProveedorControl"
    TagPrefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 30%; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plIdProducto" runat="server" Suffix=":" Text="Proveedor" HelpText="Elija el proveedor"
                        ControlName="ProveedorControlSearch2" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                    <uc2:ProveedorControl ID="prc1" runat="server" />
                    <asp:HiddenField ID="hfProveedorId" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 30%; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plMarcaIdProducto" runat="server" ControlName="dllMarcaIdProducto"
                        HelpText="Elija la marca" Suffix=":" Text="Marca" />
                </td>
                <td style="vertical-align: top;">
                    <asp:DropDownList ID="dllMarcaIdProducto" runat="server" AutoPostBack="True">
                        <asp:ListItem>Elija Marca</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="dllMarcaIdProducto" Display="None" 
                        ErrorMessage="Elija una marca" Operator="NotEqual" SetFocusOnError="True" 
                        ValueToCompare="Elija una marca"></asp:CompareValidator>
                    <asp:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="CompareValidator1">
                    </asp:ValidatorCalloutExtender>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
