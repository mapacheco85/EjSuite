Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ClienteControl

Namespace EjSuite.Modules.EjSuite
    Public Class ClienteControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                ddlBeneficiario.Visible = False
            End If
        End Sub

        Protected Sub elegirCliente(ByVal sender As Object, ByVal e As ClienteSelectedEventArgs) Handles cliCliente.ClienteSelected
            Dim qryCliente As New Query(Cliente.Schema)
            qryCliente.AddWhere(Cliente.Columns.NCodCliente, e.SelectedCliente)
            If qryCliente.GetCount(Cliente.Columns.NCodCliente) > 0 Then
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, e.SelectedCliente)
                Me.TextValue = objCliente.NCodCliente
                Me.ClienteId = CType(objCliente.NCodCliente, String)
                Me.hfValue = e.SelectedCliente
                Dim q As New Query(Beneficiario.Schema)
                q.AddWhere(Beneficiario.Columns.NCodCliente, objCliente.NCodCliente)
                Dim lst As New BeneficiarioCollection
                lst.LoadAndCloseReader(q.ExecuteReader())
                ddlBeneficiario.DataSource = lst
                ddlBeneficiario.DataValueField = Beneficiario.Columns.NCodBeneficiario
                ddlBeneficiario.DataTextField = Beneficiario.Columns.CNombre
                ddlBeneficiario.DataBind()
                ddlBeneficiario.Items.Add("Elija beneficiario")
                ddlBeneficiario.SelectedValue = "Elija beneficiario"
                ddlBeneficiario.Visible = True
                Me.Nit = lblNitCiCliente.Text.Trim()
                lblNitCiCliente.Text = lblNitCiCliente.Text.Trim()
                Me.Nombre = lblNombreCliente.Text.Trim()
                lblNombreCliente.Text = lblNombreCliente.Text.Trim()
            End If
        End Sub

        Public Property TextValue() As String
            Get
                Return Me.lblCliente.Text
            End Get
            Set(ByVal value As String)
                Me.lblCliente.Text = value
            End Set
        End Property

        Public Property hfValue() As String
            Get
                Return Me.hfClienteId.Value
            End Get
            Set(ByVal value As String)
                Me.hfClienteId.Value = value
            End Set
        End Property

        Public Property BeneficiarioId() As String
            Get
                If Not ViewState("BeneficiarioId") Is Nothing Then
                    Return CType(ViewState("BeneficiarioId"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("BeneficiarioId") = value
            End Set
        End Property

        Public Property ClienteId() As String
            Get
                If Not ViewState("nCodCliente") Is Nothing Then
                    Return CType(ViewState("nCodCliente"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("nCodCliente") = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                If Not ViewState("Nombre") Is Nothing Then
                    Return CType(ViewState("Nombre"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Nombre") = value
            End Set
        End Property

        Public Property TextValueNombre() As String
            Get
                Return Me.lblNombreCliente.Text
            End Get
            Set(ByVal value As String)
                Me.lblNombreCliente.Text = value
            End Set
        End Property

        Public Property Nit() As String
            Get
                If Not ViewState("Nit") Is Nothing Then
                    Return CType(ViewState("Nit"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Nit") = value
            End Set
        End Property

        Public Property TextValueNit() As String
            Get
                Return Me.lblNitCiCliente.Text
            End Get
            Set(ByVal value As String)
                Me.lblNitCiCliente.Text = value
            End Set
        End Property

        Public Sub CargarBeneficiario(ByVal nCodCliente As Integer)
            Dim q As New Query(Beneficiario.Schema)
            q.AddWhere(Beneficiario.Columns.NCodCliente, nCodCliente)
            Dim lst As New BeneficiarioCollection
            lst.LoadAndCloseReader(q.ExecuteReader())
            ddlBeneficiario.DataSource = lst
            ddlBeneficiario.DataValueField = Beneficiario.Columns.NCodBeneficiario
            ddlBeneficiario.DataTextField = Beneficiario.Columns.CNombre
            ddlBeneficiario.DataBind()
            ddlBeneficiario.Items.Add("Elija beneficiario")
            ddlBeneficiario.Visible = True
        End Sub

        Public Property DropDownValue() As String
            Get
                Return Me.ddlBeneficiario.Text
            End Get
            Set(ByVal value As String)
                Me.ddlBeneficiario.Text = value
            End Set
        End Property

        Protected Sub ddlBeneficiario_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlBeneficiario.SelectedIndexChanged
            If ddlBeneficiario.SelectedIndex > -1 Then
                Dim objbeneficiario As New Beneficiario(ddlBeneficiario.SelectedValue.ToString)
                Me.BeneficiarioId = ddlBeneficiario.SelectedValue.ToString
                Me.Nit = objbeneficiario.CNit
                lblNitCiCliente.Text = objbeneficiario.CNit
                Me.Nombre = objbeneficiario.CNombre    'String.Format("{0:F}", objProducto.Preciocompra)
                lblNombreCliente.Text = objbeneficiario.CNombre 'String.Format("{0:F}", objProducto.Preciocompra)
            End If
        End Sub

        Protected Sub lblNombreCliente_TextChanged(sender As Object, e As EventArgs) Handles lblNombreCliente.TextChanged
            Try
                Dim cCliente As String = New [Select]("top 1 cNombre ").From(Beneficiario.Schema). _
                    Where(Beneficiario.CNombreColumn).Like("%" + lblNombreCliente.Text.Trim() + "%").ExecuteScalar(Of String)()
                lblNombreCliente.Text = cCliente
            Catch ex As Exception
                lblNombreCliente.Text = ""
            End Try
        End Sub
    End Class
End Namespace
