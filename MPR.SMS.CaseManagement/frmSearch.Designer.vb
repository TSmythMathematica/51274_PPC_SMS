'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.StatusStripSearch = New System.Windows.Forms.StatusStrip()
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SearchFunction1 = New MPR.SMS.UserControls.SearchFunction()
        Me.StatusStripSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStripSearch
        '
        Me.StatusStripSearch.AutoSize = False
        Me.StatusStripSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRecordsLabel, Me.tsslError, Me.tsslStatus, Me.UserLabel})
        Me.StatusStripSearch.Location = New System.Drawing.Point(0, 578)
        Me.StatusStripSearch.Name = "StatusStripSearch"
        Me.StatusStripSearch.Size = New System.Drawing.Size(834, 25)
        Me.StatusStripSearch.TabIndex = 3
        Me.StatusStripSearch.Text = "StatusStrip1"
        '
        'TotalRecordsLabel
        '
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(71, 20)
        Me.TotalRecordsLabel.Text = "                    "
        '
        'tsslError
        '
        Me.tsslError.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslError.Image = CType(resources.GetObject("tsslError.Image"), System.Drawing.Image)
        Me.tsslError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslError.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.tsslError.Name = "tsslError"
        Me.tsslError.Size = New System.Drawing.Size(328, 20)
        Me.tsslError.Spring = True
        Me.tsslError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslError.Visible = False
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(655, 20)
        Me.tsslStatus.Spring = True
        Me.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(93, 20)
        Me.UserLabel.Text = "                      "
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SearchFunction1
        '
        Me.SearchFunction1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchFunction1.DataGridVisible = True
        Me.SearchFunction1.DataSource = Nothing
        Me.SearchFunction1.ExcelButtonVisible = True
        Me.SearchFunction1.Location = New System.Drawing.Point(0, 0)
        Me.SearchFunction1.Name = "SearchFunction1"
        Me.SearchFunction1.Size = New System.Drawing.Size(834, 575)
        Me.SearchFunction1.TabIndex = 0
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 603)
        Me.Controls.Add(Me.StatusStripSearch)
        Me.Controls.Add(Me.SearchFunction1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSearchV2"
        Me.StatusStripSearch.ResumeLayout(False)
        Me.StatusStripSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SearchFunction1 As MPR.SMS.UserControls.SearchFunction
    Friend WithEvents StatusStripSearch As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslError As System.Windows.Forms.ToolStripStatusLabel
End Class
