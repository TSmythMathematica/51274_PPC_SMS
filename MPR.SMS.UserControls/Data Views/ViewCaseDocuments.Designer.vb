'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseDocuments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseDocuments))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.PrimarySM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DocumentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Instrument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonHistoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressHistoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.imlViewCaseDocuments16 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseDocuments15 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrimarySM, Me.DocumentID, Me.Type, Me.Status, Me.StatusDate, Me.InstrumentID, Me.Instrument, Me.PersonHistoryID, Me.Person, Me.AddressHistoryID, Me.Address, Me.DocNum, Me.Round})
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
        'DocumentID
        '
        Me.DocumentID.HeaderText = "DocumentID"
        Me.DocumentID.Name = "DocumentID"
        Me.DocumentID.ReadOnly = True
        Me.DocumentID.Visible = False
        Me.DocumentID.Width = 70
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Type.ToolTipText = "Document Type"
        Me.Type.Width = 140
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.ToolTipText = "Document's current status"
        '
        'StatusDate
        '
        Me.StatusDate.HeaderText = "Status Date"
        Me.StatusDate.Name = "StatusDate"
        Me.StatusDate.ReadOnly = True
        '
        'InstrumentID
        '
        Me.InstrumentID.HeaderText = "InstrumentID"
        Me.InstrumentID.Name = "InstrumentID"
        Me.InstrumentID.ReadOnly = True
        Me.InstrumentID.Visible = False
        '
        'Instrument
        '
        Me.Instrument.HeaderText = "Instrument"
        Me.Instrument.Name = "Instrument"
        Me.Instrument.ReadOnly = True
        Me.Instrument.ToolTipText = "Instrument (if applicable)"
        Me.Instrument.Visible = False
        Me.Instrument.Width = 160
        '
        'PersonHistoryID
        '
        Me.PersonHistoryID.HeaderText = "PersonHistoryID"
        Me.PersonHistoryID.Name = "PersonHistoryID"
        Me.PersonHistoryID.ReadOnly = True
        Me.PersonHistoryID.Visible = False
        '
        'Person
        '
        Me.Person.HeaderText = "Person"
        Me.Person.Name = "Person"
        Me.Person.ReadOnly = True
        Me.Person.ToolTipText = "Person (if applicable)"
        Me.Person.Width = 160
        '
        'AddressHistoryID
        '
        Me.AddressHistoryID.HeaderText = "AddressHistoryID"
        Me.AddressHistoryID.Name = "AddressHistoryID"
        Me.AddressHistoryID.ReadOnly = True
        Me.AddressHistoryID.Visible = False
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.ToolTipText = "Address (if applicable)"
        Me.Address.Width = 160
        '
        'DocNum
        '
        Me.DocNum.HeaderText = "#"
        Me.DocNum.Name = "DocNum"
        Me.DocNum.ReadOnly = True
        Me.DocNum.ToolTipText = "Document # (of this type)"
        Me.DocNum.Width = 50
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
        Me.grpMembers.Controls.Add(Me.btnShowID)
        Me.grpMembers.Controls.Add(Me.btnPreview)
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
        Me.grpMembers.Text = "Documents"
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
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Enabled = False
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.ImageIndex = 0
        Me.btnPreview.ImageList = Me.imlViewCaseDocuments16
        Me.btnPreview.Location = New System.Drawing.Point(374, 143)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 3
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'imlViewCaseDocuments16
        '
        Me.imlViewCaseDocuments16.ImageStream = CType(resources.GetObject("imlViewCaseDocuments16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseDocuments16.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseDocuments16.Images.SetKeyName(0, "PrintPreview.bmp")
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(69, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(12, 14)
        Me.imgIcon.TabIndex = 4
        Me.imgIcon.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 2
        Me.btnEdit.ImageList = Me.imlViewCaseDocuments15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseDocuments15
        '
        Me.imlViewCaseDocuments15.ImageStream = CType(resources.GetObject("imlViewCaseDocuments15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseDocuments15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseDocuments15.Images.SetKeyName(0, "insert.bmp")
        Me.imlViewCaseDocuments15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseDocuments15.Images.SetKeyName(2, "update.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewCaseDocuments15
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
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.ImageList = Me.imlViewCaseDocuments15
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
        'ViewCaseDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseDocuments"
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
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents PrimarySM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DocumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Instrument As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonHistoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Person As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressHistoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imlViewCaseDocuments15 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewCaseDocuments16 As System.Windows.Forms.ImageList

End Class
