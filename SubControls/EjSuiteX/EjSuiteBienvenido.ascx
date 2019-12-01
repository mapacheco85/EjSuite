<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EjSuiteBienvenido.ascx.vb"
    Inherits="EjSuite.Modules.EjSuite.EjSuiteBienvenido" %>

<asp:UpdatePanel ID="upPanel" runat="server" RenderMode="Inline" UpdateMode="Conditional">
    <ContentTemplate>
        <p style="text-align: center; vertical-align: middle;">
            <b>Bienvenido a  EJSUITE v2.10
                <br />
                Derechos reservados ®2018</b>
        </p>
        <p style="text-align: center; vertical-align: middle;">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="../../Images/ejsuiteff.jpg" />
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
