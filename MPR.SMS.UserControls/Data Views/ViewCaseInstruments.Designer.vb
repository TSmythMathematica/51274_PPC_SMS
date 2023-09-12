'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseInstruments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseInstruments))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.PrimarySM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.InstrumentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SMMPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SMPersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRMPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRPersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogicalStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChangedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleaseDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.imlViewCaseInstruments16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseInstruments15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrimarySM, Me.InstrumentID, Me.Type, Me.InstType, Me.SMMPRID, Me.SMPersonName, Me.CRMPRID, Me.CRPersonName, Me.Status, Me.LogicalStatus, Me.DOB, Me.ChangedBy, Me.ReleaseDate, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(3, 16)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(446, 121)
        Me.grdView.TabIndex = 0
        '
        'PrimarySM
        '
        Me.PrimarySM.Description = "Primary"
        Me.PrimarySM.HeaderText = ""
        Me.PrimarySM.MinimumWidth = 20
        Me.PrimarySM.Name = "PrimarySM"
        Me.PrimarySM.ReadOnly = True
        Me.PrimarySM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PrimarySM.ToolTipText = "Primary"
        Me.PrimarySM.Visible = False
        Me.PrimarySM.Width = 20
        '
        'InstrumentID
        '
        Me.InstrumentID.HeaderText = "InstrumentID"
        Me.InstrumentID.Name = "InstrumentID"
        Me.InstrumentID.ReadOnly = True
        Me.InstrumentID.Visible = False
        Me.InstrumentID.Width = 70
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Type.ToolTipText = "Instrument Type"
        Me.Type.Width = 140
        '
        'InstType
        '
        Me.InstType.HeaderText = "Instrrument Type"
        Me.InstType.Name = "InstType"
        Me.InstType.ReadOnly = True
        Me.InstType.Visible = False
        '
        'SMMPRID
        '
        Me.SMMPRID.HeaderText = "SMMPRID"
        Me.SMMPRID.Name = "SMMPRID"
        Me.SMMPRID.ReadOnly = True
        Me.SMMPRID.Visible = False
        '
        'SMPersonName
        '
        Me.SMPersonName.HeaderText = "Sample Member"
        Me.SMPersonName.Name = "SMPersonName"
        Me.SMPersonName.ReadOnly = True
        Me.SMPersonName.ToolTipText = "Sample Member's full name"
        Me.SMPersonName.Width = 120
        '
        'CRMPRID
        '
        Me.CRMPRID.HeaderText = "CRMPRID"
        Me.CRMPRID.Name = "CRMPRID"
        Me.CRMPRID.ReadOnly = True
        Me.CRMPRID.Visible = False
        '
        'CRPersonName
        '
        Me.CRPersonName.HeaderText = "Current Respondent"
        Me.CRPersonName.Name = "CRPersonName"
        Me.CRPersonName.ReadOnly = True
        Me.CRPersonName.ToolTipText = "Current Respondent' full name"
        Me.CRPersonName.Width = 150
        '
        'Status
        '
        Me.Status.HeaderText = "Current Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.ToolTipText = "Instrument's current status (CODE)"
        Me.Status.Width = 130
        '
        'LogicalStatus
        '
        Me.LogicalStatus.HeaderText = "Logical Status"
        Me.LogicalStatus.Name = "LogicalStatus"
        Me.LogicalStatus.ReadOnly = True
        Me.LogicalStatus.ToolTipText = "Instrument's logical status (CDSP)"
        Me.LogicalStatus.Visible = False
        Me.LogicalStatus.Width = 130
        '
        'DOB
        '
        Me.DOB.HeaderText = "Status Date"
        Me.DOB.Name = "DOB"
        Me.DOB.ReadOnly = True
        Me.DOB.ToolTipText = "Date of last change to status"
        Me.DOB.Width = 91
        '
        'ChangedBy
        '
        Me.ChangedBy.HeaderText = "Changed By"
        Me.ChangedBy.Name = "ChangedBy"
        Me.ChangedBy.ReadOnly = True
        Me.ChangedBy.ToolTipText = "User name who last changed this status"
        Me.ChangedBy.Width = 90
        '
        'ReleaseDate
        '
        Me.ReleaseDate.HeaderText = "Release Date"
        Me.ReleaseDate.Name = "ReleaseDate"
        Me.ReleaseDate.ReadOnly = True
        Me.ReleaseDate.ToolTipText = "Date this instrument was released to CATI/CAPI/CAWI/etc."
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
        Me.grpMembers.Controls.Add(Me.btnStatus)
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
        Me.grpMembers.Text = "Instruments"
        '
        'btnStatus
        '
        Me.btnStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStatus.Enabled = False
        Me.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatus.ImageIndex = 0
        Me.btnStatus.ImageList = Me.imlViewCaseInstruments16
        Me.btnStatus.Location = New System.Drawing.Point(355, 143)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(94, 21)
        Me.btnStatus.TabIndex = 3
        Me.btnStatus.Text = "Status History"
        Me.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btnStatus, "History of status updates")
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'imlViewCaseInstruments16
        '
        Me.imlViewCaseInstruments16.ImageStream = CType(resources.GetObject("imlViewCaseInstruments16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseInstruments16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseInstruments16.Images.SetKeyName(0, "rules2.bmp")
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
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide ID columns")
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
        Me.imgIcon.Location = New System.Drawing.Point(69, 1)
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
        Me.btnEdit.ImageList = Me.imlViewCaseInstruments15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseInstruments15
        '
        Me.imlViewCaseInstruments15.ImageStream = CType(resources.GetObject("imlViewCaseInstruments15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseInstruments15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseInstruments15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCaseInstruments15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseInstruments15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewCaseInstruments15
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
        Me.btnAdd.ImageList = Me.imlViewCaseInstruments15
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
        '
        'ViewCaseInstruments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseInstruments"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnStatus As System.Windows.Forms.Button
    Friend WithEvents imlViewCaseInstruments15 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseInstruments16 As System.Windows.Forms.ImageList
    Friend WithEvents PrimarySM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents InstrumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SMMPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SMPersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CRMPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CRPersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogicalStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReleaseDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
