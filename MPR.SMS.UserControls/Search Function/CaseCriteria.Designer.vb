'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CaseCriteria
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
        Me.grpCases = New System.Windows.Forms.GroupBox
        Me.chkExcludeIneligibles = New System.Windows.Forms.CheckBox
        Me.optCaseType = New System.Windows.Forms.RadioButton
        Me.optAllCaseTypes = New System.Windows.Forms.RadioButton
        Me.chkInSample = New System.Windows.Forms.CheckBox
        Me.cboEntityType = New MPR.SMS.UserControls.EntityComboBox
        Me.grpCases.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCases
        '
        Me.grpCases.Controls.Add(Me.chkExcludeIneligibles)
        Me.grpCases.Controls.Add(Me.cboEntityType)
        Me.grpCases.Controls.Add(Me.optCaseType)
        Me.grpCases.Controls.Add(Me.optAllCaseTypes)
        Me.grpCases.Controls.Add(Me.chkInSample)
        Me.grpCases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCases.Location = New System.Drawing.Point(0, 0)
        Me.grpCases.Name = "grpCases"
        Me.grpCases.Size = New System.Drawing.Size(271, 119)
        Me.grpCases.TabIndex = 0
        Me.grpCases.TabStop = False
        Me.grpCases.Text = "Case criteria"
        '
        'chkExcludeIneligibles
        '
        Me.chkExcludeIneligibles.AutoSize = True
        Me.chkExcludeIneligibles.Checked = True
        Me.chkExcludeIneligibles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcludeIneligibles.Location = New System.Drawing.Point(7, 43)
        Me.chkExcludeIneligibles.Name = "chkExcludeIneligibles"
        Me.chkExcludeIneligibles.Size = New System.Drawing.Size(118, 17)
        Me.chkExcludeIneligibles.TabIndex = 1
        Me.chkExcludeIneligibles.Text = "Exclude ineligibles?"
        Me.chkExcludeIneligibles.UseVisualStyleBackColor = True
        '
        'optCaseType
        '
        Me.optCaseType.AutoSize = True
        Me.optCaseType.Location = New System.Drawing.Point(7, 89)
        Me.optCaseType.Name = "optCaseType"
        Me.optCaseType.Size = New System.Drawing.Size(119, 17)
        Me.optCaseType.TabIndex = 4
        Me.optCaseType.Text = "This case type only:"
        Me.optCaseType.UseVisualStyleBackColor = True
        '
        'optAllCaseTypes
        '
        Me.optAllCaseTypes.AutoSize = True
        Me.optAllCaseTypes.Checked = True
        Me.optAllCaseTypes.Location = New System.Drawing.Point(7, 66)
        Me.optAllCaseTypes.Name = "optAllCaseTypes"
        Me.optAllCaseTypes.Size = New System.Drawing.Size(90, 17)
        Me.optAllCaseTypes.TabIndex = 3
        Me.optAllCaseTypes.TabStop = True
        Me.optAllCaseTypes.Text = "All case types"
        Me.optAllCaseTypes.UseVisualStyleBackColor = True
        '
        'chkInSample
        '
        Me.chkInSample.AutoSize = True
        Me.chkInSample.Checked = True
        Me.chkInSample.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInSample.Location = New System.Drawing.Point(7, 20)
        Me.chkInSample.Name = "chkInSample"
        Me.chkInSample.Size = New System.Drawing.Size(99, 17)
        Me.chkInSample.TabIndex = 0
        Me.chkInSample.Text = "In-sample only?"
        Me.chkInSample.UseVisualStyleBackColor = True
        '
        'cboEntityType
        '
        Me.cboEntityType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEntityType.Enabled = False
        Me.cboEntityType.EntityAsSampleFilter = True
        Me.cboEntityType.Location = New System.Drawing.Point(124, 89)
        Me.cboEntityType.MyLabel = "Case type:"
        Me.cboEntityType.MyLabelVisible = False
        Me.cboEntityType.Name = "cboEntityType"
        Me.cboEntityType.SelectedEntityType = Nothing
        Me.cboEntityType.SelectedEntityTypeID = -1
        Me.cboEntityType.SelectedIndex = -1
        Me.cboEntityType.Size = New System.Drawing.Size(141, 21)
        Me.cboEntityType.TabIndex = 5
        '
        'CaseCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpCases)
        Me.Name = "CaseCriteria"
        Me.Size = New System.Drawing.Size(271, 119)
        Me.grpCases.ResumeLayout(False)
        Me.grpCases.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpCases As System.Windows.Forms.GroupBox
    Friend WithEvents chkExcludeIneligibles As System.Windows.Forms.CheckBox
    Friend WithEvents cboEntityType As MPR.SMS.UserControls.EntityComboBox
    Friend WithEvents optCaseType As System.Windows.Forms.RadioButton
    Friend WithEvents optAllCaseTypes As System.Windows.Forms.RadioButton
    Friend WithEvents chkInSample As System.Windows.Forms.CheckBox

End Class
