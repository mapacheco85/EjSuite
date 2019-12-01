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
    ''' Strongly-typed collection for the VwReporteKardex class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwReporteKardexCollection 
    Inherits ReadOnlyList(Of VwReporteKardex, VwReporteKardexCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwReporteKardex view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwReporteKardex 
    Inherits ReadOnlyRecord(Of VwReporteKardex)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwReporteKardex", TableType.View, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
                
                'Columns
                
                Dim colvarNCodKardex As New TableSchema.TableColumn(schema)
                colvarNCodKardex.ColumnName = "nCodKardex"
                colvarNCodKardex.DataType = DbType.Int32
                colvarNCodKardex.MaxLength = 0
                colvarNCodKardex.AutoIncrement = False
                colvarNCodKardex.IsNullable = false
                colvarNCodKardex.IsPrimaryKey = False
                colvarNCodKardex.IsForeignKey = False
                colvarNCodKardex.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodKardex)
                
                Dim colvarCGlosa As New TableSchema.TableColumn(schema)
                colvarCGlosa.ColumnName = "cGlosa"
                colvarCGlosa.DataType = DbType.AnsiString
                colvarCGlosa.MaxLength = 255
                colvarCGlosa.AutoIncrement = False
                colvarCGlosa.IsNullable = false
                colvarCGlosa.IsPrimaryKey = False
                colvarCGlosa.IsForeignKey = False
                colvarCGlosa.IsReadOnly = false
                 
                schema.Columns.Add(colvarCGlosa)
                
                Dim colvarDFechareg As New TableSchema.TableColumn(schema)
                colvarDFechareg.ColumnName = "dFechareg"
                colvarDFechareg.DataType = DbType.DateTime
                colvarDFechareg.MaxLength = 0
                colvarDFechareg.AutoIncrement = False
                colvarDFechareg.IsNullable = false
                colvarDFechareg.IsPrimaryKey = False
                colvarDFechareg.IsForeignKey = False
                colvarDFechareg.IsReadOnly = false
                 
                schema.Columns.Add(colvarDFechareg)
                
                Dim colvarCDetalles As New TableSchema.TableColumn(schema)
                colvarCDetalles.ColumnName = "cDetalles"
                colvarCDetalles.DataType = DbType.AnsiString
                colvarCDetalles.MaxLength = 2147483647
                colvarCDetalles.AutoIncrement = False
                colvarCDetalles.IsNullable = false
                colvarCDetalles.IsPrimaryKey = False
                colvarCDetalles.IsForeignKey = False
                colvarCDetalles.IsReadOnly = false
                 
                schema.Columns.Add(colvarCDetalles)
                
                Dim colvarNCodAlmacen As New TableSchema.TableColumn(schema)
                colvarNCodAlmacen.ColumnName = "nCodAlmacen"
                colvarNCodAlmacen.DataType = DbType.Int32
                colvarNCodAlmacen.MaxLength = 0
                colvarNCodAlmacen.AutoIncrement = False
                colvarNCodAlmacen.IsNullable = true
                colvarNCodAlmacen.IsPrimaryKey = False
                colvarNCodAlmacen.IsForeignKey = False
                colvarNCodAlmacen.IsReadOnly = false
                 
                schema.Columns.Add(colvarNCodAlmacen)
                
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
                
                Dim colvarNStockAnteriorEnvase As New TableSchema.TableColumn(schema)
                colvarNStockAnteriorEnvase.ColumnName = "nStockAnteriorEnvase"
                colvarNStockAnteriorEnvase.DataType = DbType.Int32
                colvarNStockAnteriorEnvase.MaxLength = 0
                colvarNStockAnteriorEnvase.AutoIncrement = False
                colvarNStockAnteriorEnvase.IsNullable = false
                colvarNStockAnteriorEnvase.IsPrimaryKey = False
                colvarNStockAnteriorEnvase.IsForeignKey = False
                colvarNStockAnteriorEnvase.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockAnteriorEnvase)
                
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
                
                Dim colvarNStockAnteriorBonificacion As New TableSchema.TableColumn(schema)
                colvarNStockAnteriorBonificacion.ColumnName = "nStockAnteriorBonificacion"
                colvarNStockAnteriorBonificacion.DataType = DbType.Int32
                colvarNStockAnteriorBonificacion.MaxLength = 0
                colvarNStockAnteriorBonificacion.AutoIncrement = False
                colvarNStockAnteriorBonificacion.IsNullable = true
                colvarNStockAnteriorBonificacion.IsPrimaryKey = False
                colvarNStockAnteriorBonificacion.IsForeignKey = False
                colvarNStockAnteriorBonificacion.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockAnteriorBonificacion)
                
                Dim colvarNStockActualBonificacion As New TableSchema.TableColumn(schema)
                colvarNStockActualBonificacion.ColumnName = "nStockActualBonificacion"
                colvarNStockActualBonificacion.DataType = DbType.Int32
                colvarNStockActualBonificacion.MaxLength = 0
                colvarNStockActualBonificacion.AutoIncrement = False
                colvarNStockActualBonificacion.IsNullable = true
                colvarNStockActualBonificacion.IsPrimaryKey = False
                colvarNStockActualBonificacion.IsForeignKey = False
                colvarNStockActualBonificacion.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockActualBonificacion)
                
                Dim colvarNStockAnteriorReintegro As New TableSchema.TableColumn(schema)
                colvarNStockAnteriorReintegro.ColumnName = "nStockAnteriorReintegro"
                colvarNStockAnteriorReintegro.DataType = DbType.Int32
                colvarNStockAnteriorReintegro.MaxLength = 0
                colvarNStockAnteriorReintegro.AutoIncrement = False
                colvarNStockAnteriorReintegro.IsNullable = true
                colvarNStockAnteriorReintegro.IsPrimaryKey = False
                colvarNStockAnteriorReintegro.IsForeignKey = False
                colvarNStockAnteriorReintegro.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockAnteriorReintegro)
                
                Dim colvarNStockActualReintegro As New TableSchema.TableColumn(schema)
                colvarNStockActualReintegro.ColumnName = "nStockActualReintegro"
                colvarNStockActualReintegro.DataType = DbType.Int32
                colvarNStockActualReintegro.MaxLength = 0
                colvarNStockActualReintegro.AutoIncrement = False
                colvarNStockActualReintegro.IsNullable = true
                colvarNStockActualReintegro.IsPrimaryKey = False
                colvarNStockActualReintegro.IsForeignKey = False
                colvarNStockActualReintegro.IsReadOnly = false
                 
                schema.Columns.Add(colvarNStockActualReintegro)
                
                Dim colvarCObservacion As New TableSchema.TableColumn(schema)
                colvarCObservacion.ColumnName = "cObservacion"
                colvarCObservacion.DataType = DbType.AnsiString
                colvarCObservacion.MaxLength = 200
                colvarCObservacion.AutoIncrement = False
                colvarCObservacion.IsNullable = false
                colvarCObservacion.IsPrimaryKey = False
                colvarCObservacion.IsForeignKey = False
                colvarCObservacion.IsReadOnly = false
                 
                schema.Columns.Add(colvarCObservacion)
                
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
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwReporteKardex",schema)
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
	      
        <XmlAttribute("NCodKardex")> _
        Public Property NCodKardex() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodKardex")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodKardex", value)
            End Set
        End Property
	      
        <XmlAttribute("CGlosa")> _
        Public Property CGlosa() As String 
		    Get
			    Return GetColumnValue(Of String)("cGlosa")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cGlosa", value)
            End Set
        End Property
	      
        <XmlAttribute("DFechareg")> _
        Public Property DFechareg() As DateTime 
		    Get
			    Return GetColumnValue(Of DateTime)("dFechareg")
			End Get
            Set(ByVal value As DateTime)
			    SetColumnValue("dFechareg", value)
            End Set
        End Property
	      
        <XmlAttribute("CDetalles")> _
        Public Property CDetalles() As String 
		    Get
			    Return GetColumnValue(Of String)("cDetalles")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cDetalles", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodAlmacen")> _
        Public Property NCodAlmacen() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nCodAlmacen")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nCodAlmacen", value)
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
	      
        <XmlAttribute("NStockAnteriorEnvase")> _
        Public Property NStockAnteriorEnvase() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nStockAnteriorEnvase")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nStockAnteriorEnvase", value)
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
	      
        <XmlAttribute("NStockAnteriorBonificacion")> _
        Public Property NStockAnteriorBonificacion() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nStockAnteriorBonificacion")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nStockAnteriorBonificacion", value)
            End Set
        End Property
	      
        <XmlAttribute("NStockActualBonificacion")> _
        Public Property NStockActualBonificacion() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nStockActualBonificacion")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nStockActualBonificacion", value)
            End Set
        End Property
	      
        <XmlAttribute("NStockAnteriorReintegro")> _
        Public Property NStockAnteriorReintegro() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nStockAnteriorReintegro")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nStockAnteriorReintegro", value)
            End Set
        End Property
	      
        <XmlAttribute("NStockActualReintegro")> _
        Public Property NStockActualReintegro() As Nullable(Of Integer) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Integer))("nStockActualReintegro")
			End Get
            Set(ByVal value As Nullable(Of Integer))
			    SetColumnValue("nStockActualReintegro", value)
            End Set
        End Property
	      
        <XmlAttribute("CObservacion")> _
        Public Property CObservacion() As String 
		    Get
			    Return GetColumnValue(Of String)("cObservacion")
			End Get
            Set(ByVal value As String)
			    SetColumnValue("cObservacion", value)
            End Set
        End Property
	      
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto() As Integer 
		    Get
			    Return GetColumnValue(Of Integer)("nCodProducto")
			End Get
            Set(ByVal value As Integer)
			    SetColumnValue("nCodProducto", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodKardex As String = "nCodKardex"
            
            Public Shared CGlosa As String = "cGlosa"
            
            Public Shared DFechareg As String = "dFechareg"
            
            Public Shared CDetalles As String = "cDetalles"
            
            Public Shared NCodAlmacen As String = "nCodAlmacen"
            
            Public Shared NPrecioCompra As String = "nPrecioCompra"
            
            Public Shared NStockAnteriorEnvase As String = "nStockAnteriorEnvase"
            
            Public Shared NStockActualEnvase As String = "nStockActualEnvase"
            
            Public Shared NStockAnteriorBonificacion As String = "nStockAnteriorBonificacion"
            
            Public Shared NStockActualBonificacion As String = "nStockActualBonificacion"
            
            Public Shared NStockAnteriorReintegro As String = "nStockAnteriorReintegro"
            
            Public Shared NStockActualReintegro As String = "nStockActualReintegro"
            
            Public Shared CObservacion As String = "cObservacion"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
	    End Structure
	    #End Region
    End Class
End Namespace
