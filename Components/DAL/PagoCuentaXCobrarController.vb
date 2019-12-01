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
    ''' Controller class for EJS_PagoCuentaXCobrar
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class PagoCuentaXCobrarController
    
        ' Preload our schema..
        Dim thisSchemaLoad As PagoCuentaXCobrar = New PagoCuentaXCobrar()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As PagoCuentaXCobrarCollection
        
            Dim coll As PagoCuentaXCobrarCollection = New PagoCuentaXCobrarCollection()
            Dim qry As Query = New Query(PagoCuentaXCobrar.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodPago As Object) As PagoCuentaXCobrarCollection 
        
            Dim coll As PagoCuentaXCobrarCollection = New PagoCuentaXCobrarCollection().Where("nCodPago", NCodPago).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As PagoCuentaXCobrarCollection 
        
            Dim coll As PagoCuentaXCobrarCollection = New PagoCuentaXCobrarCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodPago As Object) as Boolean
        
            Return (PagoCuentaXCobrar.Delete(NCodPago) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodPago As Object) as Boolean
        
            Return (PagoCuentaXCobrar.Destroy(NCodPago) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodPago As Integer,ByVal NFacturaId As Long,ByVal NMontoPagado As Decimal,ByVal CNroComprobante As String,ByVal CBancoCobro As String,ByVal BCheque As Boolean,ByVal CNroCheque As String,ByVal DFechaCobro As Nullable(Of DateTime),ByVal CBeneficiario As String,ByVal DFechaExtracto As Nullable(Of DateTime),ByVal NSaldo As Nullable(Of Decimal),ByVal NCodCobrador As Nullable(Of Integer),ByVal DFechaPago As Nullable(Of DateTime),ByVal NReciboOficial As Nullable(Of Integer),ByVal NInformeCobranza As Nullable(Of Integer))
	   
		    Dim item As PagoCuentaXCobrar = New PagoCuentaXCobrar()
		    
            item.NCodPago = NCodPago
            
            item.NFacturaId = NFacturaId
            
            item.NMontoPagado = NMontoPagado
            
            item.CNroComprobante = CNroComprobante
            
            item.CBancoCobro = CBancoCobro
            
            item.BCheque = BCheque
            
            item.CNroCheque = CNroCheque
            
            item.DFechaCobro = DFechaCobro
            
            item.CBeneficiario = CBeneficiario
            
            item.DFechaExtracto = DFechaExtracto
            
            item.NSaldo = NSaldo
            
            item.NCodCobrador = NCodCobrador
            
            item.DFechaPago = DFechaPago
            
            item.NReciboOficial = NReciboOficial
            
            item.NInformeCobranza = NInformeCobranza
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodPago As Integer,ByVal NFacturaId As Long,ByVal NMontoPagado As Decimal,ByVal CNroComprobante As String,ByVal CBancoCobro As String,ByVal BCheque As Boolean,ByVal CNroCheque As String,ByVal DFechaCobro As Nullable(Of DateTime),ByVal CBeneficiario As String,ByVal DFechaExtracto As Nullable(Of DateTime),ByVal NSaldo As Nullable(Of Decimal),ByVal NCodCobrador As Nullable(Of Integer),ByVal DFechaPago As Nullable(Of DateTime),ByVal NReciboOficial As Nullable(Of Integer),ByVal NInformeCobranza As Nullable(Of Integer))
	    
		    Dim item As PagoCuentaXCobrar = New PagoCuentaXCobrar()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodPago = NCodPago 
				
			item.NFacturaId = NFacturaId 
				
			item.NMontoPagado = NMontoPagado 
				
			item.CNroComprobante = CNroComprobante 
				
			item.CBancoCobro = CBancoCobro 
				
			item.BCheque = BCheque 
				
			item.CNroCheque = CNroCheque 
				
			item.DFechaCobro = DFechaCobro 
				
			item.CBeneficiario = CBeneficiario 
				
			item.DFechaExtracto = DFechaExtracto 
				
			item.NSaldo = NSaldo 
				
			item.NCodCobrador = NCodCobrador 
				
			item.DFechaPago = DFechaPago 
				
			item.NReciboOficial = NReciboOficial 
				
			item.NInformeCobranza = NInformeCobranza 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
