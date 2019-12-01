Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProductoVentaControl

Namespace EjSuite.Modules.EjSuite
    Public Class VentaControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija un producto"
            End If
        End Sub

        Protected Sub elegirProducto(ByVal sender As Object, ByVal e As ProductoVentaSelectedEventArgs) Handles prcProducto.ProductoSelected
            Dim qryProducto As New Query(Producto.Schema)
            qryProducto.AddWhere(Producto.Columns.NCodProducto, e.SelectedProducto)
            If qryProducto.GetCount(Producto.Columns.NCodProducto) > 0 Then
                Dim objProducto As New Producto(e.SelectedProducto)
                Me.TextValue = objProducto.CNombreComercial
                Me.ProductoId = CType(objProducto.NCodProducto, String)
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

        Public Property ProductoId() As String 'Nullable(Of Integer)
            Get
                If Not ViewState("nCodProducto") Is Nothing Then
                    Return CType(ViewState("nCodProducto"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String) 'Nullable(Of Integer))
                ViewState("nCodProducto") = value
            End Set
        End Property

    End Class
End Namespace