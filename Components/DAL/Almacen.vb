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
	''' Strongly-typed collection for the Almacen class.
	''' </summary>
	<Serializable> _
	Public Partial Class AlmacenCollection 
	Inherits ActiveList(Of Almacen, AlmacenCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As AlmacenCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Almacen = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Almacen table.
	''' </summary>
	<Serializable> _
	Public Partial Class Almacen 
	Inherits ActiveRecord(Of Almacen)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Almacen", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodAlmacen As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodAlmacen.ColumnName = "nCodAlmacen"
                colvarNCodAlmacen.DataType = DbType.Int32
                colvarNCodAlmacen.MaxLength = 0
                colvarNCodAlmacen.AutoIncrement = false
                colvarNCodAlmacen.IsNullable = false
                colvarNCodAlmacen.IsPrimaryKey = true
                colvarNCodAlmacen.IsForeignKey = false
                colvarNCodAlmacen.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodAlmacen)
                
                Dim colvarNCodSucursal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = false
                colvarNCodSucursal.IsNullable = true
                colvarNCodSucursal.IsPrimaryKey = false
                colvarNCodSucursal.IsForeignKey = true
                colvarNCodSucursal.IsReadOnly = false
                
                
				colvarNCodSucursal.ForeignKeyTableName = "EJS_Sucursal"
                
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarNCodJefeAlmacen As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodJefeAlmacen.ColumnName = "nCodJefeAlmacen"
                colvarNCodJefeAlmacen.DataType = DbType.Int32
                colvarNCodJefeAlmacen.MaxLength = 0
                colvarNCodJefeAlmacen.AutoIncrement = false
                colvarNCodJefeAlmacen.IsNullable = true
                colvarNCodJefeAlmacen.IsPrimaryKey = false
                colvarNCodJefeAlmacen.IsForeignKey = false
                colvarNCodJefeAlmacen.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodJefeAlmacen)
                
                Dim colvarCCapacidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCapacidad.ColumnName = "cCapacidad"
                colvarCCapacidad.DataType = DbType.AnsiString
                colvarCCapacidad.MaxLength = 255
                colvarCCapacidad.AutoIncrement = false
                colvarCCapacidad.IsNullable = true
                colvarCCapacidad.IsPrimaryKey = false
                colvarCCapacidad.IsForeignKey = false
                colvarCCapacidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCapacidad)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Almacen",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodAlmacen")> _
        Public Property NCodAlmacen As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodAlmacen)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodAlmacen, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodSucursal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSucursal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodJefeAlmacen")> _
        Public Property NCodJefeAlmacen As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodJefeAlmacen)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodJefeAlmacen, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCapacidad")> _
        Public Property CCapacidad As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCapacidad)
			End Get
		    
			Set
				SetColumnValue(Columns.CCapacidad, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function KardexInventarioRecords() As EjSuite.KardexInventarioCollection 
	
				Return New EjSuite.KardexInventarioCollection().Where(KardexInventario.Columns.NCodAlmacen, NCodAlmacen).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Sucursal ActiveRecord object related to this Almacen
		''' </summary>
		Public Property Sucursal() As EjSuite.Sucursal
			Get
				Return EjSuite.Sucursal.FetchByID(Me.NCodSucursal)
			End Get
			Set
				SetColumnValue("nCodSucursal", Value.NCodSucursal)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodAlmacen As Integer,ByVal varNCodSucursal As Nullable(Of Integer),ByVal varNCodJefeAlmacen As Nullable(Of Integer),ByVal varCCapacidad As String)
			Dim item As Almacen = New Almacen()
			
            item.NCodAlmacen = varNCodAlmacen
            
            item.NCodSucursal = varNCodSucursal
            
            item.NCodJefeAlmacen = varNCodJefeAlmacen
            
            item.CCapacidad = varCCapacidad
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodAlmacen As Integer,ByVal varNCodSucursal As Nullable(Of Integer),ByVal varNCodJefeAlmacen As Nullable(Of Integer),ByVal varCCapacidad As String)
			Dim item As Almacen = New Almacen()
		    
                item.NCodAlmacen = varNCodAlmacen
				
                item.NCodSucursal = varNCodSucursal
				
                item.NCodJefeAlmacen = varNCodJefeAlmacen
				
                item.CCapacidad = varCCapacidad
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodAlmacenColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodJefeAlmacenColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCapacidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodAlmacen As String = "nCodAlmacen"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared NCodJefeAlmacen As String = "nCodJefeAlmacen"
            
            Public Shared CCapacidad As String = "cCapacidad"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        Public Sub SetPKValues()
        End Sub
        #End Region
        
        #Region "Deep Save"
		
        Public Sub DeepSave()
            Save()
            
        End Sub
        #End Region
        
	End Class
End Namespace
