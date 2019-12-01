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
    ''' Controller class for EJS_SniData
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class SniDatumController
    
        ' Preload our schema..
        Dim thisSchemaLoad As SniDatum = New SniDatum()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As SniDatumCollection
        
            Dim coll As SniDatumCollection = New SniDatumCollection()
            Dim qry As Query = New Query(SniDatum.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodSNI As Object) As SniDatumCollection 
        
            Dim coll As SniDatumCollection = New SniDatumCollection().Where("nCodSNI", NCodSNI).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As SniDatumCollection 
        
            Dim coll As SniDatumCollection = New SniDatumCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodSNI As Object) as Boolean
        
            Return (SniDatum.Delete(NCodSNI) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodSNI As Object) as Boolean
        
            Return (SniDatum.Destroy(NCodSNI) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodSNI As Integer,ByVal CLlave As String,ByVal CAutorizacion As String,ByVal DFechaInicio As DateTime,ByVal DFechaFinal As DateTime,ByVal NNroFacturaInicial As Integer,ByVal CLeyenda453 As String,ByVal BUsaQR As Boolean,ByVal BVigente As Boolean)
	   
		    Dim item As SniDatum = New SniDatum()
		    
            item.NCodSNI = NCodSNI
            
            item.CLlave = CLlave
            
            item.CAutorizacion = CAutorizacion
            
            item.DFechaInicio = DFechaInicio
            
            item.DFechaFinal = DFechaFinal
            
            item.NNroFacturaInicial = NNroFacturaInicial
            
            item.CLeyenda453 = CLeyenda453
            
            item.BUsaQR = BUsaQR
            
            item.BVigente = BVigente
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodSNI As Integer,ByVal CLlave As String,ByVal CAutorizacion As String,ByVal DFechaInicio As DateTime,ByVal DFechaFinal As DateTime,ByVal NNroFacturaInicial As Integer,ByVal CLeyenda453 As String,ByVal BUsaQR As Boolean,ByVal BVigente As Boolean)
	    
		    Dim item As SniDatum = New SniDatum()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodSNI = NCodSNI 
				
			item.CLlave = CLlave 
				
			item.CAutorizacion = CAutorizacion 
				
			item.DFechaInicio = DFechaInicio 
				
			item.DFechaFinal = DFechaFinal 
				
			item.NNroFacturaInicial = NNroFacturaInicial 
				
			item.CLeyenda453 = CLeyenda453 
				
			item.BUsaQR = BUsaQR 
				
			item.BVigente = BVigente 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
