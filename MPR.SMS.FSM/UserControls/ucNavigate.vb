Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports System.Windows.Forms

Public Class ucNavigate
    Inherits System.Windows.Forms.UserControl

#Region "Private Variables"

    Private mViewBy As ViewByType = ViewByType.Region
    Private mobjInterviewers As Interviewers
    Private mobjTeams As InterviewerTeams
    Private mobjSupervisors As InterviewerSupervisors
    Private mobjRegions As InterviewerRegions
    Private mobjCurrentSupervisor As InterviewerSupervisor = Nothing
    Private mblnDragAndDropInProgress As Boolean = False
    Private mobjCaseAssignments As CaseAssignments

    Private mfound As TreeNode = Nothing    

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Public Properties"

    Public Enum ViewByType
        Region = 1
        Supervisor
        Team
        Interviewer
    End Enum

    <System.ComponentModel.DefaultValue(1)> <System.ComponentModel.Browsable(False)>
    Public Property ViewBy() As ViewByType
        Get
            Return mViewBy
        End Get
        Set(ByVal value As ViewByType)
            If value > 0 Then
                mViewBy = value
                RefreshView(mViewBy)
            End If
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property CurrentSupervisor() As InterviewerSupervisor
        Get
            Return mobjCurrentSupervisor
        End Get
        Set(ByVal value As InterviewerSupervisor)
            mobjCurrentSupervisor = value
            If mobjCurrentSupervisor IsNot Nothing Then
                mobjInterviewers = New Interviewers(mobjCurrentSupervisor)
                mobjTeams = New InterviewerTeams(mobjCurrentSupervisor)
            End If
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property Interviewers() As Interviewers
        Get
            If Not Me.DesignMode AndAlso mobjInterviewers Is Nothing Then
                If mobjCurrentSupervisor Is Nothing Then
                    mobjInterviewers = New Interviewers()
                Else
                    mobjInterviewers = New Interviewers(mobjCurrentSupervisor)
                End If
            End If
            Return mobjInterviewers
        End Get
        Set(ByVal value As Interviewers)
            mobjInterviewers = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property InterviewerTeams() As InterviewerTeams
        Get
            If Not Me.DesignMode AndAlso mobjTeams Is Nothing Then
                If mobjCurrentSupervisor Is Nothing Then
                    mobjTeams = New InterviewerTeams()
                Else
                    mobjTeams = New InterviewerTeams(mobjCurrentSupervisor)
                End If
            End If
            Return mobjTeams
        End Get
        Set(ByVal value As InterviewerTeams)
            mobjTeams = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property InterviewerSupervisors() As InterviewerSupervisors
        Get
            If Not Me.DesignMode AndAlso mobjSupervisors Is Nothing Then
                mobjSupervisors = New InterviewerSupervisors()
            End If
            Return mobjSupervisors
        End Get
        Set(ByVal value As InterviewerSupervisors)
            mobjSupervisors = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property InterviewerRegions() As InterviewerRegions
        Get
            If Not Me.DesignMode AndAlso mobjRegions Is Nothing Then
                mobjRegions = New InterviewerRegions()
            End If
            Return mobjRegions
        End Get
        Set(ByVal value As InterviewerRegions)
            mobjRegions = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property SelectedNode() As TreeNode
        Get
            Return tvNavigation.SelectedNode
        End Get
        Set(ByVal value As TreeNode)
            'If value IsNot Nothing AndAlso tvNavigation.SelectedNode Is value Then
            '    RefreshSelectedNode()
            'Else
            '    tvNavigation.SelectedNode = value
            'End If
            tvNavigation.SelectedNode = value
            'RefreshSelectedNode()
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property SelectedItem() As Object
        Get
            If tvNavigation.SelectedNode IsNot Nothing Then
                Return tvNavigation.SelectedNode.Tag
            Else
                Return Nothing
            End If
        End Get
    End Property

    <System.ComponentModel.Browsable(False)>
    Public Property CaseAssignments() As CaseAssignments
        Get
            Return mobjCaseAssignments
        End Get
        Set(ByVal value As CaseAssignments)
            mobjCaseAssignments = value
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        If Me.DesignMode Then Exit Sub

        'Me.Refresh()

        Interviewers = Nothing
        InterviewerTeams = Nothing
        InterviewerSupervisors = Nothing
        InterviewerRegions = Nothing
        RefreshView(mViewBy)
    End Sub

    Public Sub UpdateNode(ByRef tn As TreeNode, ByVal obj As Object)
        ' for updating tree nodes after case assignment is changed
        tn.Tag = obj

        Select Case  tn.Tag.GetType
            Case GetType(Interviewer)
                Dim interviewer as Interviewer = Ctype(obj, Interviewer)        
                tn.Text = interviewer.NodeText
            Case GetType(InterviewerRegion)
                Dim reg as InterviewerRegion = Ctype(obj, InterviewerRegion)
                tn.Text = reg.NodeText
            Case GetType(InterviewerSupervisor)
                Dim sup as InterviewerSupervisor = Ctype(obj, InterviewerSupervisor)
                tn.Text = sup.NodeText
            Case GetType(InterviewerTeam)
                Dim team as InterviewerTeam = Ctype(obj, InterviewerTeam)
                tn.Text = team.NodeText
        End Select

    End Sub

    Public Function FindNode(ByVal key As String) As TreeNode
        ' find a tree node that contains the key
        mfound = Nothing        
        For Each tn As TreeNode In Me.tvNavigation.Nodes
            If tn.Text.Contains(key) then
                mfound = tn
                Exit For
            Else 
                RecursiveSearch(tn, key)
            End If
        Next

        Return mfound
    End Function

