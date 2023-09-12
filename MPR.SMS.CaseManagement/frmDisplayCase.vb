'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls

Public Class frmDisplayCase

#Region "Private Variables"

    Private mobjCase As [Case]
    Private mobjSelPerson As Person     'Selected Person
    Private mblnEditable As Boolean = False
    Private mobjCurrentTab As TabPage

#End Region

#Region "Constructors"

    Public Sub New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(intEntityTypeID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjCurrentTab = tabCase.TabPages(0)

        AddCase(CType(intEntityTypeID, Data.Enumerations.tlkpEntityType))
    End Sub

    Public Sub New(objCase As [Case], objPerson As Person, blnReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjCurrentTab = tabCase.TabPages(0)

        If Not blnReadOnly Then LockCase()

        mobjSelPerson = objPerson
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayCase(objCase As [Case], objPerson As Person)

        txtEntityName.Text = GetSafeValue(objCase.EntityName)
        chkInSample.Checked = GetSafeValue(objCase.InSample)
        chkIsIneligible.Checked = GetSafeValue(objCase.IsIneligible)
        txtPSU.Text = GetSafeValue(objCase.PSU)
        txtCaseNotes.Text = GetSafeValue(objCase.CaseNotes)

        ViewCaseMembers.SelectedCase = objCase
        If objPerson IsNot Nothing Then
            ViewCaseMembers.SelectedPerson = objPerson
        Else
            ViewCaseMembers.SelectedPerson = objCase.PrimarySampleMember
        End If

        ViewCaseInstruments.SelectedCase = objCase
        ViewCaseDocuments.SelectedCase = objCase
        ViewCaseNotes.SelectedCase = objCase

        'fill in the Random Assignment control
        EditCaseRA.CaseRA = objCase.CaseRA

        If Not objCase Is Nothing AndAlso
           Not objCase.CaseID.IsNull AndAlso
           Not GetSafeValue(objCase.CaseID).Equals(0) Then
            tsslCaseID.Text = "CaseID: " & objCase.CaseID.ToString
            'tsslStatus.Text = objCase.Status.ToString
            If objCase.IsReadOnly Then
                tsslLocked.Image = imgImages.Images("lock-unavailable.bmp")
                tsslLocked.ToolTipText =
                    "This case is unavailable for editing because it is locked by someone else, or you only have read-only access."
            Else
                tsslLocked.Image = imgImages.Images("lock-owned.bmp")
                tsslLocked.ToolTipText = "This case is locked by you and available for editing."
            End If
            tsbDelete.Enabled = False   'Authorization.IsSupervisor 'not allowed at this time
            mblnEditable = Not objCase.IsReadOnly And
                           CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSCaseManagement)
        Else
            tsslCaseID.Text = "New case"
            tsslStatus.Text = "Untouched"
            tsslLocked.Image = imgImages.Images("lock-none.bmp")
            tsslLocked.ToolTipText = "This case has not been saved yet."
            tsbDelete.Enabled = False
            mblnEditable = True
        End If
        tsslEntity.Text = GetSafeValue(objCase.EntityType.Description)

        'fill in the form title and status bar fields
        Me.Text = "SMS - [ " & Project.ShortName & "] - " & tsslCaseID.Text
        If Not objCase.EntityName.ToString.Length.Equals(0) Then
            Me.Text = Me.Text & " - " & objCase.EntityName.ToString
        End If

        'AF 07/30/13 -moving this to load, otherwise it resizes the screen upon every change / save
        'Me.WindowState = FormWindowState.Maximized

        tsbSave.Enabled = False

        '== enable/disable Add/Edit/Delete functions
        txtEntityName.ReadOnly = Not mblnEditable
        txtPSU.ReadOnly = Not mblnEditable
        txtCaseNotes.ReadOnly = Not mblnEditable
        chkInSample.AutoCheck = False   'mblnEditable
        chkIsIneligible.AutoCheck = False   'mblnEditable

        ViewCaseMembers.AllowAdd = mblnEditable
        ViewCaseMembers.AllowEdit = mblnEditable
        ViewCaseMembers.AllowDelete = False   'Authorization.IsSupervisor 'not allowed at this time

        ViewCaseAddresses.AllowAdd = ViewCaseMembers.AllowAdd
        ViewCaseAddresses.AllowEdit = ViewCaseMembers.AllowEdit
        ViewCaseAddresses.AllowDelete = ViewCaseMembers.AllowDelete

        ViewCasePhones.AllowAdd = ViewCaseMembers.AllowAdd
        ViewCasePhones.AllowEdit = ViewCaseMembers.AllowEdit
        ViewCasePhones.AllowDelete = ViewCaseMembers.AllowDelete

        ViewCaseEmails.AllowAdd = ViewCaseMembers.AllowAdd
        ViewCaseEmails.AllowEdit = ViewCaseMembers.AllowEdit
        ViewCaseEmails.AllowDelete = ViewCaseMembers.AllowDelete

        ViewCaseSocialNetworks.AllowAdd = ViewCaseMembers.AllowAdd
        ViewCaseSocialNetworks.AllowEdit = ViewCaseMembers.AllowEdit
        ViewCaseSocialNetworks.AllowDelete = ViewCaseMembers.AllowDelete

        'we won't allow add/edit/delete Instrument records at this time.
        ViewCaseInstruments.AllowAdd = False    'mblnEditable
        ViewCaseInstruments.AllowEdit = False    'mblnEditable
        ViewCaseInstruments.AllowDelete = False    'Authorization.IsSupervisor

        ViewCaseDocuments.AllowAdd = ViewCaseMembers.AllowAdd
        ViewCaseDocuments.AllowEdit = False    'ViewCaseMembers.AllowEdit
        ViewCaseDocuments.AllowDelete = ViewCaseMembers.AllowDelete 'IsSupervisor    
        ViewCaseDocuments.AllowPreview = True    'ViewCaseMembers.AllowAdd

        EditCaseRA.ReadOnly = Not mblnEditable
        EditTeacher.ReadOnly = Not mblnEditable
        EditClassroom.ReadOnly = Not mblnEditable
        EditSchool.ReadOnly = Not mblnEditable
        EditDistrict.ReadOnly = Not mblnEditable
        EditSite.ReadOnly = Not mblnEditable

        FillEntityTab(objCase)

        tabCase.SelectedTab = mobjCurrentTab
    End Sub

    Private Sub FillEntityTab(objCase As [Case])

        'Show/Hide the applicable tabs
        If Not tabCase.TabPages("tabCaseStudent") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseStudent"))
        End If
        If Not tabCase.TabPages("tabCaseClassroom") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseClassroom"))
        End If
        If Not tabCase.TabPages("tabCaseTeacher") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseTeacher"))
        End If
        If Not tabCase.TabPages("tabCaseSchool") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseSchool"))
        End If
        If Not tabCase.TabPages("tabCaseDistrict") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseDistrict"))
        End If
        If Not tabCase.TabPages("tabCaseSite") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseSite"))
        End If

        'fill the applicable entity user control(s) 
        Select Case objCase.EntityTypeID.Value
            Case Data.Enumerations.tlkpEntityType.Student
                tabCase.TabPages.Add(tabCaseStudent)
                FillStudentTab(objCase)
            Case Data.Enumerations.tlkpEntityType.Classroom
                tabCase.TabPages.Add(tabCaseClassroom)
                EditClassroom.Classroom = objCase.Classroom
            Case Data.Enumerations.tlkpEntityType.Teacher
                tabCase.TabPages.Add(tabCaseTeacher)
                EditTeacher.Teacher = objCase.Teacher
            Case Data.Enumerations.tlkpEntityType.School
                tabCase.TabPages.Add(tabCaseSchool)
                EditSchool.School = objCase.School
            Case Data.Enumerations.tlkpEntityType.District
                tabCase.TabPages.Add(tabCaseDistrict)
                EditDistrict.District = objCase.District
            Case Data.Enumerations.tlkpEntityType.Site
                tabCase.TabPages.Add(tabCaseSite)
                'NOTE: Uncomment below if Site is to be a Case Entity Type
                'EditSite.Site = mobjCase.Site
        End Select
    End Sub

    Private Sub FillStudentTab(objCase As [Case])

        flpStudents.Controls.Clear()

        Dim i As Integer = 0
        Dim EditStudent(objCase.Persons.Count - 1) As EditStudent
        For Each objPerson As Person In objCase.Persons
            If objPerson.RelationshipType.IsPrimarySampleMember.IsTrue Then

                If objPerson.Student Is Nothing Then
                    objPerson.Student = New Student(objPerson) _
                    '(GetSafeValue(objPerson.CaseID), GetSafeValue(objPerson.MPRID))
                End If

                EditStudent(i) = New EditStudent(objPerson)
                EditStudent(i).Dock = DockStyle.Top
                EditStudent(i).ReadOnly = Not mblnEditable
                AddHandler CType(EditStudent(i), EditStudent).OnChanged, AddressOf Me.OnStudentChanged
                flpStudents.Controls.Add(EditStudent(i))
                EditStudent(i).Width = flpStudents.Width - (2*EditStudent(i).Left)

                i = i + 1
            End If
        Next
    End Sub

    Private Sub LockCase()

        If GetSafeValue(mobjCase.CaseID) <> 0 Then

            'try to lock case
            Try
                mobjCase.Lock()

                If mobjCase.IsReadOnly Then
                    MessageBox.Show(
                        "This case you have selected is read-only because it is currently being updated by another user. If you think the case is locked in error, contact your supervisor to release it.",
                        Project.ShortName & " – Case is locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " – Case is locked", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand)
            End Try
        End If
    End Sub

    'Returns: Yes    = save changes and continue with chosen action (i.e. exit, search, etc)
    '         No     = don't save changes and continue with chosen action
    '         Cancel = don't save changes and don't continue with chosen action

    Private Function ConfirmSave() As DialogResult

        If mobjCase Is Nothing Then Return DialogResult.No

        If mobjCase.IsModified Then
            Dim dr As DialogResult = MessageBox.Show("Do you want to save the changes you have made to this case?",
                                                     Project.ShortName & " – Save changes?",
                                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Yes Then
                If Not SaveCase() Then
                    Return DialogResult.Cancel
                End If
            End If
            Return dr
        Else
            Return DialogResult.No
        End If
    End Function

    Private Function SaveCase() As Boolean

        If Not EntityIsValid() Then
            Return False
        End If
        mobjCurrentTab = tabCase.SelectedTab

        'verify that there's at least one person record
        If mobjCase.Persons.Count = 0 Then
            MessageBox.Show("You must have at least one member in order to save a Case.", "Save error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        'now save (insert or update) the entire Case object
        Try
            If GetSafeValue(mobjCase.CaseID) = 0 Then
                mobjCase.Insert()
                LockCase()
            Else
                mobjCase.Update()
            End If
            tsbSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error saving this case", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return False
        End Try
        Return True
    End Function

    Private Sub AddCase(iEntityType As Data.Enumerations.tlkpEntityType)

        mobjCase = New [Case](iEntityType)

        mobjCase.InSample = True

        DisplayCase(mobjCase, Nothing)

        tsbSave.Enabled = True
    End Sub

    'EntityIsValid: returns True if all validation checks are passed,
    'otherwise returns False

    Private Function EntityIsValid() As Boolean

        'do the validations
        Select Case mobjCase.EntityTypeID

            Case Data.Enumerations.tlkpEntityType.Student

                For Each objPerson As Person In mobjCase.Persons
                    If objPerson.Student IsNot Nothing AndAlso
                       objPerson.Student.IsModified Then
                        Try
                            If flpStudents.Controls.Count > 0 AndAlso
                               Not StudentValidator.IsValid() Then
                                StudentValidator.Validate()
                                tabCase.SelectedTab = tabCaseStudent
                                Return False
                            Else
                                Exit For
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                Next

            Case Data.Enumerations.tlkpEntityType.Teacher

                If mobjCase.Teacher IsNot Nothing AndAlso
                   mobjCase.Teacher.IsModified AndAlso
                   Not TeacherValidator.IsValid() Then
                    TeacherValidator.Validate()
                    tabCase.SelectedTab = tabCaseTeacher
                    Return False
                End If

            Case Data.Enumerations.tlkpEntityType.Classroom

                If mobjCase.Classroom IsNot Nothing AndAlso
                   mobjCase.Classroom.IsModified AndAlso
                   Not ClassroomValidator.IsValid() Then
                    ClassroomValidator.Validate()
                    tabCase.SelectedTab = tabCaseClassroom
                    Return False
                End If
        End Select

        'although the Case's Random Assignment info is not really an "entity",
        'it is a Class object that needs to be validated.
        If mobjCase.CaseRA IsNot Nothing AndAlso
           mobjCase.CaseRA.IsModified AndAlso
           Not CaseRAValidator.IsValid() Then
            CaseRAValidator.Validate()
            tabCase.SelectedTab = tabCaseSampling
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Event Handlers"

    Private Sub ViewCaseMembers_OnAdd(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnAdd

        If mobjCase.EntityTypeID = Data.Enumerations.tlkpEntityType.Student AndAlso
           GetSafeValue(objPerson.RelationshipType.IsPrimarySampleMember) Then
            FillStudentTab(mobjCase)
        End If
    End Sub

    Private Sub ViewCaseMembers_OnChanged(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseMembers.Refresh()
        'ViewCaseAddresses.Refresh()
        'ViewCasePhones.Refresh()
    End Sub

    Private Sub ViewCaseAddresses_OnChanged(sender As Object, objAddress As Address) Handles ViewCaseAddresses.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseAddresses.Refresh()
        'ViewCasePhones.Refresh()
    End Sub

    Private Sub ViewCasePhones_OnChanged(sender As Object, objPhone As Phone) Handles ViewCasePhones.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCasePhones.Refresh()
    End Sub

    Private Sub ViewCaseEmails_OnChanged(sender As Object, objEmail As Email) Handles ViewCaseEmails.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseEmails.Refresh()
    End Sub

    Private Sub ViewCaseSocialNetworks_OnChanged(sender As Object, objSocialNetwork As SocialNetwork) _
        Handles ViewCaseSocialNetworks.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseSocialNetworks.Refresh()
    End Sub

    Private Sub ViewCaseInstruments_OnChanged(sender As Object, objInstrument As Instrument) _
        Handles ViewCaseInstruments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseInstruments.Refresh()
    End Sub

    Private Sub ViewCaseDocuments_OnChanged(sender As Object, objDocument As Document) _
        Handles ViewCaseDocuments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseDocuments.Refresh()
    End Sub

    Private Sub ViewCaseMembers_OnClick(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnClick

        mobjSelPerson = objPerson

        ViewCaseAddresses.SelectedCase = mobjCase
        ViewCasePhones.SelectedCase = mobjCase
        ViewCaseEmails.SelectedCase = mobjCase
        ViewCaseSocialNetworks.SelectedCase = mobjCase

        ViewCaseAddresses.SelectedPerson = objPerson
        ViewCasePhones.SelectedPerson = objPerson
        ViewCaseEmails.SelectedPerson = objPerson
        ViewCaseSocialNetworks.SelectedPerson = objPerson
    End Sub

    Private Sub txtEntityName_TextChanged(sender As Object, e As EventArgs) Handles txtEntityName.TextChanged

        mobjCase.EntityName = txtEntityName.Text
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub txtCaseNotes_TextChanged(sender As Object, e As EventArgs) Handles txtCaseNotes.TextChanged

        mobjCase.CaseNotes = txtCaseNotes.Text
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub txtPSU_TextChanged(sender As Object, e As EventArgs) Handles txtPSU.TextChanged

        mobjCase.PSU = txtPSU.Text
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub chkInSample_Click(sender As Object, e As EventArgs) Handles chkInSample.Click

        If Not mobjCase.IsReadOnly Then
            lblInSampleWarning.Visible =
                (mobjCase.InSample.IsTrue <> chkInSample.Checked And mobjCase.Persons.Count > 1)
            mobjCase.InSample = chkInSample.Checked
            tsbSave.Enabled = mobjCase.IsModified
            ViewCaseMembers.Refresh()
        End If
    End Sub

    Private Sub chkIsIneligible_Click(sender As Object, e As EventArgs) Handles chkIsIneligible.Click

        If Not mobjCase.IsReadOnly Then
            lblInSampleWarning.Visible =
                (mobjCase.IsIneligible.IsTrue <> chkIsIneligible.Checked And mobjCase.Persons.Count > 1)
            mobjCase.IsIneligible = chkIsIneligible.Checked
            tsbSave.Enabled = mobjCase.IsModified
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click

        If SaveCase() Then
            DisplayCase(mobjCase, mobjSelPerson)
        End If
    End Sub

    Private Sub frmDisplayCase_Load(sender As Object, e As EventArgs) Handles Me.Load

        '== set-up the generic form properties:

        'fill the Entity Types into the New pull-down button
        tsbNew.DropDownItems.Clear()
        Dim objEntity As EntityType
        For Each objEntity In Project.EntityTypes
            If GetSafeValue(objEntity.EntityAsSample) Then
                tsbNew.DropDownItems.Add(objEntity.Description.ToString)
                tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Tag = objEntity
            End If
        Next

        tsslUser.Text = CurrentUser.Name

        DisplayCase(mobjCase, mobjSelPerson)

        'AF 07/30/13 moved this here to maximize upon load but not to re-maximize if user resized screen.
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmDisplayCase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmSave() = DialogResult.Cancel)
        If Not e.Cancel AndAlso Not mobjCase Is Nothing Then
            mobjCase.Unlock()
            mobjCase.Dispose()
        End If
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click

        Me.Close()
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click

        If mobjCase.IsModified Then
            Dim dr As DialogResult = MessageBox.Show("Are you sure you want to delete this case?",
                                                     Project.ShortName & " – Delete case?", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dr = DialogResult.Yes Then

                Try
                    If Not mobjCase.Delete() Then
                        MessageBox.Show("This case was not successfully deleted from the database.",
                                        Project.Name & " – Error deleting case", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                    End If
                    mobjCase.Dispose()
                    mobjCase = Nothing
                    DisplayCase(mobjCase, Nothing)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Project.Name & " – Error deleting case", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                End Try

            End If
        End If
    End Sub

    Private Sub tsbNew_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) _
        Handles tsbNew.DropDownItemClicked

        If ConfirmSave() = DialogResult.Cancel Then Exit Sub
        mobjCase.Unlock()
        mobjCase.Dispose()

        Dim objEntityType As EntityType = CType(e.ClickedItem.Tag, EntityType)
        AddCase(CType(objEntityType.EntityTypeID.Value, Data.Enumerations.tlkpEntityType))
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click

        Dim frm As New frmSearch
        frm.Show()
    End Sub

    Private Sub tsslCaseID_MouseDown(sender As Object, e As MouseEventArgs) Handles tsslCaseID.MouseDown

        'Case History
        If e.Button = MouseButtons.Right Then
            If Not mobjCase.CaseID.IsNull AndAlso Not mobjCase.CaseID.Value.Equals(0) Then
                Dim frm As New frmDisplayHistory(mobjCase)
                frm.Width = Me.Width
                frm.Location = New Point(Me.Left, Cursor.Position.Y - 12 - frm.Height)
                frm.Show()
            End If

        End If
    End Sub

    Private Sub tabCaseClassroom_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseClassroom.MouseDown

        'Classroom History
        If e.Button = MouseButtons.Right Then
            EditClassroom.ShowHistory()
        End If
    End Sub

    Private Sub tabCaseDistrict_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseDistrict.MouseDown

        'District History
        If e.Button = MouseButtons.Right Then
            EditDistrict.ShowHistory()
        End If
    End Sub

    Private Sub tabCaseSampling_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseSampling.MouseDown

        'Case RandomAssignment History
        If e.Button = MouseButtons.Right Then
            EditCaseRA.ShowHistory()
        End If
    End Sub

    Private Sub tabCaseSchool_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseSchool.MouseDown

        'School History
        If e.Button = MouseButtons.Right Then
            EditSchool.ShowHistory()
        End If
    End Sub

    Private Sub tabCaseSite_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseSite.MouseDown

        'Note: un-comment the section below if Site is a sample case and has history
        ''Site History
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    EditSite.ShowHistory()
        'End If
    End Sub

    Private Sub tabCaseTeacher_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseTeacher.MouseDown

        'Teacher History
        If e.Button = MouseButtons.Right Then
            EditTeacher.ShowHistory()
        End If
    End Sub

    Private Sub EditCaseRA_OnChanged(sender As Object, objCaseRA As CaseRA) Handles EditCaseRA.OnChanged

        mobjCase.CaseRA = objCaseRA
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub EditClassroom_OnChanged(sender As Object, objClassroom As Classroom) Handles EditClassroom.OnChanged

        mobjCase.Classroom = objClassroom
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub EditTeacher_OnChanged(sender As Object, objTeacher As Teacher) Handles EditTeacher.OnChanged

        mobjCase.Teacher = objTeacher
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub EditSite_OnChanged(sender As Object, objSite As Site) Handles EditSite.OnChanged

        'NOTE: Uncomment the section below if the project use Site as a Case Entity type.
        'mobjCase.Site = objSite
        'tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub EditDistrict_OnChanged(sender As Object, objDistrict As District) Handles EditDistrict.OnChanged

        mobjCase.District = objDistrict
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub EditSchool_OnChanged(sender As Object, objSchool As School) Handles EditSchool.OnChanged

        mobjCase.School = objSchool
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub OnStudentChanged(sender As Object, objStudent As Student)

        Dim index As Integer = mobjCase.Persons.IndexOfObject(objStudent.Person)
        mobjCase.Persons(index).Student = objStudent
        tsbSave.Enabled = mobjCase.IsModified
        ViewCaseMembers.Refresh()
    End Sub

    Private Sub flpStudents_Layout(sender As Object, e As LayoutEventArgs) Handles flpStudents.Layout

        For Each ctl As Control In flpStudents.Controls
            ctl.Left = 3
            ctl.Width = flpStudents.Width - (2*ctl.Left)
        Next
    End Sub

#End Region
End Class