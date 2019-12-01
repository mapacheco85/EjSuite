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
    ''' Controller class for EJS_GrupoProducto
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class GrupoProductoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As GrupoProducto = New GrupoProducto()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As GrupoProductoCollection
        
            Dim coll As GrupoProductoCollection = New GrupoProductoCollection()
            Dim qry As Query = New Query(GrupoProducto.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodGrupo As Object) As GrupoProductoCollection 
        
            Dim coll As GrupoProductoCollection = New GrupoProductoCollection().Where("nCodGrupo", NCodGrupo).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As GrupoProductoCollection 
        
            Dim coll As GrupoProductoCollection = New GrupoProductoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodGrupo As Object) as Boolean
        
            Return (GrupoProducto.Delete(NCodGrupo) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodGrupo As Object) as Boolean
        
            Return (GrupoProducto.Destroy(NCodGrupo) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodGrupo As Integer,ByVal CGrupoProducto As String,ByVal CSigla As String)
	   
		    Dim item As GrupoProducto = New GrupoProducto()
		    
            item.NCodGrupo = NCodGrupo
            
            item.CGrupoProducto = CGrupoProducto
            
            item.CSigla = CSigla
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodGrupo As Integer,ByVal CGrupoProducto As String,ByVal CSigla As String)
	    
		    Dim item As GrupoProducto = New GrupoProducto()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodGrupo = NCodGrupo 
				
			item.CGrupoProducto = CGrupoProducto 
				
			item.CSigla = CSigla 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
