'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditCaseRA
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
        Me.txtRandStatus = New System.Windows.Forms.TextBox()
        Me.lblRandNum = New System.Windows.Forms.Label()
        Me.lblRandStatus = New System.Windows.Forms.Label()
        Me.txtRandNum = New System.Windows.Forms.TextBox()
        Me.lblRandDate = New System.Windows.Forms.Label()
        Me.txtRandDate = New MPR.SMS.UserControls.DateWithValidator()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.lblDupes = New System.Windows.Forms.Label()
        Me.chkOverride = New System.Windows.Forms.CheckBox()
        Me.grdErrors = New System.Windows.Forms.DataGridView()
        Me.grdDuplicates = New System.Windows.Forms.DataGridView()
        CType(Me.grdErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDuplicates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRandStatus
        '
        Me.txtRandStatus.Location = New System.Drawing.Point(122, 37)
        Me.txtRandStatus.MaxLength = 1
        Me.txtRandStatus.Name = "txtRandStatus"
        Me.txtRandStatus.Size = New System.Drawing.Size(20, 20)
        Me.txtRandStatus.TabIndex = 3
        '
        'lblRandNum
        '
        Me.lblRandNum.AutoSize = True
        Me.lblRandNum.Location = New System.Drawing.Point(9, 14)
        Me.lblRandNum.Name = "lblRandNum"
        Me.lblRandNum.Size = New System.Drawing.Size(60, 13)
        Me.lblRandNum.TabIndex = 0
        Me.lblRandNum.Text = "Random #:"
        '
        'lblRandStatus
        '
        Me.lblRandStatus.AutoSize = True
        Me.lblRandStatus.Location = New System.Drawing.Point(9, 38)
        Me.lblRandStatus.Name = "lblRandStatus"
        Me.lblRandStatus.Size = New System.Drawing.Size(111, 13)
        Me.lblRandStatus.TabIndex = 2
        Me.lblRandStatus.Text = "Randomization status:"
        '
        'txtRandNum
        '
        Me.txtRandNum.Location = New System.Drawing.Point(122, 11)
        Me.txtRandNum.MaxLength = 20
        Me.txtRandNum.Name = "txtRandNum"
        Me.txtRandNum.Size = New System.Drawing.Size(152, 20)
        Me.txtRandNum.TabIndex = 1
        '
        'lblRandDate
        '
        Me.lblRandDate.AutoSize = True
        Me.lblRandDate.Location = New System.Drawing.Point(9, 64)
        Me.lblRandDate.Name = "lblRandDate"
        Me.lblRandDate.Size = New System.Drawing.Size(104, 13)
        Me.lblRandDate.TabIndex = 4
        Me.lblRandDate.Text = "Randomization date:"
        '
        'txtRandDate
        '
        Me.txtRandDate.Location = New System.Drawing.Point(122, 64)
        Me.txtRandDate.Name = "txtRandDate"
        Me.txtRandDate.ReadOnly = False
        Me.txtRandDate.Required = False
        Me.txtRandDate.Size = New System.Drawing.Size(96, 20)
        Me.txtRandDate.TabIndex = 5
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(9, 98)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(37, 13)
        Me.lblErrors.TabIndex = 6
        Me.lblErrors.Text = "Errors:"
        '
        'lblDupes
        '
        Me.lblDupes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDupes.AutoSize = True
        Me.lblDupes.Location = New System.Drawing.Point(9, 253)
        Me.lblDupes.Name = "lblDupes"
        Me.lblDupes.Size = New System.Drawing.Size(60, 13)
        Me.lblDupes.TabIndex = 8
        Me.lblDupes.Text = "Duplicates:"
        '
        'chkOverride
        '
        Me.chkOverride.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOverride.AutoSize = True
        Me.chkOverride.Location = New System.Drawing.Point(334, 252)
        Me.chkOverride.Name = "chkOverride"
        Me.chkOverride.Size = New System.Drawing.Size(119, 17)
        Me.chkOverride.TabIndex = 9
        Me.chkOverride.Text = "Override Duplicates"
        Me.chkOverride.UseVisualStyleBackColor = True
        '
        'grdErrors
        '
        Me.grdErrors.AllowUserToAddRows = False
        Me.grdErrors.AllowUserToDeleteRows = False
        Me.grdErrors.AllowUserToOrderColumns = True
        Me.grdErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdErrors.Location = New System.Drawing.Point(12, 114)
        Me.grdErrors.Name = "grdErrors"
        Me.grdErrors.ReadOnly = True
        Me.grdErrors.Size = New System.Drawing.Size(432, 132)
        Me.grdErrors.TabIndex = 7
        '
        'grdDuplicates
        '
        Me.grdDuplicates.AllowUserToAddRows = False
        Me.grdDuplicates.AllowUserToDeleteRows = False
        Me.grdDuplicates.AllowUserToOrderColumns = True
        Me.grdDuplicates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDuplicates.Location = New System.Drawing.Point(12, 275)
        Me.grdDuplicates.Name = "grdDuplicates"
        Me.grdDuplicates.ReadOnly = True
        Me.grdDuplicates.Size = New System.Drawing.Size(432, 158)
        Me.grdDuplicates.TabIndex = 10
        '
        'EditCaseRA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.grdDuplicates)
        Me.Controls.Add(Me.grdErrors)
        Me.Controls.Add(Me.chkOverride)
        Me.Controls.Add(Me.lblDupes)
        Me.Controls.Add(Me.lblErrors)
        Me.Controls.Add(Me.txtRandStatus)
        Me.Controls.Add(Me.txtRandDate)
        Me.Controls.Add(Me.lblRandDate)
        Me.Controls.Add(Me.txtRandNum)
        Me.Controls.Add(Me.lblRandStatus)
        Me.Controls.Add(Me.lblRandNum)
        Me.Name = "EditCaseRA"
        Me.Size = New System.Drawing.Size(456, 448)
        CType(Me.grdErrors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDuplicates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRandNum As System.Windows.Forms.Label
    Friend WithEvents txtRandStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblRandStatus As System.Windows.Forms.Label
    Friend WithEvents txtRandNum As System.Windows.Forms.TextBox
    Friend WithEvents lblRandDate As System.Windows.Forms.Label
    Friend WithEvents txtRandDate As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents lblDupes As System.Windows.Forms.Label
    Friend WithEvents chkOverride As System.Windows.Forms.CheckBox
    Friend WithEvents grdErrors As System.Windows.Forms.DataGridView
    Friend WithEvents grdDuplicates As System.Windows.Forms.DataGridView

End Class
