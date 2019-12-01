<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteReporteKardex.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuiteReporteKardex" %>
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
		<br />
		<asp:Panel ID="pnlReporteKardex" runat="server">
			<fieldset id="panelbusqueda" runat="server" style="width: 100%">
				<legend><b>Datos de búsqueda:</b></legend>
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechainicial" runat="server" ControlName="txtFechainicial" Suffix=":"
								Text="Desde" HelpText="Fecha de inicio para la búsqueda" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechainicial" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO">
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
							<ig:WebDatePicker ID="txtFechafinal" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO">
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
							<asp:Button ID="cmdSearchReporteKardex" runat="server" CssClass="CommandButton" Text="Buscar" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdCancelReporteKardex" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<br />
							<asp:Label ID="lblMessageReporteKardex" runat="server" Style="font-weight: 700"></asp:Label>
							<br />
							<br />
							<div style="width: 100%; height: 450px; overflow: scroll">
								<asp:GridView ID="grdReporteKardex" runat="server" AutoGenerateColumns="False" Width="100%"
									CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
									BorderWidth="1px" CellPadding="4">
									<Columns>
										<asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="nCodProducto" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="detalles" HeaderText="PRODUCTO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:TemplateField HeaderText="FECHA" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="observacion" HeaderText="OBSERVACION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="preciocompra" HeaderText="PRECIO UNITARIO" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="stockanteriorenvase" HeaderText="STOCK ANTERIOR" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="stockactualenvase" HeaderText="STOCK ACTUAL" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="glosa" HeaderText="GLOSA" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
			<p>
				<asp:LinkButton ID="lbtnExportarExcel" runat="server">Exportar Reporte a Excel</asp:LinkButton>
			</p>
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:PostBackTrigger ControlID="lbtnExportarExcel" />
	</Triggers>
</asp:UpdatePanel>
<%--<asp:LinkButton ID="lbtnExportarPDF" runat="server">Exportar Reporte a PDF</asp:LinkButton>--%>
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
