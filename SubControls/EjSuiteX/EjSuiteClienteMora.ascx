<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteClienteMora.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteClienteMora" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
        <br />
        <asp:Panel ID="pnlClientesMora" runat="server" DefaultButton="cmdSearchClientesMora">
            <fieldset id="panelbusqueda" runat="server" style="width: 100%">
                <legend><b>Datos de Búsqueda:</b></legend>
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicial" runat="server" ControlName="txtFechainicial" Suffix=":"
                                Text="Desde" HelpText="Fecha de inicio para la búsqueda" Width="100%" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicial" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicial"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechafinal"
                                ControlToValidate="txtFechainicial" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinal" runat="server" ControlName="txtFechafinal" Suffix=":"
                                Text="Hasta" HelpText="Fecha final para la búsqueda" Width="100%" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinal" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinal"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdSearchClientesMora" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdCancelClientesMora" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblMessageClientesMora" runat="server" Font-Bold="True" Width="100%"></asp:Label>
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdClientesMora" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CssClass="Normal">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No"></asp:TemplateField>
                                        <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nCodCliente" HeaderText="Código" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCliente" HeaderText="Cliente" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerSettings Position="TopAndBottom" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar Reporte a Excel</asp:LinkButton>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lbtnExportarExcel" />
    </Triggers>
</asp:UpdatePanel>
<br />
<asp:UpdateProgress ID="upHeader" runat="server" AssociatedUpdatePanelID="upPanel"
    DisplayAfter="0">
    <ProgressTemplate>
        <br />
        <br />
        <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" runat="server" CssClass="normal" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" />
