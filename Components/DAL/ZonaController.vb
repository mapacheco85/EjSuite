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
    ''' Controller class for EJS_Zonas
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ZonaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Zona = New Zona()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ZonaCollection
        
            Dim coll As ZonaCollection = New ZonaCollection()
            Dim qry As Query = New Query(Zona.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodUnidad As Object) As ZonaCollection 
        
            Dim coll As ZonaCollection = New ZonaCollection().Where("nCodUnidad", NCodUnidad).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ZonaCollection 
        
            Dim coll As ZonaCollection = New ZonaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodUnidad As Object) as Boolean
        
            Return (Zona.Delete(NCodUnidad) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodUnidad As Object) as Boolean
        
            Return (Zona.Destroy(NCodUnidad) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodUnidad As Integer,ByVal CDescripcion As String)
	   
		    Dim item As Zona = New Zona()
		    
            item.NCodUnidad = NCodUnidad
            
            item.CDescripcion = CDescripcion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodUnidad As Integer,ByVal CDescripcion As String)
	    
		    Dim item As Zona = New Zona()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodUnidad = NCodUnidad 
				
			item.CDescripcion = CDescripcion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
