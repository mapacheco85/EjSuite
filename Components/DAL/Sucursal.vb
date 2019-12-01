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
	''' Strongly-typed collection for the Sucursal class.
	''' </summary>
	<Serializable> _
	Public Partial Class SucursalCollection 
	Inherits ActiveList(Of Sucursal, SucursalCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As SucursalCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Sucursal = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Sucursal table.
	''' </summary>
	<Serializable> _
	Public Partial Class Sucursal 
	Inherits ActiveRecord(Of Sucursal)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Sucursal", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodSucursal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = false
                colvarNCodSucursal.IsNullable = false
                colvarNCodSucursal.IsPrimaryKey = true
                colvarNCodSucursal.IsForeignKey = false
                colvarNCodSucursal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarNCodRegion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodRegion.ColumnName = "nCodRegion"
                colvarNCodRegion.DataType = DbType.Int32
                colvarNCodRegion.MaxLength = 0
                colvarNCodRegion.AutoIncrement = false
                colvarNCodRegion.IsNullable = true
                colvarNCodRegion.IsPrimaryKey = false
                colvarNCodRegion.IsForeignKey = true
                colvarNCodRegion.IsReadOnly = false
                
                
				colvarNCodRegion.ForeignKeyTableName = "EJS_Region"
                
                schema.Columns.Add(colvarNCodRegion)
                
                Dim colvarCZona As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCZona.ColumnName = "cZona"
                colvarCZona.DataType = DbType.AnsiString
                colvarCZona.MaxLength = 255
                colvarCZona.AutoIncrement = false
                colvarCZona.IsNullable = false
                colvarCZona.IsPrimaryKey = false
                colvarCZona.IsForeignKey = false
                colvarCZona.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCZona)
                
                Dim colvarCDireccion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDireccion.ColumnName = "cDireccion"
                colvarCDireccion.DataType = DbType.AnsiString
                colvarCDireccion.MaxLength = 255
                colvarCDireccion.AutoIncrement = false
                colvarCDireccion.IsNullable = false
                colvarCDireccion.IsPrimaryKey = false
                colvarCDireccion.IsForeignKey = false
                colvarCDireccion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDireccion)
                
                Dim colvarBCasaMatriz As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBCasaMatriz.ColumnName = "bCasaMatriz"
                colvarBCasaMatriz.DataType = DbType.Boolean
                colvarBCasaMatriz.MaxLength = 0
                colvarBCasaMatriz.AutoIncrement = false
                colvarBCasaMatriz.IsNullable = false
                colvarBCasaMatriz.IsPrimaryKey = false
                colvarBCasaMatriz.IsForeignKey = false
                colvarBCasaMatriz.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBCasaMatriz)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Sucursal",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodSucursal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSucursal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodRegion")> _
        Public Property NCodRegion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodRegion)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodRegion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CZona")> _
        Public Property CZona As String 
			Get
				Return GetColumnValue(Of String)(Columns.CZona)
			End Get
		    
			Set
				SetColumnValue(Columns.CZona, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDireccion")> _
        Public Property CDireccion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDireccion)
			End Get
		    
			Set
				SetColumnValue(Columns.CDireccion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BCasaMatriz")> _
        Public Property BCasaMatriz As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BCasaMatriz)
			End Get
		    
			Set
				SetColumnValue(Columns.BCasaMatriz, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function AlmacenRecords() As EjSuite.AlmacenCollection 
	
				Return New EjSuite.AlmacenCollection().Where(Almacen.Columns.NCodSucursal, NCodSucursal).Load()
	
			End Function
			
			Public Function EmpleadoSucursalRecords() As EjSuite.EmpleadoSucursalCollection 
	
				Return New EjSuite.EmpleadoSucursalCollection().Where(EmpleadoSucursal.Columns.NCodSucursal, NCodSucursal).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Region ActiveRecord object related to this Sucursal
		''' </summary>
		Public Property Region() As EjSuite.Region
			Get
				Return EjSuite.Region.FetchByID(Me.NCodRegion)
			End Get
			Set
				SetColumnValue("nCodRegion", Value.NCodRegion)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodSucursal As Integer,ByVal varNCodRegion As Nullable(Of Integer),ByVal varCZona As String,ByVal varCDireccion As String,ByVal varBCasaMatriz As Boolean)
			Dim item As Sucursal = New Sucursal()
			
            item.NCodSucursal = varNCodSucursal
            
            item.NCodRegion = varNCodRegion
            
            item.CZona = varCZona
            
            item.CDireccion = varCDireccion
            
            item.BCasaMatriz = varBCasaMatriz
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodSucursal As Integer,ByVal varNCodRegion As Nullable(Of Integer),ByVal varCZona As String,ByVal varCDireccion As String,ByVal varBCasaMatriz As Boolean)
			Dim item As Sucursal = New Sucursal()
		    
                item.NCodSucursal = varNCodSucursal
				
                item.NCodRegion = varNCodRegion
				
                item.CZona = varCZona
				
                item.CDireccion = varCDireccion
				
                item.BCasaMatriz = varBCasaMatriz
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodRegionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CZonaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BCasaMatrizColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared NCodRegion As String = "nCodRegion"
            
            Public Shared CZona As String = "cZona"
            
            Public Shared CDireccion As String = "cDireccion"
            
            Public Shared BCasaMatriz As String = "bCasaMatriz"
            
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
