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
    Public Partial Class SPs
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_BuscarClientesListado Procedure
        ''' </summary>
        Public Shared Function BuscarClientesListado(ByVal cDato As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_BuscarClientesListado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cDato", cDato, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_BuscarClientesMora Procedure
        ''' </summary>
        Public Shared Function BuscarClientesMora(ByVal nSucursal As Nullable(Of Integer), ByVal dFecIni As String, ByVal dFecFin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_BuscarClientesMora", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nSucursal", nSucursal, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@dFecIni", dFecIni, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@dFecFin", dFecFin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_BuscarFacturaReimpresion Procedure
        ''' </summary>
        Public Shared Function BuscarFacturaReimpresion(ByVal dFecIni As String, ByVal dFecFin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_BuscarFacturaReimpresion", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@dFecIni", dFecIni, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@dFecFin", dFecFin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_BuscarParametro Procedure
        ''' </summary>
        Public Shared Function BuscarParametro(ByVal cParametro As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_BuscarParametro", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cParametro", cParametro, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_BuscarProductoVenta Procedure
        ''' </summary>
        Public Shared Function BuscarProductoVenta(ByVal cProducto As String, ByVal nAlmacen As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_BuscarProductoVenta", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cProducto", cProducto, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@nAlmacen", nAlmacen, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_ListarEmpleados Procedure
        ''' </summary>
        Public Shared Function ListarEmpleados(ByVal cDato As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_ListarEmpleados", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cDato", cDato, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_ListarVentasDiarias Procedure
        ''' </summary>
        Public Shared Function ListarVentasDiarias(ByVal cFecha1 As String, ByVal cFecha2 As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_ListarVentasDiarias", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cFecha1", cFecha1, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@cFecha2", cFecha2, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_ObtenerListadoValor Procedure
        ''' </summary>
        Public Shared Function ObtenerListadoValor(ByVal nValor As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_ObtenerListadoValor", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nValor", nValor, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_SincronizarUsuario Procedure
        ''' </summary>
        Public Shared Function SincronizarUsuario() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_SincronizarUsuario", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spBuscaKardex Procedure
        ''' </summary>
        Public Shared Function SpBuscaKardex(ByVal userid As Nullable(Of Integer), ByVal sucursalid As Nullable(Of Integer), ByVal productoid As Nullable(Of Integer), ByVal fechainicio As Nullable(Of DateTime), ByVal fechafin As Nullable(Of DateTime)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spBuscaKardex", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@userid", userid, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@sucursalid", sucursalid, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@productoid", productoid, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.DateTime, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.DateTime, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_SPBuscarAlmacenesEmpleado Procedure
        ''' </summary>
        Public Shared Function SPBuscarAlmacenesEmpleado(ByVal userid As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_SPBuscarAlmacenesEmpleado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@userid", userid, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_SpClienteProductoConsolidado Procedure
        ''' </summary>
        Public Shared Function SpClienteProductoConsolidado(ByVal fechainicial As String, ByVal fechafinal As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_SpClienteProductoConsolidado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicial", fechainicial, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafinal", fechafinal, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spCobrosEmpleado Procedure
        ''' </summary>
        Public Shared Function SpCobrosEmpleado(ByVal empid As Nullable(Of Integer), ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spCobrosEmpleado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@empid", empid, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_SPCopiaSeguridad Procedure
        ''' </summary>
        Public Shared Function SPCopiaSeguridad() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_SPCopiaSeguridad", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spEmpleadoProductoConsolidado Procedure
        ''' </summary>
        Public Shared Function SpEmpleadoProductoConsolidado(ByVal fechainicial As String, ByVal fechafinal As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spEmpleadoProductoConsolidado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicial", fechainicial, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafinal", fechafinal, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spPagoConsolidado Procedure
        ''' </summary>
        Public Shared Function SpPagoConsolidado(ByVal fechainicial As String, ByVal fechafinal As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spPagoConsolidado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicial", fechainicial, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafinal", fechafinal, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReporteConsolidado Procedure
        ''' </summary>
        Public Shared Function SpReporteConsolidado(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReporteConsolidado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReporteEmpleadoPorMeses Procedure
        ''' </summary>
        Public Shared Function SpReporteEmpleadoPorMeses(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReporteEmpleadoPorMeses", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReporteGlobalProductos Procedure
        ''' </summary>
        Public Shared Function SpReporteGlobalProductos(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReporteGlobalProductos", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReportePreferencias Procedure
        ''' </summary>
        Public Shared Function SpReportePreferencias(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReportePreferencias", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReporteProductosPorMeses Procedure
        ''' </summary>
        Public Shared Function SpReporteProductosPorMeses(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReporteProductosPorMeses", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spReporteSucursalPorMeses Procedure
        ''' </summary>
        Public Shared Function SpReporteSucursalPorMeses(ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spReporteSucursalPorMeses", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spVence3Meses Procedure
        ''' </summary>
        Public Shared Function SpVence3Meses() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spVence3Meses", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spVencenMeses Procedure
        ''' </summary>
        Public Shared Function SpVencenMeses(ByVal fechaactual As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spVencenMeses", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechaactual", fechaactual, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spVentasEmpleado Procedure
        ''' </summary>
        Public Shared Function SpVentasEmpleado(ByVal empid As Nullable(Of Integer), ByVal fechainicio As String, ByVal fechafin As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spVentasEmpleado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@empid", empid, DbType.Int32, 0, 10)
        	    
            
            sp.Command.AddParameter("@fechainicio", fechainicio, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafin", fechafin, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spVentasPorVendedor Procedure
        ''' </summary>
        Public Shared Function SpVentasPorVendedor(ByVal fechainicial As String, ByVal fechafinal As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spVentasPorVendedor", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@fechainicial", fechainicial, DbType.AnsiString, Nothing, Nothing)
        	    
            
            sp.Command.AddParameter("@fechafinal", fechafinal, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_SPVerDatosAlmacen Procedure
        ''' </summary>
        Public Shared Function SPVerDatosAlmacen(ByVal almacenid As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_SPVerDatosAlmacen", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@almacenid", almacenid, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_spVerificarStock Procedure
        ''' </summary>
        Public Shared Function SpVerificarStock(ByVal almacenid As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_spVerificarStock", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@almacenid", almacenid, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerCabeceraLote Procedure
        ''' </summary>
        Public Shared Function VerCabeceraLote(ByVal cNumero As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerCabeceraLote", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cNumero", cNumero, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosBeneficiario Procedure
        ''' </summary>
        Public Shared Function VerDatosBeneficiario(ByVal cBeneficiario As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosBeneficiario", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cBeneficiario", cBeneficiario, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosCliente Procedure
        ''' </summary>
        Public Shared Function VerDatosCliente(ByVal cBusqueda As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosCliente", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cBusqueda", cBusqueda, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosEmpleado Procedure
        ''' </summary>
        Public Shared Function VerDatosEmpleado(ByVal cNombre As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosEmpleado", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cNombre", cNombre, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosGrupoTerapeutico Procedure
        ''' </summary>
        Public Shared Function VerDatosGrupoTerapeutico(ByVal cGrupoTer As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosGrupoTerapeutico", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cGrupoTer", cGrupoTer, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosProducto Procedure
        ''' </summary>
        Public Shared Function VerDatosProducto(ByVal cProducto As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosProducto", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cProducto", cProducto, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosProveedor Procedure
        ''' </summary>
        Public Shared Function VerDatosProveedor(ByVal cProveedor As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosProveedor", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cProveedor", cProveedor, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosRegion Procedure
        ''' </summary>
        Public Shared Function VerDatosRegion(ByVal cLugar As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosRegion", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cLugar", cLugar, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosSNIData Procedure
        ''' </summary>
        Public Shared Function VerDatosSNIData(ByVal dFecha As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosSNIData", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@dFecha", dFecha, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDatosSucursal Procedure
        ''' </summary>
        Public Shared Function VerDatosSucursal(ByVal cZona As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDatosSucursal", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cZona", cZona, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerDetalleLote Procedure
        ''' </summary>
        Public Shared Function VerDetalleLote(ByVal cNumero As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerDetalleLote", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cNumero", cNumero, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerFacturaCabecera Procedure
        ''' </summary>
        Public Shared Function VerFacturaCabecera(ByVal nFactura As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerFacturaCabecera", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nFactura", nFactura, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerFacturaDetalle Procedure
        ''' </summary>
        Public Shared Function VerFacturaDetalle(ByVal nFactura As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerFacturaDetalle", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nFactura", nFactura, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerFacturaPie Procedure
        ''' </summary>
        Public Shared Function VerFacturaPie(ByVal nFactura As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerFacturaPie", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nFactura", nFactura, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerLotesNoVencidos Procedure
        ''' </summary>
        Public Shared Function VerLotesNoVencidos() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerLotesNoVencidos", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerLotesVencidos Procedure
        ''' </summary>
        Public Shared Function VerLotesVencidos() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerLotesVencidos", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerOCCabecera Procedure
        ''' </summary>
        Public Shared Function VerOCCabecera(ByVal nCodPedido As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerOCCabecera", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nCodPedido", nCodPedido, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerOCDetalle Procedure
        ''' </summary>
        Public Shared Function VerOCDetalle(ByVal nCodPedido As Nullable(Of Integer)) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerOCDetalle", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@nCodPedido", nCodPedido, DbType.Int32, 0, 10)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerPreciosXLinea Procedure
        ''' </summary>
        Public Shared Function VerPreciosXLinea(ByVal cLinea As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerPreciosXLinea", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cLinea", cLinea, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerProductosDebajoStockMinimo Procedure
        ''' </summary>
        Public Shared Function VerProductosDebajoStockMinimo() As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerProductosDebajoStockMinimo", DataService.GetInstance("DALEjSuite"), "")
            
            Return sp
        End Function
        
        ''' <summary>
        ''' Creates an object wrapper for the EJS_VerZonas Procedure
        ''' </summary>
        Public Shared Function VerZonas(ByVal cDescripcion As String) As StoredProcedure 
            Dim sp As New SubSonic.StoredProcedure("EJS_VerZonas", DataService.GetInstance("DALEjSuite"), "dbo")
            
            sp.Command.AddParameter("@cDescripcion", cDescripcion, DbType.AnsiString, Nothing, Nothing)
        	    
            
            Return sp
        End Function
        
    End Class
        
End Namespace
