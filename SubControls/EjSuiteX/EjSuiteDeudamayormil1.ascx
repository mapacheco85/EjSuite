﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteDeudamayormil1.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuiteDeudamayormil1" %>
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
	<table style="background-color: rgba(204, 204, 204, 0.5); width: 100%; border: 0px; padding: 5px;  border-spacing: 5px;">
			<tr>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" 
						CausesValidation="False">Reporte Deuda Mayor a mil</asp:LinkButton>
				</td>				
			</tr>
		</table>	  
		<table style="width: 512px; height: 19px; border: 0px; padding: 0px; border-spacing: 0px;">
			<tr>
				<td class="SubHead">
					<asp:Label ID="lblResult" runat="server" ForeColor="#CC3300"></asp:Label>
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
								<asp:GridView ID="grdRepSucursal" runat="server" AutoGenerateColumns="False" CellPadding="4"
									CssClass="Normal" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
									BorderWidth="1px" ShowFooter="True" Visible="False" Width="100%">
									<Columns>
										<asp:BoundField DataField="Cliente" HeaderText="Cliente" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="Numero" HeaderText="No. Factura" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
										<asp:BoundField DataField="Emitida" HeaderText="Emitida" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
										<asp:BoundField DataField="Vence" HeaderText="Vencimiento" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
										<asp:BoundField DataField="Pagado" HeaderText="Pagado" DataFormatString="{0:F}" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
										<asp:BoundField DataField="Deuda" HeaderText="Deuda" DataFormatString="{0:F}" HeaderStyle-ForeColor="White"
											 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
									</Columns>
									<PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
									<RowStyle ForeColor="#003399" HorizontalAlign="Left" VerticalAlign="Top" 
										BackColor="White" />
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