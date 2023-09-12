'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsent
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
        Me.components = New System.ComponentModel.Container
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ToolTipConsent = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboAssent = New MPR.SMS.UserControls.ConsentComboBox
        Me.cboConsent = New MPR.SMS.UserControls.ConsentComboBox
        Me.txtMPRID = New System.Windows.Forms.TextBox
        Me.lblMPRID = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(178, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(66, 109)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboAssent
        '
        Me.cboAssent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAssent.Location = New System.Drawing.Point(12, 65)
        Me.cboAssent.MyLabel = "Assent:"
        Me.cboAssent.Name = "cboAssent"
        Me.cboAssent.SelectedConsentID = -1
        Me.cboAssent.SelectedConsentType = Nothing
        Me.cboAssent.SelectedIndex = -1
        Me.cboAssent.Size = New System.Drawing.Size(293, 21)
        Me.cboAssent.TabIndex = 4
        Me.ToolTipConsent.SetToolTip(Me.cboAssent, "Permission has been granted by this person who is a minor.")
        '
        'cboConsent
        '
        Me.cboConsent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboConsent.Location = New System.Drawing.Point(12, 38)
        Me.cboConsent.MyLabel = "Consent:"
        Me.cboConsent.Name = "cboConsent"
        Me.cboConsent.SelectedConsentID = -1
        Me.cboConsent.SelectedConsentType = Nothing
        Me.cboConsent.SelectedIndex = -1
        Me.cboConsent.Size = New System.Drawing.Size(293, 21)
        Me.cboConsent.TabIndex = 3
        Me.ToolTipConsent.SetToolTip(Me.cboConsent, "Permission has been granted by a non-minor for this person.")
        '
        'txtMPRID
        '
        Me.txtMPRID.Location = New System.Drawing.Point(100, 12)
        Me.txtMPRID.MaxLength = 20
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.ReadOnly = True
        Me.txtMPRID.Size = New System.Drawing.Size(68, 20)
        Me.txtMPRID.TabIndex = 1
        Me.txtMPRID.TabStop = False
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Location = New System.Drawing.Point(12, 12)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(45, 13)
        Me.lblMPRID.TabIndex = 0
        Me.lblMPRID.Text = "MPRID:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(174, 12)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(131, 20)
        Me.txtName.TabIndex = 2
        Me.txtName.TabStop = False
        '
        'frmConsent
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(317, 144)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtMPRID)
        Me.Controls.Add(Me.lblMPRID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cboAssent)
        Me.Controls.Add(Me.cboConsent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmConsent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Consent/Assent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboConsent As MPR.SMS.UserControls.ConsentComboBox
    Friend WithEvents cboAssent As MPR.SMS.UserControls.ConsentComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ToolTipConsent As System.Windows.Forms.ToolTip
    Friend WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents lblMPRID As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
End Class
