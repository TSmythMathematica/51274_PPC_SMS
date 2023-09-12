'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmEmail
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private mobjEmail As Email

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case],
                   objPerson As Person,
                   objEmail As Email)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson
        mobjEmail = objEmail

        EditPersonName.Person = mobjPerson
        EditEmail.Person = mobjPerson
        EditEmail.Email = mobjEmail

        EditEmail.IsShared = (mobjEmail.Person Is Nothing)

        If mobjEmail.IsValid Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit Email"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add Email"
        End If

        EditEmail.Focus()
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
            mobjEmail = EditEmail.Email

            'set the Person object depending on whether it's shared or personal
            If EditEmail.IsShared Then
                mobjEmail.Person = Nothing
            Else
                mobjEmail.Person = mobjPerson
            End If

            'add/update the Email object into the Case/Person collection
            mobjCase.Emails.ModifyObjectInCollection(mobjEmail)

            'if this is the person's only email, make it the Best email.
            If mobjEmail.IsValid AndAlso
               mobjPerson.Emails.Count = 1 Then
                mobjPerson.BestEmail = mobjEmail
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class