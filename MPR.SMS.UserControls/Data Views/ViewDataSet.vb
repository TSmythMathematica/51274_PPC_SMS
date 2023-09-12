'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Threading
Imports MPR.SMS.Data

Public Class ViewDataSet

#Region "Private Variables"

    Dim mstrDataSource As String
    Dim mintDblClickCol As Integer = 0

#End Region

#Region "Public Properties"

    <DefaultValue("")>
    Public Property DataSource As String
        Get
            Return mstrDataSource
        End Get
        Set
            mstrDataSource = value
            Refresh()
        End Set
    End Property

    Public ReadOnly Property Columns As DataGridViewColumnCollection
        Get
            Return grdView.Columns
        End Get
    End Property

    Public ReadOnly Property Rows As DataGridViewRowCollection
        Get
            Return grdView.Rows
        End Get
    End Property

    <DefaultValue("Nothing")>
    Public Property SortedColumn As DataGridViewColumn
        Get
            Return grdView.SortedColumn
        End Get
        Set
            If value IsNot Nothing Then
                grdView.Sort(value, ListSortDirection.Ascending)
            End If
        End Set
    End Property

    Public Property DoubleClickColumn As Integer
        Get
            Return mintDblClickCol
        End Get
        Set
            mintDblClickCol = value
            grdView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End Set
    End Property

    Public WriteOnly Property SortDirection As ListSortDirection
        Set
            grdView.Sort(grdView.SortedColumn, value)
        End Set
    End Property

    <DefaultValue("DataGridViewSelectionMode.ColumnHeaderSelect")> _
    <Category("Appearance")>
    Public Property SelectionMode As DataGridViewSelectionMode
        Get
            Return grdView.SelectionMode
        End Get
        Set
            grdView.SelectionMode = value
        End Set
    End Property

    <DefaultValue(False)> _
    <Category("Appearance")>
    Public Property MultiSelect As Boolean
        Get
            Return grdView.MultiSelect
        End Get
        Set
            grdView.MultiSelect = value
        End Set
    End Property

    Public ReadOnly Property SelectedRows As DataGridViewSelectedRowCollection
        Get
            Return grdView.SelectedRows
        End Get
    End Property

#End Region

#Region "Public Methods"

    Public Shadows Sub Refresh()

        InitializeDataGridView(mstrDataSource)
        MyBase.Refresh()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitializeDataGridView(strSQL As String)

        If strSQL Is Nothing OrElse strSQL.Length.Equals(0) Then Return

        Try
            ' Set up the DataGridView.
            With grdView
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True

                ' Set up the data source.
                .DataSource = GetDataTable(strSQL)

                ' Automatically resize the visible rows.
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders
                .RowTemplate.Height = 18
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .RowHeadersWidth = 22

                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D

                'Dim col As DataGridViewColumn = .Columns(0)
                '.Sort(col, System.ComponentModel.ListSortDirection.Descending)

                .ReadOnly = True
                grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            End With
        Catch ex As SqlException
            MessageBox.Show(ex.Message,
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Thread.CurrentThread.Abort()
        End Try
    End Sub

#End Region

#Region "Events"

    Public Event SelectionChanged(sender As Object, e As EventArgs)
    Public Shadows Event Click(sender As Object, e As EventArgs)
    Public Shadows Event DoubleClick(sender As Object, e As EventArgs)
    Public Shadows Event OnDoubleClickRow(sender As Object, strReturnValue As String)

#End Region

#Region "Event Handlers"

    'this seems to have been added to accomodate adding checkboxes to a grid. However, this code introduces bugs for grids that don't 
    'have checkboxes, and anyway, this user control was meant for read-only displaying of recordsets, not for editing. SL 7/8/13
    'Private Sub grdView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdView.CellContentClick

    '    If e.ColumnIndex >= 0 And e.ColumnIndex < 4 Then
    '        Dim chkbox As DataGridViewCheckBoxCell = DirectCast(grdView.SelectedCells(e.ColumnIndex), DataGridViewCheckBoxCell)
    '        If Not (chkbox Is Nothing) Then
    '            If IsNothing(chkbox.Value) Then
    '                chkbox.Value = False
    '            ElseIf chkbox.Value.Equals(True) Then
    '                chkbox.Value = False
    '            Else
    '                chkbox.Value = True
    '            End If

    '        End If
    '    End If

    'End Sub

    Private Sub grdView_Click(sender As Object, e As EventArgs) Handles grdView.Click

        RaiseEvent Click(Me, e)
    End Sub

    Private Sub grdView_DoubleClick(sender As Object, e As EventArgs) Handles grdView.DoubleClick

        RaiseEvent DoubleClick(Me, e)

        Try
            Dim str As String = grdView.SelectedRows(0).Cells(mintDblClickCol).Value.ToString
            RaiseEvent OnDoubleClickRow(Me, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        RaiseEvent SelectionChanged(Me, e)
    End Sub

#End Region
End Class
