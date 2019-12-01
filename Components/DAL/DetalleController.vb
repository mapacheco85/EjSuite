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
    ''' Controller class for EJS_Detalle
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class DetalleController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Detalle = New Detalle()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As DetalleCollection
        
            Dim coll As DetalleCollection = New DetalleCollection()
            Dim qry As Query = New Query(Detalle.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodDetalle As Object) As DetalleCollection 
        
            Dim coll As DetalleCollection = New DetalleCollection().Where("nCodDetalle", NCodDetalle).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As DetalleCollection 
        
            Dim coll As DetalleCollection = New DetalleCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodDetalle As Object) as Boolean
        
            Return (Detalle.Delete(NCodDetalle) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodDetalle As Object) as Boolean
        
            Return (Detalle.Destroy(NCodDetalle) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodDetalle As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NcodFactura As Long,ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal NDescuento As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCien As Boolean,ByVal BMil As Boolean)
	   
		    Dim item As Detalle = New Detalle()
		    
            item.NCodDetalle = NCodDetalle
            
            item.NCodProducto = NCodProducto
            
            item.NcodFactura = NcodFactura
            
            item.NCantidad = NCantidad
            
            item.NPrecioUnitario = NPrecioUnitario
            
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
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodDetalle As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NcodFactura As Long,ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal NDescuento As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCien As Boolean,ByVal BMil As Boolean)
	    
		    Dim item As Detalle = New Detalle()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodDetalle = NCodDetalle 
				
			item.NCodProducto = NCodProducto 
				
			item.NcodFactura = NcodFactura 
				
			item.NCantidad = NCantidad 
				
			item.NPrecioUnitario = NPrecioUnitario 
				
			item.NDescuento = NDescuento 
				
			item.BUnidad = BUnidad 
				
			item.BDocena = BDocena 
				
			item.BCien = BCien 
				
			item.BMil = BMil 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
