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
	''' Strongly-typed collection for the InformeCobranza class.
	''' </summary>
	<Serializable> _
	Public Partial Class InformeCobranzaCollection 
	Inherits ActiveList(Of InformeCobranza, InformeCobranzaCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As InformeCobranzaCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As InformeCobranza = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_InformeCobranzas table.
	''' </summary>
	<Serializable> _
	Public Partial Class InformeCobranza 
	Inherits ActiveRecord(Of InformeCobranza)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_InformeCobranzas", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodCliente As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodCliente.ColumnName = "nCodCliente"
                colvarNCodCliente.DataType = DbType.Int32
                colvarNCodCliente.MaxLength = 0
                colvarNCodCliente.AutoIncrement = false
                colvarNCodCliente.IsNullable = false
                colvarNCodCliente.IsPrimaryKey = false
                colvarNCodCliente.IsForeignKey = false
                colvarNCodCliente.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodCliente)
                
                Dim colvarDFecha As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFecha.ColumnName = "dFecha"
                colvarDFecha.DataType = DbType.AnsiString
                colvarDFecha.MaxLength = 0
                colvarDFecha.AutoIncrement = false
                colvarDFecha.IsNullable = false
                colvarDFecha.IsPrimaryKey = false
                colvarDFecha.IsForeignKey = false
                colvarDFecha.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFecha)
                
                Dim colvarCVendedor As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCVendedor.ColumnName = "cVendedor"
                colvarCVendedor.DataType = DbType.AnsiString
                colvarCVendedor.MaxLength = 60
                colvarCVendedor.AutoIncrement = false
                colvarCVendedor.IsNullable = false
                colvarCVendedor.IsPrimaryKey = false
                colvarCVendedor.IsForeignKey = false
                colvarCVendedor.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCVendedor)
                
                Dim colvarCObservaciones As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCObservaciones.ColumnName = "cObservaciones"
                colvarCObservaciones.DataType = DbType.AnsiString
                colvarCObservaciones.MaxLength = 60
                colvarCObservaciones.AutoIncrement = false
                colvarCObservaciones.IsNullable = false
                colvarCObservaciones.IsPrimaryKey = false
                colvarCObservaciones.IsForeignKey = false
                colvarCObservaciones.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCObservaciones)
                
                Dim colvarNCodigo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodigo.ColumnName = "nCodigo"
                colvarNCodigo.DataType = DbType.Int32
                colvarNCodigo.MaxLength = 0
                colvarNCodigo.AutoIncrement = false
                colvarNCodigo.IsNullable = false
                colvarNCodigo.IsPrimaryKey = false
                colvarNCodigo.IsForeignKey = false
                colvarNCodigo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodigo)
                
                Dim colvarNMonto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMonto.ColumnName = "nMonto"
                colvarNMonto.DataType = DbType.Double
                colvarNMonto.MaxLength = 0
                colvarNMonto.AutoIncrement = false
                colvarNMonto.IsNullable = false
                colvarNMonto.IsPrimaryKey = false
                colvarNMonto.IsForeignKey = false
                colvarNMonto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMonto)
                
                Dim colvarNEfectivo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEfectivo.ColumnName = "nEfectivo"
                colvarNEfectivo.DataType = DbType.Double
                colvarNEfectivo.MaxLength = 0
                colvarNEfectivo.AutoIncrement = false
                colvarNEfectivo.IsNullable = false
                colvarNEfectivo.IsPrimaryKey = false
                colvarNEfectivo.IsForeignKey = false
                colvarNEfectivo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEfectivo)
                
                Dim colvarNCheque As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCheque.ColumnName = "nCheque"
                colvarNCheque.DataType = DbType.Double
                colvarNCheque.MaxLength = 0
                colvarNCheque.AutoIncrement = false
                colvarNCheque.IsNullable = false
                colvarNCheque.IsPrimaryKey = false
                colvarNCheque.IsForeignKey = false
                colvarNCheque.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCheque)
                
                Dim colvarNReciboOficial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNReciboOficial.ColumnName = "nReciboOficial"
                colvarNReciboOficial.DataType = DbType.Int32
                colvarNReciboOficial.MaxLength = 0
                colvarNReciboOficial.AutoIncrement = false
                colvarNReciboOficial.IsNullable = false
                colvarNReciboOficial.IsPrimaryKey = false
                colvarNReciboOficial.IsForeignKey = false
                colvarNReciboOficial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNReciboOficial)
                
                Dim colvarNInformeCobranza As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNInformeCobranza.ColumnName = "nInformeCobranza"
                colvarNInformeCobranza.DataType = DbType.Int32
                colvarNInformeCobranza.MaxLength = 0
                colvarNInformeCobranza.AutoIncrement = false
                colvarNInformeCobranza.IsNullable = false
                colvarNInformeCobranza.IsPrimaryKey = true
                colvarNInformeCobranza.IsForeignKey = false
                colvarNInformeCobranza.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNInformeCobranza)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_InformeCobranzas",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodCliente")> _
        Public Property NCodCliente As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodCliente)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodCliente, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFecha")> _
        Public Property DFecha As String 
			Get
				Return GetColumnValue(Of String)(Columns.DFecha)
			End Get
		    
			Set
				SetColumnValue(Columns.DFecha, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CVendedor")> _
        Public Property CVendedor As String 
			Get
				Return GetColumnValue(Of String)(Columns.CVendedor)
			End Get
		    
			Set
				SetColumnValue(Columns.CVendedor, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CObservaciones")> _
        Public Property CObservaciones As String 
			Get
				Return GetColumnValue(Of String)(Columns.CObservaciones)
			End Get
		    
			Set
				SetColumnValue(Columns.CObservaciones, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodigo")> _
        Public Property NCodigo As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodigo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodigo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NMonto")> _
        Public Property NMonto As Double 
			Get
				Return GetColumnValue(Of Double)(Columns.NMonto)
			End Get
		    
			Set
				SetColumnValue(Columns.NMonto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEfectivo")> _
        Public Property NEfectivo As Double 
			Get
				Return GetColumnValue(Of Double)(Columns.NEfectivo)
			End Get
		    
			Set
				SetColumnValue(Columns.NEfectivo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCheque")> _
        Public Property NCheque As Double 
			Get
				Return GetColumnValue(Of Double)(Columns.NCheque)
			End Get
		    
			Set
				SetColumnValue(Columns.NCheque, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NReciboOficial")> _
        Public Property NReciboOficial As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NReciboOficial)
			End Get
		    
			Set
				SetColumnValue(Columns.NReciboOficial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NInformeCobranza")> _
        Public Property NInformeCobranza As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NInformeCobranza)
			End Get
		    
			Set
				SetColumnValue(Columns.NInformeCobranza, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodCliente As Integer,ByVal varDFecha As String,ByVal varCVendedor As String,ByVal varCObservaciones As String,ByVal varNCodigo As Integer,ByVal varNMonto As Double,ByVal varNEfectivo As Double,ByVal varNCheque As Double,ByVal varNReciboOficial As Integer,ByVal varNInformeCobranza As Integer)
			Dim item As InformeCobranza = New InformeCobranza()
			
            item.NCodCliente = varNCodCliente
            
            item.DFecha = varDFecha
            
            item.CVendedor = varCVendedor
            
            item.CObservaciones = varCObservaciones
            
            item.NCodigo = varNCodigo
            
            item.NMonto = varNMonto
            
            item.NEfectivo = varNEfectivo
            
            item.NCheque = varNCheque
            
            item.NReciboOficial = varNReciboOficial
            
            item.NInformeCobranza = varNInformeCobranza
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodCliente As Integer,ByVal varDFecha As String,ByVal varCVendedor As String,ByVal varCObservaciones As String,ByVal varNCodigo As Integer,ByVal varNMonto As Double,ByVal varNEfectivo As Double,ByVal varNCheque As Double,ByVal varNReciboOficial As Integer,ByVal varNInformeCobranza As Integer)
			Dim item As InformeCobranza = New InformeCobranza()
		    
                item.NCodCliente = varNCodCliente
				
                item.DFecha = varDFecha
				
                item.CVendedor = varCVendedor
				
                item.CObservaciones = varCObservaciones
				
                item.NCodigo = varNCodigo
				
                item.NMonto = varNMonto
				
                item.NEfectivo = varNEfectivo
				
                item.NCheque = varNCheque
				
                item.NReciboOficial = varNReciboOficial
				
                item.NInformeCobranza = varNInformeCobranza
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodClienteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CVendedorColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CObservacionesColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodigoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NMontoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEfectivoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NChequeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NReciboOficialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NInformeCobranzaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodCliente As String = "nCodCliente"
            
            Public Shared DFecha As String = "dFecha"
            
            Public Shared CVendedor As String = "cVendedor"
            
            Public Shared CObservaciones As String = "cObservaciones"
            
            Public Shared NCodigo As String = "nCodigo"
            
            Public Shared NMonto As String = "nMonto"
            
            Public Shared NEfectivo As String = "nEfectivo"
            
            Public Shared NCheque As String = "nCheque"
            
            Public Shared NReciboOficial As String = "nReciboOficial"
            
            Public Shared NInformeCobranza As String = "nInformeCobranza"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
