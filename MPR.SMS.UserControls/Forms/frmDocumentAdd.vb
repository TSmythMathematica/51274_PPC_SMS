'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

Public Class frmDocumentAdd
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjDocument As Document
    Private ReadOnly mdtStartTime As DateTime

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mdtStartTime = Now    'start a new session
    End Sub

    Public Sub New(objCase As [Case],
                   objDocument As Document)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjDocument = objDocument

        AddDocument.Case = mobjCase
        AddDocument.Document = mobjDocument


        If Not mobjDocument Is Nothing AndAlso Not GetSafeValue(mobjDocument.DocumentID).Equals(0) Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Document"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add Document"
        End If
        mdtStartTime = Now    'start a new session
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        'fill the objects from the edit classes
        mobjDocument = AddDocument.Document

        'If FormValidator.IsValid() Then
        DialogResult = DialogResult.OK
        'Else
        '    FormValidator.Validate()
        '    DialogResult = System.Windows.Forms.DialogResult.None
        'End If

        'check to see if the user is trying to add a second document
        'of the same document type, if it's not allowed.
        Dim objDocType As DocumentType = mobjDocument.DocumentType
        If Not objDocType.AllowMultipleAdds Then
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
            mobjCase.Documents.ModifyObjectInCollection(mobjDocument)

            'create a Locating Attempt
            Dim objPerson As Person =
                    mobjCase.Persons(mobjCase.Persons.IndexOf(mobjDocument.PersonHistory.MPRID.ToString))
            Dim objLocAttempt As New LocatingAttempt(objPerson)
            With objLocAttempt
                .LocatingAttemptTypeID = New SqlInt32(8) 'send document
                .LocatingAttemptResultID = New SqlInt32(Data.Enumerations.LocatingAttemptResult.DocumentSent)
                .Note = "Sent document: " & mobjDocument.DocumentType.Description.ToString
                .LocatingAttemptDate = Now
                .AddressHistoryID = mobjDocument.AddressHistoryID

                'update the Time of this session and the total time
                Dim dtNow As DateTime = Now
                SetSafeValue(.TimeSpentInSeconds, DateDiff(DateInterval.Second, mdtStartTime, dtNow).ToString())
            End With
            'update the Person object (with the new Loc Attempt) into the Case collection
            mobjCase.Persons.ModifyObjectInCollection(objPerson)

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region

#Region "Private Methods"

#End Region
End Class