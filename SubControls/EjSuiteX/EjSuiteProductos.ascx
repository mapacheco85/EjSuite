<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteProductos.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteProductos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProveedorControlSearch.ascx" TagName="ProveedorControlSearch" TagPrefix="uc1" %>
<%@ Register Src="GrupoterapeuticoControlSearch.ascx" TagName="GrupoterapeuticoControlSearch"
    TagPrefix="uc2" %>
<%@ Register Src="ProveedorMarcaSearchControl.ascx" TagName="ProveedorMarcaSearchControl"
    TagPrefix="uc3" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Nuevo Producto</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda Productos</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Nuevo Grupo Venta</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn4" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda Grupos Venta</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlNuevoProducto" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plIdProducto" runat="server" ControlName="txtIdProducto" Suffix=":"
                            Text="Codigo del Producto" HelpText="Codigo del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtIdProducto" runat="server" CssClass="NormalTextBox" Width="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender13" runat="server" Enabled="True"
                            TargetControlID="txtIdProducto" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdProducto"
                            Display="None" ErrorMessage="Ingrese el Id del producto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; vertical-align: top;" colspan="2">
                        <uc3:ProveedorMarcaSearchControl ID="ProveedorMarcaSearchControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plGrupoCodigoProducto" runat="server" Suffix=":" Text="Grupo Ventas"
                            HelpText="Elija el grupo de ventas" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc2:GrupoterapeuticoControlSearch ID="GrupoterapeuticoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNombreGenericoProducto" runat="server" ControlName="txtNombreGenericoProducto"
                            Suffix=":" Text="Producto" HelpText="Nombre del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtNombreGenericoProducto" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNombreComercialProducto" runat="server" ControlName="txtNombreComercialProducto"
                            Suffix=":" Text="Descripción" HelpText="Descripción del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtNombreComercialProducto" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                            TargetControlID="txtNombreComercialProducto" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtNombreComercialProducto"
                            Display="None" ErrorMessage="Ingrese el nombre comercial del producto"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plDetallesProducto" runat="server" ControlName="txtDetallesProducto"
                            Suffix=":" Text="Descripción Detallada" HelpText="Detalles y presentacion del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDetallesProducto" runat="server"
                            CssClass="NormalTextBox" TextMode="MultiLine"
                            Width="267px" Height="50px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDetallesProducto_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtDetallesProducto" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ControlToValidate="txtDetallesProducto"
                            Display="None" ErrorMessage="Ingrese los detalles del producto"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCompuestoProducto" runat="server" ControlName="txtCompuestoProducto"
                            Suffix=":" Text="Composicion/Material" HelpText="Composición del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCompuestoProducto" runat="server"
                            CssClass="NormalTextBox" TextMode="MultiLine"
                            Width="267px" Height="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14"
                            runat="server" Enabled="True"
                            TargetControlID="txtCompuestoProducto"
                            WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ControlToValidate="txtCompuestoProducto"
                            Display="None" ErrorMessage="Ingrese el compuesto del producto"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plPrecioCompraProducto" runat="server" ControlName="txtPrecioCompraProducto"
                            Suffix=":" Text="Precio de Compra" HelpText="Precio de compra del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtPrecioCompraProducto" runat="server" CssClass="NormalTextBox"
                            Width="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" Enabled="True"
                            TargetControlID="txtPrecioCompraProducto" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtPrecioCompraProducto"
                            Display="None" ErrorMessage="Ingrese un precio de compra correcto" SetFocusOnError="True"
                            ValidationExpression="^\$?\d+(\,(\d{2}))?$"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator1">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ControlToValidate="txtPrecioCompraProducto"
                            Display="None" ErrorMessage="Ingrese el precio de compra del producto"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13"
                            runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator5">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plStockMinimoProducto" runat="server" ControlName="txtStockMinimoProducto"
                            Suffix=":" Text="Stock mínimo" HelpText="Stock mínimo del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtStockMinimoProducto" runat="server" CssClass="NormalTextBox"
                            Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                            runat="server" ControlToValidate="txtStockMinimoProducto"
                            Display="None" ErrorMessage="Ingrese un Stock mínimo correcto" SetFocusOnError="True"
                            ValidationExpression="\d{0,10}"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator7">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plStockMaximoProducto" runat="server" ControlName="txtStockMaximoProducto"
                            Suffix=":" Text="Stock máximo" HelpText="Stock máximo del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtStockMaximoProducto" runat="server" CssClass="NormalTextBox"
                            Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                            runat="server" ControlToValidate="txtStockMaximoProducto"
                            Display="None" ErrorMessage="Ingrese el Stock máximo correcto" SetFocusOnError="True"
                            ValidationExpression="\d{0,10}"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator8">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertProducto" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertProducto_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertProducto">
                        </cc1:ConfirmButtonExtender>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Button ID="cmdCancelProducto" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaProductos" runat="server">
            <fieldset id="panelbusProducto" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 33%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProducto" runat="server" ControlName="txtBuscarProducto" Suffix=":"
                                Text="Producto" HelpText="Ingrese el nombre genérico o comercial del producto" />
                        </td>
                        <td style="width: 33%; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarProducto" runat="server" Width="350px"></asp:TextBox>
                        </td>
                        <td style="width: 33%; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageProducto" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdProducto" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" Width="100%">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <Columns>
                                        <asp:BoundField DataField="nCodProducto" HeaderText="Código"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCodProducto" HeaderText="Cod. Barra"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDetalles" HeaderText="Producto"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCompuesto" HeaderText="Composición"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Precio de Compra"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <RowStyle ForeColor="#003399" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Left" />
                                    <PagerSettings Position="TopAndBottom" />
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
            <fieldset id="panelviewProducto" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plIdProducto1" runat="server" ControlName="txtIdProducto1" Suffix=":"
                                Text="Codigo Producto" HelpText="Codigo del producto en formato barras" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:Label ID="lblIdProducto1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="Label1" runat="server" ControlName="hfProveedorIdProducto1" Suffix=":"
                                Text="" HelpText="Cato" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:HiddenField ID="hfProveedorIdProducto1" runat="server" Visible="False" />
                            <asp:HiddenField ID="hfMarcaIdProducto1" runat="server" Visible="False" />
                            <asp:Label ID="lblProveedorNomRazonProducto1" runat="server" />
                            <asp:Label ID="lblMarcaEmpresaProducto1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead" colspan="2">
                            <uc3:ProveedorMarcaSearchControl ID="ProveedorMarcaSearchControl2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plGrupoCodigoProducto1" runat="server" ControlName="dllGrupoCodigoProducto1"
                                Suffix=":" Text="Grupo Ventas" HelpText="Codigo de grupo" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:HiddenField ID="hfGrupoCodigoProducto1" runat="server" Visible="False" />
                            <asp:Label ID="lblGrupoMedicoProducto1" runat="server" />
                            <uc2:GrupoterapeuticoControlSearch ID="GrupoterapeuticoControlSearch2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plNombreGenericoProducto1" runat="server" ControlName="txtNombreGenericoProducto1"
                                Suffix=":" Text="Producto" HelpText="Nombre del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtNombreGenericoProducto1" runat="server" CssClass="NormalTextBox"
                                Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                TargetControlID="txtNombreGenericoProducto1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="txtNombreGenericoProducto1"
                                Display="None" ErrorMessage="Ingrese el nombre genérico del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator9">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plNombreComercialProducto1" runat="server" ControlName="txtNombreComercialProducto1"
                                Suffix=":" Text="Descripción" HelpText="Descripción del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtNombreComercialProducto1" runat="server" CssClass="NormalTextBox"
                                Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True"
                                TargetControlID="txtNombreComercialProducto1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="txtNombreComercialProducto1"
                                Display="None" ErrorMessage="Ingrese el nombre comercial del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator10">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDetallesProducto1" runat="server" ControlName="txtDetallesProducto1"
                                Suffix=":" Text="Descripción Detallada" HelpText="Detalles y presentación del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtDetallesProducto1" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                                Width="267px" Height="50px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                TargetControlID="txtDetallesProducto1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ControlToValidate="txtDetallesProducto1"
                                Display="None" ErrorMessage="Ingrese los detalles del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator11">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCompuestoProducto1" runat="server" ControlName="txtCompuestoProducto1"
                                Suffix=":" Text="Composición/Material" HelpText="Composición del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtCompuestoProducto1" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                                Width="267px" Height="100px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" runat="server" Enabled="True"
                                TargetControlID="txtCompuestoProducto1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                ControlToValidate="txtCompuestoProducto1"
                                Display="None" ErrorMessage="Ingrese el compuesto del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator19">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plPrecioCompraProducto1" runat="server" ControlName="txtPrecioCompraProducto1"
                                Suffix=":" Text="Precio de Compra" HelpText="Precio de compra del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtPrecioCompraProducto1" runat="server" CssClass="NormalTextBox"
                                Width="100px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                TargetControlID="txtPrecioCompraProducto1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtPrecioCompraProducto1"
                                Display="None" ErrorMessage="Ingrese un precio de compra correcto" SetFocusOnError="True"
                                ValidationExpression="^\$?\d+(\,(\d{2}))?$"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                TargetControlID="RegularExpressionValidator2">
                            </cc1:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                ControlToValidate="txtPrecioCompraProducto1"
                                Display="None" ErrorMessage="Ingrese el precio de compra del producto"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator12">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plStockMinimoProducto1" runat="server" ControlName="txtStockMinimoProducto1"
                                Suffix=":" Text="Stock mínimo" HelpText="Stock mínimo del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtStockMinimoProducto1" runat="server" CssClass="NormalTextBox"
                                Width="100px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                ControlToValidate="txtStockMinimoProducto1" Display="None"
                                ErrorMessage="Ingrese un Stock mínimo correcto"
                                SetFocusOnError="True" ValidationExpression="\d{0,10}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server" Enabled="True"
                                TargetControlID="RegularExpressionValidator13">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plStockMaximoProducto1" runat="server" ControlName="txtStockMaximoProducto1"
                                Suffix=":" Text="Stock máximo" HelpText="Stock máximo del producto" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtStockMaximoProducto1" runat="server" CssClass="NormalTextBox"
                                Width="100px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                ControlToValidate="txtStockMaximoProducto1" Display="None"
                                ErrorMessage="Ingrese el Stock máximo correcto"
                                SetFocusOnError="True" ValidationExpression="\d{0,10}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True"
                                TargetControlID="RegularExpressionValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateProducto" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateProducto_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateProducto">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 80%; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteProducto" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteProducto_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True" TargetControlID="cmdDeleteProducto">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlNuevoGrupoTerapeutico" runat="server">
            <table style="width: 512px; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCodigoGrupoTerapeutico" runat="server" ControlName="txtCodigoGrupoTerapeutico"
                            Suffix=":" Text="Código" HelpText="Código del grupo de ventas" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCodigoGrupoTerapeutico" runat="server" CssClass="NormalTextBox"
                            Width="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender12" runat="server" Enabled="True"
                            TargetControlID="txtCodigoGrupoTerapeutico" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                            ControlToValidate="txtCodigoGrupoTerapeutico"
                            Display="None" ErrorMessage="Ingrese el código del grupo médico"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator16">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plGrupomedicoGrupoTerapeutico" runat="server" ControlName="txtGrupomedicoGrupoTerapeutico"
                            Suffix=":" Text="Grupo Ventas" HelpText="Nombre del grupo de ventas" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtGrupomedicoGrupoTerapeutico" runat="server" CssClass="NormalTextBox"
                            Width="267px" Height="57px" TextMode="MultiLine"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                            TargetControlID="txtGrupomedicoGrupoTerapeutico" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                            ControlToValidate="txtGrupomedicoGrupoTerapeutico"
                            Display="None" ErrorMessage="Ingrese el grupo médico"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator17">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertGrupoTerapeutico" runat="server" CssClass="CommandButton"
                            Text="Insertar" Style="height: 26px" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                            ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsertProducto">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelGrupoTerapeutico" runat="server" CssClass="CommandButton"
                            Text="Cancelar" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaGrupoTerapeutico" runat="server">
            <fieldset id="panelbusGrupoTerapeutico" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 150px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plGrupoTerapeutico" runat="server" ControlName="txtBuscarGrupoTerapeutico"
                                Suffix=":" Text="Grupo Terapeútico" HelpText="Ingrese el grupo médico" />
                        </td>
                        <td style="width: 292px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarGrupoTerapeutico" runat="server" Width="280px"></asp:TextBox>
                        </td>
                        <td style="width: 70px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdBuscarGrupoTerapeutico" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageGrupoTerapeutico" runat="server"></asp:Label>
                            <br />
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdGrupoTerapeutico" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" Width="100%">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <Columns>
                                        <asp:BoundField DataField="nCodGrupo" HeaderText="Código"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cGrupoProducto" HeaderText="Grupo Ventas"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <RowStyle ForeColor="#003399" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Left" />
                                    <PagerSettings Position="TopAndBottom" />
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
            <fieldset id="panelviewGrupoTerapeutico" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 20%; vertical-align: top;">
                            <dnn:label ID="plCodigoGrupoTerapeutico1" runat="server" ControlName="txtCodigoGrupoTerapeutico1"
                                Suffix=":" Text="Código" HelpText="Código del grupo de ventas" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:Label ID="lblCodigoGrupoTerapeutico1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;">
                            <dnn:label ID="plGrupomedicoGrupoTerapeutico1" runat="server"
                                ControlName="txtGrupomedicoGrupoTerapeutico1"
                                Suffix=":" Text="Grupo Ventas" HelpText="Nombre del grupo de ventas" />
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:TextBox ID="txtGrupomedicoGrupoTerapeutico1" runat="server" CssClass="NormalTextBox"
                                Width="267px" Height="57px" TextMode="MultiLine"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                TargetControlID="txtGrupomedicoGrupoTerapeutico1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                ControlToValidate="txtGrupomedicoGrupoTerapeutico1"
                                Display="None" ErrorMessage="Ingrese el grupo médico"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator18">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top;">
                            <asp:Button ID="cmdUpdateGrupoTerapeutico" runat="server" CssClass="CommandButton"
                                Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
                                ConfirmText="Desea modificar este registro?"
                                Enabled="True" TargetControlID="cmdUpdateProducto">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td style="width: 80%; vertical-align: top;">
                            <asp:Button ID="cmdDeleteGrupoTerapeutico" runat="server" CssClass="CommandButton"
                                Text="Eliminar" CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server"
                                ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdDeleteProducto">
                            </cc1:ConfirmButtonExtender>
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
