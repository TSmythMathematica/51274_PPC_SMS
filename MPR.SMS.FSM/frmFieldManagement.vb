Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.Windows.Forms
Imports System.Windows.Forms

Public Class frmFieldManagement

#Region "Private Variables"

    Private mobjInterviewers As Interviewers
    Private mintCaseViewType As CaseAssignments.CaseAssignmentType
    Private mblnAdmin As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If Not Me.DesignMode Then

            ucNavigate.Dock = DockStyle.Fill

            mblnAdmin = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

            If mblnAdmin Then
                ViewByRegions.Checked = (My.Settings.FSMViewStaffBy = 1 Or My.Settings.FSMViewStaffBy = 0)
                ViewBySupervisors.Checked = (My.Settings.FSMViewStaffBy = 2)
                ViewByTeams.Checked = (My.Settings.FSMViewStaffBy = 3)
                ViewByInterviewers.Checked = (My.Settings.FSMViewStaffBy = 4)
            Else
                ucNavigate.CurrentSupervisor = New InterviewerSupervisor(CurrentUser.Name)

                ViewByRegions.Enabled = False
                ViewBySupervisors.Enabled = False
                ViewByInterviewers.Checked =
                    (My.Settings.FSMViewStaffBy = 4 Or Project.ProjectUsesInterviewTeams = False)
                ViewByTeams.Checked = Not ViewByInterviewers.Checked
            End If

            CaseViewType = CType(My.Settings.FSMViewAssignmentsBy, CaseAssignments.CaseAssignmentType)

            TreeView.Checked = True
            tbTreeView.Checked = True
            ViewRefresh.Enabled = True
            tbRefresh.Enabled = True
            mnuInterviewWeeks.Enabled = mblnAdmin
            ucCaseAssignments.AllowFiltering = True

            Me.Text = "SMS - [ " & Project.ShortName & "] - Field Management"

            EditCaseProperties.Enabled = False
        End If
    End Sub

#End Region

