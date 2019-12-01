<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuitePagosCheque.ascx.vb"
	Inherits="EjSuite.Modules.EjSuite.EjSuitePagosCheque" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/Controls/LabelControl.ascx" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="Flan" %>
<%@ Register Src="VendedorControlSearch.ascx" TagName="VendedorControlSearch" TagPrefix="uc1" %>
<%@ Register Src="PagoCliente.ascx" TagName="PagoCliente" TagPrefix="uc2" %>
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
					<asp:LinkButton ID="lbtn1" runat="server" CssClass="ig_Button" CausesValidation="False">Nuevo Pago(Cheque)</asp:LinkButton>
				</td>
				<td style="text-align: center;">
					<asp:LinkButton ID="lbtn2" runat="server" CssClass="ig_Button" CausesValidation="False">Búsqueda de Pagos(Cheque)</asp:LinkButton>
				</td>
			</tr>
		</table>
		<br />
		<asp:Panel ID="pnlPagos" runat="server">
			<fieldset id="panelNuevoPago" runat="server" style="width: 100%">
				<legend>Pago con Cheque:</legend>
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plCobradorPago" runat="server" Suffix=":" Text="Cobrador" HelpText="Elija el cobrador" />
						</td>
						<td style="vertical-align: top;">
							<uc1:VendedorControlSearch ID="VendedorControlSearch1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechaPago" runat="server" ControlName="txtFechaPago" Suffix=":"
								Text="Fecha" HelpText="Fecha de pago" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechaPago" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaPago"
								Display="None" ErrorMessage="Ingrese la fecha de pago" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator3">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<uc2:PagoCliente ID="PagoCliente1" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plMontoPago" runat="server" ControlName="txtMontoPago" Suffix=":"
								Text="Monto" HelpText="Monto de pago" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtMontoPago" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMontoPago"
								Display="None" ErrorMessage="Ingrese un monto correcto" SetFocusOnError="True"
								ValidationExpression="^\$?\d+(\,(\d{2}))?$">
							</asp:RegularExpressionValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
								TargetControlID="RegularExpressionValidator1">
							</cc1:ValidatorCalloutExtender>
							<cc1:TextBoxWatermarkExtender ID="txtMontoPagoTextBoxWatermarkExtender2" runat="server"
								Enabled="True" TargetControlID="txtMontoPago" WatermarkCssClass="watermark" WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMontoPago"
								Display="None" ErrorMessage="Ingrese el monto de pago" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator4">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plNumChequePago" runat="server" ControlName="txtNumChequePago" Suffix=":"
								Text="Cheque No" HelpText="Número de cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtNumChequePago" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<cc1:TextBoxWatermarkExtender ID="txtNumChequePago_TextBoxWatermarkExtender13" runat="server"
								Enabled="True" TargetControlID="txtNumChequePago" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumChequePago"
								Display="None" ErrorMessage="Ingrese el Número de cheque" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator5">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plBancoChequePago" runat="server" ControlName="txtBancoChequePago"
								Suffix=":" Text="Banco" HelpText="Banco donde se cobrar&amp;acute; el cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtBancoChequePago" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<cc1:TextBoxWatermarkExtender ID="txtBancoChequePago_TextBoxWatermarkExtender13"
								runat="server" Enabled="True" TargetControlID="txtBancoChequePago" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBancoChequePago"
								Display="None" ErrorMessage="Ingrese el nombre del banco" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator1">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechaCobroChequePago" runat="server" ControlName="txtFechaCobroChequePago"
								Suffix=":" Text="Fecha Cheque" HelpText="Fecha de emisión del cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtFechaCobroChequePago" runat="server" CssClass="NormalTextBox"
								Width="150px"></asp:TextBox>
							<cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy"
								TargetControlID="txtFechaCobroChequePago" TodaysDateFormat="dd/MM/yyyy">
							</cc1:CalendarExtender>
							<cc1:TextBoxWatermarkExtender ID="txtFechaCobroChequePago_TextBoxWatermarkExtender13"
								runat="server" Enabled="True" TargetControlID="txtFechaCobroChequePago" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFechaCobroChequePago"
								Display="None" ErrorMessage="Ingrese la fecha de cobro del cheque" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator6">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdInsertPago" runat="server" CssClass="CommandButton" Text="Insertar" />
							<cc1:ConfirmButtonExtender ID="cmdInsert_ConfirmButtonExtender" runat="server" ConfirmText="Desea realizar esta operacion?"
								Enabled="True" TargetControlID="cmdInsertPago">
							</cc1:ConfirmButtonExtender>
						</td>
						<td style="vertical-align: top;">
							<asp:Button ID="cmdCancelPago" runat="server" CssClass="CommandButton" Text="Cancelar"
								CausesValidation="False" />
						</td>
					</tr>
				</table>
			</fieldset>
			<table style="width: 512px; height: 19px;border: 0px; padding: 0px; border-spacing: 0px;">
				<tr>
					<td class="SubHead">
						<asp:Label ID="lblMessagePagos" runat="server" ForeColor="#CC3300" Style="font-weight: 700"></asp:Label>
					</td>
				</tr>
			</table>
			<fieldset id="panelVerPagos" runat="server" style="width: 100%">
				<legend><b>Detalle de Pagos:</b></legend>
				<asp:Label ID="Label1" runat="server" Text="Cliente: " Font-Bold="True"></asp:Label>
				<asp:Label ID="lblClientePago" runat="server"></asp:Label>
				<br />
				<asp:Label ID="Label2" runat="server" Text="Factura No: " Font-Bold="True"></asp:Label>
				<asp:Label ID="lblFacturaPago" runat="server"></asp:Label>
				<div style="width: 100%; height: 500px; overflow: scroll">
					<asp:GridView ID="grdPagos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="FECHA DE PAGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
							<asp:BoundField DataField="monto" HeaderText="MONTO" DataFormatString="{0:F}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
							<asp:TemplateField HeaderText="COBRADOR" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
							<asp:TemplateField HeaderText="FORMA DE PAGO" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
						</Columns>
						<RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
						<HeaderStyle HorizontalAlign="Left" />
						<PagerSettings Position="TopAndBottom" />
					</asp:GridView>
				</div>
			</fieldset>
		</asp:Panel>
		<asp:Panel ID="pnlBusquedaPagos" runat="server">
			<fieldset id="panelbusPago" runat="server" style="width: 100%">
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plBuscarPagos" runat="server" ControlName="txtBuscarPagos" Suffix=":"
								Text="Cliente" HelpText="Ingrese el cliente" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:TextBox ID="txtBuscarPagos" runat="server" Width="367px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plDesde" runat="server" ControlName="txtInicio" Suffix=":" Text="Desde el"
								HelpText="Fecha inicio" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<ig:WebDatePicker ID="txtInicio" runat="server" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO" Nullable="False">
								<Buttons SpinButtonsDisplay="OnRight">
								</Buttons>
							</ig:WebDatePicker>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plHasta" runat="server" ControlName="txtFinal" Suffix=":" Text="Hasta el"
								HelpText="Fecha final" />
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<ig:WebDatePicker ID="txtFinal" runat="server" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO" Nullable="False">
								<Buttons SpinButtonsDisplay="OnRight">
								</Buttons>
							</ig:WebDatePicker>
						</td>
					</tr>
					<tr>
						<td>
							&nbsp;
						</td>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="btnBuscarPagos" runat="server" Text="Buscar" />
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:Label ID="lblMessageBusquedaPagos" runat="server"></asp:Label>
							<br />
							<div style="width: auto; height: 500px; overflow: scroll">
								<asp:GridView ID="grdBusquedaPagos" runat="server" AutoGenerateColumns="False" CssClass="Normal"
									Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
									CellPadding="4">
									<Columns>
										<asp:BoundField DataField="nCodCliente" HeaderText="CODIGO" />
										<asp:BoundField DataField="cliente" HeaderText="CLIENTE">
											<ItemStyle  />
										</asp:BoundField>
										<asp:BoundField DataField="numero" HeaderText="FACTURA No">
											<ItemStyle HorizontalAlign="Right" />
										</asp:BoundField>
										<asp:TemplateField HeaderText="FECHA DE PAGO">
											<ItemStyle HorizontalAlign="Center" />
										</asp:TemplateField>
										<asp:BoundField DataField="monto" HeaderText="ABONO" DataFormatString="{0:F}">
											<ItemStyle HorizontalAlign="Right" />
										</asp:BoundField>
										<asp:BoundField DataField="vendedor" HeaderText="COBRADOR">
											<ItemStyle Width="150px" />
										</asp:BoundField>
										<asp:BoundField DataField="RO" HeaderText="RO">
                                        <ItemStyle HorizontalAlign="Center" />
										</asp:BoundField>
										<asp:BoundField DataField="IC" HeaderText="IC">
                                        <ItemStyle HorizontalAlign="Center" />
										</asp:BoundField>
										<asp:CommandField SelectText="Editar" ShowSelectButton="True" />
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
							<p>
								<asp:LinkButton ID="lbtnXLS" runat="server">Exportar a Excel</asp:LinkButton>
							</p>
						</td>
					</tr>
				</table>
			</fieldset>
			<fieldset id="panelviewPago" runat="server" style="width: 100%">
				<legend><b>Pago al contado:</b></legend>
				<table style="width: 100%; border: 0px; padding: 0px; border-spacing: 0px;">
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plCobradorPago1" runat="server" Suffix=":" Text="Cobrador" HelpText="Elija el cobrador" />
						</td>
						<td style="vertical-align: top;">
							<uc1:VendedorControlSearch ID="VendedorControlSearch2" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechaPago1" runat="server" ControlName="txtFechaPago" Suffix=":"
								Text="Fecha" HelpText="Fecha de pago" />
						</td>
						<td style="vertical-align: top;">
							<ig:WebDatePicker ID="txtFechaPago1" runat="server" EditMode="CalendarOnly" DisplayModeFormat="d"
								DataMode="Text" Culture="es-BO">
							</ig:WebDatePicker>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaPago1"
								Display="None" ErrorMessage="Ingrese la fecha de pago" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator1">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:Label ID="Label4" runat="server" Text="CLIENTE: " Font-Bold="True"></asp:Label>
							<asp:Label ID="lblCliente" runat="server"></asp:Label>&nbsp;
							<asp:Label ID="Label3" runat="server" Text="   FACTURA No: " Font-Bold="True"></asp:Label>
							<asp:Label ID="lblNroFactura" runat="server"></asp:Label>&nbsp;
							<asp:Label ID="Label5" runat="server" Text="   SALDO: " Font-Bold="True"></asp:Label>
							<asp:Label ID="lblSaldo" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<uc2:PagoCliente ID="PagoCliente2" runat="server" />
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plMontoPago1" runat="server" ControlName="txtMontoPago1" Suffix=":"
								Text="Monto" HelpText="Monto de pago" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtMontoPago1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMontoPago1"
								Display="None" ErrorMessage="Ingrese un monto correcto" SetFocusOnError="True"
								ValidationExpression="^\$?\d+(\,(\d{2}))?$">
							</asp:RegularExpressionValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender77" runat="server" Enabled="True"
								TargetControlID="RegularExpressionValidator2">
							</cc1:ValidatorCalloutExtender>
							<cc1:TextBoxWatermarkExtender ID="txtMontoPago1TextBoxWatermarkExtender22" runat="server"
								Enabled="True" TargetControlID="txtMontoPago1" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMontoPago1"
								Display="None" ErrorMessage="Ingrese el monto de pago" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator2">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plNumChequePago1" runat="server" ControlName="txtNumChequePago1" Suffix=":"
								Text="Cheque No" HelpText="Número de cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtNumChequePago1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<cc1:TextBoxWatermarkExtender ID="txtNumChequePago1_TextBoxWatermarkExtender13" runat="server"
								Enabled="True" TargetControlID="txtNumChequePago1" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNumChequePago1"
								Display="None" ErrorMessage="Ingrese el Número de cheque" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender55" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator8">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plBancoChequePago1" runat="server" ControlName="txtBancoChequePago1"
								Suffix=":" Text="Banco" HelpText="Banco donde se cobrar&amp;acute; el cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtBancoChequePago1" runat="server" CssClass="NormalTextBox" Width="267px"></asp:TextBox>
							<cc1:TextBoxWatermarkExtender ID="txtBancoChequePago1_TextBoxWatermarkExtender13"
								runat="server" Enabled="True" TargetControlID="txtBancoChequePago1" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBancoChequePago1"
								Display="None" ErrorMessage="Ingrese el nombre del banco" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator9">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<dnn:label ID="plFechaCobroChequePago1" runat="server" ControlName="txtFechaCobroChequePago1"
								Suffix=":" Text="Fecha Cheque" HelpText="Fecha de emisión del cheque" />
						</td>
						<td style="vertical-align: top;">
							<asp:TextBox ID="txtFechaCobroChequePago1" runat="server" CssClass="NormalTextBox"
								Width="150px"></asp:TextBox>
							<cc1:CalendarExtender ID="CalendarExtender44" runat="server" Enabled="True" Format="dd/MM/yyyy"
								TargetControlID="txtFechaCobroChequePago1" TodaysDateFormat="dd/MM/yyyy">
							</cc1:CalendarExtender>
							<cc1:TextBoxWatermarkExtender ID="txtFechaCobroChequePago1_TextBoxWatermarkExtender13"
								runat="server" Enabled="True" TargetControlID="txtFechaCobroChequePago1" WatermarkCssClass="watermark"
								WatermarkText="*">
							</cc1:TextBoxWatermarkExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFechaCobroChequePago1"
								Display="None" ErrorMessage="Ingrese la fecha de cobro del cheque" SetFocusOnError="True"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender66" runat="server" Enabled="True"
								TargetControlID="RequiredFieldValidator10">
							</cc1:ValidatorCalloutExtender>
						</td>
					</tr>
					<tr>
						<td style="width: 120px; vertical-align: top;" class="SubHead">
							<asp:Button ID="cmdUpdatePago" runat="server" CssClass="CommandButton" Text="Modificar" />
							<cc1:ConfirmButtonExtender ID="cmdUpdate_ConfirmButtonExtender" runat="server" ConfirmText="Desea guardar los cambios efectuados?"
								Enabled="True" TargetControlID="cmdUpdatePago">
							</cc1:ConfirmButtonExtender>
						</td>
						<td style="vertical-align: top;">
							<asp:Button ID="cmdDeletePago" runat="server" CssClass="CommandButton" Text="Eliminar"
								CausesValidation="False" />
							<cc1:ConfirmButtonExtender ID="cmdDeletePago_ConfirmButtonExtender" runat="server"
								ConfirmText="Desea eliminar este pago?" Enabled="True" TargetControlID="cmdDeletePago">
							</cc1:ConfirmButtonExtender>
						</td>
					</tr>
				</table>
			</fieldset>
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:PostBackTrigger ControlID="lbtnXLS" />
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
