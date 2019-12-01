<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteIngresos.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteIngresos" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">
					Guia de Ingreso</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">
					Ajuste de Ingresos</asp:LinkButton>
                </td>
            </tr>
        </table>
        <p>&nbsp;</p>
        <asp:Panel ID="pnlNuevoLote" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="lblProductoKardex" runat="server" Suffix=":" Text="Producto" HelpText="Elija un producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plComprobanteLote" runat="server" Suffix=":" Text="Comprobante" HelpText="Comprobante de Lote"
                            ControlName="txtComprobanteLote" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtComprobanteLote" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                            TargetControlID="txtComprobanteLote" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComprobanteLote"
                            Display="None" ErrorMessage="Ingrese el comprobante de Lote" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFacturaLote" runat="server" Suffix=":" Text="Factura" HelpText="Factura del Lote"
                            ControlName="txtFacturaLote" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtFacturaLote" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFormapagoLote" runat="server" Suffix=":" Text="Tipo de compra" HelpText="Compra para el Kardex" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:DropDownList ID="ddlFormapagoLote" runat="server">
                            <asp:ListItem Selected="True">Elija una opcion</asp:ListItem>
                            <asp:ListItem>Contado</asp:ListItem>
                            <asp:ListItem>Bonificado</asp:ListItem>
                            <asp:ListItem>Reintegrado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechaingresoLote" runat="server" ControlName="txtFechaingresoLote"
                            Suffix=":" Text="Fecha ingreso" HelpText="Fecha de ingreso del Lote" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechaingresoLote" runat="server"
                            DisplayModeFormat="d" Culture="es-BO">
                        </ig:WebDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaingresoLote"
                            Display="None" ErrorMessage="Ingrese la fecha de ingreso del lote" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechavctoLote" runat="server" ControlName="txtFechavctoLote" Suffix=":"
                            Text="Fecha de vencimiento" HelpText="Fecha de vencimiento del Lote" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechavctoLote" runat="server" DisplayModeFormat="d" Culture="es-BO">
                        </ig:WebDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plEstadoLote" runat="server" Suffix=":" Text="Estado" HelpText="Estado del Lote" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:RadioButtonList ID="rbtEstadoLote" runat="server" RepeatDirection="Horizontal"
                            Width="293px">
                            <asp:ListItem Selected="True" Value="1">Existente</asp:ListItem>
                            <asp:ListItem Value="0">Vendido/Dado de baja</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plTotalenvasesLote" runat="server" Suffix=":" Text="Total unidades"
                            HelpText="Total unidades de la Guia de Ingreso" ControlName="txtTotalenvasesLote" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtTotalenvasesLote" runat="server" CssClass="NormalTextBox" Width="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                            TargetControlID="txtTotalenvasesLote" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTotalenvasesLote"
                            Display="None" ErrorMessage="Ingrese el total de unidades de la Guia de Ingreso"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator6">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plObservacionesLote" runat="server" Suffix=":" Text="Observaciones"
                            HelpText="Observaciones acerca del Lote" ControlName="txtObservacionesLote" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtObservacionesLote" runat="server" CssClass="NormalTextBox" Width="267px"
                            Height="80px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:LinkButton ID="lbtnAdd" runat="server">Adicionar</asp:LinkButton>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:LinkButton ID="lbtnCancelar" runat="server">Cancelar</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="lbtnIngresar" runat="server" CausesValidation="False">Ingresar Guia de Ingreso Completo</asp:LinkButton>
            <cc1:ConfirmButtonExtender ID="lbtnIngresar_ConfirmButtonExtender" runat="server"
                ConfirmText="Desea ingresar este nuevo Lote de Productos?" Enabled="True" TargetControlID="lbtnIngresar">
            </cc1:ConfirmButtonExtender>
            <br />
            <asp:GridView ID="grdLotes" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nCodProducto" HeaderText="Producto"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cComprobanteRecibo" HeaderText="Comp. Nro."
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cNumeroFactura" HeaderText="Nro. Factura"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cFormaPago" HeaderText="Compra"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="F. Ingreso"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="F. Vcto."
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="bEstadoLote" HeaderText="Estado"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="nTotalEnvases" HeaderText="Total (u)"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cObservaciones" HeaderText="Observaciones"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True"
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
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaLote" runat="server" Width="100%">
            <fieldset id="panelbusLote" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarLote" runat="server" ControlName="txtBuscarLote" Suffix=":"
                                Text="Guia de Ingreso/Producto" HelpText="Ingrese la guia de ingreso o producto para la búsqueda" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarLote" runat="server" Width="330px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarLote" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageLote" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdBusquedaLotes" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cComprobanteRecibo" HeaderText="Comp. Lote" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNombreGenerico" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNombreComercial" HeaderText="Descripción" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nTotalEnvases" HeaderText="Total (u)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
            <fieldset id="panelviewLote" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProductoidLote1" runat="server" Suffix=":" Text="Id Producto" HelpText="Id de Producto" />
                        </td>
                        <td style="vertical-align: top;">
                            <table style="width: 423px">
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:HiddenField ID="hfProductoidLote1" runat="server" />
                                    </td>
                                    <td style="vertical-align: top;">
                                        <asp:Label ID="lblProductoidLote1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plComprobanteLote1" runat="server" Suffix=":" Text="Comprobante" HelpText="Comprobante de Lote"
                                ControlName="txtComprobanteLote1" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblComprobanteLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFacturaLote1" runat="server" Suffix=":" Text="Factura" HelpText="Factura del Lote"
                                ControlName="txtFacturaLote1" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblFacturaLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFormapagoLote1" runat="server" Suffix=":" Text="Tipo de compra"
                                HelpText="Compra para el Kardex" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="ddlFormapagoLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechaingresoLote1" runat="server" ControlName="txtFechaingresoLote1"
                                Suffix=":" Text="Fecha ingreso" HelpText="Fecha de ingreso del Lote" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblFechaingresoLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechavctoLote1" runat="server" ControlName="txtFechavctoLote1" Suffix=":"
                                Text="Fecha de vencimiento" HelpText="Fecha de vencimiento del Lote" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblFechavctoLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plEstadoLote1" runat="server" Suffix=":" Text="Estado" HelpText="Estado del Lote" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblEstadoLote1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plTotalenvasesLote1" runat="server" Suffix=":" Text="Total unidades"
                                HelpText="Total unidades de la Guia de Ingreso" ControlName="txtTotalenvasesLote1" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtTotalenvasesLote1" runat="server" CssClass="NormalTextBox" Width="100px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender13" runat="server" Enabled="True"
                                TargetControlID="txtTotalenvasesLote1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtTotalenvasesLote1"
                                Display="None" ErrorMessage="Ingrese el total de unidades de la Guia de Ingreso"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plObservacionesLote1" runat="server" Suffix=":" Text="Observaciones"
                                HelpText="Observaciones acerca del Lote" ControlName="txtObservacionesLote1" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtObservacionesLote1" runat="server" CssClass="NormalTextBox" Width="267px"
                                Height="80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateLote" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateLote_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateLote">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteLote" runat="server" CssClass="CommandButton" Text="Limpiar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <article>
            <asp:LinkButton ID="lbtnPDF" runat="server" CausesValidation="False">Imprimir Guía</asp:LinkButton>
            <cc1:ModalPopupExtender ID="lbtnPDF_ModalPopupExtender" runat="server"
                BehaviorID="lbtnPDF_ModalPopupExtender" PopupControlID="pnlModalReporte"
                TargetControlID="lbtnPDF">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlModalReporte" Style="display: none; background-color: InfoBackground;"
                runat="server">
                <p style="text-align: right;">
                    <asp:LinkButton ID="cmdCancel" runat="server" Text="Cerrar" CssClass="CommandButton"
                        CausesValidation="False" />
                </p>
                <p style="text-align: center; font: bold;">
                    <h2>REPORTE DE INGRESO DE LOTES</h2>
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
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" />
        <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" />
        <asp:PostBackTrigger ControlID="lbtnPDF" />
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
