<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteDatosSni.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteDatosSni" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<style type="text/css">
    .auto-style1
    {
        width: 120px;
    }
</style>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">
					Nueva Dosificación</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">
					Búsqueda Dosificación</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlNuevoDatosSNI" runat="server">
            <table style="width: 512px; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plLlaveDatosSni" runat="server" ControlName="txtLlaveDatosSni" Suffix=":"
                            Text="Llave Dosificadora" HelpText="Llave del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtLlaveDatosSni" runat="server" CssClass="NormalTextBox" Width="280px"
                            Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtLlaveDatosSni_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtLlaveDatosSni" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ControlToValidate="txtLlaveDatosSni"
                            Display="None" ErrorMessage="Ingrese la llave" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plAutorizacionDatosSni" runat="server" ControlName="txtAutorizacionDatosSni"
                            Suffix=":" Text="No. Autorización" HelpText="Autorización del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtAutorizacionDatosSni" runat="server" CssClass="NormalTextBox"
                            Width="280px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtAutorizacionDatosSni_TextBoxWatermarkExtender"
                            runat="server" Enabled="True"
                            TargetControlID="txtAutorizacionDatosSni" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                            runat="server" ControlToValidate="txtAutorizacionDatosSni"
                            Display="None" ErrorMessage="Ingrese un número de autorización correcto"
                            SetFocusOnError="True" ValidationExpression="\d{0,15}"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender0"
                            runat="server" Enabled="True" TargetControlID="RegularExpressionValidator3">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ControlToValidate="txtAutorizacionDatosSni"
                            Display="None" ErrorMessage="Autorización" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechainicialDatosSni" runat="server" ControlName="txtFechainicioDatosSni"
                            Suffix=":" Text="Fecha Inicio" HelpText="Fecha de inicio del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechainicioDatosSni" runat="server" EditMode="CalendarOnly"
                            DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                        </ig:WebDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFechafinDatosSni" runat="server" ControlName="txtFechafinDatosSni"
                            Suffix=":" Text="Fecha Límite" HelpText="Fecha límite del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <ig:WebDatePicker ID="txtFechafinDatosSni" runat="server" EditMode="CalendarOnly"
                            DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                        </ig:WebDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plFacturaInicialDatosSni" runat="server" ControlName="txtFacturaInicial"
                            Suffix=":" Text="No. Factura Inicial" HelpText="Numero de Factura Inicial del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtFacturaInicial" runat="server" CssClass="NormalTextBox" Width="280px"
                            Text=""></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                            TargetControlID="txtFacturaInicial" WatermarkCssClass="watermark" WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFacturaInicial"
                            Display="None" ErrorMessage="Ingrese un numero valido" Operator="DataTypeCheck"
                            SetFocusOnError="True" Type="Integer"></asp:CompareValidator>
                        <cc1:ValidatorCalloutExtender ID="CompareValidator3_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="CompareValidator3">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plLeyenda453" runat="server" ControlName="ddlLeyenda453"
                            Suffix=":" Text="Leyenda 453" HelpText="Fecha de inicio del Dato SNI" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:DropDownList ID="ddlLeyenda453" runat="server" AutoPostBack="True"
                            Width="100%" Font-Size="X-Small">
                        </asp:DropDownList>
                        <cc1:DropDownExtender ID="ddlLeyenda453_DropDownExtender" runat="server"
                            DynamicServicePath="" Enabled="True" TargetControlID="ddlLeyenda453">
                        </cc1:DropDownExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsert" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsert_ConfirmButtonExtender"
                            runat="server" ConfirmText="Desea ingresar este registro?"
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
        <asp:Panel ID="pnlBusquedaDatosSNI" runat="server" DefaultButton="btnBuscarDatosSni">
            <fieldset id="panelbusDat" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarDatosSni" runat="server"
                                ControlName="txtBuscarDatosSni" Suffix=":"
                                Text="Fecha" HelpText="Ingrese fecha de inicio del Dato SNI" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <ig:WebDatePicker ID="txtBuscarDatosSni" runat="server" Culture="es-BO" DataMode="Text" DisplayModeFormat="d">
                            </ig:WebDatePicker>
                        </td>
                        <td style="vertical-align: top;" class="auto-style1">
                            <asp:Button ID="btnBuscarDatosSni" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100%;">
                            <asp:Label ID="lblMessageDatosSNI" runat="server"></asp:Label>
                            <br />
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdDatosSNI" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cLlave" HeaderText="Llave Dosificador"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cAutorizacion" HeaderText="Nro. Autorización"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Fecha Inicio"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Fecha Límite"
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
            <fieldset id="panelviewDat" runat="server" style="width: 512px">
                <table style="width: 512px; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plLlaveDatosSni1" runat="server" ControlName="txtLlaveDatosSni1" Suffix=":"
                                Text="Llave Dosificadora" HelpText="Llave del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtLlaveDatosSni1" runat="server" CssClass="NormalTextBox" Width="280px"
                                Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                TargetControlID="txtLlaveDatosSni1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                runat="server" ControlToValidate="txtLlaveDatosSni1"
                                Display="None" ErrorMessage="Ingrese la llave"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator6">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plAutorizacionDatosSni1"
                                runat="server" ControlName="txtAutorizacionDatosSni1"
                                Suffix=":" Text="No. Autorización" HelpText="Autorización del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtAutorizacionDatosSni1" runat="server" CssClass="NormalTextBox"
                                Width="280px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                TargetControlID="txtAutorizacionDatosSni1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                runat="server" ControlToValidate="txtAutorizacionDatosSni1"
                                Display="None" ErrorMessage="Ingrese un número de autorización correcto"
                                SetFocusOnError="True" ValidationExpression="\d{0,15}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator4_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RegularExpressionValidator4">
                            </cc1:ValidatorCalloutExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                runat="server" ControlToValidate="txtAutorizacionDatosSni1"
                                Display="None" ErrorMessage="Autorización"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator7">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicioDatosSni1"
                                runat="server" ControlName="txtFechainicioDatosSni1"
                                Suffix=":" Text="Fecha Inicio" HelpText="Fecha de inicio del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicioDatosSni1" runat="server"
                                DisplayModeFormat="d" Culture="es-BO">
                                <Buttons SpinButtonsDisplay="OnRight">
                                </Buttons>
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinDatosSni1"
                                runat="server" ControlName="txtFechafinDatosSni1"
                                Suffix=":" Text="Fecha Límite" HelpText="Fecha limite del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinDatosSni1" runat="server"
                                DisplayModeFormat="d" Culture="es-BO">
                                <Buttons SpinButtonsDisplay="OnRight">
                                </Buttons>
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFacturaInicialDatosSni1"
                                runat="server" ControlName="txtFacturaInicial1"
                                Suffix=":" Text="No. Factura Inicial"
                                HelpText="Numero de Factura Inicial del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtFacturaInicial1" runat="server"
                                CssClass="NormalTextBox" Width="280px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                TargetControlID="txtFacturaInicial1" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtFacturaInicial1"
                                Display="None" ErrorMessage="Ingrese un dato numérico" Operator="DataTypeCheck"
                                SetFocusOnError="True" Type="Integer"></asp:CompareValidator>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plLeyenda4531" runat="server" ControlName="ddlLeyenda4531"
                                Suffix=":" Text="Leyenda 453" HelpText="Fecha de inicio del Dato SNI" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:DropDownList ID="ddlLeyenda4531" runat="server" AutoPostBack="True"
                                Width="100%" Font-Size="X-Small">
                            </asp:DropDownList>
                            <cc1:DropDownExtender ID="DropDownExtender1" runat="server"
                                DynamicServicePath="" Enabled="True" TargetControlID="ddlLeyenda4531">
                            </cc1:DropDownExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateDatosSni" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateDatosSni_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?"
                                Enabled="True" TargetControlID="cmdUpdateDatosSni">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteDatosSni" runat="server"
                                CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteDatosSni_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdDeleteDatosSni">
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
