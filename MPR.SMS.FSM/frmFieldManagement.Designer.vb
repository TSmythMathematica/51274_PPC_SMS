<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFieldManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFieldManagement))
        Me.MainMenu = New System.Windows.Forms.MenuStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.FileOpenCase = New System.Windows.Forms.ToolStripMenuItem
        Me.FileMenuSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.FilePrintCase = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.FileMenuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.EditCaseProperties = New System.Windows.Forms.ToolStripMenuItem
        Me.EditAssignCases = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInterviewWeeks = New System.Windows.Forms.ToolStripMenuItem
        Me.EditAssignCasesSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.mnuNewRegion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNewSupervisor = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNewTeam = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNewInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSep = New System.Windows.Forms.ToolStripSeparator
        Me.mnuUpdateRegion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateSupervisor = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateTeam = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTrackInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.TreeView = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchView = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ViewStaffBy = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewByRegions = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewBySupervisors = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewByTeams = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewByInterviewers = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAssignmentsByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesAssigned = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesUnassigned = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesActive = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesCompleted = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuViewCasesValidation = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocuments = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocumentsReports = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocsSep = New System.Windows.Forms.ToolStripSeparator
        Me.mnuDocumentsRelease = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocumentsTeam = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocumentsSupplies = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDocumentsValidations = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsUserInformation = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsChangePassword = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.MyToolBar = New System.Windows.Forms.ToolStrip
        Me.tbSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.tbTreeView = New System.Windows.Forms.ToolStripButton
        Me.tbSearch = New System.Windows.Forms.ToolStripButton
        Me.tbRefresh = New System.Windows.Forms.ToolStripButton
        Me.MyStatusBar = New System.Windows.Forms.StatusStrip
        Me.StaffCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.CaseCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusBarCurrentUserPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.ucSearch = New MPR.SMS.FieldManagement.ucCaseAssignmentSearch
        Me.ucNavigate = New MPR.SMS.FieldManagement.ucNavigate
        Me.ucCaseAssignments = New MPR.SMS.FieldManagement.ucCaseAssignments
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.mnuSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.MainMenu.SuspendLayout()
        Me.MyToolBar.SuspendLayout()
        Me.MyStatusBar.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.mnuDocuments, Me.OptionsMenu, Me.HelpMenu})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(690, 24)
        Me.MainMenu.TabIndex = 1
        Me.MainMenu.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileOpenCase, Me.FileMenuSeparator, Me.FilePrintCase, Me.ToolStripSeparator1, Me.FileMenuExit})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(35, 20)
        Me.FileMenu.Text = "&File"
        '
        'FileOpenCase
        '
        Me.FileOpenCase.Enabled = False
        Me.FileOpenCase.Image = CType(resources.GetObject("FileOpenCase.Image"), System.Drawing.Image)
        Me.FileOpenCase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileOpenCase.Name = "FileOpenCase"
        Me.FileOpenCase.Size = New System.Drawing.Size(152, 22)
        Me.FileOpenCase.Text = "&Open Case..."
        '
        'FileMenuSeparator
        '
        Me.FileMenuSeparator.Name = "FileMenuSeparator"
        Me.FileMenuSeparator.Size = New System.Drawing.Size(149, 6)
        '
        'FilePrintCase
        '
        Me.FilePrintCase.Image = CType(resources.GetObject("FilePrintCase.Image"), System.Drawing.Image)
        Me.FilePrintCase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FilePrintCase.Name = "FilePrintCase"
        Me.FilePrintCase.Size = New System.Drawing.Size(152, 22)
        Me.FilePrintCase.Text = "&Print..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'FileMenuExit
        '
        Me.FileMenuExit.Name = "FileMenuExit"
        Me.FileMenuExit.Size = New System.Drawing.Size(152, 22)
        Me.FileMenuExit.Text = "E&xit"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCaseProperties, Me.EditAssignCases, Me.EditAssignCasesSeparator, Me.mnuNewRegion, Me.mnuNewSupervisor, Me.mnuNewTeam, Me.mnuNewInterviewer, Me.mnuSep, Me.mnuUpdateRegion, Me.mnuUpdateSupervisor, Me.mnuUpdateTeam, Me.mnuUpdateInterviewer, Me.mnuTrackInterviewer, Me.mnuSep2, Me.mnuInterviewWeeks})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(37, 20)
        Me.EditMenu.Text = "&Edit"
        '
        'EditCaseProperties
        '
        Me.EditCaseProperties.Name = "EditCaseProperties"
        Me.EditCaseProperties.Size = New System.Drawing.Size(191, 22)
        Me.EditCaseProperties.Text = "Case &Properties..."
        '
        'EditAssignCases
        '
        Me.EditAssignCases.Name = "EditAssignCases"
        Me.EditAssignCases.Size = New System.Drawing.Size(191, 22)
        Me.EditAssignCases.Text = "&Assign Case(s)"
        '
        'mnuInterviewWeeks
        '
        Me.mnuInterviewWeeks.Name = "mnuInterviewWeeks"
        Me.mnuInterviewWeeks.Size = New System.Drawing.Size(191, 22)
        Me.mnuInterviewWeeks.Text = "Interview &Weeks..."
        '
        'EditAssignCasesSeparator
        '
        Me.EditAssignCasesSeparator.Name = "EditAssignCasesSeparator"
        Me.EditAssignCasesSeparator.Size = New System.Drawing.Size(188, 6)
        '
        'mnuNewRegion
        '
        Me.mnuNewRegion.Name = "mnuNewRegion"
        Me.mnuNewRegion.Size = New System.Drawing.Size(191, 22)
        Me.mnuNewRegion.Text = "New &Region..."
        '
        'mnuNewSupervisor
        '
        Me.mnuNewSupervisor.Name = "mnuNewSupervisor"
        Me.mnuNewSupervisor.Size = New System.Drawing.Size(191, 22)
        Me.mnuNewSupervisor.Text = "New &Supervisor..."
        '
        'mnuNewTeam
        '
        Me.mnuNewTeam.Name = "mnuNewTeam"
        Me.mnuNewTeam.Size = New System.Drawing.Size(191, 22)
        Me.mnuNewTeam.Text = "New &Team..."
        '
        'mnuNewInterviewer
        '
        Me.mnuNewInterviewer.Name = "mnuNewInterviewer"
        Me.mnuNewInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.mnuNewInterviewer.Text = "New &Interviewer..."
        '
        'mnuSep
        '
        Me.mnuSep.Name = "mnuSep"
        Me.mnuSep.Size = New System.Drawing.Size(188, 6)
        Me.mnuSep.Visible = False
        '
        'mnuUpdateRegion
        '
        Me.mnuUpdateRegion.Name = "mnuUpdateRegion"
        Me.mnuUpdateRegion.Size = New System.Drawing.Size(191, 22)
        Me.mnuUpdateRegion.Text = "&Update Region..."
        Me.mnuUpdateRegion.Visible = False
        '
        'mnuUpdateSupervisor
        '
        Me.mnuUpdateSupervisor.Name = "mnuUpdateSupervisor"
        Me.mnuUpdateSupervisor.Size = New System.Drawing.Size(191, 22)
        Me.mnuUpdateSupervisor.Text = "&Update Supervisor..."
        Me.mnuUpdateSupervisor.Visible = False
        '
        'mnuUpdateTeam
        '
        Me.mnuUpdateTeam.Name = "mnuUpdateTeam"
        Me.mnuUpdateTeam.Size = New System.Drawing.Size(191, 22)
        Me.mnuUpdateTeam.Text = "&Update Team..."
        Me.mnuUpdateTeam.Visible = False
        '
        'mnuUpdateInterviewer
        '
        Me.mnuUpdateInterviewer.Name = "mnuUpdateInterviewer"
        Me.mnuUpdateInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.mnuUpdateInterviewer.Text = "&Update Interviewer..."
        Me.mnuUpdateInterviewer.Visible = False
        '
        'mnuTrackInterviewer
        '
        Me.mnuTrackInterviewer.Name = "mnuTrackInterviewer"
        Me.mnuTrackInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.mnuTrackInterviewer.Text = "Trac&k Interviewer..."
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewRefresh, Me.ToolStripSeparator7, Me.TreeView, Me.SearchView, Me.ToolStripSeparator2, Me.ViewStaffBy, Me.ViewAssignmentsByToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(41, 20)
        Me.ViewMenu.Text = "&View"
        '
        'ViewRefresh
        '
        Me.ViewRefresh.Image = CType(resources.GetObject("ViewRefresh.Image"), System.Drawing.Image)
        Me.ViewRefresh.Name = "ViewRefresh"
        Me.ViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ViewRefresh.Size = New System.Drawing.Size(197, 22)
        Me.ViewRefresh.Text = "&Refresh"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(194, 6)
        '
        'TreeView
        '
        Me.TreeView.Image = CType(resources.GetObject("TreeView.Image"), System.Drawing.Image)
        Me.TreeView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TreeView.Name = "TreeView"
        Me.TreeView.Size = New System.Drawing.Size(197, 22)
        Me.TreeView.Text = "Staff &View"
        '
        'SearchView
        '
        Me.SearchView.Image = CType(resources.GetObject("SearchView.Image"), System.Drawing.Image)
        Me.SearchView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SearchView.Name = "SearchView"
        Me.SearchView.Size = New System.Drawing.Size(197, 22)
        Me.SearchView.Text = "&Search View"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'ViewStaffBy
        '
        Me.ViewStaffBy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewByRegions, Me.ViewBySupervisors, Me.ViewByTeams, Me.ViewByInterviewers})
        Me.ViewStaffBy.Name = "ViewStaffBy"
        Me.ViewStaffBy.Size = New System.Drawing.Size(197, 22)
        Me.ViewStaffBy.Text = "View Field Staff by..."
        '
        'ViewByRegions
        '
        Me.ViewByRegions.CheckOnClick = True
        Me.ViewByRegions.Image = CType(resources.GetObject("ViewByRegions.Image"), System.Drawing.Image)
        Me.ViewByRegions.ImageTransparentColor = System.Drawing.Color.White
        Me.ViewByRegions.Name = "ViewByRegions"
        Me.ViewByRegions.Size = New System.Drawing.Size(146, 22)
        Me.ViewByRegions.Text = "Regions"
        '
        'ViewBySupervisors
        '
        Me.ViewBySupervisors.CheckOnClick = True
        Me.ViewBySupervisors.Image = CType(resources.GetObject("ViewBySupervisors.Image"), System.Drawing.Image)
        Me.ViewBySupervisors.ImageTransparentColor = System.Drawing.Color.White
        Me.ViewBySupervisors.Name = "ViewBySupervisors"
        Me.ViewBySupervisors.Size = New System.Drawing.Size(146, 22)
        Me.ViewBySupervisors.Text = "Supervisors"
        '
        'ViewByTeams
        '
        Me.ViewByTeams.CheckOnClick = True
        Me.ViewByTeams.Image = CType(resources.GetObject("ViewByTeams.Image"), System.Drawing.Image)
        Me.ViewByTeams.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ViewByTeams.Name = "ViewByTeams"
        Me.ViewByTeams.Size = New System.Drawing.Size(146, 22)
        Me.ViewByTeams.Text = "Teams"
        '
        'ViewByInterviewers
        '
        Me.ViewByInterviewers.CheckOnClick = True
        Me.ViewByInterviewers.Image = CType(resources.GetObject("ViewByInterviewers.Image"), System.Drawing.Image)
        Me.ViewByInterviewers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ViewByInterviewers.Name = "ViewByInterviewers"
        Me.ViewByInterviewers.Size = New System.Drawing.Size(146, 22)
        Me.ViewByInterviewers.Text = "Interviewers"
        '
        'ViewAssignmentsByToolStripMenuItem
        '
        Me.ViewAssignmentsByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewCasesAll, Me.mnuViewCasesAssigned, Me.mnuViewCasesUnassigned, Me.mnuViewCasesActive, Me.mnuViewCasesCompleted, Me.mnuViewCasesValidation})
        Me.ViewAssignmentsByToolStripMenuItem.Name = "ViewAssignmentsByToolStripMenuItem"
        Me.ViewAssignmentsByToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ViewAssignmentsByToolStripMenuItem.Text = "View Assignments by..."
        '
        'mnuViewCasesAll
        '
        Me.mnuViewCasesAll.CheckOnClick = True
        Me.mnuViewCasesAll.Name = "mnuViewCasesAll"
        Me.mnuViewCasesAll.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesAll.Text = "All &Cases"
        '
        'mnuViewCasesAssigned
        '
        Me.mnuViewCasesAssigned.CheckOnClick = True
        Me.mnuViewCasesAssigned.Name = "mnuViewCasesAssigned"
        Me.mnuViewCasesAssigned.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesAssigned.Text = "&Assigned Cases"
        '
        'mnuViewCasesUnassigned
        '
        Me.mnuViewCasesUnassigned.CheckOnClick = True
        Me.mnuViewCasesUnassigned.Name = "mnuViewCasesUnassigned"
        Me.mnuViewCasesUnassigned.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesUnassigned.Text = "&Unassigned Cases"
        '
        'mnuViewCasesActive
        '
        Me.mnuViewCasesActive.CheckOnClick = True
        Me.mnuViewCasesActive.Name = "mnuViewCasesActive"
        Me.mnuViewCasesActive.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesActive.Text = "Acti&ve Cases"
        '
        'mnuViewCasesCompleted
        '
        Me.mnuViewCasesCompleted.CheckOnClick = True
        Me.mnuViewCasesCompleted.Name = "mnuViewCasesCompleted"
        Me.mnuViewCasesCompleted.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesCompleted.Text = "Co&mpleted Cases"
        '
        'mnuViewCasesValidation
        '
        Me.mnuViewCasesValidation.CheckOnClick = True
        Me.mnuViewCasesValidation.Name = "mnuViewCasesValidation"
        Me.mnuViewCasesValidation.Size = New System.Drawing.Size(172, 22)
        Me.mnuViewCasesValidation.Text = "&Validation Cases"
        '
        'mnuDocuments
        '
        Me.mnuDocuments.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDocumentsReports, Me.mnuDocsSep, Me.mnuDocumentsRelease, Me.mnuDocumentsTeam, Me.mnuDocumentsSupplies, Me.mnuDocumentsValidations})
        Me.mnuDocuments.Name = "mnuDocuments"
        Me.mnuDocuments.Size = New System.Drawing.Size(72, 20)
        Me.mnuDocuments.Text = "&Documents"
        '
        'mnuDocumentsReports
        '
        Me.mnuDocumentsReports.Name = "mnuDocumentsReports"
        Me.mnuDocumentsReports.Size = New System.Drawing.Size(210, 22)
        Me.mnuDocumentsReports.Text = "&Reports..."
        '
        'mnuDocsSep
        '
        Me.mnuDocsSep.Name = "mnuDocsSep"
        Me.mnuDocsSep.Size = New System.Drawing.Size(207, 6)
        '
        'mnuDocumentsRelease
        '
        Me.mnuDocumentsRelease.Name = "mnuDocumentsRelease"
        Me.mnuDocumentsRelease.Size = New System.Drawing.Size(210, 22)
        Me.mnuDocumentsRelease.Text = "Release &Cases"
        '
        'mnuDocumentsTeam
        '
        Me.mnuDocumentsTeam.Name = "mnuDocumentsTeam"
        Me.mnuDocumentsTeam.Size = New System.Drawing.Size(210, 22)
        Me.mnuDocumentsTeam.Text = "&Team / Interviewer Listing"
        '
        'mnuDocumentsSupplies
        '
        Me.mnuDocumentsSupplies.Name = "mnuDocumentsSupplies"
        Me.mnuDocumentsSupplies.Size = New System.Drawing.Size(210, 22)
        Me.mnuDocumentsSupplies.Text = "Interviewer &Supplies"
        '
        'mnuDocumentsValidations
        '
        Me.mnuDocumentsValidations.Name = "mnuDocumentsValidations"
        Me.mnuDocumentsValidations.Size = New System.Drawing.Size(210, 22)
        Me.mnuDocumentsValidations.Text = "&Validations"
        '
        'OptionsMenu
        '
        Me.OptionsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsUserInformation, Me.OptionsChangePassword})
        Me.OptionsMenu.Name = "OptionsMenu"
        Me.OptionsMenu.Size = New System.Drawing.Size(56, 20)
        Me.OptionsMenu.Text = "&Options"
        Me.OptionsMenu.Visible = False
        '
        'OptionsUserInformation
        '
        Me.OptionsUserInformation.Name = "OptionsUserInformation"
        Me.OptionsUserInformation.Size = New System.Drawing.Size(183, 22)
        Me.OptionsUserInformation.Text = "&User Information..."
        '
        'OptionsChangePassword
        '
        Me.OptionsChangePassword.Name = "OptionsChangePassword"
        Me.OptionsChangePassword.Size = New System.Drawing.Size(183, 22)
        Me.OptionsChangePassword.Text = "Change &Password..."
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpAbout})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(40, 20)
        Me.HelpMenu.Text = "&Help"
        Me.HelpMenu.Visible = False
        '
        'HelpAbout
        '
        Me.HelpAbout.Name = "HelpAbout"
        Me.HelpAbout.Size = New System.Drawing.Size(126, 22)
        Me.HelpAbout.Text = "&About..."
        '
        'MyToolBar
        '
        Me.MyToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSeparator, Me.tbTreeView, Me.tbSearch, Me.tbRefresh})
        Me.MyToolBar.Location = New System.Drawing.Point(0, 24)
        Me.MyToolBar.Name = "MyToolBar"
        Me.MyToolBar.Size = New System.Drawing.Size(690, 25)
        Me.MyToolBar.TabIndex = 2
        Me.MyToolBar.Text = "ToolStrip1"
        '
        'tbSeparator
        '
        Me.tbSeparator.Name = "tbSeparator"
        Me.tbSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'tbTreeView
        '
        Me.tbTreeView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbTreeView.Image = CType(resources.GetObject("tbTreeView.Image"), System.Drawing.Image)
        Me.tbTreeView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbTreeView.Name = "tbTreeView"
        Me.tbTreeView.Size = New System.Drawing.Size(23, 22)
        Me.tbTreeView.Text = "View by Staff"
        '
        'tbSearch
        '
        Me.tbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSearch.Image = CType(resources.GetObject("tbSearch.Image"), System.Drawing.Image)
        Me.tbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(23, 22)
        Me.tbSearch.Text = "Find Cases"
        '
        'tbRefresh
        '
        Me.tbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbRefresh.Image = CType(resources.GetObject("tbRefresh.Image"), System.Drawing.Image)
        Me.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbRefresh.Name = "tbRefresh"
        Me.tbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tbRefresh.Text = "Refresh"
        '
        'MyStatusBar
        '
        Me.MyStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StaffCount, Me.CaseCount, Me.StatusBarCurrentUserPanel})
        Me.MyStatusBar.Location = New System.Drawing.Point(0, 455)
        Me.MyStatusBar.Name = "MyStatusBar"
        Me.MyStatusBar.Size = New System.Drawing.Size(690, 25)
        Me.MyStatusBar.TabIndex = 4
        Me.MyStatusBar.Text = "Ready"
        '
        'StaffCount
        '
        Me.StaffCount.AutoSize = False
        Me.StaffCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StaffCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.StaffCount.Name = "StaffCount"
        Me.StaffCount.Size = New System.Drawing.Size(300, 20)
        Me.StaffCount.Text = "# of Interviewers"
        Me.StaffCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CaseCount
        '
        Me.CaseCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.CaseCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.CaseCount.Name = "CaseCount"
        Me.CaseCount.Size = New System.Drawing.Size(289, 20)
        Me.CaseCount.Spring = True
        Me.CaseCount.Text = "# of Cases"
        Me.CaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusBarCurrentUserPanel
        '
        Me.StatusBarCurrentUserPanel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StatusBarCurrentUserPanel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.StatusBarCurrentUserPanel.Image = CType(resources.GetObject("StatusBarCurrentUserPanel.Image"), System.Drawing.Image)
        Me.StatusBarCurrentUserPanel.Name = "StatusBarCurrentUserPanel"
        Me.StatusBarCurrentUserPanel.Size = New System.Drawing.Size(86, 20)
        Me.StatusBarCurrentUserPanel.Text = "CurrentUser"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ucSearch)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ucNavigate)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ucCaseAssignments)
        Me.SplitContainer2.Size = New System.Drawing.Size(690, 406)
        Me.SplitContainer2.SplitterDistance = 272
        Me.SplitContainer2.TabIndex = 5
        '
        'ucSearch
        '
        Me.ucSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucSearch.Location = New System.Drawing.Point(0, 183)
        Me.ucSearch.Name = "ucSearch"
        Me.ucSearch.Size = New System.Drawing.Size(272, 223)
        Me.ucSearch.TabIndex = 1
        Me.ucSearch.Visible = False
        '
        'ucNavigate
        '
        Me.ucNavigate.CaseAssignments = Nothing
        Me.ucNavigate.CurrentSupervisor = Nothing
        Me.ucNavigate.Dock = System.Windows.Forms.DockStyle.Top
        Me.ucNavigate.InterviewerRegions = Nothing
        Me.ucNavigate.Interviewers = Nothing
        Me.ucNavigate.InterviewerSupervisors = Nothing
        Me.ucNavigate.InterviewerTeams = Nothing
        Me.ucNavigate.Location = New System.Drawing.Point(0, 0)
        Me.ucNavigate.Name = "ucNavigate"
        Me.ucNavigate.SelectedNode = Nothing
        Me.ucNavigate.Size = New System.Drawing.Size(272, 183)
        Me.ucNavigate.TabIndex = 0
        Me.ucNavigate.ViewBy = MPR.SMS.FieldManagement.ucNavigate.ViewByType.Region
        '
        'ucCaseAssignments
        '
        Me.ucCaseAssignments.CaseAssignments = Nothing
        Me.ucCaseAssignments.CaseViewType = MPR.SMS.Data.CaseAssignments.CaseAssignmentType.ViewAll
        Me.ucCaseAssignments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCaseAssignments.Location = New System.Drawing.Point(0, 0)
        Me.ucCaseAssignments.Name = "ucCaseAssignments"
        Me.ucCaseAssignments.Size = New System.Drawing.Size(414, 406)
        Me.ucCaseAssignments.TabIndex = 0
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'mnuSep2
        '
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.Size = New System.Drawing.Size(188, 6)
        '
        'frmFieldManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 480)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.MyStatusBar)
        Me.Controls.Add(Me.MyToolBar)
        Me.Controls.Add(Me.MainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFieldManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Field Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.MyToolBar.ResumeLayout(False)
        Me.MyToolBar.PerformLayout()
        Me.MyStatusBar.ResumeLayout(False)
        Me.MyStatusBar.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpenCase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenuSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilePrintCase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditAssignCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditAssignCasesSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUpdateSupervisor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateTeam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TreeView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsUserInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MyToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents tbSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbTreeView As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents MyStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StaffCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusBarCurrentUserPanel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CaseCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewBySupervisors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewByRegions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewByTeams As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewByInterviewers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewStaffBy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ucNavigate As MPR.SMS.FieldManagement.ucNavigate
    Friend WithEvents ViewAssignmentsByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesAssigned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesUnassigned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesActive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesCompleted As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewCasesValidation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateRegion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuNewRegion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewSupervisor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewTeam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents mnuTrackInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ucCaseAssignments As MPR.SMS.FieldManagement.ucCaseAssignments
    Friend WithEvents ucSearch As MPR.SMS.FieldManagement.ucCaseAssignmentSearch
    Friend WithEvents mnuInterviewWeeks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocuments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocumentsRelease As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocumentsTeam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocumentsSupplies As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocumentsValidations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCaseProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocumentsReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocsSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSep2 As System.Windows.Forms.ToolStripSeparator
End Class
