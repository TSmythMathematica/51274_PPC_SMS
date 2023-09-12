'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditStudent

#Region "Private fields"

    'Private mobjCase As [Case]
    Private ReadOnly mobjPerson As Person = Nothing
    Private mobjStudent As Student = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

#End Region

#Region "Public Properties"

    Public Property Student As Student
        Get
            FillProperties()
            Return mobjStudent
        End Get
        Set
            mobjStudent = value
            mobjStudent.Case = mobjPerson.Case
            FillUserControl()
            PersonName.Person = mobjStudent.Person
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

        'Student History
        If mobjStudent IsNot Nothing AndAlso
           Not GetSafeValue(mobjStudent.MPRID).Equals("") Then
            Dim frm As New frmDisplayHistory(mobjStudent)
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

        If mobjStudent Is Nothing Then Exit Sub

        With mobjStudent
            SetSafeValue(.Grade, txtGrade.Text)
            Try
                SetSafeValue(.SelectionOrder, txtSelOrder.Text)
            Catch ex As Exception
                txtSelOrder.Text = "0"
            End Try
            .SelectionType = cboAssignmentType.SelectedAssignmentCode
            SetSafeValue(.SchoolID, txtSchoolID.Text)
            SetSafeValue(.ClassroomID, txtClassID.Text)
            If GetSafeValue(.GradeBaseline) = "" Then
                SetSafeValue(.GradeBaseline, txtGrade.Text)
            Else
                SetSafeValue(.GradeBaseline, txtGradeBaseline.Text)
            End If
            If GetSafeValue(.ClassroomIDBaseline) = 0 Then
                SetSafeValue(.ClassroomIDBaseline, txtClassID.Text)
            End If

        End With
    End Sub

    Private Sub FillUserControl()

        If mobjStudent Is Nothing Then Exit Sub

        With mobjStudent
            If GetSafeValue(.SchoolID) > 0 Then
                txtSchoolID.Text = CStr(GetSafeValue(.SchoolID))
            Else
                If GetSafeValue(.ClassroomID) > 0 Then
                    txtSchoolID.Text = CStr(GetSafeValue(mobjStudent.Classroom.SchoolID))
                Else
                    txtSchoolID.Text = "0"
                End If
            End If
            txtGradeBaseline.Text = GetSafeValue(.GradeBaseline)

            If GetSafeValue(.ClassroomIDBaseline) <> 0 Then
                lblClassroomBaseline.Text =
                    GetSafeValue(New Classroom(GetSafeValue(.ClassroomIDBaseline)).DisplayClassName)
            Else
                lblClassroomBaseline.Text = "<unassigned>"
            End If

            txtGrade.Text = GetSafeValue(.Grade)
            If Not .SelectionOrder.IsNull Then
                txtSelOrder.Text = CStr(GetSafeValue(.SelectionOrder))
            Else
                txtSelOrder.Text = ""
            End If
            cboAssignmentType.SelectedAssignmentCode = GetSafeValue(.SelectionType)
            txtClassID.Text = CStr(GetSafeValue(.ClassroomID))

            'populate the Student Mobility History grid
            vwMobility.DataSource = "SELECT * FROM vwMobilityStudent WHERE MPRID = '" & GetSafeValue(.MPRID) & "'"
            vwMobility.Columns(0).Visible = False
            vwMobility.Columns("HistoryID").Visible = False
            vwMobility.SortedColumn = vwMobility.Columns("HistoryID")
            vwMobility.SortDirection = ListSortDirection.Descending

        End With
        EnableUserControl([ReadOnly])
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtGrade.ReadOnly = blnReadOnly
        txtSelOrder.ReadOnly = blnReadOnly
        cboAssignmentType.ReadOnly = blnReadOnly
        lnkClassroom.Enabled = Not blnReadOnly
        lnkSchool.Enabled = Not blnReadOnly
        txtGradeBaseline.ReadOnly = True

        Me.TabStop = Not blnReadOnly
    End Sub

    Private Sub GetNewClassroom()

        Dim frm As New frmMobilityStudent(Me.Student)
        frm.ShowDialog()
        FillUserControl()
        If mobjStudent.MobilityTypeID.Equals(3) Then
            mobjPerson.InSample = False
        End If

        RaiseEvent OnChanged(Me, Student)
    End Sub

    Private Sub ShowTeachers()

        If GetSafeValue(Student.ClassroomID) <> 0 Then
            Dim strSQL As String = "SELECT [Teacher Name], Grade FROM vwTeachersByClassroom WHERE ClassroomID = " &
                                   Student.ClassroomID.ToString
            Dim frm As New frmDisplayDataView(strSQL, "Teachers")
            'frm.Width = Me.Parent.Width
            If frm.Columns(0).Width < 120 Then frm.Columns(0).Width = 120 _
            'without this, the grid doesn't resize the 1st column properly, probably because there's a space in the header text...
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Cursor.Position.X - frm.Width\2, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Cursor.Position.X - frm.Width\2, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

    Private Sub ShowClassrooms()

        If GetSafeValue(Student.SchoolID) <> 0 Then
            Dim strSQL As String =
                    "SELECT Name, Grade, ClassroomNumber as [Classroom #], [In Sample?] FROM vwClassroomsBySchool WHERE SchoolID = " &
                    Student.SchoolID.ToString
            Dim frm As New frmDisplayDataView(strSQL, "Classrooms")
            'frm.Width = Me.Parent.Width
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objPerson As Person)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjPerson = objPerson
        Student = mobjPerson.Student
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objStudent As Student)

