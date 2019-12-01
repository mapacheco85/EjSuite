<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AlmacenEmpleadoControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.AlmacenEmpleadoControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/AlmacenEmpleadoControl.ascx" TagName="AlmacenEmpleadoControl"
    TagPrefix="aec" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un almacén"></asp:Label>&nbsp;
            <aec:AlmacenEmpleadoControl ID="aecAlmacen" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
