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
    ''' Controller class for EJS_Sucursal
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class SucursalController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Sucursal = New Sucursal()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As SucursalCollection
        
            Dim coll As SucursalCollection = New SucursalCollection()
            Dim qry As Query = New Query(Sucursal.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodSucursal As Object) As SucursalCollection 
        
            Dim coll As SucursalCollection = New SucursalCollection().Where("nCodSucursal", NCodSucursal).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As SucursalCollection 
        
            Dim coll As SucursalCollection = New SucursalCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodSucursal As Object) as Boolean
        
            Return (Sucursal.Delete(NCodSucursal) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodSucursal As Object) as Boolean
        
            Return (Sucursal.Destroy(NCodSucursal) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodSucursal As Integer,ByVal NCodRegion As Nullable(Of Integer),ByVal CZona As String,ByVal CDireccion As String,ByVal BCasaMatriz As Boolean)
	   
		    Dim item As Sucursal = New Sucursal()
		    
            item.NCodSucursal = NCodSucursal
            
            item.NCodRegion = NCodRegion
            
            item.CZona = CZona
            
            item.CDireccion = CDireccion
            
            item.BCasaMatriz = BCasaMatriz
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodSucursal As Integer,ByVal NCodRegion As Nullable(Of Integer),ByVal CZona As String,ByVal CDireccion As String,ByVal BCasaMatriz As Boolean)
	    
		    Dim item As Sucursal = New Sucursal()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodSucursal = NCodSucursal 
				
			item.NCodRegion = NCodRegion 
				
			item.CZona = CZona 
				
			item.CDireccion = CDireccion 
				
			item.BCasaMatriz = BCasaMatriz 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
