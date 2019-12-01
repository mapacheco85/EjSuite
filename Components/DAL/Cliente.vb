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
	''' Strongly-typed collection for the Cliente class.
	''' </summary>
	<Serializable> _
	Public Partial Class ClienteCollection 
	Inherits ActiveList(Of Cliente, ClienteCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ClienteCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Cliente = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Cliente table.
	''' </summary>
	<Serializable> _
	Public Partial Class Cliente 
	Inherits ActiveRecord(Of Cliente)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Cliente", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCliente.ColumnName = "nCodCliente"
                colvarNCodCliente.DataType = DbType.Int64
                colvarNCodCliente.MaxLength = 0
                colvarNCodCliente.AutoIncrement = false
                colvarNCodCliente.IsNullable = false
                colvarNCodCliente.IsPrimaryKey = true
                colvarNCodCliente.IsForeignKey = false
                colvarNCodCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCliente)
                
                Dim colvarCNit As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNit.ColumnName = "cNit"
                colvarCNit.DataType = DbType.AnsiString
                colvarCNit.MaxLength = 20
                colvarCNit.AutoIncrement = false
                colvarCNit.IsNullable = false
                colvarCNit.IsPrimaryKey = false
                colvarCNit.IsForeignKey = false
                colvarCNit.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNit)
                
                Dim colvarNCodRegion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodRegion.ColumnName = "nCodRegion"
                colvarNCodRegion.DataType = DbType.Int32
                colvarNCodRegion.MaxLength = 0
                colvarNCodRegion.AutoIncrement = false
                colvarNCodRegion.IsNullable = true
                colvarNCodRegion.IsPrimaryKey = false
                colvarNCodRegion.IsForeignKey = false
                colvarNCodRegion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodRegion)
                
                Dim colvarCCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCliente.ColumnName = "cCliente"
                colvarCCliente.DataType = DbType.AnsiString
                colvarCCliente.MaxLength = 255
                colvarCCliente.AutoIncrement = false
                colvarCCliente.IsNullable = false
                colvarCCliente.IsPrimaryKey = false
                colvarCCliente.IsForeignKey = false
                colvarCCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCliente)
                
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
                
                Dim colvarCTelefono As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTelefono.ColumnName = "cTelefono"
                colvarCTelefono.DataType = DbType.AnsiString
                colvarCTelefono.MaxLength = 255
                colvarCTelefono.AutoIncrement = false
                colvarCTelefono.IsNullable = true
                colvarCTelefono.IsPrimaryKey = false
                colvarCTelefono.IsForeignKey = false
                colvarCTelefono.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTelefono)
                
                Dim colvarNCodUsuario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodUsuario.ColumnName = "nCodUsuario"
                colvarNCodUsuario.DataType = DbType.Int32
                colvarNCodUsuario.MaxLength = 0
                colvarNCodUsuario.AutoIncrement = false
                colvarNCodUsuario.IsNullable = true
                colvarNCodUsuario.IsPrimaryKey = false
                colvarNCodUsuario.IsForeignKey = false
                colvarNCodUsuario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodUsuario)
                
                Dim colvarNCodZona As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodZona.ColumnName = "nCodZona"
                colvarNCodZona.DataType = DbType.Int32
                colvarNCodZona.MaxLength = 0
                colvarNCodZona.AutoIncrement = false
                colvarNCodZona.IsNullable = true
                colvarNCodZona.IsPrimaryKey = false
                colvarNCodZona.IsForeignKey = false
                colvarNCodZona.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodZona)
                
                Dim colvarCContacto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCContacto.ColumnName = "cContacto"
                colvarCContacto.DataType = DbType.AnsiString
                colvarCContacto.MaxLength = 255
                colvarCContacto.AutoIncrement = false
                colvarCContacto.IsNullable = true
                colvarCContacto.IsPrimaryKey = false
                colvarCContacto.IsForeignKey = false
                colvarCContacto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCContacto)
                
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
                
                Dim colvarCReferencias As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCReferencias.ColumnName = "cReferencias"
                colvarCReferencias.DataType = DbType.AnsiString
                colvarCReferencias.MaxLength = 255
                colvarCReferencias.AutoIncrement = false
                colvarCReferencias.IsNullable = true
                colvarCReferencias.IsPrimaryKey = false
                colvarCReferencias.IsForeignKey = false
                colvarCReferencias.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCReferencias)
                
                Dim colvarCCelularContacto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCelularContacto.ColumnName = "cCelularContacto"
                colvarCCelularContacto.DataType = DbType.AnsiString
                colvarCCelularContacto.MaxLength = 20
                colvarCCelularContacto.AutoIncrement = false
                colvarCCelularContacto.IsNullable = true
                colvarCCelularContacto.IsPrimaryKey = false
                colvarCCelularContacto.IsForeignKey = false
                colvarCCelularContacto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCelularContacto)
                
                Dim colvarCTelefono2 As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTelefono2.ColumnName = "cTelefono2"
                colvarCTelefono2.DataType = DbType.AnsiString
                colvarCTelefono2.MaxLength = 20
                colvarCTelefono2.AutoIncrement = false
                colvarCTelefono2.IsNullable = true
                colvarCTelefono2.IsPrimaryKey = false
                colvarCTelefono2.IsForeignKey = false
                colvarCTelefono2.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTelefono2)
                
                Dim colvarBValido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBValido.ColumnName = "bValido"
                colvarBValido.DataType = DbType.Boolean
                colvarBValido.MaxLength = 0
                colvarBValido.AutoIncrement = false
                colvarBValido.IsNullable = false
                colvarBValido.IsPrimaryKey = false
                colvarBValido.IsForeignKey = false
                colvarBValido.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBValido)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Cliente",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodCliente")> _
        Public Property NCodCliente As Long 
			Get
				Return GetColumnValue(Of Long)(Columns.NCodCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCliente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNit")> _
        Public Property CNit As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNit)
			End Get
		    
			Set
				SetColumnValue(Columns.CNit, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodRegion")> _
        Public Property NCodRegion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodRegion)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodRegion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCliente")> _
        Public Property CCliente As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.CCliente, Value)
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
        <XmlAttribute("NCodUsuario")> _
        Public Property NCodUsuario As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodUsuario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodUsuario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodZona")> _
        Public Property NCodZona As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodZona)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodZona, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CContacto")> _
        Public Property CContacto As String 
			Get
				Return GetColumnValue(Of String)(Columns.CContacto)
			End Get
		    
			Set
				SetColumnValue(Columns.CContacto, Value)
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
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CReferencias")> _
        Public Property CReferencias As String 
			Get
				Return GetColumnValue(Of String)(Columns.CReferencias)
			End Get
		    
			Set
				SetColumnValue(Columns.CReferencias, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCelularContacto")> _
        Public Property CCelularContacto As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCelularContacto)
			End Get
		    
			Set
				SetColumnValue(Columns.CCelularContacto, Value)
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
        <XmlAttribute("BValido")> _
        Public Property BValido As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BValido)
			End Get
		    
			Set
				SetColumnValue(Columns.BValido, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function BeneficiarioRecords() As EjSuite.BeneficiarioCollection 
	
				Return New EjSuite.BeneficiarioCollection().Where(Beneficiario.Columns.NCodCliente, NCodCliente).Load()
	
			End Function
			
			Public Function FacturaRecords() As EjSuite.FacturaCollection 
	
				Return New EjSuite.FacturaCollection().Where(Factura.Columns.NCodCliente, NCodCliente).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodCliente As Long,ByVal varCNit As String,ByVal varNCodRegion As Nullable(Of Integer),ByVal varCCliente As String,ByVal varCDireccion As String,ByVal varCTelefono As String,ByVal varNCodUsuario As Nullable(Of Integer),ByVal varNCodZona As Nullable(Of Integer),ByVal varCContacto As String,ByVal varCEmail As String,ByVal varCReferencias As String,ByVal varCCelularContacto As String,ByVal varCTelefono2 As String,ByVal varBValido As Boolean)
			Dim item As Cliente = New Cliente()
			
            item.NCodCliente = varNCodCliente
            
            item.CNit = varCNit
            
            item.NCodRegion = varNCodRegion
            
            item.CCliente = varCCliente
            
            item.CDireccion = varCDireccion
            
            item.CTelefono = varCTelefono
            
            item.NCodUsuario = varNCodUsuario
            
            item.NCodZona = varNCodZona
            
            item.CContacto = varCContacto
            
            item.CEmail = varCEmail
            
            item.CReferencias = varCReferencias
            
            item.CCelularContacto = varCCelularContacto
            
            item.CTelefono2 = varCTelefono2
            
            item.BValido = varBValido
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodCliente As Long,ByVal varCNit As String,ByVal varNCodRegion As Nullable(Of Integer),ByVal varCCliente As String,ByVal varCDireccion As String,ByVal varCTelefono As String,ByVal varNCodUsuario As Nullable(Of Integer),ByVal varNCodZona As Nullable(Of Integer),ByVal varCContacto As String,ByVal varCEmail As String,ByVal varCReferencias As String,ByVal varCCelularContacto As String,ByVal varCTelefono2 As String,ByVal varBValido As Boolean)
			Dim item As Cliente = New Cliente()
		    
                item.NCodCliente = varNCodCliente
				
                item.CNit = varCNit
				
                item.NCodRegion = varNCodRegion
				
                item.CCliente = varCCliente
				
                item.CDireccion = varCDireccion
				
                item.CTelefono = varCTelefono
				
                item.NCodUsuario = varNCodUsuario
				
                item.NCodZona = varNCodZona
				
                item.CContacto = varCContacto
				
                item.CEmail = varCEmail
				
                item.CReferencias = varCReferencias
				
                item.CCelularContacto = varCCelularContacto
				
                item.CTelefono2 = varCTelefono2
				
                item.BValido = varBValido
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNitColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodRegionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTelefonoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodZonaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CContactoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CEmailColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CReferenciasColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCelularContactoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTelefono2Column() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BValidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CNit As String = "cNit"
            
            Public Shared NCodRegion As String = "nCodRegion"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared CDireccion As String = "cDireccion"
            
            Public Shared CTelefono As String = "cTelefono"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared NCodZona As String = "nCodZona"
            
            Public Shared CContacto As String = "cContacto"
            
            Public Shared CEmail As String = "cEmail"
            
            Public Shared CReferencias As String = "cReferencias"
            
            Public Shared CCelularContacto As String = "cCelularContacto"
            
            Public Shared CTelefono2 As String = "cTelefono2"
            
            Public Shared BValido As String = "bValido"
            
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
