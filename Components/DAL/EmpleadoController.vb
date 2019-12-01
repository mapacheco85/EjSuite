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
    ''' Controller class for EJS_Empleado
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class EmpleadoController
    
        ' Preload our schema..
        Dim thisSchemaLoad As Empleado = New Empleado()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As EmpleadoCollection
        
            Dim coll As EmpleadoCollection = New EmpleadoCollection()
            Dim qry As Query = New Query(Empleado.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodEmpleado As Object) As EmpleadoCollection 
        
            Dim coll As EmpleadoCollection = New EmpleadoCollection().Where("nCodEmpleado", NCodEmpleado).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As EmpleadoCollection 
        
            Dim coll As EmpleadoCollection = New EmpleadoCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodEmpleado As Object) as Boolean
        
            Return (Empleado.Delete(NCodEmpleado) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodEmpleado As Object) as Boolean
        
            Return (Empleado.Destroy(NCodEmpleado) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodEmpleado As Integer,ByVal NCodUsuario As Integer,ByVal NEstadoCivil As Nullable(Of Integer),ByVal CNombres As String,ByVal CApellidoPaterno As String,ByVal CApellidoMaterno As String,ByVal CCarnetIdentidad As String,ByVal CGarantias As String,ByVal IFoto As Byte(),ByVal IDocumentos As Byte(),ByVal BValido As Boolean,ByVal CUsuario As String,ByVal CClave As String,ByVal NCodGrupo As Nullable(Of Integer))
	   
		    Dim item As Empleado = New Empleado()
		    
            item.NCodEmpleado = NCodEmpleado
            
            item.NCodUsuario = NCodUsuario
            
            item.NEstadoCivil = NEstadoCivil
            
            item.CNombres = CNombres
            
            item.CApellidoPaterno = CApellidoPaterno
            
            item.CApellidoMaterno = CApellidoMaterno
            
            item.CCarnetIdentidad = CCarnetIdentidad
            
            item.CGarantias = CGarantias
            
            item.IFoto = IFoto
            
            item.IDocumentos = IDocumentos
            
            item.BValido = BValido
            
            item.CUsuario = CUsuario
            
            item.CClave = CClave
            
            item.NCodGrupo = NCodGrupo
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodEmpleado As Integer,ByVal NCodUsuario As Integer,ByVal NEstadoCivil As Nullable(Of Integer),ByVal CNombres As String,ByVal CApellidoPaterno As String,ByVal CApellidoMaterno As String,ByVal CCarnetIdentidad As String,ByVal CGarantias As String,ByVal IFoto As Byte(),ByVal IDocumentos As Byte(),ByVal BValido As Boolean,ByVal CUsuario As String,ByVal CClave As String,ByVal NCodGrupo As Nullable(Of Integer))
	    
		    Dim item As Empleado = New Empleado()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodEmpleado = NCodEmpleado 
				
			item.NCodUsuario = NCodUsuario 
				
			item.NEstadoCivil = NEstadoCivil 
				
			item.CNombres = CNombres 
				
			item.CApellidoPaterno = CApellidoPaterno 
				
			item.CApellidoMaterno = CApellidoMaterno 
				
			item.CCarnetIdentidad = CCarnetIdentidad 
				
			item.CGarantias = CGarantias 
				
			item.IFoto = IFoto 
				
			item.IDocumentos = IDocumentos 
				
			item.BValido = BValido 
				
			item.CUsuario = CUsuario 
				
			item.CClave = CClave 
				
			item.NCodGrupo = NCodGrupo 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
