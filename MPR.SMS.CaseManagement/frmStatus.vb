'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports MPR.SMS.Data

Public Class frmStatus
    Inherits Form

#Region "Private Fields"

    Private ReadOnly bindingsourceStatus As New BindingSource
    Private dataAdapterStatus As New SqlDataAdapter
    Private IsDataChanged As Boolean = False
    Private IsDataError As Boolean = False
    Private mobjStatus As New Status
    Private ReadOnly cmdUpdateStatus As SqlCommand
    Private ReadOnly cmdInsertStatus As SqlCommand
    Private paramErrorCode As SqlParameter

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ComputerNameLabel.Text = My.Computer.Name
        'Me.UserLabel.Text = My.User.Name
        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        'Me.UserLabel.ForeColor = Color.Red
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Add/Update Status Codes"

        'AF 11/12/07 Added Update and Insert Commands so update can be done by users without db_datawriter access
        cmdUpdateStatus = New SqlCommand("wiz_tlkpStatus_Update", New SqlConnection(Project.ConnectionString))
        cmdUpdateStatus.CommandType = CommandType.StoredProcedure
        AddParameterstoCommand(cmdUpdateStatus)
        cmdInsertStatus = New SqlCommand("wiz_tlkpStatus_Insert", New SqlConnection(Project.ConnectionString))
        cmdInsertStatus.CommandType = CommandType.StoredProcedure
        AddParameterstoCommand(cmdInsertStatus)
    End Sub

    Sub AddParameterstoCommand(cmd As SqlCommand)
        cmd.Parameters.Add("@Code", SqlDbType.VarChar, 4, "Code")
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100, "Description")
        cmd.Parameters.Add("@AltCode", SqlDbType.VarChar, 50, "AltCode")
        cmd.Parameters.Add("@BlaiseReturnCode", SqlDbType.Char, 1, "BlaiseReturnCode")
        cmd.Parameters.Add("@StatusType", SqlDbType.VarChar, 50, "StatusType")
        cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1, "IsActive")
        cmd.Parameters.Add("@IsComplete", SqlDbType.Bit, 1, "IsComplete")
        cmd.Parameters.Add("@IsFinalStatus", SqlDbType.Bit, 1, "IsFinalStatus")
        cmd.Parameters.Add("@IsInterimStatus", SqlDbType.Bit, 1, "IsInterimStatus")
        cmd.Parameters.Add("@IsCATIStatus", SqlDbType.Bit, 1, "IsCATIStatus")
        cmd.Parameters.Add("@IsCAPIStatus", SqlDbType.Bit, 1, "IsCAPIStatus")
        cmd.Parameters.Add("@IsCAWIStatus", SqlDbType.Bit, 1, "IsCAWIStatus")
        cmd.Parameters.Add("@IsHardcopyStatus", SqlDbType.Bit, 1, "IsHardcopyStatus")
        cmd.Parameters.Add("@IsCaseInLocating", SqlDbType.Bit, 1, "IsCaseInLocating")
        cmd.Parameters.Add("@IsCaseInLocatingSupervisor", SqlDbType.Bit, 1, "IsCaseInLocatingSupervisor")
        cmd.Parameters.Add("@IsStatusAvailableInLocating", SqlDbType.Bit, 1, "IsStatusAvailableInLocating")
        cmd.Parameters.Add("@IsStatusAvailableInLocatingSupervisor", SqlDbType.Bit, 1,
                           "IsStatusAvailableInLocatingSupervisor")
        cmd.Parameters.Add("@IsSentToCATI", SqlDbType.Bit, 1, "IsSentToCATI")

        paramErrorCode = New SqlParameter("@ErrorCode", SqlDbType.Int, 8)
        paramErrorCode.Direction = ParameterDirection.Output
        cmd.Parameters.Add(paramErrorCode)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dgvStatus.DataSource = Me.bindingsourceStatus
        GetData("SELECT * FROM tlkpStatus")
        Me.tsbtnSave.Enabled = False
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) _
        Handles dgvStatus.CellValidating

        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "Code" Then
            If CType(e.FormattedValue, String).Length <> 4 Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The status code should be 4 characters long."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "Description" Then
            If CType(e.FormattedValue, String).Length > 100 Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The status description is too long. Maximum size is 100 characters."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "StatusType" Then
            If CType(e.FormattedValue, String).Length > 50 Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The status type is too long. Maximum size is 50 characters."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If

        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "IsCaseInLocatingSupervisor" Then
            If CType(e.FormattedValue, Boolean) And
               CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsFinalStatus").FormattedValue, Boolean) = True Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The final status can't be active or available in locating."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "IsCaseInLocating" Then
            If CType(e.FormattedValue, Boolean) And
               CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsFinalStatus").FormattedValue, Boolean) Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The final status can't be active or available in locating."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "IsStatusAvailableInLocating" Then
            If CType(e.FormattedValue, Boolean) And
               CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsFinalStatus").FormattedValue, Boolean) Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The final status can't be active or available in locating."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "IsStatusAvailableInLocatingSupervisor" Then
            If CType(e.FormattedValue, Boolean) And
               CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsFinalStatus").FormattedValue, Boolean) Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The final status can't be active or available in locating."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
        If Me.dgvStatus.Columns(e.ColumnIndex).Name = "IsFinalStatus" Then
            If (CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsCaseInLocatingSupervisor").FormattedValue, Boolean) Or
                CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsCaseInLocating").FormattedValue, Boolean) Or
                CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsStatusAvailableInLocating").FormattedValue, Boolean) Or
                CType(Me.dgvStatus.Rows(e.RowIndex).Cells.Item("IsStatusAvailableInLocatingSupervisor").FormattedValue,
                      Boolean)) And
               CType(e.FormattedValue, Boolean) Then
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText =
                    "The final status can't be active or available in locating."
            Else
                Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvStatus.CellValueChanged
        IsDataChanged = True
        Me.tsbtnSave.Enabled = True
        Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGoldenrodYellow
        Me.dgvStatus.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
    End Sub

    Private Sub frmStatus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (ConfirmExit() = DialogResult.No)
    End Sub

    Private Sub tsbtnSave_Click(sender As Object, e As EventArgs) Handles tsbtnSave.Click
        RemoveRowErrorText()
        Data_Validation()
        If IsDataError Then
            MessageBox.Show("Data validation error, please check data and correct", Project.Name)
            Exit Sub
        Else
            Try
                Me.Validate()
                Me.bindingsourceStatus.EndEdit()
                Me.dataAdapterStatus.Update(CType(Me.bindingsourceStatus.DataSource, DataTable))
                IsDataChanged = False
                Me.tsbtnSave.Enabled = False
                MessageBox.Show("Record updated successfully", Project.Name)
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.Name)
            End Try
        End If
    End Sub

    Private Sub tsbtnRules_Click(sender As Object, e As EventArgs) Handles tsbtnRules.Click

        If IsDataChanged Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show("You have unsaved changes - are you sure you want to view rules? ", Project.Name,
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2)

            If dlgResult = DialogResult.No Then
                Return
            End If
        End If
        Dim frmStatusRule As New frmStatusRule()
        frmStatusRule.Show()
    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click

        Me.Close()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub GetData(selectcommand As String)

        Try
            Me.dataAdapterStatus = New SqlDataAdapter(selectcommand, Project.ConnectionString)

            'AF 11/12/07 these 2 lines force these stored procs to be called instead of default updates
            dataAdapterStatus.UpdateCommand = cmdUpdateStatus
            dataAdapterStatus.InsertCommand = cmdInsertStatus

            Dim table As New DataTable
            Me.dataAdapterStatus.Fill(table)
            Me.bindingsourceStatus.DataSource = table

            Me.dgvStatus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Me.dgvStatus.Columns(0).Frozen = True

            'AF 11/15/07 Can't make this read only because you need to be able to insert new codes.
            'Me.dgvStatus.Columns(0).ReadOnly = True
            Me.dgvStatus.Columns(1).Frozen = True
            Me.dgvStatus.SelectionMode = DataGridViewSelectionMode.CellSelect
            Me.dgvStatus.MultiSelect = False
            'Me.dgvStatus.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            'Me.dgvStatus.AllowUserToAddRows = False
            Me.dgvStatus.AllowUserToDeleteRows = False
            'data grid view count new row also, since add rows are allowed
            Me.tsslTotalRecords.Text = "Total Records: " & Me.dgvStatus.Rows.Count - 1
            'Row Header Width = 41 and Row Template Height = 21 required to display error icon.
            Me.dgvStatus.RowHeadersWidth = 41
            Me.dgvStatus.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            'Me.dgvStatus.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Catch ex As Exception
            MessageBox.Show("Error Loading Status Data")
        End Try
    End Sub

    Private Sub Data_Validation()

        For Each row As DataGridViewRow In Me.dgvStatus.Rows
            If Not row.IsNewRow Then
                If CType(row.Cells("Code").FormattedValue, String).Length <> 4 Or
                   CType(row.Cells("Description").FormattedValue, String).Length > 100 Or
                   CType(row.Cells("StatusType").FormattedValue, String).Length > 50 Or
                   (CType(row.Cells("IsFinalStatus").FormattedValue, Boolean) And
                    (CType(row.Cells("IsCaseInLocating").FormattedValue, Boolean) Or
                     CType(row.Cells("IsStatusAvailableInLocating").FormattedValue, Boolean))) Then
                    'CType(row.Cells("IsCaseInLocatingSupervisor").FormattedValue, Boolean) Or _
                    'CType(row.Cells("IsStatusAvailableInLocatingSupervisor").FormattedValue, Boolean) Or _
                    row.Selected = True
                    row.ErrorText = "Error in this row, hover column error to see detail."
                    IsDataError = True
                    If CType(row.Cells("Code").FormattedValue, String).Length <> 4 Then
                        row.Cells("Code").ErrorText = "The status code should be 4 characters long."
                    End If
                    If CType(row.Cells("Description").FormattedValue, String).Length > 100 Then
                        row.Cells("Description").ErrorText =
                            "The status description is too long. Maximum size is 100 characters."
                    End If
                    If CType(row.Cells("StatusType").FormattedValue, String).Length > 50 Then
                        row.Cells("StatusType").ErrorText =
                            "The status type is too long. Maximum size is 50 characters."
                    End If
                    If CType(row.Cells("IsFinalStatus").FormattedValue, Boolean) And
                       CType(row.Cells("IsCaseInLocatingSupervisor").FormattedValue, Boolean) Then
                        row.Cells("IsFinalStatus").ErrorText =
                            "The final status can't be active or available in locating."
                        row.Cells("IsCaseInLocatingSupervisor").ErrorText =
                            "The final status can't be active or available in locating."
                    End If
                    If CType(row.Cells("IsFinalStatus").FormattedValue, Boolean) And
                       CType(row.Cells("IsCaseInLocating").FormattedValue, Boolean) Then
                        row.Cells("IsFinalStatus").ErrorText =
                            "The final status can't be active or available in locating."
                        row.Cells("IsCaseInLocating").ErrorText =
                            "The final status can't be active or available in locating."
                    End If
                    If CType(row.Cells("IsFinalStatus").FormattedValue, Boolean) And
                       CType(row.Cells("IsStatusAvailableInLocating").FormattedValue, Boolean) Then
                        row.Cells("IsFinalStatus").ErrorText =
                            "The final status can't be active or available in locating."
                        row.Cells("IsStatusAvailableInLocating").ErrorText =
                            "The final status can't be active or available in locating."
                    End If
                    If CType(row.Cells("IsFinalStatus").FormattedValue, Boolean) And
                       CType(row.Cells("IsStatusAvailableInLocatingSupervisor").FormattedValue, Boolean) Then
                        row.Cells("IsFinalStatus").ErrorText =
                            "The final status can't be active or available in locating."
                        row.Cells("IsStatusAvailableInLocatingSupervisor").ErrorText =
                            "The final status can't be active or available in locating."
                    End If

                End If
            End If
        Next
    End Sub

    Private Sub RemoveRowErrorText()

        For Each row As DataGridViewRow In Me.dgvStatus.Rows
            row.ErrorText = ""
            Dim I As Integer
            For I = 0 To row.Cells.Count - 1
                row.Cells(I).ErrorText = ""
            Next

            IsDataError = False
        Next
    End Sub

    Private Function ConfirmExit() As DialogResult

        If IsDataChanged Or IsDataError Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show("You have unsaved changes - are you sure you want to exit? ", Project.Name,
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2)

            If dlgResult = DialogResult.No Then
                Return DialogResult.No
            Else
                Return DialogResult.Yes
            End If
        Else
            Return DialogResult.Yes
        End If
    End Function

#End Region
End Class
