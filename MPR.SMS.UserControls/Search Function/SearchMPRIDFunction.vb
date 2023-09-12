'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class SearchMPRIDFunction

#Region "Private Variables"

    Private mResultsDataSet As DataSet
    Private mstrDataSource As String

#End Region

#Region "Public Events"

    Public Event BeginSearch(sender As Object, e As EventArgs)
    Public Event EndSearch(sender As Object, e As EventArgs)
    Public Event SearchError(sender As Object, e As EventArgs, ErrorMsg As String)
    Public Event SearchResultClick(sender As Object, e As EventArgs, DataRow As DataRow)
    Public Event SearchResultDoubleClick(sender As Object, e As EventArgs, DataRow As DataRow)
    Public Event CloseButtonClick(sender As Object, e As EventArgs)
    Public Event ClearButtonClick(sender As Object, e As EventArgs)


#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

#End Region

#Region "Public Properties"

    <Category("Appearance")>
    Public Property DataGridVisible As Boolean
        Get
            Return Me.dgvSearchResults.Visible
        End Get
        Set
            Me.dgvSearchResults.Visible = False 'Value
        End Set
    End Property

    <Browsable(False),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property SearchCriteria As String
        Get
            If Me.tabSearch.SelectedTab Is Me.tabPageAdvanced Then
                'AF 11/10/09 this allowed SQL Injection. For now just drop everything after a semicolon 
                'later we might want to do more...
                If txtAdvancedSearch.Text.Contains(";") Then
                    Return txtAdvancedSearch.Text.Remove(txtAdvancedSearch.Text.IndexOf(";"))
                Else
                    Return txtAdvancedSearch.Text.Trim()
                End If
            Else
                Return GetCriteria(dgvSearchCriteria.Rows)
            End If
        End Get
        'Set(ByVal Value As String)
        '    mstrSelect = Value
        'End Set
    End Property

    <Category("Data")>
    <DefaultValue("")>
    Public Property DataSource As String
        Get
            Return mstrDataSource
        End Get
        Set
            mstrDataSource = Value
        End Set
    End Property

    <DefaultValue(0)>
    <Category("Data")>
    Public ReadOnly Property ResultSetCount As Integer
        Get
            If mResultsDataSet IsNot Nothing Then
                Return mResultsDataSet.Tables(0).Rows.Count
            Else
                Return 0
            End If
        End Get
    End Property

    <Category("Data")>
    <DefaultValue("")>
    Public ReadOnly Property DataTable As DataTable
        Get
            Return mResultsDataSet.Tables(0)
        End Get
    End Property


#End Region

