'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Email records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseEmails provides a reusable ListView/Grid control for
'''     browsing a case's Emails. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseEmails

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjEmail As Email

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
                SelectedEmail = mobjPerson.BestEmail
            Else
                SelectedEmail = Nothing
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedEmail As Email
        Get
            If mobjEmail Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjEmail = CType(grdView.SelectedRows(0).Tag, Email)
            ElseIf grdView.Rows.Count.Equals(0) Then
                mobjEmail = Nothing
            End If
            Return mobjEmail
        End Get
        Set
            mobjEmail = value
            If mobjEmail Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjEmail) Then
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

        Dim objEmail As Email = mobjEmail

        FillGrid(mobjPerson)
        SelectedEmail = objEmail
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objEmail As Email)
    Public Shadows Event OnDoubleClick(sender As Object, objEmail As Email)
    Public Shadows Event OnChanged(sender As Object, objEmail As Email)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjEmail = CType(grdView.SelectedRows(0).Tag, Email)

            RaiseEvent OnClick(Me, SelectedEmail)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
            btnBest.Enabled = btnEdit.Enabled
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjEmail = CType(grdView.SelectedRows(0).Tag, Email)

            RaiseEvent OnDoubleClick(Me, SelectedEmail)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedEmail.EmailID.IsNull Then
                    ctxMenu.Show(grdView, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub mnuViewEmailHistory_Click(sender As Object, e As EventArgs) Handles mnuViewEmailHistory.Click

        Dim frm As New frmDisplayHistory(SelectedEmail)
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y)
        End If
        frm.Show()
    End Sub

    Private Sub mnuViewBestEmailHistory_Click(sender As Object, e As EventArgs) Handles mnuViewBestEmailHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestEmailHistory WHERE MPRID = " & SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Email Selection History")
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
        Dim objEmail As New Email(GetSafeValue(mobjPerson.CaseID))

        objEmail.Person = objPerson

        Dim frm As New frmEmail(mobjCase, objPerson, objEmail)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedEmail = objEmail
            RaiseEvent OnChanged(Me, objEmail)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = mobjPerson
        Dim objEmail As Email = SelectedEmail

        Dim frm As New frmEmail(mobjCase, objPerson, objEmail)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedEmail = objEmail
            RaiseEvent OnChanged(Me, objEmail)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelEmail As Email = SelectedEmail

        mobjCase.Emails.Remove(objSelEmail)
        RaiseEvent OnChanged(Me, objSelEmail)
        FillGrid(mobjPerson)
        SelectedEmail = Nothing
    End Sub

    Private Sub btnBest_Click(sender As Object, e As EventArgs) Handles btnBest.Click

        mobjPerson.BestEmail = mobjEmail
        Refresh()
        RaiseEvent OnChanged(Me, mobjEmail)
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("EmailID").Visible

        blnShow = Not blnShow
        grdView.Columns("EmailID").Visible = blnShow
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

        Dim objPrevEmail As Email = SelectedEmail

        grdView.Rows.Clear()

        If Not objPerson Is Nothing Then
            For Each objEmail As Email In objPerson.Emails

                Dim blnOK As Boolean = chkShowDuplicates.Checked OrElse
                                       (Not GetSafeValue(objEmail.SourceQuality.Description).Equals("Duplicate"))

                If blnOK Then
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              GetSafeValue(objEmail.EmailID),
                                              GetSafeValue(objEmail.SourceQuality.Rank),
                                              imgQuality.Images("Quality-Unknown.bmp"),
                                              GetSafeValue(objEmail.EmailAddress),
                                              GetSafeValue(objEmail.EmailType.Description),
                                              GetSafeDate(objEmail.CreatedOn),
                                              GetSafeValue(objEmail.Round)}

                    If mobjPerson.BestEmail IsNot Nothing AndAlso mobjPerson.BestEmail.Equals(objEmail) Then
                        objRow(0) = imgImages.Images("Best Email.bmp")
                    End If
                    If GetSafeValue(objEmail.SourceQualityID) = 1 Then
                        objRow(3) = imgQuality.Images("Quality-Bad.bmp")
                    ElseIf GetSafeValue(objEmail.SourceQualityID) = 2 Then
                        objRow(3) = imgQuality.Images("Quality-Good.bmp")
                    ElseIf GetSafeValue(objEmail.SourceQualityID) = 3 Then
                        objRow(3) = imgQuality.Images("Quality-Duplicate.bmp")
                    End If
                    If GetSafeValue(objEmail.EmailID).Equals(0) Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objEmail
                End If
            Next
            SelectedEmail = objPrevEmail
            RaiseEvent OnClick(Me, SelectedEmail)
        End If
        grdView.Columns("Email").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        grdView.Sort(grdView.Columns("Rank"), ListSortDirection.Ascending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjPerson IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedEmail IsNot Nothing)
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
            If SelectedEmail IsNot Nothing AndAlso GetSafeValue(SelectedEmail.EmailID).Equals(0) Then
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