#End Region

#Region "Event Handlers"


    Private Sub txtSchoolID_TextChanged(sender As Object, e As EventArgs) Handles txtSchoolID.TextChanged

        If CInt(txtSchoolID.Text) <> 0 Then
            lnkSchool.Text = GetSafeValue(New School(CInt(txtSchoolID.Text)).Name)
        Else
            lnkSchool.Text = "<unassigned>"
        End If
    End Sub

    Private Sub txtClassID_TextChanged(sender As Object, e As EventArgs) Handles txtClassID.TextChanged

        If mobjStudent Is Nothing Then Exit Sub

        If CInt(txtClassID.Text) <> GetSafeValue(mobjStudent.ClassroomID) Then
            RaiseEvent OnChanged(Me, Student)
        End If

        If CInt(txtClassID.Text) <> 0 Then
            lnkClassroom.Text = GetSafeValue(New Classroom(CInt(txtClassID.Text)).DisplayClassName)
        Else
            lnkClassroom.Text = "<unassigned>"
        End If
    End Sub

    Private Sub cboAssignmentType_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboAssignmentType.SelectedIndexChanged

        If mobjStudent IsNot Nothing AndAlso
           cboAssignmentType.SelectedAssignmentCode <> GetSafeValue(mobjStudent.SelectionType) Then
            RaiseEvent OnChanged(Me, Student)
        End If
    End Sub

    Private Sub lnkSchool_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkSchool.LinkClicked

        If e.Button = MouseButtons.Right Then
            ShowClassrooms()
        Else
            GetNewClassroom()
        End If
    End Sub

    Private Sub lnkClassroom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkClassroom.LinkClicked

        If e.Button = MouseButtons.Right Then
            ShowTeachers()
        Else
            GetNewClassroom()
        End If
    End Sub

    Private Sub txtSelOrder_TextChanged(sender As Object, e As EventArgs) Handles txtSelOrder.TextChanged

        If Not Me.DesignMode Then
            If txtSelOrder.Text <> GetSafeValue(mobjStudent.SelectionOrder).ToString Then
                RaiseEvent OnChanged(Me, Student)
            End If
        End If
    End Sub

    Private Sub txtGrade_TextChanged(sender As Object, e As EventArgs) Handles txtGrade.TextChanged

        If Not Me.DesignMode Then
            If txtGrade.Text <> GetSafeValue(mobjStudent.Grade) Then
                RaiseEvent OnChanged(Me, Student)
            End If
        End If
    End Sub

    Private Sub EditStudent_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'Student History
        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

#End Region
End Class
