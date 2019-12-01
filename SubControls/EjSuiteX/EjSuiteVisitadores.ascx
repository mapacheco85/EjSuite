<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteVisitadores.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteVisitadores" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="EmpleadoControlSearch.ascx" TagName="EmpleadoControlSearch" TagPrefix="uc1" %>
<%@ Register Src="SucursalControlSearch.ascx" TagName="SucursalControlSearch" TagPrefix="uc2" %>
<%@ Register Assembly="Infragistics4.WebUI.WebSchedule.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Datos Empleados</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Asignación de Sucursal</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button"
                        CausesValidation="False">Búsqueda de Empleados/Asignación</asp:LinkButton>
                </td>
            </tr>
        </table>
        <p></p>
        <asp:Panel ID="pnlBusquedaEmpleado" runat="server">
            <fieldset id="panelbusEmp" runat="server" style="width: 100%; height: 100%;">
                <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <dnn:label ID="plBuscarEmpleado" runat="server"
                                ControlName="txtBuscarEmpleado" Suffix=":"
                                Text="Buscar Empleado:" HelpText="Ingrese el Nombre o Apellido del empleado" />
                        </td>
                        <td style="width: 350px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarEmpleado" runat="server"
                                Width="100%" BorderColor="Black"
                                BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="btnBuscarEmpleado" runat="server"
                                Text="Buscar" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageEmpleado" runat="server"></asp:Label><br />
                            <br />
                            <div style="width: auto; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdEmpleado" runat="server" AutoGenerateColumns="False" Width="100%"
                                    EmptyDataText="Registros no encontrados" ScrollBars="Auto" CssClass="Normal"
                                    BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                        <asp:BoundField DataField="cNombres" HeaderText="Nombres"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="cNombres" />
                                        <asp:BoundField DataField="cApellidoPaterno" HeaderText="Apellidos"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="cApellidoPaterno" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top"
                                        BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Center" BackColor="#003399"
                                        Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True"
                                        ForeColor="#CCFF99" />
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
            <fieldset id="panelviewEmp" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <dnn:label ID="plUseridEmpleado" runat="server" ControlName="lblUseridEmpleado" Suffix=":"
                                Text="Cod. Empleado" HelpText="Código de empleado" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblUseridEmpleado" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <dnn:label ID="plNombresEmpleado" runat="server" ControlName="txtNombresEmpleado"
                                Suffix=":" Text="Nombre(s)" HelpText="Nombre(s) del empleado" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtNombresEmpleado" runat="server" CssClass="NormalTextBox"
                                Width="267px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                TargetControlID="txtNombresEmpleado"
                                WatermarkText="*">
                            </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtNombresEmpleado"
                                Display="None" ErrorMessage="Ingrese el(los) nombre(s) del empleado"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" PopupPosition="Left">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <dnn:label ID="plApellidosEmpleado" runat="server" ControlName="txtApellidosEmpleado"
                                Suffix=":" Text="Apellido(s)" HelpText="Apellidos del Empleado" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtApellidosEmpleado" runat="server"
                                CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtApellidosEmpleado"
                                Display="None" ErrorMessage="Ingrese los apellidos del empleado"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender
                                ID="RequiredFieldValidator2_ValidatorCalloutExtender" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator2">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdUpdateEmpleado" runat="server" Text="Modificar" /><asp:ConfirmButtonExtender
                                ID="cmdUpdateEmpleado_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea confirmar esta modificación?"
                                Enabled="True" TargetControlID="cmdUpdateEmpleado">
                            </asp:ConfirmButtonExtender>
                            &#160;&#160;
                        </td>
                        <td class="SubHead" style="vertical-align: top;">
                            <asp:Button ID="cmdDeleteEmpleado" runat="server" Text="Cancelar" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlNuevaActividad" runat="server">
            <table style="border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="vertical-align: top;" class="SubHead">
                        <dnn:label ID="plSucursalidActividad" runat="server" ControlName="txtSucursalidActividad"
                            Suffix=":" Text="Sucursal" HelpText="Asignar Sucursal" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc2:SucursalControlSearch ID="SucursalControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;" class="SubHead">
                        <dnn:label ID="plEmpleadoidActividad" runat="server" ControlName="txtEmpleadoidActividad"
                            Suffix=":" Text="Empleado" HelpText="Asignar Empleado" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:EmpleadoControlSearch ID="EmpleadoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechainicioActividad" runat="server" ControlName="txtFechainicioActividad"
                            Suffix=":" Text="Fecha inicio" HelpText="Fecha de inicio de la actividad" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechainicioActividad" runat="server" EditMode="KeyboardAndCalendar"
                            DisplayModeFormat="d" Culture="es-BO">
                        </ig:WebDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtFechainicioActividad"
                            Display="None" ErrorMessage="Ingrese la fecha de inicio de la actividad"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3" PopupPosition="Left">
                        </asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToCompare="txtFechafinalActividad"
                            ControlToValidate="txtFechainicioActividad"
                            ErrorMessage="La fecha de inicio de la actividad debe ser menor a la fecha final de la actividad"
                            Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="CompareValidator1">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechafinalActividad" runat="server" ControlName="txtFechafinalActividad"
                            Suffix=":" Text="Fecha final" HelpText="Fecha de finalización de la actividad" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechafinalActividad" runat="server" EditMode="KeyboardAndCalendar"
                            DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                        </ig:WebDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertActividad" runat="server" Text="Insertar" />
                        <asp:ConfirmButtonExtender ID="cmdInsertActividad_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertActividad">
                        </asp:ConfirmButtonExtender>
                    </td>
                    <td style="vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelActividad" runat="server" Text="Cancelar" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaActividad" runat="server">
            <fieldset id="panelbusAct" runat="server" style="width: 100%;">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarActividad" runat="server"
                                ControlName="txtBuscarActividad"
                                Suffix=":" Text="Asignación"
                                HelpText="Ingrese el nombre o apellido del empleado para ver sus zonas asignadas">
                            </dnn:label>
                        </td>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarActividad" runat="server" Width="340px"></asp:TextBox>
                        </td>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarActividad" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageActividad" runat="server"></asp:Label><br />
                            <br />
                            <div style="width: auto; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdActividad" runat="server"
                                    AutoGenerateColumns="False" CssClass="Normal"
                                    Width="100%" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cNombres" HeaderText="Nombres"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cApellidoPaterno" HeaderText="Apellidos"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="F. Inicio"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="F. Final"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cZona" HeaderText="Zona"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399"
                                        Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top"
                                        BackColor="White" ForeColor="#003399" />
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
            <fieldset id="panelviewAct" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plSucursalidActividad1" runat="server" ControlName="lblSucursalidActividad1"
                                Suffix=":" Text="Sucursal" HelpText="Asignar Sucursal">
                            </dnn:label>
                        </td>
                        <td style="vertical-align: top;">
                            <table style="width: 390px">
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:HiddenField ID="hfSucursalidActividad1" runat="server" />
                                    </td>
                                    <td style="vertical-align: top; width: 100px">
                                        <asp:Label ID="lblSucursalidActividad1" runat="server"></asp:Label>
                                    </td>
                                    <td style="vertical-align: top;">
                                        <uc2:SucursalControlSearch ID="SucursalControlSearch2" runat="server">
                                        </uc2:SucursalControlSearch>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plEmpleadoidActividad1" runat="server"
                                ControlName="lblEmpleadoidActividad1"
                                Suffix=":" Text="Empleado" HelpText="Asignar Empleado">
                            </dnn:label>
                        </td>
                        <td style="vertical-align: top;">
                            <table style="width: 390px">
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:HiddenField ID="hfEmpleadoidActividad1" runat="server" />
                                    </td>
                                    <td style="vertical-align: top; width: 100px">
                                        <asp:Label ID="lblEmpleadoidActividad1" runat="server"></asp:Label>
                                    </td>
                                    <td style="vertical-align: top;">
                                        <uc1:EmpleadoControlSearch ID="EmpleadoControlSearch2" runat="server">
                                        </uc1:EmpleadoControlSearch>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicioActividad1" runat="server" ControlName="txtFechainicioActividad1"
                                Suffix=":" Text="Fecha inicio" HelpText="Fecha de inicio de la actividad">
                            </dnn:label>
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicioActividad1" runat="server" DisplayModeFormat="d"
                                Culture="es-BO">
                                <Buttons SpinButtonsDisplay="OnRight">
                                </Buttons>
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtFechainicioActividad1"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de la actividad"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4"
                                PopupPosition="Left">
                            </asp:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator2" runat="server"
                                ControlToCompare="txtFechafinalActividad1"
                                ControlToValidate="txtFechainicioActividad1"
                                ErrorMessage="La fecha de inicio de la actividad debe ser menor a la fecha final de la actividad"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="CompareValidator2_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator2" PopupPosition="Left">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalActividad1" runat="server"
                                ControlName="txtFechafinalActividad1"
                                Suffix=":" Text="Fecha final" HelpText="Fecha de finalización de la actividad">
                            </dnn:label>
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalActividad1" runat="server" DisplayModeFormat="d"
                                Culture="es-BO">
                                <Buttons SpinButtonsDisplay="OnRight">
                                </Buttons>
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateActividad" runat="server" Text="Modificar" />
                            <asp:ConfirmButtonExtender ID="cmdUpdateActividad_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True"
                                TargetControlID="cmdUpdateActividad">
                            </asp:ConfirmButtonExtender>
                        </td>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteActividad" runat="server" Text="Eliminar"
                                CausesValidation="False" />
                            <asp:ConfirmButtonExtender ID="cmdDeleteActividad_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True"
                                TargetControlID="cmdDeleteActividad">
                            </asp:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
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
