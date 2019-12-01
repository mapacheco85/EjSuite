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
    ''' Controller class for EJS_CotizacionDetalle
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class CotizacionDetalleController
    
        ' Preload our schema..
        Dim thisSchemaLoad As CotizacionDetalle = New CotizacionDetalle()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As CotizacionDetalleCollection
        
            Dim coll As CotizacionDetalleCollection = New CotizacionDetalleCollection()
            Dim qry As Query = New Query(CotizacionDetalle.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodCotizacionDetalle As Object) As CotizacionDetalleCollection 
        
            Dim coll As CotizacionDetalleCollection = New CotizacionDetalleCollection().Where("nCodCotizacionDetalle", NCodCotizacionDetalle).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As CotizacionDetalleCollection 
        
            Dim coll As CotizacionDetalleCollection = New CotizacionDetalleCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodCotizacionDetalle As Object) as Boolean
        
            Return (CotizacionDetalle.Delete(NCodCotizacionDetalle) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodCotizacionDetalle As Object) as Boolean
        
            Return (CotizacionDetalle.Destroy(NCodCotizacionDetalle) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodCotizacionDetalle As Integer,ByVal NCodCotizacion As Integer,ByVal NCodProducto As Integer,ByVal NPrecioUnitario As Decimal,ByVal NCantidad As Integer,ByVal NDescuento As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCien As Boolean,ByVal BMil As Boolean)
	   
		    Dim item As CotizacionDetalle = New CotizacionDetalle()
		    
            item.NCodCotizacionDetalle = NCodCotizacionDetalle
            
            item.NCodCotizacion = NCodCotizacion
            
            item.NCodProducto = NCodProducto
            
            item.NPrecioUnitario = NPrecioUnitario
            
            item.NCantidad = NCantidad
            
            item.NDescuento = NDescuento
            
            item.BUnidad = BUnidad
            
            item.BDocena = BDocena
            
            item.BCien = BCien
            
            item.BMil = BMil
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodCotizacionDetalle As Integer,ByVal NCodCotizacion As Integer,ByVal NCodProducto As Integer,ByVal NPrecioUnitario As Decimal,ByVal NCantidad As Integer,ByVal NDescuento As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCien As Boolean,ByVal BMil As Boolean)
	    
		    Dim item As CotizacionDetalle = New CotizacionDetalle()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodCotizacionDetalle = NCodCotizacionDetalle 
				
			item.NCodCotizacion = NCodCotizacion 
				
			item.NCodProducto = NCodProducto 
				
			item.NPrecioUnitario = NPrecioUnitario 
				
			item.NCantidad = NCantidad 
				
			item.NDescuento = NDescuento 
				
			item.BUnidad = BUnidad 
				
			item.BDocena = BDocena 
				
			item.BCien = BCien 
				
			item.BMil = BMil 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
