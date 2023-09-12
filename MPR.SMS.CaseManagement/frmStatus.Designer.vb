'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatus))
        Me.dgvStatus = New System.Windows.Forms.DataGridView
        Me.ssStatus = New System.Windows.Forms.StatusStrip
        Me.tsslTotalRecords = New System.Windows.Forms.ToolStripStatusLabel
        Me.BlankSpaceLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ComputerNameLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsStatus = New System.Windows.Forms.ToolStrip
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton
        Me.tsbtnRules = New System.Windows.Forms.ToolStripButton
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.tsStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStatus
        '
        Me.dgvStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatus.Location = New System.Drawing.Point(0, 38)
        Me.dgvStatus.Name = "dgvStatus"
        Me.dgvStatus.RowHeadersWidth = 35
        Me.dgvStatus.RowTemplate.Height = 21
        Me.dgvStatus.Size = New System.Drawing.Size(486, 173)
        Me.dgvStatus.TabIndex = 0
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTotalRecords, Me.BlankSpaceLabel, Me.ComputerNameLabel, Me.UserLabel})
        Me.ssStatus.Location = New System.Drawing.Point(0, 214)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(486, 25)
        Me.ssStatus.TabIndex = 3
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tsslTotalRecords
        '
        Me.tsslTotalRecords.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTotalRecords.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslTotalRecords.Name = "tsslTotalRecords"
        Me.tsslTotalRecords.Size = New System.Drawing.Size(81, 20)
        Me.tsslTotalRecords.Text = "Total Records:"
        '
        'BlankSpaceLabel
        '
        Me.BlankSpaceLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankSpaceLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankSpaceLabel.Name = "BlankSpaceLabel"
        Me.BlankSpaceLabel.Size = New System.Drawing.Size(223, 20)
        Me.BlankSpaceLabel.Spring = True
        '
        'ComputerNameLabel
        '
        Me.ComputerNameLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ComputerNameLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ComputerNameLabel.Name = "ComputerNameLabel"
        Me.ComputerNameLabel.Size = New System.Drawing.Size(88, 20)
        Me.ComputerNameLabel.Text = "Computer Name"
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(79, 20)
        Me.UserLabel.Text = "User Name"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsStatus
        '
        Me.tsStatus.AutoSize = False
        Me.tsStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnSave, Me.tsbtnRules, Me.tsbtnClose})
        Me.tsStatus.Location = New System.Drawing.Point(0, 0)
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(486, 35)
        Me.tsStatus.TabIndex = 4
        Me.tsStatus.Text = "ToolStrip1"
        '
        'tsbtnSave
        '
        Me.tsbtnSave.AutoSize = False
        Me.tsbtnSave.Image = CType(resources.GetObject("tsbtnSave.Image"), System.Drawing.Image)
        Me.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSave.Name = "tsbtnSave"
        Me.tsbtnSave.Size = New System.Drawing.Size(35, 33)
        Me.tsbtnSave.Text = "Save"
        Me.tsbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnSave.ToolTipText = "Save Changes"
        '
        'tsbtnRules
        '
        Me.tsbtnRules.AutoSize = False
        Me.tsbtnRules.Image = CType(resources.GetObject("tsbtnRules.Image"), System.Drawing.Image)
        Me.tsbtnRules.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnRules.Name = "tsbtnRules"
        Me.tsbtnRules.Size = New System.Drawing.Size(35, 33)
        Me.tsbtnRules.Text = "Rules"
        Me.tsbtnRules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnRules.ToolTipText = "Add/Update Status Update Rules"
        '
        'tsbtnClose
        '
        Me.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnClose.AutoSize = False
        Me.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnClose.Name = "tsbtnClose"
        Me.tsbtnClose.Size = New System.Drawing.Size(35, 33)
        Me.tsbtnClose.Text = "Close"
        Me.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnClose.ToolTipText = "Close this form"
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 239)
        Me.Controls.Add(Me.tsStatus)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.dgvStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStatus"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.tsStatus.ResumeLayout(False)
        Me.tsStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvStatus As System.Windows.Forms.DataGridView
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents ComputerNameLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankSpaceLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsStatus As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnRules As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslTotalRecords As System.Windows.Forms.ToolStripStatusLabel
End Class
