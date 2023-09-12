'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all SocialNetwork records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseSocialNetworkData provides a reusable ListView/Grid control for
'''     browsing a case's SocialNetworkData. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>

    Public Class ViewCaseSocialNetworks

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjSocialNetwork As SocialNetwork

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
                SelectedSocialNetwork = mobjPerson.BestSocialNetwork
            Else
                SelectedSocialNetwork = Nothing
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedSocialNetwork As SocialNetwork
        Get
            If mobjSocialNetwork Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjSocialNetwork = CType(grdView.SelectedRows(0).Tag, SocialNetwork)
            ElseIf grdView.Rows.Count.Equals(0) Then
                mobjSocialNetwork = Nothing
            End If
            Return mobjSocialNetwork
        End Get
        Set
            mobjSocialNetwork = value
            If mobjSocialNetwork Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjSocialNetwork) Then
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

    <DefaultValue(False)>
    <Category("Behavior")>
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

        Dim objSocialNetwork As SocialNetwork = mobjSocialNetwork

        FillGrid(mobjPerson)
        SelectedSocialNetwork = objSocialNetwork
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objSocialNetwork As SocialNetwork)
    Public Shadows Event OnDoubleClick(sender As Object, objSocialNetwork As SocialNetwork)
    Public Shadows Event OnChanged(sender As Object, objSocialNetwork As SocialNetwork)

#End Region

#Region "Event Handlers"

    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 140
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjSocialNetwork = CType(grdView.SelectedRows(0).Tag, SocialNetwork)

            RaiseEvent OnClick(Me, SelectedSocialNetwork)
            btnEdit.Enabled = mblnAllowEdit
            btnDelete.Enabled = EnableDeleteButton()
            btnBest.Enabled = btnEdit.Enabled
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            'If grdView.SelectedRows.Count = 0 Then
            '    mobjSocialNetwork = CType(grdView.Rows(grdView.SelectedCells(0).RowIndex).Tag, SocialNetwork)
            'Else
            mobjSocialNetwork = CType(grdView.SelectedRows(0).Tag, SocialNetwork)
            'End If


            RaiseEvent OnDoubleClick(Me, SelectedSocialNetwork)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedSocialNetwork.SocialNetworkID.IsNull Then
                    ctxMenu.Show(grdView, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub mnuViewSocialNetworkHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewSocialNetworkHistory.Click

        Dim frm As New frmDisplayHistory(SelectedSocialNetwork)
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y)
        End If
        frm.Show()
    End Sub

    Private Sub mnuViewBestSocialNetworkHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestSocialNetworkHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestSocialNetworkHistory WHERE MPRID = " & SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best SocialNetwork Selection History")
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

    Private Sub mnuLaunchURL_Click(sender As Object, e As EventArgs) Handles mnuLaunchURL.Click
        mobjSocialNetwork = CType(grdView.SelectedRows(0).Tag, SocialNetwork)
        Dim strURL As String = GetSafeValue(mobjSocialNetwork.URL)

        '        Dim frm As New frmWebBrowser(strURL)
        '        frm.Show()

        If Not strURL.StartsWith("http://") Then
            strURL = "http://" & strURL
        End If
        'Dim WebBrowser As New System.Windows.Forms.WebBrowser
        If strURL.Length.Equals(0) Then
            MessageBox.Show("Error launching URL.  Please make sure a proper URL is provided.", "No URL supplied",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            Try
                '    WebBrowser.Navigate(New Uri(strURL))
                Process.Start(strURL)
            Catch ex As UriFormatException
                MessageBox.Show(
                    ex.Message & Environment.NewLine & Environment.NewLine &
                    "Please make sure URL is properly formatted.", "Error launching URL", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim objPerson As Person = mobjPerson
        Dim objSocialNetwork As New SocialNetwork(GetSafeValue(mobjPerson.CaseID))

        objSocialNetwork.Person = objPerson

        Dim frm As New frmSocialNetwork(mobjCase, objPerson, objSocialNetwork)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedSocialNetwork = objSocialNetwork
            RaiseEvent OnChanged(Me, objSocialNetwork)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = mobjPerson
        Dim objSocialNetwork As SocialNetwork = SelectedSocialNetwork

        Dim frm As New frmSocialNetwork(mobjCase, objPerson, objSocialNetwork)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedSocialNetwork = objSocialNetwork
            RaiseEvent OnChanged(Me, objSocialNetwork)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelSocialNetwork As SocialNetwork = SelectedSocialNetwork

        mobjCase.SocialNetworks.Remove(objSelSocialNetwork)
        RaiseEvent OnChanged(Me, objSelSocialNetwork)
        FillGrid(mobjPerson)
        SelectedSocialNetwork = Nothing
    End Sub

    Private Sub btnBest_Click(sender As Object, e As EventArgs) Handles btnBest.Click

        mobjPerson.BestSocialNetwork = mobjSocialNetwork
        Refresh()
        RaiseEvent OnChanged(Me, mobjSocialNetwork)
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("SocialNetworkID").Visible

        blnShow = Not blnShow
        grdView.Columns("SocialNetworkID").Visible = blnShow
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

        Dim objPrevSocialNetwork As SocialNetwork = SelectedSocialNetwork

        grdView.Rows.Clear()

        If Not objPerson Is Nothing Then
            For Each objSocialNetwork As SocialNetwork In objPerson.SocialNetworks

                Dim blnOK As Boolean = chkShowDuplicates.Checked OrElse
                                       (Not GetSafeValue(objSocialNetwork.SourceQuality.Description).Equals("Duplicate"))

                Dim x As Integer = CInt(GetSafeValue(objSocialNetwork.StatusTypeID))
                Dim strFriendFollowStatus As String =
                        Project.SocialNetworkStatuses.ItemByStatusID(x).Description.ToString

                Dim strLikeUs As String = String.Empty
                Select Case GetSafeValue(objSocialNetwork.LikeUs)
                    Case True
                        strLikeUs = "Yes"
                    Case False
                        strLikeUs = "No"
                End Select

                If blnOK Then
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              GetSafeValue(objSocialNetwork.SocialNetworkID),
                                              GetSafeValue(objSocialNetwork.SourceQuality.Rank),
                                              imgQuality.Images("Quality-Unknown.bmp"),
                                              GetSafeValue(objSocialNetwork.UserName),
                                              GetSafeValue(objSocialNetwork.URL),
                                              GetSafeValue(objSocialNetwork.SocialNetworkType.Description),
                                              strFriendFollowStatus,
                                              strLikeUs,
                                              GetSafeValue(objSocialNetwork.Notes),
                                              GetSafeDate(objSocialNetwork.CreatedOn),
                                              GetSafeValue(objSocialNetwork.Round)}

                    If _
                        mobjPerson.BestSocialNetwork IsNot Nothing AndAlso
                        mobjPerson.BestSocialNetwork.Equals(objSocialNetwork) Then
                        objRow(0) = imgImages.Images("BestBlue.bmp")
                    End If
                    If GetSafeValue(objSocialNetwork.SourceQualityID) = 1 Then
                        objRow(3) = imgQuality.Images("Quality-Bad.bmp")
                    ElseIf GetSafeValue(objSocialNetwork.SourceQualityID) = 2 Then
                        objRow(3) = imgQuality.Images("Quality-Good.bmp")
                    ElseIf GetSafeValue(objSocialNetwork.SourceQualityID) = 3 Then
                        objRow(3) = imgQuality.Images("Quality-Duplicate.bmp")
                    End If
                    If GetSafeValue(objSocialNetwork.SocialNetworkID).Equals(0) Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objSocialNetwork
                End If
            Next
            SelectedSocialNetwork = objPrevSocialNetwork
            RaiseEvent OnClick(Me, SelectedSocialNetwork)
        End If
        grdView.Columns("SocialNetwork").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        grdView.Sort(grdView.Columns("Rank"), ListSortDirection.Ascending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd And mobjPerson IsNot Nothing
        btnEdit.Enabled = mblnAllowEdit And (SelectedSocialNetwork IsNot Nothing)
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
            If SelectedSocialNetwork IsNot Nothing AndAlso GetSafeValue(SelectedSocialNetwork.SocialNetworkID).Equals(0) _
                Then
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
