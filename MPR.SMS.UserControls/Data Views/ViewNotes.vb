'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data


Public Class ViewNotes

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjNote As Note
    Private mobjAddress As Address
    Private mobjPerson As Person


    Private mblnAllowAdd As Boolean = True
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
            mobjCase = value
            If Not mobjCase Is Nothing Then FillGrid(mobjCase)
        End Set
    End Property

    Public Property SelectedAddress As Address
        Get
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
            'If Not mobjAddress Is Nothing Then FillGrid(mobjAddress)
        End Set
    End Property

    ''<System.ComponentModel.Browsable(False)> _
    ''Public Property SelectedPerson() As Person
    ''    Get
    ''        Return mobjPerson
    ''    End Get
    ''    Set(ByVal value As Person)
    ''        mobjPerson = value
    ''        If SelectedCase Is Nothing AndAlso _
    ''           mobjPerson IsNot Nothing Then
    ''            SelectedCase = mobjPerson.Case
    ''        End If
    ''        If mobjPerson IsNot Nothing Then
    ''            If mobjPerson.BestPhysicalAddress IsNot Nothing Then
    ''                SelectedAddress = mobjPerson.BestPhysicalAddress
    ''            ElseIf mobjPerson.BestMailingAddress IsNot Nothing Then
    ''                SelectedAddress = mobjPerson.BestMailingAddress
    ''            Else
    ''                SelectedAddress = mobjPerson.BestCheckAddress
    ''            End If
    ''        Else
    ''            SelectedAddress = Nothing
    ''        End If
    ''        If Not Me.DesignMode Then FillGrid(mobjPerson)
    ''    End Set
    ''End Property

    Public Property SelectedNote As Note
        Get
            If mobjNote Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjNote = CType(grdView.SelectedRows(0).Tag, Note)
            End If
            Return mobjNote
        End Get
        Set
            mobjNote = value
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
            mblnAllowAdd = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Private Property AllowEdit As Boolean
        Get
            Return mblnAllowEdit
        End Get
        Set
            mblnAllowEdit = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Private Property AllowDelete As Boolean
        Get
            Return mblnAllowDelete
        End Get
        Set
            mblnAllowDelete = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Public Property GroupByName As Boolean
        Get
            Return mblnGroupByName
        End Get
        Set
            mblnGroupByName = value
            chkGroupByName.Checked = value
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

        Dim objNote As Note = mobjNote

        FillGrid(mobjCase)
        SelectedNote = objNote
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objNote As Note)
    Public Shadows Event OnDoubleClick(sender As Object, objNote As Note)
    Public Shadows Event OnChanged(sender As Object, objNote As Note)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, Note)

            RaiseEvent OnClick(Me, SelectedNote)
            'btnEdit.Enabled = mblnAllowEdit
            'btnDelete.Enabled = EnableDeleteButton()
        End If
    End Sub

    ' EE: logic added 2/11/2015 for Is Field Note?  enhancement
    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick
        Dim objNote As Note

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, Note)
            ' switch to opposite
            If GetSafeValue(mobjNote.IsFieldNote) Then
                mobjNote.IsFieldNote = False
                If Not mobjCase Is Nothing Then FillGrid(mobjCase)
            Else
                ' setting to true ... set all to false, initially
                If Not mobjAddress Is Nothing Then
                    For Each objNote In mobjCase.Notes
                        If objNote.Address Is mobjAddress Then objNote.IsFieldNote = False
                    Next
                End If
                ' if not set then set to true
                mobjNote.IsFieldNote = True
                If Not mobjCase Is Nothing Then FillGrid(mobjCase)
            End If
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If SelectedNote IsNot Nothing Then
                    Dim frm As New frmDisplayNote(SelectedNote)
                    'frm.Width = CInt(grdView.Width * 0.75)

                    'Dim PointX As Integer = CInt(System.Windows.Forms.Cursor.Position.X - frm.Width / 2)
                    'If PointX < 0 Then PointX = 0

                    'Dim PointY As Integer = System.Windows.Forms.Cursor.Position.Y + 12
                    'If PointY + frm.Height > Screen.GetWorkingArea(Me).Height Then
                    '    PointY = System.Windows.Forms.Cursor.Position.Y - frm.Height - 12
                    'End If

                    'frm.Location = New Point(PointX, PointY)
                    'frm.Show()

                    frm.Width = grdView.Width
                    If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                        frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                                 Cursor.Position.Y - 12 - frm.Height)
                    Else
                        frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                                 Cursor.Position.Y + 12)
                    End If
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
                If e.Column.Name = "CreatedOn" Then
                    e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
                Else
                    e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
                    If e.SortResult = 0 Then

                        e.SortResult = DateTime.Compare(
                            CType(grdView.Rows(e.RowIndex1).Cells("CreatedOn").Value, DateTime),
                            CType(grdView.Rows(e.RowIndex2).Cells("CreatedOn").Value, DateTime))
                    End If
                End If
            End If
        Else
            'sort by clicked column, then by Note Date
            e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
            If e.Column.Name = "CreatedOn" Then
                e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
            ElseIf e.SortResult = 0 Then
                e.SortResult = DateTime.Compare(CType(grdView.Rows(e.RowIndex1).Cells("CreatedOn").Value, DateTime),
                                                CType(grdView.Rows(e.RowIndex2).Cells("CreatedOn").Value, DateTime))
            End If
        End If

        e.Handled = True
    End Sub

    'Private Sub btnAdd_VisibleChanged(sender As Object, e As EventArgs)
    '    If btnAdd.Visible = False And btnDelete.Visible = False And btnEdit.Visible = False Then
    '        Height -= btnAdd.Height
    '    End If
    'End Sub


    'Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim objPerson As Person = mobjPerson
    '    Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))


    '    objNote.Case = mobjAddress.Case
    '    objNote.Person = mobjAddress.Person
    '    objNote.Address = mobjAddress

    '    'If mobjAddress.Address1.Value = "" Then
    '    '    MessageBox.Show("Please add address before adding notes.", Project.Name & " – Error adding note", MessageBoxButtons.OK)
    '    '    Exit Sub
    '    'End If

    '    Dim frm As New frmNote(mobjCase, objNote, 1)
    '    frm.ShowDialog()

    '    If frm.DialogResult = DialogResult.OK Then
    '        FillGrid(mobjCase)
    '        SelectedNote = objNote
    '        RaiseEvent OnChanged(Me, objNote)
    '    End If

    'End Sub

    'Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    'Dim objNote As Note = GetSelectedNote()

    '    'Dim frm As New frmNote(mobjCase, objNote)
    '    'frm.ShowDialog()

    '    'If frm.DialogResult = DialogResult.OK Then
    '    '    FillGrid(mobjCase)
    '    '    SelectedNote = objNote
    '    '    RaiseEvent OnChanged(Me, objNote)
    '    'End If

    'End Sub

    'Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    'Dim objSelNote As AddressNote = Me.SelectedNote

    '    'mobjCase.AddressNotes.Remove(objSelNote)
    '    'RaiseEvent OnChanged(Me, objSelNote)
    '    'FillGrid(mobjCase)
    '    'SelectedNote = Nothing

    'End Sub

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
        Dim objNote As Note

        grdView.Rows.Clear()
        mblnObjectWasAdded = False

        If Not objCase Is Nothing Then
            'Dim objNotes  Notes(mobjCase)
            For Each objNote In objCase.Notes
                Dim strPerson As String = ""
                If objNote.Person IsNot Nothing Then
                    strPerson = objNote.Person.FullName
                End If

                If objNote.TableID = SelectedAddress.AddressID Or objNote.TableID.IsNull Then

                    Dim objDoc As Document
                    Dim strDocType As String = ""
                    Dim i As Integer = 0

                    If objNote.DocumentID > 0 Then

                        For Each objDoc In objCase.Documents
                            If objNote.DocumentID = objCase.Documents.Item(i).DocumentID Then
                                strDocType = CStr(objDoc.DocumentType.Description)
                                Exit For
                            End If
                            i = i + 1
                        Next

                    End If

                    'NOTE: change GetSafeDate(objNote.NoteDate) to GetSafeValue(objNote.NoteDate)
                    'below, if you want to display Time
                    ' EE: logic added 2/11/2015 for Is Field Note?  enhancement
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              imgCheckbox.Images("checkbox-unchecked.bmp"),
                                              GetSafeValue(objNote.CreatedOn),
                                              GetSafeValue(objNote.Notes),
                                              GetSafeValue(objNote.SourceType.Description),
                                              strPerson,
                                              strDocType,
                                              GetSafeValue(objNote.CreatedBy),
                                              GetSafeValue(objNote.MPRID)}

                    If GetSafeValue(objNote.IsFieldNote) Then
                        objRow(1) = imgCheckbox.Images("checkbox-checked.bmp")
                    End If

                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objNote

                End If

            Next
            RaiseEvent OnClick(Me, SelectedNote)
        End If
        grdView.Columns("Notes").DefaultCellStyle.BackColor = Color.LightYellow
        'grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Notes").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        grdView.Sort(grdView.Columns("CreatedOn"), ListSortDirection.Descending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        '    btnAdd.Enabled = mblnAllowAdd And mobjAddress IsNot Nothing
        '    btnEdit.Enabled = mblnAllowEdit And (SelectedNote IsNot Nothing)
        '    btnDelete.Enabled = EnableDeleteButton()

        '    'if no buttons are allowed, then expand the grid to cover the buttons
        '    Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))
        '    If blnReadOnly Then
        '        grdView.Height = grpMembers.Height - 24
        '    Else
        '        grdView.Height = grpMembers.Height - btnAdd.Height - 30
        '    End If

        '    btnAdd.Visible = Not blnReadOnly And mblnAllowAdd
        '    btnEdit.Visible = Not blnReadOnly And mblnAllowEdit
        '    btnDelete.Visible = Not blnReadOnly And mblnAllowDelete
    End Sub
    'Private Function EnableDeleteButton() As Boolean

    '    'If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
    '    '    'allow deleting of newly added records
    '    '    If SelectedNote IsNot Nothing AndAlso GetSafeValue(SelectedNote.NoteID).Equals(0) Then
    '    '        Return mblnAllowDelete
    '    '    Else    'otherwise, only supervisors can delete existing records
    '    '        Return mblnAllowDelete And Authorization.IsSupervisor
    '    '    End If
    '    'Else
    '    Return False
    '    'End If

    'End Function

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
