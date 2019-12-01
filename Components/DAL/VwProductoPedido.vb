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
    ''' Strongly-typed collection for the VwProductoPedido class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwProductoPedidoCollection 
    Inherits ReadOnlyList(Of VwProductoPedido, VwProductoPedidoCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwProductoPedido view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwProductoPedido 
    Inherits ReadOnlyRecord(Of VwProductoPedido)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwProductoPedido", TableType.View, DataService.GetInstance("DALEjSuite"))
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
                
                Dim colvarProducto As New TableSchema.TableColumn(schema)
                colvarProducto.ColumnName = "Producto"
                colvarProducto.DataType = DbType.AnsiString
                colvarProducto.MaxLength = 100
                colvarProducto.AutoIncrement = False
                colvarProducto.IsNullable = true
                colvarProducto.IsPrimaryKey = False
                colvarProducto.IsForeignKey = False
                colvarProducto.IsReadOnly = false
                 
                schema.Columns.Add(colvarProducto)
                
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
                
                Dim colvarFaltante As New TableSchema.TableColumn(schema)
                colvarFaltante.ColumnName = "FALTANTE"
                colvarFaltante.DataType = DbType.Int32
                colvarFaltante.MaxLength = 0
                colvarFaltante.AutoIncrement = False
                colvarFaltante.IsNullable = false
                colvarFaltante.IsPrimaryKey = False
                colvarFaltante.IsForeignKey = False
                colvarFaltante.IsReadOnly = false
                 
                schema.Columns.Add(colvarFaltante)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwProductoPedido",schema)
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
	      
        <XmlAttribute("Producto")> _
        Public Property Producto() As String 
		    Get
			    Return GetColumnValue(Of String)("Producto")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Producto", value)
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
	      
        <XmlAttribute("Faltante")> _
        Public Property Faltante() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("FALTANTE")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("FALTANTE", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared Producto As String = "Producto"
            
            Public Shared NPrecioCompra As String = "nPrecioCompra"
            
            Public Shared Faltante As String = "FALTANTE"
            
	    End Structure
	    #End Region
    End Class
End Namespace
