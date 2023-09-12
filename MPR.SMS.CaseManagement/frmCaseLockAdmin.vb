'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmCaseLockAdmin
    Inherits Form

#Region "Private Fields"

#End Region

#Region "Public Properties"

#End Region

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnRelease As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvwCaseLocks As System.Windows.Forms.ListView

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(frmCaseLockAdmin))
        Me.btnRelease = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lvwCaseLocks = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'btnRelease
        '
        Me.btnRelease.Anchor =
            CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.btnRelease.Enabled = False
        Me.btnRelease.Location = New System.Drawing.Point(150, 214)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(136, 25)
        Me.btnRelease.TabIndex = 1
        Me.btnRelease.Text = "&Release Case Lock"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),
                                   System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(302, 214)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(137, 25)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        '
        'lvwCaseLocks
        '
        Me.lvwCaseLocks.AllowColumnReorder = True
        Me.lvwCaseLocks.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.lvwCaseLocks.FullRowSelect = True
        Me.lvwCaseLocks.HideSelection = False
        Me.lvwCaseLocks.Location = New System.Drawing.Point(8, 9)
        Me.lvwCaseLocks.MultiSelect = False
        Me.lvwCaseLocks.Name = "lvwCaseLocks"
        Me.lvwCaseLocks.Size = New System.Drawing.Size(431, 193)
        Me.lvwCaseLocks.TabIndex = 0
        Me.lvwCaseLocks.UseCompatibleStateImageBehavior = False
        '
        'frmCaseLockAdmin
        '
        Me.AcceptButton = Me.btnRelease
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(446, 249)
        Me.Controls.Add(Me.lvwCaseLocks)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRelease)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCaseLockAdmin"
        Me.Padding = New System.Windows.Forms.Padding(7)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Case Lock Administration"
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.CenterToScreen()

        ShowLocks()
    End Sub

#End Region

#Region "Public Properties"

#End Region

#Region "Private Methods"

    Private Sub ShowLocks()

        Dim objLocks As New CaseLocks

        Dim objSelectedLock As CaseLock = Nothing

        If Not lvwCaseLocks.Tag Is Nothing Then
            If lvwCaseLocks.Tag.GetType().ToString() = "MPR.SMS.Data.CaseLocks" Then
                If lvwCaseLocks.SelectedItems.Count = 1 Then
                    objSelectedLock = CType(lvwCaseLocks.SelectedItems(0).Tag, CaseLock)
                End If
            End If
        End If

        lvwCaseLocks.Clear()

        lvwCaseLocks.Tag = objLocks

        lvwCaseLocks.View = View.Details

        lvwCaseLocks.Columns.Add("CaseID", 0, HorizontalAlignment.Left)
        lvwCaseLocks.Columns.Add("Lock Date", 0, HorizontalAlignment.Left)
        lvwCaseLocks.Columns.Add("Windows User Name", 0, HorizontalAlignment.Left)
        lvwCaseLocks.Columns.Add("Workstation", 0, HorizontalAlignment.Left)

        Dim objLock As CaseLock

        For Each objLock In objLocks
            Dim lvi As ListViewItem = lvwCaseLocks.Items.Add(objLock.CaseID.ToString)
            lvi.Tag = objLock
            'lvi.ImageIndex = 5
            If Not objLock.LockDate.IsNull Then
                lvi.SubItems.Add(objLock.LockDate.ToString)
            End If
            If Not objLock.UserName.IsNull Then
                lvi.SubItems.Add(objLock.UserName.Value)
            End If
            If Not objLock.Workstation.IsNull Then
                lvi.SubItems.Add(objLock.Workstation.Value)
            End If
            If (Not objSelectedLock Is Nothing) AndAlso
               (objSelectedLock.CaseID.Value = objLock.CaseID.Value) Then
                lvi.Selected = True
                lvi.Focused = True
            End If
        Next

        ' Auto size the columns

        Dim ch As ColumnHeader

        For Each ch In lvwCaseLocks.Columns
            ch.Width = - 2
        Next

        If lvwCaseLocks.SelectedItems.Count > 0 Then
            lvwCaseLocks.Items(0).Focused = True
            lvwCaseLocks.Items(0).Selected = True
        End If

        lvwCaseLocks.Invalidate()
    End Sub

    Private Sub ReleaseLock()

        If lvwCaseLocks.SelectedItems.Count = 0 Then
            btnRelease.Enabled = False
            Return
        End If

        Dim objLock As CaseLock = CType(lvwCaseLocks.SelectedItems(0).Tag, CaseLock)
        Dim strMsg As String = "Are you sure you want to release the lock for CaseID '" & objLock.CaseID.Value & "'?"

        If _
            MessageBox.Show(strMsg, "Survey Management System Case Locks", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) = DialogResult.Yes Then
            If objLock.Delete Then
                lvwCaseLocks.SelectedItems(0).Remove()
            End If
        End If
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub lvwCaseLocks_Click(sender As Object, e As EventArgs) _
        Handles lvwCaseLocks.Click, lvwCaseLocks.SelectedIndexChanged

        btnRelease.Enabled = (lvwCaseLocks.SelectedItems.Count > 0)
    End Sub

    Private Sub btnRelease_Click(sender As Object, e As EventArgs) Handles btnRelease.Click
        ReleaseLock()
    End Sub

    Private Sub lvwCaseLocks_DoubleClick(sender As Object, e As EventArgs) Handles lvwCaseLocks.ItemActivate
        ReleaseLock()
    End Sub

    Private Sub frmCaseLockAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - " & Me.Text
    End Sub

#End Region
End Class
