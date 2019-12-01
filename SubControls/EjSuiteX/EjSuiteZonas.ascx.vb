Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite

    Public Class EjSuiteZonas
        Inherits EjSuiteModuleBase

        Private Sub CargarZona()
            Dim q As New Query(Zona.Schema)
            If Trim(txtBuscarZona.Text) <> "" Then
                q.AddWhere(Zona.Columns.CDescripcion, Comparison.Like, "%" & txtBuscarZona.Text.Trim & "%")
            End If
            q.ORDER_BY(Zona.Columns.CDescripcion)
            Dim lst As New ZonaCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdZona.DataSource = lst
            grdZona.DataKeyNames() = New String() {Zona.Columns.NCodUnidad}
            grdZona.DataBind()
            lblMessageZona.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            panelbusCli.Visible = True
        End Sub


        Private Sub inicializar()
            txtDescripcion.Text = ""
            txtDescripcion1.Text = ""
            txtBuscarZona.Text = ""
            lblMessageZona.Text = ""
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarZona.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.btnBuscarZona.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoZona.Visible = False
                pnlBusquedaZona.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsertZona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertZona.Click
            If Page.IsValid Then
                Dim q As SqlQuery = New [Select]("nCodUnidad"). _
                    From(Zona.Schema). _
                    Where(Zona.Columns.CDescripcion).IsEqualTo(txtDescripcion.Text)

                Dim ds As DataSet
                ds = q.ExecuteDataSet
                If ds.Tables(0).Rows.Count > 0 Then
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Zona existente!")
                Else
                    Dim objNewZona As New Zona()
                    objNewZona.CDescripcion = txtDescripcion.Text
                    objNewZona.Save()
                    pnlBusquedaZona.Visible = False
                    pnlNuevoZona.Visible = False
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                End If
            End If
        End Sub

        Protected Sub cmdCancelZona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelZona.Click
            txtDescripcion.Text = ""
            pnlBusquedaZona.Visible = False
            pnlNuevoZona.Visible = False
        End Sub

        Protected Sub btnBuscarZona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarZona.Click
            CargarZona()
        End Sub

        Protected Sub grdZona_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdZona.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdZona.PageIndex = indice
            CargarZona()
        End Sub

        Protected Sub grdZona_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdZona.SelectedIndexChanged
            If grdZona.SelectedIndex > -1 Then
                Dim indice As Integer = grdZona.SelectedIndex
                Dim id As String = CType(grdZona.DataKeys(indice).Value, String)
                ViewState("cid") = id
                Dim objZona As New Zona(id)
                txtDescripcion1.Text = objZona.CDescripcion
                txtBuscarZona.Text = ""
                panelbusCli.Visible = False
                panelviewCli.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateZona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateZona.Click
            If ViewState("cid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As String = CType(ViewState("cid"), String)
                Dim objZona As New Zona(id)
                objZona.CDescripcion = txtDescripcion1.Text
                objZona.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaZona.Visible = False
                pnlNuevoZona.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteZona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteZona.Click
            Try
                If ViewState("cid") IsNot Nothing Then
                    Dim id As String = CType(ViewState("cid"), String)
                    Zona.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaZona.Visible = False
                    pnlNuevoZona.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaZona.Visible = False
                pnlNuevoZona.Visible = False
            End Try
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoZona.Visible = True
            pnlBusquedaZona.Visible = False
            grdZona.DataSource = Nothing
            grdZona.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoZona.Visible = False
            pnlBusquedaZona.Visible = True
            panelbusCli.Visible = True
            panelviewCli.Visible = False
            grdZona.DataSource = Nothing
            grdZona.DataBind()
        End Sub
    End Class
End Namespace
