Imports System 
Imports System.Text 
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Configuration 
Imports System.Xml 
Imports System.Xml.Serialization
Imports SubSonic 
Imports SubSonic.Utilities
Namespace EjSuite
	#Region "Tables Struct"
	Public Partial Structure Tables
		Dim x As Integer
		
		Public Shared ReadOnly Almacen As String = "EJS_Almacen"
        
		Public Shared ReadOnly Beneficiario As String = "EJS_Beneficiario"
        
		Public Shared ReadOnly Catalogo As String = "EJS_Catalogo"
        
		Public Shared ReadOnly Cliente As String = "EJS_Cliente"
        
		Public Shared ReadOnly Cotizacion As String = "EJS_Cotizacion"
        
		Public Shared ReadOnly CotizacionDetalle As String = "EJS_CotizacionDetalle"
        
		Public Shared ReadOnly Detalle As String = "EJS_Detalle"
        
		Public Shared ReadOnly Empleado As String = "EJS_Empleado"
        
		Public Shared ReadOnly EmpleadoSucursal As String = "EJS_EmpleadoSucursal"
        
		Public Shared ReadOnly Empresa As String = "EJS_Empresa"
        
		Public Shared ReadOnly ErrorX As String = "EJS_Error"
        
		Public Shared ReadOnly Estado As String = "EJS_Estado"
        
		Public Shared ReadOnly Factura As String = "EJS_Factura"
        
		Public Shared ReadOnly Grupo As String = "EJS_Grupo"
        
		Public Shared ReadOnly GrupoProducto As String = "EJS_GrupoProducto"
        
		Public Shared ReadOnly InformeCobranza As String = "EJS_InformeCobranzas"
        
		Public Shared ReadOnly KardexInventario As String = "EJS_KardexInventario"
        
		Public Shared ReadOnly Leyenda As String = "EJS_Leyenda"
        
		Public Shared ReadOnly ListadoProducto As String = "EJS_ListadoProducto"
        
		Public Shared ReadOnly LogOperacione As String = "EJS_LogOperaciones"
        
		Public Shared ReadOnly Lote As String = "EJS_Lote"
        
		Public Shared ReadOnly MacroUnidade As String = "EJS_MacroUnidades"
        
		Public Shared ReadOnly Marca As String = "EJS_Marca"
        
		Public Shared ReadOnly Medida As String = "EJS_Medida"
        
		Public Shared ReadOnly NotaCredito As String = "EJS_NotaCredito"
        
		Public Shared ReadOnly NotaDebito As String = "EJS_NotaDebito"
        
		Public Shared ReadOnly Objetivo As String = "EJS_Objetivo"
        
		Public Shared ReadOnly ObjetivoDetalle As String = "EJS_ObjetivoDetalle"
        
		Public Shared ReadOnly OrdenCompra As String = "EJS_OrdenCompra"
        
		Public Shared ReadOnly OrdenCompraDetalle As String = "EJS_OrdenCompraDetalle"
        
		Public Shared ReadOnly PagoCuentaXCobrar As String = "EJS_PagoCuentaXCobrar"
        
		Public Shared ReadOnly Parametro As String = "EJS_Parametro"
        
		Public Shared ReadOnly Producto As String = "EJS_Producto"
        
		Public Shared ReadOnly Proveedor As String = "EJS_Proveedor"
        
		Public Shared ReadOnly Region As String = "EJS_Region"
        
		Public Shared ReadOnly SniDatum As String = "EJS_SniData"
        
		Public Shared ReadOnly Sucursal As String = "EJS_Sucursal"
        
		Public Shared ReadOnly Zona As String = "EJS_Zonas"
        
		Public Shared ReadOnly Zonas1 As String = "EJS_Zonas1"
        
	End Structure
	#End Region
	#Region "Schemas"
	