#Region "Public Methods"

    Public Sub Initialize()

        mResultsDataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text,
                                                   DataSource + " WHERE 1 <> 1")
        InitCriteria(mResultsDataSet.Tables(0))
    End Sub

    Public Sub DoSearch()

        Dim strSQL As String = DataSource
        Dim strWHERE As String = SearchCriteria

        If Not strSQL.Length.Equals(0) Then
            If Not strWHERE.Length.Equals(0) Then
                strSQL = strSQL & " WHERE " & strWHERE
            End If
            mResultsDataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text, strSQL)
            dgvSearchResults.DataSource = mResultsDataSet.Tables(0)

        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitCriteria(dt As DataTable)

        dgvSearchCriteria.Rows.Clear()
        Dim i As Integer
        For i = 0 To dt.Columns.Count - 1
            dgvSearchCriteria.Rows.Add(dt.Columns.Item(i).ToString)
        Next
    End Sub

    Private Function GetCriteria(rows As DataGridViewRowCollection) As String

        Dim strCriteria As String = ""
        'For Each row As DataGridViewRow In rows
        '    If Not row.Cells(2).FormattedValue.ToString = "" Or
        '       row.Cells(1).FormattedValue.ToString = "is empty" Or
        '       row.Cells(1).FormattedValue.ToString = "is not empty" Then
        '        If Not strCriteria = "" Then
        '            strCriteria = strCriteria + " AND "
        '        End If
        '        strCriteria = strCriteria + GetFormatedCriteria(row)
        '        '" ([MPRID] = '10002315')"
        '    End If
        'Next
        strCriteria = " ([MPRID] = '" + txtMPRID.Text + "')"
        Return strCriteria
    End Function

    Private Function GetFormatedCriteria(row As DataGridViewRow) As String

        Dim strFormatedCriteria As String = ""

        If row.Cells(1).FormattedValue.ToString = "is equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] = '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is not equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] <> '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is less than" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] < '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is less than or equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] <= '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is greater than" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] > '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString.ToString = "is greater than or equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] >= '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is empty" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] IS NULL OR [" &
                                  row.Cells(0).FormattedValue.ToString & "] = '')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is not empty" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] IS NOT NULL AND [" &
                                  row.Cells(0).FormattedValue.ToString & "] <> '')"
        ElseIf row.Cells(1).FormattedValue.ToString = "begins with" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '" &
                                  row.Cells(2).FormattedValue.ToString & "%')"
        ElseIf row.Cells(1).FormattedValue.ToString = "ends with" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '%" &
                                  row.Cells(2).FormattedValue.ToString & "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "contains" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '%" &
                                  row.Cells(2).FormattedValue.ToString & "%')"
        End If

        Return strFormatedCriteria
    End Function

#End Region

#Region "Event Handlers"

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Private Sub btnSearch_Click(sender As Object, e As EventArgs)

        Cursor = Cursors.WaitCursor
        Dim blnError As Boolean = False
        Dim strSelect As String = SearchCriteria

        If Not strSelect = "" Then
            Try

                RaiseEvent BeginSearch(sender, e)

                DoSearch()

                If dgvSearchResults.Rows.Count = 0 Then
                    lblErrorMsg.Text = "MPRID not found"
                    RaiseEvent SearchError(sender, e, "No records found with this search criteria.")
                    blnError = True
                Else
                    lblErrorMsg.Text = ""
                End If

            Catch ex As Exception
                RaiseEvent SearchError(sender, e, "You have entered an invalid expression.")
                blnError = True
            End Try
        Else
            RaiseEvent SearchError(sender, e, "You have not specified any search criteria.")
            blnError = True
        End If
        dgvSearchResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        Cursor = Cursors.Default
        If Not blnError Then RaiseEvent EndSearch(sender, e)

        If dgvSearchResults.Rows.Count > 0 Then
            Dim arg As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(0, 0)
            dgvSearchResults.Rows(0).Selected = True
            dgvSearchResults_CellDoubleClick(sender, arg)
        End If
    End Sub
    Private Sub dgvSearchResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearchResults.CellDoubleClick

        If e.RowIndex >= 0 AndAlso dgvSearchResults.SelectedRows.Count > 0 Then
            RaiseEvent _
                SearchResultDoubleClick(sender, e,
                                        CType(dgvSearchResults.SelectedRows(0).DataBoundItem, DataRowView).Row)
        End If
    End Sub

    Private Sub dgvSearchResults_Click(sender As Object, e As EventArgs)

        If dgvSearchResults.SelectedRows.Count > 0 Then
            RaiseEvent _
                SearchResultClick(sender, e, CType(dgvSearchResults.SelectedRows(0).DataBoundItem, DataRowView).Row)
        End If
    End Sub


    Private Sub dgvSearchCriteria_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

        If dgvSearchCriteria.CurrentCell.EditType.ToString = "System.Windows.Forms.DataGridViewComboBoxEditingControl" _
            Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        'Private Sub btnClear_Click(sender As Object, e As EventArgs)

        RaiseEvent ClearButtonClick(sender, e)
        InitCriteria(mResultsDataSet.Tables(0))
        txtMPRID.Text = ""
        lblErrorMsg.Text = ""
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        'Private Sub btnClose_Click(sender As Object, e As EventArgs)

        RaiseEvent CloseButtonClick(sender, e)
    End Sub

    Private Sub lnkCopyToAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


        Me.txtAdvancedSearch.Text = GetCriteria(dgvSearchCriteria.Rows)
        Me.tabSearch.SelectedTab = Me.tabPageAdvanced
    End Sub

    Private Sub tabSearch_SelectedIndexChanged(sender As Object, e As EventArgs)

        If Me.tabSearch.SelectedTab Is Me.tabPageBasic Then
            Me.lnkCopyToAdvanced.Visible = True
            Me.btnClear.Enabled = True
        Else
            Me.lnkCopyToAdvanced.Visible = False
            Me.btnClear.Enabled = False
        End If
    End Sub


#End Region
End Class
