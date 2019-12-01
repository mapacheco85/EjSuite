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
    ''' Controller class for EJS_OrdenCompraDetalle
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class OrdenCompraDetalleController
    
        ' Preload our schema..
        Dim thisSchemaLoad As OrdenCompraDetalle = New OrdenCompraDetalle()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As OrdenCompraDetalleCollection
        
            Dim coll As OrdenCompraDetalleCollection = New OrdenCompraDetalleCollection()
            Dim qry As Query = New Query(OrdenCompraDetalle.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodPedidoDetalle As Object) As OrdenCompraDetalleCollection 
        
            Dim coll As OrdenCompraDetalleCollection = New OrdenCompraDetalleCollection().Where("nCodPedidoDetalle", NCodPedidoDetalle).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As OrdenCompraDetalleCollection 
        
            Dim coll As OrdenCompraDetalleCollection = New OrdenCompraDetalleCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodPedidoDetalle As Object) as Boolean
        
            Return (OrdenCompraDetalle.Delete(NCodPedidoDetalle) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodPedidoDetalle As Object) as Boolean
        
            Return (OrdenCompraDetalle.Destroy(NCodPedidoDetalle) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodPedidoDetalle As Integer,ByVal NCodPedido As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal NDescuento As Decimal)
	   
		    Dim item As OrdenCompraDetalle = New OrdenCompraDetalle()
		    
            item.NCodPedidoDetalle = NCodPedidoDetalle
            
            item.NCodPedido = NCodPedido
            
            item.NCodProducto = NCodProducto
            
            item.NCantidad = NCantidad
            
            item.NPrecioUnitario = NPrecioUnitario
            
            item.NDescuento = NDescuento
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodPedidoDetalle As Integer,ByVal NCodPedido As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal NDescuento As Decimal)
	    
		    Dim item As OrdenCompraDetalle = New OrdenCompraDetalle()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodPedidoDetalle = NCodPedidoDetalle 
				
			item.NCodPedido = NCodPedido 
				
			item.NCodProducto = NCodProducto 
				
			item.NCantidad = NCantidad 
				
			item.NPrecioUnitario = NPrecioUnitario 
				
			item.NDescuento = NDescuento 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
