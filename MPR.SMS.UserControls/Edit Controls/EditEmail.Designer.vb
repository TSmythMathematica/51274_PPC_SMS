'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditEmail))
        Me.lblEmail = New System.Windows.Forms.Label
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox
        Me.lblWarning = New System.Windows.Forms.Label
        Me.imgIcon = New System.Windows.Forms.PictureBox
        Me.lblSourceQuality = New System.Windows.Forms.Label
        Me.lblSourceType = New System.Windows.Forms.Label
        Me.lblEmailType = New System.Windows.Forms.Label
        Me.cboSourceType = New MPR.SMS.UserControls.SourceTypeComboBox
        Me.cboEmailType = New MPR.SMS.UserControls.EmailTypeComboBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.btnShared = New System.Windows.Forms.Button
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.cboSourceQuality = New MPR.SMS.UserControls.SourceQualityComboBox
        Me.TextValidator = New MPR.Windows.Forms.Validation.CustomValidator
        Me.chkBestEmail = New System.Windows.Forms.CheckBox
        Me.grpUserCtrl.SuspendLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(7, 18)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblEmail.TabIndex = 0
        Me.lblEmail.Text = "Email:"
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Controls.Add(Me.chkBestEmail)
        Me.grpUserCtrl.Controls.Add(Me.lblWarning)
        Me.grpUserCtrl.Controls.Add(Me.imgIcon)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceType)
        Me.grpUserCtrl.Controls.Add(Me.lblEmailType)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceType)
        Me.grpUserCtrl.Controls.Add(Me.cboEmailType)
        Me.grpUserCtrl.Controls.Add(Me.txtEmail)
        Me.grpUserCtrl.Controls.Add(Me.btnShared)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceQuality)
        Me.grpUserCtrl.Controls.Add(Me.lblEmail)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(300, 227)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = False
        Me.grpUserCtrl.Text = "Email"
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblWarning.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(42, 170)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Padding = New System.Windows.Forms.Padding(2)
        Me.lblWarning.Size = New System.Drawing.Size(231, 45)
        Me.lblWarning.TabIndex = 9
        Me.lblWarning.Text = "Note: Changing any information on this shared email will also apply those changes" & _
            " to all other members of this case."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = False
        '
        'imgIcon
        '
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Image)
        Me.imgIcon.Location = New System.Drawing.Point(40, 1)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(16, 14)
        Me.imgIcon.TabIndex = 9
        Me.imgIcon.TabStop = False
        '
        'lblSourceQuality
        '
        Me.lblSourceQuality.AutoSize = True
        Me.lblSourceQuality.Location = New System.Drawing.Point(7, 91)
        Me.lblSourceQuality.Name = "lblSourceQuality"
        Me.lblSourceQuality.Size = New System.Drawing.Size(42, 13)
        Me.lblSourceQuality.TabIndex = 6
        Me.lblSourceQuality.Text = "Quality:"
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoSize = True
        Me.lblSourceType.Location = New System.Drawing.Point(7, 68)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(44, 13)
        Me.lblSourceType.TabIndex = 4
        Me.lblSourceType.Text = "Source:"
        '
        'lblEmailType
        '
        Me.lblEmailType.AutoSize = True
        Me.lblEmailType.Location = New System.Drawing.Point(7, 45)
        Me.lblEmailType.Name = "lblEmailType"
        Me.lblEmailType.Size = New System.Drawing.Size(58, 13)
        Me.lblEmailType.TabIndex = 2
        Me.lblEmailType.Text = "Email type:"
        '
        'cboSourceType
        '
        Me.cboSourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceType.Location = New System.Drawing.Point(72, 68)
        Me.cboSourceType.MyLabel = "Source:"
        Me.cboSourceType.MyLabelVisible = False
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.SelectedSourceType = Nothing
        Me.cboSourceType.SelectedSourceTypeID = 0
        Me.cboSourceType.Size = New System.Drawing.Size(220, 21)
        Me.cboSourceType.TabIndex = 5
        '
        'cboEmailType
        '
        Me.cboEmailType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEmailType.Location = New System.Drawing.Point(72, 45)
        Me.cboEmailType.MyLabel = "Email type:"
        Me.cboEmailType.MyLabelVisible = False
        Me.cboEmailType.Name = "cboEmailType"
        Me.cboEmailType.SelectedEmailType = Nothing
        Me.cboEmailType.SelectedEmailTypeID = 0
        Me.cboEmailType.Size = New System.Drawing.Size(220, 24)
        Me.cboEmailType.TabIndex = 3
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(72, 19)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(205, 20)
        Me.txtEmail.TabIndex = 1
        '
        'btnShared
        '
        Me.btnShared.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnShared.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnShared.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnShared.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShared.ImageKey = "users.bmp"
        Me.btnShared.ImageList = Me.ImageList
        Me.btnShared.Location = New System.Drawing.Point(42, 142)
        Me.btnShared.Name = "btnShared"
        Me.btnShared.Size = New System.Drawing.Size(231, 21)
        Me.btnShared.TabIndex = 8
        Me.btnShared.Text = "This email is shared with all case members"
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
        Me.cboSourceQuality.Location = New System.Drawing.Point(72, 91)
        Me.cboSourceQuality.MyLabel = "Quality:"
        Me.cboSourceQuality.MyLabelVisible = False
        Me.cboSourceQuality.Name = "cboSourceQuality"
        Me.cboSourceQuality.SelectedSourceQuality = Nothing
        Me.cboSourceQuality.SelectedSourceQualityID = 0
        Me.cboSourceQuality.Size = New System.Drawing.Size(220, 22)
        Me.cboSourceQuality.TabIndex = 7
        '
        'TextValidator
        '
        Me.TextValidator.ControlToValidate = Me.txtEmail
        Me.TextValidator.ErrorMessage = "Email is required"
        Me.TextValidator.Icon = CType(resources.GetObject("TextValidator.Icon"), System.Drawing.Icon)
        '
        'chkBestEmail
        '
        Me.chkBestEmail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkBestEmail.AutoSize = True
        Me.chkBestEmail.Location = New System.Drawing.Point(42, 119)
        Me.chkBestEmail.Name = "chkBestEmail"
        Me.chkBestEmail.Size = New System.Drawing.Size(228, 17)
        Me.chkBestEmail.TabIndex = 29
        Me.chkBestEmail.Text = "This is the 'best' email for this case member"
        Me.chkBestEmail.UseVisualStyleBackColor = True
        '
        'EditEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditEmail"
        Me.Size = New System.Drawing.Size(300, 227)
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents cboSourceType As MPR.SMS.UserControls.SourceTypeComboBox
    Friend WithEvents cboSourceQuality As MPR.SMS.UserControls.SourceQualityComboBox
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents btnShared As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cboEmailType As MPR.SMS.UserControls.EmailTypeComboBox
    Friend WithEvents lblSourceQuality As System.Windows.Forms.Label
    Friend WithEvents lblSourceType As System.Windows.Forms.Label
    Friend WithEvents lblEmailType As System.Windows.Forms.Label
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Protected WithEvents TextValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents chkBestEmail As System.Windows.Forms.CheckBox

End Class
