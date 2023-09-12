<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaseAssignmentSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucCaseAssignmentSearch))
        Me.MyCaption = New MPR.SMS.FieldManagement.UserControls.ucPaneCaption
        Me.DetailPanel = New System.Windows.Forms.Panel
        Me.lblMPRID = New System.Windows.Forms.Label
        Me.optMPRID = New System.Windows.Forms.RadioButton
        Me.txtMPRID = New System.Windows.Forms.TextBox
        Me.cboStatus = New MPR.SMS.UserControls.StatusComboBox
        Me.optStatus = New System.Windows.Forms.RadioButton
        Me.cboMatch = New System.Windows.Forms.ComboBox
        Me.optLastName = New System.Windows.Forms.RadioButton
        Me.optCaseID = New System.Windows.Forms.RadioButton
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.btnGo = New System.Windows.Forms.Button
        Me.txtCaseID = New System.Windows.Forms.TextBox
        Me.DetailPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyCaption
        '
        Me.MyCaption.BackColor = System.Drawing.SystemColors.Control
        Me.MyCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyCaption.Caption = "Search for cases..."
        Me.MyCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.MyCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MyCaption.Location = New System.Drawing.Point(0, 0)
        Me.MyCaption.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MyCaption.Name = "MyCaption"
        Me.MyCaption.Size = New System.Drawing.Size(242, 27)
        Me.MyCaption.TabIndex = 0
        '
        'DetailPanel
        '
        Me.DetailPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailPanel.BackColor = System.Drawing.SystemColors.Window
        Me.DetailPanel.Controls.Add(Me.lblMPRID)
        Me.DetailPanel.Controls.Add(Me.optMPRID)
        Me.DetailPanel.Controls.Add(Me.txtMPRID)
        Me.DetailPanel.Controls.Add(Me.cboStatus)
        Me.DetailPanel.Controls.Add(Me.optStatus)
        Me.DetailPanel.Controls.Add(Me.cboMatch)
        Me.DetailPanel.Controls.Add(Me.optLastName)
        Me.DetailPanel.Controls.Add(Me.optCaseID)
        Me.DetailPanel.Controls.Add(Me.txtLastName)
        Me.DetailPanel.Controls.Add(Me.btnGo)
        Me.DetailPanel.Controls.Add(Me.txtCaseID)
        Me.DetailPanel.Location = New System.Drawing.Point(0, 25)
        Me.DetailPanel.Name = "DetailPanel"
        Me.DetailPanel.Size = New System.Drawing.Size(242, 285)
        Me.DetailPanel.TabIndex = 1
        '
        'lblMPRID
        '
        Me.lblMPRID.AutoSize = True
        Me.lblMPRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPRID.Location = New System.Drawing.Point(123, 90)
        Me.lblMPRID.Name = "lblMPRID"
        Me.lblMPRID.Size = New System.Drawing.Size(111, 12)
        Me.lblMPRID.TabIndex = 4
        Me.lblMPRID.Text = "(Primary sample member)"
        '
        'optMPRID
        '
        Me.optMPRID.AutoSize = True
        Me.optMPRID.Location = New System.Drawing.Point(14, 71)
        Me.optMPRID.Name = "optMPRID"
        Me.optMPRID.Size = New System.Drawing.Size(102, 17)
        Me.optMPRID.TabIndex = 2
        Me.optMPRID.TabStop = True
        Me.optMPRID.Text = "where &MPRID is"
        Me.optMPRID.UseVisualStyleBackColor = True
        '
        'txtMPRID
        '
        Me.txtMPRID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMPRID.Location = New System.Drawing.Point(125, 71)
        Me.txtMPRID.MaxLength = 8
        Me.txtMPRID.Name = "txtMPRID"
        Me.txtMPRID.Size = New System.Drawing.Size(112, 20)
        Me.txtMPRID.TabIndex = 3
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.Location = New System.Drawing.Point(125, 200)
        Me.cboStatus.MyLabel = "Status:"
        Me.cboStatus.MyLabelVisible = False
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.SelectedStatus = Nothing
        Me.cboStatus.Size = New System.Drawing.Size(112, 24)
        Me.cboStatus.TabIndex = 9
        '
        'optStatus
        '
        Me.optStatus.AutoSize = True
        Me.optStatus.Location = New System.Drawing.Point(14, 200)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(95, 17)
        Me.optStatus.TabIndex = 8
        Me.optStatus.TabStop = True
        Me.optStatus.Text = "where &status is"
        Me.optStatus.UseVisualStyleBackColor = True
        '
        'cboMatch
        '
        Me.cboMatch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMatch.FormattingEnabled = True
        Me.cboMatch.Items.AddRange(New Object() {"matches", "contains", "begins with", "ends with"})
        Me.cboMatch.Location = New System.Drawing.Point(125, 124)
        Me.cboMatch.Name = "cboMatch"
        Me.cboMatch.Size = New System.Drawing.Size(112, 21)
        Me.cboMatch.TabIndex = 6
        '
        'optLastName
        '
        Me.optLastName.AutoSize = True
        Me.optLastName.Location = New System.Drawing.Point(14, 128)
        Me.optLastName.Name = "optLastName"
        Me.optLastName.Size = New System.Drawing.Size(102, 17)
        Me.optLastName.TabIndex = 5
        Me.optLastName.TabStop = True
        Me.optLastName.Text = "where last &name"
        Me.optLastName.UseVisualStyleBackColor = True
        '
        'optCaseID
        '
        Me.optCaseID.AutoSize = True
        Me.optCaseID.Location = New System.Drawing.Point(14, 31)
        Me.optCaseID.Name = "optCaseID"
        Me.optCaseID.Size = New System.Drawing.Size(105, 17)
        Me.optCaseID.TabIndex = 0
        Me.optCaseID.TabStop = True
        Me.optCaseID.Text = "where &Case ID is"
        Me.optCaseID.UseVisualStyleBackColor = True
        '
        'txtLastName
        '
        Me.txtLastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.Location = New System.Drawing.Point(125, 154)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(112, 20)
        Me.txtLastName.TabIndex = 7
        '
        'btnGo
        '
        Me.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGo.BackColor = System.Drawing.SystemColors.Control
        Me.btnGo.CausesValidation = False
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGo.Location = New System.Drawing.Point(96, 247)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(52, 22)
        Me.btnGo.TabIndex = 10
        Me.btnGo.Text = "&Go"
        Me.btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'txtCaseID
        '
        Me.txtCaseID.Location = New System.Drawing.Point(125, 31)
        Me.txtCaseID.MaxLength = 8
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Size = New System.Drawing.Size(58, 20)
        Me.txtCaseID.TabIndex = 1
        '
        'ucCaseAssignmentSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MyCaption)
        Me.Controls.Add(Me.DetailPanel)
        Me.Name = "ucCaseAssignmentSearch"
        Me.Size = New System.Drawing.Size(242, 310)
        Me.DetailPanel.ResumeLayout(False)
        Me.DetailPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyCaption As MPR.SMS.FieldManagement.UserControls.ucPaneCaption
    Friend WithEvents DetailPanel As System.Windows.Forms.Panel
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Protected WithEvents txtCaseID As System.Windows.Forms.TextBox
    Friend WithEvents cboMatch As System.Windows.Forms.ComboBox
    Friend WithEvents optLastName As System.Windows.Forms.RadioButton
    Friend WithEvents optCaseID As System.Windows.Forms.RadioButton
    Friend WithEvents cboStatus As MPR.SMS.UserControls.StatusComboBox
    Friend WithEvents optStatus As System.Windows.Forms.RadioButton
    Friend WithEvents optMPRID As System.Windows.Forms.RadioButton
    Protected WithEvents txtMPRID As System.Windows.Forms.TextBox
    Friend WithEvents lblMPRID As System.Windows.Forms.Label

End Class
