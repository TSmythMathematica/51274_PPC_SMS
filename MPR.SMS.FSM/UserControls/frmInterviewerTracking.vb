Imports MPR.SMS.Data
Imports System.Drawing

Public Class frmInterviewerTracking

#Region "Private Variables"

    Private mobjInterviewer As Interviewer
    Private mobjSelectedTracking As InterviewerTracking

#End Region

#Region "Constructors"

    Public Sub New(ByVal objInterviewer As interviewer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjInterviewer = objInterviewer

        RefreshView(mobjInterviewer)
        Me.Text = "Interviewer Tracking - " & mobjInterviewer.FullName
    End Sub

#End Region

#Region "Private Methods"

    Private Sub RefreshView(ByVal objInterviewer As Interviewer)

        Cursor = Cursors.WaitCursor
        lvInterviewerTrackings.EmptyMessage = "Retrieving records, please wait..."

        lvInterviewerTrackings.Items.Clear()

        lvInterviewerTrackings.ColumnSorter.SortColumn = 0
        lvInterviewerTrackings.ColumnSorter.Order = SortOrder.Ascending

        lvInterviewerTrackings.Tag = objInterviewer

        'set column types
        lvInterviewerTrackings.ColumnType(0) = SortType.DateCompare
        lvInterviewerTrackings.ColumnType(1) = SortType.DateCompare
        lvInterviewerTrackings.ColumnType(2) = SortType.NumericCompare
        lvInterviewerTrackings.ColumnType(3) = SortType.NumericCompare

        'fill the list
        For Each objTracking As InterviewerTracking In objInterviewer.InterviewerTrackings

            Dim lvi As ListViewItem

            lvi = lvInterviewerTrackings.Items.Add(GetSafeDate(objTracking.DateReported))
            lvi.Tag = objTracking

            lvi.SubItems.Add(GetSafeDate(objTracking.WeekEnd))

            lvi.SubItems.Add(Math.Round(GetSafeValue(objTracking.Hours), 2).ToString)
            lvi.SubItems.Add(Math.Round(GetSafeValue(objTracking.TotalExpenses), 2).ToString)
            If GetSafeValue(objTracking.Notes).Length > 50 Then
                lvi.SubItems.Add(GetSafeValue(objTracking.Notes).Substring(0, 50) & "...")
            Else
                lvi.SubItems.Add(GetSafeValue(objTracking.Notes))
            End If

        Next
        lvInterviewerTrackings.EmptyMessage = "There are currently no tracking records for this interviewer."

        ' Auto resize list view columns
        For Each ch As ColumnHeader In lvInterviewerTrackings.Columns()
            ch.Width = - 2
        Next

        'fill the WeekEnding combo box
        cboWeekEnd.Items.Clear()
        cboWeekEnd.DisplayMember = "DisplayWeek"

        Dim objWeeks As InterviewWeeks = New InterviewWeeks
        For Each objWeek As InterviewWeek In objWeeks
            cboWeekEnd.Items.Add(objWeek)
        Next

        ClearForm()

        Cursor = Cursors.Default
    End Sub

    Private Sub ClearForm()

        txtDateReported.Text = Now().ToShortDateString
        cboWeekEnd.SelectedIndex = - 1
        txtHours.Text = "0"
        txtHoursAdministrative.Text = "0"
        txtHoursInterviewing.Text = "0"
        txtHoursLocating.Text = "0"
        txtHoursTraveling.Text = "0"
        txtMileage.Text = "0"
        txtMileageExpense.Text = "0"
        txtExpenses.Text = "0"
        txtCarRental.Text = "0"
        txtAirTravel.Text = "0"
        txtTotalExpenses.Text = "0"
        txtNotes.Text = ""
        cbSuppliesFedEx.Checked = False
        cbSuppliesExpRep.Checked = False
        cbSuppliesWYWO.Checked = False
        cbSuppliesBrochure.Checked = False
        cbSuppliesChecklist.Checked = False
        txtSuppliesOther.Text = ""

        lblMileage.Text = "Mileage Expense (miles * " & CStr(mobjInterviewer.MileageRate) & ")"
        lblSuppliesSent.Text = ""

        btnSave.Text = "Add"
        btnCancel.Text = "Close"
    End Sub

    Private Sub FillForm(ByVal objTracking As InterviewerTracking)

        With objTracking
            txtDateReported.Text = GetSafeDate(.DateReported)
            SelectedWeekEnd = .WeekEnd

            txtHours.Text = Math.Round(GetSafeValue(.Hours), 2).ToString
            txtHoursAdministrative.Text = Math.Round(GetSafeValue(.HoursAdministrative), 2).ToString
            txtHoursInterviewing.Text = Math.Round(GetSafeValue(.HoursInterviewing), 2).ToString
            txtHoursLocating.Text = Math.Round(GetSafeValue(.HoursLocating), 2).ToString
            txtHoursTraveling.Text = Math.Round(GetSafeValue(.HoursTraveling), 2).ToString
            txtMileage.Text = Math.Round(GetSafeValue(.Mileage), 2).ToString
            txtMileageExpense.Text = Math.Round(GetSafeValue(.MileageExpense), 2).ToString
            txtExpenses.Text = Math.Round(GetSafeValue(.Expenses), 2).ToString
            txtCarRental.Text = Math.Round(GetSafeValue(.CarRental), 2).ToString
            txtAirTravel.Text = Math.Round(GetSafeValue(.AirTravel), 2).ToString
            txtTotalExpenses.Text = Math.Round(GetSafeValue(.TotalExpenses), 2).ToString _
            'CDbl(txtExpenses.Text) + CDbl(txtMileageExpense.Text) + CDbl(txtCarRental.Text) + CDbl(txtAirTravel.Text)
            txtNotes.Text = GetSafeValue(.Notes)
            cbSuppliesFedEx.Checked = GetSafeValue(.SuppliesFedEx)
            cbSuppliesExpRep.Checked = GetSafeValue(.SuppliesExpRep)
            cbSuppliesWYWO.Checked = GetSafeValue(.SuppliesWYWO)
            cbSuppliesBrochure.Checked = GetSafeValue(.SuppliesBrochure)
            cbSuppliesChecklist.Checked = GetSafeValue(.SuppliesChecklist)
            txtSuppliesOther.Text = GetSafeValue(.SuppliesOther)
            If Not .SuppliesPrintedOn.IsNull Then
                lblSuppliesSent.Text = "Supplies were sent by " & vbCrLf & GetSafeValue(.SuppliesPrintedBy) & vbCrLf &
                                       "on " & GetSafeDate(.SuppliesPrintedOn)
            Else
                lblSuppliesSent.Text = ""
            End If
        End With

        btnSave.Text = "Update"
        btnCancel.Text = "Cancel"
    End Sub

    Private Property SelectedWeekEnd() As SqlTypes.SqlDateTime
        Get
            If cboWeekEnd.SelectedIndex = - 1 Then
                Return New SqlTypes.SqlDateTime()
            Else
                Return CType(cboWeekEnd.Items(cboWeekEnd.SelectedIndex), InterviewWeek).WeekEnd
            End If
        End Get
        Set(ByVal value As SqlTypes.SqlDateTime)
            cboWeekEnd.SelectedIndex = - 1
            If Not value.IsNull Then
                Dim i As Integer = 0
                For Each objWeek As InterviewWeek In cboWeekEnd.Items
                    If GetSafeDate(objWeek.WeekEnd) = GetSafeDate(value) Then
                        cboWeekEnd.SelectedIndex = i
                        Exit For
                    End If
                    i += 1
                Next
            End If
        End Set
    End Property

    Private Property SelectedWeekBegin() As SqlTypes.SqlDateTime
        Get
            If cboWeekEnd.SelectedIndex = - 1 Then
                Return New SqlTypes.SqlDateTime()
            Else
                Return CType(cboWeekEnd.Items(cboWeekEnd.SelectedIndex), InterviewWeek).WeekBeg
            End If
        End Get
        Set(ByVal value As SqlTypes.SqlDateTime)
            cboWeekEnd.SelectedIndex = - 1
            If Not value.IsNull Then
                Dim i As Integer = 0
                For Each objWeek As InterviewWeek In cboWeekEnd.Items
                    If GetSafeDate(objWeek.WeekBeg) = GetSafeDate(value) Then
                        cboWeekEnd.SelectedIndex = i
                        Exit For
                    End If
                    i += 1
                Next
            End If
        End Set
    End Property

    Private Sub TotalExpenses()

        If IsNumeric(txtMileageExpense.Text) AndAlso
           IsNumeric(txtExpenses.Text) AndAlso
           IsNumeric(txtCarRental.Text) AndAlso
           IsNumeric(txtAirTravel.Text) Then

            txtMileage.Text =
                Math.Round(CDbl(txtMileageExpense.Text)/GetSafeValue(mobjInterviewer.MileageRate), 2).ToString

            txtTotalExpenses.Text = CStr(CDbl(txtExpenses.Text) +
                                         CDbl(txtMileageExpense.Text) +
                                         CDbl(txtCarRental.Text) +
                                         CDbl(txtAirTravel.Text))
        Else
            FormValidator.Validate()
        End If
    End Sub

    Private Sub TotalHours()
        If IsNumeric(txtHoursAdministrative.Text) AndAlso
           IsNumeric(txtHoursInterviewing.Text) AndAlso
           IsNumeric(txtHoursTraveling.Text) AndAlso
           IsNumeric(txtHoursLocating.Text) Then

            txtHours.Text = CStr(CDbl(txtHoursAdministrative.Text) +
                                 CDbl(txtHoursInterviewing.Text) +
                                 CDbl(txtHoursTraveling.Text) +
                                 CDbl(txtHoursLocating.Text))
        Else
            FormValidator.Validate()
        End If
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim blnAdd As Boolean = btnSave.Text = "Add"

        Dim blnOK As Boolean = False
        FormValidator.Validate()
        If FormValidator.IsValid() Then
            blnOK = True

            'check that there isn't already a record for this week ending date
            If blnAdd Then
                For Each obj As InterviewerTracking In mobjInterviewer.InterviewerTrackings
                    If obj.WeekEnd = SelectedWeekEnd Then
                        MessageBox.Show(
                            "The interview week you have specified is already being used.  You may edit this record by double-clicking it from the list above.",
                            "Track Interviewer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        blnOK = False
                        Exit For
                    End If
                Next
            End If
        Else
            blnOK = False
        End If

        If blnOK Then
            If blnAdd Then
                mobjSelectedTracking = New InterviewerTracking()
                mobjSelectedTracking.InterviewerID = mobjInterviewer.InterviewerID
            End If

            With mobjSelectedTracking
                SetSafeValue(.DateReported, txtDateReported.Text)
                If Not SelectedWeekEnd.IsNull Then
                    .WeekEnd = SelectedWeekEnd
                    .WeekBeg = SelectedWeekBegin
                End If
                SetSafeValue(.Hours, txtHours.Text)
                SetSafeValue(.HoursAdministrative, txtHoursAdministrative.Text)
                SetSafeValue(.HoursInterviewing, txtHoursInterviewing.Text)
                SetSafeValue(.HoursLocating, txtHoursLocating.Text)
                SetSafeValue(.HoursTraveling, txtHoursTraveling.Text)
                SetSafeValue(.Mileage, txtMileage.Text)
                SetSafeValue(.MileageExpense, txtMileageExpense.Text)
                SetSafeValue(.Expenses, txtExpenses.Text)
                SetSafeValue(.CarRental, txtCarRental.Text)
                SetSafeValue(.AirTravel, txtAirTravel.Text)
                SetSafeValue(.Notes, txtNotes.Text)
                SetSafeValue(.SuppliesFedEx, cbSuppliesFedEx.Checked)
                SetSafeValue(.SuppliesExpRep, cbSuppliesExpRep.Checked)
                SetSafeValue(.SuppliesWYWO, cbSuppliesWYWO.Checked)
                SetSafeValue(.SuppliesBrochure, cbSuppliesBrochure.Checked)
                SetSafeValue(.SuppliesChecklist, cbSuppliesChecklist.Checked)
                SetSafeValue(.SuppliesOther, txtSuppliesOther.Text)
            End With

            'insert or update the record within the collection
            mobjInterviewer.InterviewerTrackings.ModifyObjectInCollection(mobjSelectedTracking)

            mobjInterviewer.Update()

            RefreshView(mobjInterviewer)

        End If
    End Sub

    Private Sub lvInterviewerTrackings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles lvInterviewerTrackings.DoubleClick

        If lvInterviewerTrackings.SelectedItems.Count = 1 Then
            mobjSelectedTracking = CType(lvInterviewerTrackings.SelectedItems(0).Tag, InterviewerTracking)

            FillForm(mobjSelectedTracking)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If btnCancel.Text = "Cancel" Then
            ClearForm()
        Else
            Close()
        End If
    End Sub

    Private Sub txtExpenses_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpenses.Leave
        TotalExpenses()
    End Sub

    Private Sub txtMileageExpense_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtMileageExpense.Leave
        TotalExpenses()
    End Sub

    Private Sub txtCarRental_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtCarRental.Leave
        TotalExpenses()
    End Sub

    Private Sub txtAirTravel_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtAirTravel.Leave
        TotalExpenses()
    End Sub

    Private Sub txtHoursAdministrative_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtHoursAdministrative.Leave
        TotalHours()
    End Sub

    Private Sub txtHoursInterviewing_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtHoursInterviewing.Leave
        TotalHours()
    End Sub

    Private Sub txtHoursLocating_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtHoursLocating.Leave
        TotalHours()
    End Sub

    Private Sub txtHoursTraveling_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtHoursTraveling.Leave
        TotalHours()
    End Sub

#Region " Validators"

    Private Sub ValidatorNotes_Validating(ByVal sender As System.Object,
                                          ByVal e As _
                                             MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorNotes.Validating

        e.Valid = (ValidatorNotes.ControlToValidate.Text.Length > 0)
    End Sub

    Private Sub ValidatorWeek_Validating(ByVal sender As System.Object,
                                         ByVal e As _
                                            MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorWeek.Validating

        e.Valid = (ValidatorWeek.ControlToValidate.Text.Length > 0)
    End Sub

    Private Sub ValidatorTotal_Validating(ByVal sender As System.Object,
                                          ByVal e As _
                                             MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorTotal.Validating

        e.Valid = IsNumeric(ValidatorTotal.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorAdmin_Validating(ByVal sender As System.Object,
                                          ByVal e As _
                                             MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorAdmin.Validating

        e.Valid = IsNumeric(ValidatorAdmin.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorInterviewing_Validating(ByVal sender As System.Object,
                                                 ByVal e As _
                                                    MPR.Windows.Forms.Validation.CustomValidator.
                                                    ValidatingCancelEventArgs) Handles ValidatorInterviewing.Validating

        e.Valid = IsNumeric(ValidatorInterviewing.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorLocating_Validating(ByVal sender As System.Object,
                                             ByVal e As _
                                                MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorLocating.Validating

        e.Valid = IsNumeric(ValidatorLocating.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorTraveling_Validating(ByVal sender As System.Object,
                                              ByVal e As _
                                                 MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorTraveling.Validating

        e.Valid = IsNumeric(ValidatorTraveling.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorOtherExp_Validating(ByVal sender As System.Object,
                                             ByVal e As _
                                                MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorOtherExp.Validating

        e.Valid = IsNumeric(ValidatorOtherExp.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorMileageExp_Validating(ByVal sender As System.Object,
                                               ByVal e As _
                                                  MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorMileageExp.Validating

        e.Valid = IsNumeric(ValidatorMileageExp.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorCarRental_Validating(ByVal sender As System.Object,
                                              ByVal e As _
                                                 MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorCarRental.Validating

        e.Valid = IsNumeric(ValidatorCarRental.ControlToValidate.Text)
    End Sub

    Private Sub ValidatorAirTravel_Validating(ByVal sender As System.Object,
                                              ByVal e As _
                                                 MPR.Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorAirTravel.Validating

        e.Valid = IsNumeric(ValidatorAirTravel.ControlToValidate.Text)
    End Sub

#End Region

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
        BitBlt(dc2, 0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height, dc1, 0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object,
                                         ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
        Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Private Sub PrintButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        CaptureScreen()
        PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.ShowDialog()
    End Sub

#End Region
End Class