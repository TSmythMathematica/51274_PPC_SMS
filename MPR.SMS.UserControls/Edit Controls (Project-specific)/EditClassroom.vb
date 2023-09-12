'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditClassroom

#Region "Private fields"

    Private mobjClassroom As Classroom = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

#End Region

#Region "Public Properties"

    Public Property Classroom As Classroom
        Get
            FillProperties()
            Return mobjClassroom
        End Get
        Set
            mobjClassroom = value
            If mobjClassroom IsNot Nothing Then
                mobjClassroom.ClassroomTeachers = Nothing   'reset from database
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

        If mobjClassroom IsNot Nothing AndAlso
           Not GetSafeValue(mobjClassroom.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjClassroom)
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

        If mobjClassroom Is Nothing Then Exit Sub

        With mobjClassroom
            SetSafeValue(.Grade, txtGrade.Text)
            SetSafeValue(.Name, txtName.Text)
            RangeValidator.Validate()
            If RangeValidator.IsValid Then
                SetSafeValue(.ClassroomNumber, txtClassNum.Text)
            Else
                .ClassroomNumber = 0
            End If
            .SchoolID = cboSchool.SelectedSchoolID

        End With
    End Sub

    Private Sub FillUserControl()

        If mobjClassroom Is Nothing Then Exit Sub

        With mobjClassroom
            cboSchool.SelectedSchoolID = GetSafeValue(.SchoolID)
            txtGrade.Text = GetSafeValue(.Grade)
            txtName.Text = GetSafeValue(.Name)
            If GetSafeValue(.ClassroomNumber) <> 0 Then
                txtClassNum.Text = CStr(GetSafeValue(.ClassroomNumber))
            Else
                txtClassNum.Text = ""
            End If

            vwMobility.DataSource = "SELECT * FROM vwMobilityClassroom WHERE ClassroomID = " &
                                    GetSafeValue(.ClassroomID)
            vwMobility.Columns(0).Visible = False
            vwMobility.Columns("HistoryID").Visible = False
            vwMobility.SortedColumn = vwMobility.Columns("HistoryID")
            vwMobility.SortDirection = ListSortDirection.Descending

            vwStudents.DataSource = "SELECT * FROM vwStudentsByClassroom WHERE ClassroomID = " &
                                    GetSafeValue(.ClassroomID)
            vwStudents.Columns(0).Visible = False
        End With
        FillTeachers(mobjClassroom)

        EnableUserControl(mblnReadOnly)
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtGrade.ReadOnly = blnReadOnly
        txtName.ReadOnly = blnReadOnly
        txtClassNum.ReadOnly = blnReadOnly
        cboSchool.ReadOnly = blnReadOnly Or (cboSchool.SelectedSchoolID > 0)
        btnAdd.Enabled = Not blnReadOnly
        If Not Project.AllowManyTeachersPerClassroom Then
            btnAdd.Enabled = btnAdd.Enabled And vwTeachers.Rows.Count = 0
        End If
        btnEdit.Enabled = Not blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

    Private Sub FillTeachers(objClassroom As Classroom)

        vwTeachers.Rows.Clear()

        If objClassroom.ClassroomTeachers IsNot Nothing Then
            For Each objClassTeacher As ClassroomTeacher In objClassroom.ClassroomTeachers

                If objClassTeacher.Teacher IsNot Nothing Then
                    Dim objRow As Object() = {GetSafeValue(objClassTeacher.TeacherID),
                                              GetSafeValue(objClassTeacher.Teacher.DisplayName)}

                    vwTeachers.Rows.Add(objRow)
                    vwTeachers.Rows(vwTeachers.Rows.Count - 1).Tag = objClassTeacher
                End If
            Next
        End If
        vwTeachers.Sort(vwTeachers.Columns("TeacherName"), ListSortDirection.Ascending)

        'vwTeachers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        If vwTeachers.Rows.Count > 0 Then vwTeachers.Rows(0).Selected = True

        btnAdd.Enabled = True
        btnEdit.Enabled = (vwTeachers.Rows.Count > 0) And Not mblnReadOnly
        If Not Project.AllowManyTeachersPerClassroom Then
            btnAdd.Enabled = btnAdd.Enabled And vwTeachers.Rows.Count = 0
        End If
    End Sub

    Private Function TeacherIsInClassroom(objClassroomTeachers As ClassroomTeachers, intTeacherID As Integer) As Boolean

        With objClassroomTeachers
            For i As Integer = 0 To (.Count - 1)
                Dim objClassroomTeacher As ClassroomTeacher = CType(.Item(i), ClassroomTeacher)
                If Not objClassroomTeacher.TeacherID.IsNull AndAlso objClassroomTeacher.TeacherID.Value = intTeacherID _
                    Then
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

    Public Shadows Event OnChanged(sender As Object, objClassroom As Classroom)

