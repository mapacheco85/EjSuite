<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="sucursal1Control.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.sucursal1Control" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<asp:ImageButton ID="lbnPopup" runat="server" EnableViewState="false"
    ImageUrl="~/DesktopModules/EjSuite/Images/add_me.gif" />
<cc1:ModalPopupExtender ID="ModalPopup1" runat="server" DropShadow="True" BackgroundCssClass="modalBackground"
    PopupControlID="pnlPopup" Enabled="True" TargetControlID="lbnPopup">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlPopup" Style="display: none; background-color: InfoBackground;"
    runat="server" DefaultButton="cmdBuscar1">
    <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <fieldset id="fsBusqueda" runat="server">
                <legend>
                    <asp:Label ID="lblTitulo1" runat="server" Text="Buscar Sucursal" Font-Bold="True"
                        Style="margin-bottom: 0px" />
                </legend>
                <table style="width:100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 150px" class="SubHead">
                            <dnn:label ID="plSucursal1" runat="server" ControlName="txtBusqueda" Suffix=":" Text="Sucursal" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBusqueda" runat="server" EnableViewState="False" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="cmdBuscar1" runat="server" Text="Buscar" CssClass="CommandButton"
                                CausesValidation="False" />&nbsp;
                            <asp:HyperLink ID="hypSucursal1" runat="server" Target="_blank" Font-Italic="False">Gestionar Sucursal</asp:HyperLink>&nbsp;
                            <asp:LinkButton ID="cmdCancelar1" runat="server" Text="Cancelar" CssClass="CommandButton"
                                CausesValidation="False" />
                            <asp:Label ID="lblResult" runat="server" Font-Bold="True"></asp:Label>
                            <div style="width: 100%; height: 250px; overflow: scroll;">
                                <asp:GridView ID="grdSucursal1" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron registros."
                                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Zona" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cDireccion" HeaderText="Dirección"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CheckBoxField DataField="bCasaMatriz" HeaderText="Casa Matriz"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CheckBoxField>
                                    </Columns>
                                    <PagerStyle CssClass="Sellersgridviewpager" BackColor="#99CCCC"
                                        ForeColor="#003399" HorizontalAlign="Left" />
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
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
