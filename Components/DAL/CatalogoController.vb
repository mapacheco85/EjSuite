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
    ''' Controller class for EJS_Catalogo
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class CatalogoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Catalogo = New Catalogo()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As CatalogoCollection
        
            Dim coll As CatalogoCollection = New CatalogoCollection()
            Dim qry As Query = New Query(Catalogo.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodCatalogo As Object) As CatalogoCollection 
        
            Dim coll As CatalogoCollection = New CatalogoCollection().Where("nCodCatalogo", NCodCatalogo).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As CatalogoCollection 
        
            Dim coll As CatalogoCollection = New CatalogoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodCatalogo As Object) as Boolean
        
            Return (Catalogo.Delete(NCodCatalogo) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodCatalogo As Object) as Boolean
        
            Return (Catalogo.Destroy(NCodCatalogo) = 1)
        
        End Function
        
       
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodCatalogo As Integer,ByVal CCodCatalogo As String) as Boolean
            Dim qry As Query = new Query(Catalogo.Schema)
            qry.QueryType = QueryType.Delete
            qry.AddWhere("NCodCatalogo", NCodCatalogo).AND("CCodCatalogo", CCodCatalogo)
            qry.Execute()
            Return true
        End Function
       
    	
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodCatalogo As Integer,ByVal CValorCatalogo As String,ByVal CCodCatalogo As String,ByVal BVigente As Boolean,ByVal NDependeDe As Nullable(Of Integer))
	   
		    Dim item As Catalogo = New Catalogo()
		    
            item.NCodCatalogo = NCodCatalogo
            
            item.CValorCatalogo = CValorCatalogo
            
            item.CCodCatalogo = CCodCatalogo
            
            item.BVigente = BVigente
            
            item.NDependeDe = NDependeDe
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodCatalogo As Integer,ByVal CValorCatalogo As String,ByVal CCodCatalogo As String,ByVal BVigente As Boolean,ByVal NDependeDe As Nullable(Of Integer))
	    
		    Dim item As Catalogo = New Catalogo()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodCatalogo = NCodCatalogo 
				
			item.CValorCatalogo = CValorCatalogo 
				
			item.CCodCatalogo = CCodCatalogo 
				
			item.BVigente = BVigente 
				
			item.NDependeDe = NDependeDe 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
