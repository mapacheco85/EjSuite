<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuitePedidoFacturacion.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuitePedidoFacturacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VentaControlSearch.ascx" TagName="VentaControlSearch" TagPrefix="uc1" %>
<%@ Register Src="ClienteControlSearch.ascx" TagName="ClienteControlSearch" TagPrefix="uc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="CuentaCliente.ascx" TagName="CuentaCliente" TagPrefix="uc3" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<%@ Register Src="ClienteVendedorControl.ascx" TagName="ClienteVendedorControl" TagPrefix="uc5" %>
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
        <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td style="text-align: left;">
                    <asp:Image ID="imgLogo" runat="server"
                        Imagestyle="text-align: left;" Height="100px" Width="300px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblEmpresa" runat="server" Text="" Font-Bold="True"
                        Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblPropietario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblSucursal" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblDatos" runat="server">
                    </asp:Label><br />
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlProducto" runat="server" Width="100%">
            <br />
            <asp:Label ID="Mensaje" runat="server" Font-Bold="True"
                Font-Underline="True">Datos para Imprimir en la Factura:</asp:Label>
            <br />
            <br />
            <table style="width: 100%; border: 1px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td colspan="2">
                        <uc2:ClienteControlSearch ID="ClienteControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechaEmision" runat="server" Suffix=":"
                            Text="Fecha Emision" HelpText="Fecha Emision" />
                    </td>
                    <td style="width: 75%; vertical-align: top;">
                        <asp:Label ID="txtFechaEmision" runat="server" CssClass="NormalTextBox" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%; border: 3px; padding: 0px; border-spacing: 0px;">
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
                        <asp:TextBox ID="txtCantidad" runat="server"
                            CssClass="NormalTextBox" AutoPostBack="True"
                            BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1"
                            runat="server" ErrorMessage="Ingrese un valor numerico"
                            ControlToValidate="txtCantidad" Display="None"
                            Operator="DataTypeCheck" SetFocusOnError="True"
                            Type="Integer"></asp:CompareValidator>
                        <cc1:ValidatorCalloutExtender
                            ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="CompareValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                    <td style="text-align: right;">
                        <asp:DropDownList ID="txtDescuento" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="lblTotal" runat="server" Text="0,00"></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="cmdInsertA" runat="server"
                            CssClass="CommandButton" Text="+" Width="20px" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertA_ConfirmButtonExtender"
                            runat="server" ConfirmText="Desea ingresar este producto a la Lista?"
                            Enabled="True" TargetControlID="cmdInsertA">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Label ID="lblError0" runat="server"></asp:Label>
        <br />
        <asp:Panel ID="pnlPedido" runat="server" Visible="False">
            <asp:GridView ID="grdProductos" runat="server"
                AutoGenerateColumns="False" CssClass="Normal"
                Width="100%" BackColor="White" BorderColor="#3366CC"
                BorderStyle="None" BorderWidth="1px"
                CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Código"
                        ControlStyle-Width="200px"  ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center">
                        <ControlStyle  />
                    </asp:BoundField>
                    <asp:BoundField DataField="detalle" HeaderText="Producto"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="punitario" HeaderText="P. Unit."
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="descuento" HeaderText="Descuento"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="total" HeaderText="P. Total"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:CommandField SelectText="Editar" DeleteText="Eliminar" ShowDeleteButton="true"
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
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 50%; text-align: left;">Son:&nbsp;&nbsp;
                        <asp:Label ID="lblLiteralCompra" runat="server"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: right;">Total Factura: Bs.&nbsp;&nbsp;
                        <asp:Label ID="lbTotalCompra" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: right;">&nbsp;
                    </td>
                    <td style="width: 50%; text-align: center">
                        <asp:Button ID="cmdFacturar" runat="server" CssClass="StandardButton" Text="Facturar" />
                        <cc1:ConfirmButtonExtender ID="cmdFacturacion_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea registrar esta factura?" Enabled="True" TargetControlID="cmdFacturar">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <fieldset id="panelFacturar" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px">
                            <dnn:label ID="plCodigoControl" runat="server"
                                AutoPostBack="True" Suffix=":" Text="Código de Control"
                                HelpText="Código de control generado" />
                        </td>
                        <td>
                            <asp:Label ID="lblCodigoControl" runat="server" Width="100%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgQr" runat="server" Height="85px" Width="85px" />
                        </td>
                        <td>
                            <asp:Label ID="lblAdvertencia" runat="server" Style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
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
                        <rsweb:ReportViewer ID="rptReporte" runat="server" AsyncRendering="false" Height="100%" ShowPrintButton="true" ShowRefreshButton="false" SizeToReportContent="true" Width="100%" ZoomMode="FullPage" ZoomPercent="100">
                        </rsweb:ReportViewer>
                    </p>
                </p>
            </asp:Panel>
            </article>
            <asp:Label ID="lblRes" runat="server"></asp:Label>
            <br />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upHeader" runat="server" AssociatedUpdatePanelID="upPanel"
    DisplayAfter="0">
    <ProgressTemplate>
        <br />
        <br />
        <asp:Image ID="imgUpdateHeader" runat="server"
             ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" runat="server"
             CssClass="normal" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
