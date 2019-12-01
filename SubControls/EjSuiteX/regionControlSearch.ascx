<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="regionControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.regionControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/regionControl.ascx" TagName="regionControl" TagPrefix="rgc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija una Sucursal" CssClass="label"></asp:Label>&nbsp;
            <rgc:regionControl ID="cLista" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
