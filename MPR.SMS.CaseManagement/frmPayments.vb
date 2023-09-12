'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls

Public Class frmPayments
    'TODO: RPS - Changes needed for RPS gift card and change in processing. See some other TODO comments in code below for more details
    ' 1. Verify that we are getting MPRID from the payment record, if not need to get person info from payment record 
    '    (Don't know why we would need to do this, there should always be a MPRID).
    ' 2. If we determine that there should always be an MPRID as mentioned in 1 - enforce it. 
    ' 3. Add GiftCardID to RPS proc that gets payment record, and to pass it back. 
    ' 4. frmPaymentConfim probably needs more options for paymenttype and needs some gift card id logic. 

#Region "Private Fields"

    Private mobjCase As [Case] = Nothing
    Private ReadOnly mstrSQL As String = ""

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Respondent Payment Re-Issue "

        mstrSQL = "SELECT * FROM dbo.vwSMSPayments WHERE [Project Code] LIKE '" & Project.ProjectCode & "%'"
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click

        Me.Close()
    End Sub

    Private Sub frmPayments_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmExit("You have unsaved changes - are you sure you want to exit?") = DialogResult.No)
    End Sub

    Private Sub frmPayments_Load(sender As Object, e As EventArgs) Handles Me.Load

        DisplayGrid(mstrSQL)

        ViewCaseMembers.AllowAdd = True     'False
        ViewCaseMembers.AllowEdit = True     'False
        ViewCaseMembers.AllowDelete = False

        ViewCaseAddresses.AllowAdd = True
        ViewCaseAddresses.AllowEdit = True
        ViewCaseAddresses.AllowDelete = False

        GroupBoxAdresses.Visible = False
        chkEditNameAddress.Checked = False

        If dgvPayments.Rows.Count > 0 Then
            dgvPayments.Rows(0).Selected = True
        End If
    End Sub

    Private Sub dgvPayments_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvPayments.MouseClick

        If e.Button = MouseButtons.Right Then
            If dgvPayments.HitTest(e.X, e.Y).RowIndex >= 0 Then
                dgvPayments.Rows(dgvPayments.HitTest(e.X, e.Y).RowIndex).Selected = True
                Dim SelectedRowID As Integer

                SelectedRowID =
                    CInt(dgvPayments.Rows(dgvPayments.HitTest(e.X, e.Y).RowIndex).Cells("SequentialNo").FormattedValue)

                If SelectedRowID >= 0 Then
                    Dim strSQL As String = "SELECT * FROM tblPaymentsDetail WHERE PaymentID = '" & SelectedRowID & "'"
                    Dim frm As New frmDisplayDataView(strSQL, "Payment Details")
                    frm.Width = dgvPayments.Width
                    frm.Location = New Point(Me.dgvPayments.PointToScreen(dgvPayments.Location).X,
                                             Cursor.Position.Y + 12)
                    frm.Show()
                End If
            End If
        End If
    End Sub

    Private Sub dgvPayments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPayments.SelectionChanged

        btnReissue.Enabled = (dgvPayments.SelectedRows.Count <> 0)
        If dgvPayments.SelectedRows.Count = 0 Then Return

        If mobjCase IsNot Nothing Then
            Dim strMsg As String = "You have unsaved changes to this case - do you want to save it now?" &
                                   Environment.NewLine &
                                   "(A payment reissue will NOT be created at this time.)"
            If ConfirmExit(strMsg) = DialogResult.Yes Then
                SaveCase()
            End If
        End If

        'TODO: RPS - do we ALWAYS get an MPRID here? there is logic in the stored proc that gets payment information from the RPS table if there isn't a MPRID. 
        '   This needs to be investigated. If we need to get ANYTHING from the RPS it needs to be done in the code now. 
        '   The logic I changed below should actually enforce that this needs to be a valid MPRID anyway....

        Dim strMPRID As String = dgvPayments.SelectedRows(0).Cells("MPRID").FormattedValue.ToString()

        Dim objPerson As New Person(strMPRID)

        'AF 12/30/13 - logic was updated to check for valid PERSON object first.
        If objPerson.CaseID.IsNull Then
            MessageBox.Show(
                "This case was not found the in the SMS sample, and therefore should not be reissued checks through SMS. If you think this is in error, please contact your database programmer. MPRID = " &
                strMPRID, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkEditNameAddress.Checked = False
            btnReissue.Enabled = False
            Exit Sub
        End If

        Dim intCaseID As Integer = CInt(objPerson.CaseID)
        Dim objCase As [Case] = New [Case](intCaseID, False)

        If objCase.Persons IsNot Nothing Then
            mobjCase = objCase
            objPerson.Case = mobjCase
        Else
            MessageBox.Show(
                "This case was not found the in the SMS sample, and therefore should not be reissued checks through SMS. If you think this is in error, please contact your database programmer. MPRID = " &
                strMPRID, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkEditNameAddress.Checked = False
            btnReissue.Enabled = False
            Exit Sub 'AF 12/30/13 - added end here - if this DID get here, it shouldn't continue... 
        End If

        Try
            ViewCaseMembers.SelectedCase = mobjCase
            ViewCaseMembers.SelectedPerson = objPerson
            ViewCaseAddresses.SelectedAddress = objPerson.BestCheckAddress
        Catch ex As Exception
            MessageBox.Show(
                "This case was not found the in the SMS sample, and therefore should not be reissued checks through SMS. If you think this is in error, please contact your database programmer. MPRID = " &
                strMPRID, "Error retrieving case", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkEditNameAddress.Checked = False
            btnReissue.Enabled = False
        End Try
    End Sub

    Private Sub ViewCaseMembers_OnClick(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnClick

        ViewCaseAddresses.SelectedCase = mobjCase
        ViewCaseAddresses.SelectedPerson = objPerson
        'ViewCaseAddresses.Refresh()
    End Sub

    Private Sub chkEditNameAddress_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkEditNameAddress.CheckedChanged

        GroupBoxAdresses.Visible = chkEditNameAddress.Checked
    End Sub

    Private Sub btnReissue_Click(sender As Object, e As EventArgs) Handles btnReissue.Click

        Dim blnNewName As Boolean = chkEditNameAddress.Checked

        If dgvPayments.SelectedRows.Count = 0 Then
            Return
        ElseIf blnNewName AndAlso
               ViewCaseMembers.SelectedPerson Is Nothing Then
            '  (ViewCaseMembers.SelectedPerson Is Nothing Or _
            '  ViewCaseAddresses.SelectedAddress Is Nothing) Then
            MessageBox.Show("You must select a valid name and address to reissue this check.",
                            Project.ShortName & " - Error reissuing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim strMPRID As String = dgvPayments.CurrentRow.Cells("MPRID").FormattedValue.ToString.Trim
        Dim intAddressID As Integer = 0
        Dim intSeqNum As Integer = CInt(dgvPayments.CurrentRow.Cells("SequentialNo").FormattedValue)

        Dim objPerson As Person
        Dim objAddress As Address = Nothing

        If blnNewName Then
            objPerson = ViewCaseMembers.SelectedPerson
            objAddress = ViewCaseAddresses.SelectedAddress
        Else
            objPerson = New Person(strMPRID)
        End If

        'TODO: RPS - need to send everything we get in Stored Proc from RPS (looks like it's only VendorID unless MPRID is missing) 
        '   Need to send GiftCardID as well. 
        Dim frm As New frmPaymentConfirm
        With frm
            .BankAccount = dgvPayments.CurrentRow.Cells("Bank Account").FormattedValue.ToString.Trim
            .CheckAmount = CType(dgvPayments.CurrentRow.Cells("Amount").FormattedValue, Double)
            .ProjectCode = dgvPayments.CurrentRow.Cells("Project Code").FormattedValue.ToString.Substring(0, 5)
            .TaskCode = dgvPayments.CurrentRow.Cells("Project Code").FormattedValue.ToString.Substring(6, 3)
            .Notes = ""
            .ProjectType = dgvPayments.CurrentRow.Cells("Project Type").FormattedValue.ToString.Trim
            .Mode = dgvPayments.CurrentRow.Cells("Mode").FormattedValue.ToString.Trim
            .PaymentType = dgvPayments.CurrentRow.Cells("Payment Type").FormattedValue.ToString.Trim
            If blnNewName Then
                .FullName = objPerson.FullName
                If objAddress IsNot Nothing Then
                    .FullAddress = objAddress.FullAddress
                End If
            Else
                .FullName = dgvPayments.CurrentRow.Cells("Name").FormattedValue.ToString.Trim
                .FullAddress = dgvPayments.CurrentRow.Cells("Address").FormattedValue.ToString.Trim &
                               Environment.NewLine &
                               dgvPayments.CurrentRow.Cells("City").FormattedValue.ToString.Trim & ", " &
                               dgvPayments.CurrentRow.Cells("State").FormattedValue.ToString.Trim & " " &
                               dgvPayments.CurrentRow.Cells("Postal Code").FormattedValue.ToString.Trim
            End If
        End With
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            If Not blnNewName Or SaveCase() Then
                strMPRID = GetSafeValue(objPerson.MPRID)
                intAddressID = 0
                If objAddress IsNot Nothing Then
                    intAddressID = GetSafeValue(objAddress.AddressID)
                End If

                TransmitData(CurrentUser.Name, intSeqNum,
                             strMPRID, intAddressID, frm.CheckAmount,
                             frm.ProjectCode & "." & frm.TaskCode,
                             frm.ProjectType, frm.Mode, frm.PaymentType,
                             frm.BankAccount, frm.Notes)

                'AF 11/08/12 - Transmit now creates a staging table for the RPS - this actually sends the data to the RPS.
                'SendToRPS()

                'AF 12/30/13 - using document processing webservice (starting with Document Processing v5) to send now...
                Dim result As String = RPS.SendToRPS(Project.ShortName)

                If result <> "" Then
                    MessageBox.Show(result, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)
                End If

            End If
            chkEditNameAddress.Checked = False
        End If
    End Sub

    Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefresh.Click

        DisplayGrid(mstrSQL)
    End Sub

    Private Sub tsbFilter_Click(sender As Object, e As EventArgs) Handles tsbFilter.Click

        Dim frm As New frmPaymentFilter
        With frm
            .ProjectCode = Project.ProjectCode
            .TaskCode = Project.RPSTaskCode
        End With
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            DisplayGrid(mstrSQL & frm.Filters)
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayGrid(strSQL As String)

        chkEditNameAddress.Checked = False
        btnReissue.Enabled = False
        Try

            strSQL += " ORDER BY SequentialNo DESC "
            With dgvPayments
                .DataSource = GetRPSDataTable(strSQL)
                .Columns("MPRID").Width = 65
                .Columns("Amount").Width = 65
                .Columns("Address").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns(1).Frozen = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .MultiSelect = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With

            TotalRecordsLabel.Text = "Total records: " & dgvPayments.Rows.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Respondent Payment error", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub TransmitData(strUser As String, intSeqNum As Integer, strMPRID As String, intAddressID As Integer,
                             dblAmount As Double, strProjectCode As String, strProjectType As String,
                             strModeOfPayment As String, strTypeOfPayment As String,
                             strBankAccount As String, strNotes As String)

        Cursor = Cursors.WaitCursor

        Dim ErrMsg As String = ""

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand("SMS_TransmitToRPS_Reissue", conn)

        'send the parameters:
        cmdSQL.Parameters.Add(New SqlParameter("@UserName", SqlDbType.Char, 32, ParameterDirection.Input, False, 0, 0,
                                               "", DataRowVersion.Proposed, strUser))
        cmdSQL.Parameters.Add(New SqlParameter("@SeqNo", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "",
                                               DataRowVersion.Proposed, intSeqNum))
        cmdSQL.Parameters.Add(New SqlParameter("@MPRID", SqlDbType.Char, 8, ParameterDirection.Input, False, 0, 0, "",
                                               DataRowVersion.Proposed, strMPRID))
        cmdSQL.Parameters.Add(New SqlParameter("@AddressID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0,
                                               "", DataRowVersion.Proposed, intAddressID))
        cmdSQL.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Money, 4, ParameterDirection.Input, False, 10, 0, "",
                                               DataRowVersion.Proposed, dblAmount))
        cmdSQL.Parameters.Add(New SqlParameter("@ProjectCode", SqlDbType.VarChar, 10, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, strProjectCode))
        cmdSQL.Parameters.Add(New SqlParameter("@ProjectType", SqlDbType.VarChar, 25, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, strProjectType))
        cmdSQL.Parameters.Add(New SqlParameter("@ModeOfPayment", SqlDbType.VarChar, 25, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, strModeOfPayment))
        cmdSQL.Parameters.Add(New SqlParameter("@TypeOfPayment", SqlDbType.VarChar, 25, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, strTypeOfPayment))
        cmdSQL.Parameters.Add(New SqlParameter("@BankAccount", SqlDbType.VarChar, 25, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, strBankAccount))
        cmdSQL.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 255, ParameterDirection.Input, False, 10, 0,
                                               "", DataRowVersion.Proposed, strNotes))
        cmdSQL.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 4000, ParameterDirection.Output, True, 0,
                                               0, "", DataRowVersion.Proposed, ErrMsg))

        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure

            cmdSQL.ExecuteNonQuery()

            ErrMsg = cmdSQL.Parameters.Item("@ErrMsg").Value.ToString()
            If ErrMsg.Length > 0 Then
                MessageBox.Show(ErrMsg, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Record transmitted successfully", Project.ShortName & " - Reissue successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error transmitting", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
        Cursor = Cursors.Default

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Function ConfirmExit(strMsg As String) As DialogResult

        If mobjCase IsNot Nothing AndAlso mobjCase.IsModified Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show(strMsg, Project.ShortName & " - Changes made to Case", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If dlgResult = DialogResult.No Then
                Return DialogResult.No
            Else
                Return DialogResult.Yes
            End If
        Else
            Return DialogResult.Yes
        End If
    End Function

    Private Function SaveCase() As Boolean

        If ViewCaseAddresses.SelectedAddress IsNot Nothing Then
            ViewCaseMembers.SelectedPerson.BestCheckAddress = ViewCaseAddresses.SelectedAddress
        End If

        If mobjCase.IsModified Then
            Try
                mobjCase.Lock()
                If Not mobjCase.IsReadOnly Then
                    mobjCase.Update()
                    mobjCase.Unlock()

                    ViewCaseMembers.Refresh()
                    ViewCaseAddresses.Refresh()
                    'MessageBox.Show("Record saved successfully", Project.ShortName & " - Save successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show(
                        "This case is unavailable for editing because it is locked by someone else, or you only have read-only access.",
                        Project.ShortName & " - Case is locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " - Error saving", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Return False
            End Try
        End If
        Return True
    End Function

#End Region
End Class