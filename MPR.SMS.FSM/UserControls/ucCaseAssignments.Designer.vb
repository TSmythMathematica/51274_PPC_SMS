<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaseAssignments
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewColumnSorter1 As MPR.SMS.FieldManagement.ListViewColumnSorter = New MPR.SMS.FieldManagement.ListViewColumnSorter()
        Me.MyPanel = New System.Windows.Forms.Panel()
        Me.MyListViewPanel = New System.Windows.Forms.Panel()
        Me.lvCaseAssignments = New MPR.SMS.FieldManagement.ucListViewEx()
        Me.chMPRID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chCaseID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.MoreFieldAttempts = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chPriorityStatus = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chLastAttemptDate = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chLACity = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chFirstName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chLastName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chAddress1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chCity = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chState = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chPostalCode = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chCurrentStatus = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chLocatingStatus = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chReleaseDate = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chLanguage = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chGender = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chAge = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.chInterviewerName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ctxCaseAssignments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxCaseProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAssignCase = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewCasesSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxViewAllCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxViewAssignedCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxViewUnassignedCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxViewActiveCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxViewCompletedCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxViewValidationCases = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyCaptionPanel = New System.Windows.Forms.Panel()
        Me.MyCaption = New MPR.SMS.FieldManagement.UserControls.ucPaneCaption()
        Me.MyPanel.SuspendLayout
        Me.MyListViewPanel.SuspendLayout
        Me.ctxCaseAssignments.SuspendLayout
        Me.MyCaptionPanel.SuspendLayout
        Me.SuspendLayout
        '
        'MyPanel
        '
        Me.MyPanel.Controls.Add(Me.MyListViewPanel)
        Me.MyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyPanel.Location = New System.Drawing.Point(0, 0)
        Me.MyPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MyPanel.Name = "MyPanel"
        Me.MyPanel.Size = New System.Drawing.Size(1183, 364)
        Me.MyPanel.TabIndex = 0
        '
        'MyListViewPanel
        '
        Me.MyListViewPanel.Controls.Add(Me.lvCaseAssignments)
        Me.MyListViewPanel.Controls.Add(Me.MyCaptionPanel)
        Me.MyListViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyListViewPanel.Location = New System.Drawing.Point(0, 0)
        Me.MyListViewPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MyListViewPanel.Name = "MyListViewPanel"
        Me.MyListViewPanel.Size = New System.Drawing.Size(1183, 364)
        Me.MyListViewPanel.TabIndex = 0
        '
        'lvCaseAssignments
        '
        Me.lvCaseAssignments.CausesValidation = false
        Me.lvCaseAssignments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chMPRID, Me.chCaseID, Me.MoreFieldAttempts, Me.chPriorityStatus, Me.chLastAttemptDate, Me.chLACity, Me.chFirstName, Me.chLastName, Me.chAddress1, Me.chCity, Me.chState, Me.chPostalCode, Me.chCurrentStatus, Me.chLocatingStatus, Me.chReleaseDate, Me.chLanguage, Me.chGender, Me.chAge, Me.chInterviewerName})
        ListViewColumnSorter1.ColumnType = MPR.SMS.FieldManagement.SortType.StringCompare
        ListViewColumnSorter1.Order = System.Windows.Forms.SortOrder.None
        ListViewColumnSorter1.SortColumn = 0
        Me.lvCaseAssignments.ColumnSorter = ListViewColumnSorter1
        Me.lvCaseAssignments.ContextMenuStrip = Me.ctxCaseAssignments
        Me.lvCaseAssignments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCaseAssignments.EmptyMessage = ""
        Me.lvCaseAssignments.FullRowSelect = true
        Me.lvCaseAssignments.HideSelection = false
        Me.lvCaseAssignments.Location = New System.Drawing.Point(0, 32)
        Me.lvCaseAssignments.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCaseAssignments.MultiSelect = false
        Me.lvCaseAssignments.Name = "lvCaseAssignments"
        Me.lvCaseAssignments.Size = New System.Drawing.Size(1183, 332)
        Me.lvCaseAssignments.TabIndex = 1
        Me.lvCaseAssignments.UseCompatibleStateImageBehavior = false
        Me.lvCaseAssignments.View = System.Windows.Forms.View.Details
        '
        'chMPRID
        '
        Me.chMPRID.Text = "MPRID"
        '
        'chCaseID
        '
        Me.chCaseID.Text = "CaseID"
        '
        'MoreFieldAttempts
        '
        Me.MoreFieldAttempts.Text = "16+Attempts"
        '
        'chPriorityStatus
        '
        Me.chPriorityStatus.Text = "Priority Flag"
        '
        'chLastAttemptDate
        '
        Me.chLastAttemptDate.Text = "Last Attempt Date"
        '
        'chLACity
        '
        Me.chLACity.Text = "Last Attempt City"
        '
        'chFirstName
        '
        Me.chFirstName.Text = "First Name"
        Me.chFirstName.Width = 93
        '
        'chLastName
        '
        Me.chLastName.Text = "Last Name"
        '
        'chAddress1
        '
        Me.chAddress1.Text = "Address1"
        '
        'chCity
        '
        Me.chCity.Text = "City"
        '
        'chState
        '
        Me.chState.Text = "State"
        '
        'chPostalCode
        '
        Me.chPostalCode.Text = "Zip"
        '
        'chCurrentStatus
        '
        Me.chCurrentStatus.Text = "Instrument Status"
        '
        'chLocatingStatus
        '
        Me.chLocatingStatus.Text = "Locating Status"
        '
        'chReleaseDate
        '
        Me.chReleaseDate.Text = "Release date"
        '
        'chLanguage
        '
        Me.chLanguage.Text = "Language"
        '
        'chGender
        '
        Me.chGender.Text = "Gender"
        '
        'chAge
        '
        Me.chAge.Text = "Age"
        '
        'chInterviewerName
        '
        Me.chInterviewerName.Text = "Interviewer"
        '
        'ctxCaseAssignments
        '
        Me.ctxCaseAssignments.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxCaseAssignments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxCaseProperties, Me.ctxAssignCase, Me.ViewCasesSeparator, Me.ctxViewAllCases, Me.ctxViewAssignedCases, Me.ctxViewUnassignedCases, Me.ctxViewActiveCases, Me.ctxViewCompletedCases, Me.ctxViewValidationCases})
        Me.ctxCaseAssignments.Name = "ctxCaseAssignments"
        Me.ctxCaseAssignments.Size = New System.Drawing.Size(196, 202)
        '
        'ctxCaseProperties
        '
        Me.ctxCaseProperties.Name = "ctxCaseProperties"
        Me.ctxCaseProperties.Size = New System.Drawing.Size(195, 24)
        Me.ctxCaseProperties.Text = "Case &Properties..."
        '
        'ctxAssignCase
        '
        Me.ctxAssignCase.Name = "ctxAssignCase"
        Me.ctxAssignCase.Size = New System.Drawing.Size(195, 24)
        Me.ctxAssignCase.Text = "A&ssign Case..."
        '
        'ViewCasesSeparator
        '
        Me.ViewCasesSeparator.Name = "ViewCasesSeparator"
        Me.ViewCasesSeparator.Size = New System.Drawing.Size(192, 6)
        '
        'ctxViewAllCases
        '
        Me.ctxViewAllCases.CheckOnClick = true
        Me.ctxViewAllCases.Name = "ctxViewAllCases"
        Me.ctxViewAllCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewAllCases.Text = "All &Cases"
        '
        'ctxViewAssignedCases
        '
        Me.ctxViewAssignedCases.CheckOnClick = true
        Me.ctxViewAssignedCases.Name = "ctxViewAssignedCases"
        Me.ctxViewAssignedCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewAssignedCases.Text = "&Assigned Cases"
        '
        'ctxViewUnassignedCases
        '
        Me.ctxViewUnassignedCases.CheckOnClick = true
        Me.ctxViewUnassignedCases.Name = "ctxViewUnassignedCases"
        Me.ctxViewUnassignedCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewUnassignedCases.Text = "&Unassigned Cases"
        '
        'ctxViewActiveCases
        '
        Me.ctxViewActiveCases.CheckOnClick = true
        Me.ctxViewActiveCases.Name = "ctxViewActiveCases"
        Me.ctxViewActiveCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewActiveCases.Text = "Acti&ve Cases"
        '
        'ctxViewCompletedCases
        '
        Me.ctxViewCompletedCases.CheckOnClick = true
        Me.ctxViewCompletedCases.Name = "ctxViewCompletedCases"
        Me.ctxViewCompletedCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewCompletedCases.Text = "Co&mpleted Cases"
        '
        'ctxViewValidationCases
        '
        Me.ctxViewValidationCases.CheckOnClick = true
        Me.ctxViewValidationCases.Name = "ctxViewValidationCases"
        Me.ctxViewValidationCases.Size = New System.Drawing.Size(195, 24)
        Me.ctxViewValidationCases.Text = "&Validation Cases"
        '
        'MyCaptionPanel
        '
        Me.MyCaptionPanel.Controls.Add(Me.MyCaption)
        Me.MyCaptionPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MyCaptionPanel.Location = New System.Drawing.Point(0, 0)
        Me.MyCaptionPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MyCaptionPanel.Name = "MyCaptionPanel"
        Me.MyCaptionPanel.Size = New System.Drawing.Size(1183, 32)
        Me.MyCaptionPanel.TabIndex = 0
        '
        'MyCaption
        '
        Me.MyCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyCaption.Caption = "Case Assignments"
        Me.MyCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyCaption.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Bold)
        Me.MyCaption.Location = New System.Drawing.Point(0, 0)
        Me.MyCaption.Margin = New System.Windows.Forms.Padding(7, 5, 7, 5)
        Me.MyCaption.Name = "MyCaption"
        Me.MyCaption.Size = New System.Drawing.Size(1183, 32)
        Me.MyCaption.TabIndex = 0
        '
        'ucCaseAssignments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MyPanel)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ucCaseAssignments"
        Me.Size = New System.Drawing.Size(1183, 364)
        Me.MyPanel.ResumeLayout(false)
        Me.MyListViewPanel.ResumeLayout(false)
        Me.ctxCaseAssignments.ResumeLayout(false)
        Me.MyCaptionPanel.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents MyPanel As System.Windows.Forms.Panel
    Friend WithEvents MyListViewPanel As System.Windows.Forms.Panel
    Friend WithEvents MyCaptionPanel As System.Windows.Forms.Panel
    Friend WithEvents lvCaseAssignments As MPR.SMS.FieldManagement.ucListViewEx
    Friend WithEvents MyCaption As MPR.SMS.FieldManagement.UserControls.ucPaneCaption
    Friend WithEvents ctxCaseAssignments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxCaseProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAssignCase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCasesSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxViewAllCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxViewAssignedCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxViewUnassignedCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxViewActiveCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxViewCompletedCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxViewValidationCases As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chMPRID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCaseID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFirstName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chState As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLanguage As System.Windows.Forms.ColumnHeader
    Friend WithEvents chReleaseDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCurrentStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCity As ColumnHeader
    Friend WithEvents chPostalCode As ColumnHeader
    Friend WithEvents chInterviewerName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLocatingStatus As ColumnHeader
    Friend WithEvents chLastAttemptDate As ColumnHeader
    Friend WithEvents chLastName As ColumnHeader
    Friend WithEvents chLACity As ColumnHeader
    Friend WithEvents chAge As ColumnHeader
    Friend WithEvents chAddress1 As ColumnHeader
    Friend WithEvents chGender As ColumnHeader
    Friend WithEvents chPriorityStatus As ColumnHeader
    Friend WithEvents MoreFieldAttempts As ColumnHeader
End Class
