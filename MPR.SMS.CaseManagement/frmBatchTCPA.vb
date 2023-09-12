'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Security.Principal
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports MPR.SMS.Data
Imports MPR.SMS.Data.BaseClasses
Imports MPR.SMS.DataQuality


Public Class frmBatchTCPA

#Region "Private Fields"

    Private ReadOnly bs As New BindingSource
    Private sqlda As New SqlDataAdapter
    Private blnCancel As Boolean = False
    Private conn As SqlConnection

    Public _Statusdesc As String
    Public _StatusCode As String
    Private isclean As Boolean

    Dim cts As CancellationTokenSource

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property


#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - " & Me.Text

        Me.tspProgress.Visible = False
        Me.btnCancel.Visible = False
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Select Case tabBatch.SelectedTab.Text
            Case "Phones"
                DisplayGrid()
        End Select
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click

        Me.Cursor = Cursors.AppStarting

        'conn = New SqlClient.SqlConnection(Project.ConnectionString)

        'make sure the grid is populated with the results that match the selected criteria.
        'if you are enterprising enough, you can put in logic to only re-populate the grid 
        'if some criteria changed since the last time it was populated.
        btnPreview.PerformClick()

        tspProgress.Visible = True
        btnCancel.Visible = True
        tspProgress.Value = 0
        Me.Refresh()
        blnCancel = False
        cts = New CancellationTokenSource()

        SendBatchesToLookup() 'this does the lookup

        'Hide in the function after lookup is complete.
        'tspProgress.Visible = False
        'btnCancel.Visible = False
        'tspProgress.Value = 0

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnCancel = True
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        btnCancel.BorderStyle = Border3DStyle.Sunken
        Application.DoEvents()
    End Sub

    Private Sub btnCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseUp
        btnCancel.BorderStyle = Border3DStyle.RaisedInner
        Application.DoEvents()
    End Sub

    Private Sub btnCaseLocks_Click(sender As Object, e As EventArgs) Handles btnCaseLocks.Click

        Dim frm As frmCaseLockAdmin = New frmCaseLockAdmin
        frm.Show()
    End Sub

    'double click to open a case
    Private Sub dgvResults_DoubleClick(sender As Object, e As EventArgs) Handles dgvResults.DoubleClick

        Dim row As DataGridViewRow = dgvResults.SelectedRows(0)
        Dim intCaseID As Integer = CType(row.Cells("CaseID").Value, Integer)
        Dim objCase As New [Case](intCaseID, False)

        Dim strMPRID As String = row.Cells("MPRID").Value.ToString
        Dim objPerson As Person = Nothing
        If strMPRID.Length > 0 Then
            objPerson = New Person(strMPRID)
        End If

        Dim frmDisplayCase As New frmDisplayCase(objCase, objPerson, False)
        frmDisplayCase.Show()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayGrid() '(ByVal strSQL As String)

        'tspProgress.Visible = False

        Dim openedHere As Boolean = False
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            conn = New SqlConnection(Project.ConnectionString)
            conn.Open()
            openedHere = True
        End If


        Try
            With dgvResults
                .Columns.Clear()
                .DataSource = bs

                Dim cmdToExecute As SqlCommand = New SqlCommand()
                cmdToExecute.CommandText = "dbo.[SMS_GetPhoneForTCPALookup]"
                cmdToExecute.CommandType = CommandType.StoredProcedure
                Dim table As DataTable = New DataTable("tblPhone")
                sqlda = New SqlDataAdapter(cmdToExecute)

                cmdToExecute.Connection = conn

                ' Use base class connection object
                Dim mErrorCode As SqlInt32

                cmdToExecute.Parameters.Add(New SqlParameter("@InSampleOnly", SqlDbType.Bit, 1, ParameterDirection.Input,
                                                             True, 0, 0, "", DataRowVersion.Proposed,
                                                             CaseCriteria.InSampleOnly))
                cmdToExecute.Parameters.Add(New SqlParameter("@ExcludeIneligibles", SqlDbType.Bit, 1,
                                                             ParameterDirection.Input, True, 0, 0, "",
                                                             DataRowVersion.Proposed, CaseCriteria.ExcludeIneligibles))
                cmdToExecute.Parameters.Add(New SqlParameter("@SelectedCaseType", SqlDbType.Int, 4,
                                                             ParameterDirection.Input, True, 10, 0, "",
                                                             DataRowVersion.Proposed, CaseCriteria.SelectedCaseType))
                cmdToExecute.Parameters.Add(New SqlParameter("@SelectedPersonType", SqlDbType.Int, 4,
                                                             ParameterDirection.Input, True, 10, 0, "",
                                                             DataRowVersion.Proposed, PersonCriteria.SelectedPersonType))
                cmdToExecute.Parameters.Add(New SqlParameter("@ExcludeCleanedPhones", SqlDbType.Bit, 1,
                                                             ParameterDirection.Input, True, 0, 0, "",
                                                             DataRowVersion.Proposed, chkExcludeCleanedPhones.Checked))
                cmdToExecute.Parameters.Add(New SqlParameter("@BestOnly", SqlDbType.Bit, 1, ParameterDirection.Input,
                                                             True, 0, 0, "", DataRowVersion.Proposed,
                                                             optBestPhone.Checked))
                cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output,
                                                             True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))


                'Dim table As New DataTable
                sqlda.Fill(table)
                mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)
                If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
                    ' Throw error.
                    Throw _
                        New Exception(
                            "Stored Procedure 'SMS_GetPhoneForTCPALookup' reported the ErrorCode: " &
                            mErrorCode.ToString())
                End If

                bs.DataSource = table

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .RowHeadersWidth = 39

                If .Rows.Count > 0 Then
                    .Rows(0).Selected = True
                End If

            End With

            Me.TotalRecordsLabel.Text = "Total Records: " & Me.dgvResults.Rows.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try

        If openedHere Then
            conn.Close()
        End If

        With dgvResults
            .ReadOnly = True

            'try to remove fields that don't exist in all queries
            Try
                .Columns("PhoneID").Visible = False
            Catch ex As Exception
            End Try
        End With
    End Sub

    Private Async Sub SendBatchesToLookup()

        Dim bln As Boolean
        bln = Await Task.Run(Function()
            Return PopulatePhoneGridView()
        End Function)
    End Sub

    Public Function PopulatePhoneGridView() As Boolean

        Dim openedHere As Boolean = False

        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            conn = New SqlConnection(Project.ConnectionString)
            conn.Open()
            openedHere = True
        End If

        Dim strTCPAPhoneType As String = "U"
        Dim sbXml As New StringBuilder
        Dim rownum As Integer = 0
        Dim batchCounter As Integer = 0
        Const batchSize As Integer = 100
        Dim args As New BatchProgressArgs
        args.TotalBatches = CInt(Math.Ceiling(dgvResults.Rows.Count/batchSize))
        args.BatchesProcessed = 0
        UpdateProgress(Me, args)

        For Each dgvRow As DataGridViewRow In dgvResults.Rows

            rownum += 1
            tspProgress.Value = CInt(Math.Ceiling(rownum*100/dgvResults.Rows.Count))

            If blnCancel Then
                Exit For
            End If

            strTCPAPhoneType = TCPAPhoneLookup.GetPhoneType(dgvRow.Cells("Phonenum").Value.ToString)

            dgvRow.Cells("TCPAPhoneType").Value = strTCPAPhoneType
            'Thread.Sleep(500)

            batchCounter += 1
            If Not chkTestRun.Checked Then

                sbXml.Append(String.Format("<row><ID>{0}</ID><A>{1}</A></row>", dgvRow.Cells("PhoneID").Value.ToString,
                                           strTCPAPhoneType))

                If batchCounter = batchSize Then
                    SaveBatchToDb(sbXml) 'uses conn opened in this function

                    args.BatchesProcessed += 1
                    UpdateProgress(Me, args)

                    batchCounter = 0
                    sbXml.Clear()
                End If

            End If

            dgvRow.Cells("Result").Value = "ok"

        Next

        If Not chkTestRun.Checked AndAlso sbXml.Length > 0 Then
            SaveBatchToDb(sbXml)

            args.BatchesProcessed += 1
            UpdateProgress(Me, args)
        End If

        If openedHere Then
            conn.Close()
        End If

        tspProgress.Visible = False
        btnCancel.Visible = False
        Return True
    End Function

    Private Sub SaveBatchToDb(sbXml As StringBuilder)

        Using cmd As New SqlCommand("SMS_UpdateTCPAPhoneType")
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@xml", sbXml.ToString())
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Sub UpdateProgress(Sender As Object, Message As BatchProgressArgs)
        If blnCancel Then
            TotalRecordsLabel.Text = "Process cancelled after " + Message.BatchesProcessed.ToString + " of " +
                                     Message.TotalBatches.ToString + " Batches."
        Else
            TotalRecordsLabel.Text = "Processed " + Message.BatchesProcessed.ToString + " of " +
                                     Message.TotalBatches.ToString + " Batches."
        End If
    End Sub

#End Region
End Class

