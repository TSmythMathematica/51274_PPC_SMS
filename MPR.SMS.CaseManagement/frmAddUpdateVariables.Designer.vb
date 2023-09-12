'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddUpdateVariables
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
        Dim ssFrequency As System.Windows.Forms.StatusStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUpdateVariables))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsslTotalRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ComputerNameLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvVariables = New System.Windows.Forms.DataGridView()
        Me.tsbtnFrequency = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnVariables = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnExcel = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.tsFrequency = New System.Windows.Forms.ToolStrip()
        ssFrequency = New System.Windows.Forms.StatusStrip()
        ssFrequency.SuspendLayout()
        CType(Me.dgvVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsFrequency.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssFrequency
        '
        ssFrequency.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTotalRecords, Me.tsslMessage, Me.ComputerNameLabel, Me.UserLabel})
        ssFrequency.Location = New System.Drawing.Point(0, 641)
        ssFrequency.Name = "ssFrequency"
        ssFrequency.Size = New System.Drawing.Size(892, 25)
        ssFrequency.TabIndex = 9
        ssFrequency.Text = "StatusStrip1"
        '
        'tsslTotalRecords
        '
        Me.tsslTotalRecords.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTotalRecords.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslTotalRecords.Name = "tsslTotalRecords"
        Me.tsslTotalRecords.Size = New System.Drawing.Size(86, 20)
        Me.tsslTotalRecords.Text = "Total Records:"
        '
        'tsslMessage
        '
        Me.tsslMessage.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslMessage.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslMessage.Name = "tsslMessage"
        Me.tsslMessage.Size = New System.Drawing.Size(590, 20)
        Me.tsslMessage.Spring = True
        '
        'ComputerNameLabel
        '
        Me.ComputerNameLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ComputerNameLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ComputerNameLabel.Image = CType(resources.GetObject("ComputerNameLabel.Image"), System.Drawing.Image)
        Me.ComputerNameLabel.Name = "ComputerNameLabel"
        Me.ComputerNameLabel.Size = New System.Drawing.Size(116, 20)
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
        Me.UserLabel.Size = New System.Drawing.Size(85, 20)
        Me.UserLabel.Text = "User Name"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvVariables
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVariables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVariables.Location = New System.Drawing.Point(0, 35)
        Me.dgvVariables.Name = "dgvVariables"
        Me.dgvVariables.RowHeadersWidth = 35
        Me.dgvVariables.RowTemplate.Height = 21
        Me.dgvVariables.Size = New System.Drawing.Size(892, 606)
        Me.dgvVariables.TabIndex = 10
        '
        'tsbtnFrequency
        '
        Me.tsbtnFrequency.Image = CType(resources.GetObject("tsbtnFrequency.Image"), System.Drawing.Image)
        Me.tsbtnFrequency.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnFrequency.Name = "tsbtnFrequency"
        Me.tsbtnFrequency.Size = New System.Drawing.Size(97, 32)
        Me.tsbtnFrequency.Text = "Frequency Label"
        Me.tsbtnFrequency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnFrequency.ToolTipText = "Add / Edit Frequency Label"
        '
        'tsbtnVariables
        '
        Me.tsbtnVariables.Image = CType(resources.GetObject("tsbtnVariables.Image"), System.Drawing.Image)
        Me.tsbtnVariables.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnVariables.Name = "tsbtnVariables"
        Me.tsbtnVariables.Size = New System.Drawing.Size(132, 32)
        Me.tsbtnVariables.Text = "Variable PreResponse"
        Me.tsbtnVariables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnVariables.ToolTipText = "Add / Edit Resolution"
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
        'tsbtnExcel
        '
        Me.tsbtnExcel.Image = CType(resources.GetObject("tsbtnExcel.Image"), System.Drawing.Image)
        Me.tsbtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExcel.Name = "tsbtnExcel"
        Me.tsbtnExcel.Size = New System.Drawing.Size(87, 32)
        Me.tsbtnExcel.Text = "Export to Excel"
        Me.tsbtnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'tsFrequency
        '
        Me.tsFrequency.AutoSize = False
        Me.tsFrequency.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnSave, Me.tsbtnFrequency, Me.tsbtnVariables, Me.tsbtnClose, Me.tsbtnExcel})
        Me.tsFrequency.Location = New System.Drawing.Point(0, 0)
        Me.tsFrequency.Name = "tsFrequency"
        Me.tsFrequency.Size = New System.Drawing.Size(892, 35)
        Me.tsFrequency.TabIndex = 8
        Me.tsFrequency.Text = "ToolStrip1"
        '
        'frmAddUpdateVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 666)
        Me.Controls.Add(Me.dgvVariables)
        Me.Controls.Add(ssFrequency)
        Me.Controls.Add(Me.tsFrequency)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddUpdateVariables"
        Me.Text = "frmAddUpdateVariables"
        ssFrequency.ResumeLayout(False)
        ssFrequency.PerformLayout()
        CType(Me.dgvVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsFrequency.ResumeLayout(False)
        Me.tsFrequency.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvVariables As System.Windows.Forms.DataGridView
    Friend WithEvents tsbtnFrequency As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnVariables As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslTotalRecords As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ComputerNameLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsFrequency As System.Windows.Forms.ToolStrip
End Class
