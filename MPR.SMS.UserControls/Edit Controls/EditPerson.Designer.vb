'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditPerson
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPerson))
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox()
        Me.txtLexID = New System.Windows.Forms.TextBox()
        Me.lblLexID = New System.Windows.Forms.Label()
        Me.btnConsent = New System.Windows.Forms.Button()
        Me.chkIsIneligible = New System.Windows.Forms.CheckBox()
        Me.chkInSample = New System.Windows.Forms.CheckBox()
        Me.btnRace = New System.Windows.Forms.Button()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.txtLangOther = New System.Windows.Forms.TextBox()
        Me.cboLanguage = New MPR.SMS.UserControls.LanguageTypeComboBox()
        Me.lblLang = New System.Windows.Forms.Label()
        Me.lblRelation = New System.Windows.Forms.Label()
        Me.cboRelationship = New MPR.SMS.UserControls.RelationshipTypeComboBox()
        Me.txtDOB = New MPR.SMS.UserControls.DateWithValidator()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtSSN = New MPR.SMS.UserControls.SSNWithValidator()
        Me.lblSSN = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.lblSuffix = New System.Windows.Forms.Label()
        Me.lblLName = New System.Windows.Forms.Label()
        Me.lblMI = New System.Windows.Forms.Label()
        Me.lblFN = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.LastNameValidator = New MPR.Windows.Forms.Validation.RequiredFieldValidator()
        Me.grpUserCtrl.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LastNameValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Controls.Add(Me.txtLexID)
        Me.grpUserCtrl.Controls.Add(Me.lblLexID)
        Me.grpUserCtrl.Controls.Add(Me.btnConsent)
        Me.grpUserCtrl.Controls.Add(Me.chkIsIneligible)
        Me.grpUserCtrl.Controls.Add(Me.chkInSample)
        Me.grpUserCtrl.Controls.Add(Me.btnRace)
        Me.grpUserCtrl.Controls.Add(Me.imgIcon)
        Me.grpUserCtrl.Controls.Add(Me.txtLangOther)
        Me.grpUserCtrl.Controls.Add(Me.cboLanguage)
        Me.grpUserCtrl.Controls.Add(Me.lblLang)
        Me.grpUserCtrl.Controls.Add(Me.lblRelation)
        Me.grpUserCtrl.Controls.Add(Me.cboRelationship)
        Me.grpUserCtrl.Controls.Add(Me.txtDOB)
        Me.grpUserCtrl.Controls.Add(Me.lblDOB)
        Me.grpUserCtrl.Controls.Add(Me.cboGender)
        Me.grpUserCtrl.Controls.Add(Me.lblGender)
        Me.grpUserCtrl.Controls.Add(Me.txtSSN)
        Me.grpUserCtrl.Controls.Add(Me.lblSSN)
        Me.grpUserCtrl.Controls.Add(Me.lblTitle)
        Me.grpUserCtrl.Controls.Add(Me.txtTitle)
        Me.grpUserCtrl.Controls.Add(Me.txtSuffix)
        Me.grpUserCtrl.Controls.Add(Me.txtMName)
        Me.grpUserCtrl.Controls.Add(Me.txtLName)
        Me.grpUserCtrl.Controls.Add(Me.txtFName)
        Me.grpUserCtrl.Controls.Add(Me.lblSuffix)
        Me.grpUserCtrl.Controls.Add(Me.lblLName)
        Me.grpUserCtrl.Controls.Add(Me.lblMI)
        Me.grpUserCtrl.Controls.Add(Me.lblFN)
        Me.grpUserCtrl.Controls.Add(Me.lblName)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(693, 119)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = False
        Me.grpUserCtrl.Text = "Person"
        '
        'txtLexID
        '
        Me.txtLexID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLexID.Location = New System.Drawing.Point(580, 19)
        Me.txtLexID.MaxLength = 15
        Me.txtLexID.Name = "txtLexID"
        Me.txtLexID.Size = New System.Drawing.Size(103, 20)
        Me.txtLexID.TabIndex = 8
        '
        'lblLexID
        '
        Me.lblLexID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLexID.AutoSize = True
        Me.lblLexID.Location = New System.Drawing.Point(538, 19)
        Me.lblLexID.Name = "lblLexID"
        Me.lblLexID.Size = New System.Drawing.Size(44, 13)
        Me.lblLexID.TabIndex = 7
        Me.lblLexID.Text = "LEX ID:"
        '
        'btnConsent
        '
        Me.btnConsent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConsent.Location = New System.Drawing.Point(263, 62)
        Me.btnConsent.Name = "btnConsent"
        Me.btnConsent.Size = New System.Drawing.Size(59, 21)
        Me.btnConsent.TabIndex = 15
        Me.btnConsent.Text = "Consent"
        Me.btnConsent.UseVisualStyleBackColor = True
        '
        'chkIsIneligible
        '
        Me.chkIsIneligible.AutoCheck = False
        Me.chkIsIneligible.AutoSize = True
        Me.chkIsIneligible.Location = New System.Drawing.Point(495, 43)
        Me.chkIsIneligible.Name = "chkIsIneligible"
        Me.chkIsIneligible.Size = New System.Drawing.Size(73, 17)
        Me.chkIsIneligible.TabIndex = 10
        Me.chkIsIneligible.Text = "Ineligible?"
        Me.chkIsIneligible.UseVisualStyleBackColor = True
        '
        'chkInSample
        '
        Me.chkInSample.AutoCheck = False
        Me.chkInSample.AutoSize = True
        Me.chkInSample.Checked = True
        Me.chkInSample.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInSample.Location = New System.Drawing.Point(406, 43)
        Me.chkInSample.Name = "chkInSample"
        Me.chkInSample.Size = New System.Drawing.Size(79, 17)
        Me.chkInSample.TabIndex = 9
        Me.chkInSample.Text = "In Sample?"
        Me.chkInSample.UseVisualStyleBackColor = True
        '
        'btnRace
        '
        Me.btnRace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRace.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRace.Location = New System.Drawing.Point(495, 62)
        Me.btnRace.Name = "btnRace"
        Me.btnRace.Size = New System.Drawing.Size(188, 20)
        Me.btnRace.TabIndex = 18
        Me.btnRace.Text = "Race/Ethnicity"
        Me.btnRace.UseVisualStyleBackColor = True
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(48, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 14)
        Me.imgIcon.TabIndex = 5
        Me.imgIcon.TabStop = False
        '
        'txtLangOther
        '
        Me.txtLangOther.Location = New System.Drawing.Point(215, 88)
        Me.txtLangOther.MaxLength = 50
        Me.txtLangOther.Name = "txtLangOther"
        Me.txtLangOther.Size = New System.Drawing.Size(107, 20)
        Me.txtLangOther.TabIndex = 21
        '
        'cboLanguage
        '
        Me.cboLanguage.Location = New System.Drawing.Point(70, 87)
        Me.cboLanguage.MyLabel = "Language:"
        Me.cboLanguage.MyLabelVisible = False
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.SelectedLanguageType = Nothing
        Me.cboLanguage.SelectedLanguageTypeID = 0
        Me.cboLanguage.Size = New System.Drawing.Size(137, 24)
        Me.cboLanguage.TabIndex = 20
        '
        'lblLang
        '
        Me.lblLang.AutoSize = True
        Me.lblLang.Location = New System.Drawing.Point(6, 88)
        Me.lblLang.Name = "lblLang"
        Me.lblLang.Size = New System.Drawing.Size(58, 13)
        Me.lblLang.TabIndex = 19
        Me.lblLang.Text = "Language:"
        '
        'lblRelation
        '
        Me.lblRelation.AutoSize = True
        Me.lblRelation.Location = New System.Drawing.Point(328, 88)
        Me.lblRelation.Name = "lblRelation"
        Me.lblRelation.Size = New System.Drawing.Size(68, 13)
        Me.lblRelation.TabIndex = 22
        Me.lblRelation.Text = "Relationship:"
        '
        'cboRelationship
        '
        Me.cboRelationship.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRelationship.EntityTypeFilter = MPR.SMS.Data.Enumerations.tlkpEntityType.None
        Me.cboRelationship.Location = New System.Drawing.Point(406, 88)
        Me.cboRelationship.MyLabel = "Relationship:"
        Me.cboRelationship.MyLabelVisible = False
        Me.cboRelationship.Name = "cboRelationship"
        Me.cboRelationship.SelectedRelationshipType = Nothing
        Me.cboRelationship.SelectedRelationshipTypeID = 0
        Me.cboRelationship.Size = New System.Drawing.Size(277, 24)
        Me.cboRelationship.TabIndex = 23
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(406, 62)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.ReadOnly = False
        Me.txtDOB.Required = False
        Me.txtDOB.Size = New System.Drawing.Size(86, 20)
        Me.txtDOB.TabIndex = 17
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Location = New System.Drawing.Point(328, 62)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(68, 13)
        Me.lblDOB.TabIndex = 16
        Me.lblDOB.Text = "Date of birth:"
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"", "M", "F"})
        Me.cboGender.Location = New System.Drawing.Point(215, 62)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(43, 21)
        Me.cboGender.TabIndex = 14
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(172, 62)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(45, 13)
        Me.lblGender.TabIndex = 13
        Me.lblGender.Text = "Gender:"
        '
        'txtSSN
        '
        Me.txtSSN.Location = New System.Drawing.Point(70, 62)
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.ReadOnly = False
        Me.txtSSN.Required = False
        Me.txtSSN.Size = New System.Drawing.Size(104, 20)
        Me.txtSSN.TabIndex = 12
        '
        'lblSSN
        '
        Me.lblSSN.AutoSize = True
        Me.lblSSN.Location = New System.Drawing.Point(5, 62)
        Me.lblSSN.Name = "lblSSN"
        Me.lblSSN.Size = New System.Drawing.Size(32, 13)
        Me.lblSSN.TabIndex = 11
        Me.lblSSN.Text = "SSN:"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(370, 19)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(30, 13)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Title:"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(406, 19)
        Me.txtTitle.MaxLength = 50
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(126, 20)
        Me.txtTitle.TabIndex = 6
        '
        'txtSuffix
        '
        Me.txtSuffix.Location = New System.Drawing.Point(331, 19)
        Me.txtSuffix.MaxLength = 50
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(33, 20)
        Me.txtSuffix.TabIndex = 4
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(164, 19)
        Me.txtMName.MaxLength = 20
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(49, 20)
        Me.txtMName.TabIndex = 2
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(215, 19)
        Me.txtLName.MaxLength = 30
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(108, 20)
        Me.txtLName.TabIndex = 3
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(70, 19)
        Me.txtFName.MaxLength = 20
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(92, 20)
        Me.txtFName.TabIndex = 1
        '
        'lblSuffix
        '
        Me.lblSuffix.AutoSize = True
        Me.lblSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuffix.Location = New System.Drawing.Point(329, 37)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(35, 12)
        Me.lblSuffix.TabIndex = 4
        Me.lblSuffix.Text = "(Suffix)"
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.Location = New System.Drawing.Point(213, 37)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(29, 12)
        Me.lblLName.TabIndex = 3
        Me.lblLName.Text = "(Last)"
        '
        'lblMI
        '
        Me.lblMI.AutoSize = True
        Me.lblMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMI.Location = New System.Drawing.Point(162, 37)
        Me.lblMI.Name = "lblMI"
        Me.lblMI.Size = New System.Drawing.Size(39, 12)
        Me.lblMI.TabIndex = 2
        Me.lblMI.Text = "(Middle)"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(71, 37)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(30, 12)
        Me.lblFN.TabIndex = 1
        Me.lblFN.Text = "(First)"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(5, 19)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'LastNameValidator
        '
        Me.LastNameValidator.ErrorMessage = "Last Name is required"
        Me.LastNameValidator.Icon = CType(resources.GetObject("LastNameValidator.Icon"), System.Drawing.Icon)
        Me.LastNameValidator.Required = True
        '
        'EditPerson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditPerson"
        Me.Size = New System.Drawing.Size(693, 119)
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LastNameValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblSuffix As System.Windows.Forms.Label
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblMI As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtDOB As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtSSN As MPR.SMS.UserControls.SSNWithValidator
    Friend WithEvents lblSSN As System.Windows.Forms.Label
    Friend WithEvents lblRelation As System.Windows.Forms.Label
    Friend WithEvents cboRelationship As MPR.SMS.UserControls.RelationshipTypeComboBox
    Friend WithEvents cboLanguage As MPR.SMS.UserControls.LanguageTypeComboBox
    Friend WithEvents lblLang As System.Windows.Forms.Label
    Friend WithEvents txtLangOther As System.Windows.Forms.TextBox
    Protected WithEvents LastNameValidator As MPR.Windows.Forms.Validation.RequiredFieldValidator
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnRace As System.Windows.Forms.Button
    Friend WithEvents chkInSample As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsIneligible As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsent As System.Windows.Forms.Button
    Friend WithEvents txtLexID As System.Windows.Forms.TextBox
    Friend WithEvents lblLexID As System.Windows.Forms.Label

End Class
