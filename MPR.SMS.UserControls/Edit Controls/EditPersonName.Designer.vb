'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditPersonName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPersonName))
        Me.grpUserCtrl = New System.Windows.Forms.GroupBox
        Me.txtMPRID = New System.Windows.Forms.TextBox
        Me.lblMPRID = New System.Windows.Forms.Label
        Me.txtSuffix = New System.Windows.Forms.TextBox
        Me.txtMName = New System.Windows.Forms.TextBox
        Me.txtLName = New System.Windows.Forms.TextBox
        Me.txtFName = New System.Windows.Forms.TextBox
        Me.lblSuffix = New System.Windows.Forms.Label
        Me.lblLName = New System.Windows.Forms.Label
        Me.lblMI = New System.Windows.Forms.Label
        Me.lblFN = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.LastNameValidator = New MPR.Windows.Forms.Validation.RequiredFieldValidator
        Me.grpUserCtrl.SuspendLayout()
        CType(Me.LastNameValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpUserCtrl
        '
        Me.grpUserCtrl.Controls.Add(Me.txtMPRID)
        Me.grpUserCtrl.Controls.Add(Me.lblMPRID)
        Me.grpUserCtrl.Controls.Add(Me.txtSuffix)
        Me.grpUserCtrl.Controls.Add(Me.txtMName)
        Me.grpUserCtrl.Controls.Add(Me.txtLName)
        Me.grpUserCtrl.Controls.Add(Me.txtFName)
        Me.grpUserCtrl.Controls.Add(Me.lblSuffix)
        Me.grpUserCtrl.Controls.Add(Me.lblLName)
        Me.grpUserCtrl.Controls.Add(Me.lblMI)
        Me.grpUserCtrl.Controls.Add(Me.lblFN)
        Me.grpUserCtrl.Controls.Add(Me.lblName)
        Me.grpUserCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpUserCtrl.Location = New System.Drawing.Point(0, 0)
        Me.grpUserCtrl.Name = "grpUserCtrl"
        Me.grpUserCtrl.Size = New System.Drawing.Size(443, 60)
        Me.grpUserCtrl.TabIndex = 0
        Me.grpUserCtrl.TabStop = False
        '
        'txtMPRID
        '
        Me.txtMPRID.Location = New System.Drawing.Point(74, 19)
        Me.txtMPRID.MaxLength = 20
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.ReadOnly = True
        Me.txtMPRID.Size = New System.Drawing.Size(68, 20)
        Me.txtMPRID.TabIndex = 1
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Location = New System.Drawing.Point(11, 19)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(45, 13)
        Me.lblMPRID.TabIndex = 0
        Me.lblMPRID.Text = "MPRID:"
        '
        'txtSuffix
        '
        Me.txtSuffix.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuffix.Location = New System.Drawing.Point(395, 19)
        Me.txtSuffix.MaxLength = 50
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(33, 20)
        Me.txtSuffix.TabIndex = 10
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(267, 19)
        Me.txtMName.MaxLength = 1
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(40, 20)
        Me.txtMName.TabIndex = 6
        '
        'txtLName
        '
        Me.txtLName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLName.Location = New System.Drawing.Point(308, 19)
        Me.txtLName.MaxLength = 30
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(79, 20)
        Me.txtLName.TabIndex = 8
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(194, 19)
        Me.txtFName.MaxLength = 20
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(71, 20)
        Me.txtFName.TabIndex = 4
        '
        'lblSuffix
        '
        Me.lblSuffix.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSuffix.AutoSize = True
        Me.lblSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuffix.Location = New System.Drawing.Point(393, 37)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(35, 12)
        Me.lblSuffix.TabIndex = 9
        Me.lblSuffix.Text = "(Suffix)"
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.Location = New System.Drawing.Point(306, 37)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(29, 12)
        Me.lblLName.TabIndex = 7
        Me.lblLName.Text = "(Last)"
        '
        'lblMI
        '
        Me.lblMI.AutoSize = True
        Me.lblMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMI.Location = New System.Drawing.Point(261, 37)
        Me.lblMI.Name = "lblMI"
        Me.lblMI.Size = New System.Drawing.Size(39, 12)
        Me.lblMI.TabIndex = 5
        Me.lblMI.Text = "(Middle)"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(195, 37)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(30, 12)
        Me.lblFN.TabIndex = 3
        Me.lblFN.Text = "(First)"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(150, 19)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name:"
        '
        'LastNameValidator
        '
        Me.LastNameValidator.ErrorMessage = "Last Name is required"
        Me.LastNameValidator.Icon = CType(resources.GetObject("LastNameValidator.Icon"), System.Drawing.Icon)
        Me.LastNameValidator.Required = True
        '
        'EditPersonName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUserCtrl)
        Me.Name = "EditPersonName"
        Me.Size = New System.Drawing.Size(443, 60)
        Me.grpUserCtrl.ResumeLayout(False)
        Me.grpUserCtrl.PerformLayout()
        CType(Me.LastNameValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpUserCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblSuffix As System.Windows.Forms.Label
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblMI As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Protected WithEvents LastNameValidator As MPR.Windows.Forms.Validation.RequiredFieldValidator
    Friend WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents lblMPRID As System.Windows.Forms.Label

End Class
