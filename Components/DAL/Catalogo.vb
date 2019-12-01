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
	''' Strongly-typed collection for the Catalogo class.
	''' </summary>
	<Serializable> _
	Public Partial Class CatalogoCollection 
	Inherits ActiveList(Of Catalogo, CatalogoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As CatalogoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Catalogo = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Catalogo table.
	''' </summary>
	<Serializable> _
	Public Partial Class Catalogo 
	Inherits ActiveRecord(Of Catalogo)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Catalogo", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodCatalogo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCatalogo.ColumnName = "nCodCatalogo"
                colvarNCodCatalogo.DataType = DbType.Int32
                colvarNCodCatalogo.MaxLength = 0
                colvarNCodCatalogo.AutoIncrement = false
                colvarNCodCatalogo.IsNullable = false
                colvarNCodCatalogo.IsPrimaryKey = true
                colvarNCodCatalogo.IsForeignKey = false
                colvarNCodCatalogo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCatalogo)
                
                Dim colvarCValorCatalogo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCValorCatalogo.ColumnName = "cValorCatalogo"
                colvarCValorCatalogo.DataType = DbType.AnsiString
                colvarCValorCatalogo.MaxLength = 255
                colvarCValorCatalogo.AutoIncrement = false
                colvarCValorCatalogo.IsNullable = false
                colvarCValorCatalogo.IsPrimaryKey = false
                colvarCValorCatalogo.IsForeignKey = false
                colvarCValorCatalogo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCValorCatalogo)
                
                Dim colvarCCodCatalogo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCodCatalogo.ColumnName = "cCodCatalogo"
                colvarCCodCatalogo.DataType = DbType.AnsiString
                colvarCCodCatalogo.MaxLength = 255
                colvarCCodCatalogo.AutoIncrement = false
                colvarCCodCatalogo.IsNullable = false
                colvarCCodCatalogo.IsPrimaryKey = true
                colvarCCodCatalogo.IsForeignKey = false
                colvarCCodCatalogo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCodCatalogo)
                
                Dim colvarBVigente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBVigente.ColumnName = "bVigente"
                colvarBVigente.DataType = DbType.Boolean
                colvarBVigente.MaxLength = 0
                colvarBVigente.AutoIncrement = false
                colvarBVigente.IsNullable = false
                colvarBVigente.IsPrimaryKey = false
                colvarBVigente.IsForeignKey = false
                colvarBVigente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBVigente)
                
                Dim colvarNDependeDe As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNDependeDe.ColumnName = "nDependeDe"
                colvarNDependeDe.DataType = DbType.Int32
                colvarNDependeDe.MaxLength = 0
                colvarNDependeDe.AutoIncrement = false
                colvarNDependeDe.IsNullable = true
                colvarNDependeDe.IsPrimaryKey = false
                colvarNDependeDe.IsForeignKey = false
                colvarNDependeDe.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNDependeDe)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Catalogo",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodCatalogo")> _
        Public Property NCodCatalogo As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCatalogo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCatalogo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CValorCatalogo")> _
        Public Property CValorCatalogo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CValorCatalogo)
			End Get
		    
			Set
				SetColumnValue(Columns.CValorCatalogo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCodCatalogo")> _
        Public Property CCodCatalogo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCodCatalogo)
			End Get
		    
			Set
				SetColumnValue(Columns.CCodCatalogo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BVigente")> _
        Public Property BVigente As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BVigente)
			End Get
		    
			Set
				SetColumnValue(Columns.BVigente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NDependeDe")> _
        Public Property NDependeDe As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NDependeDe)
			End Get
		    
			Set
				SetColumnValue(Columns.NDependeDe, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodCatalogo As Integer,ByVal varCValorCatalogo As String,ByVal varCCodCatalogo As String,ByVal varBVigente As Boolean,ByVal varNDependeDe As Nullable(Of Integer))
			Dim item As Catalogo = New Catalogo()
			
            item.NCodCatalogo = varNCodCatalogo
            
            item.CValorCatalogo = varCValorCatalogo
            
            item.CCodCatalogo = varCCodCatalogo
            
            item.BVigente = varBVigente
            
            item.NDependeDe = varNDependeDe
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodCatalogo As Integer,ByVal varCValorCatalogo As String,ByVal varCCodCatalogo As String,ByVal varBVigente As Boolean,ByVal varNDependeDe As Nullable(Of Integer))
			Dim item As Catalogo = New Catalogo()
		    
                item.NCodCatalogo = varNCodCatalogo
				
                item.CValorCatalogo = varCValorCatalogo
				
                item.CCodCatalogo = varCCodCatalogo
				
                item.BVigente = varBVigente
				
                item.NDependeDe = varNDependeDe
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodCatalogoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CValorCatalogoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCodCatalogoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BVigenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NDependeDeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodCatalogo As String = "nCodCatalogo"
            
            Public Shared CValorCatalogo As String = "cValorCatalogo"
            
            Public Shared CCodCatalogo As String = "cCodCatalogo"
            
            Public Shared BVigente As String = "bVigente"
            
            Public Shared NDependeDe As String = "nDependeDe"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
