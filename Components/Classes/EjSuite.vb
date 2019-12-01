Imports Microsoft.VisualBasic
Imports DotNetNuke.Entities.Users
Imports SubSonic
Imports System.Data
Imports System.Data.SqlClient
Imports DotNetNuke.Security.Roles


Namespace EjSuite.Modules.EjSuite
    Public Class EjSuite

        ''' <summary>
        ''' Invoca las imagenes de su carpeta
        ''' </summary>
        ''' <param name="pFile">Nombre del archivo</param>
        ''' <returns>La ruta de la imagen </returns>
        ''' <remarks>ruta de la imagen</remarks>
        Public Shared Function ModuleImagePath(ByVal pFile As String) As String
            Return String.Format("~/DesktopModules/EjSuite/Images/{0}", pFile)
        End Function

        ''' <summary>
        ''' Convierte fechas a formato norteamericano
        ''' </summary>
        ''' <param name="cFecha">Fecha en formato dd/MM/yyyy</param>
        ''' <returns>Una fecha en formato MM/dd/yyyy</returns>
        ''' <remarks>a formato norteamericano</remarks>
        Public Shared Function ConvertToUsaFormat(ByVal cFecha As String)
            Return String.Format("{0}-{1}-{2}", cFecha.Substring(6, 4), cFecha.Substring(3, 2), cFecha.Substring(0, 2))
        End Function

        ''' <summary>
        ''' Convierte fechas de formato norteamericano a boliviano
        ''' </summary>
        ''' <param name="fecha">Fecha en formato M/d/y</param>
        ''' <returns>Una fecha en formato dd/MM/yyyy</returns>
        ''' <remarks>formato norteamericano a boliviano</remarks>
        Public Shared Function ConvertToBolivianFormat(ByVal fecha As String) As String
            Return String.Format("{0}/{1}/{2}", fecha.Substring(3, 2), fecha.Substring(0, 2), fecha.Substring(6, 4))
        End Function

        ''' <summary>
        ''' Convierte fechas de formato norteamericano a boliviano
        ''' </summary>
        ''' <param name="fecha">Fecha en formato M/d/y</param>
        ''' <returns>Una fecha en formato dd/MM/yyyy</returns>
        ''' <remarks>formato norteamericano a boliviano</remarks>
        Public Shared Function ConvertToBolivianFormat(ByVal fecha() As String) As String
            Dim numeros(3) As Integer
            numeros(0) = Integer.Parse(fecha(0))
            numeros(1) = Integer.Parse(fecha(1))
            numeros(2) = Integer.Parse(fecha(2))
            Return IIf(numeros(0) < 10, "0" & numeros(0).ToString(), numeros(0).ToString()) & _
                "/" & IIf(numeros(1) < 10, "0" & numeros(1).ToString(), numeros(1).ToString()) & _
                "/" & numeros(2).ToString()
        End Function

        ''' <summary>
        ''' Valida permisos de usuario
        ''' </summary>
        ''' <param name="cRol">Rol del usuario</param>
        ''' <returns>El permiso que tiene el usuario</returns>
        ''' <remarks>tiene el usuario</remarks>
        Public Shared Function ControlarAccesoUsuarios(ByVal cRol As String) As Boolean
            Dim bValido As Boolean = False

            Select Case cRol.ToLower()
                Case "ejs_managers"
                    Dim cRoleName As String = cRol.ToLower()
                    bValido = False
                    Dim oRoles As New OnlineUserInfo
                    Dim oUserRoles As New RoleController
                    Dim oUser As UserInfo = UserController.Instance.GetCurrentUserInfo()

                    For Each cIndice As String In oUser.Roles
                        If cIndice.ToLower = cRol.ToLower Then
                            bValido = True
                            Exit For
                        End If
                    Next
                    Return bValido
                Case "ejs_stores"
                    bValido = False
                    Dim oRoles As New OnlineUserInfo
                    Dim oUserRoles As New RoleController
                    Dim oUser As UserInfo = UserController.Instance.GetCurrentUserInfo()

                    For Each cIndice As String In oUser.Roles
                        If cIndice.ToLower = cRol.ToLower Then
                            bValido = True
                            Exit For
                        End If
                    Next
                    Return bValido
                Case "ejs_auxiliar"
                    bValido = False
                    Dim oRoles As New OnlineUserInfo
                    Dim oUserRoles As New RoleController
                    Dim oUser As UserInfo = UserController.Instance.GetCurrentUserInfo()

                    For Each cIndice As String In oUser.Roles
                        If cIndice.ToLower = cRol.ToLower Then
                            bValido = True
                            Exit For
                        End If
                    Next
                    Return bValido
                Case "ejs_vendedor"
                    bValido = False
                    Dim oRoles As New OnlineUserInfo
                    Dim oUserRoles As New RoleController
                    Dim oUser As UserInfo = UserController.Instance.GetCurrentUserInfo()

                    For Each cIndice As String In oUser.Roles
                        If cIndice.ToLower = cRol.ToLower Then
                            bValido = True
                            Exit For
                        End If
                    Next
                    Return bValido
                Case Else
                    Return False
            End Select
        End Function

        ''' <summary>
        ''' Genera el campo codificado que ira al codigo QR
        ''' </summary>
        ''' <param name="NITEmisor">NIT del emisor</param>
        ''' <param name="NumeroFactura">Número correlativo de Factura o Nota Fiscal</param>
        ''' <param name="NumeroAutorizacion">Número otorgado por la Administración Tributaria para identificar la dosificación</param>
        ''' <param name="FechaEmision">Con formato: DD/MM/AAAA</param>
        ''' <param name="MontoTotal">Monto total consignado en la Factura o Nota Fiscal, (utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <param name="ImporteCreditoFiscal">Monto válido para el cálculo del Crédito Fiscal, (utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <param name="CodigoControl">Código que identifica la transacción comercial realizada con la Factura o Nota Fiscal</param>
        ''' <param name="NitCiCex">NIT del comprador, en caso de no contar se consignará el número de Cédula de Identidad o Carnet de Extranjería o el carácter cero (0)</param>
        ''' <param name="ImporteIceIehdTasas">Monto ICE/IEHD/TASAS, en el caso de no corresponder consignar el carácter cero (0). (Utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <param name="ImporteVentasGravamen">Cuando corresponda, caso contrario se consignará el carácter cero (0). (Utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <param name="ImporteNoSujetoCreditoFiscal">Cuando corresponda, caso contrario se consignará el carácter cero  (0). (Utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <param name="DescuentosBonificacionesRebajas">Cuando corresponda, caso contrario se consignará el carácter cero (0). (Utilizando el punto . como separador de decimales para los centavos)</param>
        ''' <returns>Una cadena de 142 caracteres separada por el caracter |</returns>
        ''' <remarks>Genera el campo codificado</remarks>
        Public Shared Function ObtenerCodigoBaseQR(ByVal NITEmisor As String, ByVal NumeroFactura As String, ByVal NumeroAutorizacion As String, _
         ByVal FechaEmision As String, ByVal MontoTotal As String, ByVal ImporteCreditoFiscal As String, ByVal CodigoControl As String, _
         ByVal NitCiCex As String, ByVal ImporteIceIehdTasas As String, ByVal ImporteVentasGravamen As String, _
         ByVal ImporteNoSujetoCreditoFiscal As String, ByVal DescuentosBonificacionesRebajas As String) As String
            Dim cadenaQR As String = ""
            Try
                Return New [Select]("TOP 1 dbo.EJS_ObtenerCodigoBaseQR('" & NITEmisor & "','" & NumeroFactura & _
                                        "','" & NumeroAutorizacion & "','" & FechaEmision & "','" & MontoTotal & _
                                        "','" & ImporteCreditoFiscal & "','" & CodigoControl & "','" & NitCiCex & _
                                        "','" & ImporteIceIehdTasas & "','" & ImporteVentasGravamen & "','" & _
                                        ImporteNoSujetoCreditoFiscal & "','" & DescuentosBonificacionesRebajas & "') "). _
                                   From(Empleado.Schema).ExecuteScalar(Of String)()
            Catch exc As Exception
                Return exc.Message
            End Try
        End Function

        ''' <summary>
        ''' Funcion para generar el codigo de control
        ''' </summary>
        ''' <param name="aut">Número de Autorización</param>
        ''' <param name="fac">Número de la factura</param>
        ''' <param name="nit">Número de NIT del cliente</param>
        ''' <param name="fecha">Fecha en formato AAAAMMDD</param>
        ''' <param name="dd">Monto Decimal de la factura</param>
        ''' <param name="monto">Monto entero de la factura</param>
        ''' <param name="llave">Llave de dosificación</param>
        ''' <param name="fechalimite">Fecha Límite</param>
        ''' <returns>El codigo de control en formato hexadecimal</returns>
        ''' <remarks>codigo de control</remarks>
        Public Shared Function CargarCodigoControl(ByVal aut As Int64, ByVal fac As Int64, ByVal nit As Int64, _
                                         ByVal fecha As Int64, ByVal dd As Double, ByVal monto As Int64, _
                                         ByVal llave As String, ByVal fechalimite As String) As String
            Dim cCodigoControl As String = ""
            Try
                Return New [Select]("TOP 1 dbo.fnGeneracionCodigoControl('" & aut.ToString() & "','" & fac.ToString() & _
                                        "','" & nit.ToString() & "'," & fecha & "," & monto & ",'" & llave & "') "). _
                                   From(Empleado.Schema).ExecuteScalar(Of String)()
            Catch exc As Exception
                Return "00-00-00-00-00"
            End Try
        End Function

        ''' <summary>
        ''' Funcion para mostrar el literal de un monto
        ''' </summary>
        ''' <param name="nMonto">Monto en formato decimal</param>
        ''' <returns>El numero en literal con los centavos</returns>
        ''' <remarks>mostrar el literal </remarks>
        Public Shared Function ObtenerLiteral(ByVal nMonto As Decimal) As String
            Dim cLiteral As String = ""
            Try
                Dim cConsulta As String = "TOP 1 dbo.fnNumeroALetrasMoneda(" & nMonto.ToString().Replace(",", ".") & ") "
                Return New [Select](cConsulta).From(Empleado.Schema).ExecuteScalar(Of String)()
            Catch exc As Exception
                Return "CERO 00/100 BOLIVIANOS"
            End Try
        End Function

        ''' <summary>
        ''' Función para cargar los reportes del sistema
        ''' </summary>
        ''' <param name="cUsuario">Usuario</param>
        ''' <param name="cClave">Contraseña</param>
        ''' <param name="cDireccion">Direccion de los reportes</param>
        ''' <remarks>cargar los reportes</remarks>
        Public Shared Sub ObtenerAccesoReporte(ByRef cUsuario As String, ByRef cClave As String, ByRef cDireccion As String)
            Dim oParametro As New Parametro(Parametro.Columns.NCodParametro, 6)
            cDireccion = oParametro.CValorParametro
            oParametro = New Parametro(Parametro.Columns.NCodParametro, 7)
            cUsuario = oParametro.CValorParametro
            oParametro = New Parametro(Parametro.Columns.NCodParametro, 8)
            cClave = oParametro.CValorParametro
        End Sub

        ''' <summary>
        ''' Función para cargar los valores de los parámetros
        ''' </summary>
        ''' <param name="nCodParametro">Codigo del Parámetro</param>
        ''' <returns>El valor del parámetro solicitado</returns>
        ''' <remarks>valores de los parámetros</remarks>
        Public Shared Function ObtenerParametro(ByVal nCodParametro As Integer) As String
            Dim oParametro As New Parametro(Parametro.Columns.NCodParametro, nCodParametro)
            Return oParametro.CValorParametro
        End Function

        ''' <summary>
        ''' Funcion para cargar los valores del catalogo
        ''' </summary>
        ''' <param name="nCodValor">Codigo Numerico del Catalogo</param>
        ''' <param name="cCodValor">Valor texto del Catalogo</param>
        ''' <returns>El valor obtenido del catalogo</returns>
        ''' <remarks>valores del catalogo</remarks>
        Public Shared Function ObtenerValores(ByVal nCodValor As String, ByVal cCodValor As String) As String
            Try
                Dim oValor As Catalogo = New [Select](). _
                    From(Of Catalogo)().Where(Catalogo.Columns.NCodCatalogo).IsEqualTo(nCodValor). _
                    And(Catalogo.Columns.CCodCatalogo).IsEqualTo(cCodValor).ExecuteSingle(Of Catalogo)()
                Return oValor.CValorCatalogo
            Catch exc As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' Retorna un cuadro de mensaje para el usuario final
        ''' </summary>
        ''' <param name="upLienzo">Panel AJAX</param>
        ''' <param name="tValor">Valor de parametros</param>
        ''' <param name="cTexto">Texto en el mensaje</param>
        ''' <remarks>cuadro de mensaje</remarks>
        Public Shared Sub Mensaje(ByVal upLienzo As Control, ByVal tValor As Type, ByVal cTexto As String)
            Dim cScript As String = String.Format("<script language='javascript'>alert('{0} ');</script>", cTexto)
            ScriptManager.RegisterStartupScript(upLienzo, tValor, "Script", cScript, False)
        End Sub

        ''' <summary>
        ''' Presenta los valores de la empresa
        ''' </summary>
        ''' <returns>Retorna los datos de la empresa para mostrarlos en pantalla</returns>
        ''' <remarks>datos de la empresa</remarks>
        Public Shared Function GetEmpresa() As Empresa
            Dim oEmpresa As New Empresa(Empresa.Columns.NCodEmpresa, 1)
            Return oEmpresa
        End Function

    End Class
End Namespace



