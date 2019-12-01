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
	''' Strongly-typed collection for the EmpleadoSucursal class.
	''' </summary>
	<Serializable> _
	Public Partial Class EmpleadoSucursalCollection 
	Inherits ActiveList(Of EmpleadoSucursal, EmpleadoSucursalCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As EmpleadoSucursalCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As EmpleadoSucursal = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_EmpleadoSucursal table.
	''' </summary>
	<Serializable> _
	Public Partial Class EmpleadoSucursal 
	Inherits ActiveRecord(Of EmpleadoSucursal)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_EmpleadoSucursal", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodEmpleadoSucursal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEmpleadoSucursal.ColumnName = "nCodEmpleadoSucursal"
                colvarNCodEmpleadoSucursal.DataType = DbType.Int32
                colvarNCodEmpleadoSucursal.MaxLength = 0
                colvarNCodEmpleadoSucursal.AutoIncrement = false
                colvarNCodEmpleadoSucursal.IsNullable = false
                colvarNCodEmpleadoSucursal.IsPrimaryKey = true
                colvarNCodEmpleadoSucursal.IsForeignKey = false
                colvarNCodEmpleadoSucursal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodEmpleadoSucursal)
                
                Dim colvarNCodSucursal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = false
                colvarNCodSucursal.IsNullable = true
                colvarNCodSucursal.IsPrimaryKey = false
                colvarNCodSucursal.IsForeignKey = true
                colvarNCodSucursal.IsReadOnly = false
                
                
				colvarNCodSucursal.ForeignKeyTableName = "EJS_Sucursal"
                
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarNCodEmpleado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEmpleado.ColumnName = "nCodEmpleado"
                colvarNCodEmpleado.DataType = DbType.Int32
                colvarNCodEmpleado.MaxLength = 0
                colvarNCodEmpleado.AutoIncrement = false
                colvarNCodEmpleado.IsNullable = true
                colvarNCodEmpleado.IsPrimaryKey = false
                colvarNCodEmpleado.IsForeignKey = true
                colvarNCodEmpleado.IsReadOnly = false
                
                
				colvarNCodEmpleado.ForeignKeyTableName = "EJS_Empleado"
                
                schema.Columns.Add(colvarNCodEmpleado)
                
                Dim colvarDFechaInicio As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaInicio.ColumnName = "dFechaInicio"
                colvarDFechaInicio.DataType = DbType.DateTime
                colvarDFechaInicio.MaxLength = 0
                colvarDFechaInicio.AutoIncrement = false
                colvarDFechaInicio.IsNullable = false
                colvarDFechaInicio.IsPrimaryKey = false
                colvarDFechaInicio.IsForeignKey = false
                colvarDFechaInicio.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaInicio)
                
                Dim colvarDFechaFinal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaFinal.ColumnName = "dFechaFinal"
                colvarDFechaFinal.DataType = DbType.DateTime
                colvarDFechaFinal.MaxLength = 0
                colvarDFechaFinal.AutoIncrement = false
                colvarDFechaFinal.IsNullable = true
                colvarDFechaFinal.IsPrimaryKey = false
                colvarDFechaFinal.IsForeignKey = false
                colvarDFechaFinal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaFinal)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_EmpleadoSucursal",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodEmpleadoSucursal")> _
        Public Property NCodEmpleadoSucursal As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodEmpleadoSucursal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEmpleadoSucursal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodSucursal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSucursal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodEmpleado")> _
        Public Property NCodEmpleado As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodEmpleado)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEmpleado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaInicio")> _
        Public Property DFechaInicio As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaInicio)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaInicio, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaFinal")> _
        Public Property DFechaFinal As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaFinal)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaFinal, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Sucursal ActiveRecord object related to this EmpleadoSucursal
		''' </summary>
		Public Property Sucursal() As EjSuite.Sucursal
			Get
				Return EjSuite.Sucursal.FetchByID(Me.NCodSucursal)
			End Get
			Set
				SetColumnValue("nCodSucursal", Value.NCodSucursal)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Empleado ActiveRecord object related to this EmpleadoSucursal
		''' </summary>
		Public Property Empleado() As EjSuite.Empleado
			Get
				Return EjSuite.Empleado.FetchByID(Me.NCodEmpleado)
			End Get
			Set
				SetColumnValue("nCodEmpleado", Value.NCodEmpleado)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodEmpleadoSucursal As Integer,ByVal varNCodSucursal As Nullable(Of Integer),ByVal varNCodEmpleado As Nullable(Of Integer),ByVal varDFechaInicio As DateTime,ByVal varDFechaFinal As Nullable(Of DateTime))
			Dim item As EmpleadoSucursal = New EmpleadoSucursal()
			
            item.NCodEmpleadoSucursal = varNCodEmpleadoSucursal
            
            item.NCodSucursal = varNCodSucursal
            
            item.NCodEmpleado = varNCodEmpleado
            
            item.DFechaInicio = varDFechaInicio
            
            item.DFechaFinal = varDFechaFinal
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodEmpleadoSucursal As Integer,ByVal varNCodSucursal As Nullable(Of Integer),ByVal varNCodEmpleado As Nullable(Of Integer),ByVal varDFechaInicio As DateTime,ByVal varDFechaFinal As Nullable(Of DateTime))
			Dim item As EmpleadoSucursal = New EmpleadoSucursal()
		    
                item.NCodEmpleadoSucursal = varNCodEmpleadoSucursal
				
                item.NCodSucursal = varNCodSucursal
				
                item.NCodEmpleado = varNCodEmpleado
				
                item.DFechaInicio = varDFechaInicio
				
                item.DFechaFinal = varDFechaFinal
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodEmpleadoSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodEmpleadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaInicioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaFinalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodEmpleadoSucursal As String = "nCodEmpleadoSucursal"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared NCodEmpleado As String = "nCodEmpleado"
            
            Public Shared DFechaInicio As String = "dFechaInicio"
            
            Public Shared DFechaFinal As String = "dFechaFinal"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
