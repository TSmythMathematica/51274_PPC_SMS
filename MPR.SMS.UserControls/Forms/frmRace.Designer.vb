'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GrpRace = New System.Windows.Forms.GroupBox
        Me.lstItems = New System.Windows.Forms.CheckedListBox
        Me.lblEthnicity = New System.Windows.Forms.Label
        Me.chkHispanic = New System.Windows.Forms.CheckBox
        Me.lblOther = New System.Windows.Forms.Label
        Me.txtOther = New System.Windows.Forms.TextBox
        Me.GrpRace.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(291, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(291, 41)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GrpRace
        '
        Me.GrpRace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRace.Controls.Add(Me.lstItems)
        Me.GrpRace.Location = New System.Drawing.Point(0, 2)
        Me.GrpRace.Name = "GrpRace"
        Me.GrpRace.Size = New System.Drawing.Size(285, 135)
        Me.GrpRace.TabIndex = 0
        Me.GrpRace.TabStop = False
        Me.GrpRace.Text = "Select all Races that apply:"
        '
        'lstItems
        '
        Me.lstItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItems.CheckOnClick = True
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(6, 18)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(273, 109)
        Me.lstItems.TabIndex = 0
        Me.lstItems.ThreeDCheckBoxes = True
        '
        'lblEthnicity
        '
        Me.lblEthnicity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEthnicity.AutoSize = True
        Me.lblEthnicity.Location = New System.Drawing.Point(3, 171)
        Me.lblEthnicity.Name = "lblEthnicity"
        Me.lblEthnicity.Size = New System.Drawing.Size(50, 13)
        Me.lblEthnicity.TabIndex = 3
        Me.lblEthnicity.Text = "Ethnicity:"
        '
        'chkHispanic
        '
        Me.chkHispanic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkHispanic.AutoSize = True
        Me.chkHispanic.Location = New System.Drawing.Point(59, 170)
        Me.chkHispanic.Name = "chkHispanic"
        Me.chkHispanic.Size = New System.Drawing.Size(67, 17)
        Me.chkHispanic.TabIndex = 4
        Me.chkHispanic.Text = "Hispanic"
        Me.chkHispanic.UseVisualStyleBackColor = True
        '
        'lblOther
        '
        Me.lblOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOther.AutoSize = True
        Me.lblOther.Location = New System.Drawing.Point(3, 149)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(128, 13)
        Me.lblOther.TabIndex = 1
        Me.lblOther.Text = "If ""Other"", please specify:"
        '
        'txtOther
        '
        Me.txtOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOther.Location = New System.Drawing.Point(138, 149)
        Me.txtOther.MaxLength = 50
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(141, 20)
        Me.txtOther.TabIndex = 2
        '
        'frmRace
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(370, 193)
        Me.Controls.Add(Me.txtOther)
        Me.Controls.Add(Me.lblOther)
        Me.Controls.Add(Me.chkHispanic)
        Me.Controls.Add(Me.lblEthnicity)
        Me.Controls.Add(Me.GrpRace)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmRace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Race/Ethnicities"
        Me.GrpRace.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GrpRace As System.Windows.Forms.GroupBox
    Friend WithEvents lstItems As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblEthnicity As System.Windows.Forms.Label
    Friend WithEvents chkHispanic As System.Windows.Forms.CheckBox
    Friend WithEvents lblOther As System.Windows.Forms.Label
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
End Class
