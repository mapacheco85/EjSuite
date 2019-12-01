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
    ''' Strongly-typed collection for the Vwdatakardex class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwdatakardexCollection 
    Inherits ReadOnlyList(Of Vwdatakardex, VwdatakardexCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VWDATAKARDEX view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class Vwdatakardex 
    Inherits ReadOnlyRecord(Of Vwdatakardex)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VWDATAKARDEX", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarProveedor As New TableSchema.TableColumn(schema)
                colvarProveedor.ColumnName = "Proveedor"
                colvarProveedor.DataType = DbType.AnsiString
                colvarProveedor.MaxLength = 255
                colvarProveedor.AutoIncrement = False
                colvarProveedor.IsNullable = false
                colvarProveedor.IsPrimaryKey = False
                colvarProveedor.IsForeignKey = False
                colvarProveedor.IsReadOnly = false
                 
                schema.Columns.Add(colvarProveedor)
                
                Dim colvarInsumo As New TableSchema.TableColumn(schema)
                colvarInsumo.ColumnName = "Insumo"
                colvarInsumo.DataType = DbType.AnsiString
                colvarInsumo.MaxLength = -1
                colvarInsumo.AutoIncrement = False
                colvarInsumo.IsNullable = true
                colvarInsumo.IsPrimaryKey = False
                colvarInsumo.IsForeignKey = False
                colvarInsumo.IsReadOnly = false
                 
                schema.Columns.Add(colvarInsumo)
                
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
                
                Dim colvarFechaRegistro As New TableSchema.TableColumn(schema)
                colvarFechaRegistro.ColumnName = "FechaRegistro"
                colvarFechaRegistro.DataType = DbType.AnsiString
                colvarFechaRegistro.MaxLength = 10
                colvarFechaRegistro.AutoIncrement = False
                colvarFechaRegistro.IsNullable = true
                colvarFechaRegistro.IsPrimaryKey = False
                colvarFechaRegistro.IsForeignKey = False
                colvarFechaRegistro.IsReadOnly = false
                 
                schema.Columns.Add(colvarFechaRegistro)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VWDATAKARDEX",schema)
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
	      
        <XmlAttribute("Proveedor")> _
        Public Property Proveedor() As String 
		    Get
			    Return GetColumnValue(Of String)("Proveedor")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Proveedor", value)
            End Set
        End Property
	      
        <XmlAttribute("Insumo")> _
        Public Property Insumo() As String 
		    Get
			    Return GetColumnValue(Of String)("Insumo")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("Insumo", value)
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
	      
        <XmlAttribute("FechaRegistro")> _
        Public Property FechaRegistro() As String 
		    Get
			    Return GetColumnValue(Of String)("FechaRegistro")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("FechaRegistro", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared Proveedor As String = "Proveedor"
            
            Public Shared Insumo As String = "Insumo"
            
            Public Shared NStockActualEnvase As String = "nStockActualEnvase"
            
            Public Shared FechaRegistro As String = "FechaRegistro"
            
	    End Structure
	    #End Region
    End Class
End Namespace
