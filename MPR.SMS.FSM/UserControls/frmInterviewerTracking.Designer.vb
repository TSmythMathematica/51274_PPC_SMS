<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterviewerTracking
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
        Dim ListViewColumnSorter1 As MPR.SMS.FieldManagement.ListViewColumnSorter = New MPR.SMS.FieldManagement.ListViewColumnSorter
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInterviewerTracking))
        Me.lblSuppliesSent = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtAirTravel = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCarRental = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTotalExpenses = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtExpenses = New System.Windows.Forms.TextBox
        Me.txtMileage = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMileageExpense = New System.Windows.Forms.TextBox
        Me.lblMileage = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtHoursTraveling = New System.Windows.Forms.TextBox
        Me.txtHoursLocating = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtHoursInterviewing = New System.Windows.Forms.TextBox
        Me.txtHoursAdministrative = New System.Windows.Forms.TextBox
        Me.txtHours = New System.Windows.Forms.TextBox
        Me.Supplies = New System.Windows.Forms.GroupBox
        Me.txtSuppliesOther = New System.Windows.Forms.TextBox
        Me.cbSuppliesExpRep = New System.Windows.Forms.CheckBox
        Me.cbSuppliesBrochure = New System.Windows.Forms.CheckBox
        Me.cbSuppliesWYWO = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbSuppliesFedEx = New System.Windows.Forms.CheckBox
        Me.cbSuppliesChecklist = New System.Windows.Forms.CheckBox
        Me.cboWeekEnd = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.FormValidator = New MPR.Windows.Forms.Validation.FormValidator
        Me.ListValidationSummary = New MPR.Windows.Forms.Validation.ListValidationSummary
        Me.ValidatorNotes = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorWeek = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorTotal = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorAdmin = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorInterviewing = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorLocating = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorTraveling = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorOtherExp = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorMileageExp = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorCarRental = New MPR.Windows.Forms.Validation.CustomValidator
        Me.ValidatorAirTravel = New MPR.Windows.Forms.Validation.CustomValidator
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.lvInterviewerTrackings = New MPR.SMS.FieldManagement.ucListViewEx
        Me.chDateReported = New System.Windows.Forms.ColumnHeader
        Me.chWeekEnd = New System.Windows.Forms.ColumnHeader
        Me.chHours = New System.Windows.Forms.ColumnHeader
        Me.chExpenses = New System.Windows.Forms.ColumnHeader
        Me.chNotes = New System.Windows.Forms.ColumnHeader
        Me.txtDateReported = New MPR.SMS.UserControls.DateWithValidator
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Supplies.SuspendLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorInterviewing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorLocating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorTraveling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorOtherExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorMileageExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorCarRental, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidatorAirTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSuppliesSent
        '
        Me.lblSuppliesSent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSuppliesSent.Location = New System.Drawing.Point(6, 141)
        Me.lblSuppliesSent.Name = "lblSuppliesSent"
        Me.lblSuppliesSent.Size = New System.Drawing.Size(154, 40)
        Me.lblSuppliesSent.TabIndex = 7
        Me.lblSuppliesSent.Text = "<Supplies Sent>"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(401, 463)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 11
        Me.btnPrint.Text = "Print"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtAirTravel)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCarRental)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalExpenses)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtExpenses)
        Me.GroupBox2.Controls.Add(Me.txtMileage)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtMileageExpense)
        Me.GroupBox2.Controls.Add(Me.lblMileage)
        Me.GroupBox2.Location = New System.Drawing.Point(196, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 184)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Expenses"
        '
        'txtAirTravel
        '
        Me.txtAirTravel.Location = New System.Drawing.Point(104, 128)
        Me.txtAirTravel.Name = "txtAirTravel"
        Me.txtAirTravel.Size = New System.Drawing.Size(48, 20)
        Me.txtAirTravel.TabIndex = 9
        Me.txtAirTravel.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Air travel:"
        '
        'txtCarRental
        '
        Me.txtCarRental.Location = New System.Drawing.Point(104, 104)
        Me.txtCarRental.Name = "txtCarRental"
        Me.txtCarRental.Size = New System.Drawing.Size(48, 20)
        Me.txtCarRental.TabIndex = 7
        Me.txtCarRental.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Car rental:"
        '
        'txtTotalExpenses
        '
        Me.txtTotalExpenses.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtTotalExpenses.Location = New System.Drawing.Point(104, 152)
        Me.txtTotalExpenses.Name = "txtTotalExpenses"
        Me.txtTotalExpenses.Size = New System.Drawing.Size(48, 20)
        Me.txtTotalExpenses.TabIndex = 11
        Me.txtTotalExpenses.TabStop = False
        Me.txtTotalExpenses.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 152)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Total expenses:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Other expenses:"
        '
        'txtExpenses
        '
        Me.txtExpenses.Location = New System.Drawing.Point(104, 24)
        Me.txtExpenses.Name = "txtExpenses"
        Me.txtExpenses.Size = New System.Drawing.Size(48, 20)
        Me.txtExpenses.TabIndex = 1
        Me.txtExpenses.Text = "0"
        '
        'txtMileage
        '
        Me.txtMileage.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtMileage.Location = New System.Drawing.Point(104, 48)
        Me.txtMileage.Name = "txtMileage"
        Me.txtMileage.Size = New System.Drawing.Size(48, 20)
        Me.txtMileage.TabIndex = 3
        Me.txtMileage.TabStop = False
        Me.txtMileage.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mileage (miles):"
        '
        'txtMileageExpense
        '
        Me.txtMileageExpense.Location = New System.Drawing.Point(104, 72)
        Me.txtMileageExpense.Name = "txtMileageExpense"
        Me.txtMileageExpense.Size = New System.Drawing.Size(48, 20)
        Me.txtMileageExpense.TabIndex = 5
        Me.txtMileageExpense.Text = "0"
        '
        'lblMileage
        '
        Me.lblMileage.Location = New System.Drawing.Point(8, 72)
        Me.lblMileage.Name = "lblMileage"
        Me.lblMileage.Size = New System.Drawing.Size(96, 40)
        Me.lblMileage.TabIndex = 4
        Me.lblMileage.Text = "Mileage expense (miles * rate):"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(15, 400)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(533, 48)
        Me.txtNotes.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtHoursTraveling)
        Me.GroupBox1.Controls.Add(Me.txtHoursLocating)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHoursInterviewing)
        Me.GroupBox1.Controls.Add(Me.txtHoursAdministrative)
        Me.GroupBox1.Controls.Add(Me.txtHours)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 184)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Weekly hours"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Traveling:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Locating:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Interviewing:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Administrative:"
        '
        'txtHoursTraveling
        '
        Me.txtHoursTraveling.Location = New System.Drawing.Point(96, 120)
        Me.txtHoursTraveling.Name = "txtHoursTraveling"
        Me.txtHoursTraveling.Size = New System.Drawing.Size(48, 20)
        Me.txtHoursTraveling.TabIndex = 9
        Me.txtHoursTraveling.Text = "0"
        '
        'txtHoursLocating
        '
        Me.txtHoursLocating.Location = New System.Drawing.Point(96, 96)
        Me.txtHoursLocating.Name = "txtHoursLocating"
        Me.txtHoursLocating.Size = New System.Drawing.Size(48, 20)
        Me.txtHoursLocating.TabIndex = 7
        Me.txtHoursLocating.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total:"
        '
        'txtHoursInterviewing
        '
        Me.txtHoursInterviewing.Location = New System.Drawing.Point(96, 72)
        Me.txtHoursInterviewing.Name = "txtHoursInterviewing"
        Me.txtHoursInterviewing.Size = New System.Drawing.Size(48, 20)
        Me.txtHoursInterviewing.TabIndex = 5
        Me.txtHoursInterviewing.Text = "0"
        '
        'txtHoursAdministrative
        '
        Me.txtHoursAdministrative.Location = New System.Drawing.Point(96, 48)
        Me.txtHoursAdministrative.Name = "txtHoursAdministrative"
        Me.txtHoursAdministrative.Size = New System.Drawing.Size(48, 20)
        Me.txtHoursAdministrative.TabIndex = 3
        Me.txtHoursAdministrative.Text = "0"
        '
        'txtHours
        '
        Me.txtHours.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtHours.Location = New System.Drawing.Point(96, 24)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(48, 20)
        Me.txtHours.TabIndex = 1
        Me.txtHours.TabStop = False
        Me.txtHours.Text = "0"
        '
        'Supplies
        '
        Me.Supplies.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Supplies.Controls.Add(Me.txtSuppliesOther)
        Me.Supplies.Controls.Add(Me.lblSuppliesSent)
        Me.Supplies.Controls.Add(Me.cbSuppliesExpRep)
        Me.Supplies.Controls.Add(Me.cbSuppliesBrochure)
        Me.Supplies.Controls.Add(Me.cbSuppliesWYWO)
        Me.Supplies.Controls.Add(Me.Label12)
        Me.Supplies.Controls.Add(Me.cbSuppliesFedEx)
        Me.Supplies.Controls.Add(Me.cbSuppliesChecklist)
        Me.Supplies.Location = New System.Drawing.Point(388, 196)
        Me.Supplies.Name = "Supplies"
        Me.Supplies.Size = New System.Drawing.Size(168, 184)
        Me.Supplies.TabIndex = 7
        Me.Supplies.TabStop = False
        Me.Supplies.Text = "Supplies needed"
        '
        'txtSuppliesOther
        '
        Me.txtSuppliesOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppliesOther.Location = New System.Drawing.Point(58, 112)
        Me.txtSuppliesOther.Name = "txtSuppliesOther"
        Me.txtSuppliesOther.Size = New System.Drawing.Size(102, 20)
        Me.txtSuppliesOther.TabIndex = 6
        '
        'cbSuppliesExpRep
        '
        Me.cbSuppliesExpRep.Location = New System.Drawing.Point(16, 40)
        Me.cbSuppliesExpRep.Name = "cbSuppliesExpRep"
        Me.cbSuppliesExpRep.Size = New System.Drawing.Size(128, 16)
        Me.cbSuppliesExpRep.TabIndex = 1
        Me.cbSuppliesExpRep.Text = "Expense reports"
        '
        'cbSuppliesBrochure
        '
        Me.cbSuppliesBrochure.Location = New System.Drawing.Point(16, 72)
        Me.cbSuppliesBrochure.Name = "cbSuppliesBrochure"
        Me.cbSuppliesBrochure.Size = New System.Drawing.Size(104, 16)
        Me.cbSuppliesBrochure.TabIndex = 3
        Me.cbSuppliesBrochure.Text = "Brochure"
        '
        'cbSuppliesWYWO
        '
        Me.cbSuppliesWYWO.Location = New System.Drawing.Point(16, 56)
        Me.cbSuppliesWYWO.Name = "cbSuppliesWYWO"
        Me.cbSuppliesWYWO.Size = New System.Drawing.Size(142, 16)
        Me.cbSuppliesWYWO.TabIndex = 2
        Me.cbSuppliesWYWO.Text = """While You Were Out"""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Other:"
        '
        'cbSuppliesFedEx
        '
        Me.cbSuppliesFedEx.Location = New System.Drawing.Point(16, 24)
        Me.cbSuppliesFedEx.Name = "cbSuppliesFedEx"
        Me.cbSuppliesFedEx.Size = New System.Drawing.Size(128, 16)
        Me.cbSuppliesFedEx.TabIndex = 0
        Me.cbSuppliesFedEx.Text = "Fed-Ex airbills"
        '
        'cbSuppliesChecklist
        '
        Me.cbSuppliesChecklist.Location = New System.Drawing.Point(16, 88)
        Me.cbSuppliesChecklist.Name = "cbSuppliesChecklist"
        Me.cbSuppliesChecklist.Size = New System.Drawing.Size(128, 16)
        Me.cbSuppliesChecklist.TabIndex = 4
        Me.cbSuppliesChecklist.Text = "Screener checklist"
        '
        'cboWeekEnd
        '
        Me.cboWeekEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboWeekEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWeekEnd.Location = New System.Drawing.Point(404, 164)
        Me.cboWeekEnd.Name = "cboWeekEnd"
        Me.cboWeekEnd.Size = New System.Drawing.Size(144, 21)
        Me.cboWeekEnd.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Notes:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Interview week:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date reported:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(486, 463)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.Location = New System.Drawing.Point(315, 463)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Add"
        '
        'PrintDocument1
        '
        '
        'FormValidator
        '
        Me.ListValidationSummary.SetErrorCaption(Me.FormValidator, "Input error!")
        Me.ListValidationSummary.SetErrorMessage(Me.FormValidator, "Please correct the following errors before proceeding")
        Me.FormValidator.HostingForm = Me
        Me.ListValidationSummary.SetShowSummary(Me.FormValidator, True)
        Me.FormValidator.ValidateOnAccept = False
        '
        'ValidatorNotes
        '
        Me.ValidatorNotes.ControlToValidate = Me.txtNotes
        Me.ValidatorNotes.ErrorMessage = "A note is required."
        Me.ValidatorNotes.Icon = CType(resources.GetObject("ValidatorNotes.Icon"), System.Drawing.Icon)
        Me.ValidatorNotes.Required = True
        '
        'ValidatorWeek
        '
        Me.ValidatorWeek.ControlToValidate = Me.cboWeekEnd
        Me.ValidatorWeek.ErrorMessage = "Week Ending is required."
        Me.ValidatorWeek.Icon = CType(resources.GetObject("ValidatorWeek.Icon"), System.Drawing.Icon)
        Me.ValidatorWeek.Required = True
        '
        'ValidatorTotal
        '
        Me.ValidatorTotal.ControlToValidate = Me.txtTotalExpenses
        Me.ValidatorTotal.ErrorMessage = "Total Hours are required."
        Me.ValidatorTotal.Icon = CType(resources.GetObject("ValidatorTotal.Icon"), System.Drawing.Icon)
        Me.ValidatorTotal.Required = True
        '
        'ValidatorAdmin
        '
        Me.ValidatorAdmin.ControlToValidate = Me.txtHoursAdministrative
        Me.ValidatorAdmin.ErrorMessage = "Administrative Hours are required."
        Me.ValidatorAdmin.Icon = CType(resources.GetObject("ValidatorAdmin.Icon"), System.Drawing.Icon)
        Me.ValidatorAdmin.Required = True
        '
        'ValidatorInterviewing
        '
        Me.ValidatorInterviewing.ControlToValidate = Me.txtHoursInterviewing
        Me.ValidatorInterviewing.ErrorMessage = "Interviewing Hours are required."
        Me.ValidatorInterviewing.Icon = CType(resources.GetObject("ValidatorInterviewing.Icon"), System.Drawing.Icon)
        Me.ValidatorInterviewing.Required = True
        '
        'ValidatorLocating
        '
        Me.ValidatorLocating.ControlToValidate = Me.txtHoursLocating
        Me.ValidatorLocating.ErrorMessage = "A note is required."
        Me.ValidatorLocating.Icon = CType(resources.GetObject("ValidatorLocating.Icon"), System.Drawing.Icon)
        Me.ValidatorLocating.Required = True
        '
        'ValidatorTraveling
        '
        Me.ValidatorTraveling.ControlToValidate = Me.txtHoursTraveling
        Me.ValidatorTraveling.ErrorMessage = "Traveling Hours is required."
        Me.ValidatorTraveling.Icon = CType(resources.GetObject("ValidatorTraveling.Icon"), System.Drawing.Icon)
        Me.ValidatorTraveling.Required = True
        '
        'ValidatorOtherExp
        '
        Me.ValidatorOtherExp.ControlToValidate = Me.txtExpenses
        Me.ValidatorOtherExp.ErrorMessage = "Other Expenses is required."
        Me.ValidatorOtherExp.Icon = CType(resources.GetObject("ValidatorOtherExp.Icon"), System.Drawing.Icon)
        Me.ValidatorOtherExp.Required = True
        '
        'ValidatorMileageExp
        '
        Me.ValidatorMileageExp.ControlToValidate = Me.txtMileageExpense
        Me.ValidatorMileageExp.ErrorMessage = "Mileage Expense is required."
        Me.ValidatorMileageExp.Icon = CType(resources.GetObject("ValidatorMileageExp.Icon"), System.Drawing.Icon)
        Me.ValidatorMileageExp.Required = True
        '
        'ValidatorCarRental
        '
        Me.ValidatorCarRental.ControlToValidate = Me.txtCarRental
        Me.ValidatorCarRental.ErrorMessage = "Car Rental expense are required."
        Me.ValidatorCarRental.Icon = CType(resources.GetObject("ValidatorCarRental.Icon"), System.Drawing.Icon)
        Me.ValidatorCarRental.Required = True
        '
        'ValidatorAirTravel
        '
        Me.ValidatorAirTravel.ControlToValidate = Me.txtAirTravel
        Me.ValidatorAirTravel.ErrorMessage = "Air Travel expenses are required."
        Me.ValidatorAirTravel.Icon = CType(resources.GetObject("ValidatorAirTravel.Icon"), System.Drawing.Icon)
        Me.ValidatorAirTravel.Required = True
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
        'lvInterviewerTrackings
        '
        Me.lvInterviewerTrackings.AllowDrop = True
        Me.lvInterviewerTrackings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvInterviewerTrackings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDateReported, Me.chWeekEnd, Me.chHours, Me.chExpenses, Me.chNotes})
        ListViewColumnSorter1.ColumnType = MPR.SMS.FieldManagement.SortType.StringCompare
        ListViewColumnSorter1.Order = System.Windows.Forms.SortOrder.None
        ListViewColumnSorter1.SortColumn = 0
        Me.lvInterviewerTrackings.ColumnSorter = ListViewColumnSorter1
        Me.lvInterviewerTrackings.EmptyMessage = ""
        Me.lvInterviewerTrackings.FullRowSelect = True
        Me.lvInterviewerTrackings.HideSelection = False
        Me.lvInterviewerTrackings.Location = New System.Drawing.Point(15, 12)
        Me.lvInterviewerTrackings.Name = "lvInterviewerTrackings"
        Me.lvInterviewerTrackings.Size = New System.Drawing.Size(533, 141)
        Me.lvInterviewerTrackings.TabIndex = 0
        Me.lvInterviewerTrackings.UseCompatibleStateImageBehavior = False
        Me.lvInterviewerTrackings.View = System.Windows.Forms.View.Details
        '
        'chDateReported
        '
        Me.chDateReported.Text = "Date Reported"
        '
        'chWeekEnd
        '
        Me.chWeekEnd.Text = "Week End"
        '
        'chHours
        '
        Me.chHours.Text = "Hours"
        '
        'chExpenses
        '
        Me.chExpenses.Text = "Expenses"
        '
        'chNotes
        '
        Me.chNotes.Text = "Notes"
        '
        'txtDateReported
        '
        Me.txtDateReported.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDateReported.Location = New System.Drawing.Point(108, 164)
        Me.txtDateReported.Name = "txtDateReported"
        Me.txtDateReported.ReadOnly = False
        Me.txtDateReported.Required = True
        Me.txtDateReported.Size = New System.Drawing.Size(88, 20)
        Me.txtDateReported.TabIndex = 2
        '
        'frmInterviewerTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 498)
        Me.Controls.Add(Me.lvInterviewerTrackings)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Supplies)
        Me.Controls.Add(Me.cboWeekEnd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDateReported)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInterviewerTracking"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Interviewer Tracking"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Supplies.ResumeLayout(False)
        Me.Supplies.PerformLayout()
        CType(Me.FormValidator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorWeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorInterviewing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorLocating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorTraveling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorOtherExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorMileageExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorCarRental, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidatorAirTravel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSuppliesSent As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAirTravel As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCarRental As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalExpenses As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtExpenses As System.Windows.Forms.TextBox
    Friend WithEvents txtMileage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMileageExpense As System.Windows.Forms.TextBox
    Friend WithEvents lblMileage As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHoursTraveling As System.Windows.Forms.TextBox
    Friend WithEvents txtHoursLocating As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHoursInterviewing As System.Windows.Forms.TextBox
    Friend WithEvents txtHoursAdministrative As System.Windows.Forms.TextBox
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents Supplies As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuppliesOther As System.Windows.Forms.TextBox
    Friend WithEvents cbSuppliesExpRep As System.Windows.Forms.CheckBox
    Friend WithEvents cbSuppliesBrochure As System.Windows.Forms.CheckBox
    Friend WithEvents cbSuppliesWYWO As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSuppliesFedEx As System.Windows.Forms.CheckBox
    Friend WithEvents cbSuppliesChecklist As System.Windows.Forms.CheckBox
    Friend WithEvents cboWeekEnd As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDateReported As MPR.SMS.UserControls.DateWithValidator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lvInterviewerTrackings As MPR.SMS.FieldManagement.ucListViewEx
    Friend WithEvents chDateReported As System.Windows.Forms.ColumnHeader
    Friend WithEvents chWeekEnd As System.Windows.Forms.ColumnHeader
    Friend WithEvents chHours As System.Windows.Forms.ColumnHeader
    Friend WithEvents chExpenses As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNotes As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Protected WithEvents FormValidator As MPR.Windows.Forms.Validation.FormValidator
    Friend WithEvents ListValidationSummary As MPR.Windows.Forms.Validation.ListValidationSummary
    Friend WithEvents ValidatorNotes As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorWeek As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorTotal As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorAdmin As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorInterviewing As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorLocating As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorTraveling As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorOtherExp As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorMileageExp As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorCarRental As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents ValidatorAirTravel As MPR.Windows.Forms.Validation.CustomValidator
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
