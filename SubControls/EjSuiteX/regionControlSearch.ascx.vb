Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Imports SubSonic
Imports EjSuite.Modules.EjSuite.regionControl

Namespace EjSuite.Modules.EjSuite
    Public Class regionControlSearch
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack Then
                txt1.Text = "Elija una Region"
            End If
        End Sub
        Protected Sub elegirRegion(ByVal sender As Object, ByVal e As RegionSelectedEventArgs) Handles cLista.RegionSelected
            Dim qryReg As New Query(Region.Schema)
            qryReg.AddWhere(Region.Columns.NCodRegion, e.SelectedRegion)
            If qryReg.GetCount(Region.Columns.NCodRegion) > 0 Then
                Dim emp As New Region(e.SelectedRegion)
                Me.TextValue = emp.CLugar
                Me.regionId = CType(emp.NCodRegion, Integer)
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

        Public Property regionId() As Nullable(Of Integer)
            Get
                If Not ViewState("RegionId") Is Nothing Then
                    Return CInt(ViewState("RegionId"))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Nullable(Of Integer))
                ViewState("RegionId") = value
            End Set
        End Property
    End Class
End Namespace