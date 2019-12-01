<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuitePedido.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuitePedido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VentaControlSearch.ascx" TagName="VentaControlSearch" TagPrefix="uc1" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Registrar Pedidos</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Buscar Pedidos</asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlregistroPedidos" runat="server">
            <table style="width: 100%; border: 2px inset; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="text-align: center;"><b>Producto</b></td>
                    <td style="text-align: center;"><b>Costo Unit.</b></td>
                    <td style="text-align: center;"><b>Cantidad</b></td>
                    <td style="text-align: center;"><b>Totales</b></td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <uc2:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="lblPrecioUnit" runat="server" Text="0,00"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="True" BorderStyle="Inset"
                            BorderWidth="1px" CssClass="NormalTextBox"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="txtCantidad" Display="None" ErrorMessage="Ingrese un valor numerico"
                            Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer"></asp:CompareValidator>
                        <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="CompareValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="lblTotal" runat="server" Text="0,00"></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="cmdInsertA" runat="server" CssClass="CommandButton"
                            Text="+" Width="20px" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertA_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este producto a la Lista?"
                            Enabled="True" TargetControlID="cmdInsertA">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="grdProductos" runat="server"
                AutoGenerateColumns="False" BackColor="White"
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" CssClass="Normal" Width="100%">
                <Columns>
                    <asp:BoundField ControlStyle-Width="200px"  DataField="cantidad"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="detalle" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="Detalle" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="punitario" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="P. Unit." ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="total" HeaderStyle-HorizontalAlign="Center"
                        HeaderText="P. Total" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField DeleteText="Eliminar" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-HorizontalAlign="Center" SelectText="Editar" ShowDeleteButton="true">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Left" VerticalAlign="Top" />
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Left" />
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
                    <asp:Label ID="lblLiteralCompra0" runat="server"></asp:Label>
                    </td>
                    <td style="width: 50%; text-align: right;">Total Factura: Bs.&nbsp;&nbsp;
                    <asp:Label ID="lbTotalCompra0" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: right;">&nbsp; </td>
                    <td style="width: 50%; text-align: center">
                        <asp:Button ID="btnPedido" runat="server" Text="Realizar Pedido" />
                        <cc1:ConfirmButtonExtender ID="btnPedido_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea Realizar el Pedido?" Enabled="True" TargetControlID="btnPedido">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlPedido" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/DesktopModules/EjSuite/Images/ejsuiteff.jpg"
                            Imagestyle="text-align: left;" Height="100px" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="Label1" runat="server" Text="DyR DISTRIBUIDORES" Font-Bold="True"
                            Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="Label2" runat="server" Text="De: EDSON JIMENEZ CANAZA"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="Label3" runat="server" Text="CASA MATRIZ 0" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="Label4" runat="server">
                        Av. LAS AMERICAS 555 ESQ. OCOBAYA<br />
                        Z. VILLA FATIMA<br />
                        TEL/FAX : 2261026 <br />
                        CORREO: contactos@ejsuitebolivia.com <br />
                        LA PAZ - BOLIVIA
                        </asp:Label>
                    </td>
                </tr>
            </table>
            <p>
                <asp:Label ID="lblFecha" runat="server" />

            </p>
            <asp:GridView ID="grdPedido" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                ShowFooter="True" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="cNombreGenerico" HeaderText="Producto"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nCantidad" HeaderText="Cantidad"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nPrecioUnitario" HeaderText="Precio"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nTotal" HeaderText="Total"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
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
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 280px; vertical-align: top; text-align: right;" class="SubHead">Son:&nbsp;&nbsp;
                        <asp:Label ID="lblLiteralCompra" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead" style="vertical-align: top; text-align: right;">Total Pedido: Bs.&nbsp;&nbsp;
                        <asp:Label ID="lblTotalCompra" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlBusquedaPed" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plBuscarPedido" runat="server" ControlName="txtFechaPedido" Suffix=":"
                            Text="Fecha" HelpText="Ingrese la fecha del Pedido" />
                    </td>
                    <td style="vertical-align: top;width: 750px" class="SubHead">
                        <ig:WebDatePicker ID="txtFechaPedido" runat="server" EditMode="CalendarOnly"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>

                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessageCliente" runat="server"></asp:Label>
                        <br />
                        <br />
                        <div style="width: 100%; height: 200px; overflow: scroll">
                            <asp:GridView ID="grdPedidos" runat="server" AutoGenerateColumns="False"
                                Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                EmptyDataText="No se encontraron registros."
                                BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <asp:BoundField DataField="nCodPedido" HeaderText="Código"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cNumeroOC" HeaderText="OC"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dFechaSolicitud" HeaderText="F. Solicitud"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nCodVendedor" HeaderText="Solicitante"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dFechaEntrega" HeaderText="F. Entrega"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:CommandField SelectText="Elegir" ShowSelectButton="True"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                                <RowStyle CssClass="RowStyle" BackColor="White" ForeColor="#003399" />
                                <PagerStyle CssClass="PagerStyle" BackColor="#99CCCC" ForeColor="#003399"
                                    HorizontalAlign="Left" />
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle CssClass="HeaderStyle" BackColor="#003399" Font-Bold="True"
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
        </asp:Panel>
        <article>
            <asp:LinkButton ID="cmdExportarPDF" runat="server" Text="Exportar a PDF" CssClass="CommandButton"
                CausesValidation="False" />
            <cc1:ModalPopupExtender ID="cmdExportarPDF_ModalPopupExtender" runat="server"
                BehaviorID="cmdExportarPDF_ModalPopupExtender" PopupControlID="pnlModalReporte"
                TargetControlID="cmdExportarPDF">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlModalReporte"
                Style="display: none; background-color: InfoBackground; overflow: auto; max-height: 500px; max-width: 500px;"
                runat="server">
                <p style="text-align: right;">
                    <asp:LinkButton ID="lbtnCerrar" runat="server" Text="Cerrar" CssClass="CommandButton"
                        CausesValidation="False" />
                </p>
                <p style="text-align: center; font: bold;">
                    <h2>ORDEN DE COMPRA</h2>
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
<%--<FooterTemplate>
                    <asp:TextBox ID="txtcantidad" runat="server" Enabled="False" 
                        BackColor="#6699FF" ForeColor="Black"></asp:TextBox>
 </FooterTemplate>--%>
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
