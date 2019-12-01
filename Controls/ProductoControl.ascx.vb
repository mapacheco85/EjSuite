Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class ProductoControl
        Inherits EjSuiteModuleBase

        Public Sub BuscarProducto()
            Dim ds As New DataSet
            ds = SPs.VerDatosProducto(txtBusqueda.Text.Trim()).GetDataSet()

            lblSearchResults.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            grdProductos.DataSource = ds.Tables(0).DefaultView
            grdProductos.DataKeyNames() = New String() {"nCodProducto"}
            grdProductos.DataBind()
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
                BuscarProducto()
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarProducto()
        End Sub

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdProductos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProductos.RowCommand
            Select Case e.CommandName.ToLower()
                Case "productoselect"
                    Dim mye As New ProductoSelectedEventArgs
                    mye.SelectedProducto = e.CommandArgument.ToString()
                    RaiseEvent ProductoSelected(Me, mye)
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypProducto As New LinkButton() With {.CommandName = "ProductoSelect", .CssClass = "CommandButton", .ValidationGroup = "ProductoSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypProducto)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProductos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdProductos.DataKeys(indice).Value.ToString

                    Dim objProducto As New Producto(id)
                    Dim hypProducto As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypProducto.Text = objProducto.NCodProducto
                    hypProducto.CommandArgument = objProducto.NCodProducto
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event ProductoSelected(ByVal sender As Object, ByVal e As ProductoSelectedEventArgs)

    End Class

    Public Class ProductoSelectedEventArgs
        Inherits EventArgs

        Private _selectedproducto As String
        Public Property SelectedProducto() As String
            Get
                Return _selectedproducto
            End Get
            Set(ByVal value As String)
                _selectedproducto = value
            End Set
        End Property
    End Class

End Namespace