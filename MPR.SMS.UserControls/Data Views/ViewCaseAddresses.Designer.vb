'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseAddresses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseAddresses))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnBest = New System.Windows.Forms.Button()
        Me.mnuBest = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarkAsBestForAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BestPhysicalAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestMailingAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestCheckAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlViewCaseAddress16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseAddress15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.chkShowDuplicates = New System.Windows.Forms.CheckBox()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.imgQuality = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuViewAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestMailingAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestPhysicalAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestCheckAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BestPhysicalAddress = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BestMailingAddress = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BestCheckAddress = New System.Windows.Forms.DataGridViewImageColumn()
        Me.AddressID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quality = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Cleaned = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostalCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        Me.mnuBest.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpShow.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
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
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BestPhysicalAddress, Me.BestMailingAddress, Me.BestCheckAddress, Me.AddressID, Me.Rank, Me.Quality, Me.Cleaned, Me.Address, Me.City, Me.State, Me.PostalCode, Me.Type, Me.DateCreated, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(3, 21)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(446, 118)
        Me.grdView.TabIndex = 0
        '
        'grpMembers
        '
        Me.grpMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMembers.Controls.Add(Me.btnBest)
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
        Me.grpMembers.Text = "Addresses"
        '
        'btnBest
        '
        Me.btnBest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBest.ContextMenuStrip = Me.mnuBest
        Me.btnBest.Enabled = False
        Me.btnBest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBest.ImageIndex = 0
        Me.btnBest.ImageList = Me.imlViewCaseAddress16
        Me.btnBest.Location = New System.Drawing.Point(374, 143)
        Me.btnBest.Name = "btnBest"
        Me.btnBest.Size = New System.Drawing.Size(75, 21)
        Me.btnBest.TabIndex = 4
        Me.btnBest.Text = "Best"
        Me.btnBest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBest.UseVisualStyleBackColor = True
        '
        'mnuBest
        '
        Me.mnuBest.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarkAsBestForAllToolStripMenuItem, Me.ToolStripMenuItem2, Me.BestPhysicalAddressToolStripMenuItem, Me.BestMailingAddressToolStripMenuItem, Me.BestCheckAddressToolStripMenuItem})
        Me.mnuBest.Name = "mnuBest"
        Me.mnuBest.Size = New System.Drawing.Size(211, 98)
        '
        'MarkAsBestForAllToolStripMenuItem
        '
        Me.MarkAsBestForAllToolStripMenuItem.Image = CType(resources.GetObject("MarkAsBestForAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MarkAsBestForAllToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.MarkAsBestForAllToolStripMenuItem.Name = "MarkAsBestForAllToolStripMenuItem"
        Me.MarkAsBestForAllToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.MarkAsBestForAllToolStripMenuItem.Text = "Best for All Address Types"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(207, 6)
        '
        'BestPhysicalAddressToolStripMenuItem
        '
        Me.BestPhysicalAddressToolStripMenuItem.Image = CType(resources.GetObject("BestPhysicalAddressToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BestPhysicalAddressToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.BestPhysicalAddressToolStripMenuItem.Name = "BestPhysicalAddressToolStripMenuItem"
        Me.BestPhysicalAddressToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.BestPhysicalAddressToolStripMenuItem.Text = "Best Physical Address"
        '
        'BestMailingAddressToolStripMenuItem
        '
        Me.BestMailingAddressToolStripMenuItem.Image = CType(resources.GetObject("BestMailingAddressToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BestMailingAddressToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.BestMailingAddressToolStripMenuItem.Name = "BestMailingAddressToolStripMenuItem"
        Me.BestMailingAddressToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.BestMailingAddressToolStripMenuItem.Text = "Best Mailing Address"
        '
        'BestCheckAddressToolStripMenuItem
        '
        Me.BestCheckAddressToolStripMenuItem.Image = CType(resources.GetObject("BestCheckAddressToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BestCheckAddressToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.BestCheckAddressToolStripMenuItem.Name = "BestCheckAddressToolStripMenuItem"
        Me.BestCheckAddressToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.BestCheckAddressToolStripMenuItem.Text = "Best Check Address"
        '
        'imlViewCaseAddress16
        '
        Me.imlViewCaseAddress16.ImageStream = CType(resources.GetObject("imlViewCaseAddress16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseAddress16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseAddress16.Images.SetKeyName(0, "Best (blue).bmp")
        '
        'btnShowID
        '
        Me.btnShowID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowID.FlatAppearance.BorderSize = 0
        Me.btnShowID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowID.ImageKey = "show.bmp"
        Me.btnShowID.ImageList = Me.imlShowHide
        Me.btnShowID.Location = New System.Drawing.Point(437, -1)
        Me.btnShowID.Margin = New System.Windows.Forms.Padding(1)
        Me.btnShowID.Name = "btnShowID"
        Me.btnShowID.Size = New System.Drawing.Size(12, 12)
        Me.btnShowID.TabIndex = 7
        Me.btnShowID.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide Address ID column")
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
        Me.imgIcon.Location = New System.Drawing.Point(63, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 12)
        Me.imgIcon.TabIndex = 6
        Me.imgIcon.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 2
        Me.btnEdit.ImageList = Me.imlViewCaseAddress15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseAddress15
        '
        Me.imlViewCaseAddress15.ImageStream = CType(resources.GetObject("imlViewCaseAddress15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseAddress15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseAddress15.Images.SetKeyName(0, "delete.bmp")
        Me.imlViewCaseAddress15.Images.SetKeyName(1, "insert.bmp")
        Me.imlViewCaseAddress15.Images.SetKeyName(2, "update.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 0
        Me.btnDelete.ImageList = Me.imlViewCaseAddress15
        Me.btnDelete.Location = New System.Drawing.Point(165, 143)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageIndex = 1
        Me.btnAdd.ImageList = Me.imlViewCaseAddress15
        Me.btnAdd.Location = New System.Drawing.Point(3, 143)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
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
        Me.imgImages.Images.SetKeyName(10, "SuccessComplete.bmp")
        '
        'grpShow
        '
        Me.grpShow.Controls.Add(Me.chkShowDuplicates)
        Me.grpShow.Controls.Add(Me.lblShow)
        Me.grpShow.Location = New System.Drawing.Point(310, -4)
        Me.grpShow.Name = "grpShow"
        Me.grpShow.Size = New System.Drawing.Size(123, 27)
        Me.grpShow.TabIndex = 12
        Me.grpShow.TabStop = False
        '
        'chkShowDuplicates
        '
        Me.chkShowDuplicates.AutoSize = True
        Me.chkShowDuplicates.Location = New System.Drawing.Point(45, 7)
        Me.chkShowDuplicates.Name = "chkShowDuplicates"
        Me.chkShowDuplicates.Size = New System.Drawing.Size(76, 17)
        Me.chkShowDuplicates.TabIndex = 8
        Me.chkShowDuplicates.Text = "Duplicates"
        Me.chkShowDuplicates.UseVisualStyleBackColor = True
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
        'imgQuality
        '
        Me.imgQuality.ImageStream = CType(resources.GetObject("imgQuality.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgQuality.TransparentColor = System.Drawing.Color.Transparent
        Me.imgQuality.Images.SetKeyName(0, "Quality-Unknown.bmp")
        Me.imgQuality.Images.SetKeyName(1, "Quality-Bad.bmp")
        Me.imgQuality.Images.SetKeyName(2, "Quality-Good.bmp")
        Me.imgQuality.Images.SetKeyName(3, "Quality-Duplicate.bmp")
        '
        'mnuViewAddressHistory
        '
        Me.mnuViewAddressHistory.Name = "mnuViewAddressHistory"
        Me.mnuViewAddressHistory.Size = New System.Drawing.Size(325, 22)
        Me.mnuViewAddressHistory.Text = "View Address &History"
        '
        'mnuViewBestMailingAddressHistory
        '
        Me.mnuViewBestMailingAddressHistory.Name = "mnuViewBestMailingAddressHistory"
        Me.mnuViewBestMailingAddressHistory.Size = New System.Drawing.Size(325, 22)
        Me.mnuViewBestMailingAddressHistory.Text = "View ""&Best"" Selection History - Mailing Address"
        '
        'mnuViewBestPhysicalAddressHistory
        '
        Me.mnuViewBestPhysicalAddressHistory.Name = "mnuViewBestPhysicalAddressHistory"
        Me.mnuViewBestPhysicalAddressHistory.Size = New System.Drawing.Size(325, 22)
        Me.mnuViewBestPhysicalAddressHistory.Text = "View ""Best"" Selection History - &Physical Address"
        '
        'mnuViewBestCheckAddressHistory
        '
        Me.mnuViewBestCheckAddressHistory.Name = "mnuViewBestCheckAddressHistory"
        Me.mnuViewBestCheckAddressHistory.Size = New System.Drawing.Size(325, 22)
        Me.mnuViewBestCheckAddressHistory.Text = "View ""Best"" Selection History - &Check Address"
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewAddressHistory, Me.mnuViewBestMailingAddressHistory, Me.mnuViewBestPhysicalAddressHistory, Me.mnuViewBestCheckAddressHistory})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(326, 92)
        '
        'BestPhysicalAddress
        '
        Me.BestPhysicalAddress.Description = "Best Physical Address"
        Me.BestPhysicalAddress.HeaderText = ""
        Me.BestPhysicalAddress.MinimumWidth = 20
        Me.BestPhysicalAddress.Name = "BestPhysicalAddress"
        Me.BestPhysicalAddress.ReadOnly = True
        Me.BestPhysicalAddress.ToolTipText = "Best physical address?"
        Me.BestPhysicalAddress.Width = 20
        '
        'BestMailingAddress
        '
        Me.BestMailingAddress.Description = "Best Mailing Address"
        Me.BestMailingAddress.HeaderText = ""
        Me.BestMailingAddress.MinimumWidth = 20
        Me.BestMailingAddress.Name = "BestMailingAddress"
        Me.BestMailingAddress.ReadOnly = True
        Me.BestMailingAddress.ToolTipText = "Best mailing address?"
        Me.BestMailingAddress.Width = 20
        '
        'BestCheckAddress
        '
        Me.BestCheckAddress.Description = "Best Check Address"
        Me.BestCheckAddress.HeaderText = ""
        Me.BestCheckAddress.MinimumWidth = 20
        Me.BestCheckAddress.Name = "BestCheckAddress"
        Me.BestCheckAddress.ReadOnly = True
        Me.BestCheckAddress.ToolTipText = "Best check address?"
        Me.BestCheckAddress.Width = 20
        '
        'AddressID
        '
        Me.AddressID.HeaderText = "AddressID"
        Me.AddressID.Name = "AddressID"
        Me.AddressID.ReadOnly = True
        Me.AddressID.Visible = False
        Me.AddressID.Width = 70
        '
        'Rank
        '
        Me.Rank.HeaderText = "Rank"
        Me.Rank.Name = "Rank"
        Me.Rank.ReadOnly = True
        Me.Rank.Visible = False
        '
        'Quality
        '
        Me.Quality.HeaderText = "Quality"
        Me.Quality.Name = "Quality"
        Me.Quality.ReadOnly = True
        Me.Quality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Quality.ToolTipText = "Quality of address"
        Me.Quality.Width = 45
        '
        'Cleaned
        '
        Me.Cleaned.HeaderText = ""
        Me.Cleaned.Name = "Cleaned"
        Me.Cleaned.ReadOnly = True
        Me.Cleaned.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cleaned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cleaned.ToolTipText = "Cleaned?"
        Me.Cleaned.Width = 20
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.ToolTipText = "Full street address"
        Me.Address.Width = 120
        '
        'City
        '
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        Me.City.ReadOnly = True
        Me.City.ToolTipText = "City"
        Me.City.Width = 75
        '
        'State
        '
        Me.State.HeaderText = "State"
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.ToolTipText = "State"
        Me.State.Width = 40
        '
        'PostalCode
        '
        Me.PostalCode.HeaderText = "Postal Code"
        Me.PostalCode.Name = "PostalCode"
        Me.PostalCode.ReadOnly = True
        Me.PostalCode.ToolTipText = "Zip or Postal Code"
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.ToolTipText = "Type of Address"
        '
        'DateCreated
        '
        Me.DateCreated.HeaderText = "Date Created"
        Me.DateCreated.Name = "DateCreated"
        Me.DateCreated.ReadOnly = True
        Me.DateCreated.ToolTipText = "Date address was created"
        '
        'Round
        '
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = True
        Me.Round.ToolTipText = "Round when data was last changed"
        Me.Round.Width = 50
        '
        'ViewCaseAddresses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpShow)
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseAddresses"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        Me.mnuBest.ResumeLayout(False)
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpShow.ResumeLayout(False)
        Me.grpShow.PerformLayout()
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents grpMembers As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents btnBest As System.Windows.Forms.Button
    Friend WithEvents mnuBest As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BestPhysicalAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestMailingAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestCheckAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowDuplicates As System.Windows.Forms.CheckBox
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents imgQuality As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseAddress15 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseAddress16 As System.Windows.Forms.ImageList
    Friend WithEvents MarkAsBestForAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestMailingAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestPhysicalAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestCheckAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BestPhysicalAddress As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents BestMailingAddress As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents BestCheckAddress As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents AddressID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quality As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Cleaned As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostalCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
