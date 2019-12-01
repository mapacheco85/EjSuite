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
    ''' Controller class for EJS_ListadoProducto
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ListadoProductoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As ListadoProducto = New ListadoProducto()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ListadoProductoCollection
        
            Dim coll As ListadoProductoCollection = New ListadoProductoCollection()
            Dim qry As Query = New Query(ListadoProducto.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodListado As Object) As ListadoProductoCollection 
        
            Dim coll As ListadoProductoCollection = New ListadoProductoCollection().Where("nCodListado", NCodListado).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ListadoProductoCollection 
        
            Dim coll As ListadoProductoCollection = New ListadoProductoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodListado As Object) as Boolean
        
            Return (ListadoProducto.Delete(NCodListado) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodListado As Object) as Boolean
        
            Return (ListadoProducto.Destroy(NCodListado) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodListado As Integer,ByVal NCodProducto As String,ByVal NCodGrupo As Nullable(Of Integer),ByVal ProNCodProducto As Nullable(Of Integer),ByVal DFechaReg As Nullable(Of DateTime),ByVal BVigente As Nullable(Of Boolean))
	   
		    Dim item As ListadoProducto = New ListadoProducto()
		    
            item.NCodListado = NCodListado
            
            item.NCodProducto = NCodProducto
            
            item.NCodGrupo = NCodGrupo
            
            item.ProNCodProducto = ProNCodProducto
            
            item.DFechaReg = DFechaReg
            
            item.BVigente = BVigente
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodListado As Integer,ByVal NCodProducto As String,ByVal NCodGrupo As Nullable(Of Integer),ByVal ProNCodProducto As Nullable(Of Integer),ByVal DFechaReg As Nullable(Of DateTime),ByVal BVigente As Nullable(Of Boolean))
	    
		    Dim item As ListadoProducto = New ListadoProducto()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodListado = NCodListado 
				
			item.NCodProducto = NCodProducto 
				
			item.NCodGrupo = NCodGrupo 
				
			item.ProNCodProducto = ProNCodProducto 
				
			item.DFechaReg = DFechaReg 
				
			item.BVigente = BVigente 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
