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
	''' Strongly-typed collection for the MacroUnidade class.
	''' </summary>
	<Serializable> _
	Public Partial Class MacroUnidadeCollection 
	Inherits ActiveList(Of MacroUnidade, MacroUnidadeCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As MacroUnidadeCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As MacroUnidade = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_MacroUnidades table.
	''' </summary>
	<Serializable> _
	Public Partial Class MacroUnidade 
	Inherits ActiveRecord(Of MacroUnidade)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_MacroUnidades", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodMacroUnidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodMacroUnidad.ColumnName = "nCodMacroUnidad"
                colvarNCodMacroUnidad.DataType = DbType.Int32
                colvarNCodMacroUnidad.MaxLength = 0
                colvarNCodMacroUnidad.AutoIncrement = false
                colvarNCodMacroUnidad.IsNullable = false
                colvarNCodMacroUnidad.IsPrimaryKey = true
                colvarNCodMacroUnidad.IsForeignKey = false
                colvarNCodMacroUnidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodMacroUnidad)
                
                Dim colvarCDescripcion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDescripcion.ColumnName = "cDescripcion"
                colvarCDescripcion.DataType = DbType.AnsiString
                colvarCDescripcion.MaxLength = 50
                colvarCDescripcion.AutoIncrement = false
                colvarCDescripcion.IsNullable = false
                colvarCDescripcion.IsPrimaryKey = false
                colvarCDescripcion.IsForeignKey = false
                colvarCDescripcion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDescripcion)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_MacroUnidades",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodMacroUnidad")> _
        Public Property NCodMacroUnidad As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodMacroUnidad)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodMacroUnidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDescripcion")> _
        Public Property CDescripcion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDescripcion)
			End Get
		    
			Set
				SetColumnValue(Columns.CDescripcion, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodMacroUnidad As Integer,ByVal varCDescripcion As String)
			Dim item As MacroUnidade = New MacroUnidade()
			
            item.NCodMacroUnidad = varNCodMacroUnidad
            
            item.CDescripcion = varCDescripcion
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodMacroUnidad As Integer,ByVal varCDescripcion As String)
			Dim item As MacroUnidade = New MacroUnidade()
		    
                item.NCodMacroUnidad = varNCodMacroUnidad
				
                item.CDescripcion = varCDescripcion
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodMacroUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDescripcionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodMacroUnidad As String = "nCodMacroUnidad"
            
            Public Shared CDescripcion As String = "cDescripcion"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
