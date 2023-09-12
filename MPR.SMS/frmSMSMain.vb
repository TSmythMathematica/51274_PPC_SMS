'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Deployment.Application
Imports MPR.SMS.CaseManagement
Imports MPR.SMS.Data
Imports MPR.SMS.DataQuality
Imports MPR.SMS.DocumentProcessing
Imports MPR.SMS.Locating
Imports MPR.SMS.Security
Imports MPR.Windows.Forms


''' <summary>
'''     Represents the main window that makes up the SMS application's user interface.
''' </summary>

    Public Class frmSMSMain
    Inherits Form

#Region "Constructors"

    ''' <summary>
    '''     Creates a new instance of the main window for a Project.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmSMSMainV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Project.Name & " - Main Menu"
        If Not Project.ShortName Is Nothing Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Main Menu"
        End If


        'lblDB.Text = "Server: " & Project.ServerName & vbCrLf & _
        '             "Database: " & Project.Database & vbCrLf & _
        '             "User: " & CurrentUser.Name & vbCrLf & _
        '             "SMS version: " & Application.ProductVersion

        ' Added for getting the publish version number after deployment - 07/26/2011 WJ 
        If (ApplicationDeployment.IsNetworkDeployed) Then
            lblDB.Text = "Server: " & Project.ServerName & vbCrLf &
                         "Database: " & Project.Database & vbCrLf &
                         "User: " & CurrentUser.Name & vbCrLf &
                         Project.ShortName.ToString & " version: " & My.Application.Deployment.CurrentVersion.ToString()
        Else ' design / debug mode get Assembly version # from assembly info 
            lblDB.Text = "Server: " & Project.ServerName & vbCrLf &
                         "Database: " & Project.Database & vbCrLf &
                         "User: " & CurrentUser.Name & vbCrLf &
                         Project.ShortName.ToString & " version: " & Application.ProductVersion _
            'Assembly version # from assembly info 
        End If


        Me.CenterToScreen()

        ' Display menu options based on current User's permissions
        mnuCaseOpen.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSCaseManagement)
        mnuCaseAdd.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSCaseManagement)
        mnuCaseUpdate.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSCaseManagement)
        mnuCaseAddStudents.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSCaseManagement)
        mnuCaseLookup.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.SMSCaseManagement)
        mnuFieldManagement.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.FSMCaseAssignment)

        mnuRandomAssignment.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSRandomAssignment)

        btnDocProcessing.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSDocumentProcessing)
        mnuDocQueue.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

        btnPayProcessing.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSPaymentProcessing)

        btnReports.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.SMSReporting)

        btnLocating.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.SMSLocating)

        'locating Supervisor functions:
        Dim blnLocSup As Boolean = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
        mnuSep1.Visible = blnLocSup
        mnuLocatingSupervisorReview.Visible = blnLocSup
        mnuLocatingSupervisorReports.Visible = blnLocSup

        btnAdmin.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
        mnuAdminDQWS.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.SystemAdministrator)

        'uncomment out the line below if you don't want Project Admins to have access to the Import function
        'mnuAdminImport.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.SystemAdministrator)

        mnuAdminSurveySettings.Enabled = Project.IsISMSProject

        'fill the Entity Types into the "Add Case" sub-menu
        mnuCaseAdd.MenuItems.Clear()
        Dim mi As MenuItem
        Dim objEntity As EntityType
        For Each objEntity In Project.EntityTypes
            If GetSafeValue(objEntity.EntityAsSample) Then
                mi = New MenuItem(GetSafeValue(objEntity.Description))
                mi.Tag = objEntity
                mnuCaseAdd.MenuItems.Add(mi)
                AddHandler mi.Click, AddressOf Me.mnuCaseAdd_Click
            End If
        Next

        'fill the Instrument Types into the "Update SRDEE" sub-menu
        mnuUpdateSRDEE.MenuItems.Clear()
        Dim objInstrumentType As InstrumentType
        For Each objInstrumentType In Project.InstrumentTypes
            If GetSafeValue(objInstrumentType.IsSRDEE) Then
                mi = New MenuItem(GetSafeValue(objInstrumentType.Description))
                mi.Tag = objInstrumentType
                mnuUpdateSRDEE.MenuItems.Add(mi)
                AddHandler mi.Click, AddressOf Me.mnuUpdateSRDEE_Click
            End If
        Next

        'fill the Instrument Types into the "View SRDEE" sub-menu
        mnuViewSRDEE.MenuItems.Clear()
        For Each objInstrumentType In Project.InstrumentTypes
            If GetSafeValue(objInstrumentType.IsSRDEE) Then
                mi = New MenuItem(GetSafeValue(objInstrumentType.Description))
                mi.Tag = objInstrumentType
                mnuViewSRDEE.MenuItems.Add(mi)
                AddHandler mi.Click, AddressOf Me.mnuViewSRDEE_Click
            End If
        Next

        'fill the Instrument Types into the "Compare SRDEE" sub-menu
        mnuCompareSRDEE.MenuItems.Clear()
        For Each objInstrumentType In Project.InstrumentTypes
            If GetSafeValue(objInstrumentType.IsSRDEELongitudinal) Then
                mi = New MenuItem(GetSafeValue(objInstrumentType.Description))
                mi.Tag = objInstrumentType
                mnuCompareSRDEE.MenuItems.Add(mi)
                AddHandler mi.Click, AddressOf Me.mnuCompareSRDEE_Click
            End If
        Next

        'Dim IsSRDEEUser As Boolean = GetSRDEEUser(CurrentUser.Name.ToString)
        Dim IsSRDEESupervisor As Boolean = GetSRDEESupervisor(CurrentUser.Name.ToString)

        If IsSRDEESupervisor AndAlso CurrentUser.HasFullAccess(Security.Enumerations.Permission.SRDEE) Then
            mnuAddUpdateVariables.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SRDEE)
        Else
            mnuAddUpdateVariables.Enabled = False
        End If

        mnuUpdateSRDEE.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SRDEE)
        mnuViewSRDEE.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.SRDEE)
        mnuCompareSRDEE.Enabled = CurrentUser.HasPermission(Security.Enumerations.Permission.SRDEE)
    End Sub

    Private Sub frmSMSMainV2_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ShowMessageOfTheDay()
    End Sub

    Private Sub ShowMessageOfTheDay()

        Dim Setting As Setting = Project.Settings.MessageOfTheDay
        If Setting IsNot Nothing Then
            lblDescription.Text = Setting.Value.ToString.Replace("<project long name>", Project.Name.ToString)
            lblDescription.Text = lblDescription.Text.Replace("<project short name>", Project.ShortName.ToString)
        Else
            lblDescription.Text = String.Format("Welcome to the {0} project, from your project administrator.",
                                                Project.Name.ToString)
        End If

        lblValue.Height = 13
        lblValue.Text = lblDescription.Text
        lblValue.Font = lblDescription.Font
        'increase the height of the control if the text is too long for the width
        Dim w1 As Integer = lblDescription.Width
        lblValue.AutoSize = True
        Dim w2 As Integer = lblValue.Width + 2  'add 2 b/c sometimes autosize doesn't add enough spaces
        lblValue.AutoSize = False
        Dim x As Integer = CInt(w2/w1)
        If w2 > w1 AndAlso w2 Mod w1 > 0 Then x += 1
        If x > 1 Then
            dy = (lblValue.Height - 4)*(x - 1)
            'lblDescription.Height += dy
        End If
    End Sub

    Private dy As Integer

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click

        AboutDialog.Run("Server: " & Project.ServerName, "Database: " & Project.Database)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click

        Reports.ShowDialog(Me, Project.ShortName, Project.ProjectCode)
    End Sub

    Private Sub mnuCaseOpen_Click(sender As Object, e As EventArgs) Handles mnuCaseOpen.Click

        Dim mi As MenuItem = CType(sender, MenuItem)

    End Sub

    Private Sub mnuCaseOpenMPRID_Click(sender As Object, e As EventArgs) Handles mnuCaseOpenMPRID.Click

        Dim frm As New frmMPRIDSearch
        frm.Show()
    End Sub

    Private Sub mnuCaseAdd_Click(sender As Object, e As EventArgs) Handles mnuCaseAdd.Click

        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim frmDisplayCase As New frmDisplayCase(CType(mi.Tag, EntityType).EntityTypeID.Value)
        frmDisplayCase.Show()
    End Sub

    Private Sub mnuCaseUpdate_Click(sender As Object, e As EventArgs) Handles mnuCaseUpdate.Click

        Dim frm As New frmSearch
        frm.Show()
    End Sub

    Private Sub mnuCaseOpenPhone_Click(sender As Object, e As EventArgs) Handles mnuCaseOpenPhone.Click

        Dim frm As New frmSearch("Phone")
        frm.Show()
    End Sub

    Private Sub mnuCaseAddStudents_Click(sender As Object, e As EventArgs) Handles mnuCaseAddStudents.Click

        Dim frm As New frmStudentEntry
        frm.Show()
    End Sub

    Private Sub mnuCaseLookup_Click(sender As Object, e As EventArgs) Handles mnuCaseLookup.Click

        Dim frm As New frmSearch(True)    'open in read-only mode
        frm.Show()
    End Sub

    Private Sub mnuAdminCaseLocks_Click(sender As Object, e As EventArgs) Handles mnuAdminCaseLocks.Click

        Dim frm As New frmCaseLockAdmin
        frm.Show()
    End Sub

    Private Sub mnuDocRelease_Click(sender As Object, e As EventArgs) Handles mnuDocRelease.Click

        ReleaseDocuments.ShowDialog(Me, Project.ShortName, Project.ProjectCode)
    End Sub

    Private Sub mnuDocReceipt_Click(sender As Object, e As EventArgs) Handles mnuDocReceipt.Click

        Dim frm As New frmStatusing
        frm.Show()
    End Sub

    Private Sub mnuDocQueue_Click(sender As Object, e As EventArgs) Handles mnuDocQueue.Click

        Dim frm As New frmDocuments
        frm.Show()
    End Sub

    Private Sub mnuDocQueries_Click(sender As Object, e As EventArgs) Handles mnuDocQueries.Click

        Queries.ShowDialog(Me, Project.ShortName, True)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnCase_Click(sender As Object, e As EventArgs) Handles btnCase.Click

        btnCase.ContextMenu.Show(btnCase, New Point(btnCase.Width, 0))
    End Sub

    Private Sub btnDocProcessing_Click(sender As Object, e As EventArgs) Handles btnDocProcessing.Click

        btnDocProcessing.ContextMenu.Show(btnDocProcessing, New Point(btnDocProcessing.Width, 0))
    End Sub

    Private Sub btnPayProcessing_Click(sender As Object, e As EventArgs) Handles btnPayProcessing.Click

        btnPayProcessing.ContextMenu.Show(btnPayProcessing, New Point(btnPayProcessing.Width, 0))
    End Sub

    Private Sub btnLocating_Click(sender As Object, e As EventArgs) Handles btnLocating.Click

        btnLocating.ContextMenu.Show(btnLocating, New Point(btnLocating.Width, 0))
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click

        btnAdmin.ContextMenu.Show(btnAdmin, New Point(btnAdmin.Width, 0))
    End Sub

    Private Sub mnuAdminStatus_Click(sender As Object, e As EventArgs) Handles mnuAdminStatus.Click

        Dim frm As New frmStatus
        frm.Show()
    End Sub

    Private Sub mnuAdminImport_Click(sender As Object, e As EventArgs) Handles mnuAdminImport.Click

        Dim frm As New frmDataImport
        frm.Show()
    End Sub

    Private Sub mnuAdminMgmt_Click(sender As Object, e As EventArgs) Handles mnuAdminMgmt.Click

        Dim frm As New frmManagementSummary
        frm.Show()
    End Sub

    Private Sub mnuAdminDQWS_Click(sender As Object, e As EventArgs) Handles mnuAdminDQWS.Click

        Dim frm As New frmDemo
        frm.Show()
    End Sub

    Private Sub mnuLocatingSelect_Click(sender As Object, e As EventArgs) Handles mnuLocatingSelect.Click

        Dim frm As New frmLocatingSelection
        frm.Show()
    End Sub

    Private Sub mnuLocatingSupervisorReports_Click(sender As Object, e As EventArgs) _
        Handles mnuLocatingSupervisorReports.Click

        Reports.ShowDialog(Me, Project.ShortName & "\Locating", Project.ProjectCode)
    End Sub

    Private Sub mnuLocatingSupervisorReview_Click(sender As Object, e As EventArgs) _
        Handles mnuLocatingSupervisorReview.Click

        Dim frm As New frmSearchSupReview
        frm.Show()
    End Sub

    Private Sub mnuLocatingCallIns_Click(sender As Object, e As EventArgs) Handles mnuLocatingCallIns.Click

        Dim frm As New frmSearchCallIn
        frm.Show()
    End Sub

    Private Sub mnuPaymentAddressReview_Click(sender As Object, e As EventArgs) Handles mnuPaymentAddressReview.Click

        Dim frm As New frmAddressReview
        frm.Show()
    End Sub

    Private Sub mnuPaymentReissues_Click(sender As Object, e As EventArgs) Handles mnuPaymentReissues.Click

        Dim frm As New frmPayments
        frm.Show()
    End Sub

    Private Sub mnuFieldManagement_Click(sender As Object, e As EventArgs) Handles mnuFieldManagement.Click

        'Dim frm As New frmFieldManagement(New Uri(Project.FMSiteAddress))
        Dim frm As New MPR.SMS.FieldManagement.frmFieldManagement
        frm.Show()

        frm.Show()
    End Sub

    Private Sub mnuBatchClean_Click(sender As Object, e As EventArgs) Handles mnuBatchClean.Click

        Dim frm As New frmBatchClean
        frm.Show()
    End Sub

    Private Sub mnuAdminTCPALookup_Click(sender As Object, e As EventArgs) Handles mnuAdminTCPALookup.Click

        Dim frm As New frmBatchTCPA
        frm.Show()
    End Sub

    Private Sub mnuDocDiscrep_Click(sender As Object, e As EventArgs) Handles mnuDocDiscrep.Click

        'ReadHistFromConfirmit()
        'ReadFromConfirmit()
        Dim frm As New frmConfirmitReport
        frm.Show()
    End Sub

    Private Sub mnuAdminReports_Click(sender As Object, e As EventArgs) Handles mnuAdminReports.Click
        Reports.ShowDialog(Me, Project.ShortName & "\Admin", Project.ProjectCode)
    End Sub

    Private Sub mnuAdminSurveySettings_Click(sender As Object, e As EventArgs) Handles mnuAdminSurveySettings.Click

        Dim frm As New frmSurveySettings
        frm.Show()
    End Sub

    Private Sub btnSRDEE_Click(sender As Object, e As EventArgs) Handles btnSRDEE.Click

        btnSRDEE.ContextMenu.Show(btnSRDEE, New Point(btnSRDEE.Width, 0))
    End Sub

    Private Sub mnuAddUpdateVariables_Click(sender As Object, e As EventArgs) Handles mnuAddUpdateVariables.Click

        Dim frm As New frmAddUpdateVariables
        frm.ShowDialog()
    End Sub

    Private Sub mnuUpdateSRDEE_Click(sender As Object, e As EventArgs) Handles mnuUpdateSRDEE.Click

        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim _
            frm As _
                New frmSearchSurveyResponse(CInt(CType(mi.Tag, InstrumentType).InstrumentTypeID.Value),
                                            CType(mi.Tag, InstrumentType).Description.Value, "Update", "")
        frm.Show()
    End Sub

    Private Sub mnuViewSRDEE_Click(sender As Object, e As EventArgs) Handles mnuViewSRDEE.Click

        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim _
            frm As _
                New frmSearchSurveyResponse(CInt(CType(mi.Tag, InstrumentType).InstrumentTypeID.Value),
                                            CType(mi.Tag, InstrumentType).Description.Value, "View", "")
        frm.Show()
    End Sub

    Private Sub mnuCompareSRDEE_Click(sender As Object, e As EventArgs) Handles mnuCompareSRDEE.Click

        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim _
            frm As _
                New frmSearchSurveyResponse(0, CType(mi.Tag, InstrumentType).Description.Value, "Compare",
                                            CType(mi.Tag, InstrumentType).SRDEEViewLongitudinal.Value)
        frm.Show()
    End Sub

#End Region
End Class
