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
    ''' Controller class for EJS_OrdenCompra
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class OrdenCompraController
    
        ' Preload our schema..
        Dim thisSchemaLoad As OrdenCompra = New OrdenCompra()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As OrdenCompraCollection
        
            Dim coll As OrdenCompraCollection = New OrdenCompraCollection()
            Dim qry As Query = New Query(OrdenCompra.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodPedido As Object) As OrdenCompraCollection 
        
            Dim coll As OrdenCompraCollection = New OrdenCompraCollection().Where("nCodPedido", NCodPedido).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As OrdenCompraCollection 
        
            Dim coll As OrdenCompraCollection = New OrdenCompraCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodPedido As Object) as Boolean
        
            Return (OrdenCompra.Delete(NCodPedido) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodPedido As Object) as Boolean
        
            Return (OrdenCompra.Destroy(NCodPedido) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodPedido As Integer,ByVal CNit As String,ByVal CNumeroOC As String,ByVal DFechaEntrega As DateTime,ByVal NFacturaAsociada As Integer,ByVal BEntregado As Boolean,ByVal BNotaDebito As Boolean,ByVal NCodSucursal As Integer,ByVal BAnulado As Nullable(Of Boolean),ByVal DFechaSolicitud As String,ByVal BNotaCredito As Nullable(Of Boolean),ByVal NCodCliente As Integer,ByVal NCodVendedor As Nullable(Of Integer),ByVal NCodBeneficiario As Nullable(Of Integer),ByVal CFirmaCliente As String,ByVal CEstadoEnvio As String,ByVal BEsPedido As Nullable(Of Boolean),ByVal BEsOC As Nullable(Of Boolean))
	   
		    Dim item As OrdenCompra = New OrdenCompra()
		    
            item.NCodPedido = NCodPedido
            
            item.CNit = CNit
            
            item.CNumeroOC = CNumeroOC
            
            item.DFechaEntrega = DFechaEntrega
            
            item.NFacturaAsociada = NFacturaAsociada
            
            item.BEntregado = BEntregado
            
            item.BNotaDebito = BNotaDebito
            
            item.NCodSucursal = NCodSucursal
            
            item.BAnulado = BAnulado
            
            item.DFechaSolicitud = DFechaSolicitud
            
            item.BNotaCredito = BNotaCredito
            
            item.NCodCliente = NCodCliente
            
            item.NCodVendedor = NCodVendedor
            
            item.NCodBeneficiario = NCodBeneficiario
            
            item.CFirmaCliente = CFirmaCliente
            
            item.CEstadoEnvio = CEstadoEnvio
            
            item.BEsPedido = BEsPedido
            
            item.BEsOC = BEsOC
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodPedido As Integer,ByVal CNit As String,ByVal CNumeroOC As String,ByVal DFechaEntrega As DateTime,ByVal NFacturaAsociada As Integer,ByVal BEntregado As Boolean,ByVal BNotaDebito As Boolean,ByVal NCodSucursal As Integer,ByVal BAnulado As Nullable(Of Boolean),ByVal DFechaSolicitud As String,ByVal BNotaCredito As Nullable(Of Boolean),ByVal NCodCliente As Integer,ByVal NCodVendedor As Nullable(Of Integer),ByVal NCodBeneficiario As Nullable(Of Integer),ByVal CFirmaCliente As String,ByVal CEstadoEnvio As String,ByVal BEsPedido As Nullable(Of Boolean),ByVal BEsOC As Nullable(Of Boolean))
	    
		    Dim item As OrdenCompra = New OrdenCompra()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodPedido = NCodPedido 
				
			item.CNit = CNit 
				
			item.CNumeroOC = CNumeroOC 
				
			item.DFechaEntrega = DFechaEntrega 
				
			item.NFacturaAsociada = NFacturaAsociada 
				
			item.BEntregado = BEntregado 
				
			item.BNotaDebito = BNotaDebito 
				
			item.NCodSucursal = NCodSucursal 
				
			item.BAnulado = BAnulado 
				
			item.DFechaSolicitud = DFechaSolicitud 
				
			item.BNotaCredito = BNotaCredito 
				
			item.NCodCliente = NCodCliente 
				
			item.NCodVendedor = NCodVendedor 
				
			item.NCodBeneficiario = NCodBeneficiario 
				
			item.CFirmaCliente = CFirmaCliente 
				
			item.CEstadoEnvio = CEstadoEnvio 
				
			item.BEsPedido = BEsPedido 
				
			item.BEsOC = BEsOC 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
