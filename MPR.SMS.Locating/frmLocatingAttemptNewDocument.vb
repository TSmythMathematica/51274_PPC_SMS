'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Windows.Forms
Imports MPR.SMS.Data

Public Class frmLocatingAttemptNewDocument

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

        'fill the objects from the edit classes
        Dim objDocument As Document = AddDocument.Document

        'check to see if the user is trying to add a second document
        'of the same document type, if it's not allowed.
        Dim objDocType As DocumentType = objDocument.DocumentType
        If objDocType IsNot Nothing AndAlso Not objDocType.AllowMultipleAdds Then
            For Each objDoc As Document In mobjCase.Documents
                If objDoc.DocumentType.Equals(objDocType) Then
                    MessageBox.Show(
                        "This document type cannot be created multiple times for the same case. If you think you should be able to add multiple documents of this type, contact your project administrator.",
                        "Error adding document", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DialogResult = DialogResult.None
                    Exit For
                End If
            Next
        End If

        If DialogResult = DialogResult.OK Then

            'add/update the Document object into the Case collection
            mobjCase.Documents.ModifyObjectInCollection(objDocument)

            'fill the objects from the edit classes
            mobjLocatingStatus = EditLocatingStatus.LocatingStatus
            mobjLocatingAttempt = EditLocatingAttempt.LocatingAttempt

            mobjLocatingAttempt.PersonLocated = objDocument.PersonHistory.Person
            mobjLocatingAttempt.AddressHistory = objDocument.AddressHistory
            mobjLocatingAttempt.Document = objDocument
            mobjLocatingAttempt.LocatingStatus = mobjLocatingStatus.LocatingStatus

            mobjPerson.LocatingStatus = mobjLocatingStatus
            mobjPerson.LocatingAttempts.Add(0, mobjLocatingAttempt)
            DialogResult = DialogResult.OK

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmLocatingAttemptNewDocument_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objDocument As New Document(GetSafeValue(mobjCase.CaseID))
        objDocument.PersonHistory = mobjPerson.PersonHistory

        AddDocument.Case = mobjCase
        AddDocument.Document = objDocument
    End Sub

#End Region
End Class