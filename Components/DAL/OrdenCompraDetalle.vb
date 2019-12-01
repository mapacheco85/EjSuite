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
	''' <summary>
	''' Strongly-typed collection for the OrdenCompraDetalle class.
	''' </summary>
	<Serializable> _
	Public Partial Class OrdenCompraDetalleCollection 
	Inherits ActiveList(Of OrdenCompraDetalle, OrdenCompraDetalleCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As OrdenCompraDetalleCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As OrdenCompraDetalle = Me(i)
				For Each w As SubSonic.Where In Me.wheres
					Dim remove As Boolean = False
					Dim pi As System.Reflection.PropertyInfo = o.GetType().GetProperty(w.ColumnName)
					If pi.CanRead Then
						Dim val As Object = pi.GetValue(o, Nothing)
						Select Case w.Comparison
							Case SubSonic.Comparison.Equals
								If (Not val.Equals(w.ParameterValue)) Then
									remove = True
								End If
						End Select
					End If
					If remove Then
						Me.Remove(o)
						Exit For
					End If
				Next w
			Next i
			Return Me
		End Function
		
		
	End Class
	''' <summary>
	''' This is an ActiveRecord class which wraps the EJS_OrdenCompraDetalle table.
	''' </summary>
	<Serializable> _
	Public Partial Class OrdenCompraDetalle 
	Inherits ActiveRecord(Of OrdenCompraDetalle)
		#Region ".ctors and Default Settings"
		
		Public Sub New()
			SetSQLProps()
			InitSetDefaults()
			MarkNew()
		End Sub
		
		Public Sub New(ByVal useDatabaseDefaults As Boolean)
			SetSQLProps()
			If useDatabaseDefaults = True Then
				ForceDefaults()
			End If
			MarkNew()
		End Sub
		Private Sub InitSetDefaults()
			SetDefaults()
		End Sub
        
		Public Sub New(ByVal keyID As Object)
			SetSQLProps()
			InitSetDefaults()
			LoadByKey(keyID)
		End Sub
		Public Sub New(ByVal columnName As String, ByVal columnValue As Object)
			SetSQLProps()
			InitSetDefaults()
			LoadByParam(columnName,columnValue)
		End Sub
		
        
		Protected Shared Sub SetSQLProps()
			GetTableSchema()
		End Sub
		#End Region
		
		#Region "Schema and Query Accessor"
		
		Public Shared ReadOnly Property Schema() As TableSchema.Table
			Get
				If BaseSchema Is Nothing Then
					SetSQLProps()
				End If
				Return BaseSchema
			End Get
		End Property
		Private Shared Sub GetTableSchema()
			If (Not IsSchemaInitialized) Then
				'Schema declaration
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_OrdenCompraDetalle", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodPedidoDetalle As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodPedidoDetalle.ColumnName = "nCodPedidoDetalle"
                colvarNCodPedidoDetalle.DataType = DbType.Int32
                colvarNCodPedidoDetalle.MaxLength = 0
                colvarNCodPedidoDetalle.AutoIncrement = false
                colvarNCodPedidoDetalle.IsNullable = false
                colvarNCodPedidoDetalle.IsPrimaryKey = true
                colvarNCodPedidoDetalle.IsForeignKey = false
                colvarNCodPedidoDetalle.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodPedidoDetalle)
                
                Dim colvarNCodPedido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodPedido.ColumnName = "nCodPedido"
                colvarNCodPedido.DataType = DbType.Int32
                colvarNCodPedido.MaxLength = 0
                colvarNCodPedido.AutoIncrement = false
                colvarNCodPedido.IsNullable = false
                colvarNCodPedido.IsPrimaryKey = false
                colvarNCodPedido.IsForeignKey = true
                colvarNCodPedido.IsReadOnly = false
                
                
				colvarNCodPedido.ForeignKeyTableName = "EJS_OrdenCompra"
                
                schema.Columns.Add(colvarNCodPedido)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = true
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = true
                colvarNCodProducto.IsReadOnly = false
                
                
				colvarNCodProducto.ForeignKeyTableName = "EJS_Producto"
                
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarNCantidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCantidad.ColumnName = "nCantidad"
                colvarNCantidad.DataType = DbType.Int32
                colvarNCantidad.MaxLength = 0
                colvarNCantidad.AutoIncrement = false
                colvarNCantidad.IsNullable = false
                colvarNCantidad.IsPrimaryKey = false
                colvarNCantidad.IsForeignKey = false
                colvarNCantidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCantidad)
                
                Dim colvarNPrecioUnitario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioUnitario.ColumnName = "nPrecioUnitario"
                colvarNPrecioUnitario.DataType = DbType.Currency
                colvarNPrecioUnitario.MaxLength = 0
                colvarNPrecioUnitario.AutoIncrement = false
                colvarNPrecioUnitario.IsNullable = false
                colvarNPrecioUnitario.IsPrimaryKey = false
                colvarNPrecioUnitario.IsForeignKey = false
                colvarNPrecioUnitario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioUnitario)
                
                Dim colvarNDescuento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNDescuento.ColumnName = "nDescuento"
                colvarNDescuento.DataType = DbType.Decimal
                colvarNDescuento.MaxLength = 0
                colvarNDescuento.AutoIncrement = false
                colvarNDescuento.IsNullable = false
                colvarNDescuento.IsPrimaryKey = false
                colvarNDescuento.IsForeignKey = false
                colvarNDescuento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNDescuento)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_OrdenCompraDetalle",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodPedidoDetalle")> _
        Public Property NCodPedidoDetalle As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodPedidoDetalle)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodPedidoDetalle, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodPedido")> _
        Public Property NCodPedido As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodPedido)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodPedido, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCantidad")> _
        Public Property NCantidad As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCantidad)
			End Get
		    
			Set
				SetColumnValue(Columns.NCantidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioUnitario")> _
        Public Property NPrecioUnitario As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioUnitario)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioUnitario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NDescuento")> _
        Public Property NDescuento As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NDescuento)
			End Get
		    
			Set
				SetColumnValue(Columns.NDescuento, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a OrdenCompra ActiveRecord object related to this OrdenCompraDetalle
		''' </summary>
		Public Property OrdenCompra() As EjSuite.OrdenCompra
			Get
				Return EjSuite.OrdenCompra.FetchByID(Me.NCodPedido)
			End Get
			Set
				SetColumnValue("nCodPedido", Value.NCodPedido)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Producto ActiveRecord object related to this OrdenCompraDetalle
		''' </summary>
		Public Property Producto() As EjSuite.Producto
			Get
				Return EjSuite.Producto.FetchByID(Me.NCodProducto)
			End Get
			Set
				SetColumnValue("nCodProducto", Value.NCodProducto)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodPedidoDetalle As Integer,ByVal varNCodPedido As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varNCantidad As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varNDescuento As Decimal)
			Dim item As OrdenCompraDetalle = New OrdenCompraDetalle()
			
            item.NCodPedidoDetalle = varNCodPedidoDetalle
            
            item.NCodPedido = varNCodPedido
            
            item.NCodProducto = varNCodProducto
            
            item.NCantidad = varNCantidad
            
            item.NPrecioUnitario = varNPrecioUnitario
            
            item.NDescuento = varNDescuento
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodPedidoDetalle As Integer,ByVal varNCodPedido As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varNCantidad As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varNDescuento As Decimal)
			Dim item As OrdenCompraDetalle = New OrdenCompraDetalle()
		    
                item.NCodPedidoDetalle = varNCodPedidoDetalle
				
                item.NCodPedido = varNCodPedido
				
                item.NCodProducto = varNCodProducto
				
                item.NCantidad = varNCantidad
				
                item.NPrecioUnitario = varNPrecioUnitario
				
                item.NDescuento = varNDescuento
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodPedidoDetalleColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodPedidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCantidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioUnitarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NDescuentoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodPedidoDetalle As String = "nCodPedidoDetalle"
            
            Public Shared NCodPedido As String = "nCodPedido"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared NPrecioUnitario As String = "nPrecioUnitario"
            
            Public Shared NDescuento As String = "nDescuento"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
