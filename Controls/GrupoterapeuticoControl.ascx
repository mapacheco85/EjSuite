<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GrupoterapeuticoControl.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.GrupoterapeuticoControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<asp:ImageButton ID="lbnElegir" runat="server" EnableViewState="false"
    ImageUrl="~/DesktopModules/EjSuite/Images/add_me.gif" />
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="True" BackgroundCssClass="modalBackground"
    PopupControlID="pnlSearchModal" Enabled="True" TargetControlID="lbnElegir">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnlSearchModal" Style="display: none; background-color: InfoBackground;" runat="server" DefaultButton="cmdSearch">
    <asp:UpdatePanel ID="upsearchModal" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <fieldset id="fsContactSearch" runat="server">
                <legend>
                    <asp:Label ID="lblLinea" runat="server"
                        Text="Buscar Grupo Ventas"
                        Font-Bold="True" />
                </legend>
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 200px" class="SubHead">
                            <dnn:label ID="plGrupoTerapeutico" runat="server" ControlName="txtBusqueda"
                                Suffix=":" Text="Grupo Ventas" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBusqueda" runat="server" EnableViewState="False"
                                Width="100%" /><br />
                            <asp:LinkButton ID="cmdSearch" runat="server" Text="Buscar"
                                CssClass="CommandButton" CausesValidation="False" />&nbsp;
                            <asp:HyperLink ID="hypAdminEmpresa" runat="server" Target="_blank"
                                Font-Italic="False">Gestionar Grupos Ventas</asp:HyperLink>&nbsp;
                            <asp:LinkButton ID="cmdCancel" runat="server" Text="Cancelar" CssClass="CommandButton"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblSearchResults" runat="server" Font-Bold="True"></asp:Label>

                            <div style="width: 100%; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdGruposTerapeuticos" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No se encontraron registros."
                                    CssClass="tablecloth-theme" Width="100%" BackColor="White"
                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <AlternatingRowStyle CssClass="alt-data-row" />
                                    <PagerStyle CssClass="grvpager" BackColor="#99CCCC" ForeColor="#003399"
                                        HorizontalAlign="Left" />
                                    <RowStyle CssClass="row-over" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle CssClass="footer" BackColor="#99CCCC" ForeColor="#003399" />
                                    <SelectedRowStyle CssClass="row-select" BackColor="#009999" Font-Bold="True"
                                        ForeColor="#CCFF99" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Código"></asp:TemplateField>
                                        <asp:BoundField DataField="cGrupoProducto" HeaderText="Grupo Ventas" />
                                    </Columns>
                                    <PagerStyle CssClass="Sellersgridviewpager" />
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
