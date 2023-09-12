'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocatingSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocatingSelection))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpCase = New System.Windows.Forms.GroupBox()
        Me.txtMPRID = New System.Windows.Forms.TextBox()
        Me.optMPRID = New System.Windows.Forms.RadioButton()
        Me.optNewest = New System.Windows.Forms.RadioButton()
        Me.optOldest = New System.Windows.Forms.RadioButton()
        Me.btnGetCase = New System.Windows.Forms.Button()
        Me.btnDetails = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.grpCounts = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNumTot = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumSup = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumLoc = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vwLocatingSelection = New MPR.SMS.UserControls.ViewDataSet()
        Me.grpTZ = New System.Windows.Forms.GroupBox()
        Me.chkEST = New System.Windows.Forms.CheckBox()
        Me.chkCST = New System.Windows.Forms.CheckBox()
        Me.chkMST = New System.Windows.Forms.CheckBox()
        Me.chkPST = New System.Windows.Forms.CheckBox()
        Me.chkOther = New System.Windows.Forms.CheckBox()
        Me.grpCase.SuspendLayout()
        Me.grpCounts.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpTZ.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(638, 509)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'grpCase
        '
        Me.grpCase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpCase.Controls.Add(Me.txtMPRID)
        Me.grpCase.Controls.Add(Me.optMPRID)
        Me.grpCase.Controls.Add(Me.optNewest)
        Me.grpCase.Controls.Add(Me.optOldest)
        Me.grpCase.Location = New System.Drawing.Point(13, 403)
        Me.grpCase.Name = "grpCase"
        Me.grpCase.Size = New System.Drawing.Size(145, 97)
        Me.grpCase.TabIndex = 1
        Me.grpCase.TabStop = False
        Me.grpCase.Text = "Get"
        '
        'txtMPRID
        '
        Me.txtMPRID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMPRID.Enabled = False
        Me.txtMPRID.Location = New System.Drawing.Point(77, 66)
        Me.txtMPRID.MaxLength = 8
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.Size = New System.Drawing.Size(57, 20)
        Me.txtMPRID.TabIndex = 3
        '
        'optMPRID
        '
        Me.optMPRID.AutoSize = True
        Me.optMPRID.Location = New System.Drawing.Point(7, 66)
        Me.optMPRID.Name = "optMPRID"
        Me.optMPRID.Size = New System.Drawing.Size(63, 17)
        Me.optMPRID.TabIndex = 2
        Me.optMPRID.Text = "&MPRID:"
        Me.optMPRID.UseVisualStyleBackColor = True
        '
        'optNewest
        '
        Me.optNewest.AutoSize = True
        Me.optNewest.Location = New System.Drawing.Point(7, 43)
        Me.optNewest.Name = "optNewest"
        Me.optNewest.Size = New System.Drawing.Size(61, 17)
        Me.optNewest.TabIndex = 1
        Me.optNewest.Text = "&Newest"
        Me.optNewest.UseVisualStyleBackColor = True
        '
        'optOldest
        '
        Me.optOldest.AutoSize = True
        Me.optOldest.Checked = True
        Me.optOldest.Location = New System.Drawing.Point(7, 20)
        Me.optOldest.Name = "optOldest"
        Me.optOldest.Size = New System.Drawing.Size(55, 17)
        Me.optOldest.TabIndex = 0
        Me.optOldest.TabStop = True
        Me.optOldest.Text = "O&ldest"
        Me.optOldest.UseVisualStyleBackColor = True
        '
        'btnGetCase
        '
        Me.btnGetCase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGetCase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetCase.Location = New System.Drawing.Point(20, 509)
        Me.btnGetCase.Name = "btnGetCase"
        Me.btnGetCase.Size = New System.Drawing.Size(127, 32)
        Me.btnGetCase.TabIndex = 6
        Me.btnGetCase.Text = "&Open Case"
        Me.btnGetCase.UseVisualStyleBackColor = False
        '
        'btnDetails
        '
        Me.btnDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetails.Location = New System.Drawing.Point(638, 452)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(75, 32)
        Me.btnDetails.TabIndex = 5
        Me.btnDetails.Text = "&Details"
        Me.btnDetails.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(638, 415)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 32)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'grpCounts
        '
        Me.grpCounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCounts.Controls.Add(Me.TableLayoutPanel1)
        Me.grpCounts.Location = New System.Drawing.Point(339, 403)
        Me.grpCounts.Name = "grpCounts"
        Me.grpCounts.Size = New System.Drawing.Size(282, 97)
        Me.grpCounts.TabIndex = 3
        Me.grpCounts.TabStop = False
        Me.grpCounts.Text = "Counts"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumTot, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumSup, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumLoc, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(276, 78)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblNumTot
        '
        Me.lblNumTot.AutoSize = True
        Me.lblNumTot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNumTot.Location = New System.Drawing.Point(223, 51)
        Me.lblNumTot.Name = "lblNumTot"
        Me.lblNumTot.Size = New System.Drawing.Size(49, 26)
        Me.lblNumTot.TabIndex = 5
        Me.lblNumTot.Text = "0"
        Me.lblNumTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumSup
        '
        Me.lblNumSup.AutoSize = True
        Me.lblNumSup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNumSup.ForeColor = System.Drawing.Color.Blue
        Me.lblNumSup.Location = New System.Drawing.Point(223, 26)
        Me.lblNumSup.Name = "lblNumSup"
        Me.lblNumSup.Size = New System.Drawing.Size(49, 24)
        Me.lblNumSup.TabIndex = 3
        Me.lblNumSup.Text = "0"
        Me.lblNumSup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(4, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "# available to supervisors:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumLoc
        '
        Me.lblNumLoc.AutoSize = True
        Me.lblNumLoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNumLoc.Location = New System.Drawing.Point(223, 1)
        Me.lblNumLoc.Name = "lblNumLoc"
        Me.lblNumLoc.Size = New System.Drawing.Size(49, 24)
        Me.lblNumLoc.TabIndex = 1
        Me.lblNumLoc.Text = "0"
        Me.lblNumLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "# available to locators:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'vwLocatingSelection
        '
        Me.vwLocatingSelection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwLocatingSelection.DataSource = Nothing
        Me.vwLocatingSelection.DoubleClickColumn = 0
        Me.vwLocatingSelection.Location = New System.Drawing.Point(13, 13)
        Me.vwLocatingSelection.MultiSelect = True
        Me.vwLocatingSelection.Name = "vwLocatingSelection"
        Me.vwLocatingSelection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.vwLocatingSelection.Size = New System.Drawing.Size(700, 384)
        Me.vwLocatingSelection.SortedColumn = Nothing
        Me.vwLocatingSelection.TabIndex = 0
        '
        'grpTZ
        '
        Me.grpTZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpTZ.Controls.Add(Me.chkOther)
        Me.grpTZ.Controls.Add(Me.chkPST)
        Me.grpTZ.Controls.Add(Me.chkMST)
        Me.grpTZ.Controls.Add(Me.chkCST)
        Me.grpTZ.Controls.Add(Me.chkEST)
        Me.grpTZ.Location = New System.Drawing.Point(165, 403)
        Me.grpTZ.Name = "grpTZ"
        Me.grpTZ.Size = New System.Drawing.Size(168, 97)
        Me.grpTZ.TabIndex = 2
        Me.grpTZ.TabStop = False
        Me.grpTZ.Text = "Included Timezones"
        '
        'chkEST
        '
        Me.chkEST.AutoSize = True
        Me.chkEST.Checked = True
        Me.chkEST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEST.Location = New System.Drawing.Point(7, 20)
        Me.chkEST.Name = "chkEST"
        Me.chkEST.Size = New System.Drawing.Size(47, 17)
        Me.chkEST.TabIndex = 0
        Me.chkEST.Text = "EST"
        Me.chkEST.UseVisualStyleBackColor = True
        '
        'chkCST
        '
        Me.chkCST.AutoSize = True
        Me.chkCST.Checked = True
        Me.chkCST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCST.Location = New System.Drawing.Point(7, 44)
        Me.chkCST.Name = "chkCST"
        Me.chkCST.Size = New System.Drawing.Size(47, 17)
        Me.chkCST.TabIndex = 1
        Me.chkCST.Text = "CST"
        Me.chkCST.UseVisualStyleBackColor = True
        '
        'chkMST
        '
        Me.chkMST.AutoSize = True
        Me.chkMST.Checked = True
        Me.chkMST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMST.Location = New System.Drawing.Point(109, 21)
        Me.chkMST.Name = "chkMST"
        Me.chkMST.Size = New System.Drawing.Size(49, 17)
        Me.chkMST.TabIndex = 2
        Me.chkMST.Text = "MST"
        Me.chkMST.UseVisualStyleBackColor = True
        '
        'chkPST
        '
        Me.chkPST.AutoSize = True
        Me.chkPST.Checked = True
        Me.chkPST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPST.Location = New System.Drawing.Point(109, 42)
        Me.chkPST.Name = "chkPST"
        Me.chkPST.Size = New System.Drawing.Size(47, 17)
        Me.chkPST.TabIndex = 3
        Me.chkPST.Text = "PST"
        Me.chkPST.UseVisualStyleBackColor = True
        '
        'chkOther
        '
        Me.chkOther.AutoSize = True
        Me.chkOther.Checked = True
        Me.chkOther.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOther.Location = New System.Drawing.Point(7, 69)
        Me.chkOther.Name = "chkOther"
        Me.chkOther.Size = New System.Drawing.Size(144, 17)
        Me.chkOther.TabIndex = 4
        Me.chkOther.Text = "Missing or invalid phones"
        Me.chkOther.UseVisualStyleBackColor = True
        '
        'frmLocatingSelection
        '
        Me.AcceptButton = Me.btnGetCase
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(725, 553)
        Me.Controls.Add(Me.grpTZ)
        Me.Controls.Add(Me.grpCounts)
        Me.Controls.Add(Me.btnGetCase)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.grpCase)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.vwLocatingSelection)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocatingSelection"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Locating: Select Case"
        Me.grpCase.ResumeLayout(False)
        Me.grpCase.PerformLayout()
        Me.grpCounts.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grpTZ.ResumeLayout(False)
        Me.grpTZ.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents vwLocatingSelection As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpCase As System.Windows.Forms.GroupBox
    Friend WithEvents btnDetails As System.Windows.Forms.Button
    Friend WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents optMPRID As System.Windows.Forms.RadioButton
    Friend WithEvents optNewest As System.Windows.Forms.RadioButton
    Friend WithEvents optOldest As System.Windows.Forms.RadioButton
    Friend WithEvents btnGetCase As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents grpCounts As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNumTot As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumSup As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumLoc As System.Windows.Forms.Label
    Friend WithEvents grpTZ As System.Windows.Forms.GroupBox
    Friend WithEvents chkPST As System.Windows.Forms.CheckBox
    Friend WithEvents chkMST As System.Windows.Forms.CheckBox
    Friend WithEvents chkCST As System.Windows.Forms.CheckBox
    Friend WithEvents chkEST As System.Windows.Forms.CheckBox
    Friend WithEvents chkOther As System.Windows.Forms.CheckBox
End Class
