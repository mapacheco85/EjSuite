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
	''' Strongly-typed collection for the Empresa class.
	''' </summary>
	<Serializable> _
	Public Partial Class EmpresaCollection 
	Inherits ActiveList(Of Empresa, EmpresaCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As EmpresaCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Empresa = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Empresa table.
	''' </summary>
	<Serializable> _
	Public Partial Class Empresa 
	Inherits ActiveRecord(Of Empresa)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Empresa", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodEmpresa As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEmpresa.ColumnName = "nCodEmpresa"
                colvarNCodEmpresa.DataType = DbType.Int32
                colvarNCodEmpresa.MaxLength = 0
                colvarNCodEmpresa.AutoIncrement = false
                colvarNCodEmpresa.IsNullable = false
                colvarNCodEmpresa.IsPrimaryKey = true
                colvarNCodEmpresa.IsForeignKey = false
                colvarNCodEmpresa.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodEmpresa)
                
                Dim colvarCRazonSocial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCRazonSocial.ColumnName = "cRazonSocial"
                colvarCRazonSocial.DataType = DbType.AnsiString
                colvarCRazonSocial.MaxLength = 255
                colvarCRazonSocial.AutoIncrement = false
                colvarCRazonSocial.IsNullable = false
                colvarCRazonSocial.IsPrimaryKey = false
                colvarCRazonSocial.IsForeignKey = false
                colvarCRazonSocial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCRazonSocial)
                
                Dim colvarCPropietario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCPropietario.ColumnName = "cPropietario"
                colvarCPropietario.DataType = DbType.AnsiString
                colvarCPropietario.MaxLength = 255
                colvarCPropietario.AutoIncrement = false
                colvarCPropietario.IsNullable = false
                colvarCPropietario.IsPrimaryKey = false
                colvarCPropietario.IsForeignKey = false
                colvarCPropietario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCPropietario)
                
                Dim colvarILogo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarILogo.ColumnName = "iLogo"
                colvarILogo.DataType = DbType.Binary
                colvarILogo.MaxLength = 2147483647
                colvarILogo.AutoIncrement = false
                colvarILogo.IsNullable = true
                colvarILogo.IsPrimaryKey = false
                colvarILogo.IsForeignKey = false
                colvarILogo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarILogo)
                
                Dim colvarCDireccion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDireccion.ColumnName = "cDireccion"
                colvarCDireccion.DataType = DbType.AnsiString
                colvarCDireccion.MaxLength = 255
                colvarCDireccion.AutoIncrement = false
                colvarCDireccion.IsNullable = true
                colvarCDireccion.IsPrimaryKey = false
                colvarCDireccion.IsForeignKey = false
                colvarCDireccion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDireccion)
                
                Dim colvarCTelefonos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTelefonos.ColumnName = "cTelefonos"
                colvarCTelefonos.DataType = DbType.AnsiString
                colvarCTelefonos.MaxLength = 255
                colvarCTelefonos.AutoIncrement = false
                colvarCTelefonos.IsNullable = true
                colvarCTelefonos.IsPrimaryKey = false
                colvarCTelefonos.IsForeignKey = false
                colvarCTelefonos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTelefonos)
                
                Dim colvarCCiudad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCiudad.ColumnName = "cCiudad"
                colvarCCiudad.DataType = DbType.AnsiString
                colvarCCiudad.MaxLength = 255
                colvarCCiudad.AutoIncrement = false
                colvarCCiudad.IsNullable = true
                colvarCCiudad.IsPrimaryKey = false
                colvarCCiudad.IsForeignKey = false
                colvarCCiudad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCiudad)
                
                Dim colvarCEstado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCEstado.ColumnName = "cEstado"
                colvarCEstado.DataType = DbType.AnsiString
                colvarCEstado.MaxLength = 255
                colvarCEstado.AutoIncrement = false
                colvarCEstado.IsNullable = true
                colvarCEstado.IsPrimaryKey = false
                colvarCEstado.IsForeignKey = false
                colvarCEstado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCEstado)
                
                Dim colvarCPais As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCPais.ColumnName = "cPais"
                colvarCPais.DataType = DbType.AnsiString
                colvarCPais.MaxLength = 255
                colvarCPais.AutoIncrement = false
                colvarCPais.IsNullable = true
                colvarCPais.IsPrimaryKey = false
                colvarCPais.IsForeignKey = false
                colvarCPais.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCPais)
                
                Dim colvarBValido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBValido.ColumnName = "bValido"
                colvarBValido.DataType = DbType.Boolean
                colvarBValido.MaxLength = 0
                colvarBValido.AutoIncrement = false
                colvarBValido.IsNullable = true
                colvarBValido.IsPrimaryKey = false
                colvarBValido.IsForeignKey = false
                colvarBValido.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBValido)
                
                Dim colvarCCorreo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCorreo.ColumnName = "cCorreo"
                colvarCCorreo.DataType = DbType.AnsiString
                colvarCCorreo.MaxLength = 255
                colvarCCorreo.AutoIncrement = false
                colvarCCorreo.IsNullable = true
                colvarCCorreo.IsPrimaryKey = false
                colvarCCorreo.IsForeignKey = false
                colvarCCorreo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCorreo)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Empresa",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodEmpresa")> _
        Public Property NCodEmpresa As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodEmpresa)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEmpresa, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CRazonSocial")> _
        Public Property CRazonSocial As String 
			Get
				Return GetColumnValue(Of String)(Columns.CRazonSocial)
			End Get
		    
			Set
				SetColumnValue(Columns.CRazonSocial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CPropietario")> _
        Public Property CPropietario As String 
			Get
				Return GetColumnValue(Of String)(Columns.CPropietario)
			End Get
		    
			Set
				SetColumnValue(Columns.CPropietario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("ILogo")> _
        Public Property ILogo As Byte() 
			Get
				Return GetColumnValue(Of Byte())(Columns.ILogo)
			End Get
		    
			Set
				SetColumnValue(Columns.ILogo, Value)
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
        <XmlAttribute("CTelefonos")> _
        Public Property CTelefonos As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTelefonos)
			End Get
		    
			Set
				SetColumnValue(Columns.CTelefonos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCiudad")> _
        Public Property CCiudad As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCiudad)
			End Get
		    
			Set
				SetColumnValue(Columns.CCiudad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CEstado")> _
        Public Property CEstado As String 
			Get
				Return GetColumnValue(Of String)(Columns.CEstado)
			End Get
		    
			Set
				SetColumnValue(Columns.CEstado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CPais")> _
        Public Property CPais As String 
			Get
				Return GetColumnValue(Of String)(Columns.CPais)
			End Get
		    
			Set
				SetColumnValue(Columns.CPais, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BValido")> _
        Public Property BValido As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BValido)
			End Get
		    
			Set
				SetColumnValue(Columns.BValido, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCorreo")> _
        Public Property CCorreo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCorreo)
			End Get
		    
			Set
				SetColumnValue(Columns.CCorreo, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodEmpresa As Integer,ByVal varCRazonSocial As String,ByVal varCPropietario As String,ByVal varILogo As Byte(),ByVal varCDireccion As String,ByVal varCTelefonos As String,ByVal varCCiudad As String,ByVal varCEstado As String,ByVal varCPais As String,ByVal varBValido As Nullable(Of Boolean),ByVal varCCorreo As String)
			Dim item As Empresa = New Empresa()
			
            item.NCodEmpresa = varNCodEmpresa
            
            item.CRazonSocial = varCRazonSocial
            
            item.CPropietario = varCPropietario
            
            item.ILogo = varILogo
            
            item.CDireccion = varCDireccion
            
            item.CTelefonos = varCTelefonos
            
            item.CCiudad = varCCiudad
            
            item.CEstado = varCEstado
            
            item.CPais = varCPais
            
            item.BValido = varBValido
            
            item.CCorreo = varCCorreo
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodEmpresa As Integer,ByVal varCRazonSocial As String,ByVal varCPropietario As String,ByVal varILogo As Byte(),ByVal varCDireccion As String,ByVal varCTelefonos As String,ByVal varCCiudad As String,ByVal varCEstado As String,ByVal varCPais As String,ByVal varBValido As Nullable(Of Boolean),ByVal varCCorreo As String)
			Dim item As Empresa = New Empresa()
		    
                item.NCodEmpresa = varNCodEmpresa
				
                item.CRazonSocial = varCRazonSocial
				
                item.CPropietario = varCPropietario
				
                item.ILogo = varILogo
				
                item.CDireccion = varCDireccion
				
                item.CTelefonos = varCTelefonos
				
                item.CCiudad = varCCiudad
				
                item.CEstado = varCEstado
				
                item.CPais = varCPais
				
                item.BValido = varBValido
				
                item.CCorreo = varCCorreo
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodEmpresaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CRazonSocialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CPropietarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property ILogoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTelefonosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCiudadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CEstadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CPaisColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BValidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCorreoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodEmpresa As String = "nCodEmpresa"
            
            Public Shared CRazonSocial As String = "cRazonSocial"
            
            Public Shared CPropietario As String = "cPropietario"
            
            Public Shared ILogo As String = "iLogo"
            
            Public Shared CDireccion As String = "cDireccion"
            
            Public Shared CTelefonos As String = "cTelefonos"
            
            Public Shared CCiudad As String = "cCiudad"
            
            Public Shared CEstado As String = "cEstado"
            
            Public Shared CPais As String = "cPais"
            
            Public Shared BValido As String = "bValido"
            
            Public Shared CCorreo As String = "cCorreo"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
