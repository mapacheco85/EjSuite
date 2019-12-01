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
	''' Strongly-typed collection for the Proveedor class.
	''' </summary>
	<Serializable> _
	Public Partial Class ProveedorCollection 
	Inherits ActiveList(Of Proveedor, ProveedorCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ProveedorCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Proveedor = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Proveedor table.
	''' </summary>
	<Serializable> _
	Public Partial Class Proveedor 
	Inherits ActiveRecord(Of Proveedor)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Proveedor", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodProveedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProveedor.ColumnName = "nCodProveedor"
                colvarNCodProveedor.DataType = DbType.Int32
                colvarNCodProveedor.MaxLength = 0
                colvarNCodProveedor.AutoIncrement = false
                colvarNCodProveedor.IsNullable = false
                colvarNCodProveedor.IsPrimaryKey = true
                colvarNCodProveedor.IsForeignKey = false
                colvarNCodProveedor.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodProveedor)
                
                Dim colvarCNombre As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNombre.ColumnName = "cNombre"
                colvarCNombre.DataType = DbType.AnsiString
                colvarCNombre.MaxLength = 255
                colvarCNombre.AutoIncrement = false
                colvarCNombre.IsNullable = false
                colvarCNombre.IsPrimaryKey = false
                colvarCNombre.IsForeignKey = false
                colvarCNombre.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNombre)
                
                Dim colvarCDireccion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDireccion.ColumnName = "cDireccion"
                colvarCDireccion.DataType = DbType.AnsiString
                colvarCDireccion.MaxLength = 255
                colvarCDireccion.AutoIncrement = false
                colvarCDireccion.IsNullable = false
                colvarCDireccion.IsPrimaryKey = false
                colvarCDireccion.IsForeignKey = false
                colvarCDireccion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDireccion)
                
                Dim colvarCRepresentante As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCRepresentante.ColumnName = "cRepresentante"
                colvarCRepresentante.DataType = DbType.AnsiString
                colvarCRepresentante.MaxLength = 255
                colvarCRepresentante.AutoIncrement = false
                colvarCRepresentante.IsNullable = false
                colvarCRepresentante.IsPrimaryKey = false
                colvarCRepresentante.IsForeignKey = false
                colvarCRepresentante.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCRepresentante)
                
                Dim colvarCTelefono As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTelefono.ColumnName = "cTelefono"
                colvarCTelefono.DataType = DbType.AnsiString
                colvarCTelefono.MaxLength = 255
                colvarCTelefono.AutoIncrement = false
                colvarCTelefono.IsNullable = false
                colvarCTelefono.IsPrimaryKey = false
                colvarCTelefono.IsForeignKey = false
                colvarCTelefono.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTelefono)
                
                Dim colvarCTelefono2 As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTelefono2.ColumnName = "cTelefono2"
                colvarCTelefono2.DataType = DbType.AnsiString
                colvarCTelefono2.MaxLength = 255
                colvarCTelefono2.AutoIncrement = false
                colvarCTelefono2.IsNullable = true
                colvarCTelefono2.IsPrimaryKey = false
                colvarCTelefono2.IsForeignKey = false
                colvarCTelefono2.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTelefono2)
                
                Dim colvarCCelular As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCelular.ColumnName = "cCelular"
                colvarCCelular.DataType = DbType.AnsiString
                colvarCCelular.MaxLength = 255
                colvarCCelular.AutoIncrement = false
                colvarCCelular.IsNullable = true
                colvarCCelular.IsPrimaryKey = false
                colvarCCelular.IsForeignKey = false
                colvarCCelular.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCelular)
                
                Dim colvarCEmail As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCEmail.ColumnName = "cEmail"
                colvarCEmail.DataType = DbType.AnsiString
                colvarCEmail.MaxLength = 255
                colvarCEmail.AutoIncrement = false
                colvarCEmail.IsNullable = true
                colvarCEmail.IsPrimaryKey = false
                colvarCEmail.IsForeignKey = false
                colvarCEmail.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCEmail)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Proveedor",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodProveedor")> _
        Public Property NCodProveedor As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodProveedor)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProveedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNombre")> _
        Public Property CNombre As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNombre)
			End Get
		    
			Set
				SetColumnValue(Columns.CNombre, Value)
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
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CRepresentante")> _
        Public Property CRepresentante As String 
			Get
				Return GetColumnValue(Of String)(Columns.CRepresentante)
			End Get
		    
			Set
				SetColumnValue(Columns.CRepresentante, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTelefono")> _
        Public Property CTelefono As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTelefono)
			End Get
		    
			Set
				SetColumnValue(Columns.CTelefono, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTelefono2")> _
        Public Property CTelefono2 As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTelefono2)
			End Get
		    
			Set
				SetColumnValue(Columns.CTelefono2, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCelular")> _
        Public Property CCelular As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCelular)
			End Get
		    
			Set
				SetColumnValue(Columns.CCelular, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CEmail")> _
        Public Property CEmail As String 
			Get
				Return GetColumnValue(Of String)(Columns.CEmail)
			End Get
		    
			Set
				SetColumnValue(Columns.CEmail, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function MarcaRecords() As EjSuite.MarcaCollection 
	
				Return New EjSuite.MarcaCollection().Where(Marca.Columns.NCodProveedor, NCodProveedor).Load()
	
			End Function
			
			Public Function ProductoRecords() As EjSuite.ProductoCollection 
	
				Return New EjSuite.ProductoCollection().Where(Producto.Columns.NCodProveedor, NCodProveedor).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodProveedor As Integer,ByVal varCNombre As String,ByVal varCDireccion As String,ByVal varCRepresentante As String,ByVal varCTelefono As String,ByVal varCTelefono2 As String,ByVal varCCelular As String,ByVal varCEmail As String)
			Dim item As Proveedor = New Proveedor()
			
            item.NCodProveedor = varNCodProveedor
            
            item.CNombre = varCNombre
            
            item.CDireccion = varCDireccion
            
            item.CRepresentante = varCRepresentante
            
            item.CTelefono = varCTelefono
            
            item.CTelefono2 = varCTelefono2
            
            item.CCelular = varCCelular
            
            item.CEmail = varCEmail
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodProveedor As Integer,ByVal varCNombre As String,ByVal varCDireccion As String,ByVal varCRepresentante As String,ByVal varCTelefono As String,ByVal varCTelefono2 As String,ByVal varCCelular As String,ByVal varCEmail As String)
			Dim item As Proveedor = New Proveedor()
		    
                item.NCodProveedor = varNCodProveedor
				
                item.CNombre = varCNombre
				
                item.CDireccion = varCDireccion
				
                item.CRepresentante = varCRepresentante
				
                item.CTelefono = varCTelefono
				
                item.CTelefono2 = varCTelefono2
				
                item.CCelular = varCCelular
				
                item.CEmail = varCEmail
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodProveedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombreColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CRepresentanteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTelefonoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTelefono2Column() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCelularColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CEmailColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodProveedor As String = "nCodProveedor"
            
            Public Shared CNombre As String = "cNombre"
            
            Public Shared CDireccion As String = "cDireccion"
            
            Public Shared CRepresentante As String = "cRepresentante"
            
            Public Shared CTelefono As String = "cTelefono"
            
            Public Shared CTelefono2 As String = "cTelefono2"
            
            Public Shared CCelular As String = "cCelular"
            
            Public Shared CEmail As String = "cEmail"
            
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
