<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteCotizacion.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteCotizacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="sucursalControlSearch.ascx" TagName="sucursalControlSearch" TagPrefix="scs" %>
<%@ Register Src="CotizacionControlSearch.ascx" TagName="CotizacionControlSearch"
    TagPrefix="ccs" %>
<%@ Register Src="CuentaCliente.ascx" TagName="CuentaCliente" TagPrefix="uc3" %>
<%@ Register Src="VentaControlSearch.ascx" TagName="VentaControlSearch" TagPrefix="uc1" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<%@ Register Src="ClienteControlSearch.ascx" TagName="ClienteControlSearch" TagPrefix="uc2" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Nueva Cotización</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Buscar Cotización</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Ejecutar Cotización</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Panel ID="pnlEncabezado" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Image ID="imgLogo" runat="server"
                            Imagestyle="text-align: left;" Height="100px" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="lblEmpresa" runat="server" Text="" Font-Bold="True"
                            Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="lblPropietario" runat="server" Text=""
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="lblSucursal" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left;">
                        <asp:Label ID="lblDatos" runat="server" Font-Bold="True">
                        </asp:Label><br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlNuevaCotizacion" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNroCotizacion" runat="server" Suffix=":" Text="Cotización Nro"
                            HelpText="Código Cotización" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Label ID="lblNroCotizacion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechaEmision" runat="server" Suffix=":" Text="Fecha Emision" HelpText="Fecha Emision" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="NormalTextBox">
                        </asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaEmision_CalendarExtender" runat="server" Enabled="True"
                            Format="dd/MM/yyyy" TargetControlID="txtFechaEmision" TodaysDateFormat="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtFechaEmisionTextBoxWatermarkExtender2" runat="server"
                            Enabled="True" TargetControlID="txtFechaEmision" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFechaEmision"
                            Display="None" ErrorMessage="Ingrese la fecha de emisión" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plClienteCotizacion" runat="server" Suffix=":" Text="Cliente" HelpText="Elija un cliente" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc3:CuentaCliente ID="CuentaCliente1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechaVencimiento" runat="server" Suffix=":" Text="Plazo" HelpText="Seleccione un plazo para la validez de la cotización" />
                    </td>
                    <td style="vertical-align: top; width: 120px;">
                        <asp:DropDownList ID="ddlPlazoCotizacion" runat="server" AutoPostBack="true"
                            Width="150px">
                        </asp:DropDownList><br />
                        <asp:Label ID="txtPlazoCotizacion" runat="server" CssClass="NormalTextBox" Width="150px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plTipoCotizacion" runat="server" Suffix=":" Text="Tipo Cotización" HelpText="Seleccione el tipo de cotizacion" />
                    </td>
                    <td style="vertical-align: top; width: 120px;">
                        <asp:RadioButtonList ID="rblTipoCotizacion" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 100%; border: 3px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="text-align: center; font: bold;"><b>Producto</b></td>
                    <td style="text-align: center; font: bold;"><b>Precio Unitario</b></td>
                    <td style="text-align: center; font: bold;"><b>Cantidad</b></td>
                    <td style="text-align: center; font: bold;"><b>Descuento</b></td>
                    <td style="text-align: center; font: bold;"><b>Totales</b></td>
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
                        <asp:DropDownList ID="txtDescuento" runat="server" AutoPostBack="True" Style="height: 22px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">

                        <asp:Label ID="lblTotal" runat="server" Text="0,00"></asp:Label>

                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="cmdInsertA" runat="server" CssClass="CommandButton"
                            Text="+" Width="20px" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                            ConfirmText="Desea ingresar este producto a la Lista?"
                            Enabled="True" TargetControlID="cmdInsertA">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlCotizacion" runat="server">
            <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Código" ControlStyle-Width="200px" 
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ControlStyle  />
                    </asp:BoundField>
                    <asp:BoundField DataField="detalle" HeaderText="Detalle"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="punitario" HeaderText="P. Unit."
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="descuento" HeaderText="Descuento"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="total" HeaderText="P. Total"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:CommandField SelectText="Editar" DeleteText="Eliminar"
                        ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
            <br />
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 470px; vertical-align: top; text-align: left;" class="SubHead">
                        <%--Son:&nbsp;&nbsp; 
                        <asp:Label ID="lblLiteralCotizacion" runat="server"></asp:Label>--%>
                    </td>
                    <td class="SubHead" style="vertical-align: top; text-align: right;">Total Cotización: Bs.&nbsp;&nbsp;
                        <asp:Label ID="lblTotalCotizacion" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 470px; text-align: right; vertical-align: top;" class="SubHead">&nbsp;
                        <%--<cc1:confirmbuttonextender ID="cmdFacturacion_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Desea Realizar el Pedido?" Enabled="True" 
                            TargetControlID="cmdFacturar">
                            </cc1:confirmbuttonextender>--%>
                    </td>
                    <td class="SubHead" style="vertical-align: top; text-align: right;">
                        <asp:Button ID="cmdCotizar" runat="server" CssClass="StandardButton" Text="RegistrarCotización" />
                        <%--<cc1:confirmbuttonextender ID="cmdCotizar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Desea ingresar esta Cotización?" Enabled="True" 
                    TargetControlID="cmdCotizar">
                </cc1:confirmbuttonextender>--%>
                    </td>
                </tr>
            </table>
            <br />
            <%--<asp:LinkButton ID="lbtnPDF" runat="server">Imprimir Cotización</asp:LinkButton>--%>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaCotizacion" runat="server">
            <fieldset id="panelbusCotizacion" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCotizacion" runat="server" ControlName="txtBuscarCotizacion" Suffix=":"
                                Text="Cliente/Nro Cotización" HelpText="Ingrese el nombre o nro de cotizacion o la fecha de emision de la cotizacion" />
                        </td>
                        <td style="width: 550px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarCotizacion" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarCotizacion" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageCotizacion" runat="server"></asp:Label>
                            <br />
                            <asp:GridView ID="grdCotizacion" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <Columns>
                                    <asp:BoundField DataField="nNumeroCotizacion" HeaderText="No. Cotización"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cCliente" HeaderText="Cliente"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="Fecha Emisión"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="Fecha Vencimiento"
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
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset id="panelviewCotizacion" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 30%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plNroCotizacion1" runat="server" Suffix=":" Text="Cotización Nro"
                                HelpText="Código Cotización" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblNroCotizacion1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechaEmision1" runat="server" Suffix=":" Text="Fecha Emisión"
                                HelpText="Fecha Emisión" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaEmision1" runat="server" CssClass="NormalTextBox"
                                Width="150px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtFechaEmision1_CalendarExtender" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" TargetControlID="txtFechaEmision1" TodaysDateFormat="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plClienteCotizacion1" runat="server" Suffix=":" Text="Cliente" HelpText="Elija un cliente" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc3:CuentaCliente ID="CuentaCliente2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechaVencimiento1" runat="server" Suffix=":" Text="Plazo" HelpText="Seleccione un plazo para la validez de la cotización" />
                        </td>
                        <td style="vertical-align: top; width: 120px">
                            <asp:DropDownList ID="ddlPlazoCotizacion1" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:Label ID="txtPlazoCotizacion1" runat="server" CssClass="NormalTextBox" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plTipoCotizacion1" runat="server" Suffix=":" Text="Tipo Cotización" HelpText="Seleccione el tipo de cotizacion" />
                        </td>
                        <td style="vertical-align: top; width: 120px;">
                            <asp:RadioButtonList ID="rblTipoCotizacion1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"></asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProducto1" runat="server" Suffix=":" Text="Producto" HelpText="Seleccione los productos" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <uc1:VentaControlSearch ID="VentaControlSearch2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCantidad1" runat="server" ControlName="txtCantidad1" Suffix=":"
                                Text="Cantidad" HelpText="Inserte la cantidad del producto" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <asp:TextBox ID="txtCantidad1" runat="server" CssClass="NormalTextBox" Width="60px"
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDescuento1" runat="server" ControlName="txtDescuento1" Suffix=":"
                                Text="Descuento" HelpText="Inserte descuento del producto" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <asp:TextBox ID="txtDescuento1" runat="server" CssClass="NormalTextBox" Width="60px"
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="pltotal1" runat="server" ControlName="lbltotal1" HelpText="Precio a Cobrar por la Cantidad del Producto"
                                Suffix=":" Text="Total del Producto" />
                        </td>
                        <td style="width: 200px; vertical-align: top;">
                            <asp:Label ID="lbltotal1" runat="server" Text="0"></asp:Label>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Button ID="cmdInsertA1" runat="server" CssClass="CommandButton" Text="Adicionar" />
                            <cc1:ConfirmButtonExtender ID="cmdInsertA1_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea ingresar este producto a la Lista?" Enabled="True" TargetControlID="cmdInsertA1">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grdProductosCotizacion" runat="server" AutoGenerateColumns="False"
                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="CODIGO" ControlStyle-Width="200px" 
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ControlStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="detalle" HeaderText="Detalle"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="punitario" HeaderText="P. Unit."
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="descuento" HeaderText="Descuento"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="total" HeaderText="P. Total"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:CommandField SelectText="Editar" DeleteText="Eliminar"
                            ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" />
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
                <br />
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 470px; vertical-align: top; text-align: left;" class="SubHead">
                            <%--Son:&nbsp;&nbsp; 
                            <asp:Label ID="lblLiteralCotizacion" runat="server"></asp:Label>--%>
                        </td>
                        <td class="SubHead" style="vertical-align: top; text-align: right;">Total Cotización: Bs.&nbsp;&nbsp;
                            <asp:Label ID="lblTotalCotizacion1" runat="server" Text="0.00"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 470px; vertical-align: top; text-align: right;" class="SubHead">
                            <asp:Button ID="cmdUpdate" runat="server" CssClass="StandardButton"
                                Text="Modificar Cotización" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdate_ConfirmButtonExtender"
                                runat="server" ConfirmText="Desea modificar esta Cotización?"
                                Enabled="True" TargetControlID="cmdUpdate">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td class="SubHead" style="vertical-align: top; text-align: right">
                            <asp:Button ID="cmdDelete" runat="server" CssClass="StandardButton"
                                Text="Eliminar Cotización" />
                            <cc1:ConfirmButtonExtender ID="cmdDelete_ConfirmButtonExtender"
                                runat="server" ConfirmText="Desea eliminar esta Cotización?"
                                Enabled="True" TargetControlID="cmdDelete">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
                <br />
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlEjecutarCotizacion" runat="server">
            <fieldset id="panelbusEjCotizacion" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plEjCotizacion" runat="server"
                                ControlName="txtBuscarEjCotizacion"
                                Suffix=":" Text="Cliente/Nro Cotización"
                                HelpText="Ingrese el nombre o nro de cotizacion o la fecha de emision de la cotizacion" />
                        </td>
                        <td style="width: 350px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarEjCotizacion" runat="server" ></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdBuscarEjCotizacion" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdEjCotizacion" runat="server" AutoGenerateColumns="False"
                                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="numero" HeaderText="No. Cotización"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cliente" HeaderText="Cliente"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Fecha Emisión"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Fecha Vencimiento"
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
            <fieldset id="panelviewEjCotizacion" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td>
                            <dnn:label ID="plACuentaDe3" runat="server" Suffix=":"
                                Text="A cuenta de" HelpText="La cuenta del cliente" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc3:CuentaCliente ID="CuentaCliente3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="VendidoPor3" runat="server" Suffix=":"
                                Text="Vendedor" HelpText="Elija un vendedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc4:VendedorControlSearch ID="VendedorControlSearch3" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Label ID="Mensaje3" runat="server" Font-Bold="True" Font-Underline="True">Datos para Imprimir en la Factura:</asp:Label>
                <br />
                <br />
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <uc2:ClienteControlSearch ID="ClienteControlSearch3" runat="server" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechaEmision3" runat="server" Suffix=":" Text="Fecha Emision" HelpText="Fecha Emision" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaEmision3" runat="server" CssClass="NormalTextBox">
                            </asp:TextBox>
                            <cc1:CalendarExtender ID="txtFechaEmision3_CalendarExtender" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" TargetControlID="txtFechaEmision3" TodaysDateFormat="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td></td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProducto3" runat="server" Suffix=":" Text="Producto" HelpText="Seleccione los productos" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <uc1:VentaControlSearch ID="VentaControlSearch3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCantidad3" runat="server" ControlName="txtCantidad3" Suffix=":"
                                Text="Cantidad" HelpText="Inserte la cantidad del producto" />
                        </td>
                        <td style="width: 200px; vertical-align: top;" colspan="2">
                            <asp:TextBox ID="txtCantidad3" runat="server" CssClass="NormalTextBox" Width="60px"
                                AutoPostBack="True"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtCantidad3" ErrorMessage="Insertar la cantidad" 
                                ForeColor="#660033" ValidationExpression="\d{1,4}"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDescuento3" runat="server" ControlName="txtDescuento3" Suffix=":"
                                Text="Descuento" HelpText="Inserte descuento del producto" />
                        </td>
                        <td style="width: 200px; vertical-align: top;" colspan="2">
                            <asp:TextBox ID="txtDescuento3" runat="server" CssClass="NormalTextBox" Width="60px"
                                AutoPostBack="True"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtDescuento3" ErrorMessage="Insertar la cantidad" 
                                ForeColor="#660033" ValidationExpression="\d{1,4}"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="pltotal3" runat="server" ControlName="lbltotal3" HelpText="Precio a Cobrar por la Cantidad del Producto"
                                Suffix=":" Text="Total del Producto" />
                        </td>
                        <td style="width: 200px; vertical-align: top;">
                            <asp:Label ID="lbltotal3" runat="server" Text="0"></asp:Label>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Button ID="cmdInsertA3" runat="server" CssClass="CommandButton" Text="Adicionar" />
                            <%--<cc1:ConfirmButtonExtender ID="cmdInsertA_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Desea ingresar este producto a la Lista?" Enabled="True" 
                                TargetControlID="cmdInsertA3"></cc1:ConfirmButtonExtender>--%>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grdProductosEjCotizacion" runat="server" AutoGenerateColumns="False"
                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="CODIGO" ControlStyle-Width="200px" >
                            <ControlStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="detalle" HeaderText="DETALLE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="punitario" HeaderText="P. UNIT." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="descuento" HeaderText="DESCUENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="total" HeaderText="P. TOTAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:CommandField SelectText="Editar" DeleteText="Eliminar" ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
                <br />
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 500px; vertical-align: top; text-align: left;" class="SubHead">Son:&nbsp;&nbsp;
                            <asp:Label ID="lblLiteralCompra3" runat="server"></asp:Label>
                        </td>
                        <td class="SubHead" style="vertical-align: top; text-align: right;">Total Factura: Bs.&nbsp;&nbsp;
                            <asp:Label ID="lbTotalCompra3" runat="server" Text="0.00"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 500px; vertical-align: top; text-align: right;" class="SubHead">&nbsp;
                        </td>
                        <td class="SubHead" style="vertical-align: top; text-align: right;">
                            <asp:Button ID="cmdFacturar" runat="server" CssClass="StandardButton" Text="Facturar" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </fieldset>
            <fieldset id="panelFacturar" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
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
                            <dnn:label ID="plFechaVencimiento3" runat="server" Suffix=":" Text="Fecha Vencimiento"
                                HelpText="Seleccione el cliente" />
                        </td>
                        <td style="vertical-align: top; width: 120px">
                            <asp:DropDownList ID="ddlFechaVencimiento3" runat="server" AutoPostBack="true"
                                Width="150px">
                                <asp:ListItem Value="0" Selected="True">Ninguno</asp:ListItem>
                                <asp:ListItem Value="1">15 dias</asp:ListItem>
                                <asp:ListItem Value="2">30 dias</asp:ListItem>
                                <asp:ListItem Value="3">60 dias</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="txtFechaVencimiento3" runat="server" CssClass="NormalTextBox" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCodigoControl3" runat="server" AutoPostBack="True" Suffix=":" Text="Código de Control"
                                HelpText="Código de control generado" />
                        </td>
                        <td style="vertical-align: top;" colspan="2">
                            <asp:Label ID="lblCodigoControl3" runat="server" Width="100%"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <p>
                    <asp:LinkButton ID="lbtnFinalizar" runat="server">Finalizar Facturacion</asp:LinkButton>
                </p>
                <asp:Label ID="lblRes" runat="server" Width="100%"></asp:Label>
                <br />
            </fieldset>
            <br />
            <asp:LinkButton ID="lbtnPDF" runat="server">Imprimir Cotización</asp:LinkButton><br />
            <asp:LinkButton ID="lbtnPDF1" runat="server">Imprimir Cotización Actualizada</asp:LinkButton><br />
            <asp:LinkButton ID="lbtnImprimirFactura" runat="server">Imprimir Factura</asp:LinkButton><br />
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
