'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Threading
Imports MPR.SMS.Data

Public Class EditCaseRA

#Region "Private fields"

    Private mobjCaseRA As CaseRA = Nothing

    Private mblnReadOnly As Boolean = False

#End Region

#Region "Public Properties"

    Public Shadows Property CaseRA As CaseRA
        Get
            FillProperties()
            Return mobjCaseRA
        End Get
        Set
            mobjCaseRA = value
            FillUserControl()
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjCaseRA IsNot Nothing AndAlso
           Not GetSafeValue(mobjCaseRA.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjCaseRA)
            frm.Width = Me.Parent.Width
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjCaseRA Is Nothing Then Exit Sub

        With mobjCaseRA
            'SetSafeValue(.RandomNumber, txtRandNum.Text)
            SetSafeValue(.RandomizationStatus, txtRandStatus.Text)
            If IsDate(txtRandDate.Text) Or txtRandDate.Text.Equals("") Then
                SetSafeValue(.RandomizationDate, txtRandDate.Text)
            End If
            .OverrideDuplicate = chkOverride.Checked
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjCaseRA Is Nothing Then Exit Sub

        With mobjCaseRA
            txtRandNum.Text = GetSafeValue(.RandomNumber).ToString
            txtRandStatus.Text = GetSafeValue(.RandomizationStatus)
            txtRandDate.Text = GetSafeDate(.RandomizationDate)
            chkOverride.Checked = GetSafeValue(.OverrideDuplicate)
        End With
        If Project.ErrorChecking <> Project.CheckingType.NoChecking Then
            InitializeDataGridView(grdErrors, mobjCaseRA.Case.CaseErrors)
            InitializeErrorsGrid()
        End If
        If Project.DuplicatesChecking <> Project.CheckingType.NoChecking Then
            InitializeDataGridView(grdDuplicates, mobjCaseRA.Case.Duplicates)
            InitializeDupesGrid()
        End If
        EnableUserControl(mblnReadOnly)
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtRandNum.ReadOnly = True
        txtRandStatus.ReadOnly = blnReadOnly
        txtRandDate.ReadOnly = blnReadOnly
        chkOverride.AutoCheck = Not blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

    Private Sub InitializeDataGridView(grdView As DataGridView, objCollection As Object)
        Try
            ' Set up the DataGridView.
            With grdView
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True

                ' Set up the data source.
                .DataSource = objCollection

                ' Automatically resize the visible rows.
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders
                .RowTemplate.Height = 17
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .RowHeadersWidth = 22

                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D

                'Dim col As DataGridViewColumn = .Columns(0)
                '.Sort(col, System.ComponentModel.ListSortDirection.Descending)

                .ReadOnly = True

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Thread.CurrentThread.Abort()
        End Try
    End Sub

    Private Sub InitializeDupesGrid()

        With grdDuplicates
            For Each col As DataGridViewColumn In .Columns
                Select Case col.HeaderText
                    Case "DupeCaseID"
                        col.DisplayIndex = 0
                    Case "MPRID"
                        col.DisplayIndex = 1
                    Case "DupeMPRID"
                        col.DisplayIndex = 2
                    Case "DupeType"
                        col.DisplayIndex = 3
                    Case "Duplicate"
                        col.DisplayIndex = 4
                    Case Else
                        col.Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub InitializeErrorsGrid()

        With grdErrors
            For Each col As DataGridViewColumn In .Columns
                Select Case col.HeaderText
                    Case "MPRID"
                        col.DisplayIndex = 0
                    Case "ErrorTypeDescription"
                        col.DisplayIndex = 1
                    Case "ErrorValue"
                        col.DisplayIndex = 2
                    Case Else
                        col.Visible = False
                End Select
            Next
        End With
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objCaseRA As CaseRA)

#End Region

#Region "Event Handlers"

    Private Sub txtRandStatus_TextChanged(sender As Object, e As EventArgs) Handles txtRandStatus.TextChanged

        If Not Me.DesignMode Then
            If txtRandStatus.Text <> GetSafeValue(mobjCaseRA.RandomizationStatus) Then
                RaiseEvent OnChanged(Me, CaseRA)
            End If
        End If
    End Sub

    Private Sub txtRandDate_TextChanged(sender As Object, e As EventArgs) Handles txtRandDate.TextChanged

        If Not Me.DesignMode Then
            If txtRandDate.Text <> GetSafeDate(mobjCaseRA.RandomizationDate) Then
                RaiseEvent OnChanged(Me, CaseRA)
            End If
        End If
    End Sub

    Private Sub chkOverride_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverride.CheckedChanged

        If Not Me.DesignMode Then
            If chkOverride.Checked <> GetSafeValue(mobjCaseRA.OverrideDuplicate) Then
                RaiseEvent OnChanged(Me, CaseRA)
            End If
        End If
    End Sub

    Private Sub EditCaseRA_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Add any initialization after the InitializeComponent() call.
        If Not Me.DesignMode Then
            grdErrors.Visible = (Project.ErrorChecking <> Project.CheckingType.NoChecking)
            lblErrors.Visible = grdErrors.Visible
            grdDuplicates.Visible = (Project.DuplicatesChecking <> Project.CheckingType.NoChecking)
            lblDupes.Visible = grdDuplicates.Visible
            chkOverride.Visible = grdDuplicates.Visible
        End If
    End Sub

    Private Sub EditCaseRA_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'Case RandomAssignment History
        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

#End Region
End Class
