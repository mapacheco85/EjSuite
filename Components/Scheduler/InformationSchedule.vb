Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Configuration
Imports DotNetNuke
Imports DotNetNuke.Services.Scheduling
Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Common
Imports SubSonic

Imports DotNetNuke.Common.Globals

Namespace EjSuite.Modules.EjSuite.Schedule

    Public Class InformationSchedule
        Inherits DotNetNuke.Services.Scheduling.SchedulerClient

        Public Overrides Sub DoWork()
            Try
                'corriendo los eventos del DNN
                Me.Progressing()

                'corriendo la tarea automatizada
                EnviarReporteDiario()
                Me.ScheduleHistoryItem.Succeeded = True
                Me.ScheduleHistoryItem.AddLogNote("Reporte de ventas enviado exitosamente.")
            Catch ex As Exception
                Me.ScheduleHistoryItem.Succeeded = False
                Me.ScheduleHistoryItem.AddLogNote("Fallo la tarea: " & ex.Message)
                Me.Errored(ex)
                LogException(ex)
            End Try
        End Sub

        Private Sub EnviarReporteDiario()
            Dim oUinfo As UserInfo = UserController.Instance.GetCurrentUserInfo()
            Dim cCrLf As String = System.Environment.NewLine
            Dim nPortalId As Integer = oUinfo.PortalID
            Dim cHostEmail As String = Globals.GetHostPortalSettings().Email
            Dim oConsulta As New SubSonic.Query(Factura.Schema)
            oConsulta.AddBetweenAnd(Factura.Columns.DFechaEmision, Today.AddDays(-1), Today.AddDays(1))
            Dim oData As New FacturaCollection()
            oData.LoadAndCloseReader(oConsulta.ExecuteReader())
            If oData.Count > 0 Then
                Dim oStringBuilder As New StringBuilder
                oStringBuilder.Append("Estimado(a) [Usuario]:" & cCrLf)
                oStringBuilder.Append("Cargo: [Rol]" & cCrLf)
                oStringBuilder.Append("[Mensaje]" & cCrLf & cCrLf)
                oStringBuilder.Append("Fecha del Reporte: [FechaRep]" & cCrLf)
                oStringBuilder.Append("Le rogamos tomar acción lo mas pronto posible." & cCrLf)

                Dim cMotivo As String = "Reporte Diario"
                Dim cNombre As String = oUinfo.DisplayName
                Dim cMensaje As String = String.Empty
                Dim cRol As String = "Gerente"
                Dim cEmail As String = oUinfo.Email

                For Each objFactura As Factura In oData
                    Dim objCliente As New Cliente(objFactura.NCodCliente)
                    cMensaje = "Ventas diarias al " & Now.Date.ToString() & cCrLf & cCrLf
                    cMensaje &= "Cliente: " & objCliente.CCliente & cCrLf
                    cMensaje &= "Fecha: " & objFactura.DFechaEmision & cCrLf

                    Dim monto As Decimal = 0D
                    Dim oConsultaV As New SubSonic.Query(Detalle.Schema)
                    oConsultaV.AddWhere(Detalle.Columns.NcodFactura, objFactura.NCodFactura)
                    Dim lstDetalle As New DetalleCollection()
                    lstDetalle.LoadAndCloseReader(oConsultaV.ExecuteReader())

                    For Each objDetalle As Detalle In lstDetalle
                        monto += (objDetalle.NCantidad * objDetalle.NPrecioUnitario) * (1 - (objDetalle.NDescuento / 100))
                    Next

                    cMensaje += "Monto (Bs.): " & monto.ToString() & vbCrLf
                    oStringBuilder.Replace("[Mensaje]", cMensaje)
                    oStringBuilder.Replace("[Rol]", cRol)
                    oStringBuilder.Replace("[Usuario]", cNombre)
                    oStringBuilder.Replace("[FechaRep]", Now.ToString())
                Next
                'Let's notify manager
                If cHostEmail <> "" Then
                    DotNetNuke.Services.Mail.Mail.SendMail(cHostEmail, cHostEmail, "", "Reportes de ventas diarias", oStringBuilder.ToString(), "", "TEXT", "", "", "", "")
                Else
                    DotNetNuke.Services.Mail.Mail.SendMail(cHostEmail, cHostEmail, "", "Usuario sin email", "El usuario '" & cNombre & "' no tiene email.", "", "TEXT", "", "", "", "")
                End If
                'Return "Processed " & eCount.ToString & " contract email(s)"
            Else
                'Return "No contracts to process"
            End If
        End Sub
    End Class
End Namespace
