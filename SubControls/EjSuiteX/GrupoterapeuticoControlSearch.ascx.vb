Imports SubSonic

Imports DotNetNuke
Imports EjSuite.Modules.EjSuite.GrupoterapeuticoControl
Imports EjSuite.Modules.EjSuite

Namespace EjSuite.Modules.EjSuite
    Public Class GrupoterapeuticoControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub elegirGrupoterapeutico(ByVal sender As Object, ByVal e As GrupoterapeuticoSelectedEventArgs) Handles gtcGrupoTerapeutico.GrupoterapeuticoSelected
            Dim qryGrupoterapeutico As New Query(GrupoProducto.Schema)
            qryGrupoterapeutico.AddWhere(GrupoProducto.Columns.NCodGrupo, e.SelectedGrupoterapeutico)
            If qryGrupoterapeutico.GetCount(GrupoProducto.Columns.NCodGrupo) > 0 Then
                Dim objGrupoterapeutico As New GrupoProducto(e.SelectedGrupoterapeutico)
                Me.TextValue = objGrupoterapeutico.CGrupoProducto
                Me.Grupocodigo = CType(objGrupoterapeutico.NCodGrupo, String)
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

        Public Property Grupocodigo() As String
            Get
                If Not ViewState("Grupocodigo") Is Nothing Then
                    Return CType(ViewState("Grupocodigo"), String)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Grupocodigo") = value
            End Set
        End Property

    End Class
End Namespace