Imports SubSonic
Imports DotNetNuke
Imports DotNetNuke.Security.Roles
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EjSuite.Modules.EjSuite
    Public Class DeudorControl
        Inherits EjSuiteModuleBase
        Public Sub New()
            
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then
                txtFechafinalDeudas.Text = Now.Date
                Me.ModalPopupExtender1.Hide()
                Dim q As New Query(VwDeuda.Schema)
                txtFechafinalDeudas.Text = Now.Date
                q.AddWhere(VwDeuda.Columns.Deuda, Comparison.GreaterThan, 0)
                If txtFechafinalDeudas.Text <> "" Then
                    q.AND(VwDeuda.Columns.Vence, Comparison.GreaterOrEquals, txtFechafinalDeudas)
                End If
                If txtFechafinalDeudas.Text <> "" Then
                    q.AND(VwDeuda.Columns.Emitida, Comparison.LessOrEquals, txtFechafinalDeudas.Text)
                End If
                Dim ORDER_BY1 As Query = q.ORDER_BY(VwDeuda.Columns.NNumero)
                Dim lst As New VwDeudaCollection()
                lst.LoadAndCloseReader(q.ExecuteReader())
                grdDeudas.DataSource = lst
                grdDeudas.DataKeyNames = New String() {VwDeuda.Columns.NCodFactura}
                grdDeudas.DataBind()
                lblSearchResults.Text = String.Format("Se encontraron {0} registro(s)", lst.Count.ToString())
            End If
        End Sub

        Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Me.ModalPopupExtender1.Hide()
        End Sub
    End Class
End Namespace
