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
	''' Strongly-typed collection for the KardexInventario class.
	''' </summary>
	<Serializable> _
	Public Partial Class KardexInventarioCollection 
	Inherits ActiveList(Of KardexInventario, KardexInventarioCollection)
	    Public Sub New()
		End Sub
		
		Public Function Filter() As KardexInventarioCollection
			For i As Integer = Me.Count - 1 To 0 Step -1
				Dim o As KardexInventario = Me(i)
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
	''' This is an ActiveRecord class which wraps the EJS_KardexInventario table.
	''' </summary>
	<Serializable> _
	Public Partial Class KardexInventario 
	Inherits ActiveRecord(Of KardexInventario)
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
				Dim schema As TableSchema.Table = New TableSchema.Table("EJS_KardexInventario", TableType.Table, DataService.GetInstance("DALEjSuite"))
				schema.Columns = New TableSchema.TableColumnCollection()
				schema.SchemaName = "dbo"
				'columns
				
                
                Dim colvarNCodKardex As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodKardex.ColumnName = "nCodKardex"
                colvarNCodKardex.DataType = DbType.Int32
                colvarNCodKardex.MaxLength = 0
                colvarNCodKardex.AutoIncrement = false
                colvarNCodKardex.IsNullable = false
                colvarNCodKardex.IsPrimaryKey = true
                colvarNCodKardex.IsForeignKey = false
                colvarNCodKardex.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCodKardex)
                
                Dim colvarNCodAlmacen As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodAlmacen.ColumnName = "nCodAlmacen"
                colvarNCodAlmacen.DataType = DbType.Int32
                colvarNCodAlmacen.MaxLength = 0
                colvarNCodAlmacen.AutoIncrement = false
                colvarNCodAlmacen.IsNullable = true
                colvarNCodAlmacen.IsPrimaryKey = false
                colvarNCodAlmacen.IsForeignKey = true
                colvarNCodAlmacen.IsReadOnly = false
                
                
				colvarNCodAlmacen.ForeignKeyTableName = "EJS_Almacen"
                
                schema.Columns.Add(colvarNCodAlmacen)
                
                Dim colvarNCodLote As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodLote.ColumnName = "nCodLote"
                colvarNCodLote.DataType = DbType.Int32
                colvarNCodLote.MaxLength = 0
                colvarNCodLote.AutoIncrement = false
                colvarNCodLote.IsNullable = true
                colvarNCodLote.IsPrimaryKey = false
                colvarNCodLote.IsForeignKey = true
                colvarNCodLote.IsReadOnly = false
                
                
				colvarNCodLote.ForeignKeyTableName = "EJS_Lote"
                
                schema.Columns.Add(colvarNCodLote)
                
                Dim colvarNCodProducto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCodProducto.ColumnName = "nCodProducto"
                colvarNCodProducto.DataType = DbType.Int32
                colvarNCodProducto.MaxLength = 0
                colvarNCodProducto.AutoIncrement = false
                colvarNCodProducto.IsNullable = true
                colvarNCodProducto.IsPrimaryKey = false
                colvarNCodProducto.IsForeignKey = true
                colvarNCodProducto.IsReadOnly = false
                
                
				colvarNCodProducto.ForeignKeyTableName = "EJS_Producto"
                
                schema.Columns.Add(colvarNCodProducto)
                
                Dim colvarDFechareg As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarDFechareg.ColumnName = "dFechareg"
                colvarDFechareg.DataType = DbType.DateTime
                colvarDFechareg.MaxLength = 0
                colvarDFechareg.AutoIncrement = false
                colvarDFechareg.IsNullable = false
                colvarDFechareg.IsPrimaryKey = false
                colvarDFechareg.IsForeignKey = false
                colvarDFechareg.IsReadOnly = false
                
                
                schema.Columns.Add(colvarDFechareg)
                
                Dim colvarCObservacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCObservacion.ColumnName = "cObservacion"
                colvarCObservacion.DataType = DbType.AnsiString
                colvarCObservacion.MaxLength = 200
                colvarCObservacion.AutoIncrement = false
                colvarCObservacion.IsNullable = false
                colvarCObservacion.IsPrimaryKey = false
                colvarCObservacion.IsForeignKey = false
                colvarCObservacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCObservacion)
                
                Dim colvarNPrecioCompra As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioCompra.ColumnName = "nPrecioCompra"
                colvarNPrecioCompra.DataType = DbType.Currency
                colvarNPrecioCompra.MaxLength = 0
                colvarNPrecioCompra.AutoIncrement = false
                colvarNPrecioCompra.IsNullable = false
                colvarNPrecioCompra.IsPrimaryKey = false
                colvarNPrecioCompra.IsForeignKey = false
                colvarNPrecioCompra.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioCompra)
                
                Dim colvarNEntrada As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEntrada.ColumnName = "nEntrada"
                colvarNEntrada.DataType = DbType.Int32
                colvarNEntrada.MaxLength = 0
                colvarNEntrada.AutoIncrement = false
                colvarNEntrada.IsNullable = false
                colvarNEntrada.IsPrimaryKey = false
                colvarNEntrada.IsForeignKey = false
                colvarNEntrada.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEntrada)
                
                Dim colvarNSalida As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNSalida.ColumnName = "nSalida"
                colvarNSalida.DataType = DbType.Int32
                colvarNSalida.MaxLength = 0
                colvarNSalida.AutoIncrement = false
                colvarNSalida.IsNullable = false
                colvarNSalida.IsPrimaryKey = false
                colvarNSalida.IsForeignKey = false
                colvarNSalida.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNSalida)
                
                Dim colvarNEntradaSueltos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEntradaSueltos.ColumnName = "nEntradaSueltos"
                colvarNEntradaSueltos.DataType = DbType.Int32
                colvarNEntradaSueltos.MaxLength = 0
                colvarNEntradaSueltos.AutoIncrement = false
                colvarNEntradaSueltos.IsNullable = false
                colvarNEntradaSueltos.IsPrimaryKey = false
                colvarNEntradaSueltos.IsForeignKey = false
                colvarNEntradaSueltos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEntradaSueltos)
                
                Dim colvarNSalidaSueltos As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNSalidaSueltos.ColumnName = "nSalidaSueltos"
                colvarNSalidaSueltos.DataType = DbType.Int32
                colvarNSalidaSueltos.MaxLength = 0
                colvarNSalidaSueltos.AutoIncrement = false
                colvarNSalidaSueltos.IsNullable = false
                colvarNSalidaSueltos.IsPrimaryKey = false
                colvarNSalidaSueltos.IsForeignKey = false
                colvarNSalidaSueltos.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNSalidaSueltos)
                
                Dim colvarNStockAnteriorEnvase As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockAnteriorEnvase.ColumnName = "nStockAnteriorEnvase"
                colvarNStockAnteriorEnvase.DataType = DbType.Int32
                colvarNStockAnteriorEnvase.MaxLength = 0
                colvarNStockAnteriorEnvase.AutoIncrement = false
                colvarNStockAnteriorEnvase.IsNullable = false
                colvarNStockAnteriorEnvase.IsPrimaryKey = false
                colvarNStockAnteriorEnvase.IsForeignKey = false
                colvarNStockAnteriorEnvase.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockAnteriorEnvase)
                
                Dim colvarNStockActualEnvase As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockActualEnvase.ColumnName = "nStockActualEnvase"
                colvarNStockActualEnvase.DataType = DbType.Int32
                colvarNStockActualEnvase.MaxLength = 0
                colvarNStockActualEnvase.AutoIncrement = false
                colvarNStockActualEnvase.IsNullable = false
                colvarNStockActualEnvase.IsPrimaryKey = false
                colvarNStockActualEnvase.IsForeignKey = false
                colvarNStockActualEnvase.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockActualEnvase)
                
                Dim colvarNStockAnteriorSuelto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockAnteriorSuelto.ColumnName = "nStockAnteriorSuelto"
                colvarNStockAnteriorSuelto.DataType = DbType.Int32
                colvarNStockAnteriorSuelto.MaxLength = 0
                colvarNStockAnteriorSuelto.AutoIncrement = false
                colvarNStockAnteriorSuelto.IsNullable = false
                colvarNStockAnteriorSuelto.IsPrimaryKey = false
                colvarNStockAnteriorSuelto.IsForeignKey = false
                colvarNStockAnteriorSuelto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockAnteriorSuelto)
                
                Dim colvarNStockActualSuelto As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockActualSuelto.ColumnName = "nStockActualSuelto"
                colvarNStockActualSuelto.DataType = DbType.Int32
                colvarNStockActualSuelto.MaxLength = 0
                colvarNStockActualSuelto.AutoIncrement = false
                colvarNStockActualSuelto.IsNullable = false
                colvarNStockActualSuelto.IsPrimaryKey = false
                colvarNStockActualSuelto.IsForeignKey = false
                colvarNStockActualSuelto.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockActualSuelto)
                
                Dim colvarNCostoTotal As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNCostoTotal.ColumnName = "nCostoTotal"
                colvarNCostoTotal.DataType = DbType.Currency
                colvarNCostoTotal.MaxLength = 0
                colvarNCostoTotal.AutoIncrement = false
                colvarNCostoTotal.IsNullable = false
                colvarNCostoTotal.IsPrimaryKey = false
                colvarNCostoTotal.IsForeignKey = false
                colvarNCostoTotal.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNCostoTotal)
                
                Dim colvarCGlosa As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarCGlosa.ColumnName = "cGlosa"
                colvarCGlosa.DataType = DbType.AnsiString
                colvarCGlosa.MaxLength = 255
                colvarCGlosa.AutoIncrement = false
                colvarCGlosa.IsNullable = false
                colvarCGlosa.IsPrimaryKey = false
                colvarCGlosa.IsForeignKey = false
                colvarCGlosa.IsReadOnly = false
                
                
                schema.Columns.Add(colvarCGlosa)
                
                Dim colvarNPrecioAlmacen As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioAlmacen.ColumnName = "nPrecioAlmacen"
                colvarNPrecioAlmacen.DataType = DbType.Currency
                colvarNPrecioAlmacen.MaxLength = 0
                colvarNPrecioAlmacen.AutoIncrement = false
                colvarNPrecioAlmacen.IsNullable = false
                colvarNPrecioAlmacen.IsPrimaryKey = false
                colvarNPrecioAlmacen.IsForeignKey = false
                colvarNPrecioAlmacen.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioAlmacen)
                
                Dim colvarNPrecioVenta As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNPrecioVenta.ColumnName = "nPrecioVenta"
                colvarNPrecioVenta.DataType = DbType.Currency
                colvarNPrecioVenta.MaxLength = 0
                colvarNPrecioVenta.AutoIncrement = false
                colvarNPrecioVenta.IsNullable = false
                colvarNPrecioVenta.IsPrimaryKey = false
                colvarNPrecioVenta.IsForeignKey = false
                colvarNPrecioVenta.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNPrecioVenta)
                
                Dim colvarNEntradaBonificacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEntradaBonificacion.ColumnName = "nEntradaBonificacion"
                colvarNEntradaBonificacion.DataType = DbType.Int32
                colvarNEntradaBonificacion.MaxLength = 0
                colvarNEntradaBonificacion.AutoIncrement = false
                colvarNEntradaBonificacion.IsNullable = true
                colvarNEntradaBonificacion.IsPrimaryKey = false
                colvarNEntradaBonificacion.IsForeignKey = false
                colvarNEntradaBonificacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEntradaBonificacion)
                
                Dim colvarNSalidaBonificacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNSalidaBonificacion.ColumnName = "nSalidaBonificacion"
                colvarNSalidaBonificacion.DataType = DbType.Int32
                colvarNSalidaBonificacion.MaxLength = 0
                colvarNSalidaBonificacion.AutoIncrement = false
                colvarNSalidaBonificacion.IsNullable = true
                colvarNSalidaBonificacion.IsPrimaryKey = false
                colvarNSalidaBonificacion.IsForeignKey = false
                colvarNSalidaBonificacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNSalidaBonificacion)
                
                Dim colvarNEntradaReintegro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNEntradaReintegro.ColumnName = "nEntradaReintegro"
                colvarNEntradaReintegro.DataType = DbType.Int32
                colvarNEntradaReintegro.MaxLength = 0
                colvarNEntradaReintegro.AutoIncrement = false
                colvarNEntradaReintegro.IsNullable = true
                colvarNEntradaReintegro.IsPrimaryKey = false
                colvarNEntradaReintegro.IsForeignKey = false
                colvarNEntradaReintegro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNEntradaReintegro)
                
                Dim colvarNSalidaReintegro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNSalidaReintegro.ColumnName = "nSalidaReintegro"
                colvarNSalidaReintegro.DataType = DbType.Int32
                colvarNSalidaReintegro.MaxLength = 0
                colvarNSalidaReintegro.AutoIncrement = false
                colvarNSalidaReintegro.IsNullable = true
                colvarNSalidaReintegro.IsPrimaryKey = false
                colvarNSalidaReintegro.IsForeignKey = false
                colvarNSalidaReintegro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNSalidaReintegro)
                
                Dim colvarNStockAnteriorBonificacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockAnteriorBonificacion.ColumnName = "nStockAnteriorBonificacion"
                colvarNStockAnteriorBonificacion.DataType = DbType.Int32
                colvarNStockAnteriorBonificacion.MaxLength = 0
                colvarNStockAnteriorBonificacion.AutoIncrement = false
                colvarNStockAnteriorBonificacion.IsNullable = true
                colvarNStockAnteriorBonificacion.IsPrimaryKey = false
                colvarNStockAnteriorBonificacion.IsForeignKey = false
                colvarNStockAnteriorBonificacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockAnteriorBonificacion)
                
                Dim colvarNStockActualBonificacion As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockActualBonificacion.ColumnName = "nStockActualBonificacion"
                colvarNStockActualBonificacion.DataType = DbType.Int32
                colvarNStockActualBonificacion.MaxLength = 0
                colvarNStockActualBonificacion.AutoIncrement = false
                colvarNStockActualBonificacion.IsNullable = true
                colvarNStockActualBonificacion.IsPrimaryKey = false
                colvarNStockActualBonificacion.IsForeignKey = false
                colvarNStockActualBonificacion.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockActualBonificacion)
                
                Dim colvarNStockAnteriorReintegro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockAnteriorReintegro.ColumnName = "nStockAnteriorReintegro"
                colvarNStockAnteriorReintegro.DataType = DbType.Int32
                colvarNStockAnteriorReintegro.MaxLength = 0
                colvarNStockAnteriorReintegro.AutoIncrement = false
                colvarNStockAnteriorReintegro.IsNullable = true
                colvarNStockAnteriorReintegro.IsPrimaryKey = false
                colvarNStockAnteriorReintegro.IsForeignKey = false
                colvarNStockAnteriorReintegro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockAnteriorReintegro)
                
                Dim colvarNStockActualReintegro As TableSchema.TableColumn = New TableSchema.TableColumn(schema)
                colvarNStockActualReintegro.ColumnName = "nStockActualReintegro"
                colvarNStockActualReintegro.DataType = DbType.Int32
                colvarNStockActualReintegro.MaxLength = 0
                colvarNStockActualReintegro.AutoIncrement = false
                colvarNStockActualReintegro.IsNullable = true
                colvarNStockActualReintegro.IsPrimaryKey = false
                colvarNStockActualReintegro.IsForeignKey = false
                colvarNStockActualReintegro.IsReadOnly = false
                
                
                schema.Columns.Add(colvarNStockActualReintegro)
                
				BaseSchema = schema
				
				'add this schema to the provider
                'so we can query it later
                DataService.Providers("DALEjSuite").AddSchema("EJS_KardexInventario",schema)
			End If
		End Sub
		Public Shared Function CreateQuery() As Query
			Return New Query(Schema)
		End Function
		
		#End Region
		
		#Region "Props"
	
        
        <Bindable(True)> _  
        <XmlAttribute("NCodKardex")> _
        Public Property NCodKardex As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NCodKardex)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodKardex, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodAlmacen")> _
        Public Property NCodAlmacen As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodAlmacen)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodAlmacen, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodLote")> _
        Public Property NCodLote As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodLote)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodLote, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCodProducto")> _
        Public Property NCodProducto As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NCodProducto)
			End Get
		    
			Set
				SetColumnValue(Columns.NCodProducto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("DFechareg")> _
        Public Property DFechareg As DateTime 
			Get
				Return GetColumnValue(Of DateTime)(Columns.DFechareg)
			End Get
		    
			Set
				SetColumnValue(Columns.DFechareg, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CObservacion")> _
        Public Property CObservacion As String 
			Get
				Return GetColumnValue(Of String)(Columns.CObservacion)
			End Get
		    
			Set
				SetColumnValue(Columns.CObservacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioCompra")> _
        Public Property NPrecioCompra As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioCompra)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioCompra, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEntrada")> _
        Public Property NEntrada As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NEntrada)
			End Get
		    
			Set
				SetColumnValue(Columns.NEntrada, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NSalida")> _
        Public Property NSalida As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NSalida)
			End Get
		    
			Set
				SetColumnValue(Columns.NSalida, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEntradaSueltos")> _
        Public Property NEntradaSueltos As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NEntradaSueltos)
			End Get
		    
			Set
				SetColumnValue(Columns.NEntradaSueltos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NSalidaSueltos")> _
        Public Property NSalidaSueltos As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NSalidaSueltos)
			End Get
		    
			Set
				SetColumnValue(Columns.NSalidaSueltos, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockAnteriorEnvase")> _
        Public Property NStockAnteriorEnvase As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NStockAnteriorEnvase)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockAnteriorEnvase, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockActualEnvase")> _
        Public Property NStockActualEnvase As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NStockActualEnvase)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockActualEnvase, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockAnteriorSuelto")> _
        Public Property NStockAnteriorSuelto As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NStockAnteriorSuelto)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockAnteriorSuelto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockActualSuelto")> _
        Public Property NStockActualSuelto As Integer 
			Get
				Return GetColumnValue(Of Integer)(Columns.NStockActualSuelto)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockActualSuelto, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NCostoTotal")> _
        Public Property NCostoTotal As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NCostoTotal)
			End Get
		    
			Set
				SetColumnValue(Columns.NCostoTotal, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("CGlosa")> _
        Public Property CGlosa As String 
			Get
				Return GetColumnValue(Of String)(Columns.CGlosa)
			End Get
		    
			Set
				SetColumnValue(Columns.CGlosa, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioAlmacen")> _
        Public Property NPrecioAlmacen As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioAlmacen)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioAlmacen, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NPrecioVenta")> _
        Public Property NPrecioVenta As Decimal 
			Get
				Return GetColumnValue(Of Decimal)(Columns.NPrecioVenta)
			End Get
		    
			Set
				SetColumnValue(Columns.NPrecioVenta, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEntradaBonificacion")> _
        Public Property NEntradaBonificacion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NEntradaBonificacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NEntradaBonificacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NSalidaBonificacion")> _
        Public Property NSalidaBonificacion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NSalidaBonificacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NSalidaBonificacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NEntradaReintegro")> _
        Public Property NEntradaReintegro As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NEntradaReintegro)
			End Get
		    
			Set
				SetColumnValue(Columns.NEntradaReintegro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NSalidaReintegro")> _
        Public Property NSalidaReintegro As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NSalidaReintegro)
			End Get
		    
			Set
				SetColumnValue(Columns.NSalidaReintegro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockAnteriorBonificacion")> _
        Public Property NStockAnteriorBonificacion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NStockAnteriorBonificacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockAnteriorBonificacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockActualBonificacion")> _
        Public Property NStockActualBonificacion As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NStockActualBonificacion)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockActualBonificacion, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockAnteriorReintegro")> _
        Public Property NStockAnteriorReintegro As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NStockAnteriorReintegro)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockAnteriorReintegro, Value)
			End Set
		End Property
		
		
		
        <Bindable(True)> _  
        <XmlAttribute("NStockActualReintegro")> _
        Public Property NStockActualReintegro As Nullable(Of Integer) 
			Get
				Return GetColumnValue(Of Nullable(Of Integer))(Columns.NStockActualReintegro)
			End Get
		    
			Set
				SetColumnValue(Columns.NStockActualReintegro, Value)
			End Set
		End Property
		
		
		
		
		#End Region
		
		
		
		
		
		
		
		
		
	    #Region "ForeignKey Methods"
	    
		''' <summary>
		''' Returns a Lote ActiveRecord object related to this KardexInventario
		''' </summary>
		Public Property Lote() As EjSuite.Lote
			Get
				Return EjSuite.Lote.FetchByID(Me.NCodLote)
			End Get
			Set
				SetColumnValue("nCodLote", Value.NCodLote)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Almacen ActiveRecord object related to this KardexInventario
		''' </summary>
		Public Property Almacen() As EjSuite.Almacen
			Get
				Return EjSuite.Almacen.FetchByID(Me.NCodAlmacen)
			End Get
			Set
				SetColumnValue("nCodAlmacen", Value.NCodAlmacen)
			End Set
		End Property
	    
		''' <summary>
		''' Returns a Producto ActiveRecord object related to this KardexInventario
		''' </summary>
		Public Property Producto() As EjSuite.Producto
			Get
				Return EjSuite.Producto.FetchByID(Me.NCodProducto)
			End Get
			Set
				SetColumnValue("nCodProducto", Value.NCodProducto)
			End Set
		End Property
	    
	    #End Region
	    
		
		
	    'no ManyToMany tables defined (0)
	    
		
        
		#Region "ObjectDataSource support"
		
		''' <summary>
		''' Inserts a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Insert(ByVal varNCodKardex As Integer,ByVal varNCodAlmacen As Nullable(Of Integer),ByVal varNCodLote As Nullable(Of Integer),ByVal varNCodProducto As Nullable(Of Integer),ByVal varDFechareg As DateTime,ByVal varCObservacion As String,ByVal varNPrecioCompra As Decimal,ByVal varNEntrada As Integer,ByVal varNSalida As Integer,ByVal varNEntradaSueltos As Integer,ByVal varNSalidaSueltos As Integer,ByVal varNStockAnteriorEnvase As Integer,ByVal varNStockActualEnvase As Integer,ByVal varNStockAnteriorSuelto As Integer,ByVal varNStockActualSuelto As Integer,ByVal varNCostoTotal As Decimal,ByVal varCGlosa As String,ByVal varNPrecioAlmacen As Decimal,ByVal varNPrecioVenta As Decimal,ByVal varNEntradaBonificacion As Nullable(Of Integer),ByVal varNSalidaBonificacion As Nullable(Of Integer),ByVal varNEntradaReintegro As Nullable(Of Integer),ByVal varNSalidaReintegro As Nullable(Of Integer),ByVal varNStockAnteriorBonificacion As Nullable(Of Integer),ByVal varNStockActualBonificacion As Nullable(Of Integer),ByVal varNStockAnteriorReintegro As Nullable(Of Integer),ByVal varNStockActualReintegro As Nullable(Of Integer))
			Dim item As KardexInventario = New KardexInventario()
			
            item.NCodKardex = varNCodKardex
            
            item.NCodAlmacen = varNCodAlmacen
            
            item.NCodLote = varNCodLote
            
            item.NCodProducto = varNCodProducto
            
            item.DFechareg = varDFechareg
            
            item.CObservacion = varCObservacion
            
            item.NPrecioCompra = varNPrecioCompra
            
            item.NEntrada = varNEntrada
            
            item.NSalida = varNSalida
            
            item.NEntradaSueltos = varNEntradaSueltos
            
            item.NSalidaSueltos = varNSalidaSueltos
            
            item.NStockAnteriorEnvase = varNStockAnteriorEnvase
            
            item.NStockActualEnvase = varNStockActualEnvase
            
            item.NStockAnteriorSuelto = varNStockAnteriorSuelto
            
            item.NStockActualSuelto = varNStockActualSuelto
            
            item.NCostoTotal = varNCostoTotal
            
            item.CGlosa = varCGlosa
            
            item.NPrecioAlmacen = varNPrecioAlmacen
            
            item.NPrecioVenta = varNPrecioVenta
            
            item.NEntradaBonificacion = varNEntradaBonificacion
            
            item.NSalidaBonificacion = varNSalidaBonificacion
            
            item.NEntradaReintegro = varNEntradaReintegro
            
            item.NSalidaReintegro = varNSalidaReintegro
            
            item.NStockAnteriorBonificacion = varNStockAnteriorBonificacion
            
            item.NStockActualBonificacion = varNStockActualBonificacion
            
            item.NStockAnteriorReintegro = varNStockAnteriorReintegro
            
            item.NStockActualReintegro = varNStockActualReintegro
            
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		''' <summary>
		''' Updates a record, can be used with the Object Data Source
		''' </summary>
		Public Shared Sub Update(ByVal varNCodKardex As Integer,ByVal varNCodAlmacen As Nullable(Of Integer),ByVal varNCodLote As Nullable(Of Integer),ByVal varNCodProducto As Nullable(Of Integer),ByVal varDFechareg As DateTime,ByVal varCObservacion As String,ByVal varNPrecioCompra As Decimal,ByVal varNEntrada As Integer,ByVal varNSalida As Integer,ByVal varNEntradaSueltos As Integer,ByVal varNSalidaSueltos As Integer,ByVal varNStockAnteriorEnvase As Integer,ByVal varNStockActualEnvase As Integer,ByVal varNStockAnteriorSuelto As Integer,ByVal varNStockActualSuelto As Integer,ByVal varNCostoTotal As Decimal,ByVal varCGlosa As String,ByVal varNPrecioAlmacen As Decimal,ByVal varNPrecioVenta As Decimal,ByVal varNEntradaBonificacion As Nullable(Of Integer),ByVal varNSalidaBonificacion As Nullable(Of Integer),ByVal varNEntradaReintegro As Nullable(Of Integer),ByVal varNSalidaReintegro As Nullable(Of Integer),ByVal varNStockAnteriorBonificacion As Nullable(Of Integer),ByVal varNStockActualBonificacion As Nullable(Of Integer),ByVal varNStockAnteriorReintegro As Nullable(Of Integer),ByVal varNStockActualReintegro As Nullable(Of Integer))
			Dim item As KardexInventario = New KardexInventario()
		    
                item.NCodKardex = varNCodKardex
				
                item.NCodAlmacen = varNCodAlmacen
				
                item.NCodLote = varNCodLote
				
                item.NCodProducto = varNCodProducto
				
                item.DFechareg = varDFechareg
				
                item.CObservacion = varCObservacion
				
                item.NPrecioCompra = varNPrecioCompra
				
                item.NEntrada = varNEntrada
				
                item.NSalida = varNSalida
				
                item.NEntradaSueltos = varNEntradaSueltos
				
                item.NSalidaSueltos = varNSalidaSueltos
				
                item.NStockAnteriorEnvase = varNStockAnteriorEnvase
				
                item.NStockActualEnvase = varNStockActualEnvase
				
                item.NStockAnteriorSuelto = varNStockAnteriorSuelto
				
                item.NStockActualSuelto = varNStockActualSuelto
				
                item.NCostoTotal = varNCostoTotal
				
                item.CGlosa = varCGlosa
				
                item.NPrecioAlmacen = varNPrecioAlmacen
				
                item.NPrecioVenta = varNPrecioVenta
				
                item.NEntradaBonificacion = varNEntradaBonificacion
				
                item.NSalidaBonificacion = varNSalidaBonificacion
				
                item.NEntradaReintegro = varNEntradaReintegro
				
                item.NSalidaReintegro = varNSalidaReintegro
				
                item.NStockAnteriorBonificacion = varNStockAnteriorBonificacion
				
                item.NStockActualBonificacion = varNStockActualBonificacion
				
                item.NStockAnteriorReintegro = varNStockAnteriorReintegro
				
                item.NStockActualReintegro = varNStockActualReintegro
				
			item.IsNew = False
			If Not System.Web.HttpContext.Current Is Nothing Then
				item.Save(System.Web.HttpContext.Current.User.Identity.Name)
			Else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name)
			End If
		End Sub
		#End Region
		
		
		#Region "Typed Columns"
        
        
        Public Shared ReadOnly Property NCodKardexColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(0)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodAlmacenColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(1)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodLoteColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(2)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCodProductoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(3)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property DFecharegColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(4)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CObservacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(5)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioCompraColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(6)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEntradaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(7)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NSalidaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(8)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEntradaSueltosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(9)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NSalidaSueltosColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(10)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockAnteriorEnvaseColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(11)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockActualEnvaseColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(12)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockAnteriorSueltoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(13)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockActualSueltoColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(14)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NCostoTotalColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(15)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property CGlosaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(16)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioAlmacenColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(17)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NPrecioVentaColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(18)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEntradaBonificacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(19)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NSalidaBonificacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(20)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NEntradaReintegroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(21)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NSalidaReintegroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(22)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockAnteriorBonificacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(23)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockActualBonificacionColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(24)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockAnteriorReintegroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(25)
            End Get
        End Property
        
        
        Public Shared ReadOnly Property NStockActualReintegroColumn() As TableSchema.TableColumn
            Get
                Return Schema.Columns(26)
            End Get
        End Property
        
        
        #End Region
		
		#Region "Columns Struct"
		Public Structure Columns
			Dim x as Integer
			
            Public Shared NCodKardex As String = "nCodKardex"
            
            Public Shared NCodAlmacen As String = "nCodAlmacen"
            
            Public Shared NCodLote As String = "nCodLote"
            
            Public Shared NCodProducto As String = "nCodProducto"
            
            Public Shared DFechareg As String = "dFechareg"
            
            Public Shared CObservacion As String = "cObservacion"
            
            Public Shared NPrecioCompra As String = "nPrecioCompra"
            
            Public Shared NEntrada As String = "nEntrada"
            
            Public Shared NSalida As String = "nSalida"
            
            Public Shared NEntradaSueltos As String = "nEntradaSueltos"
            
            Public Shared NSalidaSueltos As String = "nSalidaSueltos"
            
            Public Shared NStockAnteriorEnvase As String = "nStockAnteriorEnvase"
            
            Public Shared NStockActualEnvase As String = "nStockActualEnvase"
            
            Public Shared NStockAnteriorSuelto As String = "nStockAnteriorSuelto"
            
            Public Shared NStockActualSuelto As String = "nStockActualSuelto"
            
            Public Shared NCostoTotal As String = "nCostoTotal"
            
            Public Shared CGlosa As String = "cGlosa"
            
            Public Shared NPrecioAlmacen As String = "nPrecioAlmacen"
            
            Public Shared NPrecioVenta As String = "nPrecioVenta"
            
            Public Shared NEntradaBonificacion As String = "nEntradaBonificacion"
            
            Public Shared NSalidaBonificacion As String = "nSalidaBonificacion"
            
            Public Shared NEntradaReintegro As String = "nEntradaReintegro"
            
            Public Shared NSalidaReintegro As String = "nSalidaReintegro"
            
            Public Shared NStockAnteriorBonificacion As String = "nStockAnteriorBonificacion"
            
            Public Shared NStockActualBonificacion As String = "nStockActualBonificacion"
            
            Public Shared NStockAnteriorReintegro As String = "nStockAnteriorReintegro"
            
            Public Shared NStockActualReintegro As String = "nStockActualReintegro"
            
		End Structure
		#End Region
		
				
		#Region "Update PK Collections"
		
        #End Region
        
        #Region "Deep Save"
		
        #End Region
        
	End Class
End Namespace
