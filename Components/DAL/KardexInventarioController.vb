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
    ''' Controller class for EJS_KardexInventario
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class KardexInventarioController
    
        ' Preload our schema..
        Dim thisSchemaLoad As KardexInventario = New KardexInventario()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As KardexInventarioCollection
        
            Dim coll As KardexInventarioCollection = New KardexInventarioCollection()
            Dim qry As Query = New Query(KardexInventario.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodKardex As Object) As KardexInventarioCollection 
        
            Dim coll As KardexInventarioCollection = New KardexInventarioCollection().Where("nCodKardex", NCodKardex).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As KardexInventarioCollection 
        
            Dim coll As KardexInventarioCollection = New KardexInventarioCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodKardex As Object) as Boolean
        
            Return (KardexInventario.Delete(NCodKardex) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodKardex As Object) as Boolean
        
            Return (KardexInventario.Destroy(NCodKardex) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodKardex As Integer,ByVal NCodAlmacen As Nullable(Of Integer),ByVal NCodLote As Nullable(Of Integer),ByVal NCodProducto As Nullable(Of Integer),ByVal DFechareg As DateTime,ByVal CObservacion As String,ByVal NPrecioCompra As Decimal,ByVal NEntrada As Integer,ByVal NSalida As Integer,ByVal NEntradaSueltos As Integer,ByVal NSalidaSueltos As Integer,ByVal NStockAnteriorEnvase As Integer,ByVal NStockActualEnvase As Integer,ByVal NStockAnteriorSuelto As Integer,ByVal NStockActualSuelto As Integer,ByVal NCostoTotal As Decimal,ByVal CGlosa As String,ByVal NPrecioAlmacen As Decimal,ByVal NPrecioVenta As Decimal,ByVal NEntradaBonificacion As Nullable(Of Integer),ByVal NSalidaBonificacion As Nullable(Of Integer),ByVal NEntradaReintegro As Nullable(Of Integer),ByVal NSalidaReintegro As Nullable(Of Integer),ByVal NStockAnteriorBonificacion As Nullable(Of Integer),ByVal NStockActualBonificacion As Nullable(Of Integer),ByVal NStockAnteriorReintegro As Nullable(Of Integer),ByVal NStockActualReintegro As Nullable(Of Integer))
	   
		    Dim item As KardexInventario = New KardexInventario()
		    
            item.NCodKardex = NCodKardex
            
            item.NCodAlmacen = NCodAlmacen
            
            item.NCodLote = NCodLote
            
            item.NCodProducto = NCodProducto
            
            item.DFechareg = DFechareg
            
            item.CObservacion = CObservacion
            
            item.NPrecioCompra = NPrecioCompra
            
            item.NEntrada = NEntrada
            
            item.NSalida = NSalida
            
            item.NEntradaSueltos = NEntradaSueltos
            
            item.NSalidaSueltos = NSalidaSueltos
            
            item.NStockAnteriorEnvase = NStockAnteriorEnvase
            
            item.NStockActualEnvase = NStockActualEnvase
            
            item.NStockAnteriorSuelto = NStockAnteriorSuelto
            
            item.NStockActualSuelto = NStockActualSuelto
            
            item.NCostoTotal = NCostoTotal
            
            item.CGlosa = CGlosa
            
            item.NPrecioAlmacen = NPrecioAlmacen
            
            item.NPrecioVenta = NPrecioVenta
            
            item.NEntradaBonificacion = NEntradaBonificacion
            
            item.NSalidaBonificacion = NSalidaBonificacion
            
            item.NEntradaReintegro = NEntradaReintegro
            
            item.NSalidaReintegro = NSalidaReintegro
            
            item.NStockAnteriorBonificacion = NStockAnteriorBonificacion
            
            item.NStockActualBonificacion = NStockActualBonificacion
            
            item.NStockAnteriorReintegro = NStockAnteriorReintegro
            
            item.NStockActualReintegro = NStockActualReintegro
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodKardex As Integer,ByVal NCodAlmacen As Nullable(Of Integer),ByVal NCodLote As Nullable(Of Integer),ByVal NCodProducto As Nullable(Of Integer),ByVal DFechareg As DateTime,ByVal CObservacion As String,ByVal NPrecioCompra As Decimal,ByVal NEntrada As Integer,ByVal NSalida As Integer,ByVal NEntradaSueltos As Integer,ByVal NSalidaSueltos As Integer,ByVal NStockAnteriorEnvase As Integer,ByVal NStockActualEnvase As Integer,ByVal NStockAnteriorSuelto As Integer,ByVal NStockActualSuelto As Integer,ByVal NCostoTotal As Decimal,ByVal CGlosa As String,ByVal NPrecioAlmacen As Decimal,ByVal NPrecioVenta As Decimal,ByVal NEntradaBonificacion As Nullable(Of Integer),ByVal NSalidaBonificacion As Nullable(Of Integer),ByVal NEntradaReintegro As Nullable(Of Integer),ByVal NSalidaReintegro As Nullable(Of Integer),ByVal NStockAnteriorBonificacion As Nullable(Of Integer),ByVal NStockActualBonificacion As Nullable(Of Integer),ByVal NStockAnteriorReintegro As Nullable(Of Integer),ByVal NStockActualReintegro As Nullable(Of Integer))
	    
		    Dim item As KardexInventario = New KardexInventario()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodKardex = NCodKardex 
				
			item.NCodAlmacen = NCodAlmacen 
				
			item.NCodLote = NCodLote 
				
			item.NCodProducto = NCodProducto 
				
			item.DFechareg = DFechareg 
				
			item.CObservacion = CObservacion 
				
			item.NPrecioCompra = NPrecioCompra 
				
			item.NEntrada = NEntrada 
				
			item.NSalida = NSalida 
				
			item.NEntradaSueltos = NEntradaSueltos 
				
			item.NSalidaSueltos = NSalidaSueltos 
				
			item.NStockAnteriorEnvase = NStockAnteriorEnvase 
				
			item.NStockActualEnvase = NStockActualEnvase 
				
			item.NStockAnteriorSuelto = NStockAnteriorSuelto 
				
			item.NStockActualSuelto = NStockActualSuelto 
				
			item.NCostoTotal = NCostoTotal 
				
			item.CGlosa = CGlosa 
				
			item.NPrecioAlmacen = NPrecioAlmacen 
				
			item.NPrecioVenta = NPrecioVenta 
				
			item.NEntradaBonificacion = NEntradaBonificacion 
				
			item.NSalidaBonificacion = NSalidaBonificacion 
				
			item.NEntradaReintegro = NEntradaReintegro 
				
			item.NSalidaReintegro = NSalidaReintegro 
				
			item.NStockAnteriorBonificacion = NStockAnteriorBonificacion 
				
			item.NStockActualBonificacion = NStockActualBonificacion 
				
			item.NStockAnteriorReintegro = NStockAnteriorReintegro 
				
			item.NStockActualReintegro = NStockActualReintegro 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
