'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaymentConfirm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblConfirm1 = New System.Windows.Forms.Label()
        Me.lblConfirm2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpRPS = New System.Windows.Forms.GroupBox()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.cboMode = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtProjectType = New System.Windows.Forms.TextBox()
        Me.txtTaskCode = New System.Windows.Forms.TextBox()
        Me.txtProjectCode = New System.Windows.Forms.TextBox()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 281)
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
        'lblConfirm1
        '
        Me.lblConfirm1.AutoSize = True
        Me.lblConfirm1.Location = New System.Drawing.Point(4, 9)
        Me.lblConfirm1.Name = "lblConfirm1"
        Me.lblConfirm1.Size = New System.Drawing.Size(189, 13)
        Me.lblConfirm1.TabIndex = 1
        Me.lblConfirm1.Text = "You are about to create a payment for:"
        '
        'lblConfirm2
        '
        Me.lblConfirm2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConfirm2.AutoSize = True
        Me.lblConfirm2.Location = New System.Drawing.Point(4, 281)
        Me.lblConfirm2.Name = "lblConfirm2"
        Me.lblConfirm2.Size = New System.Drawing.Size(106, 13)
        Me.lblConfirm2.TabIndex = 7
        Me.lblConfirm2.Text = "Create this payment?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(225, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Amount:     $"
        '
        'grpRPS
        '
        Me.grpRPS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRPS.Controls.Add(Me.cboPaymentType)
        Me.grpRPS.Controls.Add(Me.cboMode)
        Me.grpRPS.Controls.Add(Me.txtAmount)
        Me.grpRPS.Controls.Add(Me.txtProjectType)
        Me.grpRPS.Controls.Add(Me.txtTaskCode)
        Me.grpRPS.Controls.Add(Me.txtProjectCode)
        Me.grpRPS.Controls.Add(Me.txtAccount)
        Me.grpRPS.Controls.Add(Me.txtNote)
        Me.grpRPS.Controls.Add(Me.Label9)
        Me.grpRPS.Controls.Add(Me.Label3)
        Me.grpRPS.Controls.Add(Me.Label8)
        Me.grpRPS.Controls.Add(Me.Label7)
        Me.grpRPS.Controls.Add(Me.Label6)
        Me.grpRPS.Controls.Add(Me.Label5)
        Me.grpRPS.Controls.Add(Me.Label4)
        Me.grpRPS.Controls.Add(Me.Label10)
        Me.grpRPS.Location = New System.Drawing.Point(7, 103)
        Me.grpRPS.Name = "grpRPS"
        Me.grpRPS.Size = New System.Drawing.Size(416, 163)
        Me.grpRPS.TabIndex = 6
        Me.grpRPS.TabStop = False
        Me.grpRPS.Text = "RPS info"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Items.AddRange(New Object() {"Post Pay", "Pre Pay"})
        Me.cboPaymentType.Location = New System.Drawing.Point(303, 74)
        Me.cboPaymentType.MaxLength = 25
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(107, 21)
        Me.cboPaymentType.TabIndex = 13
        '
        'cboMode
        '
        Me.cboMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode.FormattingEnabled = True
        Me.cboMode.Items.AddRange(New Object() {"Checks Inhouse", "Checks Vendor"})
        Me.cboMode.Location = New System.Drawing.Point(303, 48)
        Me.cboMode.MaxLength = 25
        Me.cboMode.Name = "cboMode"
        Me.cboMode.Size = New System.Drawing.Size(107, 21)
        Me.cboMode.TabIndex = 9
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(303, 22)
        Me.txtAmount.MaxLength = 6
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(56, 20)
        Me.txtAmount.TabIndex = 3
        Me.txtAmount.Text = "20.00"
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(104, 74)
        Me.txtProjectType.MaxLength = 25
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.ReadOnly = True
        Me.txtProjectType.Size = New System.Drawing.Size(104, 20)
        Me.txtProjectType.TabIndex = 11
        Me.txtProjectType.Text = "Baseline CAPI"
        '
        'txtTaskCode
        '
        Me.txtTaskCode.Location = New System.Drawing.Point(147, 48)
        Me.txtTaskCode.MaxLength = 3
        Me.txtTaskCode.Name = "txtTaskCode"
        Me.txtTaskCode.Size = New System.Drawing.Size(27, 20)
        Me.txtTaskCode.TabIndex = 6
        Me.txtTaskCode.Text = "999"
        '
        'txtProjectCode
        '
        Me.txtProjectCode.Location = New System.Drawing.Point(104, 48)
        Me.txtProjectCode.MaxLength = 4
        Me.txtProjectCode.Name = "txtProjectCode"
        Me.txtProjectCode.Size = New System.Drawing.Size(37, 20)
        Me.txtProjectCode.TabIndex = 5
        Me.txtProjectCode.Text = "9999"
        '
        'txtAccount
        '
        Me.txtAccount.Location = New System.Drawing.Point(104, 22)
        Me.txtAccount.MaxLength = 25
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.ReadOnly = True
        Me.txtAccount.Size = New System.Drawing.Size(104, 20)
        Me.txtAccount.TabIndex = 1
        Me.txtAccount.Text = "2079950072052"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(104, 98)
        Me.txtNote.MaxLength = 255
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(306, 60)
        Me.txtNote.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(225, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Payment type:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(225, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Payment mode:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Project type:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Notes:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Project/task code:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Account:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(139, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "."
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(108, 32)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(50, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Joe Blow"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(108, 56)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(64, 13)
        Me.lblAddress.TabIndex = 5
        Me.lblAddress.Text = "123 Main St"
        '
        'frmPaymentConfirm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(435, 322)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.grpRPS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblConfirm2)
        Me.Controls.Add(Me.lblConfirm1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentConfirm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Confirm Payment Reissue"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpRPS.ResumeLayout(False)
        Me.grpRPS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblConfirm1 As System.Windows.Forms.Label
    Friend WithEvents lblConfirm2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpRPS As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents cboPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents cboMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectType As System.Windows.Forms.TextBox
    Friend WithEvents txtTaskCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox

End Class
