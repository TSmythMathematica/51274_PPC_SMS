'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDemo
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
        Me.txtUnparsed = New System.Windows.Forms.TextBox()
        Me.btnParseName = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnPhone = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkGeocode = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.btnParseAddress = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnTCPALookup = New System.Windows.Forms.Button()
        Me.txtTCPAPhone = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.TabPage3.SuspendLayout
        Me.SuspendLayout
        '
        'txtUnparsed
        '
        Me.txtUnparsed.Location = New System.Drawing.Point(6, 16)
        Me.txtUnparsed.Name = "txtUnparsed"
        Me.txtUnparsed.Size = New System.Drawing.Size(269, 20)
        Me.txtUnparsed.TabIndex = 0
        '
        'btnParseName
        '
        Me.btnParseName.Location = New System.Drawing.Point(389, 45)
        Me.btnParseName.Name = "btnParseName"
        Me.btnParseName.Size = New System.Drawing.Size(111, 23)
        Me.btnParseName.TabIndex = 2
        Me.btnParseName.Text = "Parse &Name"
        Me.btnParseName.UseVisualStyleBackColor = true
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(12, 120)
        Me.txtResult.Multiline = true
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(514, 190)
        Me.txtResult.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 14)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(514, 100)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnPhone)
        Me.TabPage1.Controls.Add(Me.btnParseName)
        Me.TabPage1.Controls.Add(Me.txtUnparsed)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(506, 74)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Phone/Name"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'btnPhone
        '
        Me.btnPhone.Location = New System.Drawing.Point(389, 16)
        Me.btnPhone.Name = "btnPhone"
        Me.btnPhone.Size = New System.Drawing.Size(111, 23)
        Me.btnPhone.TabIndex = 3
        Me.btnPhone.Text = "Parse &Phone"
        Me.btnPhone.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkGeocode)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtZip)
        Me.TabPage2.Controls.Add(Me.txtState)
        Me.TabPage2.Controls.Add(Me.txtCity)
        Me.TabPage2.Controls.Add(Me.txtAddress)
        Me.TabPage2.Controls.Add(Me.btnParseAddress)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(506, 74)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Address"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'chkGeocode
        '
        Me.chkGeocode.AutoSize = true
        Me.chkGeocode.Location = New System.Drawing.Point(389, 35)
        Me.chkGeocode.Name = "chkGeocode"
        Me.chkGeocode.Size = New System.Drawing.Size(70, 17)
        Me.chkGeocode.TabIndex = 9
        Me.chkGeocode.Text = "Geocode"
        Me.chkGeocode.UseVisualStyleBackColor = true
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(7, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "City/State/Zip:"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Address:"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(287, 35)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(77, 20)
        Me.txtZip.TabIndex = 6
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(251, 35)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(30, 20)
        Me.txtState.TabIndex = 5
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(95, 35)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(150, 20)
        Me.txtCity.TabIndex = 4
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(95, 9)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(269, 20)
        Me.txtAddress.TabIndex = 3
        '
        'btnParseAddress
        '
        Me.btnParseAddress.Location = New System.Drawing.Point(389, 9)
        Me.btnParseAddress.Name = "btnParseAddress"
        Me.btnParseAddress.Size = New System.Drawing.Size(111, 23)
        Me.btnParseAddress.TabIndex = 2
        Me.btnParseAddress.Text = "Parse &Address"
        Me.btnParseAddress.UseVisualStyleBackColor = true
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnTCPALookup)
        Me.TabPage3.Controls.Add(Me.txtTCPAPhone)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(506, 74)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TCPA Phone Lookup"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'btnTCPALookup
        '
        Me.btnTCPALookup.Location = New System.Drawing.Point(389, 16)
        Me.btnTCPALookup.Name = "btnTCPALookup"
        Me.btnTCPALookup.Size = New System.Drawing.Size(111, 23)
        Me.btnTCPALookup.TabIndex = 5
        Me.btnTCPALookup.Text = "Lookup &Phone"
        Me.btnTCPALookup.UseVisualStyleBackColor = true
        '
        'txtTCPAPhone
        '
        Me.txtTCPAPhone.Location = New System.Drawing.Point(6, 16)
        Me.txtTCPAPhone.Name = "txtTCPAPhone"
        Me.txtTCPAPhone.Size = New System.Drawing.Size(269, 20)
        Me.txtTCPAPhone.TabIndex = 4
        '
        'frmDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 322)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtResult)
        Me.Name = "frmDemo"
        Me.Text = "Melissa Data (Mailer's +4) DQWS Demo"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtUnparsed As System.Windows.Forms.TextBox
    Friend WithEvents btnParseName As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnPhone As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnParseAddress As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents chkGeocode As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnTCPALookup As System.Windows.Forms.Button
    Friend WithEvents txtTCPAPhone As System.Windows.Forms.TextBox
End Class
