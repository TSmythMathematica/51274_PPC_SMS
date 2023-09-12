'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing
Imports MPR.SMS.Security

Public Class frmAddUpdateVariables
    Inherits Form

#Region "Private Fields"

    Private ReadOnly bindingsourceVariable As New BindingSource
    Private dataAdapterVariable As New SqlDataAdapter
    Private IsDataChanged As Boolean = False
    Private ReadOnly IsDataError As Boolean = False
    Private strMenuOption As String = String.Empty
    Private ReadOnly lstSASFormat As New DataGridViewComboBoxColumn()
    Private ds As DataSet
    Private InstrumentType As String = String.Empty
    Private intInstrumentTypeID As Integer = 0

#End Region

#Region "Constructors"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ComputerNameLabel.Text = My.Computer.Name
        Me.UserLabel.Text = CurrentUser.Name
        Me.Text = Project.ShortName.ToString & " - Add / Edit Variables"
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Maximized
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmAddUpdateVariable_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LoadFrequency()

            Me.tsbtnVariables.DropDownItems.Clear()


            For Each objInstrumentType As InstrumentType In Project.InstrumentTypes
                If objInstrumentType.IsSRDEE Then

                    Me.tsbtnVariables.DropDownItems.Add(objInstrumentType.Description.ToString, Nothing,
                                                        AddressOf Me.tsbtnVariables_Click)

                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub dgvVariables_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvVariables.CellValueChanged
        If e.RowIndex <> - 1 Then
            If Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "SASFormat" Then
                If Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue.ToString <> "Standard" _
                   Or Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue.ToString <> "" _
                   Or
                   Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue.ToString <>
                   Me.dgvVariables.Rows(e.RowIndex).Cells("Variable").FormattedValue.ToString Then
                    MessageBox.Show(
                        "You have selected an incorrect SASFormat for variable : " &
                        Me.dgvVariables.Rows(e.RowIndex).Cells("Variable").FormattedValue.ToString &
                        ". Please select the correct SASFormat.", Project.ShortName & " - Incorrect SASFormat!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.dgvVariables.Rows(e.RowIndex).Selected = True
                    Exit Sub
                End If
            End If
            Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGoldenrodYellow
            Me.dgvVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
            IsDataChanged = True
            Me.tsbtnSave.Enabled = True
        End If
    End Sub

    Private Sub frmAddUpdateVariable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (ConfirmExit() = DialogResult.No)
    End Sub

    Private Sub tsbtnSave_Click(sender As Object, e As EventArgs) Handles tsbtnSave.Click
        If IsDataError Then
            MessageBox.Show("Data validation error, please check data and correct", Project.Name)
            Exit Sub
        Else
            Try
                Me.Validate()
                Me.bindingsourceVariable.EndEdit()
                Me.dataAdapterVariable.Update(CType(Me.bindingsourceVariable.DataSource, DataTable))
                IsDataChanged = False
                Me.tsbtnSave.Enabled = False
                MessageBox.Show("Record(s) updated successfully", Project.ShortName, MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Reload()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " - Error saving..", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click
        Me.Close()
    End Sub

    Private Sub tsbtnFrequency_Click(sender As Object, e As EventArgs) Handles tsbtnFrequency.Click
        Try
            If IsDataChanged Then
                MessageBox.Show("Save changes you have made, and then proceed to define Variables.", Project.Name)
            Else
                LoadFrequency()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub tsbtnVariables_Click(sender As Object, e As EventArgs) Handles tsbtnVariables.Click
        Try
            If sender.ToString <> Me.tsbtnVariables.Text Then
                If IsDataChanged Then
                    MessageBox.Show("Save changes you have made, and then proceed to Frequency Labels.", Project.Name)
                Else
                    For Each objInstrumentType As InstrumentType In Project.InstrumentTypes
                        If objInstrumentType.IsSRDEE Then
                            If objInstrumentType.Description.ToString = sender.ToString Then
                                Me.intInstrumentTypeID = GetSafeValue(objInstrumentType.InstrumentTypeID)
                                Me.InstrumentType = objInstrumentType.Description.ToString
                                LoadVariables(GetSafeValue(intInstrumentTypeID))
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub tsbtnExcel_Click(sender As Object, e As EventArgs) Handles tsbtnExcel.Click
        Cursor = Cursors.WaitCursor

        ds = New DataSet
        Try

            Select Case strMenuOption

                Case "Frequency"
                    Me.ExportToExcel("FrequencyLabels", "SRDEE_FrequencyLabels")

                Case "Variables"
                    Me.ExportToExcel("Variables - " & Me.InstrumentType, "SRDEE_Variables")

            End Select

            Utility.DataSetToExcel(ds, Nothing)
            ds.Dispose()
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error exporting to Excel!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Private Methods"

    Private Sub GetFrequency(selectcommand As String)
        Try
            Me.dataAdapterVariable = New SqlDataAdapter(selectcommand, Project.ConnectionString)

            Dim table As New DataTable
            Me.dataAdapterVariable.Fill(table)
            Me.bindingsourceVariable.DataSource = table

            Me.dgvVariables.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Me.dgvVariables.Columns("LabelID").Frozen = True
            Me.dgvVariables.Columns("LabelID").ReadOnly = True

            Me.dgvVariables.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvVariables.MultiSelect = False
            Me.dgvVariables.AllowUserToDeleteRows = False
            Me.dgvVariables.AllowUserToAddRows = True
            'data grid view count new row also, since add rows are allowed
            Me.tsslTotalRecords.Text = "Total Frequency labels for Current Round: " & Me.dgvVariables.Rows.Count - 1
            Me.dgvVariables.RowHeadersWidth = 41
            Me.dgvVariables.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

            ' Create a list column for the SASFormat.
            Me.dgvVariables.Columns("SASFormat").Visible = True
            Me.dgvVariables.Columns("SASFormat").ReadOnly = True
            Me.lstSASFormat.DisplayIndex = 1
            Me.lstSASFormat.HeaderText = "SAS Format"
            Me.lstSASFormat.Width = 200
            Me.lstSASFormat.MaxDropDownItems = 15

        Catch ex As Exception
            MessageBox.Show("Error Loading Frequency Label Data. " & ex.Message, Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GetVariables(selectcommand As String)
        Try
            Me.dataAdapterVariable = New SqlDataAdapter(selectcommand, Project.ConnectionString)

            Dim table As New DataTable
            Me.dataAdapterVariable.Fill(table)
            Me.bindingsourceVariable.DataSource = table

            Me.dgvVariables.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Me.dgvVariables.Columns("VariableID").Frozen = True
            Me.dgvVariables.Columns("Variable").Frozen = True
            Me.dgvVariables.Columns("VariableID").ReadOnly = True
            Me.dgvVariables.Columns("Variable").ReadOnly = True

            Me.dgvVariables.Columns("QuestionNumber").ReadOnly = True
            Me.dgvVariables.Columns("AllowedValue").ReadOnly = True
            Me.dgvVariables.Columns("AllowedValueForSAS").ReadOnly = True

            Me.dgvVariables.Columns("InstrumentTypeID").ReadOnly = True
            Me.dgvVariables.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvVariables.MultiSelect = False
            Me.dgvVariables.AllowUserToDeleteRows = False
            Me.dgvVariables.AllowUserToAddRows = False
            'since add rows are not allowed, data grid view count is the total count
            Me.tsslTotalRecords.Text = "Total PreResponse Variables for Current Round: " & Me.dgvVariables.Rows.Count

            Me.dgvVariables.RowHeadersWidth = 41
            Me.dgvVariables.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

            ' Create a list column for the SASFormat list.
            Me.dgvVariables.Columns("SASFormat").Visible = True
            Me.dgvVariables.Columns("SASFormat").ReadOnly = True
            Me.lstSASFormat.DisplayIndex = 8
            Me.lstSASFormat.HeaderText = "SAS Format"
            Me.lstSASFormat.Width = 180

        Catch ex As Exception
            MessageBox.Show("Error Loading PreResponse Variables. " & ex.Message, Project.ShortName,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Function ConfirmExit() As DialogResult
        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Function

    Private Sub Reload()
        Try
            Select Case strMenuOption
                Case "Frequency"
                    Me.LoadFrequency()
                Case "Variables"
                    Me.LoadVariables(Me.intInstrumentTypeID)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadFrequency()
        Try
            Me.Text = Project.ShortName.ToString & " - Add / Edit Frequency"
            Me.strMenuOption = "Frequency"
            Me.bindingsourceVariable.DataSource = Nothing
            Me.dgvVariables.DataSource = Me.bindingsourceVariable
            GetFrequency(
                "SELECT [LabelID] ,[SASFormat], [Value], [Label] FROM [tlkpSRDEEFrequencyLabel] ORDER BY [SASFormat]")
            Me.tsbtnSave.Enabled = False
            Me.tsbtnFrequency.Font = New Font(Me.tsbtnFrequency.Font, FontStyle.Bold)
            Me.tsbtnVariables.Font = New Font(Me.tsbtnVariables.Font, FontStyle.Regular)
            Me.tsbtnFrequency.BackColor = Color.LimeGreen
            Me.tsbtnVariables.BackColor = Color.Transparent

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadVariables(IntInstrTypeID As Integer)
        Try
            Me.Text = Project.ShortName.ToString & " - Add / Edit Variables"
            Me.strMenuOption = "Variables"
            Me.bindingsourceVariable.DataSource = Nothing
            Me.dgvVariables.DataSource = Me.bindingsourceVariable
            GetVariables(
                "SELECT * FROM [tlkpSRDEEVariablePreResponse] WHERE InstrumentTypeID = " & IntInstrTypeID &
                " Order By VariableID")
            Me.tsbtnSave.Enabled = False
            Me.tsbtnVariables.Font = New Font(Me.tsbtnVariables.Font, FontStyle.Bold)
            Me.tsbtnFrequency.Font = New Font(Me.tsbtnFrequency.Font, FontStyle.Regular)
            Me.tsbtnFrequency.BackColor = Color.Transparent
            Me.tsbtnVariables.BackColor = Color.LimeGreen

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ExportToExcel(strTable As String, strDataSource As String)
        Try
            Dim dt As DataTable = New DataTable
            ds.Tables.Add(strTable)  'Add a new table to the dataset
            If strMenuOption = "Frequency" Then
                dt = GetDataTable(strDataSource)
            Else
                dt = GetDataTableByID(strDataSource, Me.intInstrumentTypeID)
            End If
            Dim dc As DataColumn
            For Each c As DataColumn In dt.Columns
                dc = New DataColumn(c.ColumnName)
                ds.Tables(strTable).Columns.Add(dc)
            Next
            Dim dr As DataRow
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = ds.Tables(strTable).Rows.Add
                For Each column As DataColumn In dt.Columns
                    dr.Item(column.ColumnName) = dt.Rows.Item(i).Item(column.ColumnName)
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error exporting to Excel!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ExportGridToExcel(strTable As String)
        Try
            ds.Tables.Add(strTable)
            'Add the columns
            Dim col As DataColumn
            'For each colum in the datagridveiw add a new column to new table table
            For Each dgvCol As DataGridViewColumn In Me.dgvVariables.Columns
                col = New DataColumn(dgvCol.Name)
                ds.Tables(strTable).Columns.Add(col)
            Next
            'Add the rows from the datagridview
            Dim row As DataRow
            For i As Integer = 0 To dgvVariables.Rows.Count - 1
                row = ds.Tables(strTable).Rows.Add
                For Each column As DataGridViewColumn In dgvVariables.Columns
                    row.Item(column.Index) = dgvVariables.Rows.Item(i).Cells(column.Index).Value
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error exporting to Excel!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region
End Class
