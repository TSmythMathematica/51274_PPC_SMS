'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing
Imports MPR.SMS.DocumentProcessing.ReportService
Imports MPR.SMS.Security

Public Class frmBatchCreate2

#Region "Private Fields"

    Dim ReadOnly menmBatchType As Data.Enumerations.BatchType

    Dim mblnCreatingNewBatch As Boolean = False

    Dim ReadOnly mdctInstrumentsAvailable As New Dictionary(Of String, Integer)  ' i.e. (ITCode, InstrumentID)
    Dim ReadOnly mdctInstrumentsAdded As New Dictionary(Of String, Integer)

    Dim WithEvents mdtBatches As DataTable
    Dim mdtBatchItems As DataTable

    Dim mobjNewBatch As Batch
    Dim mobjInstrumentType As InstrumentType

    Dim mdtStatusCodes As DataTable

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

    Private Sub frmBatchCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PROMPT for instrument type
        ' PROMPT for instrument type
        Dim frm As frmBatchInstrumentType = New frmBatchInstrumentType(menmBatchType)
        frm.ShowDialog()

        ' did user cancel?
        If (frm.DialogResult = DialogResult.Cancel) OrElse (frm.InstrumentType Is Nothing) Then
            ' CLOSE THIS FORM
            Me.DialogResult = DialogResult.Cancel
            Me.Close() '>>>>

        Else
            ' SETUP THIS FORM 
            mobjInstrumentType = frm.InstrumentType

            If menmBatchType = Data.Enumerations.BatchType.Final Then
                btnPrintBatchSheet.Visible = False
            Else
                btnPrintBatchSheet.Visible = True
            End If

            ' Can only add batches if there are available Instruments
            Try
                If GetAvailableInstruments() Then
                    btnCreateNewBatch.Enabled = True
                Else
                    btnCreateNewBatch.Enabled = False
                End If
            Catch ex As Exception
                btnCreateNewBatch.Enabled = False
            End Try

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
            bindingsourceBatches.DataSource = mdtBatches
            bindingsourceBatchItems.DataSource = mdtBatchItems
            txtBatchID.DataBindings.Add(New Binding("Text", bindingsourceBatches, "PublicBatchID"))
            txtBatchNumber.DataBindings.Add(New Binding("Text", bindingsourceBatches, "BatchNumber"))
            txtBatchNotes.DataBindings.Add(New Binding("Text", bindingsourceBatches, "Notes"))

            SetFormTitle()
            bindingsourceBatches.MoveLast()
            dgvBatchItems.Select()
        End If

        btnCancel.Enabled = False
    End Sub

    Private Sub frmBatchCreate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If mblnCreatingNewBatch Then
            Dim strMsg As String =
                    "Are you sure you want to discard this batch?  Press No to return to the batch or Yes to close without saving."
            If _
                Not _
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                DialogResult.Yes Then
                e.Cancel = True
                Exit Sub
            Else
                EndCreateNewBatch(False)
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If mblnCreatingNewBatch Then
            EndCreateNewBatch()
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If mblnCreatingNewBatch Then
            Dim strMsg As String = "Are you sure you want to discard this batch, discarding all status code changes?"
            If _
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                DialogResult.Yes Then
                EndCreateNewBatch(False)
            End If
        End If
    End Sub


    Private Sub btnCreateNewBatch_Click(sender As Object, e As EventArgs) Handles btnCreateNewBatch.Click

        If mblnCreatingNewBatch Then
            ' just in case user is clicking button again (but didn't add any items)
            If (mdtBatchItems.Rows.Count = 0) Then
                ' do nothing (i.e. let user work with the already-created, empty batch)
            Else
                EndCreateNewBatch()
                BeginCreateNewBatch()
            End If

        Else
            BeginCreateNewBatch()
        End If
    End Sub

    Private Sub bindingsourceBatches_PositionChanged(sender As Object, e As EventArgs) _
        Handles bindingsourceBatches.PositionChanged
        If mblnCreatingNewBatch Then
            ' if moving away from new Batch record, then End editing of that batch
            If (bindingsourceBatches.Position <> bindingsourceBatches.Count - 1) Then
                EndCreateNewBatch()
            End If
        End If

        ' populate the BatchItems grid
        If bindingsourceBatches.Current IsNot Nothing Then
            FillBatchItemsDataSource(CType(CType(bindingsourceBatches.Current, DataRowView).Row.Item("objBatch"), Batch))
        End If
    End Sub

    Private Sub dgvBatchItems_CellEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvBatchItems.CellEnter
        If mblnCreatingNewBatch AndAlso (dgvBatchItems.CurrentRow IsNot Nothing) Then
            Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)
            If IsDBNull(currentrow.Item("ITCode")) Then
                BatchItemsGridReadOnly(False, True)
            Else
                BatchItemsGridReadOnly(False, False)
            End If
        End If
    End Sub

    Private Sub dgvBatchItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
        Handles dgvBatchItems.DataError
        Debug.WriteLine(e.RowIndex)

        Dim strMessage As String = "Problem encountered in the grid." + Environment.NewLine _
                                   + "Please report the following info to tech support." + Environment.NewLine +
                                   Environment.NewLine _
                                   + e.Exception.Message

        If mblnCreatingNewBatch Then
            ' abort the batch
            strMessage = "Batch needs to be discarded." + Environment.NewLine _
                         + strMessage
            MessageBox.Show(strMessage, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EndCreateNewBatch(False)
        Else
            ' close the form
            strMessage = "Closing this form due to error." + Environment.NewLine _
                         + strMessage
            MessageBox.Show(strMessage, Project.ShortName & " - DataGridView error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub


    Private Sub dgvBatchItems_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles dgvBatchItems.EditingControlShowing

        If dgvBatchItems.CurrentCell.OwningColumn.Name = "ITCode" Then
            ' setup AutoComplete
            Dim txt As TextBox
            txt = TryCast(e.Control, TextBox)
            If txt IsNot Nothing Then
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource
                txt.AutoCompleteCustomSource = AvailableITCodes()
            End If
        End If
    End Sub

    Private Sub dgvBatchItems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) _
        Handles dgvBatchItems.CellValidating
        Dim cell As DataGridViewCell = dgvBatchItems.Item(e.ColumnIndex, e.RowIndex)
        Dim ctrl As Control = dgvBatchItems.EditingControl

        Try

            ' Validate ITCode
            If cell.IsInEditMode AndAlso dgvBatchItems.Columns(e.ColumnIndex).Name = "ITCode" Then
                Dim strITCode As String = ctrl.Text
                Dim intInstrumentID As Integer

                If strITCode.Length = 0 Then
                    ' ignore it
                    ' (user may have accidentally entered an ITCode, then cleared it, which is ok).

                ElseIf Not mdctInstrumentsAvailable.TryGetValue(strITCode, intInstrumentID) Then
                    ' INVALID
                    Dim msg As String = "The ITCode you entered is not in the list" + Environment.NewLine +
                                        Environment.NewLine +
                                        "Please enter (or select) an ITCode from the list."
                    MessageBox.Show(msg, "Invalid ITCode", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True

                Else
                    ' VALID
                    ' save intInstrumentID
                    If Not mdctInstrumentsAdded.ContainsKey(strITCode) Then
                        mdctInstrumentsAdded.Add(strITCode, intInstrumentID)
                    End If

                    ' make unavailable
                    If mdctInstrumentsAvailable.ContainsKey(strITCode) Then
                        mdctInstrumentsAvailable.Remove(strITCode)
                    End If

                    'If mobjInstrumentType.InstrumentTypeID = 32 Then ' 32 = In-Home
                    '    ' User scanned in one IT code, now fill the grid with all available instruments in the booklet
                    '    mdtBatchItems.Clear()
                    '    Dim dtBooklet As DataTable = Batch.InstrumentsInBooklet(intInstrumentID, menmBatchType)
                    '    Dim row As DataRow
                    '    For Each row In dtBooklet.Rows
                    '        ' add to grid datasource
                    '        Dim rowBatchItem As DataRow = mdtBatchItems.Rows.Add()
                    '        rowBatchItem("ITCode") = row("ITCode")
                    '        rowBatchItem("Description") = row("Description")

                    '        Dim strStatusCode As String = BatchItem.StatusCodeWhenBatched(menmBatchType, row("StatusCode").ToString)
                    '        AddStatusCode(strStatusCode) ' need to ensure it is in list, otherwise dgv will throw error
                    '        rowBatchItem("StatusCode") = strStatusCode

                    '        ' save intInstrumentID (todo:?  yes, this data structure is now redundant; we could do better)
                    '        If Not mdctInstrumentsAdded.ContainsKey(row("ITCode").ToString) Then
                    '            mdctInstrumentsAdded.Add(row("ITCode").ToString, CType(row("InstrumentID"), Integer))
                    '        End If
                    '    Next

                    '    ' lockdown the grid/columns...
                    '    BatchItemsGridReadOnly(False, False)
                    '    dgvBatchItems.Columns("ITCode").ReadOnly = True
                    '    dgvBatchItems.AllowUserToAddRows = False

                    ' If mobjInstrumentType.InstrumentTypeID >= 30 Then    ' 35 = DVD
                    Dim currentrow As DataRowView = CType(bindingsourceBatchItems.Current, DataRowView)
                    ' add to grid datasource
                    currentrow.Item("ITCode") = strITCode
                    ' assign values to other columns
                    currentrow.Item("Description") = mobjInstrumentType.Description
                    Dim strstatuscode As String = BatchItem.StatusCodeWhenBatched(menmBatchType)
                    AddStatusCode(strstatuscode) ' need to ensure it is in list, otherwise dgv will throw error
                    currentrow.Item("StatusCode") = strstatuscode
                    dgvBatchItems.Refresh() _
                    ' w/o this, the new StatusCode value didn't display (until user activated the cell).
                    'End If

                    BatchItemsGridReadOnly(False, False)
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
    '''     Adds a status code to the allowable list of status codes.
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
        If mblnCreatingNewBatch AndAlso mdtBatchItems.Rows.Count = mobjNewBatch.MaxBatchSize Then
            dgvBatchItems.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub mdtBatches_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs) _
        Handles mdtBatches.ColumnChanged

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

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub SetFormTitle()
        Dim strTitle As String

        If menmBatchType = Data.Enumerations.BatchType.QC Then
            strTitle = "Receipt and Create QC Transmittal"
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
            Dim strMsg As String = "There are no instruments available for this type of Batch."
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCreateNewBatch.Enabled = False
            Exit Sub ' >>>>
        End If

        ' create the batch
        Try
            mobjNewBatch = New Batch(menmBatchType, mobjInstrumentType)
        Catch ex As Exception
            Dim strMsg As String = "Unable to Create new batch." + Environment.NewLine +
                                   "If problem persists, please notify technical support." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub ' >>>>
        End Try

        AddBatchToBatchesDataSource(mobjNewBatch)

        ' prepare for new Batch Items
        mdtBatchItems.Clear()
        BatchItemsGridReadOnly(False, True)
        dgvBatchItems.AllowUserToAddRows = True
        SetupStatusCodeLookupForNewBatch()

        ' select the grid
        bindingsourceBatches.MoveLast()
        dgvBatchItems.CurrentCell = dgvBatchItems.Item(0, 0)
        dgvBatchItems.Select()

        txtBatchNotes.ReadOnly = False ' (it would have been ReadOnly if this is the first Batch).

        mblnCreatingNewBatch = True

        btnCancel.Enabled = True
    End Sub

    ' This is useful because, unfortunately, setting DataGridView.ReadOnly overrides all the
    ' design-time Column.ReadOnly values.
    Private Sub BatchItemsGridReadOnly(isGridReadOnly As Boolean,
                                       Optional ByVal isAllButITCodeColumnReadOnly As Boolean = True)

        dgvBatchItems.ReadOnly = isGridReadOnly
        dgvBatchItems.Columns("Description").ReadOnly = True ' always
        dgvBatchItems.Columns("StatusCode").ReadOnly = isAllButITCodeColumnReadOnly
        dgvBatchItems.Columns("Notes").ReadOnly = isAllButITCodeColumnReadOnly
    End Sub

    Private Sub EndCreateNewBatch(Optional ByVal ShouldSave As Boolean = True)

        If mblnCreatingNewBatch Then
            If ShouldSave Then
                ' create and save all BatchItems
                Dim row As DataRow
                Dim strListofIds As String = ""
                Dim objBatchType As New BatchType(menmBatchType)
                Dim Ids(GetSafeValue(objBatchType.MaxBatchSizeDefault)) As String
                Dim i As Integer = 0

                For Each row In mdtBatchItems.Rows
                    Dim strITCode As String = row.Item("ITCode").ToString

                    If strITCode.Length = 0 Then
                        ' ignore/skip it
                    ElseIf mdctInstrumentsAdded.ContainsKey(strITCode) Then

                        If row.Item("StatusCode").ToString = "0000" Then
                            Ids(i) = row.Item("ITCode").ToString
                            i = i + 1
                            If strListofIds = "" Then
                                strListofIds = row.Item("ITCode").ToString
                            Else
                                strListofIds = strListofIds + ", " + row.Item("ITCode").ToString
                            End If
                        End If
                    End If
                Next

                Dim result As Integer
                If strListofIds <> "" Then
                    result =
                        MsgBox(
                            "The following instruments will be reset to '0000 Untouched' and removed from all batches. Are you sure you wish to proceed?  " +
                            strListofIds, MsgBoxStyle.YesNo, "Instruments will be removed from Batches")
                End If

                If result = vbNo Then
                    Exit Sub
                End If

                If result = vbYes Then
                    Dim j As Integer = 0
                    For j = 0 To (i - 1)
                        'remove instrument from all existing batches.
                        Dim objBatchItemstoberemoved As BatchItem = Nothing
                        objBatchItemstoberemoved = New BatchItem(mobjNewBatch)
                        objBatchItemstoberemoved.InstrumentID = mdctInstrumentsAdded(Ids(j))
                        objBatchItemstoberemoved.SelectOne()
                        objBatchItemstoberemoved.DeleteAllWInstrumentIDLogic()

                        'Update status code of instrument back to status prior to having been receipted.
                        'Dim objInstrumenttoStatus As Instrument = Nothing
                        'objInstrumenttoStatus = New Instrument(mdctInstrumentsAdded(Ids(j)), GetSafeValue(mobjInstrumentType.InstrumentTypeID))

                        'objInstrumenttoStatus.StatusCode = "0000"
                        'objInstrumenttoStatus.Update()

                        Dim k As Integer
                        Dim objCase As New [Case](CType(objBatchItemstoberemoved.Instrument.CaseID, Integer), False)
                        If objCase.Instruments.Count > 0 Then
                            For k = 0 To objCase.Instruments.Count - 1
                                If objCase.Instruments.Item(j).InstrumentID = mdctInstrumentsAdded(Ids(j)) Then
                                    objCase.Instruments.Item(j).CurrentStatus = "0000"
                                    objCase.Instruments.Item(j).StatusChangedBy = CurrentUser.Name
                                    objCase.Instruments.Item(j).StatusChangeDate = Now
                                    objCase.Instruments.Item(j).Update()
                                End If
                            Next
                        End If
                    Next j
                End If

                For Each row In mdtBatchItems.Rows
                    ' make sure ITCode is valid
                    Dim strITCode As String = row.Item("ITCode").ToString

                    If strITCode.Length = 0 Or row.Item("StatusCode").ToString = "0000" Then
                        ' ignore/skip it
                    ElseIf mdctInstrumentsAdded.ContainsKey(strITCode) Then
                        Dim objBatchItem As BatchItem = Nothing

                        ' Create BatchItem
                        Try
                            objBatchItem = New BatchItem(mobjNewBatch)
                            objBatchItem.InstrumentID = mdctInstrumentsAdded(strITCode)
                            objBatchItem.ITCode = strITCode
                            objBatchItem.Notes = row.Item("Notes").ToString
                            mobjNewBatch.BatchItems.Add(objBatchItem)
                        Catch ex As Exception
                            Dim strMsg As String = "Unable to add Instrument " + strITCode + " to Batch." +
                                                   Environment.NewLine + Environment.NewLine +
                                                   "[Error Details]" + Environment.NewLine +
                                                   ex.Message
                            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Try

                        ' Status it
                        Try
                            Dim strOldStatus As New Status(objBatchItem.Instrument.CurrentStatus.ToString)

                            Dim strnewstatus As New Status(row.Item("StatusCode").ToString)

                            Try
                                objBatchItem.UpdateInstrumentStatus(row.Item("StatusCode").ToString)
                            Catch ex As Exception
                                Dim strMsg As String = "Unable to status Instrument " + strITCode + "." +
                                                       Environment.NewLine + Environment.NewLine +
                                                       "[Error Details]" + Environment.NewLine +
                                                       ex.Message
                                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation)
                            End Try

                            If _
                                (strOldStatus.IsCaseInLocatingSupervisor = True) And
                                strnewstatus.IsCaseInLocatingSupervisor = False And strnewstatus.IsFinalStatus = True _
                                Then

                                'create a locating attempt record, with a note, indicating the original
                                'respondent in locating had a final status outside of locating.
                                'for each case member still in locating, add the attempt/note
                                Dim mobjPerson As New Person(Strings.Left(row.Item("ITCode").ToString, 8))
                                mobjPerson.Case = New [Case](GetSafeValue(mobjPerson.CaseID), False)

                                Dim mobjCase As New [Case](mobjPerson.CaseID.Value, True)

                                Dim mobjInstrument As New Instrument(mobjCase)

                                Dim j As Integer
                                For j = 0 To mobjCase.Instruments.Count - 1
                                    If _
                                        mobjCase.Instruments(j).InstrumentTypeID.Value =
                                        (mobjInstrumentType.InstrumentTypeID.Value) Then
                                        mobjInstrument = mobjCase.Instruments(j)
                                        Exit For
                                    End If
                                Next

                                Dim objCRPerson As New Person(mobjInstrument.CurrentRespondentMPRID.ToString)
                                objCRPerson.Case = New [Case](GetSafeValue(objCRPerson.CaseID), False)

                                For Each objPerson As Person In mobjCase.Persons
                                    If objPerson.LocatingStatus IsNot Nothing AndAlso
                                       (objPerson.LocatingStatus.Status.IsCaseInLocating Or
                                        objPerson.LocatingStatus.Status.IsCaseInLocatingSupervisor Or
                                        objPerson.MPRID.ToString.Equals(mobjInstrument.CurrentRespondentMPRID)) Then
                                        Dim objLocAtt As New LocatingAttempt(objPerson)
                                        With objLocAtt
                                            .Person = objPerson
                                            .PersonLocated = objCRPerson
                                            .Note = GetSafeValue(mobjInstrument.InstrumentType.Description) &
                                                    " has been final statused as " & strnewstatus.Code.ToString &
                                                    " for " & objCRPerson.FullName & " (" & objCRPerson.MPRID.ToString &
                                                    ")"
                                            .LocatingStatus = strnewstatus.Code
                                            .LocatingAttemptTypeID = 0      'Other
                                            .LocatingAttemptResultID = 0    'No new info found
                                            .LocatingAttemptDate = Now
                                        End With

                                    End If
                                Next

                                'then if there are no other instruments in Locating for 
                                'this Respondent, then update LocatingStatus to take them
                                'out of Locating.
                                Dim blnOutOfLocating As Boolean = True
                                For Each objInst As Instrument In mobjCase.Instruments
                                    If _
                                        objInst.CurrentRespondentMPRID.ToString.Equals(objCRPerson.MPRID.ToString) AndAlso
                                        Not objInst.InstrumentID.Value.Equals(mobjInstrument.InstrumentID.Value) AndAlso
                                        (objInst.Status.IsCaseInLocating Or
                                         objInst.Status.IsCaseInLocatingSupervisor) Then
                                        blnOutOfLocating = False
                                        Exit For
                                    End If
                                Next

                                If blnOutOfLocating Then
                                    'take respondent out of locating

                                    Dim sPrevLastModifiedby As String = ""
                                    Dim blnUpdateLastModified As Boolean = False

                                    'Dim blnIsFinalUnlocatable As Boolean = GetSafeValue(mobjInstrument.CurrentStatus).Equals("2590") Or _
                                    '                                       GetSafeValue(mobjInstrument.CurrentStatus).Equals("2591")
                                    Dim blnIsFinalUnlocatable As Boolean =
                                            GetSafeValue(mobjInstrument.CurrentStatus).StartsWith("25")

                                    Try
                                        With objCRPerson.LocatingStatus
                                            'first store current LastModifiedBy...
                                            sPrevLastModifiedby = GetSafeValue(.LastModifiedBy)

                                            If blnIsFinalUnlocatable Then _
'if 2590 or 2591 just set locating code = status code
                                                .LocatingStatus = strnewstatus.Code
                                            ElseIf mobjInstrument.Status.IsCAWIStatus Or
                                                   mobjInstrument.Status.IsCAPIStatus Or
                                                   mobjInstrument.Status.IsHardcopyStatus Then
                                                .LocatingStatus = "1891"     'address found?
                                                blnUpdateLastModified = True
                                            Else
                                                .LocatingStatus = "1890"     'phone # found
                                                blnUpdateLastModified = True
                                            End If
                                            .StatusDate = Now
                                            .Update()
                                        End With
                                    Catch ex As Exception
                                        MessageBox.Show(
                                            "Problem removing " & objCRPerson.MPRID.ToString & " from Locating  " _
                                            & "Please report this error to tech support:" _
                                            & Environment.NewLine & Environment.NewLine & ex.Message,
                                            Project.ShortName & " - Remove from Locating Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                                    End Try

                                    mobjCase.Update()

                                    If blnUpdateLastModified Then
                                        objCRPerson.LocatingStatus.UpdateLastModifiedBy(
                                            objCRPerson.LocatingStatus.LocatingStatusID, sPrevLastModifiedby)
                                    End If
                                End If
                            End If

                            If menmBatchType = Data.Enumerations.BatchType.SupReviewDVD Then
                                If row.Item("StatusCode").ToString() = "366" Then
                                    Dim objCoderAssignment As New CoderAssignment
                                    'Dim objCoder As New Coder(2)
                                    With objCoderAssignment
                                        .Instrument = objBatchItem.Instrument
                                        .Instrumentid = objBatchItem.InstrumentID
                                        .CaseID = objBatchItem.Instrument.CaseID
                                        .MPRID = objBatchItem.Instrument.CurrentRespondentMPRID
                                        .ITCode = objBatchItem.ITCode
                                        .CoderId = 2
                                        .Insert()
                                    End With
                                End If
                            End If

                        Catch ex As Exception
                            Dim strMsg As String = "Unable to update locating status for Instrument " + strITCode + "." +
                                                   Environment.NewLine + Environment.NewLine +
                                                   "[Error Details]" + Environment.NewLine +
                                                   ex.Message
                            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Try
                    End If
                Next
            End If 'ShouldSave

            If mobjNewBatch.BatchItems.Count = 0 Or ShouldSave = False Then
                ' Batch is empty, so delete it

                Dim s As Integer = 0
                If Not mdtBatchItems.Rows.Count = 0 Then
                    For s = (mdtBatchItems.Rows.Count - 1) To 0 Step - 1
                        mdtBatchItems.Rows(s).Delete()
                    Next s
                End If

                mdtBatches.Rows(mdtBatches.Rows.Count - 1).Delete()
                mobjNewBatch.Delete()

            End If

        End If

        With dgvBatchItems
            .ReadOnly = True
            .AllowUserToAddRows = False
            .Refresh()
        End With

        SetupStatusCodeLookupForDisplay()
        mblnCreatingNewBatch = False
        btnCancel.Enabled = False
    End Sub

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
        mdtBatches = New DataTable("Batches")
        mdtBatches.Columns.Add("BatchID", GetType(Integer))
        mdtBatches.Columns.Add("PublicBatchID", GetType(Integer))
        mdtBatches.Columns.Add("Notes", GetType(String))
        mdtBatches.Columns.Add("BatchNumber", GetType(String))
        mdtBatches.Columns.Add("objBatch", GetType(Batch))

        ' get all Batches of My BatchType and InstrumentType
        'Dim objBatches As New Batches(menmBatchType, Me.mobjInstrumentType)
        'If objBatches.Count > 0 Then
        '    Dim objBatch As Batch
        '    For Each objBatch In objBatches
        '        AddBatchToBatchesDataSource(objBatch)
        '        txtBatchNotes.ReadOnly = False
        '    Next
        'Else
        '    txtBatchNotes.ReadOnly = True
        'End If

        ' BATCH ITEMS
        mdtBatchItems = New DataTable("BatchItems")
        mdtBatchItems.Columns.Add("ITCode", GetType(String))
        mdtBatchItems.Columns.Add("Description", GetType(String))
        mdtBatchItems.Columns.Add("StatusCode", GetType(String))
        mdtBatchItems.Columns.Add("Notes", GetType(String))
        ' will be populated during navigation

        SetupStatusCodeLookupForDisplay()
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
                cbocol.DisplayMember = "DisplayMember"
                cbocol.DataPropertyName = "StatusCode"
                cbocol.ValueMember = "Code"
                cbocol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                cbocol.DropDownWidth = 350
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
                    .ValueMember = "Code" ' ' i.e. tlkpStatus column name
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

    ' returns the newly added row
    Private Function AddBatchToBatchesDataSource(objBatch As Batch) As DataRow

        If objBatch IsNot Nothing Then
            Dim objRow(4) As Object
            objRow(0) = GetSafeValue(objBatch.BatchID)
            objRow(1) = GetSafeValue(objBatch.PublicBatchID)
            objRow(2) = GetSafeValue(objBatch.Notes)
            objRow(3) = GetSafeValue(objBatch.BatchNumber)
            objRow(4) = objBatch
            Return mdtBatches.Rows.Add(objRow)
        Else
            Return Nothing
        End If
    End Function

    ' in effect, this fills the BatchItems grid
    Private Sub FillBatchItemsDataSource(objBatch As Batch)

        mdtBatchItems.Clear()

        ' fill it
        Dim objBatchItem As BatchItem
        If objBatch.BatchItems.Count > 0 Then
            For Each objBatchItem In objBatch.BatchItems
                'AF 05/21/10 Default to complete for final statusing
                If objBatch.BatchType = Data.Enumerations.BatchType.Final Then _
                    objBatchItem.Instrument.CurrentStatus = "2040"
                Dim objRow(3) As Object
                objRow(0) = objBatchItem.ITCode
                objRow(1) = InstrumentTypeDescription(objBatchItem.Instrument.InstrumentType)
                objRow(2) = GetSafeValue(objBatchItem.Instrument.CurrentStatus)
                objRow(3) = GetSafeValue(objBatchItem.Notes)
                mdtBatchItems.Rows.Add(objRow)
            Next
        End If
    End Sub

    Private Function InstrumentTypeDescription(instType As InstrumentType) As String
        If instType Is Nothing Then
            Return ""
        Else
            Return instType.Description.ToString
        End If
    End Function

    Private Sub btnPrintBatchSheet_Click(sender As Object, e As EventArgs) Handles btnPrintBatchSheet.Click
        If mblnCreatingNewBatch Then
            EndCreateNewBatch()
        End If

        If bindingsourceBatches.Current IsNot Nothing Then
            Try
                Dim objBatch As Batch = CType(CType(bindingsourceBatches.Current, DataRowView).Row.Item("objBatch"),
                                              Batch)

                'SSRS Version
                Dim parameter As New ParameterValue
                With parameter
                    .Name = "BatchID"
                    .Value = GetSafeValue(objBatch.BatchID).ToString
                End With
                Dim parameterList As New List(Of ParameterValue)
                parameterList.Add(parameter)
                Reports.ShowReport(Project.ShortName, "BatchSheet", Project.ProjectCode, True, Nothing, parameterList)

                'Crystal Version
                'SMS.DocumentProcessing.Reports.ShowReport(Project.ShortName & "\Batching", "BatchSheet.rpt", True, GetSafeValue(objBatch.BatchID).ToString)
            Catch ex As Exception
                Dim strMsg As String = "A problem occurred trying to print the batch sheet." + Environment.NewLine +
                                       "If problem persists, please notify technical support." + Environment.NewLine +
                                       Environment.NewLine +
                                       "[Error Details]" + Environment.NewLine +
                                       ex.Message
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Nothing to print.", "Print Batch Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region
End Class
