<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteRepFichas.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuiteRepFichas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="CuentaCliente.ascx" TagName="CuentaCliente" TagPrefix="uc1" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
	<ContentTemplate>
		<table style="width: 512px; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
			<tr>
				<td class="SubHead">
					<asp:Label ID="lblResult" runat="server" ForeColor="#CC3300"></asp:Label>
				</td>
			</tr>
		</table>
		<br />
		<asp:Panel ID="pnlClienteExtracto" runat="server">
			<fieldset id="panelbusqueda" runat="server" style="width: 100%">
				<legend>Datos de búsqueda:</legend>
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plClienteExtracto" runat="server" ControlName="txtClienteExtracto"
								Suffix=":" Text="Cliente" HelpText="Elija un cliente para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<uc1:CuentaCliente ID="CuentaCliente1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicial" runat="server" ControlName="txtFechainicial" Suffix=":"
								Text="Desde" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicial" runat="server" EditMode="CalendarOnly"
							DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>							
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechainicial"
								Display="None" ErrorMessage="Ingrese la fecha de inicio de búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator13">
							</cc1:ValidatorCalloutExtender>
							<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechafinal"
								ControlToValidate="txtFechainicial" ErrorMessage="La fecha inicial de búsqueda debe ser menor a la fecha final de búsqueda"
								Operator="LessThan" Type="Date" Display="None"></asp:CompareValidator>
							<cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
								Enabled="True" TargetControlID="CompareValidator1">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechafinal" runat="server" ControlName="txtFechafinal" Suffix=":"
								Text="Hasta" HelpText="Fecha final para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechafinal" runat="server" EditMode="CalendarOnly"
							DisplayModeFormat="d" Culture="es-BO">
							</ig:WebDatePicker>									
							<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechafinal"
								Display="None" ErrorMessage="Ingrese la fecha final para la búsqueda" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator14">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdSearchCuentaCliente" runat="server" CssClass="CommandButton" 
								Text="Buscar" style="width: 61px" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelCuentaCliente" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageCuentaCliente" runat="server"></asp:Label>
							<br />
							<div style="width: 100%; height: 450px; overflow: scroll">
								<asp:GridView ID="grdFichaCuenta" runat="server" AutoGenerateColumns="False" Width="100%"
									CssClass="Normal" BackColor="White" BorderColor="#3366CC" 
									BorderStyle="None" BorderWidth="1px" CellPadding="4">
									<Columns>
										<asp:BoundField DataField="nCodCliente" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="cliente" HeaderText="CLIENTE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="numero" HeaderText="FACTURA No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:TemplateField HeaderText="FECHA EMISION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:TemplateField HeaderText="FECHA VENCIMIENTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="debe" HeaderText="DEBE" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="haber" HeaderText="HABER" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:TemplateField HeaderText="SALDO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
		</asp:Panel>
		<p>
			<asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar Reporte a Excel</asp:LinkButton>
		</p>
		<p>
			<asp:LinkButton ID="lbtnExportarPDF" runat="server">Exportar Reporte a PDF</asp:LinkButton>
		</p>
	</ContentTemplate>
	<Triggers>
		<asp:PostBackTrigger ControlID="lbtnExportarExcel" />
		<asp:PostBackTrigger ControlID="lbtnExportarPDF" />
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
