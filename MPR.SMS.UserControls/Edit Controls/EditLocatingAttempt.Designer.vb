'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditLocatingAttempt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditLocatingAttempt))
        Me.lblResult = New System.Windows.Forms.Label
        Me.lblNotes = New System.Windows.Forms.Label
        Me.lblAttempt = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.grpAttempt = New System.Windows.Forms.GroupBox
        Me.cboLocTask = New MPR.SMS.UserControls.LocatingAttemptTypeComboBox
        Me.cboLocResult = New MPR.SMS.UserControls.LocatingAttemptResultComboBox
        Me.NoteValidator = New MPR.Windows.Forms.Validation.RequiredFieldValidator
        Me.ResultValidator = New MPR.Windows.Forms.Validation.CustomValidator
        Me.grpAttempt.SuspendLayout()
        CType(Me.NoteValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(6, 48)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(40, 13)
        Me.lblResult.TabIndex = 2
        Me.lblResult.Text = "Result:"
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(6, 78)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(38, 13)
        Me.lblNotes.TabIndex = 4
        Me.lblNotes.Text = "Notes:"
        '
        'lblAttempt
        '
        Me.lblAttempt.AutoSize = True
        Me.lblAttempt.Location = New System.Drawing.Point(6, 20)
        Me.lblAttempt.Name = "lblAttempt"
        Me.lblAttempt.Size = New System.Drawing.Size(34, 13)
        Me.lblAttempt.TabIndex = 0
        Me.lblAttempt.Text = "Task:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(74, 78)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(289, 74)
        Me.txtNotes.TabIndex = 5
        '
        'grpAttempt
        '
        Me.grpAttempt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAttempt.Controls.Add(Me.cboLocTask)
        Me.grpAttempt.Controls.Add(Me.cboLocResult)
        Me.grpAttempt.Controls.Add(Me.lblAttempt)
        Me.grpAttempt.Controls.Add(Me.txtNotes)
        Me.grpAttempt.Controls.Add(Me.lblNotes)
        Me.grpAttempt.Controls.Add(Me.lblResult)
        Me.grpAttempt.Location = New System.Drawing.Point(3, 3)
        Me.grpAttempt.Name = "grpAttempt"
        Me.grpAttempt.Size = New System.Drawing.Size(383, 167)
        Me.grpAttempt.TabIndex = 0
        Me.grpAttempt.TabStop = False
        Me.grpAttempt.Text = "Locating attempt:"
        '
        'cboLocTask
        '
        Me.cboLocTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLocTask.Location = New System.Drawing.Point(74, 19)
        Me.cboLocTask.MyLabel = "Locating type:"
        Me.cboLocTask.MyLabelVisible = False
        Me.cboLocTask.Name = "cboLocTask"
        Me.cboLocTask.ReadOnly = True
        Me.cboLocTask.SelectedLocatingAttemptType = Nothing
        Me.cboLocTask.SelectedLocatingAttemptTypeID = 0
        Me.cboLocTask.Size = New System.Drawing.Size(289, 24)
        Me.cboLocTask.TabIndex = 1
        '
        'cboLocResult
        '
        Me.cboLocResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLocResult.LocatingAttemptType = Nothing
        Me.cboLocResult.Location = New System.Drawing.Point(74, 48)
        Me.cboLocResult.MyLabel = "Locating result:"
        Me.cboLocResult.MyLabelVisible = False
        Me.cboLocResult.Name = "cboLocResult"
        Me.cboLocResult.SelectedLocatingAttemptResult = Nothing
        Me.cboLocResult.SelectedLocatingAttemptResultID = 0
        Me.cboLocResult.Size = New System.Drawing.Size(289, 24)
        Me.cboLocResult.TabIndex = 3
        '
        'NoteValidator
        '
        Me.NoteValidator.ControlToValidate = Me.txtNotes
        Me.NoteValidator.ErrorMessage = "Note is required"
        Me.NoteValidator.Icon = CType(resources.GetObject("NoteValidator.Icon"), System.Drawing.Icon)
        Me.NoteValidator.Required = True
        '
        'ResultValidator
        '
        Me.ResultValidator.ControlToValidate = Me.cboLocResult
        Me.ResultValidator.ErrorMessage = "Result code is required"
        Me.ResultValidator.Icon = CType(resources.GetObject("ResultValidator.Icon"), System.Drawing.Icon)
        Me.ResultValidator.Required = True
        '
        'EditLocatingAttempt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpAttempt)
        Me.Name = "EditLocatingAttempt"
        Me.Size = New System.Drawing.Size(389, 173)
        Me.grpAttempt.ResumeLayout(False)
        Me.grpAttempt.PerformLayout()
        CType(Me.NoteValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblAttempt As System.Windows.Forms.Label
    Friend WithEvents grpAttempt As System.Windows.Forms.GroupBox
    Friend WithEvents cboLocTask As MPR.SMS.UserControls.LocatingAttemptTypeComboBox
    Friend WithEvents cboLocResult As MPR.SMS.UserControls.LocatingAttemptResultComboBox
    Protected WithEvents NoteValidator As MPR.Windows.Forms.Validation.RequiredFieldValidator
    Friend WithEvents ResultValidator As MPR.Windows.Forms.Validation.CustomValidator

End Class
