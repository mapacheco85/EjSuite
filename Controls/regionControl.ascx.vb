Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class regionControl
        Inherits EjSuiteModuleBase

        Public Sub CargarEmpresas()
            Dim ds As New DataSet
            ds = SPs.VerDatosRegion(Me.txtBusquedaR.Text).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdRegion.DataSource = ds.Tables(0).DefaultView
            grdRegion.DataKeyNames = New String() {"nCodRegion"}
            grdRegion.DataBind()
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                txtBusquedaR.Text = ""
                Const friendlyName As String = "EjSuite"
                Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=Sucursal"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Vendedores", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelR.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            CargarEmpresas()
        End Sub

        Protected Sub grdEmpresas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdRegion.RowCommand
            Select Case e.CommandName.ToLower
                Case "regionselect"
                    Dim mye As New RegionSelectedEventArgs() With {.SelectedRegion = CInt(e.CommandArgument)}
                    RaiseEvent RegionSelected(Me, mye)
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRegion.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypRegion As New LinkButton() With {.CommandName = "RegionSelect", .CssClass = "CommandButton", .ValidationGroup = "RegionSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypRegion)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRegion.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim objRegion As Region = CType(e.Row.DataItem, Region)
                    Dim hypRegion As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypRegion.Text = objRegion.CLugar
                    hypRegion.CommandArgument = objRegion.NCodRegion.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event RegionSelected(ByVal sender As Object, ByVal e As RegionSelectedEventArgs)

        Protected Sub lbnElegirR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegirR.Click
            Me.ModalPopupExtender1.Show()
        End Sub
    End Class
    Public Class RegionSelectedEventArgs
        Inherits EventArgs

        Private _selectedregion As System.Nullable(Of Integer)
        Public Property SelectedRegion() As System.Nullable(Of Integer)
            Get
                Return _selectedregion
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _selectedregion = value
            End Set
        End Property
    End Class
End Namespace