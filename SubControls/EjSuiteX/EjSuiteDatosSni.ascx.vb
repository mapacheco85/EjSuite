Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic

Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteDatosSni
        Inherits EjSuiteModuleBase

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            Me.txtBuscarDatosSni.Attributes.Add("onkeypress", String.Format("  var bt = document.getElementById('{0}');  if (bt) {{if (event.keyCode == 13) {{bt.click(); return false;}}}} ", Me.btnBuscarDatosSni.ClientID))
        End Sub

        Private Sub CargarDatosSni()
            Dim ds As New DataSet
            ds = SPs.VerDatosSNIData(txtBuscarDatosSni.Text).GetDataSet()

            grdDatosSNI.DataSource = ds.Tables(0).DefaultView
            grdDatosSNI.DataKeyNames() = New String() {"nCodSNI"}
            grdDatosSNI.DataBind()
            lblMessageDatosSNI.Text = String.Format("Se encontraron: {0} registro(s)", ds.Tables(0).Rows.Count)
            ds = Nothing
            panelbusDat.Visible = True
        End Sub

        Private Sub inicializar()
            txtLlaveDatosSni.Text = ""
            txtAutorizacionDatosSni.Text = ""
            txtFechainicioDatosSni.Text = ""
            txtFechafinDatosSni.Text = ""

            txtLlaveDatosSni1.Text = ""
            txtAutorizacionDatosSni1.Text = ""
            txtFechainicioDatosSni1.Text = ""
            txtFechafinDatosSni1.Text = ""
            txtFacturaInicial1.Text = ""
            lblMessageDatosSNI.Text = ""

            Dim q As New Query(Leyenda.Schema)
            q.AddWhere(Leyenda.Columns.CTipo, "VNT")
            Dim lst As New LeyendaCollection()
            lst.LoadAndCloseReader(q.ExecuteReader())

            ddlLeyenda453.DataSource = lst
            ddlLeyenda453.DataTextField = Leyenda.Columns.CNormativa
            ddlLeyenda453.DataValueField = Leyenda.Columns.CNormativa
            ddlLeyenda453.DataBind()

            ddlLeyenda4531.DataSource = lst
            ddlLeyenda4531.DataTextField = Leyenda.Columns.CNormativa
            ddlLeyenda4531.DataValueField = Leyenda.Columns.CNormativa
            ddlLeyenda4531.DataBind()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                pnlNuevoDatosSNI.Visible = False
                pnlBusquedaDatosSNI.Visible = False
                inicializar()
            End If
        End Sub

        Protected Sub cmdInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsert.Click
            If Page.IsValid Then
                Dim objNewDatosSni As New Snidatum()
                objNewDatosSni.CLlave = txtLlaveDatosSni.Text
                objNewDatosSni.CAutorizacion = txtAutorizacionDatosSni.Text
                objNewDatosSni.DFechaInicio = CType(txtFechainicioDatosSni.Text, Date)
                objNewDatosSni.DFechaFinal = CType(txtFechafinDatosSni.Text, Date)
                objNewDatosSni.NNroFacturaInicial = CType(txtFacturaInicial.Text, Integer)
                objNewDatosSni.BUsaQR = True
                objNewDatosSni.CLeyenda453 = ddlLeyenda453.Text
                objNewDatosSni.Save()
                pnlBusquedaDatosSNI.Visible = False
                pnlNuevoDatosSNI.Visible = False
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro ingresado exitosamente!")
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            txtLlaveDatosSni.Text = ""
            txtAutorizacionDatosSni.Text = ""
            txtFechainicioDatosSni.Text = ""
            txtFechafinDatosSni.Text = ""
            pnlBusquedaDatosSNI.Visible = False
            pnlNuevoDatosSNI.Visible = False
        End Sub

        Protected Sub btnBuscarDatosSni_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarDatosSni.Click
            CargarDatosSni()
        End Sub

        Protected Sub grdDatosSNI_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatosSNI.PageIndexChanging
            Dim indice As Integer = e.NewPageIndex
            grdDatosSNI.PageIndex = indice
            CargarDatosSni()
        End Sub

        Protected Sub grdDatosSNI_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdDatosSNI.SelectedIndexChanged
            If grdDatosSNI.SelectedIndex > -1 Then
                Dim indice As Integer = grdDatosSNI.SelectedIndex
                Dim id As Integer = CType(grdDatosSNI.DataKeys(indice).Value, Integer)
                ViewState("dsid") = id.ToString()
                Dim objDatosSni As New Snidatum(id)
                txtLlaveDatosSni1.Text = objDatosSni.CLlave
                txtAutorizacionDatosSni1.Text = objDatosSni.CAutorizacion
                txtFechainicioDatosSni1.Text = objDatosSni.DFechaInicio.ToShortDateString()
                txtFechafinDatosSni1.Text = objDatosSni.DFechaFinal.ToShortDateString()
                txtFacturaInicial1.Text = objDatosSni.NNroFacturaInicial.ToString()
                ddlLeyenda453.Text = objDatosSni.CLeyenda453
                txtBuscarDatosSni.Text = ""
                panelbusDat.Visible = False
                panelviewDat.Visible = True
            End If
        End Sub

        Protected Sub cmdUpdateDatosSni_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateDatosSni.Click
            If ViewState("dsid") IsNot Nothing AndAlso Page.IsValid Then
                Dim id As Integer = CType(ViewState("dsid"), Integer)
                Dim objDatosSni As New Snidatum(id)
                objDatosSni.CLlave = txtLlaveDatosSni1.Text
                objDatosSni.CAutorizacion = txtAutorizacionDatosSni1.Text
                objDatosSni.DFechaInicio = CType(txtFechainicioDatosSni1.Text, Date)
                objDatosSni.DFechaFinal = CType(txtFechafinDatosSni1.Text, Date)
                objDatosSni.NNroFacturaInicial = CType(txtFacturaInicial1.Text, Integer)
                objDatosSni.BUsaQR = True
                objDatosSni.CLeyenda453 = ddlLeyenda453.Text
                objDatosSni.Save()
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro modificado!")
                pnlBusquedaDatosSNI.Visible = False
                pnlNuevoDatosSNI.Visible = False
            End If
        End Sub

        Protected Sub cmdDeleteDatosSni_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteDatosSni.Click
            Try
                If ViewState("dsid") IsNot Nothing Then
                    Dim id As Integer = CType(ViewState("dsid"), Integer)
                    Snidatum.Delete(id)
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Registro eliminado correctamente!")
                    pnlBusquedaDatosSNI.Visible = False
                    pnlNuevoDatosSNI.Visible = False
                End If
            Catch ex As Exception
                EjSuite.Mensaje(Me.upPanel, Me.GetType(), "¡Tiene dependencias este item!")
                pnlBusquedaDatosSNI.Visible = False
                pnlNuevoDatosSNI.Visible = False
            End Try
        End Sub

        Protected Sub grdDatosSNI_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatosSNI.RowDataBound
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim indice As Integer = e.Row.RowIndex
                    Dim cod As Integer = CType(grdDatosSNI.DataKeys(indice).Value, Integer)
                    Dim objDatosSni As New Snidatum(cod)
                    Dim hypDatosSni As Label = CType(e.Row.Cells(2).Controls(0), Label)
                    hypDatosSni.Text = objDatosSni.DFechaInicio.ToShortDateString()
                    Dim hypDatosSni2 As Label = CType(e.Row.Cells(3).Controls(0), Label)
                    hypDatosSni2.Text = objDatosSni.DFechaFinal.ToShortDateString()
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub grdDatosSNI_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatosSNI.RowCreated
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    Dim hypDatosSni As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(2).Controls.Add(hypDatosSni)
                    Dim hypDatosSni2 As New Label() With {.CssClass = "CommandButton"}
                    e.Row.Cells(3).Controls.Add(hypDatosSni2)
                Case Else
                    Exit Select
            End Select
        End Sub

        Protected Sub lbtn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn1.Click
            inicializar()
            pnlNuevoDatosSNI.Visible = True
            pnlBusquedaDatosSNI.Visible = False
            grdDatosSNI.DataSource = Nothing
            grdDatosSNI.DataBind()
        End Sub

        Protected Sub lbtn2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn2.Click
            inicializar()
            pnlNuevoDatosSNI.Visible = False
            pnlBusquedaDatosSNI.Visible = True
            panelbusDat.Visible = True
            panelviewDat.Visible = False
            grdDatosSNI.DataSource = Nothing
            grdDatosSNI.DataBind()
        End Sub
    End Class
End Namespace
