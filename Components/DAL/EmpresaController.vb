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
    ''' Controller class for EJS_Empresa
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class EmpresaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Empresa = New Empresa()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As EmpresaCollection
        
            Dim coll As EmpresaCollection = New EmpresaCollection()
            Dim qry As Query = New Query(Empresa.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodEmpresa As Object) As EmpresaCollection 
        
            Dim coll As EmpresaCollection = New EmpresaCollection().Where("nCodEmpresa", NCodEmpresa).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As EmpresaCollection 
        
            Dim coll As EmpresaCollection = New EmpresaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodEmpresa As Object) as Boolean
        
            Return (Empresa.Delete(NCodEmpresa) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodEmpresa As Object) as Boolean
        
            Return (Empresa.Destroy(NCodEmpresa) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodEmpresa As Integer,ByVal CRazonSocial As String,ByVal CPropietario As String,ByVal ILogo As Byte(),ByVal CDireccion As String,ByVal CTelefonos As String,ByVal CCiudad As String,ByVal CEstado As String,ByVal CPais As String,ByVal BValido As Nullable(Of Boolean),ByVal CCorreo As String)
	   
		    Dim item As Empresa = New Empresa()
		    
            item.NCodEmpresa = NCodEmpresa
            
            item.CRazonSocial = CRazonSocial
            
            item.CPropietario = CPropietario
            
            item.ILogo = ILogo
            
            item.CDireccion = CDireccion
            
            item.CTelefonos = CTelefonos
            
            item.CCiudad = CCiudad
            
            item.CEstado = CEstado
            
            item.CPais = CPais
            
            item.BValido = BValido
            
            item.CCorreo = CCorreo
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodEmpresa As Integer,ByVal CRazonSocial As String,ByVal CPropietario As String,ByVal ILogo As Byte(),ByVal CDireccion As String,ByVal CTelefonos As String,ByVal CCiudad As String,ByVal CEstado As String,ByVal CPais As String,ByVal BValido As Nullable(Of Boolean),ByVal CCorreo As String)
	    
		    Dim item As Empresa = New Empresa()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodEmpresa = NCodEmpresa 
				
			item.CRazonSocial = CRazonSocial 
				
			item.CPropietario = CPropietario 
				
			item.ILogo = ILogo 
				
			item.CDireccion = CDireccion 
				
			item.CTelefonos = CTelefonos 
				
			item.CCiudad = CCiudad 
				
			item.CEstado = CEstado 
				
			item.CPais = CPais 
				
			item.BValido = BValido 
				
			item.CCorreo = CCorreo 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
