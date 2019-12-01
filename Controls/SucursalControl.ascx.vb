Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class SucursalControl
        Inherits EjSuiteModuleBase

        Public Sub CargarSucursal()
            Dim ds As New DataSet
            ds = SPs.VerDatosSucursal(Me.txtSucursal.Text).GetDataSet()
            lblResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdSucursal.DataSource = ds.Tables(0).DefaultView
            grdSucursal.DataKeyNames = New String() {"nCodSucursal"}
            grdSucursal.DataBind()
            Me.txtSucursal.Text = Me.txtSucursal.Text.Replace(",", "")
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                txtSucursal.Text = ""
                Const friendlyName As String = "EjSuite"
                Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=Vendedores"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Vendedores", "EjSuiteSub")
                hypSucursal.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelar.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscar.Click
            CargarSucursal()
        End Sub

        Protected Sub grdEmpresas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSucursal.RowCommand
            Select Case e.CommandName.ToLower()
                Case "sucursalselect"
                    Dim mye As New SucursalSelectedEventArgs
                    mye.SelectedSucursal = CInt(e.CommandArgument)
                    RaiseEvent SucursalSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypSucursal As New LinkButton() With {.CommandName = "SucursalSelect", .CssClass = "CommandButton", .ValidationGroup = "SucursalSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypSucursal)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim nIndice As Integer = e.Row.RowIndex
                    Dim nCodSucursal As String = grdSucursal.DataKeys(nIndice).Value.ToString()
                    Dim objSucursal As Sucursal = Sucursal.FetchByID(nCodSucursal)
                    Dim hypSucursal As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypSucursal.Text = objSucursal.CZona
                    hypSucursal.CommandArgument = objSucursal.NCodSucursal.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event SucursalSelected(ByVal sender As Object, ByVal e As SucursalSelectedEventArgs)

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub
    End Class
    Public Class SucursalSelectedEventArgs
        Inherits EventArgs

        Private _selectedsucursal As System.Nullable(Of Integer)
        Public Property SelectedSucursal() As System.Nullable(Of Integer)
            Get
                Return _selectedsucursal
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _selectedsucursal = value
            End Set
        End Property
    End Class
End Namespace
