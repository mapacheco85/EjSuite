Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.SucursalControl

Namespace EjSuite.Modules.EjSuite
    Public Class SucursalControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija una Sucursal"
            End If
        End Sub

        Protected Sub elegirSucursal(ByVal sender As Object, ByVal e As SucursalSelectedEventArgs) Handles sucSucursal.SucursalSelected
            Dim qrySucursal As New Query(Sucursal.Schema)
            qrySucursal.AddWhere(Sucursal.Columns.NCodSucursal, e.SelectedSucursal)
            If qrySucursal.GetCount(Sucursal.Columns.NCodSucursal) > 0 Then
                Dim objSucursal As New Sucursal(e.SelectedSucursal)
                Me.TextValue = objSucursal.CZona
                Me.SucursalId = CType(objSucursal.NCodSucursal, Integer)
            End If
        End Sub
        Public Property TextValue() As String
            Get
                Return Me.txt1.Text
            End Get
            Set(ByVal value As String)
                Me.txt1.Text = value
            End Set
        End Property

        Public Property SucursalId() As Nullable(Of Integer)
            Get
                If Not ViewState("SucursalId") Is Nothing Then
                    Return CInt(ViewState("SucursalId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("SucursalId") = value
            End Set
        End Property
    End Class
End Namespace