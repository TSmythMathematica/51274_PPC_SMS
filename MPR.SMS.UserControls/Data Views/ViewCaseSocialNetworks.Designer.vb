'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseSocialNetworks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseSocialNetworks))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.BestSocialNetwork = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SocialNetworkID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quality = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SocialNetwork = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.URL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestAccepted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LikeUs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.picSM = New System.Windows.Forms.PictureBox()
        Me.btnBest = New System.Windows.Forms.Button()
        Me.imlViewCaseSN16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseSN15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuViewSocialNetworkHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBestSocialNetworkHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaunchURL = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgQuality = New System.Windows.Forms.ImageList(Me.components)
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.chkShowDuplicates = New System.Windows.Forms.CheckBox()
        Me.lblShow = New System.Windows.Forms.Label()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        CType(Me.picSM, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BestSocialNetwork, Me.SocialNetworkID, Me.Rank, Me.Quality, Me.SocialNetwork, Me.URL, Me.Type, Me.RequestAccepted, Me.LikeUs, Me.Notes, Me.DtCreated, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(3, 21)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(452, 123)
        Me.grdView.TabIndex = 0
        '
        'BestSocialNetwork
        '
        Me.BestSocialNetwork.Description = "Best SocialNetwork"
        Me.BestSocialNetwork.HeaderText = ""
        Me.BestSocialNetwork.MinimumWidth = 20
        Me.BestSocialNetwork.Name = "BestSocialNetwork"
        Me.BestSocialNetwork.ReadOnly = True
        Me.BestSocialNetwork.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestSocialNetwork.ToolTipText = "Best SocialNetwork?"
        Me.BestSocialNetwork.Width = 20
        '
        'SocialNetworkID
        '
        Me.SocialNetworkID.HeaderText = "SocialNetworkID"
        Me.SocialNetworkID.Name = "SocialNetworkID"
        Me.SocialNetworkID.ReadOnly = True
        Me.SocialNetworkID.Visible = False
        Me.SocialNetworkID.Width = 70
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
        Me.Quality.ToolTipText = "Quality of SocialNetwork"
        Me.Quality.Width = 45
        '
        'SocialNetwork
        '
        Me.SocialNetwork.HeaderText = "User Name"
        Me.SocialNetwork.Name = "SocialNetwork"
        Me.SocialNetwork.ReadOnly = True
        Me.SocialNetwork.ToolTipText = "SocialNetwork address"
        Me.SocialNetwork.Width = 120
        '
        'URL
        '
        Me.URL.HeaderText = "URL"
        Me.URL.Name = "URL"
        Me.URL.ReadOnly = True
        Me.URL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.ToolTipText = "Type of SocialNetwork"
        Me.Type.Width = 75
        '
        'RequestAccepted
        '
        Me.RequestAccepted.HeaderText = "Status"
        Me.RequestAccepted.Name = "RequestAccepted"
        Me.RequestAccepted.ReadOnly = True
        '
        'LikeUs
        '
        Me.LikeUs.HeaderText = "Like Us?"
        Me.LikeUs.Name = "LikeUs"
        Me.LikeUs.ReadOnly = True
        Me.LikeUs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LikeUs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Notes
        '
        Me.Notes.HeaderText = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = True
        Me.Notes.Width = 150
        '
        'DtCreated
        '
        Me.DtCreated.HeaderText = "Date Created"
        Me.DtCreated.Name = "DtCreated"
        Me.DtCreated.ReadOnly = True
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
        Me.grpMembers.Controls.Add(Me.grpShow)
        Me.grpMembers.Controls.Add(Me.picSM)
        Me.grpMembers.Controls.Add(Me.btnBest)
        Me.grpMembers.Controls.Add(Me.btnShowID)
        Me.grpMembers.Controls.Add(Me.btnEdit)
        Me.grpMembers.Controls.Add(Me.btnDelete)
        Me.grpMembers.Controls.Add(Me.btnAdd)
        Me.grpMembers.Controls.Add(Me.grdView)
        Me.grpMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpMembers.Location = New System.Drawing.Point(0, 0)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Padding = New System.Windows.Forms.Padding(0)
        Me.grpMembers.Size = New System.Drawing.Size(458, 176)
        Me.grpMembers.TabIndex = 0
        Me.grpMembers.TabStop = False
        Me.grpMembers.Text = "Social Networks"
        '
        'picSM
        '
        Me.picSM.Image = CType(resources.GetObject("picSM.Image"), System.Drawing.Image)
        Me.picSM.Location = New System.Drawing.Point(90, -1)
        Me.picSM.Name = "picSM"
        Me.picSM.Size = New System.Drawing.Size(17, 17)
        Me.picSM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSM.TabIndex = 9
        Me.picSM.TabStop = False
        '
        'btnBest
        '
        Me.btnBest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBest.Enabled = False
        Me.btnBest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBest.ImageKey = "Best (blue).bmp"
        Me.btnBest.ImageList = Me.imlViewCaseSN16
        Me.btnBest.Location = New System.Drawing.Point(380, 150)
        Me.btnBest.Name = "btnBest"
        Me.btnBest.Size = New System.Drawing.Size(75, 21)
        Me.btnBest.TabIndex = 4
        Me.btnBest.Text = "Best"
        Me.btnBest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBest.UseVisualStyleBackColor = True
        '
        'imlViewCaseSN16
        '
        Me.imlViewCaseSN16.ImageStream = CType(resources.GetObject("imlViewCaseSN16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseSN16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseSN16.Images.SetKeyName(0, "Best (blue).bmp")
        Me.imlViewCaseSN16.Images.SetKeyName(1, "Phone.bmp")
        '
        'btnShowID
        '
        Me.btnShowID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowID.FlatAppearance.BorderSize = 0
        Me.btnShowID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowID.ImageKey = "show.bmp"
        Me.btnShowID.ImageList = Me.imlShowHide
        Me.btnShowID.Location = New System.Drawing.Point(446, 0)
        Me.btnShowID.Margin = New System.Windows.Forms.Padding(1)
        Me.btnShowID.Name = "btnShowID"
        Me.btnShowID.Size = New System.Drawing.Size(12, 12)
        Me.btnShowID.TabIndex = 8
        Me.btnShowID.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide SocialNetwork ID column")
        Me.btnShowID.UseVisualStyleBackColor = True
        '
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageKey = "update.bmp"
        Me.btnEdit.ImageList = Me.imlViewCaseSN15
        Me.btnEdit.Location = New System.Drawing.Point(84, 150)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseSN15
        '
        Me.imlViewCaseSN15.ImageStream = CType(resources.GetObject("imlViewCaseSN15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseSN15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseSN15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCaseSN15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseSN15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageKey = "delete.bmp"
        Me.btnDelete.ImageList = Me.imlViewCaseSN15
        Me.btnDelete.Location = New System.Drawing.Point(165, 150)
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
        Me.btnAdd.ImageKey = "insert.bmp"
        Me.btnAdd.ImageList = Me.imlViewCaseSN15
        Me.btnAdd.Location = New System.Drawing.Point(3, 150)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewSocialNetworkHistory, Me.mnuViewBestSocialNetworkHistory, Me.mnuLaunchURL})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(227, 70)
        '
        'mnuViewSocialNetworkHistory
        '
        Me.mnuViewSocialNetworkHistory.Name = "mnuViewSocialNetworkHistory"
        Me.mnuViewSocialNetworkHistory.Size = New System.Drawing.Size(226, 22)
        Me.mnuViewSocialNetworkHistory.Text = "View Social Network &History"
        '
        'mnuViewBestSocialNetworkHistory
        '
        Me.mnuViewBestSocialNetworkHistory.Name = "mnuViewBestSocialNetworkHistory"
        Me.mnuViewBestSocialNetworkHistory.Size = New System.Drawing.Size(226, 22)
        Me.mnuViewBestSocialNetworkHistory.Text = "View ""&Best"" Selection History"
        '
        'mnuLaunchURL
        '
        Me.mnuLaunchURL.Name = "mnuLaunchURL"
        Me.mnuLaunchURL.Size = New System.Drawing.Size(226, 22)
        Me.mnuLaunchURL.Text = "Launch &URL"
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
        'grpShow
        '
        Me.grpShow.Controls.Add(Me.chkShowDuplicates)
        Me.grpShow.Controls.Add(Me.lblShow)
        Me.grpShow.Location = New System.Drawing.Point(310, -6)
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
        'ViewCaseSocialNetworks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseSocialNetworks"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        CType(Me.picSM, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents btnBest As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuViewSocialNetworkHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBestSocialNetworkHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgQuality As System.Windows.Forms.ImageList
    Friend WithEvents mnuLaunchURL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picSM As System.Windows.Forms.PictureBox
    Friend WithEvents BestSocialNetwork As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents SocialNetworkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quality As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents SocialNetwork As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents URL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestAccepted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LikeUs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Notes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imlViewCaseSN16 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseSN15 As System.Windows.Forms.ImageList
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowDuplicates As System.Windows.Forms.CheckBox
    Friend WithEvents lblShow As System.Windows.Forms.Label

End Class
