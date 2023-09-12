'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditLocatingStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditLocatingStatus))
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.lblStatusDate = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblStatusCode = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtModifiedBy = New System.Windows.Forms.TextBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDate = New MPR.SMS.UserControls.DateWithValidator()
        Me.cboStatus = New MPR.SMS.UserControls.StatusComboBox()
        Me.StatusValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.grpStatus.SuspendLayout()
        CType(Me.StatusValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedBy.AutoSize = True
        Me.lblModifiedBy.Location = New System.Drawing.Point(181, 184)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Size = New System.Drawing.Size(64, 13)
        Me.lblModifiedBy.TabIndex = 6
        Me.lblModifiedBy.Text = "Modified by:"
        '
        'lblStatusDate
        '
        Me.lblStatusDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatusDate.AutoSize = True
        Me.lblStatusDate.Location = New System.Drawing.Point(5, 184)
        Me.lblStatusDate.Name = "lblStatusDate"
        Me.lblStatusDate.Size = New System.Drawing.Size(64, 13)
        Me.lblStatusDate.TabIndex = 4
        Me.lblStatusDate.Text = "Status date:"
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(5, 74)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(38, 13)
        Me.lblNotes.TabIndex = 2
        Me.lblNotes.Text = "Notes:"
        '
        'lblStatusCode
        '
        Me.lblStatusCode.AutoSize = True
        Me.lblStatusCode.Location = New System.Drawing.Point(5, 42)
        Me.lblStatusCode.Name = "lblStatusCode"
        Me.lblStatusCode.Size = New System.Drawing.Size(67, 13)
        Me.lblStatusCode.TabIndex = 0
        Me.lblStatusCode.Text = "Status code:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(83, 74)
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(294, 99)
        Me.txtNotes.TabIndex = 3
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModifiedBy.Location = New System.Drawing.Point(251, 184)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.ReadOnly = True
        Me.txtModifiedBy.Size = New System.Drawing.Size(116, 20)
        Me.txtModifiedBy.TabIndex = 7
        '
        'grpStatus
        '
        Me.grpStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStatus.Controls.Add(Me.lblStatus)
        Me.grpStatus.Controls.Add(Me.Label1)
        Me.grpStatus.Controls.Add(Me.lblStatusCode)
        Me.grpStatus.Controls.Add(Me.txtDate)
        Me.grpStatus.Controls.Add(Me.lblModifiedBy)
        Me.grpStatus.Controls.Add(Me.cboStatus)
        Me.grpStatus.Controls.Add(Me.txtNotes)
        Me.grpStatus.Controls.Add(Me.txtModifiedBy)
        Me.grpStatus.Controls.Add(Me.lblNotes)
        Me.grpStatus.Controls.Add(Me.lblStatusDate)
        Me.grpStatus.Location = New System.Drawing.Point(3, 3)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(2)
        Me.grpStatus.Size = New System.Drawing.Size(386, 214)
        Me.grpStatus.TabIndex = 0
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Respondent status:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(82, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Current Status:"
        '
        'txtDate
        '
        Me.txtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDate.Location = New System.Drawing.Point(83, 181)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Required = True
        Me.txtDate.Size = New System.Drawing.Size(86, 23)
        Me.txtDate.TabIndex = 5
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.Location = New System.Drawing.Point(83, 42)
        Me.cboStatus.MyLabel = "Status:"
        Me.cboStatus.MyLabelVisible = False
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.SelectedStatus = Nothing
        Me.cboStatus.Size = New System.Drawing.Size(294, 24)
        Me.cboStatus.TabIndex = 1
        '
        'StatusValidator
        '
        Me.StatusValidator.ControlToValidate = Me.cboStatus
        Me.StatusValidator.ErrorMessage = "Status code is required"
        Me.StatusValidator.Icon = CType(resources.GetObject("StatusValidator.Icon"), System.Drawing.Icon)
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'EditLocatingStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpStatus)
        Me.Name = "EditLocatingStatus"
        Me.Size = New System.Drawing.Size(389, 217)
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        CType(Me.StatusValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblModifiedBy As System.Windows.Forms.Label
    Friend WithEvents cboStatus As MPR.SMS.UserControls.StatusComboBox
    Friend WithEvents txtModifiedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusDate As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblStatusCode As System.Windows.Forms.Label
    Friend WithEvents txtDate As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents StatusValidator As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents lblStatus As System.Windows.Forms.Label

End Class
