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
    ''' Controller class for EJS_Producto
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ProductoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Producto = New Producto()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ProductoCollection
        
            Dim coll As ProductoCollection = New ProductoCollection()
            Dim qry As Query = New Query(Producto.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodProducto As Object) As ProductoCollection 
        
            Dim coll As ProductoCollection = New ProductoCollection().Where("nCodProducto", NCodProducto).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ProductoCollection 
        
            Dim coll As ProductoCollection = New ProductoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodProducto As Object) as Boolean
        
            Return (Producto.Delete(NCodProducto) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodProducto As Object) as Boolean
        
            Return (Producto.Destroy(NCodProducto) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodProducto As Integer,ByVal CCodProducto As String,ByVal NCodProveedor As Nullable(Of Integer),ByVal NCodMarca As Nullable(Of Integer),ByVal NCodGrupo As Nullable(Of Integer),ByVal CNombreGenerico As String,ByVal CNombreComercial As String,ByVal CDetalles As String,ByVal NPrecioCompra As Decimal,ByVal CUnUna As String,ByVal CContiene As String,ByVal CTipoElementos As String,ByVal CMedidad As String,ByVal CUnidad As String,ByVal BSueltos As Boolean,ByVal NMontoVentaEnvase As Decimal,ByVal NMontoVentaIndividual As Nullable(Of Decimal),ByVal NPromocion As Nullable(Of Decimal),ByVal NStockMinimo As Nullable(Of Decimal),ByVal NStockMaximo As Nullable(Of Decimal),ByVal BVigente As Boolean,ByVal CCompuesto As String)
	   
		    Dim item As Producto = New Producto()
		    
            item.NCodProducto = NCodProducto
            
            item.CCodProducto = CCodProducto
            
            item.NCodProveedor = NCodProveedor
            
            item.NCodMarca = NCodMarca
            
            item.NCodGrupo = NCodGrupo
            
            item.CNombreGenerico = CNombreGenerico
            
            item.CNombreComercial = CNombreComercial
            
            item.CDetalles = CDetalles
            
            item.NPrecioCompra = NPrecioCompra
            
            item.CUnUna = CUnUna
            
            item.CContiene = CContiene
            
            item.CTipoElementos = CTipoElementos
            
            item.CMedidad = CMedidad
            
            item.CUnidad = CUnidad
            
            item.BSueltos = BSueltos
            
            item.NMontoVentaEnvase = NMontoVentaEnvase
            
            item.NMontoVentaIndividual = NMontoVentaIndividual
            
            item.NPromocion = NPromocion
            
            item.NStockMinimo = NStockMinimo
            
            item.NStockMaximo = NStockMaximo
            
            item.BVigente = BVigente
            
            item.CCompuesto = CCompuesto
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodProducto As Integer,ByVal CCodProducto As String,ByVal NCodProveedor As Nullable(Of Integer),ByVal NCodMarca As Nullable(Of Integer),ByVal NCodGrupo As Nullable(Of Integer),ByVal CNombreGenerico As String,ByVal CNombreComercial As String,ByVal CDetalles As String,ByVal NPrecioCompra As Decimal,ByVal CUnUna As String,ByVal CContiene As String,ByVal CTipoElementos As String,ByVal CMedidad As String,ByVal CUnidad As String,ByVal BSueltos As Boolean,ByVal NMontoVentaEnvase As Decimal,ByVal NMontoVentaIndividual As Nullable(Of Decimal),ByVal NPromocion As Nullable(Of Decimal),ByVal NStockMinimo As Nullable(Of Decimal),ByVal NStockMaximo As Nullable(Of Decimal),ByVal BVigente As Boolean,ByVal CCompuesto As String)
	    
		    Dim item As Producto = New Producto()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodProducto = NCodProducto 
				
			item.CCodProducto = CCodProducto 
				
			item.NCodProveedor = NCodProveedor 
				
			item.NCodMarca = NCodMarca 
				
			item.NCodGrupo = NCodGrupo 
				
			item.CNombreGenerico = CNombreGenerico 
				
			item.CNombreComercial = CNombreComercial 
				
			item.CDetalles = CDetalles 
				
			item.NPrecioCompra = NPrecioCompra 
				
			item.CUnUna = CUnUna 
				
			item.CContiene = CContiene 
				
			item.CTipoElementos = CTipoElementos 
				
			item.CMedidad = CMedidad 
				
			item.CUnidad = CUnidad 
				
			item.BSueltos = BSueltos 
				
			item.NMontoVentaEnvase = NMontoVentaEnvase 
				
			item.NMontoVentaIndividual = NMontoVentaIndividual 
				
			item.NPromocion = NPromocion 
				
			item.NStockMinimo = NStockMinimo 
				
			item.NStockMaximo = NStockMaximo 
				
			item.BVigente = BVigente 
				
			item.CCompuesto = CCompuesto 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
