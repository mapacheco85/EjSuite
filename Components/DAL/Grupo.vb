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
	''' Strongly-typed collection for the Grupo class.
	''' </summary>
	<Serializable> _
	Public Partial Class GrupoCollection 
	Inherits ActiveList(Of Grupo, GrupoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As GrupoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Grupo = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Grupo table.
	''' </summary>
	<Serializable> _
	Public Partial Class Grupo 
	Inherits ActiveRecord(Of Grupo)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Grupo", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodGrupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodGrupo.ColumnName = "nCodGrupo"
                colvarNCodGrupo.DataType = DbType.Int32
                colvarNCodGrupo.MaxLength = 0
                colvarNCodGrupo.AutoIncrement = false
                colvarNCodGrupo.IsNullable = false
                colvarNCodGrupo.IsPrimaryKey = true
                colvarNCodGrupo.IsForeignKey = false
                colvarNCodGrupo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodGrupo)
                
                Dim colvarCTipoGrupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTipoGrupo.ColumnName = "cTipoGrupo"
                colvarCTipoGrupo.DataType = DbType.AnsiString
                colvarCTipoGrupo.MaxLength = 5
                colvarCTipoGrupo.AutoIncrement = false
                colvarCTipoGrupo.IsNullable = false
                colvarCTipoGrupo.IsPrimaryKey = false
                colvarCTipoGrupo.IsForeignKey = false
                colvarCTipoGrupo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTipoGrupo)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Grupo",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodGrupo")> _
        Public Property NCodGrupo As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodGrupo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodGrupo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTipoGrupo")> _
        Public Property CTipoGrupo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTipoGrupo)
			End Get
		    
			Set
				SetColumnValue(Columns.CTipoGrupo, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function ListadoProductoRecords() As EjSuite.ListadoProductoCollection 
	
				Return New EjSuite.ListadoProductoCollection().Where(ListadoProducto.Columns.NCodGrupo, NCodGrupo).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodGrupo As Integer,ByVal varCTipoGrupo As String)
			Dim item As Grupo = New Grupo()
			
            item.NCodGrupo = varNCodGrupo
            
            item.CTipoGrupo = varCTipoGrupo
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodGrupo As Integer,ByVal varCTipoGrupo As String)
			Dim item As Grupo = New Grupo()
		    
                item.NCodGrupo = varNCodGrupo
				
                item.CTipoGrupo = varCTipoGrupo
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodGrupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTipoGrupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodGrupo As String = "nCodGrupo"
            
            Public Shared CTipoGrupo As String = "cTipoGrupo"
            
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
