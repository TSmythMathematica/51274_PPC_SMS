'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmNote
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjAddress As Address
    Private mobjNote As Note
    Private ReadOnly intNoteTypeID As Int16

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.btnOK.Enabled = False
    End Sub

    Public Sub New(objCase As [Case],
                   objNote As Note,
                   NoteTypeID As Int16)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjNote = objNote
        intNoteTypeID = NoteTypeID

        EditNote.ViewNotes.SelectedAddress = objNote.Address
        EditNote.ViewNotes.SelectedCase = objCase
        'EditNote.ViewNotes.btnAdd.Visible = False
        EditNote.ViewNotes.grpMembers.Text = ""
        EditNote.ViewNotes.imgIcon.Visible = False

        EditNote.Address = mobjAddress
        EditNote.Person = mobjPerson
        EditNote.Note = mobjNote
        EditNote.cboNoteType.SelectedNoteTypeID = intNoteTypeID
        EditNote.lblNoteType.Visible = False
        EditNote.cboNoteType.ReadOnly = True
        EditNote.cboNoteType.Visible = False
        EditNote.Note.DocumentID = 0


        'EditNote.IsShared = (mobjNote.Person Is Nothing)

        'If mobjNote.IsValid Then
        '    Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Note"
        'Else
        '    Me.Text = "SMS - [ " & Project.ShortName & "] - Add Note"
        'End If

        Me.Text = "SMS - [ " & Project.ShortName & "] - Add Note"

        EditNote.Focus()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click


        'If FormValidator.ValidateOnAccept Then
        '    DialogResult = System.Windows.Forms.DialogResult.OK
        'Else
        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            FormValidator.Validate()
            DialogResult = DialogResult.None
        End If
        'End If

        If DialogResult = DialogResult.OK Then

            'fill the objects from the edit classes
            mobjNote = EditNote.Note


            ' ''set the Person object depending on whether it's shared or personal
            ''If EditNote.IsShared Then
            ''    mobjNote.Person = Nothing
            ''Else
            ''    mobjNote.Person = mobjPerson
            ''End If

            'add/update the Note object into the Case/Person collection
            If EditNote.Note.IsValid Then 'BT: 12/08/2014 Added for Address Notes.
                'add/update the Note object into the Case/Person collection
                mobjCase.Notes.ModifyObjectInCollection(mobjNote)
            End If


            ' ''if this is the person's only Note, make it the Best Note.
            ''If mobjNote.IsValid AndAlso _
            ''   mobjPerson.Notes.Count = 1 Then
            ''    mobjPerson.BestNote = mobjNote
            ''End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class