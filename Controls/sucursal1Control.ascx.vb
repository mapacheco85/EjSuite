Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class sucursal1Control
        Inherits EjSuiteModuleBase

        Public Sub CargarSucursal1()
            Dim ds As New DataSet
            ds = SPs.VerDatosSucursal(Me.txtBusqueda.Text).GetDataSet()
            lblResult.Text = String.Format("Se encontraron {0} registro(s)", ds.Tables(0).Rows.Count)

            grdSucursal1.DataSource = ds.Tables(0).DefaultView
            grdSucursal1.DataKeyNames = New String() {"nCodSucursal"}
            grdSucursal1.DataBind()
            Me.fsBusqueda.Visible = True
            ds = Nothing

            upModal.Update()
            Me.ModalPopup1.Show()
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
                param(1) = "EjSuiteSubControl=Vendedores"
                Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
                'Dim urlDoc As String = EditUrl("EjSuiteSubControl", "Vendedores", "EjSuiteSub")
                hypSucursal1.NavigateUrl = urlDoc
                Me.ModalPopup1.Hide()
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelar1.Click
            Me.ModalPopup1.Hide()
        End Sub

        Protected Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscar1.Click
            CargarSucursal1()
        End Sub

        Protected Sub grdSucursal1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSucursal1.RowCommand
            Select Case e.CommandName.ToLower
                Case "sucursal1select"
                    Dim mye As New Sucursal1SelectedEventArgs() With {.SelectedSucursal1 = CInt(e.CommandArgument)}
                    RaiseEvent Sucursal1Selected(Me, mye)
                    Me.ModalPopup1.Hide()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdSucursal1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal1.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypSucursal As New LinkButton() With {.CommandName = "Sucursal1Select", .CssClass = "CommandButton", .ValidationGroup = "Sucursal1SelectorSel"}
                    e.Row.Cells(0).Controls.Add(hypSucursal)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdSucursal1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal1.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim objSucursal As Sucursal = CType(e.Row.DataItem, Sucursal)
                    Dim hypSucursal As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
                    hypSucursal.Text = objSucursal.CZona
                    hypSucursal.CommandArgument = objSucursal.NCodSucursal.ToString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Public Event Sucursal1Selected(ByVal sender As Object, ByVal e As Sucursal1SelectedEventArgs)

        Private Sub lbnPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbnPopup.Click
            Me.ModalPopup1.Show()
        End Sub
    End Class
    Public Class Sucursal1SelectedEventArgs
        Inherits EventArgs

        Private _selectedsucursal1 As System.Nullable(Of Integer)
        Public Property SelectedSucursal1() As System.Nullable(Of Integer)
            Get
                Return _selectedsucursal1
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _selectedsucursal1 = value
            End Set
        End Property
    End Class
End Namespace
