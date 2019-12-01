Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports EjSuite.Modules.EjSuite.regionControlSearch

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteAsignaciones
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscar.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscar.ClientID))
            Me.txtBuscarA.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarA.ClientID))
            Me.txtBuscarR.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarR.ClientID))
            Me.txtBuscarS.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarS.ClientID))
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'ALMACEN
        Private Sub BuscarAlmacen()
            Dim q As SqlQuery = New [Select]("nCodAlmacen, cZona, cNombres, cApellidoPaterno, cNombres + ' ' + cApellidoPaterno as NombreCompleto"). _
                From(Almacen.Schema). _
                InnerJoin(Sucursal.NCodSucursalColumn, Almacen.NCodSucursalColumn). _
                InnerJoin(Empleado.NCodEmpleadoColumn, Almacen.NCodJefeAlmacenColumn)

            If txtBuscarA.Text.Trim() <> "" Then
                q.Where(Sucursal.Columns.CZona).Like(String.Format("%{0}%", txtBuscarA.Text)). _
                    Or(Empleado.Columns.CNombres).Like(String.Format("%{0}%", txtBuscarA.Text)). _
                    Or(Empleado.Columns.CApellidoPaterno).Like(String.Format("%{0}%", txtBuscarA.Text))
            End If

            Dim ds As DataSet
            ds = q.ExecuteDataSet
            grdAlmacen.DataSource = ds.Tables(0).DefaultView
            grdAlmacen.DataKeyNames() = New String() {"nCodAlmacen"}
            grdAlmacen.DataBind()
            lblMesA.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
        End Sub

        Protected Sub btnNuevoA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevoA.Click
            pnlAlmacenIns.Visible = True
            pnlAlmacenbus.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            'cargarSucursal()
        End Sub

        Protected Sub cmdInsertA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertA.Click
            If Page.IsValid Then
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodEmpleado, EmpleadoControlSearch2.EmpleadoId)
                'objNewAlmacen.Sucursalid = CType(ddlSucursal.SelectedValue, Decimal)
                Dim objNewAlmacen As New Almacen() With {.NCodSucursal = CType(sucursalControlSearch2.SucursalId, Decimal), .NCodJefeAlmacen = CType(objEmpleado.NCodEmpleado, Integer), .CCapacidad = ""}
                objNewAlmacen.Save()
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
                pnlAsignacion.Visible = False
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                'txtCapacidad.Text = ""
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                'ddlSucursal.ClearSelection()
            End If
        End Sub

        Protected Sub btnBuscarA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarA.Click
            BuscarAlmacen()
            grdAlmacen.Visible = True
            pnlAlmacenbus.Visible = True
            panelbusA.Visible = True
            panelviewA.Visible = False
            pnlAlmacenIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            txtBuscarA.Text = ""
        End Sub

        Protected Sub grdAlmacen_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAlmacen.PageIndexChanging
            Dim indA As Integer = e.NewPageIndex
            grdAlmacen.PageIndex = indA
            BuscarAlmacen()
            grdAlmacen.Visible = True
            pnlAlmacenbus.Visible = True
            panelbusA.Visible = True
            panelviewA.Visible = False
            pnlAlmacenIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
        End Sub

        'Protected Sub grdAlmacen_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlmacen.RowCreated
        '    Select Case e.Row.RowType
        '        Case DataControlRowType.DataRow
        '            Dim lblSucursal As New Label
        '            lblSucursal.CssClass = "CommandButton"
        '            e.Row.Cells(0).Controls.Add(lblSucursal)
        '            Dim lblEmpleado As New Label
        '            lblEmpleado.CssClass = "CommandButton"
        '            e.Row.Cells(1).Controls.Add(lblEmpleado)
        '    End Select
        'End Sub

        'Protected Sub grdAlmacen_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlmacen.RowDataBound
        '    Select Case e.Row.RowType
        '        Case DataControlRowType.DataRow
        '            Dim objAlmacen As Almacen = CType(e.Row.DataItem, Almacen)
        '            Dim lblSucursal As Label = CType(e.Row.Cells(0).Controls(0), Label)
        '            lblSucursal.Text = objAlmacen.Sucursal.Zona
        '            Dim objAlmacen1 As Almacen = CType(e.Row.DataItem, Almacen)
        '            Dim lblEmpleado As Label = CType(e.Row.Cells(1).Controls(0), Label)
        '            Dim objempleado As New Empleado(Empleado.Columns.Userid, objAlmacen1.Jefealmacen)
        '            lblEmpleado.Text = objempleado.Nombres & " " & objempleado.Apellidos
        '    End Select
        'End Sub

        Protected Sub grdAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdAlmacen.SelectedIndexChanged
            If grdAlmacen.SelectedIndex > -1 Then
                Dim indA As Integer = grdAlmacen.SelectedIndex
                Dim idA As Integer = CType(grdAlmacen.DataKeys(indA).Value, Integer)
                ViewState("Aid") = idA.ToString()
                Dim objAlmacen As New Almacen(idA)
                Dim objSucursal As New Sucursal(objAlmacen.NCodAlmacen)
                sucursalControlSearch1.TextValue = objSucursal.CZona
                sucursalControlSearch1.SucursalId = CType(objAlmacen.NCodSucursal, Integer)
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, objAlmacen.NCodJefeAlmacen)
                EmpleadoControlSearch1.TextValue = String.Format("{0} {1} {2}", objEmpleado.CNombres, objEmpleado.CApellidoPaterno, objEmpleado.CApellidoMaterno)
                EmpleadoControlSearch1.EmpleadoId = CType(objEmpleado.NCodEmpleado, Integer)
                'txtCapacidad1.Text = objAlmacen.Capacidad
                txtBuscarA.Text = ""
                pnlAlmacenbus.Visible = True
                panelbusA.Visible = False
                panelviewA.Visible = True
                pnlAlmacenIns.Visible = False
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
            End If
        End Sub

        Protected Sub cmdUpdateA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateA.Click
            If ViewState("Aid") IsNot Nothing Then
                Dim id As Integer = CType(ViewState("Aid"), Integer)
                Dim objAlmacen As New Almacen(id)
                objAlmacen.NCodSucursal = CType(sucursalControlSearch1.SucursalId, Integer)
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodEmpleado, EmpleadoControlSearch1.EmpleadoId)
                objAlmacen.NCodJefeAlmacen = CType(objEmpleado.NCodEmpleado, Integer)
                'objAlmacen.Capacidad = txtCapacidad1.Text
                objAlmacen.Save()
                If (sucursalControlSearch1 IsNot Nothing) Then
                    sucursalControlSearch1 = Nothing
                End If
                If (EmpleadoControlSearch1 IsNot Nothing) Then
                    EmpleadoControlSearch1 = Nothing
                End If
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
            End If
        End Sub

        Protected Sub cmdDeleteA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteA.Click
            Try
                If ViewState("Aid") IsNot Nothing Then
                    Dim idA As Integer = CType(ViewState("Aid"), Integer)
                    Almacen.Delete(idA)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlAlmacenbus.Visible = False
                    pnlAlmacenIns.Visible = False
                    pnlRegionBus.Visible = False
                    pnlRegionIns.Visible = False
                    pnlSucursalBus.Visible = False
                    pnlSucursalIns.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
            End Try
        End Sub

        '=================================================================================================================
        'REGION
        Private Sub BuscarRegion()
            Dim qryRegion As New Query(Region.Schema)
            If txtBuscarR.Text <> "" Then
                qryRegion.AddWhere(Region.Columns.CLugar, Comparison.Like, String.Format("%{0}%", txtBuscarR.Text))
            End If
            Dim lstR As New RegionCollection()
            lstR.LoadAndCloseReader(qryRegion.ExecuteReader)
            grdRegion.DataSource = lstR
            grdRegion.DataKeyNames() = New String() {Region.Columns.NCodRegion}
            grdRegion.DataBind()
            lblMesR.Text = String.Format("Se encontraron: {0} registro(s)", lstR.Count)
        End Sub

        Private Sub cargarRegion()
            'ddlRegion.DataSource = Region.FetchAll
            'ddlRegion.DataValueField = Region.Columns.Regionid
            'ddlRegion.DataTextField = Region.Columns.Lugar
            'ddlRegion.DataBind()
        End Sub

        Protected Sub btnNuevoR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevoR.Click
            pnlRegionIns.Visible = True
            pnlRegionBus.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
        End Sub

        Protected Sub cmdInsertR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertR.Click
            Dim objNewRegion As New Region()
            objNewRegion.CLugar = txtLugar.Text
            objNewRegion.Save()
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            txtLugar.Text = ""
        End Sub

        Protected Sub btnBuscarR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarR.Click
            BuscarRegion()
            grdRegion.Visible = True
            pnlRegionBus.Visible = True
            panelbusR.Visible = True
            panelviewR.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
        End Sub

        Protected Sub grdRegion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdRegion.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdRegion.PageIndex = indice
            BuscarRegion()
            grdRegion.Visible = True
            pnlRegionBus.Visible = True
            panelbusR.Visible = True
            panelviewR.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
        End Sub

        Protected Sub grdRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdRegion.SelectedIndexChanged
            If grdRegion.SelectedIndex > -1 Then
                Dim indiceR As Integer = grdRegion.SelectedIndex
                Dim idR As Integer = CType(grdRegion.DataKeys(indiceR).Value, Integer)
                ViewState("Rid") = idR.ToString()
                Dim objRegion As New Region(idR)
                txtLugar1.Text = objRegion.CLugar
                txtBuscarR.Text = ""
                pnlRegionBus.Visible = True
                panelbusR.Visible = False
                panelviewR.Visible = True
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
            End If
        End Sub

        Protected Sub cmdUpdaterR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdaterR.Click
            If ViewState("Rid") IsNot Nothing Then
                Dim id As Integer = CType(ViewState("Rid"), Integer)
                Dim objRegion As New Region(id)
                objRegion.CLugar = txtLugar1.Text
                objRegion.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteR.Click
            Try
                If ViewState("Rid") IsNot Nothing Then
                    Dim idR As Integer = CType(ViewState("Rid"), Integer)
                    Region.Delete(idR)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlRegionBus.Visible = False
                    pnlRegionIns.Visible = False
                    pnlSucursalBus.Visible = False
                    pnlSucursalIns.Visible = False
                    pnlAlmacenbus.Visible = False
                    pnlAlmacenIns.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
            End Try

        End Sub

        '=================================================================================================================
        'SUCURSAL
        Private Sub BuscarSucursal()
            Dim qrySucursal As New Query(Sucursal.Schema)
            If txtBuscarS.Text <> "" Then
                qrySucursal.AddWhere(Sucursal.Columns.CZona, Comparison.Like, String.Format("%{0}%", txtBuscarS.Text))
            End If
            Dim lstS As New SucursalCollection()
            lstS.LoadAndCloseReader(qrySucursal.ExecuteReader)
            grdSucursal.DataSource = lstS
            grdSucursal.DataKeyNames() = New String() {Sucursal.Columns.NCodSucursal}
            grdSucursal.DataBind()
            lblMesS.Text = String.Format("Se encontraron: {0} registro(s)", lstS.Count)
        End Sub

        'Private Sub cargarSucursal()
        '    ddlSucursal.DataSource = Sucursal.FetchAll
        '    ddlSucursal.DataValueField = Sucursal.Columns.Sucursalid
        '    ddlSucursal.DataTextField = Sucursal.Columns.Zona
        '    ddlSucursal.DataBind()
        'End Sub

        Protected Sub btnNuevoS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevoS.Click
            pnlSucursalIns.Visible = True
            pnlSucursalBus.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            cargarRegion()
        End Sub

        Protected Sub cmdInsertS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsertS.Click
            If Page.IsValid Then
                'objSucursal.Regionid = CType(ddlRegion.SelectedValue, Decimal)
                Dim objSucursal As New Sucursal() With {.NCodRegion = CType(regionControlSearch2.regionId, Decimal), .CZona = txtZona.Text, .CDireccion = txtDireccion.Text}
                If ckbCasamatriz.Checked = True Then
                    objSucursal.BCasaMatriz = True
                Else
                    objSucursal.BCasaMatriz = False
                End If
                objSucursal.Save()
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
                txtZona.Text = ""
                txtDireccion.Text = ""
                'ddlRegion.SelectedValue = Nothing
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
                'ddlRegion.ClearSelection()
            End If
        End Sub

        Protected Sub btnBuscarS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarS.Click
            BuscarSucursal()
            grdSucursal.Visible = True
            pnlSucursalBus.Visible = True
            panelbusS.Visible = True
            panelviewS.Visible = False
            pnlSucursalIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
        End Sub

        Protected Sub grdSucursal_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdSucursal.PageIndexChanging
            Dim ind As Integer = e.NewPageIndex
            grdSucursal.PageIndex = ind
            BuscarSucursal()
            grdSucursal.Visible = True
            pnlSucursalBus.Visible = True
            panelbusS.Visible = True
            panelviewS.Visible = False
            pnlSucursalIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
        End Sub

        Protected Sub grdSucursal_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim lblRegion As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(0).Controls.Add(lblRegion)
            End Select

        End Sub

        Protected Sub grdSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim objSucursal As Sucursal = CType(e.Row.DataItem, Sucursal)
                    Dim lblRegion As Label = CType(e.Row.Cells(0).Controls(0), Label)
                    Dim objRegion As New Region(objSucursal.NCodRegion)
                    lblRegion.Text = objRegion.CLugar
                Case Else
                    Exit Select
            End Select

        End Sub

        Protected Sub grdSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdSucursal.SelectedIndexChanged
            If grdSucursal.SelectedIndex > -1 Then
                Dim indS As Integer = grdSucursal.SelectedIndex
                Dim idS As Integer = CType(grdSucursal.DataKeys(indS).Value, Integer)
                ViewState("Sid") = idS.ToString()
                Dim objSucursal As New Sucursal(idS)
                Dim objRegion As New Region(objSucursal.NCodRegion)
                regionControlSearch1.TextValue = objRegion.CLugar
                regionControlSearch1.regionId = CType(objSucursal.NCodRegion, Integer)
                txtZona1.Text = objSucursal.CZona
                txtDireccion1.Text = objSucursal.CDireccion
                If objSucursal.BCasaMatriz = True Then
                    ckbCasamatriz1.Checked = True
                Else
                    ckbCasamatriz1.Checked = False
                End If
                txtBuscarR.Text = ""
                pnlSucursalBus.Visible = True
                panelbusS.Visible = False
                panelviewS.Visible = True
                pnlSucursalIns.Visible = False
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
            End If
        End Sub

        Protected Sub cmdUpdateS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateS.Click
            If ViewState("Sid") IsNot Nothing Then
                Dim id As Integer = CType(ViewState("Sid"), Integer)
                Dim objSucursal As New Sucursal(id)
                objSucursal.NCodRegion = CType(regionControlSearch1.regionId, Integer)
                objSucursal.CZona = txtZona1.Text
                objSucursal.CDireccion = txtDireccion1.Text
                If ckbCasamatriz1.Checked = True Then
                    objSucursal.BCasaMatriz = True
                Else
                    objSucursal.BCasaMatriz = False
                End If
                objSucursal.Save()
                If (regionControlSearch1 IsNot Nothing) Then
                    regionControlSearch1 = Nothing
                End If
                ckbCasamatriz1.Checked = False
                pnlSucursalBus.Visible = False
                pnlSucursalIns.Visible = False
                pnlRegionBus.Visible = False
                pnlRegionIns.Visible = False
                pnlAlmacenbus.Visible = False
                pnlAlmacenIns.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
            End If
        End Sub

        Protected Sub cmdDeleteS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteS.Click
            Try
                If ViewState("Sid") IsNot Nothing Then
                    Dim idS As Integer = CType(ViewState("Sid"), Integer)
                    Sucursal.Delete(idS)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlSucursalBus.Visible = False
                    pnlSucursalIns.Visible = False
                    pnlRegionBus.Visible = False
                    pnlRegionIns.Visible = False
                    pnlAlmacenbus.Visible = False
                    pnlAlmacenIns.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")

            End Try

        End Sub

        '=================================================================================================================
        'ASIGNACION
        Private Sub asignacion()
            Dim qry As SqlQuery = New [Select]("nCodAlmacen, cZona, cLugar, cNombres, cApellidoPaterno"). _
                From(Almacen.Schema).InnerJoin(Sucursal.NCodSucursalColumn, Almacen.NCodSucursalColumn). _
                InnerJoin(Region.NCodRegionColumn, Sucursal.NCodRegionColumn). _
                InnerJoin(Empleado.NCodEmpleadoColumn, Almacen.NCodJefeAlmacenColumn)
            If txtBuscar.Text <> "" Then
                qry = New [Select]("nCodAlmacen, cZona, cLugar, cNombres, cApellidoPaterno").From(Almacen.Schema). _
                    InnerJoin(Sucursal.NCodSucursalColumn, Almacen.NCodSucursalColumn). _
                    InnerJoin(Region.NCodRegionColumn, Sucursal.NCodRegionColumn). _
                    InnerJoin(Empleado.NCodEmpleadoColumn, Almacen.NCodJefeAlmacenColumn). _
                    Where(Region.Columns.CLugar).Like(String.Format("%{0}%", txtBuscar.Text)). _
                    Or(Sucursal.Columns.CZona).Like(String.Format("%{0}%", txtBuscar.Text)). _
                    Or(Empleado.Columns.CApellidoPaterno).Like(String.Format("%{0}%", txtBuscar.Text)). _
                    Or(Empleado.Columns.CApellidoMaterno).Like(String.Format("%{0}%", txtBuscar.Text)). _
                    Or(Empleado.Columns.CNombres).Like(String.Format("%{0}%", txtBuscar.Text))
            End If
            Dim lst As New DataSet
            lst = qry.ExecuteDataSet()
            grdAsignacion.DataSource = lst.Tables(0).DefaultView
            grdAsignacion.DataKeyNames() = New String() {Almacen.Columns.NCodAlmacen}
            grdAsignacion.DataBind()
            lblMes.Text = String.Format("Se encontraron: {0} registro(s)", lst.Tables(0).Rows.Count)
        End Sub

        Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
            asignacion()
            grdAsignacion.Visible = True
            pnlAsignacion.Visible = True
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
        End Sub

        Protected Sub grdAsignacion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAsignacion.PageIndexChanging
            Dim ind As Integer = e.NewPageIndex
            grdAsignacion.PageIndex = ind
            asignacion()
            grdAsignacion.Visible = True
            pnlAsignacion.Visible = True
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
        End Sub

        Protected Sub grdAsignacion_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAsignacion.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    'Dim lblSucursal As New Label
                    'lblSucursal.CssClass = "CommandButton"
                    'e.Row.Cells(1).Controls.Add(lblSucursal)

                    'Dim lblRegion As New Label
                    'lblRegion.CssClass = "CommandButton"
                    'e.Row.Cells(2).Controls.Add(lblRegion)

                    'Dim lblEmpleado As New Label
                    'lblEmpleado.CssClass = "CommandButton"
                    'e.Row.Cells(3).Controls.Add(lblEmpleado)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdAsignacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAsignacion.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    'Dim objAlmacen As Almacen = CType(e.Row.DataItem, Almacen)
                    'Dim lblSucursal As Label = CType(e.Row.Cells(1).Controls(0), Label)
                    'lblSucursal.Text = objAlmacen.Sucursal.Zona


                    'Dim objSucursal As New Sucursal(objAlmacen.Sucursalid)
                    'Dim lblRegion As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    'lblRegion.Text = objSucursal.Region.Lugar


                    'Dim objAlmacen1 As Almacen = CType(e.Row.DataItem, Almacen)
                    'Dim lblEmpleado As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    'Dim objempleado As New Empleado(Empleado.Columns.Userid, objAlmacen1.Jefealmacen)
                    'lblEmpleado.Text = objempleado.Nombres & " " & objempleado.Apellidos
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub lbtn1_Click(sender As Object, e As EventArgs) Handles lbtn1.Click
            pnlAlmacenbus.Visible = True
            pnlAlmacenIns.Visible = False
            panelbusA.Visible = True
            panelviewA.Visible = False
            lblMesA.Text = ""
            txtBuscarA.Text = ""
            grdAlmacen.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlAsignacion.Visible = False
        End Sub

        Protected Sub lbtn2_Click(sender As Object, e As EventArgs) Handles lbtn2.Click
            pnlSucursalBus.Visible = True
            pnlSucursalIns.Visible = False
            panelbusS.Visible = True
            panelviewS.Visible = False
            lblMesS.Text = ""
            grdSucursal.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            pnlAsignacion.Visible = False
        End Sub

        Protected Sub lbtn3_Click(sender As Object, e As EventArgs) Handles lbtn3.Click
            pnlRegionBus.Visible = True
            pnlRegionIns.Visible = False
            panelbusR.Visible = True
            panelviewR.Visible = False
            lblMesR.Text = ""
            grdRegion.Visible = False
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
            pnlAsignacion.Visible = False
        End Sub

        Protected Sub lbtn4_Click(sender As Object, e As EventArgs) Handles lbtn4.Click
            pnlAsignacion.Visible = True
            grdAsignacion.Visible = True
            pnlRegionBus.Visible = False
            pnlRegionIns.Visible = False
            lblMesR.Text = ""
            pnlAlmacenbus.Visible = False
            pnlAlmacenIns.Visible = False
            pnlSucursalBus.Visible = False
            pnlSucursalIns.Visible = False
        End Sub
    End Class
End Namespace
