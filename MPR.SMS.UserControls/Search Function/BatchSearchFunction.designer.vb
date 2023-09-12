'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatchSearchFunction
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchSearchFunction))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainerSearch = New System.Windows.Forms.SplitContainer()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.btnPrintBatchSheet = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.imlSearch = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PanelSearchCriteria = New System.Windows.Forms.Panel()
        Me.lnkCopyToAdvanced = New System.Windows.Forms.LinkLabel()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabPageBasic = New System.Windows.Forms.TabPage()
        Me.dgvSearchCriteria = New System.Windows.Forms.DataGridView()
        Me.Field = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comparison = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Expression = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabPageAdvanced = New System.Windows.Forms.TabPage()
        Me.txtAdvancedSearch = New System.Windows.Forms.TextBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainerSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerSearch.Panel1.SuspendLayout()
        Me.SplitContainerSearch.Panel2.SuspendLayout()
        Me.SplitContainerSearch.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButtons.SuspendLayout()
        Me.PanelSearchCriteria.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabPageBasic.SuspendLayout()
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageAdvanced.SuspendLayout()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerSearch
        '
        Me.SplitContainerSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerSearch.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerSearch.Name = "SplitContainerSearch"
        Me.SplitContainerSearch.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerSearch.Panel1
        '
        Me.SplitContainerSearch.Panel1.Controls.Add(Me.PanelLogo)
        Me.SplitContainerSearch.Panel1.Controls.Add(Me.PanelButtons)
        Me.SplitContainerSearch.Panel1.Controls.Add(Me.PanelSearchCriteria)
        '
        'SplitContainerSearch.Panel2
        '
        Me.SplitContainerSearch.Panel2.Controls.Add(Me.dgvSearchResults)
        Me.SplitContainerSearch.Size = New System.Drawing.Size(1002, 580)
        Me.SplitContainerSearch.SplitterDistance = 292
        Me.SplitContainerSearch.TabIndex = 0
        Me.SplitContainerSearch.TabStop = False
        '
        'PanelLogo
        '
        Me.PanelLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLogo.Controls.Add(Me.PictureBoxLogo)
        Me.PanelLogo.Location = New System.Drawing.Point(785, 4)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(214, 52)
        Me.PanelLogo.TabIndex = 2
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxLogo.Image = CType(resources.GetObject("PictureBoxLogo.Image"), System.Drawing.Image)
        Me.PictureBoxLogo.Location = New System.Drawing.Point(3, 0)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(211, 52)
        Me.PictureBoxLogo.TabIndex = 0
        Me.PictureBoxLogo.TabStop = False
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.Controls.Add(Me.btnPrintBatchSheet)
        Me.PanelButtons.Controls.Add(Me.btnExcel)
        Me.PanelButtons.Controls.Add(Me.btnClose)
        Me.PanelButtons.Controls.Add(Me.btnClear)
        Me.PanelButtons.Controls.Add(Me.btnSearch)
        Me.PanelButtons.Location = New System.Drawing.Point(777, 61)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(222, 218)
        Me.PanelButtons.TabIndex = 1
        '
        'btnPrintBatchSheet
        '
        Me.btnPrintBatchSheet.Image = CType(resources.GetObject("btnPrintBatchSheet.Image"), System.Drawing.Image)
        Me.btnPrintBatchSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintBatchSheet.Location = New System.Drawing.Point(78, 169)
        Me.btnPrintBatchSheet.Name = "btnPrintBatchSheet"
        Me.btnPrintBatchSheet.Size = New System.Drawing.Size(144, 36)
        Me.btnPrintBatchSheet.TabIndex = 5
        Me.btnPrintBatchSheet.Text = "&Print Batch Sheet"
        Me.btnPrintBatchSheet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintBatchSheet.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(78, 127)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(144, 36)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "&Export to Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(78, 85)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(144, 36)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.ImageIndex = 0
        Me.btnClear.ImageList = Me.imlSearch
        Me.btnClear.Location = New System.Drawing.Point(78, 43)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(144, 36)
        Me.btnClear.TabIndex = 1
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'imlSearch
        '
        Me.imlSearch.ImageStream = CType(resources.GetObject("imlSearch.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSearch.TransparentColor = System.Drawing.Color.White
        Me.imlSearch.Images.SetKeyName(0, "delete.bmp")
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(78, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 36)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PanelSearchCriteria
        '
        Me.PanelSearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSearchCriteria.Controls.Add(Me.lnkCopyToAdvanced)
        Me.PanelSearchCriteria.Controls.Add(Me.tabSearch)
        Me.PanelSearchCriteria.Location = New System.Drawing.Point(3, 3)
        Me.PanelSearchCriteria.Name = "PanelSearchCriteria"
        Me.PanelSearchCriteria.Size = New System.Drawing.Size(767, 286)
        Me.PanelSearchCriteria.TabIndex = 0
        '
        'lnkCopyToAdvanced
        '
        Me.lnkCopyToAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCopyToAdvanced.AutoSize = True
        Me.lnkCopyToAdvanced.Location = New System.Drawing.Point(670, 6)
        Me.lnkCopyToAdvanced.Name = "lnkCopyToAdvanced"
        Me.lnkCopyToAdvanced.Size = New System.Drawing.Size(99, 13)
        Me.lnkCopyToAdvanced.TabIndex = 1
        Me.lnkCopyToAdvanced.TabStop = True
        Me.lnkCopyToAdvanced.Text = "Copy To Advanced"
        '
        'tabSearch
        '
        Me.tabSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSearch.Controls.Add(Me.tabPageBasic)
        Me.tabSearch.Controls.Add(Me.tabPageAdvanced)
        Me.tabSearch.Location = New System.Drawing.Point(0, 3)
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(769, 283)
        Me.tabSearch.TabIndex = 0
        Me.tabSearch.TabStop = False
        '
        'tabPageBasic
        '
        Me.tabPageBasic.Controls.Add(Me.dgvSearchCriteria)
        Me.tabPageBasic.Location = New System.Drawing.Point(4, 22)
        Me.tabPageBasic.Name = "tabPageBasic"
        Me.tabPageBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageBasic.Size = New System.Drawing.Size(761, 257)
        Me.tabPageBasic.TabIndex = 0
        Me.tabPageBasic.Text = "Basic"
        Me.tabPageBasic.ToolTipText = "Basic Search"
        Me.tabPageBasic.UseVisualStyleBackColor = True
        '
        'dgvSearchCriteria
        '
        Me.dgvSearchCriteria.AllowUserToAddRows = False
        Me.dgvSearchCriteria.AllowUserToDeleteRows = False
        Me.dgvSearchCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSearchCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchCriteria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Field, Me.Comparison, Me.Expression})
        Me.dgvSearchCriteria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearchCriteria.Location = New System.Drawing.Point(3, 3)
        Me.dgvSearchCriteria.Name = "dgvSearchCriteria"
        Me.dgvSearchCriteria.RowHeadersVisible = False
        Me.dgvSearchCriteria.RowTemplate.Height = 24
        Me.dgvSearchCriteria.Size = New System.Drawing.Size(755, 251)
        Me.dgvSearchCriteria.TabIndex = 0
        '
        'Field
        '
        Me.Field.HeaderText = "Field"
        Me.Field.Name = "Field"
        Me.Field.ReadOnly = True
        '
        'Comparison
        '
        Me.Comparison.HeaderText = "Comparison"
        Me.Comparison.Items.AddRange(New Object() {"", "is equal to", "is not equal to", "is less than", "is less than or equal to", "is greater than", "is greater than or equal to", "is empty", "is not empty", "begins with", "ends with", "contains"})
        Me.Comparison.MaxDropDownItems = 20
        Me.Comparison.Name = "Comparison"
        Me.Comparison.Width = 150
        '
        'Expression
        '
        Me.Expression.HeaderText = "Expression"
        Me.Expression.Name = "Expression"
        Me.Expression.Width = 150
        '
        'tabPageAdvanced
        '
        Me.tabPageAdvanced.Controls.Add(Me.txtAdvancedSearch)
        Me.tabPageAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAdvanced.Name = "tabPageAdvanced"
        Me.tabPageAdvanced.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAdvanced.Size = New System.Drawing.Size(761, 257)
        Me.tabPageAdvanced.TabIndex = 1
        Me.tabPageAdvanced.Text = "Advanced"
        Me.tabPageAdvanced.ToolTipText = "Advanced-user Search"
        Me.tabPageAdvanced.UseVisualStyleBackColor = True
        '
        'txtAdvancedSearch
        '
        Me.txtAdvancedSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdvancedSearch.Location = New System.Drawing.Point(3, 3)
        Me.txtAdvancedSearch.Multiline = True
        Me.txtAdvancedSearch.Name = "txtAdvancedSearch"
        Me.txtAdvancedSearch.Size = New System.Drawing.Size(755, 251)
        Me.txtAdvancedSearch.TabIndex = 0
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.AllowUserToAddRows = False
        Me.dgvSearchResults.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvSearchResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSearchResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearchResults.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearchResults.MultiSelect = False
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.ReadOnly = True
        Me.dgvSearchResults.RowHeadersWidth = 25
        Me.dgvSearchResults.RowTemplate.Height = 18
        Me.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearchResults.Size = New System.Drawing.Size(1002, 284)
        Me.dgvSearchResults.TabIndex = 0
        '
        'BatchSearchFunction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerSearch)
        Me.Name = "BatchSearchFunction"
        Me.Size = New System.Drawing.Size(1002, 580)
        Me.SplitContainerSearch.Panel1.ResumeLayout(False)
        Me.SplitContainerSearch.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerSearch.ResumeLayout(False)
        Me.PanelLogo.ResumeLayout(False)
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelSearchCriteria.ResumeLayout(False)
        Me.PanelSearchCriteria.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabPageBasic.ResumeLayout(False)
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageAdvanced.ResumeLayout(False)
        Me.tabPageAdvanced.PerformLayout()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerSearch As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents PanelSearchCriteria As System.Windows.Forms.Panel
    Friend WithEvents PanelLogo As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabPageBasic As System.Windows.Forms.TabPage
    Friend WithEvents tabPageAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents dgvSearchCriteria As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtAdvancedSearch As System.Windows.Forms.TextBox
    Friend WithEvents Field As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comparison As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Expression As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lnkCopyToAdvanced As System.Windows.Forms.LinkLabel
    Friend WithEvents imlSearch As System.Windows.Forms.ImageList
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrintBatchSheet As System.Windows.Forms.Button

End Class
