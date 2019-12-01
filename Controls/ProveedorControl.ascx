<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProveedorControl.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.ProveedorControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<asp:ImageButton ID="lbnElegir" runat="server" EnableViewState="false"
    ImageUrl="~/DesktopModules/EjSuite/Images/add_me.gif" />
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="True"
    BackgroundCssClass="modalBackground" PopupControlID="pnlSearchModal" Enabled="True"
    TargetControlID="lbnElegir">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlSearchModal" Style="display: none; background-color: InfoBackground;"
    runat="server" DefaultButton="cmdSearch">
    <asp:UpdatePanel ID="upsearchModal" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <fieldset id="fsContactSearch" runat="server">
                <legend>
                    <asp:Label ID="lblLinea" runat="server" Text="Buscar Proveedor"
                        Font-Bold="True" />
                </legend>
                <table style="width:100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 650px">
                            <table border="0" style=" padding: 0px; border-spacing: 0px;">
                                <tr>
                                    <td style="width: 147px" class="SubHead">
                                        <dnn:label ID="plRazonSocial" runat="server" ControlName="txtBusqueda" Suffix=":"
                                            Text="Proveedor" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBusqueda" runat="server" EnableViewState="False" Width="100%" /><br />
                                        <asp:LinkButton ID="cmdSearch" runat="server" Text="Buscar" CssClass="CommandButton"
                                            CausesValidation="False" />&nbsp;
                                        <asp:HyperLink ID="hypAdminEmpresa" runat="server" Target="_blank"
                                            Font-Italic="False">Gestionar proveedores</asp:HyperLink>&nbsp;
                                        <asp:LinkButton ID="cmdCancel" runat="server" Text="Cancelar" CssClass="CommandButton"
                                            CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblSearchResults" runat="server" Font-Bold="True"></asp:Label>
                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdProveedores" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron registros."
                                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Proveedor" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cRepresentante" HeaderText="Contacto"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cTelefono" HeaderText="Teléfono"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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
