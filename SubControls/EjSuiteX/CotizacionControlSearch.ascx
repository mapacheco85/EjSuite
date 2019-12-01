<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CotizacionControlSearch.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.CotizacionControlSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>

<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VentaControlSearch.ascx" TagName="VenControlSearch" TagPrefix="vcs" %>
<style type="text/css">
    .style2
    {
        width: 846px;
    }
    .style4
    {
        width: 23%;
    }
    .NormalTextBox
    {
    }
    .style6
    {
        width: 11%;
    }
</style>
<asp:Panel ID="pnlProducto" runat="server">
    <table style="width: 100%; height: 19px; margin-top: 0px; border: 0px; padding: 0px; border-spacing: 0px;">
        <tr>
            <td class="style2" style="width: 50%">
                Producto:<vcs:VenControlSearch ID="VentaControlSearch1" runat="server" />
                <br />
            </td>
            <td class="style4" style="width: 20%; vertical-align: top;">
                Cantidad:<br />
                <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="True" CssClass="NormalTextBox"
                    Width="58px">0</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCantidad"
                    ErrorMessage="Insertar la cantidad" ForeColor="#660033" 
                    ValidationExpression="\d{1,15}" Display="None"></asp:RegularExpressionValidator>
                <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender" 
                    runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1">
                </cc1:ValidatorCalloutExtender>
                <br />
                &nbsp;<asp:CheckBox ID="ckbSuelto" runat="server" AutoPostBack="True" 
                    Text="Suelto" Visible="False" />
            </td>
            <td class="style6" style="width: 20%; vertical-align: top;">
                Total<br />
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 10%; vertical-align: bottom;" class="SubHead">&nbsp;
                <asp:LinkButton ID="cmdInsertar" runat="server">Adicionar</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Label ID="lblError0" runat="server" style="font-weight: 700"></asp:Label>
<br />
<br />
<asp:UpdatePanel ID="pnlPedido" runat="server" Visible="False">
    <ContentTemplate>
        <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CellPadding="3"
            CssClass="Normal" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" Width="100%">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="prod" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="cant" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center"  />
                <asp:BoundField DataField="punit" HeaderText="Precio Unitario" ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center"  />
                <asp:TemplateField HeaderText="Suelto" ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSuelto" runat="server" Checked='<%# Bind("suelto") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="total" HeaderText="Totales"  ItemStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center" />
                <asp:CommandField DeleteText="Eliminar" SelectText="Editar" ShowDeleteButton="true" 
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            </Columns>
            <RowStyle ForeColor="#000066" HorizontalAlign="Left" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerSettings Position="TopAndBottom" />
        </asp:GridView>
        <br />
        <br />
        Total:&nbsp;&nbsp;
        <asp:Label ID="lbTotalCompra" runat="server" Text="0.00"></asp:Label>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
