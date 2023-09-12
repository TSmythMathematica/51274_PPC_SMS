'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewAddressRemail
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewAddressRemail))
        Me.grpAddress = New System.Windows.Forms.GroupBox()
        Me.grdView = New System.Windows.Forms.DataGridView()
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
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnShowAddressNotes = New System.Windows.Forms.Button()
        Me.btnLocate = New System.Windows.Forms.Button()
        Me.btnRemail = New System.Windows.Forms.Button()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuViewAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestMailingAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestPhysicalAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestCheckAddressHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBest = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarkAsBestForAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BestPhysicalAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestMailingAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestCheckAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imlViewCaseAddress16 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgQuality = New System.Windows.Forms.ImageList(Me.components)
        Me.imlViewCaseAddress15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpAddress.SuspendLayout()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.mnuBest.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.grdView)
        Me.grpAddress.Location = New System.Drawing.Point(3, 3)
        Me.grpAddress.Margin = New System.Windows.Forms.Padding(1)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Padding = New System.Windows.Forms.Padding(1)
        Me.grpAddress.Size = New System.Drawing.Size(648, 199)
        Me.grpAddress.TabIndex = 0
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "Please Select an Address for a Remail [Or Send Case to Locating]:"
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
        Me.grdView.Location = New System.Drawing.Point(4, 17)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(640, 178)
        Me.grdView.TabIndex = 2
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
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 2
        Me.btnEdit.Location = New System.Drawing.Point(591, 206)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(57, 21)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnShowAddressNotes
        '
        Me.btnShowAddressNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnShowAddressNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowAddressNotes.ImageIndex = 2
        Me.btnShowAddressNotes.Location = New System.Drawing.Point(438, 206)
        Me.btnShowAddressNotes.Name = "btnShowAddressNotes"
        Me.btnShowAddressNotes.Size = New System.Drawing.Size(135, 21)
        Me.btnShowAddressNotes.TabIndex = 4
        Me.btnShowAddressNotes.Text = "Show Address Notes"
        Me.btnShowAddressNotes.UseVisualStyleBackColor = True
        '
        'btnLocate
        '
        Me.btnLocate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLocate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLocate.ImageIndex = 2
        Me.btnLocate.Location = New System.Drawing.Point(513, 245)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(139, 21)
        Me.btnLocate.TabIndex = 5
        Me.btnLocate.Text = "Send Case To Locating"
        Me.btnLocate.UseVisualStyleBackColor = True
        '
        'btnRemail
        '
        Me.btnRemail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemail.ImageIndex = 2
        Me.btnRemail.Location = New System.Drawing.Point(272, 245)
        Me.btnRemail.Name = "btnRemail"
        Me.btnRemail.Size = New System.Drawing.Size(235, 21)
        Me.btnRemail.TabIndex = 6
        Me.btnRemail.Text = "Queue Selected Address for Remail"
        Me.btnRemail.UseVisualStyleBackColor = True
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewAddressHistory, Me.mnuViewBestMailingAddressHistory, Me.mnuViewBestPhysicalAddressHistory, Me.mnuViewBestCheckAddressHistory})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(326, 92)
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
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'imlViewCaseAddress16
        '
        Me.imlViewCaseAddress16.ImageStream = CType(resources.GetObject("imlViewCaseAddress16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseAddress16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseAddress16.Images.SetKeyName(0, "Best (blue).bmp")
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
        'imlViewCaseAddress15
        '
        Me.imlViewCaseAddress15.ImageStream = CType(resources.GetObject("imlViewCaseAddress15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseAddress15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseAddress15.Images.SetKeyName(0, "delete.bmp")
        Me.imlViewCaseAddress15.Images.SetKeyName(1, "insert.bmp")
        Me.imlViewCaseAddress15.Images.SetKeyName(2, "update.bmp")
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 2
        Me.btnClose.Location = New System.Drawing.Point(513, 245)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 21)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ViewAddressRemail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRemail)
        Me.Controls.Add(Me.btnLocate)
        Me.Controls.Add(Me.btnShowAddressNotes)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.grpAddress)
        Me.Name = "ViewAddressRemail"
        Me.Size = New System.Drawing.Size(658, 282)
        Me.grpAddress.ResumeLayout(False)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.mnuBest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpAddress As System.Windows.Forms.GroupBox
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
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
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnShowAddressNotes As System.Windows.Forms.Button
    Friend WithEvents btnLocate As System.Windows.Forms.Button
    Friend WithEvents btnRemail As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuViewAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestMailingAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestPhysicalAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestCheckAddressHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBest As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarkAsBestForAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BestPhysicalAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestMailingAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestCheckAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseAddress16 As System.Windows.Forms.ImageList
    Friend WithEvents imgQuality As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseAddress15 As System.Windows.Forms.ImageList
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
