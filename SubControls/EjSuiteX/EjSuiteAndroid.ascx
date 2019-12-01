<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteAndroid.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteAndroid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <br />
        <fieldset id="fsReimpresion" runat="server" visible="true">
            <legend>Reimpresión de facturas</legend>

            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechainicial" runat="server" ControlName="txtFechainicial" Suffix=":"
                            Text="Desde" HelpText="Fecha de inicio para la búsqueda" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechainicial" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
                            DataMode="Text" Culture="es-BO">
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
                            Text="Hasta" HelpText="Fecha final para la búsqueda" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechafinal" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
                            DataMode="Text" Culture="es-BO">
                        </ig:WebDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                            ControlToValidate="txtFechafinal"
                            Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator14">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdSearchExtracto" runat="server" CssClass="CommandButton" Text="Buscar" />
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelExtracto" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:Label ID="lblMessageExtracto" runat="server" Style="font-weight: 700"></asp:Label>
                        <br />
                        <div style="width: 100%; height: 300px; overflow: scroll">
                            <asp:GridView ID="grdRepFactura" runat="server" AutoGenerateColumns="False" Width="100%"
                                CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" 
                                                CausesValidation="false" Text="Imprimir" OnClick="btnEdit_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nNumero" HeaderText="No. Factura"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emisión"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="nCodCliente" HeaderText="Cod.Cliente"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cCliente" HeaderText="Cliente"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Beneficiario" HeaderText="Beneficiario"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
                        <article>
                            <asp:LinkButton ID="lbtnPDF" runat="server" Style="display: none">Imprimir Factura</asp:LinkButton>
                            <cc1:ModalPopupExtender ID="lbtnPDF_ModalPopupExtender" runat="server"
                                BehaviorID="lbtnPDF_ModalPopupExtender" PopupControlID="pnlModalReporte"
                                TargetControlID="lbtnPDF">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlModalReporte"
                                Style="display: none; background-color: InfoBackground; overflow: auto; max-height: 500px; max-"
                                runat="server">
                                <p style="text-align: right;">
                                    <asp:LinkButton ID="lbtnCerrar" runat="server" Text="Cerrar" CssClass="CommandButton"
                                        CausesValidation="False" />
                                </p>
                                <p style="text-align: center; font: bold;">
                                    <h2>FACTURA</h2>
                                    <p>
                                        <rsweb:reportviewer id="rptReporte" runat="server" asyncrendering="false" height="100%" showprintbutton="true" showrefreshbutton="false" sizetoreportcontent="true" width="100%" zoommode="FullPage" zoompercent="100">
                        </rsweb:reportviewer>
                                    </p>
                                </p>
                            </asp:Panel>
                        </article>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upHeader" runat="server" AssociatedUpdatePanelID="upPanel"
    DisplayAfter="0">
    <ProgressTemplate>
        <br />
        <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" runat="server" CssClass="normal" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />


