Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports SubSonic
Imports EjSuite.Modules.EjSuite.VentaControlSearch
Imports System.Transactions
Imports iTextSharp.text.pdf
Imports DotNetNuke.Entities.Users


Namespace EjSuite.Modules.EjSuite
    Public Class EjSuiteBienvenido
        Inherits EjSuiteModuleBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then

                If (UserController.Instance.GetCurrentUserInfo().Username <> "") Then
                    Dim idSni As Integer = New [Select](Aggregate.Max(SniDatum.Columns.NCodSNI)). _
                                From(SniDatum.Schema).ExecuteScalar(Of Integer)()
                    Dim objSni As New SniDatum(idSni)

                    If DateDiff(DateInterval.Day, Now.Date, objSni.DFechaFinal) < 50 Then
                        EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("¡Le quedan {0} días de facturación!", _
                         DateDiff(DateInterval.Day, Now.Date, objSni.DFechaFinal)))
                    End If
                    imgLogo.Visible = True
                    EjSuite.Mensaje(Me.upPanel, Me.GetType(), String.Format("¡Bienvenido: {0} al Sistema EjSuite !", _
                                                        UserController.Instance.GetCurrentUserInfo().Username))
                Else
                    imgLogo.Visible = False
                End If
            End If
        End Sub

    End Class
End Namespace