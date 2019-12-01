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
    ''' Controller class for EJS_Zonas1
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class Zonas1Controller
    
        ' Preload our schema..
        Dim thisSchemaLoad As Zonas1 = New Zonas1()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As Zonas1Collection
        
            Dim coll As Zonas1Collection = New Zonas1Collection()
            Dim qry As Query = New Query(Zonas1.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodZonaDetalle As Object) As Zonas1Collection 
        
            Dim coll As Zonas1Collection = New Zonas1Collection().Where("nCodZonaDetalle", NCodZonaDetalle).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As Zonas1Collection 
        
            Dim coll As Zonas1Collection = New Zonas1Collection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodZonaDetalle As Object) as Boolean
        
            Return (Zonas1.Delete(NCodZonaDetalle) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodZonaDetalle As Object) as Boolean
        
            Return (Zonas1.Destroy(NCodZonaDetalle) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodZonaDetalle As Integer,ByVal NCodUsuario As Decimal,ByVal NCodUnidad As Integer,ByVal CDescripcion As String)
	   
		    Dim item As Zonas1 = New Zonas1()
		    
            item.NCodZonaDetalle = NCodZonaDetalle
            
            item.NCodUsuario = NCodUsuario
            
            item.NCodUnidad = NCodUnidad
            
            item.CDescripcion = CDescripcion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodZonaDetalle As Integer,ByVal NCodUsuario As Decimal,ByVal NCodUnidad As Integer,ByVal CDescripcion As String)
	    
		    Dim item As Zonas1 = New Zonas1()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodZonaDetalle = NCodZonaDetalle 
				
			item.NCodUsuario = NCodUsuario 
				
			item.NCodUnidad = NCodUnidad 
				
			item.CDescripcion = CDescripcion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
