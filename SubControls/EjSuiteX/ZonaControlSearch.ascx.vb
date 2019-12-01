Imports SubSonic
Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.ZonaControl

Namespace EjSuite.Modules.EjSuite
    Public Class ZonaControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija una zona"
            End If
        End Sub

        Protected Sub elegirZona(ByVal sender As Object, ByVal e As ZonaSelectedEventArgs) Handles sucZona.ZonaSelected
            Dim qryZona As New Query(Zona.Schema)
            qryZona.AddWhere(Zona.Columns.NCodUnidad, e.SelectedZona)
            If qryZona.GetCount(Zona.Columns.NCodUnidad) > 0 Then
                Dim objZona As New Zona(e.SelectedZona)
                Me.TextValue = objZona.CDescripcion
                Me.ZonaId = CType(objZona.NCodUnidad, Integer)
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

        Public Property ZonaId() As Nullable(Of Integer)
            Get
                If Not ViewState("ZonaId") Is Nothing Then
                    Return CInt(ViewState("ZonaId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("ZonaId") = value
            End Set
        End Property
    End Class
End Namespace