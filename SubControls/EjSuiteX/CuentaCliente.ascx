<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CuentaCliente.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.CuentaCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/ClienteControl1.ascx" TagName="ClienteControl" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un cliente"></asp:Label>&nbsp;
            <uc1:ClienteControl ID="cliCliente" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
