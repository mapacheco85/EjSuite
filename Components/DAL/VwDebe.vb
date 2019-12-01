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
    ''' Strongly-typed collection for the VwDebe class.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwDebeCollection 
    Inherits ReadOnlyList(Of VwDebe, VwDebeCollection)       
        Public Sub New()
        End Sub
    End Class
    ''' <summary>
    ''' This is  Read-only wrapper class for the EJS_VwDebe view.
    ''' </summary>
    <Serializable()> _
    Public Partial Class VwDebe 
    Inherits ReadOnlyRecord(Of VwDebe)
    
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_VwDebe", TableType.View, DataService.GetInstance("DALEjSuite"))
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
                
                Dim colvarDebe As New TableSchema.TableColumn(schema)
                colvarDebe.ColumnName = "debe"
                colvarDebe.DataType = DbType.Decimal
                colvarDebe.MaxLength = 0
                colvarDebe.AutoIncrement = False
                colvarDebe.IsNullable = true
                colvarDebe.IsPrimaryKey = False
                colvarDebe.IsForeignKey = False
                colvarDebe.IsReadOnly = false
                 
                schema.Columns.Add(colvarDebe)
                
                BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_VwDebe",schema)
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
	      
        <XmlAttribute("Debe")> _
        Public Property Debe() As Nullable(Of Decimal) 
		    Get
			    Return GetColumnValue(Of Nullable(Of Decimal))("debe")
			End Get
            Set(ByVal value As Nullable(Of Decimal))
			    SetColumnValue("debe", value)
            End Set
        End Property
	    
	    #End Region
    
	    #Region "Columns Struct"
	    Public Structure Columns
			Dim x as Integer
	        
            Public Shared NCodFactura As String = "nCodFactura"
            
            Public Shared Debe As String = "debe"
            
	    End Structure
	    #End Region
    End Class
End Namespace
