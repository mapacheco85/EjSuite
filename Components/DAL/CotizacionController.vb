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
    ''' Controller class for EJS_Cotizacion
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class CotizacionController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Cotizacion = New Cotizacion()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As CotizacionCollection
        
            Dim coll As CotizacionCollection = New CotizacionCollection()
            Dim qry As Query = New Query(Cotizacion.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodCotizacion As Object) As CotizacionCollection 
        
            Dim coll As CotizacionCollection = New CotizacionCollection().Where("nCodCotizacion", NCodCotizacion).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As CotizacionCollection 
        
            Dim coll As CotizacionCollection = New CotizacionCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodCotizacion As Object) as Boolean
        
            Return (Cotizacion.Delete(NCodCotizacion) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodCotizacion As Object) as Boolean
        
            Return (Cotizacion.Destroy(NCodCotizacion) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodCotizacion As Integer,ByVal NCodSucursalId As Integer,ByVal NCodUsuario As Integer,ByVal DFechaLimite As DateTime,ByVal DFechaCotizacion As DateTime,ByVal DFechaEjecucion As Nullable(Of DateTime),ByVal DFechaParcial As Nullable(Of DateTime),ByVal CCliente As String,ByVal NNumeroCotizacion As Integer,ByVal BEjecutada As Boolean,ByVal BParcialmente As Nullable(Of Boolean),ByVal CCodCliente As Integer)
	   
		    Dim item As Cotizacion = New Cotizacion()
		    
            item.NCodCotizacion = NCodCotizacion
            
            item.NCodSucursalId = NCodSucursalId
            
            item.NCodUsuario = NCodUsuario
            
            item.DFechaLimite = DFechaLimite
            
            item.DFechaCotizacion = DFechaCotizacion
            
            item.DFechaEjecucion = DFechaEjecucion
            
            item.DFechaParcial = DFechaParcial
            
            item.CCliente = CCliente
            
            item.NNumeroCotizacion = NNumeroCotizacion
            
            item.BEjecutada = BEjecutada
            
            item.BParcialmente = BParcialmente
            
            item.CCodCliente = CCodCliente
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodCotizacion As Integer,ByVal NCodSucursalId As Integer,ByVal NCodUsuario As Integer,ByVal DFechaLimite As DateTime,ByVal DFechaCotizacion As DateTime,ByVal DFechaEjecucion As Nullable(Of DateTime),ByVal DFechaParcial As Nullable(Of DateTime),ByVal CCliente As String,ByVal NNumeroCotizacion As Integer,ByVal BEjecutada As Boolean,ByVal BParcialmente As Nullable(Of Boolean),ByVal CCodCliente As Integer)
	    
		    Dim item As Cotizacion = New Cotizacion()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodCotizacion = NCodCotizacion 
				
			item.NCodSucursalId = NCodSucursalId 
				
			item.NCodUsuario = NCodUsuario 
				
			item.DFechaLimite = DFechaLimite 
				
			item.DFechaCotizacion = DFechaCotizacion 
				
			item.DFechaEjecucion = DFechaEjecucion 
				
			item.DFechaParcial = DFechaParcial 
				
			item.CCliente = CCliente 
				
			item.NNumeroCotizacion = NNumeroCotizacion 
				
			item.BEjecutada = BEjecutada 
				
			item.BParcialmente = BParcialmente 
				
			item.CCodCliente = CCodCliente 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
