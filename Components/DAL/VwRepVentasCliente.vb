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
    ''' Strongly-typed collection for the VwRepVentasCliente class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwRepVentasClienteCollection 
    Inherits ReadOnlyList(Of VwRepVentasCliente, VwRepVentasClienteCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwRepVentasClientes view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwRepVentasCliente 
    Inherits ReadOnlyRecord(Of VwRepVentasCliente)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwRepVentasClientes", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
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
                
                Dim colvarNCodSucursal As New TableSchema.TableColumn(schema)
                colvarNCodSucursal.ColumnName = "nCodSucursal"
                colvarNCodSucursal.DataType = DbType.Int32
                colvarNCodSucursal.MaxLength = 0
                colvarNCodSucursal.AutoIncrement = False
                colvarNCodSucursal.IsNullable = false
                colvarNCodSucursal.IsPrimaryKey = False
                colvarNCodSucursal.IsForeignKey = False
                colvarNCodSucursal.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodSucursal)
                
                Dim colvarDFechaEmision As New TableSchema.TableColumn(schema)
                colvarDFechaEmision.ColumnName = "dFechaEmision"
                colvarDFechaEmision.DataType = DbType.DateTime
                colvarDFechaEmision.MaxLength = 0
                colvarDFechaEmision.AutoIncrement = False
                colvarDFechaEmision.IsNullable = true
                colvarDFechaEmision.IsPrimaryKey = False
                colvarDFechaEmision.IsForeignKey = False
                colvarDFechaEmision.IsReadOnly = false
                 
                schema.Columns.Add(colvarDFechaEmision)
                
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
                
                Dim colvarProducto As New TableSchema.TableColumn(schema)
                colvarProducto.ColumnName = "Producto"
                colvarProducto.DataType = DbType.AnsiString
                colvarProducto.MaxLength = -1
                colvarProducto.AutoIncrement = False
                colvarProducto.IsNullable = true
                colvarProducto.IsPrimaryKey = False
                colvarProducto.IsForeignKey = False
                colvarProducto.IsReadOnly = false
                 
                schema.Columns.Add(colvarProducto)
                
                Dim colvarNCantidad As New TableSchema.TableColumn(schema)
                colvarNCantidad.ColumnName = "nCantidad"
                colvarNCantidad.DataType = DbType.Int32
                colvarNCantidad.MaxLength = 0
                colvarNCantidad.AutoIncrement = False
                colvarNCantidad.IsNullable = false
                colvarNCantidad.IsPrimaryKey = False
                colvarNCantidad.IsForeignKey = False
                colvarNCantidad.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCantidad)
                
                Dim colvarTotal As New TableSchema.TableColumn(schema)
                colvarTotal.ColumnName = "Total"
                colvarTotal.DataType = DbType.Decimal
                colvarTotal.MaxLength = 0
                colvarTotal.AutoIncrement = False
                colvarTotal.IsNullable = true
                colvarTotal.IsPrimaryKey = False
                colvarTotal.IsForeignKey = False
                colvarTotal.IsReadOnly = false
                 
                schema.Columns.Add(colvarTotal)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwRepVentasClientes",schema)
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
	      
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodSucursal")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodSucursal", value)
            End Set
        End Property
	      
        <XmlAttribute("DFechaEmision")> _
        Public Property DFechaEmision() As Nullable(Of DateTime) 
		    Get
			    Return GetColumnValue(Of Nullable(Of DateTime))("dFechaEmision")
			End Get
            Set(ByVal value As Nullable(Of DateTime))
			    SetColumnValue("dFechaEmision", value)
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
	      
        <XmlAttribute("Producto")> _
        Public Property Producto() As String 
		    Get
			    Return GetColumnValue(Of String)("Producto")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Producto", value)
            End Set
        End Property
	      
        <XmlAttribute("NCantidad")> _
        Public Property NCantidad() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCantidad")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCantidad", value)
            End Set
        End Property
	      
        <XmlAttribute("Total")> _
        Public Property Total() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("Total")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("Total", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared DFechaEmision As String = "dFechaEmision"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared Producto As String = "Producto"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared Total As String = "Total"
            
	    End Structure
	    #End Region
    End Class
End Namespace
