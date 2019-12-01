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
    ''' Controller class for EJS_Beneficiario
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class BeneficiarioController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Beneficiario = New Beneficiario()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As BeneficiarioCollection
        
            Dim coll As BeneficiarioCollection = New BeneficiarioCollection()
            Dim qry As Query = New Query(Beneficiario.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodBeneficiario As Object) As BeneficiarioCollection 
        
            Dim coll As BeneficiarioCollection = New BeneficiarioCollection().Where("nCodBeneficiario", NCodBeneficiario).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As BeneficiarioCollection 
        
            Dim coll As BeneficiarioCollection = New BeneficiarioCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodBeneficiario As Object) as Boolean
        
            Return (Beneficiario.Delete(NCodBeneficiario) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodBeneficiario As Object) as Boolean
        
            Return (Beneficiario.Destroy(NCodBeneficiario) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodBeneficiario As Integer,ByVal NCodCliente As Long,ByVal CNit As String,ByVal CNombre As String,ByVal DFechaReg As DateTime,ByVal CDireccion As String)
	   
		    Dim item As Beneficiario = New Beneficiario()
		    
            item.NCodBeneficiario = NCodBeneficiario
            
            item.NCodCliente = NCodCliente
            
            item.CNit = CNit
            
            item.CNombre = CNombre
            
            item.DFechaReg = DFechaReg
            
            item.CDireccion = CDireccion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodBeneficiario As Integer,ByVal NCodCliente As Long,ByVal CNit As String,ByVal CNombre As String,ByVal DFechaReg As DateTime,ByVal CDireccion As String)
	    
		    Dim item As Beneficiario = New Beneficiario()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodBeneficiario = NCodBeneficiario 
				
			item.NCodCliente = NCodCliente 
				
			item.CNit = CNit 
				
			item.CNombre = CNombre 
				
			item.DFechaReg = DFechaReg 
				
			item.CDireccion = CDireccion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
