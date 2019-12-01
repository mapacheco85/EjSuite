<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VentaControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.VentaControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ProductoVentaControl.ascx" TagName="ProductoVentaControl"
    TagPrefix="prc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un producto"></asp:Label>&nbsp;
            <prc:ProductoVentaControl ID="prcProducto" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
