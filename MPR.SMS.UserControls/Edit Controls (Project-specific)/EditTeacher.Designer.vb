'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditTeacher
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditTeacher))
        Me.grpBaseline = New System.Windows.Forms.GroupBox
        Me.cboClassroomBaseline = New MPR.SMS.UserControls.ClassroomComboBox
        Me.cboSchoolBaseline = New MPR.SMS.UserControls.SchoolComboBox
        Me.txtGradeBaseline = New MPR.SMS.UserControls.GradeWithValidator
        Me.lblGradeBaseline = New System.Windows.Forms.Label
        Me.txtGradeSubjTaught = New System.Windows.Forms.TextBox
        Me.lblGrade1 = New System.Windows.Forms.Label
        Me.lblGrade3 = New System.Windows.Forms.Label
        Me.grpMobility = New System.Windows.Forms.GroupBox
        Me.vwMobility = New MPR.SMS.UserControls.ViewDataSet
        Me.txtGrade = New MPR.SMS.UserControls.GradeWithValidator
        Me.grpClassrooms = New System.Windows.Forms.GroupBox
        Me.vwClassrooms = New System.Windows.Forms.DataGridView
        Me.ClassroomID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Classroom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.imlEditTeacher15 = New System.Windows.Forms.ImageList(Me.components)
        Me.grpBaseline.SuspendLayout()
        Me.grpMobility.SuspendLayout()
        Me.grpClassrooms.SuspendLayout()
        CType(Me.vwClassrooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBaseline
        '
        Me.grpBaseline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBaseline.Controls.Add(Me.cboClassroomBaseline)
        Me.grpBaseline.Controls.Add(Me.cboSchoolBaseline)
        Me.grpBaseline.Controls.Add(Me.txtGradeBaseline)
        Me.grpBaseline.Controls.Add(Me.lblGradeBaseline)
        Me.grpBaseline.Location = New System.Drawing.Point(9, 68)
        Me.grpBaseline.Name = "grpBaseline"
        Me.grpBaseline.Size = New System.Drawing.Size(281, 113)
        Me.grpBaseline.TabIndex = 4
        Me.grpBaseline.TabStop = False
        Me.grpBaseline.Text = "Baseline:"
        '
        'cboClassroomBaseline
        '
        Me.cboClassroomBaseline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboClassroomBaseline.Location = New System.Drawing.Point(6, 85)
        Me.cboClassroomBaseline.MyLabel = "Classroom:"
        Me.cboClassroomBaseline.Name = "cboClassroomBaseline"
        Me.cboClassroomBaseline.SelectedClassroom = Nothing
        Me.cboClassroomBaseline.SelectedClassroomID = 0
        Me.cboClassroomBaseline.Size = New System.Drawing.Size(263, 24)
        Me.cboClassroomBaseline.TabIndex = 3
        '
        'cboSchoolBaseline
        '
        Me.cboSchoolBaseline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSchoolBaseline.Location = New System.Drawing.Point(6, 55)
        Me.cboSchoolBaseline.MyLabel = "School:"
        Me.cboSchoolBaseline.Name = "cboSchoolBaseline"
        Me.cboSchoolBaseline.SelectedSchool = Nothing
        Me.cboSchoolBaseline.SelectedSchoolID = 0
        Me.cboSchoolBaseline.Size = New System.Drawing.Size(263, 24)
        Me.cboSchoolBaseline.TabIndex = 2
        '
        'txtGradeBaseline
        '
        Me.txtGradeBaseline.AllowGrade0 = False
        Me.txtGradeBaseline.AllowGradeK = True
        Me.txtGradeBaseline.AllowGradePK = True
        Me.txtGradeBaseline.Location = New System.Drawing.Point(94, 29)
        Me.txtGradeBaseline.Name = "txtGradeBaseline"
        Me.txtGradeBaseline.ReadOnly = False
        Me.txtGradeBaseline.Required = False
        Me.txtGradeBaseline.Size = New System.Drawing.Size(40, 20)
        Me.txtGradeBaseline.TabIndex = 1
        '
        'lblGradeBaseline
        '
        Me.lblGradeBaseline.AutoSize = True
        Me.lblGradeBaseline.Location = New System.Drawing.Point(6, 29)
        Me.lblGradeBaseline.Name = "lblGradeBaseline"
        Me.lblGradeBaseline.Size = New System.Drawing.Size(39, 13)
        Me.lblGradeBaseline.TabIndex = 0
        Me.lblGradeBaseline.Text = "Grade:"
        '
        'txtGradeSubjTaught
        '
        Me.txtGradeSubjTaught.Location = New System.Drawing.Point(103, 38)
        Me.txtGradeSubjTaught.MaxLength = 255
        Me.txtGradeSubjTaught.Name = "txtGradeSubjTaught"
        Me.txtGradeSubjTaught.Size = New System.Drawing.Size(175, 20)
        Me.txtGradeSubjTaught.TabIndex = 3
        '
        'lblGrade1
        '
        Me.lblGrade1.AutoSize = True
        Me.lblGrade1.Location = New System.Drawing.Point(16, 14)
        Me.lblGrade1.Name = "lblGrade1"
        Me.lblGrade1.Size = New System.Drawing.Size(39, 13)
        Me.lblGrade1.TabIndex = 0
        Me.lblGrade1.Text = "Grade:"
        '
        'lblGrade3
        '
        Me.lblGrade3.AutoSize = True
        Me.lblGrade3.Location = New System.Drawing.Point(16, 38)
        Me.lblGrade3.Name = "lblGrade3"
        Me.lblGrade3.Size = New System.Drawing.Size(84, 13)
        Me.lblGrade3.TabIndex = 2
        Me.lblGrade3.Text = "Subjects taught:"
        '
        'grpMobility
        '
        Me.grpMobility.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMobility.Controls.Add(Me.vwMobility)
        Me.grpMobility.Location = New System.Drawing.Point(480, 3)
        Me.grpMobility.Name = "grpMobility"
        Me.grpMobility.Size = New System.Drawing.Size(138, 178)
        Me.grpMobility.TabIndex = 6
        Me.grpMobility.TabStop = False
        Me.grpMobility.Text = "Teacher mobility history:"
        '
        'vwMobility
        '
        Me.vwMobility.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwMobility.DataSource = Nothing
        Me.vwMobility.Location = New System.Drawing.Point(6, 19)
        Me.vwMobility.MultiSelect = True
        Me.vwMobility.Name = "vwMobility"
        Me.vwMobility.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwMobility.Size = New System.Drawing.Size(125, 150)
        Me.vwMobility.SortedColumn = Nothing
        Me.vwMobility.TabIndex = 0
        '
        'txtGrade
        '
        Me.txtGrade.AllowGrade0 = False
        Me.txtGrade.AllowGradeK = True
        Me.txtGrade.AllowGradePK = True
        Me.txtGrade.Location = New System.Drawing.Point(103, 14)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.ReadOnly = False
        Me.txtGrade.Required = False
        Me.txtGrade.Size = New System.Drawing.Size(40, 20)
        Me.txtGrade.TabIndex = 1
        '
        'grpClassrooms
        '
        Me.grpClassrooms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpClassrooms.Controls.Add(Me.vwClassrooms)
        Me.grpClassrooms.Controls.Add(Me.btnEdit)
        Me.grpClassrooms.Controls.Add(Me.btnAdd)
        Me.grpClassrooms.Location = New System.Drawing.Point(296, 68)
        Me.grpClassrooms.Name = "grpClassrooms"
        Me.grpClassrooms.Size = New System.Drawing.Size(178, 113)
        Me.grpClassrooms.TabIndex = 5
        Me.grpClassrooms.TabStop = False
        Me.grpClassrooms.Text = "Classrooms:"
        '
        'vwClassrooms
        '
        Me.vwClassrooms.AllowUserToAddRows = False
        Me.vwClassrooms.AllowUserToDeleteRows = False
        Me.vwClassrooms.AllowUserToOrderColumns = True
        Me.vwClassrooms.AllowUserToResizeRows = False
        Me.vwClassrooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwClassrooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.vwClassrooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.vwClassrooms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClassroomID, Me.Classroom})
        Me.vwClassrooms.Location = New System.Drawing.Point(6, 17)
        Me.vwClassrooms.MultiSelect = False
        Me.vwClassrooms.Name = "vwClassrooms"
        Me.vwClassrooms.ReadOnly = True
        Me.vwClassrooms.RowHeadersVisible = False
        Me.vwClassrooms.RowTemplate.Height = 17
        Me.vwClassrooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.vwClassrooms.Size = New System.Drawing.Size(166, 58)
        Me.vwClassrooms.TabIndex = 0
        '
        'ClassroomID
        '
        Me.ClassroomID.HeaderText = "ClassroomID"
        Me.ClassroomID.Name = "ClassroomID"
        Me.ClassroomID.ReadOnly = True
        Me.ClassroomID.ToolTipText = "ClassroomID"
        Me.ClassroomID.Visible = False
        Me.ClassroomID.Width = 70
        '
        'Classroom
        '
        Me.Classroom.HeaderText = "Classroom"
        Me.Classroom.Name = "Classroom"
        Me.Classroom.ReadOnly = True
        Me.Classroom.ToolTipText = "Classroom"
        Me.Classroom.Width = 145
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 0
        Me.btnEdit.ImageList = Me.imlEditTeacher15
        Me.btnEdit.Location = New System.Drawing.Point(87, 81)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageIndex = 1
        Me.btnAdd.ImageList = Me.imlEditTeacher15
        Me.btnAdd.Location = New System.Drawing.Point(6, 81)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'imlEditTeacher15
        '
        Me.imlEditTeacher15.ImageStream = CType(resources.GetObject("imlEditTeacher15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlEditTeacher15.TransparentColor = System.Drawing.Color.White
        Me.imlEditTeacher15.Images.SetKeyName(0, "update.bmp")
        Me.imlEditTeacher15.Images.SetKeyName(1, "insert.bmp")
        '
        'EditTeacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.grpClassrooms)
        Me.Controls.Add(Me.grpMobility)
        Me.Controls.Add(Me.grpBaseline)
        Me.Controls.Add(Me.txtGrade)
        Me.Controls.Add(Me.lblGrade3)
        Me.Controls.Add(Me.lblGrade1)
        Me.Controls.Add(Me.txtGradeSubjTaught)
        Me.Name = "EditTeacher"
        Me.Size = New System.Drawing.Size(626, 190)
        Me.grpBaseline.ResumeLayout(False)
        Me.grpBaseline.PerformLayout()
        Me.grpMobility.ResumeLayout(False)
        Me.grpClassrooms.ResumeLayout(False)
        CType(Me.vwClassrooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpBaseline As System.Windows.Forms.GroupBox
    Friend WithEvents lblGrade1 As System.Windows.Forms.Label
    Friend WithEvents txtGradeSubjTaught As System.Windows.Forms.TextBox
    Friend WithEvents txtGrade As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents txtGradeBaseline As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents lblGradeBaseline As System.Windows.Forms.Label
    Friend WithEvents lblGrade3 As System.Windows.Forms.Label
    Friend WithEvents cboClassroomBaseline As MPR.SMS.UserControls.ClassroomComboBox
    Friend WithEvents cboSchoolBaseline As MPR.SMS.UserControls.SchoolComboBox
    Friend WithEvents grpMobility As System.Windows.Forms.GroupBox
    Friend WithEvents vwMobility As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents grpClassrooms As System.Windows.Forms.GroupBox
    Friend WithEvents vwClassrooms As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ClassroomID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Classroom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imlEditTeacher15 As System.Windows.Forms.ImageList

End Class
