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
	''' Strongly-typed collection for the Objetivo class.
	''' </summary>
	<Serializable> _
	Public Partial Class ObjetivoCollection 
	Inherits ActiveList(Of Objetivo, ObjetivoCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As ObjetivoCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As Objetivo = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_Objetivo table.
	''' </summary>
	<Serializable> _
	Public Partial Class Objetivo 
	Inherits ActiveRecord(Of Objetivo)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_Objetivo", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodObjetivo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodObjetivo.ColumnName = "nCodObjetivo"
                colvarNCodObjetivo.DataType = DbType.Int32
                colvarNCodObjetivo.MaxLength = 0
                colvarNCodObjetivo.AutoIncrement = false
                colvarNCodObjetivo.IsNullable = false
                colvarNCodObjetivo.IsPrimaryKey = true
                colvarNCodObjetivo.IsForeignKey = false
                colvarNCodObjetivo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodObjetivo)
                
                Dim colvarDFechaAsignacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaAsignacion.ColumnName = "dFechaAsignacion"
                colvarDFechaAsignacion.DataType = DbType.DateTime
                colvarDFechaAsignacion.MaxLength = 0
                colvarDFechaAsignacion.AutoIncrement = false
                colvarDFechaAsignacion.IsNullable = false
                colvarDFechaAsignacion.IsPrimaryKey = false
                colvarDFechaAsignacion.IsForeignKey = false
                colvarDFechaAsignacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaAsignacion)
                
                Dim colvarNMesCumplimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNMesCumplimiento.ColumnName = "nMesCumplimiento"
                colvarNMesCumplimiento.DataType = DbType.Int32
                colvarNMesCumplimiento.MaxLength = 0
                colvarNMesCumplimiento.AutoIncrement = false
                colvarNMesCumplimiento.IsNullable = false
                colvarNMesCumplimiento.IsPrimaryKey = false
                colvarNMesCumplimiento.IsForeignKey = false
                colvarNMesCumplimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNMesCumplimiento)
                
                Dim colvarNGestionCumplimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNGestionCumplimiento.ColumnName = "nGestionCumplimiento"
                colvarNGestionCumplimiento.DataType = DbType.Int32
                colvarNGestionCumplimiento.MaxLength = 0
                colvarNGestionCumplimiento.AutoIncrement = false
                colvarNGestionCumplimiento.IsNullable = false
                colvarNGestionCumplimiento.IsPrimaryKey = false
                colvarNGestionCumplimiento.IsForeignKey = false
                colvarNGestionCumplimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNGestionCumplimiento)
                
                Dim colvarBEsProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsProducto.ColumnName = "bEsProducto"
                colvarBEsProducto.DataType = DbType.Boolean
                colvarBEsProducto.MaxLength = 0
                colvarBEsProducto.AutoIncrement = false
                colvarBEsProducto.IsNullable = false
                colvarBEsProducto.IsPrimaryKey = false
                colvarBEsProducto.IsForeignKey = false
                colvarBEsProducto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsProducto)
                
                Dim colvarBEsCupo As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsCupo.ColumnName = "bEsCupo"
                colvarBEsCupo.DataType = DbType.Boolean
                colvarBEsCupo.MaxLength = 0
                colvarBEsCupo.AutoIncrement = false
                colvarBEsCupo.IsNullable = false
                colvarBEsCupo.IsPrimaryKey = false
                colvarBEsCupo.IsForeignKey = false
                colvarBEsCupo.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsCupo)
                
                Dim colvarBEsVenta As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsVenta.ColumnName = "bEsVenta"
                colvarBEsVenta.DataType = DbType.Boolean
                colvarBEsVenta.MaxLength = 0
                colvarBEsVenta.AutoIncrement = false
                colvarBEsVenta.IsNullable = false
                colvarBEsVenta.IsPrimaryKey = false
                colvarBEsVenta.IsForeignKey = false
                colvarBEsVenta.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsVenta)
                
                Dim colvarBEsGerencial As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarBEsGerencial.ColumnName = "bEsGerencial"
                colvarBEsGerencial.DataType = DbType.Boolean
                colvarBEsGerencial.MaxLength = 0
                colvarBEsGerencial.AutoIncrement = false
                colvarBEsGerencial.IsNullable = false
                colvarBEsGerencial.IsPrimaryKey = false
                colvarBEsGerencial.IsForeignKey = false
                colvarBEsGerencial.IsReadOnly = false
                
                
                schema.Columns.Add(colvarBEsGerencial)
                
                Dim colvarNLimite1 As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNLimite1.ColumnName = "nLimite1"
                colvarNLimite1.DataType = DbType.Decimal
                colvarNLimite1.MaxLength = 0
                colvarNLimite1.AutoIncrement = false
                colvarNLimite1.IsNullable = false
                colvarNLimite1.IsPrimaryKey = false
                colvarNLimite1.IsForeignKey = false
                colvarNLimite1.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNLimite1)
                
                Dim colvarNLimite2 As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNLimite2.ColumnName = "nLimite2"
                colvarNLimite2.DataType = DbType.Decimal
                colvarNLimite2.MaxLength = 0
                colvarNLimite2.AutoIncrement = false
                colvarNLimite2.IsNullable = false
                colvarNLimite2.IsPrimaryKey = false
                colvarNLimite2.IsForeignKey = false
                colvarNLimite2.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNLimite2)
                
                Dim colvarDFechaCumplimiento As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechaCumplimiento.ColumnName = "dFechaCumplimiento"
                colvarDFechaCumplimiento.DataType = DbType.DateTime
                colvarDFechaCumplimiento.MaxLength = 0
                colvarDFechaCumplimiento.AutoIncrement = false
                colvarDFechaCumplimiento.IsNullable = false
                colvarDFechaCumplimiento.IsPrimaryKey = false
                colvarDFechaCumplimiento.IsForeignKey = false
                colvarDFechaCumplimiento.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechaCumplimiento)
                
                Dim colvarNCodEmpleado As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodEmpleado.ColumnName = "nCodEmpleado"
                colvarNCodEmpleado.DataType = DbType.Int32
                colvarNCodEmpleado.MaxLength = 0
                colvarNCodEmpleado.AutoIncrement = false
                colvarNCodEmpleado.IsNullable = false
                colvarNCodEmpleado.IsPrimaryKey = false
                colvarNCodEmpleado.IsForeignKey = false
                colvarNCodEmpleado.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodEmpleado)
                
                Dim colvarNPorcentaje As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPorcentaje.ColumnName = "nPorcentaje"
                colvarNPorcentaje.DataType = DbType.Decimal
                colvarNPorcentaje.MaxLength = 0
                colvarNPorcentaje.AutoIncrement = false
                colvarNPorcentaje.IsNullable = false
                colvarNPorcentaje.IsPrimaryKey = false
                colvarNPorcentaje.IsForeignKey = false
                colvarNPorcentaje.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPorcentaje)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_Objetivo",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodObjetivo")> _
        Public Property NCodObjetivo As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodObjetivo)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodObjetivo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaAsignacion")> _
        Public Property DFechaAsignacion As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaAsignacion)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaAsignacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NMesCumplimiento")> _
        Public Property NMesCumplimiento As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NMesCumplimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.NMesCumplimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NGestionCumplimiento")> _
        Public Property NGestionCumplimiento As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NGestionCumplimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.NGestionCumplimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsProducto")> _
        Public Property BEsProducto As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEsProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsCupo")> _
        Public Property BEsCupo As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEsCupo)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsCupo, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsVenta")> _
        Public Property BEsVenta As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEsVenta)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsVenta, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("BEsGerencial")> _
        Public Property BEsGerencial As Boolean 
			Get
				Return GetColumnValue(Of Boolean)(Columns.BEsGerencial)
			End Get
		    
			Set
				SetColumnValue(Columns.BEsGerencial, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NLimite1")> _
        Public Property NLimite1 As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NLimite1)
			End Get
		    
			Set
				SetColumnValue(Columns.NLimite1, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NLimite2")> _
        Public Property NLimite2 As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NLimite2)
			End Get
		    
			Set
				SetColumnValue(Columns.NLimite2, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechaCumplimiento")> _
        Public Property DFechaCumplimiento As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechaCumplimiento)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechaCumplimiento, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodEmpleado")> _
        Public Property NCodEmpleado As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodEmpleado)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodEmpleado, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPorcentaje")> _
        Public Property NPorcentaje As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPorcentaje)
			End Get
		    
			Set
				SetColumnValue(Columns.NPorcentaje, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
        
	    #Region "PrimaryKey Methods"
	    
			Public Function ObjetivoDetalleRecords() As EjSuite.ObjetivoDetalleCollection 
	
				Return New EjSuite.ObjetivoDetalleCollection().Where(ObjetivoDetalle.Columns.NCodObjetivo, NCodObjetivo).Load()
	
			End Function
			
		#End Region
		
		
		
		
		
		
		
		
	    'no foreign key tables defined (0)
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodObjetivo As Integer,ByVal varDFechaAsignacion As DateTime,ByVal varNMesCumplimiento As Integer,ByVal varNGestionCumplimiento As Integer,ByVal varBEsProducto As Boolean,ByVal varBEsCupo As Boolean,ByVal varBEsVenta As Boolean,ByVal varBEsGerencial As Boolean,ByVal varNLimite1 As Decimal,ByVal varNLimite2 As Decimal,ByVal varDFechaCumplimiento As DateTime,ByVal varNCodEmpleado As Integer,ByVal varNPorcentaje As Decimal)
			Dim item As Objetivo = New Objetivo()
			
            item.NCodObjetivo = varNCodObjetivo
            
            item.DFechaAsignacion = varDFechaAsignacion
            
            item.NMesCumplimiento = varNMesCumplimiento
            
            item.NGestionCumplimiento = varNGestionCumplimiento
            
            item.BEsProducto = varBEsProducto
            
            item.BEsCupo = varBEsCupo
            
            item.BEsVenta = varBEsVenta
            
            item.BEsGerencial = varBEsGerencial
            
            item.NLimite1 = varNLimite1
            
            item.NLimite2 = varNLimite2
            
            item.DFechaCumplimiento = varDFechaCumplimiento
            
            item.NCodEmpleado = varNCodEmpleado
            
            item.NPorcentaje = varNPorcentaje
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodObjetivo As Integer,ByVal varDFechaAsignacion As DateTime,ByVal varNMesCumplimiento As Integer,ByVal varNGestionCumplimiento As Integer,ByVal varBEsProducto As Boolean,ByVal varBEsCupo As Boolean,ByVal varBEsVenta As Boolean,ByVal varBEsGerencial As Boolean,ByVal varNLimite1 As Decimal,ByVal varNLimite2 As Decimal,ByVal varDFechaCumplimiento As DateTime,ByVal varNCodEmpleado As Integer,ByVal varNPorcentaje As Decimal)
			Dim item As Objetivo = New Objetivo()
		    
                item.NCodObjetivo = varNCodObjetivo
				
                item.DFechaAsignacion = varDFechaAsignacion
				
                item.NMesCumplimiento = varNMesCumplimiento
				
                item.NGestionCumplimiento = varNGestionCumplimiento
				
                item.BEsProducto = varBEsProducto
				
                item.BEsCupo = varBEsCupo
				
                item.BEsVenta = varBEsVenta
				
                item.BEsGerencial = varBEsGerencial
				
                item.NLimite1 = varNLimite1
				
                item.NLimite2 = varNLimite2
				
                item.DFechaCumplimiento = varDFechaCumplimiento
				
                item.NCodEmpleado = varNCodEmpleado
				
                item.NPorcentaje = varNPorcentaje
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodObjetivoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaAsignacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NMesCumplimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NGestionCumplimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsCupoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsVentaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property BEsGerencialColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NLimite1Column() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NLimite2Column() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFechaCumplimientoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodEmpleadoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPorcentajeColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodObjetivo As String = "nCodObjetivo"
            
            Public Shared DFechaAsignacion As String = "dFechaAsignacion"
            
            Public Shared NMesCumplimiento As String = "nMesCumplimiento"
            
            Public Shared NGestionCumplimiento As String = "nGestionCumplimiento"
            
            Public Shared BEsProducto As String = "bEsProducto"
            
            Public Shared BEsCupo As String = "bEsCupo"
            
            Public Shared BEsVenta As String = "bEsVenta"
            
            Public Shared BEsGerencial As String = "bEsGerencial"
            
            Public Shared NLimite1 As String = "nLimite1"
            
            Public Shared NLimite2 As String = "nLimite2"
            
            Public Shared DFechaCumplimiento As String = "dFechaCumplimiento"
            
            Public Shared NCodEmpleado As String = "nCodEmpleado"
            
            Public Shared NPorcentaje As String = "nPorcentaje"
            
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
