'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchSurveyResponse
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchSurveyResponse))
        Me.cboComparision3 = New System.Windows.Forms.ComboBox()
        Me.txtVal3 = New System.Windows.Forms.TextBox()
        Me.dgvSearchResults = New System.Windows.Forms.DataGridView()
        Me.cboVar3 = New System.Windows.Forms.ComboBox()
        Me.lblComparision = New System.Windows.Forms.Label()
        Me.cboComparision2 = New System.Windows.Forms.ComboBox()
        Me.tabPageAdvanced = New System.Windows.Forms.TabPage()
        Me.txtAdvancedSearch = New System.Windows.Forms.TextBox()
        Me.tabPageQueryBuilder = New System.Windows.Forms.TabPage()
        Me.cboComparision1 = New System.Windows.Forms.ComboBox()
        Me.rbOr = New System.Windows.Forms.RadioButton()
        Me.rbAnd = New System.Windows.Forms.RadioButton()
        Me.txtVal2 = New System.Windows.Forms.TextBox()
        Me.txtVal1 = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblQuestionNumber = New System.Windows.Forms.Label()
        Me.cboVar2 = New System.Windows.Forms.ComboBox()
        Me.cboVar1 = New System.Windows.Forms.ComboBox()
        Me.Expression = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comparison = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Field = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.SplitContainerSearch = New System.Windows.Forms.SplitContainer()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.cbIncludeHistory = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PanelSearchCriteria = New System.Windows.Forms.Panel()
        Me.lnkCopyToAdvanced = New System.Windows.Forms.LinkLabel()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabPageBasic = New System.Windows.Forms.TabPage()
        Me.cboVariableList = New System.Windows.Forms.ComboBox()
        Me.dgvSearchCriteria = New System.Windows.Forms.DataGridView()
        Me.grpSearchResult = New System.Windows.Forms.GroupBox()
        Me.cbGridUpdate = New System.Windows.Forms.CheckBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageAdvanced.SuspendLayout()
        Me.tabPageQueryBuilder.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerSearch.Panel1.SuspendLayout()
        Me.SplitContainerSearch.Panel2.SuspendLayout()
        Me.SplitContainerSearch.SuspendLayout()
        Me.PanelButtons.SuspendLayout()
        Me.PanelSearchCriteria.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabPageBasic.SuspendLayout()
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboComparision3
        '
        Me.cboComparision3.FormattingEnabled = True
        Me.cboComparision3.Items.AddRange(New Object() {"", "is equal to", "is not equal to", "is less than", "is less than or equal to", "is greater than", "is greater than or equal to", "is empty", "is not empty", "begins with", "ends with", "contains"})
        Me.cboComparision3.Location = New System.Drawing.Point(136, 75)
        Me.cboComparision3.Name = "cboComparision3"
        Me.cboComparision3.Size = New System.Drawing.Size(121, 21)
        Me.cboComparision3.TabIndex = 22
        '
        'txtVal3
        '
        Me.txtVal3.Location = New System.Drawing.Point(272, 75)
        Me.txtVal3.Name = "txtVal3"
        Me.txtVal3.Size = New System.Drawing.Size(100, 20)
        Me.txtVal3.TabIndex = 19
        '
        'dgvSearchResults
        '
        Me.dgvSearchResults.AllowUserToAddRows = False
        Me.dgvSearchResults.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvSearchResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSearchResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvSearchResults.Location = New System.Drawing.Point(10, 45)
        Me.dgvSearchResults.MultiSelect = False
        Me.dgvSearchResults.Name = "dgvSearchResults"
        Me.dgvSearchResults.ReadOnly = True
        Me.dgvSearchResults.RowHeadersWidth = 25
        Me.dgvSearchResults.RowTemplate.Height = 18
        Me.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearchResults.Size = New System.Drawing.Size(1060, 370)
        Me.dgvSearchResults.TabIndex = 0
        '
        'cboVar3
        '
        Me.cboVar3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVar3.FormattingEnabled = True
        Me.cboVar3.Location = New System.Drawing.Point(9, 75)
        Me.cboVar3.Name = "cboVar3"
        Me.cboVar3.Size = New System.Drawing.Size(117, 21)
        Me.cboVar3.TabIndex = 18
        '
        'lblComparision
        '
        Me.lblComparision.AutoSize = True
        Me.lblComparision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComparision.Location = New System.Drawing.Point(160, 4)
        Me.lblComparision.Name = "lblComparision"
        Me.lblComparision.Size = New System.Drawing.Size(75, 13)
        Me.lblComparision.TabIndex = 17
        Me.lblComparision.Text = "Comparision"
        '
        'cboComparision2
        '
        Me.cboComparision2.FormattingEnabled = True
        Me.cboComparision2.Items.AddRange(New Object() {"", "is equal to", "is not equal to", "is less than", "is less than or equal to", "is greater than", "is greater than or equal to", "is empty", "is not empty", "begins with", "ends with", "contains"})
        Me.cboComparision2.Location = New System.Drawing.Point(136, 48)
        Me.cboComparision2.Name = "cboComparision2"
        Me.cboComparision2.Size = New System.Drawing.Size(121, 21)
        Me.cboComparision2.TabIndex = 16
        '
        'tabPageAdvanced
        '
        Me.tabPageAdvanced.Controls.Add(Me.txtAdvancedSearch)
        Me.tabPageAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAdvanced.Name = "tabPageAdvanced"
        Me.tabPageAdvanced.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAdvanced.Size = New System.Drawing.Size(837, 165)
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
        Me.txtAdvancedSearch.Size = New System.Drawing.Size(831, 159)
        Me.txtAdvancedSearch.TabIndex = 0
        '
        'tabPageQueryBuilder
        '
        Me.tabPageQueryBuilder.Controls.Add(Me.cboComparision3)
        Me.tabPageQueryBuilder.Controls.Add(Me.txtVal3)
        Me.tabPageQueryBuilder.Controls.Add(Me.cboVar3)
        Me.tabPageQueryBuilder.Controls.Add(Me.lblComparision)
        Me.tabPageQueryBuilder.Controls.Add(Me.cboComparision2)
        Me.tabPageQueryBuilder.Controls.Add(Me.cboComparision1)
        Me.tabPageQueryBuilder.Controls.Add(Me.rbOr)
        Me.tabPageQueryBuilder.Controls.Add(Me.rbAnd)
        Me.tabPageQueryBuilder.Controls.Add(Me.txtVal2)
        Me.tabPageQueryBuilder.Controls.Add(Me.txtVal1)
        Me.tabPageQueryBuilder.Controls.Add(Me.lblValue)
        Me.tabPageQueryBuilder.Controls.Add(Me.lblQuestionNumber)
        Me.tabPageQueryBuilder.Controls.Add(Me.cboVar2)
        Me.tabPageQueryBuilder.Controls.Add(Me.cboVar1)
        Me.tabPageQueryBuilder.Location = New System.Drawing.Point(4, 22)
        Me.tabPageQueryBuilder.Name = "tabPageQueryBuilder"
        Me.tabPageQueryBuilder.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageQueryBuilder.Size = New System.Drawing.Size(837, 165)
        Me.tabPageQueryBuilder.TabIndex = 2
        Me.tabPageQueryBuilder.Text = "Query Builder"
        Me.tabPageQueryBuilder.UseVisualStyleBackColor = True
        '
        'cboComparision1
        '
        Me.cboComparision1.FormattingEnabled = True
        Me.cboComparision1.Items.AddRange(New Object() {"", "is equal to", "is not equal to", "is less than", "is less than or equal to", "is greater than", "is greater than or equal to", "is empty", "is not empty", "begins with", "ends with", "contains"})
        Me.cboComparision1.Location = New System.Drawing.Point(136, 21)
        Me.cboComparision1.Name = "cboComparision1"
        Me.cboComparision1.Size = New System.Drawing.Size(121, 21)
        Me.cboComparision1.TabIndex = 15
        '
        'rbOr
        '
        Me.rbOr.AutoSize = True
        Me.rbOr.Checked = True
        Me.rbOr.Location = New System.Drawing.Point(215, 114)
        Me.rbOr.Name = "rbOr"
        Me.rbOr.Size = New System.Drawing.Size(41, 17)
        Me.rbOr.TabIndex = 14
        Me.rbOr.TabStop = True
        Me.rbOr.Text = "OR"
        Me.rbOr.UseVisualStyleBackColor = True
        '
        'rbAnd
        '
        Me.rbAnd.AutoSize = True
        Me.rbAnd.Location = New System.Drawing.Point(135, 114)
        Me.rbAnd.Name = "rbAnd"
        Me.rbAnd.Size = New System.Drawing.Size(48, 17)
        Me.rbAnd.TabIndex = 13
        Me.rbAnd.Text = "AND"
        Me.rbAnd.UseVisualStyleBackColor = True
        '
        'txtVal2
        '
        Me.txtVal2.Location = New System.Drawing.Point(272, 48)
        Me.txtVal2.Name = "txtVal2"
        Me.txtVal2.Size = New System.Drawing.Size(100, 20)
        Me.txtVal2.TabIndex = 12
        '
        'txtVal1
        '
        Me.txtVal1.Location = New System.Drawing.Point(272, 21)
        Me.txtVal1.Name = "txtVal1"
        Me.txtVal1.Size = New System.Drawing.Size(100, 20)
        Me.txtVal1.TabIndex = 11
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(294, 4)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(39, 13)
        Me.lblValue.TabIndex = 9
        Me.lblValue.Text = "Value"
        '
        'lblQuestionNumber
        '
        Me.lblQuestionNumber.AutoSize = True
        Me.lblQuestionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestionNumber.Location = New System.Drawing.Point(17, 4)
        Me.lblQuestionNumber.Name = "lblQuestionNumber"
        Me.lblQuestionNumber.Size = New System.Drawing.Size(100, 13)
        Me.lblQuestionNumber.TabIndex = 7
        Me.lblQuestionNumber.Text = "QuestionNumber"
        '
        'cboVar2
        '
        Me.cboVar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVar2.FormattingEnabled = True
        Me.cboVar2.Location = New System.Drawing.Point(9, 48)
        Me.cboVar2.Name = "cboVar2"
        Me.cboVar2.Size = New System.Drawing.Size(117, 21)
        Me.cboVar2.TabIndex = 6
        '
        'cboVar1
        '
        Me.cboVar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVar1.FormattingEnabled = True
        Me.cboVar1.Location = New System.Drawing.Point(9, 21)
        Me.cboVar1.Name = "cboVar1"
        Me.cboVar1.Size = New System.Drawing.Size(117, 21)
        Me.cboVar1.TabIndex = 5
        '
        'Expression
        '
        Me.Expression.HeaderText = "Expression"
        Me.Expression.Name = "Expression"
        Me.Expression.Width = 150
        '
        'Comparison
        '
        Me.Comparison.HeaderText = "Comparison"
        Me.Comparison.Items.AddRange(New Object() {"", "is equal to", "is not equal to", "is less than", "is less than or equal to", "is greater than", "is greater than or equal to", "is empty", "is not empty", "begins with", "ends with", "contains"})
        Me.Comparison.MaxDropDownItems = 20
        Me.Comparison.Name = "Comparison"
        Me.Comparison.Width = 150
        '
        'Field
        '
        Me.Field.HeaderText = "Field"
        Me.Field.Name = "Field"
        Me.Field.ReadOnly = True
        '
        'PanelLogo
        '
        Me.PanelLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLogo.Controls.Add(Me.PictureBoxLogo)
        Me.PanelLogo.Location = New System.Drawing.Point(863, 4)
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
        Me.SplitContainerSearch.Panel2.Controls.Add(Me.grpSearchResult)
        Me.SplitContainerSearch.Size = New System.Drawing.Size(1080, 632)
        Me.SplitContainerSearch.SplitterDistance = 200
        Me.SplitContainerSearch.TabIndex = 1
        Me.SplitContainerSearch.TabStop = False
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.Controls.Add(Me.cbIncludeHistory)
        Me.PanelButtons.Controls.Add(Me.btnClose)
        Me.PanelButtons.Controls.Add(Me.btnClear)
        Me.PanelButtons.Controls.Add(Me.btnSearch)
        Me.PanelButtons.Location = New System.Drawing.Point(855, 61)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(222, 145)
        Me.PanelButtons.TabIndex = 1
        '
        'cbIncludeHistory
        '
        Me.cbIncludeHistory.AutoSize = True
        Me.cbIncludeHistory.Location = New System.Drawing.Point(8, 101)
        Me.cbIncludeHistory.Name = "cbIncludeHistory"
        Me.cbIncludeHistory.Size = New System.Drawing.Size(181, 17)
        Me.cbIncludeHistory.TabIndex = 3
        Me.cbIncludeHistory.Text = "Include Updated Variable History"
        Me.cbIncludeHistory.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(147, 59)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(147, 30)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(147, 1)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
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
        Me.PanelSearchCriteria.Size = New System.Drawing.Size(845, 260)
        Me.PanelSearchCriteria.TabIndex = 0
        '
        'lnkCopyToAdvanced
        '
        Me.lnkCopyToAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCopyToAdvanced.AutoSize = True
        Me.lnkCopyToAdvanced.Location = New System.Drawing.Point(748, 6)
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
        Me.tabSearch.Controls.Add(Me.tabPageQueryBuilder)
        Me.tabSearch.Controls.Add(Me.tabPageAdvanced)
        Me.tabSearch.Location = New System.Drawing.Point(0, 3)
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(845, 191)
        Me.tabSearch.TabIndex = 0
        Me.tabSearch.TabStop = False
        '
        'tabPageBasic
        '
        Me.tabPageBasic.Controls.Add(Me.cboVariableList)
        Me.tabPageBasic.Controls.Add(Me.dgvSearchCriteria)
        Me.tabPageBasic.Location = New System.Drawing.Point(4, 22)
        Me.tabPageBasic.Name = "tabPageBasic"
        Me.tabPageBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageBasic.Size = New System.Drawing.Size(837, 165)
        Me.tabPageBasic.TabIndex = 0
        Me.tabPageBasic.Text = "Basic"
        Me.tabPageBasic.ToolTipText = "Basic Search"
        Me.tabPageBasic.UseVisualStyleBackColor = True
        '
        'cboVariableList
        '
        Me.cboVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVariableList.FormattingEnabled = True
        Me.cboVariableList.Location = New System.Drawing.Point(255, 24)
        Me.cboVariableList.Name = "cboVariableList"
        Me.cboVariableList.Size = New System.Drawing.Size(117, 21)
        Me.cboVariableList.TabIndex = 4
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
        Me.dgvSearchCriteria.RowTemplate.Height = 20
        Me.dgvSearchCriteria.Size = New System.Drawing.Size(831, 159)
        Me.dgvSearchCriteria.TabIndex = 0
        '
        'grpSearchResult
        '
        Me.grpSearchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSearchResult.Controls.Add(Me.cbGridUpdate)
        Me.grpSearchResult.Controls.Add(Me.btnExcel)
        Me.grpSearchResult.Location = New System.Drawing.Point(3, 4)
        Me.grpSearchResult.Name = "grpSearchResult"
        Me.grpSearchResult.Size = New System.Drawing.Size(1070, 421)
        Me.grpSearchResult.TabIndex = 1
        Me.grpSearchResult.TabStop = False
        Me.grpSearchResult.Text = "Search Result"
        '
        'cbGridUpdate
        '
        Me.cbGridUpdate.AutoSize = True
        Me.cbGridUpdate.Location = New System.Drawing.Point(10, 20)
        Me.cbGridUpdate.Name = "cbGridUpdate"
        Me.cbGridUpdate.Size = New System.Drawing.Size(83, 17)
        Me.cbGridUpdate.TabIndex = 5
        Me.cbGridUpdate.Text = "Grid Update"
        Me.cbGridUpdate.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(960, 15)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(107, 23)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.TabStop = False
        Me.btnExcel.Text = "&Export to Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'SearchSurveyResponse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerSearch)
        Me.Name = "SearchSurveyResponse"
        Me.Size = New System.Drawing.Size(1080, 632)
        CType(Me.dgvSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageAdvanced.ResumeLayout(False)
        Me.tabPageAdvanced.PerformLayout()
        Me.tabPageQueryBuilder.ResumeLayout(False)
        Me.tabPageQueryBuilder.PerformLayout()
        Me.PanelLogo.ResumeLayout(False)
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerSearch.Panel1.ResumeLayout(False)
        Me.SplitContainerSearch.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerSearch.ResumeLayout(False)
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelButtons.PerformLayout()
        Me.PanelSearchCriteria.ResumeLayout(False)
        Me.PanelSearchCriteria.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabPageBasic.ResumeLayout(False)
        CType(Me.dgvSearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchResult.ResumeLayout(False)
        Me.grpSearchResult.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboComparision3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtVal3 As System.Windows.Forms.TextBox
    Friend WithEvents dgvSearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents cboVar3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblComparision As System.Windows.Forms.Label
    Friend WithEvents cboComparision2 As System.Windows.Forms.ComboBox
    Friend WithEvents tabPageAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents txtAdvancedSearch As System.Windows.Forms.TextBox
    Friend WithEvents tabPageQueryBuilder As System.Windows.Forms.TabPage
    Friend WithEvents cboComparision1 As System.Windows.Forms.ComboBox
    Friend WithEvents rbOr As System.Windows.Forms.RadioButton
    Friend WithEvents rbAnd As System.Windows.Forms.RadioButton
    Friend WithEvents txtVal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtVal1 As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblQuestionNumber As System.Windows.Forms.Label
    Friend WithEvents cboVar2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboVar1 As System.Windows.Forms.ComboBox
    Friend WithEvents Expression As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comparison As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Field As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelLogo As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainerSearch As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents PanelSearchCriteria As System.Windows.Forms.Panel
    Friend WithEvents lnkCopyToAdvanced As System.Windows.Forms.LinkLabel
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabPageBasic As System.Windows.Forms.TabPage
    Friend WithEvents cboVariableList As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSearchCriteria As System.Windows.Forms.DataGridView
    Friend WithEvents grpSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents cbGridUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncludeHistory As System.Windows.Forms.CheckBox

End Class
