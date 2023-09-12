'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmMobilityStudent

#Region "Private Variables"

    Private ReadOnly mobjStudent As Student

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objStudent As student)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjStudent = objStudent
        With mobjStudent
            If GetSafeValue(.SchoolID) > 0 Then
                cboSchool.SelectedSchoolID = GetSafeValue(.SchoolID)
            Else
                cboSchool.SelectedSchoolID = - 1
            End If
            cboClassroom.SelectedClassroomID = GetSafeValue(.ClassroomID)
            If Not .MobilityCode.IsNull Then
                cboMobilityCode.SelectedMobility = New MobilityCode(GetSafeValue(.MobilityCode))
            Else
                cboMobilityCode.SelectedMobility = New MobilityCode("000")
            End If
            txtMobilityDate.Text = GetSafeDate(Now)   'GetSafeDate(.MobilityDate)
            txtMobilityNote.Text = GetSafeValue(.MobilityNote)

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
               Not mobjStudent.StudentID.IsNull AndAlso
               mobjStudent.Classroom IsNot Nothing AndAlso
               Not GetSafeValue(mobjStudent.ClassroomID).Equals(GetSafeValue(cboClassroom.SelectedClassroomID)) Then
                MessageBox.Show(
                    "You cannot use the 'Original Assignment' mobility code for changes to the student's school or classroom." &
                    Environment.NewLine & "Please select an appropriate mobility code.", "Mobility Code Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = DialogResult.None
            Else

                With mobjStudent
                    .SchoolID = cboSchool.SelectedSchoolID
                    .ClassroomID = cboClassroom.SelectedClassroomID
                    .MobilityCode = cboMobilityCode.SelectedMobility.MobilityCode.ToString
                    SetSafeValue(.MobilityDate, txtMobilityDate.Text)
                    .MobilityNote = txtMobilityNote.Text.ToString
                End With
            End If
        End If
    End Sub

    Private Sub cboSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSchool.SelectedIndexChanged

        If cboClassroom.SelectedClassroom Is Nothing OrElse
           cboClassroom.SelectedClassroom.SchoolID.IsNull OrElse
           cboSchool.SelectedSchoolID <> cboClassroom.SelectedClassroom.SchoolID Then
            If cboSchool.SelectedSchoolID > 0 Then
                cboClassroom.SchoolIDFilter = cboSchool.SelectedSchoolID
            Else
                cboClassroom.Clear()
            End If
        End If
    End Sub

    Private Sub cboMobilityCode_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboMobilityCode.SelectedIndexChanged

        lblWarning.Visible = (cboMobilityCode.SelectedMobility.MobilityTypeID.Value = 3)
    End Sub

#End Region
End Class