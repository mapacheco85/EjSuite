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
    ''' Controller class for EJS_Cliente
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ClienteController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Cliente = New Cliente()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ClienteCollection
        
            Dim coll As ClienteCollection = New ClienteCollection()
            Dim qry As Query = New Query(Cliente.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodCliente As Object) As ClienteCollection 
        
            Dim coll As ClienteCollection = New ClienteCollection().Where("nCodCliente", NCodCliente).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ClienteCollection 
        
            Dim coll As ClienteCollection = New ClienteCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodCliente As Object) as Boolean
        
            Return (Cliente.Delete(NCodCliente) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodCliente As Object) as Boolean
        
            Return (Cliente.Destroy(NCodCliente) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodCliente As Long,ByVal CNit As String,ByVal NCodRegion As Nullable(Of Integer),ByVal CCliente As String,ByVal CDireccion As String,ByVal CTelefono As String,ByVal NCodUsuario As Nullable(Of Integer),ByVal NCodZona As Nullable(Of Integer),ByVal CContacto As String,ByVal CEmail As String,ByVal CReferencias As String,ByVal CCelularContacto As String,ByVal CTelefono2 As String,ByVal BValido As Boolean)
	   
		    Dim item As Cliente = New Cliente()
		    
            item.NCodCliente = NCodCliente
            
            item.CNit = CNit
            
            item.NCodRegion = NCodRegion
            
            item.CCliente = CCliente
            
            item.CDireccion = CDireccion
            
            item.CTelefono = CTelefono
            
            item.NCodUsuario = NCodUsuario
            
            item.NCodZona = NCodZona
            
            item.CContacto = CContacto
            
            item.CEmail = CEmail
            
            item.CReferencias = CReferencias
            
            item.CCelularContacto = CCelularContacto
            
            item.CTelefono2 = CTelefono2
            
            item.BValido = BValido
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodCliente As Long,ByVal CNit As String,ByVal NCodRegion As Nullable(Of Integer),ByVal CCliente As String,ByVal CDireccion As String,ByVal CTelefono As String,ByVal NCodUsuario As Nullable(Of Integer),ByVal NCodZona As Nullable(Of Integer),ByVal CContacto As String,ByVal CEmail As String,ByVal CReferencias As String,ByVal CCelularContacto As String,ByVal CTelefono2 As String,ByVal BValido As Boolean)
	    
		    Dim item As Cliente = New Cliente()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodCliente = NCodCliente 
				
			item.CNit = CNit 
				
			item.NCodRegion = NCodRegion 
				
			item.CCliente = CCliente 
				
			item.CDireccion = CDireccion 
				
			item.CTelefono = CTelefono 
				
			item.NCodUsuario = NCodUsuario 
				
			item.NCodZona = NCodZona 
				
			item.CContacto = CContacto 
				
			item.CEmail = CEmail 
				
			item.CReferencias = CReferencias 
				
			item.CCelularContacto = CCelularContacto 
				
			item.CTelefono2 = CTelefono2 
				
			item.BValido = BValido 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
