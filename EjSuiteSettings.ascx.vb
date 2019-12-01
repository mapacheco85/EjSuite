' EjSuite Notes® - http://www.EjSuitebolivia.com
' Copyright (c) 2011-2031
' by Miguel Angel Pacheco Arteaga. ( http://www.dahathbolivia.com)

Imports System.Web.UI

Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions

Namespace EjSuite.Modules.EjSuite
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Settings class manages Module Settings
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Partial Class EjSuiteSettings
        Inherits Entities.Modules.ModuleSettingsBase

#Region "Base Method Implementations"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' LoadSettings loads the settings from the Database and displays them
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Overrides Sub LoadSettings()
            Try
                If (Page.IsPostBack = False) Then
                    If CType(TabModuleSettings("template"), String) <> "" Then
                        txtTemplate.Text = CType(TabModuleSettings("template"), String)
                    End If
                End If
            Catch exc As Exception           'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' UpdateSettings saves the modified settings to the Database
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Overrides Sub UpdateSettings()
            Try
                Dim objModules As New Entities.Modules.ModuleController
                objModules.UpdateTabModuleSetting(TabModuleId, "template", txtTemplate.Text)

            Catch exc As Exception           'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
#End Region

    End Class
End Namespace

