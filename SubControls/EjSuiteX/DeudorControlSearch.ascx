<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DeudorControlSearch.ascx.vb" 
Inherits="EjSuite.Modules.EjSuite.DeudorControlSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register src="../../Controls/DeudorControl.ascx" tagname="DeudorControl" tagprefix="uc1" %>

<asp:UpdatePanel ID="upPanel1" runat="server">
<ContentTemplate>
    <div>
        <asp:Label ID="txt1" runat="server" Text="Deudores"></asp:Label>&nbsp;
        
        <uc1:DeudorControl ID="deuDeudor" runat="server" />
        
    </div>
</ContentTemplate>
</asp:UpdatePanel>
