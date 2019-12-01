Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ProductoControl
Imports EjSuite.Modules.EjSuite
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class PagoCliente
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirCliente(ByVal sender As Object, ByVal e As ClienteSelectedEventArgs1) Handles clicCliente.ClienteSelected
            Dim qryCliente As New Query(Cliente.Schema)
            qryCliente.AddWhere(Cliente.Columns.NCodCliente, e.SelectedCliente)
            If qryCliente.GetCount(Cliente.Columns.NCodCliente) > 0 Then
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, e.SelectedCliente)
                Me.TextValue = objCliente.CCliente
                Me.ClienteId = CType(objCliente.NCodCliente, String)
                Me.hfValue = e.SelectedCliente
                '=====================================================================================================
                Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
                Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
                Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                '=====================================================================================================
                Dim qryFactura As New Query(Factura.Schema)
                qryFactura.AddWhere(Factura.Columns.NCodSucursal, objSucursal.NCodSucursal)
                qryFactura.AND(Factura.Columns.BPagada, False)
                qryFactura.AND(Factura.Columns.NCodCliente, e.SelectedCliente)

                ddlFactura.Items.Clear()
                If qryFactura.GetCount(Factura.Columns.NCodFactura) > 0 Then
                    Dim lst As New FacturaCollection
                    lst.LoadAndCloseReader(qryFactura.ExecuteReader)
                    ddlFactura.DataSource = lst
                    ddlFactura.DataTextField = Factura.Columns.NNumero
                    ddlFactura.DataValueField = Factura.Columns.NCodFactura
                    ddlFactura.DataBind()
                    ddlFactura.Items.Add("Elija una Factura")
                    ddlFactura.SelectedValue = "Elija una Factura"
                Else
                    ddlFactura.DataSource = Nothing
                    ddlFactura.DataBind()
                    ddlFactura.Items.Add("No tiene pendientes")
                    ddlFactura.SelectedValue = "No tiene pendientes"
                End If
            End If
        End Sub

        Protected Sub ddlFactura_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFactura.SelectedIndexChanged
            If ddlFactura.SelectedIndex > -1 Then
                Me.nCodFactura = CType(ddlFactura.SelectedValue, Integer)
                Me.FacturaSelected = ddlFactura.SelectedValue
                Dim objFactura As New Factura(Me.nCodFactura)
                Dim totalfactura As Decimal = New [Select](Aggregate.Sum("(nPrecioUnitario * (1-(nDescuento/100)))*nCantidad")). _
                    From(Detalle.Schema). _
                    Where(Detalle.Columns.NcodFactura).IsEqualTo(objFactura.NCodFactura).ExecuteScalar(Of Decimal)()
                Dim pagos As Decimal = New [Select](Aggregate.Sum("nMontoPagado")). _
                    From(PagoCuentaXCobrar.Schema).Where(PagoCuentaXCobrar.Columns.NFacturaId).IsEqualTo(Me.nCodFactura).ExecuteScalar(Of Decimal)()
                Dim saldo As Decimal = 0
                saldo = totalfactura - pagos
                Me.Saldo = saldo
                Me.SaldoTextValue = String.Format("{0:F}", saldo)
            End If
        End Sub

        Public Property TextValue() As String
            Get
                Return Me.lblCliente.Text
            End Get
            Set(ByVal value As String)
                Me.lblCliente.Text = value
            End Set
        End Property

        Public Property hfValue() As String
            Get
                Return Me.hfClienteId.Value
            End Get
            Set(ByVal value As String)
                Me.hfClienteId.Value = value
            End Set
        End Property

        Public Property ClienteId() As String
            Get
                If Not ViewState("nCodCliente") Is Nothing Then
                    Return CType(ViewState("nCodCliente"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("nCodCliente") = value
            End Set
        End Property

        Public Property nCodFactura() As Nullable(Of Integer)
            Get
                If Not ViewState("nCodFactura") Is Nothing Then
                    Return CInt(ViewState("nCodFactura"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("nCodFactura") = value
            End Set
        End Property

        Public Property FacturaSelected() As String
            Get
                Return Me.ddlFactura.SelectedValue
            End Get
            Set(ByVal value As String)
                Me.ddlFactura.SelectedValue = value
            End Set
        End Property

        Public Property Saldo() As Nullable(Of Decimal)
            Get
                If Not ViewState("Saldo") Is Nothing Then
                    Return CInt(ViewState("Saldo"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                ViewState("Saldo") = value
            End Set
        End Property

        Public Property SaldoTextValue() As String
            Get
                Return Me.lblSaldoPago.Text
            End Get
            Set(ByVal value As String)
                Me.lblSaldoPago.Text = value
            End Set
        End Property

    End Class
End Namespace
