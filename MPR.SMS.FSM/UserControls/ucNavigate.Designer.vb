<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNavigate
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucNavigate))
        Me.MyPanel = New System.Windows.Forms.Panel
        Me.MyTreeViewPanel = New System.Windows.Forms.Panel
        Me.tvNavigation = New System.Windows.Forms.TreeView
        Me.ctxNavigation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxNewRegion = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxNewSupervisor = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxNewTeam = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxNewInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxNewSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ctxUpdateRegion = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxUpdateSupervisor = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxUpdateTeam = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxUpdateInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxTrackInterviewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxMenuSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ctxRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.MyCaption = New MPR.SMS.FieldManagement.UserControls.ucPaneCaption
        Me.MyPanel.SuspendLayout()
        Me.MyTreeViewPanel.SuspendLayout()
        Me.ctxNavigation.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyPanel
        '
        Me.MyPanel.Controls.Add(Me.MyTreeViewPanel)
        Me.MyPanel.Controls.Add(Me.MyCaption)
        Me.MyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyPanel.Location = New System.Drawing.Point(0, 0)
        Me.MyPanel.Name = "MyPanel"
        Me.MyPanel.Size = New System.Drawing.Size(232, 344)
        Me.MyPanel.TabIndex = 0
        '
        'MyTreeViewPanel
        '
        Me.MyTreeViewPanel.Controls.Add(Me.tvNavigation)
        Me.MyTreeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyTreeViewPanel.Location = New System.Drawing.Point(0, 26)
        Me.MyTreeViewPanel.Name = "MyTreeViewPanel"
        Me.MyTreeViewPanel.Size = New System.Drawing.Size(232, 318)
        Me.MyTreeViewPanel.TabIndex = 1
        '
        'tvNavigation
        '
        Me.tvNavigation.CausesValidation = False
        Me.tvNavigation.ContextMenuStrip = Me.ctxNavigation
        Me.tvNavigation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvNavigation.FullRowSelect = True
        Me.tvNavigation.HideSelection = False
        Me.tvNavigation.ImageIndex = 0
        Me.tvNavigation.ImageList = Me.ImageList
        Me.tvNavigation.Location = New System.Drawing.Point(0, 0)
        Me.tvNavigation.Name = "tvNavigation"
        Me.tvNavigation.SelectedImageIndex = 0
        Me.tvNavigation.ShowNodeToolTips = True
        Me.tvNavigation.Size = New System.Drawing.Size(232, 318)
        Me.tvNavigation.TabIndex = 0
        '
        'ctxNavigation
        '
        Me.ctxNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxNewRegion, Me.ctxNewSupervisor, Me.ctxNewTeam, Me.ctxNewInterviewer, Me.ctxNewSeparator, Me.ctxUpdateRegion, Me.ctxUpdateSupervisor, Me.ctxUpdateTeam, Me.ctxUpdateInterviewer, Me.ctxTrackInterviewer, Me.ctxMenuSeparator, Me.ctxRefresh})
        Me.ctxNavigation.Name = "ctxNavigation"
        Me.ctxNavigation.Size = New System.Drawing.Size(192, 258)
        '
        'ctxNewRegion
        '
        Me.ctxNewRegion.Name = "ctxNewRegion"
        Me.ctxNewRegion.Size = New System.Drawing.Size(191, 22)
        Me.ctxNewRegion.Text = "New &Region..."
        '
        'ctxNewSupervisor
        '
        Me.ctxNewSupervisor.Name = "ctxNewSupervisor"
        Me.ctxNewSupervisor.Size = New System.Drawing.Size(191, 22)
        Me.ctxNewSupervisor.Text = "New &Supervisor..."
        '
        'ctxNewTeam
        '
        Me.ctxNewTeam.Name = "ctxNewTeam"
        Me.ctxNewTeam.Size = New System.Drawing.Size(191, 22)
        Me.ctxNewTeam.Text = "New &Team..."
        '
        'ctxNewInterviewer
        '
        Me.ctxNewInterviewer.Name = "ctxNewInterviewer"
        Me.ctxNewInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.ctxNewInterviewer.Text = "New &Interviewer..."
        '
        'ctxNewSeparator
        '
        Me.ctxNewSeparator.Name = "ctxNewSeparator"
        Me.ctxNewSeparator.Size = New System.Drawing.Size(188, 6)
        '
        'ctxUpdateRegion
        '
        Me.ctxUpdateRegion.Name = "ctxUpdateRegion"
        Me.ctxUpdateRegion.Size = New System.Drawing.Size(191, 22)
        Me.ctxUpdateRegion.Text = "&Update Region..."
        Me.ctxUpdateRegion.Visible = False
        '
        'ctxUpdateSupervisor
        '
        Me.ctxUpdateSupervisor.Name = "ctxUpdateSupervisor"
        Me.ctxUpdateSupervisor.Size = New System.Drawing.Size(191, 22)
        Me.ctxUpdateSupervisor.Text = "&Update Supervisor..."
        Me.ctxUpdateSupervisor.Visible = False
        '
        'ctxUpdateTeam
        '
        Me.ctxUpdateTeam.Name = "ctxUpdateTeam"
        Me.ctxUpdateTeam.Size = New System.Drawing.Size(191, 22)
        Me.ctxUpdateTeam.Text = "&Update Team..."
        Me.ctxUpdateTeam.Visible = False
        '
        'ctxUpdateInterviewer
        '
        Me.ctxUpdateInterviewer.Name = "ctxUpdateInterviewer"
        Me.ctxUpdateInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.ctxUpdateInterviewer.Text = "&Update Interviewer..."
        Me.ctxUpdateInterviewer.Visible = False
        '
        'ctxTrackInterviewer
        '
        Me.ctxTrackInterviewer.Name = "ctxTrackInterviewer"
        Me.ctxTrackInterviewer.Size = New System.Drawing.Size(191, 22)
        Me.ctxTrackInterviewer.Text = "Trac&k Interviewer..."
        '
        'ctxMenuSeparator
        '
        Me.ctxMenuSeparator.Name = "ctxMenuSeparator"
        Me.ctxMenuSeparator.Size = New System.Drawing.Size(188, 6)
        '
        'ctxRefresh
        '
        Me.ctxRefresh.Name = "ctxRefresh"
        Me.ctxRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ctxRefresh.Size = New System.Drawing.Size(191, 22)
        Me.ctxRefresh.Text = "&Refresh"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "")
        Me.ImageList.Images.SetKeyName(1, "")
        Me.ImageList.Images.SetKeyName(2, "Open.bmp")
        Me.ImageList.Images.SetKeyName(3, "Team.bmp")
        Me.ImageList.Images.SetKeyName(4, "Interviewer.bmp")
        Me.ImageList.Images.SetKeyName(5, "Supervisor.bmp")
        Me.ImageList.Images.SetKeyName(6, "Regions.bmp")
        Me.ImageList.Images.SetKeyName(7, "none.bmp")
        Me.ImageList.Images.SetKeyName(8, "NoAction.bmp")
        '
        'MyCaption
        '
        Me.MyCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyCaption.Caption = "Field Staff"
        Me.MyCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.MyCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MyCaption.Location = New System.Drawing.Point(0, 0)
        Me.MyCaption.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MyCaption.Name = "MyCaption"
        Me.MyCaption.Size = New System.Drawing.Size(232, 26)
        Me.MyCaption.TabIndex = 0
        '
        'ucNavigate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MyPanel)
        Me.Name = "ucNavigate"
        Me.Size = New System.Drawing.Size(232, 344)
        Me.MyPanel.ResumeLayout(False)
        Me.MyTreeViewPanel.ResumeLayout(False)
        Me.ctxNavigation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyPanel As System.Windows.Forms.Panel
    Friend WithEvents MyTreeViewPanel As System.Windows.Forms.Panel
    Friend WithEvents MyCaption As MPR.SMS.FieldManagement.UserControls.ucPaneCaption
    Friend WithEvents ctxNavigation As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents ctxNewSupervisor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxNewTeam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxNewInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxNewSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxUpdateSupervisor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxUpdateTeam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxUpdateInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxTrackInterviewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxRefresh As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents tvNavigation As System.Windows.Forms.TreeView
    Friend WithEvents ctxNewRegion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxUpdateRegion As System.Windows.Forms.ToolStripMenuItem

End Class
