'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmPersonEdit
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case],
                   objPerson As Person)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson

        EditPerson.Person = mobjPerson

        If mobjPerson.IsValid Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Person"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add Person"
        End If

        EditPerson.Focus()
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
            mobjPerson = EditPerson.Person

            'add/update the Person object into the Case's Person collection
            mobjCase.Persons.ModifyObjectInCollection(mobjPerson)

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class