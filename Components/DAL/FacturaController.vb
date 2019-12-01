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
    ''' Controller class for EJS_Factura
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class FacturaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Factura = New Factura()
        Private strUserName As String = String.Empty
        Protected ReadOnly Property UserName() As String
            Get
				If strUserName.Length = 0 Then
		        
    				If Not System.Web.HttpContext.Current Is Nothing Then
						strUserName = System.Web.HttpContext.Current.User.Identity.Name
					Else
		        		strUserName = System.Threading.Thread.CurrentPrincipal.Identity.Name
					End If
					Return strUserName
				End If
				Return strUserName
			End Get
        End Property
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As FacturaCollection
        
            Dim coll As FacturaCollection = New FacturaCollection()
            Dim qry As Query = New Query(Factura.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodFactura As Object) As FacturaCollection 
        
            Dim coll As FacturaCollection = New FacturaCollection().Where("nCodFactura", NCodFactura).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As FacturaCollection 
        
            Dim coll As FacturaCollection = New FacturaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodFactura As Object) as Boolean
        
            Return (Factura.Delete(NCodFactura) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodFactura As Object) as Boolean
        
            Return (Factura.Destroy(NCodFactura) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodFactura As Long,ByVal CNit As String,ByVal CNombreFactura As String,ByVal NNumero As Integer,ByVal CAutorizacion As String,ByVal CCodigoFactura As String,ByVal CLlaveDosificacion As String,ByVal DFechaEmision As Nullable(Of DateTime),ByVal DFechaLimite As DateTime,ByVal DVencimiento As Nullable(Of DateTime),ByVal BPendiente As Boolean,ByVal BPagada As Boolean,ByVal BAnulado As Nullable(Of Boolean),ByVal NCodSucursal As Integer,ByVal NCodUsuario As Integer,ByVal NCodCliente As Long,ByVal CValorQR As String,ByVal NCodCuenta As Nullable(Of Integer),ByVal NCodVendedor As Nullable(Of Integer),ByVal DFechaContabilidad As Nullable(Of DateTime))
	   
		    Dim item As Factura = New Factura()
		    
            item.NCodFactura = NCodFactura
            
            item.CNit = CNit
            
            item.CNombreFactura = CNombreFactura
            
            item.NNumero = NNumero
            
            item.CAutorizacion = CAutorizacion
            
            item.CCodigoFactura = CCodigoFactura
            
            item.CLlaveDosificacion = CLlaveDosificacion
            
            item.DFechaEmision = DFechaEmision
            
            item.DFechaLimite = DFechaLimite
            
            item.DVencimiento = DVencimiento
            
            item.BPendiente = BPendiente
            
            item.BPagada = BPagada
            
            item.BAnulado = BAnulado
            
            item.NCodSucursal = NCodSucursal
            
            item.NCodUsuario = NCodUsuario
            
            item.NCodCliente = NCodCliente
            
            item.CValorQR = CValorQR
            
            item.NCodCuenta = NCodCuenta
            
            item.NCodVendedor = NCodVendedor
            
            item.DFechaContabilidad = DFechaContabilidad
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodFactura As Long,ByVal CNit As String,ByVal CNombreFactura As String,ByVal NNumero As Integer,ByVal CAutorizacion As String,ByVal CCodigoFactura As String,ByVal CLlaveDosificacion As String,ByVal DFechaEmision As Nullable(Of DateTime),ByVal DFechaLimite As DateTime,ByVal DVencimiento As Nullable(Of DateTime),ByVal BPendiente As Boolean,ByVal BPagada As Boolean,ByVal BAnulado As Nullable(Of Boolean),ByVal NCodSucursal As Integer,ByVal NCodUsuario As Integer,ByVal NCodCliente As Long,ByVal CValorQR As String,ByVal NCodCuenta As Nullable(Of Integer),ByVal NCodVendedor As Nullable(Of Integer),ByVal DFechaContabilidad As Nullable(Of DateTime))
	    
		    Dim item As Factura = New Factura()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodFactura = NCodFactura 
				
			item.CNit = CNit 
				
			item.CNombreFactura = CNombreFactura 
				
			item.NNumero = NNumero 
				
			item.CAutorizacion = CAutorizacion 
				
			item.CCodigoFactura = CCodigoFactura 
				
			item.CLlaveDosificacion = CLlaveDosificacion 
				
			item.DFechaEmision = DFechaEmision 
				
			item.DFechaLimite = DFechaLimite 
				
			item.DVencimiento = DVencimiento 
				
			item.BPendiente = BPendiente 
				
			item.BPagada = BPagada 
				
			item.BAnulado = BAnulado 
				
			item.NCodSucursal = NCodSucursal 
				
			item.NCodUsuario = NCodUsuario 
				
			item.NCodCliente = NCodCliente 
				
			item.CValorQR = CValorQR 
				
			item.NCodCuenta = NCodCuenta 
				
			item.NCodVendedor = NCodVendedor 
				
			item.DFechaContabilidad = DFechaContabilidad 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
