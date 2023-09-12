'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmPersonAdd
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjAddress As Address
    Private mobjPhone As Phone
    Private mobjNote As Note
    'Private intNoteTypeID As Int16 = 1 'Note Type As Address 'BT: 12/08/2014 Added for Address Notes.


#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case],
                   objPerson As Person,
                   objAddress As Address,
                   objPhone As Phone,
                   objNote As Note, intNoteTypeID As Int16) 'BT: 12/08/2014 Added for Address Notes.

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson
        mobjAddress = objAddress
        mobjPhone = objPhone
        mobjNote = objNote               'BT: 12/08/2014 Added for Address Notes.


        EditPerson.Person = mobjPerson
        EditAddress.Person = mobjPerson
        EditAddress.Address = mobjAddress
        EditPhone.Person = mobjPerson
        EditPhone.Phone = mobjPhone

        ''EditAddress.ViewNotes.SelectedCase = objCase
        ''EditAddress.ViewNotes.SelectedAddress = objAddress
        'BT: 12/08/2014 Added for Address Notes.
        EditNote.ViewNotes.SelectedAddress = objAddress
        EditNote.ViewNotes.SelectedCase = objCase
        ' EditNote.ViewNotes.btnAdd.Visible = False
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
        'BT: 12/08/2014 Added for Address Notes.

        EditAddress.IsShared = (mobjAddress.Person Is Nothing)
        EditPhone.IsShared = (mobjPhone.Person Is Nothing)

        If mobjPerson.IsValid Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Person"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add Person"
        End If
        If mobjAddress.IsValid Then
            Me.Text += " / Edit Address"
        Else
            Me.Text += " / Add Address"
        End If
        If mobjPhone.IsValid Then
            Me.Text += " / Edit Phone"
        Else
            Me.Text += " / Add Phone"
        End If

        If GetSafeValue(mobjPerson.MPRID).Equals(0) Then
            EditPerson.Focus()
        ElseIf Not mobjAddress Is Nothing AndAlso GetSafeValue(mobjAddress.AddressID).Equals(0) Then
            EditAddress.Focus()
        ElseIf Not mobjPhone Is Nothing AndAlso GetSafeValue(mobjPhone.PhoneID).Equals(0) Then
            EditPhone.Focus()
        Else
            EditPerson.Focus()
        End If
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        'If (EditPerson.Person.IsValid = False Or EditAddress.Address.IsValid = False) And mobjCase.Notes(mobjCase.Notes.Count - 1).Notes.Value <> "" Then
        '    MessageBox.Show("You must create a person and address record before creating an address note.", Project.Name & " – Error adding note", MessageBoxButtons.OK)
        '    Exit Sub
        'End If

        'BT: 12/08/2014 Added for Address Notes.
        If _
            (EditPerson.Person.IsValid = False Or EditAddress.Address.IsValid = False) And
            (EditNote.Note.Notes <> "" Or EditNote.Note.SourceTypeID > 0) Then
            MessageBox.Show("You must create a person and address record before creating an address note.",
                            Project.Name & " – Error adding note", MessageBoxButtons.OK)
            Exit Sub
        End If

        If _
            EditPerson.Person.IsValid = True And EditAddress.Address.IsValid = True And EditNote.Note.Notes = "" And
            EditNote.Note.SourceTypeID > 0 Then
            MessageBox.Show("You must create an address note.", Project.Name & " – Error adding note",
                            MessageBoxButtons.OK)
            Exit Sub
        End If
        'BT: 12/08/2014 Added for Address Notes.

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
            mobjPerson = EditPerson.Person
            mobjAddress = EditAddress.Address
            mobjPhone = EditPhone.Phone
            mobjNote = EditNote.Note

            'set the Person object depending on whether it's shared or personal
            If EditAddress.IsShared Then
                mobjAddress.Person = Nothing
            Else
                mobjAddress.Person = mobjPerson
            End If

            If EditPhone.IsShared Then
                mobjPhone.Person = Nothing
            Else
                mobjPhone.Person = mobjPerson
            End If


            'add/update the Person object into the Case's Person collection
            mobjCase.Persons.ModifyObjectInCollection(mobjPerson)

            'add/update the Address object into the Case/Person collection
            mobjCase.Addresses.ModifyObjectInCollection(mobjAddress)

            'add/update the Phone object into the Case/Person collection
            mobjCase.Phones.ModifyObjectInCollection(mobjPhone)

            If EditNote.Note.IsValid Then 'BT: 12/08/2014 Added for Address Notes.
                'add/update the Note object into the Case/Person collection
                mobjCase.Notes.ModifyObjectInCollection(mobjNote)
            End If

            'if this is the person's only address, make it the Best address.
            If mobjAddress.IsValid AndAlso
               mobjPerson.Addresses.Count = 1 Then
                mobjPerson.BestPhysicalAddress = mobjAddress
                mobjPerson.BestMailingAddress = mobjAddress
            End If

            'if this is the person's only phone, make it the Best phone.
            If mobjPhone.IsValid AndAlso
               mobjPerson.Phones.Count = 1 Then
                mobjPerson.BestPhone = mobjPhone
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
        'If mobjCase.Notes(mobjCase.Notes.Count - 1).Notes.Value <> "" Then
        '    If mobjCase.Notes.IsModified Then
        '        mobjCase.RestoreModified()
        '    End If
        'End If
    End Sub

#End Region
End Class