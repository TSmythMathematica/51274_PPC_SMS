Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports System.Drawing

Public Class frmInterviewer
    Inherits System.Windows.Forms.Form

#Region "Private Fields"

    Private mobjInterviewer As Interviewer
    Private mobjSupervisor As InterviewerSupervisor
    Private mobjTeam As InterviewerTeam

#End Region

#Region "Events"

    Public Event AddInterviewer(ByVal Interviewer As Interviewer)

    Public Event UpdateInterviewer(ByVal Interviewer As Interviewer)

#End Region

#Region "Public Properties"


#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal objInterviewer As Interviewer)

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjInterviewer = objInterviewer
        mobjTeam = objInterviewer.InterviewerTeam
        If mobjTeam Is Nothing Then
            mobjSupervisor = mobjInterviewer.InterviewerSupervisor
        Else
            mobjSupervisor = mobjTeam.InterviewerSupervisor
        End If
        FillForm(mobjInterviewer)
    End Sub

    Public Sub New(ByVal objInterviewer As Interviewer, ByVal objSupervisor As InterviewerSupervisor)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjInterviewer = objInterviewer
        mobjSupervisor = objSupervisor
        mobjTeam = Nothing
        FillForm(mobjInterviewer)
    End Sub

    Public Sub New(ByVal objInterviewer As Interviewer, ByVal objTeam As InterviewerTeam)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjInterviewer = objInterviewer
        mobjTeam = objTeam
        mobjSupervisor = objTeam.InterviewerSupervisor
        FillForm(mobjInterviewer)
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSupervisors As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtExpectedHoursPerWeek As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAddressLine1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddressLine2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtApptDayOfWeek As System.Windows.Forms.TextBox
    Friend WithEvents txtApptTime As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtMileageRate As System.Windows.Forms.TextBox
    Friend WithEvents txtLaptopID As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PrintButton As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents txtLastSendRecDate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblInterviewerTeams As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtPostalCode As MPR.SMS.UserControls.ZipCodeWithValidator
    Friend WithEvents grpAddress As System.Windows.Forms.GroupBox
    Friend WithEvents txtPhone2 As MPR.SMS.UserControls.PhoneWithValidator
    Friend WithEvents txtPhone1 As MPR.SMS.UserControls.PhoneWithValidator
    Friend WithEvents txtState As MPR.SMS.UserControls.StateComboBox
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents lblAdd2 As System.Windows.Forms.Label
    Friend WithEvents lblAdd1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents txtTeam As System.Windows.Forms.TextBox
    Friend WithEvents txtSupervisor As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(frmInterviewer))
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblSupervisors = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLastSendRecDate = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtLaptopID = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtMileageRate = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtExpectedHoursPerWeek = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtApptDayOfWeek = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtApptTime = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtEmployeeID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAddressLine1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddressLine2 = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PrintButton = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.lblInterviewerTeams = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.grpAddress = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblAdd2 = New System.Windows.Forms.Label
        Me.lblAdd1 = New System.Windows.Forms.Label
        Me.lblLName = New System.Windows.Forms.Label
        Me.lblFN = New System.Windows.Forms.Label
        Me.txtState = New MPR.SMS.UserControls.StateComboBox
        Me.txtPhone2 = New MPR.SMS.UserControls.PhoneWithValidator
        Me.txtPhone1 = New MPR.SMS.UserControls.PhoneWithValidator
        Me.txtPostalCode = New MPR.SMS.UserControls.ZipCodeWithValidator
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary
        Me.txtSupervisor = New System.Windows.Forms.TextBox
        Me.txtTeam = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.grpAddress.SuspendLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(301, 386)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(67, 32)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(126, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(199, 32)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(140, 20)
        Me.txtLastName.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 32)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(381, 386)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'lblSupervisors
        '
        Me.lblSupervisors.AutoSize = True
        Me.lblSupervisors.Location = New System.Drawing.Point(13, 347)
        Me.lblSupervisors.Name = "lblSupervisors"
        Me.lblSupervisors.Size = New System.Drawing.Size(60, 13)
        Me.lblSupervisors.TabIndex = 2
        Me.lblSupervisors.Text = "Supervisor:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLastSendRecDate)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtLaptopID)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtMileageRate)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtRate)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtExpectedHoursPerWeek)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtApptDayOfWeek)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtApptTime)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 222)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 110)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Interviewer"
        '
        'txtLastSendRecDate
        '
        Me.txtLastSendRecDate.Location = New System.Drawing.Point(386, 80)
        Me.txtLastSendRecDate.Name = "txtLastSendRecDate"
        Me.txtLastSendRecDate.ReadOnly = True
        Me.txtLastSendRecDate.Size = New System.Drawing.Size(120, 20)
        Me.txtLastSendRecDate.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(383, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Last transmission date:"
        '
        'txtLaptopID
        '
        Me.txtLaptopID.Location = New System.Drawing.Point(259, 80)
        Me.txtLaptopID.Name = "txtLaptopID"
        Me.txtLaptopID.Size = New System.Drawing.Size(96, 20)
        Me.txtLaptopID.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(256, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Laptop ID:"
        '
        'txtMileageRate
        '
        Me.txtMileageRate.Location = New System.Drawing.Point(67, 80)
        Me.txtMileageRate.Name = "txtMileageRate"
        Me.txtMileageRate.ReadOnly = True
        Me.txtMileageRate.Size = New System.Drawing.Size(65, 20)
        Me.txtMileageRate.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(64, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Mileage rate:"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(9, 80)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(48, 20)
        Me.txtRate.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Rate:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"active", "inactive", "removed"})
        Me.cboStatus.Location = New System.Drawing.Point(426, 40)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(80, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(423, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Status:"
        '
        'txtExpectedHoursPerWeek
        '
        Me.txtExpectedHoursPerWeek.Location = New System.Drawing.Point(259, 40)
        Me.txtExpectedHoursPerWeek.Name = "txtExpectedHoursPerWeek"
        Me.txtExpectedHoursPerWeek.Size = New System.Drawing.Size(48, 20)
        Me.txtExpectedHoursPerWeek.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(256, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Expected hours per week:"
        '
        'txtApptDayOfWeek
        '
        Me.txtApptDayOfWeek.Location = New System.Drawing.Point(150, 40)
        Me.txtApptDayOfWeek.Name = "txtApptDayOfWeek"
        Me.txtApptDayOfWeek.Size = New System.Drawing.Size(96, 20)
        Me.txtApptDayOfWeek.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(147, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Day of week:"
        '
        'txtApptTime
        '
        Me.txtApptTime.Location = New System.Drawing.Point(9, 40)
        Me.txtApptTime.Name = "txtApptTime"
        Me.txtApptTime.Size = New System.Drawing.Size(123, 20)
        Me.txtApptTime.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Appointment time:"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(150, 80)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(96, 20)
        Me.txtEmployeeID.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(147, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Employee ID:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(67, 171)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(272, 20)
        Me.txtEmail.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Email:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Phone:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(427, 32)
        Me.txtDescription.MaxLength = 10
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(95, 20)
        Me.txtDescription.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(361, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Description:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(361, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Zip code:"
        '
        'txtAddressLine1
        '
        Me.txtAddressLine1.Location = New System.Drawing.Point(67, 72)
        Me.txtAddressLine1.MaxLength = 40
        Me.txtAddressLine1.Name = "txtAddressLine1"
        Me.txtAddressLine1.Size = New System.Drawing.Size(272, 20)
        Me.txtAddressLine1.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Address:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "State:"
        '
        'txtAddressLine2
        '
        Me.txtAddressLine2.Location = New System.Drawing.Point(67, 94)
        Me.txtAddressLine2.MaxLength = 40
        Me.txtAddressLine2.Name = "txtAddressLine2"
        Me.txtAddressLine2.Size = New System.Drawing.Size(272, 20)
        Me.txtAddressLine2.TabIndex = 11
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(67, 119)
        Me.txtCity.MaxLength = 25
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(126, 20)
        Me.txtCity.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "City:"
        '
        'PrintButton
        '
        Me.PrintButton.Location = New System.Drawing.Point(461, 386)
        Me.PrintButton.Name = "PrintButton"
        Me.PrintButton.Size = New System.Drawing.Size(75, 23)
        Me.PrintButton.TabIndex = 8
        Me.PrintButton.Text = "Print"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'lblInterviewerTeams
        '
        Me.lblInterviewerTeams.AutoSize = True
        Me.lblInterviewerTeams.Location = New System.Drawing.Point(13, 373)
        Me.lblInterviewerTeams.Name = "lblInterviewerTeams"
        Me.lblInterviewerTeams.Size = New System.Drawing.Size(37, 13)
        Me.lblInterviewerTeams.TabIndex = 4
        Me.lblInterviewerTeams.Text = "Team:"
        '
        'PrintDocument1
        '
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.Label1)
        Me.grpAddress.Controls.Add(Me.Label2)
        Me.grpAddress.Controls.Add(Me.lblAdd2)
        Me.grpAddress.Controls.Add(Me.lblAdd1)
        Me.grpAddress.Controls.Add(Me.lblLName)
        Me.grpAddress.Controls.Add(Me.lblFN)
        Me.grpAddress.Controls.Add(Me.txtState)
        Me.grpAddress.Controls.Add(Me.txtPhone2)
        Me.grpAddress.Controls.Add(Me.txtPhone1)
        Me.grpAddress.Controls.Add(Me.txtPostalCode)
        Me.grpAddress.Controls.Add(Me.lblName)
        Me.grpAddress.Controls.Add(Me.txtLastName)
        Me.grpAddress.Controls.Add(Me.txtFirstName)
        Me.grpAddress.Controls.Add(Me.Label3)
        Me.grpAddress.Controls.Add(Me.txtCity)
        Me.grpAddress.Controls.Add(Me.txtAddressLine2)
        Me.grpAddress.Controls.Add(Me.Label5)
        Me.grpAddress.Controls.Add(Me.Label6)
        Me.grpAddress.Controls.Add(Me.txtAddressLine1)
        Me.grpAddress.Controls.Add(Me.Label7)
        Me.grpAddress.Controls.Add(Me.Label4)
        Me.grpAddress.Controls.Add(Me.txtDescription)
        Me.grpAddress.Controls.Add(Me.Label10)
        Me.grpAddress.Controls.Add(Me.txtEmail)
        Me.grpAddress.Controls.Add(Me.Label8)
        Me.grpAddress.Location = New System.Drawing.Point(7, 12)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Size = New System.Drawing.Size(529, 204)
        Me.grpAddress.TabIndex = 0
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "Contact Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                 System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(249, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                 System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 12)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "1"
        '
        'lblAdd2
        '
        Me.lblAdd2.AutoSize = True
        Me.lblAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                  System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd2.Location = New System.Drawing.Point(55, 100)
        Me.lblAdd2.Name = "lblAdd2"
        Me.lblAdd2.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd2.TabIndex = 10
        Me.lblAdd2.Text = "2"
        '
        'lblAdd1
        '
        Me.lblAdd1.AutoSize = True
        Me.lblAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                  System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd1.Location = New System.Drawing.Point(55, 78)
        Me.lblAdd1.Name = "lblAdd1"
        Me.lblAdd1.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd1.TabIndex = 8
        Me.lblAdd1.Text = "1"
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                   System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.Location = New System.Drawing.Point(199, 52)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(29, 12)
        Me.lblLName.TabIndex = 6
        Me.lblLName.Text = "(Last)"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular,
                                                System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(65, 52)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(30, 12)
        Me.lblFN.TabIndex = 5
        Me.lblFN.Text = "(First)"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(294, 119)
        Me.txtState.MyLabel = "State:"
        Me.txtState.MyLabelVisible = False
        Me.txtState.Name = "txtState"
        Me.txtState.SelectedState = Nothing
        Me.txtState.SelectedStateAbbreviation = "0"
        Me.txtState.SelectedStateID = 0
        Me.txtState.Size = New System.Drawing.Size(45, 24)
        Me.txtState.TabIndex = 15
        '
        'txtPhone2
        '
        Me.txtPhone2.Location = New System.Drawing.Point(259, 145)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.ReadOnly = False
        Me.txtPhone2.Required = False
        Me.txtPhone2.Size = New System.Drawing.Size(96, 20)
        Me.txtPhone2.TabIndex = 22
        Me.txtPhone2.TextFormatted = ""
        '
        'txtPhone1
        '
        Me.txtPhone1.Location = New System.Drawing.Point(67, 145)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.ReadOnly = False
        Me.txtPhone1.Required = False
        Me.txtPhone1.Size = New System.Drawing.Size(96, 21)
        Me.txtPhone1.TabIndex = 20
        Me.txtPhone1.TextFormatted = ""
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(426, 119)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.ReadOnly = False
        Me.txtPostalCode.Required = False
        Me.txtPostalCode.Size = New System.Drawing.Size(96, 20)
        Me.txtPostalCode.TabIndex = 17
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator,
                                                 "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        '
        'txtSupervisor
        '
        Me.txtSupervisor.Location = New System.Drawing.Point(74, 347)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(161, 20)
        Me.txtSupervisor.TabIndex = 3
        '
        'txtTeam
        '
        Me.txtTeam.Location = New System.Drawing.Point(74, 373)
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.ReadOnly = True
        Me.txtTeam.Size = New System.Drawing.Size(161, 20)
        Me.txtTeam.TabIndex = 5
        '
        'frmInterviewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(546, 421)
        Me.Controls.Add(Me.txtTeam)
        Me.Controls.Add(Me.txtSupervisor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpAddress)
        Me.Controls.Add(Me.lblInterviewerTeams)
        Me.Controls.Add(Me.PrintButton)
        Me.Controls.Add(Me.lblSupervisors)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInterviewer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Interviewer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpAddress.ResumeLayout(False)
        Me.grpAddress.PerformLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillForm(ByVal objInterviewer As Interviewer)

        If objInterviewer.InterviewerID.IsNull Then
            btnOK.Text = "Add"
            Me.Text = "Add Interviewer"
            cboStatus.Text = "active"
        Else
            btnOK.Text = "Update"
            Me.Text = "Update Interviewer - " & objInterviewer.FullName
            With objInterviewer
                txtLastName.Text = GetSafeValue(.LastName)
                txtFirstName.Text = GetSafeValue(.FirstName)
                txtAddressLine1.Text = GetSafeValue(.AddressLine1)
                txtAddressLine2.Text = GetSafeValue(.AddressLine2)
                txtCity.Text = GetSafeValue(.City)
                txtState.SelectedStateAbbreviation = GetSafeValue(.State)
                txtPostalCode.Text = GetSafeValue(.PostalCode)
                txtEmployeeID.Text = GetSafeValue(.EmployeeID)
                txtPhone1.Text = GetSafeValue(.Phone1)
                txtPhone2.Text = GetSafeValue(.Phone2)
                txtEmail.Text = GetSafeValue(.Email)
                txtApptTime.Text = GetSafeValue(.ApptTime)
                txtApptDayOfWeek.Text = GetSafeValue(.ApptDayofWeek)
                txtExpectedHoursPerWeek.Text = CStr(GetSafeValue(.ExpectedHoursPerWeek))
                cboStatus.Text = GetSafeValue(.Status)
                txtDescription.Text = GetSafeValue(.Description)
                txtRate.Text = CStr(GetSafeValue(.Rate))
                txtMileageRate.Text = GetSafeValue(.MileageRate.ToString)
                txtLaptopID.Text = GetSafeValue(.LaptopID)
                txtLastSendRecDate.Text = GetSafeDate(.LastTransmissionDate)


            End With

        End If
        Dim fnt As Drawing.Font = Control.DefaultFont
        fnt = New Drawing.Font(fnt, Drawing.FontStyle.Italic)
        If mobjSupervisor IsNot Nothing Then
            txtSupervisor.Text = mobjSupervisor.FullName
        Else
            txtSupervisor.Text = "<no supervisor>"
            txtSupervisor.Font = fnt
        End If
        If mobjTeam IsNot Nothing Then
            txtTeam.Text = GetSafeValue(mobjTeam.TeamName)
        Else
            txtTeam.Text = "<no team>"
            txtTeam.Font = fnt
        End If
        txtTeam.Visible = Project.ProjectUsesInterviewTeams
        lblInterviewerTeams.Visible = Project.ProjectUsesInterviewTeams

        EnableButtons()
    End Sub

    Private Sub FillObject(ByVal objInterviewer As Interviewer)

        With objInterviewer
            .LastName = txtLastName.Text.Trim()
            .FirstName = txtFirstName.Text.Trim()

            .AddressLine1 = txtAddressLine1.Text.Trim()
            .AddressLine2 = txtAddressLine2.Text.Trim()
            .City = txtCity.Text.Trim()
            .State = txtState.SelectedStateAbbreviation
            .PostalCode = txtPostalCode.Text.Trim()
            .EmployeeID = txtEmployeeID.Text.Trim()
            .Phone1 = txtPhone1.Text.Trim()
            .Phone2 = txtPhone2.Text.Trim()
            .Email = txtEmail.Text.Trim()
            .ApptTime = txtApptTime.Text.Trim()
            .ApptDayofWeek = txtApptDayOfWeek.Text.Trim()
            If txtExpectedHoursPerWeek.Text.Trim() = "" Then
                .ExpectedHoursPerWeek = 0
            Else
                .ExpectedHoursPerWeek = CInt(txtExpectedHoursPerWeek.Text.Trim())
            End If
            .Status = cboStatus.Text.Trim()
            .Description = txtDescription.Text.Trim()
            If txtRate.Text.Trim() = "" Then
                .Rate = 0
            Else
                .Rate = CType(CSng(txtRate.Text.Trim()), SqlTypes.SqlSingle)
            End If
            If txtMileageRate.Text.Trim() = "" Then
                .MileageRate = CType(CSng(0.375), SqlTypes.SqlSingle)
            Else
                .MileageRate = CType(CSng(txtMileageRate.Text.Trim()), SqlTypes.SqlSingle)
            End If
            .LaptopID = txtLaptopID.Text.Trim()

            If mobjTeam IsNot Nothing Then .TeamID = mobjTeam.TeamID
            If mobjSupervisor IsNot Nothing Then .InterviewerSupervisorID = mobjSupervisor.InterviewerSupervisorID

        End With
    End Sub

    Private Sub EnableButtons()

        ' Enable/Disable the OK button as needed
        btnOK.Enabled = txtLastName.Text.Trim().Length > 0 AndAlso
                        txtFirstName.Text.Trim().Length > 0

        If btnOK.Enabled Then
            Me.AcceptButton = btnOK
        Else
            Me.AcceptButton = Nothing
        End If
        Me.CancelButton = btnCancel
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If FormValidator.IsValid() Then
            DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            FormValidator.Validate()
            DialogResult = System.Windows.Forms.DialogResult.None
        End If

        If DialogResult = System.Windows.Forms.DialogResult.OK Then
            FillObject(mobjInterviewer)
            If Not mobjInterviewer.Update() Then
                Me.txtFirstName.Focus()
                Me.txtFirstName.SelectAll()
                MessageBox.Show("The Interviewer name you have specified is already being used.", "New Interviewer",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = System.Windows.Forms.DialogResult.None
            End If
        End If
    End Sub

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtFirstName.TextChanged

        EnableButtons()
    End Sub

    Private Sub txtLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtLastName.TextChanged

        EnableButtons()
    End Sub

#End Region

#Region "Printing"

    Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt"(ByVal hdcDest As IntPtr, ByVal nXDest As Integer,
                                                                   ByVal nYDest As Integer, ByVal nWidth As Integer,
                                                                   ByVal nHeight As Integer, ByVal hdcSrc As IntPtr,
                                                                   ByVal nXSrc As Integer, ByVal nYSrc As Integer,
                                                                   ByVal dwRop As System.Int32) As Long
    Dim memoryImage As Bitmap

    Private Sub CaptureScreen()

        Dim mygraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        memoryImage = New Bitmap(s.Width, s.Height, mygraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        Dim dc1 As IntPtr = mygraphics.GetHdc
        Dim dc2 As IntPtr = memoryGraphics.GetHdc
        BitBlt(dc2, 0, 0, Me.ClientRectangle.Width,
               Me.ClientRectangle.Height, dc1, 0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object,
                                         ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
        Handles PrintDocument1.PrintPage

        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Private Sub PrintButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintButton.Click

        CaptureScreen()
        PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.ShowDialog()
    End Sub

#End Region
End Class
