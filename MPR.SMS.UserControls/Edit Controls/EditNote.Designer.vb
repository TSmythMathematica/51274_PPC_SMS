'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditNote
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditNote))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TextValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblNoteType = New System.Windows.Forms.Label()
        Me.lblSourceType = New System.Windows.Forms.Label()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox()
        Me.chkShowInField = New System.Windows.Forms.CheckBox()
        Me.ViewNotes = New MPR.SMS.UserControls.ViewNotes()
        Me.cboSourceType = New MPR.SMS.UserControls.SourceTypeComboBox()
        Me.cboNoteType = New MPR.SMS.UserControls.NoteTypeComboBox()
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUserCtrl.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList.Images.SetKeyName(0, "user.bmp")
        Me.ImageList.Images.SetKeyName(1, "users.bmp")
        '
        'TextValidator
        '
        Me.TextValidator.ControlToValidate = Me.txtNotes
        Me.TextValidator.ErrorMessage = "Note is required"
        Me.TextValidator.Icon = CType(resources.GetObject("TextValidator.Icon"), System.Drawing.Icon)
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(69, 248)
        Me.txtNotes.MaxLength = 4000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(561, 58)
        Me.txtNotes.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(4, 247)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(38, 13)
        Me.lblNotes.TabIndex = 4
        Me.lblNotes.Text = "Notes:"
        '
        'lblNoteType
        '
        Me.lblNoteType.AutoSize = True
        Me.lblNoteType.Location = New System.Drawing.Point(4, 189)
        Me.lblNoteType.Name = "lblNoteType"
        Me.lblNoteType.Size = New System.Drawing.Size(56, 13)
        Me.lblNoteType.TabIndex = 0
        Me.lblNoteType.Text = "Note type:"
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoSize = True
        Me.lblSourceType.Location = New System.Drawing.Point(4, 212)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(44, 13)
        Me.lblSourceType.TabIndex = 2
        Me.lblSourceType.Text = "Source:"
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
        'grpUserCtrl
        '
        Me.grpUserCtrl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpUserCtrl.Controls.Add(Me.chkShowInField)
        Me.grpUserCtrl.Controls.Add(Me.ViewNotes)
        Me.grpUserCtrl.Controls.Add(Me.imgIcon)
        Me.grpUserCtrl.Controls.Add(Me.lblSourceType)
        Me.grpUserCtrl.Controls.Add(Me.lblNoteType)
        Me.grpUserCtrl.Controls.Add(Me.cboSourceType)
        Me.grpUserCtrl.Controls.Add(Me.cboNoteType)
        Me.grpUserCtrl.Controls.Add(Me.txtNotes)
        Me.grpUserCtrl.Controls.Add(Me.lblNotes)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Margin = New System.Windows.Forms.Padding(0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Padding = New System.Windows.Forms.Padding(0)
        Me.grpUserCtrl.Size = New System.Drawing.Size(637, 321)
        Me.grpUserCtrl.TabIndex = 1
        Me.grpUserCtrl.TabStop = False
        Me.grpUserCtrl.Text = "Notes"
        '
        'chkShowInField
        '
        Me.chkShowInField.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowInField.AutoSize = True
        Me.chkShowInField.Checked = True
        Me.chkShowInField.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowInField.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowInField.Location = New System.Drawing.Point(528, 216)
        Me.chkShowInField.Name = "chkShowInField"
        Me.chkShowInField.Size = New System.Drawing.Size(105, 17)
        Me.chkShowInField.TabIndex = 11
        Me.chkShowInField.Text = "Is Field Note?"
        Me.chkShowInField.UseVisualStyleBackColor = True
        '
        'ViewNotes
        '
        Me.ViewNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewNotes.Location = New System.Drawing.Point(6, 19)
        Me.ViewNotes.Name = "ViewNotes"
        Me.ViewNotes.SelectedAddress = Nothing
        Me.ViewNotes.SelectedCase = Nothing
        Me.ViewNotes.SelectedNote = Nothing
        Me.ViewNotes.Size = New System.Drawing.Size(625, 170)
        Me.ViewNotes.TabIndex = 10
        '
        'cboSourceType
        '
        Me.cboSourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSourceType.Location = New System.Drawing.Point(69, 212)
        Me.cboSourceType.MyLabel = "Source:"
        Me.cboSourceType.MyLabelVisible = False
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.SelectedSourceType = Nothing
        Me.cboSourceType.SelectedSourceTypeID = 0
        Me.cboSourceType.Size = New System.Drawing.Size(406, 21)
        Me.cboSourceType.TabIndex = 3
        '
        'cboNoteType
        '
        Me.cboNoteType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboNoteType.Location = New System.Drawing.Point(69, 189)
        Me.cboNoteType.MyLabel = "Note type:"
        Me.cboNoteType.MyLabelVisible = False
        Me.cboNoteType.Name = "cboNoteType"
        Me.cboNoteType.Size = New System.Drawing.Size(406, 24)
        Me.cboNoteType.TabIndex = 1
        '
        'EditNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditNote"
        Me.Size = New System.Drawing.Size(637, 321)
        CType(Me.TextValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Protected WithEvents TextValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents cboNoteType As MPR.SMS.UserControls.NoteTypeComboBox
    Friend WithEvents cboSourceType As MPR.SMS.UserControls.SourceTypeComboBox
    Friend WithEvents lblNoteType As System.Windows.Forms.Label
    Friend WithEvents lblSourceType As System.Windows.Forms.Label
    Friend WithEvents imgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents ViewNotes As MPR.SMS.UserControls.ViewNotes
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowInField As System.Windows.Forms.CheckBox

End Class
