<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteTraspasos.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteTraspasos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc1" %>
<%@ Register Src="AlmacenEmpleadoControlSearch.ascx" TagName="AlmacenEmpleadoControlSearch"
    TagPrefix="uc2" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Traspasos</asp:LinkButton>
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
        <asp:Panel ID="pnlNuevoTraspaso" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plProductoTraspaso" runat="server" Suffix=":" Text="Producto" HelpText="Nombre del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc1:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plAlmacenorigenTraspaso" runat="server" Suffix=":" Text="Almacen origen"
                            HelpText="Almacen de origen para realizar el traspaso" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Label ID="lblAlmacenorigenTraspaso" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plAlmacendestinoTraspaso" runat="server" Suffix=":" Text="Almacen destino"
                            HelpText="Almacen de destino para realizar el traspaso" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc2:AlmacenEmpleadoControlSearch ID="AlmacenEmpleadoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCantidadsueltosTraspaso" runat="server" ControlName="txtCantidadsueltosTraspaso"
                            Suffix=":" Text="Cantidad Sueltos" HelpText="Cantidad de Productos en sueltos" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCantidadsueltosTraspaso" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCantidadsueltosTraspaso_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtCantidadsueltosTraspaso" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCantidadsueltosTraspaso"
                            Display="None" ErrorMessage="Ingrese una cantidad de productos fraccionados correcta"
                            SetFocusOnError="True" ValidationExpression="\d{0,9}"> </asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator1">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidadsueltosTraspaso"
                            Display="None" ErrorMessage="Ingrese la cantidad de productos fraccionados" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCantidadenvasesTraspaso" runat="server" ControlName="txtCantidadenvasesTraspaso"
                            Suffix=":" Text="Cantidad Cajas" HelpText="Cantidad de Cajas del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCantidadenvasesTraspaso" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCantidadenvasesTraspaso_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtCantidadenvasesTraspaso" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCantidadenvasesTraspaso"
                            Display="None" ErrorMessage="Ingrese una cantidad de unidades del producto correcta"
                            SetFocusOnError="True" ValidationExpression="\d{0,9}"> </asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator2">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidadenvasesTraspaso"
                            Display="None" ErrorMessage="Ingrese la cantidad de unidades del producto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertTraspaso" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertTraspaso_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertTraspaso">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelTraspaso" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblMessageTraspaso" runat="server"></asp:Label>
        <br />
        <asp:LinkButton ID="lbtnKardexTraspaso" runat="server">Ir a Kardex</asp:LinkButton>
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