'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBatchCreate2
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchCreate2))
        Me.dgvBatchItems = New System.Windows.Forms.DataGridView()
        Me.ITCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.bindingsourceStatusCodes = New System.Windows.Forms.BindingSource(Me.components)
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bindingsourceBatchItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBatchID = New System.Windows.Forms.TextBox()
        Me.txtBatchNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBatchNotes = New System.Windows.Forms.TextBox()
        Me.btnCreateNewBatch = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInstrumentName = New System.Windows.Forms.TextBox()
        Me.btnPrintBatchSheet = New System.Windows.Forms.Button()
        Me.bindingsourceBatches = New System.Windows.Forms.BindingSource(Me.components)
        Me.bindingnavBatchItems = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceStatusCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingnavBatchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingnavBatchItems.SuspendLayout()
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
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBatchItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvBatchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITCode, Me.Description, Me.StatusCode, Me.Notes})
        Me.dgvBatchItems.DataSource = Me.bindingsourceBatchItems
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBatchItems.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvBatchItems.Location = New System.Drawing.Point(6, 9)
        Me.dgvBatchItems.Name = "dgvBatchItems"
        Me.dgvBatchItems.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBatchItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvBatchItems.Size = New System.Drawing.Size(666, 262)
        Me.dgvBatchItems.TabIndex = 0
        '
        'ITCode
        '
        Me.ITCode.DataPropertyName = "ITCode"
        Me.ITCode.HeaderText = "IT Code"
        Me.ITCode.Name = "ITCode"
        Me.ITCode.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Instrument Type"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 125
        '
        'StatusCode
        '
        Me.StatusCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.StatusCode.DataSource = Me.bindingsourceStatusCodes
        Me.StatusCode.DisplayStyleForCurrentCellOnly = True
        Me.StatusCode.HeaderText = "Status"
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.ReadOnly = True
        Me.StatusCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StatusCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.StatusCode.Width = 225
        '
        'Notes
        '
        Me.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Notes.DataPropertyName = "Notes"
        Me.Notes.HeaderText = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Batch ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(131, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Batch Number:"
        '
        'txtBatchID
        '
        Me.txtBatchID.Location = New System.Drawing.Point(77, 46)
        Me.txtBatchID.Name = "txtBatchID"
        Me.txtBatchID.ReadOnly = True
        Me.txtBatchID.Size = New System.Drawing.Size(48, 20)
        Me.txtBatchID.TabIndex = 3
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.Location = New System.Drawing.Point(210, 46)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtBatchNumber.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 386)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Batch Notes:"
        '
        'txtBatchNotes
        '
        Me.txtBatchNotes.Location = New System.Drawing.Point(13, 402)
        Me.txtBatchNotes.Multiline = True
        Me.txtBatchNotes.Name = "txtBatchNotes"
        Me.txtBatchNotes.Size = New System.Drawing.Size(561, 105)
        Me.txtBatchNotes.TabIndex = 9
        '
        'btnCreateNewBatch
        '
        Me.btnCreateNewBatch.Location = New System.Drawing.Point(592, 386)
        Me.btnCreateNewBatch.Name = "btnCreateNewBatch"
        Me.btnCreateNewBatch.Size = New System.Drawing.Size(104, 23)
        Me.btnCreateNewBatch.TabIndex = 12
        Me.btnCreateNewBatch.Text = "Create &New Batch"
        Me.btnCreateNewBatch.UseVisualStyleBackColor = True
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
        'btnPrintBatchSheet
        '
        Me.btnPrintBatchSheet.Location = New System.Drawing.Point(592, 413)
        Me.btnPrintBatchSheet.Name = "btnPrintBatchSheet"
        Me.btnPrintBatchSheet.Size = New System.Drawing.Size(104, 40)
        Me.btnPrintBatchSheet.TabIndex = 13
        Me.btnPrintBatchSheet.Text = "Save and &Print Batch Sheet"
        Me.btnPrintBatchSheet.UseVisualStyleBackColor = True
        '
        'bindingsourceBatches
        '
        '
        'bindingnavBatchItems
        '
        Me.bindingnavBatchItems.AddNewItem = Nothing
        Me.bindingnavBatchItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bindingnavBatchItems.BindingSource = Me.bindingsourceBatchItems
        Me.bindingnavBatchItems.CountItem = Me.BindingNavigatorCountItem1
        Me.bindingnavBatchItems.DeleteItem = Nothing
        Me.bindingnavBatchItems.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingnavBatchItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5})
        Me.bindingnavBatchItems.Location = New System.Drawing.Point(54, 276)
        Me.bindingnavBatchItems.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.bindingnavBatchItems.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.bindingnavBatchItems.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.bindingnavBatchItems.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.bindingnavBatchItems.Name = "bindingnavBatchItems"
        Me.bindingnavBatchItems.PositionItem = Me.BindingNavigatorPositionItem1
        Me.bindingnavBatchItems.Size = New System.Drawing.Size(209, 25)
        Me.bindingnavBatchItems.TabIndex = 2
        Me.bindingnavBatchItems.Text = "Batch Items"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Record:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvBatchItems)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.bindingnavBatchItems)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 304)
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
        Me.btnClose.Location = New System.Drawing.Point(592, 457)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 23)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Save and &Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(592, 484)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBatchCreate2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 514)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrintBatchSheet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInstrumentName)
        Me.Controls.Add(Me.btnCreateNewBatch)
        Me.Controls.Add(Me.txtBatchNotes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBatchNumber)
        Me.Controls.Add(Me.txtBatchID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBatchCreate2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receiving And Batching"
        CType(Me.dgvBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceStatusCodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingnavBatchItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingnavBatchItems.ResumeLayout(False)
        Me.bindingnavBatchItems.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBatchItems As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBatchID As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNotes As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateNewBatch As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInstrumentName As System.Windows.Forms.TextBox
    Friend WithEvents btnPrintBatchSheet As System.Windows.Forms.Button
    Friend WithEvents bindingsourceBatchItems As System.Windows.Forms.BindingSource
    Friend WithEvents bindingsourceBatches As System.Windows.Forms.BindingSource
    Friend WithEvents bindingnavBatchItems As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents bindingsourceStatusCodes As System.Windows.Forms.BindingSource
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ITCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Notes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
