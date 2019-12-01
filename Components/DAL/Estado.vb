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
	''' Strongly-typed collection for the Estado class.
	''' </summary>
	<Serializable> _
	Public Partial Class EstadoCollection 
	Inherits ActiveList(Of Estado, EstadoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As EstadoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Estado = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Estado table.
	''' </summary>
	<Serializable> _
	Public Partial Class Estado 
	Inherits ActiveRecord(Of Estado)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Estado", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodEstado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEstado.ColumnName = "nCodEstado"
                colvarNCodEstado.DataType = DbType.Int32
                colvarNCodEstado.MaxLength = 0
                colvarNCodEstado.AutoIncrement = false
                colvarNCodEstado.IsNullable = false
                colvarNCodEstado.IsPrimaryKey = true
                colvarNCodEstado.IsForeignKey = false
                colvarNCodEstado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodEstado)
                
                Dim colvarNCodAjuste As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodAjuste.ColumnName = "nCodAjuste"
                colvarNCodAjuste.DataType = DbType.Int32
                colvarNCodAjuste.MaxLength = 0
                colvarNCodAjuste.AutoIncrement = false
                colvarNCodAjuste.IsNullable = false
                colvarNCodAjuste.IsPrimaryKey = false
                colvarNCodAjuste.IsForeignKey = false
                colvarNCodAjuste.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodAjuste)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = true
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
                
                Dim colvarBCentenas As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBCentenas.ColumnName = "bCentenas"
                colvarBCentenas.DataType = DbType.Boolean
                colvarBCentenas.MaxLength = 0
                colvarBCentenas.AutoIncrement = false
                colvarBCentenas.IsNullable = false
                colvarBCentenas.IsPrimaryKey = false
                colvarBCentenas.IsForeignKey = false
                colvarBCentenas.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBCentenas)
                
                Dim colvarBMiles As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBMiles.ColumnName = "bMiles"
                colvarBMiles.DataType = DbType.Boolean
                colvarBMiles.MaxLength = 0
                colvarBMiles.AutoIncrement = false
                colvarBMiles.IsNullable = false
                colvarBMiles.IsPrimaryKey = false
                colvarBMiles.IsForeignKey = false
                colvarBMiles.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBMiles)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Estado",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodEstado")> _
        Public Property NCodEstado As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodEstado)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEstado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodAjuste")> _
        Public Property NCodAjuste As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodAjuste)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodAjuste, Value)
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
        <XmlAttribute("BCentenas")> _
        Public Property BCentenas As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BCentenas)
			End Get
		    
			Set
				SetColumnValue(Columns.BCentenas, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BMiles")> _
        Public Property BMiles As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BMiles)
			End Get
		    
			Set
				SetColumnValue(Columns.BMiles, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodEstado As Integer,ByVal varNCodAjuste As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varNCantidad As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varBUnidad As Boolean,ByVal varBDocena As Boolean,ByVal varBCentenas As Boolean,ByVal varBMiles As Boolean)
			Dim item As Estado = New Estado()
			
            item.NCodEstado = varNCodEstado
            
            item.NCodAjuste = varNCodAjuste
            
            item.NCodProducto = varNCodProducto
            
            item.NCantidad = varNCantidad
            
            item.NPrecioUnitario = varNPrecioUnitario
            
            item.BUnidad = varBUnidad
            
            item.BDocena = varBDocena
            
            item.BCentenas = varBCentenas
            
            item.BMiles = varBMiles
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodEstado As Integer,ByVal varNCodAjuste As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varNCantidad As Integer,ByVal varNPrecioUnitario As Decimal,ByVal varBUnidad As Boolean,ByVal varBDocena As Boolean,ByVal varBCentenas As Boolean,ByVal varBMiles As Boolean)
			Dim item As Estado = New Estado()
		    
                item.NCodEstado = varNCodEstado
				
                item.NCodAjuste = varNCodAjuste
				
                item.NCodProducto = varNCodProducto
				
                item.NCantidad = varNCantidad
				
                item.NPrecioUnitario = varNPrecioUnitario
				
                item.BUnidad = varBUnidad
				
                item.BDocena = varBDocena
				
                item.BCentenas = varBCentenas
				
                item.BMiles = varBMiles
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodEstadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodAjusteColumn() As TableSchema.TableColumn
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
        
        
        Public Shared ReadOnly Property BUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BDocenaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BCentenasColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BMilesColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodEstado As String = "nCodEstado"
            
            Public Shared NCodAjuste As String = "nCodAjuste"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared NPrecioUnitario As String = "nPrecioUnitario"
            
            Public Shared BUnidad As String = "bUnidad"
            
            Public Shared BDocena As String = "bDocena"
            
            Public Shared BCentenas As String = "bCentenas"
            
            Public Shared BMiles As String = "bMiles"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
