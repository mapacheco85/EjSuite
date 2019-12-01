<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteRepSucursal.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteRepSucursal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc1" %>
<%@ Register Src="SucursalControlSearch.ascx" TagName="SucursalControlSearch" TagPrefix="uc2" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px; border-spacing: 5px;">
            <tr>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Reporte Mensual</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Consolidado Global</asp:LinkButton>
                </td>
                <td style="text-align: center;">
                    <asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Consolidado Productos</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table style="width: 100%; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
            <tr>
                <td class="SubHead">&nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlBusqueda1" runat="server">
            <fieldset id="panelbusRepS" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicialRepSucursal" runat="server" ControlName="txtFechainicialRepSucursal"
                                Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicialRepSucursal" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicialRepSucursal"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechafinalRepSucursal"
                                ControlToValidate="txtFechainicialRepSucursal" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                Enabled="True" TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalRepSucursal" runat="server" ControlName="txtFechafinalRepSucursal"
                                Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalRepSucursal" runat="server" EditMode="CalendarOnly"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinalRepSucursal"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdSearchRepSucursal" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="cmdCancelRepSucursal" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblMessageRepSucursal" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 300px; overflow: scroll">
                                <asp:GridView ID="grdRepSucursal" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ccliente" HeaderText="Cliente" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Mes" HeaderText="Mes" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="año" HeaderText="Año" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="total" HeaderText="Monto" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
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
        </asp:Panel>
        <asp:Panel ID="pnlBusqueda2" runat="server">
            <fieldset id="panelbusRepC" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicialRepConsolidado" runat="server" ControlName="txtFechainicialRepConsolidado"
                                Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicialRepConsolidado" runat="server"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechainicialRepConsolidado"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFechafinalRepConsolidado"
                                ControlToValidate="txtFechainicialRepConsolidado" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalRepConsolidado" runat="server" ControlName="txtFechafinalRepConsolidado"
                                Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalRepConsolidado" runat="server"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechafinalRepConsolidado"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnCancel" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblRes" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 300px; overflow: scroll">
                                <asp:GridView ID="grdConsolidados" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ccliente" HeaderText="Cliente" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="total" HeaderText="Monto" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
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
        </asp:Panel>
        <asp:Panel ID="pnlBusqueda3" runat="server">
            <fieldset id="panelbusRepP" runat="server" style="width: 100%">
                <table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechainicialRepProducto" runat="server" ControlName="txtFechainicialRepProducto"
                                Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechainicialRepProducto" runat="server"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechainicialRepProducto"
                                Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator13">
                            </cc1:ValidatorCalloutExtender>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtFechafinalRepProducto"
                                ControlToValidate="txtFechainicialRepProducto" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
                                Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                TargetControlID="CompareValidator1">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <dnn:label ID="plFechafinalRepProducto" runat="server" ControlName="txtFechafinalRepProducto"
                                Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
                        </td>
                        <td style="vertical-align: top;">
                            <ig:WebDatePicker ID="txtFechafinalRepProducto" runat="server"
                                DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
                            </ig:WebDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechafinalRepProducto"
                                Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                TargetControlID="RequiredFieldValidator14">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnBuscar1" runat="server" CssClass="CommandButton" Text="Buscar" />
                        </td>
                        <td style="width: 120px; vertical-align: top;" class="SubHead">
                            <asp:Button ID="btnCancelar1" runat="server" CssClass="CommandButton" Text="Cancelar"
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Label ID="lblBusqueda" runat="server"></asp:Label>
                            <br />
                            <div style="width: auto; height: 300px; overflow: scroll">
                                <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
                                    ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="proveedor" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="total" HeaderText="Monto" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
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
        </asp:Panel>
        <br />
        <asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar Reporte a Excel</asp:LinkButton>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lbtnExportarExcel" />
    </Triggers>
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
