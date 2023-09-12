'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBatchClean
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchClean))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ssAddressReview = New System.Windows.Forms.StatusStrip
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tspProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.btnCancel = New System.Windows.Forms.ToolStripStatusLabel
        Me.BlankLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tabBatch = New System.Windows.Forms.TabControl
        Me.tabAddress = New System.Windows.Forms.TabPage
        Me.chkExcludeCleanedAddresses = New System.Windows.Forms.CheckBox
        Me.cboAddressType = New MPR.SMS.UserControls.AddressTypeComboBox
        Me.chkBestCheck = New System.Windows.Forms.CheckBox
        Me.chkBestMailing = New System.Windows.Forms.CheckBox
        Me.optAddressType = New System.Windows.Forms.RadioButton
        Me.optBest = New System.Windows.Forms.RadioButton
        Me.chkBestPhysical = New System.Windows.Forms.CheckBox
        Me.optAll = New System.Windows.Forms.RadioButton
        Me.tabPhone = New System.Windows.Forms.TabPage
        Me.chkExcludeCleanedPhones = New System.Windows.Forms.CheckBox
        Me.cboPhoneType = New MPR.SMS.UserControls.PhoneTypeComboBox
        Me.optPhoneType = New System.Windows.Forms.RadioButton
        Me.optBestPhone = New System.Windows.Forms.RadioButton
        Me.optAllPhones = New System.Windows.Forms.RadioButton
        Me.tabName = New System.Windows.Forms.TabPage
        Me.optClean = New System.Windows.Forms.RadioButton
        Me.optProperCase = New System.Windows.Forms.RadioButton
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnClean = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPreview = New System.Windows.Forms.Button
        Me.dgvResults = New System.Windows.Forms.DataGridView
        Me.CaseCriteria = New MPR.SMS.UserControls.CaseCriteria
        Me.PersonCriteria = New MPR.SMS.UserControls.PersonCriteria
        Me.grpResults = New System.Windows.Forms.GroupBox
        Me.chkTestRun = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCaseLocks = New System.Windows.Forms.Button
        Me.ssAddressReview.SuspendLayout()
        Me.tabBatch.SuspendLayout()
        Me.tabAddress.SuspendLayout()
        Me.tabPhone.SuspendLayout()
        Me.tabName.SuspendLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssAddressReview
        '
        Me.ssAddressReview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRecordsLabel, Me.tspProgress, Me.btnCancel, Me.BlankLabel, Me.UserLabel})
        Me.ssAddressReview.Location = New System.Drawing.Point(0, 498)
        Me.ssAddressReview.Name = "ssAddressReview"
        Me.ssAddressReview.Size = New System.Drawing.Size(687, 25)
        Me.ssAddressReview.TabIndex = 4
        Me.ssAddressReview.Text = "StatusStrip1"
        '
        'TotalRecordsLabel
        '
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(77, 20)
        Me.TotalRecordsLabel.Text = "Total Records"
        '
        'tspProgress
        '
        Me.tspProgress.Name = "tspProgress"
        Me.tspProgress.Size = New System.Drawing.Size(100, 19)
        '
        'btnCancel
        '
        Me.btnCancel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.btnCancel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(43, 20)
        Me.btnCancel.Text = "Cancel"
        '
        'BlankLabel
        '
        Me.BlankLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankLabel.Name = "BlankLabel"
        Me.BlankLabel.Size = New System.Drawing.Size(430, 20)
        Me.BlankLabel.Spring = True
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(20, 20)
        '
        'tabBatch
        '
        Me.tabBatch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabBatch.Controls.Add(Me.tabAddress)
        Me.tabBatch.Controls.Add(Me.tabPhone)
        Me.tabBatch.Controls.Add(Me.tabName)
        Me.tabBatch.Location = New System.Drawing.Point(279, 12)
        Me.tabBatch.Name = "tabBatch"
        Me.tabBatch.SelectedIndex = 0
        Me.tabBatch.Size = New System.Drawing.Size(262, 204)
        Me.tabBatch.TabIndex = 2
        '
        'tabAddress
        '
        Me.tabAddress.Controls.Add(Me.chkExcludeCleanedAddresses)
        Me.tabAddress.Controls.Add(Me.cboAddressType)
        Me.tabAddress.Controls.Add(Me.chkBestCheck)
        Me.tabAddress.Controls.Add(Me.chkBestMailing)
        Me.tabAddress.Controls.Add(Me.optAddressType)
        Me.tabAddress.Controls.Add(Me.optBest)
        Me.tabAddress.Controls.Add(Me.chkBestPhysical)
        Me.tabAddress.Controls.Add(Me.optAll)
        Me.tabAddress.Location = New System.Drawing.Point(4, 22)
        Me.tabAddress.Name = "tabAddress"
        Me.tabAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddress.Size = New System.Drawing.Size(254, 178)
        Me.tabAddress.TabIndex = 0
        Me.tabAddress.Text = "Addresses"
        Me.tabAddress.UseVisualStyleBackColor = True
        '
        'chkExcludeCleanedAddresses
        '
        Me.chkExcludeCleanedAddresses.AutoSize = True
        Me.chkExcludeCleanedAddresses.Checked = True
        Me.chkExcludeCleanedAddresses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeCleanedAddresses.Location = New System.Drawing.Point(3, 11)
        Me.chkExcludeCleanedAddresses.Name = "chkExcludeCleanedAddresses"
        Me.chkExcludeCleanedAddresses.Size = New System.Drawing.Size(185, 17)
        Me.chkExcludeCleanedAddresses.TabIndex = 7
        Me.chkExcludeCleanedAddresses.Text = "Exclude previously cleaned data?"
        Me.chkExcludeCleanedAddresses.UseVisualStyleBackColor = True
        '
        'cboAddressType
        '
        Me.cboAddressType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAddressType.Enabled = False
        Me.cboAddressType.Location = New System.Drawing.Point(95, 151)
        Me.cboAddressType.MyLabel = "Address type:"
        Me.cboAddressType.MyLabelVisible = False
        Me.cboAddressType.Name = "cboAddressType"
        Me.cboAddressType.SelectedAddressType = Nothing
        Me.cboAddressType.SelectedAddressTypeID = 0
        Me.cboAddressType.Size = New System.Drawing.Size(146, 24)
        Me.cboAddressType.TabIndex = 6
        '
        'chkBestCheck
        '
        Me.chkBestCheck.AutoSize = True
        Me.chkBestCheck.Enabled = False
        Me.chkBestCheck.Location = New System.Drawing.Point(25, 128)
        Me.chkBestCheck.Name = "chkBestCheck"
        Me.chkBestCheck.Size = New System.Drawing.Size(57, 17)
        Me.chkBestCheck.TabIndex = 4
        Me.chkBestCheck.Text = "Check"
        Me.chkBestCheck.UseVisualStyleBackColor = True
        '
        'chkBestMailing
        '
        Me.chkBestMailing.AutoSize = True
        Me.chkBestMailing.Enabled = False
        Me.chkBestMailing.Location = New System.Drawing.Point(25, 105)
        Me.chkBestMailing.Name = "chkBestMailing"
        Me.chkBestMailing.Size = New System.Drawing.Size(59, 17)
        Me.chkBestMailing.TabIndex = 3
        Me.chkBestMailing.Text = "Mailing"
        Me.chkBestMailing.UseVisualStyleBackColor = True
        '
        'optAddressType
        '
        Me.optAddressType.AutoSize = True
        Me.optAddressType.Location = New System.Drawing.Point(3, 151)
        Me.optAddressType.Name = "optAddressType"
        Me.optAddressType.Size = New System.Drawing.Size(93, 17)
        Me.optAddressType.TabIndex = 5
        Me.optAddressType.Text = "This type only:"
        Me.optAddressType.UseVisualStyleBackColor = True
        '
        'optBest
        '
        Me.optBest.AutoSize = True
        Me.optBest.Location = New System.Drawing.Point(3, 59)
        Me.optBest.Name = "optBest"
        Me.optBest.Size = New System.Drawing.Size(111, 17)
        Me.optBest.TabIndex = 1
        Me.optBest.Text = "Best address only:"
        Me.optBest.UseVisualStyleBackColor = True
        '
        'chkBestPhysical
        '
        Me.chkBestPhysical.AutoSize = True
        Me.chkBestPhysical.Enabled = False
        Me.chkBestPhysical.Location = New System.Drawing.Point(25, 82)
        Me.chkBestPhysical.Name = "chkBestPhysical"
        Me.chkBestPhysical.Size = New System.Drawing.Size(65, 17)
        Me.chkBestPhysical.TabIndex = 2
        Me.chkBestPhysical.Text = "Physical"
        Me.chkBestPhysical.UseVisualStyleBackColor = True
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(3, 36)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(87, 17)
        Me.optAll.TabIndex = 0
        Me.optAll.TabStop = True
        Me.optAll.Text = "All addresses"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'tabPhone
        '
        Me.tabPhone.Controls.Add(Me.chkExcludeCleanedPhones)
        Me.tabPhone.Controls.Add(Me.cboPhoneType)
        Me.tabPhone.Controls.Add(Me.optPhoneType)
        Me.tabPhone.Controls.Add(Me.optBestPhone)
        Me.tabPhone.Controls.Add(Me.optAllPhones)
        Me.tabPhone.Location = New System.Drawing.Point(4, 22)
        Me.tabPhone.Name = "tabPhone"
        Me.tabPhone.Size = New System.Drawing.Size(254, 178)
        Me.tabPhone.TabIndex = 2
        Me.tabPhone.Text = "Phones"
        Me.tabPhone.UseVisualStyleBackColor = True
        '
        'chkExcludeCleanedPhones
        '
        Me.chkExcludeCleanedPhones.AutoSize = True
        Me.chkExcludeCleanedPhones.Checked = True
        Me.chkExcludeCleanedPhones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeCleanedPhones.Location = New System.Drawing.Point(3, 11)
        Me.chkExcludeCleanedPhones.Name = "chkExcludeCleanedPhones"
        Me.chkExcludeCleanedPhones.Size = New System.Drawing.Size(185, 17)
        Me.chkExcludeCleanedPhones.TabIndex = 4
        Me.chkExcludeCleanedPhones.Text = "Exclude previously cleaned data?"
        Me.chkExcludeCleanedPhones.UseVisualStyleBackColor = True
        '
        'cboPhoneType
        '
        Me.cboPhoneType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPhoneType.Enabled = False
        Me.cboPhoneType.Location = New System.Drawing.Point(95, 82)
        Me.cboPhoneType.MyLabel = "Phone type:"
        Me.cboPhoneType.MyLabelVisible = False
        Me.cboPhoneType.Name = "cboPhoneType"
        Me.cboPhoneType.SelectedPhoneType = Nothing
        Me.cboPhoneType.SelectedPhoneTypeID = 0
        Me.cboPhoneType.Size = New System.Drawing.Size(160, 24)
        Me.cboPhoneType.TabIndex = 3
        '
        'optPhoneType
        '
        Me.optPhoneType.AutoSize = True
        Me.optPhoneType.Location = New System.Drawing.Point(3, 82)
        Me.optPhoneType.Name = "optPhoneType"
        Me.optPhoneType.Size = New System.Drawing.Size(93, 17)
        Me.optPhoneType.TabIndex = 2
        Me.optPhoneType.Text = "This type only:"
        Me.optPhoneType.UseVisualStyleBackColor = True
        '
        'optBestPhone
        '
        Me.optBestPhone.AutoSize = True
        Me.optBestPhone.Location = New System.Drawing.Point(3, 59)
        Me.optBestPhone.Name = "optBestPhone"
        Me.optBestPhone.Size = New System.Drawing.Size(101, 17)
        Me.optBestPhone.TabIndex = 1
        Me.optBestPhone.Text = "Best phone only"
        Me.optBestPhone.UseVisualStyleBackColor = True
        '
        'optAllPhones
        '
        Me.optAllPhones.AutoSize = True
        Me.optAllPhones.Checked = True
        Me.optAllPhones.Location = New System.Drawing.Point(3, 36)
        Me.optAllPhones.Name = "optAllPhones"
        Me.optAllPhones.Size = New System.Drawing.Size(74, 17)
        Me.optAllPhones.TabIndex = 0
        Me.optAllPhones.TabStop = True
        Me.optAllPhones.Text = "All phones"
        Me.optAllPhones.UseVisualStyleBackColor = True
        '
        'tabName
        '
        Me.tabName.Controls.Add(Me.optClean)
        Me.tabName.Controls.Add(Me.optProperCase)
        Me.tabName.Location = New System.Drawing.Point(4, 22)
        Me.tabName.Name = "tabName"
        Me.tabName.Padding = New System.Windows.Forms.Padding(3)
        Me.tabName.Size = New System.Drawing.Size(254, 178)
        Me.tabName.TabIndex = 1
        Me.tabName.Text = "Names"
        Me.tabName.UseVisualStyleBackColor = True
        '
        'optClean
        '
        Me.optClean.AutoSize = True
        Me.optClean.Location = New System.Drawing.Point(3, 81)
        Me.optClean.Name = "optClean"
        Me.optClean.Size = New System.Drawing.Size(230, 17)
        Me.optClean.TabIndex = 1
        Me.optClean.Text = "Clean and genderize (send to Melissa Data)"
        Me.optClean.UseVisualStyleBackColor = True
        '
        'optProperCase
        '
        Me.optProperCase.AutoSize = True
        Me.optProperCase.Checked = True
        Me.optProperCase.Location = New System.Drawing.Point(3, 58)
        Me.optProperCase.Name = "optProperCase"
        Me.optProperCase.Size = New System.Drawing.Size(138, 17)
        Me.optProperCase.TabIndex = 0
        Me.optProperCase.TabStop = True
        Me.optProperCase.Text = "Proper case names only"
        Me.optProperCase.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(547, 101)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(133, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClean.ImageIndex = 0
        Me.btnClean.ImageList = Me.ImageList1
        Me.btnClean.Location = New System.Drawing.Point(547, 72)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(133, 23)
        Me.btnClean.TabIndex = 5
        Me.btnClean.Text = "Clean addresses"
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "VerifyAddress.bmp")
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Location = New System.Drawing.Point(547, 43)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(133, 23)
        Me.btnPreview.TabIndex = 4
        Me.btnPreview.Text = "Retrieve selected"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'dgvResults
        '
        Me.dgvResults.AllowUserToAddRows = False
        Me.dgvResults.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResults.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResults.Location = New System.Drawing.Point(3, 16)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvResults.Size = New System.Drawing.Size(670, 252)
        Me.dgvResults.TabIndex = 0
        '
        'CaseCriteria
        '
        Me.CaseCriteria.ExcludeIneligibles = True
        Me.CaseCriteria.InSampleOnly = True
        Me.CaseCriteria.Location = New System.Drawing.Point(4, 12)
        Me.CaseCriteria.Name = "CaseCriteria"
        Me.CaseCriteria.SelectedCaseType = 0
        Me.CaseCriteria.Size = New System.Drawing.Size(269, 121)
        Me.CaseCriteria.TabIndex = 0
        '
        'PersonCriteria
        '
        Me.PersonCriteria.Location = New System.Drawing.Point(4, 139)
        Me.PersonCriteria.Name = "PersonCriteria"
        Me.PersonCriteria.Size = New System.Drawing.Size(269, 75)
        Me.PersonCriteria.TabIndex = 1
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.dgvResults)
        Me.grpResults.Location = New System.Drawing.Point(4, 224)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(676, 271)
        Me.grpResults.TabIndex = 9
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Selected cases"
        '
        'chkTestRun
        '
        Me.chkTestRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTestRun.Location = New System.Drawing.Point(547, 130)
        Me.chkTestRun.Name = "chkTestRun"
        Me.chkTestRun.Size = New System.Drawing.Size(132, 17)
        Me.chkTestRun.TabIndex = 7
        Me.chkTestRun.Text = "Test run"
        Me.chkTestRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(543, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 78)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = " (Send requests to Melissa Data web-service, show results in grid, but don't save" & _
            " results to database.)"
        '
        'btnCaseLocks
        '
        Me.btnCaseLocks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCaseLocks.Location = New System.Drawing.Point(547, 12)
        Me.btnCaseLocks.Name = "btnCaseLocks"
        Me.btnCaseLocks.Size = New System.Drawing.Size(133, 23)
        Me.btnCaseLocks.TabIndex = 3
        Me.btnCaseLocks.Text = "View case locks"
        Me.btnCaseLocks.UseVisualStyleBackColor = True
        '
        'frmBatchClean
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 523)
        Me.Controls.Add(Me.btnCaseLocks)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkTestRun)
        Me.Controls.Add(Me.PersonCriteria)
        Me.Controls.Add(Me.tabBatch)
        Me.Controls.Add(Me.CaseCriteria)
        Me.Controls.Add(Me.ssAddressReview)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnClean)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBatchClean"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Cleaning"
        Me.ssAddressReview.ResumeLayout(False)
        Me.ssAddressReview.PerformLayout()
        Me.tabBatch.ResumeLayout(False)
        Me.tabAddress.ResumeLayout(False)
        Me.tabAddress.PerformLayout()
        Me.tabPhone.ResumeLayout(False)
        Me.tabPhone.PerformLayout()
        Me.tabName.ResumeLayout(False)
        Me.tabName.PerformLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResults.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssAddressReview As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tabBatch As System.Windows.Forms.TabControl
    Friend WithEvents tabAddress As System.Windows.Forms.TabPage
    Friend WithEvents tabName As System.Windows.Forms.TabPage
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents btnClean As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents tabPhone As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents optAddressType As System.Windows.Forms.RadioButton
    Friend WithEvents optBest As System.Windows.Forms.RadioButton
    Friend WithEvents chkBestPhysical As System.Windows.Forms.CheckBox
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents chkBestCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkBestMailing As System.Windows.Forms.CheckBox
    Friend WithEvents cboAddressType As MPR.SMS.UserControls.AddressTypeComboBox
    Friend WithEvents CaseCriteria As MPR.SMS.UserControls.CaseCriteria
    Friend WithEvents PersonCriteria As MPR.SMS.UserControls.PersonCriteria
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents cboPhoneType As MPR.SMS.UserControls.PhoneTypeComboBox
    Friend WithEvents optPhoneType As System.Windows.Forms.RadioButton
    Friend WithEvents optBestPhone As System.Windows.Forms.RadioButton
    Friend WithEvents optAllPhones As System.Windows.Forms.RadioButton
    Friend WithEvents chkExcludeCleanedAddresses As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeCleanedPhones As System.Windows.Forms.CheckBox
    Friend WithEvents optClean As System.Windows.Forms.RadioButton
    Friend WithEvents optProperCase As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkTestRun As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCaseLocks As System.Windows.Forms.Button
End Class
