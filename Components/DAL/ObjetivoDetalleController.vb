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
    ''' Controller class for EJS_ObjetivoDetalle
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ObjetivoDetalleController
    
        ' Preload our schema..
        Dim thisSchemaLoad As ObjetivoDetalle = New ObjetivoDetalle()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ObjetivoDetalleCollection
        
            Dim coll As ObjetivoDetalleCollection = New ObjetivoDetalleCollection()
            Dim qry As Query = New Query(ObjetivoDetalle.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodObjetivoDetalle As Object) As ObjetivoDetalleCollection 
        
            Dim coll As ObjetivoDetalleCollection = New ObjetivoDetalleCollection().Where("nCodObjetivoDetalle", NCodObjetivoDetalle).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ObjetivoDetalleCollection 
        
            Dim coll As ObjetivoDetalleCollection = New ObjetivoDetalleCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodObjetivoDetalle As Object) as Boolean
        
            Return (ObjetivoDetalle.Delete(NCodObjetivoDetalle) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodObjetivoDetalle As Object) as Boolean
        
            Return (ObjetivoDetalle.Destroy(NCodObjetivoDetalle) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodObjetivoDetalle As Integer,ByVal NCodObjetivo As Nullable(Of Integer),ByVal NCodProducto As String,ByVal NCantidad As Integer,ByVal NMonto As Decimal,ByVal NValorNumerico As Decimal,ByVal NValorLiteral As String,ByVal NFecha As String,ByVal CDescripcion As String,ByVal BTieneDescripcion As Boolean)
	   
		    Dim item As ObjetivoDetalle = New ObjetivoDetalle()
		    
            item.NCodObjetivoDetalle = NCodObjetivoDetalle
            
            item.NCodObjetivo = NCodObjetivo
            
            item.NCodProducto = NCodProducto
            
            item.NCantidad = NCantidad
            
            item.NMonto = NMonto
            
            item.NValorNumerico = NValorNumerico
            
            item.NValorLiteral = NValorLiteral
            
            item.NFecha = NFecha
            
            item.CDescripcion = CDescripcion
            
            item.BTieneDescripcion = BTieneDescripcion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodObjetivoDetalle As Integer,ByVal NCodObjetivo As Nullable(Of Integer),ByVal NCodProducto As String,ByVal NCantidad As Integer,ByVal NMonto As Decimal,ByVal NValorNumerico As Decimal,ByVal NValorLiteral As String,ByVal NFecha As String,ByVal CDescripcion As String,ByVal BTieneDescripcion As Boolean)
	    
		    Dim item As ObjetivoDetalle = New ObjetivoDetalle()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodObjetivoDetalle = NCodObjetivoDetalle 
				
			item.NCodObjetivo = NCodObjetivo 
				
			item.NCodProducto = NCodProducto 
				
			item.NCantidad = NCantidad 
				
			item.NMonto = NMonto 
				
			item.NValorNumerico = NValorNumerico 
				
			item.NValorLiteral = NValorLiteral 
				
			item.NFecha = NFecha 
				
			item.CDescripcion = CDescripcion 
				
			item.BTieneDescripcion = BTieneDescripcion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
