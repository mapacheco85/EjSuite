<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DeudorControl.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.DeudorControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<asp:ImageButton ID="lbnElegir" runat="server" EnableViewState="false"
    ImageUrl="~/DesktopModules/MarkdisNotes/Images/add_me.gif" />
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="True"
    BackgroundCssClass="modalBackground" PopupControlID="pnlSearchModal" Enabled="True"
    TargetControlID="lbnElegir">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlSearchModal" Style="display: none; background-color: InfoBackground;"
    runat="server">
    <asp:UpdatePanel ID="upsearchModal" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <fieldset id="fsContactSearch" runat="server">
                <legend>
                    <asp:Label ID="lblLinea" runat="server" Text="Deudores" />
                </legend>
                <table style="width: 100%;border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td class="SubHead" style="width: 120px; vertical-align: top;">
                            <dnn:label ID="plFechafinalDeudas" runat="server"
                                ControlName="txtFechafinalDeudas" HelpText="Fecha final para la búsqueda"
                                Suffix=":" Text="Fecha final" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtFechafinalDeudas" runat="server" CssClass="NormalTextBox"
                                Width="167px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                Format="yyyy-MM-dd" TargetControlID="txtFechafinalDeudas"
                                TodaysDateFormat="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="cmdCancel" runat="server" CausesValidation="False"
                                CssClass="CommandButton" Text="Cancel" />
                            <br />
                            <asp:Label ID="lblSearchResults" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 250px; overflow: scroll">
                                <asp:GridView ID="grdDeudas" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" CssClass="Normal">
                                    <Columns>
                                        <asp:BoundField DataField="clienteid" HeaderText="CODIGO" />
                                        <asp:BoundField DataField="cliente" HeaderText="CLIENTE" />
                                        <asp:BoundField DataField="vendedor" HeaderText="VENDEDOR" />
                                        <asp:BoundField DataField="numero" HeaderText="FACTURA No">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="EMITIDA EL"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="VENCE EL"></asp:TemplateField>
                                        <asp:BoundField DataField="Deuda" DataFormatString="{0:F}" HeaderText="SALDO">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Left"
                                        VerticalAlign="Top" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"
                                        HorizontalAlign="Left" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
