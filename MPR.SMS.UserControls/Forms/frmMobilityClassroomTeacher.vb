'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data
Imports MPR.Windows.Forms.Validation

Public Class frmMobilityClassroomTeacher

#Region "Private Variables"

    Private ReadOnly mobjClassroomTeacher As ClassroomTeacher
    'Private mobjClassroom As Classroom
    'Private mobjTeacher As Teacher

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objClassroomTeacher As ClassroomTeacher, intEntity As Data.Enumerations.tlkpEntityType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjClassroomTeacher = objClassroomTeacher

        Dim objSchool As School
        If intEntity = Data.Enumerations.tlkpEntityType.Classroom Then
            objSchool = mobjClassroomTeacher.Classroom.School
            cboClassroom.SchoolIDFilter = GetSafeValue(objSchool.SchoolID)
            cboTeacher.SchoolIDFilter = GetSafeValue(objSchool.SchoolID)
        ElseIf intEntity = Data.Enumerations.tlkpEntityType.Teacher Then
            objSchool = mobjClassroomTeacher.Teacher.School
            cboClassroom.SchoolIDFilter = GetSafeValue(objSchool.SchoolID)
            cboTeacher.SchoolIDFilter = GetSafeValue(objSchool.SchoolID)
        Else
            Throw _
                New Exception("Invalid Entity Type for Classroom/Teacher Mobility. Must be either Classroom or Teacher.")
        End If


        With mobjClassroomTeacher
            If GetSafeValue(.TeacherID) > 0 Then
                cboTeacher.SelectedTeacherID = GetSafeValue(.TeacherID)
            Else
                cboTeacher.SelectedTeacherID = - 1
            End If
            If GetSafeValue(.ClassroomID) > 0 Then
                cboClassroom.SelectedClassroomID = GetSafeValue(.ClassroomID)
            Else
                cboClassroom.SelectedClassroomID = - 1
            End If
            cboClassroom.ReadOnly = GetSafeValue(.ClassroomID) > 0
            cboTeacher.ReadOnly = GetSafeValue(.TeacherID) > 0

            If Not .MobilityCode.IsNull Then
                cboMobilityCode.SelectedMobility = New MobilityCode(GetSafeValue(.MobilityCode))
            Else
                cboMobilityCode.SelectedMobility = New MobilityCode("000")
            End If
            txtMobilityDate.Text = GetSafeDate(Now)   'GetSafeDate(.MobilityDate)
            txtMobilityNote.Text = GetSafeValue(.MobilityNotes)

        End With
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        FormValidator.Validate()
        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.None
        End If

        If DialogResult = DialogResult.OK Then

            If cboMobilityCode.SelectedMobility.MobilityCode.ToString.Equals("000") AndAlso
               Not mobjClassroomTeacher.ClassroomTeacherID.IsNull Then
                MessageBox.Show(
                    "You cannot use the 'Original Assignment' mobility code for changes to an existing assignment." &
                    Environment.NewLine & "Please select an appropriate mobility code.", "Mobility Code Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = DialogResult.None
            Else

                With mobjClassroomTeacher
                    .TeacherID = cboTeacher.SelectedTeacherID
                    .ClassroomID = cboClassroom.SelectedClassroomID
                    .MobilityCode = cboMobilityCode.SelectedMobility.MobilityCode.ToString
                    SetSafeValue(.MobilityDate, txtMobilityDate.Text)
                    .MobilityNotes = txtMobilityNote.Text.ToString
                End With
            End If
        End If
    End Sub

    Private Sub cboMobilityCode_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboMobilityCode.SelectedIndexChanged

        lblWarning.Visible = (cboMobilityCode.SelectedMobility.MobilityTypeID.Value = 3)
    End Sub

    Private Sub ClassroomValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles ClassroomValidator.Validating

        e.Valid = cboClassroom.SelectedClassroom IsNot Nothing AndAlso
                  Not cboClassroom.SelectedClassroomID.Equals(0)
    End Sub

    Private Sub TeacherValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles TeacherValidator.Validating

        e.Valid = cboTeacher.SelectedTeacher IsNot Nothing AndAlso
                  Not cboTeacher.SelectedTeacherID.Equals(0)
    End Sub

    Private Sub NoteValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles NoteValidator.Validating

        e.Valid = Not txtMobilityNote.Text.Length.Equals(0)
    End Sub

#End Region
End Class