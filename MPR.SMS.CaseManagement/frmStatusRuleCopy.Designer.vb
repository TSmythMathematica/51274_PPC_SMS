'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatusRuleCopy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatusRuleCopy))
        Me.btnGo = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.cboStatusFrom = New MPR.SMS.UserControls.StatusComboBox
        Me.cboStatusTo = New MPR.SMS.UserControls.StatusComboBox
        Me.SuspendLayout()
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.BackColor = System.Drawing.SystemColors.Control
        Me.btnGo.CausesValidation = False
        Me.btnGo.Enabled = False
        Me.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGo.Location = New System.Drawing.Point(116, 87)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(68, 22)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "&OK"
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(190, 87)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(70, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboStatusFrom
        '
        Me.cboStatusFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatusFrom.Location = New System.Drawing.Point(12, 12)
        Me.cboStatusFrom.MyLabel = "Copy from:"
        Me.cboStatusFrom.Name = "cboStatusFrom"
        Me.cboStatusFrom.SelectedStatus = Nothing
        Me.cboStatusFrom.Size = New System.Drawing.Size(248, 24)
        Me.cboStatusFrom.TabIndex = 0
        '
        'cboStatusTo
        '
        Me.cboStatusTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatusTo.Location = New System.Drawing.Point(12, 42)
        Me.cboStatusTo.MyLabel = "to:"
        Me.cboStatusTo.Name = "cboStatusTo"
        Me.cboStatusTo.SelectedStatus = Nothing
        Me.cboStatusTo.Size = New System.Drawing.Size(248, 24)
        Me.cboStatusTo.TabIndex = 1
        '
        'frmStatusRuleCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(283, 122)
        Me.Controls.Add(Me.cboStatusTo)
        Me.Controls.Add(Me.cboStatusFrom)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStatusRuleCopy"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Copy Status Update Rules"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents cboStatusTo As MPR.SMS.UserControls.StatusComboBox
    Friend WithEvents cboStatusFrom As MPR.SMS.UserControls.StatusComboBox
End Class
