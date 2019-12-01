<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ZonaControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ZonaControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ZonaControl.ascx" TagName="ZonaControl" TagPrefix="suc" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija una zona"></asp:Label>&nbsp;
            <suc:ZonaControl ID="sucZona" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
