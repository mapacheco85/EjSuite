Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class VendedorControl
        Inherits EjSuiteModuleBase

        Public Sub BuscarVendedor()
            Dim ds As New DataSet()
            ds = SPs.VerDatosEmpleado(Me.txtBusqueda.Text.Trim()).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)
            grdVendedores.DataSource = ds.Tables(0).DefaultView
            grdVendedores.DataKeyNames = New String() {"nCodEmpleado"}
            grdVendedores.DataBind()
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
                param(1) = "EjSuiteSubControl=visitadores"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarVendedor()
        End Sub

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdVendedores_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdVendedores.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdVendedores.PageIndex = indice
            BuscarVendedor()
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdVendedores_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdVendedores.RowCommand
            Select Case e.CommandName.ToLower
                Case "empleadoselect"
                    Dim mye As New EmpleadoSelectedEventArgs1() With {.SelectedEmpleado = CStr(e.CommandArgument)}
                    RaiseEvent EmpleadoSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdVendedores_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVendedores.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypEmpleado As New LinkButton() With {.CommandName = "empleadoSelect", .CssClass = "CommandButton", .ValidationGroup = "EmpleadoSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypEmpleado)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdVendedores_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVendedores.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdVendedores.DataKeys(indice).Value.ToString

                    Dim objEmpleado As New Empleado(Empleado.Columns.NCodEmpleado, id)
                    Dim hypEmpleado As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypEmpleado.Text = objEmpleado.NCodEmpleado
                    hypEmpleado.CommandArgument = objEmpleado.NCodEmpleado
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event EmpleadoSelected(ByVal sender As Object, ByVal e As EmpleadoSelectedEventArgs1)
    End Class

    Public Class EmpleadoSelectedEventArgs1
        Inherits EventArgs

        Private _selectedempleado As String
        Public Property SelectedEmpleado() As String
            Get
                Return _selectedempleado
            End Get
            Set(ByVal value As String)
                _selectedempleado = value
            End Set
        End Property
    End Class

End Namespace
