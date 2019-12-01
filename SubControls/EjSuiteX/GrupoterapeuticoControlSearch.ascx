<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GrupoterapeuticoControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.GrupoterapeuticoControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/GrupoterapeuticoControl.ascx" TagName="GrupoterapeuticoControl"
    TagPrefix="gtc" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un código de grupo de ventas"></asp:Label>&nbsp;
            <gtc:GrupoterapeuticoControl ID="gtcGrupoTerapeutico" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
