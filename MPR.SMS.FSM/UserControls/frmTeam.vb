Imports MPR.SMS.Data
Imports MPR.SMS.Security

Public Class frmTeam
    Inherits System.Windows.Forms.Form

#Region "Private Fields"

    Private mobjTeam As InterviewerTeam
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Private mobjSupervisor As InterviewerSupervisor

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal objTeam As InterviewerTeam)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjTeam = objTeam
        mobjSupervisor = objTeam.InterviewerSupervisor
        If mobjSupervisor Is Nothing Then
            mobjSupervisor = New InterviewerSupervisor(CurrentUser.Name)
        End If
        FillForm(mobjTeam)
    End Sub

    Public Sub New(ByVal objTeam As InterviewerTeam, ByVal objSupervisor As InterviewerSupervisor)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjTeam = objTeam
        mobjSupervisor = objSupervisor
        FillForm(mobjTeam)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillForm(ByVal objTeam As InterviewerTeam)

        If objTeam.TeamID.IsNull Then
            btnOK.Text = "Add"
            Me.Text = "Add Team"
            chkActive.Checked = True
        Else
            btnOK.Text = "Update"
            Me.Text = "Update Team - " & GetSafeValue(objTeam.TeamName)
            With objTeam
                txtName.Text = GetSafeValue(.TeamName)
                chkActive.Checked = GetSafeValue(.IsActive)
            End With

        End If

        cboSupervisors.Items.Clear()
        cboSupervisors.ValueMember = "InterviewerSupervisorID"
        cboSupervisors.DisplayMember = "FullName"

        Dim objSupervisors As New InterviewerSupervisors
        Dim objSupervisor As InterviewerSupervisor
        For Each objSupervisor In objSupervisors
            cboSupervisors.Items.Add(objSupervisor)
        Next
        If mobjSupervisor Is Nothing OrElse
           mobjSupervisor.InterviewerSupervisorID.IsNull Then
            cboSupervisors.SelectedIndex = - 1
        Else
            Dim i As Integer = 0
            For Each objSupervisor In cboSupervisors.Items
                If objSupervisor.InterviewerSupervisorID = mobjSupervisor.InterviewerSupervisorID Then
                    cboSupervisors.SelectedIndex = i
                End If
                i += 1
            Next
        End If

        EnableButtons()
    End Sub

    Private Sub FillObject(ByVal objTeam As InterviewerTeam)

        With objTeam
            .TeamName = txtName.Text.Trim()
            .IsActive = chkActive.Checked

            If cboSupervisors.SelectedIndex >= 0 Then
                .SupervisorID = CType(CType(cboSupervisors.SelectedItem, InterviewerSupervisor).InterviewerSupervisorID,
                                      SqlTypes.SqlInt32)
            Else
                .SupervisorID = New SqlTypes.SqlInt32
            End If

        End With
    End Sub

    Private Sub EnableButtons()

        ' Enable/Disable the OK button as needed

        btnOK.Enabled = txtName.Text.Trim().Length > 0 'AndAlso cboSupervisors.SelectedIndex >= 0

        If btnOK.Enabled Then
            Me.AcceptButton = btnOK
        Else
            Me.AcceptButton = Nothing
        End If
        Me.CancelButton = btnCancel

        cboSupervisors.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TeamInfoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents cboSupervisors As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupervisor As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(frmTeam))
        Me.lblName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TeamInfoGroupBox = New System.Windows.Forms.GroupBox
        Me.cboSupervisors = New System.Windows.Forms.ComboBox
        Me.lblSupervisor = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.TeamInfoGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(8, 26)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(68, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Team Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(82, 26)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(325, 20)
        Me.txtName.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(265, 106)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(346, 106)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'TeamInfoGroupBox
        '
        Me.TeamInfoGroupBox.Controls.Add(Me.chkActive)
        Me.TeamInfoGroupBox.Controls.Add(Me.txtName)
        Me.TeamInfoGroupBox.Controls.Add(Me.lblName)
        Me.TeamInfoGroupBox.Location = New System.Drawing.Point(6, 12)
        Me.TeamInfoGroupBox.Name = "TeamInfoGroupBox"
        Me.TeamInfoGroupBox.Size = New System.Drawing.Size(415, 75)
        Me.TeamInfoGroupBox.TabIndex = 0
        Me.TeamInfoGroupBox.TabStop = False
        Me.TeamInfoGroupBox.Text = "Team information"
        '
        'cboSupervisors
        '
        Me.cboSupervisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupervisors.Location = New System.Drawing.Point(88, 106)
        Me.cboSupervisors.Name = "cboSupervisors"
        Me.cboSupervisors.Size = New System.Drawing.Size(149, 21)
        Me.cboSupervisors.TabIndex = 2
        '
        'lblSupervisor
        '
        Me.lblSupervisor.AutoSize = True
        Me.lblSupervisor.Location = New System.Drawing.Point(14, 106)
        Me.lblSupervisor.Name = "lblSupervisor"
        Me.lblSupervisor.Size = New System.Drawing.Size(60, 13)
        Me.lblSupervisor.TabIndex = 1
        Me.lblSupervisor.Text = "Supervisor:"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(82, 52)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(62, 17)
        Me.chkActive.TabIndex = 2
        Me.chkActive.Text = "Active?"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'frmTeam
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(425, 141)
        Me.Controls.Add(Me.cboSupervisors)
        Me.Controls.Add(Me.lblSupervisor)
        Me.Controls.Add(Me.TeamInfoGroupBox)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTeam"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Team Properties"
        Me.TeamInfoGroupBox.ResumeLayout(False)
        Me.TeamInfoGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
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
            FillObject(mobjTeam)
            If Not mobjTeam.Update() Then
                Me.txtName.Focus()
                Me.txtName.SelectAll()
                MessageBox.Show("The Team name you have specified is already being used.", "New Team",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = System.Windows.Forms.DialogResult.None
            End If
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

        EnableButtons()
    End Sub

    Private Sub cboSupervisors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboSupervisors.SelectedIndexChanged

        EnableButtons()
    End Sub

#End Region
End Class
