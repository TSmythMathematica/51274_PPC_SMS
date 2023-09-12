'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Threading
Imports MPR.SMS.Data


Public Class frmDisplayDataView

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    'use this constructor for special case tables that might not use an object, 
    'such as InstrumentStatusHistory, or other views
    Public Sub New(strDataSource As String, strTitle As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = strTitle

        InitializeDataGridView(strDataSource)
    End Sub

#End Region

#Region "Public Properties"

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

    Public WriteOnly Property SortDirection As ListSortDirection
        Set
            grdView.Sort(grdView.SortedColumn, value)
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub grdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles grdView.CellFormatting
        If grdView.Columns(e.ColumnIndex).DataPropertyName = "CreatedOn" Or
           grdView.Columns(e.ColumnIndex).DataPropertyName = "LastModifiedOn" Then
            e.CellStyle.Format = "g"
        End If
    End Sub

    Private Sub grdView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdView.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub grdView_LostFocus(sender As Object, e As EventArgs) Handles grdView.LostFocus

        Me.Close()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitializeDataGridView(strSQL As String)
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
End Class