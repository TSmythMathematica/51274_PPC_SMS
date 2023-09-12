'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditTeacher

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjTeacher As Teacher = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

#End Region

#Region "Public Properties"

    Public Property Teacher As Teacher
        Get
            FillProperties()
            Return mobjTeacher
        End Get
        Set
            mobjTeacher = value
            If mobjTeacher IsNot Nothing Then
                mobjTeacher.ClassroomTeachers = Nothing   'reset from database
            End If
            FillUserControl()
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjTeacher IsNot Nothing AndAlso
           Not GetSafeValue(mobjTeacher.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjTeacher)
            frm.Width = Me.Parent.Width
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjTeacher Is Nothing Then Exit Sub

        With mobjTeacher
            SetSafeValue(.Grade, txtGrade.Text)
            SetSafeValue(.GradesSubjTaught, txtGradeSubjTaught.Text)
            If GetSafeValue(.GradeBaseline) = "" Then
                SetSafeValue(.GradeBaseline, txtGrade.Text)
            Else
                SetSafeValue(.GradeBaseline, txtGradeBaseline.Text)
            End If
            .SchoolID = cboSchoolBaseline.SelectedSchoolID
            .ClassroomIDBaseline = cboClassroomBaseline.SelectedClassroomID
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjTeacher Is Nothing Then Exit Sub

        With mobjTeacher
            txtGrade.Text = GetSafeValue(.Grade)
            txtGradeSubjTaught.Text = GetSafeValue(.GradesSubjTaught)
            txtGradeBaseline.Text = GetSafeValue(.GradeBaseline)
            cboSchoolBaseline.SelectedSchoolID = GetSafeValue(.SchoolID)
            cboClassroomBaseline.SelectedClassroomID = GetSafeValue(.ClassroomIDBaseline)

            vwMobility.DataSource = "SELECT * FROM vwMobilityTeacher WHERE TeacherID = " & GetSafeValue(.TeacherID)
            vwMobility.Columns(0).Visible = False
            vwMobility.Columns("HistoryID").Visible = False
            vwMobility.SortedColumn = vwMobility.Columns("HistoryID")
            vwMobility.SortDirection = ListSortDirection.Descending

        End With
        FillClassrooms(mobjTeacher)

        EnableUserControl([ReadOnly])
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtGrade.ReadOnly = blnReadOnly
        txtGradeSubjTaught.ReadOnly = blnReadOnly
        txtGradeBaseline.ReadOnly = True
        cboSchoolBaseline.ReadOnly = blnReadOnly Or (cboSchoolBaseline.SelectedSchoolID <> 0)
        cboClassroomBaseline.ReadOnly = blnReadOnly Or (cboClassroomBaseline.SelectedClassroomID <> 0)
        btnAdd.Enabled = Not blnReadOnly
        If Not Project.AllowManyClassroomsPerTeacher Then
            btnAdd.Enabled = btnAdd.Enabled And vwClassrooms.Rows.Count = 0
        End If
        btnEdit.Enabled = Not blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

    Private Sub FillClassrooms(objTeacher As Teacher)

        vwClassrooms.Rows.Clear()

        If objTeacher.ClassroomTeachers IsNot Nothing Then
            For Each objClassTeacher As ClassroomTeacher In objTeacher.ClassroomTeachers

                If objClassTeacher.Classroom IsNot Nothing Then
                    Dim objRow As Object() = {GetSafeValue(objClassTeacher.ClassroomID),
                                              GetSafeValue(objClassTeacher.Classroom.DisplayClassName)}

                    vwClassrooms.Rows.Add(objRow)
                    vwClassrooms.Rows(vwClassrooms.Rows.Count - 1).Tag = objClassTeacher
                End If
            Next
        End If
        vwClassrooms.Sort(vwClassrooms.Columns("Classroom"), ListSortDirection.Ascending)

        'vwClassrooms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        If vwClassrooms.Rows.Count > 0 Then vwClassrooms.Rows(0).Selected = True

        btnAdd.Enabled = True
        btnEdit.Enabled = (vwClassrooms.Rows.Count > 0) And Not mblnReadOnly
        If Not Project.AllowManyClassroomsPerTeacher Then
            btnAdd.Enabled = btnAdd.Enabled And vwClassrooms.Rows.Count = 0
        End If
    End Sub

    Private Function ClassroomIsInTeacher(objClassroomTeachers As ClassroomTeachers, intClassroomID As Integer) _
        As Boolean

        With objClassroomTeachers
            For i As Integer = 0 To (.Count - 1)
                Dim objClassroomTeacher As ClassroomTeacher = CType(.Item(i), ClassroomTeacher)
                If _
                    Not objClassroomTeacher.ClassroomID.IsNull AndAlso
                    objClassroomTeacher.ClassroomID.Value = intClassroomID Then
                    Return True
                End If
            Next
            Return False
        End With
    End Function

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objTeacher As Teacher)

