<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucValidation
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.cboStatus = New MPR.SMS.UserControls.ValidationStatusComboBox
        Me.txtNotes = New System.Windows.Forms.RichTextBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.chkValidate = New System.Windows.Forms.CheckBox
        Me.txtDate = New MPR.SMS.UserControls.DateWithValidator
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.grpDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.cboStatus)
        Me.grpDetails.Controls.Add(Me.txtNotes)
        Me.grpDetails.Controls.Add(Me.lblNote)
        Me.grpDetails.Controls.Add(Me.chkValidate)
        Me.grpDetails.Controls.Add(Me.txtDate)
        Me.grpDetails.Controls.Add(Me.lblStatus)
        Me.grpDetails.Controls.Add(Me.lblDate)
        Me.grpDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetails.Location = New System.Drawing.Point(0, 0)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(628, 171)
        Me.grpDetails.TabIndex = 0
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'cboStatus
        '
        Me.cboStatus.Location = New System.Drawing.Point(123, 47)
        Me.cboStatus.MyLabel = "Status:"
        Me.cboStatus.MyLabelVisible = False
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.ReadOnly = True
        Me.cboStatus.SelectedIndex = -1
        Me.cboStatus.SelectedValidationStatus = Nothing
        Me.cboStatus.SelectedValidationStatusID = -1
        Me.cboStatus.Size = New System.Drawing.Size(174, 21)
        Me.cboStatus.TabIndex = 2
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(6, 101)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(616, 62)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = ""
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(6, 85)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(38, 13)
        Me.lblNote.TabIndex = 5
        Me.lblNote.Text = "Notes:"
        '
        'chkValidate
        '
        Me.chkValidate.Location = New System.Drawing.Point(9, 20)
        Me.chkValidate.Name = "chkValidate"
        Me.chkValidate.Size = New System.Drawing.Size(195, 18)
        Me.chkValidate.TabIndex = 0
        Me.chkValidate.Text = "This case is selected for &validation"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(397, 47)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Required = False
        Me.txtDate.Size = New System.Drawing.Size(95, 20)
        Me.txtDate.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(30, 49)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(87, 13)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Validation status:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(327, 49)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(64, 13)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Status date:"
        '
        'ucValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpDetails)
        Me.Name = "ucValidation"
        Me.Size = New System.Drawing.Size(628, 171)
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents chkValidate As System.Windows.Forms.CheckBox
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtDate As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents cboStatus As MPR.SMS.UserControls.ValidationStatusComboBox

End Class
