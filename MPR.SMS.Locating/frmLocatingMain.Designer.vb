'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocatingMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocatingMain))
        Me.tabCase = New System.Windows.Forms.TabControl()
        Me.tabCaseLocating = New System.Windows.Forms.TabPage()
        Me.ViewCaseLocatingAttempts = New MPR.SMS.UserControls.ViewCaseLocatingAttempts()
        Me.tabCaseMembers = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ViewCasePhones = New MPR.SMS.UserControls.ViewCasePhones()
        Me.tabWWW = New System.Windows.Forms.TabControl()
        Me.tabEmail = New System.Windows.Forms.TabPage()
        Me.ViewCaseEmails = New MPR.SMS.UserControls.ViewCaseEmails()
        Me.tabSN = New System.Windows.Forms.TabPage()
        Me.ViewCaseSocialNetworks = New MPR.SMS.UserControls.ViewCaseSocialNetworks()
        Me.tabCaseInstruments = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseInstruments = New MPR.SMS.UserControls.ViewCaseInstruments()
        Me.ViewCaseDocuments = New MPR.SMS.UserControls.ViewCaseDocuments()
        Me.tabCaseNotes = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.ViewConfirmitCallHist = New MPR.SMS.UserControls.ViewConfirmitCallHist()
        Me.ViewCaseNotes = New MPR.SMS.UserControls.ViewCaseNotes()
        Me.tabCaseSup = New System.Windows.Forms.TabPage()
        Me.EditLocatingStatusSupervisor = New MPR.SMS.UserControls.EditLocatingStatusSupervisor()
        Me.ssCase = New System.Windows.Forms.StatusStrip()
        Me.tsslLocked = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCaseID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslEntity = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsCase = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsbLock = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPriority = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsmLowPriority = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmHighPriority = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslEntityName = New System.Windows.Forms.ToolStripLabel()
        Me.txtEntityName = New System.Windows.Forms.ToolStripTextBox()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tab = New System.Windows.Forms.TabPage()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.lblSSN = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblRelType = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblMPRID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblWebPW = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblOrigEmail = New System.Windows.Forms.Label()
        Me.lblOrigPhone = New System.Windows.Forms.Label()
        Me.lblOrigAddr = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tabCase.SuspendLayout
        Me.tabCaseLocating.SuspendLayout
        Me.tabCaseMembers.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer3.Panel1.SuspendLayout
        Me.SplitContainer3.Panel2.SuspendLayout
        Me.SplitContainer3.SuspendLayout
        Me.tabWWW.SuspendLayout
        Me.tabEmail.SuspendLayout
        Me.tabSN.SuspendLayout
        Me.tabCaseInstruments.SuspendLayout
        CType(Me.SplitContainer4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer4.Panel1.SuspendLayout
        Me.SplitContainer4.Panel2.SuspendLayout
        Me.SplitContainer4.SuspendLayout
        Me.tabCaseNotes.SuspendLayout
        CType(Me.SplitContainer5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer5.Panel1.SuspendLayout
        Me.SplitContainer5.Panel2.SuspendLayout
        Me.SplitContainer5.SuspendLayout
        Me.tabCaseSup.SuspendLayout
        Me.ssCase.SuspendLayout
        Me.tsCase.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.SuspendLayout
        '
        'tabCase
        '
        Me.tabCase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabCase.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabCase.Controls.Add(Me.tabCaseLocating)
        Me.tabCase.Controls.Add(Me.tabCaseMembers)
        Me.tabCase.Controls.Add(Me.tabCaseInstruments)
        Me.tabCase.Controls.Add(Me.tabCaseNotes)
        Me.tabCase.Controls.Add(Me.tabCaseSup)
        Me.tabCase.ItemSize = New System.Drawing.Size(150, 22)
        Me.tabCase.Location = New System.Drawing.Point(0, 117)
        Me.tabCase.Multiline = true
        Me.tabCase.Name = "tabCase"
        Me.tabCase.SelectedIndex = 0
        Me.tabCase.Size = New System.Drawing.Size(865, 597)
        Me.tabCase.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabCase.TabIndex = 1
        '
        'tabCaseLocating
        '
        Me.tabCaseLocating.Controls.Add(Me.ViewCaseLocatingAttempts)
        Me.tabCaseLocating.Location = New System.Drawing.Point(4, 26)
        Me.tabCaseLocating.Name = "tabCaseLocating"
        Me.tabCaseLocating.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseLocating.Size = New System.Drawing.Size(857, 567)
        Me.tabCaseLocating.TabIndex = 0
        Me.tabCaseLocating.Text = "Locating History"
        Me.tabCaseLocating.UseVisualStyleBackColor = true
        '
        'ViewCaseLocatingAttempts
        '
        Me.ViewCaseLocatingAttempts.AllowAdd = false
        Me.ViewCaseLocatingAttempts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseLocatingAttempts.Location = New System.Drawing.Point(3, 3)
        Me.ViewCaseLocatingAttempts.Name = "ViewCaseLocatingAttempts"
        Me.ViewCaseLocatingAttempts.SelectedCase = Nothing
        Me.ViewCaseLocatingAttempts.SelectedLocatingAttempt = Nothing
        Me.ViewCaseLocatingAttempts.SelectedPerson = Nothing
        Me.ViewCaseLocatingAttempts.Size = New System.Drawing.Size(851, 561)
        Me.ViewCaseLocatingAttempts.TabIndex = 1
        '
        'tabCaseMembers
        '
        Me.tabCaseMembers.Controls.Add(Me.SplitContainer1)
        Me.tabCaseMembers.Location = New System.Drawing.Point(4, 26)
        Me.tabCaseMembers.Name = "tabCaseMembers"
        Me.tabCaseMembers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseMembers.Size = New System.Drawing.Size(857, 567)
        Me.tabCaseMembers.TabIndex = 6
        Me.tabCaseMembers.Text = "Members"
        Me.tabCaseMembers.UseVisualStyleBackColor = true
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(851, 561)
        Me.SplitContainer1.SplitterDistance = 176
        Me.SplitContainer1.TabIndex = 2
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.AllowAdd = false
        Me.ViewCaseMembers.AllowEdit = false
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.Size = New System.Drawing.Size(851, 176)
        Me.ViewCaseMembers.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(851, 381)
        Me.SplitContainer2.SplitterDistance = 183
        Me.SplitContainer2.TabIndex = 0
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.AllowAdd = false
        Me.ViewCaseAddresses.AllowEdit = false
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(851, 183)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ViewCasePhones)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.tabWWW)
        Me.SplitContainer3.Size = New System.Drawing.Size(851, 194)
        Me.SplitContainer3.SplitterDistance = 448
        Me.SplitContainer3.TabIndex = 0
        '
        'ViewCasePhones
        '
        Me.ViewCasePhones.AllowAdd = false
        Me.ViewCasePhones.AllowEdit = false
        Me.ViewCasePhones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCasePhones.Location = New System.Drawing.Point(0, 0)
        Me.ViewCasePhones.Name = "ViewCasePhones"
        Me.ViewCasePhones.SelectedCase = Nothing
        Me.ViewCasePhones.SelectedPerson = Nothing
        Me.ViewCasePhones.SelectedPhone = Nothing
        Me.ViewCasePhones.Size = New System.Drawing.Size(448, 194)
        Me.ViewCasePhones.TabIndex = 0
        '
        'tabWWW
        '
        Me.tabWWW.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabWWW.Controls.Add(Me.tabEmail)
        Me.tabWWW.Controls.Add(Me.tabSN)
        Me.tabWWW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabWWW.Location = New System.Drawing.Point(0, 0)
        Me.tabWWW.Name = "tabWWW"
        Me.tabWWW.Padding = New System.Drawing.Point(0, 0)
        Me.tabWWW.SelectedIndex = 0
        Me.tabWWW.Size = New System.Drawing.Size(399, 194)
        Me.tabWWW.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabWWW.TabIndex = 1
        '
        'tabEmail
        '
        Me.tabEmail.Controls.Add(Me.ViewCaseEmails)
        Me.tabEmail.Location = New System.Drawing.Point(4, 25)
        Me.tabEmail.Name = "tabEmail"
        Me.tabEmail.Size = New System.Drawing.Size(391, 165)
        Me.tabEmail.TabIndex = 0
        Me.tabEmail.Text = "Emails"
        Me.tabEmail.UseVisualStyleBackColor = true
        '
        'ViewCaseEmails
        '
        Me.ViewCaseEmails.AllowAdd = false
        Me.ViewCaseEmails.AllowEdit = false
        Me.ViewCaseEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseEmails.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseEmails.Name = "ViewCaseEmails"
        Me.ViewCaseEmails.SelectedCase = Nothing
        Me.ViewCaseEmails.SelectedEmail = Nothing
        Me.ViewCaseEmails.SelectedPerson = Nothing
        Me.ViewCaseEmails.Size = New System.Drawing.Size(391, 165)
        Me.ViewCaseEmails.TabIndex = 0
        '
        'tabSN
        '
        Me.tabSN.Controls.Add(Me.ViewCaseSocialNetworks)
        Me.tabSN.Location = New System.Drawing.Point(4, 25)
        Me.tabSN.Name = "tabSN"
        Me.tabSN.Size = New System.Drawing.Size(391, 165)
        Me.tabSN.TabIndex = 1
        Me.tabSN.Text = "Social Networks"
        Me.tabSN.UseVisualStyleBackColor = true
        '
        'ViewCaseSocialNetworks
        '
        Me.ViewCaseSocialNetworks.AllowAdd = false
        Me.ViewCaseSocialNetworks.AllowEdit = false
        Me.ViewCaseSocialNetworks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseSocialNetworks.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseSocialNetworks.Name = "ViewCaseSocialNetworks"
        Me.ViewCaseSocialNetworks.SelectedCase = Nothing
        Me.ViewCaseSocialNetworks.SelectedPerson = Nothing
        Me.ViewCaseSocialNetworks.SelectedSocialNetwork = Nothing
        Me.ViewCaseSocialNetworks.Size = New System.Drawing.Size(391, 165)
        Me.ViewCaseSocialNetworks.TabIndex = 0
        '
        'tabCaseInstruments
        '
        Me.tabCaseInstruments.Controls.Add(Me.SplitContainer4)
        Me.tabCaseInstruments.Location = New System.Drawing.Point(4, 26)
        Me.tabCaseInstruments.Name = "tabCaseInstruments"
        Me.tabCaseInstruments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseInstruments.Size = New System.Drawing.Size(857, 567)
        Me.tabCaseInstruments.TabIndex = 4
        Me.tabCaseInstruments.Text = "Instruments & Documents"
        Me.tabCaseInstruments.UseVisualStyleBackColor = true
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.ViewCaseInstruments)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.ViewCaseDocuments)
        Me.SplitContainer4.Size = New System.Drawing.Size(851, 561)
        Me.SplitContainer4.SplitterDistance = 251
        Me.SplitContainer4.TabIndex = 6
        '
        'ViewCaseInstruments
        '
        Me.ViewCaseInstruments.AllowAdd = false
        Me.ViewCaseInstruments.AllowEdit = false
        Me.ViewCaseInstruments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseInstruments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseInstruments.Name = "ViewCaseInstruments"
        Me.ViewCaseInstruments.SelectedCase = Nothing
        Me.ViewCaseInstruments.SelectedInstrument = Nothing
        Me.ViewCaseInstruments.Size = New System.Drawing.Size(851, 251)
        Me.ViewCaseInstruments.TabIndex = 0
        '
        'ViewCaseDocuments
        '
        Me.ViewCaseDocuments.AllowAdd = false
        Me.ViewCaseDocuments.AllowEdit = false
        Me.ViewCaseDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseDocuments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseDocuments.Name = "ViewCaseDocuments"
        Me.ViewCaseDocuments.SelectedCase = Nothing
        Me.ViewCaseDocuments.SelectedDocument = Nothing
        Me.ViewCaseDocuments.Size = New System.Drawing.Size(851, 306)
        Me.ViewCaseDocuments.TabIndex = 0
        '
        'tabCaseNotes
        '
        Me.tabCaseNotes.Controls.Add(Me.SplitContainer5)
        Me.tabCaseNotes.Location = New System.Drawing.Point(4, 26)
        Me.tabCaseNotes.Name = "tabCaseNotes"
        Me.tabCaseNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseNotes.Size = New System.Drawing.Size(857, 567)
        Me.tabCaseNotes.TabIndex = 3
        Me.tabCaseNotes.Text = "Notes"
        Me.tabCaseNotes.UseVisualStyleBackColor = true
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.ViewConfirmitCallHist)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.ViewCaseNotes)
        Me.SplitContainer5.Size = New System.Drawing.Size(851, 561)
        Me.SplitContainer5.SplitterDistance = 300
        Me.SplitContainer5.TabIndex = 2
        '
        'ViewConfirmitCallHist
        '
        Me.ViewConfirmitCallHist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewConfirmitCallHist.Location = New System.Drawing.Point(0, 0)
        Me.ViewConfirmitCallHist.Name = "ViewConfirmitCallHist"
        Me.ViewConfirmitCallHist.SelectedCase = Nothing
        Me.ViewConfirmitCallHist.SelectedNote = Nothing
        Me.ViewConfirmitCallHist.Size = New System.Drawing.Size(851, 300)
        Me.ViewConfirmitCallHist.TabIndex = 0
        '
        'ViewCaseNotes
        '
        Me.ViewCaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseNotes.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseNotes.Name = "ViewCaseNotes"
        Me.ViewCaseNotes.SelectedCase = Nothing
        Me.ViewCaseNotes.SelectedNote = Nothing
        Me.ViewCaseNotes.Size = New System.Drawing.Size(851, 257)
        Me.ViewCaseNotes.TabIndex = 1
        '
        'tabCaseSup
        '
        Me.tabCaseSup.Controls.Add(Me.EditLocatingStatusSupervisor)
        Me.tabCaseSup.Location = New System.Drawing.Point(4, 26)
        Me.tabCaseSup.Name = "tabCaseSup"
        Me.tabCaseSup.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseSup.Size = New System.Drawing.Size(857, 567)
        Me.tabCaseSup.TabIndex = 5
        Me.tabCaseSup.Text = "Supervisor"
        Me.tabCaseSup.UseVisualStyleBackColor = true
        '
        'EditLocatingStatusSupervisor
        '
        Me.EditLocatingStatusSupervisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditLocatingStatusSupervisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditLocatingStatusSupervisor.LocatingStatus = Nothing
        Me.EditLocatingStatusSupervisor.Location = New System.Drawing.Point(3, 3)
        Me.EditLocatingStatusSupervisor.Name = "EditLocatingStatusSupervisor"
        Me.EditLocatingStatusSupervisor.Size = New System.Drawing.Size(851, 561)
        Me.EditLocatingStatusSupervisor.TabIndex = 0
        '
        'ssCase
        '
        Me.ssCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLocked, Me.tsslCaseID, Me.tsslEntity, Me.tsslStatus, Me.tspbProgress, Me.tsslUser})
        Me.ssCase.Location = New System.Drawing.Point(0, 717)
        Me.ssCase.Name = "ssCase"
        Me.ssCase.ShowItemToolTips = true
        Me.ssCase.Size = New System.Drawing.Size(865, 25)
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
        Me.tsslLocked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsslLocked.Name = "tsslLocked"
        Me.tsslLocked.Size = New System.Drawing.Size(20, 20)
        Me.tsslLocked.ToolTipText = "Case lock status"
        '
        'tsslCaseID
        '
        Me.tsslCaseID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCaseID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslCaseID.Name = "tsslCaseID"
        Me.tsslCaseID.Size = New System.Drawing.Size(683, 20)
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
        Me.tsslEntity.Size = New System.Drawing.Size(67, 20)
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
        Me.tsslStatus.Size = New System.Drawing.Size(43, 20)
        Me.tsslStatus.Text = "Status"
        Me.tsslStatus.ToolTipText = "Case's aggregated status"
        Me.tsslStatus.Visible = false
        '
        'tspbProgress
        '
        Me.tspbProgress.Name = "tspbProgress"
        Me.tspbProgress.Size = New System.Drawing.Size(100, 19)
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
        Me.tsslUser.Size = New System.Drawing.Size(80, 20)
        Me.tsslUser.Text = "Username"
        Me.tsslUser.ToolTipText = "Your user login name"
        '
        'tsCase
        '
        Me.tsCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbLock, Me.tsbSave, Me.tsbClose, Me.ToolStripSeparator3, Me.tsbPriority, Me.ToolStripSeparator2, Me.tslEntityName, Me.txtEntityName})
        Me.tsCase.Location = New System.Drawing.Point(0, 0)
        Me.tsCase.Name = "tsCase"
        Me.tsCase.Size = New System.Drawing.Size(865, 38)
        Me.tsCase.TabIndex = 0
        Me.tsCase.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"),System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(94, 35)
        Me.tsbNew.Text = "New Attempt"
        Me.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbNew.ToolTipText = "New Locating Attempt"
        '
        'tsbLock
        '
        Me.tsbLock.Image = CType(resources.GetObject("tsbLock.Image"),System.Drawing.Image)
        Me.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLock.Name = "tsbLock"
        Me.tsbLock.Size = New System.Drawing.Size(35, 35)
        Me.tsbLock.Text = "Start"
        Me.tsbLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbLock.ToolTipText = "Begin work on this case"
        '
        'tsbSave
        '
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"),System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(35, 35)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSave.ToolTipText = "Save changes made to this case"
        '
        'tsbClose
        '
        Me.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(40, 35)
        Me.tsbClose.Text = "Close"
        Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbClose.ToolTipText = "Close this window"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'tsbPriority
        '
        Me.tsbPriority.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmLowPriority, Me.tsmHighPriority})
        Me.tsbPriority.Image = CType(resources.GetObject("tsbPriority.Image"),System.Drawing.Image)
        Me.tsbPriority.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsbPriority.Name = "tsbPriority"
        Me.tsbPriority.Size = New System.Drawing.Size(61, 35)
        Me.tsbPriority.Text = "Priority"
        Me.tsbPriority.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbPriority.ToolTipText = "Set priority on/off"
        '
        'tsmLowPriority
        '
        Me.tsmLowPriority.Checked = true
        Me.tsmLowPriority.CheckOnClick = true
        Me.tsmLowPriority.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmLowPriority.Image = CType(resources.GetObject("tsmLowPriority.Image"),System.Drawing.Image)
        Me.tsmLowPriority.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsmLowPriority.Name = "tsmLowPriority"
        Me.tsmLowPriority.Size = New System.Drawing.Size(141, 22)
        Me.tsmLowPriority.Text = "Low Priority"
        '
        'tsmHighPriority
        '
        Me.tsmHighPriority.CheckOnClick = true
        Me.tsmHighPriority.Image = CType(resources.GetObject("tsmHighPriority.Image"),System.Drawing.Image)
        Me.tsmHighPriority.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsmHighPriority.Name = "tsmHighPriority"
        Me.tsmHighPriority.Size = New System.Drawing.Size(141, 22)
        Me.tsmHighPriority.Text = "High Priority"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'tslEntityName
        '
        Me.tslEntityName.Name = "tslEntityName"
        Me.tslEntityName.Size = New System.Drawing.Size(68, 35)
        Me.tslEntityName.Text = "Case name:"
        '
        'txtEntityName
        '
        Me.txtEntityName.MaxLength = 50
        Me.txtEntityName.Name = "txtEntityName"
        Me.txtEntityName.Size = New System.Drawing.Size(200, 38)
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imgImages.TransparentColor = System.Drawing.Color.Magenta
        Me.imgImages.Images.SetKeyName(0, "lock-none.bmp")
        Me.imgImages.Images.SetKeyName(1, "lock-owned.bmp")
        Me.imgImages.Images.SetKeyName(2, "lock-unavailable.bmp")
        Me.imgImages.Images.SetKeyName(3, "Locating")
        Me.imgImages.Images.SetKeyName(4, "Internet")
        Me.imgImages.Images.SetKeyName(5, "ChangeCR")
        Me.imgImages.Images.SetKeyName(6, "Document")
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLanguage, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSSN, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDOB, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGender, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRelType, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMPRID, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAge, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 8, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 39)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(857, 33)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = true
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Location = New System.Drawing.Point(757, 17)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(96, 15)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Locating Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(687, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Language"
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = true
        Me.lblLanguage.BackColor = System.Drawing.SystemColors.Control
        Me.lblLanguage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLanguage.Location = New System.Drawing.Point(687, 17)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(63, 15)
        Me.lblLanguage.TabIndex = 13
        Me.lblLanguage.Text = "Language"
        '
        'lblSSN
        '
        Me.lblSSN.AutoSize = true
        Me.lblSSN.BackColor = System.Drawing.SystemColors.Control
        Me.lblSSN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSSN.Location = New System.Drawing.Point(648, 17)
        Me.lblSSN.Name = "lblSSN"
        Me.lblSSN.Size = New System.Drawing.Size(32, 15)
        Me.lblSSN.TabIndex = 12
        Me.lblSSN.Text = "SSN"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = true
        Me.lblDOB.BackColor = System.Drawing.SystemColors.Control
        Me.lblDOB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDOB.Location = New System.Drawing.Point(572, 17)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(33, 15)
        Me.lblDOB.TabIndex = 11
        Me.lblDOB.Text = "DOB"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = true
        Me.lblGender.BackColor = System.Drawing.SystemColors.Control
        Me.lblGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGender.Location = New System.Drawing.Point(517, 17)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(48, 15)
        Me.lblGender.TabIndex = 10
        Me.lblGender.Text = "Gender"
        '
        'lblRelType
        '
        Me.lblRelType.AutoSize = true
        Me.lblRelType.BackColor = System.Drawing.SystemColors.Control
        Me.lblRelType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRelType.Location = New System.Drawing.Point(433, 17)
        Me.lblRelType.Name = "lblRelType"
        Me.lblRelType.Size = New System.Drawing.Size(77, 15)
        Me.lblRelType.TabIndex = 9
        Me.lblRelType.Text = "Relationship"
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.BackColor = System.Drawing.SystemColors.Control
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Location = New System.Drawing.Point(58, 17)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(368, 15)
        Me.lblName.TabIndex = 8
        Me.lblName.Text = "Name"
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = true
        Me.lblMPRID.BackColor = System.Drawing.SystemColors.Control
        Me.lblMPRID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMPRID.Location = New System.Drawing.Point(4, 17)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(47, 15)
        Me.lblMPRID.TabIndex = 7
        Me.lblMPRID.Text = "MPRID"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(648, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "SSN"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(572, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "DOB"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(517, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Gender"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(433, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Relationship"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'lblID
        '
        Me.lblID.AutoSize = true
        Me.lblID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblID.Location = New System.Drawing.Point(4, 1)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(47, 15)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "MPRID"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(612, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Age"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAge
        '
        Me.lblAge.AutoSize = true
        Me.lblAge.BackColor = System.Drawing.SystemColors.Control
        Me.lblAge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAge.Location = New System.Drawing.Point(612, 17)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(29, 15)
        Me.lblAge.TabIndex = 17
        Me.lblAge.Text = "Age"
        Me.lblAge.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(757, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Locating Status"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.lblWebPW, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUsername, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblOrigEmail, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblOrigPhone, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblOrigAddr, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 78)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(857, 33)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'lblWebPW
        '
        Me.lblWebPW.AutoSize = true
        Me.lblWebPW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWebPW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblWebPW.Location = New System.Drawing.Point(761, 17)
        Me.lblWebPW.Name = "lblWebPW"
        Me.lblWebPW.Size = New System.Drawing.Size(92, 15)
        Me.lblWebPW.TabIndex = 13
        Me.lblWebPW.Text = "Password"
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(761, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Web Password"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(661, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Web Username"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = true
        Me.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblUsername.Location = New System.Drawing.Point(661, 17)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(93, 15)
        Me.lblUsername.TabIndex = 10
        Me.lblUsername.Text = "Username"
        '
        'lblOrigEmail
        '
        Me.lblOrigEmail.AutoSize = true
        Me.lblOrigEmail.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrigEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrigEmail.Location = New System.Drawing.Point(437, 17)
        Me.lblOrigEmail.Name = "lblOrigEmail"
        Me.lblOrigEmail.Size = New System.Drawing.Size(217, 15)
        Me.lblOrigEmail.TabIndex = 9
        Me.lblOrigEmail.Text = "Original Email"
        '
        'lblOrigPhone
        '
        Me.lblOrigPhone.AutoSize = true
        Me.lblOrigPhone.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrigPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrigPhone.Location = New System.Drawing.Point(340, 17)
        Me.lblOrigPhone.Name = "lblOrigPhone"
        Me.lblOrigPhone.Size = New System.Drawing.Size(90, 15)
        Me.lblOrigPhone.TabIndex = 8
        Me.lblOrigPhone.Text = "Original Phone"
        '
        'lblOrigAddr
        '
        Me.lblOrigAddr.AutoSize = true
        Me.lblOrigAddr.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrigAddr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrigAddr.Location = New System.Drawing.Point(4, 17)
        Me.lblOrigAddr.Name = "lblOrigAddr"
        Me.lblOrigAddr.Size = New System.Drawing.Size(329, 15)
        Me.lblOrigAddr.TabIndex = 7
        Me.lblOrigAddr.Text = "Original Address"
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label21.Location = New System.Drawing.Point(437, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(217, 15)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Original Email"
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label22.Location = New System.Drawing.Point(340, 1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 15)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Original Phone"
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label23.Location = New System.Drawing.Point(4, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(329, 15)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Original Address"
        '
        'frmLocatingMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 742)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tsCase)
        Me.Controls.Add(Me.ssCase)
        Me.Controls.Add(Me.tabCase)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmLocatingMain"
        Me.Text = "Locate Person"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabCase.ResumeLayout(false)
        Me.tabCaseLocating.ResumeLayout(false)
        Me.tabCaseMembers.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        Me.SplitContainer3.Panel1.ResumeLayout(false)
        Me.SplitContainer3.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer3.ResumeLayout(false)
        Me.tabWWW.ResumeLayout(false)
        Me.tabEmail.ResumeLayout(false)
        Me.tabSN.ResumeLayout(false)
        Me.tabCaseInstruments.ResumeLayout(false)
        Me.SplitContainer4.Panel1.ResumeLayout(false)
        Me.SplitContainer4.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer4,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer4.ResumeLayout(false)
        Me.tabCaseNotes.ResumeLayout(false)
        Me.SplitContainer5.Panel1.ResumeLayout(false)
        Me.SplitContainer5.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer5,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer5.ResumeLayout(false)
        Me.tabCaseSup.ResumeLayout(false)
        Me.ssCase.ResumeLayout(false)
        Me.ssCase.PerformLayout
        Me.tsCase.ResumeLayout(false)
        Me.tsCase.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents tabCase As System.Windows.Forms.TabControl
    Friend WithEvents tabCaseLocating As System.Windows.Forms.TabPage
    Friend WithEvents ssCase As System.Windows.Forms.StatusStrip
    Friend WithEvents tsCase As System.Windows.Forms.ToolStrip
    Friend WithEvents tabCaseNotes As System.Windows.Forms.TabPage
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslCaseID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsslUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslLocked As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslEntity As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tab As System.Windows.Forms.TabPage
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslEntityName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtEntityName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents tabCaseSup As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseInstruments As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseInstruments As MPR.SMS.UserControls.ViewCaseInstruments
    Friend WithEvents ViewCaseDocuments As MPR.SMS.UserControls.ViewCaseDocuments
    Friend WithEvents tsbLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPriority As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsmLowPriority As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmHighPriority As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditLocatingStatusSupervisor As MPR.SMS.UserControls.EditLocatingStatusSupervisor
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents lblSSN As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents lblRelType As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblMPRID As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblOrigEmail As System.Windows.Forms.Label
    Friend WithEvents lblOrigPhone As System.Windows.Forms.Label
    Friend WithEvents lblOrigAddr As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ViewCaseNotes As MPR.SMS.UserControls.ViewCaseNotes
    Friend WithEvents ViewCaseLocatingAttempts As MPR.SMS.UserControls.ViewCaseLocatingAttempts
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tabCaseMembers As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCasePhones As MPR.SMS.UserControls.ViewCasePhones
    Friend WithEvents ViewCaseEmails As MPR.SMS.UserControls.ViewCaseEmails
    Friend WithEvents lblWebPW As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents tabWWW As System.Windows.Forms.TabControl
    Friend WithEvents tabEmail As System.Windows.Forms.TabPage
    Friend WithEvents tabSN As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseSocialNetworks As MPR.SMS.UserControls.ViewCaseSocialNetworks
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewConfirmitCallHist As MPR.SMS.UserControls.ViewConfirmitCallHist
End Class
