<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteVencidos.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteVencidos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProveedorControlSearch.ascx" TagName="ProveedorControlSearch" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Lotes Vencidos</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Lotes No Vencidos</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Vencidos en 3 Meses</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn4" runat="server" CssClass="ig_Button" CausesValidation="False">Stock</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 512px; height: 19px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="SubHead">
                    <br />
                    <asp:Label ID="lblResult" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlVencidos" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td>
                        <div style="width: 100%; height: 250px; overflow: scroll">
                            <asp:GridView ID="grdVencidos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="cComprobanteRecibo" HeaderText="COMPROBANTE LOTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreGenerico" HeaderText="NOMBRE GENÉRICO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreComercial" HeaderText="NOMBRE COMERCIAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="FECHA VENCIMIENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerSettings Position="TopAndBottom" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlNoVencidos" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td>
                        <div style="width: 100%; height: 250px; overflow: scroll">
                            <asp:GridView ID="grdNoVencidos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="cComprobanteRecibo" HeaderText="COMPROBANTE LOTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                    <asp:BoundField DataField="cNombreGenerico" HeaderText="NOMBRE GENÉRICO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                    <asp:BoundField DataField="cNombreComercial" HeaderText="NOMBRE COMERCIAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                    <asp:TemplateField HeaderText="FECHA INGRESO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                    <asp:TemplateField HeaderText="FECHA VENCIMIENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerSettings Position="TopAndBottom" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlVencidosMeses" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td>
                        <div style="width: 100%; height: 250px; overflow: scroll">
                            <asp:GridView ID="grdMeses" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="cComprobanteRecibo" HeaderText="COMPROBANTE LOTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreGenerico" HeaderText="NOMBRE GENÉRICO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreComercial" HeaderText="NOMBRE COMERCIAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="FECHA VENCIMIENTO"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerSettings Position="TopAndBottom" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlStockMinimo" runat="server">
            <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                <tr>
                    <td>
                        <div style="width: 100%; height: 250px; overflow: scroll">
                            <asp:GridView ID="grdStockMinimo" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="nCodProducto" HeaderText="ID PRODUCTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreGenerico" HeaderText="NOMBRE GENÉRICO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cNombreComercial" HeaderText="NOMBRE COMERCIAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="nStockActualEnvase" HeaderText="STOCK ACTUAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="nStockMinimo" HeaderText="STOCK MÍNIMO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerSettings Position="TopAndBottom" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar Reporte a Excel</asp:LinkButton>
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
