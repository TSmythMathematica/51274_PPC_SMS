'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MPR.SMS.Data
Imports MPR.SMS.Data.BaseClasses
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls


Public Class frmLocatingSelectionDetail

#Region "Private Variables"

    Private ReadOnly mstrStatus() As String
    Private mhashtimezones As Hashtable

    Private ReadOnly TZCodeEST As String = "07"
    Private ReadOnly TZCodeCST As String = "06"
    Private ReadOnly TZCodeMST As String = "05"
    Private ReadOnly TZCodePST As String = "04"

#End Region

#Region "Public Properties"

    Public ReadOnly Property SelectedCase As [Case]
        Get
            If grdView.SelectedRows.Count > 0 Then
                Dim strMPRID As String = grdView.SelectedRows(0).Cells("MPRID").Value.ToString
                Return GetCase(strMPRID)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property SelectedMPRID As String
        Get
            If grdView.SelectedRows.Count > 0 Then
                Dim strMPRID As String = grdView.SelectedRows(0).Cells("MPRID").Value.ToString
                Return strMPRID
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property SelectedTimeZones As Hashtable
        Get
            Return mhashtimezones
        End Get
        Set
            mhashtimezones = value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(strStatusCode As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Locating: Cases of status '" & strStatusCode & "'"

        mstrStatus(0) = strStatusCode
        FillGrid(mstrStatus)
    End Sub

    Public Sub New(strStatusCodes As String())

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If strStatusCodes.Length > 1 Then
            Me.Text = "Locating: multiple statuses selected"
        Else
            Me.Text = "Locating: Status " & strStatusCodes(0)
        End If

        mstrStatus = strStatusCodes
        FillGrid(mstrStatus)
    End Sub

    Public Sub New(strStatusCodes As String(), httimezones As Hashtable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.SelectedTimeZones = httimezones
        ' Add any initialization after the InitializeComponent() call.

        If strStatusCodes.Length > 1 Then
            Me.Text = "Locating: multiple statuses selected"
        Else
            Me.Text = "Locating: Status " & strStatusCodes(0)
        End If

        mstrStatus = strStatusCodes
        FillGrid(mstrStatus)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub grdView_DoubleClick(sender As Object, e As EventArgs) Handles grdView.DoubleClick

        btnGetCase.PerformClick()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnPriority_Click(sender As Object, e As EventArgs) Handles btnPriority.Click

        'for each selected row, toggle the priority from low to high, or high to low.
        For Each row As DataGridViewRow In grdView.SelectedRows
            Dim strMPRID As String = row.Cells("MPRID").Value.ToString

            Dim objPerson As New Person(strMPRID)
            Dim objCase As New [Case](objPerson.CaseID.Value, True)

            Try
                If objCase.IsReadOnly Then
                    Dim strMsg As String = "MPRID " & strMPRID &
                                           " cannot be updated at this time because it is currently being used by another user."
                    MessageBox.Show(strMsg, "Error updating case", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim intIndex As Integer = objCase.Persons.IndexOf(strMPRID)

                    'toggle the priority
                    If objCase.Persons(intIndex).LocatingStatus.PriorityStatus = 1 Then
                        objCase.Persons(intIndex).LocatingStatus.PriorityStatus = 0
                    Else
                        objCase.Persons(intIndex).LocatingStatus.PriorityStatus = 1
                    End If

                    objCase.Update()
                End If
            Catch ex As Exception
                Dim strMsg As String = "Error updating MPRID " & strMPRID & Environment.NewLine & Environment.NewLine &
                                       ex.Message
                MessageBox.Show(strMsg, "Error updating case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                objCase.Dispose()
            End Try

        Next
        FillGrid(mstrStatus)
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        ' JP 06/28/2012 - process bulk update
        Dim objblnSupervisor As Boolean = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
        Dim strErrorMessages As ArrayList = New ArrayList
        Dim strErrorMessage As String = String.Empty
        Dim strMessage As String = String.Empty
        Dim iNumUpdated As Integer = 0

        Dim objLocStatus As New LocatingStatus()
        objLocStatus.StatusDate = Now
        objLocStatus.LastModifiedBy = CurrentUser.Name

        Dim frm As New frmLocatingStatusCode(objLocStatus, True)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then

            'for each selected row, set the Status
            For Each row As DataGridViewRow In grdView.SelectedRows
                Dim strMPRID As String = row.Cells("MPRID").Value.ToString

                Dim objPerson As New Person(strMPRID)
                Dim objCase As New [Case](objPerson.CaseID.Value, True)

                Try
                    If objCase.IsReadOnly Then
                        Dim strMsg As String = "MPRID " & strMPRID &
                                               " cannot be updated at this time because it is currently being used by another user."
                        MessageBox.Show(strMsg, "Error updating case", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim intIndex As Integer = objCase.Persons.IndexOf(strMPRID)

                        ' update case only if it is a valid status
                        If _
                            ValidateStatus(objCase, objCase.Persons(intIndex).LocatingStatus, objLocStatus,
                                           objblnSupervisor, strErrorMessages) Then
                            objCase.Persons(intIndex).LocatingStatus.LocatingStatus = objLocStatus.LocatingStatus
                            objCase.Persons(intIndex).LocatingStatus.StatusDate = Now
                            objCase.Update()
                            iNumUpdated = iNumUpdated + 1 ' increment the successful update counter
                        End If
                    End If
                Catch ex As Exception
                    Dim strMsg As String = "Error updating MPRID " & strMPRID & Environment.NewLine &
                                           Environment.NewLine & ex.Message
                    MessageBox.Show(strMsg, "Error updating case", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Finally
                    objCase.Dispose()
                End Try

            Next
            strMessage = iNumUpdated & " case(s) updated successfully."

            ' build an error message if there is any
            For Each tmpMsg As String In strErrorMessages
                strErrorMessage = strErrorMessage & tmpMsg & vbCrLf
            Next

            ' concatenate the error message 
            If Not String.IsNullOrEmpty(strErrorMessage) Then
                strMessage = strMessage & vbCrLf & (grdView.SelectedRows.Count - iNumUpdated) &
                             " was(were) not updated for following reason(s)." & vbCrLf & strErrorMessage
            End If

            MessageBox.Show(strMessage, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            FillGrid(mstrStatus)

        End If
    End Sub

    Private Sub btnGetCase_Click(sender As Object, e As EventArgs) Handles btnGetCase.Click

        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        FillGrid(mstrStatus)
    End Sub

#End Region

#Region "Private Methods"


    Private Function ValidateStatus(objCase As [Case], objSourceStatus As LocatingStatus,
                                    objTargetStatus As LocatingStatus, objblnSupervisor As Boolean,
                                    ByRef strErrorMessages As ArrayList) As Boolean

        If objTargetStatus IsNot Nothing AndAlso
           objTargetStatus.LocatingStatus.ToString <> objSourceStatus.LocatingStatus.ToString Then
            'Only allow clustered cases to be updated
            Dim iNewStatus As Integer = 0
            If Integer.TryParse(objTargetStatus.Status.Code.ToString, iNewStatus) Then
                If iNewStatus >= 870 And iNewStatus < 880 Then
                    If Not objCase.IsClustered Then
                        strErrorMessages.Add(
                            "[" & objCase.CaseID.ToString &
                            "] Unable to Update Instrument Status to " + objTargetStatus.Status.Code.ToString +
                            ".  Unclustered case is not allowed to be sent to field.")
                        Return False
                    End If
                End If
            End If


            'Only allow selection of codes that are available to locators.
            If (Not (objTargetStatus.Status.IsStatusAvailableInLocating Or
                     objTargetStatus.Status.IsStatusAvailableInLocatingSupervisor)) _
               And
               (objSourceStatus.LocatingStatus.ToSqlInt32 >= 900 Or
                (objSourceStatus.LocatingStatus.ToSqlInt32 >= 500 And objSourceStatus.LocatingStatus.ToSqlInt32 < 600)) _
                Then
                ' save each message only once
                If _
                    strErrorMessages.IndexOf(objTargetStatus.LocatingStatus.ToString & " is not a valid Locator status.") <
                    0 Then
                    strErrorMessages.Add(
                        "[" & objCase.CaseID.ToString & "]" & objTargetStatus.LocatingStatus.ToString &
                        " is not a valid Locator status.")
                End If
                Return False

                'AF 08/13/09 - this should not fire if the case is currently a 900 either. 
                'Changed it to just check if the case is currently in locating supervisor...
            ElseIf (objTargetStatus.Status.IsStatusAvailableInLocating Or
                    objTargetStatus.Status.IsStatusAvailableInLocatingSupervisor) _
                   And Not objSourceStatus.Status.IsCaseInLocatingSupervisor Then
                ' save each message only once
                If _
                    strErrorMessages.IndexOf(
                        objTargetStatus.LocatingStatus.ToString &
                        " is not a valid status before the case is in Locating.  Please choose a 500 series status.") <
                    0 Then
                    strErrorMessages.Add(
                        "[" & objCase.CaseID.ToString & "]" & objTargetStatus.LocatingStatus.ToString &
                        " is not a valid status before the case is in Locating.  Please choose a 500 series status.")
                End If
                Return False

                'Only allow Supervisor locating statutes if the user is a supervisor
            ElseIf Not objTargetStatus.Status.IsStatusAvailableInLocating And
                   objTargetStatus.Status.IsStatusAvailableInLocatingSupervisor And
                   Not objblnSupervisor Then
                ' save each message only once
                If _
                    strErrorMessages.IndexOf(
                        objTargetStatus.LocatingStatus.ToString &
                        " is a supervisor-only status code. You are not authorized to select it.") < 0 Then
                    strErrorMessages.Add(
                        "[" & objCase.CaseID.ToString & "]" & objTargetStatus.LocatingStatus.ToString &
                        " is a supervisor-only status code. You are not authorized to select it.")
                End If
                Return False
            Else
                Dim objInstrument As Instrument = New Instrument(objCase)

                If _
                    objInstrument.StatusUpdateRuleResult(objSourceStatus.Status.Code.ToString,
                                                         objTargetStatus.Status.Code.ToString) =
                    Instrument.StatusUpdateResult.Error Then
                    Dim strMsg As String = "[" & objCase.CaseID.ToString &
                                           "] Unable to Update Instrument Status to " +
                                           objTargetStatus.Status.Code.ToString +
                                           ".  Either the update rule is missing or does not allow " +
                                           objTargetStatus.Status.Code.ToString + " to overwrite " +
                                           objSourceStatus.Status.Code.ToString + "."
                    strErrorMessages.Add(strMsg)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function GetCase(strMPRID As String) As [Case]

        Dim strMsg As String = "There was an error retrieving this case:" & Environment.NewLine & Environment.NewLine &
                               "The MPRID may be invalid, or it is no longer awaiting locating."
        Dim objPerson As Person = Nothing

        Try
            objPerson = New Person(strMPRID)
            Return New [Case](objPerson.CaseID.Value, False)

        Catch ex As Exception
            MessageBox.Show(strMsg, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End Try
    End Function

    Private Sub FillGrid(strStatusCodes As String())

        grdView.Rows.Clear()

        For Each strStatCode As String In strStatusCodes

            'don't forget to update stored proc SMS_vwLocatingSelectionDetail_SelectAllWStatusCodeLogic if any columns
            'are added/updated to vwLocatingSelectionDetail
            Dim objView As New LocatingSelectionDetail(strStatCode)
            Dim objDataTable As DataTable = objView.LocatingSelectionDetails

            ' time zone stuff
            Dim strTimeZones As String = CType(Me.SelectedTimeZones.Item(strStatCode), String)
            Dim splitTZ As String() = strTimeZones.Split(CType(";", Char))

            For Each objDataRow As DataRow In objDataTable.Rows

                Dim objLocatingStatus As New VwLocatingSelectionDetail(objDataRow)

                ' time zone stuff - gets parsed string from ui to filter - then use code from vw and filter out
                Dim strTZ As String = ""
                If GetSafeValue(objLocatingStatus.TimeZoneCode) <> "" Then
                    strTZ = GetTimeZone(GetSafeValue(objLocatingStatus.TimeZoneCode))
                End If

                'note: I don't like the implementation of this filtering below. The commented section did a string comparison (i.e. Contains) of 
                'a long time zone description. 
                'The uncommented section isn't much better, but at least only compares the time zone code (i.e. "07") and is much more readable.
                'It also now handles missing timezones (for when the phone number's area code is invalid), or anything that falls outside of EST,
                'CST, MST, PST, such as Hawaii or Alaska.
                'This whole filtering could have been handled by the [SMS_GetNextMPRIDInLocating] stored proc and/or [vwLocating_ForGetNex] view. 
                'The stored proc only gets the next available MPRID, and the view doesn't do all of the filtering... :(  SL 7/8/13

                'Dim TimeZoneAddtoGrid As Boolean = True

                'For Each str As String In splitTZ
                '    Dim splitStrTZvalue As String() = str.Split(CType("=", Char))
                '    If strTZ.IndexOf(splitStrTZvalue(0)) > 0 Then
                '        If splitStrTZvalue(1) = "False" Then
                '            TimeZoneAddtoGrid = False
                '        End If
                '    End If
                'Next

                Dim TimeZoneAddtoGrid As Boolean = False

                For Each str As String In splitTZ
                    Dim splitStrTZvalue As String() = str.Split(CType("=", Char))
                    If splitStrTZvalue(1) = "True" Then
                        If _
                            (splitStrTZvalue(0).Equals("EST") AndAlso
                             objLocatingStatus.TimeZoneCode.ToString.Equals(TZCodeEST)) OrElse
                            (splitStrTZvalue(0).Equals("CST") AndAlso
                             objLocatingStatus.TimeZoneCode.ToString.Equals(TZCodeCST)) OrElse
                            (splitStrTZvalue(0).Equals("MST") AndAlso
                             objLocatingStatus.TimeZoneCode.ToString.Equals(TZCodeMST)) OrElse
                            (splitStrTZvalue(0).Equals("PST") AndAlso
                             objLocatingStatus.TimeZoneCode.ToString.Equals(TZCodePST)) OrElse
                            (splitStrTZvalue(0).Equals("Other") AndAlso
                             (objLocatingStatus.TimeZoneCode.ToString < TZCodePST Or
                              objLocatingStatus.TimeZoneCode.ToString > TZCodeEST)) Then
                            TimeZoneAddtoGrid = True
                        End If
                    End If
                Next

                If TimeZoneAddtoGrid = True Then

                    'don't forget to update store proc SMS_vwLocatingSelectionDetail_SelectAllWStatusCodeLogic if any columns
                    'are added/updated to vwLocatingSelectionDetail
                    With objLocatingStatus
                        Dim objRow As Object() = {imgImages.Images("empty.bmp"),
                                                  GetSafeValue(.MPRID),
                                                  GetSafeValue(.Name),
                                                  GetSafeValue(.locatingstatus),
                                                  GetSafeDate(.StatusDate),
                                                  GetSafeValue(.DaysInLocating),
                                                  GetSafeValue(.TotalSecondsInLocating),
                                                  GetSafeValue(.TimesInLocating),
                                                  CInt(.TimesTouched),
                                                  GetSafeValue(.Language),
                                                  GetSafeValue(.State),
                                                  GetSafeValue(.TimeZone),
                                                  GetSafeValue(.Site),
                                                  GetSafeValue(.UserName),
                                                  GetSafeValue(.LastModifiedBy),
                                                  GetSafeValue(.Accurint)
                                                 }

                        If GetSafeValue(.Priority) <> 0 Then
                            objRow(0) = imgImages.Images("Priority.bmp")
                        End If
                        grdView.Rows.Add(objRow)
                        grdView.Rows(grdView.Rows.Count - 1).Tag = objLocatingStatus

                    End With
                End If
            Next
        Next

        grdView.Columns("MPRID").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("StatusCode").Visible = (UBound(mstrStatus) > 1)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        btnGetCase.Enabled = (grdView.Rows.Count > 0)
        btnPriority.Enabled = (grdView.Rows.Count > 0)
        lblCount.Text = CType(grdView.Rows.Count, String)
    End Sub

    Private Function GetTimeZone(TZCode As String) As String

        If TZCode = "" Then Return ""

        Dim strSQL As String = "SELECT * FROM tlkpTimeZoneCode WHERE TimeZoneCode = '" & TZCode & "'"
        Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, strSQL)

        Dim strTZ As String = TZCode
        If dr.Read Then
            If dr("TimeZoneName").ToString <> "" Then
                strTZ = strTZ & " (" & dr("TimeZoneName").ToString & ")"
            End If
            If dr("Description").ToString <> "" Then
                strTZ = strTZ & " - " & dr("Description").ToString
            End If
        End If

        dr.Close()
        dr = Nothing

        Return strTZ
    End Function

#End Region
End Class