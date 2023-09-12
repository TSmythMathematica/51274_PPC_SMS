'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmLocatingStatus

#Region "Private Fields"

    Private ReadOnly mobjPerson As Person
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

    Public Sub New(objPerson As Person)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjPerson = objPerson
        mobjLocatingStatus = objPerson.LocatingStatus

        EditLocatingStatus.LocatingStatus = mobjLocatingStatus

        Me.Text = "SMS - [ " & Project.ShortName & "] - Locating Status"
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            FormValidator.Validate()
            DialogResult = DialogResult.None
        End If

        If DialogResult = DialogResult.OK Then

            'fill the objects from the edit classes
            mobjLocatingStatus = EditLocatingStatus.LocatingStatus

            mobjPerson.LocatingStatus = mobjLocatingStatus
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class