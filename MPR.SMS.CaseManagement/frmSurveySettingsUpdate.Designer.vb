'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurveySettingsUpdate
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
        Me.txtVariableID = New System.Windows.Forms.TextBox()
        Me.txtVariable = New System.Windows.Forms.TextBox()
        Me.lblVariableID = New System.Windows.Forms.Label()
        Me.lblVariable = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblAllowedValue = New System.Windows.Forms.Label()
        Me.txtAllowedValue = New System.Windows.Forms.TextBox()
        Me.lblExperimentGroup = New System.Windows.Forms.Label()
        Me.txtExperimentGroup = New System.Windows.Forms.TextBox()
        Me.lblIsActive = New System.Windows.Forms.Label()
        Me.txtIsActive = New System.Windows.Forms.TextBox()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.TextBox()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.txtCreatedOn = New System.Windows.Forms.TextBox()
        Me.lblLastModifiedOn = New System.Windows.Forms.Label()
        Me.txtLastModifiedOn = New System.Windows.Forms.TextBox()
        Me.lblLastModifiedBy = New System.Windows.Forms.Label()
        Me.txtLastModifiedBy = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblInstrumentType = New System.Windows.Forms.Label()
        Me.txtInstrumentType = New System.Windows.Forms.TextBox()
        Me.lblRound = New System.Windows.Forms.Label()
        Me.txtRound = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtVariableID
        '
        Me.txtVariableID.Location = New System.Drawing.Point(110, 73)
        Me.txtVariableID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtVariableID.Name = "txtVariableID"
        Me.txtVariableID.ReadOnly = True
        Me.txtVariableID.Size = New System.Drawing.Size(76, 20)
        Me.txtVariableID.TabIndex = 2
        '
        'txtVariable
        '
        Me.txtVariable.Location = New System.Drawing.Point(110, 104)
        Me.txtVariable.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtVariable.Name = "txtVariable"
        Me.txtVariable.ReadOnly = True
        Me.txtVariable.Size = New System.Drawing.Size(76, 20)
        Me.txtVariable.TabIndex = 3
        '
        'lblVariableID
        '
        Me.lblVariableID.AutoSize = True
        Me.lblVariableID.Location = New System.Drawing.Point(10, 73)
        Me.lblVariableID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVariableID.Name = "lblVariableID"
        Me.lblVariableID.Size = New System.Drawing.Size(62, 13)
        Me.lblVariableID.TabIndex = 2
        Me.lblVariableID.Text = "Variable ID:"
        '
        'lblVariable
        '
        Me.lblVariable.AutoSize = True
        Me.lblVariable.Location = New System.Drawing.Point(9, 104)
        Me.lblVariable.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVariable.Name = "lblVariable"
        Me.lblVariable.Size = New System.Drawing.Size(48, 13)
        Me.lblVariable.TabIndex = 3
        Me.lblVariable.Text = "Variable:"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(9, 137)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(63, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(110, 135)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(375, 42)
        Me.txtDescription.TabIndex = 4
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(9, 193)
        Me.lblValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 7
        Me.lblValue.Text = "Value:"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(111, 188)
        Me.txtValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(374, 20)
        Me.txtValue.TabIndex = 5
        '
        'lblAllowedValue
        '
        Me.lblAllowedValue.AutoSize = True
        Me.lblAllowedValue.Location = New System.Drawing.Point(9, 219)
        Me.lblAllowedValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAllowedValue.Name = "lblAllowedValue"
        Me.lblAllowedValue.Size = New System.Drawing.Size(88, 13)
        Me.lblAllowedValue.TabIndex = 9
        Me.lblAllowedValue.Text = "Allowed Value(s):"
        '
        'txtAllowedValue
        '
        Me.txtAllowedValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAllowedValue.Location = New System.Drawing.Point(111, 219)
        Me.txtAllowedValue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAllowedValue.Name = "txtAllowedValue"
        Me.txtAllowedValue.ReadOnly = True
        Me.txtAllowedValue.Size = New System.Drawing.Size(374, 20)
        Me.txtAllowedValue.TabIndex = 6
        '
        'lblExperimentGroup
        '
        Me.lblExperimentGroup.AutoSize = True
        Me.lblExperimentGroup.Location = New System.Drawing.Point(9, 249)
        Me.lblExperimentGroup.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExperimentGroup.Name = "lblExperimentGroup"
        Me.lblExperimentGroup.Size = New System.Drawing.Size(94, 13)
        Me.lblExperimentGroup.TabIndex = 11
        Me.lblExperimentGroup.Text = "Experiment Group:"
        '
        'txtExperimentGroup
        '
        Me.txtExperimentGroup.Location = New System.Drawing.Point(111, 247)
        Me.txtExperimentGroup.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtExperimentGroup.Name = "txtExperimentGroup"
        Me.txtExperimentGroup.ReadOnly = True
        Me.txtExperimentGroup.Size = New System.Drawing.Size(38, 20)
        Me.txtExperimentGroup.TabIndex = 7
        '
        'lblIsActive
        '
        Me.lblIsActive.AutoSize = True
        Me.lblIsActive.Location = New System.Drawing.Point(10, 276)
        Me.lblIsActive.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIsActive.Name = "lblIsActive"
        Me.lblIsActive.Size = New System.Drawing.Size(48, 13)
        Me.lblIsActive.TabIndex = 13
        Me.lblIsActive.Text = "IsActive:"
        '
        'txtIsActive
        '
        Me.txtIsActive.Location = New System.Drawing.Point(111, 276)
        Me.txtIsActive.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtIsActive.Name = "txtIsActive"
        Me.txtIsActive.ReadOnly = True
        Me.txtIsActive.Size = New System.Drawing.Size(38, 20)
        Me.txtIsActive.TabIndex = 8
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Location = New System.Drawing.Point(10, 306)
        Me.lblCreatedBy.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(59, 13)
        Me.lblCreatedBy.TabIndex = 15
        Me.lblCreatedBy.Text = "CreatedBy:"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Location = New System.Drawing.Point(111, 307)
        Me.txtCreatedBy.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(133, 20)
        Me.txtCreatedBy.TabIndex = 14
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Location = New System.Drawing.Point(10, 336)
        Me.lblCreatedOn.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(61, 13)
        Me.lblCreatedOn.TabIndex = 17
        Me.lblCreatedOn.Text = "CreatedOn:"
        '
        'txtCreatedOn
        '
        Me.txtCreatedOn.Location = New System.Drawing.Point(111, 336)
        Me.txtCreatedOn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCreatedOn.Name = "txtCreatedOn"
        Me.txtCreatedOn.ReadOnly = True
        Me.txtCreatedOn.Size = New System.Drawing.Size(133, 20)
        Me.txtCreatedOn.TabIndex = 16
        '
        'lblLastModifiedOn
        '
        Me.lblLastModifiedOn.AutoSize = True
        Me.lblLastModifiedOn.Location = New System.Drawing.Point(263, 336)
        Me.lblLastModifiedOn.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastModifiedOn.Name = "lblLastModifiedOn"
        Me.lblLastModifiedOn.Size = New System.Drawing.Size(84, 13)
        Me.lblLastModifiedOn.TabIndex = 21
        Me.lblLastModifiedOn.Text = "LastModifiedOn:"
        '
        'txtLastModifiedOn
        '
        Me.txtLastModifiedOn.Location = New System.Drawing.Point(352, 336)
        Me.txtLastModifiedOn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtLastModifiedOn.Name = "txtLastModifiedOn"
        Me.txtLastModifiedOn.ReadOnly = True
        Me.txtLastModifiedOn.Size = New System.Drawing.Size(133, 20)
        Me.txtLastModifiedOn.TabIndex = 20
        '
        'lblLastModifiedBy
        '
        Me.lblLastModifiedBy.AutoSize = True
        Me.lblLastModifiedBy.Location = New System.Drawing.Point(266, 306)
        Me.lblLastModifiedBy.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastModifiedBy.Name = "lblLastModifiedBy"
        Me.lblLastModifiedBy.Size = New System.Drawing.Size(82, 13)
        Me.lblLastModifiedBy.TabIndex = 19
        Me.lblLastModifiedBy.Text = "LastModifiedBy:"
        '
        'txtLastModifiedBy
        '
        Me.txtLastModifiedBy.Location = New System.Drawing.Point(352, 306)
        Me.txtLastModifiedBy.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtLastModifiedBy.Name = "txtLastModifiedBy"
        Me.txtLastModifiedBy.ReadOnly = True
        Me.txtLastModifiedBy.Size = New System.Drawing.Size(133, 20)
        Me.txtLastModifiedBy.TabIndex = 18
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(410, 360)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(329, 360)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "&Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblInstrumentType
        '
        Me.lblInstrumentType.AutoSize = True
        Me.lblInstrumentType.Location = New System.Drawing.Point(10, 25)
        Me.lblInstrumentType.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInstrumentType.Name = "lblInstrumentType"
        Me.lblInstrumentType.Size = New System.Drawing.Size(86, 13)
        Me.lblInstrumentType.TabIndex = 27
        Me.lblInstrumentType.Text = "Instrument Type:"
        '
        'txtInstrumentType
        '
        Me.txtInstrumentType.Location = New System.Drawing.Point(110, 25)
        Me.txtInstrumentType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtInstrumentType.Name = "txtInstrumentType"
        Me.txtInstrumentType.ReadOnly = True
        Me.txtInstrumentType.Size = New System.Drawing.Size(375, 20)
        Me.txtInstrumentType.TabIndex = 0
        '
        'lblRound
        '
        Me.lblRound.AutoSize = True
        Me.lblRound.Location = New System.Drawing.Point(10, 48)
        Me.lblRound.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblRound.Name = "lblRound"
        Me.lblRound.Size = New System.Drawing.Size(42, 13)
        Me.lblRound.TabIndex = 29
        Me.lblRound.Text = "Round:"
        '
        'txtRound
        '
        Me.txtRound.Location = New System.Drawing.Point(110, 48)
        Me.txtRound.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtRound.Name = "txtRound"
        Me.txtRound.ReadOnly = True
        Me.txtRound.Size = New System.Drawing.Size(76, 20)
        Me.txtRound.TabIndex = 1
        '
        'frmSurveySettingsUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 395)
        Me.Controls.Add(Me.lblRound)
        Me.Controls.Add(Me.txtRound)
        Me.Controls.Add(Me.lblInstrumentType)
        Me.Controls.Add(Me.txtInstrumentType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblLastModifiedOn)
        Me.Controls.Add(Me.txtLastModifiedOn)
        Me.Controls.Add(Me.lblLastModifiedBy)
        Me.Controls.Add(Me.txtLastModifiedBy)
        Me.Controls.Add(Me.lblCreatedOn)
        Me.Controls.Add(Me.txtCreatedOn)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblIsActive)
        Me.Controls.Add(Me.txtIsActive)
        Me.Controls.Add(Me.lblExperimentGroup)
        Me.Controls.Add(Me.txtExperimentGroup)
        Me.Controls.Add(Me.lblAllowedValue)
        Me.Controls.Add(Me.txtAllowedValue)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblVariable)
        Me.Controls.Add(Me.lblVariableID)
        Me.Controls.Add(Me.txtVariable)
        Me.Controls.Add(Me.txtVariableID)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.Name = "frmSurveySettingsUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Survey Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVariableID As System.Windows.Forms.TextBox
    Friend WithEvents txtVariable As System.Windows.Forms.TextBox
    Friend WithEvents lblVariableID As System.Windows.Forms.Label
    Friend WithEvents lblVariable As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblAllowedValue As System.Windows.Forms.Label
    Friend WithEvents txtAllowedValue As System.Windows.Forms.TextBox
    Friend WithEvents lblExperimentGroup As System.Windows.Forms.Label
    Friend WithEvents txtExperimentGroup As System.Windows.Forms.TextBox
    Friend WithEvents lblIsActive As System.Windows.Forms.Label
    Friend WithEvents txtIsActive As System.Windows.Forms.TextBox
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents txtCreatedOn As System.Windows.Forms.TextBox
    Friend WithEvents lblLastModifiedOn As System.Windows.Forms.Label
    Friend WithEvents txtLastModifiedOn As System.Windows.Forms.TextBox
    Friend WithEvents lblLastModifiedBy As System.Windows.Forms.Label
    Friend WithEvents txtLastModifiedBy As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblInstrumentType As System.Windows.Forms.Label
    Friend WithEvents txtInstrumentType As System.Windows.Forms.TextBox
    Friend WithEvents lblRound As System.Windows.Forms.Label
    Friend WithEvents txtRound As System.Windows.Forms.TextBox
End Class
