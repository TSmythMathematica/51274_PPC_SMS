'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditLocatingStatusSupervisor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtNumTimes = New System.Windows.Forms.TextBox()
        Me.lblNumTimes = New System.Windows.Forms.Label()
        Me.txtTotTime = New System.Windows.Forms.TextBox()
        Me.lblLEAID = New System.Windows.Forms.Label()
        Me.grpLocating = New System.Windows.Forms.GroupBox()
        Me.lblStatusDate = New System.Windows.Forms.Label()
        Me.lblDateToLoc = New System.Windows.Forms.Label()
        Me.txtNumTouched = New System.Windows.Forms.TextBox()
        Me.lblTimesTouched = New System.Windows.Forms.Label()
        Me.lblStatusCode = New System.Windows.Forms.Label()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.txtDateSent = New System.Windows.Forms.TextBox()
        Me.txtStatusDate = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lnkStatus = New System.Windows.Forms.LinkLabel()
        Me.txtNumAttempts = New System.Windows.Forms.TextBox()
        Me.lblNumAttempts = New System.Windows.Forms.Label()
        Me.vwTime = New MPR.SMS.UserControls.ViewDataSet()
        Me.vwStatus = New MPR.SMS.UserControls.ViewDataSet()
        Me.grpLocating.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNumTimes
        '
        Me.txtNumTimes.Location = New System.Drawing.Point(129, 96)
        Me.txtNumTimes.MaxLength = 50
        Me.txtNumTimes.Name = "txtNumTimes"
        Me.txtNumTimes.ReadOnly = True
        Me.txtNumTimes.Size = New System.Drawing.Size(26, 20)
        Me.txtNumTimes.TabIndex = 7
        '
        'lblNumTimes
        '
        Me.lblNumTimes.AutoSize = True
        Me.lblNumTimes.Location = New System.Drawing.Point(7, 96)
        Me.lblNumTimes.Name = "lblNumTimes"
        Me.lblNumTimes.Size = New System.Drawing.Size(113, 13)
        Me.lblNumTimes.TabIndex = 6
        Me.lblNumTimes.Text = "Times sent to locating:"
        '
        'txtTotTime
        '
        Me.txtTotTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotTime.Location = New System.Drawing.Point(129, 122)
        Me.txtTotTime.MaximumSize = New System.Drawing.Size(100, 20)
        Me.txtTotTime.MaxLength = 10
        Me.txtTotTime.MinimumSize = New System.Drawing.Size(60, 20)
        Me.txtTotTime.Name = "txtTotTime"
        Me.txtTotTime.ReadOnly = True
        Me.txtTotTime.Size = New System.Drawing.Size(60, 20)
        Me.txtTotTime.TabIndex = 13
        '
        'lblLEAID
        '
        Me.lblLEAID.AutoSize = True
        Me.lblLEAID.Location = New System.Drawing.Point(7, 122)
        Me.lblLEAID.Name = "lblLEAID"
        Me.lblLEAID.Size = New System.Drawing.Size(116, 13)
        Me.lblLEAID.TabIndex = 12
        Me.lblLEAID.Text = "Total time (in seconds):"
        '
        'grpLocating
        '
        Me.grpLocating.Controls.Add(Me.vwTime)
        Me.grpLocating.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLocating.Location = New System.Drawing.Point(0, 0)
        Me.grpLocating.Name = "grpLocating"
        Me.grpLocating.Size = New System.Drawing.Size(381, 158)
        Me.grpLocating.TabIndex = 0
        Me.grpLocating.TabStop = False
        Me.grpLocating.Text = "Time spent:"
        '
        'lblStatusDate
        '
        Me.lblStatusDate.AutoSize = True
        Me.lblStatusDate.Location = New System.Drawing.Point(7, 44)
        Me.lblStatusDate.Name = "lblStatusDate"
        Me.lblStatusDate.Size = New System.Drawing.Size(64, 13)
        Me.lblStatusDate.TabIndex = 2
        Me.lblStatusDate.Text = "Status date:"
        '
        'lblDateToLoc
        '
        Me.lblDateToLoc.AutoSize = True
        Me.lblDateToLoc.Location = New System.Drawing.Point(6, 69)
        Me.lblDateToLoc.Name = "lblDateToLoc"
        Me.lblDateToLoc.Size = New System.Drawing.Size(108, 13)
        Me.lblDateToLoc.TabIndex = 4
        Me.lblDateToLoc.Text = "Date sent to locating:"
        '
        'txtNumTouched
        '
        Me.txtNumTouched.Location = New System.Drawing.Point(548, 96)
        Me.txtNumTouched.MaxLength = 50
        Me.txtNumTouched.Name = "txtNumTouched"
        Me.txtNumTouched.ReadOnly = True
        Me.txtNumTouched.Size = New System.Drawing.Size(26, 20)
        Me.txtNumTouched.TabIndex = 11
        Me.txtNumTouched.Visible = False
        '
        'lblTimesTouched
        '
        Me.lblTimesTouched.AutoSize = True
        Me.lblTimesTouched.Location = New System.Drawing.Point(462, 96)
        Me.lblTimesTouched.Name = "lblTimesTouched"
        Me.lblTimesTouched.Size = New System.Drawing.Size(80, 13)
        Me.lblTimesTouched.TabIndex = 10
        Me.lblTimesTouched.Text = "Times touched:"
        Me.lblTimesTouched.Visible = False
        '
        'lblStatusCode
        '
        Me.lblStatusCode.AutoSize = True
        Me.lblStatusCode.Location = New System.Drawing.Point(7, 17)
        Me.lblStatusCode.Name = "lblStatusCode"
        Me.lblStatusCode.Size = New System.Drawing.Size(67, 13)
        Me.lblStatusCode.TabIndex = 0
        Me.lblStatusCode.Text = "Status code:"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.vwStatus)
        Me.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpStatus.Location = New System.Drawing.Point(0, 0)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(202, 158)
        Me.grpStatus.TabIndex = 0
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status history:"
        '
        'txtDateSent
        '
        Me.txtDateSent.Location = New System.Drawing.Point(129, 70)
        Me.txtDateSent.Name = "txtDateSent"
        Me.txtDateSent.ReadOnly = True
        Me.txtDateSent.Size = New System.Drawing.Size(118, 20)
        Me.txtDateSent.TabIndex = 5
        '
        'txtStatusDate
        '
        Me.txtStatusDate.Location = New System.Drawing.Point(129, 44)
        Me.txtStatusDate.Name = "txtStatusDate"
        Me.txtStatusDate.ReadOnly = True
        Me.txtStatusDate.Size = New System.Drawing.Size(118, 20)
        Me.txtStatusDate.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 148)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpLocating)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpStatus)
        Me.SplitContainer1.Size = New System.Drawing.Size(587, 158)
        Me.SplitContainer1.SplitterDistance = 381
        Me.SplitContainer1.TabIndex = 14
        '
        'lnkStatus
        '
        Me.lnkStatus.AutoSize = True
        Me.lnkStatus.Location = New System.Drawing.Point(126, 17)
        Me.lnkStatus.Name = "lnkStatus"
        Me.lnkStatus.Size = New System.Drawing.Size(43, 13)
        Me.lnkStatus.TabIndex = 1
        Me.lnkStatus.TabStop = True
        Me.lnkStatus.Text = "<none>"
        '
        'txtNumAttempts
        '
        Me.txtNumAttempts.Location = New System.Drawing.Point(313, 96)
        Me.txtNumAttempts.MaxLength = 50
        Me.txtNumAttempts.Name = "txtNumAttempts"
        Me.txtNumAttempts.ReadOnly = True
        Me.txtNumAttempts.Size = New System.Drawing.Size(26, 20)
        Me.txtNumAttempts.TabIndex = 9
        '
        'lblNumAttempts
        '
        Me.lblNumAttempts.AutoSize = True
        Me.lblNumAttempts.Location = New System.Drawing.Point(239, 96)
        Me.lblNumAttempts.Name = "lblNumAttempts"
        Me.lblNumAttempts.Size = New System.Drawing.Size(73, 13)
        Me.lblNumAttempts.TabIndex = 8
        Me.lblNumAttempts.Text = "# of Attempts:"
        '
        'vwTime
        '
        Me.vwTime.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwTime.DataSource = Nothing
        Me.vwTime.DoubleClickColumn = 0
        Me.vwTime.Location = New System.Drawing.Point(6, 18)
        Me.vwTime.MultiSelect = True
        Me.vwTime.Name = "vwTime"
        Me.vwTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwTime.Size = New System.Drawing.Size(368, 132)
        Me.vwTime.SortedColumn = Nothing
        Me.vwTime.TabIndex = 0
        '
        'vwStatus
        '
        Me.vwStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwStatus.DataSource = Nothing
        Me.vwStatus.DoubleClickColumn = 0
        Me.vwStatus.Location = New System.Drawing.Point(6, 18)
        Me.vwStatus.MultiSelect = True
        Me.vwStatus.Name = "vwStatus"
        Me.vwStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwStatus.Size = New System.Drawing.Size(189, 132)
        Me.vwStatus.SortedColumn = Nothing
        Me.vwStatus.TabIndex = 0
        '
        'EditLocatingStatusSupervisor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtNumAttempts)
        Me.Controls.Add(Me.lblNumAttempts)
        Me.Controls.Add(Me.lnkStatus)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblStatusCode)
        Me.Controls.Add(Me.txtTotTime)
        Me.Controls.Add(Me.txtNumTouched)
        Me.Controls.Add(Me.lblTimesTouched)
        Me.Controls.Add(Me.txtDateSent)
        Me.Controls.Add(Me.lblDateToLoc)
        Me.Controls.Add(Me.lblStatusDate)
        Me.Controls.Add(Me.txtStatusDate)
        Me.Controls.Add(Me.txtNumTimes)
        Me.Controls.Add(Me.lblNumTimes)
        Me.Controls.Add(Me.lblLEAID)
        Me.Name = "EditLocatingStatusSupervisor"
        Me.Size = New System.Drawing.Size(593, 309)
        Me.grpLocating.ResumeLayout(False)
        Me.grpStatus.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLEAID As System.Windows.Forms.Label
    Friend WithEvents txtTotTime As System.Windows.Forms.TextBox
    Friend WithEvents txtNumTimes As System.Windows.Forms.TextBox
    Friend WithEvents lblNumTimes As System.Windows.Forms.Label
    Friend WithEvents grpLocating As System.Windows.Forms.GroupBox
    Friend WithEvents vwTime As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents txtStatusDate As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusDate As System.Windows.Forms.Label
    Friend WithEvents txtDateSent As System.Windows.Forms.TextBox
    Friend WithEvents lblDateToLoc As System.Windows.Forms.Label
    Friend WithEvents txtNumTouched As System.Windows.Forms.TextBox
    Friend WithEvents lblTimesTouched As System.Windows.Forms.Label
    Friend WithEvents lblStatusCode As System.Windows.Forms.Label
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents vwStatus As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lnkStatus As System.Windows.Forms.LinkLabel
    Friend WithEvents txtNumAttempts As System.Windows.Forms.TextBox
    Friend WithEvents lblNumAttempts As System.Windows.Forms.Label

End Class
