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
	''' Strongly-typed collection for the Leyenda class.
	''' </summary>
	<Serializable> _
	Public Partial Class LeyendaCollection 
	Inherits ActiveList(Of Leyenda, LeyendaCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As LeyendaCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Leyenda = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Leyenda table.
	''' </summary>
	<Serializable> _
	Public Partial Class Leyenda 
	Inherits ActiveRecord(Of Leyenda)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Leyenda", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodLeyenda As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodLeyenda.ColumnName = "nCodLeyenda"
                colvarNCodLeyenda.DataType = DbType.Int32
                colvarNCodLeyenda.MaxLength = 0
                colvarNCodLeyenda.AutoIncrement = false
                colvarNCodLeyenda.IsNullable = false
                colvarNCodLeyenda.IsPrimaryKey = true
                colvarNCodLeyenda.IsForeignKey = false
                colvarNCodLeyenda.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodLeyenda)
                
                Dim colvarCNormativa As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNormativa.ColumnName = "cNormativa"
                colvarCNormativa.DataType = DbType.AnsiString
                colvarCNormativa.MaxLength = 255
                colvarCNormativa.AutoIncrement = false
                colvarCNormativa.IsNullable = false
                colvarCNormativa.IsPrimaryKey = false
                colvarCNormativa.IsForeignKey = false
                colvarCNormativa.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNormativa)
                
                Dim colvarCTipo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTipo.ColumnName = "cTipo"
                colvarCTipo.DataType = DbType.AnsiStringFixedLength
                colvarCTipo.MaxLength = 3
                colvarCTipo.AutoIncrement = false
                colvarCTipo.IsNullable = false
                colvarCTipo.IsPrimaryKey = false
                colvarCTipo.IsForeignKey = false
                colvarCTipo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTipo)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Leyenda",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodLeyenda")> _
        Public Property NCodLeyenda As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodLeyenda)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodLeyenda, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNormativa")> _
        Public Property CNormativa As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNormativa)
			End Get
		    
			Set
				SetColumnValue(Columns.CNormativa, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTipo")> _
        Public Property CTipo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTipo)
			End Get
		    
			Set
				SetColumnValue(Columns.CTipo, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodLeyenda As Integer,ByVal varCNormativa As String,ByVal varCTipo As String)
			Dim item As Leyenda = New Leyenda()
			
            item.NCodLeyenda = varNCodLeyenda
            
            item.CNormativa = varCNormativa
            
            item.CTipo = varCTipo
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodLeyenda As Integer,ByVal varCNormativa As String,ByVal varCTipo As String)
			Dim item As Leyenda = New Leyenda()
		    
                item.NCodLeyenda = varNCodLeyenda
				
                item.CNormativa = varCNormativa
				
                item.CTipo = varCTipo
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodLeyendaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNormativaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTipoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodLeyenda As String = "nCodLeyenda"
            
            Public Shared CNormativa As String = "cNormativa"
            
            Public Shared CTipo As String = "cTipo"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
