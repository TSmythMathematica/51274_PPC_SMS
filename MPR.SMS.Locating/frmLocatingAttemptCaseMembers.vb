'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Windows.Forms
Imports MPR.SMS.Data

Public Class frmLocatingAttemptCaseMembers

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private mobjLocatingAttempt As LocatingAttempt
    Private mobjLocatingStatus As LocatingStatus

    'last to be modified:
    Private mobjLastPerson As Person = Nothing
    Private mobjLastAddress As Address = Nothing
    Private mobjLastPhone As Phone = Nothing
    Private mobjLastEmail As Email = Nothing

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

        ViewCaseMembers.SelectedCase = mobjCase
        ViewCaseNotes.SelectedCase = mobjCase

        Me.Text = "SMS - [ " & Project.ShortName & "] - Locating Task: " &
                  objLocatingAttemptType.LocatingAttemptType.ToString
    End Sub

#End Region

#Region "Private Methods"

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

            'fill the objects from the edit classes
            mobjLocatingStatus = EditLocatingStatus.LocatingStatus
            mobjLocatingAttempt = EditLocatingAttempt.LocatingAttempt

            mobjLocatingAttempt.PersonLocated = mobjLastPerson
            mobjLocatingAttempt.Address = mobjLastAddress
            mobjLocatingAttempt.Phone = mobjLastPhone
            mobjLocatingAttempt.Email = mobjLastEmail
            mobjLocatingAttempt.LocatingStatus = mobjLocatingStatus.LocatingStatus

            mobjPerson.LocatingStatus = mobjLocatingStatus
            mobjPerson.LocatingAttempts.Add(0, mobjLocatingAttempt)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ViewCaseMembers_OnChanged(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnChanged

        mobjLastPerson = objPerson
        mobjLastAddress = Nothing
        mobjLastPhone = Nothing
        mobjLastEmail = Nothing
    End Sub

    Private Sub ViewCaseMembers_OnAdd(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnAdd

        mobjLastPerson = objPerson
        mobjLastAddress = Nothing
        mobjLastPhone = Nothing
        mobjLastEmail = Nothing

        Dim iCnt As Integer = 0

        iCnt = objPerson.Addresses.Count
        If iCnt > 0 Then mobjLastAddress = objPerson.Addresses(iCnt - 1)

        iCnt = objPerson.Phones.Count
        If iCnt > 0 Then mobjLastPhone = objPerson.Phones(iCnt - 1)

        iCnt = objPerson.Emails.Count
        If iCnt > 0 Then mobjLastEmail = objPerson.Emails(iCnt - 1)
    End Sub

#End Region
End Class