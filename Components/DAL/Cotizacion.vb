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
	''' Strongly-typed collection for the Cotizacion class.
	''' </summary>
	<Serializable> _
	Public Partial Class CotizacionCollection 
	Inherits ActiveList(Of Cotizacion, CotizacionCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As CotizacionCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Cotizacion = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Cotizacion table.
	''' </summary>
	<Serializable> _
	Public Partial Class Cotizacion 
	Inherits ActiveRecord(Of Cotizacion)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Cotizacion", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodCotizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCotizacion.ColumnName = "nCodCotizacion"
                colvarNCodCotizacion.DataType = DbType.Int32
                colvarNCodCotizacion.MaxLength = 0
                colvarNCodCotizacion.AutoIncrement = false
                colvarNCodCotizacion.IsNullable = false
                colvarNCodCotizacion.IsPrimaryKey = true
                colvarNCodCotizacion.IsForeignKey = false
                colvarNCodCotizacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCotizacion)
                
                Dim colvarNCodSucursalId As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodSucursalId.ColumnName = "nCodSucursalId"
                colvarNCodSucursalId.DataType = DbType.Int32
                colvarNCodSucursalId.MaxLength = 0
                colvarNCodSucursalId.AutoIncrement = false
                colvarNCodSucursalId.IsNullable = false
                colvarNCodSucursalId.IsPrimaryKey = false
                colvarNCodSucursalId.IsForeignKey = false
                colvarNCodSucursalId.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodSucursalId)
                
                Dim colvarNCodUsuario As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodUsuario.ColumnName = "nCodUsuario"
                colvarNCodUsuario.DataType = DbType.Int32
                colvarNCodUsuario.MaxLength = 0
                colvarNCodUsuario.AutoIncrement = false
                colvarNCodUsuario.IsNullable = false
                colvarNCodUsuario.IsPrimaryKey = false
                colvarNCodUsuario.IsForeignKey = false
                colvarNCodUsuario.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodUsuario)
                
                Dim colvarDFechaLimite As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaLimite.ColumnName = "dFechaLimite"
                colvarDFechaLimite.DataType = DbType.DateTime
                colvarDFechaLimite.MaxLength = 0
                colvarDFechaLimite.AutoIncrement = false
                colvarDFechaLimite.IsNullable = false
                colvarDFechaLimite.IsPrimaryKey = false
                colvarDFechaLimite.IsForeignKey = false
                colvarDFechaLimite.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaLimite)
                
                Dim colvarDFechaCotizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaCotizacion.ColumnName = "dFechaCotizacion"
                colvarDFechaCotizacion.DataType = DbType.DateTime
                colvarDFechaCotizacion.MaxLength = 0
                colvarDFechaCotizacion.AutoIncrement = false
                colvarDFechaCotizacion.IsNullable = false
                colvarDFechaCotizacion.IsPrimaryKey = false
                colvarDFechaCotizacion.IsForeignKey = false
                colvarDFechaCotizacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaCotizacion)
                
                Dim colvarDFechaEjecucion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaEjecucion.ColumnName = "dFechaEjecucion"
                colvarDFechaEjecucion.DataType = DbType.DateTime
                colvarDFechaEjecucion.MaxLength = 0
                colvarDFechaEjecucion.AutoIncrement = false
                colvarDFechaEjecucion.IsNullable = true
                colvarDFechaEjecucion.IsPrimaryKey = false
                colvarDFechaEjecucion.IsForeignKey = false
                colvarDFechaEjecucion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaEjecucion)
                
                Dim colvarDFechaParcial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaParcial.ColumnName = "dFechaParcial"
                colvarDFechaParcial.DataType = DbType.DateTime
                colvarDFechaParcial.MaxLength = 0
                colvarDFechaParcial.AutoIncrement = false
                colvarDFechaParcial.IsNullable = true
                colvarDFechaParcial.IsPrimaryKey = false
                colvarDFechaParcial.IsForeignKey = false
                colvarDFechaParcial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaParcial)
                
                Dim colvarCCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCliente.ColumnName = "cCliente"
                colvarCCliente.DataType = DbType.AnsiString
                colvarCCliente.MaxLength = 50
                colvarCCliente.AutoIncrement = false
                colvarCCliente.IsNullable = false
                colvarCCliente.IsPrimaryKey = false
                colvarCCliente.IsForeignKey = false
                colvarCCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCliente)
                
                Dim colvarNNumeroCotizacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNNumeroCotizacion.ColumnName = "nNumeroCotizacion"
                colvarNNumeroCotizacion.DataType = DbType.Int32
                colvarNNumeroCotizacion.MaxLength = 0
                colvarNNumeroCotizacion.AutoIncrement = false
                colvarNNumeroCotizacion.IsNullable = false
                colvarNNumeroCotizacion.IsPrimaryKey = false
                colvarNNumeroCotizacion.IsForeignKey = false
                colvarNNumeroCotizacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNNumeroCotizacion)
                
                Dim colvarBEjecutada As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEjecutada.ColumnName = "bEjecutada"
                colvarBEjecutada.DataType = DbType.Boolean
                colvarBEjecutada.MaxLength = 0
                colvarBEjecutada.AutoIncrement = false
                colvarBEjecutada.IsNullable = false
                colvarBEjecutada.IsPrimaryKey = false
                colvarBEjecutada.IsForeignKey = false
                colvarBEjecutada.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEjecutada)
                
                Dim colvarBParcialmente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBParcialmente.ColumnName = "bParcialmente"
                colvarBParcialmente.DataType = DbType.Boolean
                colvarBParcialmente.MaxLength = 0
                colvarBParcialmente.AutoIncrement = false
                colvarBParcialmente.IsNullable = true
                colvarBParcialmente.IsPrimaryKey = false
                colvarBParcialmente.IsForeignKey = false
                colvarBParcialmente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBParcialmente)
                
                Dim colvarCCodCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCCodCliente.ColumnName = "cCodCliente"
                colvarCCodCliente.DataType = DbType.Int32
                colvarCCodCliente.MaxLength = 0
                colvarCCodCliente.AutoIncrement = false
                colvarCCodCliente.IsNullable = false
                colvarCCodCliente.IsPrimaryKey = false
                colvarCCodCliente.IsForeignKey = false
                colvarCCodCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCCodCliente)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Cotizacion",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodCotizacion")> _
        Public Property NCodCotizacion As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCotizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCotizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodSucursalId")> _
        Public Property NCodSucursalId As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodSucursalId)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodSucursalId, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodUsuario")> _
        Public Property NCodUsuario As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodUsuario)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodUsuario, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaLimite")> _
        Public Property DFechaLimite As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaLimite)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaLimite, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaCotizacion")> _
        Public Property DFechaCotizacion As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaCotizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaCotizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaEjecucion")> _
        Public Property DFechaEjecucion As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaEjecucion)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaEjecucion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaParcial")> _
        Public Property DFechaParcial As Nullable(Of DateTime) 
			Get
				Return GetColumnValue(Of Nullable(Of DateTime))(Columns.DFechaParcial)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaParcial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCliente")> _
        Public Property CCliente As String 
			Get
				Return GetColumnValue(Of String)(Columns.CCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.CCliente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NNumeroCotizacion")> _
        Public Property NNumeroCotizacion As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NNumeroCotizacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NNumeroCotizacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEjecutada")> _
        Public Property BEjecutada As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEjecutada)
			End Get
		    
			Set
				SetColumnValue(Columns.BEjecutada, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BParcialmente")> _
        Public Property BParcialmente As Nullable(Of Boolean) 
			Get
				Return GetColumnValue(Of Nullable(Of Boolean))(Columns.BParcialmente)
			End Get
		    
			Set
				SetColumnValue(Columns.BParcialmente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CCodCliente")> _
        Public Property CCodCliente As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.CCodCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.CCodCliente, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function CotizacionDetalleRecords() As EjSuite.CotizacionDetalleCollection 
	
				Return New EjSuite.CotizacionDetalleCollection().Where(CotizacionDetalle.Columns.NCodCotizacion, NCodCotizacion).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodCotizacion As Integer,ByVal varNCodSucursalId As Integer,ByVal varNCodUsuario As Integer,ByVal varDFechaLimite As DateTime,ByVal varDFechaCotizacion As DateTime,ByVal varDFechaEjecucion As Nullable(Of DateTime),ByVal varDFechaParcial As Nullable(Of DateTime),ByVal varCCliente As String,ByVal varNNumeroCotizacion As Integer,ByVal varBEjecutada As Boolean,ByVal varBParcialmente As Nullable(Of Boolean),ByVal varCCodCliente As Integer)
			Dim item As Cotizacion = New Cotizacion()
			
            item.NCodCotizacion = varNCodCotizacion
            
            item.NCodSucursalId = varNCodSucursalId
            
            item.NCodUsuario = varNCodUsuario
            
            item.DFechaLimite = varDFechaLimite
            
            item.DFechaCotizacion = varDFechaCotizacion
            
            item.DFechaEjecucion = varDFechaEjecucion
            
            item.DFechaParcial = varDFechaParcial
            
            item.CCliente = varCCliente
            
            item.NNumeroCotizacion = varNNumeroCotizacion
            
            item.BEjecutada = varBEjecutada
            
            item.BParcialmente = varBParcialmente
            
            item.CCodCliente = varCCodCliente
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodCotizacion As Integer,ByVal varNCodSucursalId As Integer,ByVal varNCodUsuario As Integer,ByVal varDFechaLimite As DateTime,ByVal varDFechaCotizacion As DateTime,ByVal varDFechaEjecucion As Nullable(Of DateTime),ByVal varDFechaParcial As Nullable(Of DateTime),ByVal varCCliente As String,ByVal varNNumeroCotizacion As Integer,ByVal varBEjecutada As Boolean,ByVal varBParcialmente As Nullable(Of Boolean),ByVal varCCodCliente As Integer)
			Dim item As Cotizacion = New Cotizacion()
		    
                item.NCodCotizacion = varNCodCotizacion
				
                item.NCodSucursalId = varNCodSucursalId
				
                item.NCodUsuario = varNCodUsuario
				
                item.DFechaLimite = varDFechaLimite
				
                item.DFechaCotizacion = varDFechaCotizacion
				
                item.DFechaEjecucion = varDFechaEjecucion
				
                item.DFechaParcial = varDFechaParcial
				
                item.CCliente = varCCliente
				
                item.NNumeroCotizacion = varNNumeroCotizacion
				
                item.BEjecutada = varBEjecutada
				
                item.BParcialmente = varBParcialmente
				
                item.CCodCliente = varCCodCliente
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodCotizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodSucursalIdColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodUsuarioColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaLimiteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaCotizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaEjecucionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaParcialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NNumeroCotizacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEjecutadaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BParcialmenteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodCotizacion As String = "nCodCotizacion"
            
            Public Shared NCodSucursalId As String = "nCodSucursalId"
            
            Public Shared NCodUsuario As String = "nCodUsuario"
            
            Public Shared DFechaLimite As String = "dFechaLimite"
            
            Public Shared DFechaCotizacion As String = "dFechaCotizacion"
            
            Public Shared DFechaEjecucion As String = "dFechaEjecucion"
            
            Public Shared DFechaParcial As String = "dFechaParcial"
            
            Public Shared CCliente As String = "cCliente"
            
            Public Shared NNumeroCotizacion As String = "nNumeroCotizacion"
            
            Public Shared BEjecutada As String = "bEjecutada"
            
            Public Shared BParcialmente As String = "bParcialmente"
            
            Public Shared CCodCliente As String = "cCodCliente"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        Public Sub SetPKValues()
        End Sub
        #End Region
        
        #Region "Deep Save"
		
        Public Sub DeepSave()
            Save()
            
        End Sub
        #End Region
        
	End Class
End Namespace
