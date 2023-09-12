'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditClassroom
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditClassroom))
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblGrade1 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblClassNum = New System.Windows.Forms.Label()
        Me.txtClassNum = New System.Windows.Forms.TextBox()
        Me.RangeValidator = New MPR.Windows.Forms.Validation.RangeValidator()
        Me.grpMobility = New System.Windows.Forms.GroupBox()
        Me.grpStudents = New System.Windows.Forms.GroupBox()
        Me.grpTeachers = New System.Windows.Forms.GroupBox()
        Me.vwTeachers = New System.Windows.Forms.DataGridView()
        Me.TeacherID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TeacherName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.imlEditClassroom15 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.vwStudents = New MPR.SMS.UserControls.ViewDataSet()
        Me.vwMobility = New MPR.SMS.UserControls.ViewDataSet()
        Me.cboSchool = New MPR.SMS.UserControls.SchoolComboBox()
        Me.txtGrade = New MPR.SMS.UserControls.GradeWithValidator()
        CType(Me.RangeValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMobility.SuspendLayout()
        Me.grpStudents.SuspendLayout()
        Me.grpTeachers.SuspendLayout()
        CType(Me.vwTeachers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(97, 16)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(186, 20)
        Me.txtName.TabIndex = 1
        '
        'lblGrade1
        '
        Me.lblGrade1.AutoSize = True
        Me.lblGrade1.Location = New System.Drawing.Point(9, 75)
        Me.lblGrade1.Name = "lblGrade1"
        Me.lblGrade1.Size = New System.Drawing.Size(39, 13)
        Me.lblGrade1.TabIndex = 3
        Me.lblGrade1.Text = "Grade:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(9, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(87, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Classroom name:"
        '
        'lblClassNum
        '
        Me.lblClassNum.AutoSize = True
        Me.lblClassNum.Location = New System.Drawing.Point(208, 75)
        Me.lblClassNum.Name = "lblClassNum"
        Me.lblClassNum.Size = New System.Drawing.Size(45, 13)
        Me.lblClassNum.TabIndex = 5
        Me.lblClassNum.Text = "Class #:"
        '
        'txtClassNum
        '
        Me.txtClassNum.Location = New System.Drawing.Point(259, 75)
        Me.txtClassNum.MaxLength = 2
        Me.txtClassNum.Name = "txtClassNum"
        Me.txtClassNum.Size = New System.Drawing.Size(24, 20)
        Me.txtClassNum.TabIndex = 6
        '
        'RangeValidator
        '
        Me.RangeValidator.ControlToValidate = Me.txtClassNum
        Me.RangeValidator.DataType = MPR.Windows.Forms.Validation.ValidationDataType.[Integer]
        Me.RangeValidator.ErrorMessage = "Classroom Number must be between 1 and 99"
        Me.RangeValidator.Icon = CType(resources.GetObject("RangeValidator.Icon"), System.Drawing.Icon)
        Me.RangeValidator.MaximumValue = "99"
        Me.RangeValidator.MinimumValue = "1"
        '
        'grpMobility
        '
        Me.grpMobility.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMobility.Controls.Add(Me.vwMobility)
        Me.grpMobility.Location = New System.Drawing.Point(3, 101)
        Me.grpMobility.Name = "grpMobility"
        Me.grpMobility.Size = New System.Drawing.Size(280, 152)
        Me.grpMobility.TabIndex = 7
        Me.grpMobility.TabStop = False
        Me.grpMobility.Text = "Teacher mobility history:"
        '
        'grpStudents
        '
        Me.grpStudents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStudents.Controls.Add(Me.vwStudents)
        Me.grpStudents.Location = New System.Drawing.Point(473, 6)
        Me.grpStudents.Name = "grpStudents"
        Me.grpStudents.Size = New System.Drawing.Size(194, 247)
        Me.grpStudents.TabIndex = 9
        Me.grpStudents.TabStop = False
        Me.grpStudents.Text = "Students:"
        '
        'grpTeachers
        '
        Me.grpTeachers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpTeachers.Controls.Add(Me.vwTeachers)
        Me.grpTeachers.Controls.Add(Me.btnEdit)
        Me.grpTeachers.Controls.Add(Me.btnAdd)
        Me.grpTeachers.Location = New System.Drawing.Point(289, 101)
        Me.grpTeachers.Name = "grpTeachers"
        Me.grpTeachers.Size = New System.Drawing.Size(178, 152)
        Me.grpTeachers.TabIndex = 8
        Me.grpTeachers.TabStop = False
        Me.grpTeachers.Text = "Teachers:"
        '
        'vwTeachers
        '
        Me.vwTeachers.AllowUserToAddRows = False
        Me.vwTeachers.AllowUserToDeleteRows = False
        Me.vwTeachers.AllowUserToOrderColumns = True
        Me.vwTeachers.AllowUserToResizeRows = False
        Me.vwTeachers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwTeachers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.vwTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.vwTeachers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TeacherID, Me.TeacherName})
        Me.vwTeachers.Location = New System.Drawing.Point(6, 17)
        Me.vwTeachers.MultiSelect = False
        Me.vwTeachers.Name = "vwTeachers"
        Me.vwTeachers.ReadOnly = True
        Me.vwTeachers.RowHeadersVisible = False
        Me.vwTeachers.RowTemplate.Height = 17
        Me.vwTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.vwTeachers.Size = New System.Drawing.Size(166, 97)
        Me.vwTeachers.TabIndex = 0
        '
        'TeacherID
        '
        Me.TeacherID.HeaderText = "TeacherID"
        Me.TeacherID.Name = "TeacherID"
        Me.TeacherID.ReadOnly = True
        Me.TeacherID.ToolTipText = "TeacherID"
        Me.TeacherID.Visible = False
        Me.TeacherID.Width = 70
        '
        'TeacherName
        '
        Me.TeacherName.HeaderText = "Teacher Name"
        Me.TeacherName.Name = "TeacherName"
        Me.TeacherName.ReadOnly = True
        Me.TeacherName.ToolTipText = "Teacher's Name"
        Me.TeacherName.Width = 145
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 0
        Me.btnEdit.ImageList = Me.imlEditClassroom15
        Me.btnEdit.Location = New System.Drawing.Point(87, 120)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit..."
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'imlEditClassroom15
        '
        Me.imlEditClassroom15.ImageStream = CType(resources.GetObject("imlEditClassroom15.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlEditClassroom15.TransparentColor = System.Drawing.Color.White
        Me.imlEditClassroom15.Images.SetKeyName(0, "update.bmp")
        Me.imlEditClassroom15.Images.SetKeyName(1, "insert.bmp")
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.ImageIndex = 1
        Me.btnAdd.ImageList = Me.imlEditClassroom15
        Me.btnAdd.Location = New System.Drawing.Point(6, 120)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'vwStudents
        '
        Me.vwStudents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwStudents.DataSource = Nothing
        Me.vwStudents.DoubleClickColumn = 0
        Me.vwStudents.Location = New System.Drawing.Point(6, 17)
        Me.vwStudents.MultiSelect = True
        Me.vwStudents.Name = "vwStudents"
        Me.vwStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwStudents.Size = New System.Drawing.Size(181, 219)
        Me.vwStudents.SortedColumn = Nothing
        Me.vwStudents.TabIndex = 0
        '
        'vwMobility
        '
        Me.vwMobility.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwMobility.DataSource = Nothing
        Me.vwMobility.DoubleClickColumn = 0
        Me.vwMobility.Location = New System.Drawing.Point(6, 17)
        Me.vwMobility.MultiSelect = True
        Me.vwMobility.Name = "vwMobility"
        Me.vwMobility.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
        Me.vwMobility.Size = New System.Drawing.Size(267, 124)
        Me.vwMobility.SortedColumn = Nothing
        Me.vwMobility.TabIndex = 0
        '
        'cboSchool
        '
        Me.cboSchool.Location = New System.Drawing.Point(9, 45)
        Me.cboSchool.MyLabel = "School:"
        Me.cboSchool.Name = "cboSchool"
        Me.cboSchool.SelectedSchool = Nothing
        Me.cboSchool.SelectedSchoolID = 0
        Me.cboSchool.Size = New System.Drawing.Size(274, 24)
        Me.cboSchool.TabIndex = 2
        '
        'txtGrade
        '
        Me.txtGrade.AllowGrade0 = False
        Me.txtGrade.AllowGradeK = True
        Me.txtGrade.AllowGradePK = True
        Me.txtGrade.Location = New System.Drawing.Point(97, 75)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.ReadOnly = False
        Me.txtGrade.Required = False
        Me.txtGrade.Size = New System.Drawing.Size(40, 20)
        Me.txtGrade.TabIndex = 4
        '
        'EditClassroom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.grpTeachers)
        Me.Controls.Add(Me.grpStudents)
        Me.Controls.Add(Me.grpMobility)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblClassNum)
        Me.Controls.Add(Me.txtClassNum)
        Me.Controls.Add(Me.cboSchool)
        Me.Controls.Add(Me.txtGrade)
        Me.Controls.Add(Me.lblGrade1)
        Me.Controls.Add(Me.lblName)
        Me.Name = "EditClassroom"
        Me.Size = New System.Drawing.Size(670, 259)
        CType(Me.RangeValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMobility.ResumeLayout(False)
        Me.grpStudents.ResumeLayout(False)
        Me.grpTeachers.ResumeLayout(False)
        CType(Me.vwTeachers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGrade1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtGrade As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboSchool As MPR.SMS.UserControls.SchoolComboBox
    Friend WithEvents lblClassNum As System.Windows.Forms.Label
    Friend WithEvents txtClassNum As System.Windows.Forms.TextBox
    Friend WithEvents RangeValidator As MPR.Windows.Forms.Validation.RangeValidator
    Friend WithEvents grpMobility As System.Windows.Forms.GroupBox
    Friend WithEvents vwMobility As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents grpStudents As System.Windows.Forms.GroupBox
    Friend WithEvents vwStudents As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents grpTeachers As System.Windows.Forms.GroupBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents vwTeachers As System.Windows.Forms.DataGridView
    Friend WithEvents TeacherID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeacherName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imlEditClassroom15 As System.Windows.Forms.ImageList

End Class
