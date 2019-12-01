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
    ''' Controller class for EJS_InformeCobranzas
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class InformeCobranzaController
    
        ' Preload our schema..
        Dim thisSchemaLoad As InformeCobranza = New InformeCobranza()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As InformeCobranzaCollection
        
            Dim coll As InformeCobranzaCollection = New InformeCobranzaCollection()
            Dim qry As Query = New Query(InformeCobranza.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NInformeCobranza As Object) As InformeCobranzaCollection 
        
            Dim coll As InformeCobranzaCollection = New InformeCobranzaCollection().Where("nInformeCobranza", NInformeCobranza).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As InformeCobranzaCollection 
        
            Dim coll As InformeCobranzaCollection = New InformeCobranzaCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NInformeCobranza As Object) as Boolean
        
            Return (InformeCobranza.Delete(NInformeCobranza) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NInformeCobranza As Object) as Boolean
        
            Return (InformeCobranza.Destroy(NInformeCobranza) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodCliente As Integer,ByVal DFecha As String,ByVal CVendedor As String,ByVal CObservaciones As String,ByVal NCodigo As Integer,ByVal NMonto As Double,ByVal NEfectivo As Double,ByVal NCheque As Double,ByVal NReciboOficial As Integer,ByVal NInformeCobranza As Integer)
	   
		    Dim item As InformeCobranza = New InformeCobranza()
		    
            item.NCodCliente = NCodCliente
            
            item.DFecha = DFecha
            
            item.CVendedor = CVendedor
            
            item.CObservaciones = CObservaciones
            
            item.NCodigo = NCodigo
            
            item.NMonto = NMonto
            
            item.NEfectivo = NEfectivo
            
            item.NCheque = NCheque
            
            item.NReciboOficial = NReciboOficial
            
            item.NInformeCobranza = NInformeCobranza
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodCliente As Integer,ByVal DFecha As String,ByVal CVendedor As String,ByVal CObservaciones As String,ByVal NCodigo As Integer,ByVal NMonto As Double,ByVal NEfectivo As Double,ByVal NCheque As Double,ByVal NReciboOficial As Integer,ByVal NInformeCobranza As Integer)
	    
		    Dim item As InformeCobranza = New InformeCobranza()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodCliente = NCodCliente 
				
			item.DFecha = DFecha 
				
			item.CVendedor = CVendedor 
				
			item.CObservaciones = CObservaciones 
				
			item.NCodigo = NCodigo 
				
			item.NMonto = NMonto 
				
			item.NEfectivo = NEfectivo 
				
			item.NCheque = NCheque 
				
			item.NReciboOficial = NReciboOficial 
				
			item.NInformeCobranza = NInformeCobranza 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
