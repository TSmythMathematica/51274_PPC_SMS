<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaseTracking
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
        Dim ListViewColumnSorter1 As MPR.SMS.FieldManagement.ListViewColumnSorter = New MPR.SMS.FieldManagement.ListViewColumnSorter()
        Me.grpTracking = New System.Windows.Forms.GroupBox()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cboInterviewers = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpRemarks = New System.Windows.Forms.GroupBox()
        Me.cbRemark5 = New System.Windows.Forms.CheckBox()
        Me.cbRemark3 = New System.Windows.Forms.CheckBox()
        Me.cbRemark10 = New System.Windows.Forms.CheckBox()
        Me.cbRemark6 = New System.Windows.Forms.CheckBox()
        Me.cbRemark7 = New System.Windows.Forms.CheckBox()
        Me.cbRemark8 = New System.Windows.Forms.CheckBox()
        Me.cbRemark9 = New System.Windows.Forms.CheckBox()
        Me.cbRemark1 = New System.Windows.Forms.CheckBox()
        Me.cbRemark2 = New System.Windows.Forms.CheckBox()
        Me.cbRemark4 = New System.Windows.Forms.CheckBox()
        txtDateReported = New SMS.UserControls.DateWithValidator()
        cboReportedStatus = New SMS.UserControls.FMStatusComboBox()
        Me.lvCaseTrackings = New MPR.SMS.FieldManagement.ucListViewEx()
        Me.chDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpTracking.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        Me.grpRemarks.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTracking
        '
        Me.grpTracking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTracking.Controls.Add(Me.lvCaseTrackings)
        Me.grpTracking.Location = New System.Drawing.Point(3, 3)
        Me.grpTracking.Name = "grpTracking"
        Me.grpTracking.Size = New System.Drawing.Size(622, 163)
        Me.grpTracking.TabIndex = 0
        Me.grpTracking.TabStop = False
        Me.grpTracking.Text = "Case tracking"
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.btnCancel)
        Me.grpDetails.Controls.Add(Me.btnSave)
        Me.grpDetails.Controls.Add(Me.cboInterviewers)
        Me.grpDetails.Controls.Add(Me.Label3)
        Me.grpDetails.Controls.Add(Me.txtNotes)
        Me.grpDetails.Controls.Add(Me.Label6)
        Me.grpDetails.Controls.Add(Me.txtDateReported)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.Controls.Add(Me.Label1)
        Me.grpDetails.Controls.Add(Me.grpRemarks)
        Me.grpDetails.Controls.Add(Me.cboReportedStatus)
        Me.grpDetails.Location = New System.Drawing.Point(3, 169)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(622, 266)
        Me.grpDetails.TabIndex = 1
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(541, 234)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Clear"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(460, 234)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Add"
        '
        'cboInterviewers
        '
        Me.cboInterviewers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterviewers.Location = New System.Drawing.Point(380, 34)
        Me.cboInterviewers.Name = "cboInterviewers"
        Me.cboInterviewers.Size = New System.Drawing.Size(236, 21)
        Me.cboInterviewers.TabIndex = 5
        Me.cboInterviewers.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(377, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Interviewer:"
        Me.Label3.Visible = False
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(6, 74)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(610, 38)
        Me.txtNotes.TabIndex = 7
        Me.txtNotes.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Notes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Reported Status:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date Reported:"
        '
        'grpRemarks
        '
        Me.grpRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpRemarks.Controls.Add(Me.cbRemark5)
        Me.grpRemarks.Controls.Add(Me.cbRemark3)
        Me.grpRemarks.Controls.Add(Me.cbRemark10)
        Me.grpRemarks.Controls.Add(Me.cbRemark6)
        Me.grpRemarks.Controls.Add(Me.cbRemark7)
        Me.grpRemarks.Controls.Add(Me.cbRemark8)
        Me.grpRemarks.Controls.Add(Me.cbRemark9)
        Me.grpRemarks.Controls.Add(Me.cbRemark1)
        Me.grpRemarks.Controls.Add(Me.cbRemark2)
        Me.grpRemarks.Controls.Add(Me.cbRemark4)
        Me.grpRemarks.Location = New System.Drawing.Point(6, 121)
        Me.grpRemarks.Name = "grpRemarks"
        Me.grpRemarks.Size = New System.Drawing.Size(610, 107)
        Me.grpRemarks.TabIndex = 0
        Me.grpRemarks.TabStop = False
        Me.grpRemarks.Text = "Remarks"
        Me.grpRemarks.Visible = False
        '
        'cbRemark5
        '
        Me.cbRemark5.Location = New System.Drawing.Point(10, 83)
        Me.cbRemark5.Name = "cbRemark5"
        Me.cbRemark5.Size = New System.Drawing.Size(272, 20)
        Me.cbRemark5.TabIndex = 4
        Me.cbRemark5.Text = "&5. Spoke with LL/Management Company"
        '
        'cbRemark3
        '
        Me.cbRemark3.Location = New System.Drawing.Point(10, 51)
        Me.cbRemark3.Name = "cbRemark3"
        Me.cbRemark3.Size = New System.Drawing.Size(272, 20)
        Me.cbRemark3.TabIndex = 2
        Me.cbRemark3.Text = "&3. Left Letter/Note with Personal Message"
        '
        'cbRemark10
        '
        Me.cbRemark10.Location = New System.Drawing.Point(316, 83)
        Me.cbRemark10.Name = "cbRemark10"
        Me.cbRemark10.Size = New System.Drawing.Size(288, 20)
        Me.cbRemark10.TabIndex = 9
        Me.cbRemark10.Text = "1&0. Appointment Rescheduled"
        '
        'cbRemark6
        '
        Me.cbRemark6.Location = New System.Drawing.Point(316, 19)
        Me.cbRemark6.Name = "cbRemark6"
        Me.cbRemark6.Size = New System.Drawing.Size(288, 20)
        Me.cbRemark6.TabIndex = 5
        Me.cbRemark6.Text = "&6. Worked (Some) Contacts"
        '
        'cbRemark7
        '
        Me.cbRemark7.Location = New System.Drawing.Point(316, 35)
        Me.cbRemark7.Name = "cbRemark7"
        Me.cbRemark7.Size = New System.Drawing.Size(288, 20)
        Me.cbRemark7.TabIndex = 6
        Me.cbRemark7.Text = "&7. Worked (All) Contacts"
        '
        'cbRemark8
        '
        Me.cbRemark8.Location = New System.Drawing.Point(316, 51)
        Me.cbRemark8.Name = "cbRemark8"
        Me.cbRemark8.Size = New System.Drawing.Size(288, 20)
        Me.cbRemark8.TabIndex = 7
        Me.cbRemark8.Text = "&8. Address Correct-No Contact with SM"
        '
        'cbRemark9
        '
        Me.cbRemark9.Location = New System.Drawing.Point(316, 67)
        Me.cbRemark9.Name = "cbRemark9"
        Me.cbRemark9.Size = New System.Drawing.Size(288, 20)
        Me.cbRemark9.TabIndex = 8
        Me.cbRemark9.Text = "&9. Broken Appointment"
        '
        'cbRemark1
        '
        Me.cbRemark1.Location = New System.Drawing.Point(10, 19)
        Me.cbRemark1.Name = "cbRemark1"
        Me.cbRemark1.Size = New System.Drawing.Size(272, 20)
        Me.cbRemark1.TabIndex = 0
        Me.cbRemark1.Text = "&1. Visited Addresses"
        '
        'cbRemark2
        '
        Me.cbRemark2.Location = New System.Drawing.Point(10, 35)
        Me.cbRemark2.Name = "cbRemark2"
        Me.cbRemark2.Size = New System.Drawing.Size(272, 20)
        Me.cbRemark2.TabIndex = 1
        Me.cbRemark2.Text = "&2. Left Letter/Note"
        '
        'cbRemark4
        '
        Me.cbRemark4.Location = New System.Drawing.Point(10, 67)
        Me.cbRemark4.Name = "cbRemark4"
        Me.cbRemark4.Size = New System.Drawing.Size(272, 20)
        Me.cbRemark4.TabIndex = 3
        Me.cbRemark4.Text = "&4. Spoke with Neighbors"
        '
        'txtDateReported
        '
        Me.txtDateReported.Location = New System.Drawing.Point(6, 33)
        Me.txtDateReported.Name = "txtDateReported"
        Me.txtDateReported.ReadOnly = False
        Me.txtDateReported.Required = False
        Me.txtDateReported.Size = New System.Drawing.Size(95, 20)
        Me.txtDateReported.TabIndex = 1
        '
        'cboReportedStatus
        '
        Me.cboReportedStatus.Location = New System.Drawing.Point(72, 35)
        Me.cboReportedStatus.MyLabel = ""
        Me.cboReportedStatus.Name = "cboReportedStatus"
        Me.cboReportedStatus.SelectedStatus = Nothing
        Me.cboReportedStatus.Size = New System.Drawing.Size(302, 24)
        Me.cboReportedStatus.TabIndex = 10
        '
        'lvCaseTrackings
        '
        Me.lvCaseTrackings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDate, Me.chStatus, Me.chNote})
        ListViewColumnSorter1.ColumnType = MPR.SMS.FieldManagement.SortType.StringCompare
        ListViewColumnSorter1.Order = System.Windows.Forms.SortOrder.None
        ListViewColumnSorter1.SortColumn = 0
        Me.lvCaseTrackings.ColumnSorter = ListViewColumnSorter1
        Me.lvCaseTrackings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCaseTrackings.EmptyMessage = ""
        Me.lvCaseTrackings.FullRowSelect = True
        Me.lvCaseTrackings.HideSelection = False
        Me.lvCaseTrackings.Location = New System.Drawing.Point(3, 16)
        Me.lvCaseTrackings.MultiSelect = False
        Me.lvCaseTrackings.Name = "lvCaseTrackings"
        Me.lvCaseTrackings.Size = New System.Drawing.Size(616, 144)
        Me.lvCaseTrackings.TabIndex = 0
        Me.lvCaseTrackings.UseCompatibleStateImageBehavior = False
        Me.lvCaseTrackings.View = System.Windows.Forms.View.Details
        '
        'chDate
        '
        Me.chDate.Text = "Date Reported"
        Me.chDate.Width = 120
        '
        'chStatus
        '
        Me.chStatus.Text = "Reported Status"
        Me.chStatus.Width = 120
        '
        'chNote
        '
        Me.chNote.Text = "Notes"
        Me.chNote.Width = 360
        '
        'ucCaseTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.grpTracking)
        Me.Name = "ucCaseTracking"
        Me.Size = New System.Drawing.Size(628, 438)
        Me.grpTracking.ResumeLayout(False)
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.grpRemarks.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpTracking As System.Windows.Forms.GroupBox
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents grpRemarks As System.Windows.Forms.GroupBox
    Friend WithEvents cbRemark5 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark10 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark6 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark7 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark8 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark9 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbRemark4 As System.Windows.Forms.CheckBox
    Friend WithEvents cboInterviewers As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDateReported As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lvCaseTrackings As MPR.SMS.FieldManagement.ucListViewEx
    Friend WithEvents chDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNote As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboReportedStatus As MPR.SMS.UserControls.FMStatusComboBox
End Class
