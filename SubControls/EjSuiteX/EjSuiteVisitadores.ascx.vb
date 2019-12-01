Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports DotNetNuke.Services.Personalization
Imports DotNetNuke.Entities.Users

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteVisitadores
        Inherits EjSuiteModuleBase

        Private Sub CargarEmpleado()
            Dim q As New Query(Empleado.Schema)
            If Trim(txtBuscarEmpleado.Text) <> "" Then
                q.AddWhere(Empleado.Columns.CNombres, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
                q.OR(Empleado.Columns.CApellidoPaterno, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
                q.OR(Empleado.Columns.CApellidoMaterno, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
            End If
            q.ORDER_BY(Empleado.Columns.CApellidoPaterno)
            Dim lst As New EmpleadoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdEmpleado.DataSource = lst
            grdEmpleado.DataKeyNames() = New String() {Empleado.Columns.NCodEmpleado}
            grdEmpleado.DataBind()
            lblMessageEmpleado.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            panelbusEmp.Visible = True
        End Sub

        Private Sub CargarActividad()
            Dim q As SqlQuery = New [Select]("nCodEmpleadoSucursal, cNombres, cApellidoPaterno, dFechaInicio, dFechaFinal, cZona"). _
                    From(Empleado.Schema). _
                    InnerJoin(EmpleadoSucursal.NCodEmpleadoColumn, Empleado.NCodEmpleadoColumn). _
                    InnerJoin(Sucursal.NCodSucursalColumn, EmpleadoSucursal.NCodSucursalColumn). _
                    Where(Empleado.Columns.CNombres).Like("%" & txtBuscarActividad.Text.Trim() & "%"). _
                    Or(Empleado.Columns.CApellidoPaterno).Like("%" & txtBuscarActividad.Text.Trim() & "%"). _
                    Or(Empleado.Columns.CApellidoMaterno).Like("%" & txtBuscarActividad.Text.Trim() & "%")
            Dim ds As New DataSet
            ds = q.ExecuteDataSet
            grdActividad.DataSource = ds.Tables(0).DefaultView
            grdActividad.DataKeyNames() = New String() {EmpleadoSucursal.Columns.NCodEmpleadoSucursal}
            grdActividad.DataBind()
            lblMessageActividad.Text = "Se encontraron: " & ds.Tables(0).Rows.Count & " registro(s)"
            panelbusAct.Visible = True
            ds = Nothing
        End Sub

        Private Sub inicializar()
            txtBuscarEmpleado.Text = ""
            lblMessageEmpleado.Text = ""

            txtNombresEmpleado.Text = ""
            txtApellidosEmpleado.Text = ""

            SucursalControlSearch1.TextValue = "Elija una regional"
            EmpleadoControlSearch1.TextValue = "Elija un empleado"
            txtFechainicioActividad.Text = ""
            txtFechafinalActividad.Text = ""

            txtBuscarActividad.Text = ""
            lblMessageActividad.Text = ""

            txtFechainicioActividad1.Text = ""
            txtFechafinalActividad1.Text = ""
            SucursalControlSearch2.TextValue = "Cambiar regional"
            EmpleadoControlSearch2.TextValue = "Cambiar empleado"
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarActividad.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.btnBuscarActividad.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
            Me.txtBuscarEmpleado.Attributes.Add("onkeypress", "  var bt = document.getElementById('" + Me.btnBuscarEmpleado.ClientID + "');  if (bt) {if (event.keyCode == 13) {bt.click(); return false;}} ")
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlBusquedaEmpleado.Visible = False
                pnlNuevaActividad.Visible = False
                pnlBusquedaActividad.Visible = False
                Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
                inicializar()
            End If
        End Sub

        Protected Sub btnBuscarEmpleado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarEmpleado.Click
            CargarEmpleado()
        End Sub

        Protected Sub grdEmpleado_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEmpleado.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdEmpleado.PageIndex = indice
            CargarEmpleado()
        End Sub

        Protected Sub grdEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdEmpleado.SelectedIndexChanged
            If grdEmpleado.SelectedIndex > -1 Then
                Dim indice As Integer = grdEmpleado.SelectedIndex
                Dim id As Integer = CType(grdEmpleado.DataKeys(indice).Value, Integer)
                ViewState("eid") = id.ToString()
                Dim objEmpleado As New Empleado(id)
                lblUseridEmpleado.Text = objEmpleado.NCodEmpleado
                txtNombresEmpleado.Text = objEmpleado.CNombres
                txtApellidosEmpleado.Text = objEmpleado.CApellidoPaterno & " " & objEmpleado.CApellidoMaterno
                txtBuscarEmpleado.Text = ""
                panelbusEmp.Visible = False
                panelviewEmp.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateEmpleado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateEmpleado.Click
            Try
                If ViewState("eid") IsNot Nothing AndAlso Page.IsValid Then
                    Dim id As Integer = CType(ViewState("eid"), Integer)
                    Dim objEmpleado As New Empleado(id)
                    objEmpleado.NCodEmpleado = CType(lblUseridEmpleado.Text, Decimal)
                    objEmpleado.CNombres = txtNombresEmpleado.Text
                    objEmpleado.CApellidoPaterno = txtApellidosEmpleado.Text
                    objEmpleado.Save()
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado exitosamente!")
                    pnlBusquedaEmpleado.Visible = False
                    pnlNuevaActividad.Visible = False
                    pnlBusquedaActividad.Visible = False

                    Dim user As UserInfo = UserController.Instance.GetCurrentUserInfo()
                    user.Username = objEmpleado.CNombres
                    user.LastName = objEmpleado.CApellidoPaterno
                    UserController.UpdateUser(PortalId, user)
                End If
            Catch
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Son datos administrativos, no se pueden cambiar!")
            End Try
        End Sub

        Protected Sub cmdDeleteEmpleado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteEmpleado.Click
            txtNombresEmpleado.Text = ""
            txtApellidosEmpleado.Text = ""
            txtBuscarEmpleado.Text = ""
            panelbusEmp.Visible = True
            panelviewEmp.Visible = False
            grdEmpleado.DataSource = Nothing
            grdEmpleado.DataBind()
        End Sub

        Protected Sub cmdInsertActividad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertActividad.Click
            If Page.IsValid AndAlso EmpleadoControlSearch1.EmpleadoId.HasValue AndAlso SucursalControlSearch1.SucursalId.HasValue Then
                Dim objNewActividad As New EmpleadoSucursal()
                Dim id As Integer = New [Select](Aggregate.Max("nCodEmpleadoSucursal")).From(Of EmpleadoSucursal).ExecuteScalar(Of Integer)()
                Dim ActividadId As Integer = 0
                If id = 0 Then
                    ActividadId = 1
                Else
                    ActividadId = id + 1
                End If
                objNewActividad.NCodEmpleadoSucursal = ActividadId
                objNewActividad.NCodSucursal = SucursalControlSearch1.SucursalId
                objNewActividad.NCodEmpleado = EmpleadoControlSearch1.EmpleadoId
                objNewActividad.DFechaInicio = CType(txtFechainicioActividad.Text, Date)
                If txtFechafinalActividad.Text <> "" Then
                    objNewActividad.DFechaFinal = CType(txtFechafinalActividad.Text, Date)
                End If
                objNewActividad.Save()
                pnlBusquedaEmpleado.Visible = False
                pnlBusquedaActividad.Visible = False
                pnlNuevaActividad.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            Else
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Debe seleccionar un empleado y una sucursal!")
            End If
        End Sub

        Protected Sub cmdCancelActividad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelActividad.Click
            txtFechainicioActividad.Text = ""
            txtFechafinalActividad.Text = ""
            pnlBusquedaEmpleado.Visible = False
            pnlBusquedaActividad.Visible = False
            pnlNuevaActividad.Visible = False
        End Sub

        Protected Sub btnBuscarActividad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarActividad.Click
            CargarActividad()
        End Sub

        Protected Sub grdActividad_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdActividad.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdActividad.PageIndex = indice
            CargarActividad()
        End Sub

        Protected Sub grdActividad_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdActividad.SelectedIndexChanged
            If grdActividad.SelectedIndex > -1 Then
                Dim indice As Integer = grdActividad.SelectedIndex
                Dim id As Integer = CType(grdActividad.DataKeys(indice).Value, Integer)
                ViewState("aid") = id.ToString()
                Dim objActividad As New EmpleadoSucursal(id)
                txtFechainicioActividad1.Text = objActividad.DFechaInicio.ToShortDateString
                If objActividad.DFechaFinal.ToString <> "" Then
                    txtFechafinalActividad1.Text = objActividad.DFechaFinal.Value.ToShortDateString
                Else
                    txtFechafinalActividad1.Text = ""
                End If
                Dim objEmpleado As New Empleado(objActividad.NCodEmpleado)
                hfEmpleadoidActividad1.Value = objEmpleado.NCodEmpleado.ToString()
                lblEmpleadoidActividad1.Text = objEmpleado.CNombres
                Dim objSucursal As New Sucursal(objActividad.NCodSucursal)
                hfSucursalidActividad1.Value = objSucursal.NCodSucursal.ToString()
                lblSucursalidActividad1.Text = objSucursal.CZona
                txtBuscarActividad.Text = ""
                panelbusAct.Visible = False
                panelviewAct.Visible = True
            End If
        End Sub
        Protected Sub cmdUpdateActividad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateActividad.Click
            If ViewState("aid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As Integer = CType(ViewState("aid"), Integer)
                Dim objActividad As New EmpleadoSucursal(id)
                If SucursalControlSearch2.SucursalId.HasValue Then
                    objActividad.NCodSucursal = CType(SucursalControlSearch2.SucursalId, Decimal)
                Else
                    objActividad.NCodSucursal = CType(hfSucursalidActividad1.Value, Decimal)
                End If
                If EmpleadoControlSearch2.EmpleadoId.HasValue Then
                    objActividad.NCodEmpleado = CType(EmpleadoControlSearch2.EmpleadoId, Decimal)
                Else
                    objActividad.NCodEmpleado = CType(hfEmpleadoidActividad1.Value, Decimal)
                End If
                objActividad.DFechaInicio = CType(txtFechainicioActividad1.Text, Date)
                objActividad.DFechaFinal = CType(txtFechafinalActividad1.Text, Date)
                objActividad.Save()

                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaEmpleado.Visible = False
                pnlNuevaActividad.Visible = False
                pnlBusquedaActividad.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteActividad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteActividad.Click
            Try
                If ViewState("aid") IsNot Nothing Then
                    Dim id As Integer = CType(ViewState("aid"), Integer)
                    EmpleadoSucursal.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaEmpleado.Visible = False
                    pnlNuevaActividad.Visible = False
                    pnlBusquedaActividad.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaEmpleado.Visible = False
                pnlNuevaActividad.Visible = False
                pnlBusquedaActividad.Visible = False
            End Try
        End Sub

        Protected Sub grdActividad_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdActividad.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdActividad.DataKeys(indice).Value, Integer)
                    Dim objActividad As New EmpleadoSucursal(cod)
                    Dim hypActividad1 As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypActividad1.Text = objActividad.DFechaInicio.ToShortDateString()
                    Dim hypActividad2 As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    If objActividad.DFechaFinal.ToString <> "" Then
                        hypActividad2.Text = objActividad.DFechaFinal.Value.ToShortDateString()
                    End If
            End Select
        End Sub

        Protected Sub grdActividad_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdActividad.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypActividad1 As New Label
                    'hypActividad.CommandName = "ActividadSelect"
                    hypActividad1.CssClass = "CommandButton"
                    'hypActividad.ValidationGroup = "ActividadSelectorSel"
                    e.Row.Cells(2).Controls.Add(hypActividad1)
                    Dim hypActividad2 As New Label
                    hypActividad2.CssClass = "CommandButton"
                    e.Row.Cells(3).Controls.Add(hypActividad2)
            End Select
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlBusquedaEmpleado.Visible = True
            pnlNuevaActividad.Visible = False
            pnlBusquedaActividad.Visible = False
            panelbusEmp.Visible = True
            panelviewEmp.Visible = False
            grdActividad.DataSource = Nothing
            grdActividad.DataBind()
            grdEmpleado.DataSource = Nothing
            grdEmpleado.DataBind()
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlBusquedaEmpleado.Visible = False
            pnlNuevaActividad.Visible = True
            pnlBusquedaActividad.Visible = False
            grdActividad.DataSource = Nothing
            grdActividad.DataBind()
            grdEmpleado.DataSource = Nothing
            grdEmpleado.DataBind()
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            inicializar()
            pnlBusquedaEmpleado.Visible = False
            pnlNuevaActividad.Visible = False
            pnlBusquedaActividad.Visible = True
            panelbusAct.Visible = True
            panelviewAct.Visible = False
            grdActividad.DataSource = Nothing
            grdActividad.DataBind()
            grdEmpleado.DataSource = Nothing
            grdEmpleado.DataBind()
        End Sub

        Private Property SortDirection As String
            Get
                Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
            End Get
            Set(value As String)
                ViewState("SortDirection") = value
            End Set
        End Property


        Protected Sub grdEmpleado_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdEmpleado.Sorting
            Dim q As New Query(Empleado.Schema)
            If Trim(txtBuscarEmpleado.Text) <> "" Then
                q.AddWhere(Empleado.Columns.CNombres, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
                q.OR(Empleado.Columns.CApellidoPaterno, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
                q.OR(Empleado.Columns.CApellidoMaterno, Comparison.Like, "%" & txtBuscarEmpleado.Text.Trim() & "%")
            End If
            q.ORDER_BY(e.SortExpression)

            Dim lst As New EmpleadoCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())
            grdEmpleado.DataSource = lst
            grdEmpleado.DataKeyNames() = New String() {Empleado.Columns.NCodEmpleado}
            grdEmpleado.DataBind()
            lblMessageEmpleado.Text = "Se encontraron: " & lst.Count.ToString() & " registro(s)"
            panelbusEmp.Visible = True
        End Sub
    End Class
End Namespace