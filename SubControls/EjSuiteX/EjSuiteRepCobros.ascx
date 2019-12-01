<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteRepCobros.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteRepCobros" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <br />
        <asp:Panel ID="pnlBusquedaDeudas" runat="server" Width="100%">
            <fieldset id="panelbusDeuda" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicialDeudas" runat="server" ControlName="txtFechainicialDeudas"
                                Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicialDeudas" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicialDeudas"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechafinalDeudas"
                                ControlToValidate="txtFechainicialDeudas" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalDeudas" runat="server" ControlName="txtFechafinalDeudas"
                                Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalDeudas" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinalDeudas"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdSearchDeudas" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdCancelDeudas" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblMessageDeudas" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 500px; overflow: scroll">
                                <asp:GridView ID="grdDeudas" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nCodCliente" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cliente" HeaderText="CLIENTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vendedor" HeaderText="VENDEDOR" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="numero" HeaderText="FACTURA No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="emitida" HeaderText="EMITIDA EL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vence" HeaderText="VENCE EL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Deuda" HeaderText="SALDO" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <p>
                <asp:LinkButton ID="cmdExportarE" runat="server" Text="Exportar Excel" CssClass="CommandButton"
                CausesValidation="False" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
        </p>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdExportarE" />
        <asp:PostBackTrigger ControlID="cmdExportarSQL" />
    </Triggers>
</asp:UpdatePanel>
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
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
