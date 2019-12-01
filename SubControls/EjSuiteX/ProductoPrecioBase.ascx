<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductoPrecioBase.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProductoPrecioBase" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Src="ProveedorControlSearch.ascx" TagName="ProveedorControlSearch" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/ProveedorControl.ascx" TagName="ProveedorControl"
    TagPrefix="uc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ProductoControl.ascx" TagName="ProductoControl"
    TagPrefix="uc3" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <table style="width: 440px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 120px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plProductoidLote" runat="server" Suffix=":" Text="Id Producto" HelpText="Id de Producto" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblProducto" runat="server"></asp:Label>
                    <uc3:ProductoControl ID="ProductoControl1" runat="server" />
                    <asp:HiddenField ID="hfProductoId" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 120px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plPrecioanteriorenvaseLote" runat="server" ControlName="txtPrecioanteriorenvaseLote"
                        Suffix=":" Text="Precio anterior envase" HelpText="Precio anterior del envase del Lote" />
                </td>
                <td style="vertical-align: top;">
                    <asp:TextBox ID="txtPrecioanteriorenvaseLote" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
