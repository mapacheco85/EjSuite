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
    ''' Controller class for EJS_Grupo
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class GrupoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Grupo = New Grupo()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As GrupoCollection
        
            Dim coll As GrupoCollection = New GrupoCollection()
            Dim qry As Query = New Query(Grupo.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodGrupo As Object) As GrupoCollection 
        
            Dim coll As GrupoCollection = New GrupoCollection().Where("nCodGrupo", NCodGrupo).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As GrupoCollection 
        
            Dim coll As GrupoCollection = New GrupoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodGrupo As Object) as Boolean
        
            Return (Grupo.Delete(NCodGrupo) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodGrupo As Object) as Boolean
        
            Return (Grupo.Destroy(NCodGrupo) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodGrupo As Integer,ByVal CTipoGrupo As String)
	   
		    Dim item As Grupo = New Grupo()
		    
            item.NCodGrupo = NCodGrupo
            
            item.CTipoGrupo = CTipoGrupo
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodGrupo As Integer,ByVal CTipoGrupo As String)
	    
		    Dim item As Grupo = New Grupo()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodGrupo = NCodGrupo 
				
			item.CTipoGrupo = CTipoGrupo 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
