<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterviewWeeks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInterviewWeeks))
        Me.lstWeeks = New System.Windows.Forms.ListBox
        Me.lblWeeks = New System.Windows.Forms.Label
        Me.grpRegenerate = New System.Windows.Forms.GroupBox
        Me.txtWeeks = New System.Windows.Forms.TextBox
        Me.txtStartDate = New MPR.SMS.UserControls.DateWithValidator
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnGo = New System.Windows.Forms.Button
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary
        Me.ValidatorWeeks = New MPR.Windows.Forms.Validation.CustomValidator
        Me.grpRegenerate.SuspendLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorWeeks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstWeeks
        '
        Me.lstWeeks.FormattingEnabled = True
        Me.lstWeeks.Location = New System.Drawing.Point(15, 25)
        Me.lstWeeks.Name = "lstWeeks"
        Me.lstWeeks.Size = New System.Drawing.Size(265, 147)
        Me.lstWeeks.TabIndex = 1
        '
        'lblWeeks
        '
        Me.lblWeeks.AutoSize = True
        Me.lblWeeks.Location = New System.Drawing.Point(12, 9)
        Me.lblWeeks.Name = "lblWeeks"
        Me.lblWeeks.Size = New System.Drawing.Size(159, 13)
        Me.lblWeeks.TabIndex = 0
        Me.lblWeeks.Text = "Data collection reporting weeks:"
        '
        'grpRegenerate
        '
        Me.grpRegenerate.Controls.Add(Me.btnGo)
        Me.grpRegenerate.Controls.Add(Me.Label2)
        Me.grpRegenerate.Controls.Add(Me.Label1)
        Me.grpRegenerate.Controls.Add(Me.txtStartDate)
        Me.grpRegenerate.Controls.Add(Me.txtWeeks)
        Me.grpRegenerate.Location = New System.Drawing.Point(15, 179)
        Me.grpRegenerate.Name = "grpRegenerate"
        Me.grpRegenerate.Size = New System.Drawing.Size(265, 80)
        Me.grpRegenerate.TabIndex = 2
        Me.grpRegenerate.TabStop = False
        Me.grpRegenerate.Text = "Generate weeks"
        '
        'txtWeeks
        '
        Me.txtWeeks.Location = New System.Drawing.Point(108, 45)
        Me.txtWeeks.Name = "txtWeeks"
        Me.txtWeeks.Size = New System.Drawing.Size(27, 20)
        Me.txtWeeks.TabIndex = 3
        '
        'txtStartDate
        '
        Me.txtStartDate.Location = New System.Drawing.Point(108, 19)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.ReadOnly = False
        Me.txtStartDate.Required = False
        Me.txtStartDate.Size = New System.Drawing.Size(86, 20)
        Me.txtStartDate.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(215, 265)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(54, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Starting date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number of weeks:"
        '
        'btnGo
        '
        Me.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGo.BackColor = System.Drawing.SystemColors.Control
        Me.btnGo.CausesValidation = False
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGo.Location = New System.Drawing.Point(200, 45)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(54, 22)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "&Go"
        Me.btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        Me.FormValidator.ValidateOnAccept = False
        '
        'ValidatorWeeks
        '
        Me.ValidatorWeeks.ControlToValidate = Me.txtWeeks
        Me.ValidatorWeeks.ErrorMessage = "Enter a value between 1 and 52."
        Me.ValidatorWeeks.Icon = CType(resources.GetObject("ValidatorWeeks.Icon"), System.Drawing.Icon)
        Me.ValidatorWeeks.Required = True
        '
        'frmInterviewWeeks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(292, 298)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpRegenerate)
        Me.Controls.Add(Me.lblWeeks)
        Me.Controls.Add(Me.lstWeeks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInterviewWeeks"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Interview Weeks"
        Me.grpRegenerate.ResumeLayout(False)
        Me.grpRegenerate.PerformLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorWeeks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstWeeks As System.Windows.Forms.ListBox
    Friend WithEvents lblWeeks As System.Windows.Forms.Label
    Friend WithEvents grpRegenerate As System.Windows.Forms.GroupBox
    Friend WithEvents txtStartDate As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents txtWeeks As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents ValidatorWeeks As MPR.Windows.Forms.Validation.CustomValidator
End Class
