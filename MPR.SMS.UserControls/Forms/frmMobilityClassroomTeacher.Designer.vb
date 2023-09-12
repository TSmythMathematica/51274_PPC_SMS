'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMobilityClassroomTeacher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMobilityClassroomTeacher))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtMobilityNote = New System.Windows.Forms.TextBox()
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.NoteValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        Me.cboMobilityCode = New MPR.SMS.UserControls.MobilityComboBox()
        Me.txtMobilityDate = New MPR.SMS.UserControls.DateWithValidator()
        Me.cboClassroom = New MPR.SMS.UserControls.ClassroomComboBox()
        Me.cboTeacher = New MPR.SMS.UserControls.TeacherComboBox()
        Me.ClassroomValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        Me.TeacherValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoteValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassroomValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(57, 278)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(185, 278)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(13, 90)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(69, 13)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Mobility date:"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(13, 119)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(69, 13)
        Me.lblNote.TabIndex = 5
        Me.lblNote.Text = "Mobility note:"
        '
        'txtMobilityNote
        '
        Me.txtMobilityNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobilityNote.Location = New System.Drawing.Point(100, 116)
        Me.txtMobilityNote.MaxLength = 2000
        Me.txtMobilityNote.Multiline = True
        Me.txtMobilityNote.Name = "txtMobilityNote"
        Me.txtMobilityNote.Size = New System.Drawing.Size(194, 99)
        Me.txtMobilityNote.TabIndex = 6
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(16, 229)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblWarning.Size = New System.Drawing.Size(278, 34)
        Me.lblWarning.TabIndex = 7
        Me.lblWarning.Text = "Note: Selecting this mobility code will unasign this teacher from this classroom." & _
    ""
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = False
        '
        'NoteValidator
        '
        Me.NoteValidator.ControlToValidate = Me.txtMobilityNote
        Me.NoteValidator.ErrorMessage = "A note is required."
        Me.NoteValidator.Icon = CType(resources.GetObject("NoteValidator.Icon"), System.Drawing.Icon)
        '
        'cboMobilityCode
        '
        Me.cboMobilityCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMobilityCode.Location = New System.Drawing.Point(12, 64)
        Me.cboMobilityCode.MyLabel = "Mobility code:"
        Me.cboMobilityCode.Name = "cboMobilityCode"
        Me.cboMobilityCode.SelectedMobility = Nothing
        Me.cboMobilityCode.Size = New System.Drawing.Size(282, 24)
        Me.cboMobilityCode.TabIndex = 2
        '
        'txtMobilityDate
        '
        Me.txtMobilityDate.Location = New System.Drawing.Point(100, 90)
        Me.txtMobilityDate.Name = "txtMobilityDate"
        Me.txtMobilityDate.ReadOnly = False
        Me.txtMobilityDate.Required = True
        Me.txtMobilityDate.Size = New System.Drawing.Size(96, 20)
        Me.txtMobilityDate.TabIndex = 4
        '
        'cboClassroom
        '
        Me.cboClassroom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboClassroom.Location = New System.Drawing.Point(12, 12)
        Me.cboClassroom.MyLabel = "Classroom:"
        Me.cboClassroom.Name = "cboClassroom"
        Me.cboClassroom.SelectedClassroom = Nothing
        Me.cboClassroom.SelectedClassroomID = 0
        Me.cboClassroom.Size = New System.Drawing.Size(282, 27)
        Me.cboClassroom.TabIndex = 0
        '
        'cboTeacher
        '
        Me.cboTeacher.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTeacher.Location = New System.Drawing.Point(12, 38)
        Me.cboTeacher.MyLabel = "Teacher:"
        Me.cboTeacher.Name = "cboTeacher"
        Me.cboTeacher.SelectedTeacher = Nothing
        Me.cboTeacher.SelectedTeacherID = 0
        Me.cboTeacher.Size = New System.Drawing.Size(282, 24)
        Me.cboTeacher.TabIndex = 1
        '
        'ClassroomValidator
        '
        Me.ClassroomValidator.ControlToValidate = Me.cboClassroom
        Me.ClassroomValidator.ErrorMessage = "Classroom is required."
        Me.ClassroomValidator.Icon = CType(resources.GetObject("ClassroomValidator.Icon"), System.Drawing.Icon)
        Me.ClassroomValidator.Required = True
        '
        'TeacherValidator
        '
        Me.TeacherValidator.ControlToValidate = Me.cboTeacher
        Me.TeacherValidator.ErrorMessage = "Teacher is required."
        Me.TeacherValidator.Icon = CType(resources.GetObject("TeacherValidator.Icon"), System.Drawing.Icon)
        '
        'frmMobilityClassroomTeacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(317, 313)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cboMobilityCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtMobilityNote)
        Me.Controls.Add(Me.txtMobilityDate)
        Me.Controls.Add(Me.cboClassroom)
        Me.Controls.Add(Me.cboTeacher)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMobilityClassroomTeacher"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Change Classroom/Teacher Assignments"
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoteValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassroomValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTeacher As MPR.SMS.UserControls.TeacherComboBox
    Friend WithEvents cboClassroom As MPR.SMS.UserControls.ClassroomComboBox
    Friend WithEvents txtMobilityDate As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboMobilityCode As MPR.SMS.UserControls.MobilityComboBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtMobilityNote As System.Windows.Forms.TextBox
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents ClassroomValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents TeacherValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents NoteValidator As MPR.Windows.Forms.Validation.CustomValidator
End Class
