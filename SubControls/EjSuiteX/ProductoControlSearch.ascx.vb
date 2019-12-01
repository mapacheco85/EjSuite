Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProductoControl
Imports EjSuite.Modules.EjSuite

Namespace EjSuite.Modules.EjSuite
    Public Class ProductoControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirProducto(ByVal sender As Object, ByVal e As ProductoSelectedEventArgs) Handles prcProducto.ProductoSelected
            Dim qryProducto As New Query(Producto.Schema)
            qryProducto.AddWhere(Producto.Columns.NCodProducto, e.SelectedProducto)
            If qryProducto.GetCount(Producto.Columns.NCodProducto) > 0 Then
                Dim objProducto As New Producto(e.SelectedProducto)
                Me.TextValue = objProducto.CNombreGenerico
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

        Public Property ProductoId() As String
            Get
                If Not ViewState("nCodProducto") Is Nothing Then
                    Return CType(ViewState("nCodProducto"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("nCodProducto") = value
            End Set
        End Property

    End Class
End Namespace