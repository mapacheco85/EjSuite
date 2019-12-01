'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Namespace EjSuite.Modules.EjSuite

    Partial Public Class EjSuiteRepFichas

        '''<summary>
        '''Control upPanel.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents upPanel As Global.System.Web.UI.UpdatePanel

        '''<summary>
        '''Control lblResult.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents lblResult As Global.System.Web.UI.WebControls.Label

        '''<summary>
        '''Control pnlClienteExtracto.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents pnlClienteExtracto As Global.System.Web.UI.WebControls.Panel

        '''<summary>
        '''Control panelbusqueda.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents panelbusqueda As Global.System.Web.UI.HtmlControls.HtmlGenericControl

        '''<summary>
        '''Control plClienteExtracto.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents plClienteExtracto As Global.System.Web.UI.UserControl

        '''<summary>
        '''Control CuentaCliente1.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents CuentaCliente1 As Global.EjSuite.Modules.EjSuite.CuentaCliente

        '''<summary>
        '''Control plFechainicial.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents plFechainicial As Global.System.Web.UI.UserControl

        '''<summary>
        '''Control txtFechainicial.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents txtFechainicial As Global.Infragistics.Web.UI.EditorControls.WebDatePicker

        '''<summary>
        '''Control RequiredFieldValidator13.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents RequiredFieldValidator13 As Global.System.Web.UI.WebControls.RequiredFieldValidator

        '''<summary>
        '''Control ValidatorCalloutExtender12.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents ValidatorCalloutExtender12 As Global.AjaxControlToolkit.ValidatorCalloutExtender

        '''<summary>
        '''Control CompareValidator1.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents CompareValidator1 As Global.System.Web.UI.WebControls.CompareValidator

        '''<summary>
        '''Control CompareValidator1_ValidatorCalloutExtender.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents CompareValidator1_ValidatorCalloutExtender As Global.AjaxControlToolkit.ValidatorCalloutExtender

        '''<summary>
        '''Control plFechafinal.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents plFechafinal As Global.System.Web.UI.UserControl

        '''<summary>
        '''Control txtFechafinal.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents txtFechafinal As Global.Infragistics.Web.UI.EditorControls.WebDatePicker

        '''<summary>
        '''Control RequiredFieldValidator14.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents RequiredFieldValidator14 As Global.System.Web.UI.WebControls.RequiredFieldValidator

        '''<summary>
        '''Control ValidatorCalloutExtender21.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents ValidatorCalloutExtender21 As Global.AjaxControlToolkit.ValidatorCalloutExtender

        '''<summary>
        '''Control cmdSearchCuentaCliente.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents cmdSearchCuentaCliente As Global.System.Web.UI.WebControls.Button

        '''<summary>
        '''Control cmdCancelCuentaCliente.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents cmdCancelCuentaCliente As Global.System.Web.UI.WebControls.Button

        '''<summary>
        '''Control lblMessageCuentaCliente.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents lblMessageCuentaCliente As Global.System.Web.UI.WebControls.Label

        '''<summary>
        '''Control grdFichaCuenta.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents grdFichaCuenta As Global.System.Web.UI.WebControls.GridView

        '''<summary>
        '''Control lbtnExportarExcel.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents lbtnExportarExcel As Global.System.Web.UI.WebControls.LinkButton

        '''<summary>
        '''Control lbtnExportarPDF.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents lbtnExportarPDF As Global.System.Web.UI.WebControls.LinkButton

        '''<summary>
        '''Control upHeader.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents upHeader As Global.System.Web.UI.UpdateProgress

        '''<summary>
        '''Control upoeHeader.
        '''</summary>
        '''<remarks>
        '''Campo generado automáticamente.
        '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        '''</remarks>
        Protected WithEvents upoeHeader As Global.Flan.Controls.UpdateProgressOverlayExtender
    End Class
End Namespace
