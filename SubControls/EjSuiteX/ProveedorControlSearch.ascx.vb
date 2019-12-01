Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProveedorControl
Imports EjSuite.Modules.EjSuite

Namespace EjSuite.Modules.EjSuite
    Public Class ProveedorControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija un Proveedor"
            End If
        End Sub

        Protected Sub elegirProveedor(ByVal sender As Object, ByVal e As ProveedorSelectedEventArgs) Handles prcProveedor.ProveedorSelected
            Dim qryProveedor As New Query(Proveedor.Schema)
            qryProveedor.AddWhere(Proveedor.Columns.NCodProveedor, e.SelectedProveedor)
            If qryProveedor.GetCount(Proveedor.Columns.NCodProveedor) > 0 Then
                Dim objProveedor As New Proveedor(e.SelectedProveedor)
                Me.TextValue = objProveedor.CNombre
                Me.ProveedorId = CType(objProveedor.NCodProveedor, Integer)
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

        Public Property ProveedorId() As Nullable(Of Integer)
            Get
                If Not ViewState("ProveedorId") Is Nothing Then
                    Return CInt(ViewState("ProveedorId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("ProveedorId") = value
            End Set
        End Property
    End Class
End Namespace