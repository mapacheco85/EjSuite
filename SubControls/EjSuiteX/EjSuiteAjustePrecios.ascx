<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteAjustePrecios.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteAjustePrecios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" 
                        CausesValidation="False">Ajuste de Precios</asp:LinkButton>
                </td>                
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlBusquedaProducto" runat="server" Width="100%">
            <fieldset id="panelbusProd" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 180px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plBuscarProducto" runat="server" ControlName="txtBuscarProducto" Suffix=":"
                                Text="Marca/Proveedor" HelpText="Ingrese el nombre de la marca o proveedor" />
                        </td>
                        <td style="width: 262px; vertical-align: top;" class="SubHead">
                            <asp:TextBox ID="txtBuscarProductos" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td style="width: 70px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessageProducto" runat="server" Width="100%" Font-Bold="True"></asp:Label>
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdAjuste" runat="server" AutoGenerateColumns="False" 
                                    CssClass="Normal" Width="100%" BackColor="White" BorderColor="#3366CC" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="OK">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkmod" runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cEmpresa" HeaderText="Laboratorio" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                        <asp:BoundField DataField="cNombre" HeaderText="Proveedor" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                        <asp:BoundField DataField="cNombreGenerico" HeaderText="Nombre Comercial" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                        <asp:TemplateField HeaderText="Precio" 
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("nPrecioCompra")%>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("nPrecioCompra")%>' />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
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
            <fieldset id="panelviewProd" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 50%; vertical-align: top; text-align: center;">
                            <asp:Button ID="cmdUpdateProductos" runat="server" CssClass="CommandButton" Text="Modificar"
                                Style="height: 26px" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" 
                                ConfirmText="Desea realizar el ajuste de precios?"
                                Enabled="True" TargetControlID="cmdUpdateProductos">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
                        </td>
                        <td style="width: 50%; vertical-align: top; text-align: center;">
                            <asp:Button ID="cmdLimpiar" runat="server" CssClass="CommandButton" Text="Cancelar"
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
        <br />
        <asp:Image ID="imgUpdateHeader" runat="server" ImageUrl="~/Images/dnnanim.gif" ImageAlign="Middle" />
        <asp:Label ID="lblUpdateHeader" runat="server" CssClass="normal" Text="Espere por favor..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
<Flan:UpdateProgressOverlayExtender ID="upoeHeader" runat="server" TargetControlID="upHeader"
    CssClass="updateProgress" ControlToOverlayID="upPanel" OverlayType="Browser" />
