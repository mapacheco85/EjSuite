Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProveedorControl

Namespace EjSuite.Modules.EjSuite
    Public Class ProveedorMarcaSearchControl
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            
        End Sub
        Protected Sub elegirProveedor(ByVal sender As Object, ByVal e As ProveedorSelectedEventArgs) Handles prc1.ProveedorSelected
            Dim qryProveedor As New Query(Proveedor.Schema)
            Dim qryMarca As New Query(Marca.Schema)
            qryProveedor.AddWhere(Proveedor.Columns.NCodProveedor, e.SelectedProveedor)
            qryMarca.AddWhere(Marca.Columns.NCodProveedor, e.SelectedProveedor)
            If qryProveedor.GetCount(Proveedor.Columns.NCodProveedor) > 0 Then
                Dim objProveedor As New Proveedor(e.SelectedProveedor)
                Me.TextValue = objProveedor.CNombre
                Me.ProveedorId = e.SelectedProveedor
                Me.hfValue = objProveedor.NCodProveedor.ToString()
                If qryMarca.GetCount(Marca.Columns.NCodMarca) > 0 Then
                    Dim lst As New MarcaCollection
                    lst.LoadAndCloseReader(qryMarca.ExecuteReader)
                    dllMarcaIdProducto.DataSource = lst
                    dllMarcaIdProducto.DataTextField = Marca.Columns.CEmpresa
                    dllMarcaIdProducto.DataValueField = Marca.Columns.NCodMarca
                    dllMarcaIdProducto.DataBind()
                    dllMarcaIdProducto.Items.Add("Elija una marca")
                    dllMarcaIdProducto.SelectedValue = "Elija una marca"
                End If
            End If
        End Sub

        Public Property TextValue() As String
            Get
                Return Me.lblProveedor.Text
            End Get
            Set(ByVal value As String)
                Me.lblProveedor.Text = value
            End Set
        End Property

        Public Property hfValue() As String
            Get
                Return Me.hfProveedorId.Value
            End Get
            Set(ByVal value As String)
                Me.hfProveedorId.Value = value
            End Set
        End Property

        Public Property ProveedorId() As Nullable(Of Integer)
            Get
                If Not ViewState("ProveedorId1") Is Nothing Then
                    Return CInt(ViewState("ProveedorId1"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("ProveedorId1") = value
            End Set
        End Property

        Public Property MarcaId() As Nullable(Of Integer)
            Get
                If Not ViewState("MarcaId") Is Nothing Then
                    Return CInt(ViewState("MarcaId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("MarcaId") = value
            End Set
        End Property

        Protected Sub dllMarcaIdProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dllMarcaIdProducto.SelectedIndexChanged

            If dllMarcaIdProducto.SelectedIndex > -1 Then
                Me.MarcaId = CType(dllMarcaIdProducto.SelectedValue, Integer)
            End If

        End Sub

        Public Property dllValue() As String
            Get
                Return Me.dllMarcaIdProducto.Text
            End Get
            Set(ByVal value As String)
                Me.dllMarcaIdProducto.Items.Add(value)
            End Set
        End Property
    End Class
End Namespace