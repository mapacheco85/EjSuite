<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteAjusteVentas.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteAjusteVentas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VentaControlSearch.ascx" TagName="VentaControlSearch" TagPrefix="uc1" %>
<%@ Register Src="ClienteControlSearch.ascx" TagName="ClienteControlSearch" TagPrefix="uc2" %>
<%@ Register Src="CuentaCliente.ascx" TagName="CuentaCliente" TagPrefix="uc3" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<%@ Register Src="ClienteVendedorControl.ascx" TagName="ClienteVendedorControl" TagPrefix="uc5" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Ajustes</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Anulacion</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 100%; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">
                    <asp:Label ID="lblResult" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlBusquedaFactura" runat="server" Width="100%">
            <center>
                <b>Ajustes de Facturas</b></center>
            <br />
            <fieldset id="panelbusFact" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBusquedaFactura" runat="server" ControlName="txtBusquedaFactura"
                                Suffix=":" Text="Cliente/No Factura"
                                HelpText="Ingrese el nombre del cliente o el numero de factura" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBusquedaFactura" runat="server" Width="267px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarFactura" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageFactura" runat="server"></asp:Label>
                            <br />
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdFactura" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nNumero" HeaderText="# Factura"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCliente" HeaderText="Cliente"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNit" HeaderText="NIT/CI"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="dFechaEmision" HeaderText="Fecha"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White"
                                        ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True"
                                        ForeColor="#CCCCFF" />
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
            <fieldset id="panelviewFact" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:Image ID="imgLogo" runat="server"
                                Imagestyle="text-align: left;" Height="100px" Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:Label ID="lblEmpresa" runat="server" Font-Bold="True"
                                Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:Label ID="lblPropietario" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:Label ID="lblSucursal" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left;">
                            <asp:Label ID="lblDatos" runat="server">
                 </asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Mensaje" runat="server" Font-Bold="True" Font-Underline="True">Datos para Imprimir en la Factura:</asp:Label>
                <br />
                <br />
                <table style="border: 0px; padding: 0px; border-spacing: 0px; width: 100%;">
                    <tr>
                        <td style="vertical-align: top;" colspan="2">
                            <uc2:ClienteControlSearch ID="ClienteControlSearch1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechaEmision" runat="server" Suffix=":" Text="Fecha Emision" HelpText="Fecha Emision" />
                        </td>
                        <td style="width: 75%; vertical-align: top;" class="SubHead">
                            <asp:Label ID="lblFechaEmision" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="border: 1px; padding: 0px; border-spacing: 0px; width: 100%;">
                    <tr>
                        <td style="text-align: center; font: bold;">Producto</td>
                        <td style="text-align: center; font: bold;">Precio Unitario</td>
                        <td style="text-align: center; font: bold;">Cantidad</td>
                        <td style="text-align: center; font: bold;">Descuento</td>
                        <td style="text-align: center; font: bold;">Totales</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center;">
                            <uc1:VentaControlSearch ID="VentaControlSearch1" runat="server" />
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblPrecioUnit" runat="server" Text="0,00"></asp:Label>
                        </td>
                        <td style="text-align: right;">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="NormalTextBox"
                                AutoPostBack="True" BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ingrese un valor numerico"
                                ControlToValidate="txtCantidad" Display="None" Operator="DataTypeCheck" SetFocusOnError="True"
                                Type="Integer"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                        <td style="text-align: right;">
                            <asp:TextBox ID="txtDescuento" runat="server" CssClass="NormalTextBox"
                                AutoPostBack="True" BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Ingrese un valor numerico"
                                ControlToValidate="txtDescuento" Display="None" Operator="DataTypeCheck" SetFocusOnError="True"
                                Type="Integer"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="CompareValidator2_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator2">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblTotal" runat="server" Text="0,00"></asp:Label>
                        </td>
                        <td style="text-align: center;">
                            <asp:Button ID="cmdInsertA" runat="server" CssClass="CommandButton" Text="+" Width="20px" />
                            <cc1:ConfirmButtonExtender ID="cmdInsertA_ConfirmButtonExtender" runat="server" ConfirmText="Desea ingresar este producto a la Lista?"
                                Enabled="True" TargetControlID="cmdInsertA">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblError0" runat="server" Width="100%"></asp:Label>
                <br />
            </fieldset>
            <fieldset id="panelTotal" runat="server" style="width: 100%">
                <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                    BorderWidth="1px" Width="100%">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <Columns>
                        <asp:BoundField DataField="nCodProducto" HeaderText="Código" ControlStyle-Width="200px" Width="200px" 
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Detalle" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="nCantidad" HeaderText="Cantidad"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="P. Unit."
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="nDescuento" HeaderText="Descuento"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Total"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:CommandField SelectText="Editar" DeleteText="Eliminar"
                            ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    </Columns>
                    <RowStyle ForeColor="#003399" HorizontalAlign="Left" VerticalAlign="Top"
                        BackColor="White" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"
                        HorizontalAlign="Left" />
                    <PagerSettings Position="TopAndBottom" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <br />
                <table style="border: 0px; padding: 0px; border-spacing: 0px; width: 100%;">
                    <tr>
                        <td class="SubHead" style="width: 50%;vertical-align: top; text-align: left;">Son:&nbsp;&nbsp;
                            <asp:Label ID="lblLiteralCompra" runat="server"></asp:Label>
                        </td>
                        <td class="SubHead" style="text-align: right; vertical-align: top;">Total Factura: Bs.&nbsp;&nbsp;
                            <asp:Label ID="lbTotalCompra" runat="server" Text="0.00"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; vertical-align: top; text-align: right;" class="SubHead">Total Descuento: Bs.
                            <asp:Label ID="lblTotalDescuento" runat="server" Text="0.00"></asp:Label>
                        </td>
                        <td class="SubHead" style="text-align: right; vertical-align: top;">
                            <asp:Button ID="cmdFacturar" runat="server" CssClass="StandardButton" Text="Facturar" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <br />
            <fieldset id="panelFacturar" runat="server" style="width: 100%">
                <table style="border: 0px; padding: 0px; border-spacing: 0px; width: 100%;">
                    <tr>
                        <td class="SubHead" style="width: 120px; vertical-align: top;">&nbsp;
                        </td>
                        <td class="SubHead" style="width: 120px; vertical-align: top;">&nbsp;
                        </td>
                        <td class="SubHead" style="width: 120px; vertical-align: top;">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCodigoControl" runat="server" AutoPostBack="True"
                                Suffix=":" Text="Código de Control"
                                HelpText="Código de control generado" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <asp:Label ID="lblCodigoControl" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <article>
                <asp:LinkButton ID="lbtnPDF" runat="server" Visible="false">Imprimir Factura</asp:LinkButton>
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
                        <rsweb:ReportViewer ID="rptReporte" runat="server" AsyncRendering="false" Height="100%"
                             ShowPrintButton="true" ShowRefreshButton="false" SizeToReportContent="true"
                             Width="100%" ZoomMode="FullPage" ZoomPercent="100">
                        </rsweb:ReportViewer>
                    </p>
                </p>
            </asp:Panel>
            </article>
                <asp:Label ID="lblRes" runat="server"></asp:Label>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlAnuladas" runat="server">
            <center>
                <b>Anulación de Facturas</b></center>
            <br />
            <fieldset id="fsAnuladas" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBusquedaAnulada" runat="server"
                                ControlName="txtBusquedaAnulada"
                                Suffix=":" Text="Cliente/No Factura"
                                HelpText="Ingrese el nombre del cliente o el numero de factura" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBusquedaAnulada" runat="server" Width="267px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscaAnulada" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                            <asp:Label ID="lblTotalAnuladas" runat="server" Style="font-weight: 700"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdAnuladas" runat="server"
                                    EmptyDataText="Registros no encontrados."
                                    AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="OK" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nNumero" HeaderText="# Factura"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCliente" HeaderText="Cliente"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNit" HeaderText="NIT/CI"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="dFechaEmision" HeaderText="Fecha"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White"
                                        ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True"
                                        ForeColor="#CCCCFF" />
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
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">&nbsp;
                        </td>
                        <td style="vertical-align: top;">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdate" runat="server" CssClass="CommandButton" Text="Anular"
                                Style="height: 26px" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server"
                                ConfirmText="Desea anular esta(s) factura(s)?"
                                Enabled="True" TargetControlID="cmdUpdate">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdLimpiar" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
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
