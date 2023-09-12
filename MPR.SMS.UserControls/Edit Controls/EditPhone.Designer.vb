'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditPhone
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPhone))
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtExt = New System.Windows.Forms.TextBox()
        Me.lblExt = New System.Windows.Forms.Label()
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.chkBestPhone = New System.Windows.Forms.CheckBox()
        Me.chkIsCleaned = New System.Windows.Forms.CheckBox()
        Me.lblListed = New System.Windows.Forms.Label()
        Me.txtListedTo = New System.Windows.Forms.TextBox()
        Me.lblVerify = New System.Windows.Forms.Label()
        Me.txtDateAttempted = New System.Windows.Forms.TextBox()
        Me.lblDSTI = New System.Windows.Forms.Label()
        Me.txtDSTI = New System.Windows.Forms.TextBox()
        Me.lblTZCode = New System.Windows.Forms.Label()
        Me.txtTZCode = New System.Windows.Forms.TextBox()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblAddDate = New System.Windows.Forms.Label()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.lblSourceQuality = New System.Windows.Forms.Label()
        Me.lblSourceType = New System.Windows.Forms.Label()
        Me.lblPhoneTime = New System.Windows.Forms.Label()
        Me.lblPhoneType = New System.Windows.Forms.Label()
        Me.chkInternational = New System.Windows.Forms.CheckBox()
        Me.cboSourceType = New MPR.SMS.UserControls.SourceTypeComboBox()
        Me.cboPhoneTime = New MPR.SMS.UserControls.PhoneTimeComboBox()
        Me.cboPhoneType = New MPR.SMS.UserControls.PhoneTypeComboBox()
        Me.txtPhone = New MPR.SMS.UserControls.PhoneWithValidator()
        Me.btnShared = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.cboSourceQuality = New MPR.SMS.UserControls.SourceQualityComboBox()
        Me.txtDateAdded = New System.Windows.Forms.TextBox()
        Me.lblDateAttempt = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RegularExpressionValidator1 = New MPR.Windows.Forms.Validation.RegularExpressionValidator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTCPAPhoneType = New System.Windows.Forms.TextBox()
        Me.txtTCPADate = New System.Windows.Forms.TextBox()
        Me.grpUserCtrl.SuspendLayout
        CType(Me.imgIcon,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RegularExpressionValidator1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = true
        Me.lblPhone.Location = New System.Drawing.Point(9, 37)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(51, 13)
        Me.lblPhone.TabIndex = 2
        Me.lblPhone.Text = "Phone #:"
        '
        'txtExt
        '
        Me.txtExt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtExt.Location = New System.Drawing.Point(202, 38)
        Me.txtExt.MaximumSize = New System.Drawing.Size(80, 20)
        Me.txtExt.MaxLength = 10
        Me.txtExt.MinimumSize = New System.Drawing.Size(35, 20)
        Me.txtExt.Name = "txtExt"
        Me.txtExt.Size = New System.Drawing.Size(65, 20)
        Me.txtExt.TabIndex = 5
        '
        'lblExt
        '
        Me.lblExt.AutoSize = true
        Me.lblExt.Location = New System.Drawing.Point(171, 37)
        Me.lblExt.Name = "lblExt"
        Me.lblExt.Size = New System.Drawing.Size(25, 13)
        Me.lblExt.TabIndex = 4
        Me.lblExt.Text = "Ext:"
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Controls.Add(Me.txtTCPADate)
        Me.grpUserCtrl.Controls.Add(Me.txtTCPAPhoneType)
        Me.grpUserCtrl.Controls.Add(Me.Label2)
        Me.grpUserCtrl.Controls.Add(Me.Label1)
        Me.grpUserCtrl.Controls.Add(Me.lblNote)
        Me.grpUserCtrl.Controls.Add(Me.txtNotes)
        Me.grpUserCtrl.Controls.Add(Me.chkBestPhone)
        Me.grpUserCtrl.Controls.Add(Me.chkIsCleaned)
        Me.grpUserCtrl.Controls.Add(Me.lblListed)
        Me.grpUserCtrl.Controls.Add(Me.txtListedTo)
        Me.grpUserCtrl.Controls.Add(Me.lblVerify)
        Me.grpUserCtrl.Controls.Add(Me.txtDateAttempted)
        Me.grpUserCtrl.Controls.Add(Me.lblDSTI)
        Me.grpUserCtrl.Controls.Add(Me.txtDSTI)
        Me.grpUserCtrl.Controls.Add(Me.lblTZCode)
        Me.grpUserCtrl.Controls.Add(Me.txtTZCode)
        Me.grpUserCtrl.Controls.Add(Me.lblWarning)
        Me.grpUserCtrl.Controls.Add(Me.lblAddDate)
        Me.grpUserCtrl.Controls.Add(Me.imgIcon)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceType)
        Me.grpUserCtrl.Controls.Add(Me.lblPhoneTime)
        Me.grpUserCtrl.Controls.Add(Me.lblPhoneType)
        Me.grpUserCtrl.Controls.Add(Me.chkInternational)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceType)
        Me.grpUserCtrl.Controls.Add(Me.cboPhoneTime)
        Me.grpUserCtrl.Controls.Add(Me.cboPhoneType)
        Me.grpUserCtrl.Controls.Add(Me.txtPhone)
        Me.grpUserCtrl.Controls.Add(Me.btnShared)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblExt)
        Me.grpUserCtrl.Controls.Add(Me.txtExt)
        Me.grpUserCtrl.Controls.Add(Me.lblPhone)
        Me.grpUserCtrl.Controls.Add(Me.txtDateAdded)
        Me.grpUserCtrl.Controls.Add(Me.lblDateAttempt)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(496, 282)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = false
        Me.grpUserCtrl.Text = "Phone"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = true
        Me.lblNote.Location = New System.Drawing.Point(8, 227)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(38, 13)
        Me.lblNote.TabIndex = 28
        Me.lblNote.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(74, 224)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(412, 52)
        Me.txtNotes.TabIndex = 29
        '
        'chkBestPhone
        '
        Me.chkBestPhone.AutoSize = true
        Me.chkBestPhone.Location = New System.Drawing.Point(11, 178)
        Me.chkBestPhone.Name = "chkBestPhone"
        Me.chkBestPhone.Size = New System.Drawing.Size(234, 17)
        Me.chkBestPhone.TabIndex = 16
        Me.chkBestPhone.Text = "This is the 'best' phone for this case member"
        Me.chkBestPhone.UseVisualStyleBackColor = true
        '
        'chkIsCleaned
        '
        Me.chkIsCleaned.AutoSize = true
        Me.chkIsCleaned.Checked = true
        Me.chkIsCleaned.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsCleaned.Location = New System.Drawing.Point(174, 17)
        Me.chkIsCleaned.Name = "chkIsCleaned"
        Me.chkIsCleaned.Size = New System.Drawing.Size(71, 17)
        Me.chkIsCleaned.TabIndex = 1
        Me.chkIsCleaned.Text = "Cleaned?"
        Me.chkIsCleaned.UseVisualStyleBackColor = true
        '
        'lblListed
        '
        Me.lblListed.AutoSize = true
        Me.lblListed.Location = New System.Drawing.Point(9, 152)
        Me.lblListed.Name = "lblListed"
        Me.lblListed.Size = New System.Drawing.Size(50, 13)
        Me.lblListed.TabIndex = 14
        Me.lblListed.Text = "Listed to:"
        '
        'txtListedTo
        '
        Me.txtListedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtListedTo.Location = New System.Drawing.Point(74, 152)
        Me.txtListedTo.MaxLength = 100
        Me.txtListedTo.MinimumSize = New System.Drawing.Size(35, 20)
        Me.txtListedTo.Name = "txtListedTo"
        Me.txtListedTo.Size = New System.Drawing.Size(193, 20)
        Me.txtListedTo.TabIndex = 15
        '
        'lblVerify
        '
        Me.lblVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblVerify.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblVerify.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVerify.Location = New System.Drawing.Point(273, 15)
        Me.lblVerify.Name = "lblVerify"
        Me.lblVerify.Padding = New System.Windows.Forms.Padding(2)
        Me.lblVerify.Size = New System.Drawing.Size(213, 42)
        Me.lblVerify.TabIndex = 18
        Me.lblVerify.Text = "Verification status"
        Me.lblVerify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVerify.Visible = false
        '
        'txtDateAttempted
        '
        Me.txtDateAttempted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtDateAttempted.Location = New System.Drawing.Point(383, 106)
        Me.txtDateAttempted.Name = "txtDateAttempted"
        Me.txtDateAttempted.ReadOnly = true
        Me.txtDateAttempted.Size = New System.Drawing.Size(103, 20)
        Me.txtDateAttempted.TabIndex = 26
        '
        'lblDSTI
        '
        Me.lblDSTI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblDSTI.AutoSize = true
        Me.lblDSTI.Location = New System.Drawing.Point(425, 60)
        Me.lblDSTI.Name = "lblDSTI"
        Me.lblDSTI.Size = New System.Drawing.Size(35, 13)
        Me.lblDSTI.TabIndex = 21
        Me.lblDSTI.Text = "DSTI:"
        '
        'txtDSTI
        '
        Me.txtDSTI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtDSTI.Location = New System.Drawing.Point(466, 60)
        Me.txtDSTI.MaxLength = 1
        Me.txtDSTI.Name = "txtDSTI"
        Me.txtDSTI.Size = New System.Drawing.Size(20, 20)
        Me.txtDSTI.TabIndex = 22
        '
        'lblTZCode
        '
        Me.lblTZCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblTZCode.AutoSize = true
        Me.lblTZCode.Location = New System.Drawing.Point(280, 60)
        Me.lblTZCode.Name = "lblTZCode"
        Me.lblTZCode.Size = New System.Drawing.Size(86, 13)
        Me.lblTZCode.TabIndex = 19
        Me.lblTZCode.Text = "Time-zone code:"
        '
        'txtTZCode
        '
        Me.txtTZCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTZCode.Location = New System.Drawing.Point(383, 60)
        Me.txtTZCode.MaxLength = 2
        Me.txtTZCode.Name = "txtTZCode"
        Me.txtTZCode.Size = New System.Drawing.Size(28, 20)
        Me.txtTZCode.TabIndex = 20
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(273, 174)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblWarning.Size = New System.Drawing.Size(213, 44)
        Me.lblWarning.TabIndex = 27
        Me.lblWarning.Text = "Note: Changing any information on this shared phone will also apply those changes"& _ 
    " to all other members of this case."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = false
        '
        'lblAddDate
        '
        Me.lblAddDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblAddDate.AutoSize = true
        Me.lblAddDate.Location = New System.Drawing.Point(280, 83)
        Me.lblAddDate.Name = "lblAddDate"
        Me.lblAddDate.Size = New System.Drawing.Size(66, 13)
        Me.lblAddDate.TabIndex = 23
        Me.lblAddDate.Text = "Date added:"
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"),System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(45, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(18, 15)
        Me.imgIcon.TabIndex = 15
        Me.imgIcon.TabStop = false
        '
        'lblSourceQuality
        '
        Me.lblSourceQuality.AutoSize = true
        Me.lblSourceQuality.Location = New System.Drawing.Point(9, 129)
        Me.lblSourceQuality.Name = "lblSourceQuality"
        Me.lblSourceQuality.Size = New System.Drawing.Size(42, 13)
        Me.lblSourceQuality.TabIndex = 12
        Me.lblSourceQuality.Text = "Quality:"
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoSize = true
        Me.lblSourceType.Location = New System.Drawing.Point(9, 106)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(44, 13)
        Me.lblSourceType.TabIndex = 10
        Me.lblSourceType.Text = "Source:"
        '
        'lblPhoneTime
        '
        Me.lblPhoneTime.AutoSize = true
        Me.lblPhoneTime.Location = New System.Drawing.Point(9, 60)
        Me.lblPhoneTime.Name = "lblPhoneTime"
        Me.lblPhoneTime.Size = New System.Drawing.Size(64, 13)
        Me.lblPhoneTime.TabIndex = 6
        Me.lblPhoneTime.Text = "Time to call:"
        '
        'lblPhoneType
        '
        Me.lblPhoneType.AutoSize = true
        Me.lblPhoneType.Location = New System.Drawing.Point(9, 83)
        Me.lblPhoneType.Name = "lblPhoneType"
        Me.lblPhoneType.Size = New System.Drawing.Size(64, 13)
        Me.lblPhoneType.TabIndex = 8
        Me.lblPhoneType.Text = "Phone type:"
        '
        'chkInternational
        '
        Me.chkInternational.AutoSize = true
        Me.chkInternational.Location = New System.Drawing.Point(74, 17)
        Me.chkInternational.Name = "chkInternational"
        Me.chkInternational.Size = New System.Drawing.Size(90, 17)
        Me.chkInternational.TabIndex = 0
        Me.chkInternational.Text = "International?"
        Me.chkInternational.UseVisualStyleBackColor = true
        '
        'cboSourceType
        '
        Me.cboSourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cboSourceType.Location = New System.Drawing.Point(74, 106)
        Me.cboSourceType.MyLabel = "Source:"
        Me.cboSourceType.MyLabelVisible = false
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.SelectedSourceType = Nothing
        Me.cboSourceType.SelectedSourceTypeID = 0
        Me.cboSourceType.Size = New System.Drawing.Size(193, 21)
        Me.cboSourceType.TabIndex = 11
        '
        'cboPhoneTime
        '
        Me.cboPhoneTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cboPhoneTime.Location = New System.Drawing.Point(74, 60)
        Me.cboPhoneTime.MyLabel = "Time to call:"
        Me.cboPhoneTime.MyLabelVisible = false
        Me.cboPhoneTime.Name = "cboPhoneTime"
        Me.cboPhoneTime.SelectedPhoneTime = Nothing
        Me.cboPhoneTime.SelectedPhoneTimeID = 0
        Me.cboPhoneTime.Size = New System.Drawing.Size(193, 22)
        Me.cboPhoneTime.TabIndex = 7
        '
        'cboPhoneType
        '
        Me.cboPhoneType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cboPhoneType.Location = New System.Drawing.Point(74, 83)
        Me.cboPhoneType.MyLabel = "Phone type:"
        Me.cboPhoneType.MyLabelVisible = false
        Me.cboPhoneType.Name = "cboPhoneType"
        Me.cboPhoneType.SelectedPhoneType = Nothing
        Me.cboPhoneType.SelectedPhoneTypeID = 0
        Me.cboPhoneType.Size = New System.Drawing.Size(193, 24)
        Me.cboPhoneType.TabIndex = 9
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(74, 38)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = false
        Me.txtPhone.Required = false
        Me.txtPhone.Size = New System.Drawing.Size(96, 20)
        Me.txtPhone.TabIndex = 3
        Me.txtPhone.TextFormatted = ""
        '
        'btnShared
        '
        Me.btnShared.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnShared.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnShared.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShared.ImageKey = "users.bmp"
        Me.btnShared.ImageList = Me.ImageList
        Me.btnShared.Location = New System.Drawing.Point(12, 197)
        Me.btnShared.Name = "btnShared"
        Me.btnShared.Size = New System.Drawing.Size(255, 21)
        Me.btnShared.TabIndex = 17
        Me.btnShared.Text = "This phone is shared with all case members"
        Me.btnShared.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShared.UseVisualStyleBackColor = true
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.ImageList.Images.SetKeyName(0, "user.bmp")
        Me.ImageList.Images.SetKeyName(1, "users.bmp")
        Me.ImageList.Images.SetKeyName(2, "Phone2.bmp")
        '
        'cboSourceQuality
        '
        Me.cboSourceQuality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cboSourceQuality.Location = New System.Drawing.Point(74, 129)
        Me.cboSourceQuality.MyLabel = "Quality:"
        Me.cboSourceQuality.MyLabelVisible = false
        Me.cboSourceQuality.Name = "cboSourceQuality"
        Me.cboSourceQuality.SelectedSourceQuality = Nothing
        Me.cboSourceQuality.SelectedSourceQualityID = 0
        Me.cboSourceQuality.Size = New System.Drawing.Size(193, 22)
        Me.cboSourceQuality.TabIndex = 13
        '
        'txtDateAdded
        '
        Me.txtDateAdded.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtDateAdded.Location = New System.Drawing.Point(383, 83)
        Me.txtDateAdded.Name = "txtDateAdded"
        Me.txtDateAdded.ReadOnly = true
        Me.txtDateAdded.Size = New System.Drawing.Size(103, 20)
        Me.txtDateAdded.TabIndex = 24
        '
        'lblDateAttempt
        '
        Me.lblDateAttempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblDateAttempt.AutoSize = true
        Me.lblDateAttempt.Location = New System.Drawing.Point(280, 106)
        Me.lblDateAttempt.Name = "lblDateAttempt"
        Me.lblDateAttempt.Size = New System.Drawing.Size(102, 13)
        Me.lblDateAttempt.TabIndex = 25
        Me.lblDateAttempt.Text = "Date last attempted:"
        '
        'RegularExpressionValidator1
        '
        Me.RegularExpressionValidator1.ControlToValidate = Me.txtTZCode
        Me.RegularExpressionValidator1.ErrorMessage = "Please enter a valid Time Zone Code (01-08)"
        Me.RegularExpressionValidator1.Icon = CType(resources.GetObject("RegularExpressionValidator1.Icon"),System.Drawing.Icon)
        Me.RegularExpressionValidator1.ValidationExpression = "0[1-8]"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(280, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "TCPA Phone Type:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(280, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "TCPA Lookup Date:"
        '
        'txtTCPAPhoneType
        '
        Me.txtTCPAPhoneType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTCPAPhoneType.Location = New System.Drawing.Point(383, 129)
        Me.txtTCPAPhoneType.MaxLength = 10
        Me.txtTCPAPhoneType.Name = "txtTCPAPhoneType"
        Me.txtTCPAPhoneType.ReadOnly = true
        Me.txtTCPAPhoneType.Size = New System.Drawing.Size(103, 20)
        Me.txtTCPAPhoneType.TabIndex = 32
        '
        'txtTCPADate
        '
        Me.txtTCPADate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTCPADate.Location = New System.Drawing.Point(383, 152)
        Me.txtTCPADate.MaxLength = 10
        Me.txtTCPADate.Name = "txtTCPADate"
        Me.txtTCPADate.ReadOnly = true
        Me.txtTCPADate.Size = New System.Drawing.Size(103, 20)
        Me.txtTCPADate.TabIndex = 33
        '
        'EditPhone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditPhone"
        Me.Size = New System.Drawing.Size(496, 282)
        Me.grpUserCtrl.ResumeLayout(false)
        Me.grpUserCtrl.PerformLayout
        CType(Me.imgIcon,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RegularExpressionValidator1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtExt As System.Windows.Forms.TextBox
    Friend WithEvents lblExt As System.Windows.Forms.Label
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents cboSourceType As MPR.SMS.UserControls.SourceTypeComboBox
    Friend WithEvents cboSourceQuality As MPR.SMS.UserControls.SourceQualityComboBox
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents btnShared As System.Windows.Forms.Button
    Friend WithEvents txtPhone As MPR.SMS.UserControls.PhoneWithValidator
    Friend WithEvents cboPhoneType As MPR.SMS.UserControls.PhoneTypeComboBox
    Friend WithEvents cboPhoneTime As MPR.SMS.UserControls.PhoneTimeComboBox
    Friend WithEvents chkInternational As System.Windows.Forms.CheckBox
    Friend WithEvents lblSourceQuality As System.Windows.Forms.Label
    Friend WithEvents lblSourceType As System.Windows.Forms.Label
    Friend WithEvents lblPhoneTime As System.Windows.Forms.Label
    Friend WithEvents lblPhoneType As System.Windows.Forms.Label
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblDateAttempt As System.Windows.Forms.Label
    Friend WithEvents txtDateAttempted As System.Windows.Forms.TextBox
    Friend WithEvents lblAddDate As System.Windows.Forms.Label
    Friend WithEvents txtDateAdded As System.Windows.Forms.TextBox
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblTZCode As System.Windows.Forms.Label
    Friend WithEvents txtTZCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDSTI As System.Windows.Forms.Label
    Friend WithEvents txtDSTI As System.Windows.Forms.TextBox
    Friend WithEvents lblVerify As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblListed As System.Windows.Forms.Label
    Friend WithEvents txtListedTo As System.Windows.Forms.TextBox
    Friend WithEvents chkIsCleaned As System.Windows.Forms.CheckBox
    Friend WithEvents chkBestPhone As System.Windows.Forms.CheckBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Protected WithEvents RegularExpressionValidator1 As MPR.Windows.Forms.Validation.RegularExpressionValidator
    Friend WithEvents txtTCPADate As System.Windows.Forms.TextBox
    Friend WithEvents txtTCPAPhoneType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
