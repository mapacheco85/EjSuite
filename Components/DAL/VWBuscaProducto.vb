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
    ''' Strongly-typed collection for the VWBuscaProducto class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VWBuscaProductoCollection 
    Inherits ReadOnlyList(Of VWBuscaProducto, VWBuscaProductoCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VWBuscaProducto view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VWBuscaProducto 
    Inherits ReadOnlyRecord(Of VWBuscaProducto)
    
	    #Region "Default Settings"
	    Protected Shared Sub SetSQLProps()
	        GetTableSchema()
	    End Sub
	    #End Region
        #Region "Schema Accessor"
        Public Shared ReadOnly Property Schema() As TableSchema.Table
            Get
                If (BaseSchema Is Nothing) Then
                    SetSQLProps()
                End If
                Return BaseSchema
            End Get
        End Property
	    
	    Private Shared Sub GetTableSchema()
	        If (Not IsSchemaInitialized) Then
	            'Schema declaration
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VWBuscaProducto", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarNCodProducto As New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = False
                colvarNCodProducto.IsNullable = false
                colvarNCodProducto.IsPrimaryKey = False
                colvarNCodProducto.IsForeignKey = False
                colvarNCodProducto.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarCNombreGenerico As New TableSchema.TableColumn(schema)
                colvarCNombreGenerico.ColumnName = "cNombreGenerico"
                colvarCNombreGenerico.DataType = DbType.AnsiString
                colvarCNombreGenerico.MaxLength = 100
                colvarCNombreGenerico.AutoIncrement = False
                colvarCNombreGenerico.IsNullable = true
                colvarCNombreGenerico.IsPrimaryKey = False
                colvarCNombreGenerico.IsForeignKey = False
                colvarCNombreGenerico.IsReadOnly = false
                 
                schema.Columns.Add(colvarCNombreGenerico)
                
                Dim colvarCNombreComercial As New TableSchema.TableColumn(schema)
                colvarCNombreComercial.ColumnName = "cNombreComercial"
                colvarCNombreComercial.DataType = DbType.AnsiString
                colvarCNombreComercial.MaxLength = 100
                colvarCNombreComercial.AutoIncrement = False
                colvarCNombreComercial.IsNullable = false
                colvarCNombreComercial.IsPrimaryKey = False
                colvarCNombreComercial.IsForeignKey = False
                colvarCNombreComercial.IsReadOnly = false
                 
                schema.Columns.Add(colvarCNombreComercial)
                
                Dim colvarCompuesto As New TableSchema.TableColumn(schema)
                colvarCompuesto.ColumnName = "COMPUESTO"
                colvarCompuesto.DataType = DbType.AnsiString
                colvarCompuesto.MaxLength = -1
                colvarCompuesto.AutoIncrement = False
                colvarCompuesto.IsNullable = true
                colvarCompuesto.IsPrimaryKey = False
                colvarCompuesto.IsForeignKey = False
                colvarCompuesto.IsReadOnly = false
                 
                schema.Columns.Add(colvarCompuesto)
                
                Dim colvarDetalles As New TableSchema.TableColumn(schema)
                colvarDetalles.ColumnName = "DETALLES"
                colvarDetalles.DataType = DbType.AnsiString
                colvarDetalles.MaxLength = -1
                colvarDetalles.AutoIncrement = False
                colvarDetalles.IsNullable = true
                colvarDetalles.IsPrimaryKey = False
                colvarDetalles.IsForeignKey = False
                colvarDetalles.IsReadOnly = false
                 
                schema.Columns.Add(colvarDetalles)
                
                Dim colvarNPrecioCompra As New TableSchema.TableColumn(schema)
                colvarNPrecioCompra.ColumnName = "nPrecioCompra"
                colvarNPrecioCompra.DataType = DbType.Currency
                colvarNPrecioCompra.MaxLength = 0
                colvarNPrecioCompra.AutoIncrement = False
                colvarNPrecioCompra.IsNullable = false
                colvarNPrecioCompra.IsPrimaryKey = False
                colvarNPrecioCompra.IsForeignKey = False
                colvarNPrecioCompra.IsReadOnly = false
                 
                schema.Columns.Add(colvarNPrecioCompra)
                
                Dim colvarBVigente As New TableSchema.TableColumn(schema)
                colvarBVigente.ColumnName = "bVigente"
                colvarBVigente.DataType = DbType.Boolean
                colvarBVigente.MaxLength = 0
                colvarBVigente.AutoIncrement = False
                colvarBVigente.IsNullable = false
                colvarBVigente.IsPrimaryKey = False
                colvarBVigente.IsForeignKey = False
                colvarBVigente.IsReadOnly = false
                 
                schema.Columns.Add(colvarBVigente)
                
                Dim colvarNCodLote As New TableSchema.TableColumn(schema)
                colvarNCodLote.ColumnName = "nCodLote"
                colvarNCodLote.DataType = DbType.Int32
                colvarNCodLote.MaxLength = 0
                colvarNCodLote.AutoIncrement = False
                colvarNCodLote.IsNullable = false
                colvarNCodLote.IsPrimaryKey = False
                colvarNCodLote.IsForeignKey = False
                colvarNCodLote.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodLote)
                
                Dim colvarBEstadoLote As New TableSchema.TableColumn(schema)
                colvarBEstadoLote.ColumnName = "bEstadoLote"
                colvarBEstadoLote.DataType = DbType.Boolean
                colvarBEstadoLote.MaxLength = 0
                colvarBEstadoLote.AutoIncrement = False
                colvarBEstadoLote.IsNullable = false
                colvarBEstadoLote.IsPrimaryKey = False
                colvarBEstadoLote.IsForeignKey = False
                colvarBEstadoLote.IsReadOnly = false
                 
                schema.Columns.Add(colvarBEstadoLote)
                
                Dim colvarNCodAlmacen As New TableSchema.TableColumn(schema)
                colvarNCodAlmacen.ColumnName = "nCodAlmacen"
                colvarNCodAlmacen.DataType = DbType.Int32
                colvarNCodAlmacen.MaxLength = 0
                colvarNCodAlmacen.AutoIncrement = False
                colvarNCodAlmacen.IsNullable = false
                colvarNCodAlmacen.IsPrimaryKey = False
                colvarNCodAlmacen.IsForeignKey = False
                colvarNCodAlmacen.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodAlmacen)
                
                Dim colvarNCodSucursal As New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = False
                colvarNCodSucursal.IsNullable = true
                colvarNCodSucursal.IsPrimaryKey = False
                colvarNCodSucursal.IsForeignKey = False
                colvarNCodSucursal.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarCNombre As New TableSchema.TableColumn(schema)
                colvarCNombre.ColumnName = "cNombre"
                colvarCNombre.DataType = DbType.AnsiString
                colvarCNombre.MaxLength = 255
                colvarCNombre.AutoIncrement = False
                colvarCNombre.IsNullable = false
                colvarCNombre.IsPrimaryKey = False
                colvarCNombre.IsForeignKey = False
                colvarCNombre.IsReadOnly = false
                 
                schema.Columns.Add(colvarCNombre)
                
                Dim colvarCEmpresa As New TableSchema.TableColumn(schema)
                colvarCEmpresa.ColumnName = "cEmpresa"
                colvarCEmpresa.DataType = DbType.AnsiString
                colvarCEmpresa.MaxLength = 200
                colvarCEmpresa.AutoIncrement = False
                colvarCEmpresa.IsNullable = false
                colvarCEmpresa.IsPrimaryKey = False
                colvarCEmpresa.IsForeignKey = False
                colvarCEmpresa.IsReadOnly = false
                 
                schema.Columns.Add(colvarCEmpresa)
                
                Dim colvarNStockActualEnvase As New TableSchema.TableColumn(schema)
                colvarNStockActualEnvase.ColumnName = "nStockActualEnvase"
                colvarNStockActualEnvase.DataType = DbType.Int32
                colvarNStockActualEnvase.MaxLength = 0
                colvarNStockActualEnvase.AutoIncrement = False
                colvarNStockActualEnvase.IsNullable = false
                colvarNStockActualEnvase.IsPrimaryKey = False
                colvarNStockActualEnvase.IsForeignKey = False
                colvarNStockActualEnvase.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockActualEnvase)
                
                Dim colvarNStockActualSuelto As New TableSchema.TableColumn(schema)
                colvarNStockActualSuelto.ColumnName = "nStockActualSuelto"
                colvarNStockActualSuelto.DataType = DbType.Int32
                colvarNStockActualSuelto.MaxLength = 0
                colvarNStockActualSuelto.AutoIncrement = False
                colvarNStockActualSuelto.IsNullable = false
                colvarNStockActualSuelto.IsPrimaryKey = False
                colvarNStockActualSuelto.IsForeignKey = False
                colvarNStockActualSuelto.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockActualSuelto)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VWBuscaProducto",schema)
	        End If
	    End Sub
	    #End Region
	    
        #Region "Query Accessor"
        Public Shared Function CreateQuery As Query
            Return New Query(Schema)
        End Function
	    #End Region
	    
	    #Region ".ctors"
	    Public Sub New()
	        SetSQLProps()
            SetDefaults()
            MarkNew()
	    End Sub
	    
		Public Sub New(ByVal useDatabaseDefaults As Boolean)
			SetSQLProps()
			If useDatabaseDefaults = True Then
				ForceDefaults()
			End If
			MarkNew()
		End Sub
		
	    Public Sub New(ByVal keyID As Object)
	        SetSQLProps()
		    LoadByKey(keyID)
	    End Sub
    	
    	Public Sub new(ByVal columnName As String, ByVal columnValue As Object)
    	    SetSQLProps()
            LoadByParam(columnName , columnValue)
    	End Sub
	    #End Region
	    
	    #Region "Props"
	      
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodProducto")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodProducto", value)
            End Set
        End Property
	      
        <XmlAttribute("CNombreGenerico")> _
        Public Property CNombreGenerico() As String 
		    Get
			    Return GetColumnValue(Of String)("cNombreGenerico")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cNombreGenerico", value)
            End Set
        End Property
	      
        <XmlAttribute("CNombreComercial")> _
        Public Property CNombreComercial() As String 
		    Get
			    Return GetColumnValue(Of String)("cNombreComercial")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cNombreComercial", value)
            End Set
        End Property
	      
        <XmlAttribute("Compuesto")> _
        Public Property Compuesto() As String 
		    Get
			    Return GetColumnValue(Of String)("COMPUESTO")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("COMPUESTO", value)
            End Set
        End Property
	      
        <XmlAttribute("Detalles")> _
        Public Property Detalles() As String 
		    Get
			    Return GetColumnValue(Of String)("DETALLES")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("DETALLES", value)
            End Set
        End Property
	      
        <XmlAttribute("NPrecioCompra")> _
        Public Property NPrecioCompra() As Decimal 
		    Get
			    Return GetColumnValue(Of Decimal)("nPrecioCompra")
			End Get
            Set(ByVal value As Decimal)
			    SetColumnValue("nPrecioCompra", value)
            End Set
        End Property
	      
        <XmlAttribute("BVigente")> _
        Public Property BVigente() As Boolean 
		    Get
			    Return GetColumnValue(Of Boolean)("bVigente")
			End Get
            Set(ByVal value As Boolean)
			    SetColumnValue("bVigente", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodLote")> _
        Public Property NCodLote() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodLote")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodLote", value)
            End Set
        End Property
	      
        <XmlAttribute("BEstadoLote")> _
        Public Property BEstadoLote() As Boolean 
		    Get
			    Return GetColumnValue(Of Boolean)("bEstadoLote")
			End Get
            Set(ByVal value As Boolean)
			    SetColumnValue("bEstadoLote", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodAlmacen")> _
        Public Property NCodAlmacen() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodAlmacen")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodAlmacen", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nCodSucursal")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nCodSucursal", value)
            End Set
        End Property
	      
        <XmlAttribute("CNombre")> _
        Public Property CNombre() As String 
		    Get
			    Return GetColumnValue(Of String)("cNombre")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cNombre", value)
            End Set
        End Property
	      
        <XmlAttribute("CEmpresa")> _
        Public Property CEmpresa() As String 
		    Get
			    Return GetColumnValue(Of String)("cEmpresa")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cEmpresa", value)
            End Set
        End Property
	      
        <XmlAttribute("NStockActualEnvase")> _
        Public Property NStockActualEnvase() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nStockActualEnvase")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nStockActualEnvase", value)
            End Set
        End Property
	      
        <XmlAttribute("NStockActualSuelto")> _
        Public Property NStockActualSuelto() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nStockActualSuelto")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nStockActualSuelto", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared CNombreGenerico As String = "cNombreGenerico"
            
            Public Shared CNombreComercial As String = "cNombreComercial"
            
            Public Shared Compuesto As String = "COMPUESTO"
            
            Public Shared Detalles As String = "DETALLES"
            
            Public Shared NPrecioCompra As String = "nPrecioCompra"
            
            Public Shared BVigente As String = "bVigente"
            
            Public Shared NCodLote As String = "nCodLote"
            
            Public Shared BEstadoLote As String = "bEstadoLote"
            
            Public Shared NCodAlmacen As String = "nCodAlmacen"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared CNombre As String = "cNombre"
            
            Public Shared CEmpresa As String = "cEmpresa"
            
            Public Shared NStockActualEnvase As String = "nStockActualEnvase"
            
            Public Shared NStockActualSuelto As String = "nStockActualSuelto"
            
	    End Structure
	    #End Region
    End Class
End Namespace
