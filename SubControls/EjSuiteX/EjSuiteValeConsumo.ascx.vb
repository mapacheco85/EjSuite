Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports DotNetNuke.Entities.Users
Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteValeConsumo
        Inherits EjSuiteModuleBase

        Private Sub inicializar()
            txtCantidadsueltosMerma.Text = ""
            txtCantidadenvasesMerma.Text = ""
            lblMessageMerma.Text = ""
            ProductoControlSearch1.TextValue = "Elija un producto"
            lbtnKardexMerma.Visible = False
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevaMerma.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsertMerma_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertMerma.Click
            If Page.IsValid AndAlso ProductoControlSearch1.ProductoId <> "" Then
                Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                Dim qry As SqlQuery = New [Select]("nCodEmpleado, nCodUsuario, nCodEmpleadoSucursal, nCodSucursal, nCodAlmacen, nCodJefeAlmacen"). _
                    From(Empleado.Schema). _
                    InnerJoin(EmpleadoSucursal.NCodEmpleadoColumn, Empleado.NCodEmpleadoColumn). _
                    InnerJoin(Sucursal.NCodSucursalColumn, EmpleadoSucursal.NCodSucursalColumn). _
                    InnerJoin(Almacen.NCodSucursalColumn, Sucursal.NCodSucursalColumn). _
                    Where(Almacen.Columns.NCodJefeAlmacen).IsEqualTo(Usrid)
                Dim ds As New DataSet
                ds = qry.ExecuteDataSet
                Dim AlmacnId As Integer
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr As DataRow = ds.Tables(0).Rows(0)
                    AlmacnId = CType(dr(4), Integer)
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Usuario no asignado para realizar esta operacion!")
                End If
                '=====================================================================================================
                Dim ProdId As String = ProductoControlSearch1.ProductoId
                Dim q As New Query(KardexInventario.Schema)
                q.AddWhere(KardexInventario.Columns.NCodProducto, Comparison.Like, "%" & ProdId & "%")
                q.AND(KardexInventario.Columns.NCodAlmacen, AlmacnId)
                Dim lst As New KardexInventarioCollection()
                lst.LoadAndCloseReader(q.ExecuteReader())
                '=====================================================================================================
                Dim objNewKardex As New KardexInventario
                If lst.Count > 0 Then
                    Dim sw As Integer = 1
                    Dim kardexId As Integer = New [Select](Aggregate.Max("kardexid")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(ProdId). _
                        ExecuteScalar(Of Integer)()
                    Dim objAuxKardex As New KardexInventario(kardexId)
                    objNewKardex.NCodAlmacen = AlmacnId
                    objNewKardex.NCodLote = objAuxKardex.NCodLote
                    objNewKardex.NCodProducto = ProdId
                    objNewKardex.DFechareg = Now()
                    objNewKardex.CObservacion = "Nota de Baja"
                    objNewKardex.NPrecioCompra = objAuxKardex.NPrecioCompra
                    objNewKardex.NEntrada = 0
                    objNewKardex.NSalida = CType(txtCantidadenvasesMerma.Text, Integer)
                    objNewKardex.NEntradaSueltos = 0
                    objNewKardex.NSalidaSueltos = CType(txtCantidadsueltosMerma.Text, Integer)
                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                    If objAuxKardex.NStockActualEnvase > CType(txtCantidadenvasesMerma.Text, Integer) Then
                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - CType(txtCantidadenvasesMerma.Text, Integer)
                    Else
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡La cantidad de envases es mayor al stock actual de envases!")
                        sw = 0
                    End If
                    'objNewKardex.Stockanteriorsuelto = objAuxKardex.Stockactualsuelto
                    'If objAuxKardex.Stockactualsuelto > CType(txtCantidadsueltosMerma.Text, Integer) Then
                    '    objNewKardex.Stockactualsuelto = objAuxKardex.Stockactualsuelto - CType(txtCantidadsueltosMerma.Text, Integer)
                    'Else
                    '    EjSuite.Mensaje(Me.upPanel, Me.GetType(),"¡La cantidad de sueltos es mayor al stock actual de sueltos!")
                    '    sw = 0
                    'End If
                    objNewKardex.NCostoTotal = objAuxKardex.NCostoTotal
                    objNewKardex.NPrecioAlmacen = 0
                    objNewKardex.NPrecioVenta = 0
                    objNewKardex.CGlosa = "Por " & ddlCausaMerma.SelectedItem.ToString
                    If sw = 1 Then
                        objNewKardex.NCodKardex = New [Select]("nCodKardex").From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                        objNewKardex.Save()
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Merma ingresada exitosamente!")
                        pnlNuevaMerma.Visible = False
                        lbtnKardexMerma.Visible = True
                    End If
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Producto inexistente en el almacen!")
                End If
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Debe seleccionar un producto!")
            End If
        End Sub

        Protected Sub cmdCancelMerma_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelMerma.Click
            inicializar()
            pnlNuevaMerma.Visible = False
        End Sub

        Protected Sub lbtnKardexMerma_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnKardexMerma.Click
            Dim friendlyName As String = "EjSuite"
            Dim dmi As New DotNetNuke.Entities.Modules.PortalDesktopModuleInfo()
            Dim mc As New DotNetNuke.Entities.Modules.ModuleController
            Dim tabID As Integer = mc.GetModuleByDefinition(0, friendlyName).TabID
            Dim modID As Integer = mc.GetModuleByDefinition(0, friendlyName).ModuleID
            Dim param(2) As String
            param(0) = "mid=" & modID
            param(1) = "EjSuiteSubControl=Kardex"
            Dim urlDoc As String = NavigateURL(tabID, "EjSuiteSub", param)
            Response.Redirect(urlDoc)
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevaMerma.Visible = True
        End Sub
    End Class
End Namespace
