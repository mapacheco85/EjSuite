<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteListaGrupos.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteListaGrupos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">
                    Gestion de Grupos</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">
                    Gestión de Listas</asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlGrupos" runat="server">
            <fieldset id="fsGrupos" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarGrupo" runat="server" ControlName="txtBuscarGrupo" Suffix=":"
                                Text="Grupo" HelpText="Ingrese el nombre del Grupo" />
                        </td>
                        <td style="width: 550px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarGrupo" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarGrupo" runat="server" Text="Buscar" />
                        </td>
                        <td style="vertical-align: top;" class="SubHead">
                            <asp:LinkButton ID="lbtnNuevoGrupo" runat="server">Nuevo Registro</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMessageGrupo" runat="server"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdGrupo" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ScrollBars="Auto" EmptyDataText="No se encontraron registros."
                                    Width="100%" BackColor="White" BorderColor="#3366CC" 
                                    BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="nCodGrupo" HeaderText="Cod.Grupo" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cTipoGrupo" HeaderText="Nombre" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399"
                                         Font-Bold="True" ForeColor="#CCCCFF" />
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
            <fieldset id="fsGruposCrud" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td>
                            <dnn:label ID="plNombreGrupo" runat="server" ControlName="txtNombreGrupo" Suffix=":"
                                Text="Nombre" HelpText="Nombre del grupo" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombreGrupo" runat="server" CssClass="NormalTextBox"
                                 Width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtNombreGrupo_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtNombreGrupo" WatermarkCssClass="watermark"
                                WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                 ControlToValidate="txtNombreGrupo"
                                Display="None" ErrorMessage="Ingrese el nombre del cliente"
                                 SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="cmdInsertUpdate" runat="server" CssClass="CommandButton" Text="Modificar" />
                            <cc1:ConfirmButtonExtender ID="cmdUpdateCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea hacer esta operacion con este registro?" Enabled="True"
                                 TargetControlID="cmdInsertUpdate">
                            </cc1:ConfirmButtonExtender>
                            &nbsp; &nbsp;
                            <asp:Button ID="cmdDeleteClear" runat="server" CssClass="CommandButton" Text="Eliminar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="cmdDeleteCliente_ConfirmButtonExtender" runat="server"
                                ConfirmText="Desea hacer esta operacion con este registro?" Enabled="True"
                                 TargetControlID="cmdDeleteClear">
                            </cc1:ConfirmButtonExtender>
                            &nbsp; &nbsp;
                            <asp:Button ID="cmdCancelar" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                 ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdCancelar">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlListados" runat="server">
            <fieldset id="fsListados" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarProducto" runat="server" ControlName="txtBuscarProducto" Suffix=":"
                                Text="Producto" HelpText="Ingrese el nombre del Producto" />
                        </td>
                        <td style="width: 550px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarProducto" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td class="SubHead" style="width: 100px; vertical-align: top;">
                            <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" />
                        </td>
                        <td class="SubHead" style="width: 150px; vertical-align: top;">
                            <asp:LinkButton ID="lbtnNuevoElemento" runat="server">Nuevo Registro</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMessageProductos" runat="server"></asp:Label>
                            <br />
                            <br />
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ScrollBars="Auto" EmptyDataText="No se encontraron registros."
                                    Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="cTipoGrupo" HeaderText="Grupo" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cNombreComercial" HeaderText="Producto" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White"
                                         ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True" 
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
            <fieldset id="fsListadosCrud" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td colspan="2">
                            <div style="width: 100%; height: 200px; overflow: scroll">
                                <asp:GridView ID="grdSinListado" runat="server" 
                                    AutoGenerateColumns="False" CssClass="Normal"
                                    ScrollBars="Auto" 
                                    EmptyDataText="No se encontraron registros."
                                    Width="100%" BackColor="White" BorderColor="#3366CC" 
                                    BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" 
                                            HeaderStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cNombreComercial" HeaderText="Producto" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cDetalles" HeaderText="Descripción" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dnn:label ID="plNombreProducto" runat="server" ControlName="txtNombreProducto" Suffix=":"
                                Text="Nombre" HelpText="Nombre del producto" />
                        </td>
                        <td>
                            <asp:Label ID="txtNombreProducto" runat="server" CssClass="NormalTextBox" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dnn:label ID="plGrupo" runat="server" ControlName="ddlGrupo" Suffix=":" Text="Grupo"
                                HelpText="Nombre del grupo" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="cmdInsertarModificarLista" runat="server" CssClass="CommandButton"
                                Text="Insertar" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Desea modificar este registro?"
                                Enabled="True" TargetControlID="cmdInsertarModificarLista">
                            </cc1:ConfirmButtonExtender>
                            &nbsp; &nbsp;
                            <asp:Button ID="cmdEliminarLimpiarLista" runat="server" CssClass="CommandButton"
                                Text="Eliminar" CausesValidation="False" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" ConfirmText="Desea eliminar este registro?"
                                Enabled="True" TargetControlID="cmdEliminarLimpiarLista">
                            </cc1:ConfirmButtonExtender>
                            &nbsp; &nbsp;
                            <asp:Button ID="cmdCancelarLista" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
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
        <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" runat="server" CssClass="normal" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
