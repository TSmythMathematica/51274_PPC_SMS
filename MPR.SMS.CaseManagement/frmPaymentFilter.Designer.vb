'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaymentFilter
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRPS = New System.Windows.Forms.GroupBox
        Me.txtSeqNo = New System.Windows.Forms.TextBox
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.txtTaskCode = New System.Windows.Forms.TextBox
        Me.txtProjectCode = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMPRID = New System.Windows.Forms.TextBox
        Me.lblMPRID = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpRPS.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(137, 178)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(76, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'grpRPS
        '
        Me.grpRPS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRPS.Controls.Add(Me.txtMPRID)
        Me.grpRPS.Controls.Add(Me.lblMPRID)
        Me.grpRPS.Controls.Add(Me.txtSeqNo)
        Me.grpRPS.Controls.Add(Me.txtCheckNo)
        Me.grpRPS.Controls.Add(Me.txtTaskCode)
        Me.grpRPS.Controls.Add(Me.txtProjectCode)
        Me.grpRPS.Controls.Add(Me.txtName)
        Me.grpRPS.Controls.Add(Me.Label8)
        Me.grpRPS.Controls.Add(Me.Label7)
        Me.grpRPS.Controls.Add(Me.Label5)
        Me.grpRPS.Controls.Add(Me.Label4)
        Me.grpRPS.Controls.Add(Me.Label10)
        Me.grpRPS.Location = New System.Drawing.Point(4, 9)
        Me.grpRPS.Name = "grpRPS"
        Me.grpRPS.Size = New System.Drawing.Size(276, 163)
        Me.grpRPS.TabIndex = 1
        Me.grpRPS.TabStop = False
        Me.grpRPS.Text = "Filter payment list by the following criteria:"
        '
        'txtSeqNo
        '
        Me.txtSeqNo.Location = New System.Drawing.Point(105, 131)
        Me.txtSeqNo.MaxLength = 10
        Me.txtSeqNo.Name = "txtSeqNo"
        Me.txtSeqNo.Size = New System.Drawing.Size(70, 20)
        Me.txtSeqNo.TabIndex = 11
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Location = New System.Drawing.Point(105, 105)
        Me.txtCheckNo.MaxLength = 16
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(70, 20)
        Me.txtCheckNo.TabIndex = 9
        '
        'txtTaskCode
        '
        Me.txtTaskCode.Location = New System.Drawing.Point(148, 79)
        Me.txtTaskCode.MaxLength = 3
        Me.txtTaskCode.Name = "txtTaskCode"
        Me.txtTaskCode.Size = New System.Drawing.Size(27, 20)
        Me.txtTaskCode.TabIndex = 6
        Me.txtTaskCode.Text = "999"
        '
        'txtProjectCode
        '
        Me.txtProjectCode.Location = New System.Drawing.Point(105, 79)
        Me.txtProjectCode.MaxLength = 4
        Me.txtProjectCode.Name = "txtProjectCode"
        Me.txtProjectCode.ReadOnly = True
        Me.txtProjectCode.Size = New System.Drawing.Size(37, 20)
        Me.txtProjectCode.TabIndex = 5
        Me.txtProjectCode.Text = "9999"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(105, 53)
        Me.txtName.MaxLength = 55
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(156, 20)
        Me.txtName.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Sequential #:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Check #:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Project/task code:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Name:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(140, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "-"
        '
        'txtMPRID
        '
        Me.txtMPRID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMPRID.Location = New System.Drawing.Point(105, 27)
        Me.txtMPRID.MaxLength = 8
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.Size = New System.Drawing.Size(70, 20)
        Me.txtMPRID.TabIndex = 1
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Location = New System.Drawing.Point(7, 27)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(45, 13)
        Me.lblMPRID.TabIndex = 0
        Me.lblMPRID.Text = "MPRID:"
        '
        'frmPaymentFilter
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(295, 219)
        Me.Controls.Add(Me.grpRPS)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentFilter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filter Payments"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpRPS.ResumeLayout(False)
        Me.grpRPS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpRPS As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtSeqNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTaskCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents lblMPRID As System.Windows.Forms.Label

End Class
