Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.EmpleadoControl

Namespace EjSuite.Modules.EjSuite

    Public Class EmpleadoControlSearch
        Inherits EjSuiteModuleBase

        Private nEmpleadoId As String

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub
        Protected Sub elegirEmpleado(ByVal sender As Object, ByVal e As EmpleadoSelectedEventArgs) Handles emcEmpleado.EmpleadoSelected
            Dim qryEmpleado As New Query(Empleado.Schema)
            qryEmpleado.AddWhere(Empleado.Columns.NCodEmpleado, e.SelectedEmpleado)
            If qryEmpleado.GetCount(Empleado.Columns.NCodEmpleado) > 0 Then
                Dim objEmpleado As New Empleado(e.SelectedEmpleado)
                Me.TextValue = objEmpleado.CNombres & " " & objEmpleado.CApellidoPaterno & " " & objEmpleado.CApellidoMaterno
                Me.EmpleadoId = CType(objEmpleado.NCodEmpleado, Integer)
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

        Public Property EmpleadoId() As Nullable(Of Integer)
            Get
                If Not ViewState("EmpleadoId1") Is Nothing Then
                    Return CInt(ViewState("EmpleadoId1"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("EmpleadoId1") = value
            End Set
        End Property
    End Class
End Namespace