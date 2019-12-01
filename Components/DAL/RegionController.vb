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
    ''' Controller class for EJS_Region
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class RegionController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Region = New Region()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As RegionCollection
        
            Dim coll As RegionCollection = New RegionCollection()
            Dim qry As Query = New Query(Region.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodRegion As Object) As RegionCollection 
        
            Dim coll As RegionCollection = New RegionCollection().Where("nCodRegion", NCodRegion).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As RegionCollection 
        
            Dim coll As RegionCollection = New RegionCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodRegion As Object) as Boolean
        
            Return (Region.Delete(NCodRegion) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodRegion As Object) as Boolean
        
            Return (Region.Destroy(NCodRegion) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodRegion As Integer,ByVal CLugar As String)
	   
		    Dim item As Region = New Region()
		    
            item.NCodRegion = NCodRegion
            
            item.CLugar = CLugar
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodRegion As Integer,ByVal CLugar As String)
	    
		    Dim item As Region = New Region()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodRegion = NCodRegion 
				
			item.CLugar = CLugar 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
