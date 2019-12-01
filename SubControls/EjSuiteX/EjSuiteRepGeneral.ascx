<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteRepGeneral.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuiteRepGeneral" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
	<ContentTemplate>
		<table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
			<tr>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Ventas</asp:LinkButton>
				</td>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Productos</asp:LinkButton>
				</td>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Meses</asp:LinkButton>
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
		<asp:Panel ID="pnlVentasRepGeneral" runat="server">
			<fieldset id="panelbusVentas" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialVentasRepGeneral" runat="server" ControlName="txtFechainicialVentasRepGeneral"
								Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialVentasRepGeneral" runat="server" EditMode="CalendarOnly"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicialVentasRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator13">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechafinalVentasRepGeneral"
								ControlToValidate="txtFechainicialVentasRepGeneral" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
								Enabled="True" TargetControlID="CompareValidator1">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalVentasRepGeneral" runat="server" ControlName="txtFechafinalVentasRepGeneral"
								Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinalVentasRepGeneral" runat="server" EditMode="CalendarOnly"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinalVentasRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator14">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchVentas" runat="server" CssClass="CommandButton" Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelVentas" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageVentas" runat="server"></asp:Label>
							<br />
							<asp:GridView ID="grdVentas" runat="server" AutoGenerateColumns="False" CssClass="Normal"
								BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
								CellPadding="4" Width="100%">
								<Columns>
									<asp:BoundField DataField="EMPLEADO" HeaderText="Empleado" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
									<asp:BoundField DataField="PRODUCTO" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="MONTO" HeaderText="Monto" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
						</td>
					</tr>
				</table>
			</fieldset>
		</asp:Panel>
		<asp:Panel ID="pnlProductosRepGeneral" runat="server">
			<fieldset id="pnlbusProductos" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialProductosRepGeneral" runat="server" ControlName="txtFechainicialProductosRepGeneral"
								Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialProductosRepGeneral" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechainicialProductosRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator1">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFechafinalProductosRepGeneral"
								ControlToValidate="txtFechainicialProductosRepGeneral" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
								TargetControlID="CompareValidator2">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalProductosRepGeneral" runat="server" ControlName="txtFechafinalProductosRepGeneral"
								Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinalProductosRepGeneral" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechafinalProductosRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator2">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchProductos" runat="server" CssClass="CommandButton" Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelProductos" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageProductos" runat="server"></asp:Label>
							<br />
							<asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
								BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
								CellPadding="4" Width="100%">
								<Columns>
									<asp:BoundField DataField="cCLIENTE" HeaderText="Cliente" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="PRODUCTO" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="MONTO" HeaderText="Monto" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
						</td>
					</tr>
				</table>
			</fieldset>
		</asp:Panel>
		<asp:Panel ID="pnlMesesRepGeneral" runat="server">
			<fieldset id="pnlbusMeses" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plTotalMesesRepGeneral" runat="server" Suffix=":" Text="Reporte por"
								HelpText="Elija una opción para el reporte" />
						</td>
						<td style="vertical-align: top;">
							<asp:DropDownList ID="ddlTotalMesesRepGeneral" runat="server">
								<asp:ListItem>Producto</asp:ListItem>
								<asp:ListItem>Sucursal</asp:ListItem>
								<asp:ListItem>Empleado</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialMesesRepGeneral" runat="server" ControlName="txtFechainicialMesesRepGeneral"
								Suffix=":" Text="Fecha inicial" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialMesesRepGeneral" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechainicialMesesRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator3">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtFechafinalMesesRepGeneral"
								ControlToValidate="txtFechainicialMesesRepGeneral" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
								TargetControlID="CompareValidator3">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalMesesRepGeneral" runat="server" ControlName="txtFechafinalMesesRepGeneral"
								Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinalMesesRepGeneral" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechafinalMesesRepGeneral"
								Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator4">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchMeses" runat="server" CssClass="CommandButton" Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelMeses" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageMeses" runat="server"></asp:Label>
							<br />
							<asp:GridView ID="grdMesesProd" runat="server" AutoGenerateColumns="False" CssClass="Normal"
								BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
								CellPadding="4" Width="100%">
								<Columns>
									<asp:BoundField DataField="mes" HeaderText="Mes" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="gestion" HeaderText="Año" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="TOTAL" DataFormatString="{0:F}" HeaderText="Monto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
							<asp:GridView ID="grdMesesSuc" runat="server" AutoGenerateColumns="False" CssClass="Normal"
								BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
								CellPadding="4" Width="100%">
								<Columns>
									<asp:BoundField DataField="mes" HeaderText="Mes" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="anio" HeaderText="Año" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="nCodSucursal" HeaderText="Sucursal" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:TemplateField HeaderText="Total Bs."  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
							<asp:GridView ID="grdMesesEmp" runat="server" AutoGenerateColumns="False" CssClass="Normal"
								BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
								CellPadding="4" Width="100%">
								<Columns>
									<asp:BoundField DataField="mes" HeaderText="Mes" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="anio" HeaderText="Año" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="nombres" HeaderText="Empleado" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
									<asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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