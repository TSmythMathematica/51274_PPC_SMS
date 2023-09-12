'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports MPR.SMS.Data
Imports MPR.SMS.UserControls

Public Class frmSurveyResponseByMPRID

#Region "Private Fields"

    Private IsDataChanged As Boolean = False
    Private IsDataError As Boolean = False
    Private List As New DataGridViewComboBoxColumn()
    Private List1 As New DataGridViewComboBoxColumn()
    Private conn As SqlConnection
    Private cmdSQL As SqlCommand
    Private mintStatusIndex As Integer
    Private ReadOnly strSurType As String = String.Empty
    Private ReadOnly intInstrumentTypeID As Integer = 0
    Private ReadOnly MPRID As String = String.Empty
    Private ReadOnly mblnReadOnly As Boolean
    Private strOldNotes As String
    Private strNewNotes As String
    Private intResponseID As Integer
    Private blnRefreshGrid As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Update Survey Preliminary Response Data "
    End Sub

    Public Sub New(strMPRID As String, strSurveyType As String, intInstTypeID As Integer, IsReadOnly As Boolean)
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Update Survey Preliminary Response Data "

            MPRID = strMPRID
            mblnReadOnly = IsReadOnly

            strSurType = strSurveyType
            intInstrumentTypeID = intInstTypeID

            Me.CenterToScreen()
            Me.Text = Me.Text & " - " & strSurType

            DisplayGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error getting data..", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmSurveyResponseByMPRID_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Cursor = Cursors.WaitCursor
        DeleteSRDEELockRecord(MPRID, Me.UserLabel.Text, intInstrumentTypeID)
        Cursor = Cursors.Default
    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click

        Me.Close()
    End Sub

    Private Sub dgvResponseUpdate_CellEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvResponseUpdate.CellEnter

        If _
            Me.dgvResponseUpdate.CurrentCell.EditType.ToString =
            "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub dgvResponseUpdate_DoubleClick(sender As Object, e As EventArgs) Handles dgvResponseUpdate.DoubleClick

        Dim strMPRID As String = String.Empty
        Dim strQuestionNum As String = String.Empty
        Dim strValue As String = String.Empty
        Dim strNotes As String = String.Empty
        Dim strDescription As String = String.Empty
        Dim strVariable As String = String.Empty
        Dim strVariableID As String = String.Empty
        Dim strMode As String = String.Empty
        Dim strCreatedBy As String = String.Empty
        Dim dtCreatedOn As String = String.Empty
        Dim strLastModifiedBy As String = String.Empty
        Dim dtLastModifiedOn As String = String.Empty
        Dim strValueAllowed As String = String.Empty
        Dim strMessage As String = String.Empty

        Dim dataRow As DataRow = CType(dgvResponseUpdate.SelectedRows(0).DataBoundItem, DataRowView).Row()

        strMPRID = dataRow.Item("MPRID").ToString
        If dataRow.Item("QuestionNumber").ToString Is DBNull.Value Then
            strQuestionNum = ""
        Else
            strQuestionNum = dataRow.Item("QuestionNumber").ToString
        End If
        If dataRow.Item("Value").ToString Is DBNull.Value Then
            strValue = ""
        Else
            strValue = dataRow.Item("Value").ToString
        End If
        If dataRow.Item("Notes").ToString Is DBNull.Value Then
            strNotes = ""
        Else
            strNotes = dataRow.Item("Notes").ToString
        End If
        If dataRow.Item("Description").ToString Is DBNull.Value Then
            strDescription = ""
        Else
            strDescription = dataRow.Item("Description").ToString
        End If
        If dataRow.Item("Variable").ToString Is DBNull.Value Then
            strVariable = ""
        Else
            strVariable = dataRow.Item("Variable").ToString
        End If
        If dataRow.Item("VariableID").ToString Is DBNull.Value Then
            strVariableID = ""
        Else
            strVariableID = dataRow.Item("VariableID").ToString
        End If
        If dataRow.Item("Mode").ToString Is DBNull.Value Then
            strMode = ""
        Else
            strMode = dataRow.Item("Mode").ToString
        End If
        If dataRow.Item("CreatedBy").ToString Is DBNull.Value Then
            strCreatedBy = ""
        Else
            strCreatedBy = dataRow.Item("CreatedBy").ToString
        End If
        If dataRow.Item("CreatedOn").ToString Is DBNull.Value Then
            dtCreatedOn = ""
        Else
            dtCreatedOn = dataRow.Item("CreatedOn").ToString
        End If
        If dataRow.Item("LastModifiedBy").ToString Is DBNull.Value Then
            strLastModifiedBy = ""
        Else
            strLastModifiedBy = dataRow.Item("LastModifiedBy").ToString
        End If

        If dataRow.Item("LastModifiedOn").ToString Is DBNull.Value Then
            dtLastModifiedOn = ""
        Else
            dtLastModifiedOn = dataRow.Item("LastModifiedOn").ToString
        End If
        'Dim intRnd As Integer = CInt(dataRow.Item("Round"))
        intResponseID = CInt(dataRow.Item("PreResponseID"))

        Dim IsSupervisor As Boolean = GetSRDEESupervisor(UserLabel.Text)
        If IsSupervisor Then
            If dataRow.Item("AllowedValueForSAS").ToString Is DBNull.Value Then
                strValueAllowed = ""
            Else
                strValueAllowed = dataRow.Item("AllowedValueForSAS").ToString
            End If
        Else
            If dataRow.Item("AllowedValue").ToString Is DBNull.Value Then
                strValueAllowed = ""
            Else
                strValueAllowed = dataRow.Item("AllowedValue").ToString
            End If
        End If

        If dataRow.Item("Message").ToString Is DBNull.Value Then
            strMessage = ""
        Else
            strMessage = dataRow.Item("Message").ToString
        End If

        If mblnReadOnly Then
            MessageBox.Show(
                "This facility is unavailable for editing because it is locked by someone else or you have only Read Only permission.",
                Project.ShortName & " - Locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim _
                frm As _
                    New frmSurveyResponse(strMPRID, strQuestionNum, strValue, strNotes, strVariable, strMode,
                                          strVariableID, strDescription,
                                          strCreatedBy, dtCreatedOn, strLastModifiedBy, dtLastModifiedOn, intResponseID,
                                          strValueAllowed,
                                          strSurType, intInstrumentTypeID, "By MPRID", UserLabel.Text, strMessage)
            frm.ShowDialog()
            Me.blnRefreshGrid = True
            DisplayGrid()
        End If
    End Sub

    Private Sub dgvResponseUpdate_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvResponseUpdate.MouseClick

        Dim dataRow As DataRow = CType(dgvResponseUpdate.SelectedRows(0).DataBoundItem, DataRowView).Row()
        Dim intPreResponseID As Integer = CInt(dataRow.Item("PreResponseID").ToString)

        If e.Button = MouseButtons.Right Then

            Dim frm As New frmDisplayHistory("Survey Preliminary Response Data", intPreResponseID, strSurType)
            frm.Width = Me.Width
            frm.Location = New Point(Me.dgvResponseUpdate.Parent.PointToScreen(Me.dgvResponseUpdate.Parent.Location).X,
                                     Cursor.Position.Y + 12)
            frm.ShowDialog()

        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayGrid()
        Try
            tsMPRID.Text = "MPRID : " & MPRID
            Cursor = Cursors.WaitCursor
            If Me.blnRefreshGrid = False Then
                AddSRDEELockRecord(MPRID, Me.UserLabel.Text, intInstrumentTypeID)
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Project.ConnectionString,
                                                         CommandType.StoredProcedure, "SRDEE_ByMPRIDUserName",
                                                         New SqlParameter("@MPRID", MPRID),
                                                         New SqlParameter("@UserName", Me.UserLabel.Text),
                                                         New SqlParameter("@InstrumentTypeID", Me.intInstrumentTypeID))

            Me.dgvResponseUpdate.DataSource = ds.Tables(0)
            With dgvResponseUpdate

                .ReadOnly = True
                .Columns("MPRID").Visible = False
                .Columns("QuestionNumber").Frozen = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .MultiSelect = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 20

                If .Rows.Count > 0 Then
                    .Rows(0).Selected = True
                End If

            End With

            Me.TotalRecordsLabel.Text = "Total Records: " & Me.dgvResponseUpdate.Rows.Count
            Me.tsbtnSave.Enabled = False
            Me.blnRefreshGrid = False
            ds.Dispose()
            Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub

#End Region
End Class