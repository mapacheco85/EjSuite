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
    ''' Controller class for EJS_EmpleadoSucursal
    ''' </summary>
		<System.ComponentModel.DataObject()> Public Partial Class EmpleadoSucursalController
    
        ' Preload our schema..
        Dim thisSchemaLoad As EmpleadoSucursal = New EmpleadoSucursal()
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
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchAll() As EmpleadoSucursalCollection
        
            Dim coll As EmpleadoSucursalCollection = New EmpleadoSucursalCollection()
            Dim qry As Query = New Query(EmpleadoSucursal.Schema)
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
            
        End Function
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByID(ByVal NCodEmpleadoSucursal As Object) As EmpleadoSucursalCollection 
        
            Dim coll As EmpleadoSucursalCollection = New EmpleadoSucursalCollection().Where("nCodEmpleadoSucursal", NCodEmpleadoSucursal).Load()
            Return coll
        
        End Function
        
        <DataObjectMethod(DataObjectMethodType.Select, True)> Public Function FetchByQuery(ByVal qry As SubSonic.Query) As EmpleadoSucursalCollection 
        
            Dim coll As EmpleadoSucursalCollection = New EmpleadoSucursalCollection()
            coll.LoadAndCloseReader(qry.ExecuteReader())
            Return coll
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, True)> Public Function Delete(ByVal NCodEmpleadoSucursal As Object) as Boolean
        
            Return (EmpleadoSucursal.Delete(NCodEmpleadoSucursal) = 1)
        
        End Function
        <DataObjectMethod(DataObjectMethodType.Delete, False)> Public Function Destroy(ByVal NCodEmpleadoSucursal As Object) as Boolean
        
            Return (EmpleadoSucursal.Destroy(NCodEmpleadoSucursal) = 1)
        
        End Function
        
    	
	    ''' <summary>
	    ''' Inserts a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Insert, True)> Public Sub Insert(ByVal NCodEmpleadoSucursal As Integer,ByVal NCodSucursal As Nullable(Of Integer),ByVal NCodEmpleado As Nullable(Of Integer),ByVal DFechaInicio As DateTime,ByVal DFechaFinal As Nullable(Of DateTime))
	   
		    Dim item As EmpleadoSucursal = New EmpleadoSucursal()
		    
            item.NCodEmpleadoSucursal = NCodEmpleadoSucursal
            
            item.NCodSucursal = NCodSucursal
            
            item.NCodEmpleado = NCodEmpleado
            
            item.DFechaInicio = DFechaInicio
            
            item.DFechaFinal = DFechaFinal
            
	    
		    item.Save(UserName)
	   
	   End Sub
    	
	    ''' <summary>
	    ''' Updates a record, can be used with the Object Data Source
	    ''' </summary>
        <DataObjectMethod(DataObjectMethodType.Update, True)> Public Sub Update(ByVal NCodEmpleadoSucursal As Integer,ByVal NCodSucursal As Nullable(Of Integer),ByVal NCodEmpleado As Nullable(Of Integer),ByVal DFechaInicio As DateTime,ByVal DFechaFinal As Nullable(Of DateTime))
	    
		    Dim item As EmpleadoSucursal = New EmpleadoSucursal()
	        item.MarkOld()
	        item.IsLoaded = True
		    
			item.NCodEmpleadoSucursal = NCodEmpleadoSucursal 
				
			item.NCodSucursal = NCodSucursal 
				
			item.NCodEmpleado = NCodEmpleado 
				
			item.DFechaInicio = DFechaInicio 
				
			item.DFechaFinal = DFechaFinal 
				
	        item.Save(UserName)
	    End Sub
    End Class
End Namespace
