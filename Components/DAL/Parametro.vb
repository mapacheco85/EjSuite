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
	''' Strongly-typed collection for the Parametro class.
	''' </summary>
	<Serializable> _
	Public Partial Class ParametroCollection 
	Inherits ActiveList(Of Parametro, ParametroCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ParametroCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Parametro = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Parametro table.
	''' </summary>
	<Serializable> _
	Public Partial Class Parametro 
	Inherits ActiveRecord(Of Parametro)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Parametro", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodParametro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodParametro.ColumnName = "nCodParametro"
                colvarNCodParametro.DataType = DbType.Int32
                colvarNCodParametro.MaxLength = 0
                colvarNCodParametro.AutoIncrement = false
                colvarNCodParametro.IsNullable = false
                colvarNCodParametro.IsPrimaryKey = true
                colvarNCodParametro.IsForeignKey = false
                colvarNCodParametro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodParametro)
                
                Dim colvarCDescripcionParametro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDescripcionParametro.ColumnName = "cDescripcionParametro"
                colvarCDescripcionParametro.DataType = DbType.AnsiString
                colvarCDescripcionParametro.MaxLength = 255
                colvarCDescripcionParametro.AutoIncrement = false
                colvarCDescripcionParametro.IsNullable = false
                colvarCDescripcionParametro.IsPrimaryKey = false
                colvarCDescripcionParametro.IsForeignKey = false
                colvarCDescripcionParametro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDescripcionParametro)
                
                Dim colvarNTipoParametro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNTipoParametro.ColumnName = "nTipoParametro"
                colvarNTipoParametro.DataType = DbType.Int32
                colvarNTipoParametro.MaxLength = 0
                colvarNTipoParametro.AutoIncrement = false
                colvarNTipoParametro.IsNullable = false
                colvarNTipoParametro.IsPrimaryKey = false
                colvarNTipoParametro.IsForeignKey = false
                colvarNTipoParametro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNTipoParametro)
                
                Dim colvarCValorParametro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCValorParametro.ColumnName = "cValorParametro"
                colvarCValorParametro.DataType = DbType.AnsiString
                colvarCValorParametro.MaxLength = 255
                colvarCValorParametro.AutoIncrement = false
                colvarCValorParametro.IsNullable = false
                colvarCValorParametro.IsPrimaryKey = false
                colvarCValorParametro.IsForeignKey = false
                colvarCValorParametro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCValorParametro)
                
                Dim colvarBVigente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBVigente.ColumnName = "bVigente"
                colvarBVigente.DataType = DbType.Boolean
                colvarBVigente.MaxLength = 0
                colvarBVigente.AutoIncrement = false
                colvarBVigente.IsNullable = true
                colvarBVigente.IsPrimaryKey = false
                colvarBVigente.IsForeignKey = false
                colvarBVigente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBVigente)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Parametro",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodParametro")> _
        Public Property NCodParametro As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodParametro)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodParametro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDescripcionParametro")> _
        Public Property CDescripcionParametro As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDescripcionParametro)
			End Get
		    
			Set
				SetColumnValue(Columns.CDescripcionParametro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NTipoParametro")> _
        Public Property NTipoParametro As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NTipoParametro)
			End Get
		    
			Set
				SetColumnValue(Columns.NTipoParametro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CValorParametro")> _
        Public Property CValorParametro As String 
			Get
				Return GetColumnValue(Of String)(Columns.CValorParametro)
			End Get
		    
			Set
				SetColumnValue(Columns.CValorParametro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BVigente")> _
        Public Property BVigente As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BVigente)
			End Get
		    
			Set
				SetColumnValue(Columns.BVigente, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodParametro As Integer,ByVal varCDescripcionParametro As String,ByVal varNTipoParametro As Integer,ByVal varCValorParametro As String,ByVal varBVigente As Nullable(Of Boolean))
			Dim item As Parametro = New Parametro()
			
            item.NCodParametro = varNCodParametro
            
            item.CDescripcionParametro = varCDescripcionParametro
            
            item.NTipoParametro = varNTipoParametro
            
            item.CValorParametro = varCValorParametro
            
            item.BVigente = varBVigente
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodParametro As Integer,ByVal varCDescripcionParametro As String,ByVal varNTipoParametro As Integer,ByVal varCValorParametro As String,ByVal varBVigente As Nullable(Of Boolean))
			Dim item As Parametro = New Parametro()
		    
                item.NCodParametro = varNCodParametro
				
                item.CDescripcionParametro = varCDescripcionParametro
				
                item.NTipoParametro = varNTipoParametro
				
                item.CValorParametro = varCValorParametro
				
                item.BVigente = varBVigente
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodParametroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDescripcionParametroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NTipoParametroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CValorParametroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BVigenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodParametro As String = "nCodParametro"
            
            Public Shared CDescripcionParametro As String = "cDescripcionParametro"
            
            Public Shared NTipoParametro As String = "nTipoParametro"
            
            Public Shared CValorParametro As String = "cValorParametro"
            
            Public Shared BVigente As String = "bVigente"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
