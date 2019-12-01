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
    ''' Strongly-typed collection for the VwCuentasCliente class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwCuentasClienteCollection 
    Inherits ReadOnlyList(Of VwCuentasCliente, VwCuentasClienteCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwCuentasClientes view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwCuentasCliente 
    Inherits ReadOnlyRecord(Of VwCuentasCliente)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwCuentasClientes", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
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
                
                Dim colvarDVencimiento As New TableSchema.TableColumn(schema)
                colvarDVencimiento.ColumnName = "dVencimiento"
                colvarDVencimiento.DataType = DbType.DateTime
                colvarDVencimiento.MaxLength = 0
                colvarDVencimiento.AutoIncrement = False
                colvarDVencimiento.IsNullable = true
                colvarDVencimiento.IsPrimaryKey = False
                colvarDVencimiento.IsForeignKey = False
                colvarDVencimiento.IsReadOnly = false
                 
                schema.Columns.Add(colvarDVencimiento)
                
                Dim colvarDebe As New TableSchema.TableColumn(schema)
                colvarDebe.ColumnName = "Debe"
                colvarDebe.DataType = DbType.Currency
                colvarDebe.MaxLength = 0
                colvarDebe.AutoIncrement = False
                colvarDebe.IsNullable = false
                colvarDebe.IsPrimaryKey = False
                colvarDebe.IsForeignKey = False
                colvarDebe.IsReadOnly = false
                 
                schema.Columns.Add(colvarDebe)
                
                Dim colvarHaber As New TableSchema.TableColumn(schema)
                colvarHaber.ColumnName = "Haber"
                colvarHaber.DataType = DbType.Currency
                colvarHaber.MaxLength = 0
                colvarHaber.AutoIncrement = False
                colvarHaber.IsNullable = false
                colvarHaber.IsPrimaryKey = False
                colvarHaber.IsForeignKey = False
                colvarHaber.IsReadOnly = false
                 
                schema.Columns.Add(colvarHaber)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwCuentasClientes",schema)
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
	      
        <XmlAttribute("NCodFactura")> _
        Public Property NCodFactura() As Long 
		    Get
			    Return GetColumnValue(Of Long)("nCodFactura")
			End Get
            Set(ByVal value As Long)
			    SetColumnValue("nCodFactura", value)
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
	      
        <XmlAttribute("NNumero")> _
        Public Property NNumero() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nNumero")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nNumero", value)
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
	      
        <XmlAttribute("DVencimiento")> _
        Public Property DVencimiento() As Nullable(Of DateTime) 
		    Get
			    Return GetColumnValue(Of Nullable(Of DateTime))("dVencimiento")
			End Get
            Set(ByVal value As Nullable(Of DateTime))
			    SetColumnValue("dVencimiento", value)
            End Set
        End Property
	      
        <XmlAttribute("Debe")> _
        Public Property Debe() As Decimal 
		    Get
			    Return GetColumnValue(Of Decimal)("Debe")
			End Get
            Set(ByVal value As Decimal)
			    SetColumnValue("Debe", value)
            End Set
        End Property
	      
        <XmlAttribute("Haber")> _
        Public Property Haber() As Decimal 
		    Get
			    Return GetColumnValue(Of Decimal)("Haber")
			End Get
            Set(ByVal value As Decimal)
			    SetColumnValue("Haber", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodFactura As String = "nCodFactura"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared DFechaEmision As String = "dFechaEmision"
            
            Public Shared DVencimiento As String = "dVencimiento"
            
            Public Shared Debe As String = "Debe"
            
            Public Shared Haber As String = "Haber"
            
	    End Structure
	    #End Region
    End Class
End Namespace
