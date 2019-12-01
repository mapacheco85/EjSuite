<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductoControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProductoControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ProductoControl.ascx" TagName="ProductoControl"
    TagPrefix="prc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un producto"></asp:Label>&nbsp;
            <prc:ProductoControl ID="prcProducto" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
