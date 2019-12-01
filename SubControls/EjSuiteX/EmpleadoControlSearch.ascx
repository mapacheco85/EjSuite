<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EmpleadoControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EmpleadoControlSearch" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="../../Controls/EmpleadoControl.ascx" TagName="EmpleadoControl"
    TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="txt1" runat="server" Text="Elija un empleado"></asp:Label>&nbsp;
            <uc1:EmpleadoControl ID="emcEmpleado" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
