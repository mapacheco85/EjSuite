Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ClienteControl1

Namespace EjSuite.Modules.EjSuite
    Public Class CuentaCliente
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirCliente(ByVal sender As Object, ByVal e As ClienteSelectedEventArgs1) Handles cliCliente.ClienteSelected
            Dim qryCliente As New Query(Cliente.Schema)
            qryCliente.AddWhere(Cliente.Columns.NCodCliente, e.SelectedCliente)
            If qryCliente.GetCount(Cliente.Columns.NCodCliente) > 0 Then
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, e.SelectedCliente)
                Me.TextValue = objCliente.CCliente
                Me.ClienteId = CType(objCliente.NCodCliente, String)
            End If
        End Sub

        Public Property TextValue() As String
            Get
                Return Me.txt1.Text
            End Get
            Set(ByVal value As String)
                Me.txt1.Text = value
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

    End Class
End Namespace
