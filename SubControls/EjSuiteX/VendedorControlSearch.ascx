<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VendedorControlSearch.ascx.vb" 
Inherits="EjSuite.Modules.EjSuite.VendedorControlSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register src="../../Controls/VendedorControl.ascx" tagname="VendedorControl" tagprefix="uc1" %>

<asp:UpdatePanel ID="upPanel1" runat="server">
<ContentTemplate>
    <div>
        <asp:Label ID="txt1" runat="server" Text="Elija un vendedor"></asp:Label>&nbsp;
        <uc1:VendedorControl ID="venVendedor" runat="server" />
    </div>
</ContentTemplate>
</asp:UpdatePanel>
