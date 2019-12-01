<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteKardex.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteKardex" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc1" %>
<%@ Register Src="ProductoStockActual.ascx" TagName="ProductoStockActual" TagPrefix="uc2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server"
                        CssClass="ig_Button" CausesValidation="False">Búsqueda Kardex</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server"
                        CssClass="ig_Button" CausesValidation="False">Ajuste de Kardex</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server"
                        CssClass="ig_Button" CausesValidation="False">Reporte General</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 100%; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">&nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlBusquedaKardex" runat="server">
            <fieldset id="panelbusKard" runat="server" style="width: auto">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="lblAlmacenidKardex" runat="server" Suffix=":"
                                Text="Producto" HelpText="Elija un producto" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc1:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicialKardexB" runat="server" ControlName="txtFechainicialKardexB"
                                Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicialKardexB" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                ControlToValidate="txtFechainicialKardexB"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:validatorcalloutextender id="ValidatorCalloutExtender12"
                                runat="server" enabled="True"
                                targetcontrolid="RequiredFieldValidator13">
							</cc1:validatorcalloutextender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToCompare="txtFechafinalKardexB"
                                ControlToValidate="txtFechainicialKardexB"
                                ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:validatorcalloutextender id="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                enabled="True" targetcontrolid="CompareValidator1">
							</cc1:validatorcalloutextender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalKardexB" runat="server"
                                ControlName="txtFechafinalKardexB"
                                Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalKardexB" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                ControlToValidate="txtFechafinalKardexB"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:validatorcalloutextender id="ValidatorCalloutExtender21" runat="server" enabled="True"
                                targetcontrolid="RequiredFieldValidator14">
							</cc1:validatorcalloutextender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdSearchKardexB" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdCancelKardexB" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblMessageKardex" runat="server"></asp:Label>
                            <br />
                            <div style="width: 100%; height: 400px; overflow: scroll">
                                <asp:GridView ID="grdKardex" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Fecha"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cObservacion" HeaderText="Observación"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="P. Unitario"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nStockAnteriorEnvase" HeaderText="Stock anterior(c)"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nStockActualEnvase" HeaderText="Stock actual(c)"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cGlosa" HeaderText="Glosa"
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
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlAjusteKardex" runat="server">
            <fieldset id="panelAjusteKardex" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td colspan="2">
                            <uc2:ProductoStockActual ID="ProductoStockActual1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plUnidadesAjuste" runat="server" ControlName="txtUnidadesAjusteK"
                                Suffix=":" Text="Unidades" HelpText="Número de unidades del producto" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtUnidadesAjusteK" runat="server" CssClass="NormalTextBox" Width="150px"></asp:TextBox>
                            <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender14" runat="server" enabled="True"
                                targetcontrolid="txtUnidadesAjusteK" watermarkcssclass="watermark" watermarktext="*">
							</cc1:textboxwatermarkextender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnidadesAjusteK"
                                Display="None" ErrorMessage="Ingrese el número de unidades del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:validatorcalloutextender id="ValidatorCalloutExtender14" runat="server" enabled="True"
                                targetcontrolid="RequiredFieldValidator2">
							</cc1:validatorcalloutextender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plGlosaAjusteK" runat="server" ControlName="txtGlosaAjusteK" Suffix=":"
                                Text="Glosa" HelpText="Glosa" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtGlosaAjusteK" runat="server" CssClass="NormalTextBox" Width="267px"
                                TextMode="MultiLine" Height="50px"></asp:TextBox>
                            <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender15" runat="server" enabled="True"
                                targetcontrolid="txtGlosaAjusteK" watermarkcssclass="watermark" watermarktext="*">
							</cc1:textboxwatermarkextender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGlosaAjusteK"
                                Display="None" ErrorMessage="Ingrese la glosa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:validatorcalloutextender id="ValidatorCalloutExtender15" runat="server" enabled="True"
                                targetcontrolid="RequiredFieldValidator1">
							</cc1:validatorcalloutextender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDocumentoAjusteK" runat="server" ControlName="txtDocumentoAjusteK"
                                Suffix=":" Text="Documento" HelpText="Documento" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDocumentoAjusteK" runat="server" CssClass="NormalTextBox" Width="267px"
                                TextMode="MultiLine" Height="50px"></asp:TextBox>
                            <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender16" runat="server" enabled="True"
                                targetcontrolid="txtDocumentoAjusteK" watermarkcssclass="watermark" watermarktext="*">
							</cc1:textboxwatermarkextender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDocumentoAjusteK"
                                Display="None" ErrorMessage="Ingrese el documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:validatorcalloutextender id="ValidatorCalloutExtender16" runat="server" enabled="True"
                                targetcontrolid="RequiredFieldValidator3">
							</cc1:validatorcalloutextender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdInsert" runat="server" CssClass="CommandButton" Text="Insertar" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Button ID="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlGeneral" runat="server">
            <table>
                <tr>
                    <td>
                        <dnn:label ID="plOpcion" runat="server" ControlName="ddlOpcion" Suffix=":" Text="Elija una opcion"
                            HelpText="Filtrado producto con stock / sin stock" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:DropDownList ID="ddlOpcion" runat="server" AutoPostBack="True">
                            <asp:ListItem>--Elija una opcion--</asp:ListItem>
                            <asp:ListItem Value="1">Con Stock</asp:ListItem>
                            <asp:ListItem Value="0">Sin stock</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div style="width: 100%; height: 250px; overflow: scroll">
                <asp:GridView ID="grdGeneral" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Proveedor" HeaderText="Proveedor"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="insumo" HeaderText="Producto"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="nStockActualEnvase" HeaderText="Stock Actual"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="F. Reg."
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
        </asp:Panel>
        <br />
        <article>
            <asp:LinkButton ID="lbtnExportarPDF" CssClass="CommandButton" CausesValidation="False"
                runat="server">Exportar Reporte</asp:LinkButton>
            <cc1:modalpopupextender id="lbtnExportarPDF_ModalPopupExtender" runat="server"
                behaviorid="lbtnExportarPDF_ModalPopupExtender" popupcontrolid="pnlModalReporte"
                targetcontrolid="lbtnExportarPDF">
            </cc1:modalpopupextender>
            <asp:Panel ID="pnlModalReporte"
                Style="display: none; background-color: InfoBackground; overflow: auto; max-height: 500px; max-width: 500px;"
                runat="server">
                <p style="text-align: right;">
                    <asp:LinkButton ID="lbtnCerrar" runat="server" Text="Cerrar" CssClass="CommandButton"
                        CausesValidation="False" />
                </p>
                <p style="text-align: center; font: bold;">
                    <h2>REPORTE DE KARDEX DE PRODUCTOS</h2>
                </p>
                <p>
                    <rsweb:ReportViewer ID="rptReporte" runat="server" Width="100%" Height="100%"
                        ShowRefreshButton="false" ShowPrintButton="true" ZoomPercent="100"
                        AsyncRendering="false" SizeToReportContent="true" ZoomMode="FullPage">
                    </rsweb:ReportViewer>
                </p>
            </asp:Panel>
        </article>
    </ContentTemplate>
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
