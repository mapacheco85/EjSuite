Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProductoControl
Imports EjSuite.Modules.EjSuite

Namespace EjSuite.Modules.EjSuite
    Public Class ProductoPrecioBase
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirProducto(ByVal sender As Object, ByVal e As ProductoSelectedEventArgs) Handles ProductoControl1.ProductoSelected
            Dim objProducto As New Producto(e.SelectedProducto)
            Me.TextValue = objProducto.CDetalles
            Me.ProductoId = e.SelectedProducto
            Me.hfValue = e.SelectedProducto
            Me.Precio = String.Format("{0:F}", objProducto.NPrecioCompra)
            txtPrecioanteriorenvaseLote.Text = String.Format("{0:F}", objProducto.NPrecioCompra)
        End Sub

        Public Property TextValue() As String
            Get
                Return Me.lblProducto.Text
            End Get
            Set(ByVal value As String)
                Me.lblProducto.Text = value
            End Set
        End Property

        Public Property hfValue() As String
            Get
                Return Me.hfProductoId.Value
            End Get
            Set(ByVal value As String)
                Me.hfProductoId.Value = value
            End Set
        End Property

        Public Property ProductoId() As String
            Get
                If Not ViewState("ProductoId1") Is Nothing Then
                    Return CType(ViewState("ProductoId1"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("ProductoId1") = value
            End Set
        End Property

        Public Property Precio() As String
            Get
                If Not ViewState("Precio") Is Nothing Then
                    Return CType(ViewState("Precio"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Precio") = value
            End Set
        End Property

        Public Property TextValuePrecio() As String
            Get
                Return Me.txtPrecioanteriorenvaseLote.Text
            End Get
            Set(ByVal value As String)
                Me.txtPrecioanteriorenvaseLote.Text = value
            End Set
        End Property

    End Class
End Namespace