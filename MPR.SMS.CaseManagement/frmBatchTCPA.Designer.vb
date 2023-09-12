'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBatchTCPA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchTCPA))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ssAddressReview = New System.Windows.Forms.StatusStrip()
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.btnCancel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BlankLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tabBatch = New System.Windows.Forms.TabControl()
        Me.tabPhone = New System.Windows.Forms.TabPage()
        Me.chkExcludeCleanedPhones = New System.Windows.Forms.CheckBox()
        Me.optBestPhone = New System.Windows.Forms.RadioButton()
        Me.optAllPhones = New System.Windows.Forms.RadioButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.dgvResults = New System.Windows.Forms.DataGridView()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.chkTestRun = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCaseLocks = New System.Windows.Forms.Button()
        Me.PersonCriteria = New MPR.SMS.UserControls.PersonCriteria()
        Me.CaseCriteria = New MPR.SMS.UserControls.CaseCriteria()
        Me.ssAddressReview.SuspendLayout
        Me.tabBatch.SuspendLayout
        Me.tabPhone.SuspendLayout
        CType(Me.dgvResults,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpResults.SuspendLayout
        Me.SuspendLayout
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
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(83, 20)
        Me.TotalRecordsLabel.Text = "Total Records"
        '
        'tspProgress
        '
        Me.tspProgress.Name = "tspProgress"
        Me.tspProgress.Size = New System.Drawing.Size(100, 19)
        '
        'btnCancel
        '
        Me.btnCancel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.btnCancel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(47, 20)
        Me.btnCancel.Text = "Cancel"
        '
        'BlankLabel
        '
        Me.BlankLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankLabel.Name = "BlankLabel"
        Me.BlankLabel.Size = New System.Drawing.Size(420, 20)
        Me.BlankLabel.Spring = true
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"),System.Drawing.Image)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(20, 20)
        '
        'tabBatch
        '
        Me.tabBatch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabBatch.Controls.Add(Me.tabPhone)
        Me.tabBatch.Location = New System.Drawing.Point(279, 12)
        Me.tabBatch.Name = "tabBatch"
        Me.tabBatch.SelectedIndex = 0
        Me.tabBatch.Size = New System.Drawing.Size(262, 204)
        Me.tabBatch.TabIndex = 2
        '
        'tabPhone
        '
        Me.tabPhone.Controls.Add(Me.chkExcludeCleanedPhones)
        Me.tabPhone.Controls.Add(Me.optBestPhone)
        Me.tabPhone.Controls.Add(Me.optAllPhones)
        Me.tabPhone.Location = New System.Drawing.Point(4, 22)
        Me.tabPhone.Name = "tabPhone"
        Me.tabPhone.Size = New System.Drawing.Size(254, 178)
        Me.tabPhone.TabIndex = 2
        Me.tabPhone.Text = "Phones"
        Me.tabPhone.UseVisualStyleBackColor = true
        '
        'chkExcludeCleanedPhones
        '
        Me.chkExcludeCleanedPhones.AutoSize = true
        Me.chkExcludeCleanedPhones.Checked = true
        Me.chkExcludeCleanedPhones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeCleanedPhones.Location = New System.Drawing.Point(3, 11)
        Me.chkExcludeCleanedPhones.Name = "chkExcludeCleanedPhones"
        Me.chkExcludeCleanedPhones.Size = New System.Drawing.Size(220, 17)
        Me.chkExcludeCleanedPhones.TabIndex = 4
        Me.chkExcludeCleanedPhones.Text = "Exclude phone records looked up today?"
        Me.chkExcludeCleanedPhones.UseVisualStyleBackColor = true
        '
        'optBestPhone
        '
        Me.optBestPhone.AutoSize = true
        Me.optBestPhone.Location = New System.Drawing.Point(3, 59)
        Me.optBestPhone.Name = "optBestPhone"
        Me.optBestPhone.Size = New System.Drawing.Size(101, 17)
        Me.optBestPhone.TabIndex = 1
        Me.optBestPhone.Text = "Best phone only"
        Me.optBestPhone.UseVisualStyleBackColor = true
        '
        'optAllPhones
        '
        Me.optAllPhones.AutoSize = true
        Me.optAllPhones.Checked = true
        Me.optAllPhones.Location = New System.Drawing.Point(3, 36)
        Me.optAllPhones.Name = "optAllPhones"
        Me.optAllPhones.Size = New System.Drawing.Size(74, 17)
        Me.optAllPhones.TabIndex = 0
        Me.optAllPhones.TabStop = true
        Me.optAllPhones.Text = "All phones"
        Me.optAllPhones.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(547, 101)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(133, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClean.ImageIndex = 0
        Me.btnClean.ImageList = Me.ImageList1
        Me.btnClean.Location = New System.Drawing.Point(547, 72)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(133, 23)
        Me.btnClean.TabIndex = 5
        Me.btnClean.Text = "Lookup TCPA Type"
        Me.btnClean.UseVisualStyleBackColor = true
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "VerifyAddress.bmp")
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Location = New System.Drawing.Point(547, 43)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(133, 23)
        Me.btnPreview.TabIndex = 4
        Me.btnPreview.Text = "Retrieve selected"
        Me.btnPreview.UseVisualStyleBackColor = true
        '
        'dgvResults
        '
        Me.dgvResults.AllowUserToAddRows = false
        Me.dgvResults.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResults.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResults.Location = New System.Drawing.Point(3, 16)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.ReadOnly = true
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResults.Size = New System.Drawing.Size(670, 252)
        Me.dgvResults.TabIndex = 0
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.dgvResults)
        Me.grpResults.Location = New System.Drawing.Point(4, 224)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(676, 271)
        Me.grpResults.TabIndex = 9
        Me.grpResults.TabStop = false
        Me.grpResults.Text = "Selected cases"
        '
        'chkTestRun
        '
        Me.chkTestRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.chkTestRun.Location = New System.Drawing.Point(547, 130)
        Me.chkTestRun.Name = "chkTestRun"
        Me.chkTestRun.Size = New System.Drawing.Size(132, 17)
        Me.chkTestRun.TabIndex = 7
        Me.chkTestRun.Text = "Test run"
        Me.chkTestRun.UseVisualStyleBackColor = true
        Me.chkTestRun.Visible = false
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(543, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 78)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = " (Send requests to Melissa Data web-service, show results in grid, but don't save"& _ 
    " results to database.)"
        Me.Label1.Visible = false
        '
        'btnCaseLocks
        '
        Me.btnCaseLocks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCaseLocks.Location = New System.Drawing.Point(547, 12)
        Me.btnCaseLocks.Name = "btnCaseLocks"
        Me.btnCaseLocks.Size = New System.Drawing.Size(133, 23)
        Me.btnCaseLocks.TabIndex = 3
        Me.btnCaseLocks.Text = "View case locks"
        Me.btnCaseLocks.UseVisualStyleBackColor = true
        '
        'PersonCriteria
        '
        Me.PersonCriteria.Location = New System.Drawing.Point(4, 139)
        Me.PersonCriteria.Name = "PersonCriteria"
        Me.PersonCriteria.Size = New System.Drawing.Size(269, 75)
        Me.PersonCriteria.TabIndex = 1
        '
        'CaseCriteria
        '
        Me.CaseCriteria.ExcludeIneligibles = true
        Me.CaseCriteria.InSampleOnly = true
        Me.CaseCriteria.Location = New System.Drawing.Point(4, 12)
        Me.CaseCriteria.Name = "CaseCriteria"
        Me.CaseCriteria.SelectedCaseType = 0
        Me.CaseCriteria.Size = New System.Drawing.Size(269, 121)
        Me.CaseCriteria.TabIndex = 0
        '
        'frmBatchTCPA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmBatchTCPA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Cleaning"
        Me.ssAddressReview.ResumeLayout(false)
        Me.ssAddressReview.PerformLayout
        Me.tabBatch.ResumeLayout(false)
        Me.tabPhone.ResumeLayout(false)
        Me.tabPhone.PerformLayout
        CType(Me.dgvResults,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpResults.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ssAddressReview As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tabBatch As System.Windows.Forms.TabControl
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents btnClean As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents tabPhone As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CaseCriteria As MPR.SMS.UserControls.CaseCriteria
    Friend WithEvents PersonCriteria As MPR.SMS.UserControls.PersonCriteria
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents optBestPhone As System.Windows.Forms.RadioButton
    Friend WithEvents optAllPhones As System.Windows.Forms.RadioButton
    Friend WithEvents chkExcludeCleanedPhones As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkTestRun As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCaseLocks As System.Windows.Forms.Button
End Class
