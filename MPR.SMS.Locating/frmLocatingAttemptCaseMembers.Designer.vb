'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocatingAttemptCaseMembers
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocatingAttemptCaseMembers))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.tabLoc = New System.Windows.Forms.TabControl()
        Me.tabMembers = New System.Windows.Forms.TabPage()
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers()
        Me.tabNotes = New System.Windows.Forms.TabPage()
        Me.ViewCaseNotes = New MPR.SMS.UserControls.ViewCaseNotes()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EditLocatingAttempt = New MPR.SMS.UserControls.EditLocatingAttempt()
        Me.EditLocatingStatus = New MPR.SMS.UserControls.EditLocatingStatus()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.tabLoc.SuspendLayout()
        Me.tabMembers.SuspendLayout()
        Me.tabNotes.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(592, 389)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(511, 389)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        '
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.Location = New System.Drawing.Point(-4, 1)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.tabLoc)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer3.Size = New System.Drawing.Size(686, 382)
        Me.SplitContainer3.SplitterDistance = 204
        Me.SplitContainer3.TabIndex = 4
        '
        'tabLoc
        '
        Me.tabLoc.Controls.Add(Me.tabMembers)
        Me.tabLoc.Controls.Add(Me.tabNotes)
        Me.tabLoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabLoc.Location = New System.Drawing.Point(0, 0)
        Me.tabLoc.Name = "tabLoc"
        Me.tabLoc.SelectedIndex = 0
        Me.tabLoc.Size = New System.Drawing.Size(686, 204)
        Me.tabLoc.TabIndex = 5
        '
        'tabMembers
        '
        Me.tabMembers.Controls.Add(Me.ViewCaseMembers)
        Me.tabMembers.Location = New System.Drawing.Point(4, 22)
        Me.tabMembers.Name = "tabMembers"
        Me.tabMembers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMembers.Size = New System.Drawing.Size(678, 178)
        Me.tabMembers.TabIndex = 0
        Me.tabMembers.Text = "Members"
        Me.tabMembers.UseVisualStyleBackColor = True
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(3, 3)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.Size = New System.Drawing.Size(672, 172)
        Me.ViewCaseMembers.TabIndex = 1
        '
        'tabNotes
        '
        Me.tabNotes.Controls.Add(Me.ViewCaseNotes)
        Me.tabNotes.Location = New System.Drawing.Point(4, 22)
        Me.tabNotes.Name = "tabNotes"
        Me.tabNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNotes.Size = New System.Drawing.Size(678, 178)
        Me.tabNotes.TabIndex = 1
        Me.tabNotes.Text = "Notes"
        Me.tabNotes.UseVisualStyleBackColor = True
        '
        'ViewCaseNotes
        '
        Me.ViewCaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseNotes.Location = New System.Drawing.Point(3, 3)
        Me.ViewCaseNotes.Name = "ViewCaseNotes"
        Me.ViewCaseNotes.SelectedCase = Nothing
        Me.ViewCaseNotes.SelectedNote = Nothing
        Me.ViewCaseNotes.Size = New System.Drawing.Size(672, 172)
        Me.ViewCaseNotes.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EditLocatingAttempt)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EditLocatingStatus)
        Me.SplitContainer1.Size = New System.Drawing.Size(686, 174)
        Me.SplitContainer1.SplitterDistance = 309
        Me.SplitContainer1.TabIndex = 0
        '
        'EditLocatingAttempt
        '
        Me.EditLocatingAttempt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditLocatingAttempt.LocatingAttempt = Nothing
        Me.EditLocatingAttempt.Location = New System.Drawing.Point(0, 0)
        Me.EditLocatingAttempt.Name = "EditLocatingAttempt"
        Me.EditLocatingAttempt.Size = New System.Drawing.Size(309, 174)
        Me.EditLocatingAttempt.TabIndex = 0
        '
        'EditLocatingStatus
        '
        Me.EditLocatingStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditLocatingStatus.LocatingStatus = Nothing
        Me.EditLocatingStatus.Location = New System.Drawing.Point(0, 0)
        Me.EditLocatingStatus.Name = "EditLocatingStatus"
        Me.EditLocatingStatus.Size = New System.Drawing.Size(373, 174)
        Me.EditLocatingStatus.TabIndex = 0
        '
        'frmLocatingAttemptCaseMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 424)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocatingAttemptCaseMembers"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Locating Attempt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.tabLoc.ResumeLayout(False)
        Me.tabMembers.ResumeLayout(False)
        Me.tabNotes.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EditLocatingAttempt As MPR.SMS.UserControls.EditLocatingAttempt
    Friend WithEvents EditLocatingStatus As MPR.SMS.UserControls.EditLocatingStatus
    Friend WithEvents tabLoc As System.Windows.Forms.TabControl
    Friend WithEvents tabMembers As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents tabNotes As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseNotes As MPR.SMS.UserControls.ViewCaseNotes
End Class
