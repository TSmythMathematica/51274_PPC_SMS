'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmBatchReceive
    Dim ReadOnly menmBatchType As Data.Enumerations.BatchType
    Dim mobjInstrumentType As InstrumentType
    Dim mdtBatches As DataTable

#Region "Constructors"

    Public Sub New(enmBatchType As Data.Enumerations.BatchType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        menmBatchType = enmBatchType
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmBatchReceive_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' PROMPT for instrument type
        Dim frm As frmBatchInstrumentType = New frmBatchInstrumentType(menmBatchType)
        frm.ShowDialog()

        ' did user cancel?
        If (frm.DialogResult = DialogResult.Cancel) OrElse (frm.InstrumentType Is Nothing) Then
            DialogResult = DialogResult.Cancel
            Me.Close() ' >>>>
        Else
            ' SETUP THIS FORM 
            mobjInstrumentType = frm.InstrumentType
            Try
                FillBatchesDataSource()
            Catch ex As Exception
                Dim strMsg As String = "A problem occurred trying to retrieve data from database." + Environment.NewLine +
                                       "If problem persists, please notify technical support." + Environment.NewLine +
                                       Environment.NewLine +
                                       "[Error Details]" + Environment.NewLine +
                                       ex.Message
                MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()  ' >>>>
            End Try

            SetFormTitle()
            dgvBatches.Select()
        End If
    End Sub

    Private Sub frmBatchReceive_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' update status for any/all batches 'checked' as Received
        If mdtBatches IsNot Nothing Then
            Dim row As DataRow
            For Each row In mdtBatches.Rows
                Dim objBatch As Batch = CType(row.Item("objBatch"), Batch)
                Dim strPublicBatchID As String = GetSafeValue(objBatch.PublicBatchID).ToString
                Dim objIsReceived As Object = row.Item("IsReceived")

                If (objIsReceived IsNot DBNull.Value) AndAlso (CType(objIsReceived, Boolean)) Then
                    Try
                        objBatch.UpdateToReceivedStatus()
                    Catch ex As Exception
                        Dim strMsg As String = "Unable to status Batch " + strPublicBatchID + "." + Environment.NewLine +
                                               Environment.NewLine +
                                               "[Error Details]" + Environment.NewLine +
                                               ex.Message
                        MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try
                End If

            Next
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

#End Region

#Region "Private Functions"

    ' returns the newly added row
    Private Function AddBatchToBatchDataSource(objBatch As Batch) As DataRow

        If objBatch IsNot Nothing Then
            Dim objRow(4) As Object
            objRow(0) = GetSafeValue(objBatch.BatchID)
            objRow(1) = GetSafeValue(objBatch.PublicBatchID)
            objRow(2) = GetSafeValue(objBatch.BatchNumber)
            objRow(3) = Nothing     ' the Received checkbox field
            objRow(4) = objBatch
            Return mdtBatches.Rows.Add(objRow)
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Private Methods"

    Private Sub SetFormTitle()
        Dim strSubTitle As String
        If menmBatchType = Data.Enumerations.BatchType.QC Then
            strSubTitle = "Receiving Batches into QC"
        Else
            ' assume DE
            strSubTitle = "Receiving Batches into Data Entry"
        End If

        Me.Text = "SMS - [ " & Project.ShortName & "] - " & strSubTitle

        ' also set label to indicate Instrument Name
        If mobjInstrumentType IsNot Nothing Then
            txtInstrumentName.Text = mobjInstrumentType.Description.ToString
        Else
            txtInstrumentName.Text = ""
        End If
    End Sub

    Private Sub FillBatchesDataSource()

        ' create data source
        mdtBatches = New DataTable("Batches")
        mdtBatches.Columns.Add("BatchID", GetType(Integer))
        mdtBatches.Columns.Add("PublicBatchID", GetType(Integer))
        mdtBatches.Columns.Add("BatchNumber", GetType(String))
        mdtBatches.Columns.Add("IsReceived", GetType(Boolean))
        mdtBatches.Columns.Add("objBatch", GetType(Batch))

        Dim objBatches As New Batches(menmBatchType, Me.mobjInstrumentType)
        If objBatches.Count = 0 Then
            bindingsourceBatches.DataSource = Nothing
        Else
            ' fill it
            Dim objBatch As Batch
            For Each objBatch In objBatches
                If objBatch.ReceivedOn.IsNull Then
                    AddBatchToBatchDataSource(objBatch)
                Else
                    ' batch was already Received (so don't add it)
                End If
            Next

            'bind it
            bindingsourceBatches.DataSource = mdtBatches

        End If
    End Sub

#End Region
End Class