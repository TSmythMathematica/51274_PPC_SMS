'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.Windows.Forms.Validation

Public Class EditLocatingAttempt

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjLocatingAttempt As LocatingAttempt = Nothing
    Private ReadOnly mdtStartTime As DateTime

    Private mblnReadOnly As Boolean = False

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjLocatingAttempt IsNot Nothing AndAlso
           Not GetSafeValue(mobjLocatingAttempt.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjLocatingAttempt)
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

    Public Property LocatingAttempt As LocatingAttempt
        Get
            FillProperties()
            Return mobjLocatingAttempt
        End Get
        Set
            mobjLocatingAttempt = value
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

        If mobjLocatingAttempt Is Nothing Then Exit Sub

        With mobjLocatingAttempt
            If cboLocTask.SelectedLocatingAttemptType IsNot Nothing Then
                .LocatingAttemptTypeID = GetSafeValue(cboLocTask.SelectedLocatingAttemptTypeID)
            End If
            If cboLocResult.SelectedLocatingAttemptResult IsNot Nothing Then
                .LocatingAttemptResultID = GetSafeValue(cboLocResult.SelectedLocatingAttemptResultID)
            End If
            SetSafeValue(.Note, txtNotes.Text)
            .LocatingAttemptDate = Now

            'update the Time of this session and the total time
            Dim dtNow As DateTime = Now
            SetSafeValue(.TimeSpentInSeconds, DateDiff(DateInterval.Second, mdtStartTime, dtNow).ToString())

            .CreatedBy = CurrentUser.Name
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjLocatingAttempt Is Nothing Then Exit Sub

        With mobjLocatingAttempt
            cboLocResult.LocatingAttemptType = mobjLocatingAttempt.LocatingAttemptType
            cboLocTask.SelectedLocatingAttemptType = New LocatingAttemptType(GetSafeValue(.LocatingAttemptTypeID))
            'uncomment the line below to default the status based on the 
            'AttemptType. For now, Larry wants it left un-defaulted.
            'This has been turned on, but most values are set to NULL (no default). This way, if we do implement
            'more defaults, you only have to add the value to the table. SL 9/4/13
            If Not .LocatingAttemptResultID.IsNull Then
                cboLocResult.SelectedLocatingAttemptResult =
                    New LocatingAttemptResult(GetSafeValue(.LocatingAttemptResultID))
            End If
            txtNotes.Text = GetSafeValue(.Note).ToString
        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        cboLocTask.ReadOnly = blnReadOnly
        cboLocResult.ReadOnly = blnReadOnly
        txtNotes.ReadOnly = blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mdtStartTime = Now    'start a new session
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objLocatingAttempt As LocatingAttempt)

#End Region

#Region "Event Handlers"

    Private Sub cboLocTask_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLocTask.SelectedIndexChanged

        If mobjLocatingAttempt IsNot Nothing Then
            If _
                GetSafeValue(cboLocTask.SelectedLocatingAttemptTypeID) <>
                GetSafeValue(mobjLocatingAttempt.LocatingAttemptTypeID) Then
                RaiseEvent OnChanged(Me, LocatingAttempt)
            End If
            cboLocResult.LocatingAttemptType = cboLocTask.SelectedLocatingAttemptType
        End If
    End Sub

    Private Sub cboLocResult_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLocResult.SelectedIndexChanged

        If mobjLocatingAttempt IsNot Nothing Then
            If _
                GetSafeValue(cboLocResult.SelectedLocatingAttemptResultID) <>
                GetSafeValue(mobjLocatingAttempt.LocatingAttemptResultID) Then
                RaiseEvent OnChanged(Me, LocatingAttempt)
            End If
        End If
    End Sub

    Private Sub txtNotes_TextChanged(sender As Object, e As EventArgs) Handles txtNotes.TextChanged

        If Not Me.DesignMode Then
            If txtNotes.Text <> GetSafeValue(mobjLocatingAttempt.Note) Then
                RaiseEvent OnChanged(Me, LocatingAttempt)
            End If
        End If
    End Sub

    Private Sub EditLocatingAttempt_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        If CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator) Then

            'LocatingAttempt History
            If e.Button = MouseButtons.Right Then
                ShowHistory()
            End If
        End If
    End Sub

    Private Sub ResultValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles ResultValidator.Validating

        e.Valid = (cboLocResult.SelectedLocatingAttemptResult IsNot Nothing)
    End Sub

#End Region
End Class
