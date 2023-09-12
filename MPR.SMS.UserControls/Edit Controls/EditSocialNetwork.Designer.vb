'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditSocialNetwork
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditSocialNetwork))
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox()
        Me.txtSentRequestOn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.cboSocialNetworkStatus = New MPR.SMS.UserControls.SocialNetworkStatusComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLikeUs = New System.Windows.Forms.CheckBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.chkBestSocialNetwork = New System.Windows.Forms.CheckBox()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblSourceQuality = New System.Windows.Forms.Label()
        Me.lblSourceType = New System.Windows.Forms.Label()
        Me.lblSocialNetworkType = New System.Windows.Forms.Label()
        Me.cboSourceType = New MPR.SMS.UserControls.SourceTypeComboBox()
        Me.cboSocialNetworkType = New MPR.SMS.UserControls.SocialNetworkTypeComboBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnShared = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.cboSourceQuality = New MPR.SMS.UserControls.SourceQualityComboBox()
        Me.TextValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        Me.grpUserCtrl.SuspendLayout()
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(18, 20)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(63, 13)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "User Name:"
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Controls.Add(Me.txtSentRequestOn)
        Me.grpUserCtrl.Controls.Add(Me.Label3)
        Me.grpUserCtrl.Controls.Add(Me.txtNotes)
        Me.grpUserCtrl.Controls.Add(Me.cboSocialNetworkStatus)
        Me.grpUserCtrl.Controls.Add(Me.Label1)
        Me.grpUserCtrl.Controls.Add(Me.chkLikeUs)
        Me.grpUserCtrl.Controls.Add(Me.txtURL)
        Me.grpUserCtrl.Controls.Add(Me.lblURL)
        Me.grpUserCtrl.Controls.Add(Me.chkBestSocialNetwork)
        Me.grpUserCtrl.Controls.Add(Me.lblWarning)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceType)
        Me.grpUserCtrl.Controls.Add(Me.lblSocialNetworkType)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceType)
        Me.grpUserCtrl.Controls.Add(Me.cboSocialNetworkType)
        Me.grpUserCtrl.Controls.Add(Me.txtUserName)
        Me.grpUserCtrl.Controls.Add(Me.btnShared)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblUserName)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(366, 376)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = False
        Me.grpUserCtrl.Text = "SocialNetwork"
        '
        'txtSentRequestOn
        '
        Me.txtSentRequestOn.Enabled = False
        Me.txtSentRequestOn.Location = New System.Drawing.Point(291, 120)
        Me.txtSentRequestOn.MaxLength = 255
        Me.txtSentRequestOn.Name = "txtSentRequestOn"
        Me.txtSentRequestOn.Size = New System.Drawing.Size(52, 20)
        Me.txtSentRequestOn.TabIndex = 173
        Me.txtSentRequestOn.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(98, 196)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(245, 66)
        Me.txtNotes.TabIndex = 8
        '
        'cboSocialNetworkStatus
        '
        Me.cboSocialNetworkStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSocialNetworkStatus.Location = New System.Drawing.Point(98, 95)
        Me.cboSocialNetworkStatus.MyLabel = ""
        Me.cboSocialNetworkStatus.MyLabelVisible = False
        Me.cboSocialNetworkStatus.Name = "cboSocialNetworkStatus"
        Me.cboSocialNetworkStatus.SelectedSocialNetworkStatus = Nothing
        Me.cboSocialNetworkStatus.SelectedSocialNetworkStatusID = 0
        Me.cboSocialNetworkStatus.Size = New System.Drawing.Size(245, 24)
        Me.cboSocialNetworkStatus.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Status:"
        '
        'chkLikeUs
        '
        Me.chkLikeUs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLikeUs.AutoSize = True
        Me.chkLikeUs.Location = New System.Drawing.Point(98, 122)
        Me.chkLikeUs.Name = "chkLikeUs"
        Me.chkLikeUs.Size = New System.Drawing.Size(68, 17)
        Me.chkLikeUs.TabIndex = 4
        Me.chkLikeUs.Text = "Like Us?"
        Me.chkLikeUs.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURL.Location = New System.Drawing.Point(98, 45)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(245, 20)
        Me.txtURL.TabIndex = 1
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(18, 45)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(32, 13)
        Me.lblURL.TabIndex = 31
        Me.lblURL.Text = "URL:"
        '
        'chkBestSocialNetwork
        '
        Me.chkBestSocialNetwork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkBestSocialNetwork.AutoSize = True
        Me.chkBestSocialNetwork.Location = New System.Drawing.Point(98, 268)
        Me.chkBestSocialNetwork.Name = "chkBestSocialNetwork"
        Me.chkBestSocialNetwork.Size = New System.Drawing.Size(276, 17)
        Me.chkBestSocialNetwork.TabIndex = 9
        Me.chkBestSocialNetwork.Text = "This is the 'best' Social Network for this case member"
        Me.chkBestSocialNetwork.UseVisualStyleBackColor = True
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(98, 321)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblWarning.Size = New System.Drawing.Size(245, 45)
        Me.lblWarning.TabIndex = 11
        Me.lblWarning.Text = "Note: Changing any information on this shared Social Network will also apply thos" & _
    "e changes to all other members of this case."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = False
        '
        'lblSourceQuality
        '
        Me.lblSourceQuality.AutoSize = True
        Me.lblSourceQuality.Location = New System.Drawing.Point(18, 171)
        Me.lblSourceQuality.Name = "lblSourceQuality"
        Me.lblSourceQuality.Size = New System.Drawing.Size(42, 13)
        Me.lblSourceQuality.TabIndex = 6
        Me.lblSourceQuality.Text = "Quality:"
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoSize = True
        Me.lblSourceType.Location = New System.Drawing.Point(18, 146)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(44, 13)
        Me.lblSourceType.TabIndex = 4
        Me.lblSourceType.Text = "Source:"
        '
        'lblSocialNetworkType
        '
        Me.lblSocialNetworkType.AutoSize = True
        Me.lblSocialNetworkType.Location = New System.Drawing.Point(18, 70)
        Me.lblSocialNetworkType.Name = "lblSocialNetworkType"
        Me.lblSocialNetworkType.Size = New System.Drawing.Size(34, 13)
        Me.lblSocialNetworkType.TabIndex = 2
        Me.lblSocialNetworkType.Text = "Type:"
        '
        'cboSourceType
        '
        Me.cboSourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceType.Location = New System.Drawing.Point(98, 146)
        Me.cboSourceType.MyLabel = "Source:"
        Me.cboSourceType.MyLabelVisible = False
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.SelectedSourceType = Nothing
        Me.cboSourceType.SelectedSourceTypeID = 0
        Me.cboSourceType.Size = New System.Drawing.Size(245, 21)
        Me.cboSourceType.TabIndex = 6
        '
        'cboSocialNetworkType
        '
        Me.cboSocialNetworkType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSocialNetworkType.Location = New System.Drawing.Point(98, 70)
        Me.cboSocialNetworkType.MyLabel = "SocialNetwork type:"
        Me.cboSocialNetworkType.MyLabelVisible = False
        Me.cboSocialNetworkType.Name = "cboSocialNetworkType"
        Me.cboSocialNetworkType.SelectedSocialNetworkType = Nothing
        Me.cboSocialNetworkType.SelectedSocialNetworkTypeID = 0
        Me.cboSocialNetworkType.Size = New System.Drawing.Size(245, 24)
        Me.cboSocialNetworkType.TabIndex = 2
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Location = New System.Drawing.Point(98, 20)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(245, 20)
        Me.txtUserName.TabIndex = 0
        '
        'btnShared
        '
        Me.btnShared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShared.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnShared.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnShared.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShared.ImageKey = "users.bmp"
        Me.btnShared.ImageList = Me.ImageList
        Me.btnShared.Location = New System.Drawing.Point(98, 297)
        Me.btnShared.Name = "btnShared"
        Me.btnShared.Size = New System.Drawing.Size(245, 21)
        Me.btnShared.TabIndex = 10
        Me.btnShared.Text = "This Social Network is shared with all case members"
        Me.btnShared.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShared.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList.Images.SetKeyName(0, "user.bmp")
        Me.ImageList.Images.SetKeyName(1, "users.bmp")
        '
        'cboSourceQuality
        '
        Me.cboSourceQuality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceQuality.Location = New System.Drawing.Point(98, 171)
        Me.cboSourceQuality.MyLabel = "Quality:"
        Me.cboSourceQuality.MyLabelVisible = False
        Me.cboSourceQuality.Name = "cboSourceQuality"
        Me.cboSourceQuality.SelectedSourceQuality = Nothing
        Me.cboSourceQuality.SelectedSourceQualityID = 0
        Me.cboSourceQuality.Size = New System.Drawing.Size(245, 22)
        Me.cboSourceQuality.TabIndex = 7
        '
        'TextValidator
        '
        Me.TextValidator.ControlToValidate = Me.txtUserName
        Me.TextValidator.ErrorMessage = "SocialNetwork is required"
        Me.TextValidator.Icon = CType(resources.GetObject("TextValidator.Icon"), System.Drawing.Icon)
        '
        'EditSocialNetwork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditSocialNetwork"
        Me.Size = New System.Drawing.Size(366, 376)
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents cboSourceType As MPR.SMS.UserControls.SourceTypeComboBox
    Friend WithEvents cboSourceQuality As MPR.SMS.UserControls.SourceQualityComboBox
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents btnShared As System.Windows.Forms.Button
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents cboSocialNetworkType As MPR.SMS.UserControls.SocialNetworkTypeComboBox
    Friend WithEvents lblSourceQuality As System.Windows.Forms.Label
    Friend WithEvents lblSourceType As System.Windows.Forms.Label
    Friend WithEvents lblSocialNetworkType As System.Windows.Forms.Label
    Protected WithEvents TextValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents chkBestSocialNetwork As System.Windows.Forms.CheckBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents chkLikeUs As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSocialNetworkStatus As MPR.SMS.UserControls.SocialNetworkStatusComboBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSentRequestOn As System.Windows.Forms.TextBox

End Class
