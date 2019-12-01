<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BeneficiarioControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.BeneficiarioControlSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ClienteControl1.ascx" TagName="ClienteControl" TagPrefix="uc321" %>
<%@ Register Src="../../Controls/VendedorControl.ascx" TagName="VendedorControl"
    TagPrefix="uc123" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <asp:Label ID="txt1" runat="server" Text="Elija un cliente"></asp:Label>&nbsp;
        <uc321:ClienteControl ID="cliCliente" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
