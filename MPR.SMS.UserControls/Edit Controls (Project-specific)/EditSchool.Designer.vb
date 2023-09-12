'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditSchool
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
        Me.cboDistrict = New MPR.SMS.UserControls.DistrictComboBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtNCES = New System.Windows.Forms.TextBox
        Me.lblNCES = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtGradeLevels = New System.Windows.Forms.TextBox
        Me.grpClassrooms = New System.Windows.Forms.GroupBox
        Me.vwClassrooms = New MPR.SMS.UserControls.ViewDataSet
        Me.grpClassrooms.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDistrict
        '
        Me.cboDistrict.Location = New System.Drawing.Point(9, 69)
        Me.cboDistrict.MyLabel = "District:"
        Me.cboDistrict.Name = "cboDistrict"
        Me.cboDistrict.SelectedDistrict = Nothing
        Me.cboDistrict.SelectedDistrictID = 0
        Me.cboDistrict.Size = New System.Drawing.Size(280, 24)
        Me.cboDistrict.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(97, 17)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(192, 20)
        Me.txtName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(9, 17)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "School name:"
        '
        'txtNCES
        '
        Me.txtNCES.Location = New System.Drawing.Point(97, 43)
        Me.txtNCES.MaximumSize = New System.Drawing.Size(150, 20)
        Me.txtNCES.MaxLength = 20
        Me.txtNCES.MinimumSize = New System.Drawing.Size(100, 20)
        Me.txtNCES.Name = "txtNCES"
        Me.txtNCES.Size = New System.Drawing.Size(150, 20)
        Me.txtNCES.TabIndex = 3
        '
        'lblNCES
        '
        Me.lblNCES.AutoSize = True
        Me.lblNCES.Location = New System.Drawing.Point(9, 43)
        Me.lblNCES.Name = "lblNCES"
        Me.lblNCES.Size = New System.Drawing.Size(39, 13)
        Me.lblNCES.TabIndex = 2
        Me.lblNCES.Text = "NCES:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Grade levels:"
        '
        'txtGradeLevels
        '
        Me.txtGradeLevels.Location = New System.Drawing.Point(97, 96)
        Me.txtGradeLevels.MaximumSize = New System.Drawing.Size(150, 20)
        Me.txtGradeLevels.MaxLength = 20
        Me.txtGradeLevels.MinimumSize = New System.Drawing.Size(100, 20)
        Me.txtGradeLevels.Name = "txtGradeLevels"
        Me.txtGradeLevels.Size = New System.Drawing.Size(150, 20)
        Me.txtGradeLevels.TabIndex = 6
        '
        'grpClassrooms
        '
        Me.grpClassrooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpClassrooms.Controls.Add(Me.vwClassrooms)
        Me.grpClassrooms.Location = New System.Drawing.Point(295, -1)
        Me.grpClassrooms.Name = "grpClassrooms"
        Me.grpClassrooms.Size = New System.Drawing.Size(128, 125)
        Me.grpClassrooms.TabIndex = 7
        Me.grpClassrooms.TabStop = False
        Me.grpClassrooms.Text = "Classrooms:"
        '
        'vwClassrooms
        '
        Me.vwClassrooms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwClassrooms.DataSource = Nothing
        Me.vwClassrooms.Location = New System.Drawing.Point(6, 18)
        Me.vwClassrooms.Name = "vwClassrooms"
        Me.vwClassrooms.Size = New System.Drawing.Size(115, 99)
        Me.vwClassrooms.TabIndex = 0
        '
        'EditSchool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.grpClassrooms)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGradeLevels)
        Me.Controls.Add(Me.cboDistrict)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblNCES)
        Me.Controls.Add(Me.txtNCES)
        Me.Name = "EditSchool"
        Me.Size = New System.Drawing.Size(426, 127)
        Me.grpClassrooms.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNCES As System.Windows.Forms.Label
    Friend WithEvents txtNCES As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboDistrict As MPR.SMS.UserControls.DistrictComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGradeLevels As System.Windows.Forms.TextBox
    Friend WithEvents grpClassrooms As System.Windows.Forms.GroupBox
    Friend WithEvents vwClassrooms As MPR.SMS.UserControls.ViewDataSet

End Class
