'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Windows.Forms
Imports MPR.SMS.Data

Public Class frmDemo
    Inherits Form

    Private Sub btnParseName_Click(sender As Object, e As EventArgs) Handles btnParseName.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ServProvider As New ServiceProvider
        Dim obj As IDataquality = ServProvider.getDataCleaner
        Dim DirtyName As New DQName
        Dim DirtyNames As New List(Of DQName)
        Dim ProcessedName As ProcessedName
        Dim ProcessedNames As List(Of ProcessedName)

        DirtyName.Fullname = txtUnparsed.Text
        DirtyNames.Add(DirtyName)
        ProcessedNames = obj.ProcessNames(DirtyNames)
        ProcessedName = ProcessedNames(0)
        Me.Cursor = Cursors.Default

        With ProcessedName
            txtResult.Text = "StatusCode=" + .Results.Code + Environment.NewLine +
                             "StatusDesc=" + .Results.Description + Environment.NewLine +
                             "Prefix=" + .Prefix + Environment.NewLine +
                             "First=" + .First + Environment.NewLine +
                             "Middle=" + .Middle + Environment.NewLine +
                             "Last=" + .Last + Environment.NewLine +
                             "Suffix=" + .Suffix + Environment.NewLine +
                             "Gender=" + .Gender + Environment.NewLine
        End With
    End Sub

    Private Sub btnParseAddress_Click(sender As Object, e As EventArgs) Handles btnParseAddress.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ServProvider As New ServiceProvider
        Dim obj As IDataquality = ServProvider.getDataCleaner
        Dim DirtyAddress As New DQAddress
        Dim DirtyAddresses As New List(Of DQAddress)
        Dim ProcessedAddresses As List(Of ProcessedAddress)
        Dim ProcessedAddress As ProcessedAddress

        With DirtyAddress
            .Address = txtAddress.Text
            .City = txtCity.Text
            .State = txtState.Text
            .Zip5 = txtZip.Text
        End With
        DirtyAddresses.Add(DirtyAddress)
        ProcessedAddresses = obj.ProcessAddresses(DirtyAddresses)

        ProcessedAddress = ProcessedAddresses(0)

        With ProcessedAddress

            txtResult.Text = "StatusCode=" + .Results.Code + Environment.NewLine +
                             "StatusDesc=" + .Results.Description + Environment.NewLine +
                             "Company=" + .Company + Environment.NewLine +
                             "Street1=" + .Address1 + Environment.NewLine +
                             "Street2=" + .Address2 + Environment.NewLine +
                             "Suite=" + .Suite + Environment.NewLine +
                             "City=" + .City + Environment.NewLine +
                             "State=" + .State + Environment.NewLine +
                             "Zip=" + .Postalcode + Environment.NewLine +
                             "Latitude=" + .Latitude + Environment.NewLine +
                             "Longitude=" + .Longitude + Environment.NewLine +
                             "DeliveryPointCode=" + .DeliveryPointCode

        End With
    End Sub

    Private Sub btnPhone_Click(sender As Object, e As EventArgs) Handles btnPhone.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ServProvider As New ServiceProvider
        Dim obj As IDataquality = ServProvider.getDataCleaner
        Dim DirtyPhone As New DQPhone
        Dim DirtyPhones As New List(Of DQPhone)
        Dim ProcessedPhone As ProcessedPhone
        Dim ProcessedPhones As List(Of ProcessedPhone)

        DirtyPhone.Telephone = txtUnparsed.Text
        DirtyPhones.Add(DirtyPhone)

        ProcessedPhones = obj.ProcessPhones(DirtyPhones)
        ProcessedPhone = ProcessedPhones(0)
        Me.Cursor = Cursors.Default

        With ProcessedPhone
            txtResult.Text = "StatusCode=" + .Results.Code + Environment.NewLine +
                             "StatusDesc=" + .Results.Description + Environment.NewLine +
                             "AreaCode=" + .AreaCode + Environment.NewLine +
                             "Prefix=" + .Prefix + Environment.NewLine +
                             "Suffix=" + .Suffix + Environment.NewLine +
                             "New AreaCode=" + .NewAreaCode + Environment.NewLine +
                             "TZCode=" + .TimezoneCode + Environment.NewLine +
                             "TZ=" + .Timezone + Environment.NewLine
        End With
    End Sub


    Private Sub btnTCPALookup_Click(sender As Object, e As EventArgs) Handles btnTCPALookup.Click

        txtResult.Text = TCPAPhoneLookup.GetPhoneType(txtTCPAPhone.Text)
    End Sub
End Class