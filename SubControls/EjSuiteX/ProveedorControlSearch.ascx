<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProveedorControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProveedorControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ProveedorControl.ascx" TagName="ProveedorControl"
    TagPrefix="prc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un proveedor"></asp:Label>&nbsp;
            <prc:ProveedorControl ID="prcProveedor" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
