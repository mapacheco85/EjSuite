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
    ''' Controller class for EJS_Lote
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class LoteController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Lote = New Lote()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As LoteCollection
        
            Dim coll As LoteCollection = New LoteCollection()
            Dim qry As Query = New Query(Lote.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodLote As Object) As LoteCollection 
        
            Dim coll As LoteCollection = New LoteCollection().Where("nCodLote", NCodLote).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As LoteCollection 
        
            Dim coll As LoteCollection = New LoteCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodLote As Object) as Boolean
        
            Return (Lote.Delete(NCodLote) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodLote As Object) as Boolean
        
            Return (Lote.Destroy(NCodLote) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodLote As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal CComprobanteRecibo As String,ByVal CNumeroFactura As String,ByVal CFormaPago As String,ByVal DFechaIngreso As DateTime,ByVal DFechaVencimiento As DateTime,ByVal NPrecioAnteriorEnvase As Decimal,ByVal NPrecioActualEnvase As Decimal,ByVal BEstadoLote As Boolean,ByVal NTotalEnvases As Integer,ByVal NTotalSueltos As Integer,ByVal CObservaciones As String,ByVal NCostoUnidad As Nullable(Of Decimal),ByVal CTipo As String)
	   
		    Dim item As Lote = New Lote()
		    
            item.NCodLote = NCodLote
            
            item.NCodProducto = NCodProducto
            
            item.CComprobanteRecibo = CComprobanteRecibo
            
            item.CNumeroFactura = CNumeroFactura
            
            item.CFormaPago = CFormaPago
            
            item.DFechaIngreso = DFechaIngreso
            
            item.DFechaVencimiento = DFechaVencimiento
            
            item.NPrecioAnteriorEnvase = NPrecioAnteriorEnvase
            
            item.NPrecioActualEnvase = NPrecioActualEnvase
            
            item.BEstadoLote = BEstadoLote
            
            item.NTotalEnvases = NTotalEnvases
            
            item.NTotalSueltos = NTotalSueltos
            
            item.CObservaciones = CObservaciones
            
            item.NCostoUnidad = NCostoUnidad
            
            item.CTipo = CTipo
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodLote As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal CComprobanteRecibo As String,ByVal CNumeroFactura As String,ByVal CFormaPago As String,ByVal DFechaIngreso As DateTime,ByVal DFechaVencimiento As DateTime,ByVal NPrecioAnteriorEnvase As Decimal,ByVal NPrecioActualEnvase As Decimal,ByVal BEstadoLote As Boolean,ByVal NTotalEnvases As Integer,ByVal NTotalSueltos As Integer,ByVal CObservaciones As String,ByVal NCostoUnidad As Nullable(Of Decimal),ByVal CTipo As String)
	    
		    Dim item As Lote = New Lote()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodLote = NCodLote 
				
			item.NCodProducto = NCodProducto 
				
			item.CComprobanteRecibo = CComprobanteRecibo 
				
			item.CNumeroFactura = CNumeroFactura 
				
			item.CFormaPago = CFormaPago 
				
			item.DFechaIngreso = DFechaIngreso 
				
			item.DFechaVencimiento = DFechaVencimiento 
				
			item.NPrecioAnteriorEnvase = NPrecioAnteriorEnvase 
				
			item.NPrecioActualEnvase = NPrecioActualEnvase 
				
			item.BEstadoLote = BEstadoLote 
				
			item.NTotalEnvases = NTotalEnvases 
				
			item.NTotalSueltos = NTotalSueltos 
				
			item.CObservaciones = CObservaciones 
				
			item.NCostoUnidad = NCostoUnidad 
				
			item.CTipo = CTipo 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
