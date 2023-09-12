'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmSocialNetwork
    Inherits Form

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private mobjSocialNetwork As SocialNetwork

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case],
                   objPerson As Person,
                   objSocialNetwork As SocialNetwork)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson
        mobjSocialNetwork = objSocialNetwork

        EditPersonName.Person = mobjPerson
        EditSocialNetwork.Person = mobjPerson
        EditSocialNetwork.SocialNetwork = mobjSocialNetwork

        EditSocialNetwork.IsShared = (mobjSocialNetwork.Person Is Nothing)

        If mobjSocialNetwork.IsValid Then
            Me.Text = "SMS - [ " & Project.ShortName & "] - Edit SocialNetwork"
        Else
            Me.Text = "SMS - [ " & Project.ShortName & "] - Add SocialNetwork"
        End If

        EditSocialNetwork.Focus()
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
            mobjSocialNetwork = EditSocialNetwork.SocialNetwork

            'set the Person object depending on whether it's shared or personal
            If EditSocialNetwork.IsShared Then
                mobjSocialNetwork.Person = Nothing
            Else
                mobjSocialNetwork.Person = mobjPerson
            End If

            'add/update the SocialNetwork object into the Case/Person collection
            mobjCase.SocialNetworks.ModifyObjectInCollection(mobjSocialNetwork)

            'if this is the person's only SocialNetwork, make it the Best SocialNetwork.
            If mobjSocialNetwork.IsValid AndAlso
               mobjPerson.SocialNetworks.Count = 1 Then
                mobjPerson.BestSocialNetwork = mobjSocialNetwork
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class