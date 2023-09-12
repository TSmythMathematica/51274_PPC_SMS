'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatusing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatusing))
        Me.grpOption = New System.Windows.Forms.GroupBox()
        Me.tblOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.optReceipt = New System.Windows.Forms.RadioButton()
        Me.optBatching = New System.Windows.Forms.RadioButton()
        Me.optStatusing = New System.Windows.Forms.RadioButton()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabOptions = New System.Windows.Forms.TabControl()
        Me.tabReceipting = New System.Windows.Forms.TabPage()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtSkip = New System.Windows.Forms.TextBox()
        Me.chkLocating = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.tblItemDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSMName = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMPRID = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCRName = New System.Windows.Forms.Label()
        Me.grpSession = New System.Windows.Forms.GroupBox()
        Me.lstSession = New System.Windows.Forms.ListView()
        Me.Barcode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CRName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OldStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NewStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResultStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboInstrumentStatus = New MPR.SMS.UserControls.StatusComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDocumentStatus = New System.Windows.Forms.ComboBox()
        Me.tabBatching = New System.Windows.Forms.TabPage()
        Me.btnBatchSearch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnReAssignCoder = New System.Windows.Forms.Button()
        Me.btnAssignCoder = New System.Windows.Forms.Button()
        Me.btnSupReview = New System.Windows.Forms.Button()
        Me.btnQCDVD = New System.Windows.Forms.Button()
        Me.btnTimeStamp = New System.Windows.Forms.Button()
        Me.btnCreateFinalBatch = New System.Windows.Forms.Button()
        Me.cmdBatchClose = New System.Windows.Forms.Button()
        Me.btnBatchReceiveIntoDE = New System.Windows.Forms.Button()
        Me.btnBatchCreateForDE = New System.Windows.Forms.Button()
        Me.btnBatchReceiveIntoQC = New System.Windows.Forms.Button()
        Me.btnBatchCreateForQC = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpOption.SuspendLayout()
        Me.tblOptions.SuspendLayout()
        Me.TabOptions.SuspendLayout()
        Me.tabReceipting.SuspendLayout()
        Me.tblItemDetails.SuspendLayout()
        Me.grpSession.SuspendLayout()
        Me.tabBatching.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOption
        '
        Me.grpOption.Controls.Add(Me.tblOptions)
        Me.grpOption.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpOption.Location = New System.Drawing.Point(0, 0)
        Me.grpOption.Name = "grpOption"
        Me.grpOption.Size = New System.Drawing.Size(784, 42)
        Me.grpOption.TabIndex = 1
        Me.grpOption.TabStop = False
        '
        'tblOptions
        '
        Me.tblOptions.ColumnCount = 3
        Me.tblOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblOptions.Controls.Add(Me.optReceipt, 0, 0)
        Me.tblOptions.Controls.Add(Me.optBatching, 2, 0)
        Me.tblOptions.Controls.Add(Me.optStatusing, 1, 0)
        Me.tblOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblOptions.Location = New System.Drawing.Point(3, 16)
        Me.tblOptions.Name = "tblOptions"
        Me.tblOptions.RowCount = 1
        Me.tblOptions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblOptions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tblOptions.Size = New System.Drawing.Size(778, 23)
        Me.tblOptions.TabIndex = 0
        '
        'optReceipt
        '
        Me.optReceipt.AutoSize = True
        Me.optReceipt.Enabled = False
        Me.optReceipt.Location = New System.Drawing.Point(3, 3)
        Me.optReceipt.Name = "optReceipt"
        Me.optReceipt.Size = New System.Drawing.Size(62, 17)
        Me.optReceipt.TabIndex = 0
        Me.optReceipt.Text = "Receipt"
        Me.ToolTip.SetToolTip(Me.optReceipt, "Status a document as ""Received - No QC"", or an instrument as ""353 - Hardcopy Rece" & _
        "ived""")
        Me.optReceipt.UseVisualStyleBackColor = True
        '
        'optBatching
        '
        Me.optBatching.AutoSize = True
        Me.optBatching.Checked = True
        Me.optBatching.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optBatching.Location = New System.Drawing.Point(521, 3)
        Me.optBatching.Name = "optBatching"
        Me.optBatching.Size = New System.Drawing.Size(254, 17)
        Me.optBatching.TabIndex = 2
        Me.optBatching.TabStop = True
        Me.optBatching.Text = "Batch"
        Me.ToolTip.SetToolTip(Me.optBatching, "Create batches of hardcopy instruments")
        Me.optBatching.UseVisualStyleBackColor = True
        '
        'optStatusing
        '
        Me.optStatusing.AutoSize = True
        Me.optStatusing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optStatusing.Location = New System.Drawing.Point(262, 3)
        Me.optStatusing.Name = "optStatusing"
        Me.optStatusing.Size = New System.Drawing.Size(253, 17)
        Me.optStatusing.TabIndex = 1
        Me.optStatusing.Text = "Status"
        Me.ToolTip.SetToolTip(Me.optStatusing, "Enter a specified status and notes for a document or instrument")
        Me.optStatusing.UseVisualStyleBackColor = True
        '
        'TabOptions
        '
        Me.TabOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOptions.Controls.Add(Me.tabReceipting)
        Me.TabOptions.Controls.Add(Me.tabBatching)
        Me.TabOptions.Location = New System.Drawing.Point(0, 48)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.SelectedIndex = 0
        Me.TabOptions.Size = New System.Drawing.Size(784, 470)
        Me.TabOptions.TabIndex = 0
        Me.TabOptions.TabStop = False
        '
        'tabReceipting
        '
        Me.tabReceipting.Controls.Add(Me.chkStatus)
        Me.tabReceipting.Controls.Add(Me.txtBarcode)
        Me.tabReceipting.Controls.Add(Me.txtSkip)
        Me.tabReceipting.Controls.Add(Me.chkLocating)
        Me.tabReceipting.Controls.Add(Me.btnClose)
        Me.tabReceipting.Controls.Add(Me.btnUpdate)
        Me.tabReceipting.Controls.Add(Me.lblNotes)
        Me.tabReceipting.Controls.Add(Me.txtNotes)
        Me.tabReceipting.Controls.Add(Me.tblItemDetails)
        Me.tabReceipting.Controls.Add(Me.grpSession)
        Me.tabReceipting.Controls.Add(Me.cboInstrumentStatus)
        Me.tabReceipting.Controls.Add(Me.Label1)
        Me.tabReceipting.Controls.Add(Me.cboDocumentStatus)
        Me.tabReceipting.Location = New System.Drawing.Point(4, 22)
        Me.tabReceipting.Name = "tabReceipting"
        Me.tabReceipting.Padding = New System.Windows.Forms.Padding(3)
        Me.tabReceipting.Size = New System.Drawing.Size(776, 444)
        Me.tabReceipting.TabIndex = 0
        Me.tabReceipting.Text = "Receipting && Statusing"
        Me.tabReceipting.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Checked = True
        Me.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStatus.Location = New System.Drawing.Point(9, 421)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(163, 17)
        Me.chkStatus.TabIndex = 11
        Me.chkStatus.Text = "Retain status between scans"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(96, 6)
        Me.txtBarcode.MaxLength = 14
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(196, 20)
        Me.txtBarcode.TabIndex = 1
        '
        'txtSkip
        '
        Me.txtSkip.Location = New System.Drawing.Point(96, 6)
        Me.txtSkip.Name = "txtSkip"
        Me.txtSkip.Size = New System.Drawing.Size(10, 20)
        Me.txtSkip.TabIndex = 2
        '
        'chkLocating
        '
        Me.chkLocating.AutoSize = True
        Me.chkLocating.Checked = True
        Me.chkLocating.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLocating.Location = New System.Drawing.Point(96, 57)
        Me.chkLocating.Name = "chkLocating"
        Me.chkLocating.Size = New System.Drawing.Size(107, 17)
        Me.chkLocating.TabIndex = 5
        Me.chkLocating.Text = "Open in Locating"
        Me.chkLocating.UseVisualStyleBackColor = True
        Me.chkLocating.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(696, 417)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(615, 417)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(9, 99)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(38, 13)
        Me.lblNotes.TabIndex = 5
        Me.lblNotes.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(96, 99)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(675, 55)
        Me.txtNotes.TabIndex = 6
        '
        'tblItemDetails
        '
        Me.tblItemDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblItemDetails.ColumnCount = 2
        Me.tblItemDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.18692!))
        Me.tblItemDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.81308!))
        Me.tblItemDetails.Controls.Add(Me.Label2, 0, 4)
        Me.tblItemDetails.Controls.Add(Me.lblSMName, 1, 3)
        Me.tblItemDetails.Controls.Add(Me.Label10, 0, 3)
        Me.tblItemDetails.Controls.Add(Me.lblMPRID, 1, 2)
        Me.tblItemDetails.Controls.Add(Me.Label8, 0, 2)
        Me.tblItemDetails.Controls.Add(Me.lblStatus, 1, 1)
        Me.tblItemDetails.Controls.Add(Me.Label6, 0, 1)
        Me.tblItemDetails.Controls.Add(Me.lblItemType, 1, 0)
        Me.tblItemDetails.Controls.Add(Me.Label3, 0, 0)
        Me.tblItemDetails.Controls.Add(Me.lblCRName, 1, 4)
        Me.tblItemDetails.Location = New System.Drawing.Point(298, 6)
        Me.tblItemDetails.Name = "tblItemDetails"
        Me.tblItemDetails.RowCount = 5
        Me.tblItemDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblItemDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblItemDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblItemDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblItemDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblItemDetails.Size = New System.Drawing.Size(476, 87)
        Me.tblItemDetails.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Respondent's Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSMName
        '
        Me.lblSMName.AutoSize = True
        Me.lblSMName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSMName.Location = New System.Drawing.Point(194, 51)
        Me.lblSMName.Name = "lblSMName"
        Me.lblSMName.Size = New System.Drawing.Size(279, 17)
        Me.lblSMName.TabIndex = 7
        Me.lblSMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 17)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Sample Member's Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMPRID.Location = New System.Drawing.Point(194, 34)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(279, 17)
        Me.lblMPRID.TabIndex = 5
        Me.lblMPRID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 17)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Sample Member's MPRID:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Location = New System.Drawing.Point(194, 17)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(279, 17)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Current status:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblItemType.Location = New System.Drawing.Point(194, 0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(279, 17)
        Me.lblItemType.TabIndex = 1
        Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item type:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCRName
        '
        Me.lblCRName.AutoSize = True
        Me.lblCRName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCRName.Location = New System.Drawing.Point(194, 68)
        Me.lblCRName.Name = "lblCRName"
        Me.lblCRName.Size = New System.Drawing.Size(279, 19)
        Me.lblCRName.TabIndex = 9
        Me.lblCRName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSession
        '
        Me.grpSession.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSession.Controls.Add(Me.lstSession)
        Me.grpSession.Location = New System.Drawing.Point(6, 160)
        Me.grpSession.Name = "grpSession"
        Me.grpSession.Size = New System.Drawing.Size(768, 255)
        Me.grpSession.TabIndex = 7
        Me.grpSession.TabStop = False
        Me.grpSession.Text = "Items receipted/statused this session:"
        '
        'lstSession
        '
        Me.lstSession.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Barcode, Me.Type, Me.CRName, Me.OldStatus, Me.NewStatus, Me.ResultStatus})
        Me.lstSession.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSession.Location = New System.Drawing.Point(3, 16)
        Me.lstSession.Name = "lstSession"
        Me.lstSession.Size = New System.Drawing.Size(762, 236)
        Me.lstSession.TabIndex = 0
        Me.lstSession.UseCompatibleStateImageBehavior = False
        Me.lstSession.View = System.Windows.Forms.View.Details
        '
        'Barcode
        '
        Me.Barcode.Text = "Barcode"
        Me.Barcode.Width = 80
        '
        'Type
        '
        Me.Type.Text = "Item Type"
        Me.Type.Width = 180
        '
        'CRName
        '
        Me.CRName.Text = "Respondent's Name"
        Me.CRName.Width = 120
        '
        'OldStatus
        '
        Me.OldStatus.Text = "Old Status"
        Me.OldStatus.Width = 70
        '
        'NewStatus
        '
        Me.NewStatus.Text = "New Status"
        Me.NewStatus.Width = 70
        '
        'ResultStatus
        '
        Me.ResultStatus.Text = "Result Status"
        Me.ResultStatus.Width = 80
        '
        'cboInstrumentStatus
        '
        Me.cboInstrumentStatus.Location = New System.Drawing.Point(8, 32)
        Me.cboInstrumentStatus.MyLabel = "Current Status:"
        Me.cboInstrumentStatus.Name = "cboInstrumentStatus"
        Me.cboInstrumentStatus.SelectedStatus = Nothing
        Me.cboInstrumentStatus.Size = New System.Drawing.Size(284, 24)
        Me.cboInstrumentStatus.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Barcode:"
        '
        'cboDocumentStatus
        '
        Me.cboDocumentStatus.FormattingEnabled = True
        Me.cboDocumentStatus.Location = New System.Drawing.Point(96, 32)
        Me.cboDocumentStatus.Name = "cboDocumentStatus"
        Me.cboDocumentStatus.Size = New System.Drawing.Size(196, 21)
        Me.cboDocumentStatus.TabIndex = 4
        Me.cboDocumentStatus.Visible = False
        '
        'tabBatching
        '
        Me.tabBatching.Controls.Add(Me.btnBatchSearch)
        Me.tabBatching.Controls.Add(Me.btnReAssignCoder)
        Me.tabBatching.Controls.Add(Me.btnAssignCoder)
        Me.tabBatching.Controls.Add(Me.btnSupReview)
        Me.tabBatching.Controls.Add(Me.btnQCDVD)
        Me.tabBatching.Controls.Add(Me.btnTimeStamp)
        Me.tabBatching.Controls.Add(Me.btnCreateFinalBatch)
        Me.tabBatching.Controls.Add(Me.cmdBatchClose)
        Me.tabBatching.Controls.Add(Me.btnBatchReceiveIntoDE)
        Me.tabBatching.Controls.Add(Me.btnBatchCreateForDE)
        Me.tabBatching.Controls.Add(Me.btnBatchReceiveIntoQC)
        Me.tabBatching.Controls.Add(Me.btnBatchCreateForQC)
        Me.tabBatching.Location = New System.Drawing.Point(4, 22)
        Me.tabBatching.Name = "tabBatching"
        Me.tabBatching.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBatching.Size = New System.Drawing.Size(776, 444)
        Me.tabBatching.TabIndex = 1
        Me.tabBatching.Text = "Batching"
        Me.tabBatching.UseVisualStyleBackColor = True
        '
        'btnBatchSearch
        '
        Me.btnBatchSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBatchSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatchSearch.ImageKey = "icon_magnifyingGlass.png"
        Me.btnBatchSearch.ImageList = Me.ImageList1
        Me.btnBatchSearch.Location = New System.Drawing.Point(646, 3)
        Me.btnBatchSearch.Name = "btnBatchSearch"
        Me.btnBatchSearch.Size = New System.Drawing.Size(130, 66)
        Me.btnBatchSearch.TabIndex = 27
        Me.btnBatchSearch.Text = "Search Batches"
        Me.btnBatchSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchSearch.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "TimeStampDVD2.png")
        Me.ImageList1.Images.SetKeyName(1, "StatusDVD.png")
        Me.ImageList1.Images.SetKeyName(2, "Supervisor.png")
        Me.ImageList1.Images.SetKeyName(3, "assign.gif")
        Me.ImageList1.Images.SetKeyName(4, "re-assign.png")
        Me.ImageList1.Images.SetKeyName(5, "mailbag.png")
        Me.ImageList1.Images.SetKeyName(6, "mailQC.png")
        Me.ImageList1.Images.SetKeyName(7, "batch.png")
        Me.ImageList1.Images.SetKeyName(8, "receive.png")
        Me.ImageList1.Images.SetKeyName(9, "FinalStatusHC.png")
        Me.ImageList1.Images.SetKeyName(10, "icon_magnifyingGlass.png")
        '
        'btnReAssignCoder
        '
        Me.btnReAssignCoder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReAssignCoder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReAssignCoder.ImageKey = "re-assign.png"
        Me.btnReAssignCoder.ImageList = Me.ImageList1
        Me.btnReAssignCoder.Location = New System.Drawing.Point(409, 277)
        Me.btnReAssignCoder.Name = "btnReAssignCoder"
        Me.btnReAssignCoder.Size = New System.Drawing.Size(130, 66)
        Me.btnReAssignCoder.TabIndex = 26
        Me.btnReAssignCoder.Text = "Re-Assign DVD Coder"
        Me.btnReAssignCoder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReAssignCoder.UseVisualStyleBackColor = True
        '
        'btnAssignCoder
        '
        Me.btnAssignCoder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAssignCoder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAssignCoder.ImageKey = "assign.gif"
        Me.btnAssignCoder.ImageList = Me.ImageList1
        Me.btnAssignCoder.Location = New System.Drawing.Point(332, 191)
        Me.btnAssignCoder.Name = "btnAssignCoder"
        Me.btnAssignCoder.Size = New System.Drawing.Size(130, 66)
        Me.btnAssignCoder.TabIndex = 18
        Me.btnAssignCoder.Text = "Assign DVD Coder"
        Me.btnAssignCoder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAssignCoder.UseVisualStyleBackColor = True
        '
        'btnSupReview
        '
        Me.btnSupReview.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSupReview.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSupReview.ImageKey = "Supervisor.png"
        Me.btnSupReview.ImageList = Me.ImageList1
        Me.btnSupReview.Location = New System.Drawing.Point(495, 191)
        Me.btnSupReview.Name = "btnSupReview"
        Me.btnSupReview.Size = New System.Drawing.Size(130, 66)
        Me.btnSupReview.TabIndex = 24
        Me.btnSupReview.Text = "Supervisor Review DVD"
        Me.btnSupReview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSupReview.UseVisualStyleBackColor = True
        '
        'btnQCDVD
        '
        Me.btnQCDVD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnQCDVD.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnQCDVD.ImageKey = "StatusDVD.png"
        Me.btnQCDVD.ImageList = Me.ImageList1
        Me.btnQCDVD.Location = New System.Drawing.Point(409, 103)
        Me.btnQCDVD.Name = "btnQCDVD"
        Me.btnQCDVD.Size = New System.Drawing.Size(130, 66)
        Me.btnQCDVD.TabIndex = 21
        Me.btnQCDVD.Text = "Status DVD QC status"
        Me.btnQCDVD.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnQCDVD.UseVisualStyleBackColor = True
        '
        'btnTimeStamp
        '
        Me.btnTimeStamp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTimeStamp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTimeStamp.ImageKey = "TimeStampDVD2.png"
        Me.btnTimeStamp.ImageList = Me.ImageList1
        Me.btnTimeStamp.Location = New System.Drawing.Point(409, 17)
        Me.btnTimeStamp.Name = "btnTimeStamp"
        Me.btnTimeStamp.Size = New System.Drawing.Size(130, 66)
        Me.btnTimeStamp.TabIndex = 23
        Me.btnTimeStamp.Text = "TimeStamp DVD"
        Me.btnTimeStamp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTimeStamp.UseVisualStyleBackColor = True
        '
        'btnCreateFinalBatch
        '
        Me.btnCreateFinalBatch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCreateFinalBatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreateFinalBatch.ImageKey = "FinalStatusHC.png"
        Me.btnCreateFinalBatch.ImageList = Me.ImageList1
        Me.btnCreateFinalBatch.Location = New System.Drawing.Point(70, 363)
        Me.btnCreateFinalBatch.Name = "btnCreateFinalBatch"
        Me.btnCreateFinalBatch.Size = New System.Drawing.Size(130, 66)
        Me.btnCreateFinalBatch.TabIndex = 9
        Me.btnCreateFinalBatch.Text = "Final Status Hard Copy or DVD"
        Me.btnCreateFinalBatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCreateFinalBatch.UseVisualStyleBackColor = True
        '
        'cmdBatchClose
        '
        Me.cmdBatchClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBatchClose.Location = New System.Drawing.Point(676, 418)
        Me.cmdBatchClose.Name = "cmdBatchClose"
        Me.cmdBatchClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdBatchClose.TabIndex = 8
        Me.cmdBatchClose.Text = "&Close"
        Me.cmdBatchClose.UseVisualStyleBackColor = True
        '
        'btnBatchReceiveIntoDE
        '
        Me.btnBatchReceiveIntoDE.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBatchReceiveIntoDE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatchReceiveIntoDE.ImageKey = "receive.png"
        Me.btnBatchReceiveIntoDE.ImageList = Me.ImageList1
        Me.btnBatchReceiveIntoDE.Location = New System.Drawing.Point(70, 277)
        Me.btnBatchReceiveIntoDE.Name = "btnBatchReceiveIntoDE"
        Me.btnBatchReceiveIntoDE.Size = New System.Drawing.Size(130, 66)
        Me.btnBatchReceiveIntoDE.TabIndex = 6
        Me.btnBatchReceiveIntoDE.Text = "Receive Batches Into Data Entry"
        Me.btnBatchReceiveIntoDE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchReceiveIntoDE.UseVisualStyleBackColor = True
        '
        'btnBatchCreateForDE
        '
        Me.btnBatchCreateForDE.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBatchCreateForDE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatchCreateForDE.ImageKey = "batch.png"
        Me.btnBatchCreateForDE.ImageList = Me.ImageList1
        Me.btnBatchCreateForDE.Location = New System.Drawing.Point(70, 191)
        Me.btnBatchCreateForDE.Name = "btnBatchCreateForDE"
        Me.btnBatchCreateForDE.Size = New System.Drawing.Size(130, 66)
        Me.btnBatchCreateForDE.TabIndex = 5
        Me.btnBatchCreateForDE.Text = "Create Data Entry Batches"
        Me.btnBatchCreateForDE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchCreateForDE.UseVisualStyleBackColor = True
        '
        'btnBatchReceiveIntoQC
        '
        Me.btnBatchReceiveIntoQC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBatchReceiveIntoQC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatchReceiveIntoQC.ImageKey = "mailQC.png"
        Me.btnBatchReceiveIntoQC.ImageList = Me.ImageList1
        Me.btnBatchReceiveIntoQC.Location = New System.Drawing.Point(70, 103)
        Me.btnBatchReceiveIntoQC.Name = "btnBatchReceiveIntoQC"
        Me.btnBatchReceiveIntoQC.Size = New System.Drawing.Size(130, 66)
        Me.btnBatchReceiveIntoQC.TabIndex = 3
        Me.btnBatchReceiveIntoQC.Text = "Receive Transmittal Into QC Editing"
        Me.btnBatchReceiveIntoQC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchReceiveIntoQC.UseVisualStyleBackColor = True
        '
        'btnBatchCreateForQC
        '
        Me.btnBatchCreateForQC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBatchCreateForQC.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatchCreateForQC.ImageKey = "mailbag.png"
        Me.btnBatchCreateForQC.ImageList = Me.ImageList1
        Me.btnBatchCreateForQC.Location = New System.Drawing.Point(70, 17)
        Me.btnBatchCreateForQC.Name = "btnBatchCreateForQC"
        Me.btnBatchCreateForQC.Size = New System.Drawing.Size(130, 66)
        Me.btnBatchCreateForQC.TabIndex = 2
        Me.btnBatchCreateForQC.Text = "Receipt and Create QC Transmittal"
        Me.btnBatchCreateForQC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchCreateForQC.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.tsslCount, Me.tspbProgress, Me.tsslUser})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 518)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.ShowItemToolTips = True
        Me.StatusStrip.Size = New System.Drawing.Size(784, 25)
        Me.StatusStrip.TabIndex = 4
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(590, 20)
        Me.tsslStatus.Spring = True
        Me.tsslStatus.Text = "Scan the barcode ID, or type it in and then press Enter."
        Me.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsslCount
        '
        Me.tsslCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslCount.Name = "tsslCount"
        Me.tsslCount.Size = New System.Drawing.Size(99, 20)
        Me.tsslCount.Text = "Items scanned: 0"
        Me.tsslCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslCount.ToolTipText = "Case type"
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
        'frmStatusing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 543)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.TabOptions)
        Me.Controls.Add(Me.grpOption)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStatusing"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Receipting, Statusing and Batching"
        Me.grpOption.ResumeLayout(False)
        Me.tblOptions.ResumeLayout(False)
        Me.tblOptions.PerformLayout()
        Me.TabOptions.ResumeLayout(False)
        Me.tabReceipting.ResumeLayout(False)
        Me.tabReceipting.PerformLayout()
        Me.tblItemDetails.ResumeLayout(False)
        Me.tblItemDetails.PerformLayout()
        Me.grpSession.ResumeLayout(False)
        Me.tabBatching.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpOption As System.Windows.Forms.GroupBox
    Friend WithEvents optBatching As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusing As System.Windows.Forms.RadioButton
    Friend WithEvents optReceipt As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TabOptions As System.Windows.Forms.TabControl
    Friend WithEvents tabReceipting As System.Windows.Forms.TabPage
    Friend WithEvents tabBatching As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsslUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboDocumentStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboInstrumentStatus As MPR.SMS.UserControls.StatusComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents tblItemDetails As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpSession As System.Windows.Forms.GroupBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblSMName As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMPRID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lstSession As System.Windows.Forms.ListView
    Friend WithEvents tblOptions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Barcode As System.Windows.Forms.ColumnHeader
    Friend WithEvents Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents CRName As System.Windows.Forms.ColumnHeader
    Friend WithEvents OldStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents NewStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents ResultStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkLocating As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblItemType As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCRName As System.Windows.Forms.Label
    Friend WithEvents txtSkip As System.Windows.Forms.TextBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents btnBatchCreateForQC As System.Windows.Forms.Button
    Friend WithEvents btnBatchReceiveIntoDE As System.Windows.Forms.Button
    Friend WithEvents btnBatchCreateForDE As System.Windows.Forms.Button
    Friend WithEvents btnBatchReceiveIntoQC As System.Windows.Forms.Button
    Friend WithEvents cmdBatchClose As System.Windows.Forms.Button
    Friend WithEvents btnCreateFinalBatch As System.Windows.Forms.Button
    Friend WithEvents btnTimeStamp As System.Windows.Forms.Button
    Friend WithEvents btnQCDVD As System.Windows.Forms.Button
    Friend WithEvents btnSupReview As System.Windows.Forms.Button
    Friend WithEvents btnAssignCoder As System.Windows.Forms.Button
    Friend WithEvents btnReAssignCoder As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnBatchSearch As System.Windows.Forms.Button
End Class
