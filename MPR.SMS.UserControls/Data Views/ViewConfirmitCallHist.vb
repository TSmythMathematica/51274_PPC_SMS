'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class ViewConfirmitCallHist

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjNote As ConfirmitCallHistoryRecord

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

    Public Property SelectedNote As ConfirmitCallHistoryRecord

        Get
            If mobjNote Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjNote = CType(grdView.SelectedRows(0).Tag, ConfirmitCallHistoryRecord)
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

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        'Dim objNote As CallHistoryRecord = mobjNote

        FillGrid(mobjCase)
        'SelectedNote = objNote
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objNote As ConfirmitCallHistoryRecord)
    Public Shadows Event OnDoubleClick(sender As Object, objNote As ConfirmitCallHistoryRecord)
    Public Shadows Event OnChanged(sender As Object, objNote As ConfirmitCallHistoryRecord)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, ConfirmitCallHistoryRecord)
            RaiseEvent OnClick(Me, SelectedNote)
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjNote = CType(grdView.SelectedRows(0).Tag, ConfirmitCallHistoryRecord)
            RaiseEvent OnDoubleClick(Me, SelectedNote)
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

        Dim mblnGroupByName As Boolean = False

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
                Try
                    e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
                Catch ex As Exception
                    e.SortResult = String.Compare(CType(e.CellValue1, String), CType(e.CellValue2, String))
                End Try

            ElseIf e.SortResult = 0 Then
                Try
                    e.SortResult = DateTime.Compare(CType(grdView.Rows(e.RowIndex1).Cells("NoteDate").Value, DateTime),
                                                    CType(grdView.Rows(e.RowIndex2).Cells("NoteDate").Value, DateTime))
                Catch ex As Exception
                    e.SortResult = String.Compare(CType(grdView.Rows(e.RowIndex1).Cells("NoteDate").Value, String),
                                                  CType(grdView.Rows(e.RowIndex2).Cells("NoteDate").Value, String))
                End Try

            End If
        End If

        e.Handled = True
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

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objCase As [Case])

        Dim objNote As ConfirmitCallHistoryRecord

        grdView.Rows.Clear()

        If objCase IsNot Nothing Then

            For Each objNote In objCase.ConfirmitCallHistoryRecords

                'NOTE: change GetSafeDate(objNote.NoteDate) to GetSafeValue(objNote.NoteDate)
                'below, if you want to display Time
                Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                          GetSafeValue(mobjCase.PrimarySampleMember.MPRID),
                                          GetSafeValue(objNote.CallDateFormatted),
                                          GetSafeValue(objNote.CallStatusName),
                                          GetSafeValue(objNote.CallComment),
                                          GetSafePhone(objNote.CallPhoneNumber),
                                          GetSafeValue(objNote.TimeZoneName),
                                          GetSafeValue(objNote.CallCountCalls),
                                          GetSafeValue(objNote.CallPhoneIndex),
                                          GetSafeValue(objNote.SMVerifiedLabel),
                                          GetSafeValue(objNote.CallRefusalScore),
                                          GetSafeValue(objNote.CallQL),
                                          GetSafeValue(objNote.CallInter_Name),
                                          GetSafeValue(objNote.InstrumentType),
                                          GetSafeValue(objNote.Round)}

                grdView.Rows.Add(objRow)
                grdView.Rows(grdView.Rows.Count - 1).Tag = objNote
            Next
            'RaiseEvent OnClick(Me, SelectedNote)
        End If
        grdView.Columns("Notes").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Notes").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        grdView.Sort(grdView.Columns("NoteDate"), ListSortDirection.Descending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region
End Class

