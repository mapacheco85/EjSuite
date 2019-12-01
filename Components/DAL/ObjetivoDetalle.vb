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
	''' Strongly-typed collection for the ObjetivoDetalle class.
	''' </summary>
	<Serializable> _
	Public Partial Class ObjetivoDetalleCollection 
	Inherits ActiveList(Of ObjetivoDetalle, ObjetivoDetalleCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ObjetivoDetalleCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As ObjetivoDetalle = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_ObjetivoDetalle table.
	''' </summary>
	<Serializable> _
	Public Partial Class ObjetivoDetalle 
	Inherits ActiveRecord(Of ObjetivoDetalle)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_ObjetivoDetalle", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodObjetivoDetalle As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodObjetivoDetalle.ColumnName = "nCodObjetivoDetalle"
                colvarNCodObjetivoDetalle.DataType = DbType.Int32
                colvarNCodObjetivoDetalle.MaxLength = 0
                colvarNCodObjetivoDetalle.AutoIncrement = false
                colvarNCodObjetivoDetalle.IsNullable = false
                colvarNCodObjetivoDetalle.IsPrimaryKey = true
                colvarNCodObjetivoDetalle.IsForeignKey = false
                colvarNCodObjetivoDetalle.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodObjetivoDetalle)
                
                Dim colvarNCodObjetivo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodObjetivo.ColumnName = "nCodObjetivo"
                colvarNCodObjetivo.DataType = DbType.Int32
                colvarNCodObjetivo.MaxLength = 0
                colvarNCodObjetivo.AutoIncrement = false
                colvarNCodObjetivo.IsNullable = true
                colvarNCodObjetivo.IsPrimaryKey = false
                colvarNCodObjetivo.IsForeignKey = true
                colvarNCodObjetivo.IsReadOnly = false
                
                
				colvarNCodObjetivo.ForeignKeyTableName = "EJS_Objetivo"
                
                schema.Columns.Add(colvarNCodObjetivo)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.AnsiString
                colvarNCodProducto.MaxLength = 50
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = false
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = false
                colvarNCodProducto.IsReadOnly = false
                
                
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
                
                Dim colvarNMonto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMonto.ColumnName = "nMonto"
                colvarNMonto.DataType = DbType.Currency
                colvarNMonto.MaxLength = 0
                colvarNMonto.AutoIncrement = false
                colvarNMonto.IsNullable = false
                colvarNMonto.IsPrimaryKey = false
                colvarNMonto.IsForeignKey = false
                colvarNMonto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMonto)
                
                Dim colvarNValorNumerico As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNValorNumerico.ColumnName = "nValorNumerico"
                colvarNValorNumerico.DataType = DbType.Decimal
                colvarNValorNumerico.MaxLength = 0
                colvarNValorNumerico.AutoIncrement = false
                colvarNValorNumerico.IsNullable = false
                colvarNValorNumerico.IsPrimaryKey = false
                colvarNValorNumerico.IsForeignKey = false
                colvarNValorNumerico.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNValorNumerico)
                
                Dim colvarNValorLiteral As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNValorLiteral.ColumnName = "nValorLiteral"
                colvarNValorLiteral.DataType = DbType.AnsiString
                colvarNValorLiteral.MaxLength = 500
                colvarNValorLiteral.AutoIncrement = false
                colvarNValorLiteral.IsNullable = false
                colvarNValorLiteral.IsPrimaryKey = false
                colvarNValorLiteral.IsForeignKey = false
                colvarNValorLiteral.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNValorLiteral)
                
                Dim colvarNFecha As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNFecha.ColumnName = "nFecha"
                colvarNFecha.DataType = DbType.AnsiString
                colvarNFecha.MaxLength = 0
                colvarNFecha.AutoIncrement = false
                colvarNFecha.IsNullable = false
                colvarNFecha.IsPrimaryKey = false
                colvarNFecha.IsForeignKey = false
                colvarNFecha.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNFecha)
                
                Dim colvarCDescripcion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDescripcion.ColumnName = "cDescripcion"
                colvarCDescripcion.DataType = DbType.AnsiString
                colvarCDescripcion.MaxLength = 50
                colvarCDescripcion.AutoIncrement = false
                colvarCDescripcion.IsNullable = false
                colvarCDescripcion.IsPrimaryKey = false
                colvarCDescripcion.IsForeignKey = false
                colvarCDescripcion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDescripcion)
                
                Dim colvarBTieneDescripcion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBTieneDescripcion.ColumnName = "bTieneDescripcion"
                colvarBTieneDescripcion.DataType = DbType.Boolean
                colvarBTieneDescripcion.MaxLength = 0
                colvarBTieneDescripcion.AutoIncrement = false
                colvarBTieneDescripcion.IsNullable = false
                colvarBTieneDescripcion.IsPrimaryKey = false
                colvarBTieneDescripcion.IsForeignKey = false
                colvarBTieneDescripcion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBTieneDescripcion)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_ObjetivoDetalle",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodObjetivoDetalle")> _
        Public Property NCodObjetivoDetalle As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodObjetivoDetalle)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodObjetivoDetalle, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodObjetivo")> _
        Public Property NCodObjetivo As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodObjetivo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodObjetivo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As String 
			Get
				Return GetColumnValue(Of String)(Columns.NCodProducto)
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
        <XmlAttribute("NMonto")> _
        Public Property NMonto As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NMonto)
			End Get
		    
			Set
				SetColumnValue(Columns.NMonto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NValorNumerico")> _
        Public Property NValorNumerico As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NValorNumerico)
			End Get
		    
			Set
				SetColumnValue(Columns.NValorNumerico, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NValorLiteral")> _
        Public Property NValorLiteral As String 
			Get
				Return GetColumnValue(Of String)(Columns.NValorLiteral)
			End Get
		    
			Set
				SetColumnValue(Columns.NValorLiteral, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NFecha")> _
        Public Property NFecha As String 
			Get
				Return GetColumnValue(Of String)(Columns.NFecha)
			End Get
		    
			Set
				SetColumnValue(Columns.NFecha, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDescripcion")> _
        Public Property CDescripcion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDescripcion)
			End Get
		    
			Set
				SetColumnValue(Columns.CDescripcion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BTieneDescripcion")> _
        Public Property BTieneDescripcion As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BTieneDescripcion)
			End Get
		    
			Set
				SetColumnValue(Columns.BTieneDescripcion, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Objetivo ActiveRecord object related to this ObjetivoDetalle
		''' </summary>
		Public Property Objetivo() As EjSuite.Objetivo
			Get
				Return EjSuite.Objetivo.FetchByID(Me.NCodObjetivo)
			End Get
			Set
				SetColumnValue("nCodObjetivo", Value.NCodObjetivo)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodObjetivoDetalle As Integer,ByVal varNCodObjetivo As Nullable(Of Integer),ByVal varNCodProducto As String,ByVal varNCantidad As Integer,ByVal varNMonto As Decimal,ByVal varNValorNumerico As Decimal,ByVal varNValorLiteral As String,ByVal varNFecha As String,ByVal varCDescripcion As String,ByVal varBTieneDescripcion As Boolean)
			Dim item As ObjetivoDetalle = New ObjetivoDetalle()
			
            item.NCodObjetivoDetalle = varNCodObjetivoDetalle
            
            item.NCodObjetivo = varNCodObjetivo
            
            item.NCodProducto = varNCodProducto
            
            item.NCantidad = varNCantidad
            
            item.NMonto = varNMonto
            
            item.NValorNumerico = varNValorNumerico
            
            item.NValorLiteral = varNValorLiteral
            
            item.NFecha = varNFecha
            
            item.CDescripcion = varCDescripcion
            
            item.BTieneDescripcion = varBTieneDescripcion
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodObjetivoDetalle As Integer,ByVal varNCodObjetivo As Nullable(Of Integer),ByVal varNCodProducto As String,ByVal varNCantidad As Integer,ByVal varNMonto As Decimal,ByVal varNValorNumerico As Decimal,ByVal varNValorLiteral As String,ByVal varNFecha As String,ByVal varCDescripcion As String,ByVal varBTieneDescripcion As Boolean)
			Dim item As ObjetivoDetalle = New ObjetivoDetalle()
		    
                item.NCodObjetivoDetalle = varNCodObjetivoDetalle
				
                item.NCodObjetivo = varNCodObjetivo
				
                item.NCodProducto = varNCodProducto
				
                item.NCantidad = varNCantidad
				
                item.NMonto = varNMonto
				
                item.NValorNumerico = varNValorNumerico
				
                item.NValorLiteral = varNValorLiteral
				
                item.NFecha = varNFecha
				
                item.CDescripcion = varCDescripcion
				
                item.BTieneDescripcion = varBTieneDescripcion
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodObjetivoDetalleColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodObjetivoColumn() As TableSchema.TableColumn
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
        
        
        Public Shared ReadOnly Property NMontoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NValorNumericoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NValorLiteralColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NFechaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDescripcionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BTieneDescripcionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodObjetivoDetalle As String = "nCodObjetivoDetalle"
            
            Public Shared NCodObjetivo As String = "nCodObjetivo"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared NMonto As String = "nMonto"
            
            Public Shared NValorNumerico As String = "nValorNumerico"
            
            Public Shared NValorLiteral As String = "nValorLiteral"
            
            Public Shared NFecha As String = "nFecha"
            
            Public Shared CDescripcion As String = "cDescripcion"
            
            Public Shared BTieneDescripcion As String = "bTieneDescripcion"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
