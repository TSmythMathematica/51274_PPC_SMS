'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditDistrict
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
        Me.cboSite = New MPR.SMS.UserControls.SiteComboBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtLEAID = New System.Windows.Forms.TextBox
        Me.lblLEAID = New System.Windows.Forms.Label
        Me.grpSchools = New System.Windows.Forms.GroupBox
        Me.vwSchools = New MPR.SMS.UserControls.ViewDataSet
        Me.grpSchools.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboSite
        '
        Me.cboSite.Location = New System.Drawing.Point(3, 69)
        Me.cboSite.MyLabel = "Site:"
        Me.cboSite.Name = "cboSite"
        Me.cboSite.SelectedSite = Nothing
        Me.cboSite.SelectedSiteID = 0
        Me.cboSite.Size = New System.Drawing.Size(292, 24)
        Me.cboSite.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(91, 17)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(203, 20)
        Me.txtName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(3, 17)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "District name:"
        '
        'txtLEAID
        '
        Me.txtLEAID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLEAID.Location = New System.Drawing.Point(91, 43)
        Me.txtLEAID.MaximumSize = New System.Drawing.Size(100, 20)
        Me.txtLEAID.MaxLength = 10
        Me.txtLEAID.MinimumSize = New System.Drawing.Size(60, 20)
        Me.txtLEAID.Name = "txtLEAID"
        Me.txtLEAID.Size = New System.Drawing.Size(100, 20)
        Me.txtLEAID.TabIndex = 3
        '
        'lblLEAID
        '
        Me.lblLEAID.AutoSize = True
        Me.lblLEAID.Location = New System.Drawing.Point(3, 43)
        Me.lblLEAID.Name = "lblLEAID"
        Me.lblLEAID.Size = New System.Drawing.Size(41, 13)
        Me.lblLEAID.TabIndex = 2
        Me.lblLEAID.Text = "LEAID:"
        '
        'grpSchools
        '
        Me.grpSchools.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSchools.Controls.Add(Me.vwSchools)
        Me.grpSchools.Location = New System.Drawing.Point(302, -1)
        Me.grpSchools.Name = "grpSchools"
        Me.grpSchools.Size = New System.Drawing.Size(128, 125)
        Me.grpSchools.TabIndex = 5
        Me.grpSchools.TabStop = False
        Me.grpSchools.Text = "Schools:"
        '
        'vwSchools
        '
        Me.vwSchools.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vwSchools.DataSource = Nothing
        Me.vwSchools.Location = New System.Drawing.Point(6, 18)
        Me.vwSchools.Name = "vwSchools"
        Me.vwSchools.Size = New System.Drawing.Size(115, 99)
        Me.vwSchools.TabIndex = 0
        '
        'EditDistrict
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.grpSchools)
        Me.Controls.Add(Me.cboSite)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblLEAID)
        Me.Controls.Add(Me.txtLEAID)
        Me.Name = "EditDistrict"
        Me.Size = New System.Drawing.Size(433, 127)
        Me.grpSchools.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLEAID As System.Windows.Forms.Label
    Friend WithEvents txtLEAID As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboSite As MPR.SMS.UserControls.SiteComboBox
    Friend WithEvents grpSchools As System.Windows.Forms.GroupBox
    Friend WithEvents vwSchools As MPR.SMS.UserControls.ViewDataSet

End Class
