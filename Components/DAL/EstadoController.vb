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
    ''' Controller class for EJS_Estado
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class EstadoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Estado = New Estado()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As EstadoCollection
        
            Dim coll As EstadoCollection = New EstadoCollection()
            Dim qry As Query = New Query(Estado.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodEstado As Object) As EstadoCollection 
        
            Dim coll As EstadoCollection = New EstadoCollection().Where("nCodEstado", NCodEstado).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As EstadoCollection 
        
            Dim coll As EstadoCollection = New EstadoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodEstado As Object) as Boolean
        
            Return (Estado.Delete(NCodEstado) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodEstado As Object) as Boolean
        
            Return (Estado.Destroy(NCodEstado) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodEstado As Integer,ByVal NCodAjuste As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCentenas As Boolean,ByVal BMiles As Boolean)
	   
		    Dim item As Estado = New Estado()
		    
            item.NCodEstado = NCodEstado
            
            item.NCodAjuste = NCodAjuste
            
            item.NCodProducto = NCodProducto
            
            item.NCantidad = NCantidad
            
            item.NPrecioUnitario = NPrecioUnitario
            
            item.BUnidad = BUnidad
            
            item.BDocena = BDocena
            
            item.BCentenas = BCentenas
            
            item.BMiles = BMiles
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodEstado As Integer,ByVal NCodAjuste As Integer,ByVal NCodProducto As Nullable(Of Integer),ByVal NCantidad As Integer,ByVal NPrecioUnitario As Decimal,ByVal BUnidad As Boolean,ByVal BDocena As Boolean,ByVal BCentenas As Boolean,ByVal BMiles As Boolean)
	    
		    Dim item As Estado = New Estado()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodEstado = NCodEstado 
				
			item.NCodAjuste = NCodAjuste 
				
			item.NCodProducto = NCodProducto 
				
			item.NCantidad = NCantidad 
				
			item.NPrecioUnitario = NPrecioUnitario 
				
			item.BUnidad = BUnidad 
				
			item.BDocena = BDocena 
				
			item.BCentenas = BCentenas 
				
			item.BMiles = BMiles 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
