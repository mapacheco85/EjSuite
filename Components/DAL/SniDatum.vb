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
	''' Strongly-typed collection for the SniDatum class.
	''' </summary>
	<Serializable> _
	Public Partial Class SniDatumCollection 
	Inherits ActiveList(Of SniDatum, SniDatumCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As SniDatumCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As SniDatum = Me(i)
				For Each w As SubSonic.Where In Me.wheres
					Dim remove As Boolean = False
					Dim pi As System.Reflection.PropertyInfo = o.GetType().GetProperty(w.ColumnName)
					If pi.CanRead Then
						Dim val As Object = pi.GetValue(o, Nothing)
						Select Case w.Comparison
							Case SubSonic.Comparison.Equals
								If (Not val.Equals(w.ParameterValue)) Then
									remove = True
								End If
						End Select
					End If
					If remove Then
						Me.Remove(o)
						Exit For
					End If
				Next w
			Next i
			Return Me
		End Function
		
		
	End Class
	''' <summary>
	''' This is an ActiveRecord class which wraps the EJS_SniData table.
	''' </summary>
	<Serializable> _
	Public Partial Class SniDatum 
	Inherits ActiveRecord(Of SniDatum)
		#Region ".ctors and Default Settings"
		
		Public Sub New()
			SetSQLProps()
			InitSetDefaults()
			MarkNew()
		End Sub
		
		Public Sub New(ByVal useDatabaseDefaults As Boolean)
			SetSQLProps()
			If useDatabaseDefaults = True Then
				ForceDefaults()
			End If
			MarkNew()
		End Sub
		Private Sub InitSetDefaults()
			SetDefaults()
		End Sub
        
		Public Sub New(ByVal keyID As Object)
			SetSQLProps()
			InitSetDefaults()
			LoadByKey(keyID)
		End Sub
		Public Sub New(ByVal columnName As String, ByVal columnValue As Object)
			SetSQLProps()
			InitSetDefaults()
			LoadByParam(columnName,columnValue)
		End Sub
		
        
		Protected Shared Sub SetSQLProps()
			GetTableSchema()
		End Sub
		#End Region
		
		#Region "Schema and Query Accessor"
		
		Public Shared ReadOnly Property Schema() As TableSchema.Table
			Get
				If BaseSchema Is Nothing Then
					SetSQLProps()
				End If
				Return BaseSchema
			End Get
		End Property
		Private Shared Sub GetTableSchema()
			If (Not IsSchemaInitialized) Then
				'Schema declaration
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_SniData", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodSNI As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSNI.ColumnName = "nCodSNI"
                colvarNCodSNI.DataType = DbType.Int32
                colvarNCodSNI.MaxLength = 0
                colvarNCodSNI.AutoIncrement = false
                colvarNCodSNI.IsNullable = false
                colvarNCodSNI.IsPrimaryKey = true
                colvarNCodSNI.IsForeignKey = false
                colvarNCodSNI.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodSNI)
                
                Dim colvarCLlave As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCLlave.ColumnName = "cLlave"
                colvarCLlave.DataType = DbType.AnsiString
                colvarCLlave.MaxLength = 200
                colvarCLlave.AutoIncrement = false
                colvarCLlave.IsNullable = false
                colvarCLlave.IsPrimaryKey = false
                colvarCLlave.IsForeignKey = false
                colvarCLlave.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCLlave)
                
                Dim colvarCAutorizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCAutorizacion.ColumnName = "cAutorizacion"
                colvarCAutorizacion.DataType = DbType.AnsiString
                colvarCAutorizacion.MaxLength = 20
                colvarCAutorizacion.AutoIncrement = false
                colvarCAutorizacion.IsNullable = false
                colvarCAutorizacion.IsPrimaryKey = false
                colvarCAutorizacion.IsForeignKey = false
                colvarCAutorizacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCAutorizacion)
                
                Dim colvarDFechaInicio As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaInicio.ColumnName = "dFechaInicio"
                colvarDFechaInicio.DataType = DbType.DateTime
                colvarDFechaInicio.MaxLength = 0
                colvarDFechaInicio.AutoIncrement = false
                colvarDFechaInicio.IsNullable = false
                colvarDFechaInicio.IsPrimaryKey = false
                colvarDFechaInicio.IsForeignKey = false
                colvarDFechaInicio.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaInicio)
                
                Dim colvarDFechaFinal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaFinal.ColumnName = "dFechaFinal"
                colvarDFechaFinal.DataType = DbType.DateTime
                colvarDFechaFinal.MaxLength = 0
                colvarDFechaFinal.AutoIncrement = false
                colvarDFechaFinal.IsNullable = false
                colvarDFechaFinal.IsPrimaryKey = false
                colvarDFechaFinal.IsForeignKey = false
                colvarDFechaFinal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaFinal)
                
                Dim colvarNNroFacturaInicial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNNroFacturaInicial.ColumnName = "nNroFacturaInicial"
                colvarNNroFacturaInicial.DataType = DbType.Int32
                colvarNNroFacturaInicial.MaxLength = 0
                colvarNNroFacturaInicial.AutoIncrement = false
                colvarNNroFacturaInicial.IsNullable = false
                colvarNNroFacturaInicial.IsPrimaryKey = false
                colvarNNroFacturaInicial.IsForeignKey = false
                colvarNNroFacturaInicial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNNroFacturaInicial)
                
                Dim colvarCLeyenda453 As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCLeyenda453.ColumnName = "cLeyenda453"
                colvarCLeyenda453.DataType = DbType.AnsiString
                colvarCLeyenda453.MaxLength = -1
                colvarCLeyenda453.AutoIncrement = false
                colvarCLeyenda453.IsNullable = false
                colvarCLeyenda453.IsPrimaryKey = false
                colvarCLeyenda453.IsForeignKey = false
                colvarCLeyenda453.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCLeyenda453)
                
                Dim colvarBUsaQR As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBUsaQR.ColumnName = "bUsaQR"
                colvarBUsaQR.DataType = DbType.Boolean
                colvarBUsaQR.MaxLength = 0
                colvarBUsaQR.AutoIncrement = false
                colvarBUsaQR.IsNullable = false
                colvarBUsaQR.IsPrimaryKey = false
                colvarBUsaQR.IsForeignKey = false
                colvarBUsaQR.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBUsaQR)
                
                Dim colvarBVigente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBVigente.ColumnName = "bVigente"
                colvarBVigente.DataType = DbType.Boolean
                colvarBVigente.MaxLength = 0
                colvarBVigente.AutoIncrement = false
                colvarBVigente.IsNullable = false
                colvarBVigente.IsPrimaryKey = false
                colvarBVigente.IsForeignKey = false
                colvarBVigente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBVigente)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_SniData",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodSNI")> _
        Public Property NCodSNI As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodSNI)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSNI, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CLlave")> _
        Public Property CLlave As String 
			Get
				Return GetColumnValue(Of String)(Columns.CLlave)
			End Get
		    
			Set
				SetColumnValue(Columns.CLlave, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CAutorizacion")> _
        Public Property CAutorizacion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CAutorizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.CAutorizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaInicio")> _
        Public Property DFechaInicio As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaInicio)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaInicio, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaFinal")> _
        Public Property DFechaFinal As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaFinal)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaFinal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NNroFacturaInicial")> _
        Public Property NNroFacturaInicial As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NNroFacturaInicial)
			End Get
		    
			Set
				SetColumnValue(Columns.NNroFacturaInicial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CLeyenda453")> _
        Public Property CLeyenda453 As String 
			Get
				Return GetColumnValue(Of String)(Columns.CLeyenda453)
			End Get
		    
			Set
				SetColumnValue(Columns.CLeyenda453, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BUsaQR")> _
        Public Property BUsaQR As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BUsaQR)
			End Get
		    
			Set
				SetColumnValue(Columns.BUsaQR, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BVigente")> _
        Public Property BVigente As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BVigente)
			End Get
		    
			Set
				SetColumnValue(Columns.BVigente, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodSNI As Integer,ByVal varCLlave As String,ByVal varCAutorizacion As String,ByVal varDFechaInicio As DateTime,ByVal varDFechaFinal As DateTime,ByVal varNNroFacturaInicial As Integer,ByVal varCLeyenda453 As String,ByVal varBUsaQR As Boolean,ByVal varBVigente As Boolean)
			Dim item As SniDatum = New SniDatum()
			
            item.NCodSNI = varNCodSNI
            
            item.CLlave = varCLlave
            
            item.CAutorizacion = varCAutorizacion
            
            item.DFechaInicio = varDFechaInicio
            
            item.DFechaFinal = varDFechaFinal
            
            item.NNroFacturaInicial = varNNroFacturaInicial
            
            item.CLeyenda453 = varCLeyenda453
            
            item.BUsaQR = varBUsaQR
            
            item.BVigente = varBVigente
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodSNI As Integer,ByVal varCLlave As String,ByVal varCAutorizacion As String,ByVal varDFechaInicio As DateTime,ByVal varDFechaFinal As DateTime,ByVal varNNroFacturaInicial As Integer,ByVal varCLeyenda453 As String,ByVal varBUsaQR As Boolean,ByVal varBVigente As Boolean)
			Dim item As SniDatum = New SniDatum()
		    
                item.NCodSNI = varNCodSNI
				
                item.CLlave = varCLlave
				
                item.CAutorizacion = varCAutorizacion
				
                item.DFechaInicio = varDFechaInicio
				
                item.DFechaFinal = varDFechaFinal
				
                item.NNroFacturaInicial = varNNroFacturaInicial
				
                item.CLeyenda453 = varCLeyenda453
				
                item.BUsaQR = varBUsaQR
				
                item.BVigente = varBVigente
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodSNIColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CLlaveColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CAutorizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaInicioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaFinalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NNroFacturaInicialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CLeyenda453Column() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BUsaQRColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BVigenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodSNI As String = "nCodSNI"
            
            Public Shared CLlave As String = "cLlave"
            
            Public Shared CAutorizacion As String = "cAutorizacion"
            
            Public Shared DFechaInicio As String = "dFechaInicio"
            
            Public Shared DFechaFinal As String = "dFechaFinal"
            
            Public Shared NNroFacturaInicial As String = "nNroFacturaInicial"
            
            Public Shared CLeyenda453 As String = "cLeyenda453"
            
            Public Shared BUsaQR As String = "bUsaQR"
            
            Public Shared BVigente As String = "bVigente"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
