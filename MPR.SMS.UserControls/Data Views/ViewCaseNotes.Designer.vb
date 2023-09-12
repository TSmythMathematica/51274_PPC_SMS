'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseNotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseNotes))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.Noname = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoteDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewCaseNotes15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.imgCheckbox = New System.Windows.Forms.ImageList(Me.components)
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.chkGroupByName = New System.Windows.Forms.CheckBox()
        Me.lblShow = New System.Windows.Forms.Label()
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
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Noname, Me.MPRID, Me.NoteDate, Me.Notes, Me.Source, Me.PersonName, Me.Phone, Me.InstrumentType, Me.Username, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(3, 21)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(446, 117)
        Me.grdView.TabIndex = 0
        '
        'Noname
        '
        Me.Noname.HeaderText = ""
        Me.Noname.MinimumWidth = 20
        Me.Noname.Name = "Noname"
        Me.Noname.ReadOnly = True
        Me.Noname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Noname.Visible = False
        Me.Noname.Width = 20
        '
        'MPRID
        '
        Me.MPRID.HeaderText = "MPRID"
        Me.MPRID.Name = "MPRID"
        Me.MPRID.ReadOnly = True
        Me.MPRID.ToolTipText = "MPRID of the person this note belongs to (if applicable)"
        Me.MPRID.Visible = False
        Me.MPRID.Width = 70
        '
        'NoteDate
        '
        Me.NoteDate.HeaderText = "Date"
        Me.NoteDate.Name = "NoteDate"
        Me.NoteDate.ReadOnly = True
        Me.NoteDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoteDate.ToolTipText = "Date this record was last changed"
        Me.NoteDate.Width = 125
        '
        'Notes
        '
        Me.Notes.HeaderText = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = True
        Me.Notes.ToolTipText = "Notes"
        Me.Notes.Width = 300
        '
        'Source
        '
        Me.Source.HeaderText = "Source"
        Me.Source.Name = "Source"
        Me.Source.ReadOnly = True
        Me.Source.ToolTipText = "Source of notes (CATI, CAPI, Address, Locating, etc.)"
        Me.Source.Width = 91
        '
        'PersonName
        '
        Me.PersonName.HeaderText = "Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.ReadOnly = True
        Me.PersonName.ToolTipText = "Person's full name"
        Me.PersonName.Width = 120
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone #"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.ToolTipText = "Phone number attempted by CATI or worked in locating (if applicable)"
        '
        'InstrumentType
        '
        Me.InstrumentType.HeaderText = "Instrument Type"
        Me.InstrumentType.Name = "InstrumentType"
        Me.InstrumentType.ReadOnly = True
        Me.InstrumentType.ToolTipText = "Instrument type (if applicable)"
        Me.InstrumentType.Width = 170
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        Me.Username.ToolTipText = "Name of user who last changed this record"
        Me.Username.Width = 80
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
        Me.grpMembers.Text = "All notes"
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
        Me.imgIcon.Location = New System.Drawing.Point(54, 0)
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
        Me.btnEdit.ImageList = Me.imlViewCaseNotes15
        Me.btnEdit.Location = New System.Drawing.Point(84, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewCaseNotes15
        '
        Me.imlViewCaseNotes15.ImageStream = CType(resources.GetObject("imlViewCaseNotes15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseNotes15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseNotes15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCaseNotes15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseNotes15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewCaseNotes15
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
        Me.btnAdd.ImageList = Me.imlViewCaseNotes15
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
        'imgCheckbox
        '
        Me.imgCheckbox.ImageStream = CType(resources.GetObject("imgCheckbox.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgCheckbox.TransparentColor = System.Drawing.Color.Silver
        Me.imgCheckbox.Images.SetKeyName(0, "checkbox-unchecked.bmp")
        Me.imgCheckbox.Images.SetKeyName(1, "checkbox-checked.bmp")
        '
        'grpShow
        '
        Me.grpShow.Controls.Add(Me.chkGroupByName)
        Me.grpShow.Controls.Add(Me.lblShow)
        Me.grpShow.Location = New System.Drawing.Point(313, -4)
        Me.grpShow.Name = "grpShow"
        Me.grpShow.Size = New System.Drawing.Size(123, 27)
        Me.grpShow.TabIndex = 13
        Me.grpShow.TabStop = False
        '
        'chkGroupByName
        '
        Me.chkGroupByName.AutoSize = True
        Me.chkGroupByName.Location = New System.Drawing.Point(61, 7)
        Me.chkGroupByName.Name = "chkGroupByName"
        Me.chkGroupByName.Size = New System.Drawing.Size(54, 17)
        Me.chkGroupByName.TabIndex = 8
        Me.chkGroupByName.Text = "Name"
        Me.chkGroupByName.UseVisualStyleBackColor = True
        '
        'lblShow
        '
        Me.lblShow.AutoSize = True
        Me.lblShow.Location = New System.Drawing.Point(2, 7)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(53, 13)
        Me.lblShow.TabIndex = 9
        Me.lblShow.Text = "Group by:"
        '
        'ViewCaseNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpShow)
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseNotes"
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
    Friend WithEvents imgCheckbox As System.Windows.Forms.ImageList
    Friend WithEvents Noname As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Notes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Source As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents chkGroupByName As System.Windows.Forms.CheckBox
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents imlViewCaseNotes15 As System.Windows.Forms.ImageList

End Class
