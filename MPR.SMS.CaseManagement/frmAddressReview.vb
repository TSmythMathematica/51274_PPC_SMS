'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Security.Principal
Imports MPR.SMS.Data
Imports MPR.SMS.DataQuality
Imports MPR.SMS.DocumentProcessing


Public Class frmAddressReview

#Region "Private Fields"

    Private ReadOnly bindingsourceAddressReview As New BindingSource
    Private dataAdapterAddressReview As New SqlDataAdapter
    Private IsDataChanged As Boolean = False
    Private IsDataError As Boolean = False
    Private ReadOnly List As New DataGridViewComboBoxColumn()
    Private conn As SqlConnection
    Private cmdSQL As SqlCommand
    Private mintStatusIndex As Integer
    Private ReadOnly cmdUpdateAddressReview As SqlCommand
    Private paramErrorCode As SqlParameter

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Incentive Payment Address Review "
        Me.WindowState = FormWindowState.Maximized

        'AF 12/13/07 Added Update Command so update can be done by users without db_datawriter access
        cmdUpdateAddressReview = New SqlCommand("SMS_UpdateAddressReview", New SqlConnection(Project.ConnectionString))
        cmdUpdateAddressReview.CommandType = CommandType.StoredProcedure
        AddParameterstoCommand(cmdUpdateAddressReview)
    End Sub

    Sub AddParameterstoCommand(cmd As SqlCommand)
        cmd.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20, "First Name")
        cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar, 20, "Middle")
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 30, "Last Name")
        cmd.Parameters.Add("@Facility1", SqlDbType.VarChar, 60, "Facility1")
        cmd.Parameters.Add("@Facility2", SqlDbType.VarChar, 60, "Facility2")
        cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 60, "Address1")
        cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 60, "Address2")
        cmd.Parameters.Add("@Address3", SqlDbType.VarChar, 60, "Address3")
        cmd.Parameters.Add("@Address4", SqlDbType.VarChar, 60, "Address4")
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 25, "City")
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 2, "State")
        cmd.Parameters.Add("@Country", SqlDbType.VarChar, 40, "Country")
        cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 50, "Postal Code")
        cmd.Parameters.Add("@AddressReviewStatusID", SqlDbType.Int, 4, "AddressReviewStatusID")
        cmd.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar, 32, "LastModifiedBy")
        cmd.Parameters.Add("@LastModifiedOn", SqlDbType.DateTime, 8, "LastModifiedOn")
        cmd.Parameters.Add("@Latitude", SqlDbType.Float, 8, "Latitude")
        cmd.Parameters.Add("@Longitude", SqlDbType.Float, 8, "Longitude")
        cmd.Parameters.Add("@IsCleaned", SqlDbType.Bit, 1, "IsCleaned")
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmAddressReview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmExit() = DialogResult.Cancel)
    End Sub

    Private Sub frmAddressReview_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetAddressReviewStatusComboData()
        mintStatusIndex = - 1
        tscbAddReviewStatus.SelectedIndex = 0
        'DisplayGrid()
    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click

        Me.Close()
    End Sub

    Private Sub tscbAddReviewStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles tscbAddReviewStatus.SelectedIndexChanged

        If mintStatusIndex <> tscbAddReviewStatus.SelectedIndex Then

            If ConfirmExit() = DialogResult.Cancel Then
                tscbAddReviewStatus.SelectedIndex = mintStatusIndex
                Return
            End If
            mintStatusIndex = tscbAddReviewStatus.SelectedIndex

            ResetOldInfo()
            If Me.dgvAddressReview.Columns.Count > 0 Then
                Me.dgvAddressReview.Columns.Remove(List)
            End If
            DisplayGrid()

        End If
        tsbtnAutoApprove.Enabled = tscbAddReviewStatus.SelectedItem.ToString.Equals("Pending") _
        'only allow auto-approve for Pending addresses.
    End Sub

    Private Sub tsbtnSave_Click(sender As Object, e As EventArgs) Handles tsbtnSave.Click

        SaveChanges()
    End Sub

    Private Sub tsbtnAutoApprove_Click(sender As Object, e As EventArgs) Handles tsbtnAutoApprove.Click

        'mnuApproveAll.PerformClick()
    End Sub

    Private Sub mnuApproveAll_Click(sender As Object, e As EventArgs) Handles mnuApproveAll.Click

        Me.Cursor = Cursors.WaitCursor

        For Each row As DataGridViewRow In dgvAddressReview.Rows
            tspProgress.Value = CInt((row.Index + 1)/(dgvAddressReview.Rows.Count)*100)

            SendToDQWS(row)
        Next

        tspProgress.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuApproveSelected_Click(sender As Object, e As EventArgs) Handles mnuApproveSelected.Click

        Me.Cursor = Cursors.WaitCursor

        Dim row As DataGridViewRow = dgvAddressReview.SelectedRows(0)
        tspProgress.Value = 100

        SendToDQWS(row)

        tspProgress.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbtnTransmit_Click(sender As Object, e As EventArgs) Handles tsbtnTransmit.Click

        Dim dlgResult As DialogResult = DialogResult.No
        dlgResult = MessageBox.Show(Owner,
                                    "Are you sure you want to transmit data to the Respondent Payment System (RPS)?",
                                    "Confirm Transmit", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2)
        If dlgResult.ToString = "Yes" Then
            conn = New SqlConnection(Project.ConnectionString)
            cmdSQL = New SqlCommand("SMS_TransmitToRPS", conn)

            Cursor = Cursors.WaitCursor
            TransmitData()
            ''AF 11/08/12 - Transmit now creates a staging table for the RPS - this actually sends the data to the RPS.
            'SendToRPS()
            'AF 10/31/13 - using document processing webservice (starting with Document Processing v5) to send now...
            Dim result As String = RPS.SendToRPS(Project.ShortName)

            If result <> "" Then
                MessageBox.Show(result, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub tsbtnReissue_Click(sender As Object, e As EventArgs) Handles tsbtnReissue.Click

        'Dim dlgResult As DialogResult = System.Windows.Forms.DialogResult.No
        'dlgResult = MessageBox.Show(Owner, "Are you sure you want to reissue a payment?", "Reissue Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If dlgResult.ToString = "Yes" Then
        Dim frmPayments As New frmPayments()
        frmPayments.Show()
        'End If
    End Sub

    Private Sub dgvAddressReview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvAddressReview.CellEnter

        If Me.dgvAddressReview.CurrentCell.EditType.ToString = "System.Windows.Forms.DataGridViewComboBoxEditingControl" _
            Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub dgvAddressReview_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles dgvAddressReview.CellFormatting

        If e.ColumnIndex >= 0 Then
            If dgvAddressReview.Columns(e.ColumnIndex).ReadOnly Then
                e.CellStyle.BackColor = Color.LightGray
            ElseIf e.CellStyle.ForeColor = Color.Red Then
                e.CellStyle.BackColor = Color.Beige
            Else
                e.CellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub dgvAddressReview_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) _
        Handles dgvAddressReview.CellValidating

        If dgvAddressReview.Columns(e.ColumnIndex).ReadOnly Then Return

        dgvAddressReview.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = Data_Validation_Cell(
            CType(e.FormattedValue, String), dgvAddressReview.Columns(e.ColumnIndex).Name)
        If dgvAddressReview.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText <> "" Then
            IsDataError = True
        End If

        Return
    End Sub

    Private Sub dgvAddressReview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvAddressReview.CellValueChanged

        IsDataChanged = True
        tsbtnSave.Enabled = True
        tsbtnTransmit.Enabled = False
        tsbtnReissue.Enabled = False

        With Me.dgvAddressReview.Rows(e.RowIndex)
            .Cells(e.ColumnIndex).Style.ForeColor = Color.Red
            .Cells("LastModifiedBy").Value = UserLabel.Text
            .Cells("LastModifiedOn").Value = DateTime.Now
        End With
    End Sub

    Private Sub dgvAddressReview_SelectionChanged(sender As Object, e As EventArgs) _
        Handles dgvAddressReview.SelectionChanged

        If dgvAddressReview.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvAddressReview.SelectedRows(0)

        Dim strMPRID As String = row.Cells("MPRID").FormattedValue.ToString()
        Dim objPerson As Person = New Person(strMPRID)

        Dim intCaseID As Integer = GetSafeValue(objPerson.CaseID)

        Dim objCase As New [Case](intCaseID, False)
        Dim intAddressID As Integer = 0
        If Not row.Cells("AddressID").FormattedValue.ToString() = "" Then
            intAddressID = CInt(row.Cells("AddressID").FormattedValue.ToString())
        End If

        Dim objAddress As Address = Nothing
        Dim objAddresses As Addresses = objCase.Addresses
        If objAddresses IsNot Nothing Then
            For Each objAddress In objAddresses
                If objAddress.AddressID = intAddressID Then
                    Exit For
                End If
            Next
        End If

        Me.txtFNameNew.Text = CStr(row.Cells("First Name").FormattedValue)
        Me.txtMNameNew.Text = CStr(row.Cells("Middle").FormattedValue)
        Me.txtLNameNew.Text = CStr(row.Cells("Last Name").FormattedValue)
        Me.txtAddress1New.Text = CStr(row.Cells("Address1").FormattedValue)
        Me.txtAddress2New.Text = CStr(row.Cells("Address2").FormattedValue)
        Me.txtAddress3New.Text = CStr(row.Cells("Address3").FormattedValue)
        Me.txtAddress4New.Text = CStr(row.Cells("Address4").FormattedValue)
        Me.txtCityNew.Text = CStr(row.Cells("City").FormattedValue)
        Me.txtStateNew.Text = CStr(row.Cells("State").FormattedValue)
        Me.txtZipNew.Text = CStr(row.Cells("Postal Code").FormattedValue)
        Me.txtFacility1New.Text = CStr(row.Cells("Facility1").FormattedValue)
        Me.txtFacility2New.Text = CStr(row.Cells("Facility2").FormattedValue)

        ResetOldInfo()
        If objPerson IsNot Nothing Then
            Me.txtFName.Text = GetSafeValue(objPerson.FirstName)
            Me.txtMName.Text = GetSafeValue(objPerson.MiddleName)
            Me.txtLName.Text = GetSafeValue(objPerson.LastName)
        End If
        If objAddress IsNot Nothing Then
            Me.txtAddress1.Text = GetSafeValue(objAddress.Address1)
            Me.txtAddress2.Text = GetSafeValue(objAddress.Address2)
            Me.txtAddress3.Text = GetSafeValue(objAddress.Address3)
            Me.txtAddress4.Text = GetSafeValue(objAddress.Address4)
            Me.txtCity.Text = GetSafeValue(objAddress.City)
            Me.txtState.Text = GetSafeValue(objAddress.State)
            Me.txtZip.Text = GetSafeValue(objAddress.PostalCode)
            Me.txtFacility1.Text = GetSafeValue(objAddress.Facility1)
            Me.txtFacility2.Text = GetSafeValue(objAddress.Facility2)
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayGrid()

        Me.Cursor = Cursors.WaitCursor

        Dim strSQL As String = "SMS_GetAddressReviewRecords @StatusID=" & tscbAddReviewStatus.SelectedIndex + 1

        Try
            ExtensionMethods.DoubleBuffered(dgvAddressReview, True)

            With dgvAddressReview
                .DataSource = bindingsourceAddressReview
                dataAdapterAddressReview = New SqlDataAdapter(strSQL, Project.ConnectionString)

                'AF 12/13/07 Added Update Command so update can be done by users without db_datawriter access
                dataAdapterAddressReview.UpdateCommand = cmdUpdateAddressReview


                Dim table As New DataTable
                dataAdapterAddressReview.Fill(table)
                bindingsourceAddressReview.DataSource = table

                .Columns(2).Frozen = True
                .Columns(1).Width = 65
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .MultiSelect = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 39
                '.RowTemplate.Height = 19   'don't change the default row height - it will hide the Validation icon.

                If .Rows.Count > 0 Then
                    .Rows(0).Selected = True
                End If

                .Columns("AddressReviewStatusID").Visible = False
                .Columns("IsCleaned").Visible = False

            End With

            ' Create a list column for the ReviewStatus.
            List.DisplayIndex = 3
            List.HeaderText = "Status"

            ' This column is bound to the AddressReviewStatusID field.
            List.DataPropertyName = "AddressReviewStatusID"

            strSQL = "SELECT * FROM tlkpAddressReviewStatus "
            If Me.tscbAddReviewStatus.Text <> "Transmitted" Then
                strSQL = strSQL & "WHERE AddressReviewStatusID < 4 "
            End If

            Dim dataAdapterAddressReviewStatus As New SqlDataAdapter(strSQL, Project.ConnectionString)

            Dim dtReviewStatus As New DataTable
            dataAdapterAddressReviewStatus.Fill(dtReviewStatus)
            List.DataSource = dtReviewStatus
            List.DisplayMember = "Description"
            List.ValueMember = "AddressReviewStatusID"

            ' Add the column.
            Me.dgvAddressReview.Columns.Add(List)

            Me.TotalRecordsLabel.Text = "Total Records: " & Me.dgvAddressReview.Rows.Count
            Me.tsbtnSave.Enabled = False
            Me.tsbtnTransmit.Enabled = True
            Me.tsbtnReissue.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try

        With dgvAddressReview
            If Me.tscbAddReviewStatus.Text = "Transmitted" Then
                .ReadOnly = True

            Else
                .ReadOnly = False

                .Columns("ID").ReadOnly = True
                .Columns("MPRID").ReadOnly = True
                .Columns("AddressID").ReadOnly = True
                .Columns("InstrumentTypeID").ReadOnly = True
                .Columns("Round").ReadOnly = True
                .Columns("LastModifiedBy").ReadOnly = True
                .Columns("LastModifiedOn").ReadOnly = True
                .Columns("Latitude").ReadOnly = True
                .Columns("Longitude").ReadOnly = True

                'hide the read-only columns. SL 5/1/06
                .Columns("ID").Visible = False
                '.Columns("MPRID").Visible = False
                .Columns("AddressID").Visible = False
                .Columns("InstrumentTypeID").Visible = False
                .Columns("Round").Visible = False
                .Columns("LastModifiedBy").Visible = False
                .Columns("LastModifiedOn").Visible = False
                .Columns("Latitude").Visible = False
                .Columns("Longitude").Visible = False

            End If

            IsDataChanged = False   'reset each time grid is filled.
            IsDataError = False     'reset each time grid is filled.

        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetAddressReviewStatusComboData()

        Try
            Dim SelectRule As String = "SELECT Description FROM tlkpAddressReviewStatus ORDER BY AddressReviewStatusID"
            Dim dataAdapterAddressReviewStatusCB As New SqlDataAdapter(SelectRule, Project.ConnectionString)
            Dim table As New DataTable
            dataAdapterAddressReviewStatusCB.Fill(table)
            Dim CurRows() As DataRow, CurRow As DataRow

            CurRows = table.Select

            For Each CurRow In CurRows
                tscbAddReviewStatus.Items.Add(CurRow("Description").ToString)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading address review statuses",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function ConfirmExit() As DialogResult

        If IsDataChanged Or IsDataError Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show("Do you want to save your changes?", Project.ShortName & " – Save changes?",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button1)

            If dlgResult = DialogResult.Yes Then
                If Not SaveChanges() Then
                    Return DialogResult.Cancel
                End If
            End If

            Return dlgResult
        Else
            Return DialogResult.No
        End If
    End Function

    Private Sub Data_Validation()

        IsDataError = False
        For Each row As DataGridViewRow In Me.dgvAddressReview.Rows
            row.ErrorText = ""

            For Each cell As DataGridViewCell In row.Cells

                cell.ErrorText = Data_Validation_Cell(CType(cell.FormattedValue, String),
                                                      dgvAddressReview.Columns(cell.ColumnIndex).Name)
                If cell.ErrorText <> "" Then
                    IsDataError = True
                    row.ErrorText = "Error in this row. Hover mouse over column error to see detail."
                End If

            Next
        Next
    End Sub

    'returns the ErrorText if the field is invalid
    Private Function Data_Validation_Cell(value As String, FieldName As String) As String

        Dim strErrMsg As String = ""

        Select Case FieldName
            Case "First Name"
                If value.Length > 20 Then
                    strErrMsg = "The First Name is too long. Maximum size is 20 characters."
                End If
            Case "Middle"
                If value.Length > 20 Then
                    strErrMsg = "The Middle Name is too long. Maximum size is 1 character."
                End If
            Case "Last Name"
                If value.Length > 30 Then
                    strErrMsg = "The Last Name is too long. Maximum size is 30 characters."
                End If
            Case "Facility1"
                If value.Length > 60 Then
                    strErrMsg = "The Facility1 is too long. Maximum size is 60 characters."
                End If
            Case "Facility2"
                If value.Length > 60 Then
                    strErrMsg = "The Facility2 is too long. Maximum size is 60 characters."
                End If
            Case "Address1"
                If value.Length > 60 Then
                    strErrMsg = "The Address1 is too long. Maximum size is 60 characters."
                End If
            Case "Address2"
                If value.Length > 60 Then
                    strErrMsg = "The Address2 is too long. Maximum size is 60 characters."
                End If
            Case "Address3"
                If value.Length > 60 Then
                    strErrMsg = "The Address3 is too long. Maximum size is 60 characters."
                End If
            Case "Address4"
                If value.Length > 60 Then
                    strErrMsg = "The Address4 is too long. Maximum size is 60 characters."
                End If
            Case "City"
                If value.Length > 25 Then
                    strErrMsg = "The City is too long. Maximum size is 25 characters."
                End If
            Case "State"
                If value.Length > 2 Then
                    strErrMsg = "The State is too long. Maximum size is 2 characters."
                End If
            Case "Country"
                If value.Length > 40 Then
                    strErrMsg = "The Country is too long. Maximum size is 40 characters."
                End If
            Case "Postal Code"
                If value.Length > 10 Then
                    strErrMsg = "The Postal Code is too long. Maximum size is 10 characters."
                End If

        End Select

        Return strErrMsg
    End Function

    Private Sub TransmitData()

        Dim ErrMsg As String = ""

        Try
            conn.Open()
            cmdSQL.Parameters.Add(New SqlParameter("@UserName", SqlDbType.Char, 32, ParameterDirection.Input, False, 0,
                                                   0, "", DataRowVersion.Proposed, Me.UserLabel.Text))
            cmdSQL.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 4000, ParameterDirection.Output, True,
                                                   0, 0, "", DataRowVersion.Proposed, ErrMsg))
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.ExecuteNonQuery()
            ErrMsg = cmdSQL.Parameters.Item("@ErrMsg").Value.ToString()
            If ErrMsg.Length > 0 Then _
                MessageBox.Show(ErrMsg, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Function SaveChanges() As Boolean

        Data_Validation()
        If IsDataError Then
            MessageBox.Show("Data validation error - please correct data before continuing.", "Data validation error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Try
                Me.Validate()
                Me.bindingsourceAddressReview.EndEdit()
                Me.dataAdapterAddressReview.Update(CType(Me.bindingsourceAddressReview.DataSource, DataTable))
                IsDataChanged = False
                Me.tsbtnSave.Enabled = False
                Me.tsbtnTransmit.Enabled = True
                Me.tsbtnReissue.Enabled = True
                MessageBox.Show("Data updated successfully", "Save changes", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " - Error saving changes", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Return False
            End Try
        End If
        Return True
    End Function

    Private Sub ResetOldInfo()

        Me.txtFName.Text = ""
        Me.txtMName.Text = ""
        Me.txtLName.Text = ""
        Me.txtAddress1.Text = ""
        Me.txtAddress2.Text = ""
        Me.txtAddress3.Text = ""
        Me.txtAddress4.Text = ""
        Me.txtCity.Text = ""
        Me.txtState.Text = ""
        Me.txtZip.Text = ""
        Me.txtFacility1.Text = ""
        Me.txtFacility2.Text = ""
    End Sub

    Private Sub SendToDQWS(row As DataGridViewRow)
        If Project.MelissaDataEnabled Then
            Dim servProvider As New ServiceProvider
            Dim obj As IDataquality = servProvider.getDataCleaner
            Dim dirtyAddress As New DQAddress
            Dim dirtyAddresses As New List(Of DQAddress)
            Dim processedAddresses As List(Of ProcessedAddress)
            Dim processedAddress As ProcessedAddress

            With dirtyAddress
                .Address = row.Cells("Address1").Value.ToString
                .Address2 = row.Cells("Address2").Value.ToString
                .City = row.Cells("City").Value.ToString
                .State = row.Cells("State").Value.ToString
                If row.Cells("Country").Value.ToString.Length >= 2 AndAlso
                   row.Cells("Country").Value.ToString.Substring(0, 2).ToUpper = "CA" Then
                    .Country = "CA"
                Else
                    .Country = "US"
                End If
                If row.Cells("Postal Code").Value.ToString.Length >= 5 Then
                    .Zip5 = row.Cells("Postal Code").Value.ToString.Substring(0, 5)
                End If
                If row.Cells("Postal Code").Value.ToString.Length >= 9 Then
                    .Plus4 = row.Cells("Postal Code").Value.ToString.Substring(5, 4)
                End If
                .Company = row.Cells("Facility1").Value.ToString
            End With
            dirtyAddresses.Add(dirtyAddress)
            processedAddresses = obj.ProcessAddresses(dirtyAddresses)
            processedAddress = processedAddresses(0)

            With processedAddress
                row.Cells("Address1").Value = .Address1
                row.Cells("Address2").Value = .Address2
                If .Address2.Trim <> .Suite.Trim Then
                    If .Address2.Length + .Suite.Length < 60 Then
                        row.Cells("Address2").Value = LTrim(.Address2 + " ") + .Suite
                    Else
                        row.Cells("Address3").Value = .Suite
                    End If
                End If
                row.Cells("City").Value = .City
                row.Cells("State").Value = .State
                If .Postalcode.Trim <> "" Then
                    If .Plus4 <> " " Then
                        row.Cells("Postal Code").Value = .Postalcode + "-" + .Plus4
                    Else
                        row.Cells("Postal Code").Value = .Postalcode
                    End If
                End If
                row.Cells("Facility1").Value = .Company
                row.Cells("AddressReviewStatusID").Value = 2    'Approved
            End With

            'uncomment the code below to use the DQWS to proper-case the names.
            'using this will cost an extra transaction request per address.
            'With obj.NameInput
            '    .FullName = row.Cells("First Name").Value.ToString + " " + LTrim(row.Cells("Middle").Value.ToString + " ") + row.Cells("Last Name").Value.ToString
            'End With
            'obj.ProcessName()
            'If obj.StatusCode = DataQuality.DataQuality.DataStatusCode.NoError Then
            '    With obj.NameOutput
            '        row.Cells("First Name").Value = .First
            '        row.Cells("Middle").Value = .Middle
            '        row.Cells("Last Name").Value = RTrim(.Last + " " + .Suffix)
            '    End With
            'End If

            'instead, use this below as a free (but not as good) method to do proper casing.
            row.Cells("First Name").Value = StrConv(row.Cells("First Name").Value.ToString, VbStrConv.ProperCase)
            row.Cells("Middle").Value = StrConv(row.Cells("Middle").Value.ToString, VbStrConv.ProperCase)
            row.Cells("Last Name").Value = StrConv(row.Cells("Last Name").Value.ToString, VbStrConv.ProperCase)

            row.Cells("Latitude").Value = processedAddress.Latitude
            row.Cells("Longitude").Value = processedAddress.Longitude
            row.ErrorText = ""
            If processedAddress.isClean Then
                row.Cells("IsCleaned").Value = 1
                row.ErrorText = "Address has been Cleaned"
            Else
                IsDataChanged = True
                row.Cells("IsCleaned").Value = 0
                row.ErrorText = processedAddress.Results.Description
            End If
        End If
    End Sub

#End Region
End Class

Public Module ExtensionMethods
    Public Sub DoubleBuffered(dgv As DataGridView, setting As Boolean)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)
    End Sub
End Module