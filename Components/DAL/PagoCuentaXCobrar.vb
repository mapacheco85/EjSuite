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
	''' Strongly-typed collection for the PagoCuentaXCobrar class.
	''' </summary>
	<Serializable> _
	Public Partial Class PagoCuentaXCobrarCollection 
	Inherits ActiveList(Of PagoCuentaXCobrar, PagoCuentaXCobrarCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As PagoCuentaXCobrarCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As PagoCuentaXCobrar = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_PagoCuentaXCobrar table.
	''' </summary>
	<Serializable> _
	Public Partial Class PagoCuentaXCobrar 
	Inherits ActiveRecord(Of PagoCuentaXCobrar)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_PagoCuentaXCobrar", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodPago As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodPago.ColumnName = "nCodPago"
                colvarNCodPago.DataType = DbType.Int32
                colvarNCodPago.MaxLength = 0
                colvarNCodPago.AutoIncrement = false
                colvarNCodPago.IsNullable = false
                colvarNCodPago.IsPrimaryKey = true
                colvarNCodPago.IsForeignKey = false
                colvarNCodPago.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodPago)
                
                Dim colvarNFacturaId As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNFacturaId.ColumnName = "nFacturaId"
                colvarNFacturaId.DataType = DbType.Int64
                colvarNFacturaId.MaxLength = 0
                colvarNFacturaId.AutoIncrement = false
                colvarNFacturaId.IsNullable = false
                colvarNFacturaId.IsPrimaryKey = false
                colvarNFacturaId.IsForeignKey = true
                colvarNFacturaId.IsReadOnly = false
                
                
				colvarNFacturaId.ForeignKeyTableName = "EJS_Factura"
                
                schema.Columns.Add(colvarNFacturaId)
                
                Dim colvarNMontoPagado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMontoPagado.ColumnName = "nMontoPagado"
                colvarNMontoPagado.DataType = DbType.Currency
                colvarNMontoPagado.MaxLength = 0
                colvarNMontoPagado.AutoIncrement = false
                colvarNMontoPagado.IsNullable = false
                colvarNMontoPagado.IsPrimaryKey = false
                colvarNMontoPagado.IsForeignKey = false
                colvarNMontoPagado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMontoPagado)
                
                Dim colvarCNroComprobante As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNroComprobante.ColumnName = "cNroComprobante"
                colvarCNroComprobante.DataType = DbType.AnsiString
                colvarCNroComprobante.MaxLength = 10
                colvarCNroComprobante.AutoIncrement = false
                colvarCNroComprobante.IsNullable = false
                colvarCNroComprobante.IsPrimaryKey = false
                colvarCNroComprobante.IsForeignKey = false
                colvarCNroComprobante.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNroComprobante)
                
                Dim colvarCBancoCobro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCBancoCobro.ColumnName = "cBancoCobro"
                colvarCBancoCobro.DataType = DbType.AnsiString
                colvarCBancoCobro.MaxLength = 50
                colvarCBancoCobro.AutoIncrement = false
                colvarCBancoCobro.IsNullable = false
                colvarCBancoCobro.IsPrimaryKey = false
                colvarCBancoCobro.IsForeignKey = false
                colvarCBancoCobro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCBancoCobro)
                
                Dim colvarBCheque As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBCheque.ColumnName = "bCheque"
                colvarBCheque.DataType = DbType.Boolean
                colvarBCheque.MaxLength = 0
                colvarBCheque.AutoIncrement = false
                colvarBCheque.IsNullable = false
                colvarBCheque.IsPrimaryKey = false
                colvarBCheque.IsForeignKey = false
                colvarBCheque.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBCheque)
                
                Dim colvarCNroCheque As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNroCheque.ColumnName = "cNroCheque"
                colvarCNroCheque.DataType = DbType.AnsiString
                colvarCNroCheque.MaxLength = 10
                colvarCNroCheque.AutoIncrement = false
                colvarCNroCheque.IsNullable = true
                colvarCNroCheque.IsPrimaryKey = false
                colvarCNroCheque.IsForeignKey = false
                colvarCNroCheque.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNroCheque)
                
                Dim colvarDFechaCobro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaCobro.ColumnName = "dFechaCobro"
                colvarDFechaCobro.DataType = DbType.DateTime
                colvarDFechaCobro.MaxLength = 0
                colvarDFechaCobro.AutoIncrement = false
                colvarDFechaCobro.IsNullable = true
                colvarDFechaCobro.IsPrimaryKey = false
                colvarDFechaCobro.IsForeignKey = false
                colvarDFechaCobro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaCobro)
                
                Dim colvarCBeneficiario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCBeneficiario.ColumnName = "cBeneficiario"
                colvarCBeneficiario.DataType = DbType.AnsiString
                colvarCBeneficiario.MaxLength = 50
                colvarCBeneficiario.AutoIncrement = false
                colvarCBeneficiario.IsNullable = true
                colvarCBeneficiario.IsPrimaryKey = false
                colvarCBeneficiario.IsForeignKey = false
                colvarCBeneficiario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCBeneficiario)
                
                Dim colvarDFechaExtracto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaExtracto.ColumnName = "dFechaExtracto"
                colvarDFechaExtracto.DataType = DbType.DateTime
                colvarDFechaExtracto.MaxLength = 0
                colvarDFechaExtracto.AutoIncrement = false
                colvarDFechaExtracto.IsNullable = true
                colvarDFechaExtracto.IsPrimaryKey = false
                colvarDFechaExtracto.IsForeignKey = false
                colvarDFechaExtracto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaExtracto)
                
                Dim colvarNSaldo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNSaldo.ColumnName = "nSaldo"
                colvarNSaldo.DataType = DbType.Currency
                colvarNSaldo.MaxLength = 0
                colvarNSaldo.AutoIncrement = false
                colvarNSaldo.IsNullable = true
                colvarNSaldo.IsPrimaryKey = false
                colvarNSaldo.IsForeignKey = false
                colvarNSaldo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNSaldo)
                
                Dim colvarNCodCobrador As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCobrador.ColumnName = "nCodCobrador"
                colvarNCodCobrador.DataType = DbType.Int32
                colvarNCodCobrador.MaxLength = 0
                colvarNCodCobrador.AutoIncrement = false
                colvarNCodCobrador.IsNullable = true
                colvarNCodCobrador.IsPrimaryKey = false
                colvarNCodCobrador.IsForeignKey = true
                colvarNCodCobrador.IsReadOnly = false
                
                
				colvarNCodCobrador.ForeignKeyTableName = "EJS_Empleado"
                
                schema.Columns.Add(colvarNCodCobrador)
                
                Dim colvarDFechaPago As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaPago.ColumnName = "dFechaPago"
                colvarDFechaPago.DataType = DbType.DateTime
                colvarDFechaPago.MaxLength = 0
                colvarDFechaPago.AutoIncrement = false
                colvarDFechaPago.IsNullable = true
                colvarDFechaPago.IsPrimaryKey = false
                colvarDFechaPago.IsForeignKey = false
                colvarDFechaPago.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaPago)
                
                Dim colvarNReciboOficial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNReciboOficial.ColumnName = "nReciboOficial"
                colvarNReciboOficial.DataType = DbType.Int32
                colvarNReciboOficial.MaxLength = 0
                colvarNReciboOficial.AutoIncrement = false
                colvarNReciboOficial.IsNullable = true
                colvarNReciboOficial.IsPrimaryKey = false
                colvarNReciboOficial.IsForeignKey = false
                colvarNReciboOficial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNReciboOficial)
                
                Dim colvarNInformeCobranza As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNInformeCobranza.ColumnName = "nInformeCobranza"
                colvarNInformeCobranza.DataType = DbType.Int32
                colvarNInformeCobranza.MaxLength = 0
                colvarNInformeCobranza.AutoIncrement = false
                colvarNInformeCobranza.IsNullable = true
                colvarNInformeCobranza.IsPrimaryKey = false
                colvarNInformeCobranza.IsForeignKey = false
                colvarNInformeCobranza.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNInformeCobranza)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_PagoCuentaXCobrar",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodPago")> _
        Public Property NCodPago As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodPago)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodPago, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NFacturaId")> _
        Public Property NFacturaId As Long 
			Get
				Return GetColumnValue(Of Long)(Columns.NFacturaId)
			End Get
		    
			Set
				SetColumnValue(Columns.NFacturaId, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NMontoPagado")> _
        Public Property NMontoPagado As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NMontoPagado)
			End Get
		    
			Set
				SetColumnValue(Columns.NMontoPagado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNroComprobante")> _
        Public Property CNroComprobante As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNroComprobante)
			End Get
		    
			Set
				SetColumnValue(Columns.CNroComprobante, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CBancoCobro")> _
        Public Property CBancoCobro As String 
			Get
				Return GetColumnValue(Of String)(Columns.CBancoCobro)
			End Get
		    
			Set
				SetColumnValue(Columns.CBancoCobro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BCheque")> _
        Public Property BCheque As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BCheque)
			End Get
		    
			Set
				SetColumnValue(Columns.BCheque, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNroCheque")> _
        Public Property CNroCheque As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNroCheque)
			End Get
		    
			Set
				SetColumnValue(Columns.CNroCheque, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaCobro")> _
        Public Property DFechaCobro As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaCobro)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaCobro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CBeneficiario")> _
        Public Property CBeneficiario As String 
			Get
				Return GetColumnValue(Of String)(Columns.CBeneficiario)
			End Get
		    
			Set
				SetColumnValue(Columns.CBeneficiario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaExtracto")> _
        Public Property DFechaExtracto As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaExtracto)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaExtracto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NSaldo")> _
        Public Property NSaldo As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NSaldo)
			End Get
		    
			Set
				SetColumnValue(Columns.NSaldo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodCobrador")> _
        Public Property NCodCobrador As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodCobrador)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCobrador, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaPago")> _
        Public Property DFechaPago As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaPago)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaPago, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NReciboOficial")> _
        Public Property NReciboOficial As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NReciboOficial)
			End Get
		    
			Set
				SetColumnValue(Columns.NReciboOficial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NInformeCobranza")> _
        Public Property NInformeCobranza As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NInformeCobranza)
			End Get
		    
			Set
				SetColumnValue(Columns.NInformeCobranza, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Factura ActiveRecord object related to this PagoCuentaXCobrar
		''' </summary>
		Public Property Factura() As EjSuite.Factura
			Get
				Return EjSuite.Factura.FetchByID(Me.NFacturaId)
			End Get
			Set
				SetColumnValue("nFacturaId", Value.NCodFactura)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Empleado ActiveRecord object related to this PagoCuentaXCobrar
		''' </summary>
		Public Property Empleado() As EjSuite.Empleado
			Get
				Return EjSuite.Empleado.FetchByID(Me.NCodCobrador)
			End Get
			Set
				SetColumnValue("nCodCobrador", Value.NCodEmpleado)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodPago As Integer,ByVal varNFacturaId As Long,ByVal varNMontoPagado As Decimal,ByVal varCNroComprobante As String,ByVal varCBancoCobro As String,ByVal varBCheque As Boolean,ByVal varCNroCheque As String,ByVal varDFechaCobro As Nullable(Of DateTime),ByVal varCBeneficiario As String,ByVal varDFechaExtracto As Nullable(Of DateTime),ByVal varNSaldo As Nullable(Of Decimal),ByVal varNCodCobrador As Nullable(Of Integer),ByVal varDFechaPago As Nullable(Of DateTime),ByVal varNReciboOficial As Nullable(Of Integer),ByVal varNInformeCobranza As Nullable(Of Integer))
			Dim item As PagoCuentaXCobrar = New PagoCuentaXCobrar()
			
            item.NCodPago = varNCodPago
            
            item.NFacturaId = varNFacturaId
            
            item.NMontoPagado = varNMontoPagado
            
            item.CNroComprobante = varCNroComprobante
            
            item.CBancoCobro = varCBancoCobro
            
            item.BCheque = varBCheque
            
            item.CNroCheque = varCNroCheque
            
            item.DFechaCobro = varDFechaCobro
            
            item.CBeneficiario = varCBeneficiario
            
            item.DFechaExtracto = varDFechaExtracto
            
            item.NSaldo = varNSaldo
            
            item.NCodCobrador = varNCodCobrador
            
            item.DFechaPago = varDFechaPago
            
            item.NReciboOficial = varNReciboOficial
            
            item.NInformeCobranza = varNInformeCobranza
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodPago As Integer,ByVal varNFacturaId As Long,ByVal varNMontoPagado As Decimal,ByVal varCNroComprobante As String,ByVal varCBancoCobro As String,ByVal varBCheque As Boolean,ByVal varCNroCheque As String,ByVal varDFechaCobro As Nullable(Of DateTime),ByVal varCBeneficiario As String,ByVal varDFechaExtracto As Nullable(Of DateTime),ByVal varNSaldo As Nullable(Of Decimal),ByVal varNCodCobrador As Nullable(Of Integer),ByVal varDFechaPago As Nullable(Of DateTime),ByVal varNReciboOficial As Nullable(Of Integer),ByVal varNInformeCobranza As Nullable(Of Integer))
			Dim item As PagoCuentaXCobrar = New PagoCuentaXCobrar()
		    
                item.NCodPago = varNCodPago
				
                item.NFacturaId = varNFacturaId
				
                item.NMontoPagado = varNMontoPagado
				
                item.CNroComprobante = varCNroComprobante
				
                item.CBancoCobro = varCBancoCobro
				
                item.BCheque = varBCheque
				
                item.CNroCheque = varCNroCheque
				
                item.DFechaCobro = varDFechaCobro
				
                item.CBeneficiario = varCBeneficiario
				
                item.DFechaExtracto = varDFechaExtracto
				
                item.NSaldo = varNSaldo
				
                item.NCodCobrador = varNCodCobrador
				
                item.DFechaPago = varDFechaPago
				
                item.NReciboOficial = varNReciboOficial
				
                item.NInformeCobranza = varNInformeCobranza
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodPagoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NFacturaIdColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NMontoPagadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNroComprobanteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CBancoCobroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BChequeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNroChequeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaCobroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CBeneficiarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaExtractoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NSaldoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodCobradorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaPagoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NReciboOficialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NInformeCobranzaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodPago As String = "nCodPago"
            
            Public Shared NFacturaId As String = "nFacturaId"
            
            Public Shared NMontoPagado As String = "nMontoPagado"
            
            Public Shared CNroComprobante As String = "cNroComprobante"
            
            Public Shared CBancoCobro As String = "cBancoCobro"
            
            Public Shared BCheque As String = "bCheque"
            
            Public Shared CNroCheque As String = "cNroCheque"
            
            Public Shared DFechaCobro As String = "dFechaCobro"
            
            Public Shared CBeneficiario As String = "cBeneficiario"
            
            Public Shared DFechaExtracto As String = "dFechaExtracto"
            
            Public Shared NSaldo As String = "nSaldo"
            
            Public Shared NCodCobrador As String = "nCodCobrador"
            
            Public Shared DFechaPago As String = "dFechaPago"
            
            Public Shared NReciboOficial As String = "nReciboOficial"
            
            Public Shared NInformeCobranza As String = "nInformeCobranza"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
