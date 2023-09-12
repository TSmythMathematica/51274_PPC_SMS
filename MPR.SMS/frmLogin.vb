'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Configuration
Imports System.Reflection
Imports System.Security.Principal
Imports MPR.SMS.Security
'Imports System.IO
'Imports System.Diagnostics
'Imports System.DirectoryServices

Public Class frmLogin
    Inherits Form

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Form object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Form object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Data.Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

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
    Private WithEvents panelHeader As System.Windows.Forms.Panel
    Private WithEvents pbSMS As System.Windows.Forms.PictureBox
    Private WithEvents lblSMS As System.Windows.Forms.Label
    Private WithEvents lblUserName As System.Windows.Forms.Label
    Private WithEvents lblPassword As System.Windows.Forms.Label
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkWindowsAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents pnlWindowsAuthentication As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblVersion As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.panelHeader = New System.Windows.Forms.Panel
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblSMS = New System.Windows.Forms.Label
        Me.pbSMS = New System.Windows.Forms.PictureBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkWindowsAuthentication = New System.Windows.Forms.CheckBox
        Me.pnlWindowsAuthentication = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.panelHeader.SuspendLayout()
        CType(Me.pbSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWindowsAuthentication.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.White
        Me.panelHeader.Controls.Add(Me.lblVersion)
        Me.panelHeader.Controls.Add(Me.lblSMS)
        Me.panelHeader.Controls.Add(Me.pbSMS)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(370, 72)
        Me.panelHeader.TabIndex = 0
        '
        'lblVersion
        '
        Me.lblVersion.AccessibleDescription = "Version label"
        Me.lblVersion.AccessibleName = "Version Label"
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(89, 44)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(192, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "< version >"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSMS
        '
        Me.lblSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold,
                                                 System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMS.Location = New System.Drawing.Point(70, 16)
        Me.lblSMS.Name = "lblSMS"
        Me.lblSMS.Size = New System.Drawing.Size(288, 18)
        Me.lblSMS.TabIndex = 0
        Me.lblSMS.Text = "MPR Survey Management System"
        Me.lblSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbSMS
        '
        Me.pbSMS.Image = CType(resources.GetObject("pbSMS.Image"), System.Drawing.Image)
        Me.pbSMS.Location = New System.Drawing.Point(16, 16)
        Me.pbSMS.Name = "pbSMS"
        Me.pbSMS.Size = New System.Drawing.Size(48, 48)
        Me.pbSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSMS.TabIndex = 0
        Me.pbSMS.TabStop = False
        '
        'lblUserName
        '
        Me.lblUserName.AccessibleDescription = "User Name"
        Me.lblUserName.AccessibleName = "User Name"
        Me.lblUserName.AutoSize = True
        Me.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular,
                                                      System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserName.Location = New System.Drawing.Point(58, 20)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(61, 13)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "User name:"
        '
        'lblPassword
        '
        Me.lblPassword.AccessibleDescription = "Password"
        Me.lblPassword.AccessibleName = "Password"
        Me.lblPassword.AutoSize = True
        Me.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular,
                                                      System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPassword.Location = New System.Drawing.Point(58, 52)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = "Password"
        Me.txtPassword.AccessibleName = "Password"
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPassword.Location = New System.Drawing.Point(130, 48)
        Me.txtPassword.MaxLength = 32
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(192, 20)
        Me.txtPassword.TabIndex = 4
        '
        'txtUserName
        '
        Me.txtUserName.AccessibleDescription = "User name"
        Me.txtUserName.AccessibleName = "User name"
        Me.txtUserName.Location = New System.Drawing.Point(130, 16)
        Me.txtUserName.MaxLength = 32
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(192, 20)
        Me.txtUserName.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(154, 83)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(72, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "Login"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(250, 83)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'chkWindowsAuthentication
        '
        Me.chkWindowsAuthentication.AutoSize = True
        Me.chkWindowsAuthentication.Checked = True
        Me.chkWindowsAuthentication.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWindowsAuthentication.Location = New System.Drawing.Point(130, 6)
        Me.chkWindowsAuthentication.Name = "chkWindowsAuthentication"
        Me.chkWindowsAuthentication.Size = New System.Drawing.Size(141, 17)
        Me.chkWindowsAuthentication.TabIndex = 7
        Me.chkWindowsAuthentication.Text = "Windows Authentication"
        Me.chkWindowsAuthentication.UseVisualStyleBackColor = True
        '
        'pnlWindowsAuthentication
        '
        Me.pnlWindowsAuthentication.Controls.Add(Me.chkWindowsAuthentication)
        Me.pnlWindowsAuthentication.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlWindowsAuthentication.Location = New System.Drawing.Point(0, 72)
        Me.pnlWindowsAuthentication.Name = "pnlWindowsAuthentication"
        Me.pnlWindowsAuthentication.Size = New System.Drawing.Size(370, 22)
        Me.pnlWindowsAuthentication.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtUserName)
        Me.Panel2.Controls.Add(Me.txtPassword)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.lblUserName)
        Me.Panel2.Controls.Add(Me.lblPassword)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 127)
        Me.Panel2.TabIndex = 9
        '
        'frmLogin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 221)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlWindowsAuthentication)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.panelHeader.ResumeLayout(False)
        CType(Me.pbSMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWindowsAuthentication.ResumeLayout(False)
        Me.pnlWindowsAuthentication.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Get the application domain's executing assembly

        Dim objEntryAssembly As Assembly = Assembly.GetEntryAssembly()

        Dim title As AssemblyTitleAttribute =
                CType(AssemblyTitleAttribute.GetCustomAttribute(objEntryAssembly, GetType(AssemblyTitleAttribute)),
                      AssemblyTitleAttribute)

        Me.Text = title.Title & " " + Me.Text

        ' Initialize version information

        lblVersion.Text = "Version " & Application.ProductVersion

        ' Initially disable OK button

        btnOK.Enabled = False

        Me.txtUserName.Text = WindowsIdentity.GetCurrent.Name

        CurrentUser.Login(Nothing)

        Me.chkWindowsAuthentication.Visible = CurrentUser.IsAuthenticated AndAlso
                                              CurrentUser.IsInRole(Enumerations.Role.SystemAdministrator)
        If Not Me.chkWindowsAuthentication.Visible Then
            Me.pnlWindowsAuthentication.Visible = False
            Me.Height -= Me.pnlWindowsAuthentication.Height
        End If
    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged

        ' Enable OK button if username and password have been entered

        btnOK.Enabled = (Trim(txtUserName.Text).Length > 0) And (Trim(txtPassword.Text).Length > 0)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

        ' Enable OK button if username and password have been entered

        btnOK.Enabled = (Trim(txtUserName.Text).Length > 0) And (Trim(txtPassword.Text).Length > 0)
    End Sub

    Private Sub chkWindowsAuthentication_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkWindowsAuthentication.CheckedChanged

        If Not chkWindowsAuthentication.Visible Then Return

        Me.txtUserName.ReadOnly = chkWindowsAuthentication.Checked

        If chkWindowsAuthentication.Checked Then
            Me.txtUserName.Text = WindowsIdentity.GetCurrent.Name
            Me.txtPassword.Text = String.Empty
        End If

        EnableOKButton()
    End Sub

    Private Sub EnableOKButton()

        btnOK.Enabled = (Me.txtUserName.Text.Trim().Length > 0) AndAlso
                        (Me.chkWindowsAuthentication.Checked OrElse Me.txtPassword.Text.Trim().Length > 0)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        ' Login using the specified username and password

        btnOK.Enabled = False

        txtUserName.Enabled = False
        txtPassword.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        Me.CancelButton = Nothing

        If IsAuthenticated() Then
            Me.DialogResult = DialogResult.OK
        Else
            btnOK.Enabled = True
            txtPassword.Enabled = True
            txtPassword.Focus()
            txtPassword.SelectAll()
            txtUserName.Enabled = Me.chkWindowsAuthentication.Visible
            txtUserName.ReadOnly = Me.chkWindowsAuthentication.Checked
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(Me, "The authentication information you have supplied is not valid.",
                            "Survey Management System Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CancelButton = Me.btnCancel
        End If
    End Sub


    Private Sub btnOK_EnabledChanged(sender As Object, e As EventArgs) Handles btnOK.EnabledChanged

        ' Set the AcceptButton (i.e. default button) based on OK button's enabled state

        If btnOK.Enabled Then
            AcceptButton = btnOK
        Else
            AcceptButton = Nothing
        End If
    End Sub

    Private IsFirstActivate As Boolean = True

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If IsFirstActivate Then
            IsFirstActivate = False
            If Me.txtUserName.Text.Trim() <> String.Empty Then
                Me.txtPassword.Focus()
            End If
        End If
    End Sub

    Private Function IsAuthenticated() As Boolean

        Dim isAuthenticatedByAD As Boolean = False

        Try
            'MPR.SMS.Security.CurrentUser.Login(System.Configuration.ConfigurationManager.AppSettings("ProjectShortName"))
            If Me.chkWindowsAuthentication.Checked Then

                isAuthenticatedByAD = True
                CurrentUser.Login(ConfigurationManager.AppSettings("ProjectShortName"))
            Else
                CurrentUser.Login(ConfigurationManager.AppSettings("ProjectShortName"), Me.txtUserName.Text.Trim(),
                                  Me.txtPassword.Text.Trim())
            End If

            If Not CurrentUser.IsAuthenticated Then
                Return False
            End If
            Return True
        Catch ex As Exception
            If isAuthenticatedByAD Then
                Dim msg As String = "Your password was accepted, but there was an issue getting security settings" +
                                    vbCrLf + vbCrLf +
                                    ex.Message
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
            Return False
        End Try
    End Function

#End Region
End Class
