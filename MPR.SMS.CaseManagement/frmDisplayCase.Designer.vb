'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDisplayCase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisplayCase))
        Me.tabCase = New System.Windows.Forms.TabControl()
        Me.tabCaseMembers = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.ViewCasePhones = New MPR.SMS.UserControls.ViewCasePhones()
        Me.tabWWW = New System.Windows.Forms.TabControl()
        Me.tabEmails = New System.Windows.Forms.TabPage()
        Me.ViewCaseEmails = New MPR.SMS.UserControls.ViewCaseEmails()
        Me.tabSocialNetworks = New System.Windows.Forms.TabPage()
        Me.ViewCaseSocialNetworks = New MPR.SMS.UserControls.ViewCaseSocialNetworks()
        Me.tabCaseInstruments = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseInstruments = New MPR.SMS.UserControls.ViewCaseInstruments()
        Me.ViewCaseDocuments = New MPR.SMS.UserControls.ViewCaseDocuments()
        Me.tabCaseSampling = New System.Windows.Forms.TabPage()
        Me.EditCaseRA = New MPR.SMS.UserControls.EditCaseRA()
        Me.lblInSampleWarning = New System.Windows.Forms.Label()
        Me.chkIsIneligible = New System.Windows.Forms.CheckBox()
        Me.chkInSample = New System.Windows.Forms.CheckBox()
        Me.txtPSU = New System.Windows.Forms.TextBox()
        Me.lblPSU = New System.Windows.Forms.Label()
        Me.tabCaseNotes = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtCaseNotes = New System.Windows.Forms.TextBox()
        Me.ViewCaseNotes = New MPR.SMS.UserControls.ViewCaseNotes()
        Me.tabCaseStudent = New System.Windows.Forms.TabPage()
        Me.flpStudents = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabCaseClassroom = New System.Windows.Forms.TabPage()
        Me.EditClassroom = New MPR.SMS.UserControls.EditClassroom()
        Me.tabCaseTeacher = New System.Windows.Forms.TabPage()
        Me.EditTeacher = New MPR.SMS.UserControls.EditTeacher()
        Me.tabCaseSchool = New System.Windows.Forms.TabPage()
        Me.EditSchool = New MPR.SMS.UserControls.EditSchool()
        Me.tabCaseDistrict = New System.Windows.Forms.TabPage()
        Me.EditDistrict = New MPR.SMS.UserControls.EditDistrict()
        Me.tabCaseSite = New System.Windows.Forms.TabPage()
        Me.EditSite = New MPR.SMS.UserControls.EditSite()
        Me.ssCase = New System.Windows.Forms.StatusStrip()
        Me.tsslLocked = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCaseID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslEntity = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsCase = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslEntityName = New System.Windows.Forms.ToolStripLabel()
        Me.txtEntityName = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tab = New System.Windows.Forms.TabPage()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.StudentValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.ClassroomValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.TeacherValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.CaseRAValidator = New MPR.Windows.Forms.Validation.ContainerValidator()
        Me.tabCase.SuspendLayout()
        Me.tabCaseMembers.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.tabWWW.SuspendLayout()
        Me.tabEmails.SuspendLayout()
        Me.tabSocialNetworks.SuspendLayout()
        Me.tabCaseInstruments.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.tabCaseSampling.SuspendLayout()
        Me.tabCaseNotes.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.tabCaseStudent.SuspendLayout()
        Me.tabCaseClassroom.SuspendLayout()
        Me.tabCaseTeacher.SuspendLayout()
        Me.tabCaseSchool.SuspendLayout()
        Me.tabCaseDistrict.SuspendLayout()
        Me.tabCaseSite.SuspendLayout()
        Me.ssCase.SuspendLayout()
        Me.tsCase.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCase
        '
        Me.tabCase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCase.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabCase.Controls.Add(Me.tabCaseMembers)
        Me.tabCase.Controls.Add(Me.tabCaseInstruments)
        Me.tabCase.Controls.Add(Me.tabCaseSampling)
        Me.tabCase.Controls.Add(Me.tabCaseNotes)
        Me.tabCase.Controls.Add(Me.tabCaseStudent)
        Me.tabCase.Controls.Add(Me.tabCaseClassroom)
        Me.tabCase.Controls.Add(Me.tabCaseTeacher)
        Me.tabCase.Controls.Add(Me.tabCaseSchool)
        Me.tabCase.Controls.Add(Me.tabCaseDistrict)
        Me.tabCase.Controls.Add(Me.tabCaseSite)
        Me.tabCase.ItemSize = New System.Drawing.Size(150, 21)
        Me.tabCase.Location = New System.Drawing.Point(0, 39)
        Me.tabCase.Multiline = True
        Me.tabCase.Name = "tabCase"
        Me.tabCase.SelectedIndex = 0
        Me.tabCase.Size = New System.Drawing.Size(923, 686)
        Me.tabCase.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabCase.TabIndex = 1
        '
        'tabCaseMembers
        '
        Me.tabCaseMembers.Controls.Add(Me.SplitContainer1)
        Me.tabCaseMembers.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseMembers.Name = "tabCaseMembers"
        Me.tabCaseMembers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseMembers.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseMembers.TabIndex = 0
        Me.tabCaseMembers.Text = "Members"
        Me.tabCaseMembers.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Size = New System.Drawing.Size(909, 627)
        Me.SplitContainer1.SplitterDistance = 203
        Me.SplitContainer1.TabIndex = 1
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.AllowAdd = False
        Me.ViewCaseMembers.AllowEdit = False
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.Size = New System.Drawing.Size(909, 203)
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(909, 420)
        Me.SplitContainer2.SplitterDistance = 200
        Me.SplitContainer2.TabIndex = 0
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.AllowAdd = False
        Me.ViewCaseAddresses.AllowEdit = False
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(909, 200)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.ViewCasePhones)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.tabWWW)
        Me.SplitContainer4.Size = New System.Drawing.Size(909, 216)
        Me.SplitContainer4.SplitterDistance = 470
        Me.SplitContainer4.TabIndex = 0
        '
        'ViewCasePhones
        '
        Me.ViewCasePhones.AllowAdd = False
        Me.ViewCasePhones.AllowEdit = False
        Me.ViewCasePhones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCasePhones.Location = New System.Drawing.Point(0, 0)
        Me.ViewCasePhones.Name = "ViewCasePhones"
        Me.ViewCasePhones.SelectedCase = Nothing
        Me.ViewCasePhones.SelectedPerson = Nothing
        Me.ViewCasePhones.SelectedPhone = Nothing
        Me.ViewCasePhones.Size = New System.Drawing.Size(470, 216)
        Me.ViewCasePhones.TabIndex = 0
        '
        'tabWWW
        '
        Me.tabWWW.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabWWW.Controls.Add(Me.tabEmails)
        Me.tabWWW.Controls.Add(Me.tabSocialNetworks)
        Me.tabWWW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabWWW.ItemSize = New System.Drawing.Size(90, 22)
        Me.tabWWW.Location = New System.Drawing.Point(0, 0)
        Me.tabWWW.Multiline = True
        Me.tabWWW.Name = "tabWWW"
        Me.tabWWW.Padding = New System.Drawing.Point(0, 0)
        Me.tabWWW.SelectedIndex = 0
        Me.tabWWW.Size = New System.Drawing.Size(435, 216)
        Me.tabWWW.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabWWW.TabIndex = 1
        '
        'tabEmails
        '
        Me.tabEmails.Controls.Add(Me.ViewCaseEmails)
        Me.tabEmails.Location = New System.Drawing.Point(4, 26)
        Me.tabEmails.Name = "tabEmails"
        Me.tabEmails.Size = New System.Drawing.Size(427, 186)
        Me.tabEmails.TabIndex = 0
        Me.tabEmails.Text = "Emails"
        Me.tabEmails.UseVisualStyleBackColor = True
        '
        'ViewCaseEmails
        '
        Me.ViewCaseEmails.AllowAdd = False
        Me.ViewCaseEmails.AllowEdit = False
        Me.ViewCaseEmails.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCaseEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseEmails.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseEmails.Name = "ViewCaseEmails"
        Me.ViewCaseEmails.SelectedCase = Nothing
        Me.ViewCaseEmails.SelectedEmail = Nothing
        Me.ViewCaseEmails.SelectedPerson = Nothing
        Me.ViewCaseEmails.Size = New System.Drawing.Size(427, 186)
        Me.ViewCaseEmails.TabIndex = 0
        '
        'tabSocialNetworks
        '
        Me.tabSocialNetworks.Controls.Add(Me.ViewCaseSocialNetworks)
        Me.tabSocialNetworks.Location = New System.Drawing.Point(4, 26)
        Me.tabSocialNetworks.Name = "tabSocialNetworks"
        Me.tabSocialNetworks.Size = New System.Drawing.Size(427, 186)
        Me.tabSocialNetworks.TabIndex = 1
        Me.tabSocialNetworks.Text = "Social Networks"
        Me.tabSocialNetworks.UseVisualStyleBackColor = True
        '
        'ViewCaseSocialNetworks
        '
        Me.ViewCaseSocialNetworks.AllowAdd = False
        Me.ViewCaseSocialNetworks.AllowEdit = False
        Me.ViewCaseSocialNetworks.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCaseSocialNetworks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseSocialNetworks.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseSocialNetworks.Name = "ViewCaseSocialNetworks"
        Me.ViewCaseSocialNetworks.SelectedCase = Nothing
        Me.ViewCaseSocialNetworks.SelectedPerson = Nothing
        Me.ViewCaseSocialNetworks.SelectedSocialNetwork = Nothing
        Me.ViewCaseSocialNetworks.Size = New System.Drawing.Size(427, 186)
        Me.ViewCaseSocialNetworks.TabIndex = 0
        '
        'tabCaseInstruments
        '
        Me.tabCaseInstruments.Controls.Add(Me.SplitContainer3)
        Me.tabCaseInstruments.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseInstruments.Name = "tabCaseInstruments"
        Me.tabCaseInstruments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseInstruments.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseInstruments.TabIndex = 1
        Me.tabCaseInstruments.Text = "Instruments && Documents"
        Me.tabCaseInstruments.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
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
        Me.SplitContainer3.Size = New System.Drawing.Size(909, 627)
        Me.SplitContainer3.SplitterDistance = 275
        Me.SplitContainer3.TabIndex = 5
        '
        'ViewCaseInstruments
        '
        Me.ViewCaseInstruments.AllowAdd = False
        Me.ViewCaseInstruments.AllowEdit = False
        Me.ViewCaseInstruments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseInstruments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseInstruments.Name = "ViewCaseInstruments"
        Me.ViewCaseInstruments.SelectedCase = Nothing
        Me.ViewCaseInstruments.SelectedInstrument = Nothing
        Me.ViewCaseInstruments.Size = New System.Drawing.Size(909, 275)
        Me.ViewCaseInstruments.TabIndex = 0
        '
        'ViewCaseDocuments
        '
        Me.ViewCaseDocuments.AllowAdd = False
        Me.ViewCaseDocuments.AllowEdit = False
        Me.ViewCaseDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseDocuments.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseDocuments.Name = "ViewCaseDocuments"
        Me.ViewCaseDocuments.SelectedCase = Nothing
        Me.ViewCaseDocuments.SelectedDocument = Nothing
        Me.ViewCaseDocuments.Size = New System.Drawing.Size(909, 348)
        Me.ViewCaseDocuments.TabIndex = 0
        '
        'tabCaseSampling
        '
        Me.tabCaseSampling.Controls.Add(Me.EditCaseRA)
        Me.tabCaseSampling.Controls.Add(Me.lblInSampleWarning)
        Me.tabCaseSampling.Controls.Add(Me.chkIsIneligible)
        Me.tabCaseSampling.Controls.Add(Me.chkInSample)
        Me.tabCaseSampling.Controls.Add(Me.txtPSU)
        Me.tabCaseSampling.Controls.Add(Me.lblPSU)
        Me.tabCaseSampling.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseSampling.Name = "tabCaseSampling"
        Me.tabCaseSampling.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseSampling.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseSampling.TabIndex = 2
        Me.tabCaseSampling.Text = "Sampling"
        Me.tabCaseSampling.UseVisualStyleBackColor = True
        '
        'EditCaseRA
        '
        Me.EditCaseRA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditCaseRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditCaseRA.CaseRA = Nothing
        Me.EditCaseRA.Location = New System.Drawing.Point(10, 49)
        Me.EditCaseRA.Name = "EditCaseRA"
        Me.EditCaseRA.Size = New System.Drawing.Size(462, 590)
        Me.EditCaseRA.TabIndex = 6
        '
        'lblInSampleWarning
        '
        Me.lblInSampleWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInSampleWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblInSampleWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInSampleWarning.Location = New System.Drawing.Point(303, 8)
        Me.lblInSampleWarning.Name = "lblInSampleWarning"
        Me.lblInSampleWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblInSampleWarning.Size = New System.Drawing.Size(169, 33)
        Me.lblInSampleWarning.TabIndex = 5
        Me.lblInSampleWarning.Text = "Note: Changing the ""In Sample"" or ""Ineligible"" flags on the case level will also " & _
    "change them for each member of this case."
        Me.lblInSampleWarning.Visible = False
        '
        'chkIsIneligible
        '
        Me.chkIsIneligible.AutoSize = True
        Me.chkIsIneligible.Location = New System.Drawing.Point(216, 12)
        Me.chkIsIneligible.Name = "chkIsIneligible"
        Me.chkIsIneligible.Size = New System.Drawing.Size(73, 17)
        Me.chkIsIneligible.TabIndex = 3
        Me.chkIsIneligible.Text = "Ineligible?"
        Me.chkIsIneligible.UseVisualStyleBackColor = True
        '
        'chkInSample
        '
        Me.chkInSample.AutoSize = True
        Me.chkInSample.Location = New System.Drawing.Point(132, 12)
        Me.chkInSample.Name = "chkInSample"
        Me.chkInSample.Size = New System.Drawing.Size(79, 17)
        Me.chkInSample.TabIndex = 2
        Me.chkInSample.Text = "In Sample?"
        Me.chkInSample.UseVisualStyleBackColor = True
        '
        'txtPSU
        '
        Me.txtPSU.Location = New System.Drawing.Point(59, 12)
        Me.txtPSU.MaxLength = 6
        Me.txtPSU.Name = "txtPSU"
        Me.txtPSU.Size = New System.Drawing.Size(48, 20)
        Me.txtPSU.TabIndex = 1
        '
        'lblPSU
        '
        Me.lblPSU.AutoSize = True
        Me.lblPSU.Location = New System.Drawing.Point(21, 12)
        Me.lblPSU.Name = "lblPSU"
        Me.lblPSU.Size = New System.Drawing.Size(32, 13)
        Me.lblPSU.TabIndex = 0
        Me.lblPSU.Text = "PSU:"
        '
        'tabCaseNotes
        '
        Me.tabCaseNotes.Controls.Add(Me.SplitContainer5)
        Me.tabCaseNotes.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseNotes.Name = "tabCaseNotes"
        Me.tabCaseNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseNotes.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseNotes.TabIndex = 3
        Me.tabCaseNotes.Text = "Notes"
        Me.tabCaseNotes.UseVisualStyleBackColor = True
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
        Me.SplitContainer5.Panel1.Controls.Add(Me.lblNotes)
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtCaseNotes)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.ViewCaseNotes)
        Me.SplitContainer5.Size = New System.Drawing.Size(909, 627)
        Me.SplitContainer5.SplitterDistance = 181
        Me.SplitContainer5.TabIndex = 0
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(5, 4)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(63, 13)
        Me.lblNotes.TabIndex = 0
        Me.lblNotes.Text = "Case notes:"
        '
        'txtCaseNotes
        '
        Me.txtCaseNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaseNotes.Location = New System.Drawing.Point(3, 22)
        Me.txtCaseNotes.MaxLength = 2000
        Me.txtCaseNotes.Multiline = True
        Me.txtCaseNotes.Name = "txtCaseNotes"
        Me.txtCaseNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCaseNotes.Size = New System.Drawing.Size(901, 156)
        Me.txtCaseNotes.TabIndex = 1
        '
        'ViewCaseNotes
        '
        Me.ViewCaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseNotes.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseNotes.Name = "ViewCaseNotes"
        Me.ViewCaseNotes.SelectedCase = Nothing
        Me.ViewCaseNotes.SelectedNote = Nothing
        Me.ViewCaseNotes.Size = New System.Drawing.Size(909, 442)
        Me.ViewCaseNotes.TabIndex = 0
        '
        'tabCaseStudent
        '
        Me.tabCaseStudent.Controls.Add(Me.flpStudents)
        Me.tabCaseStudent.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseStudent.Name = "tabCaseStudent"
        Me.tabCaseStudent.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseStudent.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseStudent.TabIndex = 4
        Me.tabCaseStudent.Text = "Student(s)"
        Me.tabCaseStudent.UseVisualStyleBackColor = True
        '
        'flpStudents
        '
        Me.flpStudents.AccessibleName = ""
        Me.flpStudents.AutoScroll = True
        Me.flpStudents.BackColor = System.Drawing.SystemColors.Control
        Me.flpStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpStudents.Location = New System.Drawing.Point(3, 3)
        Me.flpStudents.Name = "flpStudents"
        Me.flpStudents.Size = New System.Drawing.Size(909, 627)
        Me.flpStudents.TabIndex = 1
        '
        'tabCaseClassroom
        '
        Me.tabCaseClassroom.Controls.Add(Me.EditClassroom)
        Me.tabCaseClassroom.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseClassroom.Name = "tabCaseClassroom"
        Me.tabCaseClassroom.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseClassroom.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseClassroom.TabIndex = 5
        Me.tabCaseClassroom.Text = "Classroom"
        Me.tabCaseClassroom.UseVisualStyleBackColor = True
        '
        'EditClassroom
        '
        Me.EditClassroom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditClassroom.Classroom = Nothing
        Me.EditClassroom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditClassroom.Location = New System.Drawing.Point(3, 3)
        Me.EditClassroom.Name = "EditClassroom"
        Me.EditClassroom.Size = New System.Drawing.Size(909, 627)
        Me.EditClassroom.TabIndex = 0
        '
        'tabCaseTeacher
        '
        Me.tabCaseTeacher.Controls.Add(Me.EditTeacher)
        Me.tabCaseTeacher.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseTeacher.Name = "tabCaseTeacher"
        Me.tabCaseTeacher.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseTeacher.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseTeacher.TabIndex = 6
        Me.tabCaseTeacher.Text = "Teacher"
        Me.tabCaseTeacher.UseVisualStyleBackColor = True
        '
        'EditTeacher
        '
        Me.EditTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditTeacher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditTeacher.Location = New System.Drawing.Point(3, 3)
        Me.EditTeacher.Name = "EditTeacher"
        Me.EditTeacher.Size = New System.Drawing.Size(909, 627)
        Me.EditTeacher.TabIndex = 0
        Me.EditTeacher.Teacher = Nothing
        '
        'tabCaseSchool
        '
        Me.tabCaseSchool.Controls.Add(Me.EditSchool)
        Me.tabCaseSchool.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseSchool.Name = "tabCaseSchool"
        Me.tabCaseSchool.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseSchool.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseSchool.TabIndex = 7
        Me.tabCaseSchool.Text = "School"
        Me.tabCaseSchool.UseVisualStyleBackColor = True
        '
        'EditSchool
        '
        Me.EditSchool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditSchool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditSchool.Location = New System.Drawing.Point(3, 3)
        Me.EditSchool.Name = "EditSchool"
        Me.EditSchool.School = Nothing
        Me.EditSchool.Size = New System.Drawing.Size(909, 627)
        Me.EditSchool.TabIndex = 0
        '
        'tabCaseDistrict
        '
        Me.tabCaseDistrict.Controls.Add(Me.EditDistrict)
        Me.tabCaseDistrict.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseDistrict.Name = "tabCaseDistrict"
        Me.tabCaseDistrict.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseDistrict.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseDistrict.TabIndex = 8
        Me.tabCaseDistrict.Text = "District"
        Me.tabCaseDistrict.UseVisualStyleBackColor = True
        '
        'EditDistrict
        '
        Me.EditDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditDistrict.District = Nothing
        Me.EditDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditDistrict.Location = New System.Drawing.Point(3, 3)
        Me.EditDistrict.Name = "EditDistrict"
        Me.EditDistrict.Size = New System.Drawing.Size(909, 627)
        Me.EditDistrict.TabIndex = 0
        '
        'tabCaseSite
        '
        Me.tabCaseSite.Controls.Add(Me.EditSite)
        Me.tabCaseSite.Location = New System.Drawing.Point(4, 49)
        Me.tabCaseSite.Name = "tabCaseSite"
        Me.tabCaseSite.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCaseSite.Size = New System.Drawing.Size(915, 633)
        Me.tabCaseSite.TabIndex = 9
        Me.tabCaseSite.Text = "Site"
        Me.tabCaseSite.UseVisualStyleBackColor = True
        '
        'EditSite
        '
        Me.EditSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditSite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditSite.Location = New System.Drawing.Point(3, 3)
        Me.EditSite.Name = "EditSite"
        Me.EditSite.Site = Nothing
        Me.EditSite.Size = New System.Drawing.Size(909, 627)
        Me.EditSite.TabIndex = 0
        '
        'ssCase
        '
        Me.ssCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLocked, Me.tsslCaseID, Me.tsslEntity, Me.tsslStatus, Me.tspbProgress, Me.tsslUser})
        Me.ssCase.Location = New System.Drawing.Point(0, 725)
        Me.ssCase.Name = "ssCase"
        Me.ssCase.ShowItemToolTips = True
        Me.ssCase.Size = New System.Drawing.Size(923, 25)
        Me.ssCase.TabIndex = 3
        Me.ssCase.Text = "StatusStrip1"
        '
        'tsslLocked
        '
        Me.tsslLocked.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslLocked.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslLocked.Image = CType(resources.GetObject("tsslLocked.Image"), System.Drawing.Image)
        Me.tsslLocked.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.tsslLocked.Name = "tsslLocked"
        Me.tsslLocked.Size = New System.Drawing.Size(20, 20)
        Me.tsslLocked.ToolTipText = "Case lock status"
        '
        'tsslCaseID
        '
        Me.tsslCaseID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCaseID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslCaseID.Name = "tsslCaseID"
        Me.tsslCaseID.Size = New System.Drawing.Size(741, 20)
        Me.tsslCaseID.Spring = True
        Me.tsslCaseID.Text = "Case ID:"
        Me.tsslCaseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslCaseID.ToolTipText = "Case ID"
        '
        'tsslEntity
        '
        Me.tsslEntity.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEntity.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslEntity.Name = "tsslEntity"
        Me.tsslEntity.Size = New System.Drawing.Size(67, 20)
        Me.tsslEntity.Text = "EntityType"
        Me.tsslEntity.ToolTipText = "Case type"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(43, 20)
        Me.tsslStatus.Text = "Status"
        Me.tsslStatus.ToolTipText = "Case's aggregated status"
        Me.tsslStatus.Visible = False
        '
        'tspbProgress
        '
        Me.tspbProgress.Name = "tspbProgress"
        Me.tspbProgress.Size = New System.Drawing.Size(100, 19)
        Me.tspbProgress.Visible = False
        '
        'tsslUser
        '
        Me.tsslUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslUser.Image = CType(resources.GetObject("tsslUser.Image"), System.Drawing.Image)
        Me.tsslUser.ImageTransparentColor = System.Drawing.Color.Silver
        Me.tsslUser.Name = "tsslUser"
        Me.tsslUser.Size = New System.Drawing.Size(80, 20)
        Me.tsslUser.Text = "Username"
        Me.tsslUser.ToolTipText = "Your user login name"
        '
        'tsCase
        '
        Me.tsCase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.ToolStripSeparator1, Me.tsbSave, Me.tsbSearch, Me.tsbDelete, Me.tsbClose, Me.ToolStripSeparator2, Me.tslEntityName, Me.txtEntityName, Me.ToolStripSeparator3})
        Me.tsCase.Location = New System.Drawing.Point(0, 0)
        Me.tsCase.Name = "tsCase"
        Me.tsCase.Size = New System.Drawing.Size(923, 38)
        Me.tsCase.TabIndex = 0
        Me.tsCase.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(44, 35)
        Me.tsbNew.Text = "New"
        Me.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbNew.ToolTipText = "Create new case"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'tsbSave
        '
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(35, 35)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSave.ToolTipText = "Save changes made to this case"
        '
        'tsbSearch
        '
        Me.tsbSearch.Image = CType(resources.GetObject("tsbSearch.Image"), System.Drawing.Image)
        Me.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearch.Name = "tsbSearch"
        Me.tsbSearch.Size = New System.Drawing.Size(46, 35)
        Me.tsbSearch.Text = "Search"
        Me.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSearch.ToolTipText = "Search for new case"
        '
        'tsbDelete
        '
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(44, 35)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbDelete.ToolTipText = "Delete this case"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
        Me.tab.UseVisualStyleBackColor = True
        '
        'StudentValidator
        '
        Me.StudentValidator.ContainerToValidate = Me.tabCaseStudent
        Me.StudentValidator.HostingForm = Me
        '
        'ClassroomValidator
        '
        Me.ClassroomValidator.ContainerToValidate = Me.tabCaseClassroom
        Me.ClassroomValidator.HostingForm = Me
        '
        'TeacherValidator
        '
        Me.TeacherValidator.ContainerToValidate = Me.tabCaseTeacher
        Me.TeacherValidator.HostingForm = Me
        '
        'CaseRAValidator
        '
        Me.CaseRAValidator.ContainerToValidate = Me.tabCaseSampling
        Me.CaseRAValidator.HostingForm = Me
        '
        'frmDisplayCase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 750)
        Me.Controls.Add(Me.tsCase)
        Me.Controls.Add(Me.ssCase)
        Me.Controls.Add(Me.tabCase)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDisplayCase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Case"
        Me.tabCase.ResumeLayout(False)
        Me.tabCaseMembers.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.tabWWW.ResumeLayout(False)
        Me.tabEmails.ResumeLayout(False)
        Me.tabSocialNetworks.ResumeLayout(False)
        Me.tabCaseInstruments.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.tabCaseSampling.ResumeLayout(False)
        Me.tabCaseSampling.PerformLayout()
        Me.tabCaseNotes.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.tabCaseStudent.ResumeLayout(False)
        Me.tabCaseClassroom.ResumeLayout(False)
        Me.tabCaseTeacher.ResumeLayout(False)
        Me.tabCaseSchool.ResumeLayout(False)
        Me.tabCaseDistrict.ResumeLayout(False)
        Me.tabCaseSite.ResumeLayout(False)
        Me.ssCase.ResumeLayout(False)
        Me.ssCase.PerformLayout()
        Me.tsCase.ResumeLayout(False)
        Me.tsCase.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabCase As System.Windows.Forms.TabControl
    Friend WithEvents tabCaseMembers As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseInstruments As System.Windows.Forms.TabPage
    Friend WithEvents ssCase As System.Windows.Forms.StatusStrip
    Friend WithEvents tsCase As System.Windows.Forms.ToolStrip
    Friend WithEvents tabCaseNotes As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseStudent As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsslCaseID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsslUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslLocked As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslEntity As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents chkIsIneligible As System.Windows.Forms.CheckBox
    Friend WithEvents chkInSample As System.Windows.Forms.CheckBox
    Friend WithEvents lblPSU As System.Windows.Forms.Label
    Friend WithEvents txtPSU As System.Windows.Forms.TextBox
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ViewCaseInstruments As MPR.SMS.UserControls.ViewCaseInstruments
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseDocuments As MPR.SMS.UserControls.ViewCaseDocuments
    Friend WithEvents tabCaseClassroom As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseTeacher As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseSchool As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseSite As System.Windows.Forms.TabPage
    Friend WithEvents tab As System.Windows.Forms.TabPage
    Friend WithEvents tabCaseSampling As System.Windows.Forms.TabPage
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslEntityName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtEntityName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblInSampleWarning As System.Windows.Forms.Label
    Friend WithEvents EditTeacher As MPR.SMS.UserControls.EditTeacher
    Friend WithEvents tabCaseDistrict As System.Windows.Forms.TabPage
    Friend WithEvents EditSite As MPR.SMS.UserControls.EditSite
    Friend WithEvents EditDistrict As MPR.SMS.UserControls.EditDistrict
    Friend WithEvents EditSchool As MPR.SMS.UserControls.EditSchool
    Friend WithEvents EditClassroom As MPR.SMS.UserControls.EditClassroom
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents flpStudents As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents StudentValidator As MPR.Windows.Forms.Validation.ContainerValidator
    Friend WithEvents ClassroomValidator As MPR.Windows.Forms.Validation.ContainerValidator
    Friend WithEvents TeacherValidator As MPR.Windows.Forms.Validation.ContainerValidator
    Friend WithEvents EditCaseRA As MPR.SMS.UserControls.EditCaseRA
    Friend WithEvents CaseRAValidator As MPR.Windows.Forms.Validation.ContainerValidator
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCasePhones As MPR.SMS.UserControls.ViewCasePhones
    Friend WithEvents ViewCaseEmails As MPR.SMS.UserControls.ViewCaseEmails
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtCaseNotes As System.Windows.Forms.TextBox
    Friend WithEvents ViewCaseNotes As MPR.SMS.UserControls.ViewCaseNotes
    Friend WithEvents tabWWW As System.Windows.Forms.TabControl
    Friend WithEvents tabEmails As System.Windows.Forms.TabPage
    Friend WithEvents tabSocialNetworks As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseSocialNetworks As MPR.SMS.UserControls.ViewCaseSocialNetworks
End Class
