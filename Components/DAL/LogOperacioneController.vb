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
    ''' Controller class for EJS_LogOperaciones
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class LogOperacioneController
    
        ' Preload our schema..
        Dim thisSchemaLoad As LogOperacione = New LogOperacione()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As LogOperacioneCollection
        
            Dim coll As LogOperacioneCollection = New LogOperacioneCollection()
            Dim qry As Query = New Query(LogOperacione.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodLog As Object) As LogOperacioneCollection 
        
            Dim coll As LogOperacioneCollection = New LogOperacioneCollection().Where("nCodLog", NCodLog).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As LogOperacioneCollection 
        
            Dim coll As LogOperacioneCollection = New LogOperacioneCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodLog As Object) as Boolean
        
            Return (LogOperacione.Delete(NCodLog) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodLog As Object) as Boolean
        
            Return (LogOperacione.Destroy(NCodLog) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodLog As Long,ByVal DFecha As DateTime,ByVal NCodUsuario As Integer,ByVal CTabla As String,ByVal COperacion As String)
	   
		    Dim item As LogOperacione = New LogOperacione()
		    
            item.NCodLog = NCodLog
            
            item.DFecha = DFecha
            
            item.NCodUsuario = NCodUsuario
            
            item.CTabla = CTabla
            
            item.COperacion = COperacion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodLog As Long,ByVal DFecha As DateTime,ByVal NCodUsuario As Integer,ByVal CTabla As String,ByVal COperacion As String)
	    
		    Dim item As LogOperacione = New LogOperacione()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodLog = NCodLog 
				
			item.DFecha = DFecha 
				
			item.NCodUsuario = NCodUsuario 
				
			item.CTabla = CTabla 
				
			item.COperacion = COperacion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
