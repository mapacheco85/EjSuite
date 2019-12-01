<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteRepVentas.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuiteRepVentas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="ProductoControlSearch.ascx" TagName="ProductoControlSearch" TagPrefix="uc1" %>
<%@ Register Src="CuentaCliente.ascx" TagName="CuentaCliente" TagPrefix="uc2" %>
<%@ Register Src="GrupoterapeuticoControlSearch.ascx" TagName="GrupoterapeuticoControlSearch"
	TagPrefix="uc3" %>
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
					<asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Clientes</asp:LinkButton>
				</td>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Productos</asp:LinkButton>
				</td>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn3" runat="server" CssClass="ig_Button" CausesValidation="False">Grupo Ventas</asp:LinkButton>
				</td>
			</tr>
		</table>
		<br />
		<asp:Panel ID="pnlBusquedaClientes" runat="server">
			<fieldset id="panelbusCli" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="lblClienteRepVentas" runat="server" Suffix=":" Text="Cliente" HelpText="Elija un cliente" />
						</td>
						<td style="vertical-align: top;">
							<uc2:CuentaCliente ID="CuentaCliente1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialClientes" runat="server" ControlName="txtFechainicialClientes"
								Suffix=":" Text="Desde el" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialClientes" runat="server" EditMode="CalendarOnly"
								DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicialClientes"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator13">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechaFinalClientes"
								ControlToValidate="txtFechainicialClientes" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="CompareValidator121_ValidatorCalloutExtender" runat="server"
								Enabled="True" TargetControlID="CompareValidator1">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalClientes" runat="server" ControlName="txtFechafinalClientes"
								Suffix=":" Text="Hasta el" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinalClientes" runat="server" EditMode="CalendarOnly"
								DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinalClientes"
								Display="None" ErrorMessage="Ingrese la fecha final" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator14_ValidatorCalloutExtender"
								runat="server" Enabled="True" TargetControlID="RequiredFieldValidator14">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchClientes" runat="server" CssClass="CommandButton" Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelClientes" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageCli" runat="server"></asp:Label>
							<br />
							<div style="width: 100%; height: 250px; overflow: scroll">
								<asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" CssClass="Normal"
									ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
									BorderWidth="1px" CellPadding="4" Width="100%">
									<Columns>
										<asp:TemplateField HeaderText="No"></asp:TemplateField>
										<asp:BoundField DataField="nCodCliente" HeaderText="Cód." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="cCliente" HeaderText="Cliente" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="nNumero" HeaderText="Nº Factura" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="producto" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="nCantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:F}"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
		<asp:Panel ID="pnlBusquedaProductos" runat="server">
			<fieldset id="panelbusPro" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="lblProductos" runat="server" Suffix=":" Text="Producto" HelpText="Elija un producto" />
						</td>
						<td style="vertical-align: top;">
							<uc1:ProductoControlSearch ID="ProductoControlSearch1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialProducto" runat="server" ControlName="txtFechainicialProducto"
								Suffix=":" Text="Desde el" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialProducto" runat="server"
								DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechainicialProducto"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator1">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFechaFinalProducto"
								ControlToValidate="txtFechainicialProducto" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="CompareValidator11_ValidatorCalloutExtender" runat="server"
								Enabled="True" TargetControlID="CompareValidator2">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalProducto" runat="server" ControlName="txtFechafinalProducto"
								Suffix=":" Text="Hasta el" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechaFinalProducto" runat="server"
								DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>
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
							<div style="width: auto; height: 250px; overflow: scroll">
								<asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
									ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
									BorderWidth="1px" CellPadding="4" Width="100%">
									<Columns>
                                        <asp:TemplateField HeaderText="No"></asp:TemplateField>
										<asp:BoundField DataField="nCodProducto" HeaderText="Cod." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="detalles" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="nCantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
		<asp:Panel ID="pnlBusquedaGruposTeraupeticos" runat="server">
			<fieldset id="panelbusGru" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="lblGrupoTerapeutico" runat="server" Suffix=":" Text="Grupo Terapeútico"
								HelpText="Elija un grupo terapeútico" />
						</td>
						<td style="vertical-align: top;">
							<uc3:GrupoterapeuticoControlSearch ID="GrupoterapeuticoControlSearch1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicialGrupoTerapeutico" runat="server" ControlName="txtFechainicialGrupoTerapeutico"
								Suffix=":" Text="Desde el" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicialGrupoTerapeutico" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechainicialGrupoTerapeutico"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1211" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator3">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtFechaFinalGrupoTerapeutico"
								ControlToValidate="txtFechainicialGrupoTerapeutico" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
								Enabled="True" TargetControlID="CompareValidator3">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinalGrupoTerapeutico" runat="server" ControlName="txtFechafinalGrupoTerapeutico"
								Suffix=":" Text="Fecha final" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinalGrupoTerapeutico" runat="server"
								DisplayModeFormat="d" DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchGrupoTerapeutico" runat="server" CssClass="CommandButton"
								Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelGrupoTerapeutico" runat="server" CssClass="CommandButton"
								Text="Cancelar" CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageGrupoTerapeutico" runat="server"></asp:Label>
							<br />
							<div style="width: auto; height: 250px; overflow: scroll">
								<asp:GridView ID="grdGruposTerapeuticos" runat="server" AutoGenerateColumns="False"
									CssClass="Normal" ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
									BorderWidth="1px" CellPadding="4" Width="100%">
									<Columns>
										<asp:TemplateField HeaderText="No"></asp:TemplateField>
										<asp:BoundField DataField="cGrupoProducto" HeaderText="Grupo Ventas" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="nCodProducto" HeaderText="Cód." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="detalles" HeaderText="Producto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
		<p>
			<asp:LinkButton ID="cmdExportarE" runat="server" Text="Exportar Excel" CssClass="CommandButton"
				CausesValidation="False" Visible="False" />
		</p>
	    <%--<p>
            <asp:HyperLink ID="hlVentasMes" runat="server" Visible="false" Enabled="false"
                NavigateUrl="http://inetEjSuite/sitio/DesktopModules/EjSuite/SubControls/EjSuiteX/EjSuiteReporteVentasMes.aspx" 
                Target="_blank">Ventas Por Mes y Gestion</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="hlVentasNetas" runat="server" Visible="false" Enabled="false" 
                NavigateUrl="http://inetEjSuite/sitio/DesktopModules/EjSuite/SubControls/EjSuiteX/EjSuiteReporteVentasNetas.aspx" 
                Target="_blank">Ventas Netas Clientes</asp:HyperLink>
        </p>--%>
	</ContentTemplate>
	<Triggers>
		<asp:PostBackTrigger ControlID="cmdExportarE" />
	</Triggers>
</asp:UpdatePanel>
<%--<p>
	<asp:linkButton ID="cmdExportarPDF" runat="server" Text="Exportar PDF" 
		CssClass="CommandButton" CausesValidation="False" />
</p>--%>
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
