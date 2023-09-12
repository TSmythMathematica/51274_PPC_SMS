'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocatingSelectionDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocatingSelectionDetail))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGetCase = New System.Windows.Forms.Button()
        Me.btnPriority = New System.Windows.Forms.Button()
        Me.imgImages = New System.Windows.Forms.ImageList(Me.components)
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.Priority = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MPRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Days = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeSpent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimesInLocating = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimesTouched = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Language = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TZCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SiteName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChangedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnStatus = New System.Windows.Forms.Button()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(663, 485)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 27)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnGetCase
        '
        Me.btnGetCase.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGetCase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetCase.Location = New System.Drawing.Point(199, 484)
        Me.btnGetCase.Name = "btnGetCase"
        Me.btnGetCase.Size = New System.Drawing.Size(110, 28)
        Me.btnGetCase.TabIndex = 1
        Me.btnGetCase.Text = "&Open Case"
        Me.btnGetCase.UseVisualStyleBackColor = False
        '
        'btnPriority
        '
        Me.btnPriority.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPriority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPriority.ImageKey = "Priority.bmp"
        Me.btnPriority.ImageList = Me.imgImages
        Me.btnPriority.Location = New System.Drawing.Point(315, 484)
        Me.btnPriority.Name = "btnPriority"
        Me.btnPriority.Size = New System.Drawing.Size(110, 28)
        Me.btnPriority.TabIndex = 2
        Me.btnPriority.Text = "Toggle &Priority"
        Me.btnPriority.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPriority.UseVisualStyleBackColor = False
        '
        'imgImages
        '
        Me.imgImages.ImageStream = CType(resources.GetObject("imgImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgImages.TransparentColor = System.Drawing.Color.Fuchsia
        Me.imgImages.Images.SetKeyName(0, "empty.bmp")
        Me.imgImages.Images.SetKeyName(1, "Priority.bmp")
        '
        'grdView
        '
        Me.grdView.AllowUserToAddRows = False
        Me.grdView.AllowUserToDeleteRows = False
        Me.grdView.AllowUserToOrderColumns = True
        Me.grdView.AllowUserToResizeColumns = False
        Me.grdView.AllowUserToResizeRows = False
        Me.grdView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Priority, Me.MPRID, Me.PersonName, Me.StatusCode, Me.DOB, Me.Days, Me.TimeSpent, Me.TimesInLocating, Me.TimesTouched, Me.Language, Me.State, Me.TZCode, Me.SiteName, Me.LockedBy, Me.ChangedBy})
        Me.grdView.Location = New System.Drawing.Point(12, 12)
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(935, 466)
        Me.grdView.TabIndex = 0
        '
        'Priority
        '
        Me.Priority.Description = "Priority"
        Me.Priority.HeaderText = ""
        Me.Priority.MinimumWidth = 20
        Me.Priority.Name = "Priority"
        Me.Priority.ReadOnly = True
        Me.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Priority.ToolTipText = "Primary"
        Me.Priority.Width = 20
        '
        'MPRID
        '
        Me.MPRID.HeaderText = "MPRID"
        Me.MPRID.Name = "MPRID"
        Me.MPRID.ReadOnly = True
        Me.MPRID.Width = 67
        '
        'PersonName
        '
        Me.PersonName.HeaderText = "Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.ReadOnly = True
        Me.PersonName.ToolTipText = "Person's full name"
        Me.PersonName.Width = 120
        '
        'StatusCode
        '
        Me.StatusCode.HeaderText = "Status"
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.ReadOnly = True
        Me.StatusCode.ToolTipText = "Status code"
        Me.StatusCode.Width = 60
        '
        'DOB
        '
        Me.DOB.HeaderText = "Status Date"
        Me.DOB.Name = "DOB"
        Me.DOB.ReadOnly = True
        Me.DOB.ToolTipText = "Date of last change to status"
        Me.DOB.Width = 88
        '
        'Days
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Days.DefaultCellStyle = DataGridViewCellStyle5
        Me.Days.HeaderText = "# Days"
        Me.Days.Name = "Days"
        Me.Days.ReadOnly = True
        Me.Days.ToolTipText = "Number of days since this case was sent to locating from CATI/CAPI"
        Me.Days.Width = 66
        '
        'TimeSpent
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TimeSpent.DefaultCellStyle = DataGridViewCellStyle6
        Me.TimeSpent.HeaderText = "Time Spent"
        Me.TimeSpent.Name = "TimeSpent"
        Me.TimeSpent.ReadOnly = True
        Me.TimeSpent.ToolTipText = "Time spent (in seconds) working on this case by locators"
        Me.TimeSpent.Width = 86
        '
        'TimesInLocating
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TimesInLocating.DefaultCellStyle = DataGridViewCellStyle7
        Me.TimesInLocating.HeaderText = "# of Times in Locating"
        Me.TimesInLocating.Name = "TimesInLocating"
        Me.TimesInLocating.ReadOnly = True
        Me.TimesInLocating.ToolTipText = "Number of times this case has been sent to locating from CATI/CAPI"
        Me.TimesInLocating.Width = 137
        '
        'TimesTouched
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TimesTouched.DefaultCellStyle = DataGridViewCellStyle8
        Me.TimesTouched.HeaderText = "# of Times Touched"
        Me.TimesTouched.Name = "TimesTouched"
        Me.TimesTouched.ReadOnly = True
        Me.TimesTouched.ToolTipText = "Number of times this case has been worked on by locators"
        Me.TimesTouched.Width = 128
        '
        'Language
        '
        Me.Language.HeaderText = "Language"
        Me.Language.Name = "Language"
        Me.Language.ReadOnly = True
        '
        'State
        '
        Me.State.HeaderText = "State"
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.ToolTipText = "Person's best known address"
        Me.State.Width = 57
        '
        'TZCode
        '
        Me.TZCode.HeaderText = "Time Zone"
        Me.TZCode.Name = "TZCode"
        Me.TZCode.ReadOnly = True
        Me.TZCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TZCode.ToolTipText = "Person's best known time zone"
        Me.TZCode.Width = 140
        '
        'SiteName
        '
        Me.SiteName.HeaderText = "Site"
        Me.SiteName.Name = "SiteName"
        Me.SiteName.ReadOnly = True
        Me.SiteName.ToolTipText = "Site (if applicable)"
        '
        'LockedBy
        '
        Me.LockedBy.HeaderText = "Locked By"
        Me.LockedBy.Name = "LockedBy"
        Me.LockedBy.ReadOnly = True
        Me.LockedBy.ToolTipText = "Username of user currently working on this case"
        '
        'ChangedBy
        '
        Me.ChangedBy.HeaderText = "Last Changed By"
        Me.ChangedBy.Name = "ChangedBy"
        Me.ChangedBy.ReadOnly = True
        Me.ChangedBy.ToolTipText = "User name who last changed this status"
        Me.ChangedBy.Width = 113
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(547, 485)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(110, 27)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 485)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "# of Cases:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(71, 485)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(13, 13)
        Me.lblCount.TabIndex = 7
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnStatus
        '
        Me.btnStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatus.Location = New System.Drawing.Point(431, 484)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(110, 28)
        Me.btnStatus.TabIndex = 3
        Me.btnStatus.Text = "&Status"
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'frmLocatingSelectionDetail
        '
        Me.AcceptButton = Me.btnGetCase
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(959, 519)
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.grdView)
        Me.Controls.Add(Me.btnGetCase)
        Me.Controls.Add(Me.btnPriority)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocatingSelectionDetail"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Locating: Selection Details"
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPriority As System.Windows.Forms.Button
    Friend WithEvents btnGetCase As System.Windows.Forms.Button
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents imgImages As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Priority As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Days As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeSpent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimesInLocating As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimesTouched As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Language As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TZCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiteName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnStatus As System.Windows.Forms.Button
End Class
