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
    ''' Controller class for EJS_Error
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ErrorXController
    
        ' Preload our schema..
        Dim thisSchemaLoad As ErrorX = New ErrorX()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ErrorXCollection
        
            Dim coll As ErrorXCollection = New ErrorXCollection()
            Dim qry As Query = New Query(ErrorX.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodError As Object) As ErrorXCollection 
        
            Dim coll As ErrorXCollection = New ErrorXCollection().Where("nCodError", NCodError).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ErrorXCollection 
        
            Dim coll As ErrorXCollection = New ErrorXCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodError As Object) as Boolean
        
            Return (ErrorX.Delete(NCodError) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodError As Object) as Boolean
        
            Return (ErrorX.Destroy(NCodError) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodError As Integer,ByVal NNumero As Integer,ByVal NGravedad As Integer,ByVal NEstado As Integer,ByVal NLinea As Integer,ByVal CProcedimiento As String,ByVal CMensaje As String,ByVal DFecha As Nullable(Of DateTime))
	   
		    Dim item As ErrorX = New ErrorX()
		    
            item.NCodError = NCodError
            
            item.NNumero = NNumero
            
            item.NGravedad = NGravedad
            
            item.NEstado = NEstado
            
            item.NLinea = NLinea
            
            item.CProcedimiento = CProcedimiento
            
            item.CMensaje = CMensaje
            
            item.DFecha = DFecha
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodError As Integer,ByVal NNumero As Integer,ByVal NGravedad As Integer,ByVal NEstado As Integer,ByVal NLinea As Integer,ByVal CProcedimiento As String,ByVal CMensaje As String,ByVal DFecha As Nullable(Of DateTime))
	    
		    Dim item As ErrorX = New ErrorX()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodError = NCodError 
				
			item.NNumero = NNumero 
				
			item.NGravedad = NGravedad 
				
			item.NEstado = NEstado 
				
			item.NLinea = NLinea 
				
			item.CProcedimiento = CProcedimiento 
				
			item.CMensaje = CMensaje 
				
			item.DFecha = DFecha 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
