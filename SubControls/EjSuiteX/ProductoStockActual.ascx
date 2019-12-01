<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductoStockActual.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProductoStockActual" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ProductoControl.ascx" TagName="ProductoControl"
    TagPrefix="prc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <table style="width: 500px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="width: 120px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plProductoid" runat="server" Suffix=":" Text="Producto" HelpText="Elija un producto" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblProducto" runat="server"></asp:Label>
                    <prc:ProductoControl ID="prcProducto" runat="server" />
                    <asp:HiddenField ID="hfProductoId" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 120px; vertical-align: top;" class="SubHead">
                    <dnn:label ID="plStockActualProducto" runat="server" Suffix=":" Text="Stock actual"
                        HelpText="Stock actual del producto" />
                </td>
                <td style="vertical-align: top;">
                    <asp:Label ID="lblStockActualProducto" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