#End Region

#Region "Private Methods"

    Private Sub RefreshView(ByVal ViewBy As ViewByType)

        If Me.DesignMode Then Exit Sub

        Cursor = Cursors.WaitCursor
        Select Case ViewBy
            Case ViewByType.Region
                FillRegionsList()
            Case ViewByType.Supervisor
                FillSupervisorsList()
            Case ViewByType.Team
                FillTeamsList()
            Case ViewByType.Interviewer
                FillInterviewersList()
        End Select
        'If tvNavigation.SelectedNode Is Nothing AndAlso tvNavigation.Nodes.Count > 0 Then
        '    tvNavigation.SelectedNode = tvNavigation.Nodes(0)
        'End If
        tvNavigation.SelectedNode = Nothing

        Cursor = Cursors.Default

        RaiseEvent OnRefreshList(Me)
    End Sub

    Private Sub FillRegionsList()

        MyCaption.Caption = "Regions"

        tvNavigation.Nodes.Clear()

        Dim tnReg As TreeNode = Nothing

        'fill all Regions
        FillRegions(Nothing, InterviewerRegions)

        'fill all Supervisors with no Region
        For Each objSup As InterviewerSupervisor In InterviewerSupervisors
            If objSup.InterviewerRegionID.IsNull Then
                tnReg = AddTreeNode(tvNavigation, "<no region>", Nothing, ViewByType.Region)
                SetNodeSpecial(tnReg, True)
                FillSupervisors(tnReg, InterviewerSupervisors)
                Exit For
            End If
        Next

        'fill teams with no region and no supervisor
        For Each objTeam As InterviewerTeam In InterviewerTeams
            If objTeam.SupervisorID.IsNull Then
                tnReg = AddTreeNode(tvNavigation, "<no supervisor>", Nothing, ViewByType.Team)
                SetNodeSpecial(tnReg, True)
                FillTeams(tnReg, InterviewerTeams)
                Exit For
            End If
        Next

        'fill interviewers with no team and no supervisor and no region
        For Each objInt As Interviewer In Interviewers
            If objInt.InterviewerSupervisorID.IsNull AndAlso
               objInt.TeamID.IsNull Then
                tnReg = AddTreeNode(tvNavigation, "<no team / supervisor>", Nothing, ViewByType.Interviewer)
                SetNodeSpecial(tnReg, True)
                FillInterviewers(tnReg, Interviewers)
                Exit For
            End If
        Next

        tvNavigation.ExpandAll()
    End Sub

    Private Sub FillSupervisorsList()

        MyCaption.Caption = "Supervisors"

        tvNavigation.Nodes.Clear()

        Dim tnSup As TreeNode = Nothing
        Dim tnTeam As TreeNode = Nothing

        'fill all Supervisors
        FillSupervisors(Nothing, InterviewerSupervisors)

        'fill all teams with no Supervisors
        For Each objTeam As InterviewerTeam In InterviewerTeams
            If objTeam.SupervisorID.IsNull Then
                tnSup = AddTreeNode(tvNavigation, "<no supervisor>", Nothing, ViewByType.Supervisor)
                SetNodeSpecial(tnSup, True)
                FillTeams(tnSup, InterviewerTeams)
                Exit For
            End If
        Next

        'fill all Interviewers with no Supervisor and no Team
        For Each objInt As Interviewer In Interviewers
            If objInt.InterviewerSupervisorID.IsNull AndAlso
               objInt.TeamID.IsNull Then
                tnTeam = AddTreeNode(tvNavigation, "<no team / supervisor>", Nothing, ViewByType.Team)
                SetNodeSpecial(tnTeam, True)
                FillInterviewers(tnTeam, Interviewers)
                Exit For
            End If
        Next

        tvNavigation.ExpandAll()
    End Sub

    Private Sub FillTeamsList()

        MyCaption.Caption = "Interviewer Teams"

        tvNavigation.Nodes.Clear()

        'fill all teams
        FillTeams(Nothing, InterviewerTeams)

        'fill all interviewers with no team
        For Each objInt As Interviewer In Interviewers
            If objInt.TeamID.IsNull Then
                Dim tnTeam As TreeNode = AddTreeNode(tvNavigation, "<no team>", Nothing, ViewByType.Team)
                SetNodeSpecial(tnTeam, True)
                FillInterviewers(tnTeam, Interviewers)
                Exit For
            End If
        Next

        tvNavigation.ExpandAll()
    End Sub

    Private Sub FillInterviewersList()

        MyCaption.Caption = "Interviewers"

        tvNavigation.Nodes.Clear()

        FillInterviewers(Nothing, Interviewers)

        tvNavigation.ExpandAll()
    End Sub

    Private Sub FillInterviewers(ByVal tnParent As TreeNode, ByVal objInterviewers As Interviewers)

        Dim tnInt As TreeNode = Nothing

        Cursor = Cursors.WaitCursor

        For Each objInt As Interviewer In objInterviewers

            If tnParent Is Nothing Then 'root
                tnInt = AddTreeNode(tvNavigation, objInt.NodeText, objInt, ViewByType.Interviewer)
            Else
                Select Case tnParent.Text
                    Case "<no team>"
                        If objInt.TeamID.IsNull Then
                            tnInt = AddTreeNode(tnParent, objInt.NodeText, objInt, ViewByType.Interviewer)
                        End If
                    Case "<no supervisor>"
                        If objInt.InterviewerSupervisorID.IsNull Then
                            tnInt = AddTreeNode(tnParent, objInt.NodeText, objInt, ViewByType.Interviewer)
                        End If
                    Case "<no team / supervisor>"
                        If objInt.InterviewerSupervisorID.IsNull And
                           objInt.TeamID.IsNull Then
                            tnInt = AddTreeNode(tnParent, objInt.NodeText, objInt, ViewByType.Interviewer)
                        End If
                    Case Else
                        tnInt = AddTreeNode(tnParent, objInt.NodeText, objInt, ViewByType.Interviewer)
                End Select
                'if the interviewer is not active, make it italicized
                If Not objInt.IsActive AndAlso tnInt IsNot Nothing Then SetNodeSpecial(tnInt, False)
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub FillTeams(ByVal tnParent As TreeNode, ByVal objTeams As InterviewerTeams)

        Dim tnTeam As TreeNode = Nothing

        For Each objTeam As InterviewerTeam In objTeams

            If Project.ProjectUsesInterviewTeams OrElse objTeam.Interviewers.Count > 0 Then
                If tnParent Is Nothing Then 'Root
                    tnTeam = AddTreeNode(tvNavigation, objTeam.NodeText, objTeam, ViewByType.Team)
                    FillInterviewers(tnTeam, objTeam.Interviewers)
                Else
                    Select Case tnParent.Text
                        Case "<no supervisor>"
                            If objTeam.SupervisorID.IsNull Then
                                tnTeam = AddTreeNode(tnParent, objTeam.NodeText, objTeam, ViewByType.Team)
                                FillInterviewers(tnTeam, objTeam.Interviewers)
                            End If
                        Case Else
                            tnTeam = AddTreeNode(tnParent, objTeam.NodeText, objTeam, ViewByType.Team)
                            FillInterviewers(tnTeam, objTeam.Interviewers)
                    End Select
                End If
                'if the interviewer is not active, make it italicized
                If Not objTeam.IsActive AndAlso tnTeam IsNot Nothing Then SetNodeSpecial(tnTeam, False)
            End If
        Next
    End Sub

    Private Sub FillSupervisors(ByVal tnParent As TreeNode, ByVal objSupervisors As InterviewerSupervisors)

        Dim tnSup As TreeNode

        For Each objSup As InterviewerSupervisor In objSupervisors

            tnSup = Nothing
            If tnParent Is Nothing Then 'Root
                tnSup = AddTreeNode(tvNavigation, objSup.NodeText, objSup, ViewByType.Supervisor)
                'FillTeams(tnSup, objSup.InterviewerTeams)      'BT: 03/15/2021 Commented line based on MIHOPE_Checkin due to Performance Issue.
            Else
                Select Case tnParent.Text
                    Case "<no region>"
                        If objSup.InterviewerRegionID.IsNull Then
                            tnSup = AddTreeNode(tnParent, objSup.NodeText, objSup, ViewByType.Supervisor)
                            FillTeams(tnSup, objSup.InterviewerTeams)
                        End If
                    Case Else
                        tnSup = AddTreeNode(tnParent, objSup.NodeText, objSup, ViewByType.Supervisor)
                        FillTeams(tnSup, objSup.InterviewerTeams)
                End Select
            End If

            'fill Interviewers for this Supervisor, with no Teams
            If tnSup IsNot Nothing Then
                For Each objInt As Interviewer In objSup.Interviewers
                    If objInt.TeamID.IsNull Then
                        If Project.ProjectUsesInterviewTeams Then
                            Dim tnTeam As TreeNode = AddTreeNode(tnSup, "<no team>", Nothing, ViewByType.Team)
                            SetNodeSpecial(tnTeam, True)
                            FillInterviewers(tnTeam, objSup.Interviewers)
                        Else
                            FillInterviewers(tnSup, objSup.Interviewers)
                        End If
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub FillRegions(ByVal tnParent As TreeNode, ByVal objRegions As InterviewerRegions)

        Dim tnReg As TreeNode = Nothing

        'fill all Regions
        For Each objReg As InterviewerRegion In objRegions

            tnReg = AddTreeNode(tvNavigation, objReg.NodeText, objReg, ViewByType.Region)
            FillSupervisors(tnReg, objReg.InterviewerSupervisors)

            'fill Team for this Region, with no Supervisor
            For Each objTeam As InterviewerTeam In objReg.InterviewerTeams
                If objTeam.SupervisorID.IsNull AndAlso
                   Not objTeam.TeamID.IsNull Then
                    Dim tnSup As TreeNode = AddTreeNode(tnReg, "<no supervisor>", Nothing, ViewByType.Supervisor)
                    SetNodeSpecial(tnSup, True)
                    FillTeams(tnSup, objReg.InterviewerTeams)
                    Exit For
                End If
            Next

            'fill interviewers with no team and no supervisor
            For Each objInt As Interviewer In objReg.Interviewers
                If objInt.InterviewerSupervisorID.IsNull AndAlso
                   objInt.TeamID.IsNull Then
                    Dim tnSup As TreeNode = AddTreeNode(tnReg, "<no team / supervisor>", Nothing, ViewByType.Interviewer)
                    SetNodeSpecial(tnSup, True)
                    FillInterviewers(tnSup, Interviewers)
                    Exit For
                End If
            Next

        Next
    End Sub

    Private Function AddTreeNode(ByVal tnParent As TreeNode, ByVal strText As String, ByVal obj As Object,
                                 ByVal ImageType As ViewByType) As TreeNode

        Dim tn As TreeNode
        tn = tnParent.Nodes.Add(strText)
        tn = SetupNode(tn, obj, ImageType)

        Return tn
    End Function

    Private Function AddTreeNode(ByVal tvParent As TreeView, ByVal strText As String, ByVal obj As Object,
                                 ByVal ImageType As ViewByType) As TreeNode

        Dim tn As TreeNode
        tn = tvParent.Nodes.Add(strText)
        tn = SetupNode(tn, obj, ImageType)

        Return tn
    End Function

    Private Function SetupNode(ByVal tn As TreeNode, ByVal obj As Object, ByVal ImageType As ViewByType) As TreeNode

        tn.Tag = obj
        tn.ImageIndex = GetImageIndex(ImageType)
        tn.SelectedImageIndex = 2
        Select Case ImageType
            Case ViewByType.Interviewer
                tn.ToolTipText = "Interviewer: " & tn.Text
                tn.SelectedImageIndex = GetImageIndex(ViewByType.Interviewer)
            Case ViewByType.Region
                tn.ToolTipText = "Region: " & tn.Text
            Case ViewByType.Supervisor
                tn.ToolTipText = "Supervisor: " & tn.Text
            Case ViewByType.Team
                tn.ToolTipText = "Team: " & tn.Text
        End Select

        Return tn
    End Function

    'This sets a node to Italic and with the optional "None" symbol
    Private Sub SetNodeSpecial(ByVal Node As TreeNode, ByVal blnNone As Boolean)

        Dim fnt As Drawing.Font = Control.DefaultFont
        fnt = New Drawing.Font(fnt, Drawing.FontStyle.Italic)
        Node.NodeFont = fnt
        If blnNone Then Node.ImageIndex = 7
    End Sub

    Private Function GetImageIndex(ByVal NodeType As ViewByType) As Integer

        Select Case NodeType
            Case ViewByType.Supervisor
                Return 5
            Case ViewByType.Region
                Return 6
            Case ViewByType.Team
                Return 3
            Case ViewByType.Interviewer
                Return 4
            Case Else
                Return 0
        End Select
    End Function

    Private Sub DoDragStaff(ByVal objDrag As Object, ByVal objTarget As Object)

        If objDrag.GetType Is GetType(Interviewer) Then
            Dim objInt As Interviewer = CType(objDrag, Interviewer)

            If objTarget.GetType Is GetType(InterviewerTeam) Then
                objInt.TeamID = CType(objTarget, InterviewerTeam).TeamID
                objInt.InterviewerSupervisorID = New SqlTypes.SqlInt32
            ElseIf objTarget.GetType Is GetType(InterviewerSupervisor) Then
                objInt.InterviewerSupervisorID = CType(objTarget, InterviewerSupervisor).InterviewerSupervisorID
                objInt.TeamID = New SqlTypes.SqlInt32
            End If

            objInt.Update()

        ElseIf objDrag.GetType Is GetType(InterviewerTeam) Then
            Dim objTeam As InterviewerTeam = CType(objDrag, InterviewerTeam)

            If objTarget.GetType Is GetType(InterviewerSupervisor) Then
                objTeam.SupervisorID = CType(objTarget, InterviewerSupervisor).InterviewerSupervisorID
            End If

            objTeam.Update()

        ElseIf objDrag.GetType Is GetType(InterviewerSupervisor) Then
            Dim objSup As InterviewerSupervisor = CType(objDrag, InterviewerSupervisor)

            If objTarget.GetType Is GetType(InterviewerRegion) Then
                objSup.InterviewerRegionID = CType(objTarget, InterviewerRegion).InterviewerRegionID
            End If

            objSup.Update()

        End If
    End Sub

    Private Sub DoDragAssignment(ByVal objAssignments As CaseAssignments, ByVal objTarget As Object)

        Dim blnAdmin As Boolean = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

        Dim frm As frmAssignCase
        frm = New frmAssignCase(objAssignments, blnAdmin, objTarget)
        frm.ShowDialog()

        frm.Dispose()
    End Sub

    Private Sub RefreshSelectedNode()

        If mblnDragAndDropInProgress Then Return

        ctxTrackInterviewer.Visible = False
        ctxUpdateInterviewer.Visible = False
        ctxUpdateTeam.Visible = False
        ctxUpdateSupervisor.Visible = False
        ctxUpdateRegion.Visible = False

        Dim obj As Object = SelectedItem
        If obj IsNot Nothing Then
            If obj.GetType Is GetType(Interviewer) Then
                ctxUpdateInterviewer.Visible = True
                ctxTrackInterviewer.Visible = True
               
            ElseIf obj.GetType Is GetType(InterviewerTeam) Then
                ctxUpdateTeam.Visible = True
              
                If SelectedNode.GetNodeCount (false) = 0 then
                    Dim rg As InterviewerTeam = CType(SelectedNode.Tag, InterviewerTeam)
                    FillInterviewers(SelectedNode, rg.Interviewers)
                end If
            ElseIf obj.GetType Is GetType(InterviewerSupervisor) Then
                ctxUpdateSupervisor.Visible = True
                
                If SelectedNode.GetNodeCount (false) = 0 then
                    Dim rg As InterviewerSupervisor = CType(SelectedNode.Tag, InterviewerSupervisor)
                    FillTeams(SelectedNode, rg.InterviewerTeams)
                end if 
            ElseIf obj.GetType Is GetType(InterviewerRegion) Then
                ctxUpdateRegion.Visible = True
               
                If SelectedNode.GetNodeCount (false) = 0 then                    
                    Dim rg As InterviewerRegion = CType(obj, InterviewerRegion)
                    FillSupervisors(SelectedNode,rg.InterviewerSupervisors)
                end if
              
            End If
        End If
        ctxMenuSeparator.Visible = (obj IsNot Nothing)

        RaiseEvent SelectionChanged(Me, obj)

    End Sub
    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal key As String)

        ' Keep calling recursively.
        For Each tn As TreeNode In treeNode.Nodes
            If tn.Text.Contains(key) Then
                mfound = tn
                Exit For
            End If

            RecursiveSearch(tn, key)
        Next
    End Sub

