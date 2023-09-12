'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayments))
        Me.tsPayments = New System.Windows.Forms.ToolStrip
        Me.btnReissue = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton
        Me.tsbFilter = New System.Windows.Forms.ToolStripButton
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.dgvPayments = New System.Windows.Forms.DataGridView
        Me.ssPayments = New System.Windows.Forms.StatusStrip
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.BlankLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBoxAdresses = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses
        Me.chkEditNameAddress = New System.Windows.Forms.CheckBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.grpPayments = New System.Windows.Forms.GroupBox
        Me.tsPayments.SuspendLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssPayments.SuspendLayout()
        Me.GroupBoxAdresses.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.grpPayments.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsPayments
        '
        Me.tsPayments.AutoSize = False
        Me.tsPayments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReissue, Me.ToolStripSeparator1, Me.tsbtnClose, Me.tsbFilter, Me.tsbRefresh})
        Me.tsPayments.Location = New System.Drawing.Point(0, 0)
        Me.tsPayments.Name = "tsPayments"
        Me.tsPayments.Size = New System.Drawing.Size(703, 35)
        Me.tsPayments.TabIndex = 0
        Me.tsPayments.Text = "ToolStrip1"
        '
        'btnReissue
        '
        Me.btnReissue.Image = CType(resources.GetObject("btnReissue.Image"), System.Drawing.Image)
        Me.btnReissue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReissue.Name = "btnReissue"
        Me.btnReissue.Size = New System.Drawing.Size(48, 32)
        Me.btnReissue.Text = "Reissue"
        Me.btnReissue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'tsbtnClose
        '
        Me.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnClose.Name = "tsbtnClose"
        Me.tsbtnClose.Size = New System.Drawing.Size(37, 32)
        Me.tsbtnClose.Text = "Close"
        '
        'tsbFilter
        '
        Me.tsbFilter.Image = CType(resources.GetObject("tsbFilter.Image"), System.Drawing.Image)
        Me.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFilter.Name = "tsbFilter"
        Me.tsbFilter.Size = New System.Drawing.Size(35, 32)
        Me.tsbFilter.Text = "Filter"
        Me.tsbFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbFilter.ToolTipText = "Filter the list of payments"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(49, 32)
        Me.tsbRefresh.Text = "Refresh"
        Me.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbRefresh.ToolTipText = "Remove filters and refresh payment list"
        '
        'dgvPayments
        '
        Me.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPayments.Location = New System.Drawing.Point(3, 16)
        Me.dgvPayments.Name = "dgvPayments"
        Me.dgvPayments.RowTemplate.Height = 18
        Me.dgvPayments.Size = New System.Drawing.Size(697, 106)
        Me.dgvPayments.TabIndex = 0
        '
        'ssPayments
        '
        Me.ssPayments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRecordsLabel, Me.BlankLabel, Me.UserLabel})
        Me.ssPayments.Location = New System.Drawing.Point(0, 514)
        Me.ssPayments.Name = "ssPayments"
        Me.ssPayments.Size = New System.Drawing.Size(703, 25)
        Me.ssPayments.TabIndex = 2
        Me.ssPayments.Text = "StatusStrip1"
        '
        'TotalRecordsLabel
        '
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(77, 20)
        Me.TotalRecordsLabel.Text = "Total Records"
        '
        'BlankLabel
        '
        Me.BlankLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankLabel.Name = "BlankLabel"
        Me.BlankLabel.Size = New System.Drawing.Size(591, 20)
        Me.BlankLabel.Spring = True
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(20, 20)
        '
        'GroupBoxAdresses
        '
        Me.GroupBoxAdresses.Controls.Add(Me.SplitContainer1)
        Me.GroupBoxAdresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAdresses.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxAdresses.Name = "GroupBoxAdresses"
        Me.GroupBoxAdresses.Size = New System.Drawing.Size(703, 328)
        Me.GroupBoxAdresses.TabIndex = 0
        Me.GroupBoxAdresses.TabStop = False
        Me.GroupBoxAdresses.Text = "Selected case:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ViewCaseMembers)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ViewCaseAddresses)
        Me.SplitContainer1.Size = New System.Drawing.Size(697, 309)
        Me.SplitContainer1.SplitterDistance = 158
        Me.SplitContainer1.TabIndex = 0
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.Size = New System.Drawing.Size(697, 158)
        Me.ViewCaseMembers.TabIndex = 0
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(697, 147)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'chkEditNameAddress
        '
        Me.chkEditNameAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkEditNameAddress.AutoSize = True
        Me.chkEditNameAddress.Location = New System.Drawing.Point(3, 128)
        Me.chkEditNameAddress.Name = "chkEditNameAddress"
        Me.chkEditNameAddress.Size = New System.Drawing.Size(188, 17)
        Me.chkEditNameAddress.TabIndex = 1
        Me.chkEditNameAddress.Text = "Reissue to different name/address"
        Me.chkEditNameAddress.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.grpPayments)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEditNameAddress)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBoxAdresses)
        Me.SplitContainer2.Size = New System.Drawing.Size(703, 479)
        Me.SplitContainer2.SplitterDistance = 147
        Me.SplitContainer2.TabIndex = 1
        '
        'grpPayments
        '
        Me.grpPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPayments.Controls.Add(Me.dgvPayments)
        Me.grpPayments.Location = New System.Drawing.Point(0, 0)
        Me.grpPayments.Name = "grpPayments"
        Me.grpPayments.Size = New System.Drawing.Size(703, 125)
        Me.grpPayments.TabIndex = 0
        Me.grpPayments.TabStop = False
        Me.grpPayments.Text = "Sent payments:"
        '
        'frmPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 539)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ssPayments)
        Me.Controls.Add(Me.tsPayments)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPayments"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsPayments.ResumeLayout(False)
        Me.tsPayments.PerformLayout()
        CType(Me.dgvPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssPayments.ResumeLayout(False)
        Me.ssPayments.PerformLayout()
        Me.GroupBoxAdresses.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.grpPayments.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsPayments As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPayments As System.Windows.Forms.DataGridView
    Friend WithEvents ssPayments As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBoxAdresses As System.Windows.Forms.GroupBox
    Friend WithEvents btnReissue As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkEditNameAddress As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpPayments As System.Windows.Forms.GroupBox
    Friend WithEvents tsbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
End Class
