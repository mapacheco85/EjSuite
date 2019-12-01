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
	''' Strongly-typed collection for the ListadoProducto class.
	''' </summary>
	<Serializable> _
	Public Partial Class ListadoProductoCollection 
	Inherits ActiveList(Of ListadoProducto, ListadoProductoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ListadoProductoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As ListadoProducto = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_ListadoProducto table.
	''' </summary>
	<Serializable> _
	Public Partial Class ListadoProducto 
	Inherits ActiveRecord(Of ListadoProducto)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_ListadoProducto", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodListado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodListado.ColumnName = "nCodListado"
                colvarNCodListado.DataType = DbType.Int32
                colvarNCodListado.MaxLength = 0
                colvarNCodListado.AutoIncrement = false
                colvarNCodListado.IsNullable = false
                colvarNCodListado.IsPrimaryKey = true
                colvarNCodListado.IsForeignKey = false
                colvarNCodListado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodListado)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.AnsiString
                colvarNCodProducto.MaxLength = 50
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = true
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = false
                colvarNCodProducto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarNCodGrupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodGrupo.ColumnName = "nCodGrupo"
                colvarNCodGrupo.DataType = DbType.Int32
                colvarNCodGrupo.MaxLength = 0
                colvarNCodGrupo.AutoIncrement = false
                colvarNCodGrupo.IsNullable = true
                colvarNCodGrupo.IsPrimaryKey = false
                colvarNCodGrupo.IsForeignKey = true
                colvarNCodGrupo.IsReadOnly = false
                
                
				colvarNCodGrupo.ForeignKeyTableName = "EJS_Grupo"
                
                schema.Columns.Add(colvarNCodGrupo)
                
                Dim colvarProNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarProNCodProducto.ColumnName = "Pro_nCodProducto"
                colvarProNCodProducto.DataType = DbType.Int32
                colvarProNCodProducto.MaxLength = 0
                colvarProNCodProducto.AutoIncrement = false
                colvarProNCodProducto.IsNullable = true
                colvarProNCodProducto.IsPrimaryKey = false
                colvarProNCodProducto.IsForeignKey = false
                colvarProNCodProducto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarProNCodProducto)
                
                Dim colvarDFechaReg As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaReg.ColumnName = "dFechaReg"
                colvarDFechaReg.DataType = DbType.DateTime
                colvarDFechaReg.MaxLength = 0
                colvarDFechaReg.AutoIncrement = false
                colvarDFechaReg.IsNullable = true
                colvarDFechaReg.IsPrimaryKey = false
                colvarDFechaReg.IsForeignKey = false
                colvarDFechaReg.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaReg)
                
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
                DataService.Providers("DALEjSuite").AddSchema("EJS_ListadoProducto",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodListado")> _
        Public Property NCodListado As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodListado)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodListado, Value)
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
        <XmlAttribute("NCodGrupo")> _
        Public Property NCodGrupo As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodGrupo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodGrupo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("ProNCodProducto")> _
        Public Property ProNCodProducto As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.ProNCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.ProNCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaReg")> _
        Public Property DFechaReg As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaReg)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaReg, Value)
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
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Grupo ActiveRecord object related to this ListadoProducto
		''' </summary>
		Public Property Grupo() As EjSuite.Grupo
			Get
				Return EjSuite.Grupo.FetchByID(Me.NCodGrupo)
			End Get
			Set
				SetColumnValue("nCodGrupo", Value.NCodGrupo)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodListado As Integer,ByVal varNCodProducto As String,ByVal varNCodGrupo As Nullable(Of Integer),ByVal varProNCodProducto As Nullable(Of Integer),ByVal varDFechaReg As Nullable(Of DateTime),ByVal varBVigente As Nullable(Of Boolean))
			Dim item As ListadoProducto = New ListadoProducto()
			
            item.NCodListado = varNCodListado
            
            item.NCodProducto = varNCodProducto
            
            item.NCodGrupo = varNCodGrupo
            
            item.ProNCodProducto = varProNCodProducto
            
            item.DFechaReg = varDFechaReg
            
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
		Public Shared Sub Update(ByVal varNCodListado As Integer,ByVal varNCodProducto As String,ByVal varNCodGrupo As Nullable(Of Integer),ByVal varProNCodProducto As Nullable(Of Integer),ByVal varDFechaReg As Nullable(Of DateTime),ByVal varBVigente As Nullable(Of Boolean))
			Dim item As ListadoProducto = New ListadoProducto()
		    
                item.NCodListado = varNCodListado
				
                item.NCodProducto = varNCodProducto
				
                item.NCodGrupo = varNCodGrupo
				
                item.ProNCodProducto = varProNCodProducto
				
                item.DFechaReg = varDFechaReg
				
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
        
        
        Public Shared ReadOnly Property NCodListadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodGrupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property ProNCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaRegColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BVigenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodListado As String = "nCodListado"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared NCodGrupo As String = "nCodGrupo"
            
            Public Shared ProNCodProducto As String = "Pro_nCodProducto"
            
            Public Shared DFechaReg As String = "dFechaReg"
            
            Public Shared BVigente As String = "bVigente"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
