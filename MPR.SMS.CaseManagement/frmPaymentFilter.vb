'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************


Public Class frmPaymentFilter

#Region "Public Properties"

    Public Property CheckName As String
        Get
            Return txtName.Text
        End Get
        Set
            txtName.Text = value
        End Set
    End Property

    Public Property ProjectCode As String
        Get
            Return txtProjectCode.Text
        End Get
        Set
            txtProjectCode.Text = value
        End Set
    End Property

    Public Property TaskCode As String
        Get
            Return txtTaskCode.Text
        End Get
        Set
            txtTaskCode.Text = value
        End Set
    End Property

    Public Property SequentialNumber As String
        Get
            Return txtSeqNo.Text
        End Get
        Set
            txtSeqNo.Text = value
        End Set
    End Property

    Public Property CheckNumber As String
        Get
            Return txtCheckNo.Text
        End Get
        Set
            txtCheckNo.Text = value
        End Set
    End Property

    Public ReadOnly Property Filters As String
        Get
            Dim strFilters As String = ""
            If txtMPRID.Text <> "" Then
                strFilters += " AND MPRID LIKE '%" & txtMPRID.Text & "%'"
            End If
            If txtName.Text <> "" Then
                strFilters += " AND Name LIKE '%" & txtName.Text & "%'"
            End If
            If txtCheckNo.Text <> "" Then
                strFilters += " AND [Check #] LIKE '%" & txtCheckNo.Text & "%'"
            End If
            If txtSeqNo.Text <> "" Then
                strFilters += " AND [SequentialNo] LIKE '%" & txtSeqNo.Text & "%'"
            End If
            If txtTaskCode.Text <> "" Then
                strFilters += " AND [Project Code] LIKE '%" & txtTaskCode.Text & "'"
            End If

            Return strFilters
        End Get
    End Property

#End Region

#Region "Event Handlers"

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region
End Class
