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
	''' Strongly-typed collection for the Producto class.
	''' </summary>
	<Serializable> _
	Public Partial Class ProductoCollection 
	Inherits ActiveList(Of Producto, ProductoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ProductoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Producto = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Producto table.
	''' </summary>
	<Serializable> _
	Public Partial Class Producto 
	Inherits ActiveRecord(Of Producto)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Producto", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = false
                colvarNCodProducto.IsPrimaryKey = true
                colvarNCodProducto.IsForeignKey = false
                colvarNCodProducto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarCCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCodProducto.ColumnName = "cCodProducto"
                colvarCCodProducto.DataType = DbType.AnsiString
                colvarCCodProducto.MaxLength = 50
                colvarCCodProducto.AutoIncrement = false
                colvarCCodProducto.IsNullable = false
                colvarCCodProducto.IsPrimaryKey = false
                colvarCCodProducto.IsForeignKey = false
                colvarCCodProducto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCodProducto)
                
                Dim colvarNCodProveedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProveedor.ColumnName = "nCodProveedor"
                colvarNCodProveedor.DataType = DbType.Int32
                colvarNCodProveedor.MaxLength = 0
                colvarNCodProveedor.AutoIncrement = false
                colvarNCodProveedor.IsNullable = true
                colvarNCodProveedor.IsPrimaryKey = false
                colvarNCodProveedor.IsForeignKey = true
                colvarNCodProveedor.IsReadOnly = false
                
                
				colvarNCodProveedor.ForeignKeyTableName = "EJS_Proveedor"
                
                schema.Columns.Add(colvarNCodProveedor)
                
                Dim colvarNCodMarca As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodMarca.ColumnName = "nCodMarca"
                colvarNCodMarca.DataType = DbType.Int32
                colvarNCodMarca.MaxLength = 0
                colvarNCodMarca.AutoIncrement = false
                colvarNCodMarca.IsNullable = true
                colvarNCodMarca.IsPrimaryKey = false
                colvarNCodMarca.IsForeignKey = true
                colvarNCodMarca.IsReadOnly = false
                
                
				colvarNCodMarca.ForeignKeyTableName = "EJS_Marca"
                
                schema.Columns.Add(colvarNCodMarca)
                
                Dim colvarNCodGrupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodGrupo.ColumnName = "nCodGrupo"
                colvarNCodGrupo.DataType = DbType.Int32
                colvarNCodGrupo.MaxLength = 0
                colvarNCodGrupo.AutoIncrement = false
                colvarNCodGrupo.IsNullable = true
                colvarNCodGrupo.IsPrimaryKey = false
                colvarNCodGrupo.IsForeignKey = true
                colvarNCodGrupo.IsReadOnly = false
                
                
				colvarNCodGrupo.ForeignKeyTableName = "EJS_GrupoProducto"
                
                schema.Columns.Add(colvarNCodGrupo)
                
                Dim colvarCNombreGenerico As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNombreGenerico.ColumnName = "cNombreGenerico"
                colvarCNombreGenerico.DataType = DbType.AnsiString
                colvarCNombreGenerico.MaxLength = 100
                colvarCNombreGenerico.AutoIncrement = false
                colvarCNombreGenerico.IsNullable = true
                colvarCNombreGenerico.IsPrimaryKey = false
                colvarCNombreGenerico.IsForeignKey = false
                colvarCNombreGenerico.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNombreGenerico)
                
                Dim colvarCNombreComercial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCNombreComercial.ColumnName = "cNombreComercial"
                colvarCNombreComercial.DataType = DbType.AnsiString
                colvarCNombreComercial.MaxLength = 100
                colvarCNombreComercial.AutoIncrement = false
                colvarCNombreComercial.IsNullable = false
                colvarCNombreComercial.IsPrimaryKey = false
                colvarCNombreComercial.IsForeignKey = false
                colvarCNombreComercial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCNombreComercial)
                
                Dim colvarCDetalles As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCDetalles.ColumnName = "cDetalles"
                colvarCDetalles.DataType = DbType.AnsiString
                colvarCDetalles.MaxLength = 2147483647
                colvarCDetalles.AutoIncrement = false
                colvarCDetalles.IsNullable = false
                colvarCDetalles.IsPrimaryKey = false
                colvarCDetalles.IsForeignKey = false
                colvarCDetalles.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCDetalles)
                
                Dim colvarNPrecioCompra As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioCompra.ColumnName = "nPrecioCompra"
                colvarNPrecioCompra.DataType = DbType.Currency
                colvarNPrecioCompra.MaxLength = 0
                colvarNPrecioCompra.AutoIncrement = false
                colvarNPrecioCompra.IsNullable = false
                colvarNPrecioCompra.IsPrimaryKey = false
                colvarNPrecioCompra.IsForeignKey = false
                colvarNPrecioCompra.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioCompra)
                
                Dim colvarCUnUna As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCUnUna.ColumnName = "cUnUna"
                colvarCUnUna.DataType = DbType.AnsiString
                colvarCUnUna.MaxLength = 100
                colvarCUnUna.AutoIncrement = false
                colvarCUnUna.IsNullable = false
                colvarCUnUna.IsPrimaryKey = false
                colvarCUnUna.IsForeignKey = false
                colvarCUnUna.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCUnUna)
                
                Dim colvarCContiene As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCContiene.ColumnName = "cContiene"
                colvarCContiene.DataType = DbType.AnsiString
                colvarCContiene.MaxLength = 100
                colvarCContiene.AutoIncrement = false
                colvarCContiene.IsNullable = false
                colvarCContiene.IsPrimaryKey = false
                colvarCContiene.IsForeignKey = false
                colvarCContiene.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCContiene)
                
                Dim colvarCTipoElementos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCTipoElementos.ColumnName = "cTipoElementos"
                colvarCTipoElementos.DataType = DbType.AnsiString
                colvarCTipoElementos.MaxLength = 100
                colvarCTipoElementos.AutoIncrement = false
                colvarCTipoElementos.IsNullable = false
                colvarCTipoElementos.IsPrimaryKey = false
                colvarCTipoElementos.IsForeignKey = false
                colvarCTipoElementos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCTipoElementos)
                
                Dim colvarCMedidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCMedidad.ColumnName = "cMedidad"
                colvarCMedidad.DataType = DbType.AnsiString
                colvarCMedidad.MaxLength = 100
                colvarCMedidad.AutoIncrement = false
                colvarCMedidad.IsNullable = false
                colvarCMedidad.IsPrimaryKey = false
                colvarCMedidad.IsForeignKey = false
                colvarCMedidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCMedidad)
                
                Dim colvarCUnidad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCUnidad.ColumnName = "cUnidad"
                colvarCUnidad.DataType = DbType.AnsiString
                colvarCUnidad.MaxLength = 100
                colvarCUnidad.AutoIncrement = false
                colvarCUnidad.IsNullable = false
                colvarCUnidad.IsPrimaryKey = false
                colvarCUnidad.IsForeignKey = false
                colvarCUnidad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCUnidad)
                
                Dim colvarBSueltos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBSueltos.ColumnName = "bSueltos"
                colvarBSueltos.DataType = DbType.Boolean
                colvarBSueltos.MaxLength = 0
                colvarBSueltos.AutoIncrement = false
                colvarBSueltos.IsNullable = false
                colvarBSueltos.IsPrimaryKey = false
                colvarBSueltos.IsForeignKey = false
                colvarBSueltos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBSueltos)
                
                Dim colvarNMontoVentaEnvase As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMontoVentaEnvase.ColumnName = "nMontoVentaEnvase"
                colvarNMontoVentaEnvase.DataType = DbType.Currency
                colvarNMontoVentaEnvase.MaxLength = 0
                colvarNMontoVentaEnvase.AutoIncrement = false
                colvarNMontoVentaEnvase.IsNullable = false
                colvarNMontoVentaEnvase.IsPrimaryKey = false
                colvarNMontoVentaEnvase.IsForeignKey = false
                colvarNMontoVentaEnvase.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMontoVentaEnvase)
                
                Dim colvarNMontoVentaIndividual As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMontoVentaIndividual.ColumnName = "nMontoVentaIndividual"
                colvarNMontoVentaIndividual.DataType = DbType.Currency
                colvarNMontoVentaIndividual.MaxLength = 0
                colvarNMontoVentaIndividual.AutoIncrement = false
                colvarNMontoVentaIndividual.IsNullable = true
                colvarNMontoVentaIndividual.IsPrimaryKey = false
                colvarNMontoVentaIndividual.IsForeignKey = false
                colvarNMontoVentaIndividual.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMontoVentaIndividual)
                
                Dim colvarNPromocion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPromocion.ColumnName = "nPromocion"
                colvarNPromocion.DataType = DbType.Currency
                colvarNPromocion.MaxLength = 0
                colvarNPromocion.AutoIncrement = false
                colvarNPromocion.IsNullable = true
                colvarNPromocion.IsPrimaryKey = false
                colvarNPromocion.IsForeignKey = false
                colvarNPromocion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPromocion)
                
                Dim colvarNStockMinimo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockMinimo.ColumnName = "nStockMinimo"
                colvarNStockMinimo.DataType = DbType.Currency
                colvarNStockMinimo.MaxLength = 0
                colvarNStockMinimo.AutoIncrement = false
                colvarNStockMinimo.IsNullable = true
                colvarNStockMinimo.IsPrimaryKey = false
                colvarNStockMinimo.IsForeignKey = false
                colvarNStockMinimo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockMinimo)
                
                Dim colvarNStockMaximo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockMaximo.ColumnName = "nStockMaximo"
                colvarNStockMaximo.DataType = DbType.Currency
                colvarNStockMaximo.MaxLength = 0
                colvarNStockMaximo.AutoIncrement = false
                colvarNStockMaximo.IsNullable = true
                colvarNStockMaximo.IsPrimaryKey = false
                colvarNStockMaximo.IsForeignKey = false
                colvarNStockMaximo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockMaximo)
                
                Dim colvarBVigente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBVigente.ColumnName = "bVigente"
                colvarBVigente.DataType = DbType.Boolean
                colvarBVigente.MaxLength = 0
                colvarBVigente.AutoIncrement = false
                colvarBVigente.IsNullable = false
                colvarBVigente.IsPrimaryKey = false
                colvarBVigente.IsForeignKey = false
                colvarBVigente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBVigente)
                
                Dim colvarCCompuesto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCompuesto.ColumnName = "cCompuesto"
                colvarCCompuesto.DataType = DbType.AnsiString
                colvarCCompuesto.MaxLength = 2147483647
                colvarCCompuesto.AutoIncrement = false
                colvarCCompuesto.IsNullable = false
                colvarCCompuesto.IsPrimaryKey = false
                colvarCCompuesto.IsForeignKey = false
                colvarCCompuesto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCompuesto)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Producto",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCodProducto")> _
        Public Property CCodProducto As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.CCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProveedor")> _
        Public Property NCodProveedor As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodProveedor)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProveedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodMarca")> _
        Public Property NCodMarca As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodMarca)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodMarca, Value)
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
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNombreGenerico")> _
        Public Property CNombreGenerico As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNombreGenerico)
			End Get
		    
			Set
				SetColumnValue(Columns.CNombreGenerico, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CNombreComercial")> _
        Public Property CNombreComercial As String 
			Get
				Return GetColumnValue(Of String)(Columns.CNombreComercial)
			End Get
		    
			Set
				SetColumnValue(Columns.CNombreComercial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CDetalles")> _
        Public Property CDetalles As String 
			Get
				Return GetColumnValue(Of String)(Columns.CDetalles)
			End Get
		    
			Set
				SetColumnValue(Columns.CDetalles, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioCompra")> _
        Public Property NPrecioCompra As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioCompra)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioCompra, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CUnUna")> _
        Public Property CUnUna As String 
			Get
				Return GetColumnValue(Of String)(Columns.CUnUna)
			End Get
		    
			Set
				SetColumnValue(Columns.CUnUna, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CContiene")> _
        Public Property CContiene As String 
			Get
				Return GetColumnValue(Of String)(Columns.CContiene)
			End Get
		    
			Set
				SetColumnValue(Columns.CContiene, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CTipoElementos")> _
        Public Property CTipoElementos As String 
			Get
				Return GetColumnValue(Of String)(Columns.CTipoElementos)
			End Get
		    
			Set
				SetColumnValue(Columns.CTipoElementos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CMedidad")> _
        Public Property CMedidad As String 
			Get
				Return GetColumnValue(Of String)(Columns.CMedidad)
			End Get
		    
			Set
				SetColumnValue(Columns.CMedidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CUnidad")> _
        Public Property CUnidad As String 
			Get
				Return GetColumnValue(Of String)(Columns.CUnidad)
			End Get
		    
			Set
				SetColumnValue(Columns.CUnidad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BSueltos")> _
        Public Property BSueltos As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BSueltos)
			End Get
		    
			Set
				SetColumnValue(Columns.BSueltos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NMontoVentaEnvase")> _
        Public Property NMontoVentaEnvase As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NMontoVentaEnvase)
			End Get
		    
			Set
				SetColumnValue(Columns.NMontoVentaEnvase, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NMontoVentaIndividual")> _
        Public Property NMontoVentaIndividual As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NMontoVentaIndividual)
			End Get
		    
			Set
				SetColumnValue(Columns.NMontoVentaIndividual, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPromocion")> _
        Public Property NPromocion As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NPromocion)
			End Get
		    
			Set
				SetColumnValue(Columns.NPromocion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockMinimo")> _
        Public Property NStockMinimo As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NStockMinimo)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockMinimo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockMaximo")> _
        Public Property NStockMaximo As Nullable(Of Decimal) 
			Get
				Return GetColumnValue(Of Nullable(Of Decimal))(Columns.NStockMaximo)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockMaximo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BVigente")> _
        Public Property BVigente As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BVigente)
			End Get
		    
			Set
				SetColumnValue(Columns.BVigente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCompuesto")> _
        Public Property CCompuesto As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCompuesto)
			End Get
		    
			Set
				SetColumnValue(Columns.CCompuesto, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function CotizacionDetalleRecords() As EjSuite.CotizacionDetalleCollection 
	
				Return New EjSuite.CotizacionDetalleCollection().Where(CotizacionDetalle.Columns.NCodProducto, NCodProducto).Load()
	
			End Function
			
			Public Function DetalleRecords() As EjSuite.DetalleCollection 
	
				Return New EjSuite.DetalleCollection().Where(Detalle.Columns.NCodProducto, NCodProducto).Load()
	
			End Function
			
			Public Function KardexInventarioRecords() As EjSuite.KardexInventarioCollection 
	
				Return New EjSuite.KardexInventarioCollection().Where(KardexInventario.Columns.NCodProducto, NCodProducto).Load()
	
			End Function
			
			Public Function LoteRecords() As EjSuite.LoteCollection 
	
				Return New EjSuite.LoteCollection().Where(Lote.Columns.NCodProducto, NCodProducto).Load()
	
			End Function
			
			Public Function OrdenCompraDetalleRecords() As EjSuite.OrdenCompraDetalleCollection 
	
				Return New EjSuite.OrdenCompraDetalleCollection().Where(OrdenCompraDetalle.Columns.NCodProducto, NCodProducto).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a GrupoProducto ActiveRecord object related to this Producto
		''' </summary>
		Public Property GrupoProducto() As EjSuite.GrupoProducto
			Get
				Return EjSuite.GrupoProducto.FetchByID(Me.NCodGrupo)
			End Get
			Set
				SetColumnValue("nCodGrupo", Value.NCodGrupo)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Proveedor ActiveRecord object related to this Producto
		''' </summary>
		Public Property Proveedor() As EjSuite.Proveedor
			Get
				Return EjSuite.Proveedor.FetchByID(Me.NCodProveedor)
			End Get
			Set
				SetColumnValue("nCodProveedor", Value.NCodProveedor)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Marca ActiveRecord object related to this Producto
		''' </summary>
		Public Property Marca() As EjSuite.Marca
			Get
				Return EjSuite.Marca.FetchByID(Me.NCodMarca)
			End Get
			Set
				SetColumnValue("nCodMarca", Value.NCodMarca)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodProducto As Integer,ByVal varCCodProducto As String,ByVal varNCodProveedor As Nullable(Of Integer),ByVal varNCodMarca As Nullable(Of Integer),ByVal varNCodGrupo As Nullable(Of Integer),ByVal varCNombreGenerico As String,ByVal varCNombreComercial As String,ByVal varCDetalles As String,ByVal varNPrecioCompra As Decimal,ByVal varCUnUna As String,ByVal varCContiene As String,ByVal varCTipoElementos As String,ByVal varCMedidad As String,ByVal varCUnidad As String,ByVal varBSueltos As Boolean,ByVal varNMontoVentaEnvase As Decimal,ByVal varNMontoVentaIndividual As Nullable(Of Decimal),ByVal varNPromocion As Nullable(Of Decimal),ByVal varNStockMinimo As Nullable(Of Decimal),ByVal varNStockMaximo As Nullable(Of Decimal),ByVal varBVigente As Boolean,ByVal varCCompuesto As String)
			Dim item As Producto = New Producto()
			
            item.NCodProducto = varNCodProducto
            
            item.CCodProducto = varCCodProducto
            
            item.NCodProveedor = varNCodProveedor
            
            item.NCodMarca = varNCodMarca
            
            item.NCodGrupo = varNCodGrupo
            
            item.CNombreGenerico = varCNombreGenerico
            
            item.CNombreComercial = varCNombreComercial
            
            item.CDetalles = varCDetalles
            
            item.NPrecioCompra = varNPrecioCompra
            
            item.CUnUna = varCUnUna
            
            item.CContiene = varCContiene
            
            item.CTipoElementos = varCTipoElementos
            
            item.CMedidad = varCMedidad
            
            item.CUnidad = varCUnidad
            
            item.BSueltos = varBSueltos
            
            item.NMontoVentaEnvase = varNMontoVentaEnvase
            
            item.NMontoVentaIndividual = varNMontoVentaIndividual
            
            item.NPromocion = varNPromocion
            
            item.NStockMinimo = varNStockMinimo
            
            item.NStockMaximo = varNStockMaximo
            
            item.BVigente = varBVigente
            
            item.CCompuesto = varCCompuesto
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodProducto As Integer,ByVal varCCodProducto As String,ByVal varNCodProveedor As Nullable(Of Integer),ByVal varNCodMarca As Nullable(Of Integer),ByVal varNCodGrupo As Nullable(Of Integer),ByVal varCNombreGenerico As String,ByVal varCNombreComercial As String,ByVal varCDetalles As String,ByVal varNPrecioCompra As Decimal,ByVal varCUnUna As String,ByVal varCContiene As String,ByVal varCTipoElementos As String,ByVal varCMedidad As String,ByVal varCUnidad As String,ByVal varBSueltos As Boolean,ByVal varNMontoVentaEnvase As Decimal,ByVal varNMontoVentaIndividual As Nullable(Of Decimal),ByVal varNPromocion As Nullable(Of Decimal),ByVal varNStockMinimo As Nullable(Of Decimal),ByVal varNStockMaximo As Nullable(Of Decimal),ByVal varBVigente As Boolean,ByVal varCCompuesto As String)
			Dim item As Producto = New Producto()
		    
                item.NCodProducto = varNCodProducto
				
                item.CCodProducto = varCCodProducto
				
                item.NCodProveedor = varNCodProveedor
				
                item.NCodMarca = varNCodMarca
				
                item.NCodGrupo = varNCodGrupo
				
                item.CNombreGenerico = varCNombreGenerico
				
                item.CNombreComercial = varCNombreComercial
				
                item.CDetalles = varCDetalles
				
                item.NPrecioCompra = varNPrecioCompra
				
                item.CUnUna = varCUnUna
				
                item.CContiene = varCContiene
				
                item.CTipoElementos = varCTipoElementos
				
                item.CMedidad = varCMedidad
				
                item.CUnidad = varCUnidad
				
                item.BSueltos = varBSueltos
				
                item.NMontoVentaEnvase = varNMontoVentaEnvase
				
                item.NMontoVentaIndividual = varNMontoVentaIndividual
				
                item.NPromocion = varNPromocion
				
                item.NStockMinimo = varNStockMinimo
				
                item.NStockMaximo = varNStockMaximo
				
                item.BVigente = varBVigente
				
                item.CCompuesto = varCCompuesto
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProveedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodMarcaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodGrupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombreGenericoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CNombreComercialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CDetallesColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioCompraColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CUnUnaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CContieneColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CTipoElementosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CMedidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CUnidadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BSueltosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NMontoVentaEnvaseColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(15)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NMontoVentaIndividualColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(16)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPromocionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(17)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockMinimoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(18)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockMaximoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(19)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BVigenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(20)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCompuestoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(21)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared CCodProducto As String = "cCodProducto"
            
            Public Shared NCodProveedor As String = "nCodProveedor"
            
            Public Shared NCodMarca As String = "nCodMarca"
            
            Public Shared NCodGrupo As String = "nCodGrupo"
            
            Public Shared CNombreGenerico As String = "cNombreGenerico"
            
            Public Shared CNombreComercial As String = "cNombreComercial"
            
            Public Shared CDetalles As String = "cDetalles"
            
            Public Shared NPrecioCompra As String = "nPrecioCompra"
            
            Public Shared CUnUna As String = "cUnUna"
            
            Public Shared CContiene As String = "cContiene"
            
            Public Shared CTipoElementos As String = "cTipoElementos"
            
            Public Shared CMedidad As String = "cMedidad"
            
            Public Shared CUnidad As String = "cUnidad"
            
            Public Shared BSueltos As String = "bSueltos"
            
            Public Shared NMontoVentaEnvase As String = "nMontoVentaEnvase"
            
            Public Shared NMontoVentaIndividual As String = "nMontoVentaIndividual"
            
            Public Shared NPromocion As String = "nPromocion"
            
            Public Shared NStockMinimo As String = "nStockMinimo"
            
            Public Shared NStockMaximo As String = "nStockMaximo"
            
            Public Shared BVigente As String = "bVigente"
            
            Public Shared CCompuesto As String = "cCompuesto"
            
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
