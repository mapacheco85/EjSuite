Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DotNetNuke.Security.Roles
Imports OfficeOpenXml
Imports OfficeOpenXml.Table

Namespace EjSuite.Modules.EjSuite
    Public Class GridViewExportUtil
        ''' <summary>
        ''' Exportacion de la grilla a Excel 2007
        ''' </summary>
        ''' <param name="fileName">Nombre del Archivo a Guardar</param>
        ''' <param name="gv">La grilla de origen para exportar</param>
        Public Shared Sub Export(ByVal fileName As String, ByVal gv As GridView)
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = ""
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"

            Dim oTabla As New DataTable()

            ' Adicionar columnas al datatable            
            If gv.HeaderRow IsNot Nothing Then
                For i As Integer = 0 To gv.HeaderRow.Cells.Count - 1
                    oTabla.Columns.Add(gv.HeaderRow.Cells(i).Text)
                Next
            End If

            ' adicionar cada una de las filas a la tabla

            For Each fila As GridViewRow In gv.Rows
                Dim oDataRow As DataRow = oTabla.NewRow
                For i As Integer = 0 To fila.Cells.Count - 1
                    oDataRow(i) = fila.Cells(i).Text.Replace(" ", "")
                Next
                oTabla.Rows.Add(oDataRow)
            Next

            Using oPkg As New ExcelPackage()
                Dim oWsht As ExcelWorksheet = oPkg.Workbook.Worksheets.Add("Sheet1")
                oWsht.Cells("A1").LoadFromDataTable(oTabla, True, TableStyles.None)
                oWsht.Cells(oWsht.Dimension.Address).AutoFitColumns()
                ' render el htmlwriter en la respuesta
                HttpContext.Current.Response.BinaryWrite(oPkg.GetAsByteArray())
            End Using
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.[End]()
        End Sub

        ''' <summary>
        ''' Exportacion de la grilla a Excel 2003
        ''' </summary>
        ''' <param name="fileName">Nombre del Archivo a Guardar</param>
        ''' <param name="gv">La grilla de origen para exportar</param>
        Public Shared Sub ExportXls(ByVal fileName As String, ByVal gv As GridView)
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName.Replace(".xlsx", ".xls")))
            HttpContext.Current.Response.ContentType = "application/ms-excel"

            Using sw As New StringWriter()
                Using htw As New HtmlTextWriter(sw)
                    Dim table As New Table()
                    If gv.HeaderRow IsNot Nothing Then
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow)
                        table.Rows.Add(gv.HeaderRow)
                    End If

                    For Each row As GridViewRow In gv.Rows
                        GridViewExportUtil.PrepareControlForExport(row)
                        table.Rows.Add(row)
                    Next

                    If gv.FooterRow IsNot Nothing Then
                        GridViewExportUtil.PrepareControlForExport(gv.FooterRow)
                        table.Rows.Add(gv.FooterRow)
                    End If
                    table.RenderControl(htw)

                    HttpContext.Current.Response.Write(sw.ToString())
                    HttpContext.Current.Response.[End]()
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Reemplazar cualquiera de los campos con valores de tipo literal.
        ''' </summary>
        ''' <param name="control">Control para exportar</param>
        Private Shared Sub PrepareControlForExport(ByVal control As Control)
            For i As Integer = 0 To control.Controls.Count - 1
                Dim current As Control = control.Controls(i)
                If TypeOf current Is LinkButton Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(TryCast(current, LinkButton).Text))
                ElseIf TypeOf current Is ImageButton Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(TryCast(current, ImageButton).AlternateText))
                ElseIf TypeOf current Is HyperLink Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(TryCast(current, HyperLink).Text))
                ElseIf TypeOf current Is DropDownList Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(TryCast(current, DropDownList).SelectedItem.Text))
                ElseIf TypeOf current Is CheckBox Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(If(TryCast(current, CheckBox).Checked, "True", "False")))
                End If

                If current.HasControls() Then
                    GridViewExportUtil.PrepareControlForExport(current)
                End If
            Next
        End Sub
    End Class
End Namespace

