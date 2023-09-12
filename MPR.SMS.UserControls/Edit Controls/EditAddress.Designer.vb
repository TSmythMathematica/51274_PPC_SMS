'******************************************************************************
' Copyright � Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAddress))
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.lblAdd1 = New System.Windows.Forms.Label()
        Me.lblAdd2 = New System.Windows.Forms.Label()
        Me.lblAdd3 = New System.Windows.Forms.Label()
        Me.lblAdd4 = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox()
        Me.btnMap = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.txtLon = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.txtFacility2 = New System.Windows.Forms.TextBox()
        Me.grpBest = New System.Windows.Forms.GroupBox()
        Me.chkBestAll = New System.Windows.Forms.CheckBox()
        Me.chkBestCheck = New System.Windows.Forms.CheckBox()
        Me.chkBestMailing = New System.Windows.Forms.CheckBox()
        Me.chkBestPhysical = New System.Windows.Forms.CheckBox()
        Me.lblVerify = New System.Windows.Forms.Label()
        Me.chkIsCleaned = New System.Windows.Forms.CheckBox()
        Me.btnShared = New System.Windows.Forms.Button()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblFac2 = New System.Windows.Forms.Label()
        Me.lblFac1 = New System.Windows.Forms.Label()
        Me.txtFacility1 = New System.Windows.Forms.TextBox()
        Me.lblFacility = New System.Windows.Forms.Label()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboSourceType = New MPR.SMS.UserControls.SourceTypeComboBox()
        Me.cboReturnedMail = New MPR.SMS.UserControls.ReturnedMailComboBox()
        Me.cboAddressType = New MPR.SMS.UserControls.AddressTypeComboBox()
        Me.cboSourceQuality = New MPR.SMS.UserControls.SourceQualityComboBox()
        Me.txtZip = New MPR.SMS.UserControls.ZipCodeWithValidator()
        Me.cboState = New MPR.SMS.UserControls.StateComboBox()
        Me.grpUserCtrl.SuspendLayout()
        Me.grpBest.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(70, 20)
        Me.txtAddress1.MaxLength = 60
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(227, 20)
        Me.txtAddress1.TabIndex = 2
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(6, 19)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(48, 13)
        Me.lblAddress.TabIndex = 0
        Me.lblAddress.Text = "Address:"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(70, 102)
        Me.txtCity.MaxLength = 25
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(227, 20)
        Me.txtCity.TabIndex = 10
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(185, 125)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(25, 13)
        Me.lblGender.TabIndex = 13
        Me.lblGender.Text = "Zip:"
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(70, 40)
        Me.txtAddress2.MaxLength = 60
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(227, 20)
        Me.txtAddress2.TabIndex = 4
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(70, 60)
        Me.txtAddress3.MaxLength = 60
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(227, 20)
        Me.txtAddress3.TabIndex = 6
        '
        'txtAddress4
        '
        Me.txtAddress4.Location = New System.Drawing.Point(70, 80)
        Me.txtAddress4.MaxLength = 60
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(227, 20)
        Me.txtAddress4.TabIndex = 8
        '
        'lblAdd1
        '
        Me.lblAdd1.AutoSize = True
        Me.lblAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd1.Location = New System.Drawing.Point(60, 20)
        Me.lblAdd1.Name = "lblAdd1"
        Me.lblAdd1.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd1.TabIndex = 1
        Me.lblAdd1.Text = "1"
        '
        'lblAdd2
        '
        Me.lblAdd2.AutoSize = True
        Me.lblAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd2.Location = New System.Drawing.Point(60, 40)
        Me.lblAdd2.Name = "lblAdd2"
        Me.lblAdd2.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd2.TabIndex = 3
        Me.lblAdd2.Text = "2"
        '
        'lblAdd3
        '
        Me.lblAdd3.AutoSize = True
        Me.lblAdd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd3.Location = New System.Drawing.Point(60, 60)
        Me.lblAdd3.Name = "lblAdd3"
        Me.lblAdd3.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd3.TabIndex = 5
        Me.lblAdd3.Text = "3"
        '
        'lblAdd4
        '
        Me.lblAdd4.AutoSize = True
        Me.lblAdd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd4.Location = New System.Drawing.Point(60, 80)
        Me.lblAdd4.Name = "lblAdd4"
        Me.lblAdd4.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd4.TabIndex = 7
        Me.lblAdd4.Text = "4"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(6, 123)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 11
        Me.lblState.Text = "State:"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(6, 102)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCity.TabIndex = 9
        Me.lblCity.Text = "City:"
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceType)
        Me.grpUserCtrl.Controls.Add(Me.btnMap)
        Me.grpUserCtrl.Controls.Add(Me.txtLon)
        Me.grpUserCtrl.Controls.Add(Me.txtLat)
        Me.grpUserCtrl.Controls.Add(Me.cboReturnedMail)
        Me.grpUserCtrl.Controls.Add(Me.txtFacility2)
        Me.grpUserCtrl.Controls.Add(Me.grpBest)
        Me.grpUserCtrl.Controls.Add(Me.lblVerify)
        Me.grpUserCtrl.Controls.Add(Me.chkIsCleaned)
        Me.grpUserCtrl.Controls.Add(Me.btnShared)
        Me.grpUserCtrl.Controls.Add(Me.lblWarning)
        Me.grpUserCtrl.Controls.Add(Me.lblFac2)
        Me.grpUserCtrl.Controls.Add(Me.lblFac1)
        Me.grpUserCtrl.Controls.Add(Me.txtFacility1)
        Me.grpUserCtrl.Controls.Add(Me.lblFacility)
        Me.grpUserCtrl.Controls.Add(Me.imgIcon)
        Me.grpUserCtrl.Controls.Add(Me.cboAddressType)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.txtZip)
        Me.grpUserCtrl.Controls.Add(Me.lblCity)
        Me.grpUserCtrl.Controls.Add(Me.lblState)
        Me.grpUserCtrl.Controls.Add(Me.lblAdd4)
        Me.grpUserCtrl.Controls.Add(Me.lblAdd3)
        Me.grpUserCtrl.Controls.Add(Me.lblAdd2)
        Me.grpUserCtrl.Controls.Add(Me.lblAdd1)
        Me.grpUserCtrl.Controls.Add(Me.txtAddress4)
        Me.grpUserCtrl.Controls.Add(Me.txtAddress3)
        Me.grpUserCtrl.Controls.Add(Me.txtAddress2)
        Me.grpUserCtrl.Controls.Add(Me.cboState)
        Me.grpUserCtrl.Controls.Add(Me.lblGender)
        Me.grpUserCtrl.Controls.Add(Me.txtCity)
        Me.grpUserCtrl.Controls.Add(Me.txtAddress1)
        Me.grpUserCtrl.Controls.Add(Me.lblAddress)
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.MinimumSize = New System.Drawing.Size(637, 248)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(637, 248)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = False
        Me.grpUserCtrl.Text = "Address"
        '
        'btnMap
        '
        Me.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMap.ImageIndex = 2
        Me.btnMap.ImageList = Me.ImageList
        Me.btnMap.Location = New System.Drawing.Point(303, 40)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Size = New System.Drawing.Size(26, 23)
        Me.btnMap.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.btnMap, "Map this location in Google Maps")
        Me.btnMap.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList.Images.SetKeyName(0, "user.bmp")
        Me.ImageList.Images.SetKeyName(1, "users.bmp")
        Me.ImageList.Images.SetKeyName(2, "maps.jpg")
        '
        'txtLon
        '
        Me.txtLon.Location = New System.Drawing.Point(9, 204)
        Me.txtLon.MaxLength = 0
        Me.txtLon.Name = "txtLon"
        Me.txtLon.Size = New System.Drawing.Size(24, 20)
        Me.txtLon.TabIndex = 32
        Me.txtLon.Visible = False
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(9, 182)
        Me.txtLat.MaxLength = 0
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(24, 20)
        Me.txtLat.TabIndex = 31
        Me.txtLat.Visible = False
        '
        'txtFacility2
        '
        Me.txtFacility2.Location = New System.Drawing.Point(70, 168)
        Me.txtFacility2.MaxLength = 60
        Me.txtFacility2.Name = "txtFacility2"
        Me.txtFacility2.Size = New System.Drawing.Size(227, 20)
        Me.txtFacility2.TabIndex = 19
        '
        'grpBest
        '
        Me.grpBest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBest.Controls.Add(Me.chkBestAll)
        Me.grpBest.Controls.Add(Me.chkBestCheck)
        Me.grpBest.Controls.Add(Me.chkBestMailing)
        Me.grpBest.Controls.Add(Me.chkBestPhysical)
        Me.grpBest.Location = New System.Drawing.Point(70, 192)
        Me.grpBest.Name = "grpBest"
        Me.grpBest.Size = New System.Drawing.Size(558, 36)
        Me.grpBest.TabIndex = 28
        Me.grpBest.TabStop = False
        Me.grpBest.Text = "Best address for this case member"
        '
        'chkBestAll
        '
        Me.chkBestAll.AutoSize = True
        Me.chkBestAll.Location = New System.Drawing.Point(16, 14)
        Me.chkBestAll.Name = "chkBestAll"
        Me.chkBestAll.Size = New System.Drawing.Size(105, 17)
        Me.chkBestAll.TabIndex = 0
        Me.chkBestAll.Text = "All address types"
        Me.chkBestAll.UseVisualStyleBackColor = True
        '
        'chkBestCheck
        '
        Me.chkBestCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkBestCheck.AutoSize = True
        Me.chkBestCheck.Location = New System.Drawing.Point(455, 15)
        Me.chkBestCheck.Name = "chkBestCheck"
        Me.chkBestCheck.Size = New System.Drawing.Size(97, 17)
        Me.chkBestCheck.TabIndex = 3
        Me.chkBestCheck.Text = "Check address"
        Me.chkBestCheck.UseVisualStyleBackColor = True
        '
        'chkBestMailing
        '
        Me.chkBestMailing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkBestMailing.AutoSize = True
        Me.chkBestMailing.Location = New System.Drawing.Point(315, 15)
        Me.chkBestMailing.Name = "chkBestMailing"
        Me.chkBestMailing.Size = New System.Drawing.Size(99, 17)
        Me.chkBestMailing.TabIndex = 2
        Me.chkBestMailing.Text = "Mailing address"
        Me.chkBestMailing.UseVisualStyleBackColor = True
        '
        'chkBestPhysical
        '
        Me.chkBestPhysical.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkBestPhysical.AutoSize = True
        Me.chkBestPhysical.Location = New System.Drawing.Point(165, 15)
        Me.chkBestPhysical.Name = "chkBestPhysical"
        Me.chkBestPhysical.Size = New System.Drawing.Size(105, 17)
        Me.chkBestPhysical.TabIndex = 1
        Me.chkBestPhysical.Text = "Physical address"
        Me.chkBestPhysical.UseVisualStyleBackColor = True
        '
        'lblVerify
        '
        Me.lblVerify.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerify.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblVerify.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVerify.Location = New System.Drawing.Point(383, 12)
        Me.lblVerify.Name = "lblVerify"
        Me.lblVerify.Padding = New System.Windows.Forms.Padding(2)
        Me.lblVerify.Size = New System.Drawing.Size(245, 24)
        Me.lblVerify.TabIndex = 21
        Me.lblVerify.Text = "Verification status"
        Me.lblVerify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVerify.Visible = False
        '
        'chkIsCleaned
        '
        Me.chkIsCleaned.AutoSize = True
        Me.chkIsCleaned.Checked = True
        Me.chkIsCleaned.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsCleaned.Location = New System.Drawing.Point(312, 17)
        Me.chkIsCleaned.Name = "chkIsCleaned"
        Me.chkIsCleaned.Size = New System.Drawing.Size(71, 17)
        Me.chkIsCleaned.TabIndex = 20
        Me.chkIsCleaned.Text = "Cleaned?"
        Me.chkIsCleaned.UseVisualStyleBackColor = True
        '
        'btnShared
        '
        Me.btnShared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShared.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnShared.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShared.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShared.ImageKey = "users.bmp"
        Me.btnShared.ImageList = Me.ImageList
        Me.btnShared.Location = New System.Drawing.Point(332, 40)
        Me.btnShared.Name = "btnShared"
        Me.btnShared.Size = New System.Drawing.Size(296, 23)
        Me.btnShared.TabIndex = 22
        Me.btnShared.Text = "This address is shared with all case members"
        Me.btnShared.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShared.UseVisualStyleBackColor = True
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(303, 65)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblWarning.Size = New System.Drawing.Size(325, 35)
        Me.lblWarning.TabIndex = 23
        Me.lblWarning.Text = "Note: Changing any information on this shared address will also apply those chang" & _
    "es to all other members of this case."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = False
        '
        'lblFac2
        '
        Me.lblFac2.AutoSize = True
        Me.lblFac2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFac2.Location = New System.Drawing.Point(60, 168)
        Me.lblFac2.Name = "lblFac2"
        Me.lblFac2.Size = New System.Drawing.Size(10, 12)
        Me.lblFac2.TabIndex = 18
        Me.lblFac2.Text = "2"
        '
        'lblFac1
        '
        Me.lblFac1.AutoSize = True
        Me.lblFac1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFac1.Location = New System.Drawing.Point(60, 146)
        Me.lblFac1.Name = "lblFac1"
        Me.lblFac1.Size = New System.Drawing.Size(10, 12)
        Me.lblFac1.TabIndex = 16
        Me.lblFac1.Text = "1"
        '
        'txtFacility1
        '
        Me.txtFacility1.Location = New System.Drawing.Point(70, 146)
        Me.txtFacility1.MaxLength = 60
        Me.txtFacility1.Name = "txtFacility1"
        Me.txtFacility1.Size = New System.Drawing.Size(227, 20)
        Me.txtFacility1.TabIndex = 17
        '
        'lblFacility
        '
        Me.lblFacility.AutoSize = True
        Me.lblFacility.Location = New System.Drawing.Point(6, 146)
        Me.lblFacility.Name = "lblFacility"
        Me.lblFacility.Size = New System.Drawing.Size(42, 13)
        Me.lblFacility.TabIndex = 15
        Me.lblFacility.Text = "Facility:"
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(52, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 12)
        Me.imgIcon.TabIndex = 23
        Me.imgIcon.TabStop = False
        '
        'cboSourceType
        '
        Me.cboSourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceType.Location = New System.Drawing.Point(312, 125)
        Me.cboSourceType.MyLabel = "Source:"
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.SelectedSourceType = Nothing
        Me.cboSourceType.SelectedSourceTypeID = 0
        Me.cboSourceType.Size = New System.Drawing.Size(316, 22)
        Me.cboSourceType.TabIndex = 25
        '
        'cboReturnedMail
        '
        Me.cboReturnedMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReturnedMail.Location = New System.Drawing.Point(312, 171)
        Me.cboReturnedMail.MyLabel = "Returned mail:"
        Me.cboReturnedMail.Name = "cboReturnedMail"
        Me.cboReturnedMail.SelectedReturnedMail = Nothing
        Me.cboReturnedMail.SelectedReturnedMailReasonID = 0
        Me.cboReturnedMail.Size = New System.Drawing.Size(316, 22)
        Me.cboReturnedMail.TabIndex = 27
        '
        'cboAddressType
        '
        Me.cboAddressType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAddressType.Location = New System.Drawing.Point(312, 102)
        Me.cboAddressType.MyLabel = "Address type:"
        Me.cboAddressType.Name = "cboAddressType"
        Me.cboAddressType.SelectedAddressType = Nothing
        Me.cboAddressType.SelectedAddressTypeID = 0
        Me.cboAddressType.Size = New System.Drawing.Size(316, 22)
        Me.cboAddressType.TabIndex = 24
        '
        'cboSourceQuality
        '
        Me.cboSourceQuality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceQuality.Location = New System.Drawing.Point(312, 148)
        Me.cboSourceQuality.MyLabel = "Quality:"
        Me.cboSourceQuality.Name = "cboSourceQuality"
        Me.cboSourceQuality.SelectedSourceQuality = Nothing
        Me.cboSourceQuality.SelectedSourceQualityID = 0
        Me.cboSourceQuality.Size = New System.Drawing.Size(316, 22)
        Me.cboSourceQuality.TabIndex = 26
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(217, 124)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = False
        Me.txtZip.Required = False
        Me.txtZip.Size = New System.Drawing.Size(96, 20)
        Me.txtZip.TabIndex = 14
        '
        'cboState
        '
        Me.cboState.Location = New System.Drawing.Point(70, 123)
        Me.cboState.MyLabel = "State:"
        Me.cboState.MyLabelVisible = False
        Me.cboState.Name = "cboState"
        Me.cboState.SelectedState = Nothing
        Me.cboState.SelectedStateAbbreviation = "0"
        Me.cboState.SelectedStateID = 0
        Me.cboState.Size = New System.Drawing.Size(109, 21)
        Me.cboState.TabIndex = 12
        '
        'EditAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditAddress"
        Me.Size = New System.Drawing.Size(637, 266)
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        Me.grpBest.ResumeLayout(False)
        Me.grpBest.PerformLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cboState As MPR.SMS.UserControls.StateComboBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents lblAdd1 As System.Windows.Forms.Label
    Friend WithEvents lblAdd2 As System.Windows.Forms.Label
    Friend WithEvents lblAdd3 As System.Windows.Forms.Label
    Friend WithEvents lblAdd4 As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents txtZip As MPR.SMS.UserControls.ZipCodeWithValidator
    Friend WithEvents cboSourceType As MPR.SMS.UserControls.SourceTypeComboBox
    Friend WithEvents cboSourceQuality As MPR.SMS.UserControls.SourceQualityComboBox
    Friend WithEvents cboAddressType As MPR.SMS.UserControls.AddressTypeComboBox
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents btnShared As System.Windows.Forms.Button
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblFac2 As System.Windows.Forms.Label
    Friend WithEvents txtFacility2 As System.Windows.Forms.TextBox
    Friend WithEvents lblFac1 As System.Windows.Forms.Label
    Friend WithEvents txtFacility1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFacility As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblVerify As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkIsCleaned As System.Windows.Forms.CheckBox
    Friend WithEvents chkBestPhysical As System.Windows.Forms.CheckBox
    Friend WithEvents grpBest As System.Windows.Forms.GroupBox
    Friend WithEvents chkBestCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkBestMailing As System.Windows.Forms.CheckBox
    Friend WithEvents cboReturnedMail As MPR.SMS.UserControls.ReturnedMailComboBox
    Friend WithEvents txtLon As System.Windows.Forms.TextBox
    Friend WithEvents txtLat As System.Windows.Forms.TextBox
    Friend WithEvents btnMap As System.Windows.Forms.Button
    Friend WithEvents chkBestAll As System.Windows.Forms.CheckBox

End Class
