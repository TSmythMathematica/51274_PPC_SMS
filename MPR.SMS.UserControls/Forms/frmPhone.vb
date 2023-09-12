'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmPhone
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private mobjPhone As Phone

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case],
                   objPerson As Person,
                   objPhone As Phone)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson
        mobjPhone = objPhone

        EditPersonName.Person = mobjPerson
        EditPhone.Person = mobjPerson
        EditPhone.Phone = mobjPhone

        EditPhone.IsShared = (mobjPhone.Person Is Nothing)

        If mobjPhone.IsValid Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Phone"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add Phone"
        End If

        EditPhone.Focus()
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
            mobjPhone = EditPhone.Phone

            'set the Person object depending on whether it's shared or personal
            If EditPhone.IsShared Then
                mobjPhone.Person = Nothing
            Else
                mobjPhone.Person = mobjPerson
            End If

            'add/update the Phone object into the Case/Person collection
            mobjCase.Phones.ModifyObjectInCollection(mobjPhone)

            'if this is the person's only phone, make it the Best phone.
            If mobjPhone.IsValid AndAlso
               mobjPerson.Phones.Count = 1 Then
                mobjPerson.BestPhone = mobjPhone
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class