#End Region

#Region "Event Handlers"

    Private Sub cboSchoolBaseline_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSchoolBaseline.SelectedIndexChanged

        If cboSchoolBaseline.SelectedSchoolID > 0 Then
            cboClassroomBaseline.SchoolIDFilter = cboSchoolBaseline.SelectedSchoolID
        Else
            cboClassroomBaseline.Clear()
        End If

        If cboSchoolBaseline.SelectedSchoolID <> GetSafeValue(mobjTeacher.SchoolID) Then
            RaiseEvent OnChanged(Me, Teacher)
        End If
    End Sub

    Private Sub cboClassroomBaseline_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboClassroomBaseline.SelectedIndexChanged

        If cboClassroomBaseline.SelectedClassroomID <> GetSafeValue(mobjTeacher.ClassroomIDBaseline) Then
            RaiseEvent OnChanged(Me, Teacher)
        End If
    End Sub

    Private Sub txtGrade_TextChanged(sender As Object, e As EventArgs) Handles txtGrade.TextChanged

        If Not Me.DesignMode Then
            If txtGrade.Text <> GetSafeValue(mobjTeacher.Grade) Then
                RaiseEvent OnChanged(Me, Teacher)
            End If
        End If
    End Sub

    Private Sub txtGradeSubjTaught_TextChanged(sender As Object, e As EventArgs) Handles txtGradeSubjTaught.TextChanged

        If Not Me.DesignMode Then
            If txtGradeSubjTaught.Text <> GetSafeValue(mobjTeacher.GradesSubjTaught) Then
                RaiseEvent OnChanged(Me, Teacher)
            End If
        End If
    End Sub

    Private Sub EditTeacher_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'Teacher History
        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'Make sure the Teacher record has been saved (and has an ID) before
        'adding Classrooms to it. Note: there's probably a way to allow this, 
        'using the Teacher object instead of the actual TeacherID, but this
        'is left as a To-Do for now.  SL 4/20/06
        If GetSafeValue(mobjTeacher.TeacherID).Equals(0) Then
            MessageBox.Show("You must save this Teacher before assigning Classrooms to it.",
                            "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        'make sure we have a School selected, otherwise, you can't select 
        'a Classroom. SL 4/24/06
        If cboSchoolBaseline.SelectedSchoolID = 0 Then
            MessageBox.Show("You must select a School before assigning Classrooms to a Teacher.",
                            "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        Dim objClassTeacher As New ClassroomTeacher
        With objClassTeacher
            .Teacher = Teacher
        End With

        Dim frm As New frmMobilityClassroomTeacher(objClassTeacher, Data.Enumerations.tlkpEntityType.Teacher)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then

            If Not ClassroomIsInTeacher(mobjTeacher.ClassroomTeachers, GetSafeValue(objClassTeacher.ClassroomID)) Then
                mobjTeacher.ClassroomTeachers.Add(objClassTeacher)
                FillClassrooms(mobjTeacher)

                RaiseEvent OnChanged(Me, Teacher)
            Else
                MessageBox.Show(
                    "You have tried to add a classroom to a teacher that is already is assigned to that classroom. Please select a different classroom.",
                    "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If vwClassrooms.SelectedRows.Count.Equals(0) Then
            btnEdit.Enabled = False
            Return
        End If
        Dim objClassTeacher As ClassroomTeacher = CType(vwClassrooms.SelectedRows(0).Tag, ClassroomTeacher)

        Dim frm As New frmMobilityClassroomTeacher(objClassTeacher, Data.Enumerations.tlkpEntityType.Teacher)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            mobjTeacher.ClassroomTeachers.ModifyObjectInCollection(objClassTeacher)
            FillClassrooms(mobjTeacher)

            RaiseEvent OnChanged(Me, Teacher)
        End If
    End Sub

    Private Sub vwClassrooms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles vwClassrooms.CellDoubleClick

        If e.RowIndex >= 0 Then
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub vwClassrooms_SelectionChanged(sender As Object, e As EventArgs) Handles vwClassrooms.SelectionChanged

        btnEdit.Enabled = (vwClassrooms.Rows.Count > 0 AndAlso vwClassrooms.SelectedRows.Count > 0)
    End Sub

#End Region
End Class
