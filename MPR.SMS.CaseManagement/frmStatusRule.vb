'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Security.Principal
Imports MPR.SMS.Data

Public Class frmStatusRule
    Inherits Form

#Region "Private Fields"

    Private ReadOnly bsStatusUpdateRule As New BindingSource
    Private ReadOnly bsMissing As New BindingSource
    Private ReadOnly bsOverride As New BindingSource
    Private ReadOnly bsNoAction As New BindingSource
    Private ReadOnly bsError As New BindingSource

    Private daStatusUpdateRule As New SqlDataAdapter
    Private daMissing As New SqlDataAdapter
    Private daOverride As New SqlDataAdapter
    Private daNoAction As New SqlDataAdapter
    Private daError As New SqlDataAdapter
    Private ReadOnly cmdUpdateStatusRule As SqlCommand
    Private ReadOnly cmdInsertStatusRule As SqlCommand
    Private ReadOnly cmdUpdateSelectedStatus As SqlCommand
    Private paramErrorCode As SqlParameter

    Private IsDirty As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ComputerNameLabel.Text = My.Computer.Name
        UserLabel.Text = WindowsIdentity.GetCurrent.Name

        btnAddOverride.Enabled = False
        btnAddNoAction.Enabled = False
        btnAddError.Enabled = False
        btnRemoveOverride.Enabled = False
        btnRemoveNoAction.Enabled = False
        btnRemoveError.Enabled = False

        btnUpdate.Enabled = False

        dgvStatusUpdateRule.Visible = False
        lblTotalRules.Visible = False
        txtTotalRules.Visible = False

        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Add/Update Status Rules"

        'AF 11/12/07 Added Update and Insert Commands so update can be done by users without db_datawriter access
        cmdUpdateStatusRule = New SqlCommand("wiz_tlkpStatusUpdateRule_Update",
                                             New SqlConnection(Project.ConnectionString))
        cmdUpdateStatusRule.CommandType = CommandType.StoredProcedure
        AddParameterstoCommand(cmdUpdateStatusRule)
        cmdInsertStatusRule = New SqlCommand("wiz_tlkpStatusUpdateRule_Insert",
                                             New SqlConnection(Project.ConnectionString))
        cmdInsertStatusRule.CommandType = CommandType.StoredProcedure
        AddParameterstoCommand(cmdInsertStatusRule)

        'AF 11/15/07 Added Update Command so we can update the tmpfile with "Selected"
        cmdUpdateSelectedStatus = New SqlCommand("SMS_UpdateSelectedMissingRules",
                                                 New SqlConnection(Project.ConnectionString))
        cmdUpdateSelectedStatus.CommandType = CommandType.StoredProcedure
        cmdUpdateSelectedStatus.Parameters.Add("@Selected", SqlDbType.Bit, 1, "Selected")
        cmdUpdateSelectedStatus.Parameters.Add("@ID", SqlDbType.Int, 8, "ID")
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub TabAdd_Enter(sender As Object, e As EventArgs) Handles TabAdd.Enter

        If BackgroundWorker.IsBusy Then
            TabRule.SelectedTab = TabRule.TabPages("tabUpdate")
        End If

        'If dgvMissing.Rows.Count = 0 Then
        '    MessageBox.Show("No missing rules to add", Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    'Else
        '    '    dgvMissing.Visible = True
        '    '    dgvOverride.Visible = True
        '    '    dgvNoAction.Visible = True
        '    '    dgvError.Visible = True
        '    '    txtTotalMissing.Visible = True
        '    '    txtTotalOverride.Visible = True
        '    '    txtTotalNoAction.Visible = True
        '    '    txtTotalError.Visible = True
        '    '    btnAddOverride.Visible = True
        '    '    btnRemoveOverride.Visible = True
        '    '    btnAddNoAction.Visible = True
        '    '    btnRemoveNoAction.Visible = True
        '    '    btnAddError.Visible = True
        '    '    btnRemoveError.Visible = True
        '    '    lblMissingRecords.Visible = True
        '    '    lblOverrideRecords.Visible = True
        '    '    lblOverride.Visible = True
        '    '    lblNoactionRecords.Visible = True
        '    '    lblNoAction.Visible = True
        '    '    lblErrorRecords.Visible = True
        '    '    lblError.Visible = True
        '    '    cbSelectAll.Visible = True
        'End If
    End Sub

    Private Sub btnAddOverride_Click(sender As Object, e As EventArgs) Handles btnAddOverride.Click

        Cursor = Cursors.WaitCursor
        daMissing.Update(CType(bsMissing.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForOverrideRules")
        DisplayData()
        cbSelectAll.Checked = False
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRemoveOverride_Click(sender As Object, e As EventArgs) Handles btnRemoveOverride.Click

        Cursor = Cursors.WaitCursor
        daOverride.Update(CType(bsOverride.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForMissingRules")
        DisplayData()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAddNoAction_Click(sender As Object, e As EventArgs) Handles btnAddNoAction.Click

        Cursor = Cursors.WaitCursor
        daMissing.Update(CType(bsMissing.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForNoActionRules")
        DisplayData()
        cbSelectAll.Checked = False
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRemoveNoAction_Click(sender As Object, e As EventArgs) Handles btnRemoveNoAction.Click

        Cursor = Cursors.WaitCursor
        daNoAction.Update(CType(bsNoAction.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForMissingRules")
        DisplayData()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAddError_Click(sender As Object, e As EventArgs) Handles btnAddError.Click

        Cursor = Cursors.WaitCursor
        daMissing.Update(CType(bsMissing.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForErrorRules")
        DisplayData()
        cbSelectAll.Checked = False
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRemoveError_Click(sender As Object, e As EventArgs) Handles btnRemoveError.Click

        Cursor = Cursors.WaitCursor
        daError.Update(CType(bsError.DataSource, DataTable))
        ExecuteStoredProc("SMS_UpdateForMissingRules")
        DisplayData()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvMissing_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvMissing.CellValueChanged

        btnAddOverride.Enabled = True
        btnAddNoAction.Enabled = True
        btnAddError.Enabled = True
        btnRemoveOverride.Enabled = False
        btnRemoveNoAction.Enabled = False
        btnRemoveError.Enabled = False
    End Sub

    Private Sub dgvOverride_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvOverride.CellValueChanged

        btnRemoveOverride.Enabled = True
    End Sub

    Private Sub dgvNoAction_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvNoAction.CellValueChanged

        btnRemoveNoAction.Enabled = True
    End Sub

    Private Sub dgvError_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvError.CellValueChanged

        btnRemoveError.Enabled = True
    End Sub

    Private Sub cbSelectAll_Click(sender As Object, e As EventArgs) Handles cbSelectAll.Click

        Cursor = Cursors.WaitCursor
        For Each row As DataGridViewRow In dgvMissing.Rows
            dgvMissing.Rows(row.Index).Cells(0).Value = cbSelectAll.Checked
            If cbSelectAll.Checked Then dgvMissing.Select()
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        dgvStatusUpdateRule.ClearSelection()
        dgvStatusUpdateRule.DataSource = bsStatusUpdateRule
        GetStatusUpdateRuleData()
        dgvStatusUpdateRule.Visible = (dgvStatusUpdateRule.Rows.Count > 0)
        lblTotalRules.Visible = (dgvStatusUpdateRule.Rows.Count > 0)
        txtTotalRules.Visible = (dgvStatusUpdateRule.Rows.Count > 0)

        If dgvStatusUpdateRule.Rows.Count = 0 Then
            MessageBox.Show("No rules for this criteria", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvStatusUpdateRule_CellEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvStatusUpdateRule.CellEnter

        If dgvStatusUpdateRule.CurrentCell.EditType.ToString = "System.Windows.Forms.DataGridViewComboBoxEditingControl" _
            Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub dgvStatusUpdateRule_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvStatusUpdateRule.CellValueChanged

        btnUpdate.Enabled = True
        btnGo.Enabled = False
        IsDirty = True

        Select Case dgvStatusUpdateRule.Rows(e.RowIndex).Cells(3).FormattedValue.ToString
            Case "Override"
                dgvStatusUpdateRule.Rows(e.RowIndex).Cells("ResultStatus").Value =
                    Me.dgvStatusUpdateRule.Rows(e.RowIndex).Cells("NewStatus").Value
            Case Else 'No Action, Error
                dgvStatusUpdateRule.Rows(e.RowIndex).Cells("ResultStatus").Value =
                    Me.dgvStatusUpdateRule.Rows(e.RowIndex).Cells("ExistingStatus").Value
        End Select
    End Sub

    Private Sub frmStatusRule_Load(sender As Object, e As EventArgs) Handles Me.Load

        BackgroundWorker.RunWorkerAsync()


        FillComboBoxStatusCodes()
        GetStatusUpdateRuleData()
    End Sub

    Private Sub frmStatusRule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmExit() = DialogResult.No)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand("SMS_InsertStatusUpdateRules", conn)
        Cursor = Cursors.WaitCursor
        Try
            Validate()

            bsStatusUpdateRule.EndEdit()
            bsMissing.EndEdit()
            bsOverride.EndEdit()
            bsNoAction.EndEdit()
            bsError.EndEdit()

            daStatusUpdateRule.Update(CType(bsStatusUpdateRule.DataSource, DataTable))

            IsDirty = False
            btnGo.Enabled = True
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.ExecuteNonQuery()

            DisplayData()
            btnUpdate.Enabled = False
            IsDirty = False

            MessageBox.Show("Record updated successfully", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Cursor = Cursors.Default

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click

        Me.Close()
    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker.DoWork

        CreateMissingRules()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) _
        Handles BackgroundWorker.RunWorkerCompleted

        DisplayData()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        Dim frm As New frmStatusRuleCopy
        frm.ShowDialog()

        BackgroundWorker.RunWorkerAsync()

        frm.Dispose()
    End Sub

#End Region

#Region "Private Methods"

    Sub AddParameterstoCommand(cmd As SqlCommand)
        cmd.Parameters.Add("@StatusUpdateRuleID", SqlDbType.Int, 8, "StatusUpdateRuleID")
        cmd.Parameters.Add("@ExistingStatus", SqlDbType.VarChar, 4, "ExistingStatus")
        cmd.Parameters.Add("@NewStatus", SqlDbType.VarChar, 4, "NewStatus")
        cmd.Parameters.Add("@ResultStatus", SqlDbType.VarChar, 4, "ResultStatus")
        cmd.Parameters.Add("@ResultID", SqlDbType.Int, 8, "ResultID")
        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50, "CreatedBy")
        cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime, 8, "CreatedON")

        paramErrorCode = New SqlParameter("@ErrorCode", SqlDbType.Int, 8)
        paramErrorCode.Direction = ParameterDirection.Output
        cmd.Parameters.Add(paramErrorCode)
    End Sub

    'fills the comboboxes with all ACTIVE status codes
    Private Sub FillComboBoxStatusCodes()

        cboExistingStatus.Items.Clear()
        cboNewStatus.Items.Clear()

        cboExistingStatus.DisplayMember = "DisplayName"
        cboNewStatus.DisplayMember = "DisplayName"

        cboExistingStatus.ValueMember = "Code"
        cboNewStatus.ValueMember = "Code"

        Dim objStatus As New Status

        'include a blank default value
        objStatus.Code = New SqlString("")
        cboExistingStatus.Items.Add(objStatus)
        cboNewStatus.Items.Add(objStatus)

        For Each objStatus In Project.Statuses
            If objStatus.IsActive Then
                cboExistingStatus.Items.Add(objStatus)
                cboNewStatus.Items.Add(objStatus)
            End If
        Next
        cboExistingStatus.SelectedIndex = 0
        cboNewStatus.SelectedIndex = 0
    End Sub

    'fills the StatusUpdateRules grid with the rules matching the selected
    'status codes from the comboboxes
    Private Sub GetStatusUpdateRuleData()

        Try
            Dim strExistingStatus As String = CType(cboExistingStatus.SelectedItem, Status).Code.ToString
            Dim strNewStatus As String = CType(cboNewStatus.SelectedItem, Status).Code.ToString

            Dim strSQL As String =
                    "SELECT ExistingStatus, NewStatus, ResultStatus, ResultID, StatusUpdateRuleID, CreatedOn, CreatedBy FROM tlkpStatusUpdateRule "
            If strExistingStatus <> "" And strNewStatus <> "" Then
                strSQL += "WHERE ExistingStatus = " & strExistingStatus & " And NewStatus = " & strNewStatus
            ElseIf strExistingStatus <> "" And strNewStatus = "" Then
                strSQL += "WHERE ExistingStatus = " & strExistingStatus
            ElseIf strExistingStatus = "" And strNewStatus <> "" Then
                strSQL += "WHERE NewStatus = " & strNewStatus
            Else
                strSQL += "WHERE 1 <> 1"
            End If
            strSQL += "ORDER BY ExistingStatus, NewStatus"

            daStatusUpdateRule = New SqlDataAdapter(strSQL, Project.ConnectionString)

            'AF 11/12/07 these 2 lines force these stored procs to be called instead of default updates
            daStatusUpdateRule.UpdateCommand = cmdUpdateStatusRule
            daStatusUpdateRule.InsertCommand = cmdInsertStatusRule


            Dim table As New DataTable
            daStatusUpdateRule.Fill(table)
            bsStatusUpdateRule.DataSource = table

            If dgvStatusUpdateRule.Columns.Count > 0 Then

                dgvStatusUpdateRule.Columns(2).Frozen = True
                dgvStatusUpdateRule.Columns(0).Width = 110
                dgvStatusUpdateRule.Columns(0).ReadOnly = True
                dgvStatusUpdateRule.Columns(1).Width = 110
                dgvStatusUpdateRule.Columns(1).ReadOnly = True
                dgvStatusUpdateRule.Columns(2).Width = 110
                dgvStatusUpdateRule.Columns(2).ReadOnly = True
                dgvStatusUpdateRule.Columns(4).Width = 110
                dgvStatusUpdateRule.Columns(4).ReadOnly = True
                dgvStatusUpdateRule.Columns(5).Visible = False
                dgvStatusUpdateRule.Columns(6).Visible = False
                dgvStatusUpdateRule.SelectionMode = DataGridViewSelectionMode.CellSelect
                dgvStatusUpdateRule.MultiSelect = False
                dgvStatusUpdateRule.AllowUserToAddRows = False
                dgvStatusUpdateRule.AllowUserToDeleteRows = False
                dgvStatusUpdateRule.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                'dgvStatusUpdateRule.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
                dgvStatusUpdateRule.Columns("StatusUpdateRuleID").Visible = False

                ' Remove the auto-generated ResultID column.
                dgvStatusUpdateRule.Columns.Remove("ResultID")

                ' Create a list column for the ResultID.
                Dim List As New DataGridViewComboBoxColumn()
                List.DisplayIndex = 3
                List.HeaderText = "Description"

                ' This column is bound to the ResultID field.
                List.DataPropertyName = "ResultID"

                Dim dataAdapterResult As SqlDataAdapter = New SqlDataAdapter("Select * from tlkpStatusResult",
                                                                             Project.ConnectionString)

                Dim dtResult As New DataTable
                dataAdapterResult.Fill(dtResult)
                List.DataSource = dtResult
                List.DisplayMember = "Description"
                List.ValueMember = "ResultID"

                ' Add the column.
                dgvStatusUpdateRule.Columns.Add(List)
            End If

            txtTotalRules.Text = dgvStatusUpdateRule.Rows.Count.ToString

        Catch ex As Exception
            'MessageBox.Show("Error Loading Status Update Rule Data", Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub SetGrid(grd As DataGridView)

        Try
            If grd.Columns.Count > 0 Then
                With grd
                    .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
                    .Columns(0).Frozen = True
                    .Columns(0).Width = 55
                    .Columns(1).Width = 75
                    .Columns(1).ReadOnly = True
                    .Columns(2).Width = 65
                    .Columns(2).ReadOnly = True
                    .Columns(3).Width = 35
                    .Columns(3).ReadOnly = True
                    .SelectionMode = DataGridViewSelectionMode.CellSelect
                    .MultiSelect = False
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                    '.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Error Loading Rules Data", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GetMissingData()

        Try
            Dim strSQL As String =
                    "SELECT Selected, ExistingStatus, NewStatus, ID FROM tmpMissingStatusUpdateRule WHERE resultid IS NULL"

            daMissing = New SqlDataAdapter(strSQL, Project.ConnectionString)

            'AF 11/15/07 this lines forces this stored proc to be called instead of default update statement
            daMissing.UpdateCommand = cmdUpdateSelectedStatus

            Dim table As New DataTable
            daMissing.Fill(table)
            bsMissing.DataSource = table

            SetGrid(dgvMissing)
            txtTotalMissing.Text = dgvMissing.Rows.Count.ToString

        Catch ex As Exception
            MessageBox.Show("Error Loading Rules Data (Missing)", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GetOverrideData()

        Try
            Dim strSQL As String =
                    "SELECT Selected, ExistingStatus, NewStatus, ResultStatus, ID FROM tmpMissingStatusUpdateRule WHERE resultid = 0"

            daOverride = New SqlDataAdapter(strSQL, Project.ConnectionString)

            'AF 11/15/07 this lines forces this stored proc to be called instead of default update statement
            daOverride.UpdateCommand = cmdUpdateSelectedStatus

            Dim table As New DataTable
            daOverride.Fill(table)
            bsOverride.DataSource = table

            SetGrid(dgvOverride)
            txtTotalOverride.Text = dgvOverride.Rows.Count.ToString

        Catch ex As Exception
            MessageBox.Show("Error Loading Rules Data (Override)", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GetNoActionData()

        Try
            Dim strSQL As String =
                    "SELECT Selected, ExistingStatus, NewStatus, ResultStatus, ID FROM tmpMissingStatusUpdateRule WHERE resultid = 1"

            daNoAction = New SqlDataAdapter(strSQL, Project.ConnectionString)

            'AF 11/15/07 this lines forces this stored proc to be called instead of default update statement
            daNoAction.UpdateCommand = cmdUpdateSelectedStatus

            Dim table As New DataTable
            daNoAction.Fill(table)
            bsNoAction.DataSource = table

            SetGrid(dgvNoAction)
            txtTotalNoAction.Text = dgvNoAction.Rows.Count.ToString

        Catch ex As Exception
            MessageBox.Show("Error Loading Rules Data (No Action)", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GetErrorData()

        Try
            Dim strSQL As String =
                    "SELECT Selected, ExistingStatus, NewStatus, ResultStatus, ID FROM tmpMissingStatusUpdateRule WHERE resultid = 2"

            daError = New SqlDataAdapter(strSQL, Project.ConnectionString)

            'AF 11/15/07 this lines forces this stored proc to be called instead of default update statement
            daError.UpdateCommand = cmdUpdateSelectedStatus

            Dim table As New DataTable
            daError.Fill(table)
            bsError.DataSource = table

            SetGrid(dgvError)
            txtTotalError.Text = dgvError.Rows.Count.ToString

        Catch ex As Exception
            MessageBox.Show("Error Loading Rules Data (Error)", Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CreateMissingRules()

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand("SMS_MissingRules", conn)
        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub DisplayData()

        dgvMissing.DataSource = bsMissing
        dgvOverride.DataSource = bsOverride
        dgvNoAction.DataSource = bsNoAction
        dgvError.DataSource = bsError

        GetMissingData()
        GetOverrideData()
        GetNoActionData()
        GetErrorData()

        If dgvOverride.Rows.Count > 0 Or
           dgvNoAction.Rows.Count > 0 Or
           dgvError.Rows.Count > 0 Then
            btnUpdate.Enabled = True
            IsDirty = True
        End If
    End Sub

    Private Sub ExecuteStoredProc(strStoredProc As String)

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand(strStoredProc, conn)
        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(
                "Error executing stored proc: " & strStoredProc & Environment.NewLine & Environment.NewLine & ex.Message,
                Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Function ConfirmExit() As DialogResult

        If IsDirty Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show("You have unsaved changes - are you sure you want to exit? ", Project.ShortName,
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