'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.Windows.Forms.Validation

Public Class EditLocatingStatus

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjLocatingStatus As LocatingStatus = Nothing

    Private mblnReadOnly As Boolean = False
    Private ReadOnly mblnSupervisor As Boolean = False

    Private mblnIsBulkUpdate As Boolean = False ' JP 06/28/2012 - add flag to indicate bulk update

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

    <DefaultValue(False)> _
    <Category("Appearance")>
    Public Property HideNotes As Boolean
        Get
            Return Not txtNotes.Visible
        End Get
        Set
            txtNotes.Visible = Not value
            lblNotes.Visible = txtNotes.Visible
            If value Then
                grpStatus.Text = ""
            Else
                grpStatus.Text = "Respondent status:"
            End If
        End Set
    End Property

    <DefaultValue(False)>
    Public Property IsBulkUpdate As Boolean
        Get
            Return mblnIsBulkUpdate
        End Get
        Set
            mblnIsBulkUpdate = value
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjLocatingStatus Is Nothing Then Exit Sub

        With mobjLocatingStatus
            If cboStatus.SelectedStatus IsNot Nothing Then
                SetSafeValue(.LocatingStatus, GetSafeValue(cboStatus.SelectedStatus.Code))
            End If
            'SetSafeValue(.StatusDate, txtDate.Text)
            .StatusDate = Now
            'SetSafeValue(.LastModifiedBy, txtModifiedBy.Text)
            SetSafeValue(.Notes, txtNotes.Text)
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjLocatingStatus Is Nothing Then Exit Sub

        With mobjLocatingStatus
            lblStatus.Text = .Status.DisplayName
            'cboStatus.SelectedStatus = New Status(.LocatingStatus.ToString)
            txtDate.Text = Now.ToString  'GetSafeValue(.StatusDate).ToString
            txtModifiedBy.Text = CurrentUser.Name  'GetSafeValue(.LastModifiedBy).ToString
            txtNotes.Text = GetSafeValue(.Notes).ToString


            Dim filter As String
            'AS 05/07/14 - added IsActive=1, since StatusComboBox only shows Active statuses
            filter = "Where IsFieldInterviewStatus=0 and IsActive = 1 and (IsCaseInLocating = 1 OR " &
                     "IsCaseInLocatingSupervisor = 1 OR " &
                     "IsStatusAvailableInLocating = 1 "
            If mblnSupervisor Then
                filter &= " OR IsStatusAvailableInLocatingSupervisor = 1 )"
            Else
                filter &= " )"
            End If
            cboStatus.Filters = filter

            'AF 02/28/14 - this need to be thoroughly tested before implementing - it should only allow status codes that are allowed by validatestatus below. 

            'Dim filter As String
            ''Filter out field locating statuses
            ''(IsCaseInLocating = 1 OR " & _("IsCaseInLocatingSupervisor = 1 OR " & _
            'filter = "Where IsFieldInterviewStatus=0 and ( IsStatusAvailableInLocating = 1 "

            'If mblnSupervisor Then
            '    filter &= " OR IsStatusAvailableInLocatingSupervisor = 1 " ')"
            'Else
            '    '   filter &= " )"
            'End If

            ''IF Case is not in locating, filter out locating statuses
            'If Not mobjLocatingStatus.Status.IsCaseInLocatingSupervisor Then
            '    If mblnSupervisor Then
            '        filter &= " OR IsCaseInLocatingSupervisor = 1 )"
            '    Else
            '        filter &= " Or IsCaseInLocating = 1 )"
            '    End If
            '    filter &= " And IsStatusAvailableInLocatingSupervisor = 0"
            'Else
            '    filter &= " )"
            'End If

            'cboStatus.Filters = filter

        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        cboStatus.ReadOnly = blnReadOnly
        'txtDate.ReadOnly = blnReadOnly
        'txtModifiedBy.ReadOnly = blnReadOnly
        txtNotes.ReadOnly = blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

    Private Function ValidateStatus() As Boolean

        ' JP 06/28/2012 - validate only if it is a single update
        If Not mblnIsBulkUpdate Then

            If cboStatus.SelectedStatus IsNot Nothing AndAlso
               cboStatus.SelectedStatus.Code.ToString <> mobjLocatingStatus.Status.Code.ToString Then
                'Only allow selection of codes that are available to locators.
                If (Not (cboStatus.SelectedStatus.IsStatusAvailableInLocating Or
                         cboStatus.SelectedStatus.IsStatusAvailableInLocatingSupervisor)) _
                   And
                   (mobjLocatingStatus.Status.Code.ToSqlInt32 >= 1900 Or
                    (mobjLocatingStatus.Status.Code.ToSqlInt32 >= 1500 And
                     mobjLocatingStatus.Status.Code.ToSqlInt32 < 1600)) Then
                    MessageBox.Show(cboStatus.SelectedStatus.Code.ToString & " is not a valid Locator status.",
                                    Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboStatus.SelectedStatus = mobjLocatingStatus.Status
                    Return False

                    'AF 08/13/09 - this should not fire if the case is currently a 1900 either. 
                    'Changed it to just check if the case is currently in locating supervisor...
                ElseIf (cboStatus.SelectedStatus.IsStatusAvailableInLocating Or
                        cboStatus.SelectedStatus.IsStatusAvailableInLocatingSupervisor) _
                       And Not mobjLocatingStatus.Status.IsCaseInLocatingSupervisor Then
                    MessageBox.Show(
                        cboStatus.SelectedStatus.Code.ToString &
                        " is not a valid status before the case is in Locating.  Please choose a 1500 series status.",
                        Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboStatus.SelectedStatus = mobjLocatingStatus.Status
                    Return False

                    'Only allow Supervisor locating statutes if the user is a supervisor
                ElseIf Not cboStatus.SelectedStatus.IsStatusAvailableInLocating And
                       cboStatus.SelectedStatus.IsStatusAvailableInLocatingSupervisor And
                       Not mblnSupervisor Then
                    MessageBox.Show(
                        cboStatus.SelectedStatus.Code.ToString &
                        " is a supervisor-only status code. You are not authorized to select it.", Project.ShortName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboStatus.SelectedStatus = mobjLocatingStatus.Status
                    Return False
                End If
            End If

        End If
        Return True
    End Function

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not Project Is Nothing Then
            mblnSupervisor = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

            ' 05/29/13 - exclude the field interview specific status by nwu
            'AF 04/25/12 - fix bug found by Dan O'Connor, tested on YouthBuild

            'MsgBox(mobjLocatingStatus.Status.DisplayName)


            ' AF 02/07/14 - Moved filter to FillUserControl 

        End If
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objLocatingStatus As LocatingStatus)

#End Region

#Region "Event Handlers"

    Private Sub cboStatus_Validating(sender As Object, e As CancelEventArgs) Handles cboStatus.Validating

        'ValidateStatus()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

        If cboStatus.SelectedStatus IsNot Nothing Then
            If cboStatus.SelectedStatus.Code.ToString <> GetSafeValue(mobjLocatingStatus.LocatingStatus) Then
                txtDate.Text = Now.ToString
                RaiseEvent OnChanged(Me, LocatingStatus)
            End If
        End If
    End Sub

    'Private Sub txtDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged

    '    If Not Me.DesignMode Then
    '        If txtDate.Text <> GetSafeValue(mobjLocatingStatus.StatusDate).ToString Then
    '            RaiseEvent OnChanged(Me, LocatingStatus)
    '        End If
    '    End If

    'End Sub

    Private Sub txtNotes_TextChanged(sender As Object, e As EventArgs) Handles txtNotes.TextChanged

        If Not Me.DesignMode Then
            If txtNotes.Text <> GetSafeValue(mobjLocatingStatus.Notes) Then
                RaiseEvent OnChanged(Me, LocatingStatus)
            End If
        End If
    End Sub

    Private Sub EditLocatingStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        If CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator) Then

            'LocatingStatus History
            If e.Button = MouseButtons.Right Then
                ShowHistory()
            End If
        End If
    End Sub

    Private Sub StatusValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles StatusValidator.Validating

        e.Valid = ((cboStatus.SelectedStatus IsNot Nothing) AndAlso ValidateStatus())
    End Sub

#End Region
End Class
