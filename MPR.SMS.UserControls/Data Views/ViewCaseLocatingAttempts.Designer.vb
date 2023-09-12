'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCaseLocatingAttempts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCaseLocatingAttempts))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.BestPhone = New System.Windows.Forms.DataGridViewImageColumn()
        Me.LocatingAttemptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AttemptDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlViewLocatingAttempts15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.imlViewLocatingAttempts16 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BestPhone, Me.LocatingAttemptID, Me.AttemptDate, Me.Type, Me.Result, Me.Status, Me.Phone, Me.Note, Me.PersonName, Me.Address, Me.Email, Me.User, Me.Round})
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
        'BestPhone
        '
        Me.BestPhone.Description = "Best"
        Me.BestPhone.HeaderText = ""
        Me.BestPhone.MinimumWidth = 20
        Me.BestPhone.Name = "BestPhone"
        Me.BestPhone.ReadOnly = True
        Me.BestPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestPhone.ToolTipText = "Best?"
        Me.BestPhone.Visible = False
        Me.BestPhone.Width = 20
        '
        'LocatingAttemptID
        '
        Me.LocatingAttemptID.HeaderText = "LocatingAttemptID"
        Me.LocatingAttemptID.Name = "LocatingAttemptID"
        Me.LocatingAttemptID.ReadOnly = True
        Me.LocatingAttemptID.Visible = False
        Me.LocatingAttemptID.Width = 70
        '
        'AttemptDate
        '
        Me.AttemptDate.HeaderText = "Date"
        Me.AttemptDate.Name = "AttemptDate"
        Me.AttemptDate.ReadOnly = True
        Me.AttemptDate.ToolTipText = "Date of attempt"
        Me.AttemptDate.Width = 125
        '
        'Type
        '
        Me.Type.HeaderText = "Attempt Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.ToolTipText = "Type of attempt"
        Me.Type.Width = 120
        '
        'Result
        '
        Me.Result.HeaderText = "Result"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        Me.Result.ToolTipText = "Result of this attempt"
        Me.Result.Width = 120
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.ToolTipText = "Locating Status Code"
        Me.Status.Width = 150
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.ToolTipText = "Phone found during this attempt"
        '
        'Note
        '
        Me.Note.HeaderText = "Notes"
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        Me.Note.ToolTipText = "Notes"
        Me.Note.Width = 150
        '
        'PersonName
        '
        Me.PersonName.HeaderText = "Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.ReadOnly = True
        Me.PersonName.ToolTipText = "Name found during this attempt"
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.ToolTipText = "Address found during this attempt"
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.ToolTipText = "Email found during this attempt"
        '
        'User
        '
        Me.User.HeaderText = "User Name"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        Me.User.ToolTipText = "Name of user that initiated this attempt"
        Me.User.Width = 120
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
        Me.grpMembers.Text = "Locating attempts"
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
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide LocatingAttempt ID column")
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
        Me.imgIcon.InitialImage = CType(resources.GetObject("imgIcon.InitialImage"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(98, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(18, 15)
        Me.imgIcon.TabIndex = 5
        Me.imgIcon.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 1
        Me.btnEdit.ImageList = Me.imlViewLocatingAttempts15
        Me.btnEdit.Location = New System.Drawing.Point(108, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlViewLocatingAttempts15
        '
        Me.imlViewLocatingAttempts15.ImageStream = CType(resources.GetObject("imlViewLocatingAttempts15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewLocatingAttempts15.TransparentColor = System.Drawing.Color.White
        Me.imlViewLocatingAttempts15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewLocatingAttempts15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewLocatingAttempts15.Images.SetKeyName(2, "insert.bmp")
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imlViewLocatingAttempts15
        Me.btnDelete.Location = New System.Drawing.Point(189, 143)
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
        Me.btnAdd.ImageList = Me.imlViewLocatingAttempts15
        Me.btnAdd.Location = New System.Drawing.Point(3, 143)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "New Attempt..."
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
        'imlViewLocatingAttempts16
        '
        Me.imlViewLocatingAttempts16.ImageStream = CType(resources.GetObject("imlViewLocatingAttempts16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlViewLocatingAttempts16.TransparentColor = System.Drawing.Color.White
        Me.imlViewLocatingAttempts16.Images.SetKeyName(0, "search4people.bmp")
        '
        'ViewCaseLocatingAttempts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCaseLocatingAttempts"
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
    Friend WithEvents BestPhone As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents LocatingAttemptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AttemptDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Note As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imlViewLocatingAttempts15 As System.Windows.Forms.ImageList
    Friend WithEvents imlViewLocatingAttempts16 As System.Windows.Forms.ImageList

End Class
