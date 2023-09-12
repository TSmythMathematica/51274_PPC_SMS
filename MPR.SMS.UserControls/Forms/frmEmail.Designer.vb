'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.EditPersonName = New MPR.SMS.UserControls.EditPersonName
        Me.EditEmail = New MPR.SMS.UserControls.EditEmail
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        Me.FormValidator.ValidateOnAccept = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(253, 301)
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
        Me.btnCancel.Location = New System.Drawing.Point(334, 301)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'EditPersonName
        '
        Me.EditPersonName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditPersonName.Location = New System.Drawing.Point(2, 1)
        Me.EditPersonName.Name = "EditPersonName"
        Me.EditPersonName.Person = Nothing
        Me.EditPersonName.ReadOnly = True
        Me.EditPersonName.Size = New System.Drawing.Size(416, 60)
        Me.EditPersonName.TabIndex = 0
        Me.EditPersonName.TabStop = False
        '
        'EditEmail
        '
        Me.EditEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditEmail.Email = Nothing
        Me.EditEmail.EmailRequired = True
        Me.EditEmail.Location = New System.Drawing.Point(2, 67)
        Me.EditEmail.Name = "EditEmail"
        Me.EditEmail.Size = New System.Drawing.Size(416, 228)
        Me.EditEmail.TabIndex = 1
        '
        'frmEmail
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(421, 330)
        Me.Controls.Add(Me.EditPersonName)
        Me.Controls.Add(Me.EditEmail)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmail"
        Me.Text = "Add/Edit Email"
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents EditEmail As MPR.SMS.UserControls.EditEmail
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents EditPersonName As MPR.SMS.UserControls.EditPersonName
End Class
