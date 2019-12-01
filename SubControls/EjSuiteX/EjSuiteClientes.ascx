<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteClientes.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteClientes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<%@ Register Src="ZonaControlSearch.ascx" TagName="ZonaControlSearch" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <script type="text/javascript">
            function validaNumero() {
                if (window.event.keyCode < 46 || window.event.keyCode > 57)
                    window.event.keyCode = 0;
            }
        </script>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">
					Nuevo Cliente</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">
					Búsqueda Clientes</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtnExportarExcel" runat="server">Ver Listado</asp:LinkButton>
                    <cc1:ModalPopupExtender ID="lbtnExportarExcel_ModalPopupExtender" runat="server"
                        BehaviorID="lbtnExportarExcel_ModalPopupExtender" PopupControlID="pnlModalReporte"
                        TargetControlID="lbtnExportarExcel">
                    </cc1:ModalPopupExtender>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlNuevoCliente" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCodigoCliente" runat="server" ControlName="txtCodigoCliente" Suffix=":"
                            Text="Código" HelpText="Código que identifica al cliente como unico" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Label ID="lblCodigoCliente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNombreCliente" runat="server" ControlName="txtNombreCliente" Suffix=":"
                            Text="Nombre" HelpText="Nombre del cliente" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="NormalTextBox" Width="100%"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtNombreCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtNombreCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                            runat="server" ControlToValidate="txtNombreCliente"
                            Display="None" ErrorMessage="Ingrese el nombre del cliente" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dnn:label ID="plVisible" runat="server" ControlName="chkVisible"
                            Suffix=":" Text="Vigente" HelpText="Mantiene al cliente visible para facturacion" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkVisible" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCiNitCliente" runat="server" ControlName="txtCiNitCliente" Suffix=":"
                            Text="NIT/CI" HelpText="Numero Cedula de Identidad o NIT" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCiNitCliente" runat="server" CssClass="NormalTextBox" Width="400px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCiNitCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtCiNitCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCiNitCliente"
                            Display="None" ErrorMessage="Ingrese el numero de cedula de identidad o NIT del cliente"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plDireccionCliente" runat="server" ControlName="txtDireccionCliente"
                            Suffix=":" Text="Direccion" HelpText="Direccion del cliente" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDireccionCliente" runat="server" CssClass="NormalTextBox" TextMode="MultiLine"
                            Width="100%" Height="50px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDireccionCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtDireccionCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                            runat="server" ControlToValidate="txtDireccionCliente"
                            Display="None" ErrorMessage="Ingrese la direccion del cliente" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plTelefonoCliente" runat="server" ControlName="txtTelefonoCliente"
                            Suffix=":" Text="Teléfono" HelpText="Teléfono del cliente" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtTelefonoCliente" runat="server" CssClass="NormalTextBox" Width="300px"
                            onKeyPress="javascript:validaNumero();">0</asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtTelefonoCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtTelefonoCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                            runat="server" ControlToValidate="txtTelefonoCliente"
                            Display="None" ErrorMessage="Ingrese un número de teléfono correcto"
                            SetFocusOnError="True" ValidationExpression="\d{1,8}"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                            runat="server" ControlToValidate="txtTelefonoCliente"
                            Display="None" ErrorMessage="Ingrese el teléfono del cliente" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator5">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="Zona" runat="server" Suffix=":" Text="Zona" HelpText="Elija una zona" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:ZonaControlSearch ID="ZonaControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plContacto" runat="server" ControlName="txtContacto" Suffix=":" Text="Contacto"
                            HelpText="Contacto(dueño) de la farmacia" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtContacto" runat="server" CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plReferencias" runat="server" ControlName="txtReferencias" Suffix=":"
                            Text="Referencias" HelpText="Referencias de ubicación de la farmacia" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtReferencias" runat="server" CssClass="NormalTextBox" Width="100%"
                            Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCelular" runat="server" ControlName="txtCelular" Suffix=":" Text="Celular"
                            HelpText="Celular de Contacto(dueño) de la farmacia" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plTelefonoContacto" runat="server" ControlName="txtTelefonoContacto"
                            Suffix=":" Text="Telefono(contacto)" HelpText="Telefono de Contacto(dueño) de la farmacia" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtTelefonoContacto" runat="server" CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertCliente" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertCliente_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertCliente">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 90px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelCliente" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaCliente" runat="server">
            <fieldset id="panelbusCli" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarCliente" runat="server" ControlName="txtBuscarCliente" Suffix=":"
                                Text="Cliente" HelpText="Ingrese el nombre del cliente" />
                        </td>
                        <td style="width: 550px" class="SubHead" style="vertical-align: top;">
                            <asp:TextBox ID="txtBuscarCliente" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageCliente" runat="server"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nCodCliente" HeaderText="Código"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cCliente" HeaderText="Cliente"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cTelefono" HeaderText="Teléfono"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Empleado" HeaderText="Vendedor"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Zona" HeaderText="Zona"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
            </fieldset>
            <fieldset id="panelviewCli" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td>
                            <dnn:label ID="plVisible1" runat="server" ControlName="chkVisible1"
                                Suffix=":" Text="Vigente" HelpText="Mantiene al cliente visible para facturacion" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkVisible1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plNombreCliente1" runat="server" ControlName="txtNombreCliente1" Suffix=":"
                                Text="Nombre" HelpText="Nombre del cliente" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtNombreCliente1" runat="server"
                                CssClass="NormalTextBox" Width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtNombreCliente1_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtNombreCliente1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtNombreCliente1"
                                Display="None" ErrorMessage="Ingrese el nombre del cliente"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCiNitCliente1" runat="server" ControlName="txtCiNitCliente1" Suffix=":"
                                Text="NIT/CI" HelpText="Numero Cedula de Identidad o NIT" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtCiNitCliente1" runat="server"
                                CssClass="NormalTextBox" Width="400px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtCiNitCliente11_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtCiNitCliente1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtCiNitCliente1"
                                Display="None" ErrorMessage="Ingrese el numero de cedula de identidad o NIT del cliente"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDireccionCliente1" runat="server" ControlName="txtDireccionCliente1"
                                Suffix=":" Text="Direccion" HelpText="Direccion del cliente" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDireccionCliente1" runat="server" CssClass="NormalTextBox"
                                TextMode="MultiLine"
                                Width="100%" Height="50px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtDireccionCliente1_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="txtDireccionCliente1"
                                WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="txtDireccionCliente1"
                                Display="None" ErrorMessage="Ingrese la direccion del cliente"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plTelefonoCliente1" runat="server" ControlName="txtTelefonoCliente1"
                                Suffix=":" Text="Teléfono" HelpText="Teléfono del cliente" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtTelefonoCliente1" runat="server"
                                CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtTelefonoCliente1_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtTelefonoCliente1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                runat="server" ControlToValidate="txtTelefonoCliente1"
                                Display="None" ErrorMessage="Ingrese un número de teléfono correcto"
                                SetFocusOnError="True" ValidationExpression="\d{7,8}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator33_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RegularExpressionValidator3">
                            </cc1:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                runat="server" ControlToValidate="txtTelefonoCliente1"
                                Display="None" ErrorMessage="Ingrese el teléfono del cliente"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator9">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="Zona1" runat="server" Suffix=":" Text="Zona" HelpText="Elija una zona" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc1:ZonaControlSearch ID="ZonaControlSearch2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plContacto1" runat="server" ControlName="txtContacto1" Suffix=":"
                                Text="Contacto" HelpText="Contacto(dueño) de la farmacia" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtContacto1" runat="server"
                                CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="width: 90px; vertical-align: top;">
                            <dnn:label ID="plReferencias1" runat="server"
                                ControlName="txtReferencias1" HelpText="Referencias de ubicación de la farmacia"
                                Suffix=":" Text="Referencias" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtReferencias1" runat="server"
                                CssClass="NormalTextBox" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="width: 90px; vertical-align: top;">
                            <dnn:label ID="plCelular1" runat="server" ControlName="txtCelular1"
                                HelpText="Celular de Contacto(dueño) de la farmacia"
                                Suffix=":" Text="Celular" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtCelular1" runat="server"
                                CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="width: 90px; vertical-align: top;">
                            <dnn:label ID="plTelefonoContacto1" runat="server"
                                ControlName="txtTelefonoContacto1"
                                HelpText="Telefono de Contacto(dueño) de la farmacia" Suffix=":" Text="Telefono(contacto)" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtTelefonoContacto1" runat="server"
                                CssClass="NormalTextBox" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="width: 90px; vertical-align: top;">
                            <asp:Button ID="cmdUpdateCliente" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateCliente">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td class="SubHead" style="width: 90px; vertical-align: top;">
                            <asp:Button ID="cmdDeleteCliente" runat="server" CausesValidation="False" CssClass="CommandButton"
                                Text="Eliminar" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True" TargetControlID="cmdDeleteCliente">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>

        <asp:Panel ID="pnlModalReporte" Style="display: none; background-color: InfoBackground;"
            runat="server">
            <p style="text-align: right;">
                <asp:LinkButton ID="cmdCancel" runat="server" Text="Cerrar" CssClass="CommandButton"
                    CausesValidation="False" />
            </p>
            <p style="text-align: center; font: bold;">
                <h2>REPORTE DE CLIENTES</h2>
            </p>
            <p>
                <rsweb:ReportViewer ID="rptReporte" runat="server" Width="100%" Height="100%"
                    ShowRefreshButton="false" ShowPrintButton="true" ZoomPercent="100"
                    AsyncRendering="false" SizeToReportContent="true" ZoomMode="FullPage">
                </rsweb:ReportViewer>
                
            </p>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lbtnExportarExcel" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upHeader" runat="server" AssociatedUpdatePanelID="upPanel"
    DisplayAfter="0">
    <ProgressTemplate>
        <p>
            <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
            <asp:Label ID="lblUpdateHeader" runat="server" CssClass="normal" Text="Espere por favor..."></asp:Label>
        </p>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
