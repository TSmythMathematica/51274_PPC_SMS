Imports MPR.SMS.Data

Public Class frmAssignCase

#Region "Private Variables"

    Private mobjCaseAssignments As CaseAssignments = Nothing
    Private mobjInterviewer As Interviewer = Nothing
    Private mobjTeam As InterviewerTeam = Nothing
    Private mobjSupervisor As InterviewerSupervisor = Nothing
    Private mobjRegion As InterviewerRegion = Nothing

#End Region

#Region "Public Properties"

    Public Property SelectedRegion() As InterviewerRegion
        Get
            If cboRegions.SelectedIndex > 0 Then
                Return CType(cboRegions.SelectedItem, InterviewerRegion)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As InterviewerRegion)
            If value Is Nothing Then
                cboRegions.SelectedIndex = 0
            Else
                Dim i As Integer = 0
                For Each obj As InterviewerRegion In cboRegions.Items
                    If obj.InterviewerRegionID = value.InterviewerRegionID Then
                        cboRegions.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property SelectedSupervisor() As InterviewerSupervisor
        Get
            If cboSupervisors.SelectedIndex > 0 Then
                Return CType(cboSupervisors.SelectedItem, InterviewerSupervisor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As InterviewerSupervisor)
            If value Is Nothing Then
                cboSupervisors.SelectedIndex = 0
            Else
                Dim i As Integer = 0
                For Each obj As InterviewerSupervisor In cboSupervisors.Items
                    If obj.InterviewerSupervisorID = value.InterviewerSupervisorID Then
                        cboSupervisors.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property SelectedTeam() As InterviewerTeam
        Get
            If cboTeams.SelectedIndex > 0 Then
                Return CType(cboTeams.SelectedItem, InterviewerTeam)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As InterviewerTeam)
            If value Is Nothing Then
                cboTeams.SelectedIndex = 0
            Else
                Dim i As Integer = 0
                For Each obj As InterviewerTeam In cboTeams.Items
                    If obj.TeamID = value.TeamID Then
                        cboTeams.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property SelectedInterviewer() As Interviewer
        Get
            If cboInterviewers.SelectedIndex > 0 Then
                Return CType(cboInterviewers.SelectedItem, Interviewer)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Interviewer)
            If value Is Nothing Then
                cboInterviewers.SelectedIndex = 0
            Else
                Dim i As Integer = 0
                For Each obj As Interviewer In cboInterviewers.Items
                    If obj.InterviewerID = value.InterviewerID Then
                        cboInterviewers.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal objCaseAssignments As CaseAssignments, ByVal blnAdmin As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCaseAssignments = objCaseAssignments

        FillForm(blnAdmin, Nothing)
    End Sub

    Public Sub New(ByVal objCaseAssignments As CaseAssignments, ByVal blnAdmin As Boolean, ByVal objTarget As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCaseAssignments = objCaseAssignments

        FillForm(blnAdmin, objTarget)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillForm(ByVal blnAdmin As Boolean, ByVal objTarget As Object)

        Dim objCaseAssignment As CaseAssignment = mobjCaseAssignments(0)
        If Not Me.DesignMode Then
            FillCaseList()

            lblTeam.Visible = Project.ProjectUsesInterviewTeams
            cboTeams.Visible = Project.ProjectUsesInterviewTeams

            mobjRegion = Nothing
            mobjSupervisor = Nothing
            mobjTeam = Nothing
            mobjInterviewer = Nothing

            'If a target is specified, use it to default the combobox selections
            If objTarget IsNot Nothing Then

                If objTarget.GetType Is GetType(InterviewerRegion) Then
                    mobjRegion = CType(objTarget, InterviewerRegion)
                ElseIf objTarget.GetType Is GetType(InterviewerSupervisor) Then
                    mobjSupervisor = CType(objTarget, InterviewerSupervisor)
                    mobjRegion = mobjSupervisor.InterviewerRegion
                ElseIf objTarget.GetType Is GetType(InterviewerTeam) Then
                    mobjTeam = CType(objTarget, InterviewerTeam)
                    mobjSupervisor = mobjTeam.InterviewerSupervisor
                    If mobjSupervisor IsNot Nothing Then mobjRegion = mobjSupervisor.InterviewerRegion
                ElseIf objTarget.GetType Is GetType(Interviewer) Then
                    mobjInterviewer = CType(objTarget, Interviewer)
                    mobjTeam = mobjInterviewer.InterviewerTeam
                    If mobjTeam IsNot Nothing Then mobjSupervisor = mobjTeam.InterviewerSupervisor
                    If mobjSupervisor Is Nothing Then mobjSupervisor = mobjInterviewer.InterviewerSupervisor
                    If mobjSupervisor IsNot Nothing Then mobjRegion = mobjSupervisor.InterviewerRegion
                End If

            Else 'otherwise, use the current assignment as the default selections

                If Not objCaseAssignment.InterviewerID.IsNull Then
                    mobjInterviewer = New Interviewer(GetSafeValue(objCaseAssignment.InterviewerID))
                    mobjTeam = mobjInterviewer.InterviewerTeam
                    If mobjTeam IsNot Nothing AndAlso mobjTeam.InterviewerSupervisor IsNot Nothing Then
                        mobjSupervisor = mobjTeam.InterviewerSupervisor
                    Else
                        mobjSupervisor = mobjInterviewer.InterviewerSupervisor
                    End If
                    If mobjSupervisor IsNot Nothing Then mobjRegion = mobjSupervisor.InterviewerRegion
                ElseIf Not objCaseAssignment.InterviewerTeamID.IsNull Then
                    mobjTeam = New InterviewerTeam(GetSafeValue(objCaseAssignment.InterviewerTeamID))
                    mobjSupervisor = mobjTeam.InterviewerSupervisor
                    If mobjSupervisor IsNot Nothing Then mobjRegion = mobjSupervisor.InterviewerRegion
                ElseIf Not objCaseAssignment.InterviewerSupervisorID.IsNull Then
                    mobjSupervisor = New InterviewerSupervisor(GetSafeValue(objCaseAssignment.InterviewerSupervisorID))
                    mobjRegion = mobjSupervisor.InterviewerRegion
                ElseIf Not objCaseAssignment.InterviewerRegionID.IsNull Then
                    mobjRegion = New InterviewerRegion(GetSafeValue(objCaseAssignment.InterviewerRegionID))
                End If
            End If

            FillRegions(New InterviewerRegions)
            SelectedRegion = mobjRegion

            If mobjRegion IsNot Nothing Then
                FillSupervisors(mobjRegion.InterviewerSupervisors)
            Else
                FillSupervisors(New InterviewerSupervisors)
            End If
            SelectedSupervisor = mobjSupervisor

            If mobjSupervisor IsNot Nothing Then
                FillTeams(mobjSupervisor.InterviewerTeams)
            Else
                FillTeams(New InterviewerTeams)
            End If
            SelectedTeam = mobjTeam

            If mobjTeam IsNot Nothing Then
                FillInterviewers(mobjTeam.Interviewers)
            ElseIf mobjSupervisor IsNot Nothing Then
                FillInterviewers(mobjSupervisor.Interviewers)
            Else
                FillInterviewers(New Interviewers)
            End If
            SelectedInterviewer = mobjInterviewer

            If Not blnAdmin Then
                cboRegions.Enabled = False
                cboRegions.BackColor = Drawing.Color.Silver

                cboSupervisors.Enabled = False
                cboSupervisors.BackColor = Drawing.Color.Silver
            End If

            cboTeams.Visible = Project.ProjectUsesInterviewTeams
            lblTeam.Visible = Project.ProjectUsesInterviewTeams

            If mobjCaseAssignments.Count > 1 Then
                Me.Text = "Change Case Assignments"
                If Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.Classroom Then
                    Me.Text += " by Classroom"
                ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.School Then
                    Me.Text += " by School"
                ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.District Then
                    Me.Text += " by District"
                ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.Custom Then
                    'change as needed
                    'Me.Text += " by Custom"
                End If
            Else
                Me.Text = "Change Case Assignment"
            End If
            lblCount.Text = "Count = " & CStr(mobjCaseAssignments.Count)
        End If
    End Sub

    Private Sub FillRegions(ByVal objRegions As InterviewerRegions)

        cboRegions.Items.Clear()
        cboRegions.DisplayMember = "Name"
        cboRegions.ValueMember = "InterviewerRegionID"

        Dim obj As New InterviewerRegion
        obj.Name = "<no region>"
        cboRegions.Items.Add(obj)

        For Each obj In objRegions
            cboRegions.Items.Add(obj)
        Next
    End Sub

    Private Sub FillSupervisors(ByVal objSupervisors As InterviewerSupervisors)

        cboSupervisors.Items.Clear()
        cboSupervisors.DisplayMember = "FullName"
        cboSupervisors.ValueMember = "InterviewerSupervisorID"

        Dim obj As New InterviewerSupervisor
        obj.FirstName = "<no supervisor>"
        cboSupervisors.Items.Add(obj)

        For Each obj In objSupervisors
            cboSupervisors.Items.Add(obj)
        Next
    End Sub

    Private Sub FillTeams(ByVal objTeams As InterviewerTeams)

        cboTeams.Items.Clear()
        cboTeams.DisplayMember = "TeamName"
        cboTeams.ValueMember = "TeamID"

        Dim obj As New InterviewerTeam
        obj.TeamName = "<no team>"
        cboTeams.Items.Add(obj)

        For Each obj In objTeams
            If obj.IsActive Then
                cboTeams.Items.Add(obj)
            End If
        Next
    End Sub

    Private Sub FillInterviewers(ByVal objInterviewers As Interviewers)

        cboInterviewers.Items.Clear()
        cboInterviewers.DisplayMember = "FullName"
        cboInterviewers.ValueMember = "InterviewerID"

        Dim obj As New Interviewer
        obj.FirstName = "<no interviewer>"
        cboInterviewers.Items.Add(obj)

        For Each obj In objInterviewers
            If obj.IsActive Then
                cboInterviewers.Items.Add(obj)
            End If
        Next
    End Sub

    Private Sub FillCaseList()

        If mobjCaseAssignments Is Nothing Then
            lvCaseAssignments.Items.Clear()
            Return
        End If

        Cursor = Cursors.WaitCursor
        lvCaseAssignments.Items.Clear()
        lvCaseAssignments.EmptyMessage = "Retrieving case assignments, please wait..."
        lvCaseAssignments.Refresh()


        'add each CaseAssignment to the list
        For Each objCaseAssignment As CaseAssignment In mobjCaseAssignments

            Dim objInst As Instrument = objCaseAssignment.Case.FieldInstrument
            Dim objSM As Person = objCaseAssignment.Case.PrimarySampleMember

            Dim lvi As ListViewItem = lvCaseAssignments.Items.Add(objCaseAssignment.CaseID.ToString)

            lvi.Tag = objCaseAssignment

            If objInst IsNot Nothing Then
                lvi.SubItems.Add(objCaseAssignment.Case.FieldInstrument.CurrentStatus.ToString)
            Else
                lvi.SubItems.Add("n/a")
            End If

            If objSM IsNot Nothing Then
                lvi.SubItems.Add(objSM.MPRID.ToString)
                lvi.SubItems.Add(objSM.FullName)
                If objSM.BestPhysicalAddress IsNot Nothing Then
                    lvi.SubItems.Add(GetSafeValue(objSM.BestPhysicalAddress.State))
                Else
                    lvi.SubItems.Add(String.Empty)
                End If
            Else
                lvi.SubItems.Add(String.Empty)
                lvi.SubItems.Add(String.Empty)
                lvi.SubItems.Add(String.Empty)
            End If

            'lvi.SubItems.Add(objCaseAssignment.SchoolName)
            lvi.SubItems.Add(objCaseAssignment.Interviewer.FullName)
            If objCaseAssignment.Supervisor IsNot Nothing Then
                lvi.SubItems.Add(objCaseAssignment.Supervisor.FullName)
            Else
                lvi.SubItems.Add(String.Empty)
            End If

            If objInst IsNot Nothing Then
                lvi.SubItems.Add(objCaseAssignment.Case.FieldInstrument.InstrumentType.Description.ToString)
            Else
                lvi.SubItems.Add("n/a")
            End If

            lvi.SubItems.Add(GetSafeDate(objCaseAssignment.LastReleasedOn))

        Next

        'Auto resize list view columns
        For Each ch As ColumnHeader In lvCaseAssignments.Columns()
            ch.Width = - 2
        Next
        lvCaseAssignments.ColumnSorter.SortColumn = 0
        lvCaseAssignments.ColumnSorter.Order = SortOrder.Ascending

        lvCaseAssignments.EmptyMessage = "There are no case assignments that meet your criteria."
        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub cboRegions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboRegions.SelectedIndexChanged

        Dim objRegion As InterviewerRegion = CType(cboRegions.SelectedItem, InterviewerRegion)
        FillSupervisors(objRegion.InterviewerSupervisors)
    End Sub

    Private Sub cboSupervisors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboSupervisors.SelectedIndexChanged

        Dim objSupervisor As InterviewerSupervisor = CType(cboSupervisors.SelectedItem, InterviewerSupervisor)
        FillTeams(objSupervisor.InterviewerTeams)
        FillInterviewers(objSupervisor.Interviewers)
    End Sub

    Private Sub cboTeams_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboTeams.SelectedIndexChanged

        Dim objTeam As InterviewerTeam = CType(cboTeams.SelectedItem, InterviewerTeam)
        FillInterviewers(objTeam.Interviewers)
    End Sub

    Private Sub cboInterviewers_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboInterviewers.SelectedIndexChanged

        Dim objInt As Interviewer = CType(cboInterviewers.SelectedItem, Interviewer)
        txtNote.Enabled = GetSafeValue(objInt.ReturnToSOC)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim blnResult As Boolean = False

        If _
            cboInterviewers.SelectedIndex <= 0 AndAlso cboSupervisors.SelectedIndex <= 0 AndAlso
            cboRegions.SelectedIndex <= 0 Then
            MessageBox.Show("Cases must be assigned to a region, supervisor, and/or interviewer.", "No assignment made",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If SelectedInterviewer IsNot Nothing Then
            If SelectedInterviewer.ReturnToSOC.IsTrue Then
                If txtNote.Text = String.Empty Then
                    MessageBox.Show("Please enter a Note when returning a case to the SOC.", "No Note made",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If mobjCaseAssignments.Count > 1 Then
                    MessageBox.Show("Only one case may be returned to the SOC at a time.", "Cannot move cases",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If mobjCaseAssignments(0).Case.PrimarySampleMember.LocatingStatus.Status.IsCaseInLocatingSupervisor _
                   OrElse mobjCaseAssignments(0).Case.PrimarySampleMember.LocatingStatus.Status.IsFinalStatus _
                   OrElse
                   GetSafeValue(mobjCaseAssignments(0).Case.PrimarySampleMember.LocatingStatus.LocatingStatus) = "1890" _
                    Then
                    MessageBox.Show("The case cannot be moved to this folder based on the current locating status.",
                                    "Invalid assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If

        End If

        For Each objCaseAssignment As CaseAssignment In mobjCaseAssignments
            With objCaseAssignment
                .ResetAssignment()

                If SelectedInterviewer IsNot Nothing Then
                    'if inst/loc status =187x, update to 188x
                    If GetSafeValue(.CaseAssignmentSearch.LocatingStatus).ToString.StartsWith("187") Then
                        Dim newStatus As String = "188" &
                                                  GetSafeValue(.CaseAssignmentSearch.LocatingStatus).ToString.Substring(
                                                      3, 1)

                        SetSafeValue(.Case.PrimarySampleMember.LocatingStatus.LocatingStatus, newStatus)
                        For Each inst As Instrument In .Case.Instruments
                            If inst.InstrumentTypeID = .CaseAssignmentSearch.InstrumentTypeID Then
                                inst.CurrentStatus = newStatus
                                inst.LogicalStatus = newStatus
                            End If
                        Next

                        'add case tracking
                        Dim objTracking As New InterviewerCaseTracking
                        objTracking.CaseID = .CaseAssignmentSearch.CaseID
                        objTracking.InterviewerID = 206
                        objTracking.DateReported = Now
                        objTracking.Notes = ""
                        SetSafeValue(objTracking.ReportedStatus, "1") 'released to field
                        objTracking.Insert()

                        .Case.Lock()
                        .Case.Update()
                        .Case.Unlock()


                    End If

                    'if assign to "Return to in House Locating" folder, update loc status to 1566 "Return to Locating from field"
                    If GetSafeValue(SelectedInterviewer.ReturnToSOC) = True Then
                        Const NewStatus As String = "1566"
                        'SetSafeValue(.Case.PrimarySampleMember.LocatingStatus.LocatingStatus, NewStatus)
                        'SetSafeValue(.Case.PrimarySampleMember.LocatingStatus.Notes, txtNote.Text)
                        For Each inst As Instrument In .Case.Instruments
                            If inst.InstrumentTypeID = .CaseAssignmentSearch.InstrumentTypeID Then
                                inst.CurrentStatus = NewStatus
                                inst.LogicalStatus = NewStatus

                                SetSafeValue(inst.SampleMember.LocatingStatus.LocatingStatus, NewStatus)
                                SetSafeValue(inst.SampleMember.LocatingStatus.Notes, txtNote.Text)
                            End If
                        Next
                        .Case.Lock()
                        .Case.Update()
                        .Case.Unlock()

                    End If

                    .InterviewerID = SelectedInterviewer.InterviewerID
                ElseIf SelectedTeam IsNot Nothing Then
                    .InterviewerTeamID = SelectedTeam.TeamID
                ElseIf SelectedSupervisor IsNot Nothing Then
                    .InterviewerSupervisorID = SelectedSupervisor.InterviewerSupervisorID
                ElseIf SelectedRegion IsNot Nothing Then
                    .InterviewerRegionID = SelectedRegion.InterviewerRegionID
                End If

                If Not .IsModified Then
                    MessageBox.Show("You did not change the assignment. Please select a different Interviewer or Team.",
                                    "No change made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    blnResult = False
                    Exit For
                Else
                    Try
                        .DateAssigned = New SqlTypes.SqlDateTime(Now)
                        blnResult = .Assign()
                    Catch ex As Exception
                        Dim strMsg As String = ex.Message
                        If mobjCaseAssignments.Count > 1 Then
                            strMsg += Environment.NewLine & Environment.NewLine &
                                      "Press OK to continue with the rest of the assignments, or Cancel to stop the assignments."
                            If _
                                MessageBox.Show(strMsg, "Error Updating Case Assignments", MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Cancel _
                                Then
                                blnResult = False
                                Exit For
                            End If
                        Else
                            MessageBox.Show(strMsg, "Error Updating Case Assignment", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                            blnResult = False
                            Exit For
                        End If
                    End Try

                End If
            End With
        Next

        If blnResult Then
            DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            DialogResult = System.Windows.Forms.DialogResult.None
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

#End Region
End Class