Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class ProveedorControl
        Inherits EjSuiteModuleBase

        Public Sub BuscarProveedor()
            Dim ds As New DataSet
            ds = SPs.VerDatosProveedor(Me.txtBusqueda.Text.Trim()).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdProveedores.DataSource = ds.Tables(0).DefaultView
            grdProveedores.DataKeyNames = New String() {"nCodProveedor"}
            grdProveedores.DataBind()
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                txtBusqueda.Text = ""
                Const friendlyName As String = "EjSuite"
                Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
                Dim mc As New DotNetNuke.Entities.Modules.ModuleController
                Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
                Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
                Dim param(2) As String
                param(0) = "mid=" & modID
                param(1) = "EjSuiteSubControl=proveedor"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Proveedor", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarProveedor()
        End Sub

        Protected Sub grdProveedores_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProveedores.RowCommand
            Select Case e.CommandName.ToLower
                Case "proveedorselect"
                    Dim mye As New ProveedorSelectedEventArgs
                    mye.SelectedProveedor = CInt(e.CommandArgument)
                    RaiseEvent ProveedorSelected(Me, mye)
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProveedores.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypProveedor As New LinkButton() With {.CommandName = "ProveedorSelect", .CssClass = "CommandButton", .ValidationGroup = "ProveedorSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypProveedor)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProveedores.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow

                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdProveedores.DataKeys(indice).Value.ToString

                    Dim objProveedor As New Proveedor(Proveedor.Columns.NCodProveedor, id)
                    Dim hypProveedor As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypProveedor.Text = objProveedor.CNombre
                    hypProveedor.CommandArgument = objProveedor.NCodProveedor.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event ProveedorSelected(ByVal sender As Object, ByVal e As ProveedorSelectedEventArgs)

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub
    End Class
    Public Class ProveedorSelectedEventArgs
        Inherits EventArgs

        Private _selectedproveedor As System.Nullable(Of Integer)
        Public Property SelectedProveedor() As System.Nullable(Of Integer)
            Get
                Return _selectedproveedor
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _selectedproveedor = value
            End Set
        End Property
    End Class
End Namespace
