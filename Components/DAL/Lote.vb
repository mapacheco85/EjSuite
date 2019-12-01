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
	''' Strongly-typed collection for the Lote class.
	''' </summary>
	<Serializable> _
	Public Partial Class LoteCollection 
	Inherits ActiveList(Of Lote, LoteCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As LoteCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Lote = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Lote table.
	''' </summary>
	<Serializable> _
	Public Partial Class Lote 
	Inherits ActiveRecord(Of Lote)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Lote", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodLote As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodLote.ColumnName = "nCodLote"
                colvarNCodLote.DataType = DbType.Int32
                colvarNCodLote.MaxLength = 0
                colvarNCodLote.AutoIncrement = false
                colvarNCodLote.IsNullable = false
                colvarNCodLote.IsPrimaryKey = true
                colvarNCodLote.IsForeignKey = false
                colvarNCodLote.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodLote)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = true
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = true
                colvarNCodProducto.IsReadOnly = false
                
                
				colvarNCodProducto.ForeignKeyTableName = "EJS_Producto"
                
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarCComprobanteRecibo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCComprobanteRecibo.ColumnName = "cComprobanteRecibo"
                colvarCComprobanteRecibo.DataType = DbType.AnsiString
                colvarCComprobanteRecibo.MaxLength = 20
                colvarCComprobanteRecibo.AutoIncrement = false
                colvarCComprobanteRecibo.IsNullable = false
                colvarCComprobanteRecibo.IsPrimaryKey = false
                colvarCComprobanteRecibo.IsForeignKey = false
                colvarCComprobanteRecibo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCComprobanteRecibo)
                
                Dim colvarCNumeroFactura As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNumeroFactura.ColumnName = "cNumeroFactura"
                colvarCNumeroFactura.DataType = DbType.AnsiString
                colvarCNumeroFactura.MaxLength = 20
                colvarCNumeroFactura.AutoIncrement = false
                colvarCNumeroFactura.IsNullable = false
                colvarCNumeroFactura.IsPrimaryKey = false
                colvarCNumeroFactura.IsForeignKey = false
                colvarCNumeroFactura.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNumeroFactura)
                
                Dim colvarCFormaPago As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCFormaPago.ColumnName = "cFormaPago"
                colvarCFormaPago.DataType = DbType.AnsiString
                colvarCFormaPago.MaxLength = 50
                colvarCFormaPago.AutoIncrement = false
                colvarCFormaPago.IsNullable = true
                colvarCFormaPago.IsPrimaryKey = false
                colvarCFormaPago.IsForeignKey = false
                colvarCFormaPago.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCFormaPago)
                
                Dim colvarDFechaIngreso As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaIngreso.ColumnName = "dFechaIngreso"
                colvarDFechaIngreso.DataType = DbType.DateTime
                colvarDFechaIngreso.MaxLength = 0
                colvarDFechaIngreso.AutoIncrement = false
                colvarDFechaIngreso.IsNullable = false
                colvarDFechaIngreso.IsPrimaryKey = false
                colvarDFechaIngreso.IsForeignKey = false
                colvarDFechaIngreso.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaIngreso)
                
                Dim colvarDFechaVencimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaVencimiento.ColumnName = "dFechaVencimiento"
                colvarDFechaVencimiento.DataType = DbType.DateTime
                colvarDFechaVencimiento.MaxLength = 0
                colvarDFechaVencimiento.AutoIncrement = false
                colvarDFechaVencimiento.IsNullable = false
                colvarDFechaVencimiento.IsPrimaryKey = false
                colvarDFechaVencimiento.IsForeignKey = false
                colvarDFechaVencimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaVencimiento)
                
                Dim colvarNPrecioAnteriorEnvase As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioAnteriorEnvase.ColumnName = "nPrecioAnteriorEnvase"
                colvarNPrecioAnteriorEnvase.DataType = DbType.Currency
                colvarNPrecioAnteriorEnvase.MaxLength = 0
                colvarNPrecioAnteriorEnvase.AutoIncrement = false
                colvarNPrecioAnteriorEnvase.IsNullable = false
                colvarNPrecioAnteriorEnvase.IsPrimaryKey = false
                colvarNPrecioAnteriorEnvase.IsForeignKey = false
                colvarNPrecioAnteriorEnvase.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioAnteriorEnvase)
                
                Dim colvarNPrecioActualEnvase As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioActualEnvase.ColumnName = "nPrecioActualEnvase"
                colvarNPrecioActualEnvase.DataType = DbType.Currency
                colvarNPrecioActualEnvase.MaxLength = 0
                colvarNPrecioActualEnvase.AutoIncrement = false
                colvarNPrecioActualEnvase.IsNullable = false
                colvarNPrecioActualEnvase.IsPrimaryKey = false
                colvarNPrecioActualEnvase.IsForeignKey = false
                colvarNPrecioActualEnvase.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioActualEnvase)
                
                Dim colvarBEstadoLote As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEstadoLote.ColumnName = "bEstadoLote"
                colvarBEstadoLote.DataType = DbType.Boolean
                colvarBEstadoLote.MaxLength = 0
                colvarBEstadoLote.AutoIncrement = false
                colvarBEstadoLote.IsNullable = false
                colvarBEstadoLote.IsPrimaryKey = false
                colvarBEstadoLote.IsForeignKey = false
                colvarBEstadoLote.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEstadoLote)
                
                Dim colvarNTotalEnvases As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNTotalEnvases.ColumnName = "nTotalEnvases"
                colvarNTotalEnvases.DataType = DbType.Int32
                colvarNTotalEnvases.MaxLength = 0
                colvarNTotalEnvases.AutoIncrement = false
                colvarNTotalEnvases.IsNullable = false
                colvarNTotalEnvases.IsPrimaryKey = false
                colvarNTotalEnvases.IsForeignKey = false
                colvarNTotalEnvases.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNTotalEnvases)
                
                Dim colvarNTotalSueltos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNTotalSueltos.ColumnName = "nTotalSueltos"
                colvarNTotalSueltos.DataType = DbType.Int32
                colvarNTotalSueltos.MaxLength = 0
                colvarNTotalSueltos.AutoIncrement = false
                colvarNTotalSueltos.IsNullable = false
                colvarNTotalSueltos.IsPrimaryKey = false
                colvarNTotalSueltos.IsForeignKey = false
                colvarNTotalSueltos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNTotalSueltos)
                
                Dim colvarCObservaciones As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCObservaciones.ColumnName = "cObservaciones"
                colvarCObservaciones.DataType = DbType.AnsiString
                colvarCObservaciones.MaxLength = 2147483647
                colvarCObservaciones.AutoIncrement = false
                colvarCObservaciones.IsNullable = true
                colvarCObservaciones.IsPrimaryKey = false
                colvarCObservaciones.IsForeignKey = false
                colvarCObservaciones.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCObservaciones)
                
                Dim colvarNCostoUnidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCostoUnidad.ColumnName = "nCostoUnidad"
                colvarNCostoUnidad.DataType = DbType.Currency
                colvarNCostoUnidad.MaxLength = 0
                colvarNCostoUnidad.AutoIncrement = false
                colvarNCostoUnidad.IsNullable = true
                colvarNCostoUnidad.IsPrimaryKey = false
                colvarNCostoUnidad.IsForeignKey = false
                colvarNCostoUnidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCostoUnidad)
                
                Dim colvarCTipo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTipo.ColumnName = "cTipo"
                colvarCTipo.DataType = DbType.AnsiString
                colvarCTipo.MaxLength = 50
                colvarCTipo.AutoIncrement = false
                colvarCTipo.IsNullable = true
                colvarCTipo.IsPrimaryKey = false
                colvarCTipo.IsForeignKey = false
                colvarCTipo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTipo)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Lote",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodLote")> _
        Public Property NCodLote As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodLote)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodLote, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CComprobanteRecibo")> _
        Public Property CComprobanteRecibo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CComprobanteRecibo)
			End Get
		    
			Set
				SetColumnValue(Columns.CComprobanteRecibo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNumeroFactura")> _
        Public Property CNumeroFactura As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNumeroFactura)
			End Get
		    
			Set
				SetColumnValue(Columns.CNumeroFactura, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CFormaPago")> _
        Public Property CFormaPago As String 
			Get
				Return GetColumnValue(Of String)(Columns.CFormaPago)
			End Get
		    
			Set
				SetColumnValue(Columns.CFormaPago, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaIngreso")> _
        Public Property DFechaIngreso As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaIngreso)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaIngreso, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaVencimiento")> _
        Public Property DFechaVencimiento As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaVencimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaVencimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioAnteriorEnvase")> _
        Public Property NPrecioAnteriorEnvase As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioAnteriorEnvase)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioAnteriorEnvase, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioActualEnvase")> _
        Public Property NPrecioActualEnvase As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioActualEnvase)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioActualEnvase, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEstadoLote")> _
        Public Property BEstadoLote As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEstadoLote)
			End Get
		    
			Set
				SetColumnValue(Columns.BEstadoLote, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NTotalEnvases")> _
        Public Property NTotalEnvases As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NTotalEnvases)
			End Get
		    
			Set
				SetColumnValue(Columns.NTotalEnvases, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NTotalSueltos")> _
        Public Property NTotalSueltos As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NTotalSueltos)
			End Get
		    
			Set
				SetColumnValue(Columns.NTotalSueltos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CObservaciones")> _
        Public Property CObservaciones As String 
			Get
				Return GetColumnValue(Of String)(Columns.CObservaciones)
			End Get
		    
			Set
				SetColumnValue(Columns.CObservaciones, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCostoUnidad")> _
        Public Property NCostoUnidad As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NCostoUnidad)
			End Get
		    
			Set
				SetColumnValue(Columns.NCostoUnidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTipo")> _
        Public Property CTipo As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTipo)
			End Get
		    
			Set
				SetColumnValue(Columns.CTipo, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function KardexInventarioRecords() As EjSuite.KardexInventarioCollection 
	
				Return New EjSuite.KardexInventarioCollection().Where(KardexInventario.Columns.NCodLote, NCodLote).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Producto ActiveRecord object related to this Lote
		''' </summary>
		Public Property Producto() As EjSuite.Producto
			Get
				Return EjSuite.Producto.FetchByID(Me.NCodProducto)
			End Get
			Set
				SetColumnValue("nCodProducto", Value.NCodProducto)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodLote As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varCComprobanteRecibo As String,ByVal varCNumeroFactura As String,ByVal varCFormaPago As String,ByVal varDFechaIngreso As DateTime,ByVal varDFechaVencimiento As DateTime,ByVal varNPrecioAnteriorEnvase As Decimal,ByVal varNPrecioActualEnvase As Decimal,ByVal varBEstadoLote As Boolean,ByVal varNTotalEnvases As Integer,ByVal varNTotalSueltos As Integer,ByVal varCObservaciones As String,ByVal varNCostoUnidad As Nullable(Of Decimal),ByVal varCTipo As String)
			Dim item As Lote = New Lote()
			
            item.NCodLote = varNCodLote
            
            item.NCodProducto = varNCodProducto
            
            item.CComprobanteRecibo = varCComprobanteRecibo
            
            item.CNumeroFactura = varCNumeroFactura
            
            item.CFormaPago = varCFormaPago
            
            item.DFechaIngreso = varDFechaIngreso
            
            item.DFechaVencimiento = varDFechaVencimiento
            
            item.NPrecioAnteriorEnvase = varNPrecioAnteriorEnvase
            
            item.NPrecioActualEnvase = varNPrecioActualEnvase
            
            item.BEstadoLote = varBEstadoLote
            
            item.NTotalEnvases = varNTotalEnvases
            
            item.NTotalSueltos = varNTotalSueltos
            
            item.CObservaciones = varCObservaciones
            
            item.NCostoUnidad = varNCostoUnidad
            
            item.CTipo = varCTipo
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodLote As Integer,ByVal varNCodProducto As Nullable(Of Integer),ByVal varCComprobanteRecibo As String,ByVal varCNumeroFactura As String,ByVal varCFormaPago As String,ByVal varDFechaIngreso As DateTime,ByVal varDFechaVencimiento As DateTime,ByVal varNPrecioAnteriorEnvase As Decimal,ByVal varNPrecioActualEnvase As Decimal,ByVal varBEstadoLote As Boolean,ByVal varNTotalEnvases As Integer,ByVal varNTotalSueltos As Integer,ByVal varCObservaciones As String,ByVal varNCostoUnidad As Nullable(Of Decimal),ByVal varCTipo As String)
			Dim item As Lote = New Lote()
		    
                item.NCodLote = varNCodLote
				
                item.NCodProducto = varNCodProducto
				
                item.CComprobanteRecibo = varCComprobanteRecibo
				
                item.CNumeroFactura = varCNumeroFactura
				
                item.CFormaPago = varCFormaPago
				
                item.DFechaIngreso = varDFechaIngreso
				
                item.DFechaVencimiento = varDFechaVencimiento
				
                item.NPrecioAnteriorEnvase = varNPrecioAnteriorEnvase
				
                item.NPrecioActualEnvase = varNPrecioActualEnvase
				
                item.BEstadoLote = varBEstadoLote
				
                item.NTotalEnvases = varNTotalEnvases
				
                item.NTotalSueltos = varNTotalSueltos
				
                item.CObservaciones = varCObservaciones
				
                item.NCostoUnidad = varNCostoUnidad
				
                item.CTipo = varCTipo
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodLoteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CComprobanteReciboColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNumeroFacturaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CFormaPagoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaIngresoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaVencimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioAnteriorEnvaseColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioActualEnvaseColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEstadoLoteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NTotalEnvasesColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NTotalSueltosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CObservacionesColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCostoUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTipoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodLote As String = "nCodLote"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared CComprobanteRecibo As String = "cComprobanteRecibo"
            
            Public Shared CNumeroFactura As String = "cNumeroFactura"
            
            Public Shared CFormaPago As String = "cFormaPago"
            
            Public Shared DFechaIngreso As String = "dFechaIngreso"
            
            Public Shared DFechaVencimiento As String = "dFechaVencimiento"
            
            Public Shared NPrecioAnteriorEnvase As String = "nPrecioAnteriorEnvase"
            
            Public Shared NPrecioActualEnvase As String = "nPrecioActualEnvase"
            
            Public Shared BEstadoLote As String = "bEstadoLote"
            
            Public Shared NTotalEnvases As String = "nTotalEnvases"
            
            Public Shared NTotalSueltos As String = "nTotalSueltos"
            
            Public Shared CObservaciones As String = "cObservaciones"
            
            Public Shared NCostoUnidad As String = "nCostoUnidad"
            
            Public Shared CTipo As String = "cTipo"
            
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
