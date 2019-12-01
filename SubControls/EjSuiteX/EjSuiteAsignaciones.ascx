<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteAsignaciones.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteAsignaciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="regionControlSearch.ascx" TagName="regionControlSearch" TagPrefix="uc1" %>
<%@ Register Src="sucursalControlSearch.ascx" TagName="sucursalControlSearch" TagPrefix="uc2" %>
<%@ Register Src="EmpleadoControlSearch.ascx" TagName="EmpleadoControlSearch" TagPrefix="uc3" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Almacén</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Sucursal</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Región</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn4" runat="server" CssClass="ig_Button" CausesValidation="False">Asignación</asp:LinkButton>
                </td>
            </tr>
        </table>
        <p>&nbsp;</p>
        <asp:Panel ID="pnlAlmacenIns" runat="server" Visible="False" GroupingText="Nuevo Almacen">
            <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plSucursal" runat="server" ControlName="ddlSucursal" Suffix=":" Text="Sucursal"
                            HelpText="Seleccione el nombre de la Sucursal" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc2:sucursalControlSearch ID="sucursalControlSearch2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plEmpleado" runat="server" ControlName="ddlEmplado" Suffix=":" Text="Empleado"
                            HelpText="Seleccionar el Empleado" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc3:EmpleadoControlSearch ID="EmpleadoControlSearch2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button ID="cmdInsertA" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertA_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsertA">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="cmdCancelA" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlAlmacenbus" runat="server" Visible="False">
            <fieldset id="panelbusA" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td>
                            <dnn:label ID="plServA" runat="server" ControlName="txtBuscarA" Suffix=":" Text="Empleado/Zona"
                                HelpText="Introduzca el nombre o apellido del empleado o la zona de la sucursal para la búsqueda" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBuscarA" runat="server" Width="350px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscarA" runat="server" Text="Buscar" />
                        </td>
                        <td>
                            <asp:Button ID="btnNuevoA" runat="server" Text="Nuevo Almacen" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                            <asp:Label ID="lblMesA" runat="server" CssClass="men" Width="100%"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdAlmacen" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cZona" HeaderText="Almacen"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="NombreCompleto" HeaderText="Responsable"
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
            <fieldset id="panelviewA" runat="server">
                <td class="style3" style="vertical-align: top;">&nbsp;&nbsp;&nbsp;
                    <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                        <tr>
                            <td style="vertical-align: top;">
                                <dnn:label ID="plSucursal1" runat="server" Suffix=":" Text="Sucursal"
                                    HelpText="Seleccione el nombre de la Sucursal" />
                            </td>
                            <td style="vertical-align: top;">
                                <uc2:sucursalControlSearch ID="sucursalControlSearch1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <dnn:label ID="plEmpleado1" runat="server" Suffix=":" Text="Empleado"
                                    HelpText="Seleccionar el Empleado" />
                            </td>
                            <td style="vertical-align: top;">
                                <uc3:EmpleadoControlSearch ID="EmpleadoControlSearch1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">&nbsp;
                            </td>
                            <td style="vertical-align: top;">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="SubHead" style="vertical-align: top;">
                                <asp:Button ID="cmdUpdateA" runat="server"
                                    CssClass="CommandButton" Text="Modificar" />
                                <cc1:ConfirmButtonExtender ID="cmdUpdateA_ConfirmButtonExtender"
                                    runat="server" ConfirmText="Desea modificar este registro?"
                                    Enabled="True" TargetControlID="cmdUpdateA">
                                </cc1:ConfirmButtonExtender>
                                &nbsp;
                            </td>
                            <td class="SubHead" style="vertical-align: top;">
                                <asp:Button ID="cmdDeleteA" runat="server" CssClass="CommandButton" Text="Eliminar"
                                    CausesValidation="False" />
                                <cc1:ConfirmButtonExtender ID="cmdDeleteA_ConfirmButtonExtender"
                                    runat="server" ConfirmText="Desea eliminar este registro?"
                                    Enabled="True" TargetControlID="cmdDeleteA">
                                </cc1:ConfirmButtonExtender>
                            </td>
                        </tr>
                    </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlSucursalIns" runat="server" Visible="False">
            <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plRegion" runat="server" ControlName="ddlRegion" Suffix=":" Text="Sucursal"
                            HelpText="Seleccione la región" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:regionControlSearch ID="regionControlSearch2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plZona" runat="server" ControlName="txtZona" Suffix=":" Text="Zona"
                            HelpText="Inserte la Zona donde se ubica la Sucursal" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtZona" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtZona"
                            Display="None" ErrorMessage="Inserte la zona de la Sucursal"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plDireccion" runat="server" ControlName="txtDireccion" Suffix=":"
                            Text="Direccion" HelpText="Inserte la Direccion de la Sucursal" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plCasamatriz" runat="server" ControlName="txtCasamatriz" Suffix=":"
                            Text="Casa Matriz" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:CheckBox ID="ckbCasamatriz" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">&nbsp;
                    </td>
                    <td style="vertical-align: top;">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="SubHead" style="vertical-align: top;">
                        <asp:Button ID="cmdInsertS" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertS_ConfirmButtonExtender"
                            runat="server" ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsertS">
                        </cc1:ConfirmButtonExtender>
                    </td>
                    <td class="SubHead" style="vertical-align: top;">
                        <asp:Button ID="cmdCancelS" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlSucursalBus" runat="server" Visible="False">
            <fieldset id="panelbusS" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plServS" runat="server" ControlName="txtBuscarS" Suffix=":" Text="Sucursal"
                                HelpText="Buscar la sucursal por la Zona" />
                        </td>
                        <td style="width: 350px; vertical-align: top;">
                            <asp:TextBox ID="txtBuscarS" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Button ID="btnBuscarS" runat="server" Text="Buscar" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Button ID="btnNuevoS" runat="server" Text="Nueva Sucursal" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                            <asp:Label ID="lblMesS" runat="server" CssClass="men"
                                EnableTheming="True" Width="100%"></asp:Label>
                            <br />
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdSucursal" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Región"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cZona" HeaderText="Zona"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDireccion" HeaderText="Dirección"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CheckBoxField DataField="bCasaMatriz" HeaderText="Casa Matriz"
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
            <fieldset id="panelviewS" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plRegion1" runat="server" Suffix=":" Text="Sucursal" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc1:regionControlSearch ID="regionControlSearch1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plZona1" runat="server" ControlName="txtZona1" Suffix=":" Text="Zona" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtZona1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                runat="server" ControlToValidate="txtZona1"
                                Display="None" ErrorMessage="Inserte la zona de la Sucursal" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator4">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plDireccion1" runat="server" ControlName="txtDireccion1" Suffix=":"
                                Text="Dirección" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDireccion1" runat="server"
                                CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plCasamatriz1" runat="server" Suffix=":" Text="Casa Matriz" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:CheckBox ID="ckbCasamatriz1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdUpdateS" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateS_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?"
                                Enabled="True" TargetControlID="cmdUpdateS">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdDeleteS" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteS_ConfirmButtonExtender"
                                runat="server" ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdDeleteS">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlRegionIns" runat="server" Visible="False">
            <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top;">
                        <dnn:label ID="plLugar" runat="server" ControlName="txtLugar" Suffix=":" Text="Región"
                            HelpText="Ingrese una Región" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtLugar" runat="server" CssClass="NormalTextBox" Width="100%"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtLugar_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtLugar" WatermarkText="Ingrese el nombre de la ciudad"
                            WatermarkCssClass="watermark">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLugar"
                            Display="None" ErrorMessage="Ingrese la Ubicación"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead" style="vertical-align: top;">
                        <asp:Button ID="cmdInsertR" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertR_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?"
                            Enabled="True" TargetControlID="cmdInsertR">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td class="SubHead" style="vertical-align: top;">
                        <asp:Button ID="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlRegionBus" runat="server" Visible="False">
            <fieldset id="panelbusR" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plServR" runat="server" ControlName="txtBuscarR"
                                Suffix=":" Text="Región"
                                HelpText="Busca la Zona por el Lugar" />
                        </td>
                        <td style="width: 350px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarR" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="btnBuscarR" runat="server" Text="Buscar" />
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="btnNuevoR" runat="server" Text="Nueva Región" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                            <asp:Label ID="lblMesR" runat="server" CssClass="men" Width="100%"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdRegion" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cLugar" HeaderText="Ubicación"
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
            <fieldset id="panelviewR" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plLugar1" runat="server" ControlName="txtLugar1" Suffix=":" Text="Región"
                                HelpText="Ubicación de la Región" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtLugar1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                TargetControlID="txtLugar1" WatermarkText="Ingrese el nombre de la ciudad"
                                WatermarkCssClass="watermark">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtLugar1"
                                Display="None" ErrorMessage="Ingrese la Ubicación" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator6">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdUpdaterR" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdaterR_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdaterR">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdDeleteR" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteR_ConfirmButtonExtender"
                                runat="server" ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdDeleteR">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlAsignacion" runat="server" Visible="False">
            <fieldset id="panelbus" runat="server">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;">
                            <dnn:label ID="plServ" runat="server" ControlName="txtBuscar" Suffix=":" Text="Parametro"
                                HelpText="Buscar la Asignación por Sucursal,Region o Jefe de Almacen" />
                        </td>
                        <td style="width: 350px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscar" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p>
                                <asp:Label ID="lblMes" runat="server" CssClass="men" Width="100%"></asp:Label>
                            </p>
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdAsignacion" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nCodAlmacen" HeaderText="Almacén" />
                                        <asp:BoundField DataField="cZona" HeaderText="Sucursal" />
                                        <asp:BoundField DataField="cLugar" HeaderText="Región" />
                                        <asp:BoundField DataField="cApellidoPaterno" HeaderText="Apellido" />
                                        <asp:BoundField DataField="cNombres" HeaderText="Nombres" />
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upHeader" runat="server" AssociatedUpdatePanelID="upPanel"
    DisplayAfter="0">
    <ProgressTemplate>
        <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" CssClass="men" runat="server" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
