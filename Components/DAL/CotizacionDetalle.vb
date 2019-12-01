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
	''' Strongly-typed collection for the CotizacionDetalle class.
	''' </summary>
	<Serializable> _
	Public Partial Class CotizacionDetalleCollection 
	Inherits ActiveList(Of CotizacionDetalle, CotizacionDetalleCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As CotizacionDetalleCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As CotizacionDetalle = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_CotizacionDetalle table.
	''' </summary>
	<Serializable> _
	Public Partial Class CotizacionDetalle 
	Inherits ActiveRecord(Of CotizacionDetalle)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_CotizacionDetalle", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodCotizacionDetalle As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCotizacionDetalle.ColumnName = "nCodCotizacionDetalle"
                colvarNCodCotizacionDetalle.DataType = DbType.Int32
                colvarNCodCotizacionDetalle.MaxLength = 0
                colvarNCodCotizacionDetalle.AutoIncrement = false
                colvarNCodCotizacionDetalle.IsNullable = false
                colvarNCodCotizacionDetalle.IsPrimaryKey = true
                colvarNCodCotizacionDetalle.IsForeignKey = false
                colvarNCodCotizacionDetalle.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCotizacionDetalle)
                
                Dim colvarNCodCotizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCotizacion.ColumnName = "nCodCotizacion"
                colvarNCodCotizacion.DataType = DbType.Int32
                colvarNCodCotizacion.MaxLength = 0
                colvarNCodCotizacion.AutoIncrement = false
                colvarNCodCotizacion.IsNullable = false
                colvarNCodCotizacion.IsPrimaryKey = false
                colvarNCodCotizacion.IsForeignKey = true
                colvarNCodCotizacion.IsReadOnly = false
                
                
				colvarNCodCotizacion.ForeignKeyTableName = "EJS_Cotizacion"
                
                schema.Columns.Add(colvarNCodCotizacion)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = false
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = true
                colvarNCodProducto.IsReadOnly = false
                
                
				colvarNCodProducto.ForeignKeyTableName = "EJS_Producto"
                
                schema.Columns.Add(colvarNCodProducto)
                
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
                
                Dim colvarBUnidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBUnidad.ColumnName = "bUnidad"
                colvarBUnidad.DataType = DbType.Boolean
                colvarBUnidad.MaxLength = 0
                colvarBUnidad.AutoIncrement = false
                colvarBUnidad.IsNullable = false
                colvarBUnidad.IsPrimaryKey = false
                colvarBUnidad.IsForeignKey = false
                colvarBUnidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBUnidad)
                
                Dim colvarBDocena As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBDocena.ColumnName = "bDocena"
                colvarBDocena.DataType = DbType.Boolean
                colvarBDocena.MaxLength = 0
                colvarBDocena.AutoIncrement = false
                colvarBDocena.IsNullable = false
                colvarBDocena.IsPrimaryKey = false
                colvarBDocena.IsForeignKey = false
                colvarBDocena.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBDocena)
                
                Dim colvarBCien As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBCien.ColumnName = "bCien"
                colvarBCien.DataType = DbType.Boolean
                colvarBCien.MaxLength = 0
                colvarBCien.AutoIncrement = false
                colvarBCien.IsNullable = false
                colvarBCien.IsPrimaryKey = false
                colvarBCien.IsForeignKey = false
                colvarBCien.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBCien)
                
                Dim colvarBMil As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBMil.ColumnName = "bMil"
                colvarBMil.DataType = DbType.Boolean
                colvarBMil.MaxLength = 0
                colvarBMil.AutoIncrement = false
                colvarBMil.IsNullable = false
                colvarBMil.IsPrimaryKey = false
                colvarBMil.IsForeignKey = false
                colvarBMil.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBMil)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_CotizacionDetalle",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodCotizacionDetalle")> _
        Public Property NCodCotizacionDetalle As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCotizacionDetalle)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCotizacionDetalle, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodCotizacion")> _
        Public Property NCodCotizacion As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCotizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCotizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProducto, Value)
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
        <XmlAttribute("NDescuento")> _
        Public Property NDescuento As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NDescuento)
			End Get
		    
			Set
				SetColumnValue(Columns.NDescuento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BUnidad")> _
        Public Property BUnidad As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BUnidad)
			End Get
		    
			Set
				SetColumnValue(Columns.BUnidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BDocena")> _
        Public Property BDocena As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BDocena)
			End Get
		    
			Set
				SetColumnValue(Columns.BDocena, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BCien")> _
        Public Property BCien As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BCien)
			End Get
		    
			Set
				SetColumnValue(Columns.BCien, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BMil")> _
        Public Property BMil As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BMil)
			End Get
		    
			Set
				SetColumnValue(Columns.BMil, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Cotizacion ActiveRecord object related to this CotizacionDetalle
		''' </summary>
		Public Property Cotizacion() As EjSuite.Cotizacion
			Get
				Return EjSuite.Cotizacion.FetchByID(Me.NCodCotizacion)
			End Get
			Set
				SetColumnValue("nCodCotizacion", Value.NCodCotizacion)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Producto ActiveRecord object related to this CotizacionDetalle
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
		Public Shared Sub Insert(ByVal varNCodCotizacionDetalle As Integer,ByVal varNCodCotizacion As Integer,ByVal varNCodProducto As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varNCantidad As Integer,ByVal varNDescuento As Decimal,ByVal varBUnidad As Boolean,ByVal varBDocena As Boolean,ByVal varBCien As Boolean,ByVal varBMil As Boolean)
			Dim item As CotizacionDetalle = New CotizacionDetalle()
			
            item.NCodCotizacionDetalle = varNCodCotizacionDetalle
            
            item.NCodCotizacion = varNCodCotizacion
            
            item.NCodProducto = varNCodProducto
            
            item.NPrecioUnitario = varNPrecioUnitario
            
            item.NCantidad = varNCantidad
            
            item.NDescuento = varNDescuento
            
            item.BUnidad = varBUnidad
            
            item.BDocena = varBDocena
            
            item.BCien = varBCien
            
            item.BMil = varBMil
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodCotizacionDetalle As Integer,ByVal varNCodCotizacion As Integer,ByVal varNCodProducto As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varNCantidad As Integer,ByVal varNDescuento As Decimal,ByVal varBUnidad As Boolean,ByVal varBDocena As Boolean,ByVal varBCien As Boolean,ByVal varBMil As Boolean)
			Dim item As CotizacionDetalle = New CotizacionDetalle()
		    
                item.NCodCotizacionDetalle = varNCodCotizacionDetalle
				
                item.NCodCotizacion = varNCodCotizacion
				
                item.NCodProducto = varNCodProducto
				
                item.NPrecioUnitario = varNPrecioUnitario
				
                item.NCantidad = varNCantidad
				
                item.NDescuento = varNDescuento
				
                item.BUnidad = varBUnidad
				
                item.BDocena = varBDocena
				
                item.BCien = varBCien
				
                item.BMil = varBMil
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodCotizacionDetalleColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodCotizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioUnitarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCantidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NDescuentoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BDocenaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BCienColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BMilColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodCotizacionDetalle As String = "nCodCotizacionDetalle"
            
            Public Shared NCodCotizacion As String = "nCodCotizacion"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared NPrecioUnitario As String = "nPrecioUnitario"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared NDescuento As String = "nDescuento"
            
            Public Shared BUnidad As String = "bUnidad"
            
            Public Shared BDocena As String = "bDocena"
            
            Public Shared BCien As String = "bCien"
            
            Public Shared BMil As String = "bMil"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
