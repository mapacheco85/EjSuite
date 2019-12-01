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
    ''' Strongly-typed collection for the VwPago class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwPagoCollection 
    Inherits ReadOnlyList(Of VwPago, VwPagoCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwPagos view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwPago 
    Inherits ReadOnlyRecord(Of VwPago)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwPagos", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarNCodPago As New TableSchema.TableColumn(schema)
                colvarNCodPago.ColumnName = "nCodPago"
                colvarNCodPago.DataType = DbType.Int32
                colvarNCodPago.MaxLength = 0
                colvarNCodPago.AutoIncrement = False
                colvarNCodPago.IsNullable = false
                colvarNCodPago.IsPrimaryKey = False
                colvarNCodPago.IsForeignKey = False
                colvarNCodPago.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodPago)
                
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
                
                Dim colvarDFechaPago As New TableSchema.TableColumn(schema)
                colvarDFechaPago.ColumnName = "dFechaPago"
                colvarDFechaPago.DataType = DbType.DateTime
                colvarDFechaPago.MaxLength = 0
                colvarDFechaPago.AutoIncrement = False
                colvarDFechaPago.IsNullable = true
                colvarDFechaPago.IsPrimaryKey = False
                colvarDFechaPago.IsForeignKey = False
                colvarDFechaPago.IsReadOnly = false
                 
                schema.Columns.Add(colvarDFechaPago)
                
                Dim colvarMonto As New TableSchema.TableColumn(schema)
                colvarMonto.ColumnName = "Monto"
                colvarMonto.DataType = DbType.Currency
                colvarMonto.MaxLength = 0
                colvarMonto.AutoIncrement = False
                colvarMonto.IsNullable = true
                colvarMonto.IsPrimaryKey = False
                colvarMonto.IsForeignKey = False
                colvarMonto.IsReadOnly = false
                 
                schema.Columns.Add(colvarMonto)
                
                Dim colvarSaldo As New TableSchema.TableColumn(schema)
                colvarSaldo.ColumnName = "Saldo"
                colvarSaldo.DataType = DbType.Decimal
                colvarSaldo.MaxLength = 0
                colvarSaldo.AutoIncrement = False
                colvarSaldo.IsNullable = true
                colvarSaldo.IsPrimaryKey = False
                colvarSaldo.IsForeignKey = False
                colvarSaldo.IsReadOnly = false
                 
                schema.Columns.Add(colvarSaldo)
                
                Dim colvarFormaPago As New TableSchema.TableColumn(schema)
                colvarFormaPago.ColumnName = "FormaPago"
                colvarFormaPago.DataType = DbType.AnsiString
                colvarFormaPago.MaxLength = 7
                colvarFormaPago.AutoIncrement = False
                colvarFormaPago.IsNullable = false
                colvarFormaPago.IsPrimaryKey = False
                colvarFormaPago.IsForeignKey = False
                colvarFormaPago.IsReadOnly = false
                 
                schema.Columns.Add(colvarFormaPago)
                
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
                
                Dim colvarIc As New TableSchema.TableColumn(schema)
                colvarIc.ColumnName = "ic"
                colvarIc.DataType = DbType.Int32
                colvarIc.MaxLength = 0
                colvarIc.AutoIncrement = False
                colvarIc.IsNullable = true
                colvarIc.IsPrimaryKey = False
                colvarIc.IsForeignKey = False
                colvarIc.IsReadOnly = false
                 
                schema.Columns.Add(colvarIc)
                
                Dim colvarRo As New TableSchema.TableColumn(schema)
                colvarRo.ColumnName = "ro"
                colvarRo.DataType = DbType.Int32
                colvarRo.MaxLength = 0
                colvarRo.AutoIncrement = False
                colvarRo.IsNullable = true
                colvarRo.IsPrimaryKey = False
                colvarRo.IsForeignKey = False
                colvarRo.IsReadOnly = false
                 
                schema.Columns.Add(colvarRo)
                
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
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwPagos",schema)
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
	      
        <XmlAttribute("NCodPago")> _
        Public Property NCodPago() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodPago")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodPago", value)
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
	      
        <XmlAttribute("Total")> _
        Public Property Total() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("Total")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("Total", value)
            End Set
        End Property
	      
        <XmlAttribute("DFechaPago")> _
        Public Property DFechaPago() As Nullable(Of DateTime) 
		    Get
			    Return GetColumnValue(Of Nullable(Of DateTime))("dFechaPago")
			End Get
            Set(ByVal value As Nullable(Of DateTime))
			    SetColumnValue("dFechaPago", value)
            End Set
        End Property
	      
        <XmlAttribute("Monto")> _
        Public Property Monto() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("Monto")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("Monto", value)
            End Set
        End Property
	      
        <XmlAttribute("Saldo")> _
        Public Property Saldo() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("Saldo")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("Saldo", value)
            End Set
        End Property
	      
        <XmlAttribute("FormaPago")> _
        Public Property FormaPago() As String 
		    Get
			    Return GetColumnValue(Of String)("FormaPago")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("FormaPago", value)
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
	      
        <XmlAttribute("NCodSucursal")> _
        Public Property NCodSucursal() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodSucursal")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodSucursal", value)
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
	      
        <XmlAttribute("Ic")> _
        Public Property Ic() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("ic")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("ic", value)
            End Set
        End Property
	      
        <XmlAttribute("Ro")> _
        Public Property Ro() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("ro")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("ro", value)
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
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodPago As String = "nCodPago"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared Total As String = "Total"
            
            Public Shared DFechaPago As String = "dFechaPago"
            
            Public Shared Monto As String = "Monto"
            
            Public Shared Saldo As String = "Saldo"
            
            Public Shared FormaPago As String = "FormaPago"
            
            Public Shared Vendedor As String = "Vendedor"
            
            Public Shared NCodSucursal As String = "nCodSucursal"
            
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared Ic As String = "ic"
            
            Public Shared Ro As String = "ro"
            
            Public Shared NCodFactura As String = "nCodFactura"
            
	    End Structure
	    #End Region
    End Class
End Namespace
