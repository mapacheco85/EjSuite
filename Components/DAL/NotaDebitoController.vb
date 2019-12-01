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
    ''' Controller class for EJS_NotaDebito
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class NotaDebitoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As NotaDebito = New NotaDebito()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As NotaDebitoCollection
        
            Dim coll As NotaDebitoCollection = New NotaDebitoCollection()
            Dim qry As Query = New Query(NotaDebito.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodNotaDebito As Object) As NotaDebitoCollection 
        
            Dim coll As NotaDebitoCollection = New NotaDebitoCollection().Where("nCodNotaDebito", NCodNotaDebito).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As NotaDebitoCollection 
        
            Dim coll As NotaDebitoCollection = New NotaDebitoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodNotaDebito As Object) as Boolean
        
            Return (NotaDebito.Delete(NCodNotaDebito) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodNotaDebito As Object) as Boolean
        
            Return (NotaDebito.Destroy(NCodNotaDebito) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodNotaDebito As Integer,ByVal DFecha As String,ByVal NCodCliente As Integer,ByVal NCodUsuario As Integer,ByVal DFechaRegistro As String,ByVal NCodPedido As Nullable(Of Integer),ByVal NCodVendedor As String,ByVal NValorPedido As Decimal)
	   
		    Dim item As NotaDebito = New NotaDebito()
		    
            item.NCodNotaDebito = NCodNotaDebito
            
            item.DFecha = DFecha
            
            item.NCodCliente = NCodCliente
            
            item.NCodUsuario = NCodUsuario
            
            item.DFechaRegistro = DFechaRegistro
            
            item.NCodPedido = NCodPedido
            
            item.NCodVendedor = NCodVendedor
            
            item.NValorPedido = NValorPedido
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodNotaDebito As Integer,ByVal DFecha As String,ByVal NCodCliente As Integer,ByVal NCodUsuario As Integer,ByVal DFechaRegistro As String,ByVal NCodPedido As Nullable(Of Integer),ByVal NCodVendedor As String,ByVal NValorPedido As Decimal)
	    
		    Dim item As NotaDebito = New NotaDebito()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodNotaDebito = NCodNotaDebito 
				
			item.DFecha = DFecha 
				
			item.NCodCliente = NCodCliente 
				
			item.NCodUsuario = NCodUsuario 
				
			item.DFechaRegistro = DFechaRegistro 
				
			item.NCodPedido = NCodPedido 
				
			item.NCodVendedor = NCodVendedor 
				
			item.NValorPedido = NValorPedido 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
