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
	''' Strongly-typed collection for the ErrorX class.
	''' </summary>
	<Serializable> _
	Public Partial Class ErrorXCollection 
	Inherits ActiveList(Of ErrorX, ErrorXCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ErrorXCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As ErrorX = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Error table.
	''' </summary>
	<Serializable> _
	Public Partial Class ErrorX 
	Inherits ActiveRecord(Of ErrorX)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Error", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodError As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodError.ColumnName = "nCodError"
                colvarNCodError.DataType = DbType.Int32
                colvarNCodError.MaxLength = 0
                colvarNCodError.AutoIncrement = false
                colvarNCodError.IsNullable = false
                colvarNCodError.IsPrimaryKey = true
                colvarNCodError.IsForeignKey = false
                colvarNCodError.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodError)
                
                Dim colvarNNumero As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNNumero.ColumnName = "nNumero"
                colvarNNumero.DataType = DbType.Int32
                colvarNNumero.MaxLength = 0
                colvarNNumero.AutoIncrement = false
                colvarNNumero.IsNullable = false
                colvarNNumero.IsPrimaryKey = false
                colvarNNumero.IsForeignKey = false
                colvarNNumero.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNNumero)
                
                Dim colvarNGravedad As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNGravedad.ColumnName = "nGravedad"
                colvarNGravedad.DataType = DbType.Int32
                colvarNGravedad.MaxLength = 0
                colvarNGravedad.AutoIncrement = false
                colvarNGravedad.IsNullable = false
                colvarNGravedad.IsPrimaryKey = false
                colvarNGravedad.IsForeignKey = false
                colvarNGravedad.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNGravedad)
                
                Dim colvarNEstado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEstado.ColumnName = "nEstado"
                colvarNEstado.DataType = DbType.Int32
                colvarNEstado.MaxLength = 0
                colvarNEstado.AutoIncrement = false
                colvarNEstado.IsNullable = false
                colvarNEstado.IsPrimaryKey = false
                colvarNEstado.IsForeignKey = false
                colvarNEstado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEstado)
                
                Dim colvarNLinea As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNLinea.ColumnName = "nLinea"
                colvarNLinea.DataType = DbType.Int32
                colvarNLinea.MaxLength = 0
                colvarNLinea.AutoIncrement = false
                colvarNLinea.IsNullable = false
                colvarNLinea.IsPrimaryKey = false
                colvarNLinea.IsForeignKey = false
                colvarNLinea.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNLinea)
                
                Dim colvarCProcedimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCProcedimiento.ColumnName = "cProcedimiento"
                colvarCProcedimiento.DataType = DbType.AnsiString
                colvarCProcedimiento.MaxLength = 500
                colvarCProcedimiento.AutoIncrement = false
                colvarCProcedimiento.IsNullable = false
                colvarCProcedimiento.IsPrimaryKey = false
                colvarCProcedimiento.IsForeignKey = false
                colvarCProcedimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCProcedimiento)
                
                Dim colvarCMensaje As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCMensaje.ColumnName = "cMensaje"
                colvarCMensaje.DataType = DbType.AnsiString
                colvarCMensaje.MaxLength = 8000
                colvarCMensaje.AutoIncrement = false
                colvarCMensaje.IsNullable = false
                colvarCMensaje.IsPrimaryKey = false
                colvarCMensaje.IsForeignKey = false
                colvarCMensaje.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCMensaje)
                
                Dim colvarDFecha As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFecha.ColumnName = "dFecha"
                colvarDFecha.DataType = DbType.DateTime
                colvarDFecha.MaxLength = 0
                colvarDFecha.AutoIncrement = false
                colvarDFecha.IsNullable = true
                colvarDFecha.IsPrimaryKey = false
                colvarDFecha.IsForeignKey = false
                colvarDFecha.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFecha)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Error",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodError")> _
        Public Property NCodError As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodError)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodError, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NNumero")> _
        Public Property NNumero As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NNumero)
			End Get
		    
			Set
				SetColumnValue(Columns.NNumero, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NGravedad")> _
        Public Property NGravedad As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NGravedad)
			End Get
		    
			Set
				SetColumnValue(Columns.NGravedad, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEstado")> _
        Public Property NEstado As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NEstado)
			End Get
		    
			Set
				SetColumnValue(Columns.NEstado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NLinea")> _
        Public Property NLinea As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NLinea)
			End Get
		    
			Set
				SetColumnValue(Columns.NLinea, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CProcedimiento")> _
        Public Property CProcedimiento As String 
			Get
				Return GetColumnValue(Of String)(Columns.CProcedimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.CProcedimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CMensaje")> _
        Public Property CMensaje As String 
			Get
				Return GetColumnValue(Of String)(Columns.CMensaje)
			End Get
		    
			Set
				SetColumnValue(Columns.CMensaje, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFecha")> _
        Public Property DFecha As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFecha)
			End Get
		    
			Set
				SetColumnValue(Columns.DFecha, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodError As Integer,ByVal varNNumero As Integer,ByVal varNGravedad As Integer,ByVal varNEstado As Integer,ByVal varNLinea As Integer,ByVal varCProcedimiento As String,ByVal varCMensaje As String,ByVal varDFecha As Nullable(Of DateTime))
			Dim item As ErrorX = New ErrorX()
			
            item.NCodError = varNCodError
            
            item.NNumero = varNNumero
            
            item.NGravedad = varNGravedad
            
            item.NEstado = varNEstado
            
            item.NLinea = varNLinea
            
            item.CProcedimiento = varCProcedimiento
            
            item.CMensaje = varCMensaje
            
            item.DFecha = varDFecha
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodError As Integer,ByVal varNNumero As Integer,ByVal varNGravedad As Integer,ByVal varNEstado As Integer,ByVal varNLinea As Integer,ByVal varCProcedimiento As String,ByVal varCMensaje As String,ByVal varDFecha As Nullable(Of DateTime))
			Dim item As ErrorX = New ErrorX()
		    
                item.NCodError = varNCodError
				
                item.NNumero = varNNumero
				
                item.NGravedad = varNGravedad
				
                item.NEstado = varNEstado
				
                item.NLinea = varNLinea
				
                item.CProcedimiento = varCProcedimiento
				
                item.CMensaje = varCMensaje
				
                item.DFecha = varDFecha
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodErrorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NNumeroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NGravedadColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEstadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NLineaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CProcedimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CMensajeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodError As String = "nCodError"
            
            Public Shared NNumero As String = "nNumero"
            
            Public Shared NGravedad As String = "nGravedad"
            
            Public Shared NEstado As String = "nEstado"
            
            Public Shared NLinea As String = "nLinea"
            
            Public Shared CProcedimiento As String = "cProcedimiento"
            
            Public Shared CMensaje As String = "cMensaje"
            
            Public Shared DFecha As String = "dFecha"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
