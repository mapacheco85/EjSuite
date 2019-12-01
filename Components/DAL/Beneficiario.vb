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
	''' Strongly-typed collection for the Beneficiario class.
	''' </summary>
	<Serializable> _
	Public Partial Class BeneficiarioCollection 
	Inherits ActiveList(Of Beneficiario, BeneficiarioCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As BeneficiarioCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Beneficiario = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Beneficiario table.
	''' </summary>
	<Serializable> _
	Public Partial Class Beneficiario 
	Inherits ActiveRecord(Of Beneficiario)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Beneficiario", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodBeneficiario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodBeneficiario.ColumnName = "nCodBeneficiario"
                colvarNCodBeneficiario.DataType = DbType.Int32
                colvarNCodBeneficiario.MaxLength = 0
                colvarNCodBeneficiario.AutoIncrement = false
                colvarNCodBeneficiario.IsNullable = false
                colvarNCodBeneficiario.IsPrimaryKey = true
                colvarNCodBeneficiario.IsForeignKey = false
                colvarNCodBeneficiario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodBeneficiario)
                
                Dim colvarNCodCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCliente.ColumnName = "nCodCliente"
                colvarNCodCliente.DataType = DbType.Int64
                colvarNCodCliente.MaxLength = 0
                colvarNCodCliente.AutoIncrement = false
                colvarNCodCliente.IsNullable = false
                colvarNCodCliente.IsPrimaryKey = false
                colvarNCodCliente.IsForeignKey = true
                colvarNCodCliente.IsReadOnly = false
                
                
				colvarNCodCliente.ForeignKeyTableName = "EJS_Cliente"
                
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
                
                Dim colvarDFechaReg As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaReg.ColumnName = "dFechaReg"
                colvarDFechaReg.DataType = DbType.DateTime
                colvarDFechaReg.MaxLength = 0
                colvarDFechaReg.AutoIncrement = false
                colvarDFechaReg.IsNullable = false
                colvarDFechaReg.IsPrimaryKey = false
                colvarDFechaReg.IsForeignKey = false
                colvarDFechaReg.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaReg)
                
                Dim colvarCDireccion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDireccion.ColumnName = "cDireccion"
                colvarCDireccion.DataType = DbType.AnsiString
                colvarCDireccion.MaxLength = -1
                colvarCDireccion.AutoIncrement = false
                colvarCDireccion.IsNullable = true
                colvarCDireccion.IsPrimaryKey = false
                colvarCDireccion.IsForeignKey = false
                colvarCDireccion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDireccion)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Beneficiario",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodBeneficiario")> _
        Public Property NCodBeneficiario As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodBeneficiario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodBeneficiario, Value)
			End Set
		End Property
		
		
		
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
        <XmlAttribute("DFechaReg")> _
        Public Property DFechaReg As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaReg)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaReg, Value)
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
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Cliente ActiveRecord object related to this Beneficiario
		''' </summary>
		Public Property Cliente() As EjSuite.Cliente
			Get
				Return EjSuite.Cliente.FetchByID(Me.NCodCliente)
			End Get
			Set
				SetColumnValue("nCodCliente", Value.NCodCliente)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodBeneficiario As Integer,ByVal varNCodCliente As Long,ByVal varCNit As String,ByVal varCNombre As String,ByVal varDFechaReg As DateTime,ByVal varCDireccion As String)
			Dim item As Beneficiario = New Beneficiario()
			
            item.NCodBeneficiario = varNCodBeneficiario
            
            item.NCodCliente = varNCodCliente
            
            item.CNit = varCNit
            
            item.CNombre = varCNombre
            
            item.DFechaReg = varDFechaReg
            
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
		Public Shared Sub Update(ByVal varNCodBeneficiario As Integer,ByVal varNCodCliente As Long,ByVal varCNit As String,ByVal varCNombre As String,ByVal varDFechaReg As DateTime,ByVal varCDireccion As String)
			Dim item As Beneficiario = New Beneficiario()
		    
                item.NCodBeneficiario = varNCodBeneficiario
				
                item.NCodCliente = varNCodCliente
				
                item.CNit = varCNit
				
                item.CNombre = varCNombre
				
                item.DFechaReg = varDFechaReg
				
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
        
        
        Public Shared ReadOnly Property NCodBeneficiarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNitColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombreColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaRegColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDireccionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodBeneficiario As String = "nCodBeneficiario"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CNit As String = "cNit"
            
            Public Shared CNombre As String = "cNombre"
            
            Public Shared DFechaReg As String = "dFechaReg"
            
            Public Shared CDireccion As String = "cDireccion"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
