'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStudentEntry))
        Me.btnAddUpdate = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.grpSchool = New System.Windows.Forms.GroupBox()
        Me.cboSchools = New MPR.SMS.UserControls.SchoolComboBox()
        Me.cboDistrict = New MPR.SMS.UserControls.DistrictComboBox()
        Me.lvwCases = New System.Windows.Forms.ListView()
        Me.chCaseID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStudent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chParent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStudentNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chSelection = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPhone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpSession = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblGrade = New System.Windows.Forms.Label()
        Me.txtPFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSex = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.grpSampling = New System.Windows.Forms.GroupBox()
        Me.optReplacement = New System.Windows.Forms.RadioButton()
        Me.optMain = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSelOrder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStudentNum = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPMiddleName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.grpStudent = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDOB = New MPR.SMS.UserControls.DateWithValidator()
        Me.txtGrade = New MPR.SMS.UserControls.GradeWithValidator()
        Me.grpParent = New System.Windows.Forms.GroupBox()
        Me.cboRelation = New MPR.SMS.UserControls.RelationshipTypeComboBox()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.txtZIP = New MPR.SMS.UserControls.ZipCodeWithValidator()
        Me.cboState = New MPR.SMS.UserControls.StateComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New MPR.SMS.UserControls.PhoneWithValidator()
        Me.txtSecondaryPhoneNum = New MPR.SMS.UserControls.PhoneWithValidator()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator()
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary()
        Me.RequiredFieldLastName = New MPR.Windows.Forms.Validation.RequiredFieldValidator()
        Me.grpSchool.SuspendLayout()
        Me.grpSession.SuspendLayout()
        Me.grpSampling.SuspendLayout()
        Me.grpStudent.SuspendLayout()
        Me.grpParent.SuspendLayout()
        Me.grpContact.SuspendLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RequiredFieldLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddUpdate
        '
        Me.btnAddUpdate.Enabled = False
        Me.btnAddUpdate.Location = New System.Drawing.Point(180, 310)
        Me.btnAddUpdate.Name = "btnAddUpdate"
        Me.btnAddUpdate.Size = New System.Drawing.Size(88, 24)
        Me.btnAddUpdate.TabIndex = 5
        Me.btnAddUpdate.Text = "&Add"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(348, 310)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(88, 24)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "&Close"
        '
        'grpSchool
        '
        Me.grpSchool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSchool.Controls.Add(Me.cboSchools)
        Me.grpSchool.Controls.Add(Me.cboDistrict)
        Me.grpSchool.Location = New System.Drawing.Point(8, 0)
        Me.grpSchool.Name = "grpSchool"
        Me.grpSchool.Size = New System.Drawing.Size(600, 72)
        Me.grpSchool.TabIndex = 0
        Me.grpSchool.TabStop = False
        '
        'cboSchools
        '
        Me.cboSchools.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSchools.DistrictIDFilter = -1
        Me.cboSchools.Location = New System.Drawing.Point(8, 40)
        Me.cboSchools.MyLabel = "School:"
        Me.cboSchools.Name = "cboSchools"
        Me.cboSchools.SelectedSchool = Nothing
        Me.cboSchools.SelectedSchoolID = 0
        Me.cboSchools.Size = New System.Drawing.Size(574, 21)
        Me.cboSchools.TabIndex = 2
        '
        'cboDistrict
        '
        Me.cboDistrict.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDistrict.Location = New System.Drawing.Point(8, 16)
        Me.cboDistrict.MyLabel = "District:"
        Me.cboDistrict.Name = "cboDistrict"
        Me.cboDistrict.SelectedDistrict = Nothing
        Me.cboDistrict.SelectedDistrictID = 0
        Me.cboDistrict.SiteIDFilter = -1
        Me.cboDistrict.Size = New System.Drawing.Size(574, 21)
        Me.cboDistrict.TabIndex = 1
        '
        'lvwCases
        '
        Me.lvwCases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwCases.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCaseID, Me.chStudent, Me.chParent, Me.chStudentNum, Me.chSelection, Me.chPhone})
        Me.lvwCases.Location = New System.Drawing.Point(8, 16)
        Me.lvwCases.Name = "lvwCases"
        Me.lvwCases.Size = New System.Drawing.Size(584, 121)
        Me.lvwCases.TabIndex = 0
        Me.lvwCases.TabStop = False
        Me.lvwCases.UseCompatibleStateImageBehavior = False
        Me.lvwCases.View = System.Windows.Forms.View.Details
        '
        'chCaseID
        '
        Me.chCaseID.Text = "CaseID"
        '
        'chStudent
        '
        Me.chStudent.Text = "Student Name"
        Me.chStudent.Width = 103
        '
        'chParent
        '
        Me.chParent.Text = "Parent Name"
        Me.chParent.Width = 128
        '
        'chStudentNum
        '
        Me.chStudentNum.Text = "Student #"
        Me.chStudentNum.Width = 81
        '
        'chSelection
        '
        Me.chSelection.Text = "Selection"
        Me.chSelection.Width = 92
        '
        'chPhone
        '
        Me.chPhone.Text = "Phone"
        Me.chPhone.Width = 81
        '
        'grpSession
        '
        Me.grpSession.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSession.Controls.Add(Me.lvwCases)
        Me.grpSession.Location = New System.Drawing.Point(8, 340)
        Me.grpSession.Name = "grpSession"
        Me.grpSession.Size = New System.Drawing.Size(600, 145)
        Me.grpSession.TabIndex = 7
        Me.grpSession.TabStop = False
        Me.grpSession.Text = "Students entered this session:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(7, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Postal code:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCity
        '
        Me.txtCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCity.Location = New System.Drawing.Point(77, 60)
        Me.txtCity.MaxLength = 25
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(115, 20)
        Me.txtCity.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(7, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 16)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "City:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(77, 38)
        Me.txtAddress2.MaxLength = 40
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(203, 20)
        Me.txtAddress2.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Address 2:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(77, 16)
        Me.txtAddress1.MaxLength = 40
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(203, 20)
        Me.txtAddress1.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(7, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Address 1:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(48, 24)
        Me.txtFirstName.MaxLength = 20
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(121, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "First:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(48, 48)
        Me.txtLastName.MaxLength = 20
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(121, 20)
        Me.txtLastName.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Last:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(7, 102)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 20)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "Phone (main):"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGrade
        '
        Me.lblGrade.Location = New System.Drawing.Point(175, 48)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(48, 16)
        Me.lblGrade.TabIndex = 6
        Me.lblGrade.Text = "Grade:"
        Me.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPFirstName
        '
        Me.txtPFirstName.Location = New System.Drawing.Point(48, 26)
        Me.txtPFirstName.MaxLength = 20
        Me.txtPFirstName.Name = "txtPFirstName"
        Me.txtPFirstName.Size = New System.Drawing.Size(121, 20)
        Me.txtPFirstName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPLastName
        '
        Me.txtPLastName.Location = New System.Drawing.Point(48, 47)
        Me.txtPLastName.MaxLength = 20
        Me.txtPLastName.Name = "txtPLastName"
        Me.txtPLastName.Size = New System.Drawing.Size(121, 20)
        Me.txtPLastName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Last:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSex
        '
        Me.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSex.ItemHeight = 13
        Me.cboSex.Items.AddRange(New Object() {"", "M", "F"})
        Me.cboSex.Location = New System.Drawing.Point(222, 73)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(42, 21)
        Me.cboSex.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(175, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Gender:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(175, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Middle:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(222, 24)
        Me.txtMiddleName.MaxLength = 20
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(58, 20)
        Me.txtMiddleName.TabIndex = 3
        '
        'grpSampling
        '
        Me.grpSampling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSampling.Controls.Add(Me.optReplacement)
        Me.grpSampling.Controls.Add(Me.optMain)
        Me.grpSampling.Controls.Add(Me.Label13)
        Me.grpSampling.Controls.Add(Me.txtSelOrder)
        Me.grpSampling.Controls.Add(Me.Label3)
        Me.grpSampling.Controls.Add(Me.txtStudentNum)
        Me.grpSampling.Controls.Add(Me.Label9)
        Me.grpSampling.Location = New System.Drawing.Point(304, 224)
        Me.grpSampling.Name = "grpSampling"
        Me.grpSampling.Size = New System.Drawing.Size(304, 80)
        Me.grpSampling.TabIndex = 4
        Me.grpSampling.TabStop = False
        Me.grpSampling.Text = "Sampling:"
        '
        'optReplacement
        '
        Me.optReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optReplacement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optReplacement.Location = New System.Drawing.Point(200, 52)
        Me.optReplacement.Name = "optReplacement"
        Me.optReplacement.Size = New System.Drawing.Size(94, 16)
        Me.optReplacement.TabIndex = 6
        Me.optReplacement.Text = "&Replacement"
        '
        'optMain
        '
        Me.optMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optMain.Checked = True
        Me.optMain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optMain.Location = New System.Drawing.Point(200, 35)
        Me.optMain.Name = "optMain"
        Me.optMain.Size = New System.Drawing.Size(80, 16)
        Me.optMain.TabIndex = 5
        Me.optMain.TabStop = True
        Me.optMain.Text = "&Main"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(197, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Selection type:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSelOrder
        '
        Me.txtSelOrder.Location = New System.Drawing.Point(98, 47)
        Me.txtSelOrder.MaxLength = 3
        Me.txtSelOrder.Name = "txtSelOrder"
        Me.txtSelOrder.Size = New System.Drawing.Size(49, 20)
        Me.txtSelOrder.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(7, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Selection order:"
        '
        'txtStudentNum
        '
        Me.txtStudentNum.Location = New System.Drawing.Point(98, 24)
        Me.txtStudentNum.MaxLength = 10
        Me.txtStudentNum.Name = "txtStudentNum"
        Me.txtStudentNum.Size = New System.Drawing.Size(93, 20)
        Me.txtStudentNum.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Student number:"
        '
        'txtPMiddleName
        '
        Me.txtPMiddleName.Location = New System.Drawing.Point(222, 26)
        Me.txtPMiddleName.MaxLength = 1
        Me.txtPMiddleName.Name = "txtPMiddleName"
        Me.txtPMiddleName.Size = New System.Drawing.Size(58, 20)
        Me.txtPMiddleName.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(175, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Middle:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpStudent
        '
        Me.grpStudent.Controls.Add(Me.Label4)
        Me.grpStudent.Controls.Add(Me.Label7)
        Me.grpStudent.Controls.Add(Me.txtDOB)
        Me.grpStudent.Controls.Add(Me.txtLastName)
        Me.grpStudent.Controls.Add(Me.txtMiddleName)
        Me.grpStudent.Controls.Add(Me.Label12)
        Me.grpStudent.Controls.Add(Me.Label6)
        Me.grpStudent.Controls.Add(Me.cboSex)
        Me.grpStudent.Controls.Add(Me.Label11)
        Me.grpStudent.Controls.Add(Me.txtFirstName)
        Me.grpStudent.Controls.Add(Me.txtGrade)
        Me.grpStudent.Controls.Add(Me.lblGrade)
        Me.grpStudent.Location = New System.Drawing.Point(8, 82)
        Me.grpStudent.Name = "grpStudent"
        Me.grpStudent.Size = New System.Drawing.Size(290, 110)
        Me.grpStudent.TabIndex = 1
        Me.grpStudent.TabStop = False
        Me.grpStudent.Text = "Student:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "DOB:"
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(48, 74)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.ReadOnly = False
        Me.txtDOB.Required = False
        Me.txtDOB.Size = New System.Drawing.Size(86, 20)
        Me.txtDOB.TabIndex = 9
        Me.txtDOB.UseMask = True
        '
        'txtGrade
        '
        Me.txtGrade.AllowGrade0 = False
        Me.txtGrade.AllowGradeK = True
        Me.txtGrade.AllowGradePK = True
        Me.txtGrade.Location = New System.Drawing.Point(222, 48)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.ReadOnly = False
        Me.txtGrade.Required = False
        Me.txtGrade.Size = New System.Drawing.Size(42, 20)
        Me.txtGrade.TabIndex = 7
        '
        'grpParent
        '
        Me.grpParent.Controls.Add(Me.txtPFirstName)
        Me.grpParent.Controls.Add(Me.Label1)
        Me.grpParent.Controls.Add(Me.txtPLastName)
        Me.grpParent.Controls.Add(Me.Label2)
        Me.grpParent.Controls.Add(Me.txtPMiddleName)
        Me.grpParent.Controls.Add(Me.Label14)
        Me.grpParent.Controls.Add(Me.cboRelation)
        Me.grpParent.Location = New System.Drawing.Point(8, 198)
        Me.grpParent.Name = "grpParent"
        Me.grpParent.Size = New System.Drawing.Size(290, 106)
        Me.grpParent.TabIndex = 2
        Me.grpParent.TabStop = False
        Me.grpParent.Text = "Parent:"
        '
        'cboRelation
        '
        Me.cboRelation.EntityTypeFilter = MPR.SMS.Data.Enumerations.tlkpEntityType.None
        Me.cboRelation.Location = New System.Drawing.Point(8, 76)
        Me.cboRelation.MyLabel = "Relation to child:"
        Me.cboRelation.Name = "cboRelation"
        Me.cboRelation.SelectedRelationshipType = Nothing
        Me.cboRelation.SelectedRelationshipTypeID = 0
        Me.cboRelation.Size = New System.Drawing.Size(256, 24)
        Me.cboRelation.TabIndex = 6
        '
        'grpContact
        '
        Me.grpContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContact.Controls.Add(Me.txtCity)
        Me.grpContact.Controls.Add(Me.txtZIP)
        Me.grpContact.Controls.Add(Me.cboState)
        Me.grpContact.Controls.Add(Me.Label18)
        Me.grpContact.Controls.Add(Me.Label17)
        Me.grpContact.Controls.Add(Me.txtAddress2)
        Me.grpContact.Controls.Add(Me.Label16)
        Me.grpContact.Controls.Add(Me.txtAddress1)
        Me.grpContact.Controls.Add(Me.Label15)
        Me.grpContact.Controls.Add(Me.txtPhoneNumber)
        Me.grpContact.Controls.Add(Me.Label19)
        Me.grpContact.Controls.Add(Me.Label26)
        Me.grpContact.Controls.Add(Me.txtSecondaryPhoneNum)
        Me.grpContact.Controls.Add(Me.Label20)
        Me.grpContact.Location = New System.Drawing.Point(304, 82)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(304, 136)
        Me.grpContact.TabIndex = 3
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Contact information:"
        '
        'txtZIP
        '
        Me.txtZIP.Location = New System.Drawing.Point(77, 82)
        Me.txtZIP.Name = "txtZIP"
        Me.txtZIP.ReadOnly = False
        Me.txtZIP.Required = False
        Me.txtZIP.Size = New System.Drawing.Size(96, 20)
        Me.txtZIP.TabIndex = 9
        '
        'cboState
        '
        Me.cboState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboState.Location = New System.Drawing.Point(240, 60)
        Me.cboState.MyLabel = "State:"
        Me.cboState.MyLabelVisible = False
        Me.cboState.Name = "cboState"
        Me.cboState.SelectedState = Nothing
        Me.cboState.SelectedStateAbbreviation = "0"
        Me.cboState.SelectedStateID = 0
        Me.cboState.Size = New System.Drawing.Size(40, 21)
        Me.cboState.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(198, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 16)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "State:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(77, 104)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.ReadOnly = False
        Me.txtPhoneNumber.Required = False
        Me.txtPhoneNumber.Size = New System.Drawing.Size(96, 20)
        Me.txtPhoneNumber.TabIndex = 11
        Me.txtPhoneNumber.TextFormatted = ""
        Me.txtPhoneNumber.UseMask = True
        '
        'txtSecondaryPhoneNum
        '
        Me.txtSecondaryPhoneNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSecondaryPhoneNum.Location = New System.Drawing.Point(200, 104)
        Me.txtSecondaryPhoneNum.Name = "txtSecondaryPhoneNum"
        Me.txtSecondaryPhoneNum.ReadOnly = False
        Me.txtSecondaryPhoneNum.Required = False
        Me.txtSecondaryPhoneNum.Size = New System.Drawing.Size(96, 20)
        Me.txtSecondaryPhoneNum.TabIndex = 13
        Me.txtSecondaryPhoneNum.TextFormatted = ""
        Me.txtSecondaryPhoneNum.UseMask = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(174, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 21)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "(alt):"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        '
        'RequiredFieldLastName
        '
        Me.RequiredFieldLastName.ControlToValidate = Me.txtLastName
        Me.RequiredFieldLastName.ErrorMessage = "Last name is required"
        Me.RequiredFieldLastName.Icon = CType(resources.GetObject("RequiredFieldLastName.Icon"), System.Drawing.Icon)
        Me.RequiredFieldLastName.Required = True
        '
        'frmStudentEntry
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 497)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.grpParent)
        Me.Controls.Add(Me.grpStudent)
        Me.Controls.Add(Me.grpSampling)
        Me.Controls.Add(Me.grpSession)
        Me.Controls.Add(Me.grpSchool)
        Me.Controls.Add(Me.btnAddUpdate)
        Me.Controls.Add(Me.grpContact)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStudentEntry"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Student Entry"
        Me.grpSchool.ResumeLayout(False)
        Me.grpSession.ResumeLayout(False)
        Me.grpSampling.ResumeLayout(False)
        Me.grpSampling.PerformLayout()
        Me.grpStudent.ResumeLayout(False)
        Me.grpStudent.PerformLayout()
        Me.grpParent.ResumeLayout(False)
        Me.grpParent.PerformLayout()
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RequiredFieldLastName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents cmdExit As System.Windows.Forms.Button
    Protected WithEvents btnAddUpdate As System.Windows.Forms.Button
    Friend WithEvents grpSchool As System.Windows.Forms.GroupBox
    Friend WithEvents grpSession As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrict As MPR.SMS.UserControls.DistrictComboBox
    Friend WithEvents cboSchools As MPR.SMS.UserControls.SchoolComboBox
    Protected WithEvents txtZIP As MPR.SMS.UserControls.ZipCodeWithValidator
    Protected WithEvents Label19 As System.Windows.Forms.Label
    Protected WithEvents cboState As MPR.SMS.UserControls.StateComboBox
    Protected WithEvents txtCity As System.Windows.Forms.TextBox
    Protected WithEvents Label17 As System.Windows.Forms.Label
    Protected WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Protected WithEvents Label16 As System.Windows.Forms.Label
    Protected WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents txtFirstName As System.Windows.Forms.TextBox
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents txtLastName As System.Windows.Forms.TextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents txtPhoneNumber As MPR.SMS.UserControls.PhoneWithValidator
    Protected WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblGrade As System.Windows.Forms.Label
    Protected WithEvents txtPFirstName As System.Windows.Forms.TextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents txtPLastName As System.Windows.Forms.TextBox
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGrade As MPR.SMS.UserControls.GradeWithValidator
    Friend WithEvents chCaseID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStudent As System.Windows.Forms.ColumnHeader
    Friend WithEvents chParent As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStudentNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSelection As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPhone As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwCases As System.Windows.Forms.ListView
    Protected WithEvents cboSex As System.Windows.Forms.ComboBox
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboRelation As MPR.SMS.UserControls.RelationshipTypeComboBox
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpSampling As System.Windows.Forms.GroupBox
    Friend WithEvents txtStudentNum As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSelOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents optMain As System.Windows.Forms.RadioButton
    Friend WithEvents optReplacement As System.Windows.Forms.RadioButton
    Protected WithEvents Label14 As System.Windows.Forms.Label
    Protected WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Protected WithEvents txtPMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents grpStudent As System.Windows.Forms.GroupBox
    Friend WithEvents grpParent As System.Windows.Forms.GroupBox
    Friend WithEvents grpContact As System.Windows.Forms.GroupBox
    Protected WithEvents Label20 As System.Windows.Forms.Label
    Protected WithEvents txtSecondaryPhoneNum As MPR.SMS.UserControls.PhoneWithValidator
    Friend WithEvents txtDOB As MPR.SMS.UserControls.DateWithValidator
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Label18 As System.Windows.Forms.Label
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents RequiredFieldLastName As MPR.Windows.Forms.Validation.RequiredFieldValidator

End Class
