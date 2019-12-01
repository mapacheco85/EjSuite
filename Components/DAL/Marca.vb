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
	''' Strongly-typed collection for the Marca class.
	''' </summary>
	<Serializable> _
	Public Partial Class MarcaCollection 
	Inherits ActiveList(Of Marca, MarcaCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As MarcaCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Marca = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Marca table.
	''' </summary>
	<Serializable> _
	Public Partial Class Marca 
	Inherits ActiveRecord(Of Marca)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Marca", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodMarca As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodMarca.ColumnName = "nCodMarca"
                colvarNCodMarca.DataType = DbType.Int32
                colvarNCodMarca.MaxLength = 0
                colvarNCodMarca.AutoIncrement = false
                colvarNCodMarca.IsNullable = false
                colvarNCodMarca.IsPrimaryKey = true
                colvarNCodMarca.IsForeignKey = false
                colvarNCodMarca.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodMarca)
                
                Dim colvarNCodProveedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProveedor.ColumnName = "nCodProveedor"
                colvarNCodProveedor.DataType = DbType.Int32
                colvarNCodProveedor.MaxLength = 0
                colvarNCodProveedor.AutoIncrement = false
                colvarNCodProveedor.IsNullable = true
                colvarNCodProveedor.IsPrimaryKey = false
                colvarNCodProveedor.IsForeignKey = true
                colvarNCodProveedor.IsReadOnly = false
                
                
				colvarNCodProveedor.ForeignKeyTableName = "EJS_Proveedor"
                
                schema.Columns.Add(colvarNCodProveedor)
                
                Dim colvarCEmpresa As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCEmpresa.ColumnName = "cEmpresa"
                colvarCEmpresa.DataType = DbType.AnsiString
                colvarCEmpresa.MaxLength = 200
                colvarCEmpresa.AutoIncrement = false
                colvarCEmpresa.IsNullable = false
                colvarCEmpresa.IsPrimaryKey = false
                colvarCEmpresa.IsForeignKey = false
                colvarCEmpresa.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCEmpresa)
                
                Dim colvarCDireccion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDireccion.ColumnName = "cDireccion"
                colvarCDireccion.DataType = DbType.AnsiString
                colvarCDireccion.MaxLength = 200
                colvarCDireccion.AutoIncrement = false
                colvarCDireccion.IsNullable = false
                colvarCDireccion.IsPrimaryKey = false
                colvarCDireccion.IsForeignKey = false
                colvarCDireccion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDireccion)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Marca",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodMarca")> _
        Public Property NCodMarca As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodMarca)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodMarca, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProveedor")> _
        Public Property NCodProveedor As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodProveedor)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProveedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CEmpresa")> _
        Public Property CEmpresa As String 
			Get
				Return GetColumnValue(Of String)(Columns.CEmpresa)
			End Get
		    
			Set
				SetColumnValue(Columns.CEmpresa, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDireccion")> _
        Public Property CDireccion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDireccion)
			End Get
		    
			Set
				SetColumnValue(Columns.CDireccion, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function ProductoRecords() As EjSuite.ProductoCollection 
	
				Return New EjSuite.ProductoCollection().Where(Producto.Columns.NCodMarca, NCodMarca).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Proveedor ActiveRecord object related to this Marca
		''' </summary>
		Public Property Proveedor() As EjSuite.Proveedor
			Get
				Return EjSuite.Proveedor.FetchByID(Me.NCodProveedor)
			End Get
			Set
				SetColumnValue("nCodProveedor", Value.NCodProveedor)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodMarca As Integer,ByVal varNCodProveedor As Nullable(Of Integer),ByVal varCEmpresa As String,ByVal varCDireccion As String)
			Dim item As Marca = New Marca()
			
            item.NCodMarca = varNCodMarca
            
            item.NCodProveedor = varNCodProveedor
            
            item.CEmpresa = varCEmpresa
            
            item.CDireccion = varCDireccion
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodMarca As Integer,ByVal varNCodProveedor As Nullable(Of Integer),ByVal varCEmpresa As String,ByVal varCDireccion As String)
			Dim item As Marca = New Marca()
		    
                item.NCodMarca = varNCodMarca
				
                item.NCodProveedor = varNCodProveedor
				
                item.CEmpresa = varCEmpresa
				
                item.CDireccion = varCDireccion
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodMarcaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProveedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CEmpresaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodMarca As String = "nCodMarca"
            
            Public Shared NCodProveedor As String = "nCodProveedor"
            
            Public Shared CEmpresa As String = "cEmpresa"
            
            Public Shared CDireccion As String = "cDireccion"
            
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
