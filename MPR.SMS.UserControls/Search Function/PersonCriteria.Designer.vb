'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PersonCriteria
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
        Me.grpPerson = New System.Windows.Forms.GroupBox
        Me.optCaseType = New System.Windows.Forms.RadioButton
        Me.optAllCaseTypes = New System.Windows.Forms.RadioButton
        Me.cboRelationshipType = New MPR.SMS.UserControls.RelationshipTypeComboBox
        Me.grpPerson.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPerson
        '
        Me.grpPerson.Controls.Add(Me.cboRelationshipType)
        Me.grpPerson.Controls.Add(Me.optCaseType)
        Me.grpPerson.Controls.Add(Me.optAllCaseTypes)
        Me.grpPerson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPerson.Location = New System.Drawing.Point(0, 0)
        Me.grpPerson.Name = "grpPerson"
        Me.grpPerson.Size = New System.Drawing.Size(295, 75)
        Me.grpPerson.TabIndex = 0
        Me.grpPerson.TabStop = False
        Me.grpPerson.Text = "Case member criteria"
        '
        'optCaseType
        '
        Me.optCaseType.AutoSize = True
        Me.optCaseType.Location = New System.Drawing.Point(7, 43)
        Me.optCaseType.Name = "optCaseType"
        Me.optCaseType.Size = New System.Drawing.Size(133, 17)
        Me.optCaseType.TabIndex = 1
        Me.optCaseType.Text = "This member type only:"
        Me.optCaseType.UseVisualStyleBackColor = True
        '
        'optAllCaseTypes
        '
        Me.optAllCaseTypes.AutoSize = True
        Me.optAllCaseTypes.Checked = True
        Me.optAllCaseTypes.Location = New System.Drawing.Point(7, 20)
        Me.optAllCaseTypes.Name = "optAllCaseTypes"
        Me.optAllCaseTypes.Size = New System.Drawing.Size(107, 17)
        Me.optAllCaseTypes.TabIndex = 0
        Me.optAllCaseTypes.TabStop = True
        Me.optAllCaseTypes.Text = "All case members"
        Me.optAllCaseTypes.UseVisualStyleBackColor = True
        '
        'cboRelationshipType
        '
        Me.cboRelationshipType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRelationshipType.Enabled = False
        Me.cboRelationshipType.EntityTypeFilter = MPR.SMS.Data.Enumerations.tlkpEntityType.None
        Me.cboRelationshipType.Location = New System.Drawing.Point(139, 45)
        Me.cboRelationshipType.MyLabel = "Relationship:"
        Me.cboRelationshipType.MyLabelVisible = False
        Me.cboRelationshipType.Name = "cboRelationshipType"
        Me.cboRelationshipType.SelectedRelationshipType = Nothing
        Me.cboRelationshipType.SelectedRelationshipTypeID = 0
        Me.cboRelationshipType.Size = New System.Drawing.Size(150, 24)
        Me.cboRelationshipType.TabIndex = 2
        '
        'PersonCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpPerson)
        Me.Name = "PersonCriteria"
        Me.Size = New System.Drawing.Size(295, 75)
        Me.grpPerson.ResumeLayout(False)
        Me.grpPerson.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPerson As System.Windows.Forms.GroupBox
    Friend WithEvents optCaseType As System.Windows.Forms.RadioButton
    Friend WithEvents optAllCaseTypes As System.Windows.Forms.RadioButton
    Friend WithEvents cboRelationshipType As MPR.SMS.UserControls.RelationshipTypeComboBox

End Class
