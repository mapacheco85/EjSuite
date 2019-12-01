Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class GrupoterapeuticoControl
        Inherits EjSuiteModuleBase


        Public Sub BuscarGrupoterapeutico()
            Dim ds As New DataSet
            ds = SPs.VerDatosGrupoTerapeutico(Me.txtBusqueda.Text).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdGruposTerapeuticos.DataSource = ds.Tables(0).DefaultView
            grdGruposTerapeuticos.DataKeyNames = New String() {"nCodGrupo"}
            grdGruposTerapeuticos.DataBind()
            Me.txtBusqueda.Text = Me.txtBusqueda.Text.Replace(",", "")
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
        End Sub


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                txtBusqueda.Text = ""
                Const friendlyName As String = "EjSuite"
                Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=productos"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Productos", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            'EliminarComillas()
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarGrupoterapeutico()
        End Sub

        Protected Sub grdGruposTerapeuticos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGruposTerapeuticos.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdGruposTerapeuticos.PageIndex = indice
            BuscarGrupoterapeutico()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdGruposTerapeuticos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdGruposTerapeuticos.RowCommand
            Select Case e.CommandName.ToLower
                Case "grupoterapeuticoselect"
                    Dim mye As New GrupoterapeuticoSelectedEventArgs() With {.SelectedGrupoterapeutico = e.CommandArgument.ToString()}

                    RaiseEvent GrupoterapeuticoSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGruposTerapeuticos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypGrupoterapeutico As New LinkButton() With {.CommandName = "grupoterapeuticoselect", .CssClass = "CommandButton", .ValidationGroup = "GrupoterapeuticoSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypGrupoterapeutico)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGruposTerapeuticos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdGruposTerapeuticos.DataKeys(indice).Value.ToString
                    Dim objGrupoVentas As New GrupoProducto(GrupoProducto.Columns.NCodGrupo, id)
                    Dim hypGrupoterapeutico As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypGrupoterapeutico.Text = objGrupoVentas.CGrupoProducto
                    hypGrupoterapeutico.CommandArgument = objGrupoVentas.NCodGrupo.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event GrupoterapeuticoSelected(ByVal sender As Object, ByVal e As GrupoterapeuticoSelectedEventArgs)

    End Class

    Public Class GrupoterapeuticoSelectedEventArgs
        Inherits EventArgs
        Public Sub New()
            
        End Sub
        Public Property SelectedGrupoterapeutico() As String
    End Class
End Namespace