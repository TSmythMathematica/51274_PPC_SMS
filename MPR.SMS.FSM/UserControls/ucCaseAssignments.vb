Imports MPR.SMS.Data
Imports MPR.SMS.Security

Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization

Public Class ucCaseAssignments

#Region "Private Fields"

    Private mobjCaseAssignments As CaseAssignments
    Private mintCaseViewType As Data.CaseAssignments.CaseAssignmentType
    Private mblnAllowFiltering As Boolean = True

#End Region

#Region "Public Properties"

    Public Property CaseAssignments() As CaseAssignments
        Get
            Return mobjCaseAssignments
        End Get
        Set(ByVal value As CaseAssignments)
            mobjCaseAssignments = value
            RefreshView()
        End Set
    End Property

    Public Property CaseViewType() As Data.CaseAssignments.CaseAssignmentType
        Get
            Return mintCaseViewType
        End Get
        Set(ByVal Value As Data.CaseAssignments.CaseAssignmentType)
            mintCaseViewType = Value

            ctxViewActiveCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewActive)
            ctxViewAllCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewAll)
            ctxViewAssignedCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewAssigned)
            ctxViewCompletedCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewCompleted)
            ctxViewUnassignedCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewUnassigned)
            ctxViewValidationCases.Checked = (mintCaseViewType = Data.CaseAssignments.CaseAssignmentType.ViewValidation)
        End Set
    End Property

    Public ReadOnly Property SelectedCaseAssignments() As CaseAssignments
        Get
            If lvCaseAssignments.SelectedItems.Count > 0 AndAlso
               lvCaseAssignments.SelectedItems(0).Tag IsNot Nothing Then

                Dim objCaseAssignments As New CaseAssignments()

                If Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.SelectedCases Then

                    For Each obj As ListViewItem In lvCaseAssignments.SelectedItems
                        objCaseAssignments.Add(CType(obj.Tag, CaseAssignment))
                    Next
                Else
                    'Get the selected assignment's education entities
                    Dim objSelectedAssigment As CaseAssignment = CType(lvCaseAssignments.SelectedItems(0).Tag,
                                                                       CaseAssignment)
                    Dim objSelStudent As Student = Nothing
                    Dim objSelClass As Classroom = Nothing
                    Dim objSelSchool As School = Nothing
                    Dim objSelDistrict As District = Nothing

                    GetEntities(objSelectedAssigment, objSelStudent, objSelClass, objSelSchool, objSelDistrict)

                    'loop through the selected node's assignments...
                    For Each objAssigment As CaseAssignment In CaseAssignments

                        '...get the education entities for each assignment...
                        Dim objStudent As Student = Nothing
                        Dim objClass As Classroom = Nothing
                        Dim objSchool As School = Nothing
                        Dim objDistrict As District = Nothing
                        GetEntities(objAssigment, objStudent, objClass, objSchool, objDistrict)

                        '...and compare the selected assignment.
                        Dim blnOK As Boolean = False
                        If Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.Classroom Then
                            blnOK =
                                CBool(
                                    (objSelClass IsNot Nothing AndAlso objClass IsNot Nothing AndAlso
                                     objSelClass.ClassroomID = objClass.ClassroomID))
                        ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.School Then
                            blnOK =
                                CBool(
                                    (objSelSchool IsNot Nothing AndAlso objSchool IsNot Nothing AndAlso
                                     objSelSchool.SchoolID = objSchool.SchoolID))
                        ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.District Then
                            blnOK =
                                CBool(
                                    (objSelDistrict IsNot Nothing AndAlso objDistrict IsNot Nothing AndAlso
                                     objSelDistrict.DistrictID = objDistrict.DistrictID))
                        ElseIf Project.FieldAssignmentAssignBy = Data.Project.FieldAssignmentAssignByType.Custom Then
                            'insert your custom logic here. use the above as examples. 
                        End If

                        'if a match, then add it to the collection
                        If blnOK Then
                            objCaseAssignments.Add(objAssigment)
                        End If
                    Next

                End If

                Return objCaseAssignments
            Else
                Return Nothing
            End If
        End Get
    End Property

    <System.ComponentModel.DefaultValue(True)>
    Public Property AllowFiltering() As Boolean
        Get
            Return mblnAllowFiltering
        End Get
        Set(ByVal value As Boolean)
            mblnAllowFiltering = value
        End Set
    End Property

#End Region

#Region "Events"

    Public Event OnViewChanged(ByVal sender As Object, ByVal CaseViewType As Data.CaseAssignments.CaseAssignmentType)
    Public Event OnCaseSelected(ByVal sender As Object, ByVal objCase As [Case])
    Public Event OnCaseProperties(ByVal sender As Object, ByVal objCase As [Case])
    Public Event OnAssignCases(ByVal sender As Object, ByVal objCaseAssignments As CaseAssignments)
    Public Event OnBeginDrag(ByVal sender As Object, ByVal objCaseAssignments As CaseAssignments)

