'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAssignCoder
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignCoder))
        Me.dgvBatchItems = New System.Windows.Forms.DataGridView
        Me.ITCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.bindingsourceStatusCodes = New System.Windows.Forms.BindingSource(Me.components)
        Me.Coder = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.bindingsourceCoders = New System.Windows.Forms.BindingSource(Me.components)
        Me.InstrumentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bilingual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bindingsourceBatchItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtInstrumentName = New System.Windows.Forms.TextBox
        Me.bindingsourceBatches = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceStatusCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceCoders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBatchItems
        '
        Me.dgvBatchItems.AllowUserToAddRows = False
        Me.dgvBatchItems.AllowUserToDeleteRows = False
        Me.dgvBatchItems.AllowUserToResizeColumns = False
        Me.dgvBatchItems.AllowUserToResizeRows = False
        Me.dgvBatchItems.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBatchItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBatchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITCode, Me.Description, Me.StatusCode, Me.Coder, Me.InstrumentID, Me.Bilingual})
        Me.dgvBatchItems.DataSource = Me.bindingsourceBatchItems
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBatchItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBatchItems.Location = New System.Drawing.Point(6, 19)
        Me.dgvBatchItems.Name = "dgvBatchItems"
        Me.dgvBatchItems.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBatchItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBatchItems.Size = New System.Drawing.Size(666, 401)
        Me.dgvBatchItems.TabIndex = 0
        '
        'ITCode
        '
        Me.ITCode.DataPropertyName = "ITCode"
        Me.ITCode.HeaderText = "IT Code"
        Me.ITCode.Name = "ITCode"
        Me.ITCode.ReadOnly = True
        Me.ITCode.Width = 80
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Instrument Type"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 160
        '
        'StatusCode
        '
        Me.StatusCode.DataSource = Me.bindingsourceStatusCodes
        Me.StatusCode.HeaderText = "StatusCode"
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.ReadOnly = True
        Me.StatusCode.Width = 200
        '
        'Coder
        '
        Me.Coder.DataSource = Me.bindingsourceCoders
        Me.Coder.HeaderText = "Coder"
        Me.Coder.Name = "Coder"
        Me.Coder.ReadOnly = True
        Me.Coder.Width = 125
        '
        'InstrumentID
        '
        Me.InstrumentID.DataPropertyName = "InstrumentID"
        Me.InstrumentID.HeaderText = "InstrumentID"
        Me.InstrumentID.Name = "InstrumentID"
        Me.InstrumentID.ReadOnly = True
        Me.InstrumentID.Visible = False
        '
        'Bilingual
        '
        Me.Bilingual.DataPropertyName = "Bilingual"
        Me.Bilingual.HeaderText = "Bilingual"
        Me.Bilingual.Name = "Bilingual"
        Me.Bilingual.ReadOnly = True
        Me.Bilingual.Width = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Instrument:"
        '
        'txtInstrumentName
        '
        Me.txtInstrumentName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtInstrumentName.Location = New System.Drawing.Point(77, 9)
        Me.txtInstrumentName.Name = "txtInstrumentName"
        Me.txtInstrumentName.ReadOnly = True
        Me.txtInstrumentName.Size = New System.Drawing.Size(357, 20)
        Me.txtInstrumentName.TabIndex = 1
        '
        'bindingsourceBatches
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvBatchItems)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 426)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(608, 480)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Save and Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(488, 480)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAssignCoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 514)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInstrumentName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAssignCoder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receiving And Batching"
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceStatusCodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceCoders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBatchItems As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInstrumentName As System.Windows.Forms.TextBox
    Friend WithEvents bindingsourceBatchItems As System.Windows.Forms.BindingSource
    Friend WithEvents bindingsourceBatches As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents bindingsourceStatusCodes As System.Windows.Forms.BindingSource
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents bindingsourceCoders As System.Windows.Forms.BindingSource
    Friend WithEvents ITCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Coder As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents InstrumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bilingual As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
