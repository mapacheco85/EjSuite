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
    ''' Controller class for EJS_Parametro
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ParametroController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Parametro = New Parametro()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ParametroCollection
        
            Dim coll As ParametroCollection = New ParametroCollection()
            Dim qry As Query = New Query(Parametro.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodParametro As Object) As ParametroCollection 
        
            Dim coll As ParametroCollection = New ParametroCollection().Where("nCodParametro", NCodParametro).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ParametroCollection 
        
            Dim coll As ParametroCollection = New ParametroCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodParametro As Object) as Boolean
        
            Return (Parametro.Delete(NCodParametro) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodParametro As Object) as Boolean
        
            Return (Parametro.Destroy(NCodParametro) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodParametro As Integer,ByVal CDescripcionParametro As String,ByVal NTipoParametro As Integer,ByVal CValorParametro As String,ByVal BVigente As Nullable(Of Boolean))
	   
		    Dim item As Parametro = New Parametro()
		    
            item.NCodParametro = NCodParametro
            
            item.CDescripcionParametro = CDescripcionParametro
            
            item.NTipoParametro = NTipoParametro
            
            item.CValorParametro = CValorParametro
            
            item.BVigente = BVigente
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodParametro As Integer,ByVal CDescripcionParametro As String,ByVal NTipoParametro As Integer,ByVal CValorParametro As String,ByVal BVigente As Nullable(Of Boolean))
	    
		    Dim item As Parametro = New Parametro()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodParametro = NCodParametro 
				
			item.CDescripcionParametro = CDescripcionParametro 
				
			item.NTipoParametro = NTipoParametro 
				
			item.CValorParametro = CValorParametro 
				
			item.BVigente = BVigente 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
