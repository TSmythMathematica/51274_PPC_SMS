'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.DataQuality

Public Class EditAddress

#Region "Private fields"

    'Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing
    Private mobjAddress As Address = Nothing

    Private mblnIsShared As Boolean = False
    Private mblnReadOnly As Boolean = False

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

    Public Property Address As Address
        Get
            FillProperties()
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
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

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjAddress Is Nothing Then Exit Sub

        With mobjAddress
            SetSafeValue(.Address1, txtAddress1.Text)
            SetSafeValue(.Address2, txtAddress2.Text)
            SetSafeValue(.Address3, txtAddress3.Text)
            SetSafeValue(.Address4, txtAddress4.Text)
            SetSafeValue(.City, txtCity.Text)
            If Not cboState.SelectedState Is Nothing Then
                .State = cboState.SelectedState.State
            Else
                .State = cboState.Text
            End If
            SetSafeValue(.Facility1, txtFacility1.Text)
            SetSafeValue(.Facility2, txtFacility2.Text)
            SetSafeValue(.PostalCode, txtZip.Text)
            .AddressTypeID = cboAddressType.SelectedAddressTypeID
            .SourceTypeID = cboSourceType.SelectedSourceTypeID
            .SourceQualityID = cboSourceQuality.SelectedSourceQualityID
            .ReturnedMailReasonID = cboReturnedMail.SelectedReturnedMailReasonID
            'SetSafeValue(.AddressNotes, txtNotes.Text)
            '.AddressNotes = ViewNotes.SelectedAddress.AddressNotes
            SetSafeValue(.IsCleaned, chkIsCleaned.Checked)
            Try
                .Latitude = CDbl(txtLat.Text)
            Catch ex As Exception
                .Latitude = 0
            End Try
            Try
                .Longitude = CDbl(txtLon.Text)
            Catch ex As Exception
                .Longitude = 0
            End Try
        End With

        If chkBestPhysical.Checked AndAlso mobjAddress.IsValid Then
            Person.BestPhysicalAddress = mobjAddress
        ElseIf Person.BestPhysicalAddress IsNot Nothing AndAlso
               Person.BestPhysicalAddress.Equals(mobjAddress) Then
            Person.BestPhysicalAddress = Nothing
        End If
        If chkBestMailing.Checked AndAlso mobjAddress.IsValid Then
            Person.BestMailingAddress = mobjAddress
        ElseIf Person.BestMailingAddress IsNot Nothing AndAlso
               Person.BestMailingAddress.Equals(mobjAddress) Then
            Person.BestMailingAddress = Nothing
        End If
        If chkBestCheck.Checked AndAlso mobjAddress.IsValid Then
            Person.BestCheckAddress = mobjAddress
        ElseIf Person.BestCheckAddress IsNot Nothing AndAlso
               Person.BestCheckAddress.Equals(mobjAddress) Then
            Person.BestCheckAddress = Nothing
        End If
    End Sub

    Private Sub FillUserControl()

        If mobjAddress Is Nothing Then Exit Sub

        With mobjAddress
            txtAddress1.Text = GetSafeValue(.Address1)
            txtAddress2.Text = GetSafeValue(.Address2)
            txtAddress3.Text = GetSafeValue(.Address3)
            txtAddress4.Text = GetSafeValue(.Address4)
            txtCity.Text = GetSafeValue(.City)
            cboState.SelectedStateAbbreviation = GetSafeValue(.State)
            txtZip.Text = GetSafeValue(.PostalCode)
            txtFacility1.Text = GetSafeValue(.Facility1)
            txtFacility2.Text = GetSafeValue(.Facility2)
            cboAddressType.SelectedAddressTypeID = GetSafeValue(.AddressTypeID)
            cboSourceType.SelectedSourceTypeID = GetSafeValue(.SourceTypeID)
            cboSourceQuality.SelectedSourceQualityID = GetSafeValue(.SourceQualityID)
            cboReturnedMail.SelectedReturnedMailReasonID = GetSafeValue(.ReturnedMailReasonID)
            'txtNotes.Text = GetSafeValue(.AddressNotes)
            chkIsCleaned.Checked = GetSafeValue(.IsCleaned)
            txtLat.Text = CStr(GetSafeValue(.Latitude))
            txtLon.Text = CStr(GetSafeValue(.Longitude))
            'ViewNotes.SelectedAddress = mobjAddress
        End With
        chkIsCleaned.Enabled = Not chkIsCleaned.Checked
        btnMap.Enabled = chkIsCleaned.Checked

        SetSharedButton()

        If Person.BestPhysicalAddress Is Nothing OrElse
           (Person.Addresses.Count = 0 And mobjAddress.AddressID.IsNull) OrElse
           (Person.Addresses.Count = 1 And Not mobjAddress.AddressID.IsNull) Then
            chkBestPhysical.Checked = True
            chkBestPhysical.AutoCheck = False
        ElseIf mobjAddress Is Nothing Then
            chkBestPhysical.Checked = False
        Else
            chkBestPhysical.Checked = (Person.BestPhysicalAddress.Equals(mobjAddress))
        End If
        If Person.BestMailingAddress Is Nothing OrElse
           (Person.Addresses.Count = 0 And mobjAddress.AddressID.IsNull) OrElse
           (Person.Addresses.Count = 1 And Not mobjAddress.AddressID.IsNull) Then
            chkBestMailing.Checked = True
            chkBestMailing.AutoCheck = False
        ElseIf mobjAddress Is Nothing Then
            chkBestMailing.Checked = False
        Else
            chkBestMailing.Checked = (Person.BestMailingAddress.Equals(mobjAddress))
        End If
        If Person.BestCheckAddress Is Nothing Then
            chkBestCheck.Checked = False
        ElseIf mobjAddress Is Nothing Then
            chkBestCheck.Checked = False
        Else
            chkBestCheck.Checked = (Person.BestCheckAddress.Equals(mobjAddress))
        End If

        If Person.FullName.Length > 0 Then
            grpBest.Text = "'Best' address for " & GetSafeValue(Person.FirstName) & " " & GetSafeValue(Person.LastName)
        End If
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtAddress1.ReadOnly = blnReadOnly
        txtAddress2.ReadOnly = blnReadOnly
        txtAddress3.ReadOnly = blnReadOnly
        txtAddress4.ReadOnly = blnReadOnly
        txtCity.ReadOnly = blnReadOnly
        txtZip.ReadOnly = blnReadOnly
        txtFacility1.ReadOnly = blnReadOnly
        txtFacility2.ReadOnly = blnReadOnly

        cboState.Enabled = Not blnReadOnly
        If blnReadOnly = True Then
            cboState.BackColor = Color.Silver
            cboState.ForeColor = Color.Black
        Else
            cboState.BackColor = Color.White
            cboState.ForeColor = Color.Black
        End If
        cboAddressType.ReadOnly = blnReadOnly
        cboSourceType.ReadOnly = blnReadOnly
        cboSourceQuality.ReadOnly = blnReadOnly
        cboReturnedMail.ReadOnly = blnReadOnly
        'txtNotes.ReadOnly = blnReadOnly
    End Sub

    Private Sub SetSharedButton()

        btnShared.Visible = Project.AllowShared
        If IsShared Then
            btnShared.Text = "This address is shared with all case members"
            btnShared.Image = ImageList.Images("users.bmp")
        Else
            btnShared.Text = "This address is specific to this case member"
            btnShared.Image = ImageList.Images("user.bmp")
        End If
    End Sub

    Private Sub SetWarning()

        lblWarning.Visible = IsShared

        If mobjAddress.IsValid Then
            lblWarning.Text =
                "Note: Changing any information on this shared address will also apply those changes to all other members of this case."
        Else
            lblWarning.Text = "Note: Adding a shared address will add this address to all other members of this case."
        End If
    End Sub

    Private Function AddressValid() As Boolean

        Return _
            (txtZip.Text.Length > 0 Or (txtCity.Text.Length > 0 And cboState.SelectedStateAbbreviation.Length > 0)) And
            (txtAddress1.Text.Length > 0 Or txtAddress2.Text.Length > 0)
    End Function

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

    Private Sub cboState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboState.SelectedIndexChanged

        txtZip.AllowInternational = Not cboState.SelectedState.ValidateZip.IsTrue

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub


    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub

    Private Sub txtZip_Validated(sender As Object, e As EventArgs) Handles txtZip.Validated

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub

    Private Sub txtAddress1_TextChanged(sender As Object, e As EventArgs) Handles txtAddress1.TextChanged

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub

    Private Sub txtAddress2_TextChanged(sender As Object, e As EventArgs) Handles txtAddress2.TextChanged

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub

    Private Sub txtFacility1_TextChanged(sender As Object, e As EventArgs) Handles txtFacility1.TextChanged

        chkIsCleaned.Enabled = AddressValid()
        chkIsCleaned.Checked = False
    End Sub

    Private Sub chkIsCleaned_Click(sender As Object, e As EventArgs) Handles chkIsCleaned.Click

        If chkIsCleaned.Checked And Project.MelissaDataEnabled Then
            lblVerify.Visible = True
            lblVerify.Text = "Sending request..."
            lblVerify.Refresh()

            Me.Cursor = Cursors.WaitCursor

            'The dataquality class will log these values during cleaning. 
            'Default is 0 if we don't have values for some reason
            'These will be reset to actual values if they exist
            Dim caseId As Integer = 0
            Dim addressId As Integer = 0

            'If the addressID and CaseID exist, then pass them to the dataquality object to save status codes
            If Not Person.CaseID.IsNull Then
                caseId = Person.CaseID.Value
            End If

            If Not mobjAddress.AddressID.IsNull Then
                addressId = mobjAddress.AddressID.Value
            End If

            Dim servProvider As New ServiceProvider
            Dim obj As IDataquality = servProvider.getDataCleaner

            Dim dirtyAddress As New DQAddress
            Dim dirtyAddresses As New List(Of DQAddress)
            Dim processedAddresses As List(Of ProcessedAddress)
            Dim processedAddress As ProcessedAddress

            With dirtyAddress
                .Address = txtAddress1.Text
                .Address2 = txtAddress2.Text
                .caseid = caseId
                .id = addressId
                .City = txtCity.Text
                .State = cboState.SelectedStateAbbreviation
                If txtZip.Text.Length >= 5 Then
                    .Zip5 = txtZip.Text.Substring(0, 5)
                End If
                If txtZip.Text.Length >= 9 Then
                    .Plus4 = txtZip.Text.Substring(5, 4)
                End If
                .Company = txtFacility1.Text
            End With

            dirtyAddresses.Add(dirtyAddress)
            processedAddresses = obj.ProcessAddresses(dirtyAddresses)

            Cursor = Cursors.Default

            processedAddress = processedAddresses(0)

            With processedAddress
                txtAddress1.Text = .Address1
                txtAddress2.Text = .Address2
                If .Address2.Trim <> .Suite.Trim Then
                    If .Address2.Length + .Suite.Length < 60 Then
                        txtAddress2.Text = LTrim(.Address2 + " ") + .Suite
                    Else
                        txtAddress3.Text = .Suite
                    End If
                End If
                txtCity.Text = .City
                cboState.SelectedStateAbbreviation = .State

                If .Postalcode.Trim <> "" Then
                    If .Plus4 <> " " Then
                        txtZip.Text = .Postalcode + "-" + .Plus4
                    Else
                        txtZip.Text = .Postalcode
                    End If
                End If

                txtLat.Text = .Latitude
                txtLon.Text = .Longitude
            End With

            If processedAddress.isClean Then
                chkIsCleaned.Enabled = False
                chkIsCleaned.Checked = True
                lblVerify.Text = "Address has been cleaned"
            Else
                txtLat.Text = ""
                txtLon.Text = ""

                lblVerify.Text = processedAddress.Results.Description
                chkIsCleaned.Checked = False
            End If
        End If
    End Sub

    Private Sub chkIsCleaned_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsCleaned.CheckedChanged
        btnMap.Enabled = chkIsCleaned.Checked
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click

        Try
            Dim strURL As String = "https://maps.google.com/maps?q=" & txtLat.Text & "+" & txtLon.Text
            Process.Start(strURL)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mapping error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub chkBestAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkBestAll.CheckedChanged

        chkBestCheck.Checked = chkBestAll.Checked
        chkBestMailing.Checked = chkBestAll.Checked
        chkBestPhysical.Checked = chkBestAll.Checked
    End Sub

#End Region
End Class
