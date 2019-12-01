<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteZonas.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteZonas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Nueva Zona</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda Zonas</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 512px; height: 19px;border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlNuevoZona" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <dnn:label ID="plCodigoZona" runat="server" ControlName="txtDescripcion" Suffix=":"
                            Text="Zona" HelpText="Dato de Zona unico" />
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDescripcion_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtDescripcion" WatermarkCssClass="watermark"
                            WatermarkText="*">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdInsertZona" runat="server" CssClass="CommandButton" Text="Insertar" />
                        <cc1:ConfirmButtonExtender ID="cmdInsertZona_ConfirmButtonExtender" runat="server"
                            ConfirmText="Desea ingresar este registro?" Enabled="True" TargetControlID="cmdInsertZona">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;
                    </td>
                    <td style="width: 120px; vertical-align: top;" class="SubHead">
                        <asp:Button ID="cmdCancelZona" runat="server" CssClass="CommandButton" Text="Cancelar"
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusquedaZona" runat="server">
            <fieldset id="panelbusCli" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarZona" runat="server" ControlName="txtBuscarZona" Suffix=":"
                                Text="Zona" HelpText="Ingrese el nombre del Zona" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarZona" runat="server" Width="340px"></asp:TextBox>
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarZona" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageZona" runat="server"></asp:Label>
                            <br />
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdZona" runat="server" AutoGenerateColumns="False"
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    EmptyDataText="No se encontraron registros."
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nCodUnidad" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDescripcion" HeaderText="ZONA" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plCodigoZona1" runat="server" ControlName="txtCodigoZona1" Suffix=":"
                                Text="Zona" HelpText="Dato de Zona unico" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtDescripcion1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtDescripcion1_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtDescripcion1" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdUpdateZona" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateZona_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea modificar este registro?" Enabled="True" TargetControlID="cmdUpdateZona">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdDeleteZona" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteZona_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea eliminar este registro?" Enabled="True" TargetControlID="cmdDeleteZona">
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
