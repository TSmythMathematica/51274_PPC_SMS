'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchMPRIDFunction
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchMPRIDFunction))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.imlSearch = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.txtMPRID = New System.Windows.Forms.TextBox()
        Me.lblMPRID = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
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
        Me.PanelButtons.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearchCriteria.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabPageBasic.SuspendLayout()
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlSearch
        '
        Me.imlSearch.ImageStream = CType(resources.GetObject("imlSearch.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSearch.TransparentColor = System.Drawing.Color.White
        Me.imlSearch.Images.SetKeyName(0, "delete.bmp")
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.Controls.Add(Me.lblErrorMsg)
        Me.PanelButtons.Controls.Add(Me.txtMPRID)
        Me.PanelButtons.Controls.Add(Me.lblMPRID)
        Me.PanelButtons.Controls.Add(Me.btnClose)
        Me.PanelButtons.Controls.Add(Me.btnClear)
        Me.PanelButtons.Controls.Add(Me.btnSearch)
        Me.PanelButtons.Location = New System.Drawing.Point(41, 25)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(344, 164)
        Me.PanelButtons.TabIndex = 5
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.AutoSize = True
        Me.lblErrorMsg.Location = New System.Drawing.Point(12, 74)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorMsg.TabIndex = 5
        '
        'txtMPRID
        '
        Me.txtMPRID.Location = New System.Drawing.Point(6, 38)
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.Size = New System.Drawing.Size(143, 20)
        Me.txtMPRID.TabIndex = 4
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Location = New System.Drawing.Point(3, 13)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(70, 13)
        Me.lblMPRID.TabIndex = 3
        Me.lblMPRID.Text = "Enter MPRID"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(200, 106)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 36)
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
        Me.btnClear.Location = New System.Drawing.Point(200, 64)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(95, 36)
        Me.btnClear.TabIndex = 1
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(200, 22)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 36)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "&Open"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxLogo.Image = CType(resources.GetObject("PictureBoxLogo.Image"), System.Drawing.Image)
        Me.PictureBoxLogo.Location = New System.Drawing.Point(419, 13)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(183, 87)
        Me.PictureBoxLogo.TabIndex = 2
        Me.PictureBoxLogo.TabStop = False
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
        Me.dgvSearchResults.Enabled = False
        Me.dgvSearchResults.Location = New System.Drawing.Point(17, 216)
        Me.dgvSearchResults.MultiSelect = False
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.ReadOnly = True
        Me.dgvSearchResults.RowHeadersWidth = 25
        Me.dgvSearchResults.RowTemplate.Height = 18
        Me.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearchResults.Size = New System.Drawing.Size(620, 36)
        Me.dgvSearchResults.TabIndex = 3
        Me.dgvSearchResults.Visible = False
        '
        'PanelSearchCriteria
        '
        Me.PanelSearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSearchCriteria.Controls.Add(Me.lnkCopyToAdvanced)
        Me.PanelSearchCriteria.Controls.Add(Me.tabSearch)
        Me.PanelSearchCriteria.Enabled = False
        Me.PanelSearchCriteria.Location = New System.Drawing.Point(521, 139)
        Me.PanelSearchCriteria.Name = "PanelSearchCriteria"
        Me.PanelSearchCriteria.Size = New System.Drawing.Size(131, 0)
        Me.PanelSearchCriteria.TabIndex = 4
        Me.PanelSearchCriteria.Visible = False
        '
        'lnkCopyToAdvanced
        '
        Me.lnkCopyToAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCopyToAdvanced.AutoSize = True
        Me.lnkCopyToAdvanced.Location = New System.Drawing.Point(34, 6)
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
        Me.tabSearch.Location = New System.Drawing.Point(0, 6)
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(116, 0)
        Me.tabSearch.TabIndex = 0
        Me.tabSearch.TabStop = False
        '
        'tabPageBasic
        '
        Me.tabPageBasic.Controls.Add(Me.dgvSearchCriteria)
        Me.tabPageBasic.Location = New System.Drawing.Point(4, 22)
        Me.tabPageBasic.Name = "tabPageBasic"
        Me.tabPageBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageBasic.Size = New System.Drawing.Size(108, 0)
        Me.tabPageBasic.TabIndex = 0
        Me.tabPageBasic.Text = "Basic"
        Me.tabPageBasic.ToolTipText = "Basic Search"
        Me.tabPageBasic.UseVisualStyleBackColor = True
        '
        'dgvSearchCriteria
        '
        Me.dgvSearchCriteria.AllowUserToAddRows = False
        Me.dgvSearchCriteria.AllowUserToDeleteRows = False
        Me.dgvSearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSearchCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSearchCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchCriteria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Field, Me.Comparison, Me.Expression})
        Me.dgvSearchCriteria.Location = New System.Drawing.Point(3, 3)
        Me.dgvSearchCriteria.Name = "dgvSearchCriteria"
        Me.dgvSearchCriteria.RowHeadersVisible = False
        Me.dgvSearchCriteria.RowTemplate.Height = 24
        Me.dgvSearchCriteria.Size = New System.Drawing.Size(102, 0)
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
        Me.tabPageAdvanced.Size = New System.Drawing.Size(108, 0)
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
        Me.txtAdvancedSearch.Size = New System.Drawing.Size(102, 0)
        Me.txtAdvancedSearch.TabIndex = 0
        '
        'SearchMPRIDFunction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelButtons)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.Controls.Add(Me.dgvSearchResults)
        Me.Controls.Add(Me.PanelSearchCriteria)
        Me.Name = "SearchMPRIDFunction"
        Me.Size = New System.Drawing.Size(648, 275)
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelButtons.PerformLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearchCriteria.ResumeLayout(False)
        Me.PanelSearchCriteria.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabPageBasic.ResumeLayout(False)
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageAdvanced.ResumeLayout(False)
        Me.tabPageAdvanced.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imlSearch As ImageList
    Friend WithEvents PanelButtons As Panel
    Friend WithEvents lblErrorMsg As Label
    Friend WithEvents txtMPRID As TextBox
    Friend WithEvents lblMPRID As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents dgvSearchResults As DataGridView
    Friend WithEvents PanelSearchCriteria As Panel
    Friend WithEvents lnkCopyToAdvanced As LinkLabel
    Friend WithEvents tabSearch As TabControl
    Friend WithEvents tabPageBasic As TabPage
    Friend WithEvents dgvSearchCriteria As DataGridView
    Friend WithEvents Field As DataGridViewTextBoxColumn
    Friend WithEvents Comparison As DataGridViewComboBoxColumn
    Friend WithEvents Expression As DataGridViewTextBoxColumn
    Friend WithEvents tabPageAdvanced As TabPage
    Friend WithEvents txtAdvancedSearch As TextBox
End Class
