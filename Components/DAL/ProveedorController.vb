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
    ''' Controller class for EJS_Proveedor
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ProveedorController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Proveedor = New Proveedor()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ProveedorCollection
        
            Dim coll As ProveedorCollection = New ProveedorCollection()
            Dim qry As Query = New Query(Proveedor.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodProveedor As Object) As ProveedorCollection 
        
            Dim coll As ProveedorCollection = New ProveedorCollection().Where("nCodProveedor", NCodProveedor).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ProveedorCollection 
        
            Dim coll As ProveedorCollection = New ProveedorCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodProveedor As Object) as Boolean
        
            Return (Proveedor.Delete(NCodProveedor) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodProveedor As Object) as Boolean
        
            Return (Proveedor.Destroy(NCodProveedor) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodProveedor As Integer,ByVal CNombre As String,ByVal CDireccion As String,ByVal CRepresentante As String,ByVal CTelefono As String,ByVal CTelefono2 As String,ByVal CCelular As String,ByVal CEmail As String)
	   
		    Dim item As Proveedor = New Proveedor()
		    
            item.NCodProveedor = NCodProveedor
            
            item.CNombre = CNombre
            
            item.CDireccion = CDireccion
            
            item.CRepresentante = CRepresentante
            
            item.CTelefono = CTelefono
            
            item.CTelefono2 = CTelefono2
            
            item.CCelular = CCelular
            
            item.CEmail = CEmail
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodProveedor As Integer,ByVal CNombre As String,ByVal CDireccion As String,ByVal CRepresentante As String,ByVal CTelefono As String,ByVal CTelefono2 As String,ByVal CCelular As String,ByVal CEmail As String)
	    
		    Dim item As Proveedor = New Proveedor()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodProveedor = NCodProveedor 
				
			item.CNombre = CNombre 
				
			item.CDireccion = CDireccion 
				
			item.CRepresentante = CRepresentante 
				
			item.CTelefono = CTelefono 
				
			item.CTelefono2 = CTelefono2 
				
			item.CCelular = CCelular 
				
			item.CEmail = CEmail 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