Public Class Schema
		
		Public Shared ReadOnly Property Almacen As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Almacen","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Beneficiario As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Beneficiario","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Catalogo As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Catalogo","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Cliente As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Cliente","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Cotizacion As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Cotizacion","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property CotizacionDetalle As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_CotizacionDetalle","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Detalle As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Detalle","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Empleado As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Empleado","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property EmpleadoSucursal As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_EmpleadoSucursal","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Empresa As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Empresa","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property ErrorX As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Error","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Estado As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Estado","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Factura As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Factura","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Grupo As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Grupo","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property GrupoProducto As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_GrupoProducto","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property InformeCobranza As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_InformeCobranzas","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property KardexInventario As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_KardexInventario","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Leyenda As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Leyenda","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property ListadoProducto As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_ListadoProducto","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property LogOperacione As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_LogOperaciones","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Lote As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Lote","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property MacroUnidade As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_MacroUnidades","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Marca As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Marca","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Medida As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Medida","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property NotaCredito As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_NotaCredito","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property NotaDebito As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_NotaDebito","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Objetivo As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Objetivo","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property ObjetivoDetalle As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_ObjetivoDetalle","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property OrdenCompra As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_OrdenCompra","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property OrdenCompraDetalle As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_OrdenCompraDetalle","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property PagoCuentaXCobrar As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_PagoCuentaXCobrar","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Parametro As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Parametro","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Producto As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Producto","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Proveedor As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Proveedor","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Region As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Region","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property SniDatum As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_SniData","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Sucursal As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Sucursal","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Zona As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Zonas","DALEjSuite")
			End Get
		End Property
        
		Public Shared ReadOnly Property Zonas1 As TableSchema.Table
			Get
				Return DataService.GetSchema("EJS_Zonas1","DALEjSuite")
			End Get
		End Property
        
	End Class
	#End Region
    #Region "View Struct"
    Public Partial Structure Views
		Dim x As Integer
		
		Public Shared ReadOnly VWBuscaProducto As String = "EJS_VWBuscaProducto"
        
		Public Shared ReadOnly VWBuscaProductoCompra As String = "EJS_VWBuscaProductoCompra"
        
		Public Shared ReadOnly VwCuentasCliente As String = "EJS_VwCuentasClientes"
        
		Public Shared ReadOnly Vwdatakardex As String = "EJS_VWDATAKARDEX"
        
		Public Shared ReadOnly VWDavinci As String = "EJS_VWDavinci"
        
		Public Shared ReadOnly VwDebe As String = "EJS_VwDebe"
        
		Public Shared ReadOnly VwDeuda As String = "EJS_VwDeudas"
        
		Public Shared ReadOnly VwDeudas1 As String = "EJS_VwDeudas1"
        
		Public Shared ReadOnly VwDeudasReporte As String = "EJS_VwDeudasReporte"
        
		Public Shared ReadOnly VwHaber As String = "EJS_VwHaber"
        
		Public Shared ReadOnly VwPago As String = "EJS_VwPagos"
        
		Public Shared ReadOnly VwProductoPedido As String = "EJS_VwProductoPedido"
        
		Public Shared ReadOnly VwReporteKardex As String = "EJS_VwReporteKardex"
        
		Public Shared ReadOnly VwRepVentasCliente As String = "EJS_VwRepVentasClientes"
        
		Public Shared ReadOnly VwRepVentasGTerapeutico As String = "EJS_VwRepVentasGTerapeutico"
        
		Public Shared ReadOnly VwRepVentasProducto As String = "EJS_VwRepVentasProductos"
        
		Public Shared ReadOnly VwVentasPorVendedor As String = "EJS_VwVentasPorVendedor"
        
    End Structure
    #End Region
	#Region "Query Factories"
	Public Partial Class DB
		Private Sub New()
		End Sub
		Public Shared _provider As DataProvider = DataService.Providers("DALEjSuite")
		Private Shared _repository As ISubSonicRepository
		Public Shared Property Repository() As ISubSonicRepository
			Get
				If _repository Is Nothing Then
					Return New SubSonicRepository(_provider)
				End If
				Return _repository
			End Get
			Set
				_repository = Value
			End Set
		End Property
		Public Shared Function SelectAllColumnsFrom(Of T As {RecordBase(Of T), New})() As [Select]
			Return Repository.SelectAllColumnsFrom(Of T)()
		End Function
		Public Shared Function [Select]() As [Select]
			Return Repository.Select()
		End Function
		Public Shared Function [Select](ParamArray ByVal columns As String()) As [Select]
			Return Repository.Select(columns)
		End Function
		Public Shared Function [Select](ParamArray ByVal aggregates As Aggregate()) As [Select]
			Return Repository.Select(aggregates)
		End Function
		Public Shared Function Update(Of T As {RecordBase(Of T), New})() As Update
			Return Repository.Update(Of T)()
		End Function
		Public Shared Function Insert() As Insert
			Return Repository.Insert()
		End Function
		Public Shared Function Delete() As Delete
			Return Repository.Delete()
		End Function
		Public Shared Function Query() As InlineQuery
			Return Repository.Query()
		End Function
        
	End Class
	#End Region
End Namespace
 
#Region "Databases"
Public Partial Structure Databases
	Dim x As Integer
	
	Public Shared ReadOnly DALEjSuite As String = "DALEjSuite"
    
End Structure
#End Region
