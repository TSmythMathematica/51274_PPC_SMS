'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing
Imports MPR.SMS.DocumentProcessing.ReportService

Public Class frmBatchCreate

#Region "Private Fields"

    Dim ReadOnly menmBatchType As Data.Enumerations.BatchType

    Dim mblnCreatingNewBatch As Boolean = False

    Dim ReadOnly mdctInstrumentsAvailable As New Dictionary(Of String, Integer)  ' i.e. (ITCode, InstrumentID)
    Dim ReadOnly mdctInstrumentsAdded As New Dictionary(Of String, Integer)

    Dim WithEvents mdtBatches As DataTable
    Dim mdtBatchItems As DataTable

    Dim mobjNewBatch As Batch
    Dim mobjInstrumentType As InstrumentType

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

            btnCancel.Enabled = False
        End If
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

    Private Sub btnCreateNewBatch_Click(sender As Object, e As EventArgs) Handles btnCreateNewBatch.Click

        ' just in case user is clicking button again (but didn't add any items)
        If mblnCreatingNewBatch AndAlso (mdtBatchItems.Rows.Count = 0) Then
            ' do nothing (i.e. let user work with the already-created, empty batch)
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

        ' Validate ITCode
        If cell.IsInEditMode AndAlso dgvBatchItems.Columns(e.ColumnIndex).Name = "ITCode" Then
            Dim strITCode As String = ctrl.Text
            Dim intInstrumentID As Integer

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

            Else
                ' INVALID
                Dim msg As String = "The ITCode you entered is not in the list" + Environment.NewLine +
                                    Environment.NewLine +
                                    "Please enter (or select) an ITCode from the list."
                MessageBox.Show(msg, "Invalid ITCode", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
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

#Region "Private Methods"

    Private Sub SetFormTitle()
        Dim strTitle As String
        If menmBatchType = Data.Enumerations.BatchType.QC Then
            strTitle = "Receipt and Create QC Transmittal"
        Else
            ' assume DE
            strTitle = "Batch for Data Entry"
        End If

        Me.Text = "SMS - [ " + Project.ShortName + "] - " + strTitle

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
        With dgvBatchItems
            .ReadOnly = False
            .AllowUserToAddRows = True
        End With

        ' select the grid
        bindingsourceBatches.MoveLast()
        dgvBatchItems.CurrentCell = dgvBatchItems.Item(0, 0)
        dgvBatchItems.Select()

        txtBatchNotes.ReadOnly = False ' (it would have been ReadOnly if this is the first Batch).

        btnCancel.Enabled = True
        mblnCreatingNewBatch = True
    End Sub

    Private Sub EndCreateNewBatch(Optional ByVal blnShouldSave As Boolean = True)

        If mblnCreatingNewBatch Then
            If blnShouldSave Then

                ' create and save all BatchItems
                Dim row As DataRow
                For Each row In mdtBatchItems.Rows
                    ' make sure ITCode is valid
                    Dim strITCode As String = row.Item("ITCode").ToString

                    If strITCode.Length = 0 Then
                        ' ignore/skip it
                    ElseIf mdctInstrumentsAdded.ContainsKey(strITCode) Then
                        Dim objBatchItem As BatchItem = Nothing

                        ' Create BatchItem
                        Try
                            objBatchItem = New BatchItem(mobjNewBatch)
                            objBatchItem.InstrumentID = mdctInstrumentsAdded(strITCode)
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
                            objBatchItem.UpdateInstrumentToBatchedStatus()
                        Catch ex As Exception
                            Dim strMsg As String = "Unable to status Instrument " + strITCode + "." +
                                                   Environment.NewLine + Environment.NewLine +
                                                   "[Error Details]" + Environment.NewLine +
                                                   ex.Message
                            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Try
                    End If
                Next
            End If ' ShouldSave 

            'If mobjNewBatch.BatchItems.Count = 0 Then
            '    ' Batch is empty, so delete it
            '    mdtBatches.Rows(mdtBatches.Rows.Count - 1).Delete()
            '    mobjNewBatch.Delete()
            'End If

            If mobjNewBatch.BatchItems.Count = 0 Or blnShouldSave = False Then
                ' Batch is empty, so delete it

                Dim s As Integer = 0
                For s = 0 To (mdtBatchItems.Rows.Count - 1)
                    mdtBatchItems.Rows(s).Delete()
                Next s

                mdtBatches.Rows(mdtBatches.Rows.Count - 1).Delete()
                mobjNewBatch.Delete()
            End If

        End If

        With dgvBatchItems
            .ReadOnly = True
            .AllowUserToAddRows = False
            .Refresh()
        End With

        btnCancel.Enabled = False
        mblnCreatingNewBatch = False
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
        mdtBatchItems.Columns.Add("Notes", GetType(String))
        ' will be populated during navigation
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
                Dim objRow(1) As Object
                objRow(0) = objBatchItem.ITCode
                objRow(1) = GetSafeValue(objBatchItem.Notes)
                mdtBatchItems.Rows.Add(objRow)
            Next
        End If
    End Sub

#End Region


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
End Class
