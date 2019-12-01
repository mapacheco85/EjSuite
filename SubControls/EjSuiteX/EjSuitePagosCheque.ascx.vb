Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuitePagosCheque
        Inherits EjSuiteModuleBase

        Private Sub cargarPagos()
            Dim qryPagos As New Query(VwPago.Schema)
            If txtBuscarPagos.Text.Trim() <> "" OrElse txtInicio.Text <> "" OrElse txtFinal.Text <> "" Then
                qryPagos.AddWhere(VwPago.Columns.CCliente, Comparison.Like, "%" & txtBuscarPagos.Text & "%")
                'qryPagos.OR(VwPago.Columns.Vendedor, Comparison.Like, "%" & txtBuscarPagos.Text & "%")
                qryPagos.BETWEEN_AND(VwPago.Columns.DFechaPago, txtInicio.Text, txtFinal.Text)
            End If

            qryPagos.ORDER_BY(VwPago.Columns.NCodPago)
            Dim lst As New VwPagoCollection
            lst.LoadAndCloseReader(qryPagos.ExecuteReader())
            lblMessageBusquedaPagos.Text = "Se encontraron " & lst.Count.ToString() & " registros"
            grdBusquedaPagos.DataSource = lst
            grdBusquedaPagos.DataKeyNames = New String() {VwPago.Columns.NCodPago}
            grdBusquedaPagos.DataBind()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlPagos.Visible = False
                pnlBusquedaPagos.Visible = False
                txtFechaPago.Text = Now.Date.ToShortDateString
                PagoCliente1.TextValue = "Elija un cliente"
                txtMontoPago.Text = ""
                txtNumChequePago.Text = ""
                txtBancoChequePago.Text = ""
                txtFechaCobroChequePago.Text = ""
            End If
        End Sub

        Protected Sub cmdInsertPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertPago.Click
            Try
                Dim facto As New Factura(PagoCliente1.nCodFactura)
                Dim fechaaux As Date = CDate(txtFechaCobroChequePago.Text)
                If Page.IsValid AndAlso PagoCliente1.ClienteId.ToString <> "" AndAlso PagoCliente1.nCodFactura.ToString <> "" AndAlso facto.DFechaEmision <= fechaaux AndAlso (CDec(txtMontoPago.Text) > 0 AndAlso CDec(txtMontoPago.Text) <= CDec(PagoCliente1.SaldoTextValue)) Then
                    Dim objNewPago As New PagoCuentaXCobrar()
                    objNewPago.NCodPago = PagoCliente1.nCodFactura
                    objNewPago.NMontoPagado = CDec(txtMontoPago.Text)
                    objNewPago.CBancoCobro = txtBancoChequePago.Text
                    objNewPago.BCheque = True
                    objNewPago.CNroCheque = txtNumChequePago.Text
                    objNewPago.DFechaCobro = CDate(txtFechaCobroChequePago.Text)
                    objNewPago.NSaldo = CDec(PagoCliente1.Saldo.ToString.Replace(".", ",")) - CDec(txtMontoPago.Text.Replace(".", ","))
                    If objNewPago.NSaldo < 0 Then
                        objNewPago.NSaldo = 0.0
                    End If
                    objNewPago.DFechaPago = CDate(txtFechaPago.Text)
                    objNewPago.NCodCobrador = VendedorControlSearch1.EmpleadoId
                    objNewPago.Save()
                    pnlPagos.Visible = True

                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Pago ingresado exitosamente!")
                    '============================================================================
                    Dim objFactura As New Factura(PagoCliente1.nCodFactura)
                    If objNewPago.NSaldo <= 0.0099D Then
                        objFactura.BPagada = True
                        objFactura.BPendiente = False
                        objFactura.Save()
                        PagoCliente1.TextValue = "Elija un cliente"
                        PagoCliente1.ClienteId = Nothing
                    Else
                        objFactura.BPagada = False
                        objFactura.BPendiente = True
                        objFactura.Save()
                    End If
                    '============================================================================
                    grdPagos.DataSource = Nothing
                    grdPagos.DataBind()
                    lblClientePago.Text = PagoCliente1.TextValue
                    lblFacturaPago.Text = objFactura.NNumero
                    Dim qryPagos As New Query(PagoCuentaXCobrar.Schema)
                    qryPagos.AddWhere(PagoCuentaXCobrar.Columns.NFacturaId, PagoCliente1.nCodFactura)
                    Dim lst As New PagoCuentaXCobrarCollection
                    lst.LoadAndCloseReader(qryPagos.ExecuteReader())
                    grdPagos.DataSource = lst
                    grdPagos.DataKeyNames = New String() {PagoCuentaXCobrar.Columns.NCodPago}
                    grdPagos.DataBind()
                    panelVerPagos.Visible = True
                    '============================================================================
                    txtFechaPago.Text = Now.Date.ToShortDateString
                    PagoCliente1.FacturaSelected = "Elija una Factura"
                    PagoCliente1.nCodFactura = Nothing
                    PagoCliente1.SaldoTextValue = ""
                    PagoCliente1.Saldo = Nothing
                    txtMontoPago.Text = ""
                    txtNumChequePago.Text = ""
                    txtBancoChequePago.Text = ""
                    txtFechaCobroChequePago.Text = ""
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Compruebe si los datos de fechas y montos son correctos!")
                End If
            Catch

            End Try
        End Sub

        Protected Sub cmdCancelPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelPago.Click
            txtFechaPago.Text = ""
            txtMontoPago.Text = ""
            txtNumChequePago.Text = ""
            txtBancoChequePago.Text = ""
            txtFechaCobroChequePago.Text = ""
            pnlPagos.Visible = False
            pnlBusquedaPagos.Visible = False
        End Sub

        Protected Sub grdPagos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPagos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdPagos.DataKeys(indice).Value, Integer)
                    Dim objPago As New PagoCuentaXCobrar(cod)
                    Dim hypPago As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    hypPago.Text = objPago.DFechaPago
                    Dim objEmpleado As New Empleado(objPago.NCodCobrador)
                    Dim hypCobrador As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypCobrador.Text = objEmpleado.CNombres & " " & objEmpleado.CApellidoPaterno & " " & objEmpleado.CApellidoMaterno
                    Dim hypFormaPago As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    If objPago.BCheque Then
                        hypFormaPago.Text = "Cheque"
                    Else
                        hypFormaPago.Text = "Contado"
                    End If
            End Select
        End Sub

        Protected Sub grdPagos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPagos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypPago As New Label
                    hypPago.CssClass = "CommandButton"
                    e.Row.Cells(0).Controls.Add(hypPago)
                    Dim hypCobrador As New Label
                    hypCobrador.CssClass = "CommandButton"
                    e.Row.Cells(2).Controls.Add(hypCobrador)
                    Dim hypFormaPago As New Label
                    hypFormaPago.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypFormaPago)
            End Select
        End Sub

        Protected Sub btnBuscarPagos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarPagos.Click
            cargarPagos()
        End Sub

        Protected Sub grdBusquedaPagos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBusquedaPagos.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdBusquedaPagos.DataKeys(indice).Value, Integer)
                    Dim objPago As New PagoCuentaXCobrar(cod)
                    Dim hypPago As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypPago.Text = objPago.DFechaPago
            End Select
        End Sub

        Protected Sub grdBusquedaPagos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBusquedaPagos.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypPago As New Label
                    hypPago.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypPago)
            End Select
        End Sub

        Protected Sub grdBusquedaPagos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBusquedaPagos.SelectedIndexChanged
            If grdBusquedaPagos.SelectedIndex > -1 Then
                Dim indice As Integer = grdBusquedaPagos.SelectedIndex
                Dim id As Integer = CType(grdBusquedaPagos.DataKeys(indice).Value, Integer)
                ViewState("pagoid") = id.ToString()
                Dim objPago As New PagoCuentaXCobrar(id)
                If objPago.DFechaPago = Now.ToShortDateString And objPago.BCheque = True Then
                    Dim objVendedor As New Empleado(objPago.NCodCobrador)
                    VendedorControlSearch2.TextValue = objVendedor.CNombres & " " & objVendedor.CApellidoPaterno & " " & objVendedor.CApellidoMaterno
                    VendedorControlSearch2.EmpleadoId = objVendedor.NCodEmpleado
                    txtFechaPago1.Text = objPago.DFechaPago
                    Dim objFactura As New Factura(objPago.NFacturaId)
                    Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, objFactura.NCodCliente)
                    lblCliente.Text = objCliente.CCliente
                    lblNroFactura.Text = objFactura.NNumero
                    lblSaldo.Text = String.Format("{0:F}", objPago.NSaldo)
                    txtMontoPago1.Text = String.Format("{0:F}", objPago.NMontoPagado)
                    txtBancoChequePago1.Text = objPago.CBancoCobro
                    txtNumChequePago1.Text = objPago.CNroCheque
                    txtFechaCobroChequePago1.Text = objPago.DFechaCobro
                    panelbusPago.Visible = False
                    panelviewPago.Visible = True
                    lblMessagePagos.Text = ""
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Solo se pueden modificar los pagos con cheque efectuados el dia de hoy!")
                End If
            End If
        End Sub

        Protected Sub cmdUpdatePago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdatePago.Click
            If UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" Then
                Dim facto As New Factura(PagoCliente1.nCodFactura)
                Dim fechaaux As Date = CDate(txtFechaCobroChequePago1.Text)
                If ViewState("pagoid") IsNot Nothing AndAlso Page.IsValid AndAlso VendedorControlSearch2.EmpleadoId.ToString <> "" AndAlso facto.DFechaEmision <= fechaaux AndAlso (CDec(txtMontoPago.Text) > 0 AndAlso CDec(txtMontoPago1.Text) <= CDec(PagoCliente2.SaldoTextValue)) Then
                    Dim id As Integer = CType(ViewState("pagoid"), Integer)
                    Dim objPago As New PagoCuentaXCobrar(id)
                    Dim objFactura As New Factura(objPago.NFacturaId)
                    If PagoCliente2.nCodFactura.HasValue Then
                        objPago.NFacturaId = PagoCliente1.nCodFactura
                    Else
                        objPago.NFacturaId = objFactura.NCodFactura
                    End If
                    Dim montoanterior As Decimal = objPago.NMontoPagado
                    objPago.NMontoPagado = CDec(txtMontoPago1.Text)
                    objPago.CBancoCobro = txtBancoChequePago1.Text
                    objPago.CNroCheque = txtNumChequePago1.Text
                    objPago.DFechaCobro = txtFechaCobroChequePago1.Text
                    objPago.BCheque = True

                    If PagoCliente2.Saldo.HasValue Then
                        objPago.NSaldo = CDec(PagoCliente2.Saldo) + montoanterior - CDec(txtMontoPago1.Text)
                    Else
                        objPago.NSaldo = CDec(lblSaldo.Text) + montoanterior - CDec(txtMontoPago1.Text)
                    End If
                    objPago.DFechaPago = CDate(txtFechaPago1.Text)
                    objPago.NCodCobrador = VendedorControlSearch2.EmpleadoId
                    objPago.Save()
                    pnlPagos.Visible = False
                    pnlBusquedaPagos.Visible = False
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Pago modificado exitosamente!")
                    '============================================================================
                    Dim objFacturaM As New Factura(objPago.NFacturaId)
                    If objPago.NSaldo <= 0.0099D Then
                        objFacturaM.BPagada = True
                        objFactura.BPendiente = False
                        objFacturaM.Save()
                    Else
                        objFacturaM.BPagada = False
                        objFactura.BPendiente = True
                        objFacturaM.Save()
                    End If
                Else
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Compruebe si los datos de fechas y montos son correctos!")
                End If
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡No está autorizado, no insista!")
            End If
        End Sub

        Protected Sub cmdDeletePago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeletePago.Click
            If UserController.Instance.GetCurrentUserInfo().Username = "ejimenez" Then
                Try
                    If ViewState("pagoid") IsNot Nothing Then
                        Dim id As Integer = CType(ViewState("pagoid"), Integer)
                        Dim pag As New PagoCuentaXCobrar(id)
                        Dim factura As New Factura(pag.NFacturaId)
                        factura.BPagada = False
                        factura.BPendiente = True
                        factura.Save()
                        PagoCuentaXCobrar.Delete(id)
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Pago eliminado exitosamente!")
                        pnlPagos.Visible = False
                        pnlBusquedaPagos.Visible = False
                    End If
                Catch ex As Exception
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Error!. Este pago no se puede eliminar")
                    pnlPagos.Visible = False
                    pnlBusquedaPagos.Visible = False
                End Try
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡No está autorizado, no insista!")
            End If
        End Sub

        Protected Sub lbtnXLS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnXLS.Click
            If grdBusquedaPagos.Rows.Count > 0 Then
                GridViewExportUtil.Export("ReportePagosCheque.xlsx", grdBusquedaPagos)
            End If
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlPagos.Visible = True
            panelNuevoPago.Visible = True
            panelVerPagos.Visible = False
            pnlBusquedaPagos.Visible = False
            grdPagos.DataSource = Nothing
            grdPagos.DataBind()
            grdBusquedaPagos.DataSource = Nothing
            grdBusquedaPagos.DataBind()
            lblMessageBusquedaPagos.Text = ""
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            
            Dim AdminSettings As Boolean = DotNetNuke.Security.PortalSecurity.IsInRoles(PortalSettings.AdministratorRoleName)
            If AdminSettings Or EjSuite.ControlarAccesoUsuarios("ejs_managers") Then
                pnlPagos.Visible = False
                pnlBusquedaPagos.Visible = True
                panelbusPago.Visible = True
                panelviewPago.Visible = False
                grdPagos.DataSource = Nothing
                grdPagos.DataBind()
                grdBusquedaPagos.DataSource = Nothing
                grdBusquedaPagos.DataBind()
                lblMessageBusquedaPagos.Text = ""
            End If
        End Sub
    End Class
End Namespace
