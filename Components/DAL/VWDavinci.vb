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
    ''' Strongly-typed collection for the VWDavinci class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VWDavinciCollection 
    Inherits ReadOnlyList(Of VWDavinci, VWDavinciCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VWDavinci view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VWDavinci 
    Inherits ReadOnlyRecord(Of VWDavinci)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VWDavinci", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarCNit As New TableSchema.TableColumn(schema)
                colvarCNit.ColumnName = "cNit"
                colvarCNit.DataType = DbType.AnsiString
                colvarCNit.MaxLength = 20
                colvarCNit.AutoIncrement = False
                colvarCNit.IsNullable = true
                colvarCNit.IsPrimaryKey = False
                colvarCNit.IsForeignKey = False
                colvarCNit.IsReadOnly = false
                 
                schema.Columns.Add(colvarCNit)
                
                Dim colvarCNombreFactura As New TableSchema.TableColumn(schema)
                colvarCNombreFactura.ColumnName = "cNombreFactura"
                colvarCNombreFactura.DataType = DbType.AnsiString
                colvarCNombreFactura.MaxLength = 255
                colvarCNombreFactura.AutoIncrement = False
                colvarCNombreFactura.IsNullable = false
                colvarCNombreFactura.IsPrimaryKey = False
                colvarCNombreFactura.IsForeignKey = False
                colvarCNombreFactura.IsReadOnly = false
                 
                schema.Columns.Add(colvarCNombreFactura)
                
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
                
                Dim colvarCAutorizacion As New TableSchema.TableColumn(schema)
                colvarCAutorizacion.ColumnName = "cAutorizacion"
                colvarCAutorizacion.DataType = DbType.AnsiString
                colvarCAutorizacion.MaxLength = 20
                colvarCAutorizacion.AutoIncrement = False
                colvarCAutorizacion.IsNullable = false
                colvarCAutorizacion.IsPrimaryKey = False
                colvarCAutorizacion.IsForeignKey = False
                colvarCAutorizacion.IsReadOnly = false
                 
                schema.Columns.Add(colvarCAutorizacion)
                
                Dim colvarDFechaEmision As New TableSchema.TableColumn(schema)
                colvarDFechaEmision.ColumnName = "dFechaEmision"
                colvarDFechaEmision.DataType = DbType.AnsiString
                colvarDFechaEmision.MaxLength = 0
                colvarDFechaEmision.AutoIncrement = False
                colvarDFechaEmision.IsNullable = true
                colvarDFechaEmision.IsPrimaryKey = False
                colvarDFechaEmision.IsForeignKey = False
                colvarDFechaEmision.IsReadOnly = false
                 
                schema.Columns.Add(colvarDFechaEmision)
                
                Dim colvarMonto As New TableSchema.TableColumn(schema)
                colvarMonto.ColumnName = "monto"
                colvarMonto.DataType = DbType.Decimal
                colvarMonto.MaxLength = 0
                colvarMonto.AutoIncrement = False
                colvarMonto.IsNullable = true
                colvarMonto.IsPrimaryKey = False
                colvarMonto.IsForeignKey = False
                colvarMonto.IsReadOnly = false
                 
                schema.Columns.Add(colvarMonto)
                
                Dim colvarCCodigoFactura As New TableSchema.TableColumn(schema)
                colvarCCodigoFactura.ColumnName = "cCodigoFactura"
                colvarCCodigoFactura.DataType = DbType.AnsiString
                colvarCCodigoFactura.MaxLength = 15
                colvarCCodigoFactura.AutoIncrement = False
                colvarCCodigoFactura.IsNullable = false
                colvarCCodigoFactura.IsPrimaryKey = False
                colvarCCodigoFactura.IsForeignKey = False
                colvarCCodigoFactura.IsReadOnly = false
                 
                schema.Columns.Add(colvarCCodigoFactura)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VWDavinci",schema)
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
	      
        <XmlAttribute("CNit")> _
        Public Property CNit() As String 
		    Get
			    Return GetColumnValue(Of String)("cNit")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cNit", value)
            End Set
        End Property
	      
        <XmlAttribute("CNombreFactura")> _
        Public Property CNombreFactura() As String 
		    Get
			    Return GetColumnValue(Of String)("cNombreFactura")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cNombreFactura", value)
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
	      
        <XmlAttribute("CAutorizacion")> _
        Public Property CAutorizacion() As String 
		    Get
			    Return GetColumnValue(Of String)("cAutorizacion")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cAutorizacion", value)
            End Set
        End Property
	      
        <XmlAttribute("DFechaEmision")> _
        Public Property DFechaEmision() As String 
		    Get
			    Return GetColumnValue(Of String)("dFechaEmision")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("dFechaEmision", value)
            End Set
        End Property
	      
        <XmlAttribute("Monto")> _
        Public Property Monto() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("monto")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("monto", value)
            End Set
        End Property
	      
        <XmlAttribute("CCodigoFactura")> _
        Public Property CCodigoFactura() As String 
		    Get
			    Return GetColumnValue(Of String)("cCodigoFactura")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cCodigoFactura", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared CNit As String = "cNit"
            
            Public Shared CNombreFactura As String = "cNombreFactura"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared CAutorizacion As String = "cAutorizacion"
            
            Public Shared DFechaEmision As String = "dFechaEmision"
            
            Public Shared Monto As String = "monto"
            
            Public Shared CCodigoFactura As String = "cCodigoFactura"
            
	    End Structure
	    #End Region
    End Class
End Namespace
