'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocatingAttempt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocatingAttempt))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tsToolbar = New System.Windows.Forms.ToolStrip()
        Me.lblURL = New System.Windows.Forms.ToolStripLabel()
        Me.cboURL = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFavorites = New System.Windows.Forms.ToolStripButton()
        Me.btnExpand = New System.Windows.Forms.ToolStripButton()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.tabCase = New System.Windows.Forms.TabControl()
        Me.tabPerson = New System.Windows.Forms.TabPage()
        Me.EditPerson = New MPR.SMS.UserControls.EditPerson()
        Me.tabAddress = New System.Windows.Forms.TabPage()
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses()
        Me.tabPhone = New System.Windows.Forms.TabPage()
        Me.ViewCasePhones = New MPR.SMS.UserControls.ViewCasePhones()
        Me.tabEmail = New System.Windows.Forms.TabPage()
        Me.ViewCaseEmails = New MPR.SMS.UserControls.ViewCaseEmails()
        Me.tabSN = New System.Windows.Forms.TabPage()
        Me.ViewCaseSocialNetworks = New MPR.SMS.UserControls.ViewCaseSocialNetworks()
        Me.tabNotes = New System.Windows.Forms.TabPage()
        Me.ViewCaseNotes = New MPR.SMS.UserControls.ViewCaseNotes()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EditLocatingAttempt = New MPR.SMS.UserControls.EditLocatingAttempt()
        Me.EditLocatingStatus = New MPR.SMS.UserControls.EditLocatingStatus()
        Me.imlShowHide = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tsToolbar.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.tabCase.SuspendLayout()
        Me.tabPerson.SuspendLayout()
        Me.tabAddress.SuspendLayout()
        Me.tabPhone.SuspendLayout()
        Me.tabEmail.SuspendLayout()
        Me.tabSN.SuspendLayout()
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
        Me.btnCancel.Location = New System.Drawing.Point(588, 596)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(507, 596)
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
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(2, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tsToolbar)
        Me.SplitContainer2.Panel1.Controls.Add(Me.WebBrowser)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(673, 587)
        Me.SplitContainer2.SplitterDistance = 157
        Me.SplitContainer2.TabIndex = 5
        '
        'tsToolbar
        '
        Me.tsToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblURL, Me.cboURL, Me.ToolStripSeparator1, Me.btnFavorites, Me.btnExpand})
        Me.tsToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tsToolbar.Name = "tsToolbar"
        Me.tsToolbar.Size = New System.Drawing.Size(673, 25)
        Me.tsToolbar.TabIndex = 11
        Me.tsToolbar.Text = "ToolStrip1"
        '
        'lblURL
        '
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(49, 22)
        Me.lblURL.Text = "A&ddress"
        '
        'cboURL
        '
        Me.cboURL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboURL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl
        Me.cboURL.Name = "cboURL"
        Me.cboURL.Size = New System.Drawing.Size(420, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFavorites
        '
        Me.btnFavorites.Image = CType(resources.GetObject("btnFavorites.Image"), System.Drawing.Image)
        Me.btnFavorites.ImageTransparentColor = System.Drawing.Color.Silver
        Me.btnFavorites.Name = "btnFavorites"
        Me.btnFavorites.Size = New System.Drawing.Size(74, 22)
        Me.btnFavorites.Text = "Favorites"
        '
        'btnExpand
        '
        Me.btnExpand.Image = CType(resources.GetObject("btnExpand.Image"), System.Drawing.Image)
        Me.btnExpand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(65, 22)
        Me.btnExpand.Text = "Expand"
        Me.btnExpand.ToolTipText = "Expand/shrink the size of the browser window"
        '
        'WebBrowser
        '
        Me.WebBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser.Location = New System.Drawing.Point(0, 28)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.ScriptErrorsSuppressed = True
        Me.WebBrowser.Size = New System.Drawing.Size(673, 127)
        Me.WebBrowser.TabIndex = 10
        Me.WebBrowser.Url = New System.Uri("http://www.google.com", System.UriKind.Absolute)
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.tabCase)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer3.Size = New System.Drawing.Size(673, 426)
        Me.SplitContainer3.SplitterDistance = 167
        Me.SplitContainer3.TabIndex = 0
        '
        'tabCase
        '
        Me.tabCase.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabCase.Controls.Add(Me.tabPerson)
        Me.tabCase.Controls.Add(Me.tabAddress)
        Me.tabCase.Controls.Add(Me.tabPhone)
        Me.tabCase.Controls.Add(Me.tabEmail)
        Me.tabCase.Controls.Add(Me.tabSN)
        Me.tabCase.Controls.Add(Me.tabNotes)
        Me.tabCase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCase.Location = New System.Drawing.Point(0, 0)
        Me.tabCase.Multiline = True
        Me.tabCase.Name = "tabCase"
        Me.tabCase.SelectedIndex = 0
        Me.tabCase.Size = New System.Drawing.Size(673, 167)
        Me.tabCase.TabIndex = 0
        '
        'tabPerson
        '
        Me.tabPerson.BackColor = System.Drawing.SystemColors.Control
        Me.tabPerson.Controls.Add(Me.EditPerson)
        Me.tabPerson.Location = New System.Drawing.Point(4, 25)
        Me.tabPerson.Name = "tabPerson"
        Me.tabPerson.Size = New System.Drawing.Size(665, 138)
        Me.tabPerson.TabIndex = 3
        Me.tabPerson.Text = "Name"
        '
        'EditPerson
        '
        Me.EditPerson.BackColor = System.Drawing.SystemColors.Control
        Me.EditPerson.Dock = System.Windows.Forms.DockStyle.Top
        Me.EditPerson.Location = New System.Drawing.Point(0, 0)
        Me.EditPerson.Name = "EditPerson"
        Me.EditPerson.Person = Nothing
        Me.EditPerson.Size = New System.Drawing.Size(665, 119)
        Me.EditPerson.TabIndex = 0
        '
        'tabAddress
        '
        Me.tabAddress.BackColor = System.Drawing.SystemColors.Control
        Me.tabAddress.Controls.Add(Me.ViewCaseAddresses)
        Me.tabAddress.Location = New System.Drawing.Point(4, 25)
        Me.tabAddress.Name = "tabAddress"
        Me.tabAddress.Size = New System.Drawing.Size(665, 177)
        Me.tabAddress.TabIndex = 0
        Me.tabAddress.Text = "Addresses"
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(665, 177)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'tabPhone
        '
        Me.tabPhone.BackColor = System.Drawing.SystemColors.Control
        Me.tabPhone.Controls.Add(Me.ViewCasePhones)
        Me.tabPhone.Location = New System.Drawing.Point(4, 25)
        Me.tabPhone.Name = "tabPhone"
        Me.tabPhone.Size = New System.Drawing.Size(665, 177)
        Me.tabPhone.TabIndex = 1
        Me.tabPhone.Text = "Phones"
        '
        'ViewCasePhones
        '
        Me.ViewCasePhones.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCasePhones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCasePhones.Location = New System.Drawing.Point(0, 0)
        Me.ViewCasePhones.Name = "ViewCasePhones"
        Me.ViewCasePhones.SelectedCase = Nothing
        Me.ViewCasePhones.SelectedPerson = Nothing
        Me.ViewCasePhones.SelectedPhone = Nothing
        Me.ViewCasePhones.Size = New System.Drawing.Size(665, 177)
        Me.ViewCasePhones.TabIndex = 0
        '
        'tabEmail
        '
        Me.tabEmail.BackColor = System.Drawing.SystemColors.Control
        Me.tabEmail.Controls.Add(Me.ViewCaseEmails)
        Me.tabEmail.Location = New System.Drawing.Point(4, 25)
        Me.tabEmail.Name = "tabEmail"
        Me.tabEmail.Size = New System.Drawing.Size(665, 177)
        Me.tabEmail.TabIndex = 2
        Me.tabEmail.Text = "Emails"
        '
        'ViewCaseEmails
        '
        Me.ViewCaseEmails.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCaseEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseEmails.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseEmails.Name = "ViewCaseEmails"
        Me.ViewCaseEmails.SelectedCase = Nothing
        Me.ViewCaseEmails.SelectedEmail = Nothing
        Me.ViewCaseEmails.SelectedPerson = Nothing
        Me.ViewCaseEmails.Size = New System.Drawing.Size(665, 177)
        Me.ViewCaseEmails.TabIndex = 0
        '
        'tabSN
        '
        Me.tabSN.Controls.Add(Me.ViewCaseSocialNetworks)
        Me.tabSN.Location = New System.Drawing.Point(4, 25)
        Me.tabSN.Name = "tabSN"
        Me.tabSN.Size = New System.Drawing.Size(665, 177)
        Me.tabSN.TabIndex = 5
        Me.tabSN.Text = "Social Networks"
        Me.tabSN.UseVisualStyleBackColor = True
        '
        'ViewCaseSocialNetworks
        '
        Me.ViewCaseSocialNetworks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseSocialNetworks.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseSocialNetworks.Name = "ViewCaseSocialNetworks"
        Me.ViewCaseSocialNetworks.SelectedCase = Nothing
        Me.ViewCaseSocialNetworks.SelectedPerson = Nothing
        Me.ViewCaseSocialNetworks.SelectedSocialNetwork = Nothing
        Me.ViewCaseSocialNetworks.Size = New System.Drawing.Size(665, 177)
        Me.ViewCaseSocialNetworks.TabIndex = 0
        '
        'tabNotes
        '
        Me.tabNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tabNotes.Controls.Add(Me.ViewCaseNotes)
        Me.tabNotes.Location = New System.Drawing.Point(4, 25)
        Me.tabNotes.Name = "tabNotes"
        Me.tabNotes.Size = New System.Drawing.Size(665, 177)
        Me.tabNotes.TabIndex = 4
        Me.tabNotes.Text = "Notes"
        '
        'ViewCaseNotes
        '
        Me.ViewCaseNotes.BackColor = System.Drawing.SystemColors.Control
        Me.ViewCaseNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseNotes.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseNotes.Name = "ViewCaseNotes"
        Me.ViewCaseNotes.SelectedCase = Nothing
        Me.ViewCaseNotes.SelectedNote = Nothing
        Me.ViewCaseNotes.Size = New System.Drawing.Size(665, 177)
        Me.ViewCaseNotes.TabIndex = 0
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
        Me.SplitContainer1.Size = New System.Drawing.Size(673, 255)
        Me.SplitContainer1.SplitterDistance = 304
        Me.SplitContainer1.TabIndex = 4
        '
        'EditLocatingAttempt
        '
        Me.EditLocatingAttempt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditLocatingAttempt.LocatingAttempt = Nothing
        Me.EditLocatingAttempt.Location = New System.Drawing.Point(0, 0)
        Me.EditLocatingAttempt.Name = "EditLocatingAttempt"
        Me.EditLocatingAttempt.Size = New System.Drawing.Size(304, 255)
        Me.EditLocatingAttempt.TabIndex = 0
        '
        'EditLocatingStatus
        '
        Me.EditLocatingStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditLocatingStatus.LocatingStatus = Nothing
        Me.EditLocatingStatus.Location = New System.Drawing.Point(0, 0)
        Me.EditLocatingStatus.Name = "EditLocatingStatus"
        Me.EditLocatingStatus.Size = New System.Drawing.Size(365, 255)
        Me.EditLocatingStatus.TabIndex = 1
        '
        'imlShowHide
        '
        Me.imlShowHide.ImageStream = CType(resources.GetObject("imlShowHide.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlShowHide.TransparentColor = System.Drawing.Color.Transparent
        Me.imlShowHide.Images.SetKeyName(0, "show.bmp")
        Me.imlShowHide.Images.SetKeyName(1, "hide.bmp")
        '
        'frmLocatingAttempt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 631)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocatingAttempt"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Locating Attempt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tsToolbar.ResumeLayout(False)
        Me.tsToolbar.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.tabCase.ResumeLayout(False)
        Me.tabPerson.ResumeLayout(False)
        Me.tabAddress.ResumeLayout(False)
        Me.tabPhone.ResumeLayout(False)
        Me.tabEmail.ResumeLayout(False)
        Me.tabSN.ResumeLayout(False)
        Me.tabNotes.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EditLocatingAttempt As MPR.SMS.UserControls.EditLocatingAttempt
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents EditLocatingStatus As MPR.SMS.UserControls.EditLocatingStatus
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabCase As System.Windows.Forms.TabControl
    Friend WithEvents tabAddress As System.Windows.Forms.TabPage
    Friend WithEvents tabPhone As System.Windows.Forms.TabPage
    Friend WithEvents tabEmail As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents ViewCasePhones As MPR.SMS.UserControls.ViewCasePhones
    Friend WithEvents ViewCaseEmails As MPR.SMS.UserControls.ViewCaseEmails
    Friend WithEvents imlShowHide As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents tabPerson As System.Windows.Forms.TabPage
    Friend WithEvents EditPerson As MPR.SMS.UserControls.EditPerson
    Friend WithEvents tsToolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents lblURL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboURL As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnExpand As System.Windows.Forms.ToolStripButton
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents btnFavorites As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tabNotes As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseNotes As MPR.SMS.UserControls.ViewCaseNotes
    Friend WithEvents tabSN As System.Windows.Forms.TabPage
    Friend WithEvents ViewCaseSocialNetworks As MPR.SMS.UserControls.ViewCaseSocialNetworks
End Class
