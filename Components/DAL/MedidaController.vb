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
    ''' Controller class for EJS_Medida
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class MedidaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Medida = New Medida()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As MedidaCollection
        
            Dim coll As MedidaCollection = New MedidaCollection()
            Dim qry As Query = New Query(Medida.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodMedida As Object) As MedidaCollection 
        
            Dim coll As MedidaCollection = New MedidaCollection().Where("nCodMedida", NCodMedida).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As MedidaCollection 
        
            Dim coll As MedidaCollection = New MedidaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodMedida As Object) as Boolean
        
            Return (Medida.Delete(NCodMedida) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodMedida As Object) as Boolean
        
            Return (Medida.Destroy(NCodMedida) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodMedida As Integer,ByVal CDescripcion As String)
	   
		    Dim item As Medida = New Medida()
		    
            item.NCodMedida = NCodMedida
            
            item.CDescripcion = CDescripcion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodMedida As Integer,ByVal CDescripcion As String)
	    
		    Dim item As Medida = New Medida()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodMedida = NCodMedida 
				
			item.CDescripcion = CDescripcion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
