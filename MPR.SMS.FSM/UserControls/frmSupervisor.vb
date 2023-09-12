Imports MPR.SMS.Data
Imports MPR.SMS.Security

Public Class frmSupervisor
    Inherits System.Windows.Forms.Form

#Region "Private Fields"

    Private mobjSupervisor As InterviewerSupervisor
    Private mobjRegion As InterviewerRegion

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal objSupervisor As InterviewerSupervisor)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjSupervisor = objSupervisor
        mobjRegion = objSupervisor.InterviewerRegion
        FillForm(mobjSupervisor)
    End Sub

    Public Sub New(ByVal objSupervisor As InterviewerSupervisor, ByVal objRegion As InterviewerRegion)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjSupervisor = objSupervisor
        mobjRegion = objRegion
        FillForm(mobjSupervisor)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillForm(ByVal objSupervisor As InterviewerSupervisor)

        If objSupervisor.InterviewerSupervisorID.IsNull Then
            btnOK.Text = "Add"
            Me.Text = "Add Supervisor"
        Else
            btnOK.Text = "Update"
            Me.Text = "Update Supervisor - " & objSupervisor.FullName
            With objSupervisor
                txtLastName.Text = GetSafeValue(.LastName)
                txtFirstName.Text = GetSafeValue(.FirstName)
                txtLogin.Text = GetSafeValue(.UserName)
            End With

        End If

        cboRegions.Items.Clear()
        cboRegions.ValueMember = "InterviewerRegionID"
        cboRegions.DisplayMember = "Name"

        Dim objRegions As New InterviewerRegions
        Dim objRegion As InterviewerRegion
        For Each objRegion In objRegions
            cboRegions.Items.Add(objRegion)
        Next
        If mobjRegion Is Nothing OrElse
           mobjRegion.InterviewerRegionID.IsNull Then
            cboRegions.SelectedIndex = - 1
        Else
            Dim i As Integer = 0
            For Each objRegion In cboRegions.Items
                If objRegion.InterviewerRegionID = mobjRegion.InterviewerRegionID Then
                    cboRegions.SelectedIndex = i
                End If
                i += 1
            Next
        End If

        EnableButtons()
    End Sub

    Private Sub FillObject(ByVal objSupervisor As InterviewerSupervisor)

        With objSupervisor
            .LastName = txtLastName.Text.Trim()
            .FirstName = txtFirstName.Text.Trim()
            .UserName = txtLogin.Text.Trim()

            If cboRegions.SelectedIndex >= 0 Then
                .InterviewerRegionID = CType(CType(cboRegions.SelectedItem, InterviewerRegion).InterviewerRegionID,
                                             SqlTypes.SqlInt32)
            Else
                .InterviewerRegionID = New SqlTypes.SqlInt32
            End If

        End With
    End Sub

    Private Sub EnableButtons()

        ' Enable/Disable the OK button as needed

        btnOK.Enabled = txtLastName.Text.Trim().Length > 0 AndAlso
                        txtFirstName.Text.Trim().Length > 0 'AndAlso cboRegions.SelectedIndex >= 0

        If btnOK.Enabled Then
            Me.AcceptButton = btnOK
        Else
            Me.AcceptButton = Nothing
        End If
        Me.CancelButton = btnCancel

        cboRegions.Enabled = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
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
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents SupervisorInfoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents cboRegions As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SupervisorInfoGroupBox = New System.Windows.Forms.GroupBox
        Me.lblLName = New System.Windows.Forms.Label
        Me.lblFN = New System.Windows.Forms.Label
        Me.cboRegions = New System.Windows.Forms.ComboBox
        Me.lblRegion = New System.Windows.Forms.Label
        Me.txtLogin = New System.Windows.Forms.TextBox
        Me.lblLogin = New System.Windows.Forms.Label
        Me.SupervisorInfoGroupBox.SuspendLayout()
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
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(210, 29)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(162, 20)
        Me.txtLastName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(52, 29)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(140, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(216, 132)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(303, 132)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'SupervisorInfoGroupBox
        '
        Me.SupervisorInfoGroupBox.Controls.Add(Me.lblLogin)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.txtLogin)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.txtFirstName)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.txtLastName)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.lblLName)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.lblFN)
        Me.SupervisorInfoGroupBox.Controls.Add(Me.lblFirstName)
        Me.SupervisorInfoGroupBox.Location = New System.Drawing.Point(6, 12)
        Me.SupervisorInfoGroupBox.Name = "SupervisorInfoGroupBox"
        Me.SupervisorInfoGroupBox.Size = New System.Drawing.Size(381, 104)
        Me.SupervisorInfoGroupBox.TabIndex = 0
        Me.SupervisorInfoGroupBox.TabStop = False
        Me.SupervisorInfoGroupBox.Text = "Supervisor information"
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                   System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.Location = New System.Drawing.Point(208, 48)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(29, 12)
        Me.lblLName.TabIndex = 4
        Me.lblLName.Text = "(Last)"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(50, 48)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(30, 12)
        Me.lblFN.TabIndex = 3
        Me.lblFN.Text = "(First)"
        '
        'cboRegions
        '
        Me.cboRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegions.Location = New System.Drawing.Point(58, 132)
        Me.cboRegions.Name = "cboRegions"
        Me.cboRegions.Size = New System.Drawing.Size(140, 21)
        Me.cboRegions.TabIndex = 2
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(14, 132)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(44, 13)
        Me.lblRegion.TabIndex = 1
        Me.lblRegion.Text = "Region:"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(210, 69)
        Me.txtLogin.MaxLength = 32
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(165, 20)
        Me.txtLogin.TabIndex = 5
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(139, 69)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(65, 13)
        Me.lblLogin.TabIndex = 6
        Me.lblLogin.Text = "Login name:"
        '
        'frmSupervisor
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(393, 165)
        Me.Controls.Add(Me.cboRegions)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.SupervisorInfoGroupBox)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSupervisor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supervisor Properties"
        Me.SupervisorInfoGroupBox.ResumeLayout(False)
        Me.SupervisorInfoGroupBox.PerformLayout()
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
            FillObject(mobjSupervisor)
            If Not mobjSupervisor.Update() Then
                Me.txtFirstName.Focus()
                Me.txtFirstName.SelectAll()
                MessageBox.Show("The Supervisor name you have specified is already being used.", "New Supervisor",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = System.Windows.Forms.DialogResult.None
            End If
        End If
    End Sub

    Private Sub txtFirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtFirstName.TextChanged

        EnableButtons()
    End Sub

    Private Sub txtLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtLastName.TextChanged

        EnableButtons()
    End Sub

    Private Sub cboRegions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboRegions.SelectedIndexChanged

        EnableButtons()
    End Sub

#End Region
End Class
