'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all LocatingAttempt records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseLocatingAttempts provides a reusable ListView/Grid control for
'''     browsing a case's LocatingAttempts. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseLocatingAttempts

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjLocatingAttempt As LocatingAttempt

    Private mblnAllowAdd As Boolean = True
    Private mblnAllowEdit As Boolean = False
    Private mblnAllowDelete As Boolean = False

    Private mblnObjectWasAdded As Boolean = False

#End Region

#Region "Public Properties"

    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
        End Set
    End Property

    Public Property SelectedPerson As Person
        Get
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
            If SelectedCase Is Nothing AndAlso
               mobjPerson IsNot Nothing Then
                SelectedCase = mobjPerson.Case
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    Public Property SelectedLocatingAttempt As LocatingAttempt
        Get
            If mobjLocatingAttempt Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjLocatingAttempt = CType(grdView.SelectedRows(0).Tag, LocatingAttempt)
            End If
            Return mobjLocatingAttempt
        End Get
        Set
            mobjLocatingAttempt = value
            If mobjLocatingAttempt Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjLocatingAttempt) Then
                        grdView.Rows(objRow.Index).Selected = True
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    <Category("Behavior")>
    Public Property AllowAdd As Boolean
        Get
            Return mblnAllowAdd
        End Get
        Set
            mblnAllowAdd = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> _
    <Category("Behavior")>
    Public Property AllowEdit As Boolean
        Get
            Return mblnAllowEdit
        End Get
        Set
            mblnAllowEdit = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> _
    <Category("Behavior")>
    Public Property AllowDelete As Boolean
        Get
            Return mblnAllowDelete
        End Get
        Set
            mblnAllowDelete = value
            SetButtons()
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objLocatingAttempt As LocatingAttempt = mobjLocatingAttempt

        FillGrid(mobjPerson)
        SelectedLocatingAttempt = objLocatingAttempt
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objLocatingAttempt As LocatingAttempt)
    Public Shadows Event OnDoubleClick(sender As Object, objLocatingAttempt As LocatingAttempt)
    Public Shadows Event OnChanged(sender As Object, objLocatingAttempt As LocatingAttempt)

#End Region

#Region "Event Handlers"

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjLocatingAttempt = CType(grdView.SelectedRows(0).Tag, LocatingAttempt)

            RaiseEvent OnClick(Me, SelectedLocatingAttempt)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjLocatingAttempt = CType(grdView.SelectedRows(0).Tag, LocatingAttempt)

            RaiseEvent OnDoubleClick(Me, SelectedLocatingAttempt)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedLocatingAttempt.LocatingAttemptID.IsNull Then
                    Dim frm As New frmDisplayHistory(SelectedLocatingAttempt)
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

        e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
        If e.Column.Name = "AttemptDate" Then
            e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
        ElseIf e.SortResult = 0 Then
            e.SortResult = DateTime.Compare(CType(grdView.Rows(e.RowIndex1).Cells("AttemptDate").Value, DateTime),
                                            CType(grdView.Rows(e.RowIndex2).Cells("AttemptDate").Value, DateTime))
        End If
        e.Handled = True
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ''TO-DO: Add a Locating Attempt
        'Dim objLocatingAttemptType As New LocatingAttemptType(0)
        'Dim frm As New frmLocatingAttempt(mobjPerson, objLocatingAttemptType)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjPerson)
        '    SelectedLocatingAttempt = objLocatingAttempt
        '    RaiseEvent OnChanged(Me, mobjPerson.LocatingAttempts(mobjPerson.LocatingAttempts.Count - 1))
        'End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'Dim objPerson As Person = mobjPerson
        'Dim objLocatingAttempt As LocatingAttempt = SelectedLocatingAttempt

        'TO-DO: Edit Locating Attempts?
        'Dim frm As New frmLocatingAttempt(mobjCase, objPerson, objLocatingAttempt)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjPerson)
        '    SelectedLocatingAttempt = objLocatingAttempt
        '    RaiseEvent OnChanged(Me, objLocatingAttempt)
        'End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelLocatingAttempt As LocatingAttempt = SelectedLocatingAttempt

        mobjPerson.LocatingAttempts.Remove(objSelLocatingAttempt)
        RaiseEvent OnChanged(Me, objSelLocatingAttempt)
        FillGrid(mobjPerson)
        SelectedLocatingAttempt = Nothing
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("LocatingAttemptID").Visible

        blnShow = Not blnShow
        grdView.Columns("LocatingAttemptID").Visible = blnShow
        If blnShow Then
            btnShowID.ImageKey = "hide.bmp"
        Else
            btnShowID.ImageKey = "show.bmp"
        End If
        grdView.Focus()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objPerson As Person)

        Dim objLocatingAttempt As LocatingAttempt

        grdView.Rows.Clear()

        If Not objPerson Is Nothing Then
            For Each objLocatingAttempt In objPerson.LocatingAttempts

                Dim strName As String = objLocatingAttempt.DisplayName
                Dim strAddress As String = objLocatingAttempt.DisplayAddress
                Dim strPhone As String = objLocatingAttempt.DisplayPhone
                Dim strEmail As String = objLocatingAttempt.DisplayEmail
                Dim strStatus As String = GetSafeValue(objLocatingAttempt.LocatingStatus)
                If Not strStatus.Equals("") Then
                    strStatus = (New Status(strStatus)).DisplayName
                End If

                Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                          GetSafeValue(objLocatingAttempt.LocatingAttemptID),
                                          GetSafeValue(objLocatingAttempt.LocatingAttemptDate),
                                          GetSafeValue(objLocatingAttempt.LocatingAttemptType.LocatingAttemptType),
                                          GetSafeValue(objLocatingAttempt.LocatingAttemptResult.LocatingAttemptResult),
                                          strStatus,
                                          strPhone,
                                          GetSafeValue(objLocatingAttempt.Note),
                                          strName,
                                          strAddress,
                                          strEmail,
                                          GetSafeValue(objLocatingAttempt.CreatedBy),
                                          GetSafeValue(objLocatingAttempt.Round)}

                If GetSafeValue(objLocatingAttempt.LocatingAttemptID).Equals(0) Then
                    mblnObjectWasAdded = True
                End If
                grdView.Rows.Add(objRow)
                grdView.Rows(grdView.Rows.Count - 1).Tag = objLocatingAttempt
            Next
            RaiseEvent OnClick(Me, SelectedLocatingAttempt)
        End If
        grdView.Columns("Type").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Note").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        grdView.Columns("Address").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        grdView.Sort(grdView.Columns("AttemptDate"), ListSortDirection.Descending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjPerson IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedLocatingAttempt IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))
        If blnReadOnly Then
            grdView.Height = grpMembers.Height - 24
        Else
            grdView.Height = grpMembers.Height - btnAdd.Height - 30
        End If

        btnAdd.Visible = Not blnReadOnly
        btnEdit.Visible = Not blnReadOnly And False '<-- to-do: allow editing?
        btnDelete.Visible = Not blnReadOnly And mblnAllowDelete
    End Sub

    Private Function EnableDeleteButton() As Boolean

        If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
            'allow deleting of newly added records
            If _
                SelectedLocatingAttempt IsNot Nothing AndAlso
                GetSafeValue(SelectedLocatingAttempt.LocatingAttemptID).Equals(0) Then
                Return mblnAllowDelete
            Else 'otherwise, only supervisors can delete existing records
                Return mblnAllowDelete And CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
            End If
        Else
            Return False
        End If
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
