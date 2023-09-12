<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignCase
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
        Dim ListViewColumnSorter1 As MPR.SMS.FieldManagement.ListViewColumnSorter = New MPR.SMS.FieldManagement.ListViewColumnSorter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignCase))
        Me.cboRegions = New System.Windows.Forms.ComboBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cboSupervisors = New System.Windows.Forms.ComboBox()
        Me.lblSupervisor = New System.Windows.Forms.Label()
        Me.cboTeams = New System.Windows.Forms.ComboBox()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.cboInterviewers = New System.Windows.Forms.ComboBox()
        Me.lblInterviewer = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblAssign = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lvCaseAssignments = New MPR.SMS.FieldManagement.ucListViewEx()
        Me.chCaseID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chMPRID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chSampleMember = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAssignedTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chSupervisor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chInstType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chReleased = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'cboRegions
        '
        Me.cboRegions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegions.BackColor = System.Drawing.SystemColors.Window
        Me.cboRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegions.Location = New System.Drawing.Point(71, 192)
        Me.cboRegions.Name = "cboRegions"
        Me.cboRegions.Size = New System.Drawing.Size(303, 21)
        Me.cboRegions.TabIndex = 1
        '
        'lblRegion
        '
        Me.lblRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(5, 192)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(44, 13)
        Me.lblRegion.TabIndex = 0
        Me.lblRegion.Text = "Region:"
        '
        'cboSupervisors
        '
        Me.cboSupervisors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSupervisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupervisors.Location = New System.Drawing.Point(71, 219)
        Me.cboSupervisors.Name = "cboSupervisors"
        Me.cboSupervisors.Size = New System.Drawing.Size(303, 21)
        Me.cboSupervisors.TabIndex = 3
        '
        'lblSupervisor
        '
        Me.lblSupervisor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSupervisor.AutoSize = True
        Me.lblSupervisor.Location = New System.Drawing.Point(5, 219)
        Me.lblSupervisor.Name = "lblSupervisor"
        Me.lblSupervisor.Size = New System.Drawing.Size(60, 13)
        Me.lblSupervisor.TabIndex = 2
        Me.lblSupervisor.Text = "Supervisor:"
        '
        'cboTeams
        '
        Me.cboTeams.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTeams.Location = New System.Drawing.Point(71, 246)
        Me.cboTeams.Name = "cboTeams"
        Me.cboTeams.Size = New System.Drawing.Size(303, 21)
        Me.cboTeams.TabIndex = 5
        '
        'lblTeam
        '
        Me.lblTeam.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(5, 246)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(37, 13)
        Me.lblTeam.TabIndex = 4
        Me.lblTeam.Text = "Team:"
        '
        'cboInterviewers
        '
        Me.cboInterviewers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInterviewers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterviewers.Location = New System.Drawing.Point(71, 273)
        Me.cboInterviewers.Name = "cboInterviewers"
        Me.cboInterviewers.Size = New System.Drawing.Size(303, 21)
        Me.cboInterviewers.TabIndex = 7
        '
        'lblInterviewer
        '
        Me.lblInterviewer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInterviewer.AutoSize = True
        Me.lblInterviewer.Location = New System.Drawing.Point(5, 273)
        Me.lblInterviewer.Name = "lblInterviewer"
        Me.lblInterviewer.Size = New System.Drawing.Size(62, 13)
        Me.lblInterviewer.TabIndex = 6
        Me.lblInterviewer.Text = "Interviewer:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(299, 411)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(202, 411)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'lblAssign
        '
        Me.lblAssign.AutoSize = True
        Me.lblAssign.Location = New System.Drawing.Point(5, 6)
        Me.lblAssign.Name = "lblAssign"
        Me.lblAssign.Size = New System.Drawing.Size(173, 13)
        Me.lblAssign.TabIndex = 11
        Me.lblAssign.Text = "Assign or re-assign all cases below:"
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Location = New System.Drawing.Point(287, 6)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(87, 13)
        Me.lblCount.TabIndex = 12
        Me.lblCount.Text = "Count = x"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNote
        '
        Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(5, 300)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(38, 13)
        Me.lblNote.TabIndex = 13
        Me.lblNote.Text = "Notes:"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(71, 300)
        Me.txtNote.MaxLength = 2000
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(303, 100)
        Me.txtNote.TabIndex = 14
        '
        'lvCaseAssignments
        '
        Me.lvCaseAssignments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCaseAssignments.CausesValidation = False
        Me.lvCaseAssignments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCaseID, Me.chStatus, Me.chMPRID, Me.chSampleMember, Me.chState, Me.chAssignedTo, Me.chSupervisor, Me.chInstType, Me.chReleased})
        ListViewColumnSorter1.ColumnType = MPR.SMS.FieldManagement.SortType.StringCompare
        ListViewColumnSorter1.Order = System.Windows.Forms.SortOrder.None
        ListViewColumnSorter1.SortColumn = 0
        Me.lvCaseAssignments.ColumnSorter = ListViewColumnSorter1
        Me.lvCaseAssignments.EmptyMessage = ""
        Me.lvCaseAssignments.FullRowSelect = True
        Me.lvCaseAssignments.Location = New System.Drawing.Point(8, 22)
        Me.lvCaseAssignments.MultiSelect = False
        Me.lvCaseAssignments.Name = "lvCaseAssignments"
        Me.lvCaseAssignments.Size = New System.Drawing.Size(366, 164)
        Me.lvCaseAssignments.TabIndex = 10
        Me.lvCaseAssignments.UseCompatibleStateImageBehavior = False
        Me.lvCaseAssignments.View = System.Windows.Forms.View.Details
        '
        'chCaseID
        '
        Me.chCaseID.DisplayIndex = 1
        Me.chCaseID.Text = "CaseID"
        '
        'chStatus
        '
        Me.chStatus.DisplayIndex = 2
        Me.chStatus.Text = "Status"
        '
        'chMPRID
        '
        Me.chMPRID.DisplayIndex = 0
        Me.chMPRID.Text = "MPRID"
        '
        'chSampleMember
        '
        Me.chSampleMember.Text = "Sample Member"
        Me.chSampleMember.Width = 93
        '
        'chState
        '
        Me.chState.Text = "State"
        '
        'chAssignedTo
        '
        Me.chAssignedTo.Text = "Interviewer"
        '
        'chSupervisor
        '
        Me.chSupervisor.Text = "Supervisor"
        '
        'chInstType
        '
        Me.chInstType.Text = "Instrument Type"
        '
        'chReleased
        '
        Me.chReleased.Text = "Released"
        '
        'frmAssignCase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 441)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lvCaseAssignments)
        Me.Controls.Add(Me.lblAssign)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cboInterviewers)
        Me.Controls.Add(Me.lblInterviewer)
        Me.Controls.Add(Me.cboTeams)
        Me.Controls.Add(Me.lblTeam)
        Me.Controls.Add(Me.cboSupervisors)
        Me.Controls.Add(Me.lblSupervisor)
        Me.Controls.Add(Me.cboRegions)
        Me.Controls.Add(Me.lblRegion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssignCase"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Case Assignment(s)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboRegions As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents cboSupervisors As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupervisor As System.Windows.Forms.Label
    Friend WithEvents cboTeams As System.Windows.Forms.ComboBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents cboInterviewers As System.Windows.Forms.ComboBox
    Friend WithEvents lblInterviewer As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lvCaseAssignments As MPR.SMS.FieldManagement.ucListViewEx
    Friend WithEvents chCaseID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPRID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSampleMember As System.Windows.Forms.ColumnHeader
    Friend WithEvents chState As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAssignedTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSupervisor As System.Windows.Forms.ColumnHeader
    Friend WithEvents chInstType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chReleased As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblAssign As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblNote As Label
    Friend WithEvents txtNote As TextBox
End Class
