Imports SubSonic
Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class AlmacenEmpleadoControl
        Inherits EjSuiteModuleBase
        Public Sub New()
            
        End Sub

        Public Sub BuscarAlmacen()
            Dim cUsuarioId As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim ds As New DataSet
            ds = SPs.SPBuscarAlmacenesEmpleado(cUsuarioId).GetDataSet()
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Dim AlmacnId As Integer = CType(dr(4), Integer)
            ds = Nothing
            '=====================================================================================================
            Dim ds1 As New DataSet
            ds1 = SPs.SPVerDatosAlmacen(AlmacnId).GetDataSet()
            lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", ds1.Tables(0).Rows.Count)

            grdAlmacenes.DataSource = ds1.Tables(0).DefaultView
            grdAlmacenes.DataKeyNames = New String() {"nCodAlmacen"}
            grdAlmacenes.DataBind()
            Me.txtBusqueda.Text = Me.txtBusqueda.Text.Replace(",", "")
            Me.fsContactSearch.Visible = True
            ds = Nothing

            upsearchModal.Update()
            Me.ModalPopupExtender1.Show()
            ds1 = Nothing
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
                param(1) = "EjSuiteSubControl=Asignaciones"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Asignaciones", "EjSuiteSub")
                hypAdminEmpresa.NavigateUrl = urlDoc
                Me.ModalPopupExtender1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
            BuscarAlmacen()
        End Sub

        Protected Sub lbnElegir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbnElegir.Click
            Me.ModalPopupExtender1.Show()
        End Sub

        Protected Sub grdAlmacenes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAlmacenes.RowCommand
            Select Case e.CommandName.ToLower()
                Case "almacenselect"
                    Dim mye As New AlmacenSelectedEventArgs() With {.SelectedAlmacen = CInt(e.CommandArgument)}
                    RaiseEvent AlmacenSelected(Me, mye)
                    Me.ModalPopupExtender1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlmacenes.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypAlmacen As New LinkButton() With {.CommandName = "AlmacenSelect", .CssClass = "CommandButton", .ValidationGroup = "AlmacenSelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypAlmacen)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlmacenes.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim id As Integer = CType(grdAlmacenes.DataKeys(indice).Value, Integer)
                    Dim objAlmacen As Almacen = Almacen.FetchByID(id)
                    Dim hypAlmacen As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypAlmacen.Text = objAlmacen.NCodAlmacen.ToString()
                    hypAlmacen.CommandArgument = objAlmacen.NCodAlmacen.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event AlmacenSelected(ByVal sender As Object, ByVal e As AlmacenSelectedEventArgs)

    End Class

    Public Class AlmacenSelectedEventArgs
        Inherits EventArgs
        Public Sub New()
            
        End Sub
        Public Property SelectedAlmacen() As System.Nullable(Of Integer)
    End Class

End Namespace