Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteKardex
        Inherits EjSuiteModuleBase

        'Dim Mode As DisplayMode = DisplayMode.Normal
        Dim bImprimirAuto As Boolean = False
        Dim bCerrarAuto As Boolean = False

        Dim nEstadoRec As Integer
        Dim nTipoImp As Integer
        Dim ServerReportRec As Microsoft.Reporting.WebForms.ServerReport
        Dim cNumFactura As String = ""

        Public Enum nTipoProducto
            Clasico = 1
            Cuotas = 2
        End Enum

        Private Sub CargarKardex()
            Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
            Dim activId As Integer = New [Select](Aggregate.Max("nCodEmpleadoSucursal")). _
                From(Empleado.Schema).InnerJoin(EmpleadoSucursal.Schema). _
                Where(Empleado.Columns.NCodUsuario).IsEqualTo(Usrid). _
                ExecuteScalar(Of Integer)()
            Dim objActividad As EmpleadoSucursal
            Dim sucId As Integer = 0
            If activId <> 0 Then
                objActividad = EmpleadoSucursal.FetchByID(activId)
                sucId = CType(objActividad.NCodSucursal, Integer)
            Else
                sucId = 1
            End If
            '==========================================================================================================
            Dim rep As DataSet = SPs.SpBuscaKardex(Usrid, sucId, ProductoControlSearch1.ProductoId, _
                                                   txtFechainicialKardexB.Text, txtFechafinalKardexB.Text).GetDataSet
            grdKardex.DataSource = rep.Tables(0).DefaultView
            grdKardex.DataKeyNames() = New String() {KardexInventario.Columns.NCodKardex}
            grdKardex.DataBind()
            lblMessageKardex.Text = String.Format("Se encontraron: {0} registro(s)", rep.Tables(0).Rows.Count)
            panelbusKard.Visible = True
            lbtnExportarPDF.Visible = True
            GenerarIngresoAlmacen(Usrid, sucId, ProductoControlSearch1.ProductoId, _
                                                   txtFechainicialKardexB.Text, txtFechafinalKardexB.Text)
            rep = Nothing
        End Sub

        Public Sub GenerarIngresoAlmacen(ByVal nUsuario As Integer, ByVal nSucursal As Integer, ByVal nProducto As Integer, _
                                          dFechaInicio As Date, dFechaFinal As Date)
            Dim cUsuario As String = ""
            Dim cClave As String = ""
            Dim cDireccion As String = ""
            EjSuite.ObtenerAccesoReporte(cUsuario, cClave, cDireccion)

            Dim sUbiNomReporte As String = "/EjReports/rptKardexInventario"
            bImprimirAuto = True
            bCerrarAuto = True
            rptReporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            rptReporte.ShowParameterPrompts = False
            rptReporte.ShowExportControls = True
            rptReporte.ShowPrintButton = True

            Dim ServerReport As Microsoft.Reporting.WebForms.ServerReport
            ServerReport = rptReporte.ServerReport

            Dim Credentials As System.Net.ICredentials
            Credentials = System.Net.CredentialCache.DefaultCredentials

            'Dim rsCredentials As ReportServerCredentials
            'rsCredentials = ServerReport.ReportServerCredentials

            Dim cred As New ReportServerCredentials(cUsuario, cClave, ".")
            rptReporte.ServerReport.ReportServerCredentials = cred
            ServerReport.ReportServerUrl = New Uri(cDireccion)
            ServerReport.ReportPath = sUbiNomReporte

            Dim prmnUserid As New Microsoft.Reporting.WebForms.ReportParameter()
            prmnUserid.Name = "userid"
            prmnUserid.Values.Add(nUsuario)

            Dim prmcSucursalid As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcSucursalid.Name = "sucursalid"
            prmcSucursalid.Values.Add(nSucursal)

            Dim prmcProductoid As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcProductoid.Name = "nCodProducto"
            prmcProductoid.Values.Add(nProducto)

            Dim prmdFechaInicio As New Microsoft.Reporting.WebForms.ReportParameter()
            prmdFechaInicio.Name = "fechainicio"
            prmdFechaInicio.Values.Add(dFechaInicio)

            Dim prmcdFechaFinal As New Microsoft.Reporting.WebForms.ReportParameter()
            prmcdFechaFinal.Name = "fechafin"
            prmcdFechaFinal.Values.Add(dFechaFinal)

            Dim parameters() As Microsoft.Reporting.WebForms.ReportParameter = {prmnUserid, prmcSucursalid, _
                                                                                prmcProductoid, prmdFechaInicio, prmcdFechaFinal}
            ServerReport.SetParameters(parameters)
        End Sub

        Private Sub inicializar()
            txtFechainicialKardexB.Text = ""
            txtFechafinalKardexB.Text = ""
            lblMessageKardex.Text = ""
            ProductoControlSearch1.TextValue = "Elija un producto"
            lbtnExportarPDF.Visible = False
            'lbtnExportarPDF.Visible = False
            ProductoStockActual1.TextValue = "Elija un producto"
            ProductoStockActual1.ProductoId = Nothing
            ProductoStockActual1.StockActual = 0
            txtUnidadesAjusteK.Text = ""
            txtDocumentoAjusteK.Text = ""
            txtGlosaAjusteK.Text = ""
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaKardex.Visible = False
                pnlAjusteKardex.Visible = False
                pnlGeneral.Visible = False
                Page.EnableViewState = True
                inicializar()
            End If
        End Sub

        Protected Sub cmdSearchKardexB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchKardexB.Click
            CargarKardex()
        End Sub

        Protected Sub cmdCancelKardex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelKardexB.Click
            pnlBusquedaKardex.Visible = False
            pnlAjusteKardex.Visible = False
        End Sub
        Protected Sub grdKardex_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdKardex.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdKardex.PageIndex = indice
            CargarKardex()
        End Sub

        Protected Sub grdKardex_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdKardex.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdKardex.DataKeys(indice).Value, Integer)
                    Dim objKardex As New KardexInventario(cod)
                    Dim hypKardex As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    hypKardex.Text = objKardex.DFechareg.ToShortDateString()
                    Dim hypKardex2 As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypKardex2.Text = String.Format("{0:F}", objKardex.NPrecioCompra)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdKardex_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdKardex.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypKardex As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(0).Controls.Add(hypKardex)
                    Dim hypKardex2 As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(2).Controls.Add(hypKardex2)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub lbtnExportarPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarPDF.Click
            If grdKardex.Rows.Count > 0 Then
                Me.lbtnExportarPDF_ModalPopupExtender.Show()
            End If
        End Sub

        Protected Sub cmdInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsert.Click
            If Page.IsValid AndAlso ProductoStockActual1.ProductoId <> Nothing AndAlso CInt(txtUnidadesAjusteK.Text) >= 0 Then
                Dim Usrid As Integer = CType(UserController.Instance.GetCurrentUserInfo().UserID, Integer)
                Dim objNewKardex As New KardexInventario
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, Usrid)
                Dim objActividad As New EmpleadoSucursal(EmpleadoSucursal.Columns.NCodEmpleado, objEmpleado.NCodEmpleado)
                Dim objSucursal As New Sucursal(Sucursal.Columns.NCodSucursal, objActividad.NCodSucursal)
                Dim objAlmacen As New Almacen(Almacen.Columns.NCodSucursal, objSucursal.NCodSucursal)
                Dim AlmacnId As Integer = CInt(objAlmacen.NCodAlmacen)
                Dim LoteId As Integer = New [Select](Aggregate.Max("nCodLote")). _
                        From(KardexInventario.Schema). _
                        Where(KardexInventario.NCodAlmacenColumn).IsEqualTo(AlmacnId). _
                        And(KardexInventario.NCodProductoColumn).IsEqualTo(ProductoStockActual1.ProductoId). _
                        ExecuteScalar(Of Integer)()

                objNewKardex.NCodAlmacen = AlmacnId
                objNewKardex.NCodLote = LoteId
                objNewKardex.NCodProducto = ProductoStockActual1.ProductoId
                objNewKardex.DFechareg = Now().Date
                objNewKardex.CObservacion = txtDocumentoAjusteK.Text
                Dim objProducto As New Producto(ProductoStockActual1.ProductoId)
                objNewKardex.NPrecioCompra = objProducto.NPrecioCompra
                objNewKardex.NEntrada = 0
                objNewKardex.NSalida = 0
                objNewKardex.NEntradaSueltos = 0
                objNewKardex.NSalidaSueltos = 0
                objNewKardex.NStockAnteriorEnvase = CDec(ProductoStockActual1.StockActual)
                objNewKardex.NStockActualEnvase = CDec(txtUnidadesAjusteK.Text)
                objNewKardex.NStockAnteriorSuelto = 0
                objNewKardex.NStockActualSuelto = 0
                objNewKardex.NCostoTotal = CDec(objProducto.NPrecioCompra) * CDec(txtUnidadesAjusteK.Text)
                objNewKardex.CGlosa = txtGlosaAjusteK.Text
                objNewKardex.NPrecioAlmacen = 0
                objNewKardex.NPrecioVenta = 0
                objNewKardex.NCodKardex = New [Select]("nCodkardex").From(KardexInventario.Schema).ExecuteScalar(Of Integer)() + 1
                objNewKardex.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Ajuste realizado exitosamente!")
                pnlBusquedaKardex.Visible = False
                pnlAjusteKardex.Visible = False
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            pnlBusquedaKardex.Visible = False
            pnlAjusteKardex.Visible = False
        End Sub

        Protected Sub ddlOpcion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlOpcion.SelectedIndexChanged

            Select Case ddlOpcion.SelectedValue.ToString()
                Case "1"
                    Dim q As New Query(Vwdatakardex.Schema)
                    q.AddWhere(Vwdatakardex.Columns.NStockActualEnvase, Comparison.GreaterThan, 0)
                    Dim oCollection As New OrderByCollection
                    oCollection.Add(OrderBy.Asc("proveedor"))
                    oCollection.Add(OrderBy.Asc("insumo"))
                    q.OrderByCollection = oCollection
                    Dim lst1 As New VwdatakardexCollection()
                    lst1.LoadAndCloseReader(q.ExecuteReader())
                    grdGeneral.DataSource = lst1
                    grdGeneral.DataKeyNames() = New String() {"insumo"}
                    grdGeneral.DataBind()
                    lblMessageKardex.Text = String.Format("Se encontraron: {0} registro(s)", grdGeneral.Rows.Count)
                Case "0"
                    Dim q As New Query(Vwdatakardex.Schema)
                    q.AddWhere(Vwdatakardex.Columns.NStockActualEnvase, 0)
                    Dim oCollection As New OrderByCollection
                    oCollection.Add(OrderBy.Asc("proveedor"))
                    oCollection.Add(OrderBy.Asc("insumo"))
                    q.OrderByCollection = oCollection
                    Dim lst1 As New VwdatakardexCollection()
                    lst1.LoadAndCloseReader(q.ExecuteReader())
                    grdGeneral.DataSource = lst1
                    grdGeneral.DataKeyNames() = New String() {"insumo"}
                    grdGeneral.DataBind()
                    lblMessageKardex.Text = String.Format("Se encontraron: {0} registro(s)", grdGeneral.Rows.Count)
                Case Else
                    Dim q As New Query(Vwdatakardex.Schema)
                    Dim lst1 As New VwdatakardexCollection()
                    lst1.LoadAndCloseReader(q.ExecuteReader())
                    Dim oCollection As New OrderByCollection
                    oCollection.Add(OrderBy.Asc("proveedor"))
                    oCollection.Add(OrderBy.Asc("insumo"))
                    q.OrderByCollection = oCollection
                    grdGeneral.DataSource = lst1
                    grdGeneral.DataKeyNames() = New String() {"insumo"}
                    grdGeneral.DataBind()
                    lblMessageKardex.Text = String.Format("Se encontraron: {0} registro(s)", grdGeneral.Rows.Count)
            End Select
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlBusquedaKardex.Visible = True
            panelbusKard.Visible = True
            pnlAjusteKardex.Visible = False
            pnlGeneral.Visible = False
            grdKardex.DataSource = Nothing
            grdKardex.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            Dim AdminSettings As Boolean = DotNetNuke.Security.PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleName)
            If AdminSettings Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                inicializar()
                pnlBusquedaKardex.Visible = False
                pnlAjusteKardex.Visible = True
                panelAjusteKardex.Visible = True
                pnlGeneral.Visible = False
                grdKardex.DataSource = Nothing
                grdKardex.DataBind()
            End If
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlBusquedaKardex.Visible = False
            pnlAjusteKardex.Visible = False
            panelAjusteKardex.Visible = False
            pnlGeneral.Visible = True
            grdKardex.DataSource = Nothing
            grdKardex.DataBind()
        End Sub

        Protected Sub lbtnCerrar_Click(sender As Object, e As EventArgs) Handles lbtnCerrar.Click
            Me.lbtnExportarPDF_ModalPopupExtender.Hide()
        End Sub
    End Class
End Namespace
