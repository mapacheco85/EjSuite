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
    ''' Controller class for EJS_Almacen
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class AlmacenController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Almacen = New Almacen()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As AlmacenCollection
        
            Dim coll As AlmacenCollection = New AlmacenCollection()
            Dim qry As Query = New Query(Almacen.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodAlmacen As Object) As AlmacenCollection 
        
            Dim coll As AlmacenCollection = New AlmacenCollection().Where("nCodAlmacen", NCodAlmacen).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As AlmacenCollection 
        
            Dim coll As AlmacenCollection = New AlmacenCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodAlmacen As Object) as Boolean
        
            Return (Almacen.Delete(NCodAlmacen) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodAlmacen As Object) as Boolean
        
            Return (Almacen.Destroy(NCodAlmacen) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodAlmacen As Integer,ByVal NCodSucursal As Nullable(Of Integer),ByVal NCodJefeAlmacen As Nullable(Of Integer),ByVal CCapacidad As String)
	   
		    Dim item As Almacen = New Almacen()
		    
            item.NCodAlmacen = NCodAlmacen
            
            item.NCodSucursal = NCodSucursal
            
            item.NCodJefeAlmacen = NCodJefeAlmacen
            
            item.CCapacidad = CCapacidad
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodAlmacen As Integer,ByVal NCodSucursal As Nullable(Of Integer),ByVal NCodJefeAlmacen As Nullable(Of Integer),ByVal CCapacidad As String)
	    
		    Dim item As Almacen = New Almacen()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodAlmacen = NCodAlmacen 
				
			item.NCodSucursal = NCodSucursal 
				
			item.NCodJefeAlmacen = NCodJefeAlmacen 
				
			item.CCapacidad = CCapacidad 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
