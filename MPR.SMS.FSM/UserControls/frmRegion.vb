Imports MPR.SMS.Data
Imports MPR.SMS.Security

Public Class frmRegion
    Inherits System.Windows.Forms.Form

#Region "Private Fields"

    Private mobjRegion As InterviewerRegion

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal objRegion As InterviewerRegion)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjRegion = objRegion
        FillForm(mobjRegion)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillForm(ByVal objRegion As InterviewerRegion)

        If objRegion.InterviewerRegionID.IsNull Then
            btnOK.Text = "Add"
            Me.Text = "Add Region"
        Else
            btnOK.Text = "Update"
            Me.Text = "Update Region - " & GetSafeValue(objRegion.Name)
            With objRegion
                txtName.Text = GetSafeValue(.Name)
            End With

        End If

        EnableButtons()
    End Sub

    Private Sub FillObject(ByVal objRegion As InterviewerRegion)

        With objRegion
            .Name = txtName.Text.Trim()

        End With
    End Sub

    Private Sub EnableButtons()

        ' Enable/Disable the OK button as needed

        btnOK.Enabled = txtName.Text.Trim().Length > 0

        If btnOK.Enabled Then
            Me.AcceptButton = btnOK
        Else
            Me.AcceptButton = Nothing
        End If
        Me.CancelButton = btnCancel
    End Sub

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
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpRegion As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpRegion = New System.Windows.Forms.GroupBox
        Me.grpRegion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(8, 29)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(38, 13)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(52, 29)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(233, 20)
        Me.txtName.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(135, 106)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(216, 106)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'grpRegion
        '
        Me.grpRegion.Controls.Add(Me.txtName)
        Me.grpRegion.Controls.Add(Me.lblFirstName)
        Me.grpRegion.Location = New System.Drawing.Point(6, 12)
        Me.grpRegion.Name = "grpRegion"
        Me.grpRegion.Size = New System.Drawing.Size(295, 75)
        Me.grpRegion.TabIndex = 0
        Me.grpRegion.TabStop = False
        Me.grpRegion.Text = "Region information"
        '
        'frmRegion
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(308, 141)
        Me.Controls.Add(Me.grpRegion)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Region Properties"
        Me.grpRegion.ResumeLayout(False)
        Me.grpRegion.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'If FormValidator.IsValid() Then
        DialogResult = System.Windows.Forms.DialogResult.OK
        'Else
        '    FormValidator.Validate()
        '    DialogResult = System.Windows.Forms.DialogResult.None
        'End If

        If DialogResult = System.Windows.Forms.DialogResult.OK Then
            FillObject(mobjRegion)
            If Not mobjRegion.Update() Then
                Me.txtName.Focus()
                Me.txtName.SelectAll()
                MessageBox.Show("The Region name you have specified is already being used.", "New Region",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = System.Windows.Forms.DialogResult.None
            End If
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

        EnableButtons()
    End Sub

#End Region
End Class
