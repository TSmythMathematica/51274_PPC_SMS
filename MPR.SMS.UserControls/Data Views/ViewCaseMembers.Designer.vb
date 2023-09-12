'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseMembers
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseMembers))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseMembers15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.chkShowContacts = New System.Windows.Forms.CheckBox()
        Me.chkShowMembers = New System.Windows.Forms.CheckBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.imgCheckbox = New System.Windows.Forms.ImageList(Me.components)
        Me.lblShow = New System.Windows.Forms.Label()
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.PrimarySM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Relationship = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SSN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InSample = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Consent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Language = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LexID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpShow.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdView
        '
        Me.grdView.AllowUserToAddRows = False
        Me.grdView.AllowUserToDeleteRows = False
        Me.grdView.AllowUserToOrderColumns = True
        Me.grdView.AllowUserToResizeRows = False
        Me.grdView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrimarySM, Me.MPRID, Me.Relationship, Me.PersonName, Me.SSN, Me.DOB, Me.InSample, Me.Consent, Me.Language, Me.LexID, Me.Round})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdView.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdView.Location = New System.Drawing.Point(3, 21)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(446, 116)
        Me.grdView.TabIndex = 0
        '
        'grpMembers
        '
        Me.grpMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMembers.Controls.Add(Me.btnShowID)
        Me.grpMembers.Controls.Add(Me.imgIcon)
        Me.grpMembers.Controls.Add(Me.btnEdit)
        Me.grpMembers.Controls.Add(Me.btnDelete)
        Me.grpMembers.Controls.Add(Me.btnAdd)
        Me.grpMembers.Controls.Add(Me.grdView)
        Me.grpMembers.Location = New System.Drawing.Point(3, 3)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Size = New System.Drawing.Size(452, 170)
        Me.grpMembers.TabIndex = 1
        Me.grpMembers.TabStop = False
        Me.grpMembers.Text = "Case members/contacts"
        '
        'btnShowID
        '
        Me.btnShowID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowID.FlatAppearance.BorderSize = 0
        Me.btnShowID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowID.ImageKey = "hide.bmp"
        Me.btnShowID.ImageList = Me.imlShowHide
        Me.btnShowID.Location = New System.Drawing.Point(437, -1)
        Me.btnShowID.Margin = New System.Windows.Forms.Padding(1)
        Me.btnShowID.Name = "btnShowID"
        Me.btnShowID.Size = New System.Drawing.Size(12, 12)
        Me.btnShowID.TabIndex = 6
        Me.btnShowID.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide MPRID column")
        Me.btnShowID.UseVisualStyleBackColor = True
        '
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(129, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 14)
        Me.imgIcon.TabIndex = 4
        Me.imgIcon.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 0
        Me.btnEdit.ImageList = Me.imlViewCaseMembers15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseMembers15
        '
        Me.imlViewCaseMembers15.ImageStream = CType(resources.GetObject("imlViewCaseMembers15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseMembers15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseMembers15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCaseMembers15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseMembers15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewCaseMembers15
        Me.btnDelete.Location = New System.Drawing.Point(165, 143)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageIndex = 2
        Me.btnAdd.ImageList = Me.imlViewCaseMembers15
        Me.btnAdd.Location = New System.Drawing.Point(3, 143)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'chkShowContacts
        '
        Me.chkShowContacts.Checked = True
        Me.chkShowContacts.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowContacts.Location = New System.Drawing.Point(110, 7)
        Me.chkShowContacts.Name = "chkShowContacts"
        Me.chkShowContacts.Size = New System.Drawing.Size(68, 16)
        Me.chkShowContacts.TabIndex = 8
        Me.chkShowContacts.Text = "Contacts"
        Me.chkShowContacts.UseVisualStyleBackColor = True
        '
        'chkShowMembers
        '
        Me.chkShowMembers.AutoSize = True
        Me.chkShowMembers.Checked = True
        Me.chkShowMembers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMembers.Location = New System.Drawing.Point(40, 7)
        Me.chkShowMembers.Name = "chkShowMembers"
        Me.chkShowMembers.Size = New System.Drawing.Size(69, 17)
        Me.chkShowMembers.TabIndex = 7
        Me.chkShowMembers.Text = "Members"
        Me.chkShowMembers.UseVisualStyleBackColor = True
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgImages.TransparentColor = System.Drawing.Color.Transparent
        Me.imgImages.Images.SetKeyName(0, "BestBlue.bmp")
        Me.imgImages.Images.SetKeyName(1, "BestGreen.bmp")
        Me.imgImages.Images.SetKeyName(2, "BestRed.bmp")
        Me.imgImages.Images.SetKeyName(3, "empty.ico")
        Me.imgImages.Images.SetKeyName(4, "Best SampleMember.bmp")
        Me.imgImages.Images.SetKeyName(5, "Best Email.bmp")
        Me.imgImages.Images.SetKeyName(6, "Best MailingAddress.bmp")
        Me.imgImages.Images.SetKeyName(7, "Best Phone.bmp")
        Me.imgImages.Images.SetKeyName(8, "Best PhysicalAddress.bmp")
        Me.imgImages.Images.SetKeyName(9, "Best CheckAddress.bmp")
        '
        'imgCheckbox
        '
        Me.imgCheckbox.ImageStream = CType(resources.GetObject("imgCheckbox.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgCheckbox.TransparentColor = System.Drawing.Color.Silver
        Me.imgCheckbox.Images.SetKeyName(0, "checkbox-unchecked.bmp")
        Me.imgCheckbox.Images.SetKeyName(1, "checkbox-checked.bmp")
        '
        'lblShow
        '
        Me.lblShow.AutoSize = True
        Me.lblShow.Location = New System.Drawing.Point(2, 7)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(37, 13)
        Me.lblShow.TabIndex = 9
        Me.lblShow.Text = "Show:"
        '
        'grpShow
        '
        Me.grpShow.Controls.Add(Me.chkShowContacts)
        Me.grpShow.Controls.Add(Me.chkShowMembers)
        Me.grpShow.Controls.Add(Me.lblShow)
        Me.grpShow.Location = New System.Drawing.Point(252, -4)
        Me.grpShow.Name = "grpShow"
        Me.grpShow.Size = New System.Drawing.Size(183, 27)
        Me.grpShow.TabIndex = 10
        Me.grpShow.TabStop = False
        '
        'PrimarySM
        '
        Me.PrimarySM.Description = "Primary sample member?"
        Me.PrimarySM.HeaderText = ""
        Me.PrimarySM.MinimumWidth = 20
        Me.PrimarySM.Name = "PrimarySM"
        Me.PrimarySM.ReadOnly = True
        Me.PrimarySM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PrimarySM.ToolTipText = "Primary sample member?"
        Me.PrimarySM.Width = 20
        '
        'MPRID
        '
        Me.MPRID.HeaderText = "MPRID"
        Me.MPRID.Name = "MPRID"
        Me.MPRID.ReadOnly = True
        Me.MPRID.Width = 70
        '
        'Relationship
        '
        Me.Relationship.HeaderText = "Relationship"
        Me.Relationship.Name = "Relationship"
        Me.Relationship.ReadOnly = True
        Me.Relationship.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Relationship.ToolTipText = "Relationship to sample member"
        Me.Relationship.Width = 120
        '
        'PersonName
        '
        Me.PersonName.HeaderText = "Person Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.ReadOnly = True
        Me.PersonName.ToolTipText = "Person's full name"
        Me.PersonName.Width = 120
        '
        'SSN
        '
        Me.SSN.HeaderText = "SSN"
        Me.SSN.Name = "SSN"
        Me.SSN.ReadOnly = True
        Me.SSN.ToolTipText = "Social security number"
        '
        'DOB
        '
        Me.DOB.HeaderText = "Date of Birth"
        Me.DOB.Name = "DOB"
        Me.DOB.ReadOnly = True
        Me.DOB.ToolTipText = "Date of birth"
        Me.DOB.Width = 91
        '
        'InSample
        '
        Me.InSample.HeaderText = "In Sample?"
        Me.InSample.Name = "InSample"
        Me.InSample.ReadOnly = True
        Me.InSample.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InSample.ToolTipText = "Is this member in the sample?"
        Me.InSample.Width = 70
        '
        'Consent
        '
        Me.Consent.HeaderText = "Consent"
        Me.Consent.Name = "Consent"
        Me.Consent.ReadOnly = True
        Me.Consent.Width = 80
        '
        'Language
        '
        Me.Language.HeaderText = "Language"
        Me.Language.Name = "Language"
        Me.Language.ReadOnly = True
        Me.Language.ToolTipText = "Primary language"
        Me.Language.Width = 80
        '
        'LexID
        '
        Me.LexID.HeaderText = "LEX ID"
        Me.LexID.Name = "LexID"
        Me.LexID.ReadOnly = True
        Me.LexID.ToolTipText = "Lexus Nexus unique identifier"
        '
        'Round
        '
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = True
        Me.Round.ToolTipText = "Round when data was last changed"
        Me.Round.Width = 50
        '
        'ViewCaseMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpShow)
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseMembers"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpShow.ResumeLayout(False)
        Me.grpShow.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents grpMembers As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents chkShowContacts As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowMembers As System.Windows.Forms.CheckBox
    Friend WithEvents imgCheckbox As System.Windows.Forms.ImageList
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents imlViewCaseMembers15 As System.Windows.Forms.ImageList
    Friend WithEvents PrimarySM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Relationship As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SSN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InSample As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Consent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Language As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LexID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
