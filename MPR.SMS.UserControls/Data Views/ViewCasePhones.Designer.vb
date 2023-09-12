'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCasePhones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCasePhones))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.BestPhone = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PhoneID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quality = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Cleaned = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnBest = New System.Windows.Forms.Button()
        Me.imlViewCasePhones16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCasePhones15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuViewPhoneHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestPhoneHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.chkShowDuplicates = New System.Windows.Forms.CheckBox()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.imgQuality = New System.Windows.Forms.ImageList(Me.components)
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
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
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BestPhone, Me.PhoneID, Me.Rank, Me.Quality, Me.Cleaned, Me.Phone, Me.Ext, Me.Time, Me.Type, Me.ListedTo, Me.PhoneNotes, Me.CreatedOn, Me.Round})
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
        'BestPhone
        '
        Me.BestPhone.Description = "Best Phone"
        Me.BestPhone.HeaderText = ""
        Me.BestPhone.MinimumWidth = 20
        Me.BestPhone.Name = "BestPhone"
        Me.BestPhone.ReadOnly = True
        Me.BestPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestPhone.ToolTipText = "Best phone?"
        Me.BestPhone.Width = 20
        '
        'PhoneID
        '
        Me.PhoneID.HeaderText = "PhoneID"
        Me.PhoneID.Name = "PhoneID"
        Me.PhoneID.ReadOnly = True
        Me.PhoneID.Visible = False
        Me.PhoneID.Width = 70
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
        Me.Quality.ToolTipText = "Quality of phone number"
        Me.Quality.Width = 45
        '
        'Cleaned
        '
        Me.Cleaned.HeaderText = ""
        Me.Cleaned.Name = "Cleaned"
        Me.Cleaned.ReadOnly = True
        Me.Cleaned.ToolTipText = "Cleaned?"
        Me.Cleaned.Width = 20
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone #"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.ToolTipText = "Phone number"
        Me.Phone.Width = 90
        '
        'Ext
        '
        Me.Ext.HeaderText = "Ext"
        Me.Ext.Name = "Ext"
        Me.Ext.ReadOnly = True
        Me.Ext.ToolTipText = "Extension"
        Me.Ext.Width = 40
        '
        'Time
        '
        Me.Time.HeaderText = "Best time"
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        Me.Time.ToolTipText = "Best time to call"
        Me.Time.Width = 80
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.ToolTipText = "Type of phone"
        Me.Type.Width = 75
        '
        'ListedTo
        '
        Me.ListedTo.HeaderText = "Listed To"
        Me.ListedTo.Name = "ListedTo"
        Me.ListedTo.ReadOnly = True
        '
        'PhoneNotes
        '
        Me.PhoneNotes.HeaderText = "Notes"
        Me.PhoneNotes.Name = "PhoneNotes"
        Me.PhoneNotes.ReadOnly = True
        Me.PhoneNotes.Width = 150
        '
        'CreatedOn
        '
        Me.CreatedOn.HeaderText = "Date Created"
        Me.CreatedOn.Name = "CreatedOn"
        Me.CreatedOn.ReadOnly = True
        '
        'Round
        '
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = True
        Me.Round.ToolTipText = "Round when data was last changed"
        Me.Round.Width = 50
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
        Me.grpMembers.Text = "Phones"
        '
        'btnBest
        '
        Me.btnBest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBest.Enabled = False
        Me.btnBest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBest.ImageIndex = 0
        Me.btnBest.ImageList = Me.imlViewCasePhones16
        Me.btnBest.Location = New System.Drawing.Point(374, 143)
        Me.btnBest.Name = "btnBest"
        Me.btnBest.Size = New System.Drawing.Size(75, 21)
        Me.btnBest.TabIndex = 4
        Me.btnBest.Text = "Best"
        Me.btnBest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBest.UseVisualStyleBackColor = True
        '
        'imlViewCasePhones16
        '
        Me.imlViewCasePhones16.ImageStream = CType(resources.GetObject("imlViewCasePhones16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCasePhones16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCasePhones16.Images.SetKeyName(0, "Best (blue).bmp")
        Me.imlViewCasePhones16.Images.SetKeyName(1, "Phone.bmp")
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
        Me.btnShowID.TabIndex = 8
        Me.btnShowID.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide Phone ID column")
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
        Me.imgIcon.BackColor = System.Drawing.SystemColors.Control
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(48, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(18, 15)
        Me.imgIcon.TabIndex = 5
        Me.imgIcon.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 0
        Me.btnEdit.ImageList = Me.imlViewCasePhones15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCasePhones15
        '
        Me.imlViewCasePhones15.ImageStream = CType(resources.GetObject("imlViewCasePhones15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCasePhones15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCasePhones15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCasePhones15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCasePhones15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewCasePhones15
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
        Me.btnAdd.ImageIndex = 2
        Me.btnAdd.ImageList = Me.imlViewCasePhones15
        Me.btnAdd.Location = New System.Drawing.Point(3, 143)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewPhoneHistory, Me.mnuViewBestPhoneHistory})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(227, 48)
        '
        'mnuViewPhoneHistory
        '
        Me.mnuViewPhoneHistory.Name = "mnuViewPhoneHistory"
        Me.mnuViewPhoneHistory.Size = New System.Drawing.Size(226, 22)
        Me.mnuViewPhoneHistory.Text = "View Phone &History"
        '
        'mnuViewBestPhoneHistory
        '
        Me.mnuViewBestPhoneHistory.Name = "mnuViewBestPhoneHistory"
        Me.mnuViewBestPhoneHistory.Size = New System.Drawing.Size(226, 22)
        Me.mnuViewBestPhoneHistory.Text = "View ""&Best"" Selection History"
        '
        'grpShow
        '
        Me.grpShow.Controls.Add(Me.chkShowDuplicates)
        Me.grpShow.Controls.Add(Me.lblShow)
        Me.grpShow.Location = New System.Drawing.Point(310, -4)
        Me.grpShow.Name = "grpShow"
        Me.grpShow.Size = New System.Drawing.Size(123, 27)
        Me.grpShow.TabIndex = 11
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
        'ViewCasePhones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpShow)
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCasePhones"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
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
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents btnBest As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuViewPhoneHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestPhoneHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowDuplicates As System.Windows.Forms.CheckBox
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents imgQuality As System.Windows.Forms.ImageList
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCasePhones15 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCasePhones16 As System.Windows.Forms.ImageList
    Friend WithEvents BestPhone As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PhoneID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quality As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Cleaned As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListedTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
