'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatusRule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatusRule))
        Me.TabRule = New System.Windows.Forms.TabControl()
        Me.TabUpdate = New System.Windows.Forms.TabPage()
        Me.cboNewStatus = New System.Windows.Forms.ComboBox()
        Me.cboExistingStatus = New System.Windows.Forms.ComboBox()
        Me.lblTotalRules = New System.Windows.Forms.Label()
        Me.txtTotalRules = New System.Windows.Forms.TextBox()
        Me.dgvStatusUpdateRule = New System.Windows.Forms.DataGridView()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNewStatus = New System.Windows.Forms.Label()
        Me.lblExistingStatus = New System.Windows.Forms.Label()
        Me.TabAdd = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSelectAll = New System.Windows.Forms.CheckBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.lblNoAction = New System.Windows.Forms.Label()
        Me.lblOverride = New System.Windows.Forms.Label()
        Me.btnRemoveError = New System.Windows.Forms.Button()
        Me.btnAddError = New System.Windows.Forms.Button()
        Me.btnRemoveNoAction = New System.Windows.Forms.Button()
        Me.btnAddNoAction = New System.Windows.Forms.Button()
        Me.btnRemoveOverride = New System.Windows.Forms.Button()
        Me.lblErrorRecords = New System.Windows.Forms.Label()
        Me.txtTotalError = New System.Windows.Forms.TextBox()
        Me.lblNoactionRecords = New System.Windows.Forms.Label()
        Me.txtTotalNoAction = New System.Windows.Forms.TextBox()
        Me.lblOverrideRecords = New System.Windows.Forms.Label()
        Me.txtTotalOverride = New System.Windows.Forms.TextBox()
        Me.lblMissingRecords = New System.Windows.Forms.Label()
        Me.txtTotalMissing = New System.Windows.Forms.TextBox()
        Me.dgvError = New System.Windows.Forms.DataGridView()
        Me.dgvNoAction = New System.Windows.Forms.DataGridView()
        Me.btnAddOverride = New System.Windows.Forms.Button()
        Me.dgvOverride = New System.Windows.Forms.DataGridView()
        Me.dgvMissing = New System.Windows.Forms.DataGridView()
        Me.ssStatusRule = New System.Windows.Forms.StatusStrip()
        Me.BlankSpaceLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ComputerNameLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStatusRule = New System.Windows.Forms.ToolStrip()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.TabRule.SuspendLayout()
        Me.TabUpdate.SuspendLayout()
        CType(Me.dgvStatusUpdateRule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAdd.SuspendLayout()
        CType(Me.dgvError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNoAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOverride, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMissing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatusRule.SuspendLayout()
        Me.tsStatusRule.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabRule
        '
        Me.TabRule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabRule.Controls.Add(Me.TabUpdate)
        Me.TabRule.Controls.Add(Me.TabAdd)
        Me.TabRule.Location = New System.Drawing.Point(0, 37)
        Me.TabRule.Name = "TabRule"
        Me.TabRule.SelectedIndex = 0
        Me.TabRule.Size = New System.Drawing.Size(732, 470)
        Me.TabRule.TabIndex = 1
        '
        'TabUpdate
        '
        Me.TabUpdate.Controls.Add(Me.cboNewStatus)
        Me.TabUpdate.Controls.Add(Me.cboExistingStatus)
        Me.TabUpdate.Controls.Add(Me.lblTotalRules)
        Me.TabUpdate.Controls.Add(Me.txtTotalRules)
        Me.TabUpdate.Controls.Add(Me.dgvStatusUpdateRule)
        Me.TabUpdate.Controls.Add(Me.btnGo)
        Me.TabUpdate.Controls.Add(Me.Label8)
        Me.TabUpdate.Controls.Add(Me.lblNewStatus)
        Me.TabUpdate.Controls.Add(Me.lblExistingStatus)
        Me.TabUpdate.Location = New System.Drawing.Point(4, 22)
        Me.TabUpdate.Name = "TabUpdate"
        Me.TabUpdate.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUpdate.Size = New System.Drawing.Size(724, 444)
        Me.TabUpdate.TabIndex = 0
        Me.TabUpdate.Text = "Update"
        Me.TabUpdate.UseVisualStyleBackColor = True
        '
        'cboNewStatus
        '
        Me.cboNewStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboNewStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewStatus.Location = New System.Drawing.Point(105, 59)
        Me.cboNewStatus.Name = "cboNewStatus"
        Me.cboNewStatus.Size = New System.Drawing.Size(152, 21)
        Me.cboNewStatus.TabIndex = 4
        '
        'cboExistingStatus
        '
        Me.cboExistingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboExistingStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExistingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExistingStatus.Location = New System.Drawing.Point(105, 18)
        Me.cboExistingStatus.Name = "cboExistingStatus"
        Me.cboExistingStatus.Size = New System.Drawing.Size(152, 21)
        Me.cboExistingStatus.TabIndex = 1
        '
        'lblTotalRules
        '
        Me.lblTotalRules.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRules.AutoSize = True
        Me.lblTotalRules.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRules.Location = New System.Drawing.Point(552, 67)
        Me.lblTotalRules.Name = "lblTotalRules"
        Me.lblTotalRules.Size = New System.Drawing.Size(91, 13)
        Me.lblTotalRules.TabIndex = 6
        Me.lblTotalRules.Text = "Total Records:"
        '
        'txtTotalRules
        '
        Me.txtTotalRules.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRules.Location = New System.Drawing.Point(649, 64)
        Me.txtTotalRules.Name = "txtTotalRules"
        Me.txtTotalRules.ReadOnly = True
        Me.txtTotalRules.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalRules.TabIndex = 7
        '
        'dgvStatusUpdateRule
        '
        Me.dgvStatusUpdateRule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStatusUpdateRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatusUpdateRule.Location = New System.Drawing.Point(16, 90)
        Me.dgvStatusUpdateRule.Name = "dgvStatusUpdateRule"
        Me.dgvStatusUpdateRule.RowTemplate.Height = 18
        Me.dgvStatusUpdateRule.Size = New System.Drawing.Size(693, 351)
        Me.dgvStatusUpdateRule.TabIndex = 8
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(263, 59)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(39, 21)
        Me.btnGo.TabIndex = 5
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(131, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "AND/OR"
        '
        'lblNewStatus
        '
        Me.lblNewStatus.AutoSize = True
        Me.lblNewStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewStatus.Location = New System.Drawing.Point(13, 59)
        Me.lblNewStatus.Name = "lblNewStatus"
        Me.lblNewStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblNewStatus.TabIndex = 3
        Me.lblNewStatus.Text = "New status:"
        '
        'lblExistingStatus
        '
        Me.lblExistingStatus.AutoSize = True
        Me.lblExistingStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistingStatus.Location = New System.Drawing.Point(13, 18)
        Me.lblExistingStatus.Name = "lblExistingStatus"
        Me.lblExistingStatus.Size = New System.Drawing.Size(93, 13)
        Me.lblExistingStatus.TabIndex = 0
        Me.lblExistingStatus.Text = "Existing status:"
        '
        'TabAdd
        '
        Me.TabAdd.Controls.Add(Me.Label3)
        Me.TabAdd.Controls.Add(Me.Label2)
        Me.TabAdd.Controls.Add(Me.Label1)
        Me.TabAdd.Controls.Add(Me.cbSelectAll)
        Me.TabAdd.Controls.Add(Me.lblError)
        Me.TabAdd.Controls.Add(Me.lblNoAction)
        Me.TabAdd.Controls.Add(Me.lblOverride)
        Me.TabAdd.Controls.Add(Me.btnRemoveError)
        Me.TabAdd.Controls.Add(Me.btnAddError)
        Me.TabAdd.Controls.Add(Me.btnRemoveNoAction)
        Me.TabAdd.Controls.Add(Me.btnAddNoAction)
        Me.TabAdd.Controls.Add(Me.btnRemoveOverride)
        Me.TabAdd.Controls.Add(Me.lblErrorRecords)
        Me.TabAdd.Controls.Add(Me.txtTotalError)
        Me.TabAdd.Controls.Add(Me.lblNoactionRecords)
        Me.TabAdd.Controls.Add(Me.txtTotalNoAction)
        Me.TabAdd.Controls.Add(Me.lblOverrideRecords)
        Me.TabAdd.Controls.Add(Me.txtTotalOverride)
        Me.TabAdd.Controls.Add(Me.lblMissingRecords)
        Me.TabAdd.Controls.Add(Me.txtTotalMissing)
        Me.TabAdd.Controls.Add(Me.dgvError)
        Me.TabAdd.Controls.Add(Me.dgvNoAction)
        Me.TabAdd.Controls.Add(Me.btnAddOverride)
        Me.TabAdd.Controls.Add(Me.dgvOverride)
        Me.TabAdd.Controls.Add(Me.dgvMissing)
        Me.TabAdd.Location = New System.Drawing.Point(4, 22)
        Me.TabAdd.Name = "TabAdd"
        Me.TabAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAdd.Size = New System.Drawing.Size(724, 444)
        Me.TabAdd.TabIndex = 1
        Me.TabAdd.Text = "Add"
        Me.TabAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(559, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Total Records:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(559, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Total Records:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(559, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Total Records:"
        '
        'cbSelectAll
        '
        Me.cbSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbSelectAll.AutoSize = True
        Me.cbSelectAll.Location = New System.Drawing.Point(8, 427)
        Me.cbSelectAll.Name = "cbSelectAll"
        Me.cbSelectAll.Size = New System.Drawing.Size(70, 17)
        Me.cbSelectAll.TabIndex = 3
        Me.cbSelectAll.Text = "Select All"
        Me.cbSelectAll.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.Location = New System.Drawing.Point(311, 338)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(75, 16)
        Me.lblError.TabIndex = 18
        Me.lblError.Text = "Error"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNoAction
        '
        Me.lblNoAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoAction.Location = New System.Drawing.Point(311, 200)
        Me.lblNoAction.Name = "lblNoAction"
        Me.lblNoAction.Size = New System.Drawing.Size(75, 14)
        Me.lblNoAction.TabIndex = 11
        Me.lblNoAction.Text = "No Action"
        Me.lblNoAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOverride
        '
        Me.lblOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOverride.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverride.Location = New System.Drawing.Point(311, 53)
        Me.lblOverride.Name = "lblOverride"
        Me.lblOverride.Size = New System.Drawing.Size(75, 14)
        Me.lblOverride.TabIndex = 4
        Me.lblOverride.Text = "Override"
        Me.lblOverride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRemoveError
        '
        Me.btnRemoveError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveError.Location = New System.Drawing.Point(311, 381)
        Me.btnRemoveError.Name = "btnRemoveError"
        Me.btnRemoveError.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveError.TabIndex = 20
        Me.btnRemoveError.Text = "< Remove"
        Me.btnRemoveError.UseVisualStyleBackColor = True
        '
        'btnAddError
        '
        Me.btnAddError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddError.Location = New System.Drawing.Point(311, 357)
        Me.btnAddError.Name = "btnAddError"
        Me.btnAddError.Size = New System.Drawing.Size(75, 23)
        Me.btnAddError.TabIndex = 19
        Me.btnAddError.Text = "Add >"
        Me.btnAddError.UseVisualStyleBackColor = True
        '
        'btnRemoveNoAction
        '
        Me.btnRemoveNoAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveNoAction.Location = New System.Drawing.Point(311, 241)
        Me.btnRemoveNoAction.Name = "btnRemoveNoAction"
        Me.btnRemoveNoAction.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveNoAction.TabIndex = 13
        Me.btnRemoveNoAction.Text = "< Remove"
        Me.btnRemoveNoAction.UseVisualStyleBackColor = True
        '
        'btnAddNoAction
        '
        Me.btnAddNoAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNoAction.Location = New System.Drawing.Point(311, 217)
        Me.btnAddNoAction.Name = "btnAddNoAction"
        Me.btnAddNoAction.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNoAction.TabIndex = 12
        Me.btnAddNoAction.Text = "Add >"
        Me.btnAddNoAction.UseVisualStyleBackColor = True
        '
        'btnRemoveOverride
        '
        Me.btnRemoveOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveOverride.Location = New System.Drawing.Point(311, 94)
        Me.btnRemoveOverride.Name = "btnRemoveOverride"
        Me.btnRemoveOverride.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveOverride.TabIndex = 6
        Me.btnRemoveOverride.Text = "< Remove"
        Me.btnRemoveOverride.UseVisualStyleBackColor = True
        '
        'lblErrorRecords
        '
        Me.lblErrorRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorRecords.AutoSize = True
        Me.lblErrorRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorRecords.Location = New System.Drawing.Point(395, 298)
        Me.lblErrorRecords.Name = "lblErrorRecords"
        Me.lblErrorRecords.Size = New System.Drawing.Size(82, 13)
        Me.lblErrorRecords.TabIndex = 21
        Me.lblErrorRecords.Text = """Error"" Rules"
        '
        'txtTotalError
        '
        Me.txtTotalError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalError.Location = New System.Drawing.Point(656, 295)
        Me.txtTotalError.Name = "txtTotalError"
        Me.txtTotalError.ReadOnly = True
        Me.txtTotalError.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalError.TabIndex = 23
        '
        'lblNoactionRecords
        '
        Me.lblNoactionRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoactionRecords.AutoSize = True
        Me.lblNoactionRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoactionRecords.Location = New System.Drawing.Point(399, 159)
        Me.lblNoactionRecords.Name = "lblNoactionRecords"
        Me.lblNoactionRecords.Size = New System.Drawing.Size(111, 13)
        Me.lblNoactionRecords.TabIndex = 14
        Me.lblNoactionRecords.Text = """No Action"" Rules"
        '
        'txtTotalNoAction
        '
        Me.txtTotalNoAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalNoAction.Location = New System.Drawing.Point(656, 156)
        Me.txtTotalNoAction.Name = "txtTotalNoAction"
        Me.txtTotalNoAction.ReadOnly = True
        Me.txtTotalNoAction.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalNoAction.TabIndex = 16
        '
        'lblOverrideRecords
        '
        Me.lblOverrideRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOverrideRecords.AutoSize = True
        Me.lblOverrideRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverrideRecords.Location = New System.Drawing.Point(399, 19)
        Me.lblOverrideRecords.Name = "lblOverrideRecords"
        Me.lblOverrideRecords.Size = New System.Drawing.Size(103, 13)
        Me.lblOverrideRecords.TabIndex = 7
        Me.lblOverrideRecords.Text = """Override"" Rules"
        '
        'txtTotalOverride
        '
        Me.txtTotalOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalOverride.Location = New System.Drawing.Point(656, 16)
        Me.txtTotalOverride.Name = "txtTotalOverride"
        Me.txtTotalOverride.ReadOnly = True
        Me.txtTotalOverride.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalOverride.TabIndex = 9
        '
        'lblMissingRecords
        '
        Me.lblMissingRecords.AutoSize = True
        Me.lblMissingRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMissingRecords.Location = New System.Drawing.Point(8, 16)
        Me.lblMissingRecords.Name = "lblMissingRecords"
        Me.lblMissingRecords.Size = New System.Drawing.Size(197, 13)
        Me.lblMissingRecords.TabIndex = 0
        Me.lblMissingRecords.Text = "Missing Rules       Total Records:"
        '
        'txtTotalMissing
        '
        Me.txtTotalMissing.Location = New System.Drawing.Point(205, 13)
        Me.txtTotalMissing.Name = "txtTotalMissing"
        Me.txtTotalMissing.ReadOnly = True
        Me.txtTotalMissing.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalMissing.TabIndex = 1
        '
        'dgvError
        '
        Me.dgvError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvError.Location = New System.Drawing.Point(398, 317)
        Me.dgvError.Name = "dgvError"
        Me.dgvError.RowTemplate.Height = 18
        Me.dgvError.Size = New System.Drawing.Size(318, 107)
        Me.dgvError.TabIndex = 24
        '
        'dgvNoAction
        '
        Me.dgvNoAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNoAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNoAction.Location = New System.Drawing.Point(400, 179)
        Me.dgvNoAction.Name = "dgvNoAction"
        Me.dgvNoAction.RowTemplate.Height = 18
        Me.dgvNoAction.Size = New System.Drawing.Size(316, 110)
        Me.dgvNoAction.TabIndex = 17
        '
        'btnAddOverride
        '
        Me.btnAddOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddOverride.Location = New System.Drawing.Point(311, 70)
        Me.btnAddOverride.Name = "btnAddOverride"
        Me.btnAddOverride.Size = New System.Drawing.Size(75, 23)
        Me.btnAddOverride.TabIndex = 5
        Me.btnAddOverride.Text = "Add >"
        Me.btnAddOverride.UseVisualStyleBackColor = True
        '
        'dgvOverride
        '
        Me.dgvOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOverride.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOverride.Location = New System.Drawing.Point(402, 38)
        Me.dgvOverride.Name = "dgvOverride"
        Me.dgvOverride.RowTemplate.Height = 18
        Me.dgvOverride.Size = New System.Drawing.Size(314, 110)
        Me.dgvOverride.TabIndex = 10
        '
        'dgvMissing
        '
        Me.dgvMissing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMissing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMissing.Location = New System.Drawing.Point(8, 38)
        Me.dgvMissing.Name = "dgvMissing"
        Me.dgvMissing.RowTemplate.Height = 18
        Me.dgvMissing.Size = New System.Drawing.Size(291, 386)
        Me.dgvMissing.TabIndex = 2
        '
        'ssStatusRule
        '
        Me.ssStatusRule.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlankSpaceLabel, Me.ComputerNameLabel, Me.UserLabel})
        Me.ssStatusRule.Location = New System.Drawing.Point(0, 506)
        Me.ssStatusRule.Name = "ssStatusRule"
        Me.ssStatusRule.Size = New System.Drawing.Size(732, 25)
        Me.ssStatusRule.TabIndex = 2
        Me.ssStatusRule.Text = "StatusStrip2"
        '
        'BlankSpaceLabel
        '
        Me.BlankSpaceLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankSpaceLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankSpaceLabel.Name = "BlankSpaceLabel"
        Me.BlankSpaceLabel.Size = New System.Drawing.Size(532, 20)
        Me.BlankSpaceLabel.Spring = True
        '
        'ComputerNameLabel
        '
        Me.ComputerNameLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ComputerNameLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ComputerNameLabel.Name = "ComputerNameLabel"
        Me.ComputerNameLabel.Size = New System.Drawing.Size(100, 20)
        Me.ComputerNameLabel.Text = "Computer Name"
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(85, 20)
        Me.UserLabel.Text = "User Name"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsStatusRule
        '
        Me.tsStatusRule.AutoSize = False
        Me.tsStatusRule.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnUpdate, Me.tsbtnClose, Me.btnCopy})
        Me.tsStatusRule.Location = New System.Drawing.Point(0, 0)
        Me.tsStatusRule.Name = "tsStatusRule"
        Me.tsStatusRule.Size = New System.Drawing.Size(732, 35)
        Me.tsStatusRule.TabIndex = 0
        Me.tsStatusRule.Text = "ToolStrip1"
        '
        'btnUpdate
        '
        Me.btnUpdate.AutoSize = False
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(35, 33)
        Me.btnUpdate.Text = "Save"
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUpdate.ToolTipText = "Save updated or added rules"
        '
        'tsbtnClose
        '
        Me.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnClose.AutoSize = False
        Me.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnClose.Name = "tsbtnClose"
        Me.tsbtnClose.Size = New System.Drawing.Size(35, 33)
        Me.tsbtnClose.Text = "Close"
        Me.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnClose.ToolTipText = "Close This Form"
        '
        'btnCopy
        '
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(39, 32)
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BackgroundWorker
        '
        '
        'frmStatusRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 531)
        Me.Controls.Add(Me.ssStatusRule)
        Me.Controls.Add(Me.TabRule)
        Me.Controls.Add(Me.tsStatusRule)
        Me.Name = "frmStatusRule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStatusRule"
        Me.TabRule.ResumeLayout(False)
        Me.TabUpdate.ResumeLayout(False)
        Me.TabUpdate.PerformLayout()
        CType(Me.dgvStatusUpdateRule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAdd.ResumeLayout(False)
        Me.TabAdd.PerformLayout()
        CType(Me.dgvError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNoAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOverride, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMissing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatusRule.ResumeLayout(False)
        Me.ssStatusRule.PerformLayout()
        Me.tsStatusRule.ResumeLayout(False)
        Me.tsStatusRule.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabRule As System.Windows.Forms.TabControl
    Friend WithEvents TabUpdate As System.Windows.Forms.TabPage
    Friend WithEvents TabAdd As System.Windows.Forms.TabPage
    Friend WithEvents dgvMissing As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOverride As System.Windows.Forms.DataGridView
    Friend WithEvents ssStatusRule As System.Windows.Forms.StatusStrip
    Friend WithEvents ComputerNameLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankSpaceLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAddOverride As System.Windows.Forms.Button
    Friend WithEvents dgvNoAction As System.Windows.Forms.DataGridView
    Friend WithEvents dgvError As System.Windows.Forms.DataGridView
    Friend WithEvents lblOverrideRecords As System.Windows.Forms.Label
    Friend WithEvents txtTotalOverride As System.Windows.Forms.TextBox
    Friend WithEvents lblMissingRecords As System.Windows.Forms.Label
    Friend WithEvents txtTotalMissing As System.Windows.Forms.TextBox
    Friend WithEvents lblErrorRecords As System.Windows.Forms.Label
    Friend WithEvents txtTotalError As System.Windows.Forms.TextBox
    Friend WithEvents lblNoactionRecords As System.Windows.Forms.Label
    Friend WithEvents txtTotalNoAction As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveError As System.Windows.Forms.Button
    Friend WithEvents btnAddError As System.Windows.Forms.Button
    Friend WithEvents btnRemoveNoAction As System.Windows.Forms.Button
    Friend WithEvents btnAddNoAction As System.Windows.Forms.Button
    Friend WithEvents btnRemoveOverride As System.Windows.Forms.Button
    Friend WithEvents lblOverride As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents lblNoAction As System.Windows.Forms.Label
    Friend WithEvents cbSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblNewStatus As System.Windows.Forms.Label
    Friend WithEvents lblExistingStatus As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvStatusUpdateRule As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalRules As System.Windows.Forms.Label
    Friend WithEvents txtTotalRules As System.Windows.Forms.TextBox
    Friend WithEvents tsStatusRule As System.Windows.Forms.ToolStrip
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboExistingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboNewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnCopy As System.Windows.Forms.ToolStripButton

End Class
