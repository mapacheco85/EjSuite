Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteTraspasos
        Inherits EjSuiteModuleBase

        Private Sub Almacen_ID()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim qry As SqlQuery = New [Select]("nCodEmpleado, nCodUsuario, nCodEmpleadoSucursal, EJS_Sucursal.nCodSucursal, nCodAlmacen, nCodJefeAlmacen, cZona, cDireccion"). _
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
                Dim zona As String = dr(6).ToString
                Dim direccion As String = dr(7).ToString
                lblAlmacenorigenTraspaso.Text = String.Format("{0} - {1} - {2}", AlmacnId, zona, direccion)
                pnlNuevoTraspaso.Visible = True
            Else
                If UserController.Instance.GetCurrentUserInfo().IsSuperUser Then
                    AlmacnId = 1
                    pnlNuevoTraspaso.Visible = True
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Usuario no asignado para realizar esta operacion!")
                    pnlNuevoTraspaso.Visible = False
                End If

            End If
            ViewState("almacenid") = AlmacnId
        End Sub

        Private Sub inicializar()
            txtCantidadsueltosTraspaso.Text = ""
            txtCantidadenvasesTraspaso.Text = ""
            lblMessageTraspaso.Text = ""
            ProductoControlSearch1.TextValue = "Elija un producto"
            AlmacenEmpleadoControlSearch1.TextValue = "Elija un almacén"
            lbtnKardexTraspaso.Visible = False
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoTraspaso.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsertTraspaso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertTraspaso.Click
            If Page.IsValid AndAlso ProductoControlSearch1.ProductoId <> "" Then
                Dim ProdId As String = ProductoControlSearch1.ProductoId
                Dim AlmacnIdOrigen As Integer = CType(ViewState("almacenid"), Integer)
                Dim q As New Query(KardexInventario.Schema)
                q.AddWhere(KardexInventario.Columns.NCodProducto, Comparison.Like, "%" & ProdId & "%")
                q.AND(KardexInventario.Columns.NCodAlmacen, AlmacnIdOrigen)
                Dim lst As New KardexInventarioCollection()
                lst.LoadAndCloseReader(q.ExecuteReader())

                Dim objNewKardex As New KardexInventario
                If lst.Count > 0 Then
                    Dim sw As Integer = 1
                    Dim kardexId As Integer = New [Select](Aggregate.Max("nCodKardex")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnIdOrigen). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(ProdId). _
                        ExecuteScalar(Of Integer)()
                    Dim objAuxKardex As New KardexInventario(kardexId)
                    objNewKardex.NCodAlmacen = AlmacnIdOrigen
                    objNewKardex.NCodLote = objAuxKardex.NCodLote
                    objNewKardex.NCodProducto = ProdId
                    objNewKardex.DFechareg = Now.Date
                    objNewKardex.CObservacion = "Nota de Remision"
                    objNewKardex.NPrecioCompra = objAuxKardex.NPrecioCompra
                    objNewKardex.NEntrada = 0
                    objNewKardex.NSalida = CType(txtCantidadenvasesTraspaso.Text, Integer)
                    objNewKardex.NEntradaSueltos = 0
                    objNewKardex.NSalidaSueltos = CType(txtCantidadsueltosTraspaso.Text, Integer)
                    objNewKardex.NStockAnteriorEnvase = objAuxKardex.NStockActualEnvase
                    If objAuxKardex.NStockActualEnvase > CType(txtCantidadenvasesTraspaso.Text, Integer) Then
                        objNewKardex.NStockActualEnvase = objAuxKardex.NStockActualEnvase - CType(txtCantidadenvasesTraspaso.Text, Integer)
                    Else
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡La cantidad de envases es mayor al stock actual de envases!")
                        sw = 0
                    End If
                    objNewKardex.NStockAnteriorSuelto = objAuxKardex.NStockActualSuelto
                    If objAuxKardex.NStockActualSuelto > CType(txtCantidadsueltosTraspaso.Text, Integer) Then
                        objNewKardex.NStockActualSuelto = objAuxKardex.NStockActualSuelto - CType(txtCantidadsueltosTraspaso.Text, Integer)
                    Else
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡La cantidad de sueltos es mayor al stock actual de sueltos!")
                        sw = 0
                    End If
                    objNewKardex.NCostoTotal = objAuxKardex.NCostoTotal
                    objNewKardex.CGlosa = ""
                    objNewKardex.NPrecioAlmacen = 0
                    objNewKardex.NPrecioVenta = 0
                    '=====================================================================================================
                    Dim AlmacnIdDestino As Integer = CType(AlmacenEmpleadoControlSearch1.AlmacenId, Integer)
                    Dim q2 As New Query(KardexInventario.Schema)
                    q2.AddWhere(KardexInventario.Columns.NCodProducto, Comparison.Like, "%" & ProdId & "%")
                    q2.AND(KardexInventario.Columns.NCodAlmacen, AlmacnIdDestino)
                    Dim lst2 As New KardexInventarioCollection()
                    lst2.LoadAndCloseReader(q2.ExecuteReader())

                    Dim objNewKardex2 As New KardexInventario
                    If lst2.Count > 0 Then
                        kardexId = New [Select](Aggregate.Max("nCodKardex")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnIdDestino). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(ProdId). _
                        ExecuteScalar(Of Integer)()
                        Dim objAuxKardex2 As New KardexInventario(kardexId)
                        objNewKardex2.NCodAlmacen = AlmacnIdDestino
                        objNewKardex2.NCodLote = objAuxKardex2.NCodLote
                        objNewKardex2.NCodProducto = ProdId
                        objNewKardex2.DFechareg = Now.Date
                        objNewKardex2.CObservacion = "Nota de Remision"
                        objNewKardex2.NPrecioCompra = objAuxKardex2.NPrecioCompra
                        objNewKardex2.NEntrada = CType(txtCantidadenvasesTraspaso.Text, Integer)
                        objNewKardex2.NSalida = 0
                        objNewKardex2.NEntradaSueltos = CType(txtCantidadsueltosTraspaso.Text, Integer)
                        objNewKardex2.NSalidaSueltos = 0
                        objNewKardex2.NStockAnteriorEnvase = objAuxKardex2.NStockActualEnvase
                        objNewKardex2.NStockActualEnvase = objAuxKardex2.NStockActualEnvase + CType(txtCantidadenvasesTraspaso.Text, Integer)
                        objNewKardex2.NStockAnteriorSuelto = objAuxKardex2.NStockActualSuelto
                        objNewKardex2.NStockActualSuelto = objAuxKardex2.NStockActualSuelto + CType(txtCantidadsueltosTraspaso.Text, Integer)
                        objNewKardex2.NCostoTotal = objAuxKardex2.NCostoTotal
                        objNewKardex2.NPrecioAlmacen = 0
                        objNewKardex2.NPrecioVenta = 0
                    Else
                        objNewKardex2.NCodAlmacen = AlmacnIdDestino
                        objNewKardex2.NCodLote = objAuxKardex.NCodLote
                        objNewKardex2.NCodProducto = ProdId
                        objNewKardex2.DFechareg = Now.Date
                        objNewKardex2.CObservacion = "Nota de Remision"
                        objNewKardex2.NPrecioCompra = objAuxKardex.NPrecioCompra
                        objNewKardex2.NEntrada = CType(txtCantidadenvasesTraspaso.Text, Integer)
                        objNewKardex2.NSalida = 0
                        objNewKardex2.NEntradaSueltos = CType(txtCantidadsueltosTraspaso.Text, Integer)
                        objNewKardex2.NSalidaSueltos = 0
                        objNewKardex2.NStockAnteriorEnvase = 0
                        objNewKardex2.NStockActualEnvase = CType(txtCantidadenvasesTraspaso.Text, Integer)
                        objNewKardex2.NStockAnteriorSuelto = 0
                        objNewKardex2.NStockActualSuelto = CType(txtCantidadsueltosTraspaso.Text, Integer)
                        objNewKardex2.NCostoTotal = objAuxKardex.NCostoTotal
                        objNewKardex2.NPrecioAlmacen = 0
                        objNewKardex2.NPrecioVenta = 0
                    End If
                    '=====================================================================================================
                    If sw = 1 Then
                        objNewKardex.NCodKardex = New [Select]("nCodKardex").From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                        objNewKardex.Save()
                        objNewKardex2.NCodKardex = New [Select]("nCodKardex").From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                        objNewKardex2.Save()
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Traspaso ingresado exitosamente!")
                        pnlNuevoTraspaso.Visible = False
                        lbtnKardexTraspaso.Visible = True
                    End If
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Producto inexistente en el almacén seleccionado!")
                End If
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Debe seleccionar un producto!")
            End If
        End Sub

        Protected Sub cmdCancelTraspaso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelTraspaso.Click
            inicializar()
            pnlNuevoTraspaso.Visible = False
        End Sub

        Protected Sub lbtnKardexTraspaso_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnKardexTraspaso.Click
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
            pnlNuevoTraspaso.Visible = True
            Almacen_ID()
        End Sub
    End Class
End Namespace
