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
	''' Strongly-typed collection for the NotaCredito class.
	''' </summary>
	<Serializable> _
	Public Partial Class NotaCreditoCollection 
	Inherits ActiveList(Of NotaCredito, NotaCreditoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As NotaCreditoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As NotaCredito = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_NotaCredito table.
	''' </summary>
	<Serializable> _
	Public Partial Class NotaCredito 
	Inherits ActiveRecord(Of NotaCredito)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_NotaCredito", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodNotaCredito As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodNotaCredito.ColumnName = "nCodNotaCredito"
                colvarNCodNotaCredito.DataType = DbType.Int32
                colvarNCodNotaCredito.MaxLength = 0
                colvarNCodNotaCredito.AutoIncrement = false
                colvarNCodNotaCredito.IsNullable = false
                colvarNCodNotaCredito.IsPrimaryKey = true
                colvarNCodNotaCredito.IsForeignKey = false
                colvarNCodNotaCredito.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodNotaCredito)
                
                Dim colvarDFecha As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFecha.ColumnName = "dFecha"
                colvarDFecha.DataType = DbType.AnsiString
                colvarDFecha.MaxLength = 0
                colvarDFecha.AutoIncrement = false
                colvarDFecha.IsNullable = false
                colvarDFecha.IsPrimaryKey = false
                colvarDFecha.IsForeignKey = false
                colvarDFecha.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFecha)
                
                Dim colvarNCodCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCliente.ColumnName = "nCodCliente"
                colvarNCodCliente.DataType = DbType.Int32
                colvarNCodCliente.MaxLength = 0
                colvarNCodCliente.AutoIncrement = false
                colvarNCodCliente.IsNullable = false
                colvarNCodCliente.IsPrimaryKey = false
                colvarNCodCliente.IsForeignKey = false
                colvarNCodCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCliente)
                
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
                
                Dim colvarDFechaRegistro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaRegistro.ColumnName = "dFechaRegistro"
                colvarDFechaRegistro.DataType = DbType.AnsiString
                colvarDFechaRegistro.MaxLength = 0
                colvarDFechaRegistro.AutoIncrement = false
                colvarDFechaRegistro.IsNullable = false
                colvarDFechaRegistro.IsPrimaryKey = false
                colvarDFechaRegistro.IsForeignKey = false
                colvarDFechaRegistro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaRegistro)
                
                Dim colvarNCodPedido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodPedido.ColumnName = "nCodPedido"
                colvarNCodPedido.DataType = DbType.Int32
                colvarNCodPedido.MaxLength = 0
                colvarNCodPedido.AutoIncrement = false
                colvarNCodPedido.IsNullable = true
                colvarNCodPedido.IsPrimaryKey = false
                colvarNCodPedido.IsForeignKey = true
                colvarNCodPedido.IsReadOnly = false
                
                
				colvarNCodPedido.ForeignKeyTableName = "EJS_OrdenCompra"
                
                schema.Columns.Add(colvarNCodPedido)
                
                Dim colvarNCodVendedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodVendedor.ColumnName = "nCodVendedor"
                colvarNCodVendedor.DataType = DbType.AnsiString
                colvarNCodVendedor.MaxLength = 50
                colvarNCodVendedor.AutoIncrement = false
                colvarNCodVendedor.IsNullable = false
                colvarNCodVendedor.IsPrimaryKey = false
                colvarNCodVendedor.IsForeignKey = false
                colvarNCodVendedor.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodVendedor)
                
                Dim colvarNValorPedido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNValorPedido.ColumnName = "nValorPedido"
                colvarNValorPedido.DataType = DbType.Currency
                colvarNValorPedido.MaxLength = 0
                colvarNValorPedido.AutoIncrement = false
                colvarNValorPedido.IsNullable = false
                colvarNValorPedido.IsPrimaryKey = false
                colvarNValorPedido.IsForeignKey = false
                colvarNValorPedido.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNValorPedido)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_NotaCredito",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodNotaCredito")> _
        Public Property NCodNotaCredito As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodNotaCredito)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodNotaCredito, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFecha")> _
        Public Property DFecha As String 
			Get
				Return GetColumnValue(Of String)(Columns.DFecha)
			End Get
		    
			Set
				SetColumnValue(Columns.DFecha, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodCliente")> _
        Public Property NCodCliente As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCliente, Value)
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
        <XmlAttribute("DFechaRegistro")> _
        Public Property DFechaRegistro As String 
			Get
				Return GetColumnValue(Of String)(Columns.DFechaRegistro)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaRegistro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodPedido")> _
        Public Property NCodPedido As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodPedido)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodPedido, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodVendedor")> _
        Public Property NCodVendedor As String 
			Get
				Return GetColumnValue(Of String)(Columns.NCodVendedor)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodVendedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NValorPedido")> _
        Public Property NValorPedido As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NValorPedido)
			End Get
		    
			Set
				SetColumnValue(Columns.NValorPedido, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a OrdenCompra ActiveRecord object related to this NotaCredito
		''' </summary>
		Public Property OrdenCompra() As EjSuite.OrdenCompra
			Get
				Return EjSuite.OrdenCompra.FetchByID(Me.NCodPedido)
			End Get
			Set
				SetColumnValue("nCodPedido", Value.NCodPedido)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodNotaCredito As Integer,ByVal varDFecha As String,ByVal varNCodCliente As Integer,ByVal varNCodUsuario As Integer,ByVal varDFechaRegistro As String,ByVal varNCodPedido As Nullable(Of Integer),ByVal varNCodVendedor As String,ByVal varNValorPedido As Decimal)
			Dim item As NotaCredito = New NotaCredito()
			
            item.NCodNotaCredito = varNCodNotaCredito
            
            item.DFecha = varDFecha
            
            item.NCodCliente = varNCodCliente
            
            item.NCodUsuario = varNCodUsuario
            
            item.DFechaRegistro = varDFechaRegistro
            
            item.NCodPedido = varNCodPedido
            
            item.NCodVendedor = varNCodVendedor
            
            item.NValorPedido = varNValorPedido
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodNotaCredito As Integer,ByVal varDFecha As String,ByVal varNCodCliente As Integer,ByVal varNCodUsuario As Integer,ByVal varDFechaRegistro As String,ByVal varNCodPedido As Nullable(Of Integer),ByVal varNCodVendedor As String,ByVal varNValorPedido As Decimal)
			Dim item As NotaCredito = New NotaCredito()
		    
                item.NCodNotaCredito = varNCodNotaCredito
				
                item.DFecha = varDFecha
				
                item.NCodCliente = varNCodCliente
				
                item.NCodUsuario = varNCodUsuario
				
                item.DFechaRegistro = varDFechaRegistro
				
                item.NCodPedido = varNCodPedido
				
                item.NCodVendedor = varNCodVendedor
				
                item.NValorPedido = varNValorPedido
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodNotaCreditoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaRegistroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodPedidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodVendedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NValorPedidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodNotaCredito As String = "nCodNotaCredito"
            
            Public Shared DFecha As String = "dFecha"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared DFechaRegistro As String = "dFechaRegistro"
            
            Public Shared NCodPedido As String = "nCodPedido"
            
            Public Shared NCodVendedor As String = "nCodVendedor"
            
            Public Shared NValorPedido As String = "nValorPedido"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
