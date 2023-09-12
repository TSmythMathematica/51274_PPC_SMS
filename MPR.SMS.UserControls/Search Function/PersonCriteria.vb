'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel

Public Class PersonCriteria

#Region "Public Properties"

    <DefaultValue(- 1)>
    Public Property SelectedPersonType As Integer
        Get
            If optAllCaseTypes.Checked Then
                Return - 1
            Else
                Return cboRelationshipType.SelectedRelationshipTypeID
            End If
        End Get
        Set
            If value = 0 Then
                optAllCaseTypes.Checked = True
            Else
                optCaseType.Checked = True
                cboRelationshipType.SelectedRelationshipTypeID = value
            End If
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub optCaseType_CheckedChanged(sender As Object, e As EventArgs) Handles optCaseType.CheckedChanged

        cboRelationshipType.Enabled = optCaseType.Checked
    End Sub

#End Region
End Class
