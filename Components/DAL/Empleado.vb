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
	''' Strongly-typed collection for the Empleado class.
	''' </summary>
	<Serializable> _
	Public Partial Class EmpleadoCollection 
	Inherits ActiveList(Of Empleado, EmpleadoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As EmpleadoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Empleado = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Empleado table.
	''' </summary>
	<Serializable> _
	Public Partial Class Empleado 
	Inherits ActiveRecord(Of Empleado)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Empleado", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodEmpleado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEmpleado.ColumnName = "nCodEmpleado"
                colvarNCodEmpleado.DataType = DbType.Int32
                colvarNCodEmpleado.MaxLength = 0
                colvarNCodEmpleado.AutoIncrement = false
                colvarNCodEmpleado.IsNullable = false
                colvarNCodEmpleado.IsPrimaryKey = true
                colvarNCodEmpleado.IsForeignKey = false
                colvarNCodEmpleado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodEmpleado)
                
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
                
                Dim colvarNEstadoCivil As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEstadoCivil.ColumnName = "nEstadoCivil"
                colvarNEstadoCivil.DataType = DbType.Int32
                colvarNEstadoCivil.MaxLength = 0
                colvarNEstadoCivil.AutoIncrement = false
                colvarNEstadoCivil.IsNullable = true
                colvarNEstadoCivil.IsPrimaryKey = false
                colvarNEstadoCivil.IsForeignKey = false
                colvarNEstadoCivil.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEstadoCivil)
                
                Dim colvarCNombres As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNombres.ColumnName = "cNombres"
                colvarCNombres.DataType = DbType.AnsiString
                colvarCNombres.MaxLength = 255
                colvarCNombres.AutoIncrement = false
                colvarCNombres.IsNullable = false
                colvarCNombres.IsPrimaryKey = false
                colvarCNombres.IsForeignKey = false
                colvarCNombres.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNombres)
                
                Dim colvarCApellidoPaterno As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCApellidoPaterno.ColumnName = "cApellidoPaterno"
                colvarCApellidoPaterno.DataType = DbType.AnsiString
                colvarCApellidoPaterno.MaxLength = 255
                colvarCApellidoPaterno.AutoIncrement = false
                colvarCApellidoPaterno.IsNullable = true
                colvarCApellidoPaterno.IsPrimaryKey = false
                colvarCApellidoPaterno.IsForeignKey = false
                colvarCApellidoPaterno.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCApellidoPaterno)
                
                Dim colvarCApellidoMaterno As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCApellidoMaterno.ColumnName = "cApellidoMaterno"
                colvarCApellidoMaterno.DataType = DbType.AnsiString
                colvarCApellidoMaterno.MaxLength = 255
                colvarCApellidoMaterno.AutoIncrement = false
                colvarCApellidoMaterno.IsNullable = true
                colvarCApellidoMaterno.IsPrimaryKey = false
                colvarCApellidoMaterno.IsForeignKey = false
                colvarCApellidoMaterno.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCApellidoMaterno)
                
                Dim colvarCCarnetIdentidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCarnetIdentidad.ColumnName = "cCarnetIdentidad"
                colvarCCarnetIdentidad.DataType = DbType.AnsiString
                colvarCCarnetIdentidad.MaxLength = 255
                colvarCCarnetIdentidad.AutoIncrement = false
                colvarCCarnetIdentidad.IsNullable = false
                colvarCCarnetIdentidad.IsPrimaryKey = false
                colvarCCarnetIdentidad.IsForeignKey = false
                colvarCCarnetIdentidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCarnetIdentidad)
                
                Dim colvarCGarantias As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCGarantias.ColumnName = "cGarantias"
                colvarCGarantias.DataType = DbType.AnsiString
                colvarCGarantias.MaxLength = 255
                colvarCGarantias.AutoIncrement = false
                colvarCGarantias.IsNullable = false
                colvarCGarantias.IsPrimaryKey = false
                colvarCGarantias.IsForeignKey = false
                colvarCGarantias.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCGarantias)
                
                Dim colvarIFoto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarIFoto.ColumnName = "iFoto"
                colvarIFoto.DataType = DbType.Binary
                colvarIFoto.MaxLength = 2147483647
                colvarIFoto.AutoIncrement = false
                colvarIFoto.IsNullable = true
                colvarIFoto.IsPrimaryKey = false
                colvarIFoto.IsForeignKey = false
                colvarIFoto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarIFoto)
                
                Dim colvarIDocumentos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarIDocumentos.ColumnName = "iDocumentos"
                colvarIDocumentos.DataType = DbType.Binary
                colvarIDocumentos.MaxLength = -1
                colvarIDocumentos.AutoIncrement = false
                colvarIDocumentos.IsNullable = true
                colvarIDocumentos.IsPrimaryKey = false
                colvarIDocumentos.IsForeignKey = false
                colvarIDocumentos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarIDocumentos)
                
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
                
                Dim colvarCUsuario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCUsuario.ColumnName = "cUsuario"
                colvarCUsuario.DataType = DbType.AnsiString
                colvarCUsuario.MaxLength = 255
                colvarCUsuario.AutoIncrement = false
                colvarCUsuario.IsNullable = true
                colvarCUsuario.IsPrimaryKey = false
                colvarCUsuario.IsForeignKey = false
                colvarCUsuario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCUsuario)
                
                Dim colvarCClave As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCClave.ColumnName = "cClave"
                colvarCClave.DataType = DbType.AnsiString
                colvarCClave.MaxLength = 255
                colvarCClave.AutoIncrement = false
                colvarCClave.IsNullable = true
                colvarCClave.IsPrimaryKey = false
                colvarCClave.IsForeignKey = false
                colvarCClave.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCClave)
                
                Dim colvarNCodGrupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodGrupo.ColumnName = "nCodGrupo"
                colvarNCodGrupo.DataType = DbType.Int32
                colvarNCodGrupo.MaxLength = 0
                colvarNCodGrupo.AutoIncrement = false
                colvarNCodGrupo.IsNullable = true
                colvarNCodGrupo.IsPrimaryKey = false
                colvarNCodGrupo.IsForeignKey = false
                colvarNCodGrupo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodGrupo)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Empleado",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodEmpleado")> _
        Public Property NCodEmpleado As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodEmpleado)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEmpleado, Value)
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
        <XmlAttribute("NEstadoCivil")> _
        Public Property NEstadoCivil As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NEstadoCivil)
			End Get
		    
			Set
				SetColumnValue(Columns.NEstadoCivil, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNombres")> _
        Public Property CNombres As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNombres)
			End Get
		    
			Set
				SetColumnValue(Columns.CNombres, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CApellidoPaterno")> _
        Public Property CApellidoPaterno As String 
			Get
				Return GetColumnValue(Of String)(Columns.CApellidoPaterno)
			End Get
		    
			Set
				SetColumnValue(Columns.CApellidoPaterno, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CApellidoMaterno")> _
        Public Property CApellidoMaterno As String 
			Get
				Return GetColumnValue(Of String)(Columns.CApellidoMaterno)
			End Get
		    
			Set
				SetColumnValue(Columns.CApellidoMaterno, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCarnetIdentidad")> _
        Public Property CCarnetIdentidad As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCarnetIdentidad)
			End Get
		    
			Set
				SetColumnValue(Columns.CCarnetIdentidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CGarantias")> _
        Public Property CGarantias As String 
			Get
				Return GetColumnValue(Of String)(Columns.CGarantias)
			End Get
		    
			Set
				SetColumnValue(Columns.CGarantias, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("IFoto")> _
        Public Property IFoto As Byte() 
			Get
				Return GetColumnValue(Of Byte())(Columns.IFoto)
			End Get
		    
			Set
				SetColumnValue(Columns.IFoto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("IDocumentos")> _
        Public Property IDocumentos As Byte() 
			Get
				Return GetColumnValue(Of Byte())(Columns.IDocumentos)
			End Get
		    
			Set
				SetColumnValue(Columns.IDocumentos, Value)
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
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CUsuario")> _
        Public Property CUsuario As String 
			Get
				Return GetColumnValue(Of String)(Columns.CUsuario)
			End Get
		    
			Set
				SetColumnValue(Columns.CUsuario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CClave")> _
        Public Property CClave As String 
			Get
				Return GetColumnValue(Of String)(Columns.CClave)
			End Get
		    
			Set
				SetColumnValue(Columns.CClave, Value)
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
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function EmpleadoSucursalRecords() As EjSuite.EmpleadoSucursalCollection 
	
				Return New EjSuite.EmpleadoSucursalCollection().Where(EmpleadoSucursal.Columns.NCodEmpleado, NCodEmpleado).Load()
	
			End Function
			
			Public Function PagoCuentaXCobrarRecords() As EjSuite.PagoCuentaXCobrarCollection 
	
				Return New EjSuite.PagoCuentaXCobrarCollection().Where(PagoCuentaXCobrar.Columns.NCodCobrador, NCodEmpleado).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodEmpleado As Integer,ByVal varNCodUsuario As Integer,ByVal varNEstadoCivil As Nullable(Of Integer),ByVal varCNombres As String,ByVal varCApellidoPaterno As String,ByVal varCApellidoMaterno As String,ByVal varCCarnetIdentidad As String,ByVal varCGarantias As String,ByVal varIFoto As Byte(),ByVal varIDocumentos As Byte(),ByVal varBValido As Boolean,ByVal varCUsuario As String,ByVal varCClave As String,ByVal varNCodGrupo As Nullable(Of Integer))
			Dim item As Empleado = New Empleado()
			
            item.NCodEmpleado = varNCodEmpleado
            
            item.NCodUsuario = varNCodUsuario
            
            item.NEstadoCivil = varNEstadoCivil
            
            item.CNombres = varCNombres
            
            item.CApellidoPaterno = varCApellidoPaterno
            
            item.CApellidoMaterno = varCApellidoMaterno
            
            item.CCarnetIdentidad = varCCarnetIdentidad
            
            item.CGarantias = varCGarantias
            
            item.IFoto = varIFoto
            
            item.IDocumentos = varIDocumentos
            
            item.BValido = varBValido
            
            item.CUsuario = varCUsuario
            
            item.CClave = varCClave
            
            item.NCodGrupo = varNCodGrupo
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodEmpleado As Integer,ByVal varNCodUsuario As Integer,ByVal varNEstadoCivil As Nullable(Of Integer),ByVal varCNombres As String,ByVal varCApellidoPaterno As String,ByVal varCApellidoMaterno As String,ByVal varCCarnetIdentidad As String,ByVal varCGarantias As String,ByVal varIFoto As Byte(),ByVal varIDocumentos As Byte(),ByVal varBValido As Boolean,ByVal varCUsuario As String,ByVal varCClave As String,ByVal varNCodGrupo As Nullable(Of Integer))
			Dim item As Empleado = New Empleado()
		    
                item.NCodEmpleado = varNCodEmpleado
				
                item.NCodUsuario = varNCodUsuario
				
                item.NEstadoCivil = varNEstadoCivil
				
                item.CNombres = varCNombres
				
                item.CApellidoPaterno = varCApellidoPaterno
				
                item.CApellidoMaterno = varCApellidoMaterno
				
                item.CCarnetIdentidad = varCCarnetIdentidad
				
                item.CGarantias = varCGarantias
				
                item.IFoto = varIFoto
				
                item.IDocumentos = varIDocumentos
				
                item.BValido = varBValido
				
                item.CUsuario = varCUsuario
				
                item.CClave = varCClave
				
                item.NCodGrupo = varNCodGrupo
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodEmpleadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEstadoCivilColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombresColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CApellidoPaternoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CApellidoMaternoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCarnetIdentidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CGarantiasColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property IFotoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property IDocumentosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BValidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CClaveColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodGrupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodEmpleado As String = "nCodEmpleado"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared NEstadoCivil As String = "nEstadoCivil"
            
            Public Shared CNombres As String = "cNombres"
            
            Public Shared CApellidoPaterno As String = "cApellidoPaterno"
            
            Public Shared CApellidoMaterno As String = "cApellidoMaterno"
            
            Public Shared CCarnetIdentidad As String = "cCarnetIdentidad"
            
            Public Shared CGarantias As String = "cGarantias"
            
            Public Shared IFoto As String = "iFoto"
            
            Public Shared IDocumentos As String = "iDocumentos"
            
            Public Shared BValido As String = "bValido"
            
            Public Shared CUsuario As String = "cUsuario"
            
            Public Shared CClave As String = "cClave"
            
            Public Shared NCodGrupo As String = "nCodGrupo"
            
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
