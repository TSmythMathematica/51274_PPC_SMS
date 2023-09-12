Imports MPR.SMS.Data

Public Class ucValidation

#Region "Private Variables"

    Private mobjCaseValidation As CaseValidation = Nothing

    Private mblnInit As Boolean = False
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Public Properties"

    Public Shadows Property CaseValidation() As CaseValidation
        Get
            FillProperties()
            Return mobjCaseValidation
        End Get
        Set(ByVal value As CaseValidation)
            mobjCaseValidation = value
            FillUserControl()
        End Set
    End Property

    <System.ComponentModel.DefaultValue(False)>
    Public Property [ReadOnly]() As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set(ByVal value As Boolean)
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjCaseValidation IsNot Nothing AndAlso
           Not GetSafeValue(mobjCaseValidation.CaseID).Equals(0) Then
            Dim frm As New SMS.UserControls.frmDisplayHistory(mobjCaseValidation)
            frm.Width = Me.Parent.Width
            If System.Windows.Forms.Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Drawing.Point(Me.ParentForm.Left + Me.Parent.Left + 4,
                                                 System.Windows.Forms.Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Drawing.Point(Me.ParentForm.Left + Me.Parent.Left + 4,
                                                 System.Windows.Forms.Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjCaseValidation Is Nothing OrElse mblnInit Then Exit Sub

        With mobjCaseValidation
            If IsDate(txtDate.Text) OrElse txtDate.Text = "" Then
                SetSafeValue(.ValidationStatusDate, txtDate.Text)
            End If
            .ValidationStatusID = cboStatus.SelectedValidationStatusID

            SetSafeValue(.Notes, txtNotes.Text)
            SetSafeValue(.IsValidate, chkValidate.Checked)
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjCaseValidation Is Nothing Then Exit Sub

        mblnInit = True
        With mobjCaseValidation
            txtDate.Text = GetSafeDate(.ValidationStatusDate)
            cboStatus.SelectedValidationStatus = New ValidationStatus(GetSafeValue(.ValidationStatusID))

            txtNotes.Text = GetSafeValue(.Notes)
            chkValidate.Checked = GetSafeValue(.IsValidate)
        End With
        EnableUserControl(mblnReadOnly)

        mblnInit = False
    End Sub

    Private Sub EnableUserControl(ByVal blnReadOnly As Boolean)

        txtDate.ReadOnly = (Not chkValidate.Checked Or blnReadOnly)
        cboStatus.ReadOnly = txtDate.ReadOnly
        txtNotes.ReadOnly = blnReadOnly
        chkValidate.AutoCheck = Not blnReadOnly

        Me.TabStop = Not blnReadOnly
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(ByVal sender As Object, ByVal objCaseValidation As CaseValidation)

#End Region

#Region "Event Handlers"

    Private Sub ucValidation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.DesignMode Then

        End If
    End Sub

    Private Sub chkValidate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkValidate.CheckedChanged

        txtDate.ReadOnly = (Not chkValidate.Checked Or [ReadOnly])
        cboStatus.ReadOnly = txtDate.ReadOnly
        'lblDate.Enabled = txtDate.ReadOnly
        'lblStatus.Enabled = txtDate.ReadOnly

        If Not Me.DesignMode Then
            If chkValidate.Checked <> GetSafeValue(mobjCaseValidation.IsValidate) Then
                RaiseEvent OnChanged(Me, CaseValidation)
            End If
        End If
    End Sub

    'Private Sub txtDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged

    '    If Not Me.DesignMode Then
    '        If txtDate.Text <> GetSafeDate(mobjCaseValidation.ValidationStatusDate) Then
    '            RaiseEvent OnChanged(Me, CaseValidation)
    '        End If
    '    End If
    'End Sub

    Private Sub txtNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNotes.TextChanged

        If Not Me.DesignMode Then
            If txtNotes.Text <> GetSafeValue(mobjCaseValidation.Notes) Then
                RaiseEvent OnChanged(Me, CaseValidation)
            End If
        End If
    End Sub

    Private Sub _SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboStatus.SelectedIndexChanged

        If Not Me.DesignMode Then
            If cboStatus.SelectedValidationStatusID <> GetSafeValue(mobjCaseValidation.ValidationStatusID) Then
                RaiseEvent OnChanged(Me, CaseValidation)
            End If
        End If
    End Sub

#End Region
End Class
