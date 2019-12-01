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
	''' Strongly-typed collection for the Factura class.
	''' </summary>
	<Serializable> _
	Public Partial Class FacturaCollection 
	Inherits ActiveList(Of Factura, FacturaCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As FacturaCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Factura = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Factura table.
	''' </summary>
	<Serializable> _
	Public Partial Class Factura 
	Inherits ActiveRecord(Of Factura)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Factura", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodFactura As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodFactura.ColumnName = "nCodFactura"
                colvarNCodFactura.DataType = DbType.Int64
                colvarNCodFactura.MaxLength = 0
                colvarNCodFactura.AutoIncrement = false
                colvarNCodFactura.IsNullable = false
                colvarNCodFactura.IsPrimaryKey = true
                colvarNCodFactura.IsForeignKey = false
                colvarNCodFactura.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodFactura)
                
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
                
                Dim colvarCNombreFactura As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNombreFactura.ColumnName = "cNombreFactura"
                colvarCNombreFactura.DataType = DbType.AnsiString
                colvarCNombreFactura.MaxLength = 255
                colvarCNombreFactura.AutoIncrement = false
                colvarCNombreFactura.IsNullable = false
                colvarCNombreFactura.IsPrimaryKey = false
                colvarCNombreFactura.IsForeignKey = false
                colvarCNombreFactura.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNombreFactura)
                
                Dim colvarNNumero As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNNumero.ColumnName = "nNumero"
                colvarNNumero.DataType = DbType.Int32
                colvarNNumero.MaxLength = 0
                colvarNNumero.AutoIncrement = false
                colvarNNumero.IsNullable = false
                colvarNNumero.IsPrimaryKey = false
                colvarNNumero.IsForeignKey = false
                colvarNNumero.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNNumero)
                
                Dim colvarCAutorizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCAutorizacion.ColumnName = "cAutorizacion"
                colvarCAutorizacion.DataType = DbType.AnsiString
                colvarCAutorizacion.MaxLength = 20
                colvarCAutorizacion.AutoIncrement = false
                colvarCAutorizacion.IsNullable = false
                colvarCAutorizacion.IsPrimaryKey = false
                colvarCAutorizacion.IsForeignKey = false
                colvarCAutorizacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCAutorizacion)
                
                Dim colvarCCodigoFactura As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCodigoFactura.ColumnName = "cCodigoFactura"
                colvarCCodigoFactura.DataType = DbType.AnsiString
                colvarCCodigoFactura.MaxLength = 15
                colvarCCodigoFactura.AutoIncrement = false
                colvarCCodigoFactura.IsNullable = false
                colvarCCodigoFactura.IsPrimaryKey = false
                colvarCCodigoFactura.IsForeignKey = false
                colvarCCodigoFactura.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCodigoFactura)
                
                Dim colvarCLlaveDosificacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCLlaveDosificacion.ColumnName = "cLlaveDosificacion"
                colvarCLlaveDosificacion.DataType = DbType.AnsiString
                colvarCLlaveDosificacion.MaxLength = 255
                colvarCLlaveDosificacion.AutoIncrement = false
                colvarCLlaveDosificacion.IsNullable = false
                colvarCLlaveDosificacion.IsPrimaryKey = false
                colvarCLlaveDosificacion.IsForeignKey = false
                colvarCLlaveDosificacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCLlaveDosificacion)
                
                Dim colvarDFechaEmision As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaEmision.ColumnName = "dFechaEmision"
                colvarDFechaEmision.DataType = DbType.DateTime
                colvarDFechaEmision.MaxLength = 0
                colvarDFechaEmision.AutoIncrement = false
                colvarDFechaEmision.IsNullable = true
                colvarDFechaEmision.IsPrimaryKey = false
                colvarDFechaEmision.IsForeignKey = false
                colvarDFechaEmision.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaEmision)
                
                Dim colvarDFechaLimite As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaLimite.ColumnName = "dFechaLimite"
                colvarDFechaLimite.DataType = DbType.DateTime
                colvarDFechaLimite.MaxLength = 0
                colvarDFechaLimite.AutoIncrement = false
                colvarDFechaLimite.IsNullable = false
                colvarDFechaLimite.IsPrimaryKey = false
                colvarDFechaLimite.IsForeignKey = false
                colvarDFechaLimite.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaLimite)
                
                Dim colvarDVencimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDVencimiento.ColumnName = "dVencimiento"
                colvarDVencimiento.DataType = DbType.DateTime
                colvarDVencimiento.MaxLength = 0
                colvarDVencimiento.AutoIncrement = false
                colvarDVencimiento.IsNullable = true
                colvarDVencimiento.IsPrimaryKey = false
                colvarDVencimiento.IsForeignKey = false
                colvarDVencimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDVencimiento)
                
                Dim colvarBPendiente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBPendiente.ColumnName = "bPendiente"
                colvarBPendiente.DataType = DbType.Boolean
                colvarBPendiente.MaxLength = 0
                colvarBPendiente.AutoIncrement = false
                colvarBPendiente.IsNullable = false
                colvarBPendiente.IsPrimaryKey = false
                colvarBPendiente.IsForeignKey = false
                colvarBPendiente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBPendiente)
                
                Dim colvarBPagada As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBPagada.ColumnName = "bPagada"
                colvarBPagada.DataType = DbType.Boolean
                colvarBPagada.MaxLength = 0
                colvarBPagada.AutoIncrement = false
                colvarBPagada.IsNullable = false
                colvarBPagada.IsPrimaryKey = false
                colvarBPagada.IsForeignKey = false
                colvarBPagada.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBPagada)
                
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
                
                Dim colvarCValorQR As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCValorQR.ColumnName = "cValorQR"
                colvarCValorQR.DataType = DbType.AnsiString
                colvarCValorQR.MaxLength = 255
                colvarCValorQR.AutoIncrement = false
                colvarCValorQR.IsNullable = false
                colvarCValorQR.IsPrimaryKey = false
                colvarCValorQR.IsForeignKey = false
                colvarCValorQR.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCValorQR)
                
                Dim colvarNCodCuenta As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCuenta.ColumnName = "nCodCuenta"
                colvarNCodCuenta.DataType = DbType.Int32
                colvarNCodCuenta.MaxLength = 0
                colvarNCodCuenta.AutoIncrement = false
                colvarNCodCuenta.IsNullable = true
                colvarNCodCuenta.IsPrimaryKey = false
                colvarNCodCuenta.IsForeignKey = false
                colvarNCodCuenta.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCuenta)
                
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
                
                Dim colvarDFechaContabilidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaContabilidad.ColumnName = "dFechaContabilidad"
                colvarDFechaContabilidad.DataType = DbType.DateTime
                colvarDFechaContabilidad.MaxLength = 0
                colvarDFechaContabilidad.AutoIncrement = false
                colvarDFechaContabilidad.IsNullable = true
                colvarDFechaContabilidad.IsPrimaryKey = false
                colvarDFechaContabilidad.IsForeignKey = false
                colvarDFechaContabilidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaContabilidad)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Factura",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodFactura")> _
        Public Property NCodFactura As Long 
			Get
				Return GetColumnValue(Of Long)(Columns.NCodFactura)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodFactura, Value)
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
        <XmlAttribute("CNombreFactura")> _
        Public Property CNombreFactura As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNombreFactura)
			End Get
		    
			Set
				SetColumnValue(Columns.CNombreFactura, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NNumero")> _
        Public Property NNumero As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NNumero)
			End Get
		    
			Set
				SetColumnValue(Columns.NNumero, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CAutorizacion")> _
        Public Property CAutorizacion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CAutorizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.CAutorizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCodigoFactura")> _
        Public Property CCodigoFactura As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCodigoFactura)
			End Get
		    
			Set
				SetColumnValue(Columns.CCodigoFactura, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CLlaveDosificacion")> _
        Public Property CLlaveDosificacion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CLlaveDosificacion)
			End Get
		    
			Set
				SetColumnValue(Columns.CLlaveDosificacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaEmision")> _
        Public Property DFechaEmision As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaEmision)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaEmision, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaLimite")> _
        Public Property DFechaLimite As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaLimite)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaLimite, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DVencimiento")> _
        Public Property DVencimiento As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DVencimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.DVencimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BPendiente")> _
        Public Property BPendiente As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BPendiente)
			End Get
		    
			Set
				SetColumnValue(Columns.BPendiente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BPagada")> _
        Public Property BPagada As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BPagada)
			End Get
		    
			Set
				SetColumnValue(Columns.BPagada, Value)
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
        <XmlAttribute("CValorQR")> _
        Public Property CValorQR As String 
			Get
				Return GetColumnValue(Of String)(Columns.CValorQR)
			End Get
		    
			Set
				SetColumnValue(Columns.CValorQR, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodCuenta")> _
        Public Property NCodCuenta As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodCuenta)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCuenta, Value)
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
        <XmlAttribute("DFechaContabilidad")> _
        Public Property DFechaContabilidad As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaContabilidad)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaContabilidad, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function DetalleRecords() As EjSuite.DetalleCollection 
	
				Return New EjSuite.DetalleCollection().Where(Detalle.Columns.NcodFactura, NCodFactura).Load()
	
			End Function
			
			Public Function PagoCuentaXCobrarRecords() As EjSuite.PagoCuentaXCobrarCollection 
	
				Return New EjSuite.PagoCuentaXCobrarCollection().Where(PagoCuentaXCobrar.Columns.NFacturaId, NCodFactura).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Cliente ActiveRecord object related to this Factura
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
		Public Shared Sub Insert(ByVal varNCodFactura As Long,ByVal varCNit As String,ByVal varCNombreFactura As String,ByVal varNNumero As Integer,ByVal varCAutorizacion As String,ByVal varCCodigoFactura As String,ByVal varCLlaveDosificacion As String,ByVal varDFechaEmision As Nullable(Of DateTime),ByVal varDFechaLimite As DateTime,ByVal varDVencimiento As Nullable(Of DateTime),ByVal varBPendiente As Boolean,ByVal varBPagada As Boolean,ByVal varBAnulado As Nullable(Of Boolean),ByVal varNCodSucursal As Integer,ByVal varNCodUsuario As Integer,ByVal varNCodCliente As Long,ByVal varCValorQR As String,ByVal varNCodCuenta As Nullable(Of Integer),ByVal varNCodVendedor As Nullable(Of Integer),ByVal varDFechaContabilidad As Nullable(Of DateTime))
			Dim item As Factura = New Factura()
			
            item.NCodFactura = varNCodFactura
            
            item.CNit = varCNit
            
            item.CNombreFactura = varCNombreFactura
            
            item.NNumero = varNNumero
            
            item.CAutorizacion = varCAutorizacion
            
            item.CCodigoFactura = varCCodigoFactura
            
            item.CLlaveDosificacion = varCLlaveDosificacion
            
            item.DFechaEmision = varDFechaEmision
            
            item.DFechaLimite = varDFechaLimite
            
            item.DVencimiento = varDVencimiento
            
            item.BPendiente = varBPendiente
            
            item.BPagada = varBPagada
            
            item.BAnulado = varBAnulado
            
            item.NCodSucursal = varNCodSucursal
            
            item.NCodUsuario = varNCodUsuario
            
            item.NCodCliente = varNCodCliente
            
            item.CValorQR = varCValorQR
            
            item.NCodCuenta = varNCodCuenta
            
            item.NCodVendedor = varNCodVendedor
            
            item.DFechaContabilidad = varDFechaContabilidad
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodFactura As Long,ByVal varCNit As String,ByVal varCNombreFactura As String,ByVal varNNumero As Integer,ByVal varCAutorizacion As String,ByVal varCCodigoFactura As String,ByVal varCLlaveDosificacion As String,ByVal varDFechaEmision As Nullable(Of DateTime),ByVal varDFechaLimite As DateTime,ByVal varDVencimiento As Nullable(Of DateTime),ByVal varBPendiente As Boolean,ByVal varBPagada As Boolean,ByVal varBAnulado As Nullable(Of Boolean),ByVal varNCodSucursal As Integer,ByVal varNCodUsuario As Integer,ByVal varNCodCliente As Long,ByVal varCValorQR As String,ByVal varNCodCuenta As Nullable(Of Integer),ByVal varNCodVendedor As Nullable(Of Integer),ByVal varDFechaContabilidad As Nullable(Of DateTime))
			Dim item As Factura = New Factura()
		    
                item.NCodFactura = varNCodFactura
				
                item.CNit = varCNit
				
                item.CNombreFactura = varCNombreFactura
				
                item.NNumero = varNNumero
				
                item.CAutorizacion = varCAutorizacion
				
                item.CCodigoFactura = varCCodigoFactura
				
                item.CLlaveDosificacion = varCLlaveDosificacion
				
                item.DFechaEmision = varDFechaEmision
				
                item.DFechaLimite = varDFechaLimite
				
                item.DVencimiento = varDVencimiento
				
                item.BPendiente = varBPendiente
				
                item.BPagada = varBPagada
				
                item.BAnulado = varBAnulado
				
                item.NCodSucursal = varNCodSucursal
				
                item.NCodUsuario = varNCodUsuario
				
                item.NCodCliente = varNCodCliente
				
                item.CValorQR = varCValorQR
				
                item.NCodCuenta = varNCodCuenta
				
                item.NCodVendedor = varNCodVendedor
				
                item.DFechaContabilidad = varDFechaContabilidad
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodFacturaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNitColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombreFacturaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NNumeroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CAutorizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCodigoFacturaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CLlaveDosificacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaEmisionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaLimiteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DVencimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BPendienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BPagadaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BAnuladoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodSucursalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(15)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CValorQRColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(16)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodCuentaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(17)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodVendedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(18)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaContabilidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(19)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodFactura As String = "nCodFactura"
            
            Public Shared CNit As String = "cNit"
            
            Public Shared CNombreFactura As String = "cNombreFactura"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared CAutorizacion As String = "cAutorizacion"
            
            Public Shared CCodigoFactura As String = "cCodigoFactura"
            
            Public Shared CLlaveDosificacion As String = "cLlaveDosificacion"
            
            Public Shared DFechaEmision As String = "dFechaEmision"
            
            Public Shared DFechaLimite As String = "dFechaLimite"
            
            Public Shared DVencimiento As String = "dVencimiento"
            
            Public Shared BPendiente As String = "bPendiente"
            
            Public Shared BPagada As String = "bPagada"
            
            Public Shared BAnulado As String = "bAnulado"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CValorQR As String = "cValorQR"
            
            Public Shared NCodCuenta As String = "nCodCuenta"
            
            Public Shared NCodVendedor As String = "nCodVendedor"
            
            Public Shared DFechaContabilidad As String = "dFechaContabilidad"
            
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
