'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents a view of notes, from all sources, for a Case.
''' </summary>
''' <remarks>
'''     ViewCaseNotes provides a reusable ListView/Grid control for
'''     browsing a case's notes. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseNotes

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjNote As AllNote

    Private mblnAllowAdd As Boolean = False
    Private mblnAllowEdit As Boolean = False
    Private mblnAllowDelete As Boolean = False
    Private mblnGroupByName As Boolean = False

    Private mblnObjectWasAdded As Boolean = False

#End Region

#Region "Public Properties"

    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = Value
            If Not mobjCase Is Nothing Then FillGrid(mobjCase)
        End Set
    End Property

    Public Property SelectedNote As AllNote
        Get
            If mobjNote Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjNote = CType(grdView.SelectedRows(0).Tag, AllNote)
            End If
            Return mobjNote
        End Get
        Set
            mobjNote = Value
            If mobjNote Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjNote) Then
                        grdView.Rows(objRow.Index).Selected = True
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Private Property AllowAdd As Boolean
        Get
            Return mblnAllowAdd
        End Get
        Set
            mblnAllowAdd = Value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Private Property AllowEdit As Boolean
        Get
            Return mblnAllowEdit
        End Get
        Set
            mblnAllowEdit = Value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Private Property AllowDelete As Boolean
        Get
            Return mblnAllowDelete
        End Get
        Set
            mblnAllowDelete = Value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Public Property GroupByName As Boolean
        Get
            Return mblnGroupByName
        End Get
        Set
            mblnGroupByName = Value
            chkGroupByName.Checked = Value
            If grdView.SortedColumn Is Nothing Then
                grdView.Sort(grdView.Columns(1), ListSortDirection.Ascending)
            Else
                grdView.Sort(grdView.SortedColumn, ListSortDirection.Ascending)
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objNote As AllNote = mobjNote

        FillGrid(mobjCase)
        SelectedNote = objNote
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objNote As AllNote)
    Public Shadows Event OnDoubleClick(sender As Object, objNote As AllNote)
    Public Shadows Event OnChanged(sender As Object, objNote As AllNote)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, AllNote)

            RaiseEvent OnClick(Me, SelectedNote)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, AllNote)

            RaiseEvent OnDoubleClick(Me, SelectedNote)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If SelectedNote IsNot Nothing Then
                    Dim frm As New frmDisplayNote(SelectedNote)
                    frm.Width = CInt(grdView.Width*0.75)

                    Dim PointX As Integer = CInt(Cursor.Position.X - frm.Width/2)
                    If PointX < 0 Then PointX = 0

                    Dim PointY As Integer = Cursor.Position.Y + 12
                    If PointY + frm.Height > Screen.GetWorkingArea(Me).Height Then
                        PointY = Cursor.Position.Y - frm.Height - 12
                    End If

                    frm.Location = New Point(PointX, PointY)
                    frm.Show()
                End If
            End If
        End If
    End Sub

    Private Sub grdView_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles grdView.SortCompare

        If mblnGroupByName Then
            'sort by Name (i.e. Person), then by clicked column, then by Note Date
            e.SortResult = String.Compare(CType(grdView.Rows(e.RowIndex1).Cells("PersonName").Value, String),
                                          CType(grdView.Rows(e.RowIndex2).Cells("PersonName").Value, String))
            If e.Column.Name <> "PersonName" AndAlso e.SortResult = 0 Then
                If e.Column.Name = "NoteDate" Then
                    e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
                Else
                    e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
                    If e.SortResult = 0 Then
                        e.SortResult = DateTime.Compare(
                            CType(grdView.Rows(e.RowIndex1).Cells("NoteDate").Value, DateTime),
                            CType(grdView.Rows(e.RowIndex2).Cells("NoteDate").Value, DateTime))
                    End If
                End If
            End If
        Else
            'sort by clicked column, then by Note Date
            e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
            If e.Column.Name = "NoteDate" Then
                e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
            ElseIf e.SortResult = 0 Then
                e.SortResult = DateTime.Compare(CType(grdView.Rows(e.RowIndex1).Cells("NoteDate").Value, DateTime),
                                                CType(grdView.Rows(e.RowIndex2).Cells("NoteDate").Value, DateTime))
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'Dim objNote As New Note(GetSafeValue(mobjNote.NoteID))

        'objNote.CaseID = mobjCase.CaseID

        'Dim frm As New frmNote(mobjCase, objNote)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjCase)
        '    SelectedNote = objNote
        '    RaiseEvent OnChanged(Me, objNote)
        'End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'Dim objNote As Note = GetSelectedNote()

        'Dim frm As New frmNote(mobjCase, objNote)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjCase)
        '    SelectedNote = objNote
        '    RaiseEvent OnChanged(Me, objNote)
        'End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelNote As AllNote = Me.SelectedNote

        mobjCase.AllNotes.Remove(objSelNote)              'BT: 11/18/2014. Changed for vwAllNotes
        RaiseEvent OnChanged(Me, objSelNote)
        FillGrid(mobjCase)
        SelectedNote = Nothing
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("MPRID").Visible

        blnShow = Not blnShow
        grdView.Columns("MPRID").Visible = blnShow
        If blnShow Then
            btnShowID.ImageKey = "hide.bmp"
        Else
            btnShowID.ImageKey = "show.bmp"
        End If
        grdView.Focus()
    End Sub

    Private Sub chkGroupByName_CheckedChanged(sender As Object, e As EventArgs) Handles chkGroupByName.CheckedChanged

        GroupByName = chkGroupByName.Checked
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objCase As [Case])

        Dim objNote As AllNote

        grdView.Rows.Clear()
        mblnObjectWasAdded = False

        If Not objCase Is Nothing Then
            Dim objNotes As New AllNotes(objCase)
            For Each objNote In objNotes
                Dim strPerson As String = ""
                If objNote.Person IsNot Nothing Then
                    strPerson = objNote.Person.FullName
                End If

                'NOTE: change GetSafeDate(objNote.NoteDate) to GetSafeValue(objNote.NoteDate)
                'below, if you want to display Time
                Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                          GetSafeValue(objNote.MPRID),
                                          GetSafeValue(objNote.NoteDate),
                                          GetSafeValue(objNote.Notes),
                                          GetSafeValue(objNote.Source),
                                          strPerson,
                                          GetSafePhone(objNote.Phone),
                                          GetSafeValue(objNote.InstrumentType),
                                          GetSafeValue(objNote.UserName),
                                          GetSafeValue(objNote.Round)}

                grdView.Rows.Add(objRow)
                grdView.Rows(grdView.Rows.Count - 1).Tag = objNote
            Next
            RaiseEvent OnClick(Me, SelectedNote)
        End If
        grdView.Columns("Notes").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Notes").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        grdView.Sort(grdView.Columns("NoteDate"), ListSortDirection.Descending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjCase IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedNote IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))
        If blnReadOnly Then
            grdView.Height = grpMembers.Height - 24
        Else
            grdView.Height = grpMembers.Height - btnAdd.Height - 30
        End If

        btnAdd.Visible = Not blnReadOnly And mblnAllowAdd
        btnEdit.Visible = Not blnReadOnly And mblnAllowEdit
        btnDelete.Visible = Not blnReadOnly And mblnAllowDelete
    End Sub

    Private Function EnableDeleteButton() As Boolean

        'If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
        '    'allow deleting of newly added records
        '    If SelectedNote IsNot Nothing AndAlso GetSafeValue(SelectedNote.NoteID).Equals(0) Then
        '        Return mblnAllowDelete
        '    Else    'otherwise, only supervisors can delete existing records
        '        Return mblnAllowDelete And Authorization.IsSupervisor
        '    End If
        'Else
        Return False
        'End If
    End Function

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetButtons()
    End Sub

#End Region
End Class
