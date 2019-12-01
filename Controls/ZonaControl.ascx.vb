Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite

    Public Class ZonaControl
        Inherits EjSuiteModuleBase

        Public Sub CargarZona()
            Dim ds As New DataSet
            ds = SPs.VerZonas(Me.txtBusquedaS.Text.Trim()).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdZona.DataSource = ds.Tables(0).DefaultView
            grdZona.DataKeyNames = New String() {"nCodUnidad"}
            grdZona.DataBind()
            Me.txtBusquedaS.Text = Me.txtBusquedaS.Text.Replace(",", "")
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                txtBusquedaS.Text = ""
                Const friendlyName As String = "EjSuite"
                Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=Zonas"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                hypAdminZona.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelS.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            CargarZona()
        End Sub

        Private Sub grdZona_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdZona.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdZona.PageIndex = indice
            CargarZona()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdEmpresas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdZona.RowCommand
            Select Case e.CommandName.ToLower()
                Case "zonaselect"
                    Dim mye As New ZonaSelectedEventArgs() With {.SelectedZona = CInt(e.CommandArgument)}
                    RaiseEvent ZonaSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdZona.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypZona As New LinkButton() With {.CommandName = "ZonaSelect", .CssClass = "CommandButton", .ValidationGroup = "ZonaSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypZona)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdZona.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdZona.DataKeys(indice).Value.ToString

                    Dim objZona As New Zona(Zona.Columns.NCodUnidad, id)
                    Dim hypZona As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypZona.Text = objZona.CDescripcion
                    hypZona.CommandArgument = objZona.NCodUnidad.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event ZonaSelected(ByVal sender As Object, ByVal e As ZonaSelectedEventArgs)

        Private Sub lbnElegirS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbnElegirS.Click
            Me.ModalPopupExtender1.Show()
        End Sub
    End Class

    Public Class ZonaSelectedEventArgs
        Inherits EventArgs

        Private _selectedZona As System.Nullable(Of Integer)
        Public Property SelectedZona() As System.Nullable(Of Integer)
            Get
                Return _selectedZona
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _selectedZona = value
            End Set
        End Property
    End Class
End Namespace
