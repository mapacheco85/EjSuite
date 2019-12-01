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
	''' Strongly-typed collection for the Region class.
	''' </summary>
	<Serializable> _
	Public Partial Class RegionCollection 
	Inherits ActiveList(Of Region, RegionCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As RegionCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Region = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Region table.
	''' </summary>
	<Serializable> _
	Public Partial Class Region 
	Inherits ActiveRecord(Of Region)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Region", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodRegion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodRegion.ColumnName = "nCodRegion"
                colvarNCodRegion.DataType = DbType.Int32
                colvarNCodRegion.MaxLength = 0
                colvarNCodRegion.AutoIncrement = false
                colvarNCodRegion.IsNullable = false
                colvarNCodRegion.IsPrimaryKey = true
                colvarNCodRegion.IsForeignKey = false
                colvarNCodRegion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodRegion)
                
                Dim colvarCLugar As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCLugar.ColumnName = "cLugar"
                colvarCLugar.DataType = DbType.AnsiString
                colvarCLugar.MaxLength = 255
                colvarCLugar.AutoIncrement = false
                colvarCLugar.IsNullable = false
                colvarCLugar.IsPrimaryKey = false
                colvarCLugar.IsForeignKey = false
                colvarCLugar.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCLugar)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Region",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodRegion")> _
        Public Property NCodRegion As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodRegion)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodRegion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CLugar")> _
        Public Property CLugar As String 
			Get
				Return GetColumnValue(Of String)(Columns.CLugar)
			End Get
		    
			Set
				SetColumnValue(Columns.CLugar, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function SucursalRecords() As EjSuite.SucursalCollection 
	
				Return New EjSuite.SucursalCollection().Where(Sucursal.Columns.NCodRegion, NCodRegion).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodRegion As Integer,ByVal varCLugar As String)
			Dim item As Region = New Region()
			
            item.NCodRegion = varNCodRegion
            
            item.CLugar = varCLugar
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodRegion As Integer,ByVal varCLugar As String)
			Dim item As Region = New Region()
		    
                item.NCodRegion = varNCodRegion
				
                item.CLugar = varCLugar
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodRegionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CLugarColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodRegion As String = "nCodRegion"
            
            Public Shared CLugar As String = "cLugar"
            
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
