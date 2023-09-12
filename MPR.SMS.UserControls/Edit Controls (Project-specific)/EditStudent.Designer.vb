'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditStudent
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
        Me.grpBaseline = New System.Windows.Forms.GroupBox
        Me.lblClassroomBaseline = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtGradeBaseline = New MPR.SMS.UserControls.GradeWithValidator
        Me.lblGradeBaseline = New System.Windows.Forms.Label
        Me.lblGrade1 = New System.Windows.Forms.Label
        Me.lblSelectionOrder = New System.Windows.Forms.Label
        Me.txtSelOrder = New System.Windows.Forms.TextBox
        Me.lblSchool = New System.Windows.Forms.Label
        Me.grpMobility = New System.Windows.Forms.GroupBox
        Me.vwMobility = New MPR.SMS.UserControls.ViewDataSet
        Me.lnkClassroom = New System.Windows.Forms.LinkLabel
        Me.lblClassroom = New System.Windows.Forms.Label
        Me.lnkSchool = New System.Windows.Forms.LinkLabel
        Me.cboAssignmentType = New MPR.SMS.UserControls.AssignmentTypeComboBox
        Me.PersonName = New MPR.SMS.UserControls.EditPersonName
        Me.txtGrade = New MPR.SMS.UserControls.GradeWithValidator
        Me.txtClassID = New System.Windows.Forms.TextBox
        Me.txtSchoolID = New System.Windows.Forms.TextBox
        Me.grpBaseline.SuspendLayout()
        Me.grpMobility.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBaseline
        '
        Me.grpBaseline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBaseline.Controls.Add(Me.lblClassroomBaseline)
        Me.grpBaseline.Controls.Add(Me.Label1)
        Me.grpBaseline.Controls.Add(Me.txtGradeBaseline)
        Me.grpBaseline.Controls.Add(Me.lblGradeBaseline)
        Me.grpBaseline.Location = New System.Drawing.Point(9, 125)
        Me.grpBaseline.Name = "grpBaseline"
        Me.grpBaseline.Size = New System.Drawing.Size(481, 48)
        Me.grpBaseline.TabIndex = 10
        Me.grpBaseline.TabStop = False
        Me.grpBaseline.Text = "Baseline:"
        '
        'lblClassroomBaseline
        '
        Me.lblClassroomBaseline.AutoSize = True
        Me.lblClassroomBaseline.Location = New System.Drawing.Point(324, 19)
        Me.lblClassroomBaseline.Name = "lblClassroomBaseline"
        Me.lblClassroomBaseline.Size = New System.Drawing.Size(73, 13)
        Me.lblClassroomBaseline.TabIndex = 3
        Me.lblClassroomBaseline.Text = "<unassigned>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(238, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Classroom:"
        '
        'txtGradeBaseline
        '
        Me.txtGradeBaseline.AllowGrade0 = False
        Me.txtGradeBaseline.AllowGradeK = True
        Me.txtGradeBaseline.AllowGradePK = True
        Me.txtGradeBaseline.Location = New System.Drawing.Point(74, 19)
        Me.txtGradeBaseline.Name = "txtGradeBaseline"
        Me.txtGradeBaseline.ReadOnly = False
        Me.txtGradeBaseline.Required = False
        Me.txtGradeBaseline.Size = New System.Drawing.Size(40, 20)
        Me.txtGradeBaseline.TabIndex = 1
        '
        'lblGradeBaseline
        '
        Me.lblGradeBaseline.AutoSize = True
        Me.lblGradeBaseline.Location = New System.Drawing.Point(6, 19)
        Me.lblGradeBaseline.Name = "lblGradeBaseline"
        Me.lblGradeBaseline.Size = New System.Drawing.Size(39, 13)
        Me.lblGradeBaseline.TabIndex = 0
        Me.lblGradeBaseline.Text = "Grade:"
        '
        'lblGrade1
        '
        Me.lblGrade1.AutoSize = True
        Me.lblGrade1.Location = New System.Drawing.Point(15, 69)
        Me.lblGrade1.Name = "lblGrade1"
        Me.lblGrade1.Size = New System.Drawing.Size(39, 13)
        Me.lblGrade1.TabIndex = 1
        Me.lblGrade1.Text = "Grade:"
        '
        'lblSelectionOrder
        '
        Me.lblSelectionOrder.AutoSize = True
        Me.lblSelectionOrder.Location = New System.Drawing.Point(129, 69)
        Me.lblSelectionOrder.Name = "lblSelectionOrder"
        Me.lblSelectionOrder.Size = New System.Drawing.Size(81, 13)
        Me.lblSelectionOrder.TabIndex = 3
        Me.lblSelectionOrder.Text = "Selection order:"
        '
        'txtSelOrder
        '
        Me.txtSelOrder.Location = New System.Drawing.Point(217, 69)
        Me.txtSelOrder.Name = "txtSelOrder"
        Me.txtSelOrder.Size = New System.Drawing.Size(24, 20)
        Me.txtSelOrder.TabIndex = 4
        '
        'lblSchool
        '
        Me.lblSchool.AutoSize = True
        Me.lblSchool.Location = New System.Drawing.Point(15, 95)
        Me.lblSchool.Name = "lblSchool"
        Me.lblSchool.Size = New System.Drawing.Size(43, 13)
        Me.lblSchool.TabIndex = 6
        Me.lblSchool.Text = "School:"
        '
        'grpMobility
        '
        Me.grpMobility.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMobility.Controls.Add(Me.vwMobility)
        Me.grpMobility.Location = New System.Drawing.Point(496, 3)
        Me.grpMobility.Name = "grpMobility"
        Me.grpMobility.Size = New System.Drawing.Size(150, 170)
        Me.grpMobility.TabIndex = 11
        Me.grpMobility.TabStop = False
        Me.grpMobility.Text = "Student mobility history:"
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
        Me.vwMobility.Size = New System.Drawing.Size(137, 142)
        Me.vwMobility.SortedColumn = Nothing
        Me.vwMobility.TabIndex = 0
        '
        'lnkClassroom
        '
        Me.lnkClassroom.AutoSize = True
        Me.lnkClassroom.Location = New System.Drawing.Point(333, 96)
        Me.lnkClassroom.Name = "lnkClassroom"
        Me.lnkClassroom.Size = New System.Drawing.Size(73, 13)
        Me.lnkClassroom.TabIndex = 9
        Me.lnkClassroom.TabStop = True
        Me.lnkClassroom.Text = "<unassigned>"
        '
        'lblClassroom
        '
        Me.lblClassroom.AutoSize = True
        Me.lblClassroom.Location = New System.Drawing.Point(247, 95)
        Me.lblClassroom.Name = "lblClassroom"
        Me.lblClassroom.Size = New System.Drawing.Size(58, 13)
        Me.lblClassroom.TabIndex = 8
        Me.lblClassroom.Text = "Classroom:"
        '
        'lnkSchool
        '
        Me.lnkSchool.AutoSize = True
        Me.lnkSchool.Location = New System.Drawing.Point(80, 96)
        Me.lnkSchool.Name = "lnkSchool"
        Me.lnkSchool.Size = New System.Drawing.Size(73, 13)
        Me.lnkSchool.TabIndex = 7
        Me.lnkSchool.TabStop = True
        Me.lnkSchool.Text = "<unassigned>"
        '
        'cboAssignmentType
        '
        Me.cboAssignmentType.Location = New System.Drawing.Point(247, 69)
        Me.cboAssignmentType.MyLabel = "Assignment:"
        Me.cboAssignmentType.Name = "cboAssignmentType"
        Me.cboAssignmentType.SelectedAssignmentCode = "0"
        Me.cboAssignmentType.SelectedAssignmentType = Nothing
        Me.cboAssignmentType.SelectedAssignmentTypeID = 0
        Me.cboAssignmentType.Size = New System.Drawing.Size(231, 24)
        Me.cboAssignmentType.TabIndex = 5
        '
        'PersonName
        '
        Me.PersonName.Location = New System.Drawing.Point(9, 4)
        Me.PersonName.Name = "PersonName"
        Me.PersonName.Person = Nothing
        Me.PersonName.ReadOnly = True
        Me.PersonName.Size = New System.Drawing.Size(481, 59)
        Me.PersonName.TabIndex = 0
        Me.PersonName.TabStop = False
        '
        'txtGrade
        '
        Me.txtGrade.AllowGrade0 = False
        Me.txtGrade.AllowGradeK = True
        Me.txtGrade.AllowGradePK = True
        Me.txtGrade.Location = New System.Drawing.Point(83, 69)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.ReadOnly = False
        Me.txtGrade.Required = False
        Me.txtGrade.Size = New System.Drawing.Size(40, 20)
        Me.txtGrade.TabIndex = 2
        '
        'txtClassID
        '
        Me.txtClassID.Location = New System.Drawing.Point(449, 95)
        Me.txtClassID.Name = "txtClassID"
        Me.txtClassID.Size = New System.Drawing.Size(29, 20)
        Me.txtClassID.TabIndex = 12
        Me.txtClassID.Text = "0"
        Me.txtClassID.Visible = False
        '
        'txtSchoolID
        '
        Me.txtSchoolID.Location = New System.Drawing.Point(212, 96)
        Me.txtSchoolID.Name = "txtSchoolID"
        Me.txtSchoolID.Size = New System.Drawing.Size(29, 20)
        Me.txtSchoolID.TabIndex = 13
        Me.txtSchoolID.Text = "0"
        Me.txtSchoolID.Visible = False
        '
        'EditStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtSchoolID)
        Me.Controls.Add(Me.txtClassID)
        Me.Controls.Add(Me.lnkSchool)
        Me.Controls.Add(Me.lblClassroom)
        Me.Controls.Add(Me.lnkClassroom)
        Me.Controls.Add(Me.grpMobility)
        Me.Controls.Add(Me.lblSchool)
        Me.Controls.Add(Me.cboAssignmentType)
        Me.Controls.Add(Me.txtSelOrder)
        Me.Controls.Add(Me.lblSelectionOrder)
        Me.Controls.Add(Me.PersonName)
        Me.Controls.Add(Me.grpBaseline)
        Me.Controls.Add(Me.txtGrade)
        Me.Controls.Add(Me.lblGrade1)
        Me.Name = "EditStudent"
        Me.Size = New System.Drawing.Size(652, 182)
        Me.grpBaseline.ResumeLayout(False)
        Me.grpBaseline.PerformLayout()
        Me.grpMobility.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpBaseline As System.Windows.Forms.GroupBox
    Friend WithEvents lblGrade1 As System.Windows.Forms.Label
    Friend WithEvents txtGrade As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents txtGradeBaseline As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents lblGradeBaseline As System.Windows.Forms.Label
    Friend WithEvents PersonName As MPR.SMS.UserControls.EditPersonName
    Friend WithEvents lblSelectionOrder As System.Windows.Forms.Label
    Friend WithEvents txtSelOrder As System.Windows.Forms.TextBox
    Friend WithEvents cboAssignmentType As MPR.SMS.UserControls.AssignmentTypeComboBox
    Friend WithEvents lblSchool As System.Windows.Forms.Label
    Friend WithEvents grpMobility As System.Windows.Forms.GroupBox
    Friend WithEvents vwMobility As MPR.SMS.UserControls.ViewDataSet
    Friend WithEvents lnkClassroom As System.Windows.Forms.LinkLabel
    Friend WithEvents lblClassroom As System.Windows.Forms.Label
    Friend WithEvents lnkSchool As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblClassroomBaseline As System.Windows.Forms.Label
    Friend WithEvents txtClassID As System.Windows.Forms.TextBox
    Friend WithEvents txtSchoolID As System.Windows.Forms.TextBox

End Class
