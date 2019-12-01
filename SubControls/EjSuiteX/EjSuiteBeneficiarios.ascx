<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteBeneficiarios.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteBeneficiarios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<%@ Register Src="ZonaControlSearch.ascx" TagName="ZonaControlSearch" TagPrefix="uc1" %>
<%@ Register Src="BeneficiarioControlSearch.ascx" TagName="BeneficiarioControlSearch"
    TagPrefix="uc2" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">
                        Nuevo Beneficiario</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">
                        Búsqueda Beneficiarios</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 100%; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlNuevoCliente" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td>
                        <dnn:label ID="plACuentaDe" runat="server" Suffix=":" Text="Cliente" 
                            HelpText="Cliente a quien corresponde este NIT" />
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <uc2:BeneficiarioControlSearch ID="BeneficiarioControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plNombreCliente" runat="server" ControlName="txtNombreCliente" Suffix=":"
                            Text="Nombre" HelpText="Nombre del cliente" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="NormalTextBox" Width="100%"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtNombreCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtNombreCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtNombreCliente"
                            Display="None" ErrorMessage="Ingrese el nombre del cliente" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCiNitCliente" runat="server" ControlName="txtCiNitCliente" Suffix=":"
                            Text="NIT/CI" HelpText="Numero Cedula de Identidad o NIT" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCiNitCliente" runat="server" CssClass="NormalTextBox" Width="400px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCiNitCliente_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtCiNitCliente" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtCiNitCliente"
                            Display="None" ErrorMessage="Ingrese el numero de cedula de identidad o NIT del cliente"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plDirBeneficiario" runat="server" ControlName="txtDirBeneficiario"
                            Suffix=":" Text="Direccion" HelpText="Direccion del beneficiario" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDirBeneficiario" runat="server" CssClass="NormalTextBox" 
                            Width="400px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDirBeneficiario_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtDirBeneficiario" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDirBeneficiario"
                            Display="None" ErrorMessage="Ingrese la direccion del beneficiario" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                            TargetControlID="RequiredFieldValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertCliente" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertCliente_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertCliente">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
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
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarCliente" runat="server" ControlName="txtBuscarCliente" Suffix=":"
                                Text="Cliente" HelpText="Ingrese el nombre del cliente" />
                        </td>
                        <td style="width: 350px" class="SubHead" style="vertical-align: top;">
                            <asp:TextBox ID="txtBuscarCliente" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageCliente" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdCliente" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ScrollBars="Auto" EmptyDataText="No se encontraron registros." Width="100%" 
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cCliente" HeaderText="Cliente" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                        <asp:BoundField DataField="Beneficiario" HeaderText="Beneficiario" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNit" HeaderText="NIT/CI" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha Reg." 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
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
            <fieldset id="panelviewCli" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td>
                            <dnn:label ID="plACuentaDe1" runat="server" Suffix=":" Text="Cliente" HelpText="Cliente a quien corresponde este NIT" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <uc2:BeneficiarioControlSearch ID="BeneficiarioControlSearch2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCiNitCliente1" runat="server" ControlName="txtCiNitCliente1" Suffix=":"
                                Text="NIT/CI" HelpText="Numero Cedula de Identidad o NIT" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtCiNitCliente1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtCiNitCliente11_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtCiNitCliente1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCiNitCliente1"
                                Display="None" ErrorMessage="Ingrese el numero de cedula de identidad o NIT del cliente"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDireccionCliente1" runat="server" ControlName="txtDireccionCliente1"
                                Suffix=":" Text="Nombre" HelpText="Nombre del beneficiario" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtNombreCliente1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtDireccionCliente1_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="txtNombreCliente1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombreCliente1"
                                Display="None" ErrorMessage="Ingrese el nombre del cliente" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDirBeneficiario1" runat="server" ControlName="txtDirBeneficiario1"
                                Suffix=":" Text="Direccion" HelpText="Direccion del beneficiario" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDirBeneficiario1" runat="server" CssClass="NormalTextBox" Width="400px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtDirBeneficiario1_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtDirBeneficiario1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtDirBeneficiario1"
                                Display="None" ErrorMessage="Ingrese la direccion del beneficiario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator31_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator31">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateCliente" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateCliente">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteCliente" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True" TargetControlID="cmdDeleteCliente">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar a Excel</asp:LinkButton>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lbtnExportarExcel" />
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
