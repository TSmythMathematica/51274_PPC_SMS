'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSMSMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMSMain))
        Me.ctxCase = New System.Windows.Forms.ContextMenu()
        Me.mnuCaseOpen = New System.Windows.Forms.MenuItem()
        Me.mnuCaseOpenMPRID = New System.Windows.Forms.MenuItem()
        Me.mnuCaseOpenPhone = New System.Windows.Forms.MenuItem()
        Me.mnuCaseAdd = New System.Windows.Forms.MenuItem()
        Me.mnuAddEntity = New System.Windows.Forms.MenuItem()
        Me.mnuCaseUpdate = New System.Windows.Forms.MenuItem()
        Me.mnuSep4 = New System.Windows.Forms.MenuItem()
        Me.mnuCaseAddStudents = New System.Windows.Forms.MenuItem()
        Me.mnuCaseLookup = New System.Windows.Forms.MenuItem()
        Me.mnuSep5 = New System.Windows.Forms.MenuItem()
        Me.mnuFieldManagement = New System.Windows.Forms.MenuItem()
        Me.mnuRandomAssignment = New System.Windows.Forms.MenuItem()
        Me.ctxDocProcessing = New System.Windows.Forms.ContextMenu()
        Me.mnuDocRelease = New System.Windows.Forms.MenuItem()
        Me.mnuDocQueue = New System.Windows.Forms.MenuItem()
        Me.mnuSep3 = New System.Windows.Forms.MenuItem()
        Me.mnuDocReceipt = New System.Windows.Forms.MenuItem()
        Me.mnuDocQueries = New System.Windows.Forms.MenuItem()
        Me.mnuDocBatch = New System.Windows.Forms.MenuItem()
        Me.mnuDocDiscrep = New System.Windows.Forms.MenuItem()
        Me.ctxLocating = New System.Windows.Forms.ContextMenu()
        Me.mnuLocatingSelect = New System.Windows.Forms.MenuItem()
        Me.mnuLocatingCallIns = New System.Windows.Forms.MenuItem()
        Me.mnuSep1 = New System.Windows.Forms.MenuItem()
        Me.mnuLocatingSupervisorReview = New System.Windows.Forms.MenuItem()
        Me.mnuLocatingSupervisorReports = New System.Windows.Forms.MenuItem()
        Me.ctxAdmin = New System.Windows.Forms.ContextMenu()
        Me.mnuAdminCaseLocks = New System.Windows.Forms.MenuItem()
        Me.mnuAdminTables = New System.Windows.Forms.MenuItem()
        Me.mnuAdminLookup = New System.Windows.Forms.MenuItem()
        Me.mnuAdminLookupAdd = New System.Windows.Forms.MenuItem()
        Me.mnuAdminLookupUpdate = New System.Windows.Forms.MenuItem()
        Me.mnuAdminStatus = New System.Windows.Forms.MenuItem()
        Me.mnuSep2 = New System.Windows.Forms.MenuItem()
        Me.mnuAdminImport = New System.Windows.Forms.MenuItem()
        Me.mnuBatchClean = New System.Windows.Forms.MenuItem()
        Me.mnuAdminDQWS = New System.Windows.Forms.MenuItem()
        Me.mnuAdminMgmt = New System.Windows.Forms.MenuItem()
        Me.mnuAdminReports = New System.Windows.Forms.MenuItem()
        Me.mnuAdminSurveySettings = New System.Windows.Forms.MenuItem()
        Me.mnuAdminTCPALookup = New System.Windows.Forms.MenuItem()
        Me.btnCase = New System.Windows.Forms.Button()
        Me.imlSMSMain = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDocProcessing = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnLocating = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.btnPayProcessing = New System.Windows.Forms.Button()
        Me.ctxPayments = New System.Windows.Forms.ContextMenu()
        Me.mnuPaymentAddressReview = New System.Windows.Forms.MenuItem()
        Me.mnuPaymentReissues = New System.Windows.Forms.MenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSRDEE = New System.Windows.Forms.Button()
        Me.ctxSRDEE = New System.Windows.Forms.ContextMenu()
        Me.mnuAddUpdateVariables = New System.Windows.Forms.MenuItem()
        Me.mnuSep19 = New System.Windows.Forms.MenuItem()
        Me.mnuUpdateSRDEE = New System.Windows.Forms.MenuItem()
        Me.mnuAddInstrumentTypes = New System.Windows.Forms.MenuItem()
        Me.mnuViewSRDEE = New System.Windows.Forms.MenuItem()
        Me.mnuAddInstrumentTypesForView = New System.Windows.Forms.MenuItem()
        Me.mnuCompareSRDEE = New System.Windows.Forms.MenuItem()
        Me.mnuAddInstrumentTypesForCompare = New System.Windows.Forms.MenuItem()
        Me.lblValue = New System.Windows.Forms.Label()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ctxCase
        '
        Me.ctxCase.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCaseOpen, Me.mnuCaseAdd, Me.mnuCaseUpdate, Me.mnuSep4, Me.mnuCaseAddStudents, Me.mnuCaseLookup, Me.mnuSep5, Me.mnuFieldManagement, Me.mnuRandomAssignment})
        '
        'mnuCaseOpen
        '
        Me.mnuCaseOpen.Index = 0
        Me.mnuCaseOpen.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCaseOpenMPRID, Me.mnuCaseOpenPhone})
        Me.mnuCaseOpen.Text = "Open Case"
        '
        'mnuCaseOpenMPRID
        '
        Me.mnuCaseOpenMPRID.Index = 0
        Me.mnuCaseOpenMPRID.Text = "MPRID"
        '
        'mnuCaseOpenPhone
        '
        Me.mnuCaseOpenPhone.Index = 1
        Me.mnuCaseOpenPhone.Text = "Phone Number"
        '
        'mnuCaseAdd
        '
        Me.mnuCaseAdd.Index = 1
        Me.mnuCaseAdd.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddEntity})
        Me.mnuCaseAdd.Text = "&Add New Case"
        '
        'mnuAddEntity
        '
        Me.mnuAddEntity.Index = 0
        Me.mnuAddEntity.Text = "Entity Types"
        '
        'mnuCaseUpdate
        '
        Me.mnuCaseUpdate.Index = 2
        Me.mnuCaseUpdate.Text = "&Update Case..."
        '
        'mnuSep4
        '
        Me.mnuSep4.Index = 3
        Me.mnuSep4.Text = "-"
        '
        'mnuCaseAddStudents
        '
        Me.mnuCaseAddStudents.Index = 4
        Me.mnuCaseAddStudents.Text = "Add &Students"
        '
        'mnuCaseLookup
        '
        Me.mnuCaseLookup.Index = 5
        Me.mnuCaseLookup.Text = "&Look-up Cases (read-only)..."
        '
        'mnuSep5
        '
        Me.mnuSep5.Index = 6
        Me.mnuSep5.Text = "-"
        '
        'mnuFieldManagement
        '
        Me.mnuFieldManagement.Index = 7
        Me.mnuFieldManagement.Text = "Field Management"
        '
        'mnuRandomAssignment
        '
        Me.mnuRandomAssignment.Index = 8
        Me.mnuRandomAssignment.Text = "&Random Assignment"
        Me.mnuRandomAssignment.Visible = False
        '
        'ctxDocProcessing
        '
        Me.ctxDocProcessing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDocRelease, Me.mnuDocQueue, Me.mnuSep3, Me.mnuDocReceipt, Me.mnuDocQueries, Me.mnuDocBatch, Me.mnuDocDiscrep})
        '
        'mnuDocRelease
        '
        Me.mnuDocRelease.Index = 0
        Me.mnuDocRelease.Text = "Release &Documents"
        '
        'mnuDocQueue
        '
        Me.mnuDocQueue.Index = 1
        Me.mnuDocQueue.Text = "Document &Queue"
        '
        'mnuSep3
        '
        Me.mnuSep3.Index = 2
        Me.mnuSep3.Text = "-"
        '
        'mnuDocReceipt
        '
        Me.mnuDocReceipt.Index = 3
        Me.mnuDocReceipt.Text = "&Receipting, Statusing && Batching"
        '
        'mnuDocQueries
        '
        Me.mnuDocQueries.Index = 4
        Me.mnuDocQueries.Text = "Queries"
        '
        'mnuDocBatch
        '
        Me.mnuDocBatch.Enabled = False
        Me.mnuDocBatch.Index = 5
        Me.mnuDocBatch.Text = "Edit &Batches"
        Me.mnuDocBatch.Visible = False
        '
        'mnuDocDiscrep
        '
        Me.mnuDocDiscrep.Index = 6
        Me.mnuDocDiscrep.Text = "&Confirmit Discrepancy Report"
        '
        'ctxLocating
        '
        Me.ctxLocating.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLocatingSelect, Me.mnuLocatingCallIns, Me.mnuSep1, Me.mnuLocatingSupervisorReview, Me.mnuLocatingSupervisorReports})
        '
        'mnuLocatingSelect
        '
        Me.mnuLocatingSelect.Index = 0
        Me.mnuLocatingSelect.Text = "&Get Locating Case..."
        '
        'mnuLocatingCallIns
        '
        Me.mnuLocatingCallIns.Index = 1
        Me.mnuLocatingCallIns.Text = "&Call-ins && Returned Mail..."
        '
        'mnuSep1
        '
        Me.mnuSep1.Index = 2
        Me.mnuSep1.Text = "-"
        '
        'mnuLocatingSupervisorReview
        '
        Me.mnuLocatingSupervisorReview.Index = 3
        Me.mnuLocatingSupervisorReview.Text = "&Supervisor Review && Search..."
        '
        'mnuLocatingSupervisorReports
        '
        Me.mnuLocatingSupervisorReports.Index = 4
        Me.mnuLocatingSupervisorReports.Text = "&Reports"
        '
        'ctxAdmin
        '
        Me.ctxAdmin.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdminCaseLocks, Me.mnuAdminTables, Me.mnuAdminLookup, Me.mnuAdminStatus, Me.mnuSep2, Me.mnuAdminImport, Me.mnuBatchClean, Me.mnuAdminDQWS, Me.mnuAdminMgmt, Me.mnuAdminReports, Me.mnuAdminSurveySettings, Me.mnuAdminTCPALookup})
        '
        'mnuAdminCaseLocks
        '
        Me.mnuAdminCaseLocks.Index = 0
        Me.mnuAdminCaseLocks.Text = "&Case Locks..."
        '
        'mnuAdminTables
        '
        Me.mnuAdminTables.Index = 1
        Me.mnuAdminTables.Text = "&Admin Tables..."
        Me.mnuAdminTables.Visible = False
        '
        'mnuAdminLookup
        '
        Me.mnuAdminLookup.Index = 2
        Me.mnuAdminLookup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAdminLookupAdd, Me.mnuAdminLookupUpdate})
        Me.mnuAdminLookup.Text = "Lookup Tables"
        Me.mnuAdminLookup.Visible = False
        '
        'mnuAdminLookupAdd
        '
        Me.mnuAdminLookupAdd.Index = 0
        Me.mnuAdminLookupAdd.Text = "Add New"
        '
        'mnuAdminLookupUpdate
        '
        Me.mnuAdminLookupUpdate.Index = 1
        Me.mnuAdminLookupUpdate.Text = "Update..."
        '
        'mnuAdminStatus
        '
        Me.mnuAdminStatus.Index = 3
        Me.mnuAdminStatus.Text = "&Status Codes..."
        '
        'mnuSep2
        '
        Me.mnuSep2.Index = 4
        Me.mnuSep2.Text = "-"
        '
        'mnuAdminImport
        '
        Me.mnuAdminImport.Index = 5
        Me.mnuAdminImport.Text = "Data &Import..."
        '
        'mnuBatchClean
        '
        Me.mnuBatchClean.Index = 6
        Me.mnuBatchClean.Text = "&Batch Clean Address/Phones/Names"
        '
        'mnuAdminDQWS
        '
        Me.mnuAdminDQWS.Index = 7
        Me.mnuAdminDQWS.Text = "DQWS Demo"
        '
        'mnuAdminMgmt
        '
        Me.mnuAdminMgmt.Index = 8
        Me.mnuAdminMgmt.Text = "&Management Summary"
        '
        'mnuAdminReports
        '
        Me.mnuAdminReports.Index = 9
        Me.mnuAdminReports.Text = "Reports"
        '
        'mnuAdminSurveySettings
        '
        Me.mnuAdminSurveySettings.Index = 10
        Me.mnuAdminSurveySettings.Text = "Survey Settin&gs"
        '
        'mnuAdminTCPALookup
        '
        Me.mnuAdminTCPALookup.Index = 11
        Me.mnuAdminTCPALookup.Text = "TCPA Lookup"
        '
        'btnCase
        '
        Me.btnCase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCase.ContextMenu = Me.ctxCase
        Me.btnCase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCase.ImageIndex = 0
        Me.btnCase.ImageList = Me.imlSMSMain
        Me.btnCase.Location = New System.Drawing.Point(8, 8)
        Me.btnCase.Name = "btnCase"
        Me.btnCase.Size = New System.Drawing.Size(248, 44)
        Me.btnCase.TabIndex = 0
        Me.btnCase.Text = "&Cases"
        Me.btnCase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnCase, "Search, Add, View or Update Cases. Manage Field Cases and Assignments. Randomly A" &
        "ssign Cases.")
        '
        'imlSMSMain
        '
        Me.imlSMSMain.ImageStream = CType(resources.GetObject("imlSMSMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSMSMain.TransparentColor = System.Drawing.Color.White
        Me.imlSMSMain.Images.SetKeyName(0, "arrow-right.bmp")
        Me.imlSMSMain.Images.SetKeyName(1, "arrow-down.bmp")
        '
        'btnDocProcessing
        '
        Me.btnDocProcessing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDocProcessing.ContextMenu = Me.ctxDocProcessing
        Me.btnDocProcessing.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDocProcessing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDocProcessing.ImageIndex = 0
        Me.btnDocProcessing.ImageList = Me.imlSMSMain
        Me.btnDocProcessing.Location = New System.Drawing.Point(8, 58)
        Me.btnDocProcessing.Name = "btnDocProcessing"
        Me.btnDocProcessing.Size = New System.Drawing.Size(248, 44)
        Me.btnDocProcessing.TabIndex = 1
        Me.btnDocProcessing.Text = "&Document Processing"
        Me.btnDocProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnDocProcessing, "Document Production, Receipting and Batching")
        '
        'btnReports
        '
        Me.btnReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReports.Location = New System.Drawing.Point(8, 158)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(248, 44)
        Me.btnReports.TabIndex = 3
        Me.btnReports.Text = "&Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnReports, "Menu of General Reports")
        '
        'btnLocating
        '
        Me.btnLocating.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLocating.ContextMenu = Me.ctxLocating
        Me.btnLocating.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLocating.ImageIndex = 0
        Me.btnLocating.ImageList = Me.imlSMSMain
        Me.btnLocating.Location = New System.Drawing.Point(8, 208)
        Me.btnLocating.Name = "btnLocating"
        Me.btnLocating.Size = New System.Drawing.Size(248, 44)
        Me.btnLocating.TabIndex = 4
        Me.btnLocating.Text = "&Locating"
        Me.btnLocating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnLocating, "Locating, Searching, Reporting and Supervisor Functions.")
        '
        'btnAdmin
        '
        Me.btnAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdmin.ContextMenu = Me.ctxAdmin
        Me.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdmin.ImageIndex = 0
        Me.btnAdmin.ImageList = Me.imlSMSMain
        Me.btnAdmin.Location = New System.Drawing.Point(8, 308)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(248, 44)
        Me.btnAdmin.TabIndex = 5
        Me.btnAdmin.Text = "&Admin"
        Me.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnAdmin, "Admin Tools, Option Settings, Status Codes and Data Imports.")
        '
        'btnPayProcessing
        '
        Me.btnPayProcessing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayProcessing.ContextMenu = Me.ctxPayments
        Me.btnPayProcessing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPayProcessing.ImageIndex = 0
        Me.btnPayProcessing.ImageList = Me.imlSMSMain
        Me.btnPayProcessing.Location = New System.Drawing.Point(8, 108)
        Me.btnPayProcessing.Name = "btnPayProcessing"
        Me.btnPayProcessing.Size = New System.Drawing.Size(248, 44)
        Me.btnPayProcessing.TabIndex = 2
        Me.btnPayProcessing.Text = "&Payment Processing"
        Me.btnPayProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnPayProcessing, "Incentive Address Review, Payment Processing and Re-Issues.")
        '
        'ctxPayments
        '
        Me.ctxPayments.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPaymentAddressReview, Me.mnuPaymentReissues})
        '
        'mnuPaymentAddressReview
        '
        Me.mnuPaymentAddressReview.Index = 0
        Me.mnuPaymentAddressReview.Text = "&Address Review"
        '
        'mnuPaymentReissues
        '
        Me.mnuPaymentReissues.Index = 1
        Me.mnuPaymentReissues.Text = "Payment &Reissues"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(449, 306)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 44)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "E&xit"
        Me.MyToolTip.SetToolTip(Me.btnClose, "Exit this application")
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Location = New System.Drawing.Point(370, 306)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(73, 44)
        Me.btnAbout.TabIndex = 7
        Me.btnAbout.Text = "About"
        Me.MyToolTip.SetToolTip(Me.btnAbout, "System and Software information")
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescription.Location = New System.Drawing.Point(261, 73)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(260, 73)
        Me.lblDescription.TabIndex = 9
        Me.lblDescription.Text = "Here's where the button descriptions can go."
        '
        'imgLogo
        '
        Me.imgLogo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(329, 6)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(188, 64)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 10
        Me.imgLogo.TabStop = False
        '
        'imgIcon
        '
        Me.imgIcon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(261, 6)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(62, 64)
        Me.imgIcon.TabIndex = 11
        Me.imgIcon.TabStop = False
        '
        'lblDB
        '
        Me.lblDB.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDB.Location = New System.Drawing.Point(263, 152)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(258, 64)
        Me.lblDB.TabIndex = 10
        Me.lblDB.Text = "Connection Info"
        '
        'btnSRDEE
        '
        Me.btnSRDEE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSRDEE.ContextMenu = Me.ctxSRDEE
        Me.btnSRDEE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSRDEE.ImageIndex = 0
        Me.btnSRDEE.ImageList = Me.imlSMSMain
        Me.btnSRDEE.Location = New System.Drawing.Point(8, 258)
        Me.btnSRDEE.Name = "btnSRDEE"
        Me.btnSRDEE.Size = New System.Drawing.Size(248, 44)
        Me.btnSRDEE.TabIndex = 13
        Me.btnSRDEE.Text = "&Survey Response Data Explorer And Editor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSRDEE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyToolTip.SetToolTip(Me.btnSRDEE, "Survey Response Data, Searching, Viewing and Editing.")
        '
        'ctxSRDEE
        '
        Me.ctxSRDEE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddUpdateVariables, Me.mnuSep19, Me.mnuUpdateSRDEE, Me.mnuViewSRDEE, Me.mnuCompareSRDEE})
        '
        'mnuAddUpdateVariables
        '
        Me.mnuAddUpdateVariables.Index = 0
        Me.mnuAddUpdateVariables.Text = "Add / Update Survey Response Variables"
        '
        'mnuSep19
        '
        Me.mnuSep19.Index = 1
        Me.mnuSep19.Text = "-"
        '
        'mnuUpdateSRDEE
        '
        Me.mnuUpdateSRDEE.Index = 2
        Me.mnuUpdateSRDEE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddInstrumentTypes})
        Me.mnuUpdateSRDEE.Text = "Update Survey Responses"
        '
        'mnuAddInstrumentTypes
        '
        Me.mnuAddInstrumentTypes.Index = 0
        Me.mnuAddInstrumentTypes.Text = "InstrumentTypes"
        '
        'mnuViewSRDEE
        '
        Me.mnuViewSRDEE.Index = 3
        Me.mnuViewSRDEE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddInstrumentTypesForView})
        Me.mnuViewSRDEE.Text = "View Current Survey Responses (Read Only)"
        '
        'mnuAddInstrumentTypesForView
        '
        Me.mnuAddInstrumentTypesForView.Index = 0
        Me.mnuAddInstrumentTypesForView.Text = "InstrumentTypes"
        '
        'mnuCompareSRDEE
        '
        Me.mnuCompareSRDEE.Index = 4
        Me.mnuCompareSRDEE.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddInstrumentTypesForCompare})
        Me.mnuCompareSRDEE.Text = "Compare Longitudinal Survey Responses (Read Only)"
        '
        'mnuAddInstrumentTypesForCompare
        '
        Me.mnuAddInstrumentTypesForCompare.Index = 0
        Me.mnuAddInstrumentTypesForCompare.Text = "InstrumentTypes"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(160, 182)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(0, 13)
        Me.lblValue.TabIndex = 12
        Me.lblValue.Visible = False
        '
        'frmSMSMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(529, 360)
        Me.Controls.Add(Me.btnSRDEE)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.lblDB)
        Me.Controls.Add(Me.imgIcon)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPayProcessing)
        Me.Controls.Add(Me.btnAdmin)
        Me.Controls.Add(Me.btnLocating)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnDocProcessing)
        Me.Controls.Add(Me.btnCase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSMSMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Main Menu"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctxCase As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuCaseUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents ctxDocProcessing As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuDocRelease As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocReceipt As System.Windows.Forms.MenuItem
    Friend WithEvents ctxLocating As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuLocatingSelect As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLocatingCallIns As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLocatingSupervisorReview As System.Windows.Forms.MenuItem
    Friend WithEvents ctxAdmin As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAdminTables As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminCaseLocks As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminStatus As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminLookup As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminLookupAdd As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminLookupUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaseAdd As System.Windows.Forms.MenuItem
    Friend WithEvents btnCase As System.Windows.Forms.Button
    Friend WithEvents btnDocProcessing As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnLocating As System.Windows.Forms.Button
    Friend WithEvents btnAdmin As System.Windows.Forms.Button
    Friend WithEvents btnPayProcessing As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents mnuLocatingSupervisorReports As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaseLookup As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminImport As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRandomAssignment As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddEntity As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocBatch As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaseAddStudents As System.Windows.Forms.MenuItem
    Friend WithEvents ctxPayments As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuPaymentAddressReview As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaymentReissues As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminDQWS As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFieldManagement As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocQueue As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminMgmt As System.Windows.Forms.MenuItem
    Friend WithEvents MyToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents imlSMSMain As System.Windows.Forms.ImageList
    Friend WithEvents mnuBatchClean As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminReports As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminSurveySettings As System.Windows.Forms.MenuItem
    Friend WithEvents btnSRDEE As System.Windows.Forms.Button
    Friend WithEvents ctxSRDEE As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAddUpdateVariables As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep19 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUpdateSRDEE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddInstrumentTypes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuViewSRDEE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddInstrumentTypesForView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCompareSRDEE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddInstrumentTypesForCompare As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocQueries As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdminTCPALookup As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocDiscrep As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaseOpen As MenuItem
    Friend WithEvents mnuCaseOpenMPRID As MenuItem
    Friend WithEvents mnuCaseOpenPhone As MenuItem
End Class
