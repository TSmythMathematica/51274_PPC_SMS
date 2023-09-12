'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MPR.SMS.Data

Public Class frmLocatingAttemptNewRespondent

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private mobjLocatingAttempt As LocatingAttempt
    Private mobjLocatingStatus As LocatingStatus

#End Region

#Region "Public Properties"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case], objPerson As Person, objLocatingAttemptType As LocatingAttemptType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjCase = objCase
        mobjPerson = objPerson
        mobjLocatingStatus = objPerson.LocatingStatus

        mobjLocatingAttempt = New LocatingAttempt()
        mobjLocatingAttempt.Person = objPerson
        mobjLocatingAttempt.LocatingAttemptTypeID = objLocatingAttemptType.LocatingAttemptTypeID
        mobjLocatingAttempt.LocatingAttemptResultID = objLocatingAttemptType.ResultDefault

        EditLocatingStatus.LocatingStatus = mobjLocatingStatus
        EditLocatingAttempt.LocatingAttempt = mobjLocatingAttempt

        ViewCaseInstruments.SelectedCase = mobjCase
        ViewCaseMembers.SelectedCase = mobjCase

        Me.Text = "SMS - [ " & Project.ShortName & "] - Locating Task: " &
                  objLocatingAttemptType.LocatingAttemptType.ToString
    End Sub

#End Region

#Region "Private Methods"

    Private Sub CheckRespondent()

        lblWarning.Visible = False
        btnOK.Enabled = False

        If ViewCaseInstruments.SelectedInstrument Is Nothing OrElse
           ViewCaseMembers.SelectedPerson Is Nothing Then
            Return
        End If

        'only allow it if the selected person is different from the
        'current respondent
        If GetSafeValue(ViewCaseInstruments.SelectedInstrument.CurrentRespondent.MPRID) =
           GetSafeValue(ViewCaseMembers.SelectedPerson.MPRID) Then
            lblWarning.Text = "The selected person is already the current respondent."
            lblWarning.Visible = True
            btnOK.Enabled = False

            'if not a new Person, then check the history
        ElseIf GetSafeValue(ViewCaseMembers.SelectedPerson.MPRID) <> "" Then

            Dim strSQL As String = "SELECT COUNT(*) FROM vwInstrumentRespondentHistory WHERE InstrumentID = " &
                                   GetSafeValue(ViewCaseInstruments.SelectedInstrument.InstrumentID) &
                                   " AND CurrentRespondentMPRID = " & GetSafeValue(ViewCaseMembers.SelectedPerson.MPRID)
            Dim dr As SqlDataReader

            dr = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, strSQL)

            While dr.Read()
                If dr.GetInt32(0) > 0 Then
                    lblWarning.Text =
                        "Note: This case member has previously been selected as the respondent for this instrument. Right-click the selected instrument to see the history."
                    lblWarning.Visible = True
                Else
                    lblWarning.Visible = False
                End If
            End While
            btnOK.Enabled = True
            dr.Close()

        Else
            btnOK.Enabled = True
        End If
    End Sub

    'this function returns the number of instruments with the given Current Respondent
    Private Function GetInstrumentsWithSameRespondent(objInstruments As Instruments, MPRID As String) As Integer

        Dim intCount As Integer = 0

        For Each objInstrument As Instrument In objInstruments
            If objInstrument.CurrentRespondentMPRID.ToString.Equals(MPRID) Then
                intCount += 1
            End If
        Next

        Return intCount
    End Function

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim msg As String

        FormValidator.Validate()
        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.None
        End If

        If DialogResult = DialogResult.OK Then

            Dim objSelInst As Instrument = ViewCaseInstruments.SelectedInstrument
            Dim objSelPerson As Person = ViewCaseMembers.SelectedPerson

            Dim blnChangeAll As Boolean = False
            Dim intCount As Integer = GetInstrumentsWithSameRespondent(mobjCase.Instruments,
                                                                       objSelInst.CurrentRespondentMPRID.ToString)
            If intCount > 1 Then
                msg =
                    "There are other instruments for this case that currently have the same respondent as the one you have selected to change. Do you want to change those other instruments as well?" &
                    Environment.NewLine & Environment.NewLine &
                    "Click 'Yes' to change all instruments with this respondent to the newly selected respondent." &
                    Environment.NewLine &
                    "Click 'No' to change only the selected instrument to the new respondent."

                blnChangeAll =
                    (MessageBox.Show(msg, Project.ShortName & " – Change current respondent", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes)
            End If

            If blnChangeAll Then
                msg = "For all instruments whose current respondent is '" & objSelInst.CurrentRespondent.FullName & "'" &
                      Environment.NewLine &
                      "you will be changing the current respondent to: '" & objSelPerson.FullName & "'" &
                      Environment.NewLine & Environment.NewLine &
                      "Continue?"
            Else
                msg = "For the instrument: '" & objSelInst.InstrumentType.Description.ToString & "'" &
                      Environment.NewLine &
                      "you will be changing the current respondent from: '" & objSelInst.CurrentRespondent.FullName &
                      "'" & Environment.NewLine &
                      "to: '" & objSelPerson.FullName & "'" & Environment.NewLine & Environment.NewLine &
                      "Continue?"
            End If

            If _
                MessageBox.Show(msg, Project.ShortName & " – Confirm new current respondent", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                If blnChangeAll Then 'change all instruments with the same current respondent
                    Dim objCR As Person = objSelInst.CurrentRespondent
                    For i As Integer = 0 To mobjCase.Instruments.Count - 1
                        If mobjCase.Instruments(i).CurrentRespondent.Equals(objCR) Then
                            mobjCase.Instruments(i).CurrentRespondent = objSelPerson
                        End If
                    Next
                Else 'change just the selected instrument
                    objSelInst.CurrentRespondent = objSelPerson
                    mobjCase.Instruments.ModifyObjectInCollection(objSelInst)
                End If

                'fill the objects from the edit classes
                mobjLocatingStatus = EditLocatingStatus.LocatingStatus
                mobjLocatingAttempt = EditLocatingAttempt.LocatingAttempt

                mobjLocatingAttempt.PersonLocated = objSelPerson
                mobjLocatingAttempt.LocatingStatus = mobjLocatingStatus.LocatingStatus

                mobjPerson.LocatingStatus = mobjLocatingStatus
                mobjPerson.LocatingAttempts.Add(0, mobjLocatingAttempt)
                DialogResult = DialogResult.OK
            Else
                DialogResult = DialogResult.Cancel
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ViewCaseMembers_OnClick(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnClick

        CheckRespondent()
    End Sub

    Private Sub ViewCaseInstruments_OnClick(sender As Object, objInstrument As Instrument) _
        Handles ViewCaseInstruments.OnClick

        CheckRespondent()
    End Sub

#End Region
End Class