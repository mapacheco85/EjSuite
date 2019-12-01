<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SucursalControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.SucursalControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/SucursalControl.ascx" TagName="SucursalControl"
    TagPrefix="suc" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija una sucursal"></asp:Label>&nbsp;
            <suc:SucursalControl ID="sucSucursal" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
