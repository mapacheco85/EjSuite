<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteValeConsumo.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteValeConsumo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc2" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" 
                        CausesValidation="False">Vale de Consumo</asp:LinkButton>
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
        <asp:Panel ID="pnlNuevaMerma" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plProductoMerma" runat="server" Suffix=":" Text="Producto" HelpText="Nombre del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <uc2:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCantidadsueltosMerma" runat="server" ControlName="txtCantidadsueltosMerma"
                            Suffix=":" Text="Cantidad Sueltos" HelpText="Cantidad de productos sueltos" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCantidadsueltosMerma" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCantidadsueltosMerma_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtCantidadsueltosMerma" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCantidadsueltosMerma"
                            Display="None" ErrorMessage="Ingrese una cantidad de productos fraccionados correcta"
                            SetFocusOnError="True" ValidationExpression="\d{0,9}">
                        </asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator1">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidadsueltosMerma"
                            Display="None" ErrorMessage="Ingrese la cantidad de productos fraccionados" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCantidadenvasesMerma" runat="server" ControlName="txtCantidadenvasesMerma"
                            Suffix=":" Text="Cantidad Envases" HelpText="Cantidad envases del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtCantidadenvasesMerma" runat="server" CssClass="NormalTextBox"
                            Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtCantidadenvasesMerma_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtCantidadenvasesMerma" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCantidadenvasesMerma"
                            Display="None" ErrorMessage="Ingrese una cantidad de unidades del producto correcta"
                            SetFocusOnError="True" ValidationExpression="\d{0,9}">
                        </asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                            TargetControlID="RegularExpressionValidator2">
                        </cc1:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidadenvasesMerma"
                            Display="None" ErrorMessage="Ingrese la cantidad de unidades del producto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCausaMerma" runat="server" Suffix=":" Text="Causa" HelpText="Nombre del producto" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:DropDownList ID="ddlCausaMerma" runat="server">
                            <asp:ListItem Value="0">Vencimiento</asp:ListItem>
                            <asp:ListItem Value="1">Inconformidad</asp:ListItem>
                            <asp:ListItem Value="2">Consignacion</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertMerma" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertMerma_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertMerma">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelMerma" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblMessageMerma" runat="server"></asp:Label>
        <br />
        <asp:LinkButton ID="lbtnKardexMerma" runat="server">Ir a Kardex</asp:LinkButton>
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