#End Region

#Region "Event Handlers"

    Private Sub ctxCaseProperties_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) _
        Handles ctxCaseProperties.Paint

        ctxViewAllCases.Enabled = AllowFiltering
        ctxViewAssignedCases.Enabled = AllowFiltering
        ctxViewUnassignedCases.Enabled = AllowFiltering
        ctxViewActiveCases.Enabled = AllowFiltering
        ctxViewCompletedCases.Enabled = AllowFiltering
        ctxViewValidationCases.Enabled = AllowFiltering
    End Sub

    Private Sub ctxCaseProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxCaseProperties.Click

        Dim objSelected As CaseAssignments = SelectedCaseAssignments
        If objSelected IsNot Nothing AndAlso objSelected.Count = 1 Then

            Dim objCase As [Case] = objSelected(0).Case

            RaiseEvent OnCaseProperties(Me, objCase)
        End If
    End Sub

    Private Sub lvCaseAssignments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles lvCaseAssignments.DoubleClick

        Dim objSelected As CaseAssignments = SelectedCaseAssignments
        If objSelected IsNot Nothing AndAlso objSelected.Count = 1 Then

            Dim objCase As [Case] = objSelected(0).Case

            RaiseEvent OnCaseProperties(Me, objCase)
        End If
    End Sub

    Private Sub lvCaseAssignments_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles lvCaseAssignments.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            lvCaseAssignments_DoubleClick(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub lvCaseAssignments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles lvCaseAssignments.SelectedIndexChanged

        Dim objSelected As CaseAssignments = SelectedCaseAssignments
        If objSelected IsNot Nothing AndAlso objSelected.Count = 1 Then

            Dim objCase As [Case] = objSelected(0).Case

            RaiseEvent OnCaseSelected(Me, objCase)
        Else
            RaiseEvent OnCaseSelected(Me, Nothing)
        End If
    End Sub

    Private Sub ctxAssignCase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxAssignCase.Click

        Dim objSelected As CaseAssignments = SelectedCaseAssignments

        If objSelected.Count > 0 Then
            RaiseEvent OnAssignCases(Me, objSelected)
        End If
    End Sub

    Private Sub ctxViewActiveCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewActiveCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewActive)
    End Sub

    Private Sub ctxViewAllCases_Clicki(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewAllCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewAll)
    End Sub

    Private Sub ctxViewAssignedCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewAssignedCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewAssigned)
    End Sub

    Private Sub ctxViewCompletedCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewCompletedCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewCompleted)
    End Sub


    Private Sub ctxViewUnassignedCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewUnassignedCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewUnassigned)
    End Sub

    Private Sub ctxViewValidationCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxViewValidationCases.Click

        RaiseEvent OnViewChanged(Me, Data.CaseAssignments.CaseAssignmentType.ViewValidation)
    End Sub

    Private Sub lvCaseAssignments_ItemDrag(ByVal sender As System.Object,
                                           ByVal e As System.Windows.Forms.ItemDragEventArgs) _
        Handles lvCaseAssignments.ItemDrag

        If Not CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment) Then
            Return
        End If

        Dim objSelected As CaseAssignments = SelectedCaseAssignments

        If objSelected.Count > 0 Then
            RaiseEvent OnBeginDrag(Me, objSelected)

            If Project.CaseAssignmentsAllowCopy Then
                DoDragDrop(e.Item, DragDropEffects.Copy)
            Else
                DoDragDrop(e.Item, DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub ctxCaseAssignments_Popup(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxCaseAssignments.Opened

        Dim count As Integer = lvCaseAssignments.SelectedItems.Count

        ctxCaseProperties.Enabled = (count = 1)
        ctxAssignCase.Enabled = (count >= 1) AndAlso
                                CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)

        If count > 1 Then
            ctxAssignCase.Text = "A&ssign Cases..."
        Else
            ctxAssignCase.Text = "A&ssign Case..."
        End If
    End Sub

    Private Sub ucCaseAssignments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Project IsNot Nothing Then
            Me.lvCaseAssignments.MultiSelect = (Project.FieldAssignmentAssignBy = 0)
        End If
    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        MyBase.Refresh()
        Me.RefreshView()
    End Sub

    Public Sub GetAssignments(ByVal obj As Object)

        If obj Is Nothing Then
            CaseAssignments = Nothing
            Exit Sub
        End If

        If obj.GetType Is GetType(Interviewer) Then
            CaseAssignments = New CaseAssignments(CType(obj, Interviewer), CaseViewType)
        ElseIf obj.GetType Is GetType(InterviewerSupervisor) Then
            CaseAssignments = New CaseAssignments(CType(obj, InterviewerSupervisor), CaseViewType)
        ElseIf obj.GetType Is GetType(InterviewerTeam) Then
            CaseAssignments = New CaseAssignments(CType(obj, InterviewerTeam), CaseViewType)
        ElseIf obj.GetType Is GetType(InterviewerRegion) Then
            CaseAssignments = New CaseAssignments(CType(obj, InterviewerRegion), CaseViewType)
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub RefreshView()

        If mobjCaseAssignments Is Nothing Then
            lvCaseAssignments.Items.Clear()
            Return
        End If

        Cursor = Cursors.WaitCursor
        lvCaseAssignments.Items.Clear()
        lvCaseAssignments.EmptyMessage = "Retrieving case assignments, please wait..."
        lvCaseAssignments.Refresh()

        If AllowFiltering Then
            Select Case CaseViewType
                Case Data.CaseAssignments.CaseAssignmentType.ViewActive
                    MyCaption.Text = "Case Assignments - Active"
                Case Data.CaseAssignments.CaseAssignmentType.ViewAll
                    MyCaption.Text = "Case Assignments - All"
                Case Data.CaseAssignments.CaseAssignmentType.ViewAssigned
                    MyCaption.Text = "Case Assignments - Assigned"
                Case Data.CaseAssignments.CaseAssignmentType.ViewCompleted
                    MyCaption.Text = "Case Assignments - Completed"
                Case Data.CaseAssignments.CaseAssignmentType.ViewUnassigned
                    MyCaption.Text = "Case Assignments - Unassigned"
                Case Data.CaseAssignments.CaseAssignmentType.ViewValidation
                    MyCaption.Text = "Case Assignments - Validation"

            End Select
        Else
            MyCaption.Text = "Case Assignments - Search Results"
        End If

        'add each CaseAssignment to the list
        For Each objCaseAssignment As CaseAssignment In CaseAssignments

            With objCaseAssignment.CaseAssignmentSearch
                Dim lvi As ListViewItem = lvCaseAssignments.Items.Add(GetSafeValue(.MPRID))
                lvi.Tag = objCaseAssignment
                lvi.SubItems.Add(GetSafeValue(.CaseID).ToString)
                lvi.SubItems.Add(GetSafeValue(.MoreFieldAttempts).ToString())
                lvi.SubItems.Add(GetSafeValue(.PriorityStatus).ToString())


                ' DateTime - Datatype in DB
                If .LastAttemptDate.IsNull() Then
                    lvi.SubItems.Add("")
                Else
                    lvi.SubItems.Add(GetSafeValue(.LastAttemptDate).ToString("d")) ' Locating status date
                End If

                lvi.SubItems.Add(GetSafeValue(.LACity))
                lvi.SubItems.Add(GetSafeValue(.FirstName))
                lvi.SubItems.Add(GetSafeValue(.LastName))

                lvi.SubItems.Add(GetSafeValue(.Address1))
                lvi.SubItems.Add(GetSafeValue(.City))
                lvi.SubItems.Add(GetSafeValue(.State))
                lvi.SubItems.Add(GetSafeValue(.Postalcode))


                lvi.SubItems.Add(GetSafeValue(.CurrentStatus))
                lvi.SubItems.Add(GetSafeValue(.Locatingstatus))


                If .LastReleasedOn.IsNull() Then
                    lvi.SubItems.Add("")
                Else
                    lvi.SubItems.Add(GetSafeValue(.LastReleasedOn).ToString("MM/dd/yyyy"))
                End If


                lvi.SubItems.Add(GetSafeValue(.Languagedesc))
                lvi.SubItems.Add(GetSafeValue(.Gender))
                lvi.SubItems.Add(GetSafeValue(.Age).ToString())


                lvi.SubItems.Add(GetSafeValue(.InterviewerName))


            End With

        Next

        'Auto resize all visibile list view columns
        For Each ch As ColumnHeader In lvCaseAssignments.Columns()
            If ch.Width <> 0 Then ch.Width = - 2
        Next
        lvCaseAssignments.ColumnSorter.SortColumn = 0
        lvCaseAssignments.ColumnSorter.Order = SortOrder.Ascending

        lvCaseAssignments.EmptyMessage = "There are no case assignments that meet your criteria."
        Cursor = Cursors.Default
    End Sub

    'retrieve the Education Entities (Student, Class, School, District) from a given Case Assignment
    Private Sub GetEntities(ByVal objAssigment As CaseAssignment, ByRef objStudent As Student,
                            ByRef objClassroom As Classroom, ByRef objSchool As School, ByRef objDistrict As District)

        objStudent = Nothing
        objClassroom = Nothing
        objSchool = Nothing
        objDistrict = Nothing

        If objAssigment.Case.PrimarySampleMember IsNot Nothing AndAlso
           objAssigment.Case.PrimarySampleMember.Student IsNot Nothing Then
            objStudent = objAssigment.Case.PrimarySampleMember.Student

            If objStudent IsNot Nothing Then
                objClassroom = objStudent.Classroom

                If objClassroom IsNot Nothing Then
                    objSchool = objClassroom.School

                    If objSchool IsNot Nothing Then
                        objDistrict = objSchool.District
                    End If
                End If
            End If
        End If
    End Sub

#End Region
End Class
