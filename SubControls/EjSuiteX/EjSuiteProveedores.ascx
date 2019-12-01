<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteProveedores.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteProveedores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProveedorControlSearch.ascx" TagName="ProveedorControlSearch" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Nuevo Proveedor</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda Proveedores</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Nuevas Marcas</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn4" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda Marcas</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 512px; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlNuevoProveedor" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNomRazon" runat="server" ControlName="txtNomRazon" Suffix=":" Text="Nombre Razón"
                            HelpText="Nombre del proveedor" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtNomRazon" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtNomRazon_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtNomRazon" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomRazon"
                            Display="None" ErrorMessage="Ingrese el nombre del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plDireccion" runat="server" ControlName="txtDireccion" Suffix=":"
                            Text="Dirección" HelpText="Dirección del proveedor" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                            Width="267px" Height="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDireccion_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtDireccion" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDireccion"
                            Display="None" ErrorMessage="Ingrese el domicilio del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plRepresentante" runat="server" ControlName="txtRepresentante" Suffix=":"
                            Text="Representante" HelpText="Nombre del representante" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtRepresentante" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtRepresentante_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtRepresentante" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRepresentante"
                            Display="None" ErrorMessage="Ingrese el representante del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plTelefono" runat="server" ControlName="txtTelefono" Suffix=":" Text="Teléfono"
                            HelpText="Teléfono del proveedor" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtTelefono_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtTelefono" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTelefono"
                            Display="None" ErrorMessage="Ingrese un número de teléfono correcto"
                            SetFocusOnError="True" ValidationExpression="\d{7,8}"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefono"
                            Display="None" ErrorMessage="Ingrese el teléfono del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator4">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsert" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsert_ConfirmButtonExtender" runat="server" ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsert">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaProveedor" runat="server">
            <fieldset id="panelbusProv" runat="server" style="width: 100%;">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProv" runat="server" ControlName="txtBuscarProveedor" Suffix=":"
                                Text="Proveedor" HelpText="Ingrese el nombre del proveedor" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarProveedor" runat="server" Width="340px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarProveedor" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageProveedor" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 400px; overflow: scroll">
                                <asp:GridView ID="grdProveedor" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="cNombre" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDireccion" HeaderText="Dirección" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cTelefono" HeaderText="Teléfono" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
            <fieldset id="panelviewProv" runat="server" style="width: 100%;">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plNomRazon1" runat="server" ControlName="txtNomRazon1" Suffix=":"
                                Text="Nombre Razón" HelpText="Nombre del proveedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtNomRazon1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                TargetControlID="txtNomRazon1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNomRazon1"
                                Display="None" ErrorMessage="Ingrese el nombre del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator5">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDireccion1" runat="server" ControlName="txtDireccion1" Suffix=":"
                                Text="Dirección" HelpText="Dirección del proveedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDireccion1" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                                Width="267px" Height="100px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True"
                                TargetControlID="txtDireccion1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDireccion1"
                                Display="None" ErrorMessage="Ingrese el domicilio del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator6">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plRepresntante1" runat="server" ControlName="txtRepresentante1" Suffix=":"
                                Text="Representante" HelpText="Nombre del representante" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtRepresentante1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                TargetControlID="txtRepresentante1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRepresentante1"
                                Display="None" ErrorMessage="Ingrese el representante del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator7">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plTelefono1" runat="server" ControlName="txtTelefono1" Suffix=":"
                                Text="Teléfono" HelpText="Teléfono del proveedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtTelefono1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                TargetControlID="txtTelefono1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelefono1"
                                Display="None" ErrorMessage="Ingrese un número de teléfono correcto"
                                SetFocusOnError="True" ValidationExpression="\d{7,8}">
                            </asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                TargetControlID="RegularExpressionValidator2">
                            </cc1:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefono1"
                                Display="None" ErrorMessage="Ingrese el teléfono del proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator8">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateProveedor" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateProveedor_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateProveedor">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteProveedor" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteProveedor_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True" TargetControlID="cmdDeleteProveedor">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlNuevaMarca" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plEmpresaMarca" runat="server" ControlName="txtEmpresaMarca" Suffix=":"
                            Text="Empresa" HelpText="Nombre de la empresa" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtEmpresaMarca" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                            TargetControlID="txtEmpresaMarca" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmpresaMarca"
                            Display="None" ErrorMessage="Ingrese el nombre de la empresa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator9">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plProveedorIdMarca" runat="server" ControlName="ddlProveedorIdMarca"
                            Suffix=":" Text="Id Proveedor" HelpText="Id del proveedor" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:ProveedorControlSearch ID="ProveedorControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plDireccionMarca" runat="server" ControlName="txtDireccionMarca" Suffix=":"
                            Text="Dirección" HelpText="Dirección de la empresa" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDireccionMarca" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                            Width="267px" Height="100px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                            TargetControlID="txtDireccionMarca" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDireccionMarca"
                            Display="None" ErrorMessage="Ingrese la dirección de la empresa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator10">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertMarca" runat="server" CssClass="CommandButton" Text="Insertar"
                            Style="height: 26px" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsert">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelMarca" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" Style="height: 26px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaMarca" runat="server">
            <fieldset id="panelbusMarc" runat="server" style="width: 100%;">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plMarca" runat="server" ControlName="txtBuscarMarca" Suffix=":" Text="Marca"
                                HelpText="Ingrese el nombre de la marca" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarMarca" runat="server" Width="367px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdBuscarMarca" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageMarca" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 400px; overflow: scroll">
                                <asp:GridView ID="grdMarca" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="cEmpresa" HeaderText="Empresa" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDireccion" HeaderText="Dirección" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
            <fieldset id="panelviewMarc" runat="server" style="width: 100%;">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plEmpresaMarca1" runat="server" ControlName="txtEmpresaMarca" Suffix=":"
                                Text="Empresa" HelpText="Nombre de la empresa" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtEmpresaMarca1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" Enabled="True"
                                TargetControlID="txtEmpresaMarca1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEmpresaMarca1"
                                Display="None" ErrorMessage="Ingrese el nombre de la empresa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator11">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plProveedorIdMarca1" runat="server" ControlName="ddlProveedorIdMarca1"
                                Suffix=":" Text="Id Proveedor" HelpText="Id del proveedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <table style="width: 390px">
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:HiddenField ID="hfProveedorIdMarca1" runat="server" />
                                    </td>
                                    <td style="vertical-align: top; width: 100px">
                                        <asp:Label ID="lblProveedorNomRazonMarca1" runat="server"></asp:Label>
                                    </td>
                                    <td style="vertical-align: top;">
                                        <uc1:ProveedorControlSearch ID="ProveedorControlSearch2" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDireccionMarca1" runat="server" ControlName="txtDireccionMarca1"
                                Suffix=":" Text="Dirección" HelpText="Dirección de la empresa" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDireccionMarca1" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                                Width="267px" Height="100px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" Enabled="True"
                                TargetControlID="txtDireccionMarca1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDireccionMarca1"
                                Display="None" ErrorMessage="Ingrese la dirección de la empresa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator12">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateMarca" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Desea modificar este registro?"
                                Enabled="True" TargetControlID="cmdUpdateProveedor">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteMarca" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdDeleteProveedor">
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