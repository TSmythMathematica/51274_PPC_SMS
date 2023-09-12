'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MPR.SMS.Data
Imports MPR.SMS.Security


Public Class frmLocatingSelection

#Region "Private Variables"

    Dim ReadOnly mblnLocSup As Boolean = False

#End Region

#Region "Private Properties"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CenterToScreen()

        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Locating: Select Case"

        mblnLocSup = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

        btnDetails.Visible = mblnLocSup

        Dim strSQL As String = "SELECT * FROM vwLocatingSelection"
        If Not mblnLocSup Then
            strSQL = strSQL & " WHERE SupervisorOnly = 0"
        End If
        With vwLocatingSelection
            .DataSource = strSQL
            .Columns("SupervisorOnly").Visible = False
            .Columns("Status").DefaultCellStyle.BackColor = Color.LightYellow
            .MultiSelect = mblnLocSup

        End With

        grpCounts.Visible = mblnLocSup
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub vwLocatingSelection_DoubleClick(sender As Object, e As EventArgs) _
        Handles vwLocatingSelection.DoubleClick

        'If btnDetails.Visible = True Then
        '    ShowDetails(New Point(Me.Location.X, System.Windows.Forms.Cursor.Position.Y + 12))
        'End If
        btnGetCase.PerformClick()
    End Sub

    Private Sub vwLocatingSelection_Paint(sender As Object, e As PaintEventArgs) Handles vwLocatingSelection.Paint

        MarkSupervisorCodes()
    End Sub

    Private Sub optMPRID_CheckedChanged(sender As Object, e As EventArgs) Handles optMPRID.CheckedChanged

        txtMPRID.Enabled = optMPRID.Checked
        If txtMPRID.Enabled Then txtMPRID.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        vwLocatingSelection.Refresh()
        MarkSupervisorCodes()
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click

        ShowDetails(New Point(Me.Location.X, Me.PointToScreen(btnRefresh.Location).Y - 18))
    End Sub

    Private Sub btnGetCase_Click(sender As Object, e As EventArgs) Handles btnGetCase.Click

        Dim strMsg As String = ""
        Dim strCaption As String = "No cases found"
        Dim strMPRID As String = ""
        Dim objCase As [Case] = Nothing

        If optMPRID.Checked Then
            strMPRID = txtMPRID.Text
        Else
            Try

                strMPRID = GetNextMPRID()

                If strMPRID = "" Then 'no case returned by stored proc
                    strMsg =
                        "No cases match your filtering criteria, or the selected case may be in use by another user or no longer awaiting locating."
                End If
            Catch ex As Exception 'error returned by stored proc
                strMsg = "There was an error retrieving this case:" & Environment.NewLine & Environment.NewLine &
                         ex.Message
                strCaption = "Error retrieving case"
            End Try
            If Not strMsg.Length.Equals(0) Then
                MessageBox.Show(strMsg, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If
        objCase = GetCase(strMPRID)

        If objCase IsNot Nothing Then
            Dim frmLoc As New frmLocatingMain(objCase, strMPRID)
            frmLoc.Show()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub MarkSupervisorCodes()

        Dim iNumLoc As Integer = 0
        Dim iNumSup As Integer = 0


        For Each row As DataGridViewRow In vwLocatingSelection.Rows
            If CType(row.Cells("SupervisorOnly").Value, Boolean) = True Then
                row.DefaultCellStyle.ForeColor = Color.Blue
                iNumSup += CType(row.Cells("# In Locating").Value, Integer)
            Else
                iNumLoc += CType(row.Cells("# In Locating").Value, Integer)
            End If
        Next
        lblNumLoc.Text = CType(iNumLoc, String)
        lblNumSup.Text = CType(iNumSup, String)
        lblNumTot.Text = CType(iNumLoc + iNumSup, String)
    End Sub

    Private Function GetNextMPRID() As String

        If vwLocatingSelection.SelectedRows.Count = 0 Then
            Return String.Empty
        End If

        Dim strMPRID As String = String.Empty
        Dim strStatus As String = String.Empty
        For i As Integer = 0 To vwLocatingSelection.SelectedRows.Count - 1
            If Not strStatus.Length.Equals(0) Then
                strStatus += ", "
            End If
            strStatus += vwLocatingSelection.SelectedRows(i).Cells("Status").Value.ToString
        Next

        Dim ErrorCode As Integer
        Dim cmdSQL As SqlCommand = New SqlCommand
        cmdSQL.Connection = New SqlConnection
        cmdSQL.Connection.ConnectionString = Project.ConnectionString
        cmdSQL.Connection.Open()

        cmdSQL.CommandText = "SMS_GetNextMPRIDInLocating"
        cmdSQL.CommandType = CommandType.StoredProcedure

        Try
            cmdSQL.Parameters.Clear()
            cmdSQL.Parameters.Add(New SqlParameter("@LocatingStatus", SqlDbType.VarChar, 255, ParameterDirection.Input,
                                                   True, 0, 0, "", DataRowVersion.Proposed, strStatus))
            cmdSQL.Parameters.Add(New SqlParameter("@GetOldest", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0,
                                                   "", DataRowVersion.Proposed, optOldest.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@EST", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "",
                                                   DataRowVersion.Proposed, chkEST.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@CST", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "",
                                                   DataRowVersion.Proposed, chkCST.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@MST", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "",
                                                   DataRowVersion.Proposed, chkMST.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@PST", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "",
                                                   DataRowVersion.Proposed, chkPST.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@TZOther", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0,
                                                   "", DataRowVersion.Proposed, chkOther.Checked))
            cmdSQL.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10,
                                                   0, "", DataRowVersion.Proposed, ErrorCode))

            Dim dr As SqlDataReader = cmdSQL.ExecuteReader()

            If dr.Read Then
                strMPRID = dr(0).ToString
            End If

            dr.Close()
            dr = Nothing

            ErrorCode = CType(cmdSQL.Parameters.Item("@ErrorCode").Value, Integer)

            If Not ErrorCode.Equals(0) Then
                Throw _
                    New Exception(
                        "Stored Procedure 'SMS_GetNextMPRIDInLocating' reported the ErrorCode: " & ErrorCode.ToString())
            End If

        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "SMS_GetNextMPRIDInLocating::Error occured." + Environment.NewLine + Environment.NewLine +
                    ex.Message, ex)

        Finally
            cmdSQL.Dispose()
        End Try

        Return strMPRID
    End Function

    Private Function GetCase(strMPRID As String) As [Case]

        Dim strMsg As String = "There was an error retrieving this case:" & Environment.NewLine & Environment.NewLine &
                               "The MPRID may be invalid, or it is no longer awaiting locating."
        Dim objPerson As Person = Nothing

        Try
            objPerson = New Person(strMPRID)
            'check that the case is in locating, or that the user is a supervisor
            If Not objPerson.LocatingStatus.Status.IsCaseInLocating AndAlso
               Not mblnLocSup Then
                MessageBox.Show(strMsg, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return Nothing
            End If
            Return New [Case](objPerson.CaseID.Value, False)

        Catch ex As Exception
            MessageBox.Show(strMsg, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End Try
    End Function

    Private Sub ShowDetails(Location As Point)

        If vwLocatingSelection.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row(s) to view Detail records for the status(es) selected.",
                            "Error retrieving Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim httimezones As Hashtable = New Hashtable()
        Dim Statuses(vwLocatingSelection.SelectedRows.Count - 1) As String

        For i As Integer = 0 To vwLocatingSelection.SelectedRows.Count - 1
            Statuses(i) = vwLocatingSelection.SelectedRows(i).Cells("Status").Value.ToString

            httimezones.Add(Statuses(i), "EST=" & chkEST.Checked & ";" &
                                         "CST=" & chkCST.Checked & ";" &
                                         "MST=" & chkMST.Checked & ";" &
                                         "PST=" & chkPST.Checked & ";" &
                                         "Other=" & chkOther.Checked)
        Next

        Dim frm As New frmLocatingSelectionDetail(Statuses, httimezones)
        frm.ShowDialog()

        Dim objCase As [Case] = Nothing
        Dim strMPRID As String = ""

        If frm.DialogResult = DialogResult.OK Then
            objCase = frm.SelectedCase
            strMPRID = frm.SelectedMPRID
        End If
        frm.Close()

        If objCase IsNot Nothing Then
            Dim frmLoc As New frmLocatingMain(objCase, strMPRID)
            frmLoc.Show()
        End If
    End Sub

#End Region
End Class