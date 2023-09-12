'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewConfirmitCallHist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewConfirmitCallHist))
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.btnShowID = New System.Windows.Forms.Button()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.imlViewCaseNotes15 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.imgCheckbox = New System.Windows.Forms.ImageList(Me.components)
        Me.grpShow = New System.Windows.Forms.GroupBox()
        Me.Noname = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoteDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DialDisp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeZone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CallCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SMVerified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefusalScore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstrumentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdView,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpMembers.SuspendLayout
        CType(Me.imgIcon,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'grdView
        '
        Me.grdView.AllowUserToAddRows = false
        Me.grdView.AllowUserToDeleteRows = false
        Me.grdView.AllowUserToOrderColumns = true
        Me.grdView.AllowUserToResizeRows = false
        Me.grdView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Noname, Me.MPRID, Me.NoteDate, Me.DialDisp, Me.Notes, Me.Phone, Me.TimeZone, Me.CallCount, Me.PhoneIndex, Me.SMVerified, Me.RefusalScore, Me.QL, Me.Username, Me.InstrumentType, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(3, 21)
        Me.grdView.MultiSelect = false
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = true
        Me.grdView.RowHeadersVisible = false
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(446, 141)
        Me.grdView.TabIndex = 0
        '
        'grpMembers
        '
        Me.grpMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpMembers.Controls.Add(Me.btnShowID)
        Me.grpMembers.Controls.Add(Me.imgIcon)
        Me.grpMembers.Controls.Add(Me.grdView)
        Me.grpMembers.Location = New System.Drawing.Point(3, 3)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Size = New System.Drawing.Size(452, 170)
        Me.grpMembers.TabIndex = 1
        Me.grpMembers.TabStop = false
        Me.grpMembers.Text = "Confirmit Call History"
        '
        'btnShowID
        '
        Me.btnShowID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnShowID.FlatAppearance.BorderSize = 0
        Me.btnShowID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowID.ImageKey = "show.bmp"
        Me.btnShowID.ImageList = Me.imlShowHide
        Me.btnShowID.Location = New System.Drawing.Point(437, -1)
        Me.btnShowID.Margin = New System.Windows.Forms.Padding(1)
        Me.btnShowID.Name = "btnShowID"
        Me.btnShowID.Size = New System.Drawing.Size(12, 12)
        Me.btnShowID.TabIndex = 6
        Me.btnShowID.TabStop = false
        Me.ToolTip.SetToolTip(Me.btnShowID, "Show/Hide MPRID column")
        Me.btnShowID.UseVisualStyleBackColor = true
        '
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"),System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(110, 0)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 14)
        Me.imgIcon.TabIndex = 4
        Me.imgIcon.TabStop = false
        '
        'imlViewCaseNotes15
        '
        Me.imlViewCaseNotes15.ImageStream = CType(resources.GetObject("imlViewCaseNotes15.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imlViewCaseNotes15.TransparentColor = System.Drawing.Color.White
        Me.imlViewCaseNotes15.Images.SetKeyName(0, "update.bmp")
        Me.imlViewCaseNotes15.Images.SetKeyName(1, "delete.bmp")
        Me.imlViewCaseNotes15.Images.SetKeyName(2, "insert.bmp")
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"),System.Windows.Forms.ImageListStreamer)
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
        Me.imgCheckbox.ImageStream = CType(resources.GetObject("imgCheckbox.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imgCheckbox.TransparentColor = System.Drawing.Color.Silver
        Me.imgCheckbox.Images.SetKeyName(0, "checkbox-unchecked.bmp")
        Me.imgCheckbox.Images.SetKeyName(1, "checkbox-checked.bmp")
        '
        'grpShow
        '
        Me.grpShow.Location = New System.Drawing.Point(313, -4)
        Me.grpShow.Name = "grpShow"
        Me.grpShow.Size = New System.Drawing.Size(123, 27)
        Me.grpShow.TabIndex = 13
        Me.grpShow.TabStop = false
        '
        'Noname
        '
        Me.Noname.HeaderText = ""
        Me.Noname.MinimumWidth = 20
        Me.Noname.Name = "Noname"
        Me.Noname.ReadOnly = true
        Me.Noname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Noname.Visible = false
        Me.Noname.Width = 20
        '
        'MPRID
        '
        Me.MPRID.HeaderText = "MPRID"
        Me.MPRID.Name = "MPRID"
        Me.MPRID.ReadOnly = true
        Me.MPRID.ToolTipText = "MPRID of the person this note belongs to (if applicable)"
        Me.MPRID.Visible = false
        Me.MPRID.Width = 70
        '
        'NoteDate
        '
        Me.NoteDate.HeaderText = "Date"
        Me.NoteDate.Name = "NoteDate"
        Me.NoteDate.ReadOnly = true
        Me.NoteDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoteDate.ToolTipText = "Date this record was last changed"
        Me.NoteDate.Width = 125
        '
        'DialDisp
        '
        Me.DialDisp.HeaderText = "DialDisp"
        Me.DialDisp.Name = "DialDisp"
        Me.DialDisp.ReadOnly = true
        Me.DialDisp.ToolTipText = "DialDisp"
        Me.DialDisp.Width = 91
        '
        'Notes
        '
        Me.Notes.HeaderText = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = true
        Me.Notes.ToolTipText = "Notes"
        Me.Notes.Width = 300
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone #"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = true
        Me.Phone.ToolTipText = "Phone number attempted by CATI or worked in locating (if applicable)"
        '
        'TimeZone
        '
        Me.TimeZone.HeaderText = "Time Zone"
        Me.TimeZone.Name = "TimeZone"
        Me.TimeZone.ReadOnly = true
        Me.TimeZone.ToolTipText = "Person's full name"
        Me.TimeZone.Width = 120
        '
        'CallCount
        '
        Me.CallCount.HeaderText = "Call Count"
        Me.CallCount.Name = "CallCount"
        Me.CallCount.ReadOnly = true
        '
        'PhoneIndex
        '
        Me.PhoneIndex.HeaderText = "Phone Index"
        Me.PhoneIndex.Name = "PhoneIndex"
        Me.PhoneIndex.ReadOnly = true
        '
        'SMVerified
        '
        Me.SMVerified.HeaderText = "SM Verified?"
        Me.SMVerified.Name = "SMVerified"
        Me.SMVerified.ReadOnly = true
        '
        'RefusalScore
        '
        Me.RefusalScore.HeaderText = "Refusal Score"
        Me.RefusalScore.Name = "RefusalScore"
        Me.RefusalScore.ReadOnly = true
        '
        'QL
        '
        Me.QL.HeaderText = "QualifiedLevel"
        Me.QL.Name = "QL"
        Me.QL.ReadOnly = true
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = true
        Me.Username.ToolTipText = "Name of user who last changed this record"
        Me.Username.Width = 80
        '
        'InstrumentType
        '
        Me.InstrumentType.HeaderText = "Instrument Type"
        Me.InstrumentType.Name = "InstrumentType"
        Me.InstrumentType.ReadOnly = true
        Me.InstrumentType.ToolTipText = "Instrument type (if applicable)"
        Me.InstrumentType.Width = 170
        '
        'Round
        '
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = true
        Me.Round.ToolTipText = "Round when data was last changed"
        Me.Round.Width = 50
        '
        'ViewCibfurnutCallHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpShow)
        Me.Controls.Add(Me.grpMembers)
        Me.Name = "ViewCibfurnutCallHist"
        Me.Size = New System.Drawing.Size(458, 176)
        CType(Me.grdView,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpMembers.ResumeLayout(false)
        CType(Me.imgIcon,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents grpMembers As System.Windows.Forms.GroupBox
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnShowID As System.Windows.Forms.Button
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents imgCheckbox As System.Windows.Forms.ImageList
    Friend WithEvents grpShow As System.Windows.Forms.GroupBox
    Friend WithEvents imlViewCaseNotes15 As System.Windows.Forms.ImageList
    Friend WithEvents Noname As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoteDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DialDisp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Notes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeZone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CallCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SMVerified As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefusalScore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
