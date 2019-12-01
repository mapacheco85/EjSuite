Imports SubSonic
Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.AlmacenEmpleadoControl

Namespace EjSuite.Modules.EjSuite

    Public Class AlmacenEmpleadoControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                txt1.Text = "Elija un almacén"
            End If
        End Sub

        Protected Sub elegirAlmacen(ByVal sender As Object, ByVal e As AlmacenSelectedEventArgs) Handles aecAlmacen.AlmacenSelected
            Dim qryAlmacen As New Query(Almacen.Schema)
            qryAlmacen.AddWhere(Almacen.Columns.NCodAlmacen, e.SelectedAlmacen)
            If qryAlmacen.GetCount(Almacen.Columns.NCodAlmacen) > 0 Then
                Dim objAlmacen As New Almacen(e.SelectedAlmacen)
                Dim objSucursal As New Sucursal(objAlmacen.NCodSucursal)
                Me.TextValue = String.Format("{0} - {1} - {2}", objAlmacen.NCodSucursal, objSucursal.CZona, objSucursal.CDireccion)
                Me.AlmacenId = CType(objAlmacen.NCodAlmacen, Integer)
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

        Public Property AlmacenId() As Nullable(Of Integer)
            Get
                If Not ViewState("AlmacenId") Is Nothing Then
                    Return CInt(ViewState("AlmacenId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("AlmacenId") = value
            End Set
        End Property

    End Class
End Namespace
