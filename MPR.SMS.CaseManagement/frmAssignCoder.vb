'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data
Imports MPR.SMS.Security

Public Class frmAssignCoder

#Region "Private Fields"

    Dim ReadOnly menmBatchType As Data.Enumerations.BatchType

    'Dim mblnCreatingNewBatch As Boolean = False

    Dim ReadOnly mdctInstrumentsAvailable As New Dictionary(Of String, Integer)  ' i.e. (ITCode, InstrumentID)
    Dim ReadOnly mdctInstrumentsAdded As New Dictionary(Of String, Integer)

    Dim WithEvents mdtExistingAssignments As DataTable
    Dim mdtNewAssignments As DataTable

    Dim mobjNewAssignment As CoderAssignment
    Dim mobjNewAssignments As CoderAssignments
    Dim mobjInstrumentType As InstrumentType
    Dim ReadOnly mobjCoders As New Coder

    Dim mdtStatusCodes As DataTable
    Dim mdtCoders As DataTable
    Dim mdtCodersFiltered As DataTable

    Dim CheckForCommit As Integer = 0

#End Region

#Region "Constructors"

    Public Sub New(enmBatchType As Data.Enumerations.BatchType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        menmBatchType = enmBatchType
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmAssignCoder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PROMPT for instrument type
        Dim frm As frmBatchInstrumentType = New frmBatchInstrumentType(menmBatchType)
        frm.ShowDialog()

        ' did user cancel?
        If (frm.DialogResult = DialogResult.Cancel) OrElse (frm.InstrumentType Is Nothing) Then
            ' CLOSE THIS FORM
            Me.DialogResult = DialogResult.Cancel
            Me.Close() '>>>>

        Else
            mobjInstrumentType = frm.InstrumentType


            '' Can only add batches if there are available Instruments
            'Try
            '    If GetAvailableInstruments() Then
            '        btnCreateNewBatch.Enabled = True
            '    Else
            '        btnCreateNewBatch.Enabled = False
            '    End If
            'Catch ex As Exception
            '    btnCreateNewBatch.Enabled = False
            'End Try

            ' Setup data sources
            Try
                SetupDataSources()
            Catch ex As Exception
                Dim strMsg As String = "A problem occurred trying to retrieve data from database." + Environment.NewLine +
                                       "If problem persists, please notify technical support." + Environment.NewLine +
                                       Environment.NewLine +
                                       "[Error Details]" + Environment.NewLine +
                                       ex.Message
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close() '>>>>
            End Try


            ' bindings
            bindingsourceBatches.DataSource = mdtExistingAssignments
            bindingsourceBatchItems.DataSource = mdtNewAssignments

            SetFormTitle()
            bindingsourceBatches.MoveLast()
            dgvBatchItems.Select()

            btnCancel.Enabled = False

            BeginCreateNewBatch()


        End If
    End Sub

    Private Sub frmBatchCreate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CheckForCommit = 1 Then
            Dim strMsg As String =
                    "Are you sure you want to discard these assignments, discarding all status code changes? Click Yes to continue closing without saving or No to return to making assignments."
            If _
                Not _
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                DialogResult.Yes Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CommitAssignments()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If CheckForCommit = 1 Then
            Dim strMsg As String =
                    "Are you sure you want to discard these assignments, discarding all status code changes? Click Yes to continue without saving or No to return to making assignments."
            If _
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                DialogResult.Yes Then
                Dim t As Integer
                For t = dgvBatchItems.Rows.Count - 2 To 0 Step - 1
                    dgvBatchItems.Rows.RemoveAt(t)
                Next t
                CheckForCommit = 0
                btnCancel.Enabled = False
            End If
        End If
    End Sub


    'Private Sub btnCreateNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If mblnCreatingNewBatch Then
    '        ' just in case user is clicking button again (but didn't add any items)
    '        If (mdtBatchItems.Rows.Count = 0) Then
    '            ' do nothing (i.e. let user work with the already-created, empty batch)
    '        Else
    '            EndCreateNewBatch()
    '            BeginCreateNewBatch()
    '        End If

    '    Else
    '        BeginCreateNewBatch()
    '    End If

    'End Sub

    Private Sub bindingsourceBatches_PositionChanged(sender As Object, e As EventArgs) _
        Handles bindingsourceBatches.PositionChanged
        'If mblnCreatingNewBatch Then
        '    ' if moving away from new Batch record, then End editing of that batch
        '    If (bindingsourceBatches.Position <> bindingsourceBatches.Count - 1) Then
        '        EndCreateNewBatch()
        '    End If
        'End If

        '' populate the BatchItems grid
        'If bindingsourceBatches.Current IsNot Nothing Then
        '    FillBatchItemsDataSource(CType(CType(bindingsourceBatches.Current, DataRowView).Row.Item("objBatch"), Batch))
        'End If
    End Sub

    Private Sub dgvBatchItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvBatchItems.CellEndEdit
        If menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
            If dgvBatchItems.CurrentCell.ColumnIndex = 2 And dgvBatchItems.CurrentCell.Value.Equals("1366") Then
                dgvBatchItems.CurrentRow.Cells(3).Value = 2
            ElseIf dgvBatchItems.CurrentCell.ColumnIndex = 3 And dgvBatchItems.CurrentCell.Value.Equals(2) Then
                dgvBatchItems.CurrentRow.Cells(2).Value = "1366"
            ElseIf dgvBatchItems.CurrentCell.ColumnIndex = 2 And dgvBatchItems.CurrentCell.Value.Equals("1383") Then
                dgvBatchItems.CurrentRow.Cells(3).Value = 3
            ElseIf dgvBatchItems.CurrentCell.ColumnIndex = 3 And dgvBatchItems.CurrentCell.Value.Equals(3) Then
                dgvBatchItems.CurrentRow.Cells(2).Value = "1383"
            ElseIf dgvBatchItems.CurrentCell.ColumnIndex = 2 And dgvBatchItems.CurrentCell.Value.Equals("1366") = False _
                Then
                dgvBatchItems.CurrentRow.Cells(3).Value = 4
            ElseIf dgvBatchItems.CurrentCell.ColumnIndex = 3 And dgvBatchItems.CurrentCell.Value.Equals(2) = False Then
                dgvBatchItems.CurrentRow.Cells(2).Value = "1365"
            End If
        End If

        CheckForCommit = 1
        btnCancel.Enabled = True
    End Sub


    Private Sub dgvBatchItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
        Handles dgvBatchItems.DataError
        Debug.WriteLine(e.RowIndex)

        Dim strMessage As String = "Problem encountered in the grid." + Environment.NewLine _
                                   + "Please report the following info to tech support." + Environment.NewLine +
                                   Environment.NewLine _
                                   + e.Exception.Message

        ' close the form
        strMessage = "Closing this form due to error." + Environment.NewLine _
                     + strMessage
        MessageBox.Show(strMessage, Project.ShortName & " - DataGridView error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Me.Close()
    End Sub


    Private Sub dgvBatchItems_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles dgvBatchItems.EditingControlShowing

        If dgvBatchItems.CurrentCell.OwningColumn.Name.ToLower = "itcode" Then
            ' setup AutoComplete
            Dim txt As TextBox
            txt = TryCast(e.Control, TextBox)
            If txt IsNot Nothing Then
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource
                txt.AutoCompleteCustomSource = AvailableITCodes()
            End If

        ElseIf dgvBatchItems.CurrentCell.OwningColumn.Name.ToLower = "coder" Then
            'Filter the Coders
            'Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)
            'If IsDBNull(currentrow.Item("InstrumentID")) Then
            '    ' User hasn't selected an IT-Code for new row (thus there is no InstrumentID).
            '    ' TODO:? Should IT-Code be the only editable column (until it is filled in)?
            '    mdtCodersFiltered = Nothing
            'ElseIf menmBatchType = Data.Enumerations.BatchType.CodeDVD Then
            '    mdtCodersFiltered = mobjCoders.SelectAllActual
            'ElseIf menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
            '    mdtCodersFiltered = mobjCoders.SelectAllPlusConsensus
            'Else
            '    mdtCodersFiltered = mobjCoders.SelectAllActual


            'Bind the control
            Dim ctrl As DataGridViewComboBoxEditingControl = TryCast(e.Control, DataGridViewComboBoxEditingControl)
            If ctrl IsNot Nothing Then
                With ctrl
                    .DataSource = mdtCoders
                    .ValueMember = "CoderID"
                    .DisplayMember = "FullName"
                    .SelectedValue = CInt(dgvBatchItems.CurrentRow.Cells(2).Value)
                End With
            End If
            'End If
        End If
    End Sub

    Private Sub dgvBatchItems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) _
        Handles dgvBatchItems.CellValidating

        Try
            Dim cell As DataGridViewCell = dgvBatchItems.Item(e.ColumnIndex, e.RowIndex)
            Dim strITCode As String
            Dim intInstrumentID As Integer

            ' Validate ITCode
            If _
                cell.IsInEditMode AndAlso dgvBatchItems.Columns(e.ColumnIndex).Name = "ITCode" And
                menmBatchType = Data.Enumerations.BatchType.CodeDVD Then
                Dim ctrl As Control = dgvBatchItems.EditingControl
                Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)

                strITCode = ctrl.Text
                If strITCode.Length = 0 Then
                    ' ignore it
                    ' (user may have accidentally entered an ITCode, then cleared it, which is ok).

                ElseIf mdctInstrumentsAvailable.TryGetValue(strITCode, intInstrumentID) Then
                    ' VALID
                    ' save intInstrumentID
                    If Not mdctInstrumentsAdded.ContainsKey(strITCode) Then
                        mdctInstrumentsAdded.Add(strITCode, intInstrumentID)
                    End If

                    ' make unavailable
                    If mdctInstrumentsAvailable.ContainsKey(strITCode) Then
                        mdctInstrumentsAvailable.Remove(strITCode)
                    End If

                    ' assign values to other columns
                    currentrow.Item("Description") = mobjInstrumentType.Description
                    Dim strstatuscode As String = BatchItem.StatusCodeWhenBatchReceived(menmBatchType)
                    AddStatusCode(strstatuscode) ' need to ensure it is in list, otherwise dgv will throw error
                    currentrow.Item("StatusCode") = strstatuscode
                    currentrow.Item("InstrumentId") = intInstrumentID
                    dgvBatchItems.Refresh() _
                    ' w/o this, the new StatusCode value didn't display (until user activated the cell).


                    'Remove Partner's coder from list if Partner has already been assigned:
                    'Dim coderid As Integer
                    Dim _
                        objInstrument As _
                            New Instrument(intInstrumentID, GetSafeValue(mobjInstrumentType.InstrumentTypeID))
                    currentrow.Item("CaseId") = GetSafeValue(objInstrument.CaseID)
                    currentrow.Item("MPRID") = GetSafeValue(objInstrument.SampleMemberMPRID)
                    'objInstrument.GetFieldInterviewer()
                    'currentrow.Item("Interviewer") = GetSafeValue(objInstrument.FieldInterviewer)
                    objInstrument.GetBilingual()
                    currentrow.Item("Bilingual") = GetSafeValue(objInstrument.Bilingual)
                    'Dim objCoderAssignments As New CoderAssignments
                    'Dim objNewCoderAssignments As New CoderAssignments
                    'Dim dtNewCoderAssignments As DataTable = objCoderAssignments.RetrieveAllBatchesbyCaseId(GetSafeValue(objInstrument.CaseID))
                    'If dtNewCoderAssignments.Rows.Count > 0 Then
                    '    coderid = CType(dtNewCoderAssignments.Rows(0).Item("CoderId"), Integer)
                    '    mobjCoders.CoderId = coderid
                    'mdtCodersFiltered = mobjCoders.SelectAllActual
                    'Else
                    'mdtCodersFiltered = mobjCoders.SelectAll
                    'End If
                    dgvBatchItems.Refresh() _
                    ' w/o this, the new Interviewer value didn't display (until user activated the cell).

                    ' '' User scanned in one IT code, now fill the grid with all available instruments in the booklet
                    ''mdtNewAssignments.Clear()
                    'Dim dtBooklet As DataTable = Batch.InstrumentsInBooklet(intInstrumentID, menmBatchType)
                    'Dim row As DataRow
                    'For Each row In dtBooklet.Rows

                    '    ' add to grid datasource

                    '    'Dim rowBatchItem As DataRow = mdtNewAssignments.Rows.Add
                    '    'rowBatchItem("ITCode") = row("ITCode")

                    '    'Dim strstatuscode As String = BatchItem.StatusCodeWhenBatchReceived(menmBatchType)

                    '    'AddStatusCode(strstatuscode) ' need to ensure it is in list, otherwise dgv will throw error
                    '    'rowBatchItem("StatusCode") = strstatuscode

                    '    'rowBatchItem("Description") = mobjInstrumentType.Description

                    '    cell.Value = row("ITCode").ToString

                    '    Dim cell2 As DataGridViewCell = dgvBatchItems.Item(e.ColumnIndex + 1, e.RowIndex)
                    '    cell2.Value = mobjInstrumentType.Description

                    '    Dim strstatuscode As String = BatchItem.StatusCodeWhenBatchReceived(menmBatchType)
                    '    Dim cell3 As DataGridViewCell = dgvBatchItems.Item(e.ColumnIndex + 2, e.RowIndex)
                    '    AddStatusCode(strstatuscode) ' need to ensure it is in list, otherwise dgv will throw error
                    '    cell3.Value = strstatuscode


                    '    ' save intInstrumentID (todo:?  yes, this data structure is now redundant; we could do better)
                    '    'If Not mdctInstrumentsAdded.ContainsKey(row("ITCode").ToString) Then
                    '    '    mdctInstrumentsAdded.Add(row("ITCode").ToString, CType(row("InstrumentID"), Integer))
                    '    'End If

                    'Next

                    ' lockdown the grid/columns...
                    'BatchItemsGridReadOnly(False, False)
                    'dgvBatchItems.Columns("ITCode").ReadOnly = False
                    'dgvBatchItems.AllowUserToAddRows = True


                End If
            ElseIf _
                cell.IsInEditMode AndAlso dgvBatchItems.Columns(e.ColumnIndex).Name = "ITCode" And
                menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
                Dim ctrl2 As Control = dgvBatchItems.EditingControl
                Dim currentrow2 As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)

                strITCode = ctrl2.Text
                If strITCode.Length = 0 Then
                    ' ignore it
                    ' (user may have accidentally entered an ITCode, then cleared it, which is ok).

                ElseIf mdctInstrumentsAvailable.TryGetValue(strITCode, intInstrumentID) Then
                    ' VALID
                    ' save intInstrumentID
                    If Not mdctInstrumentsAdded.ContainsKey(strITCode) Then
                        mdctInstrumentsAdded.Add(strITCode, intInstrumentID)
                    End If

                    ' make unavailable
                    If mdctInstrumentsAvailable.ContainsKey(strITCode) Then
                        mdctInstrumentsAvailable.Remove(strITCode)
                    End If

                    Dim objcoderassignment As New CoderAssignment(intInstrumentID, 1)

                    ' assign values to other columns
                    currentrow2.Item("Description") = mobjInstrumentType.Description
                    Dim strstatuscode As String = objcoderassignment.Instrument.CurrentStatus.ToString
                    AddStatusCode(strstatuscode) ' need to ensure it is in list, otherwise dgv will throw error
                    currentrow2.Item("StatusCode") = strstatuscode
                    currentrow2.Item("InstrumentId") = intInstrumentID
                    currentrow2.Item("CoderId") = CInt(objcoderassignment.Coder.CoderId)
                    dgvBatchItems.Refresh() _
                    ' w/o this, the new StatusCode value didn't display (until user activated the cell).

                    Dim _
                        objInstrument As _
                            New Instrument(intInstrumentID, GetSafeValue(mobjInstrumentType.InstrumentTypeID))
                    currentrow2.Item("CaseId") = GetSafeValue(objInstrument.CaseID)
                    currentrow2.Item("MPRID") = GetSafeValue(objInstrument.SampleMemberMPRID)
                    objInstrument.GetBilingual()
                    currentrow2.Item("Bilingual") = GetSafeValue(objInstrument.Bilingual)
                    'mdtCodersFiltered = mobjCoders.SelectAllPlusConsensus
                    dgvBatchItems.Refresh() _
                    ' w/o this, the new Interviewer value didn't display (until user activated the cell).
                Else
                    ' INVALID
                    Dim msg As String = "The ITCode you entered is not in the list" + Environment.NewLine +
                                        Environment.NewLine +
                                        "Please enter (or select) an ITCode from the list."
                    MessageBox.Show(msg, "Invalid ITCode", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True
                End If

            End If

        Catch ex As Exception
            Dim strMsg As String = "A problem occurred during cell validation." + Environment.NewLine +
                                   "If problem persists, please notify technical support." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' <summary>
    '''     Adds a status code to the list of allowable status codes.
    ''' </summary>
    Private Sub AddStatusCode(statuscode As String)
        If mdtStatusCodes.Select(String.Format("code='{0}'", statuscode)).Length = 0 Then
            ' get row data from AllStatusCodes, and use it to create the new row
            Dim rows As DataRow() = Batch.AllStatusCodes.Select(String.Format("code='{0}'", statuscode))
            If rows.Length > 0 Then
                Dim sourcerow As DataRow = rows(0)
                Dim newrow As DataRow = mdtStatusCodes.NewRow()
                newrow("Code") = sourcerow("Code")
                newrow("Description") = sourcerow("Description")
                newrow("DisplayMember") = sourcerow("DisplayMember")
                mdtStatusCodes.Rows.Add(newrow)
            End If
        End If
    End Sub

    Private Sub dgvBatchItems_RowValidated(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvBatchItems.RowValidated

        ' enforce MaxBatchSize
        'If mblnCreatingNewBatch AndAlso mdtBatchItems.Rows.Count = mobjNewBatch.MaxBatchSize Then
        '    dgvBatchItems.AllowUserToAddRows = False
        'End If
    End Sub

    Private Sub mdtBatches_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs) _
        Handles mdtExistingAssignments.ColumnChanged

        If CStr(e.Column.ColumnName) = "Notes" Then
            ' update Batch Note
            Dim objBatch As Batch = CType(e.Row.Item("objBatch"), Batch)
            If objBatch IsNot Nothing Then
                objBatch.Notes = CStr(e.ProposedValue)

                Try
                    objBatch.Update()
                Catch ex As Exception
                    Dim strMsg As String = "Unable to update the Batch's Notes." + Environment.NewLine +
                                           "If problem persists, please notify technical support." + Environment.NewLine +
                                           Environment.NewLine +
                                           "[Error Details]" + Environment.NewLine +
                                           ex.Message
                    MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

            End If
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub SetFormTitle()
        Dim strTitle As String

        If menmBatchType = Data.Enumerations.BatchType.QC Then
            strTitle = "Receiving and Batching Mailed Surveys"
        Else
            Try
                strTitle = (New BatchType(menmBatchType)).Description.ToString & " Batching"
                Console.WriteLine(strTitle)
            Catch ex As Exception
                strTitle = "Batching"
            End Try
        End If
        Me.Text = "SMS - [" + Project.ShortName + "] - " + strTitle

        ' also set label to indicate Instrument Name
        If mobjInstrumentType IsNot Nothing Then
            txtInstrumentName.Text = mobjInstrumentType.Description.ToString
        Else
            txtInstrumentName.Text = ""
        End If
    End Sub

    Private Sub BeginCreateNewBatch()

        If Not GetAvailableInstruments() Then
            Dim strMsg As String
            If menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
                strMsg = "There are no instruments available to re-assign."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf menmBatchType = Data.Enumerations.BatchType.CodeDVD Then
                strMsg = "There are no instruments available to assign."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'btnCreateNewBatch.Enabled = False
            Me.Close()
            Exit Sub
        End If

        ' create the batch
        Try
            mobjNewAssignment = New CoderAssignment()
        Catch ex As Exception
            Dim strMsg As String = "Unable to Create new batch." + Environment.NewLine +
                                   "If problem persists, please notify technical support." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub ' >>>>
        End Try

        AddBatchToBatchesDataSource(mobjNewAssignment)

        ' prepare for new Batch Items
        mdtNewAssignments.Clear()
        If menmBatchType = Data.Enumerations.BatchType.CodeDVD Then
            BatchItemsGridReadOnly(False, True)
        Else
            BatchItemsGridReadOnly(False, False)
        End If

        dgvBatchItems.AllowUserToAddRows = True
        SetupStatusCodeLookupForNewBatch()
        SetupCoderLookupForNewBatch()

        ' select the grid
        bindingsourceBatches.MoveLast()
        dgvBatchItems.CurrentCell = dgvBatchItems.Item(0, 0)
        dgvBatchItems.Select()

        'txtBatchNotes.ReadOnly = False ' (it would have been ReadOnly if this is the first Batch).

        btnCancel.Enabled = True
    End Sub

    ' This is useful because, unfortunately, setting DataGridView.ReadOnly overrides all the
    ' design-time Column.ReadOnly values.
    Private Sub BatchItemsGridReadOnly(isGridReadOnly As Boolean,
                                       Optional ByVal isAllButITCodeColumnReadOnly As Boolean = True)

        dgvBatchItems.ReadOnly = isGridReadOnly
        dgvBatchItems.Columns("Description").ReadOnly = True 'always
        dgvBatchItems.Columns("Coder").ReadOnly = False 'always
        dgvBatchItems.Columns("StatusCode").ReadOnly = isAllButITCodeColumnReadOnly
    End Sub


    Private Sub CommitAssignments()
        Dim i As Integer
        Dim j As Integer
        Dim strITCode As String = ""
        Dim intInstrumentId As Integer

        Try
            If dgvBatchItems.Rows.Count > 0 Then
                If menmBatchType = Data.Enumerations.BatchType.CodeDVD Then
                    bindingsourceBatchItems.MoveFirst()
                    For i = 1 To dgvBatchItems.Rows.Count - 1

                        Dim objNewCoderAssignment As New CoderAssignment
                        Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)
                        If currentrow.Item("statuscode").ToString <> "1383" Then
                            strITCode = CType(currentrow.Item("ITCode"), String)
                            objNewCoderAssignment.CoderId = CType(currentrow.Item("CoderID"), Integer)
                            objNewCoderAssignment.ITCode = CType(currentrow.Item("ITCode"), String)
                            objNewCoderAssignment.CaseID = CType(currentrow.Item("CaseID"), Integer)
                            objNewCoderAssignment.MPRID = CType(currentrow.Item("MPRID"), String)
                            objNewCoderAssignment.Instrumentid = CType(currentrow.Item("instrumentid"), Integer)

                            objNewCoderAssignment.Insert()
                        End If

                        Dim objCase As New [Case](CType(currentrow.Item("CaseID"), Integer), False)
                        If objCase.Instruments.Count > 0 Then
                            For j = 0 To objCase.Instruments.Count - 1
                                If _
                                    objCase.Instruments.Item(j).InstrumentID =
                                    CType(currentrow.Item("instrumentid"), Integer) Then
                                    objCase.Instruments.Item(j).CurrentStatus = currentrow.Item("StatusCode").ToString()
                                    objCase.Instruments.Item(j).LogicalStatus = currentrow.Item("StatusCode").ToString()
                                    objCase.Instruments.Item(j).StatusChangedBy = CurrentUser.Name
                                    objCase.Instruments.Item(j).StatusChangeDate = Now
                                    objCase.Instruments.Item(j).Update()
                                End If
                            Next
                        End If
                        bindingsourceBatchItems.MoveNext()
                    Next
                ElseIf menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
                    bindingsourceBatchItems.MoveFirst()
                    For i = 1 To dgvBatchItems.Rows.Count - 1
                        Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)
                        If currentrow.Item("statuscode").ToString <> "1383" Then
                            strITCode = CType(currentrow.Item("ITCode"), String)
                            mdctInstrumentsAdded.TryGetValue(strITCode, intInstrumentId)
                            Dim objNewCoderAssignment As New CoderAssignment(intInstrumentId, 1)
                            objNewCoderAssignment.CoderId = CType(currentrow.Item("CoderID"), Integer)
                            objNewCoderAssignment.ITCode = CType(currentrow.Item("ITCode"), String)
                            objNewCoderAssignment.CaseID = CType(currentrow.Item("CaseID"), Integer)
                            objNewCoderAssignment.MPRID = CType(currentrow.Item("MPRID"), String)
                            objNewCoderAssignment.Instrumentid = CType(currentrow.Item("instrumentid"), Integer)

                            objNewCoderAssignment.Update()
                        Else
                            strITCode = CType(currentrow.Item("ITCode"), String)
                            mdctInstrumentsAdded.TryGetValue(strITCode, intInstrumentId)
                            Dim objNewCoderAssignment As New CoderAssignment(intInstrumentId, 1)
                            objNewCoderAssignment.Update()
                            objNewCoderAssignment.Delete()
                        End If

                        Dim objCase As New [Case](CType(currentrow.Item("CaseID"), Integer), False)
                        If objCase.Instruments.Count > 0 Then
                            For j = 0 To objCase.Instruments.Count - 1
                                If _
                                    objCase.Instruments.Item(j).InstrumentID =
                                    CType(currentrow.Item("instrumentid"), Integer) Then
                                    objCase.Instruments.Item(j).CurrentStatus = currentrow.Item("StatusCode").ToString()
                                    objCase.Instruments.Item(j).LogicalStatus = currentrow.Item("StatusCode").ToString()
                                    objCase.Instruments.Item(j).StatusChangedBy = CurrentUser.Name
                                    objCase.Instruments.Item(j).StatusChangeDate = Now
                                    objCase.Instruments.Item(j).Update()
                                End If
                            Next
                        End If
                        bindingsourceBatchItems.MoveNext()
                    Next
                End If
            Else
                Dim strMsg As String = "No Instruments scanned, please try again"
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            Dim strMsg As String = "Unable to status Instrument " + strITCode + "." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        CheckForCommit = 2
    End Sub

    'Private Sub EndCreateNewBatch(Optional ByVal ShouldSave As Boolean = True)

    '    If mblnCreatingNewBatch Then
    '        If ShouldSave Then
    '            ' create and save all BatchItems
    '            Dim row As DataRow
    '            For Each row In mdtNewAssignments.Rows
    '                ' make sure ITCode is valid
    '                Dim strITCode As String = row.Item("ITCode").ToString

    '                If strITCode.Length = 0 Then
    '                    ' ignore/skip it
    '                ElseIf mdctInstrumentsAdded.ContainsKey(strITCode) Then
    '                    Dim objBatchItem As BatchItem = Nothing

    '                    ' Create BatchItem
    '                    Try
    '                        objBatchItem = New BatchItem(mobjNewBatch)
    '                        objBatchItem.InstrumentID = mdctInstrumentsAdded(strITCode)
    '                        objBatchItem.ITCode = strITCode
    '                        objBatchItem.Notes = row.Item("Notes").ToString
    '                        mobjNewBatch.BatchItems.Add(objBatchItem)
    '                    Catch ex As Exception
    '                        Dim strMsg As String = "Unable to add Instrument " + strITCode + " to Batch." + NewLine + NewLine + _
    '                                               "[Error Details]" + NewLine + _
    '                                               ex.Message
    '                        MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    End Try

    '                    ' Status it
    '                    Try
    '                        objBatchItem.UpdateInstrumentStatus(row.Item("StatusCode").ToString)
    '                    Catch ex As Exception
    '                        Dim strMsg As String = "Unable to status Instrument " + strITCode + "." + NewLine + NewLine + _
    '                                               "[Error Details]" + NewLine + _
    '                                               ex.Message
    '                        MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    End Try
    '                End If
    '            Next
    '        End If 'ShouldSave

    '        If mobjNewBatch.BatchItems.Count = 0 Then
    '            ' Batch is empty, so delete it
    '            mdtBatches.Rows(mdtBatches.Rows.Count - 1).Delete()
    '            mobjNewBatch.Delete()
    '        End If

    '    End If

    '    'Set grid to read only
    '    With dgvBatchItems
    '        .ReadOnly = True
    '        .AllowUserToAddRows = False
    '    End With

    '    SetupStatusCodeLookupForDisplay()
    '    btnCancel.Enabled = False
    '    'mblnCreatingNewBatch = False

    'End Sub

    ' Returns TRUE only if there are available instruments.
    Private Function GetAvailableInstruments() As Boolean
        mdctInstrumentsAvailable.Clear()

        Dim row As DataRow
        For Each row In Batch.InstrumentsAvailable(menmBatchType, CInt(mobjInstrumentType.InstrumentTypeID)).Rows
            mdctInstrumentsAvailable.Add(CStr(row.Item("ITCode")), CInt(row.Item("InstrumentID")))
        Next

        Return (mdctInstrumentsAvailable.Count > 0)
    End Function

    ' build the AutoCompleteStringCollection for ITCode data entry
    Private Function AvailableITCodes() As AutoCompleteStringCollection

        Dim objAutoCompleteCol As New AutoCompleteStringCollection

        Dim entry As KeyValuePair(Of String, Integer)
        For Each entry In mdctInstrumentsAvailable
            objAutoCompleteCol.Add(entry.Key.ToString)  ' add the ITCode
        Next

        Return objAutoCompleteCol
    End Function

    Private Sub SetupDataSources()

        ' BATCHES
        mdtExistingAssignments = New DataTable("CoderAssignments")
        mdtExistingAssignments.Columns.Add("CoderAssignmentID", GetType(Integer))
        mdtExistingAssignments.Columns.Add("CoderID", GetType(Integer))
        mdtExistingAssignments.Columns.Add("ITCode", GetType(String))
        mdtExistingAssignments.Columns.Add("CaseID", GetType(Integer))
        mdtExistingAssignments.Columns.Add("MPRID", GetType(String))
        'mdtExistingAssignments.Columns.Add("Interviewer", GetType(String))
        mdtExistingAssignments.Columns.Add("Bilingual", GetType(String))
        mdtExistingAssignments.Columns.Add("objCoderAssignment", GetType(CoderAssignment))

        ' get all Batches of My BatchType and InstrumentType
        Dim objAssignments As New CoderAssignments()
        If objAssignments.Count > 0 Then
            Dim objAssignment As CoderAssignment
            For Each objAssignment In objAssignments
                AddBatchToBatchesDataSource(objAssignment)
                'txtBatchNotes.ReadOnly = False
            Next
        Else
            'txtBatchNotes.ReadOnly = True
        End If

        ' BATCH ITEMS
        mdtNewAssignments = New DataTable("CoderAssignment")
        mdtNewAssignments.Columns.Add("CoderAssignmentID", GetType(Integer))
        mdtNewAssignments.Columns.Add("CoderID", GetType(Integer))
        mdtNewAssignments.Columns.Add("ITCode", GetType(String))
        mdtNewAssignments.Columns.Add("CaseID", GetType(Integer))
        mdtNewAssignments.Columns.Add("MPRID", GetType(String))
        mdtNewAssignments.Columns.Add("objCoderAssignment", GetType(CoderAssignment))
        mdtNewAssignments.Columns.Add("StatusCode", GetType(String))
        mdtNewAssignments.Columns.Add("Description", GetType(String))
        mdtNewAssignments.Columns.Add("InstrumentId", GetType(Integer))
        'mdtNewAssignments.Columns.Add("Interviewer", GetType(String))
        mdtNewAssignments.Columns.Add("Bilingual", GetType(String))

        ' will be populated during navigation

        SetupStatusCodeLookupForDisplay()
        SetupCoderLookupForDisplay()
    End Sub

    ' setup the Coder combobox lookup for user to edit
    Private Sub SetupCoderLookupForNewBatch()
        Dim strMsg As String

        Try
            If menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
                mdtCoders = mobjCoders.SelectAllPlusConsensus
            Else
                mdtCoders = mobjCoders.SelectAllActual
            End If

            If (mdtCoders IsNot Nothing) AndAlso (mdtCoders.Rows.Count > 0) Then
                bindingsourceCoders.DataSource = mdtCoders
                bindingsourceCoders.Sort = "FullName"
                Dim cbocol As DataGridViewComboBoxColumn = CType(dgvBatchItems.Columns("Coder"),
                                                                 DataGridViewComboBoxColumn)
                With cbocol
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                    .DropDownWidth = 350
                    .DataPropertyName = "CoderID" ' i.e. tblCoderAssignments column name
                    .ValueMember = "CoderID" ' ' i.e. tlkpCoders column name
                    .DisplayMember = "FullName"
                End With
            Else
                strMsg = "No Coders available." + Environment.NewLine +
                         "If problem persists, please notify technical support."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            strMsg = "A problem occurred trying to retrieve available Coders from database." + Environment.NewLine +
                     "If problem persists, please notify technical support." + Environment.NewLine + Environment.NewLine +
                     "[Error Details]" + Environment.NewLine +
                     ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' setup the Status combobox lookup for user to edit per row
    Private Sub SetupCoderLookupForNewBatch(coderid As Integer)
        Dim strMsg As String

        Try
            mdtCoders = mobjCoders.SelectAllActual
            If (mdtCoders IsNot Nothing) AndAlso (mdtCoders.Rows.Count > 0) Then
                bindingsourceCoders.DataSource = mdtCoders
                bindingsourceCoders.Sort = "FullName"
                Dim cbocol As DataGridViewComboBoxColumn = CType(dgvBatchItems.Columns("Coder"),
                                                                 DataGridViewComboBoxColumn)
                With cbocol
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                    .DropDownWidth = 350
                    .DataPropertyName = "CoderID" ' i.e. tblCoderAssignments column name
                    .ValueMember = "CoderID" ' ' i.e. tlkpCoders column name
                    .DisplayMember = "FullName"
                End With
            Else
                strMsg = "No Coders available." + Environment.NewLine +
                         "If problem persists, please notify technical support."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            strMsg = "A problem occurred trying to retrieve available Coders from database." + Environment.NewLine +
                     "If problem persists, please notify technical support." + Environment.NewLine + Environment.NewLine +
                     "[Error Details]" + Environment.NewLine +
                     ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' setup the Status combobox lookup for user to edit
    Private Sub SetupStatusCodeLookupForNewBatch()
        Dim strMsg As String

        Try
            mdtStatusCodes = Batch.AssignableStatusCodes(menmBatchType)
            If (mdtStatusCodes IsNot Nothing) AndAlso (mdtStatusCodes.Rows.Count > 0) Then
                bindingsourceStatusCodes.DataSource = mdtStatusCodes
                bindingsourceStatusCodes.Sort = "DisplayMember"
                Dim cbocol As DataGridViewComboBoxColumn = CType(dgvBatchItems.Columns("StatusCode"),
                                                                 DataGridViewComboBoxColumn)
                With cbocol
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                    .DropDownWidth = 350
                    .DataPropertyName = "StatusCode"    ' i.e. tblInstrument column name
                    .ValueMember = "Code"               ' i.e. tlkpStatus column name
                    .DisplayMember = "DisplayMember" _
                    '!? ... ommitting this assignment results in [delayed] runtime exception! ("Column 'DisplayMember' does not belong to table Table.")
                End With
            Else
                strMsg = "No Status Codes available." + Environment.NewLine +
                         "If problem persists, please notify technical support."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            strMsg = "A problem occurred trying to retrieve available Status Codes from database." + Environment.NewLine +
                     "If problem persists, please notify technical support." + Environment.NewLine + Environment.NewLine +
                     "[Error Details]" + Environment.NewLine +
                     ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' Setup the Status combobox lookup for display.
    ' We need to accomodate all status codes, because status may have been changed elsewhere in SMS
    ' If we don't have it as potential value, datagrid will throw a nonfatal exception ("DataGridViewComboBoxCell value is not valid").
    Private Sub SetupStatusCodeLookupForDisplay()
        Dim strMsg As String

        Try
            mdtStatusCodes = Batch.AllStatusCodes
            If (mdtStatusCodes IsNot Nothing) AndAlso (mdtStatusCodes.Rows.Count > 0) Then
                bindingsourceStatusCodes.DataSource = mdtStatusCodes
                Dim cbocol As DataGridViewComboBoxColumn = CType(dgvBatchItems.Columns("StatusCode"),
                                                                 DataGridViewComboBoxColumn)
                With cbocol
                    .DataPropertyName = "StatusCode" ' i.e. tblInstrument column name
                    .ValueMember = "Code"            ' i.e. tlkpStatus column name
                    .DisplayMember = "DisplayMember"
                    ' we don't want the dropdown showing
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                End With
            Else
                strMsg = "No Status Codes available." + Environment.NewLine +
                         "If problem persists, please notify technical support."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            strMsg = "A problem occurred trying to retrieve available Status Codes from database." + Environment.NewLine +
                     "If problem persists, please notify technical support." + Environment.NewLine + Environment.NewLine +
                     "[Error Details]" + Environment.NewLine +
                     ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' Setup the Coder combobox lookup for display.
    ' We need to accomodate all status codes, because status may have been changed elsewhere in SMS
    ' If we don't have it as potential value, datagrid will throw a nonfatal exception ("DataGridViewComboBoxCell value is not valid").
    Private Sub SetupCoderLookupForDisplay()
        Dim strMsg As String

        Try
            If menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
                mdtCoders = mobjCoders.SelectAllPlusConsensus
            Else
                mdtCoders = mobjCoders.SelectAllActual
            End If

            If (mdtCoders IsNot Nothing) AndAlso (mdtCoders.Rows.Count > 0) Then
                bindingsourceCoders.DataSource = mdtCoders
                Dim cbocol As DataGridViewComboBoxColumn = CType(dgvBatchItems.Columns("Coder"),
                                                                 DataGridViewComboBoxColumn)
                With cbocol
                    .DataPropertyName = "CoderID" ' i.e. tblCoderAssignments column name
                    .ValueMember = "CoderID" ' ' i.e. tlkpCoders column name
                    .DisplayMember = "FullName"
                    ' we don't want the dropdown showing
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                End With
            Else
                strMsg = "No Coders available." + Environment.NewLine +
                         "If problem persists, please notify technical support."
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            strMsg = "A problem occurred trying to retrieve available Coders from database." + Environment.NewLine +
                     "If problem persists, please notify technical support." + Environment.NewLine + Environment.NewLine +
                     "[Error Details]" + Environment.NewLine +
                     ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' returns the newly added row
    Private Function AddBatchToBatchesDataSource(objAssignment As CoderAssignment) As DataRow

        If objAssignment IsNot Nothing Then
            Dim objRow(5) As Object
            objRow(0) = GetSafeValue(objAssignment.CoderAssignmentID)
            objRow(1) = GetSafeValue(objAssignment.CoderId)
            objRow(2) = GetSafeValue(objAssignment.ITCode)
            objRow(3) = GetSafeValue(objAssignment.Caseid)
            objRow(4) = GetSafeValue(objAssignment.Mprid)
            objRow(5) = objAssignment
            Return mdtExistingAssignments.Rows.Add(objRow)
        Else
            Return Nothing
        End If
    End Function

    ' in effect, this fills the BatchItems grid
    Private Sub FillBatchItemsDataSource(objAssignment As CoderAssignment)

        mdtNewAssignments.Clear()

        ' fill it
        'Dim objbatchitem As BatchItem
        'If objBatch.BatchItems.Count > 0 Then
        '    For Each objBatchItem In objBatch.BatchItems
        '        Dim objRow(3) As Object
        '        objRow(0) = objBatchItem.ITCode
        '        objRow(1) = InstrumentTypeDescription(objBatchItem.Instrument.InstrumentType)
        '        objRow(2) = GetSafeValue(objBatchItem.Instrument.StatusCode)
        '        objRow(3) = GetSafeValue(objBatchItem.Notes)
        '        mdtBatchItems.Rows.Add(objRow)
        '    Next
        'End If
    End Sub

    ' 3/31/09:  Project requested we display In Home instrument as "In-Home (2 Bags)", but we couldn't
    '           simply change in db because other SMS code depends on Description='In Home'.
    Private Function InstrumentTypeDescription(instType As InstrumentType) As String
        If instType Is Nothing Then
            Return ""
        ElseIf instType.InstrumentTypeID = 32 Then ' In-Home
            Return instType.Description.ToString + " (2 Bags)"
        Else
            Return instType.Description.ToString
        End If
    End Function

    'Private Sub btnPrintBatchSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBatchSheet.Click
    '    If mblnCreatingNewBatch Then
    '        EndCreateNewBatch()
    '    End If

    '    If bindingsourceBatches.Current IsNot Nothing Then
    '        Dim objBatch As Batch = CType(CType(bindingsourceBatches.Current, DataRowView).Row.Item("objBatch"), Batch)
    '        SMS.DocumentProcessing.Reports.ShowReport(Project.ShortName & "\Batching", "BatchSheet.rpt", True, GetSafeValue(objBatch.BatchID).ToString)
    '    Else
    '        MessageBox.Show("Nothing to print.", "Print Batch Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If

    'End Sub

#End Region

    Private Sub dgvBatchItems_MouseLeave(sender As Object, e As EventArgs) Handles dgvBatchItems.MouseLeave
        If menmBatchType = Data.Enumerations.BatchType.ReassignDVD Then
            'AF 2/22/11 - added rowcount check to prevent crash when no rows are loaded. 
            If dgvBatchItems.RowCount > 0 AndAlso dgvBatchItems.CurrentCell.ColumnIndex <> 0 Then
                dgvBatchItems.EndEdit()
            End If
        End If
    End Sub
End Class
