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
    ''' Controller class for EJS_Marca
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class MarcaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Marca = New Marca()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As MarcaCollection
        
            Dim coll As MarcaCollection = New MarcaCollection()
            Dim qry As Query = New Query(Marca.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodMarca As Object) As MarcaCollection 
        
            Dim coll As MarcaCollection = New MarcaCollection().Where("nCodMarca", NCodMarca).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As MarcaCollection 
        
            Dim coll As MarcaCollection = New MarcaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodMarca As Object) as Boolean
        
            Return (Marca.Delete(NCodMarca) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodMarca As Object) as Boolean
        
            Return (Marca.Destroy(NCodMarca) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodMarca As Integer,ByVal NCodProveedor As Nullable(Of Integer),ByVal CEmpresa As String,ByVal CDireccion As String)
	   
		    Dim item As Marca = New Marca()
		    
            item.NCodMarca = NCodMarca
            
            item.NCodProveedor = NCodProveedor
            
            item.CEmpresa = CEmpresa
            
            item.CDireccion = CDireccion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodMarca As Integer,ByVal NCodProveedor As Nullable(Of Integer),ByVal CEmpresa As String,ByVal CDireccion As String)
	    
		    Dim item As Marca = New Marca()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodMarca = NCodMarca 
				
			item.NCodProveedor = NCodProveedor 
				
			item.CEmpresa = CEmpresa 
				
			item.CDireccion = CDireccion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