#End Region

#Region "Events"

    Public Event SelectionChanged(ByVal sender As Object, ByVal obj As Object)

    Public Event UpdateRegion(ByVal sender As Object, ByVal objRegion As InterviewerRegion)
    Public Event UpdateSupervisor(ByVal sender As Object, ByVal objSupervisor As InterviewerSupervisor)
    Public Event UpdateTeam(ByVal sender As Object, ByVal objTeam As InterviewerTeam)
    Public Event UpdateInterviewer(ByVal sender As Object, ByVal objInterviewer As Interviewer)
    Public Event OnRefreshList(ByVal sender As Object)
    Public Event OnTrackInterviewer(ByVal sender As Object, ByVal objInterviewer As Interviewer)

#End Region

#Region "Event Handlers"

    Private Sub ctxRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxRefresh.Click

        Refresh()
    End Sub

    Private Sub tvNavigation_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles tvNavigation.AfterSelect

        RefreshSelectedNode()
    End Sub

    Private Sub ctxNewRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxNewRegion.Click

        RaiseEvent UpdateRegion(Me, New InterviewerRegion)
    End Sub

    Private Sub ctxNewSupervisor_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxNewSupervisor.Click

        RaiseEvent UpdateSupervisor(Me, New InterviewerSupervisor)
    End Sub

    Private Sub ctxNewTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxNewTeam.Click

        RaiseEvent UpdateTeam(Me, New InterviewerTeam)
    End Sub

    Private Sub ctxNewInterviewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxNewInterviewer.Click

        RaiseEvent UpdateInterviewer(Me, New Interviewer)
    End Sub

    Private Sub ctxUpdateRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxUpdateRegion.Click

        If SelectedItem.GetType.Name = "InterviewerRegion" Then
            RaiseEvent UpdateRegion(Me, CType(SelectedItem, InterviewerRegion))
        End If
    End Sub

    Private Sub ctxUpdateSupervisor_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxUpdateSupervisor.Click

        If SelectedItem.GetType.Name = "InterviewerSupervisor" Then
            RaiseEvent UpdateSupervisor(Me, CType(SelectedItem, InterviewerSupervisor))
        End If
    End Sub

    Private Sub ctxUpdateTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxUpdateTeam.Click

        If SelectedItem.GetType.Name = "InterviewerTeam" Then
            RaiseEvent UpdateTeam(Me, CType(SelectedItem, InterviewerTeam))
        End If
    End Sub

    Private Sub ctxUpdateInterviewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ctxUpdateInterviewer.Click

        If SelectedItem.GetType.Name = "Interviewer" Then
            RaiseEvent UpdateInterviewer(Me, CType(SelectedItem, Interviewer))
        End If
    End Sub

    Private Sub ctxTrackInterviewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ctxTrackInterviewer.Click

        If SelectedItem.GetType.Name = "Interviewer" Then
            RaiseEvent OnTrackInterviewer(Me, CType(SelectedItem, Interviewer))
        End If
    End Sub

    'Perform the Drop
    Private Sub tvNavigation_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles tvNavigation.DragDrop

       
        'Get the TreeView raising the event (incase multiple on form)
        Dim targetTreeView As TreeView = CType(sender, TreeView)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = targetTreeView.SelectedNode

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = True Then

            'Get the TreeNode being dragged
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            DoDragStaff(dropNode.Tag, targetNode.Tag)

            dropNode.Remove()
            targetNode.Nodes.Add(dropNode)
            dropNode.EnsureVisible()



            targetTreeView.SelectedNode = dropNode

            'Check that there is a ListViewItem being dragged
        ElseIf e.Data.GetDataPresent("System.Windows.Forms.ListViewItem", True) = True Then
            'Get the TreeNode being dragged
            Dim dropNode As ListViewItem = CType(e.Data.GetData("System.Windows.Forms.ListViewItem"), ListViewItem)

            DoDragAssignment(CaseAssignments, targetNode.Tag)

           
            If Project.ShowInterviewerCaseCount Then
                'need to refresh interviewer's case count, if interviewer case counts are showing
                If targetNode.Tag.GetType Is GetType(Interviewer) 
                    Dim targetInterviewer as Interviewer = CType( targetNode.Tag, Interviewer)
                    targetInterviewer.RefreshAssignment(CaseAssignments.CaseAssignmentType.ViewActive)
                    UpdateNode(targetNode, targetInterviewer)
                End If

                Dim origInterviewer as Interviewer = CaseAssignments.Item(0).Interviewer
                If origInterviewer IsNot Nothing then 
                    Dim origNode as TreeNode = FindNode(((origInterviewer.FirstName + " " + origInterviewer.LastName).ToString()))
                    If origNode IsNot Nothing andalso origNode.Tag.GetType Is GetType(Interviewer) Then
                        origInterviewer.RefreshAssignment(CaseAssignments.CaseAssignmentType.ViewActive)
                        UpdateNode(origNode, origInterviewer)
                    End If
                End If    
            End If
        
            targetTreeView.SelectedNode = targetNode
            RaiseEvent SelectionChanged(Me, targetNode.Tag)

        End If
        mblnDragAndDropInProgress = False
    End Sub

    Private Sub tvNavigation_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles tvNavigation.DragEnter

        'See if there is a TreeNode or ListViewItem being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found, allow move effect
            e.Effect = DragDropEffects.Move
        ElseIf e.Data.GetDataPresent("System.Windows.Forms.ListViewItem", True) Then
            'ListViewItem found, allow move effect
            If Project.CaseAssignmentsAllowCopy Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            'No applicable item found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub

    'ensure that the item being dragged is valid to be dragged onto the target
    Private Sub tvNavigation_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles tvNavigation.DragOver

        mblnDragAndDropInProgress = True

        'Get the TreeView raising the event (in case multiple on form)
        Dim targetTreeView As TreeView = CType(sender, TreeView)

        'As the mouse moves over nodes, provide feedback to 
        'the user by highlighting the node that is the 
        'current drop target
        Dim pt As Drawing.Point = CType(sender, TreeView).PointToClient(New Drawing.Point(e.X, e.Y))
        Dim targetNode As TreeNode = targetTreeView.GetNodeAt(pt)


        'Check that there is a TreeNode being dragged 
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = True Then


            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            'don't allow dragging a node to itself or it's direct parent, or an inactive node.
            If Not targetNode Is dropNode.Parent Then
                'only allow valid drops: 
                'Interviewers to Teams/Supervisors
                'Teams to Supervisors
                'Supervisors to Regions
                If dropNode.Tag.GetType Is GetType(Interviewer) Then
                    If targetNode.Tag.GetType Is GetType(InterviewerTeam) Or
                       targetNode.Tag.GetType Is GetType(InterviewerSupervisor) Then
                        e.Effect = DragDropEffects.Move
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                ElseIf dropNode.Tag.GetType Is GetType(InterviewerTeam) Then
                    If targetNode.Tag.GetType Is GetType(InterviewerSupervisor) Then
                        e.Effect = DragDropEffects.Move
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                ElseIf dropNode.Tag.GetType Is GetType(InterviewerSupervisor) Then
                    If targetNode.Tag.GetType Is GetType(InterviewerRegion) Then
                        e.Effect = DragDropEffects.Move
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                Else
                    e.Effect = DragDropEffects.None
                End If
            Else
                e.Effect = DragDropEffects.None
            End If

            'Check that there is a ListViewItem being dragged 
        ElseIf e.Data.GetDataPresent("System.Windows.Forms.ListViewItem", True) = True Then

            Dim dropNode As ListViewItem = CType(e.Data.GetData("System.Windows.Forms.ListViewItem"), ListViewItem)
            Dim objAssignment As CaseAssignment = CType(dropNode.Tag, CaseAssignment)

            Dim effect As DragDropEffects = DragDropEffects.Move
            If Project.CaseAssignmentsAllowCopy Then effect = DragDropEffects.Copy

            'only allow valid drops: 
            'Cases to Interviewr/Team/Supervisor/Region and
            'not the same as the current assignment
            e.Effect = effect
            If targetNode.Tag.GetType Is GetType(Interviewer) Then
                If CType(targetNode.Tag, Interviewer).InterviewerID = objAssignment.InterviewerID Then
                    e.Effect = DragDropEffects.None
                End If
            ElseIf targetNode.Tag.GetType Is GetType(InterviewerTeam) Then
                If CType(targetNode.Tag, InterviewerTeam).TeamID = objAssignment.InterviewerTeamID Then
                    e.Effect = DragDropEffects.None
                End If
            ElseIf targetNode.Tag.GetType Is GetType(InterviewerSupervisor) Then
                If _
                    CType(targetNode.Tag, InterviewerSupervisor).InterviewerSupervisorID =
                    objAssignment.InterviewerSupervisorID Then
                    e.Effect = DragDropEffects.None
                End If
            ElseIf targetNode.Tag.GetType Is GetType(InterviewerRegion) Then
                If CType(targetNode.Tag, InterviewerRegion).InterviewerRegionID = objAssignment.InterviewerRegionID Then
                    e.Effect = DragDropEffects.None
                End If
            Else
                e.Effect = DragDropEffects.None
            End If

        End If

        'don't allow dropping onto Inactive Interviewers or Teams
        If targetNode.Tag.GetType Is GetType(Interviewer) Then
            If Not CType(targetNode.Tag, Interviewer).IsActive Then
                e.Effect = DragDropEffects.None
            End If
        ElseIf targetNode.Tag.GetType Is GetType(InterviewerTeam) Then
            If Not CType(targetNode.Tag, InterviewerTeam).IsActive Then
                e.Effect = DragDropEffects.None
            End If
        End If

        If e.Effect <> DragDropEffects.None Then
            'Select the node currently under the cursor
            targetTreeView.SelectedNode = targetNode
        End If
    End Sub

    Private Sub tvNavigation_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) _
        Handles tvNavigation.ItemDrag

        mblnDragAndDropInProgress = True
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvNavigation_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles tvNavigation.MouseUp

        mblnDragAndDropInProgress = False
    End Sub

    Private Sub tvNavigation_NodeMouseClick(ByVal sender As Object,
                                            ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) _
        Handles tvNavigation.NodeMouseClick

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            tvNavigation.SelectedNode = e.Node
        End If
        RefreshSelectedNode()
    End Sub

    Private Sub Navigate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.DesignMode Then Exit Sub

        tvNavigation.AllowDrop = CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)

        Dim blnAccess As Boolean = CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)
        Dim blnAdmin As Boolean = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)


        ctxNewInterviewer.Enabled = blnAccess
        ctxNewTeam.Enabled = blnAccess
        ctxNewSupervisor.Enabled = blnAccess And blnAdmin
        ctxNewRegion.Enabled = blnAccess And blnAdmin
        ctxUpdateInterviewer.Enabled = blnAccess
        ctxUpdateTeam.Enabled = blnAccess
        ctxUpdateSupervisor.Enabled = blnAccess
        ctxUpdateRegion.Enabled = blnAccess
        ctxNewTeam.Visible = Project.ProjectUsesInterviewTeams
        ctxUpdateTeam.Visible = Project.ProjectUsesInterviewTeams
    End Sub

#End Region
End Class


