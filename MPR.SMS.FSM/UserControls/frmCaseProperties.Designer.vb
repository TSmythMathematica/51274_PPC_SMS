<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaseProperties
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaseProperties))
        Me.tabCase = New System.Windows.Forms.TabControl()
        Me.tabCaseMembers = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.ViewCasePhones = New MPR.SMS.UserControls.ViewCasePhones()
        Me.ViewCaseEmails = New MPR.SMS.UserControls.ViewCaseEmails()
        Me.tabCaseInstruments = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseInstruments = New MPR.SMS.UserControls.ViewCaseInstruments()
        Me.ViewCaseDocuments = New MPR.SMS.UserControls.ViewCaseDocuments()
        Me.tabCaseNotes = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtCaseNotes = New System.Windows.Forms.TextBox()
        Me.ViewCaseNotes = New MPR.SMS.UserControls.ViewCaseNotes()
        Me.tabLocating = New System.Windows.Forms.TabPage()
        Me.ViewCaseLocatingAttempts = New MPR.SMS.UserControls.ViewCaseLocatingAttempts()
        Me.tabTracking = New System.Windows.Forms.TabPage()
        Me.CaseTracking = New MPR.SMS.FieldManagement.ucCaseTracking()
        Me.tabAssignments = New System.Windows.Forms.TabPage()
        Me.grpHistory = New System.Windows.Forms.GroupBox()
        Me.vwCaseAssignmentHistory = New MPR.SMS.UserControls.ViewDataSet()
        Me.tabValidation = New System.Windows.Forms.TabPage()
        Me.EditValidation = New MPR.SMS.FieldManagement.ucValidation()
        Me.ssCase = New System.Windows.Forms.StatusStrip()
        Me.tsslLocked = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCaseID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslEntity = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsCase = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslEntityName = New System.Windows.Forms.ToolStripLabel()
        Me.txtEntityName = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tab = New System.Windows.Forms.TabPage()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.CaseTrackingValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.CaseValidationValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.tabCase.SuspendLayout
        Me.tabCaseMembers.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        CType(Me.SplitContainer4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer4.Panel1.SuspendLayout
        Me.SplitContainer4.Panel2.SuspendLayout
        Me.SplitContainer4.SuspendLayout
        Me.tabCaseInstruments.SuspendLayout
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer3.Panel1.SuspendLayout
        Me.SplitContainer3.Panel2.SuspendLayout
        Me.SplitContainer3.SuspendLayout
        Me.tabCaseNotes.SuspendLayout
        CType(Me.SplitContainer5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer5.Panel1.SuspendLayout
        Me.SplitContainer5.Panel2.SuspendLayout
        Me.SplitContainer5.SuspendLayout
        Me.tabLocating.SuspendLayout
        Me.tabTracking.SuspendLayout
        Me.tabAssignments.SuspendLayout
        Me.grpHistory.SuspendLayout
        Me.tabValidation.SuspendLayout
        Me.ssCase.SuspendLayout
        Me.tsCase.SuspendLayout
        Me.SuspendLayout
        '
        'tabCase
        '
        Me.tabCase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabCase.Controls.Add(Me.tabCaseMembers)
        Me.tabCase.Controls.Add(Me.tabCaseInstruments)
        Me.tabCase.Controls.Add(Me.tabCaseNotes)
        Me.tabCase.Controls.Add(Me.tabLocating)
        Me.tabCase.Controls.Add(Me.tabTracking)
        Me.tabCase.Controls.Add(Me.tabAssignments)
        Me.tabCase.Controls.Add(Me.tabValidation)
        Me.tabCase.Location = New System.Drawing.Point(0, 48)
        Me.tabCase.Margin = New System.Windows.Forms.Padding(4)
        Me.tabCase.Multiline = true
        Me.tabCase.Name = "tabCase"
        Me.tabCase.SelectedIndex = 0
        Me.tabCase.Size = New System.Drawing.Size(1056, 593)
        Me.tabCase.TabIndex = 1
        '
        'tabCaseMembers
        '
        Me.tabCaseMembers.Controls.Add(Me.SplitContainer1)
        Me.tabCaseMembers.Location = New System.Drawing.Point(4, 25)
        Me.tabCaseMembers.Margin = New System.Windows.Forms.Padding(4)
        Me.tabCaseMembers.Name = "tabCaseMembers"
        Me.tabCaseMembers.Padding = New System.Windows.Forms.Padding(4)
        Me.tabCaseMembers.Size = New System.Drawing.Size(1048, 564)
        Me.tabCaseMembers.TabIndex = 0
        Me.tabCaseMembers.Text = "Members"
        Me.tabCaseMembers.UseVisualStyleBackColor = true
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ViewCaseMembers)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1040, 556)
        Me.SplitContainer1.SplitterDistance = 140
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.AllowAdd = false
        Me.ViewCaseMembers.AllowEdit = false
        Me.ViewCaseMembers.AutoScroll = true
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseMembers.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.Size = New System.Drawing.Size(1040, 140)
        Me.ViewCaseMembers.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ViewCaseAddresses)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(1040, 411)
        Me.SplitContainer2.SplitterDistance = 150
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.AllowAdd = false
        Me.ViewCaseAddresses.AllowEdit = false
        Me.ViewCaseAddresses.AutoScroll = true
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(1040, 150)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.ForeColor = System.Drawing.SystemColors.MenuText
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.ViewCasePhones)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.ViewCaseEmails)
        Me.SplitContainer4.Size = New System.Drawing.Size(1040, 256)
        Me.SplitContainer4.SplitterDistance = 470
        Me.SplitContainer4.SplitterWidth = 5
        Me.SplitContainer4.TabIndex = 0
        '
        'ViewCasePhones
        '
        Me.ViewCasePhones.AllowAdd = false
        Me.ViewCasePhones.AllowEdit = false
        Me.ViewCasePhones.AutoScroll = true
        Me.ViewCasePhones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCasePhones.Location = New System.Drawing.Point(0, 0)
        Me.ViewCasePhones.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCasePhones.Name = "ViewCasePhones"
        Me.ViewCasePhones.SelectedCase = Nothing
        Me.ViewCasePhones.SelectedPerson = Nothing
        Me.ViewCasePhones.SelectedPhone = Nothing
        Me.ViewCasePhones.Size = New System.Drawing.Size(470, 256)
        Me.ViewCasePhones.TabIndex = 0
        '
        'ViewCaseEmails
        '
        Me.ViewCaseEmails.AllowAdd = false
        Me.ViewCaseEmails.AllowEdit = false
        Me.ViewCaseEmails.AutoScroll = true
        Me.ViewCaseEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseEmails.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseEmails.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseEmails.Name = "ViewCaseEmails"
        Me.ViewCaseEmails.SelectedCase = Nothing
        Me.ViewCaseEmails.SelectedEmail = Nothing
        Me.ViewCaseEmails.SelectedPerson = Nothing
        Me.ViewCaseEmails.Size = New System.Drawing.Size(565, 256)
        Me.ViewCaseEmails.TabIndex = 0
        '
        'tabCaseInstruments
        '
        Me.tabCaseInstruments.Controls.Add(Me.SplitContainer3)
        Me.tabCaseInstruments.Location = New System.Drawing.Point(4, 25)
        Me.tabCaseInstruments.Margin = New System.Windows.Forms.Padding(4)
        Me.tabCaseInstruments.Name = "tabCaseInstruments"
        Me.tabCaseInstruments.Padding = New System.Windows.Forms.Padding(4)
        Me.tabCaseInstruments.Size = New System.Drawing.Size(1048, 564)
        Me.tabCaseInstruments.TabIndex = 1
        Me.tabCaseInstruments.Text = "Instruments && Documents"
        Me.tabCaseInstruments.UseVisualStyleBackColor = true
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ViewCaseInstruments)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.ViewCaseDocuments)
        Me.SplitContainer3.Size = New System.Drawing.Size(1040, 556)
        Me.SplitContainer3.SplitterDistance = 247
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 5
        '
        'ViewCaseInstruments
        '
        Me.ViewCaseInstruments.AllowAdd = false
        Me.ViewCaseInstruments.AllowEdit = false
        Me.ViewCaseInstruments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseInstruments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseInstruments.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseInstruments.Name = "ViewCaseInstruments"
        Me.ViewCaseInstruments.SelectedCase = Nothing
        Me.ViewCaseInstruments.SelectedInstrument = Nothing
        Me.ViewCaseInstruments.Size = New System.Drawing.Size(1040, 247)
        Me.ViewCaseInstruments.TabIndex = 0
        '
        'ViewCaseDocuments
        '
        Me.ViewCaseDocuments.AllowAdd = false
        Me.ViewCaseDocuments.AllowEdit = false
        Me.ViewCaseDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseDocuments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseDocuments.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseDocuments.Name = "ViewCaseDocuments"
        Me.ViewCaseDocuments.SelectedCase = Nothing
        Me.ViewCaseDocuments.SelectedDocument = Nothing
        Me.ViewCaseDocuments.Size = New System.Drawing.Size(1040, 304)
        Me.ViewCaseDocuments.TabIndex = 0
        '
        'tabCaseNotes
        '
        Me.tabCaseNotes.Controls.Add(Me.SplitContainer5)
        Me.tabCaseNotes.Location = New System.Drawing.Point(4, 25)
        Me.tabCaseNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.tabCaseNotes.Name = "tabCaseNotes"
        Me.tabCaseNotes.Padding = New System.Windows.Forms.Padding(4)
        Me.tabCaseNotes.Size = New System.Drawing.Size(1048, 564)
        Me.tabCaseNotes.TabIndex = 3
        Me.tabCaseNotes.Text = "Notes"
        Me.tabCaseNotes.UseVisualStyleBackColor = true
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer5.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.lblNotes)
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtCaseNotes)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.ViewCaseNotes)
        Me.SplitContainer5.Size = New System.Drawing.Size(1040, 556)
        Me.SplitContainer5.SplitterDistance = 164
        Me.SplitContainer5.SplitterWidth = 5
        Me.SplitContainer5.TabIndex = 0
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = true
        Me.lblNotes.Location = New System.Drawing.Point(7, 5)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(83, 17)
        Me.lblNotes.TabIndex = 0
        Me.lblNotes.Text = "Case notes:"
        '
        'txtCaseNotes
        '
        Me.txtCaseNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtCaseNotes.Location = New System.Drawing.Point(4, 27)
        Me.txtCaseNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCaseNotes.MaxLength = 2000
        Me.txtCaseNotes.Multiline = true
        Me.txtCaseNotes.Name = "txtCaseNotes"
        Me.txtCaseNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCaseNotes.Size = New System.Drawing.Size(1028, 132)
        Me.txtCaseNotes.TabIndex = 1
        '
        'ViewCaseNotes
        '
        Me.ViewCaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseNotes.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseNotes.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseNotes.Name = "ViewCaseNotes"
        Me.ViewCaseNotes.SelectedCase = Nothing
        Me.ViewCaseNotes.SelectedNote = Nothing
        Me.ViewCaseNotes.Size = New System.Drawing.Size(1040, 387)
        Me.ViewCaseNotes.TabIndex = 0
        '
        'tabLocating
        '
        Me.tabLocating.Controls.Add(Me.ViewCaseLocatingAttempts)
        Me.tabLocating.Location = New System.Drawing.Point(4, 25)
        Me.tabLocating.Margin = New System.Windows.Forms.Padding(4)
        Me.tabLocating.Name = "tabLocating"
        Me.tabLocating.Size = New System.Drawing.Size(1048, 564)
        Me.tabLocating.TabIndex = 4
        Me.tabLocating.Text = "Locating"
        Me.tabLocating.UseVisualStyleBackColor = true
        '
        'ViewCaseLocatingAttempts
        '
        Me.ViewCaseLocatingAttempts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseLocatingAttempts.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseLocatingAttempts.Margin = New System.Windows.Forms.Padding(5)
        Me.ViewCaseLocatingAttempts.Name = "ViewCaseLocatingAttempts"
        Me.ViewCaseLocatingAttempts.SelectedCase = Nothing
        Me.ViewCaseLocatingAttempts.SelectedLocatingAttempt = Nothing
        Me.ViewCaseLocatingAttempts.SelectedPerson = Nothing
        Me.ViewCaseLocatingAttempts.Size = New System.Drawing.Size(1048, 564)
        Me.ViewCaseLocatingAttempts.TabIndex = 0
        '
        'tabTracking
        '
        Me.tabTracking.Controls.Add(Me.CaseTracking)
        Me.tabTracking.Location = New System.Drawing.Point(4, 25)
        Me.tabTracking.Margin = New System.Windows.Forms.Padding(4)
        Me.tabTracking.Name = "tabTracking"
        Me.tabTracking.Size = New System.Drawing.Size(1048, 564)
        Me.tabTracking.TabIndex = 5
        Me.tabTracking.Text = "Tracking"
        Me.tabTracking.UseVisualStyleBackColor = true
        '
        'CaseTracking
        '
        Me.CaseTracking.CurrentSupervisor = Nothing
        Me.CaseTracking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaseTracking.InterviewerCaseTrackings = Nothing
        Me.CaseTracking.Location = New System.Drawing.Point(0, 0)
        Me.CaseTracking.Margin = New System.Windows.Forms.Padding(5)
        Me.CaseTracking.Name = "CaseTracking"
        Me.CaseTracking.Size = New System.Drawing.Size(1048, 564)
        Me.CaseTracking.TabIndex = 0
        '
        'tabAssignments
        '
        Me.tabAssignments.Controls.Add(Me.grpHistory)
        Me.tabAssignments.Location = New System.Drawing.Point(4, 25)
        Me.tabAssignments.Margin = New System.Windows.Forms.Padding(4)
        Me.tabAssignments.Name = "tabAssignments"
        Me.tabAssignments.Size = New System.Drawing.Size(1048, 564)
        Me.tabAssignments.TabIndex = 6
        Me.tabAssignments.Text = "Assignments"
        Me.tabAssignments.UseVisualStyleBackColor = true
        '
        'grpHistory
        '
        Me.grpHistory.Controls.Add(Me.vwCaseAssignmentHistory)
        Me.grpHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpHistory.Location = New System.Drawing.Point(0, 0)
        Me.grpHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.grpHistory.Name = "grpHistory"
        Me.grpHistory.Padding = New System.Windows.Forms.Padding(4)
        Me.grpHistory.Size = New System.Drawing.Size(1048, 564)
        Me.grpHistory.TabIndex = 2
        Me.grpHistory.TabStop = false
        Me.grpHistory.Text = "Case assignment history"
        '
        'vwCaseAssignmentHistory
        '
        Me.vwCaseAssignmentHistory.DataSource = Nothing
        Me.vwCaseAssignmentHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vwCaseAssignmentHistory.DoubleClickColumn = 0
        Me.vwCaseAssignmentHistory.Location = New System.Drawing.Point(4, 19)
        Me.vwCaseAssignmentHistory.Margin = New System.Windows.Forms.Padding(5)
        Me.vwCaseAssignmentHistory.MultiSelect = true
        Me.vwCaseAssignmentHistory.Name = "vwCaseAssignmentHistory"
        Me.vwCaseAssignmentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwCaseAssignmentHistory.Size = New System.Drawing.Size(1040, 541)
        Me.vwCaseAssignmentHistory.SortedColumn = Nothing
        Me.vwCaseAssignmentHistory.TabIndex = 1
        '
        'tabValidation
        '
        Me.tabValidation.Controls.Add(Me.EditValidation)
        Me.tabValidation.Location = New System.Drawing.Point(4, 25)
        Me.tabValidation.Margin = New System.Windows.Forms.Padding(4)
        Me.tabValidation.Name = "tabValidation"
        Me.tabValidation.Padding = New System.Windows.Forms.Padding(4)
        Me.tabValidation.Size = New System.Drawing.Size(1048, 564)
        Me.tabValidation.TabIndex = 7
        Me.tabValidation.Text = "Validation"
        Me.tabValidation.UseVisualStyleBackColor = true
        '
        'EditValidation
        '
        Me.EditValidation.CaseValidation = Nothing
        Me.EditValidation.Dock = System.Windows.Forms.DockStyle.Top
        Me.EditValidation.Location = New System.Drawing.Point(4, 4)
        Me.EditValidation.Margin = New System.Windows.Forms.Padding(5)
        Me.EditValidation.Name = "EditValidation"
        Me.EditValidation.Size = New System.Drawing.Size(1040, 233)
        Me.EditValidation.TabIndex = 0
        '
        'ssCase
        '
        Me.ssCase.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ssCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLocked, Me.tsslCaseID, Me.tsslEntity, Me.tsslStatus, Me.tspbProgress, Me.tsslUser})
        Me.ssCase.Location = New System.Drawing.Point(0, 643)
        Me.ssCase.Name = "ssCase"
        Me.ssCase.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.ssCase.ShowItemToolTips = true
        Me.ssCase.Size = New System.Drawing.Size(1056, 29)
        Me.ssCase.TabIndex = 3
        Me.ssCase.Text = "StatusStrip1"
        '
        'tsslLocked
        '
        Me.tsslLocked.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslLocked.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslLocked.Image = CType(resources.GetObject("tsslLocked.Image"),System.Drawing.Image)
        Me.tsslLocked.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.tsslLocked.Name = "tsslLocked"
        Me.tsslLocked.Size = New System.Drawing.Size(24, 24)
        Me.tsslLocked.ToolTipText = "Case lock status"
        '
        'tsslCaseID
        '
        Me.tsslCaseID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCaseID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslCaseID.Name = "tsslCaseID"
        Me.tsslCaseID.Size = New System.Drawing.Size(832, 24)
        Me.tsslCaseID.Spring = true
        Me.tsslCaseID.Text = "Case ID:"
        Me.tsslCaseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslCaseID.ToolTipText = "Case ID"
        '
        'tsslEntity
        '
        Me.tsslEntity.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEntity.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslEntity.Name = "tsslEntity"
        Me.tsslEntity.Size = New System.Drawing.Size(81, 24)
        Me.tsslEntity.Text = "EntityType"
        Me.tsslEntity.ToolTipText = "Case type"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(53, 29)
        Me.tsslStatus.Text = "Status"
        Me.tsslStatus.ToolTipText = "Case's aggregated status"
        Me.tsslStatus.Visible = false
        '
        'tspbProgress
        '
        Me.tspbProgress.Name = "tspbProgress"
        Me.tspbProgress.Size = New System.Drawing.Size(133, 28)
        Me.tspbProgress.Visible = false
        '
        'tsslUser
        '
        Me.tsslUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslUser.Image = CType(resources.GetObject("tsslUser.Image"),System.Drawing.Image)
        Me.tsslUser.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsslUser.Name = "tsslUser"
        Me.tsslUser.Size = New System.Drawing.Size(99, 24)
        Me.tsslUser.Text = "Username"
        Me.tsslUser.ToolTipText = "Your user login name"
        '
        'tsCase
        '
        Me.tsCase.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbPrint, Me.tsbClose, Me.ToolStripSeparator2, Me.tslEntityName, Me.txtEntityName, Me.ToolStripSeparator3})
        Me.tsCase.Location = New System.Drawing.Point(0, 0)
        Me.tsCase.Name = "tsCase"
        Me.tsCase.Size = New System.Drawing.Size(1056, 47)
        Me.tsCase.TabIndex = 0
        Me.tsCase.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"),System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(44, 44)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSave.ToolTipText = "Save changes made to this case"
        '
        'tsbPrint
        '
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"),System.Drawing.Image)
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(43, 44)
        Me.tsbPrint.Text = "Print"
        Me.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbPrint.ToolTipText = "Print this page"
        '
        'tsbClose
        '
        Me.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(49, 44)
        Me.tsbClose.Text = "Close"
        Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbClose.ToolTipText = "Close this window"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
        '
        'tslEntityName
        '
        Me.tslEntityName.Name = "tslEntityName"
        Me.tslEntityName.Size = New System.Drawing.Size(84, 44)
        Me.tslEntityName.Text = "Case name:"
        '
        'txtEntityName
        '
        Me.txtEntityName.MaxLength = 50
        Me.txtEntityName.Name = "txtEntityName"
        Me.txtEntityName.Size = New System.Drawing.Size(265, 47)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 47)
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imgImages.TransparentColor = System.Drawing.Color.Transparent
        Me.imgImages.Images.SetKeyName(0, "lock-none.bmp")
        Me.imgImages.Images.SetKeyName(1, "lock-owned.bmp")
        Me.imgImages.Images.SetKeyName(2, "lock-unavailable.bmp")
        '
        'tab
        '
        Me.tab.Location = New System.Drawing.Point(4, 22)
        Me.tab.Name = "tab"
        Me.tab.Padding = New System.Windows.Forms.Padding(3)
        Me.tab.Size = New System.Drawing.Size(749, 423)
        Me.tab.TabIndex = 4
        Me.tab.Text = "Classroom"
        Me.tab.UseVisualStyleBackColor = true
        '
        'CaseTrackingValidator
        '
        Me.CaseTrackingValidator.ContainerToValidate = Me.tabTracking
        Me.CaseTrackingValidator.HostingForm = Me
        '
        'CaseValidationValidator
        '
        Me.CaseValidationValidator.ContainerToValidate = Me.tabValidation
        Me.CaseValidationValidator.HostingForm = Me
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = true
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"),System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = false
        '
        'frmCaseProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 672)
        Me.Controls.Add(Me.tsCase)
        Me.Controls.Add(Me.ssCase)
        Me.Controls.Add(Me.tabCase)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCaseProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Case Properties"
        Me.tabCase.ResumeLayout(false)
        Me.tabCaseMembers.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        Me.SplitContainer4.Panel1.ResumeLayout(false)
        Me.SplitContainer4.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer4,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer4.ResumeLayout(false)
        Me.tabCaseInstruments.ResumeLayout(false)
        Me.SplitContainer3.Panel1.ResumeLayout(false)
        Me.SplitContainer3.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer3.ResumeLayout(false)
        Me.tabCaseNotes.ResumeLayout(false)
        Me.SplitContainer5.Panel1.ResumeLayout(false)
        Me.SplitContainer5.Panel1.PerformLayout
        Me.SplitContainer5.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer5,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer5.ResumeLayout(false)
        Me.tabLocating.ResumeLayout(false)
        Me.tabTracking.ResumeLayout(false)
        Me.tabAssignments.ResumeLayout(false)
        Me.grpHistory.ResumeLayout(false)
        Me.tabValidation.ResumeLayout(false)
        Me.ssCase.ResumeLayout(false)
        Me.ssCase.PerformLayout
        Me.tsCase.ResumeLayout(false)
        Me.tsCase.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents tabCase As System.Windows.Forms.TabControl
    Friend WithEvents tabCaseMembers As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseInstruments As System.Windows.Forms.TabPage
    Friend WithEvents ssCase As System.Windows.Forms.StatusStrip
    Friend WithEvents tsCase As System.Windows.Forms.ToolStrip
    Friend WithEvents tabCaseNotes As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslCaseID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsslUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslLocked As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslEntity As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents ViewCaseInstruments As MPR.SMS.UserControls.ViewCaseInstruments
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseDocuments As MPR.SMS.UserControls.ViewCaseDocuments
    Friend WithEvents tab As System.Windows.Forms.TabPage
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslEntityName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtEntityName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCasePhones As MPR.SMS.UserControls.ViewCasePhones
    Friend WithEvents ViewCaseEmails As MPR.SMS.UserControls.ViewCaseEmails
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtCaseNotes As System.Windows.Forms.TextBox
    Friend WithEvents ViewCaseNotes As MPR.SMS.UserControls.ViewCaseNotes
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents tabLocating As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseLocatingAttempts As MPR.SMS.UserControls.ViewCaseLocatingAttempts
    Friend WithEvents tabTracking As System.Windows.Forms.TabPage
    Friend WithEvents tabAssignments As System.Windows.Forms.TabPage
    Friend WithEvents vwCaseAssignmentHistory As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents CaseTracking As MPR.SMS.FieldManagement.ucCaseTracking
    Friend WithEvents grpHistory As System.Windows.Forms.GroupBox
    Friend WithEvents tabValidation As System.Windows.Forms.TabPage
    Friend WithEvents EditValidation As MPR.SMS.FieldManagement.ucValidation
    Friend WithEvents CaseTrackingValidator As MPR.Windows.Forms.Validation.ContainerValidator
    Friend WithEvents CaseValidationValidator As MPR.Windows.Forms.Validation.ContainerValidator
End Class
