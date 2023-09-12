'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Phone records within a case.
''' </summary>
''' <remarks>
'''     ViewCasePhones provides a reusable ListView/Grid control for
'''     browsing a case's Phones. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCasePhones

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjPhone As Phone

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
                SelectedPhone = mobjPerson.BestPhone
            Else
                SelectedPhone = Nothing
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedPhone As Phone
        Get
            If mobjPhone Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjPhone = CType(grdView.SelectedRows(0).Tag, Phone)
            ElseIf grdView.Rows.Count.Equals(0) Then
                mobjPhone = Nothing
            End If
            Return mobjPhone
        End Get
        Set
            mobjPhone = value
            If mobjPhone Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjPhone) Then
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

        Dim objPhone As Phone = mobjPhone

        FillGrid(mobjPerson)
        SelectedPhone = objPhone
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objPhone As Phone)
    Public Shadows Event OnDoubleClick(sender As Object, objPhone As Phone)
    Public Shadows Event OnChanged(sender As Object, objPhone As Phone)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjPhone = CType(grdView.SelectedRows(0).Tag, Phone)

            RaiseEvent OnClick(Me, SelectedPhone)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
            btnBest.Enabled = btnEdit.Enabled
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjPhone = CType(grdView.SelectedRows(0).Tag, Phone)

            RaiseEvent OnDoubleClick(Me, SelectedPhone)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedPhone.PhoneID.IsNull Then
                    ctxMenu.Show(grdView, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub mnuViewPhoneHistory_Click(sender As Object, e As EventArgs) Handles mnuViewPhoneHistory.Click

        Dim frm As New frmDisplayHistory(SelectedPhone)
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y)
        End If
        frm.Show()
    End Sub

    Private Sub mnuViewBestPhoneHistory_Click(sender As Object, e As EventArgs) Handles mnuViewBestPhoneHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestPhoneHistory WHERE MPRID = " & SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Phone Selection History")
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim objPerson As Person = mobjPerson
        Dim objPhone As New Phone(GetSafeValue(mobjPerson.CaseID))

        objPhone.Person = objPerson

        Dim frm As New frmPhone(mobjCase, objPerson, objPhone)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedPhone = objPhone
            RaiseEvent OnChanged(Me, objPhone)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = mobjPerson
        Dim objPhone As Phone = SelectedPhone

        Dim frm As New frmPhone(mobjCase, objPerson, objPhone)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedPhone = objPhone
            RaiseEvent OnChanged(Me, objPhone)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelPhone As Phone = SelectedPhone

        mobjCase.Phones.Remove(objSelPhone)
        RaiseEvent OnChanged(Me, objSelPhone)
        FillGrid(mobjPerson)
        SelectedPhone = Nothing
    End Sub

    Private Sub btnBest_Click(sender As Object, e As EventArgs) Handles btnBest.Click

        mobjPerson.BestPhone = mobjPhone
        Refresh()
        RaiseEvent OnChanged(Me, mobjPhone)
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("PhoneID").Visible

        blnShow = Not blnShow
        grdView.Columns("PhoneID").Visible = blnShow
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

        Dim objPrevPhone As Phone = SelectedPhone

        grdView.Rows.Clear()

        If Not objPerson Is Nothing Then
            For Each objPhone As Phone In objPerson.Phones

                Dim blnOK As Boolean = chkShowDuplicates.Checked OrElse
                                       (Not GetSafeValue(objPhone.SourceQuality.Description).Equals("Duplicate"))

                If blnOK Then
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              GetSafeValue(objPhone.PhoneID),
                                              GetSafeValue(objPhone.SourceQuality.Rank),
                                              imgQuality.Images("Quality-Unknown.bmp"),
                                              imgImages.Images("empty.ico"),
                                              GetSafePhone(objPhone.PhoneNum),
                                              GetSafeValue(objPhone.Extension),
                                              GetSafeValue(objPhone.PhoneTime.Description),
                                              GetSafeValue(objPhone.PhoneType.Description),
                                              GetSafeValue(objPhone.ListedTo),
                                              GetSafeValue(objPhone.Notes),
                                              GetSafeDate(objPhone.CreatedOn),
                                              GetSafeValue(objPhone.Round)}

                    If mobjPerson.BestPhone IsNot Nothing AndAlso mobjPerson.BestPhone.Equals(objPhone) Then
                        objRow(0) = imgImages.Images("Best Phone.bmp")
                    End If
                    If GetSafeValue(objPhone.SourceQualityID) = 1 Then
                        objRow(3) = imgQuality.Images("Quality-Bad.bmp")
                    ElseIf GetSafeValue(objPhone.SourceQualityID) = 2 Then
                        objRow(3) = imgQuality.Images("Quality-Good.bmp")
                    ElseIf GetSafeValue(objPhone.SourceQualityID) = 3 Then
                        objRow(3) = imgQuality.Images("Quality-Duplicate.bmp")
                    End If
                    If GetSafeValue(objPhone.IsCleaned) Then
                        objRow(4) = imgImages.Images("SuccessComplete.bmp")
                    End If
                    If GetSafeValue(objPhone.PhoneID).Equals(0) Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objPhone
                End If
            Next
            SelectedPhone = objPrevPhone
            RaiseEvent OnClick(Me, SelectedPhone)
        End If
        grdView.Columns("Phone").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        grdView.Sort(grdView.Columns("Rank"), ListSortDirection.Ascending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjPerson IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedPhone IsNot Nothing)
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
            If SelectedPhone IsNot Nothing AndAlso GetSafeValue(SelectedPhone.PhoneID).Equals(0) Then
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
