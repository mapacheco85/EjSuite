Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteDeudores
        Inherits EjSuiteModuleBase
        Private sumatoria As Decimal
        Private fecha As Date
        Private Sub Cargar()
            Dim qry As SqlQuery = New [Select]().From(VwDeudas1.Schema)
            'FECHA = "04/10/2012"
            If txtFechafinalRepSucursal.Text <> "" Then
                qry.Where(VwDeudas1.Columns.Vence).IsEqualTo(txtFechafinalRepSucursal.Text)
            End If
            qry.And(VwDeudas1.Columns.Deuda).IsGreaterThan(0)
            'qry.And(VwDeudasReporte.Columns.Deuda).IsEqualTo(0)
            qry.OrderAsc(VwDeudas1.Columns.CCliente)

            Dim lst As New VwDeudas1Collection()
            lst.LoadAndCloseReader(qry.ExecuteReader)

            grdRepSucursal.DataSource = lst
            grdRepSucursal.DataBind()
            lblMessageRepSucursal.Text = String.Format("Se encontraron: {0} registro(s)", lst.Count)
        End Sub
        Private Sub Cargar2()
            Dim qry As SqlQuery = New [Select]().From(VwDeudas1.Schema)

            'FECHA = "04/10/2012"
            If txtFechafinalRepSucursal.Text <> "" Then
                qry.Where(VwDeudas1.Columns.Emitida).IsEqualTo(txtFechafinalRepSucursal.Text)
                qry.And(VwDeudas1.Columns.Deuda).IsGreaterThan(0)
            End If
            'qry.And(VwDeudasReporte.Columns.Deuda).IsEqualTo(0)
            qry.OrderAsc(VwDeudas1.Columns.CCliente)

            Dim lst As New VwDeudas1Collection()
            lst.LoadAndCloseReader(qry.ExecuteReader)

            grdCobros.DataSource = lst
            grdCobros.DataBind()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                fecha = Today.Date
                Dim fechaf As String = fecha.ToString("yyyy/MM/dd")
                txtFechafinalRepSucursal.Text = fechaf
                pnlBusqueda1.Visible = False
                'txtFechafinalRepSucursal.Text = Now.Date
                'txtFechainicialRepSucursal.Text = ""
            End If
        End Sub

        Protected Sub cmdSearchRepSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearchRepSucursal.Click
            Cargar()
        End Sub

        Protected Sub lbtnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnExportarExcel.Click
            If grdRepSucursal.Rows.Count > 0 Then
                GridViewExportUtil.Export("Clientepago.xlsx", grdRepSucursal)
            End If
        End Sub

        Private Sub grdRepSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRepSucursal.RowDataBound
            Dim diasemana As Integer = Weekday(txtFechafinalRepSucursal.Text, vbMonday)
            Dim adias As String
            Dim diasabado, diadomingo As String
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim dp As Integer = Convert.ToInt32(e.Row.Cells(7).Text)
                    Dim fid As Integer = Convert.ToInt32(e.Row.Cells(1).Text)
                    Dim vencimiento As String = Convert.ToDateTime(e.Row.Cells(5).Text)
                    Select Case diasemana
                        Case 1
                            Select Case dp
                                Case 0
                                    'Dim id As String = CType(ViewState("cid"), String)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                    'lblResult.Text = "¡Registro modificado!"
                                Case 1
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 2
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 3
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 4
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 5
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 12
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 13
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 14
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 15
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 23
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 24
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 25
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 34
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 35
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 45
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case Else
                                    Exit Select
                            End Select
                        Case 2
                            Select Case dp
                                Case 0
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 1
                                    adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 2
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 3
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 4
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 5
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 12
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 13
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 14
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 15
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 23
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 24
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 25
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 34
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 35
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 45
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case Else
                                    Exit Select
                            End Select
                        Case 3
                            Select Case dp
                                Case 0
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 1
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 2
                                    adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 3
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 4
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 5
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 12
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 13
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 14
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 15
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 23
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 24
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 25
                                    adias = DateAdd("d", 2, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 34
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 35
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 45
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case Else
                                    Exit Select
                            End Select
                        Case 4
                            Select Case dp
                                Case 0
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 1
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 2
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 3
                                    adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 4
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 5
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 12
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 13
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 14
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 15
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 23
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 24
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 25
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 34
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 35
                                    adias = DateAdd("d", 1, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 45
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case Else
                                    Exit Select
                            End Select
                        Case 5
                            Select Case dp
                                Case 0
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 1
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 2
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 3
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 4
                                    adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 5
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 12
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 13
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 14
                                    adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 15
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 23
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 24
                                    adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 25
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 34
                                    adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                    objFactura.Save()
                                Case 35
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case 45
                                    Dim objFactura As New Factura(fid) With {.DFechaContabilidad = txtFechafinalRepSucursal.Text}
                                    objFactura.Save()
                                Case Else
                                    Exit Select
                            End Select

                            diasabado = DateAdd("d", 1, txtFechafinalRepSucursal.Text)
                            diadomingo = DateAdd("d", 2, txtFechafinalRepSucursal.Text)
                            If vencimiento = diasabado Then
                                Select Case dp
                                    Case 0
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 1
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 2
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 3
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 4
                                        adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 5
                                        adias = DateAdd("d", 7, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 12
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 13
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 14
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 15
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 23
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 24
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 25
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 34
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 35
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 45
                                        adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case Else
                                        Exit Select
                                End Select
                            End If
                            If vencimiento = diadomingo Then
                                Select Case dp
                                    Case 0
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 1
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 2
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 3
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 4
                                        adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 5
                                        adias = DateAdd("d", 7, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 12
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 13
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 14
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 15
                                        adias = DateAdd("d", 3, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 23
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 24
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 25
                                        adias = DateAdd("d", 4, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 34
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 35
                                        adias = DateAdd("d", 5, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case 45
                                        adias = DateAdd("d", 6, txtFechafinalRepSucursal)
                                        Dim objFactura As New Factura(fid) With {.DFechaContabilidad = adias}
                                        objFactura.Save()
                                    Case Else
                                        Exit Select
                                End Select
                            End If
                        Case Else
                            Exit Select
                    End Select

                    'Dim precio As Decimal = Convert.ToDecimal(e.Row.Cells(4).Text)
                    'Me.sumatoria = Me.sumatoria + precio
                Case DataControlRowType.Footer
                    'e.Row.Cells(3).Text = "Total:"
                    'e.Row.Cells(4).Text = String.Format("{0:F}", sumatoria)
                Case Else
                    Exit Select
            End Select
            Cargar2()

        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlBusqueda1.Visible = True
        End Sub

    End Class


End Namespace

