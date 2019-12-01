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
    ''' Strongly-typed collection for the VwRepVentasProducto class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwRepVentasProductoCollection 
    Inherits ReadOnlyList(Of VwRepVentasProducto, VwRepVentasProductoCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwRepVentasProductos view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwRepVentasProducto 
    Inherits ReadOnlyRecord(Of VwRepVentasProducto)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwRepVentasProductos", TableType.View, DataService.GetInstance("DALEjSuite"))
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
                
                Dim colvarNCantidad As New TableSchema.TableColumn(schema)
                colvarNCantidad.ColumnName = "nCantidad"
                colvarNCantidad.DataType = DbType.Int32
                colvarNCantidad.MaxLength = 0
                colvarNCantidad.AutoIncrement = False
                colvarNCantidad.IsNullable = true
                colvarNCantidad.IsPrimaryKey = False
                colvarNCantidad.IsForeignKey = False
                colvarNCantidad.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCantidad)
                
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
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwRepVentasProductos",schema)
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
	      
        <XmlAttribute("Detalles")> _
        Public Property Detalles() As String 
		    Get
			    Return GetColumnValue(Of String)("DETALLES")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("DETALLES", value)
            End Set
        End Property
	      
        <XmlAttribute("NCantidad")> _
        Public Property NCantidad() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nCantidad")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nCantidad", value)
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
	      
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodSucursal")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodSucursal", value)
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
	        
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared Detalles As String = "DETALLES"
            
            Public Shared NCantidad As String = "nCantidad"
            
            Public Shared DFechaEmision As String = "dFechaEmision"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared Total As String = "Total"
            
	    End Structure
	    #End Region
    End Class
End Namespace
