'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPersonAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonAdd))
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tabPerson = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.EditNote = New MPR.SMS.UserControls.EditNote()
        Me.EditAddress = New MPR.SMS.UserControls.EditAddress()
        Me.EditPhone = New MPR.SMS.UserControls.EditPhone()
        Me.EditPerson = New MPR.SMS.UserControls.EditPerson()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPerson.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(471, 701)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(568, 701)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tabPerson
        '
        Me.tabPerson.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabPerson.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabPerson.Controls.Add(Me.TabPage1)
        Me.tabPerson.Controls.Add(Me.TabPage2)
        Me.tabPerson.Location = New System.Drawing.Point(0, 120)
        Me.tabPerson.Name = "tabPerson"
        Me.tabPerson.SelectedIndex = 0
        Me.tabPerson.Size = New System.Drawing.Size(655, 575)
        Me.tabPerson.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.EditNote)
        Me.TabPage1.Controls.Add(Me.EditAddress)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(647, 546)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Address"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.EditPhone)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(647, 579)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Phone"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'EditNote
        '
        Me.EditNote.Address = Nothing
        Me.EditNote.Location = New System.Drawing.Point(5, 230)
        Me.EditNote.Name = "EditNote"
        Me.EditNote.Note = Nothing
        Me.EditNote.Person = Nothing
        Me.EditNote.Size = New System.Drawing.Size(637, 315)
        Me.EditNote.TabIndex = 2
        '
        'EditAddress
        '
        Me.EditAddress.Address = Nothing
        Me.EditAddress.Location = New System.Drawing.Point(3, 3)
        Me.EditAddress.Name = "EditAddress"
        Me.EditAddress.Person = Nothing
        Me.EditAddress.Size = New System.Drawing.Size(641, 250)
        Me.EditAddress.TabIndex = 1
        '
        'EditPhone
        '
        Me.EditPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditPhone.Location = New System.Drawing.Point(3, 3)
        Me.EditPhone.Name = "EditPhone"
        Me.EditPhone.Person = Nothing
        Me.EditPhone.Phone = Nothing
        Me.EditPhone.Size = New System.Drawing.Size(641, 573)
        Me.EditPhone.TabIndex = 4
        '
        'EditPerson
        '
        Me.EditPerson.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditPerson.Location = New System.Drawing.Point(0, 0)
        Me.EditPerson.Name = "EditPerson"
        Me.EditPerson.Person = Nothing
        Me.EditPerson.Size = New System.Drawing.Size(655, 114)
        Me.EditPerson.TabIndex = 0
        '
        'frmPersonAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(655, 730)
        Me.Controls.Add(Me.tabPerson)
        Me.Controls.Add(Me.EditPerson)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPersonAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Person"
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPerson.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents EditPerson As MPR.SMS.UserControls.EditPerson
    Friend WithEvents EditAddress As MPR.SMS.UserControls.EditAddress
    Friend WithEvents EditPhone As MPR.SMS.UserControls.EditPhone
    Friend WithEvents tabPerson As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents EditNote As MPR.SMS.UserControls.EditNote
End Class
