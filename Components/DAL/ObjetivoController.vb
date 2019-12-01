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
    ''' Controller class for EJS_Objetivo
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class ObjetivoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Objetivo = New Objetivo()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As ObjetivoCollection
        
            Dim coll As ObjetivoCollection = New ObjetivoCollection()
            Dim qry As Query = New Query(Objetivo.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodObjetivo As Object) As ObjetivoCollection 
        
            Dim coll As ObjetivoCollection = New ObjetivoCollection().Where("nCodObjetivo", NCodObjetivo).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As ObjetivoCollection 
        
            Dim coll As ObjetivoCollection = New ObjetivoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodObjetivo As Object) as Boolean
        
            Return (Objetivo.Delete(NCodObjetivo) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodObjetivo As Object) as Boolean
        
            Return (Objetivo.Destroy(NCodObjetivo) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodObjetivo As Integer,ByVal DFechaAsignacion As DateTime,ByVal NMesCumplimiento As Integer,ByVal NGestionCumplimiento As Integer,ByVal BEsProducto As Boolean,ByVal BEsCupo As Boolean,ByVal BEsVenta As Boolean,ByVal BEsGerencial As Boolean,ByVal NLimite1 As Decimal,ByVal NLimite2 As Decimal,ByVal DFechaCumplimiento As DateTime,ByVal NCodEmpleado As Integer,ByVal NPorcentaje As Decimal)
	   
		    Dim item As Objetivo = New Objetivo()
		    
            item.NCodObjetivo = NCodObjetivo
            
            item.DFechaAsignacion = DFechaAsignacion
            
            item.NMesCumplimiento = NMesCumplimiento
            
            item.NGestionCumplimiento = NGestionCumplimiento
            
            item.BEsProducto = BEsProducto
            
            item.BEsCupo = BEsCupo
            
            item.BEsVenta = BEsVenta
            
            item.BEsGerencial = BEsGerencial
            
            item.NLimite1 = NLimite1
            
            item.NLimite2 = NLimite2
            
            item.DFechaCumplimiento = DFechaCumplimiento
            
            item.NCodEmpleado = NCodEmpleado
            
            item.NPorcentaje = NPorcentaje
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodObjetivo As Integer,ByVal DFechaAsignacion As DateTime,ByVal NMesCumplimiento As Integer,ByVal NGestionCumplimiento As Integer,ByVal BEsProducto As Boolean,ByVal BEsCupo As Boolean,ByVal BEsVenta As Boolean,ByVal BEsGerencial As Boolean,ByVal NLimite1 As Decimal,ByVal NLimite2 As Decimal,ByVal DFechaCumplimiento As DateTime,ByVal NCodEmpleado As Integer,ByVal NPorcentaje As Decimal)
	    
		    Dim item As Objetivo = New Objetivo()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodObjetivo = NCodObjetivo 
				
			item.DFechaAsignacion = DFechaAsignacion 
				
			item.NMesCumplimiento = NMesCumplimiento 
				
			item.NGestionCumplimiento = NGestionCumplimiento 
				
			item.BEsProducto = BEsProducto 
				
			item.BEsCupo = BEsCupo 
				
			item.BEsVenta = BEsVenta 
				
			item.BEsGerencial = BEsGerencial 
				
			item.NLimite1 = NLimite1 
				
			item.NLimite2 = NLimite2 
				
			item.DFechaCumplimiento = DFechaCumplimiento 
				
			item.NCodEmpleado = NCodEmpleado 
				
			item.NPorcentaje = NPorcentaje 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
