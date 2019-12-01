Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProductoControl
Imports EjSuite.Modules.EjSuite
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class ProductoStockActual
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirProducto(ByVal sender As Object, ByVal e As ProductoSelectedEventArgs) Handles prcProducto.ProductoSelected
            Dim qryProducto As New Query(Producto.Schema)
            qryProducto.AddWhere(Producto.Columns.NCodProducto, e.SelectedProducto)
            If qryProducto.GetCount(Producto.Columns.NCodProducto) > 0 Then
                '=====================================================================================================
                'Verificar si el usuario esta registrado como jefe de almacen
                Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
                Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
                Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
                Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)
                '=====================================================================================================
                Dim objProducto As New Producto(e.SelectedProducto)
                Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(objProducto.NCodProducto). _
                        ExecuteScalar(Of Integer)()
                Dim objKardex As New KardexInventario(kardexId)

                Me.TextValue = objProducto.CDetalles
                Me.ProductoId = CType(objProducto.NCodProducto, String)
                Me.hfValue = e.SelectedProducto
                Me.StockActual = objKardex.NStockActualEnvase
                lblStockActualProducto.Text = objKardex.NStockActualEnvase
            End If
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

        Public Property StockActual() As String
            Get
                If Not ViewState("StockActual") Is Nothing Then
                    Return CType(ViewState("StockActual"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("StockActual") = value
            End Set
        End Property

        Public Property TextValueStockActual() As String
            Get
                Return Me.lblStockActualProducto.Text
            End Get
            Set(ByVal value As String)
                Me.lblStockActualProducto.Text = value
            End Set
        End Property

    End Class
End Namespace