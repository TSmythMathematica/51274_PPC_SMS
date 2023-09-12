'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocuments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocuments))
        Me.grdView = New System.Windows.Forms.DataGridView
        Me.DocumentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstrumentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Instrument = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPRID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PersonHistoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Person = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddressHistoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DocNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnClose = New System.Windows.Forms.Button
        Me.cboDocStatus = New System.Windows.Forms.ComboBox
        Me.lblDocStatus = New System.Windows.Forms.Label
        Me.lblDocs = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdView
        '
        Me.grdView.AllowUserToAddRows = False
        Me.grdView.AllowUserToDeleteRows = False
        Me.grdView.AllowUserToOrderColumns = True
        Me.grdView.AllowUserToResizeRows = False
        Me.grdView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DocumentID, Me.Type, Me.Status, Me.StatusDate, Me.InstrumentID, Me.Instrument, Me.MPRID, Me.PersonHistoryID, Me.Person, Me.AddressHistoryID, Me.Address, Me.DocNum, Me.Round})
        Me.grdView.Location = New System.Drawing.Point(12, 64)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        Me.grdView.RowHeadersVisible = False
        Me.grdView.RowTemplate.Height = 17
        Me.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdView.Size = New System.Drawing.Size(620, 308)
        Me.grdView.TabIndex = 4
        '
        'DocumentID
        '
        Me.DocumentID.HeaderText = "DocumentID"
        Me.DocumentID.Name = "DocumentID"
        Me.DocumentID.ReadOnly = True
        Me.DocumentID.Visible = False
        Me.DocumentID.Width = 70
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Type.ToolTipText = "Document Type"
        Me.Type.Width = 140
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.ToolTipText = "Document's current status"
        '
        'StatusDate
        '
        Me.StatusDate.HeaderText = "Status Date"
        Me.StatusDate.Name = "StatusDate"
        Me.StatusDate.ReadOnly = True
        '
        'InstrumentID
        '
        Me.InstrumentID.HeaderText = "InstrumentID"
        Me.InstrumentID.Name = "InstrumentID"
        Me.InstrumentID.ReadOnly = True
        Me.InstrumentID.Visible = False
        '
        'Instrument
        '
        Me.Instrument.HeaderText = "Instrument"
        Me.Instrument.Name = "Instrument"
        Me.Instrument.ReadOnly = True
        Me.Instrument.ToolTipText = "Instrument (if applicable)"
        Me.Instrument.Visible = False
        Me.Instrument.Width = 160
        '
        'MPRID
        '
        Me.MPRID.HeaderText = "MPRID"
        Me.MPRID.Name = "MPRID"
        Me.MPRID.ReadOnly = True
        '
        'PersonHistoryID
        '
        Me.PersonHistoryID.HeaderText = "PersonHistoryID"
        Me.PersonHistoryID.Name = "PersonHistoryID"
        Me.PersonHistoryID.ReadOnly = True
        Me.PersonHistoryID.Visible = False
        '
        'Person
        '
        Me.Person.HeaderText = "Person"
        Me.Person.Name = "Person"
        Me.Person.ReadOnly = True
        Me.Person.ToolTipText = "Person (if applicable)"
        Me.Person.Width = 160
        '
        'AddressHistoryID
        '
        Me.AddressHistoryID.HeaderText = "AddressHistoryID"
        Me.AddressHistoryID.Name = "AddressHistoryID"
        Me.AddressHistoryID.ReadOnly = True
        Me.AddressHistoryID.Visible = False
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.ToolTipText = "Address (if applicable)"
        Me.Address.Width = 160
        '
        'DocNum
        '
        Me.DocNum.HeaderText = "#"
        Me.DocNum.Name = "DocNum"
        Me.DocNum.ReadOnly = True
        Me.DocNum.ToolTipText = "Document # (of this type)"
        Me.DocNum.Width = 50
        '
        'Round
        '
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = True
        Me.Round.ToolTipText = "Round when data was last changed"
        Me.Round.Width = 50
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(557, 378)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboDocStatus
        '
        Me.cboDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocStatus.FormattingEnabled = True
        Me.cboDocStatus.Location = New System.Drawing.Point(172, 12)
        Me.cboDocStatus.Name = "cboDocStatus"
        Me.cboDocStatus.Size = New System.Drawing.Size(171, 21)
        Me.cboDocStatus.TabIndex = 1
        '
        'lblDocStatus
        '
        Me.lblDocStatus.AutoSize = True
        Me.lblDocStatus.Location = New System.Drawing.Point(12, 12)
        Me.lblDocStatus.Name = "lblDocStatus"
        Me.lblDocStatus.Size = New System.Drawing.Size(154, 13)
        Me.lblDocStatus.TabIndex = 0
        Me.lblDocStatus.Text = "Show documents of this status:"
        '
        'lblDocs
        '
        Me.lblDocs.AutoSize = True
        Me.lblDocs.Location = New System.Drawing.Point(12, 48)
        Me.lblDocs.Name = "lblDocs"
        Me.lblDocs.Size = New System.Drawing.Size(64, 13)
        Me.lblDocs.TabIndex = 2
        Me.lblDocs.Text = "Documents:"
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChange.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChange.Location = New System.Drawing.Point(438, 378)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(102, 23)
        Me.btnChange.TabIndex = 5
        Me.btnChange.Text = "Hold / Cancel"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Location = New System.Drawing.Point(536, 48)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(96, 13)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "Count = 0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 411)
        Me.Controls.Add(Me.grdView)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.lblDocs)
        Me.Controls.Add(Me.lblDocStatus)
        Me.Controls.Add(Me.cboDocStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDocuments"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Queue"
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocStatus As System.Windows.Forms.Label
    Friend WithEvents DocumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstrumentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Instrument As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonHistoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Person As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressHistoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDocs As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
End Class
