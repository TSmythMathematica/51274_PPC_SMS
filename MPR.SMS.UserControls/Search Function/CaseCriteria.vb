'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Class CaseCriteria

#Region "Public Properties"

    Public Property InSampleOnly As Boolean
        Get
            Return chkInSample.Checked
        End Get
        Set
            chkInSample.Checked = value
        End Set
    End Property

    Public Property ExcludeIneligibles As Boolean
        Get
            Return chkExcludeIneligibles.Checked
        End Get
        Set
            chkExcludeIneligibles.Checked = value
        End Set
    End Property

    Public Property SelectedCaseType As Integer
        Get
            If optAllCaseTypes.Checked Then
                Return 0
            Else
                Return cboEntityType.SelectedEntityTypeID
            End If
        End Get
        Set
            If value = 0 Then
                optAllCaseTypes.Checked = True
            Else
                optCaseType.Checked = True
                cboEntityType.SelectedEntityTypeID = value
            End If
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub optCaseType_CheckedChanged(sender As Object, e As EventArgs) Handles optCaseType.CheckedChanged

        cboEntityType.Enabled = optCaseType.Checked
    End Sub

#End Region
End Class
