'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditLocatingStatusSupervisor

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjLocatingStatus As LocatingStatus = Nothing

    Private mblnReadOnly As Boolean = False

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjLocatingStatus IsNot Nothing AndAlso
           Not GetSafeValue(mobjLocatingStatus.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjLocatingStatus)
            frm.Width = Me.Parent.Width
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Public Properties"

    Public Property LocatingStatus As LocatingStatus
        Get
            FillProperties()
            Return mobjLocatingStatus
        End Get
        Set
            mobjLocatingStatus = value
            FillUserControl()
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjLocatingStatus Is Nothing Then Exit Sub

        With mobjLocatingStatus
            If Not txtStatusDate.Text.Length.Equals(0) Then
                SetSafeValue(.StatusDate, txtStatusDate.Text)
            End If
            'SetSafeValue(.DateSentToLocating, txtDateSent.Text)
            SetSafeValue(.NoOfTimesLocating, "0" + txtNumTimes.Text)
            SetSafeValue(.NoOfTimesTouched, "0" + txtNumTouched.Text)
            SetSafeValue(.TotalTimeSpentInSeconds, "0" + txtTotTime.Text)
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjLocatingStatus Is Nothing Then Exit Sub

        With mobjLocatingStatus
            'AF 04/30/14- CBO should be removed. 
            'AS 05/07/14 - removed cboStatus
            lnkStatus.Text = .Status.DisplayName

            If Not .StatusDate.IsNull Then
                txtStatusDate.Text = GetSafeValue(.StatusDate).ToString
            End If
            If Not .DateSentToLocating.IsNull Then
                txtDateSent.Text = GetSafeValue(.DateSentToLocating).ToString
            End If
            txtNumTimes.Text = GetSafeValue(.NoOfTimesLocating).ToString
            txtNumTouched.Text = GetSafeValue(.NoOfTimesTouched).ToString
            txtNumAttempts.Text = GetSafeValue(.Person.LocatingAttempts.Count).ToString
            txtTotTime.Text = GetSafeValue(.TotalTimeSpentInSeconds).ToString

        End With

        With vwTime
            .DataSource = "SELECT * FROM vwLocatingTimes WHERE MPRID = " & mobjLocatingStatus.MPRID.ToString
            .Columns(0).Visible = False
            .SortedColumn = .Columns("Modified On")
            .SortDirection = ListSortDirection.Descending
        End With

        With vwStatus
            .DataSource = "SELECT * FROM vwLocatingStatusHistory WHERE MPRID =" & mobjLocatingStatus.MPRID.ToString
            .Columns(0).Visible = False
            .Columns("HistoryID").Visible = False
            .SortedColumn = .Columns("HistoryID")
            .SortDirection = ListSortDirection.Descending
        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        lnkStatus.Enabled = Not blnReadOnly
        'txtStatusDate.ReadOnly = blnReadOnly
        txtTotTime.ReadOnly = blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objLocatingStatus As LocatingStatus)

#End Region

#Region "Event Handlers"

    Private Sub lnkStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkStatus.LinkClicked

        'Supervisor change status
        Dim frm As New frmLocatingStatus(mobjLocatingStatus.Person)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillUserControl()
            RaiseEvent OnChanged(Me, LocatingStatus)
        End If
    End Sub

    Private Sub txtStatusDate_TextChanged(sender As Object, e As EventArgs) Handles txtStatusDate.TextChanged

        'If Not Me.DesignMode Then
        '    If txtStatusDate.Text <> GetSafeValue(mobjLocatingStatus.StatusDate).ToString Then
        '        RaiseEvent OnChanged(Me, LocatingStatus)
        '    End If
        'End If
    End Sub

    Private Sub txtTotTime_TextChanged(sender As Object, e As EventArgs) Handles txtTotTime.TextChanged

        If Not Me.DesignMode Then
            If txtTotTime.Text <> GetSafeValue(mobjLocatingStatus.TotalTimeSpentInSeconds).ToString Then
                RaiseEvent OnChanged(Me, LocatingStatus)
            End If
        End If
    End Sub

    Private Sub EditLocatingStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'LocatingStatus History
        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

#End Region
End Class
