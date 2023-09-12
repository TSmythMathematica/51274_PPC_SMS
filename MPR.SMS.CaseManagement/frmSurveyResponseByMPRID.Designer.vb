'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurveyResponseByMPRID
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveyResponseByMPRID))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ssResponseUpdate = New System.Windows.Forms.StatusStrip()
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.BlankLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsMPRID = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsResponseUpdate = New System.Windows.Forms.ToolStrip()
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton()
        Me.dgvResponseUpdate = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ssResponseUpdate.SuspendLayout()
        Me.tsResponseUpdate.SuspendLayout()
        CType(Me.dgvResponseUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssResponseUpdate
        '
        Me.ssResponseUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRecordsLabel, Me.tspProgress, Me.BlankLabel, Me.UserLabel})
        Me.ssResponseUpdate.Location = New System.Drawing.Point(0, 547)
        Me.ssResponseUpdate.Name = "ssResponseUpdate"
        Me.ssResponseUpdate.Size = New System.Drawing.Size(780, 25)
        Me.ssResponseUpdate.TabIndex = 7
        Me.ssResponseUpdate.Text = "StatusStrip1"
        '
        'TotalRecordsLabel
        '
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(83, 20)
        Me.TotalRecordsLabel.Text = "Total Records"
        '
        'tspProgress
        '
        Me.tspProgress.Name = "tspProgress"
        Me.tspProgress.Size = New System.Drawing.Size(100, 19)
        Me.tspProgress.Visible = False
        '
        'BlankLabel
        '
        Me.BlankLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankLabel.Name = "BlankLabel"
        Me.BlankLabel.Size = New System.Drawing.Size(662, 20)
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
        'tsbtnSave
        '
        Me.tsbtnSave.Image = CType(resources.GetObject("tsbtnSave.Image"), System.Drawing.Image)
        Me.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSave.Name = "tsbtnSave"
        Me.tsbtnSave.Size = New System.Drawing.Size(35, 32)
        Me.tsbtnSave.Text = "Save"
        Me.tsbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnSave.ToolTipText = "Save this session"
        Me.tsbtnSave.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'tsMPRID
        '
        Me.tsMPRID.Name = "tsMPRID"
        Me.tsMPRID.ReadOnly = True
        Me.tsMPRID.Size = New System.Drawing.Size(100, 35)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'tsResponseUpdate
        '
        Me.tsResponseUpdate.AutoSize = False
        Me.tsResponseUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnSave, Me.ToolStripSeparator1, Me.tsMPRID, Me.ToolStripSeparator2, Me.tsbtnClose})
        Me.tsResponseUpdate.Location = New System.Drawing.Point(0, 0)
        Me.tsResponseUpdate.Name = "tsResponseUpdate"
        Me.tsResponseUpdate.Size = New System.Drawing.Size(780, 35)
        Me.tsResponseUpdate.TabIndex = 5
        Me.tsResponseUpdate.Text = "ToolStrip1"
        '
        'tsbtnClose
        '
        Me.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnClose.Name = "tsbtnClose"
        Me.tsbtnClose.Size = New System.Drawing.Size(40, 32)
        Me.tsbtnClose.Text = "Close"
        '
        'dgvResponseUpdate
        '
        Me.dgvResponseUpdate.AllowUserToAddRows = False
        Me.dgvResponseUpdate.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvResponseUpdate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResponseUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvResponseUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResponseUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResponseUpdate.Location = New System.Drawing.Point(0, 0)
        Me.dgvResponseUpdate.MultiSelect = False
        Me.dgvResponseUpdate.Name = "dgvResponseUpdate"
        Me.dgvResponseUpdate.ReadOnly = True
        Me.dgvResponseUpdate.RowHeadersWidth = 25
        Me.dgvResponseUpdate.RowTemplate.Height = 18
        Me.dgvResponseUpdate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResponseUpdate.Size = New System.Drawing.Size(780, 508)
        Me.dgvResponseUpdate.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvResponseUpdate)
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 508)
        Me.Panel1.TabIndex = 6
        '
        'frmSurveyResponseByMPRID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 572)
        Me.Controls.Add(Me.ssResponseUpdate)
        Me.Controls.Add(Me.tsResponseUpdate)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(796, 610)
        Me.Name = "frmSurveyResponseByMPRID"
        Me.Text = "Update Survey Preliminary Response Data"
        Me.ssResponseUpdate.ResumeLayout(False)
        Me.ssResponseUpdate.PerformLayout()
        Me.tsResponseUpdate.ResumeLayout(False)
        Me.tsResponseUpdate.PerformLayout()
        CType(Me.dgvResponseUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssResponseUpdate As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BlankLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMPRID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsResponseUpdate As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvResponseUpdate As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
