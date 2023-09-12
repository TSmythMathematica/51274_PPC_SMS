Imports MPR.SMS.Data

Public Class ucCaseTracking

#Region "Private Variables"

    Private mobjCaseTrackings As InterviewerCaseTrackings
    Private mobjSupervisor As InterviewerSupervisor
    Private mobjSelectedTracking As InterviewerCaseTracking

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Public Properties"

    Public Property InterviewerCaseTrackings() As InterviewerCaseTrackings
        Get
            Return mobjCaseTrackings
        End Get
        Set(ByVal value As InterviewerCaseTrackings)
            mobjCaseTrackings = value
            RefreshView()
        End Set
    End Property

    Public Property CurrentSupervisor() As InterviewerSupervisor
        Get
            Return mobjSupervisor
        End Get
        Set(ByVal value As InterviewerSupervisor)
            mobjSupervisor = value
            If Not Me.DesignMode Then
                FillInterviewers(mobjSupervisor)
            End If
        End Set
    End Property

    Private Property SelectedInterviewerID() As SqlTypes.SqlInt32
        Get
            If cboInterviewers.SelectedIndex = - 1 Then
                Return - 1
            Else
                Return CType(cboInterviewers.Items(cboInterviewers.SelectedIndex), Interviewer).InterviewerID
            End If
        End Get
        Set(ByVal value As SqlTypes.SqlInt32)
            If value <= 0 Then
                cboInterviewers.SelectedIndex = 0
            Else
                Dim i As Integer = 0
                For Each objInterviewer As Interviewer In cboInterviewers.Items
                    If GetSafeValue(objInterviewer.InterviewerID) = GetSafeValue(value) Then
                        cboInterviewers.SelectedIndex = i
                        Exit For
                    End If
                    i += 1
                Next
            End If
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub RefreshView()

        If mobjCaseTrackings Is Nothing Then
            lvCaseTrackings.Items.Clear()
            Return
        End If

        Cursor = Cursors.WaitCursor
        lvCaseTrackings.Items.Clear()
        lvCaseTrackings.EmptyMessage = "Retrieving records, please wait..."
        lvCaseTrackings.Refresh()


        'add each CaseAssignment to the list
        For Each objTrack As InterviewerCaseTracking In InterviewerCaseTrackings

            Dim lvi As ListViewItem = lvCaseTrackings.Items.Add(GetSafeDate(objTrack.DateReported))

            lvi.Tag = objTrack

            lvi.SubItems.Add(New FMStatus(objTrack.ReportedStatus.ToString()).DisplayName)
            lvi.SubItems.Add(GetSafeValue(objTrack.Notes))

        Next

        lvCaseTrackings.ColumnSorter.SortColumn = 0
        lvCaseTrackings.ColumnSorter.Order = SortOrder.Descending

        lvCaseTrackings.EmptyMessage = "There are no tracking records for this case."

        ClearForm()

        Cursor = Cursors.Default
    End Sub

    Private Sub ClearForm()

        txtDateReported.Text = GetSafeDate(Now())
        cboReportedStatus.SelectedStatus = Nothing

        txtNotes.Text = String.Empty
        cbRemark1.Checked = False
        cbRemark2.Checked = False
        cbRemark3.Checked = False
        cbRemark4.Checked = False
        cbRemark5.Checked = False
        cbRemark6.Checked = False
        cbRemark7.Checked = False
        cbRemark8.Checked = False
        cbRemark9.Checked = False
        cbRemark10.Checked = False

        SelectedInterviewerID = 0

        btnSave.Text = "Add"
        btnCancel.Enabled = True

        txtDateReported.Focus()
    End Sub

    Private Sub FillForm(ByVal objCaseTracking As InterviewerCaseTracking)

        txtDateReported.Text = GetSafeDate(objCaseTracking.DateReported)
        cboReportedStatus.SelectedStatus = New FMStatus(GetSafeValue(objCaseTracking.ReportedStatus))

        txtNotes.Text = GetSafeValue(objCaseTracking.Notes)
        cbRemark1.Checked = GetSafeValue(objCaseTracking.Remark1)
        cbRemark2.Checked = GetSafeValue(objCaseTracking.Remark2)
        cbRemark3.Checked = GetSafeValue(objCaseTracking.Remark3)
        cbRemark4.Checked = GetSafeValue(objCaseTracking.Remark4)
        cbRemark5.Checked = GetSafeValue(objCaseTracking.Remark5)
        cbRemark6.Checked = GetSafeValue(objCaseTracking.Remark6)
        cbRemark7.Checked = GetSafeValue(objCaseTracking.Remark7)
        cbRemark8.Checked = GetSafeValue(objCaseTracking.Remark8)
        cbRemark9.Checked = GetSafeValue(objCaseTracking.Remark9)
        cbRemark10.Checked = GetSafeValue(objCaseTracking.Remark10)

        SelectedInterviewerID = objCaseTracking.InterviewerID

        btnSave.Text = "Update"
        btnCancel.Enabled = True
    End Sub

    Private Sub FillInterviewers(ByVal objSupervisor As InterviewerSupervisor)

        With cboInterviewers
            .Items.Clear()
            .DisplayMember = "FullName"
            .ValueMember = "InterviewerID"

            Dim objInt As New Interviewer
            objInt.FirstName = "<no interviewer selected>"
            .Items.Add(objInt)

            'if the project admin, fill in all interviewers
            If objSupervisor Is Nothing OrElse objSupervisor.InterviewerSupervisorID.IsNull Then

                Dim objInterviewers As New Interviewers()
                For Each objInterviewer As Interviewer In objInterviewers
                    .Items.Add(objInterviewer)
                Next


            Else 'fill in the current supervisor's interviewers

                'get all interviewers linked directly to the supervisor
                Dim objInterviewers As Interviewers = objSupervisor.Interviewers
                For Each objInterviewer As Interviewer In objInterviewers
                    If objInterviewer.IsActive Then
                        .Items.Add(objInterviewer)
                    End If
                Next

                'get all interviewers linked to the teams for this supervisor
                Dim objTeams As InterviewerTeams = objSupervisor.InterviewerTeams
                For Each objTeam As InterviewerTeam In objTeams
                    For Each objInterviewer As Interviewer In objTeam.Interviewers
                        If objInterviewer.IsActive AndAlso
                           objInterviewers.IndexOf(GetSafeValue(objInterviewer.InterviewerID)) = - 1 Then
                            .Items.Add(objInterviewer)
                        End If
                    Next
                Next

            End If

        End With
    End Sub

    Private Function ValidateForm() As Boolean

        'If GetSafeValue(SelectedInterviewerID) <= 0 Then
        '    MessageBox.Show("An interviewer must be selected.", "Interviewer Case Tracking", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        If txtDateReported.Text.Trim().Length = 0 Then
            MessageBox.Show("Date Reported is required.", "Interviewer Case Tracking", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return False
        ElseIf Not IsDate(txtDateReported.Text) Then
            MessageBox.Show("Date Reported is not valid.", "Interviewer Case Tracking", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

#End Region

#Region "Events"

    Public Shadows Event OnChanged(ByVal sender As Object, ByVal objInterviewerCaseTrackings As InterviewerCaseTrackings)

#End Region

#Region "Event Handlers"

    Private Sub ucCaseTracking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.DesignMode Then
            cboReportedStatus.Filters = "WHERE IsActive = 1"
        End If
    End Sub

    Private Sub lvCaseTrackings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles lvCaseTrackings.DoubleClick

        If lvCaseTrackings.SelectedItems.Count = 1 Then
            mobjSelectedTracking = CType(lvCaseTrackings.SelectedItems(0).Tag, InterviewerCaseTracking)

            FillForm(mobjSelectedTracking)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        ClearForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Not ValidateForm() Then Return

        Dim blnAdd As Boolean = btnSave.Text.Equals("Add")
        If blnAdd Then
            mobjSelectedTracking = New InterviewerCaseTracking
        End If

        With mobjSelectedTracking
            .DateReported = CDate(txtDateReported.Text.Trim())

            If cboReportedStatus.SelectedStatus IsNot Nothing Then
                .ReportedStatus = cboReportedStatus.SelectedStatus.Code
            Else
                .ReportedStatus = String.Empty
            End If
            .Notes = txtNotes.Text
            .Remark1 = cbRemark1.Checked
            .Remark2 = cbRemark2.Checked
            .Remark3 = cbRemark3.Checked
            .Remark4 = cbRemark4.Checked
            .Remark5 = cbRemark5.Checked
            .Remark6 = cbRemark6.Checked
            .Remark7 = cbRemark7.Checked
            .Remark8 = cbRemark8.Checked
            .Remark9 = cbRemark9.Checked
            .Remark10 = cbRemark10.Checked
            '.InterviewerID = SelectedInterviewerID
            .InterviewerID = 206 ' interviewer id is required. Fake one
        End With

        'insert or update the record within the collection
        InterviewerCaseTrackings.ModifyObjectInCollection(mobjSelectedTracking)

        RefreshView()

        RaiseEvent OnChanged(Me, InterviewerCaseTrackings)
    End Sub

#End Region
End Class
