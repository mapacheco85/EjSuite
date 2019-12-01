Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ClienteControl1

Namespace EjSuite.Modules.EjSuite
    Public Class VendedorControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija un Vendedor"
            End If
        End Sub

        Protected Sub elegirEmpleado(ByVal sender As Object, ByVal e As EmpleadoSelectedEventArgs1) Handles venVendedor.EmpleadoSelected
            Dim qryEmpleado As New Query(Empleado.Schema)
            qryEmpleado.AddWhere(Empleado.Columns.NCodEmpleado, CDec(e.SelectedEmpleado))
            If qryEmpleado.GetCount(Empleado.Columns.NCodEmpleado) > 0 Then
                Dim objEmpleado As New Empleado(CDec(e.SelectedEmpleado))
                Me.TextValue = objEmpleado.CNombres & " " & objEmpleado.CApellidoPaterno & " " & objEmpleado.CApellidoMaterno
                Me.EmpleadoId = CType(objEmpleado.NCodEmpleado, String)
            Else
                'Contact already exist
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

        Public Property EmpleadoId() As String
            Get
                If Not ViewState("EmpleadoId") Is Nothing Then
                    Return CType(ViewState("EmpleadoId"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("EmpleadoId") = value
            End Set
        End Property

    End Class
End Namespace