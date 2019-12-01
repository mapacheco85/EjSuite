Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class ClienteControl1
        Inherits EjSuiteModuleBase

        Public Sub BuscarCliente()
            Dim ds As New DataSet
            ds = SPs.VerDatosCliente(Me.txtBusqueda.Text.Trim()).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdClientes.DataSource = ds.Tables(0).DefaultView
            grdClientes.DataKeyNames = New String() {"nCodCliente"}
            grdClientes.DataBind()
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
                param(1) = "EjSuiteSubControl=Clientes"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Clientes", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdBuscarCliente1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarCliente1.Click
            BuscarCliente()
        End Sub

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdClientes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdClientes.RowCommand
            Select Case e.CommandName.ToLower()
                Case "clienteselect"
                    Dim mye As New ClienteSelectedEventArgs1
                    mye.SelectedCliente = CStr(e.CommandArgument)
                    RaiseEvent ClienteSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientes.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypCliente As New LinkButton() With {.CommandName = "ClienteSelect", .CssClass = "CommandButton", .ValidationGroup = "ClienteSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypCliente)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClientes.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdClientes.DataKeys(indice).Value.ToString

                    Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, id)
                    Dim hypCliente As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypCliente.Text = objCliente.NCodCliente
                    hypCliente.CommandArgument = objCliente.NCodCliente
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event ClienteSelected(ByVal sender As Object, ByVal e As ClienteSelectedEventArgs1)

    End Class

    Public Class ClienteSelectedEventArgs1
        Inherits EventArgs
        Public Sub New()

        End Sub
        Public Property SelectedCliente() As String

    End Class

End Namespace
