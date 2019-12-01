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
    ''' Controller class for EJS_Leyenda
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class LeyendaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Leyenda = New Leyenda()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As LeyendaCollection
        
            Dim coll As LeyendaCollection = New LeyendaCollection()
            Dim qry As Query = New Query(Leyenda.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodLeyenda As Object) As LeyendaCollection 
        
            Dim coll As LeyendaCollection = New LeyendaCollection().Where("nCodLeyenda", NCodLeyenda).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As LeyendaCollection 
        
            Dim coll As LeyendaCollection = New LeyendaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodLeyenda As Object) as Boolean
        
            Return (Leyenda.Delete(NCodLeyenda) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodLeyenda As Object) as Boolean
        
            Return (Leyenda.Destroy(NCodLeyenda) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodLeyenda As Integer,ByVal CNormativa As String,ByVal CTipo As String)
	   
		    Dim item As Leyenda = New Leyenda()
		    
            item.NCodLeyenda = NCodLeyenda
            
            item.CNormativa = CNormativa
            
            item.CTipo = CTipo
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodLeyenda As Integer,ByVal CNormativa As String,ByVal CTipo As String)
	    
		    Dim item As Leyenda = New Leyenda()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodLeyenda = NCodLeyenda 
				
			item.CNormativa = CNormativa 
				
			item.CTipo = CTipo 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
