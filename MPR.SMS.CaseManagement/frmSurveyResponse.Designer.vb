'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurveyResponse
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveyResponse))
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lnkQuestionnaire = New System.Windows.Forms.LinkLabel()
        Me.lblAllowedValue = New System.Windows.Forms.Label()
        Me.txtAllowedValue = New System.Windows.Forms.TextBox()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.TextBox()
        Me.txtCreatedOn = New System.Windows.Forms.TextBox()
        Me.txtMode = New System.Windows.Forms.TextBox()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtVariableName = New System.Windows.Forms.TextBox()
        Me.txtVariableID = New System.Windows.Forms.TextBox()
        Me.lblVariableID = New System.Windows.Forms.Label()
        Me.lblVariableName = New System.Windows.Forms.Label()
        Me.txtQNum = New System.Windows.Forms.TextBox()
        Me.txtMPRID = New System.Windows.Forms.TextBox()
        Me.lblMPRID = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblChangeBy = New System.Windows.Forms.Label()
        Me.lblChangeDate = New System.Windows.Forms.Label()
        Me.txtLastModifiedBy = New System.Windows.Forms.TextBox()
        Me.txtLastModifiedOn = New System.Windows.Forms.TextBox()
        Me.lblQuestionNum = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtInfo
        '
        Me.txtInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfo.Location = New System.Drawing.Point(-2, 329)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(655, 40)
        Me.txtInfo.TabIndex = 108
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(-2, 1)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.Size = New System.Drawing.Size(655, 34)
        Me.txtMessage.TabIndex = 107
        '
        'lnkQuestionnaire
        '
        Me.lnkQuestionnaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkQuestionnaire.AutoSize = True
        Me.lnkQuestionnaire.Location = New System.Drawing.Point(250, 380)
        Me.lnkQuestionnaire.Name = "lnkQuestionnaire"
        Me.lnkQuestionnaire.Size = New System.Drawing.Size(144, 13)
        Me.lnkQuestionnaire.TabIndex = 106
        Me.lnkQuestionnaire.TabStop = True
        Me.lnkQuestionnaire.Text = "View Scanned Questionnaire"
        Me.lnkQuestionnaire.Visible = False
        '
        'lblAllowedValue
        '
        Me.lblAllowedValue.AutoEllipsis = True
        Me.lblAllowedValue.AutoSize = True
        Me.lblAllowedValue.Location = New System.Drawing.Point(234, 73)
        Me.lblAllowedValue.Name = "lblAllowedValue"
        Me.lblAllowedValue.Size = New System.Drawing.Size(88, 13)
        Me.lblAllowedValue.TabIndex = 105
        Me.lblAllowedValue.Text = "Allowed Value(s):"
        Me.lblAllowedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAllowedValue
        '
        Me.txtAllowedValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAllowedValue.BackColor = System.Drawing.Color.Yellow
        Me.txtAllowedValue.Location = New System.Drawing.Point(328, 70)
        Me.txtAllowedValue.Name = "txtAllowedValue"
        Me.txtAllowedValue.ReadOnly = True
        Me.txtAllowedValue.Size = New System.Drawing.Size(311, 20)
        Me.txtAllowedValue.TabIndex = 104
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(11, 375)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(134, 23)
        Me.btnHistory.TabIndex = 103
        Me.btnHistory.Text = "&View History"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Location = New System.Drawing.Point(12, 292)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(62, 13)
        Me.lblCreatedBy.TabIndex = 102
        Me.lblCreatedBy.Text = "Created By:"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Location = New System.Drawing.Point(12, 266)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(73, 13)
        Me.lblCreatedOn.TabIndex = 101
        Me.lblCreatedOn.Text = "Created Date:"
        Me.lblCreatedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Location = New System.Drawing.Point(92, 292)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(200, 20)
        Me.txtCreatedBy.TabIndex = 100
        '
        'txtCreatedOn
        '
        Me.txtCreatedOn.Location = New System.Drawing.Point(92, 266)
        Me.txtCreatedOn.Name = "txtCreatedOn"
        Me.txtCreatedOn.ReadOnly = True
        Me.txtCreatedOn.Size = New System.Drawing.Size(200, 20)
        Me.txtCreatedOn.TabIndex = 99
        '
        'txtMode
        '
        Me.txtMode.Location = New System.Drawing.Point(328, 44)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.ReadOnly = True
        Me.txtMode.Size = New System.Drawing.Size(131, 20)
        Me.txtMode.TabIndex = 98
        '
        'lblMode
        '
        Me.lblMode.AutoEllipsis = True
        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(234, 47)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(37, 13)
        Me.lblMode.TabIndex = 97
        Me.lblMode.Text = "Mode:"
        Me.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.Location = New System.Drawing.Point(92, 99)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(545, 20)
        Me.txtDesc.TabIndex = 96
        '
        'lblDesc
        '
        Me.lblDesc.AutoEllipsis = True
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(11, 102)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDesc.TabIndex = 95
        Me.lblDesc.Text = "Description:"
        Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValue
        '
        Me.txtValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue.Location = New System.Drawing.Point(92, 156)
        Me.txtValue.MaxLength = 200
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(545, 20)
        Me.txtValue.TabIndex = 77
        '
        'lblValue
        '
        Me.lblValue.AutoEllipsis = True
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(12, 156)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 94
        Me.lblValue.Text = "Value:"
        Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVariableName
        '
        Me.txtVariableName.Location = New System.Drawing.Point(328, 127)
        Me.txtVariableName.Name = "txtVariableName"
        Me.txtVariableName.ReadOnly = True
        Me.txtVariableName.Size = New System.Drawing.Size(180, 20)
        Me.txtVariableName.TabIndex = 93
        '
        'txtVariableID
        '
        Me.txtVariableID.Location = New System.Drawing.Point(92, 130)
        Me.txtVariableID.Name = "txtVariableID"
        Me.txtVariableID.ReadOnly = True
        Me.txtVariableID.Size = New System.Drawing.Size(126, 20)
        Me.txtVariableID.TabIndex = 92
        '
        'lblVariableID
        '
        Me.lblVariableID.AutoEllipsis = True
        Me.lblVariableID.AutoSize = True
        Me.lblVariableID.Location = New System.Drawing.Point(12, 130)
        Me.lblVariableID.Name = "lblVariableID"
        Me.lblVariableID.Size = New System.Drawing.Size(62, 13)
        Me.lblVariableID.TabIndex = 91
        Me.lblVariableID.Text = "Variable ID:"
        Me.lblVariableID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVariableName
        '
        Me.lblVariableName.AutoEllipsis = True
        Me.lblVariableName.AutoSize = True
        Me.lblVariableName.Location = New System.Drawing.Point(234, 130)
        Me.lblVariableName.Name = "lblVariableName"
        Me.lblVariableName.Size = New System.Drawing.Size(48, 13)
        Me.lblVariableName.TabIndex = 90
        Me.lblVariableName.Text = "Variable:"
        Me.lblVariableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQNum
        '
        Me.txtQNum.Location = New System.Drawing.Point(92, 70)
        Me.txtQNum.Name = "txtQNum"
        Me.txtQNum.ReadOnly = True
        Me.txtQNum.Size = New System.Drawing.Size(126, 20)
        Me.txtQNum.TabIndex = 89
        '
        'txtMPRID
        '
        Me.txtMPRID.Location = New System.Drawing.Point(92, 44)
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.ReadOnly = True
        Me.txtMPRID.Size = New System.Drawing.Size(126, 20)
        Me.txtMPRID.TabIndex = 88
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoEllipsis = True
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Location = New System.Drawing.Point(12, 47)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(45, 13)
        Me.lblMPRID.TabIndex = 87
        Me.lblMPRID.Text = "MPRID:"
        Me.lblMPRID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(561, 375)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 80
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblNote
        '
        Me.lblNote.AutoEllipsis = True
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(12, 189)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(33, 13)
        Me.lblNote.TabIndex = 86
        Me.lblNote.Text = "Note:"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(480, 375)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 79
        Me.btnOK.Text = "&Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(92, 186)
        Me.txtNote.MaxLength = 2000
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(545, 71)
        Me.txtNote.TabIndex = 78
        '
        'lblChangeBy
        '
        Me.lblChangeBy.AutoSize = True
        Me.lblChangeBy.Location = New System.Drawing.Point(329, 292)
        Me.lblChangeBy.Name = "lblChangeBy"
        Me.lblChangeBy.Size = New System.Drawing.Size(88, 13)
        Me.lblChangeBy.TabIndex = 85
        Me.lblChangeBy.Text = "Last Modified By:"
        Me.lblChangeBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChangeDate
        '
        Me.lblChangeDate.AutoSize = True
        Me.lblChangeDate.Location = New System.Drawing.Point(329, 266)
        Me.lblChangeDate.Name = "lblChangeDate"
        Me.lblChangeDate.Size = New System.Drawing.Size(99, 13)
        Me.lblChangeDate.TabIndex = 84
        Me.lblChangeDate.Text = "Last Modified Date:"
        Me.lblChangeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastModifiedBy
        '
        Me.txtLastModifiedBy.Location = New System.Drawing.Point(434, 289)
        Me.txtLastModifiedBy.Name = "txtLastModifiedBy"
        Me.txtLastModifiedBy.ReadOnly = True
        Me.txtLastModifiedBy.Size = New System.Drawing.Size(200, 20)
        Me.txtLastModifiedBy.TabIndex = 83
        '
        'txtLastModifiedOn
        '
        Me.txtLastModifiedOn.Location = New System.Drawing.Point(434, 263)
        Me.txtLastModifiedOn.Name = "txtLastModifiedOn"
        Me.txtLastModifiedOn.ReadOnly = True
        Me.txtLastModifiedOn.Size = New System.Drawing.Size(200, 20)
        Me.txtLastModifiedOn.TabIndex = 82
        '
        'lblQuestionNum
        '
        Me.lblQuestionNum.AutoEllipsis = True
        Me.lblQuestionNum.AutoSize = True
        Me.lblQuestionNum.Location = New System.Drawing.Point(12, 73)
        Me.lblQuestionNum.Name = "lblQuestionNum"
        Me.lblQuestionNum.Size = New System.Drawing.Size(62, 13)
        Me.lblQuestionNum.TabIndex = 81
        Me.lblQuestionNum.Text = "Question #:"
        Me.lblQuestionNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSurveyResponse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 398)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lnkQuestionnaire)
        Me.Controls.Add(Me.lblAllowedValue)
        Me.Controls.Add(Me.txtAllowedValue)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.lblCreatedOn)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.txtCreatedOn)
        Me.Controls.Add(Me.txtMode)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.txtVariableName)
        Me.Controls.Add(Me.txtVariableID)
        Me.Controls.Add(Me.lblVariableID)
        Me.Controls.Add(Me.lblVariableName)
        Me.Controls.Add(Me.txtQNum)
        Me.Controls.Add(Me.txtMPRID)
        Me.Controls.Add(Me.lblMPRID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.lblChangeBy)
        Me.Controls.Add(Me.lblChangeDate)
        Me.Controls.Add(Me.txtLastModifiedBy)
        Me.Controls.Add(Me.txtLastModifiedOn)
        Me.Controls.Add(Me.lblQuestionNum)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(666, 436)
        Me.Name = "frmSurveyResponse"
        Me.Text = "Update Survey Preliminary Response Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lnkQuestionnaire As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAllowedValue As System.Windows.Forms.Label
    Friend WithEvents txtAllowedValue As System.Windows.Forms.TextBox
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedOn As System.Windows.Forms.TextBox
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtVariableName As System.Windows.Forms.TextBox
    Friend WithEvents txtVariableID As System.Windows.Forms.TextBox
    Friend WithEvents lblVariableID As System.Windows.Forms.Label
    Friend WithEvents lblVariableName As System.Windows.Forms.Label
    Friend WithEvents txtQNum As System.Windows.Forms.TextBox
    Friend WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents lblMPRID As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblChangeBy As System.Windows.Forms.Label
    Friend WithEvents lblChangeDate As System.Windows.Forms.Label
    Friend WithEvents txtLastModifiedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtLastModifiedOn As System.Windows.Forms.TextBox
    Friend WithEvents lblQuestionNum As System.Windows.Forms.Label
End Class
