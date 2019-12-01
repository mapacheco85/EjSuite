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
	''' Strongly-typed collection for the OrdenCompra class.
	''' </summary>
	<Serializable> _
	Public Partial Class OrdenCompraCollection 
	Inherits ActiveList(Of OrdenCompra, OrdenCompraCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As OrdenCompraCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As OrdenCompra = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_OrdenCompra table.
	''' </summary>
	<Serializable> _
	Public Partial Class OrdenCompra 
	Inherits ActiveRecord(Of OrdenCompra)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_OrdenCompra", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodPedido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodPedido.ColumnName = "nCodPedido"
                colvarNCodPedido.DataType = DbType.Int32
                colvarNCodPedido.MaxLength = 0
                colvarNCodPedido.AutoIncrement = false
                colvarNCodPedido.IsNullable = false
                colvarNCodPedido.IsPrimaryKey = true
                colvarNCodPedido.IsForeignKey = false
                colvarNCodPedido.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodPedido)
                
                Dim colvarCNit As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNit.ColumnName = "cNit"
                colvarCNit.DataType = DbType.AnsiString
                colvarCNit.MaxLength = 20
                colvarCNit.AutoIncrement = false
                colvarCNit.IsNullable = true
                colvarCNit.IsPrimaryKey = false
                colvarCNit.IsForeignKey = false
                colvarCNit.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNit)
                
                Dim colvarCNumeroOC As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNumeroOC.ColumnName = "cNumeroOC"
                colvarCNumeroOC.DataType = DbType.AnsiString
                colvarCNumeroOC.MaxLength = 20
                colvarCNumeroOC.AutoIncrement = false
                colvarCNumeroOC.IsNullable = false
                colvarCNumeroOC.IsPrimaryKey = false
                colvarCNumeroOC.IsForeignKey = false
                colvarCNumeroOC.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNumeroOC)
                
                Dim colvarDFechaEntrega As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaEntrega.ColumnName = "dFechaEntrega"
                colvarDFechaEntrega.DataType = DbType.DateTime
                colvarDFechaEntrega.MaxLength = 0
                colvarDFechaEntrega.AutoIncrement = false
                colvarDFechaEntrega.IsNullable = false
                colvarDFechaEntrega.IsPrimaryKey = false
                colvarDFechaEntrega.IsForeignKey = false
                colvarDFechaEntrega.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaEntrega)
                
                Dim colvarNFacturaAsociada As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNFacturaAsociada.ColumnName = "nFacturaAsociada"
                colvarNFacturaAsociada.DataType = DbType.Int32
                colvarNFacturaAsociada.MaxLength = 0
                colvarNFacturaAsociada.AutoIncrement = false
                colvarNFacturaAsociada.IsNullable = false
                colvarNFacturaAsociada.IsPrimaryKey = false
                colvarNFacturaAsociada.IsForeignKey = false
                colvarNFacturaAsociada.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNFacturaAsociada)
                
                Dim colvarBEntregado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEntregado.ColumnName = "bEntregado"
                colvarBEntregado.DataType = DbType.Boolean
                colvarBEntregado.MaxLength = 0
                colvarBEntregado.AutoIncrement = false
                colvarBEntregado.IsNullable = false
                colvarBEntregado.IsPrimaryKey = false
                colvarBEntregado.IsForeignKey = false
                colvarBEntregado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEntregado)
                
                Dim colvarBNotaDebito As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBNotaDebito.ColumnName = "bNotaDebito"
                colvarBNotaDebito.DataType = DbType.Boolean
                colvarBNotaDebito.MaxLength = 0
                colvarBNotaDebito.AutoIncrement = false
                colvarBNotaDebito.IsNullable = false
                colvarBNotaDebito.IsPrimaryKey = false
                colvarBNotaDebito.IsForeignKey = false
                colvarBNotaDebito.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBNotaDebito)
                
                Dim colvarNCodSucursal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = false
                colvarNCodSucursal.IsNullable = false
                colvarNCodSucursal.IsPrimaryKey = false
                colvarNCodSucursal.IsForeignKey = false
                colvarNCodSucursal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarBAnulado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBAnulado.ColumnName = "bAnulado"
                colvarBAnulado.DataType = DbType.Boolean
                colvarBAnulado.MaxLength = 0
                colvarBAnulado.AutoIncrement = false
                colvarBAnulado.IsNullable = true
                colvarBAnulado.IsPrimaryKey = false
                colvarBAnulado.IsForeignKey = false
                colvarBAnulado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBAnulado)
                
                Dim colvarDFechaSolicitud As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaSolicitud.ColumnName = "dFechaSolicitud"
                colvarDFechaSolicitud.DataType = DbType.AnsiString
                colvarDFechaSolicitud.MaxLength = 0
                colvarDFechaSolicitud.AutoIncrement = false
                colvarDFechaSolicitud.IsNullable = true
                colvarDFechaSolicitud.IsPrimaryKey = false
                colvarDFechaSolicitud.IsForeignKey = false
                colvarDFechaSolicitud.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaSolicitud)
                
                Dim colvarBNotaCredito As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBNotaCredito.ColumnName = "bNotaCredito"
                colvarBNotaCredito.DataType = DbType.Boolean
                colvarBNotaCredito.MaxLength = 0
                colvarBNotaCredito.AutoIncrement = false
                colvarBNotaCredito.IsNullable = true
                colvarBNotaCredito.IsPrimaryKey = false
                colvarBNotaCredito.IsForeignKey = false
                colvarBNotaCredito.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBNotaCredito)
                
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
                
                Dim colvarNCodVendedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodVendedor.ColumnName = "nCodVendedor"
                colvarNCodVendedor.DataType = DbType.Int32
                colvarNCodVendedor.MaxLength = 0
                colvarNCodVendedor.AutoIncrement = false
                colvarNCodVendedor.IsNullable = true
                colvarNCodVendedor.IsPrimaryKey = false
                colvarNCodVendedor.IsForeignKey = false
                colvarNCodVendedor.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodVendedor)
                
                Dim colvarNCodBeneficiario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodBeneficiario.ColumnName = "nCodBeneficiario"
                colvarNCodBeneficiario.DataType = DbType.Int32
                colvarNCodBeneficiario.MaxLength = 0
                colvarNCodBeneficiario.AutoIncrement = false
                colvarNCodBeneficiario.IsNullable = true
                colvarNCodBeneficiario.IsPrimaryKey = false
                colvarNCodBeneficiario.IsForeignKey = false
                colvarNCodBeneficiario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodBeneficiario)
                
                Dim colvarCFirmaCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCFirmaCliente.ColumnName = "cFirmaCliente"
                colvarCFirmaCliente.DataType = DbType.AnsiString
                colvarCFirmaCliente.MaxLength = 200
                colvarCFirmaCliente.AutoIncrement = false
                colvarCFirmaCliente.IsNullable = true
                colvarCFirmaCliente.IsPrimaryKey = false
                colvarCFirmaCliente.IsForeignKey = false
                colvarCFirmaCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCFirmaCliente)
                
                Dim colvarCEstadoEnvio As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCEstadoEnvio.ColumnName = "cEstadoEnvio"
                colvarCEstadoEnvio.DataType = DbType.AnsiStringFixedLength
                colvarCEstadoEnvio.MaxLength = 1
                colvarCEstadoEnvio.AutoIncrement = false
                colvarCEstadoEnvio.IsNullable = true
                colvarCEstadoEnvio.IsPrimaryKey = false
                colvarCEstadoEnvio.IsForeignKey = false
                colvarCEstadoEnvio.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCEstadoEnvio)
                
                Dim colvarBEsPedido As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsPedido.ColumnName = "bEsPedido"
                colvarBEsPedido.DataType = DbType.Boolean
                colvarBEsPedido.MaxLength = 0
                colvarBEsPedido.AutoIncrement = false
                colvarBEsPedido.IsNullable = true
                colvarBEsPedido.IsPrimaryKey = false
                colvarBEsPedido.IsForeignKey = false
                colvarBEsPedido.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsPedido)
                
                Dim colvarBEsOC As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsOC.ColumnName = "bEsOC"
                colvarBEsOC.DataType = DbType.Boolean
                colvarBEsOC.MaxLength = 0
                colvarBEsOC.AutoIncrement = false
                colvarBEsOC.IsNullable = true
                colvarBEsOC.IsPrimaryKey = false
                colvarBEsOC.IsForeignKey = false
                colvarBEsOC.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsOC)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_OrdenCompra",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodPedido")> _
        Public Property NCodPedido As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodPedido)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodPedido, Value)
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
        <XmlAttribute("CNumeroOC")> _
        Public Property CNumeroOC As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNumeroOC)
			End Get
		    
			Set
				SetColumnValue(Columns.CNumeroOC, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaEntrega")> _
        Public Property DFechaEntrega As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaEntrega)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaEntrega, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NFacturaAsociada")> _
        Public Property NFacturaAsociada As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NFacturaAsociada)
			End Get
		    
			Set
				SetColumnValue(Columns.NFacturaAsociada, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEntregado")> _
        Public Property BEntregado As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEntregado)
			End Get
		    
			Set
				SetColumnValue(Columns.BEntregado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BNotaDebito")> _
        Public Property BNotaDebito As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BNotaDebito)
			End Get
		    
			Set
				SetColumnValue(Columns.BNotaDebito, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodSucursal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSucursal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BAnulado")> _
        Public Property BAnulado As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BAnulado)
			End Get
		    
			Set
				SetColumnValue(Columns.BAnulado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaSolicitud")> _
        Public Property DFechaSolicitud As String 
			Get
				Return GetColumnValue(Of String)(Columns.DFechaSolicitud)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaSolicitud, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BNotaCredito")> _
        Public Property BNotaCredito As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BNotaCredito)
			End Get
		    
			Set
				SetColumnValue(Columns.BNotaCredito, Value)
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
        <XmlAttribute("NCodVendedor")> _
        Public Property NCodVendedor As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodVendedor)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodVendedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodBeneficiario")> _
        Public Property NCodBeneficiario As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodBeneficiario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodBeneficiario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CFirmaCliente")> _
        Public Property CFirmaCliente As String 
			Get
				Return GetColumnValue(Of String)(Columns.CFirmaCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.CFirmaCliente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CEstadoEnvio")> _
        Public Property CEstadoEnvio As String 
			Get
				Return GetColumnValue(Of String)(Columns.CEstadoEnvio)
			End Get
		    
			Set
				SetColumnValue(Columns.CEstadoEnvio, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsPedido")> _
        Public Property BEsPedido As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BEsPedido)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsPedido, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsOC")> _
        Public Property BEsOC As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BEsOC)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsOC, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function NotaCreditoRecords() As EjSuite.NotaCreditoCollection 
	
				Return New EjSuite.NotaCreditoCollection().Where(NotaCredito.Columns.NCodPedido, NCodPedido).Load()
	
			End Function
			
			Public Function NotaDebitoRecords() As EjSuite.NotaDebitoCollection 
	
				Return New EjSuite.NotaDebitoCollection().Where(NotaDebito.Columns.NCodPedido, NCodPedido).Load()
	
			End Function
			
			Public Function OrdenCompraDetalleRecords() As EjSuite.OrdenCompraDetalleCollection 
	
				Return New EjSuite.OrdenCompraDetalleCollection().Where(OrdenCompraDetalle.Columns.NCodPedido, NCodPedido).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodPedido As Integer,ByVal varCNit As String,ByVal varCNumeroOC As String,ByVal varDFechaEntrega As DateTime,ByVal varNFacturaAsociada As Integer,ByVal varBEntregado As Boolean,ByVal varBNotaDebito As Boolean,ByVal varNCodSucursal As Integer,ByVal varBAnulado As Nullable(Of Boolean),ByVal varDFechaSolicitud As String,ByVal varBNotaCredito As Nullable(Of Boolean),ByVal varNCodCliente As Integer,ByVal varNCodVendedor As Nullable(Of Integer),ByVal varNCodBeneficiario As Nullable(Of Integer),ByVal varCFirmaCliente As String,ByVal varCEstadoEnvio As String,ByVal varBEsPedido As Nullable(Of Boolean),ByVal varBEsOC As Nullable(Of Boolean))
			Dim item As OrdenCompra = New OrdenCompra()
			
            item.NCodPedido = varNCodPedido
            
            item.CNit = varCNit
            
            item.CNumeroOC = varCNumeroOC
            
            item.DFechaEntrega = varDFechaEntrega
            
            item.NFacturaAsociada = varNFacturaAsociada
            
            item.BEntregado = varBEntregado
            
            item.BNotaDebito = varBNotaDebito
            
            item.NCodSucursal = varNCodSucursal
            
            item.BAnulado = varBAnulado
            
            item.DFechaSolicitud = varDFechaSolicitud
            
            item.BNotaCredito = varBNotaCredito
            
            item.NCodCliente = varNCodCliente
            
            item.NCodVendedor = varNCodVendedor
            
            item.NCodBeneficiario = varNCodBeneficiario
            
            item.CFirmaCliente = varCFirmaCliente
            
            item.CEstadoEnvio = varCEstadoEnvio
            
            item.BEsPedido = varBEsPedido
            
            item.BEsOC = varBEsOC
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodPedido As Integer,ByVal varCNit As String,ByVal varCNumeroOC As String,ByVal varDFechaEntrega As DateTime,ByVal varNFacturaAsociada As Integer,ByVal varBEntregado As Boolean,ByVal varBNotaDebito As Boolean,ByVal varNCodSucursal As Integer,ByVal varBAnulado As Nullable(Of Boolean),ByVal varDFechaSolicitud As String,ByVal varBNotaCredito As Nullable(Of Boolean),ByVal varNCodCliente As Integer,ByVal varNCodVendedor As Nullable(Of Integer),ByVal varNCodBeneficiario As Nullable(Of Integer),ByVal varCFirmaCliente As String,ByVal varCEstadoEnvio As String,ByVal varBEsPedido As Nullable(Of Boolean),ByVal varBEsOC As Nullable(Of Boolean))
			Dim item As OrdenCompra = New OrdenCompra()
		    
                item.NCodPedido = varNCodPedido
				
                item.CNit = varCNit
				
                item.CNumeroOC = varCNumeroOC
				
                item.DFechaEntrega = varDFechaEntrega
				
                item.NFacturaAsociada = varNFacturaAsociada
				
                item.BEntregado = varBEntregado
				
                item.BNotaDebito = varBNotaDebito
				
                item.NCodSucursal = varNCodSucursal
				
                item.BAnulado = varBAnulado
				
                item.DFechaSolicitud = varDFechaSolicitud
				
                item.BNotaCredito = varBNotaCredito
				
                item.NCodCliente = varNCodCliente
				
                item.NCodVendedor = varNCodVendedor
				
                item.NCodBeneficiario = varNCodBeneficiario
				
                item.CFirmaCliente = varCFirmaCliente
				
                item.CEstadoEnvio = varCEstadoEnvio
				
                item.BEsPedido = varBEsPedido
				
                item.BEsOC = varBEsOC
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodPedidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNitColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNumeroOCColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaEntregaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NFacturaAsociadaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEntregadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BNotaDebitoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BAnuladoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaSolicitudColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BNotaCreditoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodVendedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodBeneficiarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CFirmaClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CEstadoEnvioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(15)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsPedidoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(16)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsOCColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(17)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodPedido As String = "nCodPedido"
            
            Public Shared CNit As String = "cNit"
            
            Public Shared CNumeroOC As String = "cNumeroOC"
            
            Public Shared DFechaEntrega As String = "dFechaEntrega"
            
            Public Shared NFacturaAsociada As String = "nFacturaAsociada"
            
            Public Shared BEntregado As String = "bEntregado"
            
            Public Shared BNotaDebito As String = "bNotaDebito"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared BAnulado As String = "bAnulado"
            
            Public Shared DFechaSolicitud As String = "dFechaSolicitud"
            
            Public Shared BNotaCredito As String = "bNotaCredito"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared NCodVendedor As String = "nCodVendedor"
            
            Public Shared NCodBeneficiario As String = "nCodBeneficiario"
            
            Public Shared CFirmaCliente As String = "cFirmaCliente"
            
            Public Shared CEstadoEnvio As String = "cEstadoEnvio"
            
            Public Shared BEsPedido As String = "bEsPedido"
            
            Public Shared BEsOC As String = "bEsOC"
            
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
