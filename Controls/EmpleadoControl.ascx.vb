Imports SubSonic

Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class EmpleadoControl
        Inherits EjSuiteModuleBase

        Public Sub BuscarEmpleado()
            Dim ds As New DataSet
            ds = SPs.VerDatosEmpleado(Me.txtBusqueda.Text.Trim()).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdEmpleados.DataSource = ds.Tables(0).DefaultView
            grdEmpleados.DataKeyNames = New String() {"nCodEmpleado"}
            grdEmpleados.DataBind()
            Me.txtBusqueda.Text = Me.txtBusqueda.Text.Replace(",", "")
            ds = Nothing

            Me.fsContactSearch.Visible = True
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
                param(1) = "EjSuiteSubControl=Vendedores"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Vendedores", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarEmpleado()
        End Sub

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdEmpleados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEmpleados.RowCommand
            Select Case e.CommandName.ToLower()
                Case "empleadoselect"
                    Dim mye As New EmpleadoSelectedEventArgs() With {.SelectedEmpleado = CInt(e.CommandArgument)}
                    RaiseEvent EmpleadoSelected(Me, mye)
                    'EliminarComillas()
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmpleados.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypProveedor As New LinkButton() With {.CommandName = "EmpleadoSelect", .CssClass = "CommandButton", .ValidationGroup = "EmpleadoSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypProveedor)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmpleados.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As String = grdEmpleados.DataKeys(indice).Value.ToString
                    Dim objEmpleado As Empleado = Empleado.FetchByID(id)
                    Dim hypEmpleado As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypEmpleado.Text = objEmpleado.NCodEmpleado
                    hypEmpleado.CommandArgument = objEmpleado.NCodEmpleado.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event EmpleadoSelected(ByVal sender As Object, ByVal e As EmpleadoSelectedEventArgs)

    End Class

    Public Class EmpleadoSelectedEventArgs
        Inherits EventArgs
        Public Sub New()
            
        End Sub
        Public Property SelectedEmpleado() As System.Nullable(Of Integer)
    End Class

End Namespace