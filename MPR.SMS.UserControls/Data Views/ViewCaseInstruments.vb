'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Instrument records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseInstruments provides a reusable ListView/Grid control for
'''     browsing a case's Instruments. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseInstruments

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjInstrument As Instrument

    Private mblnAllowAdd As Boolean = True
    Private mblnAllowEdit As Boolean = True
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
            If Not Me.DesignMode Then FillGrid(mobjCase)
        End Set
    End Property

    Public Property SelectedInstrument As Instrument
        Get
            If mobjInstrument Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjInstrument = CType(grdView.SelectedRows(0).Tag, Instrument)
            End If
            Return mobjInstrument
        End Get
        Set
            mobjInstrument = value
            If mobjInstrument Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjInstrument) Then
                        grdView.Rows(objRow.Index).Selected = True
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    <DefaultValue(True)> <Category("Behavior")>
    Public Property AllowAdd As Boolean
        Get
            Return mblnAllowAdd
        End Get
        Set
            mblnAllowAdd = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(True)> <Category("Behavior")>
    Public Property AllowEdit As Boolean
        Get
            Return mblnAllowEdit
        End Get
        Set
            mblnAllowEdit = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
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

        Dim objInstrument As Instrument = mobjInstrument

        FillGrid(mobjCase)
        SelectedInstrument = objInstrument
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objInstrument As Instrument)
    Public Shadows Event OnDoubleClick(sender As Object, objInstrument As Instrument)
    Public Shadows Event OnChanged(sender As Object, objInstrument As Instrument)

#End Region

#Region "Event Handlers"

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjInstrument = CType(grdView.SelectedRows(0).Tag, Instrument)

            RaiseEvent OnClick(Me, SelectedInstrument)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
        End If
        btnStatus.Enabled = (SelectedInstrument IsNot Nothing)
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjInstrument = CType(grdView.SelectedRows(0).Tag, Instrument)

            RaiseEvent OnDoubleClick(Me, SelectedInstrument)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedInstrument.InstrumentID.IsNull Then
                    Dim frm As New frmDisplayHistory(SelectedInstrument)
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'To-do: create frmInstrument
        'Dim objInstrument As New Instrument(mobjCase.CaseID.Value)

        'Dim frm As New frmInstrument(mobjCase, objInstrument)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjCase)
        '    SelectedInstrument = objInstrument
        '    RaiseEvent OnChanged(Me, objInstrument)
        'End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'To-do: create frmInstrument
        'Dim objInstrument As Instrument = Me.SelectedInstrument

        'Dim frm As New frmInstrument(mobjCase, objInstrument)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjCase)
        '    SelectedInstrument = objInstrument
        '    RaiseEvent OnChanged(Me, objInstrument)
        'End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelInstrument As Instrument = Me.SelectedInstrument

        mobjCase.Instruments.Remove(objSelInstrument)
        RaiseEvent OnChanged(Me, objSelInstrument)
        FillGrid(mobjCase)
        SelectedInstrument = Nothing
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objCase As [Case])

        Dim objInstrument As Instrument

        grdView.Rows.Clear()

        If Not objCase Is Nothing Then
            For Each objInstrument In objCase.Instruments

                Dim strSM As String = ""
                If Not objInstrument.SampleMember Is Nothing Then
                    strSM = GetSafeValue(objInstrument.SampleMember.FullName)
                End If

                Dim strCR As String = ""
                If Not objInstrument.CurrentRespondent Is Nothing Then
                    strCR = GetSafeValue(objInstrument.CurrentRespondent.FullName)
                End If

                Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                          GetSafeValue(objInstrument.InstrumentID),
                                          GetSafeValue(objInstrument.InstrumentType.Description),
                                          GetSafeValue(objInstrument.InstrumentTypeID),
                                          GetSafeValue(objInstrument.SampleMemberMPRID),
                                          strSM,
                                          GetSafeValue(objInstrument.CurrentRespondentMPRID),
                                          strCR,
                                          GetSafeValue(objInstrument.CurrentStatus) & " - " &
                                          GetSafeValue(objInstrument.Status.Description),
                                          GetSafeValue(objInstrument.LogicalStatus) & " - " &
                                          GetSafeValue(objInstrument.LogicalStatusObj.Description),
                                          GetSafeDate(objInstrument.StatusChangeDate),
                                          GetSafeValue(objInstrument.StatusChangedBy),
                                          GetSafeDate(objInstrument.ReleaseDate),
                                          GetSafeValue(objInstrument.Round)}


                grdView.Rows.Add(objRow)
                grdView.Rows(grdView.Rows.Count - 1).Tag = objInstrument
            Next
            RaiseEvent OnClick(Me, SelectedInstrument)
        End If
        grdView.Columns("Type").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd
        btnEdit.Enabled = mblnAllowEdit And (SelectedInstrument IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()
        btnStatus.Enabled = (grdView.Rows.Count > 0)

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))

        'If blnReadOnly Then
        '    grdView.Height = grpMembers.Height - 20
        'Else
        '    grdView.Height = grpMembers.Height - btnAdd.Height - 26
        'End If
        grdView.Height = grpMembers.Height - btnStatus.Height - 26

        btnAdd.Visible = Not blnReadOnly
        btnEdit.Visible = Not blnReadOnly
        btnDelete.Visible = Not blnReadOnly 'And mblnAllowDelete
    End Sub

    Private Function EnableDeleteButton() As Boolean

        If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
            'allow deleting of newly added records
            If SelectedInstrument IsNot Nothing AndAlso GetSafeValue(SelectedInstrument.InstrumentID).Equals(0) Then
                Return mblnAllowDelete
            Else 'otherwise, only supervisors can delete existing records
                Return mblnAllowDelete And CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
            End If
        Else
            Return False
        End If
    End Function

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("InstrumentID").Visible

        blnShow = Not blnShow
        grdView.Columns("InstrumentID").Visible = blnShow
        grdView.Columns("InstType").Visible = blnShow
        grdView.Columns("SMMPRID").Visible = blnShow
        grdView.Columns("CRMPRID").Visible = blnShow
        grdView.Columns("LogicalStatus").Visible = blnShow
        If blnShow Then
            btnShowID.ImageKey = "hide.bmp"
        Else
            btnShowID.ImageKey = "show.bmp"
        End If
        grdView.Focus()
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click

        If Not SelectedInstrument.InstrumentID.IsNull Then
            Dim strSQL As String = "SELECT * FROM vwInstrumentStatusHistory WHERE InstrumentID = " &
                                   SelectedInstrument.InstrumentID.Value
            Dim frm As New frmDisplayDataView(strSQL, "Instrument Status Update Rule")
            frm.Width = grdView.Width
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y + 12)
            frm.Columns(1).Visible = False
            frm.SortedColumn = frm.Columns(0)
            frm.SortDirection = ListSortDirection.Descending
            frm.Show()
        End If
    End Sub

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
