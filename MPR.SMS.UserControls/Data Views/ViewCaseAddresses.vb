'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Person records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseAddresses provides a reusable ListView/Grid control for
'''     browsing a case's members. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseAddresses

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjAddress As Address


    Private mblnAllowAdd As Boolean = True
    Private mblnAllowEdit As Boolean = True
    Private mblnAllowDelete As Boolean = False
    Private mblnShowDuplicates As Boolean = False

    Private mblnObjectWasAdded As Boolean = False

#End Region

#Region "Public Properties"

    <Browsable(False)>
    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
        End Set
    End Property

    <Browsable(False)>
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
            If mobjPerson IsNot Nothing Then
                If mobjPerson.BestPhysicalAddress IsNot Nothing Then
                    SelectedAddress = mobjPerson.BestPhysicalAddress
                ElseIf mobjPerson.BestMailingAddress IsNot Nothing Then
                    SelectedAddress = mobjPerson.BestMailingAddress
                Else
                    SelectedAddress = mobjPerson.BestCheckAddress
                End If
            Else
                SelectedAddress = Nothing
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedAddress As Address
        Get
            If mobjAddress Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)
            ElseIf grdView.Rows.Count.Equals(0) Then
                mobjAddress = Nothing
            End If
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
            If mobjAddress Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjAddress) Then
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

    <DefaultValue(False)> <Category("Behavior")>
    Public Property ShowDuplicates As Boolean
        Get
            Return mblnShowDuplicates
        End Get
        Set
            If mblnShowDuplicates <> value Then
                mblnShowDuplicates = value
                chkShowDuplicates.Checked = value
                FillGrid(SelectedPerson)
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objAddress As Address = mobjAddress

        FillGrid(mobjPerson)
        SelectedAddress = objAddress
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objAddress As Address)
    Public Shadows Event OnDoubleClick(sender As Object, objAddress As Address)
    Public Shadows Event OnChanged(sender As Object, objAddress As Address)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)

            RaiseEvent OnClick(Me, SelectedAddress)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
            btnBest.Enabled = btnEdit.Enabled
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)

            RaiseEvent OnDoubleClick(Me, SelectedAddress)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedAddress.AddressID.IsNull Then
                    ctxMenu.Show(grdView, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub mnuViewAddressHistory_Click(sender As Object, e As EventArgs) Handles mnuViewAddressHistory.Click

        Dim frm As New frmDisplayHistory(SelectedAddress)
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y)
        End If
        frm.Show()
    End Sub

    Private Sub mnuViewBestMailingAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestMailingAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestMailingAddressHistory WHERE MPRID = " &
                               SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Mailing Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 12 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 12)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub mnuViewBestPhysicalAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestPhysicalAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestPhysicalAddressHistory WHERE MPRID = " &
                               SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Physical Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 24 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 24)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub mnuViewBestCheckAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestCheckAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestCheckAddressHistory WHERE MPRID = " & SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Check Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 36 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 36)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim objPerson As Person = mobjPerson
        Dim objAddress As New Address(GetSafeValue(mobjPerson.CaseID))
        'Dim objPhone As New Phone(GetSafeValue(mobjPerson.CaseID))

        'BT: 12/08/2014 Added for Address Notes.
        Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))
        Dim intNoteTypeID As Int16 = 1 'Note Type As Address

        objNote.Case = mobjCase
        objNote.Person = objAddress.Person
        objNote.Address = objAddress
        'BT: 12/08/2014 Added for Address Notes.

        objPerson.Case = mobjCase

        objAddress.Person = objPerson
        objAddress.Person = objPerson

        'Dim frm As New frmPersonAdd(mobjCase, objPerson, objAddress, objPhone)
        Dim frm As New frmAddressEdit(mobjCase, objPerson, objAddress, objNote, intNoteTypeID) _
        'BT: 12/08/2014 Added for Address Notes.
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedAddress = objAddress
            RaiseEvent OnChanged(Me, objAddress)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = mobjPerson
        Dim objAddress As Address = SelectedAddress

        'BT: 12/08/2014 Added for Address Notes.
        Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))
        Dim intNoteTypeID As Int16 = 1 'Note Type As Address


        objNote.Case = mobjAddress.Case
        objNote.Person = mobjAddress.Person
        objNote.Address = mobjAddress
        'BT: 12/08/2014 Added for Address Notes.

        Dim frm As New frmAddressEdit(mobjCase, objPerson, objAddress, objNote, intNoteTypeID) _
        'BT: 12/08/2014 Added for Address Notes.
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedAddress = objAddress
            RaiseEvent OnChanged(Me, objAddress)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelAddress As Address = SelectedAddress

        mobjCase.Addresses.Remove(objSelAddress)
        RaiseEvent OnChanged(Me, objSelAddress)
        FillGrid(mobjPerson)
        SelectedAddress = Nothing
    End Sub

    Private Sub btnBest_Click(sender As Object, e As EventArgs) Handles btnBest.Click

        btnBest.ContextMenuStrip.Show(btnBest, New Point(0, btnBest.Height))
    End Sub

    Private Sub BestCheckAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestCheckAddressToolStripMenuItem.Click

        mobjPerson.BestCheckAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub BestMailingAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestMailingAddressToolStripMenuItem.Click

        mobjPerson.BestMailingAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub BestPhysicalAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestPhysicalAddressToolStripMenuItem.Click

        mobjPerson.BestPhysicalAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub MarkAsBestForAllToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles MarkAsBestForAllToolStripMenuItem.Click

        mobjPerson.BestCheckAddress = mobjAddress
        mobjPerson.BestMailingAddress = mobjAddress
        mobjPerson.BestPhysicalAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("AddressID").Visible

        blnShow = Not blnShow
        grdView.Columns("AddressID").Visible = blnShow
        If blnShow Then
            btnShowID.ImageKey = "hide.bmp"
        Else
            btnShowID.ImageKey = "show.bmp"
        End If
        grdView.Focus()
    End Sub

    Private Sub chkShowDuplicates_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkShowDuplicates.CheckedChanged

        ShowDuplicates = chkShowDuplicates.Checked
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objPerson As Person)

        If Project Is Nothing Then Exit Sub

        grdView.Rows.Clear()
        Dim objPrevAddress As Address = SelectedAddress

        If Not objPerson Is Nothing Then
            For Each objAddress As Address In objPerson.Addresses

                Dim blnOK As Boolean = chkShowDuplicates.Checked OrElse
                                       (Not GetSafeValue(objAddress.SourceQuality.Description).Equals("Duplicate"))

                If blnOK Then
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              imgImages.Images("empty.ico"),
                                              imgImages.Images("empty.ico"),
                                              GetSafeValue(objAddress.AddressID),
                                              GetSafeValue(objAddress.SourceQuality.Rank),
                                              imgQuality.Images("Quality-Unknown.bmp"),
                                              imgImages.Images("empty.ico"),
                                              objAddress.FullStreetAddress,
                                              GetSafeValue(objAddress.City),
                                              GetSafeValue(objAddress.State),
                                              GetSafeZip(objAddress.PostalCode),
                                              GetSafeValue(objAddress.AddressType.Description),
                                              GetSafeDate(objAddress.CreatedOn),
                                              GetSafeValue(objAddress.Round)}

                    If _
                        Not mobjPerson.BestPhysicalAddress Is Nothing AndAlso
                        mobjPerson.BestPhysicalAddress.Equals(objAddress) Then
                        objRow(0) = imgImages.Images("Best PhysicalAddress.bmp")
                    End If
                    If _
                        Not mobjPerson.BestMailingAddress Is Nothing AndAlso
                        mobjPerson.BestMailingAddress.Equals(objAddress) Then
                        objRow(1) = imgImages.Images("Best MailingAddress.bmp")
                    End If
                    If Not mobjPerson.BestCheckAddress Is Nothing AndAlso mobjPerson.BestCheckAddress.Equals(objAddress) _
                        Then
                        objRow(2) = imgImages.Images("Best CheckAddress.bmp")
                    End If
                    If GetSafeValue(objAddress.SourceQualityID) = 1 Then
                        objRow(5) = imgQuality.Images("Quality-Bad.bmp")
                    ElseIf GetSafeValue(objAddress.SourceQualityID) = 2 Then
                        objRow(5) = imgQuality.Images("Quality-Good.bmp")
                    ElseIf GetSafeValue(objAddress.SourceQualityID) = 3 Then
                        objRow(5) = imgQuality.Images("Quality-Duplicate.bmp")
                    End If
                    If GetSafeValue(objAddress.IsCleaned) Then
                        objRow(6) = imgImages.Images("SuccessComplete.bmp")
                    End If
                    If GetSafeValue(objAddress.AddressID).Equals(0) Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objAddress
                End If
            Next
            SelectedAddress = objPrevAddress
            RaiseEvent OnClick(Me, SelectedAddress)
        End If
        grdView.Columns("Address").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        grdView.Sort(grdView.Columns("Rank"), ListSortDirection.Ascending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'If grdView.SelectedRows.Count > 0 Then grdView.SelectedRows(0).Selected = False

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjPerson IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedAddress IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()
        btnBest.Enabled = btnEdit.Enabled

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))
        If blnReadOnly Then
            grdView.Height = grpMembers.Height - 24
        Else
            grdView.Height = grpMembers.Height - btnAdd.Height - 30
        End If

        btnAdd.Visible = Not blnReadOnly
        btnEdit.Visible = Not blnReadOnly
        btnDelete.Visible = Not blnReadOnly And mblnAllowDelete
        btnBest.Visible = Not blnReadOnly
    End Sub

    Private Function EnableDeleteButton() As Boolean

        If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
            'allow deleting of newly added records
            If SelectedAddress IsNot Nothing AndAlso GetSafeValue(SelectedAddress.AddressID).Equals(0) Then
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
