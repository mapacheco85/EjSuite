Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ClienteControl1

Namespace EjSuite.Modules.EjSuite
    Public Class ClienteVendedorControl
        Inherits EjSuiteModuleBase

        Protected Sub elegirCliente(ByVal sender As Object, ByVal e As ClienteSelectedEventArgs1) Handles cliCliente.ClienteSelected
            Dim qryCliente As New Query(Cliente.Schema)
            qryCliente.AddWhere(Cliente.Columns.NCodCliente, e.SelectedCliente)
            If qryCliente.GetCount(Cliente.Columns.NCodCliente) > 0 Then
                Dim objCliente As New Cliente(Cliente.Columns.NCodCliente, e.SelectedCliente)
                Me.TextValueCliente = objCliente.CCliente
                Dim objEmpleado As New Empleado(Empleado.Columns.NCodUsuario, objCliente.NCodUsuario)
                Me.TextValueEmpleado = String.Format("{0} {1} {2}", objEmpleado.CNombres.ToUpper(), objEmpleado.CApellidoPaterno.ToUpper(), objEmpleado.CApellidoMaterno.ToUpper())
                Me.ClienteId = CType(objCliente.NCodCliente, String)
                Me.EmpleadoId = CType(objEmpleado.NCodEmpleado, String)
            End If
        End Sub

        Public Property TextValueCliente() As String
            Get
                Return Me.txt1.Text
            End Get
            Set(ByVal value As String)
                Me.txt1.Text = value
            End Set
        End Property

        Public Property TextValueEmpleado() As String
            Get
                Return Me.txt2.Text
            End Get
            Set(ByVal value As String)
                Me.txt2.Text = value
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