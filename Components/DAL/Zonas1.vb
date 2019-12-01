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
	''' Strongly-typed collection for the Zonas1 class.
	''' </summary>
	<Serializable> _
	Public Partial Class Zonas1Collection 
	Inherits ActiveList(Of Zonas1, Zonas1Collection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As Zonas1Collection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Zonas1 = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Zonas1 table.
	''' </summary>
	<Serializable> _
	Public Partial Class Zonas1 
	Inherits ActiveRecord(Of Zonas1)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Zonas1", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodZonaDetalle As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodZonaDetalle.ColumnName = "nCodZonaDetalle"
                colvarNCodZonaDetalle.DataType = DbType.Int32
                colvarNCodZonaDetalle.MaxLength = 0
                colvarNCodZonaDetalle.AutoIncrement = false
                colvarNCodZonaDetalle.IsNullable = false
                colvarNCodZonaDetalle.IsPrimaryKey = true
                colvarNCodZonaDetalle.IsForeignKey = false
                colvarNCodZonaDetalle.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodZonaDetalle)
                
                Dim colvarNCodUsuario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodUsuario.ColumnName = "nCodUsuario"
                colvarNCodUsuario.DataType = DbType.Decimal
                colvarNCodUsuario.MaxLength = 0
                colvarNCodUsuario.AutoIncrement = false
                colvarNCodUsuario.IsNullable = false
                colvarNCodUsuario.IsPrimaryKey = false
                colvarNCodUsuario.IsForeignKey = false
                colvarNCodUsuario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodUsuario)
                
                Dim colvarNCodUnidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodUnidad.ColumnName = "nCodUnidad"
                colvarNCodUnidad.DataType = DbType.Int32
                colvarNCodUnidad.MaxLength = 0
                colvarNCodUnidad.AutoIncrement = false
                colvarNCodUnidad.IsNullable = false
                colvarNCodUnidad.IsPrimaryKey = false
                colvarNCodUnidad.IsForeignKey = true
                colvarNCodUnidad.IsReadOnly = false
                
                
				colvarNCodUnidad.ForeignKeyTableName = "EJS_Zonas"
                
                schema.Columns.Add(colvarNCodUnidad)
                
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
                DataService.Providers("DALEjSuite").AddSchema("EJS_Zonas1",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodZonaDetalle")> _
        Public Property NCodZonaDetalle As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodZonaDetalle)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodZonaDetalle, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodUsuario")> _
        Public Property NCodUsuario As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NCodUsuario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodUsuario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodUnidad")> _
        Public Property NCodUnidad As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodUnidad)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodUnidad, Value)
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
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Zona ActiveRecord object related to this Zonas1
		''' </summary>
		Public Property Zona() As EjSuite.Zona
			Get
				Return EjSuite.Zona.FetchByID(Me.NCodUnidad)
			End Get
			Set
				SetColumnValue("nCodUnidad", Value.NCodUnidad)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodZonaDetalle As Integer,ByVal varNCodUsuario As Decimal,ByVal varNCodUnidad As Integer,ByVal varCDescripcion As String)
			Dim item As Zonas1 = New Zonas1()
			
            item.NCodZonaDetalle = varNCodZonaDetalle
            
            item.NCodUsuario = varNCodUsuario
            
            item.NCodUnidad = varNCodUnidad
            
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
		Public Shared Sub Update(ByVal varNCodZonaDetalle As Integer,ByVal varNCodUsuario As Decimal,ByVal varNCodUnidad As Integer,ByVal varCDescripcion As String)
			Dim item As Zonas1 = New Zonas1()
		    
                item.NCodZonaDetalle = varNCodZonaDetalle
				
                item.NCodUsuario = varNCodUsuario
				
                item.NCodUnidad = varNCodUnidad
				
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
        
        
        Public Shared ReadOnly Property NCodZonaDetalleColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDescripcionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodZonaDetalle As String = "nCodZonaDetalle"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared NCodUnidad As String = "nCodUnidad"
            
            Public Shared CDescripcion As String = "cDescripcion"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
