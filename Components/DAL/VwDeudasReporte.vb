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
    ''' Strongly-typed collection for the VwDeudasReporte class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwDeudasReporteCollection 
    Inherits ReadOnlyList(Of VwDeudasReporte, VwDeudasReporteCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwDeudasReporte view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwDeudasReporte 
    Inherits ReadOnlyRecord(Of VwDeudasReporte)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwDeudasReporte", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarNCodEmpleado As New TableSchema.TableColumn(schema)
                colvarNCodEmpleado.ColumnName = "nCodEmpleado"
                colvarNCodEmpleado.DataType = DbType.Int32
                colvarNCodEmpleado.MaxLength = 0
                colvarNCodEmpleado.AutoIncrement = False
                colvarNCodEmpleado.IsNullable = false
                colvarNCodEmpleado.IsPrimaryKey = False
                colvarNCodEmpleado.IsForeignKey = False
                colvarNCodEmpleado.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodEmpleado)
                
                Dim colvarNCodCliente As New TableSchema.TableColumn(schema)
                colvarNCodCliente.ColumnName = "nCodCliente"
                colvarNCodCliente.DataType = DbType.Int64
                colvarNCodCliente.MaxLength = 0
                colvarNCodCliente.AutoIncrement = False
                colvarNCodCliente.IsNullable = false
                colvarNCodCliente.IsPrimaryKey = False
                colvarNCodCliente.IsForeignKey = False
                colvarNCodCliente.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodCliente)
                
                Dim colvarCCliente As New TableSchema.TableColumn(schema)
                colvarCCliente.ColumnName = "cCliente"
                colvarCCliente.DataType = DbType.AnsiString
                colvarCCliente.MaxLength = 255
                colvarCCliente.AutoIncrement = False
                colvarCCliente.IsNullable = false
                colvarCCliente.IsPrimaryKey = False
                colvarCCliente.IsForeignKey = False
                colvarCCliente.IsReadOnly = false
                 
                schema.Columns.Add(colvarCCliente)
                
                Dim colvarVendedor As New TableSchema.TableColumn(schema)
                colvarVendedor.ColumnName = "Vendedor"
                colvarVendedor.DataType = DbType.AnsiString
                colvarVendedor.MaxLength = 300
                colvarVendedor.AutoIncrement = False
                colvarVendedor.IsNullable = true
                colvarVendedor.IsPrimaryKey = False
                colvarVendedor.IsForeignKey = False
                colvarVendedor.IsReadOnly = false
                 
                schema.Columns.Add(colvarVendedor)
                
                Dim colvarNCodFactura As New TableSchema.TableColumn(schema)
                colvarNCodFactura.ColumnName = "nCodFactura"
                colvarNCodFactura.DataType = DbType.Int64
                colvarNCodFactura.MaxLength = 0
                colvarNCodFactura.AutoIncrement = False
                colvarNCodFactura.IsNullable = false
                colvarNCodFactura.IsPrimaryKey = False
                colvarNCodFactura.IsForeignKey = False
                colvarNCodFactura.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodFactura)
                
                Dim colvarNNumero As New TableSchema.TableColumn(schema)
                colvarNNumero.ColumnName = "nNumero"
                colvarNNumero.DataType = DbType.Int32
                colvarNNumero.MaxLength = 0
                colvarNNumero.AutoIncrement = False
                colvarNNumero.IsNullable = false
                colvarNNumero.IsPrimaryKey = False
                colvarNNumero.IsForeignKey = False
                colvarNNumero.IsReadOnly = false
                 
                schema.Columns.Add(colvarNNumero)
                
                Dim colvarEmitida As New TableSchema.TableColumn(schema)
                colvarEmitida.ColumnName = "Emitida"
                colvarEmitida.DataType = DbType.DateTime
                colvarEmitida.MaxLength = 0
                colvarEmitida.AutoIncrement = False
                colvarEmitida.IsNullable = true
                colvarEmitida.IsPrimaryKey = False
                colvarEmitida.IsForeignKey = False
                colvarEmitida.IsReadOnly = false
                 
                schema.Columns.Add(colvarEmitida)
                
                Dim colvarVence As New TableSchema.TableColumn(schema)
                colvarVence.ColumnName = "Vence"
                colvarVence.DataType = DbType.DateTime
                colvarVence.MaxLength = 0
                colvarVence.AutoIncrement = False
                colvarVence.IsNullable = true
                colvarVence.IsPrimaryKey = False
                colvarVence.IsForeignKey = False
                colvarVence.IsReadOnly = false
                 
                schema.Columns.Add(colvarVence)
                
                Dim colvarTotalPagado As New TableSchema.TableColumn(schema)
                colvarTotalPagado.ColumnName = "TotalPagado"
                colvarTotalPagado.DataType = DbType.Currency
                colvarTotalPagado.MaxLength = 0
                colvarTotalPagado.AutoIncrement = False
                colvarTotalPagado.IsNullable = true
                colvarTotalPagado.IsPrimaryKey = False
                colvarTotalPagado.IsForeignKey = False
                colvarTotalPagado.IsReadOnly = false
                 
                schema.Columns.Add(colvarTotalPagado)
                
                Dim colvarTotalFactura As New TableSchema.TableColumn(schema)
                colvarTotalFactura.ColumnName = "TotalFactura"
                colvarTotalFactura.DataType = DbType.Decimal
                colvarTotalFactura.MaxLength = 0
                colvarTotalFactura.AutoIncrement = False
                colvarTotalFactura.IsNullable = true
                colvarTotalFactura.IsPrimaryKey = False
                colvarTotalFactura.IsForeignKey = False
                colvarTotalFactura.IsReadOnly = false
                 
                schema.Columns.Add(colvarTotalFactura)
                
                Dim colvarDeuda As New TableSchema.TableColumn(schema)
                colvarDeuda.ColumnName = "Deuda"
                colvarDeuda.DataType = DbType.Decimal
                colvarDeuda.MaxLength = 0
                colvarDeuda.AutoIncrement = False
                colvarDeuda.IsNullable = true
                colvarDeuda.IsPrimaryKey = False
                colvarDeuda.IsForeignKey = False
                colvarDeuda.IsReadOnly = false
                 
                schema.Columns.Add(colvarDeuda)
                
                Dim colvarPrecio As New TableSchema.TableColumn(schema)
                colvarPrecio.ColumnName = "Precio"
                colvarPrecio.DataType = DbType.Currency
                colvarPrecio.MaxLength = 0
                colvarPrecio.AutoIncrement = False
                colvarPrecio.IsNullable = false
                colvarPrecio.IsPrimaryKey = False
                colvarPrecio.IsForeignKey = False
                colvarPrecio.IsReadOnly = false
                 
                schema.Columns.Add(colvarPrecio)
                
                Dim colvarTotalCantidad As New TableSchema.TableColumn(schema)
                colvarTotalCantidad.ColumnName = "TotalCantidad"
                colvarTotalCantidad.DataType = DbType.Int32
                colvarTotalCantidad.MaxLength = 0
                colvarTotalCantidad.AutoIncrement = False
                colvarTotalCantidad.IsNullable = true
                colvarTotalCantidad.IsPrimaryKey = False
                colvarTotalCantidad.IsForeignKey = False
                colvarTotalCantidad.IsReadOnly = false
                 
                schema.Columns.Add(colvarTotalCantidad)
                
                Dim colvarProducto As New TableSchema.TableColumn(schema)
                colvarProducto.ColumnName = "Producto"
                colvarProducto.DataType = DbType.AnsiString
                colvarProducto.MaxLength = 100
                colvarProducto.AutoIncrement = False
                colvarProducto.IsNullable = false
                colvarProducto.IsPrimaryKey = False
                colvarProducto.IsForeignKey = False
                colvarProducto.IsReadOnly = false
                 
                schema.Columns.Add(colvarProducto)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwDeudasReporte",schema)
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
	      
        <XmlAttribute("NCodEmpleado")> _
        Public Property NCodEmpleado() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodEmpleado")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodEmpleado", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodCliente")> _
        Public Property NCodCliente() As Long 
		    Get
			    Return GetColumnValue(Of Long)("nCodCliente")
			End Get
            Set(ByVal value As Long)
			    SetColumnValue("nCodCliente", value)
            End Set
        End Property
	      
        <XmlAttribute("CCliente")> _
        Public Property CCliente() As String 
		    Get
			    Return GetColumnValue(Of String)("cCliente")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cCliente", value)
            End Set
        End Property
	      
        <XmlAttribute("Vendedor")> _
        Public Property Vendedor() As String 
		    Get
			    Return GetColumnValue(Of String)("Vendedor")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Vendedor", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodFactura")> _
        Public Property NCodFactura() As Long 
		    Get
			    Return GetColumnValue(Of Long)("nCodFactura")
			End Get
            Set(ByVal value As Long)
			    SetColumnValue("nCodFactura", value)
            End Set
        End Property
	      
        <XmlAttribute("NNumero")> _
        Public Property NNumero() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nNumero")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nNumero", value)
            End Set
        End Property
	      
        <XmlAttribute("Emitida")> _
        Public Property Emitida() As Nullable(Of DateTime) 
		    Get
			    Return GetColumnValue(Of Nullable(Of DateTime))("Emitida")
			End Get
            Set(ByVal value As Nullable(Of DateTime))
			    SetColumnValue("Emitida", value)
            End Set
        End Property
	      
        <XmlAttribute("Vence")> _
        Public Property Vence() As Nullable(Of DateTime) 
		    Get
			    Return GetColumnValue(Of Nullable(Of DateTime))("Vence")
			End Get
            Set(ByVal value As Nullable(Of DateTime))
			    SetColumnValue("Vence", value)
            End Set
        End Property
	      
        <XmlAttribute("TotalPagado")> _
        Public Property TotalPagado() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("TotalPagado")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("TotalPagado", value)
            End Set
        End Property
	      
        <XmlAttribute("TotalFactura")> _
        Public Property TotalFactura() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("TotalFactura")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("TotalFactura", value)
            End Set
        End Property
	      
        <XmlAttribute("Deuda")> _
        Public Property Deuda() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("Deuda")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("Deuda", value)
            End Set
        End Property
	      
        <XmlAttribute("Precio")> _
        Public Property Precio() As Decimal 
		    Get
			    Return GetColumnValue(Of Decimal)("Precio")
			End Get
            Set(ByVal value As Decimal)
			    SetColumnValue("Precio", value)
            End Set
        End Property
	      
        <XmlAttribute("TotalCantidad")> _
        Public Property TotalCantidad() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("TotalCantidad")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("TotalCantidad", value)
            End Set
        End Property
	      
        <XmlAttribute("Producto")> _
        Public Property Producto() As String 
		    Get
			    Return GetColumnValue(Of String)("Producto")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Producto", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodEmpleado As String = "nCodEmpleado"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared Vendedor As String = "Vendedor"
            
            Public Shared NCodFactura As String = "nCodFactura"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared Emitida As String = "Emitida"
            
            Public Shared Vence As String = "Vence"
            
            Public Shared TotalPagado As String = "TotalPagado"
            
            Public Shared TotalFactura As String = "TotalFactura"
            
            Public Shared Deuda As String = "Deuda"
            
            Public Shared Precio As String = "Precio"
            
            Public Shared TotalCantidad As String = "TotalCantidad"
            
            Public Shared Producto As String = "Producto"
            
	    End Structure
	    #End Region
    End Class
End Namespace
