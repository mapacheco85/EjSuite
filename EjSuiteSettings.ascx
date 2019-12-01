<%@ Control Language="vb" AutoEventWireup="false" Inherits="EjSuite.Modules.EjSuite.EjSuiteSettings"
    CodeBehind="EjSuiteSettings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table style="border-spacing: 0px; padding: 2px; border: 0px;" summary="EjSuite Ajustes">
    <tr>
        <td class="SubHead"  style="width: 150px;">
            <dnn:label id="lblTemplate" runat="server"
                controlname="txtTemplate" suffix=":">
            </dnn:label></td>
        <td style="vertical-align: bottom;">
            <asp:TextBox ID="txtTemplate" CssClass="NormalTextBox" Width="390" Columns="30"
                TextMode="MultiLine" Rows="10" MaxLength="2000" runat="server" />
        </td>
    </tr>
</table>
