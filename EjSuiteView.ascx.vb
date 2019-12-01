'
' Copyright (c) 2019-2031 EjSuite Notes®
' All rights reserved.
'

Imports System
Imports DotNetNuke
Imports DotNetNuke.Security
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Services.Localization
Imports Infragistics.Web.UI
Imports System.Collections
Imports DotNetNuke.Common.Utilities
Imports System.Web.UI.HtmlControls
Imports System.Reflection
Imports SubSonic
Imports System.Web.UI
Imports EjSuite.Modules.EjSuite
Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Services.Personalization
Imports Infragistics.Web.UI.NavigationControls

Namespace EjSuite.Modules.EjSuite

    ''' <summary>
    ''' Presenta el contenido modular
    ''' </summary>
    Partial Class EjSuiteView
        Inherits EjSuiteModuleBase

#Region "Event Handlers"
        ''' <summary>
        ''' Inicio del software EjSuite
        ''' </summary>
        ''' <param name="sender">Envio de objetos de la pagina</param>
        ''' <param name="e">Eventos de la pagina</param>
        ''' <remarks>software EjSuite</remarks>
        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            If DotNetNuke.Framework.AJAX.IsInstalled.Equals(True) Then
                DotNetNuke.Framework.AJAX.RegisterScriptManager()
                Dim oScript As ScriptManager = CType(DotNetNuke.Framework.AJAX.GetScriptManager(Page), ScriptManager)
                oScript.EnableScriptGlobalization = True
                oScript.EnableScriptLocalization = True
            End If
            AddMyStyles()
            LoadSubControlTitle()
            LoadSubControls()
        End Sub

        ''' <summary>
        ''' Adicionar hojas de estilo externas
        ''' </summary>
        ''' <remarks>hojas de estilo</remarks>
        Protected Sub AddMyStyles()
            Dim oCSS As Control = Me.Page.FindControl("CSS")
            Dim oCache As Hashtable = CType(DataCache.GetCache("CSS"), Hashtable)
            If oCache Is Nothing Then
                oCache = New Hashtable
            End If
            If Not oCSS Is Nothing Then
                Dim oEnlace As HtmlGenericControl = New HtmlGenericControl("LINK")
                Dim cEstilos As String = EjSuite.ObtenerParametro(5)
                Dim cID As String = "style1"
                oEnlace.ID = cID
                oEnlace.Attributes("rel") = "stylesheet"
                oEnlace.Attributes("type") = "text/css"
                oEnlace.Attributes("href") = cEstilos
                oCSS.Controls.Add(oEnlace)
            End If
        End Sub

        ''' <summary>
        ''' Cargar Encabezados de los subcontroles
        ''' </summary>
        ''' <remarks>Encabezados</remarks>
        Private Sub LoadSubControlTitle()
            Try
                Me.ModuleConfiguration.ModuleTitle = "EjSuite"
                Dim cControl As String = ("" & Request("EjSuiteSubControl"))
                If cControl = "" Then cControl = "bienvenido"
                Me.EjSuitePageTitle = Localization.GetString(cControl.ToLower & ".Title", LocalResourceFile)
                Me.EjSuitePageDescription = Localization.GetString(cControl.ToLower & ".Description", LocalResourceFile)
            Catch oExcepcion As Exception
                ProcessModuleLoadException(Me, oExcepcion)
            End Try
        End Sub

        ''' <summary>
        ''' Cargar subcontroles
        ''' </summary>
        ''' <remarks>subcontroles</remarks>
        Private Sub LoadSubControls()
            Try
                Dim cControl As String = ("" & Request("EjSuiteSubControl")).ToLower

                Dim oPortal As EjSuiteModuleBase = Nothing
                If cControl = "" Then cControl = "bienvenido"
                Select Case cControl
                    Case "bienvenido"
                        oPortal = LoadSubControl("EjSuiteBienvenido")
                    'MAESTROS
                    Case "vendedores"
                        oPortal = LoadSubControl("EjSuiteVisitadores")
                    Case "asignaciones"
                        oPortal = LoadSubControl("EjSuiteAsignaciones")
                    Case "productos"
                        oPortal = LoadSubControl("EjSuiteProductos")
                    Case "proveedor"
                        oPortal = LoadSubControl("EjSuiteProveedores")
                    Case "clientes"
                        oPortal = LoadSubControl("EjSuiteClientes")
                    Case "zonas"
                        oPortal = LoadSubControl("EjSuiteZonas")
                    Case "beneficiarios"
                        oPortal = LoadSubControl("EjSuiteBeneficiarios")
                    Case "listagrupos"
                        oPortal = LoadSubControl("EjSuiteListaGrupos")
                    'ALMACENES
                    Case "ingresos"
                        oPortal = LoadSubControl("EjSuiteIngresos")
                    Case "traspasos"
                        oPortal = LoadSubControl("EjSuiteTraspasos")
                    Case "valeconsumo"
                        oPortal = LoadSubControl("EjSuiteValeConsumo")
                    Case "vencidos"
                        oPortal = LoadSubControl("EjSuiteVencidos")
                    Case "kardex"
                        oPortal = LoadSubControl("EjSuiteKardex")
                    Case "ajusteprecios"
                        oPortal = LoadSubControl("EjSuiteAjustePrecios")
                    Case "pedidos"
                        oPortal = LoadSubControl("EjSuitePedido")
                    'VENTAS
                    Case "pedfacturacion"
                        oPortal = LoadSubControl("EjSuitePedidoFacturacion")
                    Case "importpedido"
                        oPortal = LoadSubControl("EjSuiteImportPedido")
                    Case "ajusteventas"
                        oPortal = LoadSubControl("EjSuiteAjusteVentas")
                    Case "repventas"
                        oPortal = LoadSubControl("EjSuiteRepVentas")
                    Case "cotizacion"
                        oPortal = LoadSubControl("EjSuiteCotizacion")
                    Case "comisiones"
                        oPortal = LoadSubControl("EjSuiteComisiones")
                    'COBRANZAS
                    Case "repcobros"
                        oPortal = LoadSubControl("EjSuiteRepCobros")
                    Case "repfichas"
                        oPortal = LoadSubControl("EjSuiteRepFichas")
                    Case "repextracto"
                        oPortal = LoadSubControl("EjSuiteRepExtracto")
                    Case "pagoscuenta"
                        oPortal = LoadSubControl("EjSuitePagosCuenta")
                    Case "pagoscheque"
                        oPortal = LoadSubControl("EjSuitePagosCheque")
                    Case "clientemora"
                        oPortal = LoadSubControl("EjSuiteClienteMora")
                    Case "reportekardex"
                        oPortal = LoadSubControl("EjSuiteReporteKardex")
                    'GERENCIA
                    Case "datossni"
                        oPortal = LoadSubControl("EjSuiteDatosSni")
                    Case "repsucursal"
                        oPortal = LoadSubControl("EjSuiteRepSucursal")
                    Case "repgeneral"
                        oPortal = LoadSubControl("EjSuiteRepGeneral")
                    Case "repdavinci"
                        oPortal = LoadSubControl("EjSuiteRepDaVinci")
                    Case "android"
                        oPortal = LoadSubControl("EjSuiteAndroid")
                    Case "objetivosmes"
                        oPortal = LoadSubControl("EjSuiteObjetivos")
                    Case "reportes3d"
                        oPortal = LoadSubControl("EjSuiteReports3D")
                    Case "repvendedores"
                        oPortal = LoadSubControl("EjSuiteRepVendedores")
                    'REPORTE IMPUESTOS
                    Case "ventasporzona"
                        oPortal = LoadSubControl("EjSuiteVentasPorZona")
                    Case "impuestos"
                        oPortal = LoadSubControl("EjSuiteImpuestos")
                    Case Else
                        Exit Select
                End Select
                If Not oPortal Is Nothing Then
                    oPortal.ModuleConfiguration = Me.ModuleConfiguration
                    phSubControls.Controls.Add(oPortal)
                End If
            Catch oExcepcion As Exception
                ProcessModuleLoadException(Me, oExcepcion)
            End Try
        End Sub

        ''' <summary>
        ''' Cargar el SubControl en el PlaceHolder
        ''' </summary>
        ''' <param name="cMiControl">Nombre del control</param>
        ''' <returns>El control cargado como modulo base</returns>
        ''' <remarks>modulo base</remarks>
        Private Function LoadSubControl(ByVal cMiControl As String) As EjSuiteModuleBase
            Dim oPortal As EjSuiteModuleBase = Nothing
            Try
                oPortal = CType(Me.LoadControl(String.Format("SubControls/EjSuiteX/{0}.ascx", cMiControl)), EjSuiteModuleBase)
                oPortal.ModuleConfiguration = Me.ModuleConfiguration
                oPortal.ID = cMiControl
            Catch oExcepcion As Exception
                ProcessModuleLoadException(Me, oExcepcion)
            End Try
            Return oPortal
        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not IsPostBack Then

                End If
            Catch oExcepcion As Exception
                ProcessModuleLoadException(Me, oExcepcion)
            End Try
        End Sub

        ''' <summary>
        ''' Inicializar el menu principal
        ''' </summary>
        ''' <param name="sender">Envio de parametro</param>
        ''' <param name="e">Envio de eventos</param>
        ''' <remarks>menu principal</remarks>
        Protected Sub webExplorador_Init(ByVal sender As Object, ByVal e As EventArgs) Handles webExplorador1.Init
            Dim oGrupo1 As New DataMenuItem
            Dim oGrupo2 As New DataMenuItem
            Dim oGrupo3 As New DataMenuItem
            Dim oGrupo4 As New DataMenuItem
            Dim oGrupo5 As New DataMenuItem
            Dim oGrupo6 As New DataMenuItem
            Dim oSubItem As DataMenuItem
            webExplorador1.GroupSettings.Orientation = Orientation.Horizontal
            Dim bAdmin As Boolean = DotNetNuke.Security.PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleName)

            ' REGISTROS MAESTROS
            oGrupo1.Text = "Registros"
            oGrupo1.Value = ""
            webExplorador1.Items.Add(oGrupo1)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Vendedores")
                oSubItem.Target = "_self"
                oSubItem.Value = "Vendedores"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Vendedores", "EjSuiteSub")
                oSubItem.ImageUrl = Me.ModuleImagePath("cat_foru.gif")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Asignaciones")
                oSubItem.Target = "_self"
                oSubItem.Value = "Asignaciones"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Asignaciones", "EjSuiteSub")
                oSubItem.ImageUrl = Me.ModuleImagePath("compass.gif")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Productos")
                oSubItem.Target = "_self"
                oSubItem.Value = "Productos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Productos", "EjSuiteSub")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Proveedor")
                oSubItem.Target = "_self"
                oSubItem.Value = "Proveedor"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Proveedor", "EjSuiteSub")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Clientes")
                oSubItem.Target = "_self"
                oSubItem.Value = "Clientes"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Clientes", "EjSuiteSub")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Zonas")
                oSubItem.Target = "_self"
                oSubItem.Value = "Zonas"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Zonas", "EjSuiteSub")
                oGrupo1.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Beneficiarios")
                oSubItem.Target = "_self"
                oSubItem.Value = "Beneficiarios"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Beneficiarios", "EjSuiteSub")
                oGrupo1.Items.Add(oSubItem)
            End If
            If oGrupo1.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo1)
            End If

            'ALMACENES
            oGrupo2.Text = "Inventarios"
            oGrupo2.Value = ""
            webExplorador1.Items.Add(oGrupo2)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_stores") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Ingresos/Guias de Ingreso")
                oSubItem.Target = "_self"
                oSubItem.Value = "ingresos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Ingresos", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" Then
                oSubItem = New DataMenuItem("Traspasos")
                oSubItem.Target = "_self"
                oSubItem.Value = "traspasos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Traspasos", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Vale de consumo")
                oSubItem.Target = "_self"
                oSubItem.Value = "valeconsumo"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Valeconsumo", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_stores") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Vencimientos", "vencidos")
                oSubItem.Target = "_self"
                oSubItem.Value = ""
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Vencidos", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_stores") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Kardex")
                oSubItem.Target = "_self"
                oSubItem.Value = "kardex"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Kardex", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" Then
                oSubItem = New DataMenuItem("Ajuste de Precios")
                oSubItem.Target = "_self"
                oSubItem.Value = "ajusteprecios"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Ajusteprecios", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_stores") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Pedidos")
                oSubItem.Target = "_self"
                oSubItem.Value = "pedidos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Pedidos", "EjSuiteSub")
                oGrupo2.Items.Add(oSubItem)
            End If
            If oGrupo2.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo2)
            End If

            'VENTAS
            oGrupo3.Text = "Ventas"
            oGrupo3.Value = ""
            webExplorador1.Items.Add(oGrupo3)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Facturación")
                oSubItem.Target = "_self"
                oSubItem.Value = "pedfacturacion"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Pedfacturacion", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Reimprimir Facturas")
                oSubItem.Target = "_self"
                oSubItem.Value = "android"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Android", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If

            If bAdmin Or UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" Then
                oSubItem = New DataMenuItem("Ajuste de Ventas")
                oSubItem.Target = "_self"
                oSubItem.Value = "ajusteventas"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Ajusteventas", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Reporte de Ventas")
                oSubItem.Target = "_self"
                oSubItem.Value = "repventas"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Repventas", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Cotización")
                oSubItem.Target = "_self"
                oSubItem.Value = "cotizacion"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Cotizacion", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Comisiones")
                oSubItem.Target = "_self"
                oSubItem.Value = "comisiones"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Comisiones", "EjSuiteSub")
                oGrupo3.Items.Add(oSubItem)
            End If
            If oGrupo3.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo3)
            End If

            'CUENTAS POR COBRAR
            oGrupo4.Text = "Cuentas Pendientes"
            oGrupo4.Value = ""
            webExplorador1.Items.Add(oGrupo4)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Facturar Creditos")
                oSubItem.Target = "_self"
                oSubItem.Value = "importpedido"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "ImportPedido", "EjSuiteSub")
                oGrupo4.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Pagos A Cuenta")
                oSubItem.Target = "_self"
                oSubItem.Value = "pagoscuenta"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "PagosCuenta", "EjSuiteSub")
                oGrupo4.Items.Add(oSubItem)
            End If
            'If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
            '    oSubItem= New DataMenuItem("Pagos en Cheque", "pagoscheque")
            '    oSubItem.Target = "_self"
            '    oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "PagosCheque", "EjSuiteSub")
            '    oGrupo.Items.Add(oSubItem)
            'End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Reporte de Deudas")
                oSubItem.Target = "_self"
                oSubItem.Value = "repcobros"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepCobros", "EjSuiteSub")
                oGrupo4.Items.Add(oSubItem)
            End If
            'If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
            '    oSubItem= New DataMenuItem("Ficha Cuenta", "repfichas")
            '    oSubItem.Target = "_self"
            '    oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepFichas", "EjSuiteSub")
            '    oGrupo.Items.Add(oSubItem)
            'End If
            'If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
            '    oSubItem= New DataMenuItem("Extracto de Cuentas", "repextracto")
            '    oSubItem.Target = "_self"
            '    oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepExtracto", "EjSuiteSub")
            '    oGrupo.Items.Add(oSubItem)
            'End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Etiquetas")
                oSubItem.Target = "_self"
                oSubItem.Value = "clientemora"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "ClienteMora", "EjSuiteSub")
                oGrupo4.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Reporte Kardex")
                oSubItem.Target = "_self"
                oSubItem.Value = "reportekardex"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "ReporteKardex", "EjSuiteSub")
                oGrupo4.Items.Add(oSubItem)
            End If
            If oGrupo4.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo4)
            End If

            'GERENCIA
            oGrupo5.Text = "Gerencia"
            oGrupo5.Value = ""
            webExplorador1.Items.Add(oGrupo5)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Datos SNI")
                oSubItem.Target = "_self"
                oSubItem.Value = "datossni"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "DatosSni", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Reportes Preferencias del Cliente")
                oSubItem.Target = "_self"
                oSubItem.Value = "repsucursal"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepSucursal", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Reportes Generales")
                oSubItem.Target = "_self"
                oSubItem.Value = "repgeneral"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepGeneral", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Reporte Da Vinci")
                oSubItem.Target = "_self"
                oSubItem.Value = "repdavinci"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepDaVinci", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If

            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Grupos de productos")
                oSubItem.Target = "_self"
                oSubItem.Value = "listagrupos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "ListaGrupos", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                oSubItem = New DataMenuItem("Reporte Vendedores")
                oSubItem.Target = "_self"
                oSubItem.Value = "repvendedores"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "RepVendedores", "EjSuiteSub")
                oGrupo5.Items.Add(oSubItem)
            End If

            If oGrupo5.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo5)
            End If

            'REPORTE IMPUESTOS 
            oGrupo6.Text = "Impuestos"
            oGrupo6.Value = ""
            webExplorador1.Items.Add(oGrupo6)
            If bAdmin Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Or EjSuite.ControlarAccesoUsuarios("ejs_auxiliar") Then
                oSubItem = New DataMenuItem("Impuestos")
                oSubItem.Target = "_self"
                oSubItem.Value = "impuestos"
                oSubItem.NavigateUrl = EditUrl("EjSuiteSubControl", "Impuestos", "EjSuiteSub")
                oGrupo6.Items.Add(oSubItem)
            End If

            If oGrupo6.Items.Count = 0 Then
                webExplorador1.Items.Remove(oGrupo6)
            End If

        End Sub

        ''' <summary>
        ''' Controla clics del menu principal
        ''' </summary>
        ''' <param name="sender">Envio de parametros</param>
        ''' <param name="e">Envio de eventos</param>
        ''' <remarks>clics del menu</remarks>
        Protected Sub webExplorador_ItemClick(sender As Object, e As Infragistics.Web.UI.NavigationControls.DataMenuItemEventArgs) Handles webExplorador1.ItemClick
            Response.Redirect(EditUrl("FarmedSubControl", Convert.ToString(e.Item.Value), "FarmedgisSub"), True)
        End Sub

        ''' <summary>
        ''' Obtiene la descripcion del elemento de menu actual
        ''' </summary>
        ''' <value>Descripcion del Menú</value>
        ''' <returns>Descripcion del Menú</returns>
        ''' <remarks>Descripcion del Menú</remarks>
        Public Property EjSuitePageDescription() As String
            Get
                Return Me.lblPageDescription.Text
            End Get
            Set(ByVal value As String)
                Me.lblPageDescription.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Obtiene el titulo del elemento de menu actual
        ''' </summary>
        ''' <value>Tiulo del Menu</value>
        ''' <returns>Titulo del menu</returns>
        ''' <remarks>Titulo del menu</remarks>
        Public Property EjSuitePageTitle() As String
            Get
                Return Me.lblPageDescriptionTitle.Text
            End Get
            Set(ByVal value As String)
                Me.lblPageDescriptionTitle.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Accede a las imagenes del modulo
        ''' </summary>
        ''' <param name="cFile">Nombre del archivo con extension</param>
        ''' <returns>La ruta completa de la imagen</returns>
        ''' <remarks>ruta completa</remarks>
        Public Function ModuleImagePath(ByVal cFile As String)
            Return String.Format("~/DesktopModules/EjSuite/images/{0}", cFile)
        End Function
#End Region
    End Class

End Namespace
