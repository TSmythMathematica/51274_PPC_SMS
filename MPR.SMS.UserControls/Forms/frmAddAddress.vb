'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Imports MPR.SMS.Data

Public Class frmAddAddress
    Inherits Form

    Friend WithEvents AddAddress As AddAddress

#Region "Private Variables"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjSelPerson As Person     'Selected Person
    Private mblnEditable As Boolean = True
    Private mobjaddress As Address
    Private ReadOnly mboolBestCheck As Boolean
    Private ReadOnly mboolBestMail As Boolean
    Private ReadOnly mboolBestPhys As Boolean
    Private ReadOnly mobjDocument As Document

#End Region

#Region "Constructors"

    Public Sub New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StartPosition = FormStartPosition.CenterScreen
    End Sub


    Public Sub New(objCase As [Case], objPerson As Person,
                   boolBestCheck As Boolean, boolBestMail As Boolean, boolBestPhys As Boolean,
                   Document As Document)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjSelPerson = objPerson

        lblPersonName.Text = "Sample Member:  " + mobjSelPerson.FullName

        DisplayAddress(objCase, objPerson)

        Me.mboolBestCheck = boolBestCheck
        Me.mboolBestMail = boolBestMail
        Me.mboolBestPhys = boolBestPhys
        Me.mobjDocument = Document

        StartPosition = FormStartPosition.CenterScreen
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayAddress(objCase As [Case], objPerson As Person)
        AddAddress.Address = New Address(objCase)
        AddAddress.Person = objPerson
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'Dim objNewAddress As Address = AddAddress.Address  'Address is cleaned through FillProperties  ' 03/09/2021 WJ: commented out to avoid adding duplicate address records at the case level before any validation
        Dim objNewAddress As Address = Nothing
        Dim msgText As String = String.Empty
        Dim msgCaption As String = String.Empty

        If Not AddAddress.chkIsCleaned.Checked Then
            Dim dlgResult As DialogResult = DialogResult.No
            dlgResult = MessageBox.Show("There was an error in cleaning. Do you want to edit the address before saving?",
                                        Project.ShortName & " – Add Address?", MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If dlgResult = DialogResult.Yes Then
                Exit Sub
            End If
        End If

        If Not AddAddress.AddressValid Then
            MessageBox.Show("Please enter Address1, City, State, and Zip.", Me.Text, MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            Exit Sub
        End If

        '03/09/2021 WJ: added Duplicate address checking after validating the address
        AddAddress.Person = mobjSelPerson    ' call here to avoid adding duplicate address records at the case level
        If AddAddress.AddressDuplicate Then
            msgText = "The Address you have entered already exists for this MPRID: " & mobjSelPerson.MPRID.ToString & " in SMS. So you cannot add this address. Please check the addresses for this MPRID in SMS."
            msgCaption = Project.ShortName & " - Duplicate Address!!"
            MessageBox.Show(msgText, msgCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        objNewAddress = AddAddress.Address  ' call here to avoid adding duplicate address records at the case level
        '03/09/2021 WJ

        objNewAddress.Person = mobjSelPerson
        objNewAddress.SourceTypeID = GetSafeValue(Data.Enumerations.SourceType.PostOffice)

        Dim mystring As String = objNewAddress.Address1.ToString

        If mystring.Contains("P.O. ") Or mystring.Contains("PO ") Then
            If mboolBestMail = True Then
                objNewAddress.Person.BestMailingAddress = objNewAddress
            End If
            If mboolBestCheck = True Then
                objNewAddress.Person.BestCheckAddress = objNewAddress
            End If
        Else
            If mboolBestMail = True Then
                objNewAddress.Person.BestMailingAddress = objNewAddress
            End If
            If mboolBestCheck = True Then
                objNewAddress.Person.BestCheckAddress = objNewAddress
            End If
            If mboolBestPhys = True Then
                objNewAddress.Person.BestPhysicalAddress = objNewAddress
            End If
        End If

        mobjCase.Addresses.Add(objNewAddress)
        mobjCase.Update()

        If CBool(mobjDocument.DocumentType.IsForwardingAddressRemail) Then
            Dim objNewDoc As New Document(mobjCase, mobjDocument.DocumentType)
            With objNewDoc
                .PersonHistory = mobjSelPerson.PersonHistory
                .AddressHistory = objNewAddress.AddressHistory
                .DocumentStatusID = 1
                .InstrumentID = mobjDocument.InstrumentID
            End With
            mobjCase.Documents.Add(objNewDoc)
            mobjCase.Update()

        End If


        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

End Class