#Region "Properties"

    Private Property CaseViewType() As CaseAssignments.CaseAssignmentType
        Get
            Return mintCaseViewType
        End Get
        Set(ByVal value As CaseAssignments.CaseAssignmentType)
            If mintCaseViewType <> value Then
                mintCaseViewType = value
                SetViewType()
            End If
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub ViewBySupervisors_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewBySupervisors.Click

        ViewByRegions.Checked = False
        ViewBySupervisors.Checked = True
        ViewByTeams.Checked = False
        ViewByInterviewers.Checked = False
    End Sub

    Private Sub ViewByRegions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewByRegions.Click

        ViewByRegions.Checked = True
        ViewBySupervisors.Checked = False
        ViewByTeams.Checked = False
        ViewByInterviewers.Checked = False
    End Sub

    Private Sub ViewByInterviewers_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewByInterviewers.Click

        ViewByRegions.Checked = False
        ViewBySupervisors.Checked = False
        ViewByTeams.Checked = False
        ViewByInterviewers.Checked = True
    End Sub

    Private Sub ViewByTeams_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewByTeams.Click

        ViewByRegions.Checked = False
        ViewBySupervisors.Checked = False
        ViewByTeams.Checked = True
        ViewByInterviewers.Checked = False
    End Sub

    Private Sub ViewBySupervisors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewBySupervisors.CheckedChanged

        If ViewBySupervisors.Checked = True Then
            TreeView.PerformClick()
            ucNavigate.ViewBy = ucNavigate.ViewByType.Supervisor
        End If
    End Sub

    Private Sub ViewByRegions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewByRegions.CheckedChanged

        If ViewByRegions.Checked = True Then
            TreeView.PerformClick()
            ucNavigate.ViewBy = ucNavigate.ViewByType.Region
        End If
    End Sub

    Private Sub ViewByTeams_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewByTeams.CheckedChanged

        If ViewByTeams.Checked = True Then
            TreeView.PerformClick()
            ucNavigate.ViewBy = ucNavigate.ViewByType.Team
        End If
    End Sub

    Private Sub ViewByInterviewers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ViewByInterviewers.CheckedChanged

        If ViewByInterviewers.Checked = True Then
            TreeView.PerformClick()
            ucNavigate.ViewBy = ucNavigate.ViewByType.Interviewer
        End If
    End Sub

    Private Sub tbRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbRefresh.Click

        ucNavigate.Refresh()
    End Sub

    Private Sub ViewRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewRefresh.Click

        ucNavigate.Refresh()
    End Sub

    Private Sub tbTreeView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTreeView.Click

        Me.ucSearch.Visible = False
        Me.ucNavigate.Visible = True

        tbRefresh.Enabled = ucNavigate.Visible
        ViewRefresh.Enabled = tbRefresh.Enabled

        TreeView.Checked = ucNavigate.Visible
        SearchView.Checked = ucSearch.Visible
        tbTreeView.Checked = TreeView.Checked
        tbSearch.Checked = SearchView.Checked

        ucCaseAssignments.AllowFiltering = ucNavigate.Visible
    End Sub

    Private Sub TreeView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView.Click

        Me.ucSearch.Visible = False
        Me.ucNavigate.Visible = True

        tbRefresh.Enabled = ucNavigate.Visible
        ViewRefresh.Enabled = tbRefresh.Enabled

        TreeView.Checked = ucNavigate.Visible
        SearchView.Checked = ucSearch.Visible
        tbTreeView.Checked = TreeView.Checked
        tbSearch.Checked = SearchView.Checked

        ucCaseAssignments.AllowFiltering = ucNavigate.Visible
    End Sub

    Private Sub tbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearch.Click

        Me.ucSearch.Visible = True
        Me.ucNavigate.Visible = False

        tbRefresh.Enabled = ucNavigate.Visible
        ViewRefresh.Enabled = tbRefresh.Enabled

        TreeView.Checked = ucNavigate.Visible
        SearchView.Checked = ucSearch.Visible
        tbTreeView.Checked = TreeView.Checked
        tbSearch.Checked = SearchView.Checked

        ucCaseAssignments.AllowFiltering = ucNavigate.Visible
    End Sub

    Private Sub SearchView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchView.Click

        Me.ucSearch.Visible = True
        Me.ucNavigate.Visible = False

        tbRefresh.Enabled = ucNavigate.Visible
        ViewRefresh.Enabled = tbRefresh.Enabled

        TreeView.Checked = ucNavigate.Visible
        SearchView.Checked = ucSearch.Visible
        tbTreeView.Checked = TreeView.Checked
        tbSearch.Checked = SearchView.Checked

        ucCaseAssignments.AllowFiltering = ucNavigate.Visible
    End Sub

    Private Sub ucNavigate_OnRefreshList(ByVal sender As Object) Handles ucNavigate.OnRefreshList

        StaffCount.Text = CStr(ucNavigate.Interviewers.Count) & " Interviewer(s)"
    End Sub

    Private Sub ucNavigate_OnTrackInterviewer(ByVal sender As Object, ByVal objInterviewer As Data.Interviewer) _
        Handles ucNavigate.OnTrackInterviewer

        TrackInterviewer(objInterviewer)
    End Sub

    Private Sub ucNavigate_SelectionChanged(ByVal sender As Object, ByVal obj As Object) _
        Handles ucNavigate.SelectionChanged

        Me.Cursor = Cursors.WaitCursor

        mnuUpdateInterviewer.Visible = False
        mnuUpdateTeam.Visible = False
        mnuUpdateSupervisor.Visible = False
        mnuUpdateRegion.Visible = False

        mnuTrackInterviewer.Visible = False
        If obj IsNot Nothing Then
            If obj.GetType Is GetType(Interviewer) Then
                mnuUpdateInterviewer.Visible = True
                mnuTrackInterviewer.Visible = True
            ElseIf obj.GetType Is GetType(InterviewerTeam) Then
                mnuUpdateTeam.Visible = True
            ElseIf obj.GetType Is GetType(InterviewerSupervisor) Then
                mnuUpdateSupervisor.Visible = True
            ElseIf obj.GetType Is GetType(InterviewerRegion) Then
                mnuUpdateRegion.Visible = True
            End If
            ucCaseAssignments.GetAssignments(obj)
            CaseCount.Text = CStr(ucCaseAssignments.CaseAssignments.Count) & " Case(s)"
        Else
            ucCaseAssignments.CaseAssignments = Nothing
            CaseCount.Text = "0 Cases"
        End If
        mnuSep.Visible = (obj IsNot Nothing)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ucSearch_OnSearch(ByVal sender As Object, ByVal objCaseAssignments As Data.CaseAssignments) _
        Handles ucSearch.OnSearch

        ucCaseAssignments.CaseAssignments = objCaseAssignments
        CaseCount.Text = CStr(ucCaseAssignments.CaseAssignments.Count) & " Case(s)"
    End Sub

    Private Sub FileMenuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileMenuExit.Click

        Me.Close()
    End Sub

    Private Sub mnuUpdateRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUpdateRegion.Click

        If ucNavigate.SelectedNode IsNot Nothing Then
            UpdateRegion(CType(ucNavigate.SelectedNode.Tag, InterviewerRegion))
        End If
    End Sub

    Private Sub mnuUpdateSupervisor_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuUpdateSupervisor.Click

        If ucNavigate.SelectedNode IsNot Nothing Then
            UpdateSupervisor(CType(ucNavigate.SelectedNode.Tag, InterviewerSupervisor))
        End If
    End Sub

    Private Sub mnuUpdateTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUpdateTeam.Click

        If ucNavigate.SelectedNode IsNot Nothing Then
            UpdateTeam(CType(ucNavigate.SelectedNode.Tag, InterviewerTeam))
        End If
    End Sub

    Private Sub mnuUpdateInterviewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuUpdateInterviewer.Click

        If ucNavigate.SelectedNode IsNot Nothing Then
            UpdateInterviewer(CType(ucNavigate.SelectedNode.Tag, Interviewer))
        End If
    End Sub

    Private Sub mnuNewRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNewRegion.Click

        UpdateRegion(New InterviewerRegion)
    End Sub

    Private Sub mnuNewSupervisor_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuNewSupervisor.Click

        UpdateSupervisor(New InterviewerSupervisor)
    End Sub

    Private Sub mnuNewTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNewTeam.Click

        UpdateTeam(New InterviewerTeam)
    End Sub

    Private Sub mnuNewInterviewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuNewInterviewer.Click

        UpdateInterviewer(New Interviewer)
    End Sub

    Private Sub ucNavigate_UpdateInterviewer(ByVal sender As Object, ByVal objInterviewer As Data.Interviewer) _
        Handles ucNavigate.UpdateInterviewer

        If objInterviewer IsNot Nothing Then
            UpdateInterviewer(objInterviewer)
        End If
    End Sub

    Private Sub ucNavigate_UpdateRegion(ByVal sender As Object, ByVal objRegion As Data.InterviewerRegion) _
        Handles ucNavigate.UpdateRegion

        If objRegion IsNot Nothing Then
            UpdateRegion(objRegion)
        End If
    End Sub

    Private Sub ucNavigate_UpdateSupervisor(ByVal sender As Object, ByVal objSupervisor As Data.InterviewerSupervisor) _
        Handles ucNavigate.UpdateSupervisor

        If objSupervisor IsNot Nothing Then
            UpdateSupervisor(objSupervisor)
        End If
    End Sub

    Private Sub ucNavigate_UpdateTeam(ByVal sender As Object, ByVal objTeam As Data.InterviewerTeam) _
        Handles ucNavigate.UpdateTeam

        If objTeam IsNot Nothing Then
            UpdateTeam(objTeam)
        End If
    End Sub

    Private Sub frmFieldManagement_FormClosing(ByVal sender As Object,
                                               ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing

        If ViewByRegions.Checked Then
            My.Settings.FSMViewStaffBy = 1
        ElseIf ViewBySupervisors.Checked Then
            My.Settings.FSMViewStaffBy = 2
        ElseIf ViewByTeams.Checked Then
            My.Settings.FSMViewStaffBy = 3
        ElseIf ViewByInterviewers.Checked Then
            My.Settings.FSMViewStaffBy = 4
        End If
        My.Settings.FSMViewAssignmentsBy = ucCaseAssignments.CaseViewType

        My.Settings.Save()
    End Sub

    Private Sub mnuInterviewWeeks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuInterviewWeeks.Click

        Dim frm As frmInterviewWeeks = New frmInterviewWeeks
        frm.ShowDialog()
    End Sub

    Private Sub mnuTrackInterviewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuTrackInterviewer.Click

        If ucNavigate.SelectedNode IsNot Nothing AndAlso
           ucNavigate.SelectedNode.Tag.GetType Is GetType(Interviewer) Then
            TrackInterviewer(CType(ucNavigate.SelectedNode.Tag, Interviewer))
        End If
    End Sub

    Private Sub mnuViewCasesActive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesActive.CheckedChanged

        If mnuViewCasesActive.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewActive
        End If
    End Sub

    Private Sub mnuViewCasesAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesAll.CheckedChanged

        If mnuViewCasesAll.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewAll
        End If
    End Sub

    Private Sub mnuViewCasesAssigned_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesAssigned.CheckedChanged

        If mnuViewCasesAssigned.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewAssigned
        End If
    End Sub

    Private Sub mnuViewCasesCompleted_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesCompleted.CheckedChanged

        If mnuViewCasesCompleted.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewCompleted
        End If
    End Sub

    Private Sub mnuViewCasesUnassigned_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesUnassigned.CheckedChanged

        If mnuViewCasesUnassigned.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewUnassigned
        End If
    End Sub

    Private Sub mnuViewCasesValidation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mnuViewCasesValidation.CheckedChanged

        If mnuViewCasesValidation.Checked Then
            CaseViewType = CaseAssignments.CaseAssignmentType.ViewValidation
        End If
    End Sub


    Private Sub EditCaseProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles EditCaseProperties.Click

        If _
            ucCaseAssignments.SelectedCaseAssignments IsNot Nothing AndAlso
            ucCaseAssignments.SelectedCaseAssignments.Count = 1 Then
            CaseProperties(ucCaseAssignments.SelectedCaseAssignments(0).Case)
        End If
    End Sub

    Private Sub EditAssignCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditAssignCases.Click

        If ucCaseAssignments.SelectedCaseAssignments IsNot Nothing Then
            AssignCases(ucCaseAssignments.SelectedCaseAssignments)
        End If
    End Sub

    Private Sub ucCaseAssignments_OnAssignCases(ByVal sender As Object, ByVal objCaseAssignments As Data.CaseAssignments) _
        Handles ucCaseAssignments.OnAssignCases

        If objCaseAssignments IsNot Nothing Then
            AssignCases(objCaseAssignments)
        End If
    End Sub

    Private Sub ucCaseAssignments_OnBeginDrag(ByVal sender As Object, ByVal objCaseAssignments As Data.CaseAssignments) _
        Handles ucCaseAssignments.OnBeginDrag

        ucNavigate.CaseAssignments = objCaseAssignments
    End Sub

    Private Sub ucCaseAssignments_OnCaseProperties(ByVal sender As Object, ByVal objCase As Data.Case) _
        Handles ucCaseAssignments.OnCaseProperties

        If objCase IsNot Nothing Then
            CaseProperties(objCase)
        End If
    End Sub

    Private Sub ucCaseAssignments_OnCaseSelected(ByVal sender As Object, ByVal objCase As Data.Case) _
        Handles ucCaseAssignments.OnCaseSelected

        EditCaseProperties.Enabled = (objCase IsNot Nothing)
    End Sub

    Private Sub ucCaseAssignments_OnViewChanged(ByVal sender As Object,
                                                ByVal pCaseViewType As Data.CaseAssignments.CaseAssignmentType) _
        Handles ucCaseAssignments.OnViewChanged

        CaseViewType = pCaseViewType
    End Sub

    Private Sub frmFieldManagement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SplitContainer2.SplitterDistance = 272

        Dim blnAccess As Boolean = CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)

        mnuNewInterviewer.Enabled = blnAccess
        mnuNewRegion.Enabled = blnAccess And mblnAdmin
        mnuNewSupervisor.Enabled = blnAccess And mblnAdmin
        mnuNewTeam.Enabled = blnAccess
        mnuUpdateInterviewer.Enabled = blnAccess
        mnuUpdateRegion.Enabled = blnAccess
        mnuUpdateSupervisor.Enabled = blnAccess
        mnuUpdateTeam.Enabled = blnAccess
        mnuNewTeam.Visible = Project.ProjectUsesInterviewTeams
        'mnuUpdateTeam.Visible = Project.ProjectUsesInterviewTeams
        ViewByTeams.Visible = Project.ProjectUsesInterviewTeams
    End Sub

    Private Sub mnuDocumentsReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuDocumentsReports.Click

        'MPR.SMS.DocumentProcessing.Reports.ShowDialog(Me, System.Configuration.ConfigurationManager.AppSettings("ProjectShortName") & "\FieldManagement")

        MessageBox.Show("Not supported", Project.ShortName & " - Error running reports!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
    End Sub

    Private Sub mnuDocumentsRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuDocumentsRelease.Click

        MPR.SMS.DocumentProcessing.ReleaseDocuments.ReleaseDocumentGroup(Me, Project.ShortName, "CAPI Release")
    End Sub

    Private Sub mnuDocumentsTeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuDocumentsTeam.Click

        MPR.SMS.DocumentProcessing.ReleaseDocuments.ReleaseDocument(Me, Project.ShortName, "CAPI Team Members")
    End Sub

    Private Sub mnuDocumentsSupplies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuDocumentsSupplies.Click

        MPR.SMS.DocumentProcessing.ReleaseDocuments.ReleaseDocumentGroup(Me, Project.ShortName, "CAPI Supplies")
    End Sub

    Private Sub mnuDocumentsValidations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuDocumentsValidations.Click

        MPR.SMS.DocumentProcessing.ReleaseDocuments.ReleaseDocumentGroup(Me, Project.ShortName, "CAPI Validations")
    End Sub

#End Region

#Region "Private Methods"

    Private Sub UpdateRegion(ByVal objRegion As InterviewerRegion)

        Dim blnNew As Boolean = (objRegion.InterviewerRegionID.IsNull)
        Dim frm As frmRegion

        frm = New frmRegion(objRegion)

        frm.ShowDialog()
        If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then
            If blnNew Then
                ucNavigate.Refresh()
            Else
                ucNavigate.SelectedNode.Text = objRegion.NodeText
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub UpdateSupervisor(ByVal objSupervisor As InterviewerSupervisor)

        Dim blnNew As Boolean = (objSupervisor.InterviewerSupervisorID.IsNull)
        Dim frm As frmSupervisor

        'get the Supervisor's Region
        Dim objParent As Object = Nothing
        Dim objParentNode As TreeNode = ucNavigate.SelectedNode
        Do
            If objParentNode.Tag IsNot Nothing AndAlso
               objParentNode.Tag.GetType Is GetType(InterviewerRegion) Then
                objParent = objParentNode.Tag
                Exit Do
            End If
            If objParentNode.Parent Is Nothing Then Exit Do
            objParentNode = objParentNode.Parent
        Loop

        If objParent IsNot Nothing AndAlso
           objParent.GetType Is GetType(InterviewerRegion) Then
            frm = New frmSupervisor(objSupervisor, CType(objParent, InterviewerRegion))
        Else
            frm = New frmSupervisor(objSupervisor)
        End If

        frm.ShowDialog()
        If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then
            ucNavigate.Refresh()
        End If
        frm.Dispose()
    End Sub

    Private Sub UpdateTeam(ByVal objTeam As InterviewerTeam)

        Dim blnNew As Boolean = (objTeam.TeamID.IsNull)
        Dim frm As frmTeam

        'get the Team's Supervisor
        Dim objParent As Object = Nothing
        Dim objParentNode As TreeNode = ucNavigate.SelectedNode
        Do
            If objParentNode.Tag IsNot Nothing AndAlso
               objParentNode.Tag.GetType Is GetType(InterviewerSupervisor) Then
                objParent = objParentNode.Tag
                Exit Do
            End If
            If objParentNode.Parent Is Nothing Then Exit Do
            objParentNode = objParentNode.Parent
        Loop

        If objParent IsNot Nothing AndAlso
           objParent.GetType Is GetType(InterviewerSupervisor) Then
            frm = New frmTeam(objTeam, CType(objParent, InterviewerSupervisor))
        Else
            frm = New frmTeam(objTeam)
        End If

        frm.ShowDialog()
        If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then
            ucNavigate.Refresh()
        End If
        frm.Dispose()
    End Sub

    Private Sub UpdateInterviewer(ByVal objInterviewer As Interviewer)

        Dim blnNew As Boolean = (objInterviewer.InterviewerID.IsNull)
        Dim frm As frmInterviewer

        'get the Interviewer's Team (or Supervisor)
        Dim objParent As Object = Nothing
        Dim objParentNode As TreeNode = ucNavigate.SelectedNode
        Do
            If objParentNode.Tag IsNot Nothing AndAlso
               (objParentNode.Tag.GetType Is GetType(InterviewerSupervisor) OrElse
                objParentNode.Tag.GetType Is GetType(InterviewerTeam)) Then
                objParent = objParentNode.Tag
                Exit Do
            End If
            If objParentNode.Parent Is Nothing Then Exit Do
            objParentNode = objParentNode.Parent
        Loop

        If objParent IsNot Nothing AndAlso
           objParent.GetType Is GetType(InterviewerSupervisor) Then
            frm = New frmInterviewer(objInterviewer, CType(objParent, InterviewerSupervisor))
        ElseIf objParent IsNot Nothing AndAlso
               objParent.GetType Is GetType(InterviewerTeam) Then
            frm = New frmInterviewer(objInterviewer, CType(objParent, InterviewerTeam))
        Else
            frm = New frmInterviewer(objInterviewer)
        End If

        frm.ShowDialog()
        If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then
            'If blnNew Then
            ucNavigate.Refresh()
            'Else
            '    ucNavigate.SelectedNode.Text = objInterviewer.NodeText
            'End If
        End If
        frm.Dispose()
    End Sub

    Private Sub SetViewType()

        mnuViewCasesAll.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewAll)
        mnuViewCasesAssigned.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewAssigned)
        mnuViewCasesUnassigned.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewUnassigned)
        mnuViewCasesActive.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewActive)
        mnuViewCasesCompleted.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewCompleted)
        mnuViewCasesValidation.Checked = (CaseViewType = CaseAssignments.CaseAssignmentType.ViewValidation)

        ucCaseAssignments.CaseViewType = CaseViewType
        If ucNavigate.SelectedNode IsNot Nothing Then
            ucCaseAssignments.GetAssignments(ucNavigate.SelectedNode.Tag)
            CaseCount.Text = CStr(ucCaseAssignments.CaseAssignments.Count) & " Case(s)"
        End If
    End Sub

    Private Sub AssignCases(ByVal objCaseAssignments As CaseAssignments)

        Dim tn As TreeNode = ucNavigate.SelectedNode

        Dim frm As frmAssignCase
        frm = New frmAssignCase(objCaseAssignments, mblnAdmin)
        frm.ShowDialog()

        If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then

            If Project.ShowInterviewerCaseCount Then
                Dim origInterviewer as Interviewer = frm.SelectedInterviewer
                If origInterviewer IsNot Nothing then 
                    Dim origNode as TreeNode = ucNavigate.FindNode(((origInterviewer.FirstName + " " + origInterviewer.LastName).ToString()))
                    If origNode IsNot Nothing andalso origNode.Tag.GetType Is GetType(Interviewer) Then
                        origInterviewer.RefreshAssignment(CaseAssignments.CaseAssignmentType.ViewActive)
                        ucNavigate.UpdateNode(origNode, origInterviewer)
                    End If
                End If    

                If tn.Tag.GetType Is GetType(Interviewer) Then
                    'need to refresh interviewer's case count
                    Dim targetInterviewer as Interviewer = CType( tn.Tag, Interviewer)
                    targetInterviewer.RefreshAssignment(CaseAssignments.CaseAssignmentType.ViewActive)
                    ucNavigate.UpdateNode(tn, targetInterviewer)
                    ucCaseAssignments.Refresh()
                End If

               
            End If

            ucNavigate.SelectedNode = tn
            ucCaseAssignments.Refresh()
        End If
        frm.Dispose()
    End Sub

    Private Sub CaseProperties(ByVal objCase As [Case])

        Dim objPerson As Person
        If objCase.PrimarySampleMember IsNot Nothing Then
            objPerson = objCase.PrimarySampleMember
        Else
            objPerson = objCase.Persons(0)
        End If

        Dim frm As frmCaseProperties
        frm = New frmCaseProperties(objCase, objPerson, False)
        frm.ShowDialog()
    End Sub

    Private Sub TrackInterviewer(ByVal objInterviewer As Interviewer)

        Dim frm As frmInterviewerTracking
        frm = New frmInterviewerTracking(objInterviewer)
        frm.ShowDialog()
    End Sub

#End Region

#Region "Printing"

    Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt"(ByVal hdcDest As IntPtr, ByVal nXDest As Integer,
                                                                   ByVal nYDest As Integer, ByVal nWidth As Integer,
                                                                   ByVal nHeight As Integer, ByVal hdcSrc As IntPtr,
                                                                   ByVal nXSrc As Integer, ByVal nYSrc As Integer,
                                                                   ByVal dwRop As System.Int32) As Long
    Dim memoryImage As Drawing.Bitmap

    Private Sub CaptureScreen()
        Dim mygraphics As Drawing.Graphics = Me.CreateGraphics()
        Dim s As Drawing.Size = Me.Size
        memoryImage = New Drawing.Bitmap(s.Width, s.Height, mygraphics)
        Dim memoryGraphics As Drawing.Graphics = Drawing.Graphics.FromImage(memoryImage)
        Dim dc1 As IntPtr = mygraphics.GetHdc
        Dim dc2 As IntPtr = memoryGraphics.GetHdc
        BitBlt(dc2, 0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height, dc1, 0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object,
                                         ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
        Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Private Sub FilePrintCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles FilePrintCase.Click
        CaptureScreen()
        PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.ShowDialog()
    End Sub

#End Region
End Class