#End Region

#Region "Event Handlers"

    Private Sub cboSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSchool.SelectedIndexChanged

        If cboSchool.SelectedSchoolID <> GetSafeValue(mobjClassroom.SchoolID) Then
            RaiseEvent OnChanged(Me, Classroom)
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

        If Not Me.DesignMode Then
            If txtName.Text <> GetSafeValue(mobjClassroom.Name) Then
                RaiseEvent OnChanged(Me, Classroom)
            End If
        End If
    End Sub

    Private Sub txtClassNum_TextChanged(sender As Object, e As EventArgs) Handles txtClassNum.TextChanged

        If Not Me.DesignMode Then
            Try
                If txtClassNum.Text <> CStr(mobjClassroom.ClassroomNumber) Then
                    RaiseEvent OnChanged(Me, Classroom)
                End If
            Catch ex As Exception
                RaiseEvent OnChanged(Me, Classroom)
            End Try
        End If
    End Sub

    Private Sub txtGrade_TextChanged(sender As Object, e As EventArgs) Handles txtGrade.TextChanged

        If Not Me.DesignMode Then
            If txtGrade.Text <> GetSafeValue(mobjClassroom.Grade) Then
                RaiseEvent OnChanged(Me, Classroom)
            End If
        End If
    End Sub

    Private Sub EditClassroom_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'make sure the Classroom record has been saved (and has an ID) before
        'adding Teachers to it. Note: there's probably a way to allow this, 
        'using the Classroom object instead of the actual ClassroomID, but this
        'is left as a To-Do for now.  SL 4/20/06
        If GetSafeValue(mobjClassroom.ClassroomID).Equals(0) Then
            MessageBox.Show("You must save this Classroom before assigning Teachers to it.",
                            "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        'make sure we have a School selected, otherwise, you can't select 
        'a Teacher. SL 4/24/06
        If cboSchool.SelectedSchoolID = 0 Then
            MessageBox.Show("You must select a School before assigning Teachers to a Classroom.",
                            "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim objClassTeacher As New ClassroomTeacher
        With objClassTeacher
            .Classroom = Classroom
        End With

        Dim frm As New frmMobilityClassroomTeacher(objClassTeacher, Data.Enumerations.tlkpEntityType.Classroom)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then

            If Not TeacherIsInClassroom(mobjClassroom.ClassroomTeachers, GetSafeValue(objClassTeacher.TeacherID)) Then
                mobjClassroom.ClassroomTeachers.Add(objClassTeacher)
                FillTeachers(mobjClassroom)

                RaiseEvent OnChanged(Me, Classroom)
            Else
                MessageBox.Show(
                    "You have tried to add a Teacher that is already in this Classroom. Please select a different Teacher.",
                    "Classroom/Teacher Assignment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If vwTeachers.SelectedRows.Count.Equals(0) Then
            btnEdit.Enabled = False
            Return
        End If
        Dim objClassTeacher As ClassroomTeacher = CType(vwTeachers.SelectedRows(0).Tag, ClassroomTeacher)

        Dim frm As New frmMobilityClassroomTeacher(objClassTeacher, Data.Enumerations.tlkpEntityType.Classroom)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            mobjClassroom.ClassroomTeachers.ModifyObjectInCollection(objClassTeacher)
            FillTeachers(mobjClassroom)

            RaiseEvent OnChanged(Me, Classroom)
        End If
    End Sub

    Private Sub vwTeachers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles vwTeachers.CellDoubleClick

        If e.RowIndex >= 0 Then
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub vwTeachers_SelectionChanged(sender As Object, e As EventArgs) Handles vwTeachers.SelectionChanged

        btnEdit.Enabled = (vwTeachers.Rows.Count > 0 AndAlso vwTeachers.SelectedRows.Count > 0)
    End Sub

#End Region
End Class
