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
    ''' Controller class for EJS_MacroUnidades
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class MacroUnidadeController
    
        ' Preload our schema..
        Dim thisSchemaLoad As MacroUnidade = New MacroUnidade()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As MacroUnidadeCollection
        
            Dim coll As MacroUnidadeCollection = New MacroUnidadeCollection()
            Dim qry As Query = New Query(MacroUnidade.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodMacroUnidad As Object) As MacroUnidadeCollection 
        
            Dim coll As MacroUnidadeCollection = New MacroUnidadeCollection().Where("nCodMacroUnidad", NCodMacroUnidad).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As MacroUnidadeCollection 
        
            Dim coll As MacroUnidadeCollection = New MacroUnidadeCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodMacroUnidad As Object) as Boolean
        
            Return (MacroUnidade.Delete(NCodMacroUnidad) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodMacroUnidad As Object) as Boolean
        
            Return (MacroUnidade.Destroy(NCodMacroUnidad) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodMacroUnidad As Integer,ByVal CDescripcion As String)
	   
		    Dim item As MacroUnidade = New MacroUnidade()
		    
            item.NCodMacroUnidad = NCodMacroUnidad
            
            item.CDescripcion = CDescripcion
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodMacroUnidad As Integer,ByVal CDescripcion As String)
	    
		    Dim item As MacroUnidade = New MacroUnidade()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodMacroUnidad = NCodMacroUnidad 
				
			item.CDescripcion = CDescripcion 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
