<%@ Control Language="vb" Inherits="EjSuite.Modules.EjSuite.EjSuiteView"
    AutoEventWireup="false" Explicit="True" CodeBehind="EjSuiteView.ascx.vb" %>
<%@ Register Assembly="Infragistics4.Web.v13.1, Version=13.1.20131.1012, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
	Namespace="Infragistics.Web.UI.NavigationControls" TagPrefix="ig" %>
<nav>
    <table>
        <tr style="vertical-align: top; text-align: left;">
            <ig:WebDataMenu ID="webExplorador1" runat="server" Width="100%" 
                BorderStyle="Solid" BorderColor="Black"
                EnableViewState="false" ForeColor="Blue" ScrollingSpeed="Fast">
                <GroupSettings Orientation="Horizontal" ExpandDirection="Down" />
            </ig:WebDataMenu>
        </tr>
    </table>
</nav>

<table id="tblPrincipal" style="border: 0px; border-spacing: 2px; width: 100%; padding: 0px;">
    <tr>
        <td style="width: 100%; height: 100%; vertical-align: top; text-align: left;">
            <fieldset style="width: 100%;">
                <legend>
                    <asp:Label ID="lblPageDescriptionTitle" runat="server" CssClass="SubHead"
                        Font-Bold="True" Font-Overline="False" Font-Underline="True" Font-Size="Medium"></asp:Label>
                </legend>
                <table id="Table4" style="border: 0px; border-spacing: 2px; width: 100%; padding: 3px;">
                    <tr>
                        <td class="normal" style="width: 100%; vertical-align: top; text-align: left;">
                            <asp:Label ID="lblPageDescription" runat="server" CssClass="normal"
                                Font-Bold="True" Font-Italic="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; width: 100%;">
                            <asp:PlaceHolder ID="phSubControls" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
</table>
