'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Data.BaseClasses
Imports MPR.SMS.DataQuality

Public Class EditPhone

#Region "Private fields"

    'Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing
    Private mobjPhone As Phone = Nothing

    Private mblnIsShared As Boolean = False
    Private mblnReadOnly As Boolean = False
    Private mblnPhoneRequired As Boolean = False
    Private mstrLastCleanPhone As String = ""

#End Region

#Region "Public Properties"

    'Public Property [Case]() As [Case]
    '    Get
    '        Return mobjCase
    '    End Get
    '    Set(ByVal value As [Case])
    '        mobjCase = value
    '    End Set
    'End Property

    Public Property Person As Person
        Get
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
        End Set
    End Property

    'gets/sets whether the Address will be shared or personal
    <DefaultValue(False)>
    Public Property IsShared As Boolean
        Get
            Return mblnIsShared
        End Get
        Set
            mblnIsShared = value
            SetSharedButton()
            SetWarning()
        End Set
    End Property

    Public Property Phone As Phone
        Get
            FillProperties()
            Return mobjPhone
        End Get
        Set
            mobjPhone = value
            FillUserControl()
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

    <DefaultValue(False)>
    Public Property PhoneRequired As Boolean
        Get
            Return mblnPhoneRequired
        End Get
        Set
            mblnPhoneRequired = value
            'txtPhone.Required = mblnPhoneRequired  'this causes the control to validate upon load, so instead it should be set in FillUserControl()
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjPhone Is Nothing Then Exit Sub

        With mobjPhone
            SetSafeValue(.PhoneNum, txtPhone.Text)
            SetSafeValue(.Extension, txtExt.Text)
            SetSafeValue(.TimeZoneCode, txtTZCode.Text)
            SetSafeValue(.DSTI, txtDSTI.Text)
            SetSafeValue(.IsInternational, chkInternational.Checked)
            SetSafeValue(.ListedTo, txtListedTo.Text)
            SetSafeValue(.Notes, txtNotes.Text)
            .PhoneTypeID = cboPhoneType.SelectedPhoneTypeID
            .PhoneTimeID = cboPhoneTime.SelectedPhoneTimeID
            .SourceTypeID = cboSourceType.SelectedSourceTypeID
            .SourceQualityID = cboSourceQuality.SelectedSourceQualityID
            SetSafeValue(.IsCleaned, chkIsCleaned.Checked)
            'SetSafeValue(.LastAttemptedOn, txtDateAttempted.Text)
            'SetSafeValue(.CreatedOn, txtDateAdded.Text)
        End With

        If chkBestPhone.Checked AndAlso mobjPhone.IsValid Then
            Person.BestPhone = mobjPhone
        ElseIf Person.BestPhone IsNot Nothing AndAlso
               Person.BestPhone.Equals(mobjPhone) Then
            Person.BestPhone = Nothing
        End If
    End Sub

    Private Sub FillUserControl()

        If mobjPhone Is Nothing Then Exit Sub

        With mobjPhone
            txtPhone.Text = GetSafeValue(.PhoneNum)
            txtExt.Text = GetSafeValue(.Extension)
            txtTZCode.Text = GetSafeValue(.TimeZoneCode)
            txtDSTI.Text = GetSafeValue(.DSTI)
            chkInternational.Checked = GetSafeValue(.IsInternational)
            txtListedTo.Text = GetSafeValue(.ListedTo)
            txtNotes.Text = GetSafeValue(.Notes)
            cboPhoneType.SelectedPhoneTypeID = GetSafeValue(.PhoneTypeID)
            cboPhoneTime.SelectedPhoneTimeID = GetSafeValue(.PhoneTimeID)
            cboSourceType.SelectedSourceTypeID = GetSafeValue(.SourceTypeID)
            cboSourceQuality.SelectedSourceQualityID = GetSafeValue(.SourceQualityID)
            txtDateAttempted.Text = GetSafeDate(.LastAttemptedOn)
            txtDateAdded.Text = GetSafeDate(.CreatedOn)
            chkIsCleaned.Checked = GetSafeValue(.IsCleaned)
            Select Case GetSafeValue(.TCPAPhoneType)
                Case "U"
                    txtTCPAPhoneType.Text = "Unknown"
                Case "L"
                    txtTCPAPhoneType.Text = "Landline"
                Case "C"
                    txtTCPAPhoneType.Text = "Cell"
            End Select
            If Not .TCPALastModifiedOn.IsNull Then
                txtTCPADate.Text = .TCPALastModifiedOn.Value.ToShortDateString()
            End If
        End With
        txtPhone.Required = mblnPhoneRequired
        chkIsCleaned.Enabled = Not chkIsCleaned.Checked
        If chkIsCleaned.Checked Then
            mstrLastCleanPhone = txtPhone.Text
        End If

        SetSharedButton()

        If Person.BestPhone Is Nothing OrElse
           (Person.Phones.Count = 0 And mobjPhone.PhoneID.IsNull) OrElse
           (Person.Phones.Count = 1 And Not mobjPhone.PhoneID.IsNull) Then
            chkBestPhone.Checked = True
            chkBestPhone.AutoCheck = False
        ElseIf mobjPhone Is Nothing Then
            chkBestPhone.Checked = False
        Else
            chkBestPhone.Checked = (Person.BestPhone.Equals(mobjPhone))
        End If
        If Person.FullName.Length > 0 Then
            chkBestPhone.Text = "This is the 'best' phone for " & GetSafeValue(Person.FirstName) & " " &
                                GetSafeValue(Person.LastName)
        End If
        txtPhone.Select()
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtPhone.ReadOnly = blnReadOnly
        txtExt.ReadOnly = blnReadOnly
        txtTZCode.ReadOnly = blnReadOnly
        txtDSTI.ReadOnly = blnReadOnly
        chkInternational.AutoCheck = Not blnReadOnly
        txtListedTo.ReadOnly = blnReadOnly
        txtNotes.ReadOnly = blnReadOnly

        cboPhoneType.ReadOnly = blnReadOnly
        cboPhoneTime.ReadOnly = blnReadOnly
        cboSourceType.ReadOnly = blnReadOnly
        cboSourceQuality.ReadOnly = blnReadOnly

        'txtDateAttempted.ReadOnly = blnReadOnly
        'txtDateAdded.ReadOnly = blnReadOnly
    End Sub

    Private Sub SetSharedButton()

        btnShared.Visible = Project.AllowShared
        If IsShared Then
            btnShared.Text = "This phone is shared with all case members"
            btnShared.Image = ImageList.Images("users.bmp")
        Else
            btnShared.Text = "This phone is specific to this case member"
            btnShared.Image = ImageList.Images("user.bmp")
        End If
    End Sub

    Private Sub SetWarning()

        lblWarning.Visible = IsShared

        If mobjPhone.IsValid Then
            lblWarning.Text =
                "Note: Changing any information on this shared phone will also apply those changes to all other members of this case."
        Else
            lblWarning.Text = "Note: Adding a shared phone will add this phone to all other members of this case."
        End If
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnShared_Click(sender As Object, e As EventArgs) Handles btnShared.Click

        IsShared = Not IsShared
    End Sub

    Private Sub chkInternational_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkInternational.CheckedChanged

        txtPhone.AllowInternational = chkInternational.Checked
    End Sub

    Private Sub txtPhone_Validated(sender As Object, e As EventArgs) Handles txtPhone.Validated

        If chkInternational.Checked = False And
           txtPhone.Text.Length.Equals(10) And
           txtTZCode.Text.Length.Equals(0) Then

            'look up the Time Zone by Area Code.
            Dim obj As New TlkpTimeZone
            obj.ConnectionString = Project.ConnectionString
            obj.AreaCode = txtPhone.Text.Substring(0, 3)
            Dim dt As DataTable = obj.SelectOne()
            Dim dr As DataRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                txtTZCode.Text = dr("Code").ToString
                txtDSTI.Text = dr("Daylight").ToString
            End If
        End If
        If Not txtPhone.Text.Equals(mstrLastCleanPhone) Then
            mstrLastCleanPhone = txtPhone.Text
            chkIsCleaned.Checked = False
        End If
        chkIsCleaned.Enabled = Not chkIsCleaned.Checked
    End Sub

    Private Sub chkIsCleaned_Clicked(sender As Object, e As EventArgs) Handles chkIsCleaned.Click

        If chkIsCleaned.Checked And Project.MelissaDataEnabled Then
            lblVerify.Visible = True
            lblVerify.Text = "Sending request..."
            lblVerify.Refresh()

            'The dataquality class will log these values during cleaning. 
            'Default is 0 if we don't have values for some reason
            'These will be reset to actual values if they exist

            Dim _CaseID As Integer = 0
            Dim _PhoneID As Integer = 0

            'If the addressID and CaseID exist, then pass them to the dataquality object to save status codes
            If Not Person.CaseID.IsNull Then
                _CaseID = CInt(Person.CaseID)

            End If

            If Not mobjPhone.PhoneID.IsNull Then
                _PhoneID = CInt(mobjPhone.PhoneID)
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim ServProvider As New ServiceProvider
            Dim obj As IDataquality = ServProvider.getDataCleaner
            Dim DirtyPhone As New DQPhone
            Dim DirtyPhones As New List(Of DQPhone)
            Dim ProcessedPhone As ProcessedPhone
            Dim ProcessedPhones As List(Of ProcessedPhone)


            DirtyPhone.Telephone = txtPhone.Text
            DirtyPhones.Add(DirtyPhone)

            ProcessedPhones = obj.ProcessPhones(DirtyPhones)
            ProcessedPhone = ProcessedPhones(0)
            Me.Cursor = Cursors.Default


            Dim strPhone As String = ProcessedPhone.NewAreaCode
            If strPhone = " " Then strPhone = ProcessedPhone.AreaCode
            strPhone &= ProcessedPhone.Prefix & ProcessedPhone.Suffix
            txtPhone.Text = strPhone
            txtTZCode.Text = ProcessedPhone.TimezoneCode
            chkIsCleaned.Enabled = False
            mstrLastCleanPhone = txtPhone.Text

            If ProcessedPhone.isClean Then
                lblVerify.Text = "Phone has been cleaned."
            Else

                lblVerify.Text = ProcessedPhone.Results.Description
                chkIsCleaned.Checked = False
            End If
        End If
    End Sub

#End Region
End Class
