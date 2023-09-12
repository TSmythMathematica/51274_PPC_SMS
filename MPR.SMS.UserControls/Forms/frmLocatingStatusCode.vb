'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmLocatingStatusCode

#Region "Private Fields"

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

    Public Sub New(objLocatingStatus As LocatingStatus)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjLocatingStatus = objLocatingStatus

        EditLocatingStatus.LocatingStatus = mobjLocatingStatus

        Me.Text = "SMS - [ " & Project.ShortName & "] - Locating Status"
    End Sub

    ' JP 06/28/2012 - initialize BulkUpdate flag
    Public Sub New(objLocatingStatus As LocatingStatus, objIsBulkUpdate As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjLocatingStatus = objLocatingStatus

        EditLocatingStatus.LocatingStatus = mobjLocatingStatus

        EditLocatingStatus.IsBulkUpdate = objIsBulkUpdate

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

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

#End Region
End Class