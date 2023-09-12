'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurveySettings
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveySettings))
        Me.cbInstrumentTypes = New System.Windows.Forms.ComboBox()
        Me.lblInstrumentTypes = New System.Windows.Forms.Label()
        Me.dgvSurveySettings = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMessageLabel = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvSurveySettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbInstrumentTypes
        '
        Me.cbInstrumentTypes.FormattingEnabled = True
        Me.cbInstrumentTypes.Location = New System.Drawing.Point(127, 9)
        Me.cbInstrumentTypes.Margin = New System.Windows.Forms.Padding(2)
        Me.cbInstrumentTypes.Name = "cbInstrumentTypes"
        Me.cbInstrumentTypes.Size = New System.Drawing.Size(170, 21)
        Me.cbInstrumentTypes.TabIndex = 0
        '
        'lblInstrumentTypes
        '
        Me.lblInstrumentTypes.AutoSize = True
        Me.lblInstrumentTypes.Location = New System.Drawing.Point(7, 11)
        Me.lblInstrumentTypes.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInstrumentTypes.Name = "lblInstrumentTypes"
        Me.lblInstrumentTypes.Size = New System.Drawing.Size(119, 13)
        Me.lblInstrumentTypes.TabIndex = 1
        Me.lblInstrumentTypes.Text = "Select Instrument Type:"
        '
        'dgvSurveySettings
        '
        Me.dgvSurveySettings.AllowUserToAddRows = False
        Me.dgvSurveySettings.AllowUserToDeleteRows = False
        Me.dgvSurveySettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSurveySettings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSurveySettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSurveySettings.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSurveySettings.Location = New System.Drawing.Point(10, 37)
        Me.dgvSurveySettings.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvSurveySettings.MultiSelect = False
        Me.dgvSurveySettings.Name = "dgvSurveySettings"
        Me.dgvSurveySettings.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSurveySettings.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSurveySettings.RowTemplate.Height = 24
        Me.dgvSurveySettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSurveySettings.Size = New System.Drawing.Size(605, 329)
        Me.dgvSurveySettings.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRecordsLabel, Me.tsMessageLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 382)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsRecordsLabel
        '
        Me.tsRecordsLabel.Name = "tsRecordsLabel"
        Me.tsRecordsLabel.Size = New System.Drawing.Size(0, 17)
        '
        'tsMessageLabel
        '
        Me.tsMessageLabel.Name = "tsMessageLabel"
        Me.tsMessageLabel.Size = New System.Drawing.Size(0, 17)
        '
        'frmSurveySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 404)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvSurveySettings)
        Me.Controls.Add(Me.lblInstrumentTypes)
        Me.Controls.Add(Me.cbInstrumentTypes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmSurveySettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Survey Settings"
        CType(Me.dgvSurveySettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbInstrumentTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblInstrumentTypes As System.Windows.Forms.Label
    Friend WithEvents dgvSurveySettings As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsMessageLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
