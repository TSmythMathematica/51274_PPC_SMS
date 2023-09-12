'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBatchReceive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBatchReceive))
        Me.dgvBatches = New System.Windows.Forms.DataGridView
        Me.PublicBatchID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsReceived = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.bindingsourceBatches = New System.Windows.Forms.BindingSource(Me.components)
        Me.bindingnavBatches = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtInstrumentName = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingnavBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingnavBatches.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBatches
        '
        Me.dgvBatches.AllowUserToAddRows = False
        Me.dgvBatches.AllowUserToDeleteRows = False
        Me.dgvBatches.AllowUserToResizeColumns = False
        Me.dgvBatches.AllowUserToResizeRows = False
        Me.dgvBatches.AutoGenerateColumns = False
        Me.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatches.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PublicBatchID, Me.BatchNumber, Me.IsReceived})
        Me.dgvBatches.DataSource = Me.bindingsourceBatches
        Me.dgvBatches.Location = New System.Drawing.Point(21, 45)
        Me.dgvBatches.Name = "dgvBatches"
        Me.dgvBatches.Size = New System.Drawing.Size(344, 274)
        Me.dgvBatches.TabIndex = 2
        '
        'PublicBatchID
        '
        Me.PublicBatchID.DataPropertyName = "PublicBatchID"
        Me.PublicBatchID.HeaderText = "BatchID"
        Me.PublicBatchID.Name = "PublicBatchID"
        Me.PublicBatchID.ReadOnly = True
        '
        'BatchNumber
        '
        Me.BatchNumber.DataPropertyName = "BatchNumber"
        Me.BatchNumber.HeaderText = "BatchNumber"
        Me.BatchNumber.Name = "BatchNumber"
        Me.BatchNumber.ReadOnly = True
        '
        'IsReceived
        '
        Me.IsReceived.DataPropertyName = "IsReceived"
        Me.IsReceived.HeaderText = "Received"
        Me.IsReceived.Name = "IsReceived"
        '
        'bindingnavBatches
        '
        Me.bindingnavBatches.AddNewItem = Nothing
        Me.bindingnavBatches.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bindingnavBatches.BindingSource = Me.bindingsourceBatches
        Me.bindingnavBatches.CountItem = Me.BindingNavigatorCountItem
        Me.bindingnavBatches.DeleteItem = Nothing
        Me.bindingnavBatches.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingnavBatches.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bindingnavBatches.Location = New System.Drawing.Point(74, 322)
        Me.bindingnavBatches.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingnavBatches.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingnavBatches.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingnavBatches.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingnavBatches.Name = "bindingnavBatches"
        Me.bindingnavBatches.PositionItem = Me.BindingNavigatorPositionItem
        Me.bindingnavBatches.Size = New System.Drawing.Size(208, 25)
        Me.bindingnavBatches.TabIndex = 4
        Me.bindingnavBatches.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 326)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Record:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Instrument:"
        '
        'txtInstrumentName
        '
        Me.txtInstrumentName.Location = New System.Drawing.Point(91, 12)
        Me.txtInstrumentName.Name = "txtInstrumentName"
        Me.txtInstrumentName.ReadOnly = True
        Me.txtInstrumentName.Size = New System.Drawing.Size(274, 20)
        Me.txtInstrumentName.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(378, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmBatchReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 356)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtInstrumentName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bindingnavBatches)
        Me.Controls.Add(Me.dgvBatches)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBatchReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receiving Batches"
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceBatches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingnavBatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingnavBatches.ResumeLayout(False)
        Me.bindingnavBatches.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBatches As System.Windows.Forms.DataGridView
    Friend WithEvents bindingsourceBatches As System.Windows.Forms.BindingSource
    Friend WithEvents bindingnavBatches As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInstrumentName As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PublicBatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsReceived As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
