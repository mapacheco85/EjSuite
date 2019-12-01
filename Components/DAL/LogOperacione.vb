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
	''' Strongly-typed collection for the LogOperacione class.
	''' </summary>
	<Serializable> _
	Public Partial Class LogOperacioneCollection 
	Inherits ActiveList(Of LogOperacione, LogOperacioneCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As LogOperacioneCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As LogOperacione = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_LogOperaciones table.
	''' </summary>
	<Serializable> _
	Public Partial Class LogOperacione 
	Inherits ActiveRecord(Of LogOperacione)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_LogOperaciones", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodLog As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodLog.ColumnName = "nCodLog"
                colvarNCodLog.DataType = DbType.Int64
                colvarNCodLog.MaxLength = 0
                colvarNCodLog.AutoIncrement = false
                colvarNCodLog.IsNullable = false
                colvarNCodLog.IsPrimaryKey = true
                colvarNCodLog.IsForeignKey = false
                colvarNCodLog.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodLog)
                
                Dim colvarDFecha As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFecha.ColumnName = "dFecha"
                colvarDFecha.DataType = DbType.DateTime
                colvarDFecha.MaxLength = 0
                colvarDFecha.AutoIncrement = false
                colvarDFecha.IsNullable = false
                colvarDFecha.IsPrimaryKey = false
                colvarDFecha.IsForeignKey = false
                colvarDFecha.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFecha)
                
                Dim colvarNCodUsuario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodUsuario.ColumnName = "nCodUsuario"
                colvarNCodUsuario.DataType = DbType.Int32
                colvarNCodUsuario.MaxLength = 0
                colvarNCodUsuario.AutoIncrement = false
                colvarNCodUsuario.IsNullable = false
                colvarNCodUsuario.IsPrimaryKey = false
                colvarNCodUsuario.IsForeignKey = false
                colvarNCodUsuario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodUsuario)
                
                Dim colvarCTabla As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTabla.ColumnName = "cTabla"
                colvarCTabla.DataType = DbType.AnsiString
                colvarCTabla.MaxLength = 50
                colvarCTabla.AutoIncrement = false
                colvarCTabla.IsNullable = false
                colvarCTabla.IsPrimaryKey = false
                colvarCTabla.IsForeignKey = false
                colvarCTabla.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTabla)
                
                Dim colvarCOperacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCOperacion.ColumnName = "cOperacion"
                colvarCOperacion.DataType = DbType.AnsiString
                colvarCOperacion.MaxLength = 50
                colvarCOperacion.AutoIncrement = false
                colvarCOperacion.IsNullable = false
                colvarCOperacion.IsPrimaryKey = false
                colvarCOperacion.IsForeignKey = false
                colvarCOperacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCOperacion)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_LogOperaciones",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodLog")> _
        Public Property NCodLog As Long 
			Get
				Return GetColumnValue(Of Long)(Columns.NCodLog)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodLog, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFecha")> _
        Public Property DFecha As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFecha)
			End Get
		    
			Set
				SetColumnValue(Columns.DFecha, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodUsuario")> _
        Public Property NCodUsuario As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodUsuario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodUsuario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTabla")> _
        Public Property CTabla As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTabla)
			End Get
		    
			Set
				SetColumnValue(Columns.CTabla, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("COperacion")> _
        Public Property COperacion As String 
			Get
				Return GetColumnValue(Of String)(Columns.COperacion)
			End Get
		    
			Set
				SetColumnValue(Columns.COperacion, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodLog As Long,ByVal varDFecha As DateTime,ByVal varNCodUsuario As Integer,ByVal varCTabla As String,ByVal varCOperacion As String)
			Dim item As LogOperacione = New LogOperacione()
			
            item.NCodLog = varNCodLog
            
            item.DFecha = varDFecha
            
            item.NCodUsuario = varNCodUsuario
            
            item.CTabla = varCTabla
            
            item.COperacion = varCOperacion
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodLog As Long,ByVal varDFecha As DateTime,ByVal varNCodUsuario As Integer,ByVal varCTabla As String,ByVal varCOperacion As String)
			Dim item As LogOperacione = New LogOperacione()
		    
                item.NCodLog = varNCodLog
				
                item.DFecha = varDFecha
				
                item.NCodUsuario = varNCodUsuario
				
                item.CTabla = varCTabla
				
                item.COperacion = varCOperacion
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodLogColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTablaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property COperacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodLog As String = "nCodLog"
            
            Public Shared DFecha As String = "dFecha"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared CTabla As String = "cTabla"
            
            Public Shared COperacion As String = "cOperacion"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
