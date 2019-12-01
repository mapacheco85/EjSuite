<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteComisiones.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteComisiones" %>
    <%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc4" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" 
                        CausesValidation="False">Comisiones</asp:LinkButton>
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
        <asp:Panel ID="pnlCalculoComisiones" runat="server">
            <fieldset id="panelCalculoComisiones" runat="server">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plVendedor" runat="server" Suffix=":" 
                                Text="Vendedor" HelpText="Elija un vendedor" />
                        </td>
                        <td style="vertical-align: top;">
                            <uc4:VendedorControlSearch ID="VendedorControlSearch1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plDesde" runat="server" ControlName="txtDesdeComision" Suffix=":"
                                Text="Desde" HelpText="Introduzca una fecha de inicio para el cálculo de la comisión" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtDesdeComision" runat="server" EditMode="CalendarOnly"
                            DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                runat="server" ControlToValidate="txtDesdeComision"
                                Display="None" ErrorMessage="Ingrese una fecha de inicio para el cálculo de la comisión"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plHasta" runat="server" ControlName="txtHastaComision" Suffix=":"
                                Text="Hasta" HelpText="Introduzca una fecha final para el cálculo de la comisión" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtHastaComision" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate="txtHastaComision"
                                Display="None" ErrorMessage="Ingrese una fecha final para el cálculo de la comisión"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator88_ValidatorCalloutExtender"
                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="SubHead">
                            <dnn:label ID="plComision" runat="server" ControlName="txtComision" 
                                Suffix=":" Text="Comisión Ventas"
                                HelpText="Introduzca un porcentaje de Comisión" />
                        </td>
                        <td style="vertical-align: top;">
                            <asp:TextBox ID="txtComision" runat="server" CssClass="NormalTextBox" Width="150px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender16" runat="server" Enabled="True"
                                TargetControlID="txtComision" WatermarkCssClass="watermark" WatermarkText="*">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtComision"
                                Display="None" ErrorMessage="Ingrese un porcentaje de comisión" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator3">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdInsert" runat="server" CssClass="CommandButton" Text="Calcular" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdCancel" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset id="panelViewVentasVendedor" runat="server" style="width: 100%">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <div style="width: auto; height: 100%; overflow: scroll">
                    <asp:GridView ID="grdVentasVendedor" runat="server" 
                        AutoGenerateColumns="False" CssClass="Normal"
                        ShowFooter="True" EmptyDataText="No se encontraron registros."
                        Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                        BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="nNumero" HeaderText="# Factura" 
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" 
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                            <asp:BoundField DataField="Detalles" HeaderText="Detalle" 
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                            <asp:BoundField DataField="nCantidad" HeaderText="Cantidad" 
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                            <asp:BoundField DataField="Total" HeaderText="P. Total" 
                                DataFormatString="{0:f}" ItemStyle-HorizontalAlign="Center" 
                                HeaderStyle-HorizontalAlign="Center"  />
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
            </fieldset>
        </asp:Panel>
        <p>
            Comision Ventas:
            <asp:Label ID="lblComision" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="cmdExportarE" runat="server" Text="Exportar Excel" CssClass="CommandButton"
                CausesValidation="False" />
        </p>
        <%--<div style="width: 100%; height: 200px; overflow: scroll">
            <asp:GridView ID="grdCobros" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                EmptyDataText="No se encontraron registros."
                Width="100%" ShowFooter="True" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="nNumero" HeaderText="# Factura" 
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                    <asp:BoundField DataField="Vendedor" HeaderText="Cobrador" 
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Total" HeaderText="Monto Cobrado" 
                        DataFormatString="{0:f}" ItemStyle-HorizontalAlign="Center" 
                        HeaderStyle-HorizontalAlign="Center" />
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
        <p>
            Comision Cobros:
            <asp:Label ID="lblCobros" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="cmdExportarE1" runat="server">Exportar a Excel</asp:LinkButton>
        </p>--%>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdExportarE" />
        <%--<asp:PostBackTrigger ControlID="cmdExportarE1" />--%>
    </Triggers>
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
